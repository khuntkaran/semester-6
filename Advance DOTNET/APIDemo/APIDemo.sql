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