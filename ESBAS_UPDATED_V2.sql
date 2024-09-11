USE ESBAS_UPDATED_SQL_INTERNSHIP

IF OBJECT_ID('dbo.Events_Users','U') IS NOT NULL
	DROP TABLE dbo.Events_Users;

IF OBJECT_ID('dbo.Events', 'U') IS NOT NULL
    DROP TABLE dbo.Events;

IF OBJECT_ID('dbo.Users', 'U') IS NOT NULL
	DROP TABLE dbo.Users;

IF OBJECT_ID('dbo.Department', 'U') IS NOT NULL
	DROP TABLE dbo.Department;

IF OBJECT_ID('dbo.Main_Characteristicts', 'U') IS NOT NULL
	DROP TABLE dbo.Main_Characteristicts;

IF OBJECT_ID('dbo.Other_Characteristicts', 'U') IS NOT NULL
	DROP TABLE dbo.Other_Characteristicts;

IF OBJECT_ID('dbo.CostCenters', 'U') IS NOT NULL
	DROP TABLE dbo.CostCenters;

IF OBJECT_ID('dbo.Event_Location','U') IS NOT NULL
	DROP TABLE dbo.Event_Location;

IF OBJECT_ID('dbo.Task','U') IS NOT NULL
	DROP TABLE dbo.Task;

IF OBJECT_ID('dbo.Event_Type','U') IS NOT NULL
	DROP TABLE dbo.Event_Type;

IF OBJECT_ID('dbo.User_Gender','U') IS NOT NULL
	DROP TABLE dbo.User_Gender;

/* Normalizasyon tablolarý */

CREATE TABLE Event_Type(

	T_ID INT PRIMARY KEY IDENTITY(1,1),
	Name VARCHAR(100) NOT NULL,

);

CREATE TABLE Event_Location(

	L_ID INT PRIMARY KEY IDENTITY(1,1),
	Name VARCHAR(100) NOT NULL

);

CREATE TABLE User_Gender(

	G_ID INT PRIMARY KEY IDENTITY(1,1),
	Name VARCHAR(100) NOT NULL

);

CREATE TABLE Main_Characteristicts(

	MC_ID INT PRIMARY KEY IDENTITY(1,1),
	WorkingMethod VARCHAR(100) NOT NULL,
	IsOfficeEmployee VARCHAR(100) NOT NULL,
	TypeOfHazard VARCHAR(100) NOT NULL,

);

CREATE TABLE Other_Characteristicts(

	OC_ID INT PRIMARY KEY IDENTITY(1,1),
	EducationalStatus VARCHAR(100) NOT NULL,

);

CREATE TABLE CostCenters (

    CostCenterID INT PRIMARY KEY IDENTITY(1,1),
    Name NVARCHAR(100) NOT NULL,                             
    Budget DECIMAL(18, 2),                      

);

CREATE TABLE Task(

	TaskID INT PRIMARY KEY IDENTITY(1,1),
	Name VARCHAR(100) NOT NULL,

);


CREATE TABLE Department(

	DepartmentID INT PRIMARY KEY IDENTITY(1,1),
	Name VARCHAR(100) NOT NULL,
	CostCenterID INT FOREIGN KEY REFERENCES CostCenters(CostCenterID),
	TaskID INT FOREIGN KEY REFERENCES Task(TaskID),

);


CREATE TABLE Events (

    EventID INT PRIMARY KEY IDENTITY(1,1),
    Name VARCHAR(100) NOT NULL,
    Type VARCHAR(50) NOT NULL,
    Location VARCHAR(200) NOT NULL,
    EventDateTime DATETIME2 NOT NULL,
	Event_Status BIT NOT NULL,
	T_ID INT FOREIGN KEY REFERENCES Event_Type(T_ID),
	L_ID INT FOREIGN KEY REFERENCES Event_Location(L_ID),

);

CREATE TABLE Users (

    UserID INT PRIMARY KEY IDENTITY(1,1),
	UserRegistrationID VARCHAR(100) UNIQUE,
	CardID INT UNIQUE,
    FullName VARCHAR(100) NOT NULL,
    Gender VARCHAR(10) NOT NULL,
	DateOfBirth DATE,
	MailAddress VARCHAR(100) NOT NULL,
	HireDate DATETIME2 NOT NULL,
	PhoneNumber VARCHAR(100) NOT NULL,
	G_ID INT FOREIGN KEY REFERENCES User_Gender(G_ID),
	MC_ID INT FOREIGN KEY REFERENCES Main_Characteristicts(MC_ID),
	OC_ID INT FOREIGN KEY REFERENCES Other_Characteristicts(OC_ID),
	DepartmentID INT FOREIGN KEY REFERENCES Department(DepartmentID),
);

CREATE TABLE Events_Users(

	ID INT PRIMARY KEY IDENTITY(1,1),
	EventID INT FOREIGN KEY REFERENCES Events(EventID),
	CardID INT FOREIGN KEY REFERENCES Users(CardID),
	
);

ALTER TABLE Events
ADD Status BIT DEFAULT 1; 

