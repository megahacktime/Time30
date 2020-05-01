DROP TABLE IF EXISTS TbLogUso;

DROP TABLE IF EXISTS TbConteudo;

DROP TABLE IF EXISTS TbUsuarios;

DROP TABLE IF EXISTS TbCidades;

DROP TABLE IF EXISTS TbEstados;

DROP TABLE IF EXISTS TbProdutos;

DROP TABLE IF EXISTS TbCategorias;

DROP TABLE IF EXISTS TbRegioes;

CREATE TABLE TbRegioes (
  Regiao_id INTEGER UNSIGNED  NOT NULL   AUTO_INCREMENT,
  Regiao_Nome VARCHAR(100)  NULL    ,
PRIMARY KEY(Regiao_id));


CREATE TABLE TbCategorias (
  Categoria_id INTEGER UNSIGNED  NOT NULL   AUTO_INCREMENT,
  Categoria_Nome VARCHAR(150)  NULL  ,
  Categoria_ativo BIT  NULL DEFAULT 1 ,
  _deleted_ BIT  NULL DEFAULT 0   ,
PRIMARY KEY(Categoria_id));


CREATE TABLE TbProdutos (
  Produto_id INTEGER UNSIGNED  NOT NULL   AUTO_INCREMENT,
  Produto_Nome VARCHAR(150)  NOT NULL  ,
  Produto_Categoria_id INTEGER UNSIGNED  NOT NULL  ,
  Produto_Icones VARCHAR(150)  NULL  ,
  Produto_Data DATETIME  NULL DEFAULT current_timestamp() ,
  Produto_Ativo BIT  NULL DEFAULT 1 ,
  Produto_mostrarIcone BIT  NULL DEFAULT 0 ,
  Produto_Descricao TEXT  NULL  ,
  Produto_Abreviacao VARCHAR(20)  NULL  ,
  Produto_gratuito BIT  NOT NULL DEFAULT 1   ,
PRIMARY KEY(Produto_id)  ,
INDEX TbProdutos_FKIndex1(Produto_Categoria_id),
  FOREIGN KEY(Produto_Categoria_id)
    REFERENCES TbCategorias(Categoria_id)
      ON DELETE NO ACTION
      ON UPDATE NO ACTION);


CREATE TABLE TbEstados (
  Estado_id INTEGER UNSIGNED  NOT NULL   AUTO_INCREMENT,
  Estado_Regiao_id INTEGER UNSIGNED  NOT NULL  ,
  Estado_UF VARCHAR(2)  NULL  ,
  Estado_Nome VARCHAR(150)  NULL  ,
  _deleted_ BIT  NULL DEFAULT 0   ,
PRIMARY KEY(Estado_id)  ,
INDEX TbEstados_FKIndex1(Estado_Regiao_id),
  FOREIGN KEY(Estado_Regiao_id)
    REFERENCES TbRegioes(Regiao_id)
      ON DELETE NO ACTION
      ON UPDATE NO ACTION);


CREATE TABLE TbCidades (
  Cidade_id INTEGER UNSIGNED  NOT NULL   AUTO_INCREMENT,
  Cidade_Estado_id INTEGER UNSIGNED  NOT NULL  ,
  Cidade_Nome VARCHAR(150)  NULL  ,
  _deleted_ BIT  NULL DEFAULT 0   ,
PRIMARY KEY(Cidade_id)  ,
INDEX TbCidades_FKIndex1(Cidade_Estado_id),
  FOREIGN KEY(Cidade_Estado_id)
    REFERENCES TbEstados(Estado_id)
      ON DELETE NO ACTION
      ON UPDATE NO ACTION);


CREATE TABLE TbUsuarios (
  Usuario_id INTEGER UNSIGNED  NOT NULL   AUTO_INCREMENT,
  Usuario_Categoria_id INTEGER UNSIGNED  NULL  ,
  Usuario_Cidade_id INTEGER UNSIGNED  NULL  ,
  Usuario_Nome VARCHAR(150)  NULL  ,
  Usuario_Email VARCHAR(100)  NULL  ,
  Usuario_Senha VARCHAR(50)  NULL  ,
  Usuario_ativo BIT  NULL DEFAULT 1 ,
  _deleted_ BIT  NULL DEFAULT 0 ,
  Usuario_cep VARCHAR(20)  NULL  ,
  Usuario_UsarIA BIT  NULL DEFAULT 1 ,
  Usuario_admin BIT  NULL DEFAULT 0 ,
  Usuario_DataDeNascimento DATETIME  NULL    ,
PRIMARY KEY(Usuario_id)  ,
INDEX TbUsuarios_FKIndex1(Usuario_Cidade_id)  ,
INDEX TbUsuarios_FKIndex2(Usuario_Categoria_id),
  FOREIGN KEY(Usuario_Cidade_id)
    REFERENCES TbCidades(Cidade_id)
      ON DELETE NO ACTION
      ON UPDATE NO ACTION,
  FOREIGN KEY(Usuario_Categoria_id)
    REFERENCES TbCategorias(Categoria_id)
      ON DELETE NO ACTION
      ON UPDATE NO ACTION);


