create database Hoteles
go

use Hoteles
go

create table Hoteles
(
	HotelId		int identity(1,1) not null,
	Codigo		varchar(10) not null,
	Nombre		varchar(50),
	Descripcion	varchar(100),
	Direccion	varchar(100),
	Telefono	varchar(10),
	Estrellas	int,
	Precio		decimal(18,4),
	Activo		bit

	primary key(HotelId)
)
go

insert into Hoteles values ('HT00000001', 'Hilton', 'Mejor hotel de lima', 'AV. Por ahí no más.', '013381834', 5, 250.99, 1);

select * from Hoteles;