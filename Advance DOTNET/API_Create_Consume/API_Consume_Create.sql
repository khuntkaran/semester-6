-- Insert Data
Exec InsertEmployee 'Kishan','kkk','kishan232@gmal.com','45678894652',456.00
CREATE PROCEDURE InsertEmployee
    @EmpName NVARCHAR(50),
    @EmpCode NVARCHAR(50),
    @Email NVARCHAR(50),
    @Contact NVARCHAR(50),
    @Salary DECIMAL(12, 2)
AS
BEGIN
    SET NOCOUNT ON;

    -- Check if the email is unique before insertion (optional, based on your requirements)
    IF NOT EXISTS (SELECT 1 FROM Employee WHERE Email = @Email)
    BEGIN
        INSERT INTO Employee (EmpName, EmpCode, Email, Contact, Salary)
        VALUES (@EmpName, @EmpCode, @Email, @Contact, @Salary);
    END
    ELSE
    BEGIN
        -- Email already exists, handle accordingly (e.g., raise an error or return a specific value)
        -- Here, let's return -1 as an indicator for email duplication (customize based on your needs)
        SELECT -1 AS 'EmpID';
    END
END


-- Get By ID
CREATE PROCEDURE GetEmployeeById
    @EmpID INT
AS
BEGIN
    SET NOCOUNT ON;

    SELECT EmpID, EmpName, EmpCode, Email, Contact, Salary
    FROM Employee
    WHERE EmpID = @EmpID;
END

--Update Emp
CREATE PROCEDURE UpdateEmployee
    @EmpID INT,
    @EmpName NVARCHAR(50),
    @EmpCode NVARCHAR(50),
    @Email NVARCHAR(50),
    @Contact NVARCHAR(50),
    @Salary DECIMAL(12, 2)
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE Employee
    SET EmpName = @EmpName,
        EmpCode = @EmpCode,
        Email = @Email,
        Contact = @Contact,
        Salary = @Salary
    WHERE EmpID = @EmpID;
END


-- Delete
CREATE PROCEDURE DeleteEmployee
    @EmpID INT
AS
BEGIN
    SET NOCOUNT ON;

    DELETE FROM Employee
    WHERE EmpID = @EmpID;
END

--Get ALL
Create Proc GetAll
As
Select * From Employee
