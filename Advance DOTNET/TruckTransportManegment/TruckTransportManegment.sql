--MST_User Table
	BEGIN
		--insert
			CREATE PROCEDURE API_MST_User_Insert
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

	END

--MST_Truck
	BEGIN
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

	END


--MST_City
	BEGIN
			--insert
				CREATE PROCEDURE API_MST_City_Insert
					@CityName NVARCHAR(MAX),
					@CityCode NVARCHAR(MAX)
				AS
				BEGIN
					INSERT INTO MST_City (CityName, CityCode, Created, Modified)
					VALUES (@CityName, @CityCode, GETDATE(), GETDATE());
				END;

			--select by id
				CREATE PROCEDURE API_MST_City_SelectByID
					@CityID INT
				AS
				BEGIN
					SELECT CityID, CityName, CityCode, Created, Modified
					FROM MST_City
					WHERE CityID = @CityID;
				END;

			--select all
				CREATE PROCEDURE API_MST_City_SelectAll
				AS
				BEGIN
					SELECT CityID, CityName, CityCode, Created, Modified
					FROM MST_City
				END;

			--update
				CREATE PROCEDURE API_MST_City_Update
					@CityID INT,
					@CityName NVARCHAR(MAX),
					@CityCode NVARCHAR(MAX)
				AS
				BEGIN
					UPDATE MST_City
					SET CityName = @CityName, CityCode = @CityCode, Modified = GETDATE()
					WHERE CityID = @CityID;
				END;

			--delete
				CREATE PROCEDURE API_MST_City_Delete
					@CityID INT
				AS
				BEGIN
					DELETE FROM MST_City
					WHERE CityID = @CityID;
				END;
	END


--MST_GoodsType
	BEGIN
			--insert
				CREATE PROCEDURE API_MST_GoodsType_Insert
					@GoodsTypeName NVARCHAR(MAX)
				AS
				BEGIN
					INSERT INTO MST_GoodsType (GoodsTypeName, Created, Modified)
					VALUES (@GoodsTypeName, GETDATE(), GETDATE())
				END

			--select by id
				CREATE PROCEDURE API_MST_GoodsType_SelectByID
					@GoodsTypeID INT
				AS
				BEGIN
					SELECT * FROM MST_GoodsType WHERE GoodsTypeID = @GoodsTypeID
				END

			--select all
				CREATE PROCEDURE API_MST_GoodsType_SelectAll
				AS
				BEGIN
					SELECT * FROM MST_GoodsType
				END

			--update
				CREATE PROCEDURE API_MST_GoodsType_Update
					@GoodsTypeID INT,
					@GoodsTypeName NVARCHAR(MAX)
				AS
				BEGIN
					UPDATE MST_GoodsType
					SET GoodsTypeName = @GoodsTypeName,
						Modified = GETDATE()
					WHERE GoodsTypeID = @GoodsTypeID
				END

			--delete
				CREATE PROCEDURE API_MST_GoodsType_Delete
					@GoodsTypeID INT
				AS
				BEGIN
					DELETE FROM MST_GoodsType WHERE GoodsTypeID = @GoodsTypeID
				END
	END


--MST_Driver
	BEGIN
			--insert
				CREATE PROCEDURE API_MST_Driver_Insert
					@DriverName NVARCHAR(MAX),
					@LicenceNo NVARCHAR(MAX),
					@DriverPhone NVARCHAR(MAX),
					@LicenceExpiryDate DATETIME
				AS
				BEGIN
					INSERT INTO MST_Driver (DriverName, LicenceNo, DriverPhone, LicenceExpiryDate, Created, Modified)
					VALUES (@DriverName, @LicenceNo, @DriverPhone, @LicenceExpiryDate, GETDATE(), GETDATE())
				END

			--Select by ID
				CREATE PROCEDURE API_MST_Driver_SelectByID
					@DriverID INT
				AS
				BEGIN
					SELECT * FROM MST_Driver WHERE DriverID = @DriverID
				END

			--select all
				CREATE PROCEDURE API_MST_Driver_SelectAll
				AS
				BEGIN
					SELECT * FROM MST_Driver
				END

			--update
					CREATE PROCEDURE API_MST_Driver_Update
					@DriverID INT,
					@DriverName NVARCHAR(MAX),
					@LicenceNo NVARCHAR(MAX),
					@DriverPhone NVARCHAR(MAX),
					@LicenceExpiryDate DATETIME
				AS
				BEGIN
					UPDATE MST_Driver
					SET DriverName = @DriverName,
						LicenceNo = @LicenceNo,
						DriverPhone = @DriverPhone,
						LicenceExpiryDate = @LicenceExpiryDate,
						Modified = GETDATE()
					WHERE DriverID = @DriverID
				END

			--Delete
				CREATE PROCEDURE API_MST_Driver_Delete
					@DriverID INT
				AS
				BEGIN
					DELETE FROM MST_Driver WHERE DriverID = @DriverID
				END

				select * from MST_Driver
	END

