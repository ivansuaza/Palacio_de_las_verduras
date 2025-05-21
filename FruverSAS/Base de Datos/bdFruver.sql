create DATABASE dbFruver
use dbFruver


create table tblClasifcProducto(
Codigo int primary key,
Nombre varchar(50) Not Null);
go

create table tblProducto(
Codigo int primary key,
Nombre varchar(50) Not Null,
Codigo_Clasif INT NOT NULL, --FK
Precio float not NUll,
iva float ,
Activo bit not Null
FOREIGN KEY (Codigo_Clasif) REFERENCES tblClasifcProducto(Codigo)
);
go

create table tblTipo_Venta(
Codigo int primary key,
Nombre varchar(50) Not Null,
Descuento float 
);
go

create table tblFormaDePago(
Codigo int primary key,
Nombre varchar(50) Not Null,
Activo bit not Null
);
go

create table tblCargo(
Codigo int primary key,
Nombre varchar(30) Not Null,
Descripcion varchar(30)
);
go


create table tblGenero(
Codigo int primary key,
Nombre varchar(30) Not Null);
go

create table tbltipoDoc(
Codigo int primary key,
Nombre varchar(30) not null,
);
go

create table tblDepartamento(
Codigo int primary key,
Nombre varchar(30) not Null
);
go

create table tblCuidad(
Codigo int primary key,
Nombre varchar(30) not Null,
idDpto int not null
FOREIGN KEY (idDpto) REFERENCES tblDepartamento(Codigo),
);
go

select * from tblCuidad where idDpto = 1;

create table tblTipoTel(
Codigo int primary key,
Nombre varchar(30) not null
);
go

create table tblEmpleado(
Codigo int primary key,
idEmpleado int not Null,
NroDoc Int not null,
idGenero int not null,
idCargo int not null,
idTipoDoc int not null,
fecha_Ingreso varchar(30),
Nombre varchar(30) not Null,
Apellido Varchar(30) not Null,
Salario float not null,
Activo bit not Null
FOREIGN KEY (idGenero) REFERENCES tblGenero(Codigo),
FOREIGN KEY (idCargo) REFERENCES tblCargo(Codigo),
FOREIGN KEY (idTipoDoc) REFERENCES tbltipoDoc(Codigo),
);

create table tblDireccionEmpleado(
Codigo  int primary key,
idEmpleado int null,
idCuidad int not null,
Direccion varchar(50) NOT NULL,
Activo bit NOT NULL,
FOREIGN KEY (idEmpleado) REFERENCES tblEmpleado(Codigo),
FOREIGN KEY (idCuidad) REFERENCES tblCuidad(Codigo),
);
go

create table tblTelefonoEmpleado(
Codigo INT PRIMARY KEY,
NumTelefono int not null,
Activo Bit not null,
idTipoTel int not null,
idEmpleado int null
FOREIGN KEY (idTipoTel) REFERENCES tblTipoTel(Codigo),
FOREIGN KEY (idEmpleado) REFERENCES tblEmpleado(Codigo),
);
go


create table tblUsuario(
Codigo int primary key,
Codigo_Empleado int not null,
Contrasena  varchar(30) not null,
NombreUsuario varchar(30) not null,
Activo bit not Null
FOREIGN KEY (Codigo_Empleado) REFERENCES tblEmpleado(Codigo),
);
go

create table tblCliente(
Codigo int primary key,
idTipoDoc int not null,
idGenero  int not null,
Nombre varchar(30) not Null,
Apellido VARCHAR(30) NOT NULL,
NroDoc int not null,
Tipo_Cliente int ,
FOREIGN KEY (idTipoDoc) REFERENCES tbltipoDoc(Codigo),
FOREIGN KEY (idGenero) REFERENCES tblGenero(Codigo)
);
go

create table tblTelefonoCliente(
Codigo INT PRIMARY KEY,
NumTelefono int not null,
Activo Bit not null,
idTipoTel int not null,
idCliente int not null,
FOREIGN KEY (idTipoTel) REFERENCES tblTipoTel(Codigo),
FOREIGN KEY (idCliente) REFERENCES tblCliente(Codigo),
);
go

create table tblDireccionCliente(
Codigo  int primary key,
idCliente int not null,
idCuidad int not null,
Direccion varchar(50) NOT NULL,
Activo bit NOT NULL,
FOREIGN KEY (idCliente) REFERENCES tblCliente(Codigo),
FOREIGN KEY (idCuidad) REFERENCES tblCuidad(Codigo),
);
go

