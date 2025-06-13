-- Created by Vertabelo (http://vertabelo.com)
-- Last modification date: 2025-06-13 08:47:41.755

-- tables
-- Table: Language
CREATE TABLE Language (
                          Id int  NOT NULL IDENTITY(1, 1),
                          Name varchar(100)  NOT NULL,
                          CONSTRAINT Language_pk PRIMARY KEY  (Id)
);

-- Table: Record
CREATE TABLE Record (
                        Id int  NOT NULL IDENTITY(1, 1),
                        Language_Id int  NOT NULL,
                        Task_Id int  NOT NULL,
                        Student_Id int  NOT NULL,
                        ExecutionTime bigint  NOT NULL,
                        CreatedAt datetime2  NOT NULL,
                        CONSTRAINT Record_pk PRIMARY KEY  (Id)
);

-- Table: Student
CREATE TABLE Student (
                         Id int  NOT NULL IDENTITY(1, 1),
                         FirstName varchar(100)  NOT NULL,
                         LastName varchar(100)  NOT NULL,
                         Email varchar(250)  NOT NULL,
                         CONSTRAINT Student_pk PRIMARY KEY  (Id)
);

-- Table: Task
CREATE TABLE Task (
                      Id int  NOT NULL IDENTITY(1, 1),
                      Name varchar(100)  NOT NULL,
                      Descrition varchar(2000)  NOT NULL,
                      CONSTRAINT Task_pk PRIMARY KEY  (Id)
);

-- foreign keys
-- Reference: Copy_of_Table_1_Language (table: Record)
ALTER TABLE Record ADD CONSTRAINT Copy_of_Table_1_Language
    FOREIGN KEY (Language_Id)
        REFERENCES Language (Id);

-- Reference: Copy_of_Table_1_Student (table: Record)
ALTER TABLE Record ADD CONSTRAINT Copy_of_Table_1_Student
    FOREIGN KEY (Student_Id)
        REFERENCES Student (Id);

-- Reference: Copy_of_Table_1_Task (table: Record)
ALTER TABLE Record ADD CONSTRAINT Copy_of_Table_1_Task
    FOREIGN KEY (Task_Id)
        REFERENCES Task (Id);

-- End of file.

