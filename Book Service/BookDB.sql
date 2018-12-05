use master
go

create database Reservas
go

use Reservas
go

create table Reserva
(
	ReservaId			int identity (1,1) not null,
	Codigo				varchar(30) not null,
	DniMiembro			varchar(8),
	CodigoHotel			varchar(10),
	CodigoHabitacion	varchar(10),
	NumeroHabitacion	int,
	PrecioHotel			decimal(18,4),
	CantidadPersonas	int,
	FechaCheckIn		datetime,
	FechaCheckOut		datetime,
	FechaRegistro		datetime,
	Estado				varchar(15)
	
	primary key(ReservaId)
)
go

select * from Reserva;
