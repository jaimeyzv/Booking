create database Reservas
go

use Reservas
go

create table Reserva
(
	ReservaId			int identity (1,1) not null,
	Codigo				varchar(20) not null,
	DniMiembro			varchar(8),
	CodigoHotel			varchar(10),
	CodigoHabitacion	varchar(10),
)
go