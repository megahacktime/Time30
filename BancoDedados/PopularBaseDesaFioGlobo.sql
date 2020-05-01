-- Regiões
Insert into TbRegioes (Regiao_id, Regiao_Nome) values (1, 'Norte');
Insert into TbRegioes (Regiao_id, Regiao_Nome) values (2, 'Nordeste');
Insert into TbRegioes (Regiao_id, Regiao_Nome) values (3, 'Sudeste');
Insert into TbRegioes (Regiao_id, Regiao_Nome) values (4, 'Sul');
Insert into TbRegioes (Regiao_id, Regiao_Nome) values (5, 'Centro-Oeste');


 

-- Estados

Insert into TbEstados (Estado_id, Estado_Nome, Estado_UF, Estado_Regiao_id) values (12, 'Acre', 'AC', 1);
Insert into TbEstados (Estado_id, Estado_Nome, Estado_UF, Estado_Regiao_id) values (27, 'Alagoas', 'AL', 2);
Insert into TbEstados (Estado_id, Estado_Nome, Estado_UF, Estado_Regiao_id) values (16, 'Amapá', 'AP', 1);
Insert into TbEstados (Estado_id, Estado_Nome, Estado_UF, Estado_Regiao_id) values (13, 'Amazonas', 'AM', 1);
Insert into TbEstados (Estado_id, Estado_Nome, Estado_UF, Estado_Regiao_id) values (29, 'Bahia', 'BA', 2);
Insert into TbEstados (Estado_id, Estado_Nome, Estado_UF, Estado_Regiao_id) values (23, 'Ceará', 'CE', 2);
Insert into TbEstados (Estado_id, Estado_Nome, Estado_UF, Estado_Regiao_id) values (53, 'Distrito Federal', 'DF', 5);
Insert into TbEstados (Estado_id, Estado_Nome, Estado_UF, Estado_Regiao_id) values (32, 'Espírito Santo', 'ES', 3);
Insert into TbEstados (Estado_id, Estado_Nome, Estado_UF, Estado_Regiao_id) values (52, 'Goiás', 'GO', 5);
Insert into TbEstados (Estado_id, Estado_Nome, Estado_UF, Estado_Regiao_id) values (21, 'Maranhão', 'MA', 2);
Insert into TbEstados (Estado_id, Estado_Nome, Estado_UF, Estado_Regiao_id) values (51, 'Mato Grosso', 'MT', 5);
Insert into TbEstados (Estado_id, Estado_Nome, Estado_UF, Estado_Regiao_id) values (50, 'Mato Grosso do Sul', 'MS', 5);
Insert into TbEstados (Estado_id, Estado_Nome, Estado_UF, Estado_Regiao_id) values (31, 'Minas Gerais', 'MG', 3);
Insert into TbEstados (Estado_id, Estado_Nome, Estado_UF, Estado_Regiao_id) values (15, 'Pará', 'PA', 1);
Insert into TbEstados (Estado_id, Estado_Nome, Estado_UF, Estado_Regiao_id) values (25, 'Paraíba', 'PB', 2);
Insert into TbEstados (Estado_id, Estado_Nome, Estado_UF, Estado_Regiao_id) values (41, 'Paraná', 'PR', 4);
Insert into TbEstados (Estado_id, Estado_Nome, Estado_UF, Estado_Regiao_id) values (26, 'Pernambuco', 'PE', 2);
Insert into TbEstados (Estado_id, Estado_Nome, Estado_UF, Estado_Regiao_id) values (22, 'Piauí', 'PI', 2);
Insert into TbEstados (Estado_id, Estado_Nome, Estado_UF, Estado_Regiao_id) values (33, 'Rio de Janeiro', 'RJ', 3);
Insert into TbEstados (Estado_id, Estado_Nome, Estado_UF, Estado_Regiao_id) values (24, 'Rio Grande do Norte', 'RN', 2);
Insert into TbEstados (Estado_id, Estado_Nome, Estado_UF, Estado_Regiao_id) values (43, 'Rio Grande do Sul', 'RS', 4);
Insert into TbEstados (Estado_id, Estado_Nome, Estado_UF, Estado_Regiao_id) values (11, 'Rondônia', 'RO', 1);
Insert into TbEstados (Estado_id, Estado_Nome, Estado_UF, Estado_Regiao_id) values (14, 'Roraima', 'RR', 1);
Insert into TbEstados (Estado_id, Estado_Nome, Estado_UF, Estado_Regiao_id) values (42, 'Santa Catarina', 'SC', 4);
Insert into TbEstados (Estado_id, Estado_Nome, Estado_UF, Estado_Regiao_id) values (35, 'São Paulo', 'SP', 3);
Insert into TbEstados (Estado_id, Estado_Nome, Estado_UF, Estado_Regiao_id) values (28, 'Sergipe', 'SE', 2);
Insert into TbEstados (Estado_id, Estado_Nome, Estado_UF, Estado_Regiao_id) values (17, 'Tocantins', 'TO', 1);


