Create TABLE categoria (
id_Categoria int unsigned AUTO_INCREMENT primary key,
category_Num int unsigned default(1),
ticket_Num varchar(45),
nombre varchar(45)
);

select * from subcategoria;
insert into categoria(nombre)
values('tecnologia');
insert into categoria(nombre)
values('farmacia');
insert into categoria(nombre)
values('hogar');

update categoria set ticket_Num = '1.1' Where id_Categoria = 1;
update categoria set ticket_Num = '1.2' Where id_Categoria = 2;
update categoria set ticket_Num = '1.3' Where id_Categoria = 3;


select * from categoria;

create table subcategoria(
id_SubCategoria int unsigned AUTO_INCREMENT primary key,
subCategoria_Num int unsigned,
id_Categoria int unsigned,
ticket_Num varchar(45),
ticket_NumSub varchar(45),
nombre varchar(45)
);

alter table subcategoria add foreign key (id_Categoria) references categoria(id_Categoria);
alter table subcategoria add foreign key (ticket_Num) references categoria(ticket_Num);
insert into subcategoria(id_Categoria, subCategoria_Num, nombre)
values(1,1,'computacion');
insert into subcategoria(id_Categoria, subCategoria_Num, nombre)
values(1,2,'telefonia');
insert into subcategoria(id_Categoria, subCategoria_Num, nombre)
values(2,1,'medicamentos');
insert into subcategoria(id_Categoria, subCategoria_Num, nombre)
values(3,2,'baño');

update subcategoria set subCategoria_num = 1 where id_Subcategoria =4;

select * from subcategoria;

update subcategoria set ticket_NumSub = '1.1.1' where id_Categoria =1 AND subCategoria_Num = 1;
update subcategoria set ticket_NumSub = '1.1.2' where id_Categoria =1 AND subCategoria_Num =2;
update subcategoria set ticket_NumSub = '1.2.1' where id_Categoria = 2 AND subCategoria_Num=1;
update subcategoria set ticket_NumSub = '1.2.2' where id_Categoria = 2 AND subCategoria_Num=2;
update subcategoria set ticket_NumSub = '1.3.1' where id_Categoria = 3 AND subCategoria_Num = 1;

create table articulo(
sku int unsigned AUTO_INCREMENT primary Key,
articuloNum int unsigned,
inventario int unsigned,
ticketArticulo varchar(45),
numMaterial varchar(45),
nombreProducto varchar(45),
categoria varchar(45),
id_SubCategoria int unsigned
);

alter table articulo add foreign key (id_SubCategoria) references subcategoria(id_SubCategoria);
insert into articulo(id_SubCategoria, nombreProducto, numMaterial, categoria,inventario)
values(1,"Dell 4512","AX-4342FD",'1.1.1.2',3);
insert into articulo(id_SubCategoria, nombreProducto, numMaterial, categoria,inventario)
values(2,"Iphone X","AD-4332EE",'1.1.1.2.1',10);
insert into articulo(id_SubCategoria, nombreProducto, numMaterial, categoria,inventario)
values(1,"Correa","AC-5545Q",'1.1.2.2',0);
insert into articulo(id_SubCategoria, nombreProducto, numMaterial, categoria,inventario)
values(1,"Bata Hombre","BN-18643",'1.3.1.2',1);
insert into articulo(id_SubCategoria, nombreProducto, numMaterial, categoria,inventario)
values(1,"Aspirina","MD-7456AS",'1.2.1.1',22);

select * from articulo;

update articulo set categoria = '1.1.2.1' where sku = 2;

update articulo set ticketArticulo = categoria where sku != 0;

select * from categoria;
select * from subcategoria;
select * from articulo;