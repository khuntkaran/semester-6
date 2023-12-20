create database APIDemo


create Procedure API_Persion_SelectAll
as
begin
	select
		Persion.PersionID,
		Persion.Name,
		Persion.Email,
		Persion.Contact
	from Persion
end

insert into Persion values('Karan','kp@kp.kp','804711988')

exec API_Persion_SelectAll

create Procedure API_Persion_SelectByPK 3
@ID int
as
begin
	select
		Persion.PersionID,
		Persion.Name,
		Persion.Email,
		Persion.Contact
	from Persion
	where Persion.PersionID = @ID
end

create Procedure API_Persion_DeleteByPK 4
@ID int
as
begin
	delete
	from Persion
	where Persion.PersionID = @ID
end

alter Procedure API_Persion_Insert 'kkp','kp@kp','8780'
@Name nvarchar(50),
@Email nvarchar(50),
@Contact nvarchar(50)
as
begin
	insert
	into Persion
	values(@Name,@Email,@Contact)
end

create procedure API_Persion_UpdateByPK 3,'MR.karan','hello@hi','878047'
@ID int,
@Name nvarchar(50),
@Email nvarchar(50),
@Contact nvarchar(50)
as
begin
update Persion set Name=@Name,Email=@Email,Contact=@Contact where PersionID=@ID
end