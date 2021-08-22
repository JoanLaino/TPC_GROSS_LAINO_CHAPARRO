create database GROSS_LAINO_CHAPARRO_DB
GO

use GROSS_LAINO_CHAPARRO_DB
GO

create table TiposProducto(
	ID bigint primary key identity (1,1) not null,
	Descripcion varchar(50) unique not null
)
GO

create table MarcasProducto(
	ID bigint primary key identity (1,1) not null,
	Descripcion varchar(50) unique not null,
	Estado bit not null default (1)
)
GO

create table Proveedores(
	ID bigint primary key identity (1,1) not null,
	CUIT varchar(11) unique not null,
	RazonSocial varchar(100) unique not null,
	Estado bit not null default (1)
)
GO

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
GO

INSERT INTO TiposProducto(Descripcion) values('Lubricante')
INSERT INTO TiposProducto(Descripcion) values('Aceite')
INSERT INTO TiposProducto(Descripcion) values('Líquido de frenos')
INSERT INTO TiposProducto(Descripcion) values('Agua destilada')
INSERT INTO TiposProducto(Descripcion) values('Líquido refrigerante')
GO

INSERT INTO Proveedores(CUIT, RazonSocial) values('11111111111', 'ABC S.A.')
INSERT INTO Proveedores(CUIT, RazonSocial) values('22222222222', 'DEF S.R.L.')
INSERT INTO Proveedores(CUIT, RazonSocial) values('33333333333', 'GHI S.C.')
GO

INSERT INTO MarcasProducto(Descripcion) values('Shell')
INSERT INTO MarcasProducto(Descripcion) values('YPF')
INSERT INTO MarcasProducto(Descripcion) values('Castrol')
INSERT INTO MarcasProducto(Descripcion) values('Water')
INSERT INTO MarcasProducto(Descripcion) values('Dot3')
GO

INSERT INTO Inventario(EAN, Descripcion, UrlImagen, IdTipo, IdMarca, IdProveedor, FechaCompra, FechaVencimiento, Costo, PrecioVenta, Stock) values(7798030610445, 'Lubricante muy bueno', 'https://live.staticflickr.com/3771/12164538394_32d87cf00b_b.jpg', 1, 3, 1, '2021-05-15', '2021-09-15', 10, 20, 5)
INSERT INTO Inventario(EAN, Descripcion, UrlImagen, IdTipo, IdMarca, IdProveedor, FechaCompra, FechaVencimiento, Costo, PrecioVenta, Stock) values(7798030610446, 'Aceite 15W40', 'https://lubricentrocarlitos.com.ar/wp-content/uploads/2017/10/elaion-f50.jpg', 2, 2, 1, '2021-05-15', '2021-09-15', 10, 20, 5)
INSERT INTO Inventario(EAN, Descripcion, UrlImagen, IdTipo, IdMarca, IdProveedor, FechaCompra, FechaVencimiento, Costo, PrecioVenta, Stock) values(7798030610447, 'Líquido refrigerante concentrado', 'https://upload.wikimedia.org/wikipedia/commons/thumb/8/8d/Shell_lub.png/200px-Shell_lub.png', 5, 1, 2, '2021-05-15', '2021-09-15', 10, 20, 5)
INSERT INTO Inventario(EAN, Descripcion, UrlImagen, IdTipo, IdMarca, IdProveedor, FechaCompra, FechaVencimiento, Costo, PrecioVenta, Stock) values(7798030610448, 'Agua destilada', 'https://http2.mlstatic.com/D_NQ_NP_710724-MLA43593591234_092020-V.jpg', 4, 4, 2, '2021-05-15', '2021-09-15', 10, 20, 5)
INSERT INTO Inventario(EAN, Descripcion, UrlImagen, IdTipo, IdMarca, IdProveedor, FechaCompra, FechaVencimiento, Costo, PrecioVenta, Stock) values(7798030610449, 'Líquido de frenos', 'https://st2.depositphotos.com/1439888/11103/i/600/depositphotos_111033484-stock-photo-brake-fluid-with-disc-brake.jpg', 3, 5, 3, '2021-05-15', '2021-09-15', 10, 20, 5)
GO

create table TiposCliente(
	ID smallint primary key identity (1,1),
	Descripcion varchar(30) unique check 
	(Descripcion = 'Empresa' or Descripcion = 'Particular' or 
	Descripcion = 'Monotributista' or Descripcion = 'Estatal')
)
GO