CREATE TABLE TbConteudo (
  Conteudo_id INTEGER UNSIGNED  NOT NULL   AUTO_INCREMENT,
  Conteudo_dataFimExibicao DATETIME  NOT NULL  ,
  Conteudo_Cidade_id INTEGER UNSIGNED  NULL  ,
  Conteudo_Estado_id INTEGER UNSIGNED  NULL  ,
  Conteudo_Produto_id INTEGER UNSIGNED  NOT NULL  ,
  Conteudo_Nome VARCHAR(250)  NULL  ,
  Conteudo_Descricao TEXT  NULL  ,
  Conteudo_ativo BIT  NULL  ,
  Conteudo_dataCadastro DATETIME  NULL DEFAULT current_timestamp() ,
  Conteudo_dataInicioExibicao DATETIME  NULL DEFAULT current_timestamp() ,
  _deleted_ BIT  NULL DEFAULT 0 ,
  Conteudo_URL TEXT  NULL  ,
  Conteudo_Resumo TEXT  NULL  ,
  Conteudo_Conteudo TEXT  NULL    ,
PRIMARY KEY(Conteudo_id)  ,
INDEX TbConteudo_FKIndex1(Conteudo_Produto_id)  ,
INDEX TbConteudo_FKIndex2(Conteudo_Estado_id)  ,
INDEX TbConteudo_FKIndex3(Conteudo_Cidade_id),
  FOREIGN KEY(Conteudo_Produto_id)
    REFERENCES TbProdutos(Produto_id)
      ON DELETE NO ACTION
      ON UPDATE NO ACTION,
  FOREIGN KEY(Conteudo_Estado_id)
    REFERENCES TbEstados(Estado_id)
      ON DELETE NO ACTION
      ON UPDATE NO ACTION,
  FOREIGN KEY(Conteudo_Cidade_id)
    REFERENCES TbCidades(Cidade_id)
      ON DELETE NO ACTION
      ON UPDATE NO ACTION);


CREATE TABLE TbLogUso (
  LogUso_id INTEGER UNSIGNED  NOT NULL   AUTO_INCREMENT,
  LogUso_Usuario_id INTEGER UNSIGNED  NOT NULL  ,
  LogUso_Conteudo_id INTEGER UNSIGNED  NULL  ,
  LogUso_Produto_id INTEGER UNSIGNED  NULL  ,
  LogUso_Categoria_id INTEGER UNSIGNED  NULL  ,
  LogUso_DataGravacao DATETIME  NULL DEFAULT current_timestamp() ,
  _deleted_ BIT  NULL DEFAULT 0   ,
PRIMARY KEY(LogUso_id)  ,
INDEX TbLogUso_FKIndex1(LogUso_Categoria_id)  ,
INDEX TbLogUso_FKIndex2(LogUso_Produto_id)  ,
INDEX TbLogUso_FKIndex3(LogUso_Conteudo_id)  ,
INDEX TbLogUso_FKIndex4(LogUso_Usuario_id),
  FOREIGN KEY(LogUso_Categoria_id)
    REFERENCES TbCategorias(Categoria_id)
      ON DELETE NO ACTION
      ON UPDATE NO ACTION,
  FOREIGN KEY(LogUso_Produto_id)
    REFERENCES TbProdutos(Produto_id)
      ON DELETE NO ACTION
      ON UPDATE NO ACTION,
  FOREIGN KEY(LogUso_Conteudo_id)
    REFERENCES TbConteudo(Conteudo_id)
      ON DELETE NO ACTION
      ON UPDATE NO ACTION,
  FOREIGN KEY(LogUso_Usuario_id)
    REFERENCES TbUsuarios(Usuario_id)
      ON DELETE NO ACTION
      ON UPDATE NO ACTION);