-- Categorias
Insert into TbCategorias (Categoria_id, Categoria_Nome)
values (1 , 'Notícias');
Insert into TbCategorias (Categoria_id, Categoria_Nome)
values (2 , 'Esporte');
Insert into TbCategorias (Categoria_id, Categoria_Nome)
values (3 , 'Entretenimento');
Insert into TbCategorias (Categoria_id, Categoria_Nome)
values (4 , 'Infatis');
Insert into TbCategorias (Categoria_id, Categoria_Nome)
values (5, 'Educação & Cultura');

-- Produtos
   -- Noticias
insert into TbProdutos( Produto_id, Produto_Nome, Produto_Categoria_id, 
Produto_Icones, Produto_mostrarIcone, Produto_Descricao , Produto_Abreviacao)
values(1, 'Portal G1' , 1, 'g1.png', true, 'Portal de Notícias da globo', 'G1');

insert into TbProdutos( Produto_id, Produto_Nome, Produto_Categoria_id, 
Produto_Icones, Produto_mostrarIcone, Produto_Descricao , Produto_Abreviacao)
values(2, 'Globo.com' , 1, 'gcom.png', true, 'Globo.com - Portal Globo.com', 'Gcom');


insert into TbProdutos( Produto_id, Produto_Nome, Produto_Categoria_id, 
Produto_Icones, Produto_mostrarIcone, Produto_Descricao , Produto_Abreviacao)
values(3, 'O globo' , 1, 'oglobo.png', true, 'Globo.com - Portal Globo.com', 'oglobo');

insert into TbProdutos( Produto_id, Produto_Nome, Produto_Categoria_id, 
Produto_Icones, Produto_mostrarIcone, Produto_Descricao , Produto_Abreviacao)
values(4, 'Globo News' , 1, 'gnews.png', true, 'Globo.com - Portal Globo.com', 'gnews');


 -- Esporte
 
 insert into TbProdutos( Produto_id, Produto_Nome, Produto_Categoria_id, 
Produto_Icones, Produto_mostrarIcone, Produto_Descricao , Produto_Abreviacao)
values(5, 'Globo Esporte' , 2, 'ge.png', true, 'Portal Globo Esporte - Esporte', 'ge');


 -- Entretenimento
 
 insert into TbProdutos( Produto_id, Produto_Nome, Produto_Categoria_id, 
Produto_Icones, Produto_mostrarIcone, Produto_Descricao , Produto_Abreviacao)
values(6, 'GSHOW' , 3, 'gshow.png', true, 'Portal Gshow Entretenimento', 'gshow');

 insert into TbProdutos( Produto_id, Produto_Nome, Produto_Categoria_id, 
Produto_Icones, Produto_mostrarIcone, Produto_Descricao , Produto_Abreviacao)
values(7, 'globo play' , 3, 'gplay.png', true, 'Portal Gshow Entretenimento', 'globoplay');

 insert into TbProdutos( Produto_id, Produto_Nome, Produto_Categoria_id, 
Produto_Icones, Produto_mostrarIcone, Produto_Descricao , Produto_Abreviacao)
values(8, 'MultShow' , 3, 'mshow.png', true, 'Multhow - Entretenimento', 'mshow');


 -- Infantis
 insert into TbProdutos( Produto_id, Produto_Nome, Produto_Categoria_id, 
Produto_Icones, Produto_mostrarIcone, Produto_Descricao , Produto_Abreviacao)
values(9, 'Gloob' , 4, 'Gloob.png', true, 'Multhow - Entretenimento', 'Gloob');


 -- Educação e Cultura
 insert into TbProdutos( Produto_id, Produto_Nome, Produto_Categoria_id, 
Produto_Icones, Produto_mostrarIcone, Produto_Descricao , Produto_Abreviacao)
values(10, 'Futura' , 5, 'Futura.png', true, 'Futura - Educação e Cultura', 'Futura');



-- Cidades
insert into TbCidades(Cidade_id, Cidade_Nome, Cidade_Estado_id)
values(1, 'Rio de Janeiro', 33);

insert into TbCidades(Cidade_id, Cidade_Nome, Cidade_Estado_id)
values(2, 'São João de Meriti', 33);

insert into TbCidades(Cidade_id, Cidade_Nome, Cidade_Estado_id)
values(3, 'Belford Roxo', 33);
 
insert into TbCidades(Cidade_id, Cidade_Nome, Cidade_Estado_id)
values(4, 'São Paulo', 35);

insert into TbCidades(Cidade_id, Cidade_Nome, Cidade_Estado_id)
values(5, 'Campinas', 35);

insert into TbCidades(Cidade_id, Cidade_Nome, Cidade_Estado_id)
values(6, 'Ribeirão Preto', 35);

insert into TbCidades(Cidade_id, Cidade_Nome, Cidade_Estado_id)
values(7, 'Nova Iguaçu', 33);


insert into TbCidades(Cidade_id, Cidade_Nome, Cidade_Estado_id)
values(8, 'Duque de Caxias', 33);

-- Usuarios
insert into TbUsuarios(Usuario_id , Usuario_Categoria_id , 
Usuario_Cidade_id, Usuario_Nome ,Usuario_Email , Usuario_Senha , Usuario_cep,
Usuario_admin , Usuario_DataDeNascimento)
values(1, 1, 2, 'Jorge Eugenio', 'jeugenio25@gmail.com','1234','25561203')




 
  




