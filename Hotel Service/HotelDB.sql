use master
go

create database Hoteles
go

use Hoteles
go

create table Hoteles
(
	HotelId			int identity(1,1) not null,
	Codigo			varchar(10) not null,
	Nombre			varchar(50),
	Descripcion		varchar(500),
	Direccion		varchar(100),
	Telefono		varchar(10),
	CodigoImagen	varchar(15),
	Estrellas		int,
	Activo			bit

	primary key(HotelId)
)
go

insert into Hoteles values ('HT00000001', 'Maliah Beach Club', 'El Maliah Beach Club se encuentra en Zorritos y cuenta con piscina al aire libre y terraza. Este hotel de 4 estrellas dispone de habitaciones con aire acondicionado y ba�o privado y cuenta con un servicio de venta de entradas y mostrador de informaci�n tur�stica.', 'Faustino Piaggio s/n, tumb 01 Zorritos, Per�', '013381834', 'HT00000001.jpg', 4, 1);
insert into Hoteles values ('HT00000002', 'Hotel El Murique', 'El Hotel El Murique alberga piscina exterior y se encuentra frente al paseo mar�timo de Zorritos. Adem�s, ofrece restaurante, sal�n compartido y WiFi gratuita.', 'Av. Faustino Piaggio #075, 24541 Zorritos, Per�', '016325478', 'HT00000002.jpg', 4, 1);
insert into Hoteles values ('HT00000003', 'Hospedaje Punta Cana', 'El Hospedaje Punta Cana est� situado en Zorritos y cuenta con zona de playa privada y zona de barbacoa. Tiene recepci�n 24 horas y sol�rium. Tiene WiFi gratuita.', '215 Auxiliar Panamericana Norte Km. 215, Zorritos, Per�', '016325745', 'HT00000003.jpg', 4, 1);

select * from Hoteles;