create table tblPedido (
Numero_Pedido INT PRIMARY KEY,
Fecha_Pedido Date NOT NULL,
Fecha_Entrega Date NOT NULL,
Domicilio BIT NOT NULL,
idProducto int not null,
idCliente int not null,
idUsuario int not null,
idTipoVenta int not null,
idFormaPago int not null,
FOREIGN KEY (idProducto) REFERENCES tblProducto(Codigo),
FOREIGN KEY (idCliente) REFERENCES tblCliente(Codigo),
FOREIGN KEY (idUsuario) REFERENCES tblUsuario(Codigo),
FOREIGN KEY (idTipoVenta) REFERENCES tblTipo_Venta(Codigo),
FOREIGN KEY (idFormaPago) REFERENCES tblFormaDePago(Codigo),
);
go

create table tblPedido_Direc(
Codigo int primary key,
idDireccion int not null,
idPedido int not null
FOREIGN KEY (idDireccion) REFERENCES tblDireccionCliente(Codigo),
FOREIGN KEY (idPedido) REFERENCES tblPedido(Numero_Pedido)
);
go

create table Detalle_Pedido(
Codigo int primary key,
Cantidad int not null,
Descuento float,
PrecioUnitario  float not null,
subtotal  float not null,
TotalPagar float not null,
iva  float ,
idProducto int not null,
CodigoPedido int not null,
FOREIGN KEY (idProducto) REFERENCES tblProducto(Codigo),
FOREIGN KEY (CodigoPedido) REFERENCES tblPedido(Numero_Pedido),
);
go




INSERT INTO tblClasifcProducto (Codigo, Nombre)
VALUES 
(1, 'Frutas'),
(2, 'Verduras');

INSERT INTO tblProducto (Codigo, Nombre, Codigo_Clasif, Precio, iva, Activo)
VALUES 
-- Frutas
(4, 'Pera', 1, 3.0, 0.19, 1),
(5, 'Uva', 1, 4.5, 0.19, 1),
(6, 'Naranja', 1, 2.8, 0.19, 1),
(7, 'Papaya', 1, 3.2, 0.19, 1),
(8, 'Fresa', 1, 6.0, 0.19, 1),
(9, 'Kiwi', 1, 5.0, 0.19, 1),
(10, 'Mango', 1, 3.7, 0.19, 1),
(11, 'Sandía', 1, 7.0, 0.19, 1),
(12, 'Melón', 1, 6.5, 0.19, 1),
(13, 'Cereza', 1, 8.5, 0.19, 1),

-- Verduras
(14, 'Papa', 2, 1.2, 0.19, 1),
(15, 'Tomate', 2, 1.8, 0.19, 1),
(16, 'Cebolla', 2, 1.5, 0.19, 1),
(17, 'Ajo', 2, 12.0, 0.19, 1),
(18, 'Pimentón', 2, 3.5, 0.19, 1),
(19, 'Lechuga', 2, 2.0, 0.19, 1),
(20, 'Brócoli', 2, 4.0, 0.19, 1),
(21, 'Espinaca', 2, 3.2, 0.19, 1),
(22, 'Calabacín', 2, 3.0, 0.19, 1),
(23, 'Pepino', 2, 2.5, 0.19, 1),
(24, 'Berenjena', 2, 4.8, 0.19, 1),
(25, 'Apio', 2, 2.2, 0.19, 1);

INSERT INTO tblTipo_Venta (Codigo, Nombre, Descuento)
VALUES 
(1, 'Mayorista', 0.10),
(2, 'Menudeo', 0.00);

INSERT INTO tblFormaDePago (Codigo, Nombre, Activo)
VALUES 
(1, 'Efectivo', 1),
(2, 'Tarjeta de Credito', 1),
(3, 'Crédito Debito', 1),
(4, 'Contado', 1);

INSERT INTO tblCargo (Codigo, Nombre, Descripcion)
VALUES 
(1, 'Administrador de Tienda', 'Gestiona operaciones'),
(2, 'Cajero', 'Atiende clientes'),
(3, 'Repartidor', 'Entrega pedidos');

INSERT INTO tblGenero (Codigo, Nombre)
VALUES 
(1, 'Masculino'),
(2, 'Femenino'),
(3, 'Transgénero'),
(4, 'No binario'),
(5, 'Otro');

