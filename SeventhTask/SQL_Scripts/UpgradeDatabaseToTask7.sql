Create Table Examiners (
 ExaminerId BIGINT IDENTITY(1,1) CONSTRAINT PK_Examiners PRIMARY KEY,
 ExaminerName char(40) NOT NULL
);

Create Table Specialties (
 SpecialityId BIGINT IDENTITY(1,1) CONSTRAINT PK_Speciality PRIMARY KEY,
 SpecialityName char(50) NOT NULL
);

Alter table Exams 
ADD ExaminerId BIGINT;
Alter table Exams
ADD FOREIGN KEY (ExaminerId) REFERENCES Examiners(ExaminerId);

Alter table PartialCredits 
ADD ExaminerId BIGINT;
Alter table PartialCredits 
ADD FOREIGN KEY (ExaminerId) REFERENCES Examiners(ExaminerId);

Alter table Groups 
ADD SpecialityId BIGINT;
Alter table Groups 
ADD FOREIGN KEY (SpecialityId) REFERENCES Specialties(SpecialityId);