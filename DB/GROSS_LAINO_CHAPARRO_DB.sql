create database GROSS_LAINO_CHAPARRO_DB
GO

use GROSS_LAINO_CHAPARRO_DB
GO

/*
create view ExportInventario
as
select I.Codigo as EAN, I.Nombre as Nombre, I.Imagen as Imagen, TP.Descripcion as TipoProducto, 
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
	Imagen varchar(300) not null,
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

/*
INSERT INTO Inventario(Nombre, Imagen, IdTipo, IdMarca, IdProveedor, FechaCompra, FechaVencimiento, Costo, PrecioVenta, Stock, Estado) values('Lubricante Castrol', 'https://live.staticflickr.com/3771/12164538394_32d87cf00b_b.jpg', 1, 3, 1, '2021-05-15', '2021-09-15', 10, 20, 5, 1)
INSERT INTO Inventario(Nombre, Imagen, IdTipo, IdMarca, IdProveedor, FechaCompra, FechaVencimiento, Costo, PrecioVenta, Stock, Estado) values('Aceite YPF', 'https://lubricentrocarlitos.com.ar/wp-content/uploads/2017/10/elaion-f50.jpg', 2, 2, 1, '2021-05-15', '2021-09-15', 10, 20, 5, 1)
INSERT INTO Inventario(Nombre, Imagen, IdTipo, IdMarca, IdProveedor, FechaCompra, FechaVencimiento, Costo, PrecioVenta, Stock, Estado) values('Líquido refrigerante Shell', 'https://upload.wikimedia.org/wikipedia/commons/thumb/8/8d/Shell_lub.png/200px-Shell_lub.png', 5, 1, 2, '2021-05-15', '2021-09-15', 10, 20, 5, 1)
INSERT INTO Inventario(Nombre, Imagen, IdTipo, IdMarca, IdProveedor, FechaCompra, FechaVencimiento, Costo, PrecioVenta, Stock, Estado) values('Agua destilada Water', 'https://http2.mlstatic.com/D_NQ_NP_710724-MLA43593591234_092020-V.jpg', 4, 4, 2, '2021-05-15', '2021-09-15', 10, 20, 5, 1)
INSERT INTO Inventario(Nombre, Imagen, IdTipo, IdMarca, IdProveedor, FechaCompra, FechaVencimiento, Costo, PrecioVenta, Stock, Estado) values('Líquido de frenos Dot3', 'https://st2.depositphotos.com/1439888/11103/i/600/depositphotos_111033484-stock-photo-brake-fluid-with-disc-brake.jpg', 3, 5, 2, '2021-05-15', '2021-09-15', 10, 20, 5, 1)


INSERT INTO Marcas(Descripcion, Estado) values('Shell', 1)
INSERT INTO Marcas(Descripcion, Estado) values('YPF', 1)
INSERT INTO Marcas(Descripcion, Estado) values('Castrol', 1)
INSERT INTO Marcas(Descripcion, Estado) values('Water', 1)
INSERT INTO Marcas(Descripcion, Estado) values('Dot3', 1)


INSERT INTO Proveedores(CUIT, RazonSocial) values('111111111111', 'ABC S.A.')
INSERT INTO Proveedores(CUIT, RazonSocial) values('222222222222', 'DEF S.R.L.')


INSERT INTO TiposProducto(Descripcion, Estado) values('Lubricante', 1)
INSERT INTO TiposProducto(Descripcion, Estado) values('Aceite', 1)
INSERT INTO TiposProducto(Descripcion, Estado) values('Líquido de frenos', 1)
INSERT INTO TiposProducto(Descripcion, Estado) values('Agua destilada', 1)
INSERT INTO TiposProducto(Descripcion, Estado) values('Líquido refrigerante', 1)
*/