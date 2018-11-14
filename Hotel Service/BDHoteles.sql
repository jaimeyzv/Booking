create database Hoteles
go

use Hoteles
go


create table Hotel
 (
IdHotel int identity (1,1) not null primary key,
Nombre varchar (50),
Direccion varchar (50),
Telefono varchar(10)
)
go