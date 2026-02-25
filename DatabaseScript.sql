CREATE DATABASE AUCASADB_26937;
GO

USE AUCASADB_26937;
GO

CREATE TABLE POSITIONS (
    position_id INT PRIMARY KEY IDENTITY(1,1),
    position_title NVARCHAR(50) NOT NULL,
    position_description NVARCHAR(60)
);

CREATE TABLE CANDIDATES (
    student_id INT PRIMARY KEY IDENTITY(1,1),
    email NVARCHAR(50),
    fullname NVARCHAR(50),
    department NVARCHAR(50),
    semester NVARCHAR(50),
    current_avg_score NVARCHAR(50),
    position INT,
    description NVARCHAR(50),
    FOREIGN KEY (position) REFERENCES POSITIONS(position_id)
);