INSERT INTO tbltipoDoc (Codigo, Nombre)
VALUES 
(1, 'Cédula de Ciudadanía'),
(2, 'Pasaporte'),
(3, 'Cédula de Extranjería'),
(4, 'NIT');

INSERT INTO tblDepartamento (Codigo, Nombre)
VALUES 
(1, 'Antioquia'),
(2, 'Cundinamarca'),
(3, 'Valle del Cauca'),
(4, 'Atlántico');

INSERT INTO tblCuidad (Codigo, Nombre, idDpto)
VALUES
(1, 'Medellín', 1),
(2, 'Envigado', 1),
(3, 'Bello', 1),
(4, 'Itagüí', 1),
(5, 'Rionegro', 1),
(6, 'Sabaneta', 1),
(7, 'Apartadó', 1),
(8, 'Bogotá', 2),
(9, 'Soacha', 2),
(10, 'Zipaquirá', 2),
(11, 'Chía', 2),
(12, 'Fusagasugá', 2),
(13, 'Facatativá', 2),
(14, 'Girardot', 2),
(15, 'Cali', 3),
(16, 'Palmira', 3),
(17, 'Buenaventura', 3),
(18, 'Jamundí', 3),
(19, 'Tuluá', 3),
(20, 'Cartago', 3),
(21, 'Yumbo', 3),
(22, 'Barranquilla', 4),
(23, 'Soledad', 4),
(24, 'Malambo', 4),
(25, 'Sabanalarga', 4),
(26, 'Baranoa', 4),
(27, 'Galapa', 4),
(28, 'Puerto Colombia', 4)
;


select * from tblCuidad where idDpto = 1;

INSERT INTO tblTipoTel (Codigo, Nombre)
VALUES 
(1, 'Celular'),
(2, 'Fijo'),
(3, 'Empresarial');

INSERT INTO tblEmpleado (Codigo, idEmpleado, NroDoc, idGenero, idCargo, idTipoDoc, fecha_Ingreso, Nombre, Apellido, Salario, Activo)
VALUES
-- Vendedores
(1, 101, 12345678, 1, 2, 1, '2023-01-15', 'Juan', 'Pérez', 2000000, 1),
(2, 102, 12345679, 2, 2, 1, '2023-02-01', 'Ana', 'Gómez', 2100000, 1),
(3, 103, 12345680, 1, 2, 1, '2023-03-20', 'Carlos', 'López', 1900000, 1),
(4, 104, 12345681, 2, 2, 1, '2023-04-10', 'Laura', 'Martínez', 2200000, 1),
(5, 105, 12345682, 1, 2, 1, '2023-05-05', 'Luis', 'Hernández', 2000000, 1),
(6, 106, 12345683, 2, 2, 1, '2023-06-25', 'María', 'Rodríguez', 2150000, 1),
(7, 107, 12345684, 1, 2, 1, '2023-07-15', 'Jorge', 'Morales', 2050000, 1),

-- Otros empleados (para variar un poco)
(8, 108, 12345685, 1, 1, 1, '2023-01-15', 'Pedro', 'Ramírez', 3000000, 1);


INSERT INTO tblDireccionEmpleado (Codigo, idEmpleado, idCuidad, Direccion, Activo)
VALUES 
(1, 1, 1, 'Calle 123 #45-67', 1),(2, 2, 3, 'Unidad Los Molinos Apt 204', 1),
(3, 3, 2, 'Carrera 10 #20-30', 1),(4, 4, 6, 'Calle 99 #99-21', 1),
(5, 5, 9, 'Unidad Barcelona', 1), (6, 6, 11, 'Av las Vegas #12-2', 1)
;

INSERT INTO tblTelefonoEmpleado (Codigo, NumTelefono, Activo, idTipoTel, idEmpleado)
VALUES 
(1, 3001234, 1, 1, 1),
(2, 6012345, 1, 2, 2);


INSERT INTO tblUsuario (Codigo, Codigo_Empleado, Contrasena, NombreUsuario, Activo)
VALUES
-- Usuarios para vendedores
(1, 1, '12345', 'juanperez', 1),      -- Juan Pérez
(2, 2, '23456', 'anagomez', 1),       -- Ana Gómez
(3, 3, '34567', 'carloslopez', 1),    -- Carlos López
(4, 4, '45678', 'lauramartinez', 1),  -- Laura Martínez
(5, 5, '56789', 'luishernandez', 1),  -- Luis Hernández
(6, 6, '67890', 'mariarodriguez', 1), -- María Rodríguez
(7, 7, '78901', 'jorgemorales', 1),   -- Jorge Morales

