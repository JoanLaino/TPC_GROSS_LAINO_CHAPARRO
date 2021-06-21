create database GROSS_LAINO_CHAPARRO_DB
GO

use GROSS_LAINO_CHAPARRO_DB
GO

/*
alter view ExportInventario
as
select I.Codigo as EAN, I.Nombre as Nombre, TP.Descripcion as TipoProducto, 
M.Descripcion as Marca, P.RazonSocial as Proveedor, 
I.FechaCompra as FechaCompra, I.FechaVencimiento as FechaVencimiento,
I.Costo as Costo, I.PrecioVenta as PrecioVenta, I.Stock as Stock, I.Estado as Estado 
from Inventario as I
inner join TiposProducto as TP on I.IdTipo = TP.ID
inner join Marcas as M on I.IdMarca = M.ID
inner join Proveedores as P on I.IdProveedor = P.ID 
GO 

select * from ExportInventario
*/

/*
create table TiposProducto(
	ID bigint primary key identity (1,1) not null,
	Descripcion varchar(50) not null,
	Estado bit not null default (1)
)
GO

create table Marcas(
	ID bigint primary key identity (1,1) not null,
	Descripcion varchar(50) not null,
	Estado bit not null default (1)
)
GO

create table Proveedores(
	ID bigint primary key identity (1,1) not null,
	CUIT varchar(13) unique not null,
	RazonSocial varchar(100) unique not null,
	Estado bit not null default (1)
)

create table Inventario(
	Codigo bigint primary key identity (1,1) not null,
	Nombre varchar(100) not null,
	IdTipo bigint not null foreign key references TiposProducto(ID),
	IdMarca bigint not null foreign key references Marcas(ID),
	IdProveedor bigint not null foreign key references Proveedores(ID),
	FechaCompra date not null check (FechaCompra < getdate()),
	FechaVencimiento date null, check (FechaVencimiento >= getdate()),
	Costo money not null check (Costo >= 0),
	PrecioVenta money not null,
	Stock int not null check (Stock >= 0),
	Estado bit not null default (1)
)
GO
*/

/*
create table TiposCliente(
	ID smallint primary key identity (1,1),
	Descripcion varchar(30) unique check (Descripcion = 'Empresa' or Descripcion = 'Particular' or Descripcion = 'Monotributista' or Descripcion = 'Estatal'),
	Estado bit not null default (1)
)
GO

create table Clientes(
	ID bigint primary key identity (1,1) not null,
	IDTipo smallint not null foreign key references TiposCliente(ID),
	CUIT_CUIL varchar(13) unique not null,
	RazonSocial varchar(100) unique null,
	ApeNom varchar(100) not null,
	FechaAlta date not null default (getdate()) check (FechaAlta = getdate()),
	FechaNacimiento date null,
	Mail varchar(100) unique not null,
	Telefono varchar(50) not null,
	TotalVehiculosRegistrados int not null default (0) check (TotalVehiculosRegistrados >= 0),
	Estado bit not null default (1)
)
GO

create table TiposUsuario(
	ID smallint primary key identity (1,1),
	Descripcion varchar(30) unique check (Descripcion = 'Administrador' or Descripcion = 'Jefe' or Descripcion = 'Empleado'),
	Estado bit not null default (1)
)
GO

create table Usuarios(
	ID bigint primary key identity (1,1) not null,
	IDTipo smallint not null foreign key references TiposUsuario(ID),
	NickName varchar(30) unique not null,
	Clave varchar(30) not null,
	Mail varchar(100) unique not null,
	FechaAlta date not null check (FechaAlta = getdate()),
	Estado bit not null default (1)
)
GO

create table Empleados(
	ID bigint primary key identity (1,1) not null,
	Legajo varchar(6) unique not null,
	CUIL varchar(13) unique not null,
	ApeNom varchar(100) not null,
	FechaAlta date not null,
	FechaNacimiento date null,
	Mail varchar(100) unique not null,
	Telefono varchar(50) not null,
	TotalServiciosRealizados int not null default (0) check (TotalServiciosRealizados >= 0)
)
GO

create table Vehiculos(
	Patente varchar(8) primary key not null,
	IdMarca bigint not null foreign key references Marcas(ID),
	Modelo varchar(50) not null,
	AnioFabricacion int not null,
	FechaAlta date not null default (getdate()) check (FechaAlta = getdate()),
	IdCliente bigint not null foreign key references Clientes(ID)
)
GO

create table TiposServicio(
	ID int primary key identity (1,1) not null,
	Descripcion varchar(30) unique check (Descripcion = 'Cambio de aceite' or Descripcion = 'Cambio de filtros' or Descripcion = 'Revisión'),
)

create table Servicios
	ID bigint primary key identity (1,1) not null,
	FechaRealizacion date not null,
	PatenteVehiculo varchar(8) not null foreign key references Vehiculos(Patente),
	IdTipo int not null foreign key references TiposServicio(ID),
	Comentarios varchar(400) null,
	IdCliente bigint not null foreign key references Clientes(ID),
	IdEmpleado bigint not null foreign key references Empleados(ID)
)
GO
*/