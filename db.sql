CREATE DATABASE JobApplicationTracker;
use JobApplicationTracker;

CREATE USER 'webhost_JobAppTracker' IDENTIFIED BY '';  -- Specify password before creating.
GRANT ALL ON JobApplicationTracker.* TO 'webhost_JobAppTracker';


CREATE TABLE Companies (
	Id INTEGER NOT NULL AUTO_INCREMENT,
	CompanyName VARCHAR(64) NOT NULL,
	DoNotApply BIT NOT NULL DEFAULT 0,
	DateApplied DATE NULL,
	WhyWorkHere TEXT NULL,
	401kMatch TINYINT UNSIGNED NULL,
	HealthInsPercent TINYINT UNSIGNED NULL,
	DentalInsPercent TINYINT UNSIGNED NULL,
	VisionInsPercent TINYINT UNSIGNED NULL,
	Notes TEXT NULL,
	PRIMARY KEY (Id)
);

CREATE TABLE Contacts (
	Id INTEGER NOT NULL AUTO_INCREMENT,
	CompanyId INTEGER NOT NULL,

	Name VARCHAR(64) NOT NULL,
	Email VARCHAR(64) NULL,
	Phone VARCHAR(64) NULL,
	AdditionalInfo TEXT NULL,

	FOREIGN KEY (CompanyId)
	REFERENCES Companies(Id)
	ON DELETE CASCADE,

	PRIMARY KEY (Id)
);

/*
Add salary
Add company website
*/

ALTER TABLE Companies
ADD COLUMN SalaryOffered VARCHAR(64) NULL;

ALTER TABLE Companies
ADD COLUMN Website VARCHAR(256) NULL;

ALTER TABLE Companies
ADD COLUMN ApplicationStatus TINYINT NOT NULL DEFAULT 0;

ALTER TABLE Companies
MODIFY ApplicationStatus TINYINT NULL;

/*
Add Company Culture
Add Intra-Level Communication
Add Views on FOSS
Add Full Remote OK check
Add Outside US OK check
Add Company, Department, and Team size
Add Security vs Convenience
*/
ALTER TABLE Companies
ADD COLUMN Culture TEXT NULL;

ALTER TABLE Companies
ADD COLUMN IntraLvlCommunication TEXT NULL;

ALTER TABLE Companies
ADD COLUMN ViewsOnFOSS TEXT NULL; -- Example: will I be able to FOSS some of my work?

ALTER TABLE Companies
ADD COLUMN FullRemoteOK BIT NULL;

ALTER TABLE Companies
ADD COLUMN OutsideUSOK BIT NULL;

ALTER TABLE Companies
ADD COLUMN CompanySize INT NULL;

ALTER TABLE Companies
ADD COLUMN DepartmentSize INT NULL;

ALTER TABLE Companies
ADD COLUMN TeamSize INT NULL;

ALTER TABLE Companies
ADD COLUMN SecurityVsConvenience TEXT NULL;
