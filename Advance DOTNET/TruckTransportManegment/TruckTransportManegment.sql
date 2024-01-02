--MST_User Table
alter PROCEDURE API_MST_User_Insert
    @UserName NVARCHAR(max),
    @Password NVARCHAR(max),
    @Email NVARCHAR(max),
    @Phone NVARCHAR(max)
AS
BEGIN
    INSERT INTO [MST_User] (UserName, Password, Email, Phone, IsAdmin, IsActive, Created, Modified)
    VALUES (@UserName, @Password, @Email, @Phone, 0, 1, GETDATE(), GETDATE());
END

exec API_MST_User_Insert 'kkk','kkk','kkk@kkk.kkk','8780471198',1,1
exec API_MST_User_Insert 'karan','karan','karan@karan.karan','9876543210',0,1
select * from MST_User

CREATE PROCEDURE API_MST_User_Select_By_Username_Password
   @UserName NVARCHAR(max),
    @Password NVARCHAR(max)
AS
BEGIN
    SELECT * FROM [MST_User] WHERE UserName = @UserName and Password=@Password
END


CREATE PROCEDURE GetAllUsers
AS
BEGIN
    SELECT * FROM [User];
END

CREATE PROCEDURE UpdateUser
    @UserID INT,
    @UserName NVARCHAR(30),
    @Password NVARCHAR(30),
    @Email NVARCHAR(30),
    @Phone NVARCHAR(10),
    @IsAdmin BIT,
    @IsActive BIT
AS
BEGIN
    UPDATE [User] SET 
        UserName = @UserName,
        Password = @Password,
        Email = @Email,
        Phone = @Phone,
        IsAdmin = @IsAdmin,
        IsActive = @IsActive,
        Modified = GETDATE()
    WHERE UserID = @UserID;
END

CREATE PROCEDURE DeleteUser
    @UserID INT
AS
BEGIN
    DELETE FROM [User] WHERE UserID = @UserID;
END



--MST_Truck


--MST_City


--MST_GoodsType


--MST_Driver


--TruckWiseBooking