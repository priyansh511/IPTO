use IPT;
use IPTreatment;
insert into PackageDetail values('Package 1','UTest 1',1500,10)
insert into PackageDetail values('Package 2','UTest 2',2000,8)
insert into PackageDetail values('Package 1','OTest 1',1500,10)
insert into PackageDetail values('Package 2','OTest 1',2000,6)
select * from packagedetail

insert into IPTreatmentPackage values ('UROLOGY',1)
insert into IPTreatmentPackage values ('UROLOGY',2)
insert into IPTreatmentPackage values ('ORTHOPAEDICS',3)
insert into IPTreatmentPackage values ('ORTHOPAEDICS',4)
select * from IPTreatmentPackage

insert into SpecialistDetails values('Dr. Askandha Sharma', 'Orthopaedics', 20, '9461524333')
insert into SpecialistDetails values('Dr. Priyansh Soniya', 'Orthopaedics', 15, '9461526666')
insert into SpecialistDetails values('Dr. Nidhi Sharma', 'Urology', 20, '9461524322')
insert into SpecialistDetails values('Dr. Rahil Sharma', 'Urology', 10, '9461524113')
select * from SpecialistDetails

use InsuranceClaim
insert into InsurerDetail values ('LIC','LIC Jeevan Policy',100000,2)
insert into InsurerDetail values ('LIC','LIC Life Policy',150000,3)
insert into InsurerDetail values ('Bajaj Allianz','Bajaj Health',200000,5)
insert into InsurerDetail values ('LIC','LIC Health',100000,4)
insert into InsurerDetail values ('ICICI Prudential','ICICI Health',250000,5)
insert into InsurerDetail values ('HDFC Standard Life Insurance','HDFC Health Pack',200000,3)
select * from InsurerDetail