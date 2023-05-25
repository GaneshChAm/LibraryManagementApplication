Create DataBase LibrarayMangementSystem

use LibrarayMangementSystem

Create Table Books
(
BookID int identity Primary Key,
BookTitle varchar(100),
BookAuthor varchar(100),
BookQuantity int
)
--Drop Table Books

Create Table Students
(
StudentID int Identity Primary Key,
StudentRollno int ,
StudentName varchar(100),
StudentEmail varchar(100),
)
--Drop Table Students

Create Table Management
(
IssueId int identity Primary Key,
StudentID int foreign key references Students(StudentID),
BookID int foreign key references Books(BookID),
IssuedDate Date,
ReturnDate Date
)
--Drop Table Management


Select * from Books
Select * from Students
Select * from Management
