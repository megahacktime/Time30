DROP TABLE IF EXISTS TbLogUso;

DROP TABLE IF EXISTS TbUsuarios;

DROP TABLE IF EXISTS Tbbuscacampos;

DROP TABLE IF EXISTS TbConteudo;

DROP TABLE IF EXISTS TbMenu;

DROP TABLE IF EXISTS Tbbuscaformularios;

DROP TABLE IF EXISTS Tbbuscatabelas;

DROP TABLE IF EXISTS TbCidades;

DROP TABLE IF EXISTS TbEstados;

DROP TABLE IF EXISTS TbProdutos;

DROP TABLE IF EXISTS TbCategorias;

DROP TABLE IF EXISTS TbTipoDado;

DROP TABLE IF EXISTS TbRegioes;

DROP TABLE IF EXISTS TbIcones;

DROP TABLE IF EXISTS TbControleHTML;

DROP TABLE IF EXISTS TbPerfis;

DROP TABLE IF EXISTS TbConfiguracoes;

CREATE TABLE TbConfiguracoes (
  Configuracao_id INTEGER UNSIGNED  NOT NULL   AUTO_INCREMENT,
  Configuracao_Data DATETIME  NULL  ,
  Configuracao_chave VARCHAR(100)  NULL  ,
  Configuracao_valor VARCHAR(250)  NULL  ,
  Configuracao_Tipo VARCHAR(100)  NULL  ,
  _deleted_ BIT  NULL DEFAULT 0   ,
PRIMARY KEY(Configuracao_id));


CREATE TABLE TbPerfis (
  Perfil_Id INTEGER UNSIGNED  NOT NULL   AUTO_INCREMENT,
  Perfil_Descricao VARCHAR(150)  NOT NULL  ,
  _deleted_ BIT  NOT NULL DEFAULT 0 ,
  Perfil_AdmGeral BIT  NULL DEFAULT 0   ,
PRIMARY KEY(Perfil_Id));


CREATE TABLE TbControleHTML (
  ControleHTML_id INTEGER UNSIGNED  NOT NULL   AUTO_INCREMENT,
  ControleHTML_Nome VARCHAR(254)  NULL    ,
PRIMARY KEY(ControleHTML_id));


CREATE TABLE TbIcones (
  Icone_id INTEGER UNSIGNED  NOT NULL   AUTO_INCREMENT,
  Icone_Icone VARCHAR(154)  NOT NULL  ,
  _deleted_ BIT  NULL DEFAULT 0   ,
PRIMARY KEY(Icone_id));


CREATE TABLE TbRegioes (
  Regiao_id INTEGER UNSIGNED  NOT NULL   AUTO_INCREMENT,
  Regiao_Nome VARCHAR(100)  NULL    ,
PRIMARY KEY(Regiao_id));


CREATE TABLE TbTipoDado (
  TipoDado_id INTEGER UNSIGNED  NOT NULL   AUTO_INCREMENT,
  TipoDado_Nome VARCHAR(250)  NULL    ,
PRIMARY KEY(TipoDado_id));


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
  Produto_Icone VARCHAR(150)  NULL  ,
  Produto_Data DATETIME  NULL DEFAULT current_timestamp() ,
  Produto_Ativo BIT  NULL DEFAULT 1 ,
  Produto_mostrarIcone BIT  NULL DEFAULT 0 ,
  Produto_Descricao TEXT  NULL  ,
  Produto_Abreviacao VARCHAR(20)  NULL  ,
  Produto_gratuito BIT  NOT NULL DEFAULT 1 ,
  _deleted_ BIT  NULL DEFAULT 0   ,
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


CREATE TABLE Tbbuscatabelas (
  BuscaTabela_id INTEGER UNSIGNED  NOT NULL   AUTO_INCREMENT,
  _deleted_ BIT  NOT NULL DEFAULT 0 ,
  BuscaTabela_Perfil_Id INTEGER UNSIGNED  NOT NULL  ,
  BuscaTabela_tabela TEXT  NULL  ,
  BuscaTabela_Descricao TEXT  NULL  ,
  BuscaTabela_condicao TEXT  NULL  ,
  BuscaTabela_condicaoComplemento TEXT  NULL    ,
PRIMARY KEY(BuscaTabela_id)  ,
INDEX Tbbuscatabelas_FKIndex222(BuscaTabela_Perfil_Id)  ,
INDEX Tbbuscatabelas_FKIndex1(BuscaTabela_Perfil_Id),
  FOREIGN KEY(BuscaTabela_Perfil_Id)
    REFERENCES TbPerfis(Perfil_Id)
      ON DELETE NO ACTION
      ON UPDATE NO ACTION);


