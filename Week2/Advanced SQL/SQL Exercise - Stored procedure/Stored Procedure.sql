-- Departments Table
CREATE TABLE Departments (
    DepartmentID INT PRIMARY KEY,
    DepartmentName VARCHAR(100)
);

-- Employees Table
CREATE TABLE Employees (
    EmployeeID INT PRIMARY KEY IDENTITY(1,1),  -- Optional auto-increment
    FirstName VARCHAR(50),
    LastName VARCHAR(50),
    DepartmentID INT FOREIGN KEY REFERENCES Departments(DepartmentID),
    Salary DECIMAL(10,2),
    JoinDate DATE
);

-- Departments
INSERT INTO Departments (DepartmentID, DepartmentName) VALUES
(1, 'HR'),
(2, 'Finance'),
(3, 'IT'),
(4, 'Marketing');

-- Employees
INSERT INTO Employees (FirstName, LastName, DepartmentID, Salary, JoinDate) VALUES
('John', 'Doe', 1, 5000.00, '2020-01-15'),
('Jane', 'Smith', 2, 6000.00, '2019-03-22'),
('Michael', 'Johnson', 3, 7000.00, '2018-07-30'),
('Emily', 'Davis', 4, 5500.00, '2021-11-05');

CREATE PROCEDURE sp_GetEmployeesByDepartment
    @DeptID INT
AS
BEGIN
    SELECT 
        E.EmployeeID,
        E.FirstName,
        E.LastName,
        E.Salary,
        E.JoinDate,
        D.DepartmentName
    FROM Employees E
    INNER JOIN Departments D ON E.DepartmentID = D.DepartmentID
    WHERE E.DepartmentID = @DeptID;
END;

CREATE PROCEDURE sp_InsertEmployee
    @FirstName VARCHAR(50),
    @LastName VARCHAR(50),
    @DepartmentID INT,
    @Salary DECIMAL(10,2),
    @JoinDate DATE
AS
BEGIN
    INSERT INTO Employees (FirstName, LastName, DepartmentID, Salary, JoinDate)
    VALUES (@FirstName, @LastName, @DepartmentID, @Salary, @JoinDate);
END;

-- Execute a Stored Procedure
EXEC sp_GetEmployeesByDepartment @DeptID = 3;

-- Return Data from a Stored Procedure
CREATE PROCEDURE sp_CountEmployeesByDepartment
    @DeptID INT
AS
BEGIN
    SELECT 
        COUNT(*) AS TotalEmployees
    FROM Employees
    WHERE DepartmentID = @DeptID;
END;