ALTER TABLE Users
ADD Status BIT DEFAULT 1;

ALTER TABLE Events_Users
ADD Status BIT DEFAULT 1;

ALTER TABLE Department
ADD Status BIT DEFAULT 1;

ALTER TABLE CostCenters
ADD Status BIT DEFAULT 1;

ALTER TABLE Task
ADD Status BIT DEFAULT 1;

ALTER TABLE Main_Characteristicts
ADD Status BIT DEFAULT 1;

ALTER TABLE Other_Characteristicts
ADD Status BIT DEFAULT 1;

ALTER TABLE Event_Type
ADD Status BIT DEFAULT 1;

ALTER TABLE Event_Location
ADD Status BIT DEFAULT 1;

ALTER TABLE User_Gender
ADD Status BIT DEFAULT 1;

INSERT INTO Event_Type(Name) VALUES
('Conference'),
('Webinar'),
('Meeting'),
('Workshop'),
('Party');

INSERT INTO Event_Location(Name) VALUES
('Meeting Room'),
('Garden'),
('Izmir');

INSERT INTO User_Gender(Name) VALUES
('Male'),
('Female');

INSERT INTO Main_Characteristicts(WorkingMethod,IsOfficeEmployee,TypeOfHazard) VALUES
('Part-time','Office','Low Danger'),
('Full-time','Field','High Danger'),
('Full-time','Field','Medium Danger'),
('Intern','Office','Medium Danger');

INSERT INTO Other_Characteristicts(EducationalStatus) VALUES
('Open Education'),
('Associates Degree'),
('Bachelors Degree'),
('Masters Degree');

INSERT INTO CostCenters(Name,Budget) VALUES
('Information Technologies',2000.00),
('Product Manager',4000.50),
('Communication Technologies',6000.75),
('Customer Relations',9000.25),
('Human Resources',7500.50);

INSERT INTO Task(Name) VALUES
('Developing mobil applications'),
('Developing backend'),
('Developing frontend'),
('Recruit new employees'),
('Market Research Analysis'),
('Customer Satisfaction Survey'),
('Set Up and Configure Network Devices');

INSERT INTO Department(Name,CostCenterID,TaskID) VALUES
('Human Resources',5,4),
('Information Technologies',1,2),
('Information Technologies',1,1),
('Information Technologies',1,3),
('Product Manager',2,5),
('Communication Technologies',3,7),
('Customer Relations',4,6);

INSERT INTO Events (Name,Type, Location, EventDateTime,Event_Status,T_ID,L_ID) VALUES
('Innovation-Focused Culture Development Training Program', 'Education', 'Meeting Room', '2024-06-24 09:00:00',1,3,1),
('Orientation For Interns', 'Meeting', 'Meeting Room', '2024-08-02 08:00:00',1,3,1),
('Innovation-Focused Culture Development Training Program', 'Education', 'Meeting Room', '2024-07-09 08:00:00',1,2,3);

INSERT INTO Users (CardID ,UserRegistrationID , FullName,  Gender,DateOfBirth,MailAddress,HireDate,PhoneNumber,G_ID,MC_ID,OC_ID,DepartmentID) VALUES
(5666260,'8236492175846301', 'Cengizhan Kaya', 'Male', '2001-02-21', 'cengizhankaya1453@gmail.com','2024-07-08 09:00:00','+90 505 990 56 72',1,4,3,2),
(5605224,'3974821045672895','Selman Emre Erol','Male','2001-03-14',  'selmanemre@gmail.com','2024-07-15 09:45:00','+90 533 626 22 35',1,4,3,2),
(5358069,'6543109238765124', 'Atalay Beyazıt', 'Male','2003-03-01',  'atalaybeyazit16@gmail.com','2024-07-01 08:30:00','+90 545 916 60 11',1,4,3,2),
(5733290,'8345026146571354', 'Ceren Sezmen',  'Female','2001-04-30', 'cerensezmen35@gmail.com','2024-07-01 07:30:00','+90 554 695 47 79',2,4,3,5);


INSERT INTO Events_Users(EventID,CardID) VALUES
(2,5666260),
(2,5605224),
(3,5358069),
(3,5733290);

SELECT * FROM Event_Type;

SELECT * FROM Event_Location;

SELECT * FROM User_Gender;

SELECT * FROM Main_Characteristicts;

SELECT * FROM Other_Characteristicts;

SELECT * FROM CostCenters;

SELECT * FROM Task;

SELECT * FROM Department;

SELECT * FROM Events;

SELECT * FROM Users;

SELECT * FROM Events_Users;

SELECT EU.EventID,EU.CardID
FROM Events_Users AS EU
INNER JOIN Users AS U ON EU.CardID = U.CardID
WHERE EU.EventID = 1;

SELECT EU.EventID,EU.CardID
FROM Events_Users AS EU
INNER JOIN Users AS U ON EU.CardID = U.CardID
WHERE EU.EventID = 2;

SELECT EU.EventID,EU.CardID
FROM Events_Users AS EU
INNER JOIN Users AS U ON EU.CardID = U.CardID
WHERE EU.EventID = 3;