create database GROSS_LAINO_CHAPARRO_DB
GO

use GROSS_LAINO_CHAPARRO_DB
GO

create table TiposProducto(
	ID bigint primary key identity (1,1) not null,
	Descripcion varchar(50) not null,
	Estado bit not null default (1)
)
GO

create table MarcasProducto(
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
	ID bigint not null primary key identity (1,1),
	EAN bigint unique not null,
	Descripcion varchar(60) not null,
	UrlImagen varchar(300) not null,
	IdTipo bigint not null foreign key references TiposProducto(ID),
	IdMarca bigint not null foreign key references MarcasProducto(ID),
	IdProveedor bigint not null foreign key references Proveedores(ID),
	FechaCompra date not null check (FechaCompra < getdate()),
	FechaVencimiento date null, check (FechaVencimiento >= getdate()),
	Costo money not null check (Costo >= 0),
	PrecioVenta money not null,
	Stock int not null check (Stock >= 0),
	Estado bit not null default (1)
)

INSERT INTO TiposProducto(Descripcion) values('Lubricante')
INSERT INTO TiposProducto(Descripcion) values('Aceite')
INSERT INTO TiposProducto(Descripcion) values('Líquido de frenos')
INSERT INTO TiposProducto(Descripcion) values('Agua destilada')
INSERT INTO TiposProducto(Descripcion) values('Líquido refrigerante')

INSERT INTO Proveedores(CUIT, RazonSocial) values('111111111111', 'ABC S.A.')
INSERT INTO Proveedores(CUIT, RazonSocial) values('222222222222', 'DEF S.R.L.')

INSERT INTO MarcasProducto(Descripcion) values('Shell')
INSERT INTO MarcasProducto(Descripcion) values('YPF')
INSERT INTO MarcasProducto(Descripcion) values('Castrol')
INSERT INTO MarcasProducto(Descripcion) values('Water')
INSERT INTO MarcasProducto(Descripcion) values('Dot3')

INSERT INTO Inventario(EAN, Descripcion, UrlImagen, IdTipo, IdMarca, IdProveedor, FechaCompra, FechaVencimiento, Costo, PrecioVenta, Stock) values(7798030610445, 'Lubricante muy bueno', 'https://live.staticflickr.com/3771/12164538394_32d87cf00b_b.jpg', 1, 3, 1, '2021-05-15', '2021-09-15', 10, 20, 5)
INSERT INTO Inventario(EAN, Descripcion, UrlImagen, IdTipo, IdMarca, IdProveedor, FechaCompra, FechaVencimiento, Costo, PrecioVenta, Stock) values(7798030610446, 'Aceite 15W40', 'https://lubricentrocarlitos.com.ar/wp-content/uploads/2017/10/elaion-f50.jpg', 2, 2, 1, '2021-05-15', '2021-09-15', 10, 20, 5)
INSERT INTO Inventario(EAN, Descripcion, UrlImagen, IdTipo, IdMarca, IdProveedor, FechaCompra, FechaVencimiento, Costo, PrecioVenta, Stock) values(7798030610447, 'Líquido refrigerante concentrado', 'https://upload.wikimedia.org/wikipedia/commons/thumb/8/8d/Shell_lub.png/200px-Shell_lub.png', 5, 1, 2, '2021-05-15', '2021-09-15', 10, 20, 5)
INSERT INTO Inventario(EAN, Descripcion, UrlImagen, IdTipo, IdMarca, IdProveedor, FechaCompra, FechaVencimiento, Costo, PrecioVenta, Stock) values(7798030610448, 'Agua destilada', 'https://http2.mlstatic.com/D_NQ_NP_710724-MLA43593591234_092020-V.jpg', 4, 4, 2, '2021-05-15', '2021-09-15', 10, 20, 5)
INSERT INTO Inventario(EAN, Descripcion, UrlImagen, IdTipo, IdMarca, IdProveedor, FechaCompra, FechaVencimiento, Costo, PrecioVenta, Stock) values(7798030610449, 'Líquido de frenos', 'https://st2.depositphotos.com/1439888/11103/i/600/depositphotos_111033484-stock-photo-brake-fluid-with-disc-brake.jpg', 3, 5, 2, '2021-05-15', '2021-09-15', 10, 20, 5)

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
	ApeNom varchar(100) null,
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

