CREATE DATABASE HRReviewManagementSystem;
USE HRReviewManagementSystem;

CREATE TABLE users (
    Id bigint IDENTITY(1,1) NOT NULL,
    Username varchar(30) NOT NULL,
    Password varchar(255) NOT NULL, 
    Email varchar(30) NOT NULL,
    FirstName varchar(30) NOT NULL,
    LastName varchar(30) NOT NULL,
    Role tinyint NOT NULL,
    CONSTRAINT PK_users PRIMARY KEY (Id),
    CONSTRAINT UQ_users_Username UNIQUE (Username),
    CONSTRAINT UQ_users_Email UNIQUE (Email)
);

CREATE TABLE teams (
    Id bigint IDENTITY(1,1) NOT NULL,
    Name varchar(30) NOT NULL,
    CONSTRAINT PK_teams PRIMARY KEY (Id),
    CONSTRAINT UQ_teams_Name UNIQUE (Name)
);

CREATE TABLE evaluations (
    Id bigint IDENTITY(1,1) NOT NULL,
    Type tinyint NOT NULL,
    CONSTRAINT PK_evaluations PRIMARY KEY (Id)
);

CREATE TABLE evaluation_periods (
    Id bigint IDENTITY(1,1) NOT NULL,
    StartDate date NULL,
    EndDate date NULL,
    Name varchar(30) NULL,
    Description varchar(max) NULL,
    CONSTRAINT PK_evaluation_periods PRIMARY KEY (Id)
);


CREATE TABLE memberships (
    Id bigint IDENTITY(1,1) NOT NULL,
    UserId bigint NOT NULL,
    TeamId bigint NOT NULL,
    IsTeamLead bit NOT NULL,
    CONSTRAINT PK_memberships PRIMARY KEY (Id),
    CONSTRAINT FK_memberships_users_UserId FOREIGN KEY (UserId) REFERENCES users(Id) ON DELETE CASCADE,
    CONSTRAINT FK_memberships_teams_TeamId FOREIGN KEY (TeamId) REFERENCES teams(Id) ON DELETE CASCADE
);

CREATE TABLE evaluation_period_evaluations (
    Id bigint IDENTITY(1,1) NOT NULL,
    EvaluationId bigint NOT NULL,
    EvaluationPeriodId bigint NOT NULL,
    CONSTRAINT PK_evaluation_period_evaluations PRIMARY KEY (Id),
    CONSTRAINT FK_evaluation_period_evaluations_evaluations_EvaluationId FOREIGN KEY (EvaluationId) REFERENCES evaluations(Id) ON DELETE CASCADE,
    CONSTRAINT FK_evaluation_period_evaluations_evaluation_periods_EvaluationPeriodId FOREIGN KEY (EvaluationPeriodId) REFERENCES evaluation_periods(Id) ON DELETE CASCADE
);


CREATE TABLE feedbacks (
    Id bigint IDENTITY(1,1) NOT NULL,
    Content varchar(max) NOT NULL,
    Visibility tinyint NOT NULL,
    ReviewerId bigint NOT NULL,
    RevieweeId bigint NOT NULL,
    CONSTRAINT PK_feedbacks PRIMARY KEY (Id),
    CONSTRAINT FK_feedbacks_users_ReviewerId FOREIGN KEY (ReviewerId) REFERENCES users(Id) ON DELETE NO ACTION, -- Using NO ACTION as RESTRICT is not a direct T-SQL option
    CONSTRAINT FK_feedbacks_users_RevieweeId FOREIGN KEY (RevieweeId) REFERENCES users(Id) ON DELETE NO ACTION
);

CREATE TABLE questions (
    Id bigint IDENTITY(1,1) NOT NULL,
    Content varchar(max) NOT NULL,
    Type tinyint NOT NULL,
    Category tinyint NOT NULL, 
    EvaluationId bigint NOT NULL,
    CONSTRAINT PK_questions PRIMARY KEY (Id),
    CONSTRAINT FK_questions_evaluations_EvaluationId FOREIGN KEY (EvaluationId) REFERENCES evaluations(Id) ON DELETE CASCADE
);

CREATE TABLE concrete_evaluations (
    Id bigint IDENTITY(1,1) NOT NULL,
    SubmissionTime smalldatetime NULL,
    Pending tinyint NOT NULL,
    TeamId bigint NULL,
    EvaluationId bigint NULL,
    ReviewerId bigint NULL,
    RevieweeId bigint NULL,
    CONSTRAINT PK_concrete_evaluations PRIMARY KEY (Id),
    CONSTRAINT FK_concrete_evaluations_teams_TeamId FOREIGN KEY (TeamId) REFERENCES teams(Id) ON DELETE NO ACTION,
    CONSTRAINT FK_concrete_evaluations_evaluations_EvaluationId FOREIGN KEY (EvaluationId) REFERENCES evaluations(Id) ON DELETE NO ACTION,
    CONSTRAINT FK_concrete_evaluations_users_ReviewerId FOREIGN KEY (ReviewerId) REFERENCES users(Id) ON DELETE NO ACTION,
    CONSTRAINT FK_concrete_evaluations_users_RevieweeId FOREIGN KEY (RevieweeId) REFERENCES users(Id) ON DELETE NO ACTION
);

CREATE TABLE responses (
    Id bigint IDENTITY(1,1) NOT NULL,
    Type tinyint NOT NULL,
    Content varchar(max) NULL,
    QuestionId bigint NOT NULL,
    ConcreteEvaluationId bigint NOT NULL,
    CONSTRAINT PK_responses PRIMARY KEY (Id),
    CONSTRAINT FK_responses_questions_QuestionId FOREIGN KEY (QuestionId) REFERENCES questions(Id) ON DELETE CASCADE,
    CONSTRAINT FK_responses_concrete_evaluations_ConcreteEvaluationId FOREIGN KEY (ConcreteEvaluationId) REFERENCES concrete_evaluations(Id) ON DELETE CASCADE
);

CREATE TABLE dbo.RefreshTokens (
    Id BIGINT NOT NULL IDENTITY(1,1),
    Token NVARCHAR(256) NOT NULL,
    ExpiryDate DATETIME2(7) NOT NULL,
    IsRevoked BIT NOT NULL,
    UserId BIGINT NOT NULL,

    CONSTRAINT PK_RefreshTokens PRIMARY KEY CLUSTERED (Id ASC),
    CONSTRAINT UQ_RefreshTokens_Token UNIQUE NONCLUSTERED (Token ASC),
    CONSTRAINT FK_RefreshTokens_Users_UserId FOREIGN KEY (UserId) REFERENCES dbo.Users(Id) ON DELETE CASCADE
);
GO

CREATE NONCLUSTERED INDEX IX_RefreshTokens_UserId ON dbo.RefreshTokens(UserId ASC);
GO

ALTER TABLE refresh_tokens
ADD CONSTRAINT DF_RefreshTokens_IsRevoked DEFAULT 0 FOR IsRevoked;

ALTER TABLE feedbacks
ADD TeamId bigint

ALTER TABLE feedbacks
ADD FOREIGN KEY (TeamId) REFERENCES teams(Id);