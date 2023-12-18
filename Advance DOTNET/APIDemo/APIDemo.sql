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