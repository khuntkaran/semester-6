--MST_User Table
	--insert
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

	-- select by username password
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
	--insert
		CREATE PROCEDURE API_MST_Truck_Insert
			@TruckName NVARCHAR(max),
			@TruckType NVARCHAR(max),
			@Capacity DECIMAL(7, 2),
			@TruckNumber NVARCHAR(max),
			@EngineNo NVARCHAR(max),
			@ChasisNo NVARCHAR(max),
			@Price DECIMAL(12, 2)
		AS
		BEGIN
			INSERT INTO MST_Truck (TruckName, TruckType, Capacity, TruckNumber, EngineNo, ChasisNo, Price,Created,Modified)
			VALUES (@TruckName, @TruckType, @Capacity, @TruckNumber, @EngineNo, @ChasisNo, @Price,GETDATE(),GETDATE())
		END

		exec API_MST_Truck_Insert 'I-sir','big',500.2,'GJ03RR7052','XJs4804IO','TESDFA7895',20

	--select by id
		CREATE PROCEDURE API_MST_Truck_Select_By_ID
			@TruckID INT
		AS
		BEGIN
			SELECT * FROM MST_Truck WHERE TruckID = @TruckID
		END

	--select all
		CREATE PROCEDURE API_MST_Truck_SelectAll
		AS
		BEGIN
			SELECT * FROM MST_Truck
		END

	-- Update
		CREATE PROCEDURE API_MST_Truck_Update
			@TruckID INT,
			@TruckName NVARCHAR(max),
			@TruckType NVARCHAR(max),
			@Capacity DECIMAL(7, 2),
			@TruckNumber NVARCHAR(max),
			@EngineNo NVARCHAR(max),
			@ChasisNo NVARCHAR(max),
			@Price DECIMAL(12, 2)
		AS
		BEGIN
			UPDATE MST_Truck
			SET TruckName = @TruckName,
				TruckType = @TruckType,
				Capacity = @Capacity,
				TruckNumber = @TruckNumber,
				EngineNo = @EngineNo,
				ChasisNo = @ChasisNo,
				Price = @Price,
				Modified =GETDATE()
			WHERE TruckID = @TruckID
		END

	-- delete
		CREATE PROCEDURE API_MST_Truck_Delete
			@TruckID INT
		AS
		BEGIN
			DELETE FROM MST_Truck WHERE TruckID = @TruckID
		END



select * from MST_Truck
--MST_City
	

--MST_GoodsType


--MST_Driver


--TruckWiseBooking