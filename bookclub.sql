drop database bookclub;

create database bookclub;

use bookclub;

create table Person (
    id int NOT NULL AUTO_INCREMENT,
    FirstName varchar(50),
    LastName varchar(50),
    Email varchar(255),
    PRIMARY KEY (id)
);

create table Presentation (
    id int NOT NULL AUTO_INCREMENT,
    PersonId int,
    PresentationDate datetime,
    BookTitle varchar (50),
    BookAuthor varchar(50),
    Genre varchar(25),
    PRIMARY KEY (id),
    FOREIGN KEY (PersonId) REFERENCES Person(id)
);

Insert Into Person (FirstName, LastName, Email) values ('Lindsey', 'White', 'LWhite@Gmail.com');

Insert Into Presentation (PersonId, PresentationDate, BookTitle, BookAuthor, Genre) values ('1', '2020-10-6', 'Lord of the Rings: Fellowship of the Rings', 'J.R.R. Tolkein', 'Fantasy');  