-- Usuarios para otros roles
(8, 8, '89012', 'pedroramirez', 1);   


select * from tblCliente;

INSERT INTO tblCliente (Codigo, idTipoDoc, idGenero, Nombre, Apellido, NroDoc, Tipo_Cliente)
VALUES
-- Cliente 1
(1, 1, 1, 'Camilo', 'Arango', 987654321, 1), -- Tipo de cliente 1
-- Cliente 2
(2, 2, 2, 'Sofía', 'García', 123456789, 2), -- Tipo de cliente 2
-- Cliente 3
(3, 1, 1, 'Luis', 'Mejía', 456123789, 1), -- Tipo de cliente 1
-- Cliente 4
(4, 1, 2, 'Valentina', 'Torres', 789456123, 3), -- Tipo de cliente 3
-- Cliente 5
(5, 2, 2, 'Diana', 'López', 321654987, 2); -- Tipo de cliente 2


INSERT INTO tblTelefonoCliente (Codigo, NumTelefono, Activo, idTipoTel, idCliente)
VALUES 
(1, 312345, 1, 1, 1), (2, 3123456, 1, 1, 1),
(3, 602345, 1, 2, 2), (4, 112233,1, 1, 2),
(5, 090876, 1, 2, 3), (6, 987574,1,1,3 ),
(7, 123456, 1, 1, 4), (8, 122134,1,1,4),
(9, 777455, 1, 1, 5), (10, 165573, 1, 1, 5);

INSERT INTO tblDireccionCliente (Codigo, idCliente, idCuidad, Direccion, Activo)
VALUES 
(1, 1, 1, 'Av. Principal #1-23', 1), (2, 2, 2, 'Carrera 12 #7 - 82', 1),
(3, 2, 2, 'Calle 10 #15-20', 1),(4, 3, 3, 'Unidad Belen apt 401', 1),
(5, 3, 5, 'Carrera 34 #5-10', 1),(6, 4, 4, 'Calle 21 #23-21', 1),
(7, 4, 6, 'Av Sur #54-23', 1),(8, 5, 9, 'Carrera 12 #01-12', 1),
(9, 5, 3, 'Calle 33 #9-28 ', 1),(10, 1, 11, 'Av 70 #12-1', 1),
(11, 1, 1, 'Calle 114 #55-25', 1),(12, 2, 10, 'Unidad los Nogales apt 203', 1)
;



INSERT INTO tblPedido 
(Numero_Pedido, Fecha_Pedido, Fecha_Entrega, Domicilio, idProducto, idCliente, idUsuario, idTipoVenta, idFormaPago)
VALUES
(1, '2024-11-22', '2024-11-23', 1, 4, 1, 1, 1, 1),
(2, '2024-11-22', '2024-11-23', 1, 5, 2, 1, 2, 2),
(3, '2024-11-22', '2024-11-23', 0, 6, 3, 1, 1, 3);

iNSERT INTO Detalle_Pedido (Codigo, Cantidad, Descuento, PrecioUnitario, subtotal, TotalPagar, iva, idProducto, CodigoPedido)
VALUES (1, 10, 0.0, 2000.0, 20000.0, 20000.0, 19.0, 5, 5); -- 1 es el Numero_Pedido existente

-- Detalle 1: Uvas
INSERT INTO Detalle_Pedido (Codigo, Cantidad, Descuento, PrecioUnitario, subtotal, TotalPagar, iva, idProducto, CodigoPedido)
VALUES 
(1, 10, 0.10, 4.5, (10 * 4.5), (10 * 4.5) * (1 + 0.19) - ((10 * 4.5) * 0.10), 0.19, 5, 1);

-- Detalle 2: Mango
INSERT INTO Detalle_Pedido (Codigo, Cantidad, Descuento, PrecioUnitario, subtotal, TotalPagar, iva, idProducto, CodigoPedido)
VALUES 
(2, 5, 0.10, 3.7, (5 * 3.7), (5 * 3.7) * (1 + 0.19) - ((5 * 3.7) * 0.10), 0.19, 10, 1);

select * from tblPedido 
SELECT * FROM Detalle_Pedido;

select @@SERVERNAME;