create table Clientes(
	ID bigint primary key identity (1,1) not null,
	IDTipo smallint not null foreign key references TiposCliente(ID),
	CUIT_DNI varchar(11) unique not null,
	RazonSocial varchar(100) null,
	ApeNom varchar(100) null,
	FechaAlta date default (getdate()) not null,
	Mail varchar(100) unique not null,
	Telefono varchar(50) not null,
	TotalVehiculosRegistrados int default (0) check (TotalVehiculosRegistrados >= 0),
	Estado bit default (1)
)
GO

create table TiposUsuario(
	ID int primary key identity (1,1),
	Descripcion varchar(30) unique check (Descripcion = 'Administrador' or Descripcion = 'Jefe' or Descripcion = 'Empleado'),
	Estado bit default (1)
)
GO

create table Usuarios(
	ID int primary key identity (1,1) not null,
	TipoUser int not null foreign key references TiposUsuario(ID),
	Usuario varchar(50) unique not null,
	Pass varchar(50) not null,
	Mail varchar(100) unique not null,
	FechaAlta date default (getdate()),
	Estado bit not null default (1)
)
GO

INSERT INTO TiposUsuario(Descripcion) VALUES('Empleado')
INSERT INTO TiposUsuario(Descripcion) VALUES('Jefe')
INSERT INTO Usuarios(TipoUser, Usuario, Pass, Mail) VALUES(1, 'test', 'test', 'test@test.com')
INSERT INTO Usuarios(TipoUser, Usuario, Pass, Mail) VALUES(2, 'admin', 'admin', 'admin@admin.com')
INSERT INTO Usuarios(TipoUser, Usuario, Pass, Mail) VALUES(1, 'empleado', 'empleado', 'empleado@hotmail.com')
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
	TotalServiciosRealizados int not null default (0) check (TotalServiciosRealizados >= 0),
	Estado bit not null default (1)
)
GO

create table MarcasVehiculo(
	ID bigint primary key identity (1,1) not null,
	Descripcion varchar(50) unique not null
)
GO

INSERT INTO MarcasVehiculo(Descripcion) values('Volkswagen')
INSERT INTO MarcasVehiculo(Descripcion) values('Chevrolet')
INSERT INTO MarcasVehiculo(Descripcion) values('Ford')
INSERT INTO MarcasVehiculo(Descripcion) values('Honda')
INSERT INTO MarcasVehiculo(Descripcion) values('Renault')
GO

create table Vehiculos(
	ID bigint identity(1,1) primary key not null,
	Patente varchar(7) unique not null,
	IdMarca bigint not null foreign key references MarcasVehiculo(ID),
	Modelo varchar(50) not null,
	AnioFabricacion int not null,
	FechaAlta date not null default (getdate()),
	IdCliente bigint not null foreign key references Clientes(ID),
	Estado bit not null default (1)
)
GO

create table TiposServicio(
	ID int primary key identity (1,1) not null,
	Descripcion varchar(100) unique,
	Estado bit not null default(1)
)
GO

create table Servicios(
	ID bigint primary key identity (1,1) not null,
	FechaRealizacion date not null,
	PatenteVehiculo varchar(7) not null foreign key references Vehiculos(Patente),
	IdTipo int not null foreign key references TiposServicio(ID),
	Comentarios varchar(400) null,
	IdCliente bigint not null foreign key references Clientes(ID),
	IdEmpleado bigint not null foreign key references Empleados(ID),
	Estado varchar(12) not null default('Pendiente') check(Estado = 'Pendiente' OR Estado = 'En ejecución' OR Estado = 'Completado' OR Estado = 'Cancelado')
)
GO

create view ExportInventario
as
select I.ID as ID, I.EAN as EAN, I.Descripcion as Descripción, I.UrlImagen as Imagen, IdTipo, TP.Descripcion as TipoProducto, 
IdMarca, M.Descripcion as Marca, IdProveedor, P.RazonSocial as Proveedor, 
CONVERT(VARCHAR(10),I.FechaCompra,105) as 'Fecha de Compra', CONVERT(VARCHAR(10),I.FechaVencimiento,105) as 'Fecha de Vencimiento',
I.Costo as Costo, I.PrecioVenta as PrecioVenta, I.Stock as Stock, I.Estado as Estado, M.Estado as EstadoMarca, P.Estado as EstadoProveedor 
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
	@Stock int,
	@Estado bit
)
as
begin
	INSERT INTO Inventario(EAN, Descripcion, UrlImagen, IdTipo, IdMarca, IdProveedor, FechaCompra, FechaVencimiento, Costo, PrecioVenta, Stock, Estado)
	VALUES(@EAN, @Descripcion, @UrlImagen, @IdTipo, @IdMarca, @IdProveedor, @FechaCompra, @FechaVencimiento, @Costo, @PrecioVenta, @Stock, @Estado)