CREATE TABLE Tbbuscaformularios (
  BuscaFormulario_id INTEGER UNSIGNED  NOT NULL   AUTO_INCREMENT,
  BuscaFormulario_BuscaTabela_id INTEGER UNSIGNED  NOT NULL  ,
  BuscaFormulario_tabela VARCHAR(254)  NULL  ,
  BuscaFormulario_Descricao VARCHAR(254)  NULL  ,
  BuscaFormulario_Data DATETIME  NULL    ,
PRIMARY KEY(BuscaFormulario_id)  ,
INDEX Tbbuscaformularios_FKIndex1(BuscaFormulario_BuscaTabela_id)  ,
INDEX Tbbuscaformularios_FKIndex10(BuscaFormulario_BuscaTabela_id),
  FOREIGN KEY(BuscaFormulario_BuscaTabela_id)
    REFERENCES Tbbuscatabelas(BuscaTabela_id)
      ON DELETE NO ACTION
      ON UPDATE NO ACTION);


CREATE TABLE TbMenu (
  Menu_id INTEGER UNSIGNED  NOT NULL   AUTO_INCREMENT,
  Menu_Perfil_Id INTEGER UNSIGNED  NULL DEFAULT 1 ,
  Menu_Menu_id INTEGER UNSIGNED  NULL  ,
  Menu_BuscaTabela_id INTEGER UNSIGNED  NULL  ,
  Menu_Descricao VARCHAR(250)  NULL  ,
  Menu_Principal BIT  NULL DEFAULT 0 ,
  _deleted_ BIT  NULL DEFAULT 0 ,
  Menu_Ordem INTEGER UNSIGNED  NULL  ,
  Menu_UrlDestino TEXT  NULL  ,
  Menu_ClasseIcone VARCHAR(154)  NULL    ,
PRIMARY KEY(Menu_id)  ,
INDEX TbMenu_FKIndex1(Menu_BuscaTabela_id)  ,
INDEX TbMenu_FKIndex2(Menu_Menu_id)  ,
INDEX TbMenu_FKIndex3(Menu_Perfil_Id)  ,
INDEX TbMenu_FKIndex10(Menu_BuscaTabela_id)  ,
INDEX TbMenu_FKIndex20(Menu_Menu_id)  ,
INDEX TbMenu_FKIndex30(Menu_Perfil_Id),
  FOREIGN KEY(Menu_BuscaTabela_id)
    REFERENCES Tbbuscatabelas(BuscaTabela_id)
      ON DELETE NO ACTION
      ON UPDATE NO ACTION,
  FOREIGN KEY(Menu_Menu_id)
    REFERENCES TbMenu(Menu_id)
      ON DELETE NO ACTION
      ON UPDATE NO ACTION,
  FOREIGN KEY(Menu_Perfil_Id)
    REFERENCES TbPerfis(Perfil_Id)
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


CREATE TABLE Tbbuscacampos (
  BuscaCampo_id INTEGER UNSIGNED  NOT NULL   AUTO_INCREMENT,
  BuscaCampo_ControleHTML_id INTEGER UNSIGNED  NOT NULL  ,
  BuscaCampo_buscaformulario_id INTEGER UNSIGNED  NULL  ,
  BuscaCampo_TipoDado_id INTEGER UNSIGNED  NOT NULL  ,
  BuscaCampo_BuscaTabela_id INTEGER UNSIGNED  NULL  ,
  BuscaCampo_CampoDescricao VARCHAR(254)  NULL  ,
  BuscaCampo_NomeCampo VARCHAR(250)  NULL  ,
  BuscaCampo_Echave BIT  NULL DEFAULT 0 ,
  BuscaCampo_Mascara VARCHAR(254)  NULL  ,
  _deleted_ BIT  NULL DEFAULT 0 ,
  BuscaCampo_ValorPadrao TEXT  NULL  ,
  BuscaCampo_ValorMaximo VARCHAR(254)  NULL  ,
  BuscaCampo_ValorMinimo VARCHAR(254)  NULL  ,
  BuscaCampo_Disabled BIT  NULL DEFAULT 0 ,
  BuscaCampo_FonteDados TEXT  NULL  ,
  BuscaCampo_Obrigatorio BIT  NULL DEFAULT 0   ,
PRIMARY KEY(BuscaCampo_id)  ,
INDEX Tbbuscacampos_FKIndex1(BuscaCampo_BuscaTabela_id)  ,
INDEX Tbbuscacampos_FKIndex2(BuscaCampo_ControleHTML_id)  ,
INDEX Tbbuscacampos_FKIndex3(BuscaCampo_TipoDado_id)  ,
INDEX Tbbuscacampos_FKIndex4(BuscaCampo_buscaformulario_id)  ,
INDEX Tbbuscacampos_FKIndex10(BuscaCampo_BuscaTabela_id)  ,
INDEX Tbbuscacampos_FKIndex20(BuscaCampo_TipoDado_id)  ,
INDEX Tbbuscacampos_FKIndex30(BuscaCampo_buscaformulario_id)  ,
INDEX Tbbuscacampos_FKIndex40(BuscaCampo_ControleHTML_id),
  FOREIGN KEY(BuscaCampo_BuscaTabela_id)
    REFERENCES Tbbuscatabelas(BuscaTabela_id)
      ON DELETE NO ACTION
      ON UPDATE NO ACTION,
  FOREIGN KEY(BuscaCampo_TipoDado_id)
    REFERENCES TbTipoDado(TipoDado_id)
      ON DELETE NO ACTION
      ON UPDATE NO ACTION,
  FOREIGN KEY(BuscaCampo_buscaformulario_id)
    REFERENCES Tbbuscaformularios(buscaformulario_id)
      ON DELETE NO ACTION
      ON UPDATE NO ACTION,
  FOREIGN KEY(BuscaCampo_ControleHTML_id)
    REFERENCES TbControleHTML(ControleHTML_id)
      ON DELETE NO ACTION
      ON UPDATE NO ACTION);


CREATE TABLE TbUsuarios (
  Usuario_id INTEGER UNSIGNED  NOT NULL   AUTO_INCREMENT,
  Usuario_Produto_id3 INTEGER UNSIGNED  NOT NULL DEFAULT 3 ,
  Usuario_Produto_id2 INTEGER UNSIGNED  NOT NULL DEFAULT 2 ,
  Usuario_Produto_id1 INTEGER UNSIGNED  NOT NULL DEFAULT 1 ,
  Usuario_Perfil_Id INTEGER UNSIGNED  NULL  ,
  Usuario_Cidade_id INTEGER UNSIGNED  NULL  ,
  Usuario_Nome VARCHAR(150)  NULL  ,
  Usuario_Email VARCHAR(100)  NULL  ,
  Usuario_Senha VARCHAR(50)  NULL  ,
  Usuario_ativo BIT  NULL DEFAULT 1 ,
  _deleted_ BIT  NULL DEFAULT 0 ,
  Usuario_cep VARCHAR(20)  NULL  ,
  Usuario_UsarIA BIT  NULL DEFAULT 1 ,
  Usuario_DataDeNascimento DATETIME  NULL    ,
PRIMARY KEY(Usuario_id)  ,
INDEX TbUsuarios_FKIndex1(Usuario_Cidade_id)  ,
INDEX TbUsuarios_FKIndex3(Usuario_Perfil_Id)  ,
INDEX TbUsuarios_FKIndex6(Usuario_Produto_id1)  ,
INDEX TbUsuarios_FKIndex4(Usuario_Produto_id2)  ,
INDEX TbUsuarios_FKIndex5(Usuario_Produto_id3),
  FOREIGN KEY(Usuario_Cidade_id)
    REFERENCES TbCidades(Cidade_id)
      ON DELETE NO ACTION
      ON UPDATE NO ACTION,
  FOREIGN KEY(Usuario_Perfil_Id)
    REFERENCES TbPerfis(Perfil_Id)
      ON DELETE NO ACTION
      ON UPDATE NO ACTION,
  FOREIGN KEY(Usuario_Produto_id1)
    REFERENCES TbProdutos(Produto_id)
      ON DELETE NO ACTION
      ON UPDATE NO ACTION,
  FOREIGN KEY(Usuario_Produto_id2)
    REFERENCES TbProdutos(Produto_id)
      ON DELETE NO ACTION
      ON UPDATE NO ACTION,
  FOREIGN KEY(Usuario_Produto_id3)
    REFERENCES TbProdutos(Produto_id)
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



