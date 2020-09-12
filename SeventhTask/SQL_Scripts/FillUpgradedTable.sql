INSERT INTO University.dbo.Specialties VALUES ('Computer science and programming technologies');
INSERT INTO University.dbo.Specialties VALUES ('Information systems protection');
INSERT INTO University.dbo.Specialties VALUES ('Electronic computing systems');
UPDATE Groups SET SpecialityId = 1 WHERE GroupId = 1;
UPDATE Groups SET SpecialityId = 2 WHERE GroupId = 2;
UPDATE Groups SET SpecialityId = 3 WHERE GroupId = 3;

INSERT INTO University.dbo.Examiners VALUES ('Petr Sergeevich Aniki');
INSERT INTO University.dbo.Examiners VALUES ('Van Darkholme Saama');
INSERT INTO University.dbo.Examiners VALUES ('So Old Man');
INSERT INTO University.dbo.Examiners VALUES ('Eron Don Don');
UPDATE Exams SET ExaminerId = 1 WHERE ExamId = 1;
UPDATE Exams SET ExaminerId = 1 WHERE ExamId = 2;
UPDATE Exams SET ExaminerId = 1 WHERE ExamId = 3;
UPDATE Exams SET ExaminerId = 2 WHERE ExamId = 4;
UPDATE Exams SET ExaminerId = 2 WHERE ExamId = 5;
UPDATE Exams SET ExaminerId = 2 WHERE ExamId = 6;
UPDATE Exams SET ExaminerId = 2 WHERE ExamId = 7;
UPDATE Exams SET ExaminerId = 2 WHERE ExamId = 8;
UPDATE Exams SET ExaminerId = 3 WHERE ExamId = 9;
UPDATE Exams SET ExaminerId = 3 WHERE ExamId = 10;
UPDATE Exams SET ExaminerId = 3 WHERE ExamId = 11;
UPDATE Exams SET ExaminerId = 3 WHERE ExamId = 12;
UPDATE Exams SET ExaminerId = 3 WHERE ExamId = 13
UPDATE Exams SET ExaminerId = 4 WHERE ExamId = 14;
UPDATE Exams SET ExaminerId = 4 WHERE ExamId = 15;
UPDATE Exams SET ExaminerId = 4 WHERE ExamId = 16;

UPDATE PartialCredits SET ExaminerId = 1 WHERE PartialCreditId = 1;
UPDATE PartialCredits SET ExaminerId = 1 WHERE PartialCreditId = 2;
UPDATE PartialCredits SET ExaminerId = 1 WHERE PartialCreditId = 3;
UPDATE PartialCredits SET ExaminerId = 2 WHERE PartialCreditId = 4;
UPDATE PartialCredits SET ExaminerId = 2 WHERE PartialCreditId = 5;
UPDATE PartialCredits SET ExaminerId = 2 WHERE PartialCreditId = 6;
UPDATE PartialCredits SET ExaminerId = 2 WHERE PartialCreditId = 7;
UPDATE PartialCredits SET ExaminerId = 2 WHERE PartialCreditId = 8;
UPDATE PartialCredits SET ExaminerId = 3 WHERE PartialCreditId = 9;
UPDATE PartialCredits SET ExaminerId = 3 WHERE PartialCreditId = 10;