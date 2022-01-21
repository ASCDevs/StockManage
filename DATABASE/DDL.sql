-- DATABASE Created with Oracle 21c Express
-- DDL - Data Definition Language
create table Category(
    id_category NUMBER GENERATED ALWAYS AS IDENTITY PRIMARY KEY,
    categ_name varchar(100),
    dt_created DATE
);

create table Product(
    id_product NUMBER GENERATED ALWAYS AS IDENTITY PRIMARY KEY,
    id_category NUMBER NOT NULL,
    prod_name varchar2(200) NOT NULL,
    prod_desc varchar2(200),
    price_buy NUMBER,
    price_sell NUMBER,
    dt_created DATE,
    CONSTRAINT fk_category
        FOREIGN KEY (id_category)
        REFERENCES Category(id_category)
);

create table StoreFilial(
    id_store NUMBER GENERATED ALWAYS AS IDENTITY PRIMARY KEY,
    store_name varchar2(200),
    store_address varchar2(200),
    store_city varchar2(100),
    store_district varchar2(100),
    store_country varchar2(100)
);

create table Storage(
    id_storage NUMBER GENERATED ALWAYS AS IDENTITY PRIMARY KEY,
    id_product NUMBER NOT NULL,
    id_store NUMBER NOT NULL,
    prod_qtd NUMBER NOT NULL,
    prod_limit NUMBER NOT NULL,
    dt_update DATE,
    CONSTRAINT fk_product 
        FOREIGN KEY (id_product)
        REFERENCES Product(id_product),
    CONSTRAINT fk_store
        FOREIGN KEY (id_store)
        REFERENCES Store(id_store)
);

create table OrderStatus(
    id_status NUMBER GENERATED ALWAYS AS IDENTITY PRIMARY KEY,
    status_desc VARCHAR2(100)
);

create table OrderProduct(
    id_order NUMBER GENERATED ALWAYS AS IDENTITY PRIMARY KEY,
    id_status NUMBER NOT NULL,
    dt_created DATE,
    dt_finished DATE,
    order_total NUMBER,
    order_totalitens NUMBER,
    CONSTRAINT fk_status
        FOREIGN KEY (id_status)
        REFERENCES OrderStatus(id_status)
);

create table OrderItem(
    id_ordemitem NUMBER GENERATED ALWAYS AS IDENTITY PRIMARY KEY,
    id_order NUMBER NOT NULL,
    id_product NUMBER NOT NULL,
    item_total NUMBER,
    item_qtd NUMBER,
    CONSTRAINT fk_order
        FOREIGN KEY (id_order)
        REFERENCES OrderProduct(id_order),
    CONSTRAINT fk_product2
        FOREIGN KEY (id_product)
        REFERENCES Product(id_product)
);

