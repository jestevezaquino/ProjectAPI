/*********** ELIMINAR BASE DE DATOS ************/

use master
go
drop database ProjectAPI

/*********** ELIMINAR BASE DE DATOS ************/

/*********** CREAR Y USAR BASE DE DATOS ************/

go
create database ProjectAPI
go
use ProjectAPI
go

/*********** CREAR Y USAR BASE DE DATOS ************/

/*********************MODULO DE MANTENIMIENTO*********************/
create table Productos
(
	ProductoID int identity(1,1),
	Nombre varchar(max) not null,
	Precio decimal(8,2) not null,
	constraint pk_productos primary key(ProductoID) 
)
go
create table Proveedores
(
	ProveedorID int identity(1,1),
	Cedula varchar(11) not null,
	Nombre varchar(max) not null,
	Telefono varchar(10) not null,
	Email varchar(max) not null,
	constraint pk_proveedores primary key(ProveedorID)
)
go
create unique index uidx_proveedores_cedula on Proveedores(Cedula)
go
create table Clientes
(
	ClienteID int identity(1,1),
	Cedula varchar(11) not null,
	Nombre varchar(max) not null,
	Telefono varchar(10) not null,
	Email varchar(max) not null,
	Categoria varchar(20) not null,
	constraint pk_clientes primary key(ClienteID),
	constraint ck_categoria check(Categoria in('Premium','Regular'))
)
go
create unique index uidx_clientes_cedula on Clientes(Cedula)
go

/*********************MODULO DE MANTENIMIENTO*********************/

/*********************MODULO DE PROCESOS*********************/

create table Entradas
(
	EntradaID int identity(1,1),
	ProductoID int not null,
	Cantidad int not null,
	ProveedorID int not null,
	Fecha DateTime not null,
	constraint pk_entrada primary key(EntradaID)
)
go
create table Stock
(
	StockID int identity(1,1),
	ProductoID int not null,
	Cantidad int not null,
	Proveedores varchar(max) not null,
	Fecha DateTime not null,
	constraint pk_stock primary key(StockID)
)
go
create table Facturacion 
(
	FacturaID int identity(1,1),
	ClienteID int not null,
	Descripcion varchar(max),
	CantidadProductos int not null,
	SubTotal decimal(18,2) not null,
	DescuentoPorciento int not null,
	Total decimal(18,2) not null,
	Fecha DateTime not null,
	constraint pk_facturacion primary key(FacturaID)
)
go

/*********************MODULO DE PROCESOS*********************/

