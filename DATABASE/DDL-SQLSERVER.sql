create database storagemanage;
use storagemanage;

create table Category(
	id_category INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
	categ_name VARCHAR(100),
	dt_created DATE
);

create table Product(
	id_product INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
	id_category INT NOT NULL FOREIGN KEY REFERENCES Category(id_category),
	prod_name VARCHAR(200) NOT NULL,
	prod_desc VARCHAR(200),
	price_buy DECIMAL(19,2),
	price_sell DECIMAL(19,2),
	dt_created DATE
);

create table StoreFilial(
	id_store INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
	store_name VARCHAR(200),
	store_address VARCHAR(200),
	store_city VARCHAR(100),
	store_district VARCHAR(100),
	store_country VARCHAR(100)
);


create table Storage(
	id_storage INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
	id_product INT NOT NULL FOREIGN KEY REFERENCES Product(id_product),
	id_store INT NOT NULL FOREIGN KEY REFERENCES StoreFilial(id_store),
	prod_qtd INT NOT NULL,
	prod_limit INT NOT NULL,
	dt_update DATE
);

create table OrderStatus(
	id_status INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
	status_desc VARCHAR(100)
);

create table OrderProduct(
	id_order INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
	id_status INT NOT NULL FOREIGN KEY REFERENCES OrderStatus(id_status),
	dt_created DATE,
	dt_finished DATE,
	order_total DECIMAL(19,2),
	order_totalitens INT
);

create table OrderItem(
	id_orderitem INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
	id_order INT NOT NULL FOREIGN KEY REFERENCES OrderProduct(id_order),
	id_product INT NULL FOREIGN KEY REFERENCES Product(id_product),
	item_total DECIMAL(19,2),
	item_qtd INT
);
