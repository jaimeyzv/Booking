use master
go

create database Habitaciones
go

use Habitaciones
go

create table Habitaciones
(
	HabitacionId		int identity(1,1),
	CodigoHabitacion	varchar(10),
	CodigoHotel			varchar(10),
	Descripcion			varchar(500),
	Precio				decimal(18, 4),
	Numero				int,
	CantidadCamas		int,
	Codigoimagen		varchar(30),
	Disponible			bit,
	Activo				bit

	primary key(HabitacionId)
)
go

insert into Habitaciones values ('HBT0000001','HT00000001', 'Habitación familiar con 2 camas', 150.00, 101, 2,'HT00000001-HBT0000001-2.jpg', 1, 1);
insert into Habitaciones values ('HBT0000002','HT00000001', 'Habitación familiar con 3 camas', 220.00, 102 , 3,'HT00000001-HBT0000002-3.jpg', 1, 1);
insert into Habitaciones values ('HBT0000003','HT00000001', 'Habitación matrimonial con una cama de 2 plazas', 170.00, 103, 1,'HT00000001-HBT0000003-1.jpg', 1, 1);
insert into Habitaciones values ('HBT0000004','HT00000001', 'Habitación para persona sola', 50.00, 104, 1,'HT00000001-HBT0000004-1.jpg', 1, 1);
insert into Habitaciones values ('HBT0000005','HT00000001', 'Habitación matrimonial cama Queen', 159.00, 105, 1,'HT00000001-HBT0000005-1.jpg', 1, 1);
insert into Habitaciones values ('HBT0000006','HT00000002', 'Habitación matrimonial cama de dos plazas', 129.00, 101, 1,'HT00000002-HBT0000006-1.jpg', 1, 1);
insert into Habitaciones values ('HBT0000007','HT00000002', 'Habitación familiar con 3 camas', 200.00, 102, 3,'HT00000002-HBT0000007-3.jpg', 1, 1);
insert into Habitaciones values ('HBT0000008','HT00000002', 'Habitación para persona sola', 49.00, 103, 1,'HT00000002-HBT0000008-1.jpg', 1, 1);
insert into Habitaciones values ('HBT0000009','HT00000002', 'Habitación matrimonial cama de dos plazas', 110.00, 101, 1,'HT00000003-HBT0000009-1.jpg', 1, 1);

select * from Habitaciones

--delete from Habitaciones where HabitacionId = 13