using InsuranceClaimRepository.Models;
using log4net.Repository;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Linq;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace InsuranceClaimWebApi
{
    public class Program
    {
        private static void ListenForIntegrationEvents()
        {
            var factory = new ConnectionFactory();
            var connection = factory.CreateConnection();
            var channel = connection.CreateModel();
            var consumer = new EventingBasicConsumer(channel);
            consumer.Received += (model, ea) => {
                var contextOptions = new DbContextOptionsBuilder<InsuranceClaimDbContext>().Options;
                var dbContext = new InsuranceClaimDbContext(contextOptions);
                var body = ea.Body.ToArray();
                var message = Encoding.UTF8.GetString(body);
                var data = JObject.Parse(message);
                var type = ea.RoutingKey;
                if (type == "TreatmentPlan.add")
                {
                    dbContext.TreatmentPlan.Add(new TreatmentPlan() { TreatmentPlanId = data["TreatmentPlanId"].Value<int>(), PackageName = data["PackageName"].Value<string>(), TestDetails = data["TestDetails"].Value<string>(),Cost = data["Cost"].Value<int>(), TreatmentCommencementDate = data["TreatmentCommencementDate"].Value<DateTime>(), TreatmentEndDate = data["TreatmentEndDate"].Value<DateTime>(), SpecialistId = data["SpecialistId"].Value<int>(), PatientId = data["PatientId"].Value<int>() });
                    dbContext.SaveChanges();
                }
                if (type == "PatientDetail.add")
                {
                    dbContext.PatientDetail.Add(new PatientDetail() { PatientId = data["PatientId"].Value<int>(), Name = data["Name"].Value<string>(), TreatmentPackageName = data["TreatmentPackageName"].Value<string>(), Age = data["Age"].Value<int>(), TreatmentCommencementDate = data["TreatmentCommencementDate"].Value<DateTime>(), TreatmentStatus = data["TreatmentStatus"].Value<string>() });
                    dbContext.SaveChanges();
                }
                if (type == "PatientDetail.update")
                {
                    var patient = dbContext.PatientDetail.First(p => p.PatientId == data["PatientId"].Value<int>());
                    patient.TreatmentStatus = data["TreatmentStatus"].Value<string>();
                    dbContext.SaveChanges();
                }

            };
            channel.BasicConsume(queue: "TreatmentPlan.Ic", autoAck: true, consumer: consumer);
            channel.BasicConsume(queue: "PatientDetail.Ic", autoAck: true, consumer: consumer);
        }
        public static void Main(string[] args)
        {
            ListenForIntegrationEvents();

            ILoggerRepository loggerRepository = log4net.LogManager.GetRepository(Assembly.GetEntryAssembly());
            log4net.Config.XmlConfigurator.Configure(loggerRepository, new FileInfo("log4net.config"));
            CreateHostBuilder(args).Build().Run();

        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
            .ConfigureWebHostDefaults(webBuilder =>
            {
                webBuilder.UseStartup<Startup>()
            .ConfigureLogging((hostingContext, logging) =>
            {
                logging.AddLog4Net();
                logging.SetMinimumLevel(LogLevel.Debug);
            });
        });
    }
}
