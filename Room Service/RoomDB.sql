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
	Numero				int,
	CantidadCamas		int,
	Disponible			bit

	primary key(HabitacionId)
)
go

insert into Habitaciones values ('HT00000001','HBT0000001', 'Habitaci�n matrimonial', 101, 2, 1);
insert into Habitaciones values ('HT00000001','HBT0000002', 'Habitaci�n con cama de agua', 102, 2, 1);
insert into Habitaciones values ('HT00000001','HBT0000003', 'Habitaci�n con frio bar', 103, 2, 1);
insert into Habitaciones values ('HT00000001','HBT0000004', 'Habitaci�n para persona sola', 104, 1, 1);

--select * from Habitaciones where (CodigoHotel = 'HT99999999' and  Numero = 201)