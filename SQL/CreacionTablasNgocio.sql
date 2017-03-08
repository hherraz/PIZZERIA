use pizzeria;

CREATE TABLE Pedidos(
idPedido INTEGER AUTO_INCREMENT, 
Tipo_Pedido VARCHAR (30) NOT NULL,
No_mesa INTEGER,
NomGarzon VARCHAR (30) NOT NULL,
PedidoDesc VARCHAR (60) NOT NULL,
TotalPedido INTEGER,
MontoPropina INTEGER,
PropinaAbierta VARCHAR(3),
FormaDePago VARCHAR(12),
EnCaja INTEGER,	
Fecha_Pedido DATETIME,
PRIMARY KEY(idpedido)
);


CREATE TABLE Productos(
idProducto int(12) AUTO_INCREMENT,
descProducto VARCHAR(30) NOT NULL,
PrecioUnitario int(12),
Stock int(12),
Stock_Maximo int(12),
Stock_minimo int(12),
 PRIMARY KEY (idProducto));

CREATE TABLE ProductosVendidos(
idProdVendido int(12)AUTO_INCREMENT,
idProducto int(12),
idPedido int(12),
descProducto VARCHAR(30),
cantVendida int(12),
PrecioVentaUnitario int(12),
PrecioVentaTotal int(12),
PRIMARY KEY(idProdVendido));

CREATE TABLE LogUsuario(
idLogUsuario INTEGER AUTO_INCREMENT,
user VARCHAR(30),
fecha_ingreso TIMESTAMP DEFAULT CURRENT_TIMESTAMP ,
PRIMARY KEY(idLogUsuario));







 