end
GO

create procedure SP_ACTUALIZAR_PRODUCTO(
	@ID bigint,
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
	WHERE ID=@ID
end
GO

create view ExportTiposProducto
as
select TP.ID as ID, TP.Descripcion as Descripcion
from TiposProducto TP
GO

create procedure SP_INSERTAR_TIPO_PRODUCTO(
	@Descripcion varchar(60)
)
as
begin
	INSERT INTO TiposProducto(Descripcion) VALUES(@Descripcion)
end
GO

create procedure SP_ELIMINAR_TIPO_PRODUCTO(
	@ID bigint
)
as
begin
	DELETE FROM TiposProducto WHERE ID = @ID
end
GO

CREATE view ExportEmpleados
as
select E.ID as ID, E.Legajo as Legajo, E.Cuil as Cuil, E.ApeNom, CONVERT(VARCHAR(10),E.FechaAlta,105) as FechaAlta, 
CONVERT(VARCHAR(10),E.FechaNacimiento,105) as FechaNacimiento, E.Mail as Mail, E.Telefono as Telefono, E.TotalServiciosRealizados as ServiciosRealizados
from Empleados as E
GO

Create view ExportServicios
as 
select CONVERT(VARCHAR(10),s.FechaRealizacion,105) as 'Fecha de Realizacion', s.PatenteVehiculo as Patente,
(Select ts.Descripcion from TiposServicio ts where ts.id = s.IdTipo) as 'Tipo de Servicio', s.Comentarios as Comentarios,
(select c.ApeNom from Clientes c where c.ID = s.IdEmpleado) as Cliente
from Servicios s
GO

insert into Empleados (Legajo,CUIL,ApeNom,FechaAlta,FechaNacimiento,Mail,Telefono) values ('333','20123456788','Homero Simpson','10-10-2000','1-1-1980','asdasd@asd.com','1234567890')
insert into Empleados (Legajo,CUIL,ApeNom,FechaAlta,FechaNacimiento,Mail,Telefono) values ('222','88765432102','Marge Simpson','10-10-2000','1-1-1980','abcd@abcd.com','0123456789')
GO

create procedure SP_INSERTAR_EMPLEADO(
    @Legajo varchar(6),
    @CUIL varchar(13),
    @ApeNom varchar(100),
    @FechaAlta date,
    @FechaNacimiento date,
    @Mail varchar(100),
    @Telefono varchar (50)
)
as
begin
    INSERT INTO Empleados(Legajo, CUIL, ApeNom, FechaAlta, FechaNacimiento, Mail, Telefono )
    VALUES(@Legajo, @CUIL, @ApeNom, @FechaAlta, @FechaNacimiento, @Mail, @Telefono)
end
GO

create procedure SP_INSERTAR_USUARIO(
	@User varchar(50),
	@Pass varchar(50),
	@Mail varchar(100),
	@TipoUsuario int
)
as
begin	
		INSERT INTO Usuarios(TipoUser, Usuario, Pass, Mail)
		VALUES (@TipoUsuario, @User, @Pass, @Mail)	
end
go

create view ExportClientes
as
	select C.ID, C.CUIT_DNI as 'CUITDNI', isnull(C.RazonSocial,'-') as RazonSocial, isnull(C.ApeNom,'-') as ApeNom, T.ID as 'IdTipo', T.Descripcion as 'TipoCliente',
	CONVERT(VARCHAR(10),C.FechaAlta,105) as FechaAlta, C.Mail, C.Telefono, (select count(*) from Vehiculos V where V.IdCliente = C.ID) as TotalVehiculosRegistrados, C.Estado
	from Clientes C
	inner join TiposCliente T on IdTipo = T.ID
GO

insert into TiposCliente (Descripcion) values('Empresa')
insert into TiposCliente (Descripcion) values('Particular')
insert into TiposCliente (Descripcion) values('Monotributista')
insert into TiposCliente (Descripcion) values('Estatal')
GO

insert into Clientes (IDTipo, CUIT_DNI, ApeNom, Mail, Telefono)
values(2, 15326856, 'Roberto Villalobos', 'asdasd@gmail.com', '1123456789')
insert into Clientes (IDTipo, CUIT_DNI, RazonSocial, Mail, Telefono)
values(1, 35343323214, 'Salamanca SA', 'salamancasa@gmail.com', '1101234567')
GO

create view ExportProveedores
as
select P.ID ID, P.CUIT CUIT, P.RazonSocial RazonSocial, (select count(I.ID) from Inventario I where I.IdProveedor = P.ID) Asignaciones, P.Estado Estado
from Proveedores P
GO

create procedure SP_INSERTAR_PROVEEDOR(
	@CUIT varchar(11),
	@RazonSocial varchar(100)
)as
begin
	INSERT INTO Proveedores (CUIT, RazonSocial)
				Values (@CUIT, @RazonSocial)
end
GO

create procedure SP_ACTUALIZAR_CLIENTE(
	@ID bigint,
	@IdTipo smallint,
	@CUIT_DNI varchar(11),
	@RazonSocial varchar(100),
	@ApeNom varchar(100),
	@FechaAlta date,
	@Mail varchar(100),
	@Telefono varchar(50),
	@Estado bit
)as
begin
	UPDATE Clientes Set IDTipo = @IdTipo, CUIT_DNI = @CUIT_DNI, RazonSocial = @RazonSocial,
	ApeNom = @ApeNom, FechaAlta = @FechaAlta, Mail = @Mail,
	Telefono = @Telefono, Estado = @Estado WHERE ID = @ID
end
GO

create procedure SP_AGREGAR_CLIENTE_DNI(
	@IdTipo smallint,
	@CUIT_DNI varchar(11),
	@ApeNom varchar(100),
	@Mail varchar(100),
	@Telefono varchar(50)
)as
begin
	INSERT INTO Clientes(CUIT_DNI, ApeNom, IDTipo, Mail, Telefono)
	VALUES(@CUIT_DNI, @ApeNom, @IdTipo, @Mail, @Telefono)
end
GO

create procedure SP_AGREGAR_CLIENTE_CUIT(
	@IdTipo smallint,
	@CUIT_DNI varchar(11),
	@RazonSocial varchar(100),
	@Mail varchar(100),
	@Telefono varchar(50)
)as
begin
	INSERT INTO Clientes(CUIT_DNI, RazonSocial, IDTipo, Mail, Telefono)
	VALUES(@CUIT_DNI, @RazonSocial, @IdTipo, @Mail, @Telefono)
end
GO

create table HorariosLunesViernes(
    ID int primary key identity (1,1) not null,
    LunesViernes varchar(5) unique not null
)
GO

create table HorariosSabado(
    ID int primary key identity (1,1) not null,
    Sabado varchar(5) unique not null
)
GO

insert INTO HorariosLunesViernes(LunesViernes) values('08:00')
insert INTO HorariosLunesViernes(LunesViernes) values('08:30')
insert INTO HorariosLunesViernes(LunesViernes) values('09:00')
insert INTO HorariosLunesViernes(LunesViernes) values('09:30')
insert INTO HorariosLunesViernes(LunesViernes) values('10:00')
insert INTO HorariosLunesViernes(LunesViernes) values('10:30')
insert INTO HorariosLunesViernes(LunesViernes) values('11:00')
insert INTO HorariosLunesViernes(LunesViernes) values('11:30')
insert INTO HorariosLunesViernes(LunesViernes) values('12:00')
insert INTO HorariosLunesViernes(LunesViernes) values('12:30')
insert INTO HorariosLunesViernes(LunesViernes) values('13:00')
insert INTO HorariosLunesViernes(LunesViernes) values('13:30')
insert INTO HorariosLunesViernes(LunesViernes) values('14:00')
insert INTO HorariosLunesViernes(LunesViernes) values('14:30')
insert INTO HorariosLunesViernes(LunesViernes) values('15:00')
insert INTO HorariosLunesViernes(LunesViernes) values('15:30')
insert INTO HorariosLunesViernes(LunesViernes) values('16:00')
insert INTO HorariosLunesViernes(LunesViernes) values('16:30')
insert INTO HorariosLunesViernes(LunesViernes) values('17:00')
insert INTO HorariosLunesViernes(LunesViernes) values('17:30')
GO

insert INTO HorariosSabado(Sabado) values('08:00')
insert INTO HorariosSabado(Sabado) values('08:30')
insert INTO HorariosSabado(Sabado) values('09:00')
insert INTO HorariosSabado(Sabado) values('09:30')
insert INTO HorariosSabado(Sabado) values('10:00')
insert INTO HorariosSabado(Sabado) values('10:30')
insert INTO HorariosSabado(Sabado) values('11:00')
insert INTO HorariosSabado(Sabado) values('11:30')
insert INTO HorariosSabado(Sabado) values('12:00')
insert INTO HorariosSabado(Sabado) values('12:30')
GO

create table Turnos(
    ID bigint primary key not null identity(1,1),
	IdTipoServicio int not null,
	IdCliente bigint not null foreign key references Clientes(ID),
	IdVehiculo bigint not null foreign key references Vehiculos(ID),
	Dia varchar(9) not null check (Dia <> 'Domingo' OR Dia <> 'Sunday'),
    FechaHora datetime unique not null check ((DATENAME(WEEKDAY, FechaHora)) <> 'Domingo'),
	IDHorario int not null foreign key references HorariosLunesViernes(ID) --(del 1 al 20)
)
GO

create view ExportTurnos
as
select ID as ID, Dia as Dia, CONVERT(VARCHAR(10),FechaHora,105) as Fecha, CONVERT(VARCHAR(5),FechaHora,108) as Hora,
isnull((select C.ApeNom from Clientes C where ID = T.IdCliente),(select C.RazonSocial from Clientes C where ID = T.IdCliente)) as Cliente, 
(select C.CUIT_DNI from Clientes C where ID = T.IdCliente) as CUIT_DNI, (select V.Patente from Vehiculos V where ID = T.IdVehiculo) as Patente,
IDHorario as IDHorario, IdTipoServicio as IdTipoServicio, (select TS.Descripcion from TiposServicio TS where ID = IdTipoServicio) as TipoServicio
from Turnos T
GO

create procedure SP_AGREGAR_TURNO(
    @FechaHora datetime,
	@IDHorario int,
	@Dia varchar(9),
	@IdCliente bigint,
	@IdVehiculo bigint,
	@IdTipoServicio int
)as
begin
    INSERT INTO Turnos(Dia, FechaHora, IDHorario, IdCliente, IdVehiculo, IdTipoServicio) values(@Dia, @FechaHora, @IDHorario, @IdCliente, @IdVehiculo, @IdTipoServicio)
end
GO

create procedure SP_TURNOS_SELECCIONADOS(
	@Fecha varchar(10)
)as
begin
	SELECT IDHorario as ID FROM Turnos WHERE CONVERT(VARCHAR(10),FechaHora,105) = TRANSLATE(@Fecha,'/','-')
end
GO

create procedure SP_AGREGAR_VEHICULO(
	@Patente varchar(7),
	@IdMarca bigint,
	@Modelo varchar(50),
	@AnioFabricacion int,
	@IdCliente bigint
)as
begin
	INSERT INTO Vehiculos(Patente, IdMarca, Modelo, AnioFabricacion, IdCliente)
	Values (@Patente, @IdMarca, @Modelo, @AnioFabricacion, @IdCliente)
end
GO

EXEC SP_AGREGAR_VEHICULO 'ABC123', 2, 'Corsa', 2006, 1
GO

create view ExportVehiculos
as
	SELECT V.ID as ID, V.Patente as Patente, (select M.Descripcion from MarcasVehiculo M 
	Where M.ID = V.IdMarca) as Marca, V.Modelo as Modelo, V.AnioFabricacion as 'Año de fabricación',
	CONVERT(VARCHAR(10),V.FechaAlta,105) as 'Fecha de alta', (select isnull(C.ApeNom, C.RazonSocial) from Clientes C Where C.ID = V.IdCliente)
	as Cliente, Estado as Estado from Vehiculos V
GO

create view ExportUsuarios
as
	SELECT U.ID as ID, (select T.Descripcion as TipoUser from TiposUsuario T where U.TipoUser = T.ID) as TipoUser,
	U.Usuario as Usuario, U.Pass as Pass, U.Mail as Mail, CONVERT(VARCHAR(10),U.FechaAlta,105) as FechaAlta,
	Estado as Estado from Usuarios U
GO

insert into Turnos(IdTipoServicio, IdCliente, IdVehiculo, Dia, FechaHora, IDHorario)
values (1, 1, 1, 'Sábado', '22-08-2022 09:30:00.000', 
(select ID from HorariosLunesViernes where LunesViernes LIKE '%09:00%'))

insert into TiposServicio(Descripción) values('Revisión de aceite')
insert into TiposServicio(Descripción) values('Revisión de filtros')
insert into TiposServicio(Descripción) values('Revisión de aceite y filtros')
insert into TiposServicio(Descripción) values('Revisión de líquido refrigerante')
insert into TiposServicio(Descripción) values('Revisión de líquido de frenos')
insert into TiposServicio(Descripción) values('Revisión general')