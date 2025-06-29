-- Drop tables
IF OBJECT_ID('Employees', 'U') IS NOT NULL DROP TABLE Employees;
IF OBJECT_ID('Departments', 'U') IS NOT NULL DROP TABLE Departments;

CREATE TABLE Departments (
    DepartmentID INT PRIMARY KEY,
    DepartmentName VARCHAR(100)
);

CREATE TABLE Employees (
    EmployeeID INT PRIMARY KEY,
    FirstName VARCHAR(50),
    LastName VARCHAR(50),
    DepartmentID INT FOREIGN KEY REFERENCES Departments(DepartmentID),
    Salary DECIMAL(10,2),
    JoinDate DATE
);

-- Exercise 1: Create a Scalar Function
CREATE FUNCTION fn_CalculateAnnualSalary (
    @Salary DECIMAL(10,2)
)
RETURNS DECIMAL(10,2)
AS
BEGIN
    RETURN @Salary * 12;
END;

-- Test
SELECT 
    FirstName, 
    LastName, 
    Salary,
    dbo.fn_CalculateAnnualSalary(Salary) AS AnnualSalary
FROM Employees;

--Exercise 2: Create a Table-Valued Function
CREATE FUNCTION fn_GetEmployeesByDepartment (
    @DeptID INT
)
RETURNS TABLE
AS
RETURN (
    SELECT 
        EmployeeID, FirstName, LastName, Salary, JoinDate
    FROM Employees
    WHERE DepartmentID = @DeptID
);

--Test
SELECT * FROM dbo.fn_GetEmployeesByDepartment(2); -- IT Department

-- Exercise 3: Create a User-Defined Function
CREATE FUNCTION fn_CalculateBonus (
    @Salary DECIMAL(10,2)
)
RETURNS DECIMAL(10,2)
AS
BEGIN
    RETURN @Salary * 0.10;
END;

-- Test
SELECT 
    FirstName, 
    LastName, 
    Salary, 
    dbo.fn_CalculateBonus(Salary) AS Bonus
FROM Employees;

--Exercise 4: Modify a User-Defined Function
ALTER FUNCTION fn_CalculateBonus (
    @Salary DECIMAL(10,2)
)
RETURNS DECIMAL(10,2)
AS
BEGIN
    RETURN @Salary * 0.15;
END;

--Test
SELECT 
    FirstName, 
    LastName, 
    Salary, 
    dbo.fn_CalculateBonus(Salary) AS UpdatedBonus
FROM Employees;

--Exercise 5: Delete a User-Defined Function
DROP FUNCTION fn_CalculateBonus;

--Verify
SELECT dbo.fn_CalculateBonus(5000);

--Exercise 6: Execute a User-Defined Function 
SELECT 
    EmployeeID,
    FirstName,
    Salary,
    dbo.fn_CalculateAnnualSalary(Salary) AS AnnualSalary
FROM Employees;

--Exercise 7: Return Data from a Scalar Function
SELECT 
    FirstName,
    Salary,
    dbo.fn_CalculateAnnualSalary(Salary) AS AnnualSalary
FROM Employees
WHERE EmployeeID = 1;
