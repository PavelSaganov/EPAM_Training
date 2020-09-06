Create Table Groups (
 GroupId BIGINT IDENTITY(1,1) CONSTRAINT PK_Groups PRIMARY KEY,
 GroupName char(40) NOT NULL,
);

Create Table Students (
 StudentId BIGINT IDENTITY(1,1) CONSTRAINT PK_Students PRIMARY KEY,
 GroupId BIGINT,
 FirstName char(40) NOT NULL,
 Surname char(40) NOT NULL,
 SecondName char(40) NOT NULL,
 BirthDay datetime,
 FOREIGN KEY (GroupId) REFERENCES Groups (GroupId)
);

Create Table StudySessions (
 SessionId BIGINT IDENTITY(1,1) CONSTRAINT PK_Sessions PRIMARY KEY,
 GroupId BIGINT,
 StartDate datetime NOT NULL,
 EndDate datetime NOT NULL,
 FOREIGN KEY (GroupId) REFERENCES Groups (GroupId)
);

Create Table Exams (
 ExamId BIGINT IDENTITY(1,1) CONSTRAINT PK_Exams PRIMARY KEY,
 SessionId BIGINT,
 ExamDate datetime,
 ExamName char(40) NOT NULL,
 FOREIGN KEY (SessionId) REFERENCES StudySessions (SessionId)
);

Create Table PartialCredits (
 PartialCreditId BIGINT IDENTITY(1,1) CONSTRAINT PK_PartialCredits PRIMARY KEY,
 SessionId BIGINT,
 PartialCreditDate datetime,
 PartialCreditName char(40) NOT NULL,
 FOREIGN KEY (SessionId) REFERENCES StudySessions (SessionId)
);

Create Table ExamResults (
 ExamResultId BIGINT IDENTITY(1,1) CONSTRAINT PK_ExamResults PRIMARY KEY,
 ExamId BIGINT NOT NULL,
 StudentId BIGINT NOT NULL,
 Mark int,
 FOREIGN KEY (StudentId) REFERENCES Students (StudentId),
 FOREIGN KEY (ExamId) REFERENCES Exams (ExamId)
);

Create Table PartialCreditResult (
 PartialCreditResultId BIGINT IDENTITY(1,1) CONSTRAINT PK_PartialCreditResults PRIMARY KEY,
 PartialCreditId BIGINT NOT NULL,
 StudentId BIGINT NOT NULL,
 Pass bit,
 FOREIGN KEY (StudentId) REFERENCES Students (StudentId),
 FOREIGN KEY (PartialCreditId) REFERENCES PartialCredits (PartialCreditId)
);