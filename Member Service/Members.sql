create database Miembros
go

use Miembros
go

create table Miembro
(
	MiembroId		int identity(1,1) not null,
	Nombres			varchar(100),
	Ape_Paterno		varchar(50),
	Ape_Materno		varchar(50),
	Dni				char(8),
	Edad			int,
	Activo			bit

	primary key(MiembroId)
);
go

insert into Miembro values ('Jaime Yampiere', 'Zamora', 'Vasquez', '47470738', 27, 1);
insert into Miembro values ('Luis Johao', 'Rosas', 'Rosillo', '01012547', 28, 1);


select * from Miembro