--TruckWiseBooking
	Begin	
		--insert
			alter PROCEDURE dbo.API_TruckWiseBooking_Insert
				@UserID int,
				@TruckID int,
				@PickUpCityID int,
				@DropCityID int,
				@GoodsTypeID int,
				@DriverID int,
				@Distance Decimal(8,2),
				@Price Decimal(8,2),
				@Weight Decimal(8,2),
				@PickUpDate DateTime,
				@DropDate DateTime,
				@FromAddress nvarchar(500),
				@ToAddress nvarchar(500)
			AS
			BEGIN
				INSERT INTO TruckWiseBooking (UserID, TruckID, PickUpCityID, DropCityID, GoodsTypeID, DriverID, Distance, Price, Weight, PickUpDate, DropDate, FromAddress, ToAddress,Created,Modified)
				VALUES (@UserID, @TruckID, @PickUpCityID, @DropCityID, @GoodsTypeID, @DriverID, @Distance, @Price, @Weight, @PickUpDate, @DropDate, @FromAddress, @ToAddress,GetDate(),GetDate());
			END;

		--select by id
			CREATE PROCEDURE dbo.API_TruckWiseBooking_SelectByID
				@BookingID int
			AS
			BEGIN
				SELECT * FROM TruckWiseBooking WHERE BookingID = @BookingID;
			END;

		--select all
			alter PROCEDURE dbo.API_TruckWiseBooking_SelectAll
			AS
			BEGIN
				SELECT BookingID,TruckWiseBooking.UserID,UserName, TruckWiseBooking.TruckID,TruckName, PickUpCityID, MC.CityName as PickUpCityName, DropCityID ,MST_City.CityName as DropCityName, TruckWiseBooking.GoodsTypeID, GoodsTypeName ,TruckWiseBooking.DriverID, DriverName, Distance, TruckWiseBooking.Price, Weight, PickUpDate, DropDate, FromAddress, ToAddress,TruckWiseBooking.Created,TruckWiseBooking.Modified 
				FROM TruckWiseBooking 
				left outer join MST_User
				on MST_User.UserID= TruckWiseBooking.UserID
				left outer join MST_Truck
				on MST_Truck.TruckID= TruckWiseBooking.TruckID
				left outer join MST_City
				on MST_City.CityID= TruckWiseBooking.DropCityID
				left outer join MST_City as MC
				on MC.CityID= TruckWiseBooking.PickUpCityID
				left outer join MST_Driver
				on MST_Driver.DriverID= TruckWiseBooking.DriverID
				left outer join MST_GoodsType
				on MST_GoodsType.GoodsTypeID= TruckWiseBooking.GoodsTypeID
				
			END;

		--select all by userid
			alter PROCEDURE dbo.API_TruckWiseBooking_SelectAll_By_UserID
				@UserID int
			AS
			BEGIN
				SELECT BookingID,TruckWiseBooking.UserID,UserName, TruckWiseBooking.TruckID,TruckName, PickUpCityID, MC.CityName as PickUpCityName, DropCityID ,MST_City.CityName as DropCityName, TruckWiseBooking.GoodsTypeID, GoodsTypeName ,TruckWiseBooking.DriverID, DriverName, Distance, TruckWiseBooking.Price, Weight, PickUpDate, DropDate, FromAddress, ToAddress,TruckWiseBooking.Created,TruckWiseBooking.Modified 
				FROM TruckWiseBooking
				left outer join MST_User
				on MST_User.UserID= TruckWiseBooking.UserID
				left outer join MST_Truck
				on MST_Truck.TruckID= TruckWiseBooking.TruckID
				left outer join MST_City
				on MST_City.CityID= TruckWiseBooking.DropCityID
				left outer join MST_City as MC
				on MC.CityID= TruckWiseBooking.PickUpCityID
				left outer join MST_Driver
				on MST_Driver.DriverID= TruckWiseBooking.DriverID
				left outer join MST_GoodsType
				on MST_GoodsType.GoodsTypeID= TruckWiseBooking.GoodsTypeID
				where TruckWiseBooking.UserID = @UserID
				
			END;

		--update
			CREATE PROCEDURE dbo.API_TruckWiseBooking_Update
				@BookingID int,
				@UserID int,
				@TruckID int,
				@PickUpCityID int,
				@DropCityID int,
				@GoodsTypeID int,
				@DriverID int,
				@Distance Decimal(8,2),
				@Price Decimal(8,2),
				@Weight Decimal(8,2),
				@PickUpDate DateTime,
				@DropDate DateTime,
				@FromAddress nvarchar(500),
				@ToAddress nvarchar(500)
			AS
			BEGIN
				UPDATE TruckWiseBooking
				SET
					UserID = @UserID,
					TruckID = @TruckID,
					PickUpCityID = @PickUpCityID,
					DropCityID = @DropCityID,
					GoodsTypeID = @GoodsTypeID,
					DriverID = @DriverID,
					Distance = @Distance,
					Price = @Price,
					Weight = @Weight,
					PickUpDate = @PickUpDate,
					DropDate = @DropDate,
					FromAddress = @FromAddress,
					ToAddress = @ToAddress,
					Modified=GetDate()
				WHERE BookingID = @BookingID;
			END;


		--delete
			CREATE PROCEDURE dbo.API_TruckWiseBooking_Delete
				@BookingID int
			AS
			BEGIN
				DELETE FROM TruckWiseBooking WHERE BookingID = @BookingID;
			END;


	end


--Statestic
	Begin
		alter Procedure PR_Statestics_All
		as
		Declare @TruckCount int
		Declare @OrderCount int
		Declare @DriverCount int
		Declare @UserCount int

		select @TruckCount=count(*) from MST_Truck
		select  @OrderCount=count(*) from TruckWiseBooking
		select  @DriverCount=count(*) from MST_Driver
		select @UserCount=count(*) from MST_User where IsAdmin=0

		select @TruckCount as TruckCount,@OrderCount as OrderCount,@DriverCount as DriverCount,@UserCount as UserCount
	End