create table MarcasVehiculo(
	ID bigint primary key identity (1,1) not null,
	Descripcion varchar(50) not null,
	Estado bit not null default (1)
)
GO

create table Vehiculos(
	ID bigint identity(1,1) primary key not null,
	Patente varchar(8) unique not null,
	IdMarca bigint not null foreign key references MarcasVehiculo(ID),
	Modelo varchar(50) not null,
	AnioFabricacion int not null,
	FechaAlta date not null default (getdate()) check (FechaAlta = getdate()),
	IdCliente bigint not null foreign key references Clientes(ID),
	Estado bit not null default (1)
)
GO

create table TiposServicio(
	ID int primary key identity (1,1) not null,
	Descripcion varchar(30) unique check (Descripcion = 'Cambio de aceite' or Descripcion = 'Cambio de filtros' or Descripcion = 'Revisión'),
)
GO

create table Servicios(
	ID bigint primary key identity (1,1) not null,
	FechaRealizacion date not null,
	PatenteVehiculo varchar(8) not null foreign key references Vehiculos(Patente),
	IdTipo int not null foreign key references TiposServicio(ID),
	Comentarios varchar(400) null,
	IdCliente bigint not null foreign key references Clientes(ID),
	IdEmpleado bigint not null foreign key references Empleados(ID)
)
GO

create view ExportInventario
as
select I.EAN as EAN, I.Descripcion as Descripción, I.UrlImagen as Imagen, TP.Descripcion as TipoProducto, 
M.Descripcion as Marca, P.RazonSocial as Proveedor, 
CONVERT(VARCHAR(10),I.FechaCompra,105) as 'Fecha de Compra', CONVERT(VARCHAR(10),I.FechaVencimiento,105) as 'Fecha de Vencimiento',
I.Costo as Costo, I.PrecioVenta as PrecioVenta, I.Stock as Stock, I.Estado as Estado 
from Inventario as I
inner join TiposProducto as TP on I.IdTipo = TP.ID
inner join MarcasProducto as M on I.IdMarca = M.ID
inner join Proveedores as P on I.IdProveedor = P.ID 
GO

create procedure SP_INSERTAR_PRODUCTO(
	@EAN bigint,
	@Descripcion varchar(60),
	@UrlImagen varchar(300),
	@IdTipo bigint,
	@IdMarca bigint,
	@IdProveedor bigint,
	@FechaCompra date,
	@FechaVencimiento date,
	@Costo money,
	@PrecioVenta money,
	@Stock int
)
as
begin
	INSERT INTO Inventario(EAN, Descripcion, UrlImagen, IdTipo, IdMarca, IdProveedor, FechaCompra, FechaVencimiento, Costo, PrecioVenta, Stock)
	VALUES(@EAN, @Descripcion, @UrlImagen, @IdTipo, @IdMarca, @IdProveedor, @FechaCompra, @FechaVencimiento, @Costo, @PrecioVenta, @Stock)
end
GO

create procedure SP_ACTUALIZAR_PRODUCTO(
	@EAN bigint,
	@Descripcion varchar(60),
	@UrlImagen varchar(300),
	@IdTipo bigint,
	@IdMarca bigint,
	@IdProveedor bigint,
	@FechaCompra date,
	@FechaVencimiento date,
	@Costo money,
	@PrecioVenta money,
	@Stock int,
	@Estado bit
)
as
begin
	UPDATE Inventario SET Descripcion=@Descripcion, UrlImagen=@UrlImagen, IdTipo=@IdTipo, IdMarca=@IdMarca, IdProveedor=@IdProveedor, 
	FechaCompra=@FechaCompra, FechaVencimiento=@FechaVencimiento, Costo=@Costo, PrecioVenta=@PrecioVenta, Stock=@Stock, Estado=@Estado
	WHERE EAN=@EAN
end
GO

create procedure SP_ELIMINAR_PRODUCTO(
	@EAN bigint
)
as
begin
	DELETE FROM Inventario WHERE EAN = @EAN
end
GO