PRAGMA foreign_keys=OFF;
BEGIN TRANSACTION;
CREATE TABLE Students
(
	Student_ID INT NOT NULL PRIMARY KEY,
	Name VARCHAR NOT NULL,
	Last_Name VARCHAR NOT NULL
);
INSERT INTO Students VALUES(1,'Florian','Akostakioae');
INSERT INTO Students VALUES(2,'Andriy','Lyashenko');
INSERT INTO Students VALUES(3,'Vika','Toporovska');
INSERT INTO Students VALUES(4,'Ivan','Tkachuk');
INSERT INTO Students VALUES(5,'Vasily ','Shtefiuk');
INSERT INTO Students VALUES(6,'Sasha','Skalovskiy');
CREATE TABLE Subjects
(
	Subject_ID INT NOT NULL PRIMARY KEY,
	Name VARCHAR NOT NULL
);
INSERT INTO Subjects VALUES(1,'Programming');
INSERT INTO Subjects VALUES(2,'Web');
INSERT INTO Subjects VALUES(3,'Math');
CREATE TABLE Subject_type
(
	Subject_ID INT NOT NULL,
	Hours_Lectures INT NOT NULL,
	Hours_Practics INT NOT NULL,
	Hours_Labs INT NOT NULL,
	FOREIGN KEY (Subject_ID) REFERENCES Subjects(Subject_ID)
		ON DELETE CASCADE ON UPDATE CASCADE
);
INSERT INTO Subject_type VALUES(1,8,0,8);
INSERT INTO Subject_type VALUES(2,8,2,6);
CREATE TABLE Reasons
(
	Reason_ID INT NOT NULL,
	Reason VARCHAR NOT NULL,
	PRIMARY KEY (Reason_ID)
);
INSERT INTO Reasons VALUES(1,'Поважна');
INSERT INTO Reasons VALUES(2,'Не поважна');
INSERT INTO Reasons VALUES(3,'Хворий');
CREATE TABLE Elimination
(
	Student_ID INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
	Name VARCHAR NOT NULL,
	Last_Name VARCHAR NOT NULL
);
CREATE TABLE Attendance_practics
(
	Attendance_ID INTEGER PRIMARY KEY AUTOINCREMENT,
	Student_ID INT NOT NULL,
	Subject_ID INT NOT NULL,
	Day DATE NOT NULL,
	Type INT NOT NULL,
	FOREIGN KEY("Student_ID") REFERENCES "Students"("Student_ID") ON DELETE CASCADE ON UPDATE CASCADE,
	FOREIGN KEY("Subject_ID") REFERENCES "Subjects"("Subject_ID") ON DELETE CASCADE ON UPDATE CASCADE,
	FOREIGN KEY("Type") REFERENCES "Reasons"("Reason_ID")
);
CREATE TABLE Attendance_labs
(
	Attendance_ID INTEGER PRIMARY KEY AUTOINCREMENT,
	Student_ID INT NOT NULL,
	Subject_ID INT NOT NULL,
	Day DATE NOT NULL,
	Type INT NOT NULL,
	FOREIGN KEY("Student_ID") REFERENCES "Students"("Student_ID") ON DELETE CASCADE ON UPDATE CASCADE,
	FOREIGN KEY("Subject_ID") REFERENCES "Subjects"("Subject_ID") ON DELETE CASCADE ON UPDATE CASCADE,
	FOREIGN KEY("Type") REFERENCES "Reasons"("Reason_ID")
);
INSERT INTO Attendance_labs VALUES(1,1,2,'2021-11-9',1);
INSERT INTO Attendance_labs VALUES(2,1,1,'2021-11-9',1);
INSERT INTO Attendance_labs VALUES(3,2,1,'2021-11-9',2);
INSERT INTO Attendance_labs VALUES(4,2,2,'2021-11-9',3);
CREATE TABLE Attendance_lectures
(
	Attendance_ID INTEGER PRIMARY KEY AUTOINCREMENT,
	Student_ID INT NOT NULL,
	Subject_ID INT NOT NULL,
	Day DATE NOT NULL,
	Type INT NOT NULL,
	FOREIGN KEY("Student_ID") REFERENCES "Students"("Student_ID") ON DELETE CASCADE ON UPDATE CASCADE,
	FOREIGN KEY("Subject_ID") REFERENCES "Subjects"("Subject_ID") ON DELETE CASCADE ON UPDATE CASCADE,
	FOREIGN KEY("Type") REFERENCES "Reasons"("Reason_ID")
);
CREATE TABLE IF NOT EXISTS "Professors" (
	"Professor_ID"	INTEGER NOT NULL,
	"Name"	VARCHAR NOT NULL,
	"Last_Name"	VARCHAR NOT NULL,
	"Subject_ID"	VARCHAR NOT NULL,
	FOREIGN KEY("Subject_ID") REFERENCES "Subjects"("Subject_ID") ON DELETE CASCADE ON UPDATE CASCADE,
	PRIMARY KEY("Professor_ID" AUTOINCREMENT)
);
INSERT INTO Professors VALUES(1,'Yuriy','Lutsiuk','1');
INSERT INTO Professors VALUES(2,'Vasily','Koropetskiy','2');
DELETE FROM sqlite_sequence;
INSERT INTO sqlite_sequence VALUES('Professors',4);
INSERT INTO sqlite_sequence VALUES('Attendance_labs',4);
CREATE TRIGGER addSubjectType 
AFTER INSERT ON Subjects 
FOR EACH ROW 
BEGIN 
INSERT INTO Subject_type 
(Subject_ID, Hours_Lectures, Hours_Labs, Hours_Practics) 
VALUES (NEW.Subject_ID, 8, 4, 4); 
END;
CREATE TRIGGER noReasons 
AFTER DELETE ON Reasons 
FOR EACH ROW 
BEGIN 
UPDATE Attendance_labs 
SET Type = 2 
WHERE Type = 1;   
UPDATE Attendance_practics 
SET Type = 2 
WHERE Type = 1;
UPDATE Attendance_lectures 
SET Type = 2 
WHERE Type = 1;
END;
COMMIT;
