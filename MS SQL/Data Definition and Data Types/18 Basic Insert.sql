USE SoftUni
GO

INSERT INTO Towns (Name) VALUES ('Sofia')
INSERT INTO Towns (Name) VALUES ('Plovdiv')
INSERT INTO Towns (Name) VALUES ('Varna')
INSERT INTO Towns (Name) VALUES ('Burgas')
GO
INSERT INTO Departments (Name) VALUES ('Engineering')
INSERT INTO Departments (Name) VALUES ('Sales')
INSERT INTO Departments (Name) VALUES ('Marketing')
INSERT INTO Departments (Name) VALUES ('Software Development')
INSERT INTO Departments (Name) VALUES ('Quality Assurance')
GO
INSERT INTO Employees (FirstName, MiddleName, LastName, JobTitle, DepartmentId, HireDate, Salary)
VALUES                ('Ivan','Ivanov','Ivanov','.NET Developer',4,'01/02/2013',3500.00)
INSERT INTO Employees (FirstName, MiddleName, LastName, JobTitle, DepartmentId, HireDate, Salary)
VALUES                ('Petar','Petrov','Petrov','Senior Engineer',1,'02/03/2004',4000.00)
INSERT INTO Employees (FirstName, MiddleName, LastName, JobTitle, DepartmentId, HireDate, Salary)
VALUES                ('Maria','Petrova','Ivanova','Intern',5,'28/08/2016',3500.00)
INSERT INTO Employees (FirstName, MiddleName, LastName, JobTitle, DepartmentId, HireDate, Salary)
VALUES                ('Georgi','Teziev','Ivanov','CEO',4,'09/12/2007',3000.00)
INSERT INTO Employees (FirstName, MiddleName, LastName, JobTitle, DepartmentId, HireDate, Salary)
VALUES                ('Peter','Pan','Pan','Intern',4,'28/08/2016',599.88)