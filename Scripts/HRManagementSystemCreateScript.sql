CREATE DATABASE HRReviewManagementSystem; 

USE HRReviewManagementSystem;

CREATE TABLE users (
	Id bigint IDENTITY(1,1) PRIMARY KEY NOT NULL,
	Username varchar(30) UNIQUE NOT NULL,
	Password varchar(30) NOT NULL,
	FirstName varchar(30) NOT NULL,
	LastName varchar(30) NOT NULL,
	Email varchar(30) UNIQUE NOT NULL,
	Role tinyint NOT NULL
)

CREATE TABLE feedbacks (
	Id bigint IDENTITY(1,1) PRIMARY KEY NOT NULL,
	Content text NOT NULL,
	Visibility tinyint NOT NULL,
	ReviewerId bigint NOT NULL,
	RevieweeId bigint NOT NULL,

	FOREIGN KEY (ReviewerId) REFERENCES users(Id),
	FOREIGN KEY (RevieweeId) REFERENCES users(Id)
)

CREATE TABLE teams (
	Id bigint IDENTITY(1,1) PRIMARY KEY NOT NULL,
	Name varchar(30) UNIQUE NOT NULL
)

CREATE TABLE memberships (
	Id bigint IDENTITY(1,1) PRIMARY KEY NOT NULL,
	TeamId bigint NOT NULL,
	UserId bigint NOT NULL,
	IsTeamLead tinyint NOT NULL,

	FOREIGN KEY (TeamId) REFERENCES teams(Id),
	FOREIGN KEY (UserId) REFERENCES users(Id)
)


CREATE TABLE evaluations (
	Id bigint IDENTITY(1, 1) PRIMARY KEY NOT NULL,
	Type tinyint NOT NULL,
)

CREATE TABLE evaluation_periods (
	Id bigint IDENTITY(1, 1) PRIMARY KEY NOT NULL,
	StartDate date,
	EndDate date,
	Name varchar(30) UNIQUE,
	Description text
)

CREATE TABLE evaluation_period_evaluations (
	Id bigint IDENTITY(1, 1) PRIMARY KEY NOT NULL,
	EvaluationId bigint NOT NULL,
	EvaluationPeriodId bigint NOT NULL,

	FOREIGN KEY (EvaluationId) REFERENCES evaluations(Id),
	FOREIGN KEY (EvaluationPeriodId) REFERENCES evaluation_periods(Id)
)

CREATE TABLE categories (
	Id tinyint IDENTITY(1, 1) PRIMARY KEY NOT NULL,
	Name varchar(30) UNIQUE NOT NULL
)

CREATE TABLE questions (
	Id bigint IDENTITY(1, 1) PRIMARY KEY NOT NULL,
	Content text NOT NULL,
	Type tinyint NOT NULL,
	CategoryId tinyint NOT NULL,
	EvaluationId bigint NOT NULL,

	FOREIGN KEY (CategoryId) REFERENCES categories(Id),
	FOREIGN KEY (EvaluationId) REFERENCES evaluations(Id)
)

CREATE TABLE concrete_evaluations (
	Id bigint IDENTITY(1, 1) PRIMARY KEY NOT NULL,
	SubmissionTime smalldatetime,
	Pending tinyint NOT NULL,
	TeamId bigint,
	EvaluationId bigint,
	ReviewerId bigint,
	RevieweeId bigint,

	FOREIGN KEY (TeamId) REFERENCES teams(Id),
	FOREIGN KEY (EvaluationId) REFERENCES evaluations(Id),
	FOREIGN KEY (ReviewerId) REFERENCES users(Id),
	FOREIGN KEY (RevieweeId) REFERENCES users(Id),
)

CREATE TABLE responses (
	Id bigint IDENTITY(1, 1) PRIMARY KEY NOT NULL,
	Type tinyint NOT NULL,
	Content text,
	QuestionId bigint NOT NULL,
	ConcreteEvaluationId bigint NOT NULL,
)

