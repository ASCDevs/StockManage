create database estoque;
use estoque;

create table Produto(
	ProdutoId int primary key auto_increment,
    NomeProduto varchar(70) not null,
    CategoriaProduto varchar(70),
    Quantidade int,
    Preco decimal(5,2)
);

create table Cliente(
	cpf char(11) not null primary key,
    NomeCliente varchar(75) not null
);

create table Endereco(
	cpf char(11),
    EnderecoId int auto_increment,
    Logradouro varchar(70),
    Numero char(10),
    CEP int,
    Cidade varchar(60),
    UF char(2),
    foreign key(cpf) references Cliente(cpf),
    primary key(EnderecoId,cpf)
);

select * from Produto;
select * from cliente;
select * from endereco;