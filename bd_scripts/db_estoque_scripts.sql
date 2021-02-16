-- Dados Produto
insert into produto(NomeProduto,CategoriaProduto,Quantidade,Preco) values("Mouse","Periferico",25,25.98);
insert into produto(NomeProduto,CategoriaProduto,Quantidade,Preco) values("Teclado","Periferico",32,31.80);
insert into produto(NomeProduto,CategoriaProduto,Quantidade,Preco) values("Monitor","Periferico",15,300);
insert into produto(NomeProduto,CategoriaProduto,Quantidade,Preco) values("Placa-Mãe","Hardware",8,150);
insert into produto(NomeProduto,CategoriaProduto,Quantidade,Preco) values("Processadorr","Hardware",10,800);

-- Dados Cliente
insert into cliente values("10298412354","Alexandre");
insert into cliente values("10274687958","Eva");
insert into cliente values("02178535715","Roberto");
insert into cliente values("74185296302","Sara");
insert into cliente values("78465812545","Juliana");
insert into cliente values("98596522574","Avenilza");
insert into cliente values("44874458712","Armando");

-- Dados Endereços
insert into endereco(cpf,logradouro,numero,cep,cidade,uf) values("10298412354","Rua Alvarenga","69-A",012303123,"São Paulo","UF");
insert into endereco(cpf,logradouro,numero,cep,cidade,uf) values("10298412354","AV Portugal","80A",45547444,"Fortaleza","CE");

insert into endereco(cpf,logradouro,numero,cep,cidade,uf) values("10274687958","Rua Barão","23",02301055,"Suzano","SP");
insert into endereco(cpf,logradouro,numero,cep,cidade,uf) values("10274687958","Estrada Ferroso","32",123123123,"Cotia","SP");

insert into endereco(cpf,logradouro,numero,cep,cidade,uf) values("02178535715","Rua Ester","12-C",87548999,"Monte Verde","MG");

insert into endereco(cpf,logradouro,numero,cep,cidade,uf) values("74185296302","Av Angelica","156-B",06708000,"Porto Alegre","RS");

insert into endereco(cpf,logradouro,numero,cep,cidade,uf) values("78465812545","Rua Três Lagoas","203",02545000,"Curitiba","PR");

insert into endereco(cpf,logradouro,numero,cep,cidade,uf) values("98596522574","Estrada Canoas","15",47858622,"Piquet Carneiro","CE");

insert into endereco(cpf,logradouro,numero,cep,cidade,uf) values("44874458712","Rua Moçambique","150",68487110,"Maceió","AL");


select * from produto;
select * from cliente;
select * from endereco;
