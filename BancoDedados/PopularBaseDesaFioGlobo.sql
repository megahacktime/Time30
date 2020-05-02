

-- #### POPULA TABELAS GERAÇÃO AUTOMÁTICA ## 

 INSERT INTO `jeugenio25_MegaTime30`.`TbPerfis` (`Perfil_Id` , `Perfil_Descricao` , `Perfil_AdmGeral`   ) VALUES (1,'Administrador Geral' , 1 );
 INSERT INTO `jeugenio25_MegaTime30`.`TbPerfis` (`Perfil_Id` , `Perfil_Descricao` , `Perfil_AdmGeral`   ) VALUES (2,'Usuário' , 0 );




 -- Configuracoes
INSERT INTO `jeugenio25_MegaTime30`.`TbConfiguracoes` (  `Configuracao_chave` , `Configuracao_valor` , `Configuracao_Data`) VALUES ( 'NomeAplicacao' , ' ADM TIME 30', current_timestamp());
INSERT INTO `jeugenio25_MegaTime30`.`TbConfiguracoes` (  `Configuracao_chave` , `Configuracao_valor` , `Configuracao_Data`) VALUES ( 'TitleAplicacao' , ' ADM TIME 30', current_timestamp());
INSERT INTO `jeugenio25_MegaTime30`.`TbConfiguracoes` (  `Configuracao_chave` , `Configuracao_valor` , `Configuracao_Data`) VALUES ( 'PastaSistema' , 'E:\Vhosts\ideiaspara.com.br\httpdocs\Time30ADM', current_timestamp());
INSERT INTO `jeugenio25_MegaTime30`.`TbConfiguracoes` (  `Configuracao_chave` , `Configuracao_valor` , `Configuracao_Data`) VALUES ( 'URLRaiz' , 'http://www.ideiaspara.com.br/IdeasERP/', current_timestamp());
INSERT INTO `jeugenio25_MegaTime30`.`TbConfiguracoes` (  `Configuracao_chave` , `Configuracao_valor` , `Configuracao_Data`) VALUES ( 'QtdItensPorPaginas' , '10', current_timestamp());
INSERT INTO `jeugenio25_MegaTime30`.`TbConfiguracoes` (  `Configuracao_chave` , `Configuracao_valor` , `Configuracao_Data`) VALUES ( 'MensagemBemvindo' , ' ADM TIME 30 - DESAFIO GLOBO - Sistema de Gestão de Usuários ', current_timestamp());



-- Icones
INSERT INTO `jeugenio25_MegaTime30`.`TbIcones` (`Icone_Icone`) VALUES ('ND');
INSERT INTO `jeugenio25_MegaTime30`.`TbIcones` (`Icone_Icone`) VALUES ('glyphicon glyphicon-th');
INSERT INTO `jeugenio25_MegaTime30`.`TbIcones` (`Icone_Icone`) VALUES ('glyphicon glyphicon-list-alt');
INSERT INTO `jeugenio25_MegaTime30`.`TbIcones` (`Icone_Icone`) VALUES ('glyphicon glyphicon-wrench');
INSERT INTO `jeugenio25_MegaTime30`.`TbIcones` (`Icone_Icone`) VALUES ('glyphicon glyphicon-calendar');
INSERT INTO `jeugenio25_MegaTime30`.`TbIcones` (`Icone_Icone`) VALUES ('glyphicon glyphicon-earphone');
INSERT INTO `jeugenio25_MegaTime30`.`TbIcones` (`Icone_Icone`) VALUES ('glyphicon glyphicon-plus-sign');
INSERT INTO `jeugenio25_MegaTime30`.`TbIcones` (`Icone_Icone`) VALUES ('glyphicon glyphicon-cog');
INSERT INTO `jeugenio25_MegaTime30`.`TbIcones` (`Icone_Icone`) VALUES ('glyphicon glyphicon-user');
INSERT INTO `jeugenio25_MegaTime30`.`TbIcones` (`Icone_Icone`) VALUES ('glyphicon glyphicon-folder-open');



-- Config Logins
INSERT INTO `jeugenio25_MegaTime30`.`TbConfiguracoes` ( `Configuracao_chave` , `Configuracao_valor` , `Configuracao_Data`) VALUES ( 'ExibirTelaLogin' , 'true', current_timestamp());
INSERT INTO `jeugenio25_MegaTime30`.`TbConfiguracoes` ( `Configuracao_chave` , `Configuracao_valor` , `Configuracao_Data`) VALUES ( 'NomeSessaoLogin' , 'sessaoLogin', current_timestamp());
INSERT INTO `jeugenio25_MegaTime30`.`TbConfiguracoes` ( `Configuracao_chave` , `Configuracao_valor` , `Configuracao_Data`) VALUES ( 'tabelaLogin' , 'TbUsuarios', current_timestamp());
INSERT INTO `jeugenio25_MegaTime30`.`TbConfiguracoes` ( `Configuracao_chave` , `Configuracao_valor` , `Configuracao_Data`) VALUES ( 'CampoPerfil' , 'Usuario_Perfil_Id', current_timestamp());
INSERT INTO `jeugenio25_MegaTime30`.`TbConfiguracoes` ( `Configuracao_chave` , `Configuracao_valor` , `Configuracao_Data`) VALUES ( 'CampoUsuarioLogin' , 'Usuario_Email', current_timestamp());
INSERT INTO `jeugenio25_MegaTime30`.`TbConfiguracoes` ( `Configuracao_chave` , `Configuracao_valor` , `Configuracao_Data`) VALUES ( 'CampoSenhaLogin' , 'Usuario_Senha', current_timestamp());
INSERT INTO `jeugenio25_MegaTime30`.`TbConfiguracoes` ( `Configuracao_chave` , `Configuracao_valor` , `Configuracao_Data`) VALUES ( 'CampoAtivoLogin' , 'Usuario_ativo', current_timestamp());
INSERT INTO `jeugenio25_MegaTime30`.`TbConfiguracoes` ( `Configuracao_chave` , `Configuracao_valor` , `Configuracao_Data`) VALUES ( 'CampoIdLogin' , 'Usuario_id', current_timestamp());
INSERT INTO `jeugenio25_MegaTime30`.`TbConfiguracoes` ( `Configuracao_chave` , `Configuracao_valor` , `Configuracao_Data`) VALUES ( 'CampoNomeLogin' , 'Usuario_Nome', current_timestamp());

INSERT INTO `jeugenio25_MegaTime30`.`TbControleHTML` (`ControleHTML_Nome`) VALUES ('ND');
INSERT INTO `jeugenio25_MegaTime30`.`TbControleHTML` (`ControleHTML_Nome`) VALUES ('text');
INSERT INTO `jeugenio25_MegaTime30`.`TbControleHTML` (`ControleHTML_Nome`) VALUES ('radio');
INSERT INTO `jeugenio25_MegaTime30`.`TbControleHTML` (`ControleHTML_Nome`) VALUES ('select');
INSERT INTO `jeugenio25_MegaTime30`.`TbControleHTML` (`ControleHTML_Nome`) VALUES ('chekbox');
INSERT INTO `jeugenio25_MegaTime30`.`TbControleHTML` (`ControleHTML_Nome`) VALUES ('DatePicker');
INSERT INTO `jeugenio25_MegaTime30`.`TbControleHTML` (`ControleHTML_Nome`) VALUES ('inputFile');
INSERT INTO `jeugenio25_MegaTime30`.`TbControleHTML` (`ControleHTML_Nome`) VALUES ('Lista Edicao');


INSERT INTO `jeugenio25_MegaTime30`.`TbTipoDado` (`TipoDado_Nome`) VALUES ('string');
INSERT INTO `jeugenio25_MegaTime30`.`TbTipoDado` (`TipoDado_Nome`) VALUES ('int');
INSERT INTO `jeugenio25_MegaTime30`.`TbTipoDado` (`TipoDado_Nome`) VALUES ('DateTime');
INSERT INTO `jeugenio25_MegaTime30`.`TbTipoDado` (`TipoDado_Nome`) VALUES ('Double');
 






-- Menus Principais
INSERT INTO `jeugenio25_MegaTime30`.`TbMenu` (   `Menu_BuscaTabela_id`, `Menu_Descricao`, `Menu_Principal`, `_deleted_`, `Menu_Ordem`, `Menu_ClasseIcone`  , `Menu_Perfil_Id`   ) VALUES (NULL, 'Manutencoes', 1, 0, 1, 'glyphicon glyphicon-wrench',1 );
INSERT INTO `jeugenio25_MegaTime30`.`TbMenu` (   `Menu_BuscaTabela_id`, `Menu_Descricao`, `Menu_Principal`, `_deleted_`, `Menu_Ordem`, `Menu_ClasseIcone`  , `Menu_Perfil_Id`  ) VALUES (NULL, 'Cadastros', 1, 0, 2, 'glyphicon glyphicon-wrench', 2 );
 

-- Cadastro de paginas  _listagem
INSERT INTO `jeugenio25_MegaTime30`.`Tbbuscatabelas` ( `BuscaTabela_tabela`, `BuscaTabela_Descricao`, `BuscaTabela_condicao`, `_deleted_` ,  `BuscaTabela_Perfil_Id` ) VALUES ('Tbbuscatabelas tb ', 'Cadastro de Páginas', 'tb._deleted_ = 0', 0,  2  );
INSERT INTO `jeugenio25_MegaTime30`.`Tbbuscacampos` (`BuscaCampo_ControleHTML_id`, `BuscaCampo_TipoDado_id`, `BuscaCampo_BuscaTabela_id`, `BuscaCampo_CampoDescricao`, `BuscaCampo_NomeCampo`, `BuscaCampo_Echave`) VALUES ('1', '1', '1', 'Código', 'BuscaTabela_id', b'1');
INSERT INTO `jeugenio25_MegaTime30`.`Tbbuscacampos` (`BuscaCampo_ControleHTML_id`, `BuscaCampo_TipoDado_id`, `BuscaCampo_BuscaTabela_id`, `BuscaCampo_CampoDescricao`, `BuscaCampo_NomeCampo`, `BuscaCampo_Echave`) VALUES ('2', '1', '1', 'Descrição', 'BuscaTabela_Descricao', b'1');
INSERT INTO `jeugenio25_MegaTime30`.`Tbbuscacampos` (`BuscaCampo_ControleHTML_id`, `BuscaCampo_TipoDado_id`, `BuscaCampo_BuscaTabela_id`, `BuscaCampo_CampoDescricao`, `BuscaCampo_NomeCampo`, `BuscaCampo_Echave`) VALUES ('2', '1', '1', 'Tabela', 'BuscaTabela_tabela', b'1');
INSERT INTO `jeugenio25_MegaTime30`.`TbMenu` (`Menu_BuscaTabela_id`, `Menu_Descricao`, `Menu_Principal`, `_deleted_`, `Menu_Ordem`, `Menu_ClasseIcone` , `Menu_Menu_id` ,   `Menu_Perfil_Id`     ) VALUES (1, 'Cadastro de Pàginas', 0, 0, 1, 'glyphicon glyphicon-th',1 ,1);


-- Cadastro de Pagina Formularios  
INSERT INTO `jeugenio25_MegaTime30`.`Tbbuscaformularios` (`BuscaFormulario_BuscaTabela_id`,   `BuscaFormulario_tabela`, `BuscaFormulario_Descricao`) VALUES ('1',   'Tbbuscatabelas', 'Edição Páginas');
INSERT INTO `jeugenio25_MegaTime30`.`Tbbuscacampos` (`BuscaCampo_ControleHTML_id`, `BuscaCampo_TipoDado_id`, `BuscaCampo_buscaformulario_id`, `BuscaCampo_CampoDescricao`, `BuscaCampo_NomeCampo`, `BuscaCampo_Echave`, `BuscaCampo_Disabled` ) VALUES ('1', '1', '1', 'Código', 'BuscaTabela_id', 1, 1);
INSERT INTO `jeugenio25_MegaTime30`.`Tbbuscacampos` (`BuscaCampo_ControleHTML_id`, `BuscaCampo_TipoDado_id`, `BuscaCampo_buscaformulario_id`, `BuscaCampo_CampoDescricao`, `BuscaCampo_NomeCampo`, `BuscaCampo_Echave`) VALUES ('2', '1', '1', 'Descrição', 'BuscaTabela_Descricao', 0);
INSERT INTO `jeugenio25_MegaTime30`.`Tbbuscacampos` (`BuscaCampo_ControleHTML_id`, `BuscaCampo_TipoDado_id`, `BuscaCampo_buscaformulario_id`, `BuscaCampo_CampoDescricao`, `BuscaCampo_NomeCampo`, `BuscaCampo_Echave`) VALUES ('2', '1', '1', 'Tabela', 'BuscaTabela_tabela', 0);
INSERT INTO `jeugenio25_MegaTime30`.`Tbbuscacampos` (`BuscaCampo_ControleHTML_id`, `BuscaCampo_TipoDado_id`, `BuscaCampo_buscaformulario_id`, `BuscaCampo_CampoDescricao`, `BuscaCampo_NomeCampo`, `BuscaCampo_Echave`) VALUES ('2', '1', '1', 'Condição', 'BuscaTabela_condicao', 0); 
INSERT INTO `jeugenio25_MegaTime30`.`Tbbuscacampos` (`BuscaCampo_ControleHTML_id`, `BuscaCampo_TipoDado_id`, `BuscaCampo_buscaformulario_id`, `BuscaCampo_CampoDescricao`, `BuscaCampo_NomeCampo`, `BuscaCampo_Echave`) VALUES ('2', '1', '1', 'Complemento', 'BuscaTabela_condicaoComplemento', 0); 
INSERT INTO `jeugenio25_MegaTime30`.`Tbbuscacampos` (`BuscaCampo_ControleHTML_id`, `BuscaCampo_TipoDado_id`, `BuscaCampo_buscaformulario_id`, `BuscaCampo_CampoDescricao`, `BuscaCampo_NomeCampo`, `BuscaCampo_FonteDados` , `BuscaCampo_Echave`) VALUES ('4', '1', '1', 'Perfil', 'BuscaTabela_Perfil_Id', ' select  Perfil_Id ,  Perfil_Descricao from   TbPerfis where _deleted_ = 0 ',  0); 
 

  
-- Cadastro de Menus - Listagem
INSERT INTO `jeugenio25_MegaTime30`.`Tbbuscatabelas` (`BuscaTabela_tabela`, `BuscaTabela_Descricao`, `BuscaTabela_condicao` , `_deleted_`, `BuscaTabela_Perfil_Id` ) VALUES ('TbMenu mn', 'Cadastro de Menus', 'mn._deleted_ = 0', 0 , 2);
INSERT INTO `jeugenio25_MegaTime30`.`Tbbuscacampos` (`BuscaCampo_ControleHTML_id`, `BuscaCampo_TipoDado_id`, `BuscaCampo_BuscaTabela_id`, `BuscaCampo_CampoDescricao`, `BuscaCampo_NomeCampo`, `BuscaCampo_Echave`) VALUES ('1', '1', '2', 'Código', 'Menu_id', b'1');
INSERT INTO `jeugenio25_MegaTime30`.`Tbbuscacampos` (`BuscaCampo_ControleHTML_id`, `BuscaCampo_TipoDado_id`, `BuscaCampo_BuscaTabela_id`, `BuscaCampo_CampoDescricao`, `BuscaCampo_NomeCampo`, `BuscaCampo_Echave`) VALUES ('2', '1', '2', 'Descrição', 'Menu_Descricao', b'1');
INSERT INTO `jeugenio25_MegaTime30`.`TbMenu` (`Menu_BuscaTabela_id`, `Menu_Descricao`, `Menu_Principal`, `_deleted_`, `Menu_Ordem`, `Menu_ClasseIcone` , `Menu_Menu_id`    ) VALUES (2, 'Cadastro de Menus', 0, 0, 2, 'glyphicon glyphicon-list-alt',1 );
 
 
 
 
-- Cadastro de Menus - Formularios
INSERT INTO `jeugenio25_MegaTime30`.`Tbbuscaformularios` (`BuscaFormulario_BuscaTabela_id`,  `BuscaFormulario_tabela`, `BuscaFormulario_Descricao`) VALUES ('2',   'TbMenu', 'Edição do Menu');
INSERT INTO `jeugenio25_MegaTime30`.`Tbbuscacampos` (`BuscaCampo_ControleHTML_id`, `BuscaCampo_TipoDado_id`, `BuscaCampo_buscaformulario_id`, `BuscaCampo_CampoDescricao`, `BuscaCampo_NomeCampo`, `BuscaCampo_Echave`, `BuscaCampo_Disabled` ) VALUES ('1', '1', '2', 'Código', 'Menu_id', b'1', 1);
INSERT INTO `jeugenio25_MegaTime30`.`Tbbuscacampos` (`BuscaCampo_ControleHTML_id`, `BuscaCampo_TipoDado_id`, `BuscaCampo_buscaformulario_id`, `BuscaCampo_CampoDescricao`, `BuscaCampo_NomeCampo`, `BuscaCampo_Echave`) VALUES ('2', '1', '2', 'Descrição', 'Menu_Descricao', b'0');
INSERT INTO `jeugenio25_MegaTime30`.`Tbbuscacampos` (`BuscaCampo_ControleHTML_id`, `BuscaCampo_TipoDado_id`, `BuscaCampo_buscaformulario_id`, `BuscaCampo_CampoDescricao`, `BuscaCampo_NomeCampo`, `BuscaCampo_Echave`) VALUES ('5', '1', '2', 'Principal?', 'Menu_Principal', b'0');
INSERT INTO `jeugenio25_MegaTime30`.`Tbbuscacampos` (`BuscaCampo_ControleHTML_id`, `BuscaCampo_TipoDado_id`, `BuscaCampo_buscaformulario_id`, `BuscaCampo_CampoDescricao`, `BuscaCampo_NomeCampo`, `BuscaCampo_FonteDados` , `BuscaCampo_Echave`) VALUES ('4', '1', '2', 'Página', 'Menu_BuscaTabela_id', ' select BuscaTabela_id , BuscaTabela_Descricao from  Tbbuscatabelas where _deleted_ = 0 ',  0); 
INSERT INTO `jeugenio25_MegaTime30`.`Tbbuscacampos` (`BuscaCampo_ControleHTML_id`, `BuscaCampo_TipoDado_id`, `BuscaCampo_buscaformulario_id`, `BuscaCampo_CampoDescricao`, `BuscaCampo_NomeCampo`, `BuscaCampo_FonteDados` , `BuscaCampo_Echave`) VALUES ('4', '1', '2', 'Menu Principal', 'Menu_Menu_id', ' select Menu_id , Menu_Descricao from TbMenu where _deleted_ = 0 ',  0); 
INSERT INTO `jeugenio25_MegaTime30`.`Tbbuscacampos` (`BuscaCampo_ControleHTML_id`, `BuscaCampo_TipoDado_id`, `BuscaCampo_buscaformulario_id`, `BuscaCampo_CampoDescricao`, `BuscaCampo_NomeCampo`, `BuscaCampo_Echave`) VALUES ('2', '1', '2', 'Odem', 'Menu_Ordem', b'0');
INSERT INTO `jeugenio25_MegaTime30`.`Tbbuscacampos` (`BuscaCampo_ControleHTML_id`, `BuscaCampo_TipoDado_id`, `BuscaCampo_buscaformulario_id`, `BuscaCampo_CampoDescricao`, `BuscaCampo_NomeCampo`, `BuscaCampo_Echave`) VALUES ('2', '1', '2', 'URL Destino', 'Menu_UrlDestino', b'0');
-- INSERT INTO `jeugenio25_MegaTime30`.`Tbbuscacampos` (`BuscaCampo_ControleHTML_id`, `BuscaCampo_TipoDado_id`, `BuscaCampo_buscaformulario_id`, `BuscaCampo_CampoDescricao`, `BuscaCampo_NomeCampo`, `BuscaCampo_Echave`) VALUES ('2', '1', '2', 'Classe CSS', 'Menu_ClasseIcone', b'0');
INSERT INTO `jeugenio25_MegaTime30`.`Tbbuscacampos` (`BuscaCampo_ControleHTML_id`, `BuscaCampo_TipoDado_id`, `BuscaCampo_buscaformulario_id`, `BuscaCampo_CampoDescricao`, `BuscaCampo_NomeCampo`, `BuscaCampo_FonteDados` , `BuscaCampo_Echave`) VALUES ('4', '1', '2', 'Icones', 'Menu_ClasseIcone', ' select Icone_Icone , Icone_Icone from  TbIcones where _deleted_ = 0 ',  0); 
INSERT INTO `jeugenio25_MegaTime30`.`Tbbuscacampos` (`BuscaCampo_ControleHTML_id`, `BuscaCampo_TipoDado_id`, `BuscaCampo_buscaformulario_id`, `BuscaCampo_CampoDescricao`, `BuscaCampo_NomeCampo`, `BuscaCampo_FonteDados` , `BuscaCampo_Echave`) VALUES ('4', '1', '2', 'Perfil', 'Menu_Perfil_Id', ' select  Perfil_Id ,  Perfil_Descricao from   TbPerfis where _deleted_ = 0 ',  0); 


-- POPULA TABELAS GERAÇÃO AUTOMÁTICA  ####


-- POPULA  ADMINISTRACAO ####

-- Cadastro de Usuários
INSERT INTO `jeugenio25_MegaTime30`.`Tbbuscatabelas` (`BuscaTabela_Perfil_Id`, `BuscaTabela_tabela`, `BuscaTabela_Descricao`, `BuscaTabela_condicao` , `_deleted_`) VALUES ('2', 'TbUsuarios mn', 'Cadastro de Usuários', 'mn._deleted_ = 0', 0);
INSERT INTO `jeugenio25_MegaTime30`.`Tbbuscacampos` (`BuscaCampo_ControleHTML_id`, `BuscaCampo_TipoDado_id`, `BuscaCampo_BuscaTabela_id`, `BuscaCampo_CampoDescricao`, `BuscaCampo_NomeCampo`, `BuscaCampo_Echave`) VALUES ('1', '1', '3', 'Código', 'Usuario_id', b'1');
INSERT INTO `jeugenio25_MegaTime30`.`Tbbuscacampos` (`BuscaCampo_ControleHTML_id`, `BuscaCampo_TipoDado_id`, `BuscaCampo_BuscaTabela_id`, `BuscaCampo_CampoDescricao`, `BuscaCampo_NomeCampo`, `BuscaCampo_Echave`) VALUES ('1', '1', '3', 'Local', 'Usuario_Nome', b'1');

-- Cadastro de Usuários Menu
INSERT INTO `jeugenio25_MegaTime30`.`TbMenu` (`Menu_BuscaTabela_id`, `Menu_Descricao`, `Menu_Principal`, `_deleted_`, `Menu_Ordem`, `Menu_ClasseIcone` , `Menu_Menu_id`    ) VALUES (3, 'Cadastro de Usuários', 0, 0, 1, 'glyphicon glyphicon-th',2 );


-- Cadastro de Usuários Formulário
INSERT INTO `jeugenio25_MegaTime30`.`Tbbuscaformularios` (`BuscaFormulario_BuscaTabela_id`,   `BuscaFormulario_tabela`, `BuscaFormulario_Descricao`) VALUES ('3',   'TbUsuarios', 'Edição Usuários');
INSERT INTO `jeugenio25_MegaTime30`.`Tbbuscacampos` (`BuscaCampo_ControleHTML_id`, `BuscaCampo_TipoDado_id`, `BuscaCampo_buscaformulario_id`, `BuscaCampo_CampoDescricao`, `BuscaCampo_NomeCampo`, `BuscaCampo_Echave`, `BuscaCampo_Disabled` ) VALUES ('1', '1', '3', 'Código', 'Usuario_id', 1, 1);
INSERT INTO `jeugenio25_MegaTime30`.`Tbbuscacampos` (`BuscaCampo_ControleHTML_id`, `BuscaCampo_TipoDado_id`, `BuscaCampo_buscaformulario_id`, `BuscaCampo_CampoDescricao`, `BuscaCampo_NomeCampo`, `BuscaCampo_Echave`) VALUES ('2', '1', '3', 'Nome', 'Usuario_Nome', 0);
INSERT INTO `jeugenio25_MegaTime30`.`Tbbuscacampos` (`BuscaCampo_ControleHTML_id`, `BuscaCampo_TipoDado_id`, `BuscaCampo_buscaformulario_id`, `BuscaCampo_CampoDescricao`, `BuscaCampo_NomeCampo`, `BuscaCampo_Echave`) VALUES ('2', '1', '3', 'Endereco', 'Usuario_Email', 0); 
INSERT INTO `jeugenio25_MegaTime30`.`Tbbuscacampos` (`BuscaCampo_ControleHTML_id`, `BuscaCampo_TipoDado_id`, `BuscaCampo_buscaformulario_id`, `BuscaCampo_CampoDescricao`, `BuscaCampo_NomeCampo`, `BuscaCampo_Echave`) VALUES ('2', '1', '3', 'Senha', 'Usuario_Senha', 0); 

INSERT INTO `jeugenio25_MegaTime30`.`Tbbuscacampos` (`BuscaCampo_ControleHTML_id`, `BuscaCampo_TipoDado_id`, `BuscaCampo_buscaformulario_id`, `BuscaCampo_CampoDescricao`, `BuscaCampo_NomeCampo`, `BuscaCampo_FonteDados` , `BuscaCampo_Echave`) VALUES ('4', '1', '3', 'Perfil', 'Usuario_Perfil_id', ' select Perfil_id , Perfil_Descricao from  TbPerfis where _deleted_ = 0 ',  0); 
INSERT INTO `jeugenio25_MegaTime30`.`Tbbuscacampos` (`BuscaCampo_ControleHTML_id`, `BuscaCampo_TipoDado_id`, `BuscaCampo_buscaformulario_id`, `BuscaCampo_CampoDescricao`, `BuscaCampo_NomeCampo`, `BuscaCampo_FonteDados` , `BuscaCampo_Echave`) VALUES ('4', '1', '3', 'Categoria', 'Usuario_Categoria_id', ' select Categoria_id  ,  Categoria_Nome from   TbCategorias where _deleted_ = 0 ',  0); 
INSERT INTO `jeugenio25_MegaTime30`.`Tbbuscacampos` (`BuscaCampo_ControleHTML_id`, `BuscaCampo_TipoDado_id`, `BuscaCampo_buscaformulario_id`, `BuscaCampo_CampoDescricao`, `BuscaCampo_NomeCampo`, `BuscaCampo_FonteDados` , `BuscaCampo_Echave`) VALUES ('4', '1', '3', 'Cidade', 'Usuario_Cidade_id', ' select  Cidade_id ,  Cidade_Nome from   TbCidades where _deleted_ = 0 ',  0); 

INSERT INTO `jeugenio25_MegaTime30`.`Tbbuscacampos` (`BuscaCampo_ControleHTML_id`, `BuscaCampo_TipoDado_id`, `BuscaCampo_buscaformulario_id`, `BuscaCampo_CampoDescricao`, `BuscaCampo_NomeCampo`, `BuscaCampo_Echave`) VALUES ('5', '1', '3', 'Ativo', 'Usuario_ativo', b'0');
INSERT INTO `jeugenio25_MegaTime30`.`Tbbuscacampos` (`BuscaCampo_ControleHTML_id`, `BuscaCampo_TipoDado_id`, `BuscaCampo_buscaformulario_id`, `BuscaCampo_CampoDescricao`, `BuscaCampo_NomeCampo`, `BuscaCampo_Echave`) VALUES ('5', '1', '3', 'Usar IA', 'Usuario_UsarIA', b'0');
INSERT INTO `jeugenio25_MegaTime30`.`Tbbuscacampos` (`BuscaCampo_ControleHTML_id`, `BuscaCampo_TipoDado_id`, `BuscaCampo_buscaformulario_id`, `BuscaCampo_CampoDescricao`, `BuscaCampo_NomeCampo`, `BuscaCampo_Echave`,  `BuscaCampo_Mascara`  ) VALUES ('6', '3', '3', 'Data de Nascimento', 'Usuario_DataDeNascimento', 0, '' );
 

-- INSERT INTO `jeugenio25_MegaTime30`.`Tbbuscacampos` (`BuscaCampo_ControleHTML_id`, `BuscaCampo_TipoDado_id`, `BuscaCampo_buscaformulario_id`, `BuscaCampo_CampoDescricao`, `BuscaCampo_NomeCampo`, `BuscaCampo_Echave`, `BuscaCampo_Mascara`) VALUES ('2', '1', '5', 'CPF', 'Colaborador_CPF', 0 , '\d{3}\.\d{3}\.\d{3}-\d{2}'); 
-- INSERT INTO `jeugenio25_MegaTime30`.`Tbbuscacampos` (`BuscaCampo_ControleHTML_id`, `BuscaCampo_TipoDado_id`, `BuscaCampo_buscaformulario_id`, `BuscaCampo_CampoDescricao`, `BuscaCampo_NomeCampo`, `BuscaCampo_Echave`, `BuscaCampo_Mascara` ) VALUES ('2', '1', '5', 'Telefone', 'Colaborador_telefone', 0,'\([0-9]{2}\)[\s][0-9]{4}-[0-9]{4,5}'); 




-- Cadastro de Categorias Lista
INSERT INTO `jeugenio25_MegaTime30`.`Tbbuscatabelas` (`BuscaTabela_Perfil_Id`, `BuscaTabela_tabela`, `BuscaTabela_Descricao`, `BuscaTabela_condicao` , `_deleted_`) VALUES ('2', 'TbCategorias mn', 'Cadastro de Categorias', 'mn._deleted_ = 0', 0);
INSERT INTO `jeugenio25_MegaTime30`.`Tbbuscacampos` (`BuscaCampo_ControleHTML_id`, `BuscaCampo_TipoDado_id`, `BuscaCampo_BuscaTabela_id`, `BuscaCampo_CampoDescricao`, `BuscaCampo_NomeCampo`, `BuscaCampo_Echave`) VALUES ('1', '1', '4', 'Código', 'Categoria_id', b'1');
INSERT INTO `jeugenio25_MegaTime30`.`Tbbuscacampos` (`BuscaCampo_ControleHTML_id`, `BuscaCampo_TipoDado_id`, `BuscaCampo_BuscaTabela_id`, `BuscaCampo_CampoDescricao`, `BuscaCampo_NomeCampo`, `BuscaCampo_Echave`) VALUES ('1', '1', '4', 'Categoria', 'Categoria_Nome', b'1');

-- Cadastro de Categorias Menu
INSERT INTO `jeugenio25_MegaTime30`.`TbMenu` (`Menu_BuscaTabela_id`, `Menu_Descricao`, `Menu_Principal`, `_deleted_`, `Menu_Ordem`, `Menu_ClasseIcone` , `Menu_Menu_id`    ) VALUES (4, 'Cadastro de Categorias', 0, 0, 1, 'glyphicon glyphicon-th',2 );

-- Cadastro de Categorias Formulário
INSERT INTO `jeugenio25_MegaTime30`.`Tbbuscaformularios` (`BuscaFormulario_BuscaTabela_id`,   `BuscaFormulario_tabela`, `BuscaFormulario_Descricao`) VALUES ('4',   'TbCategorias', 'Edição Categorias');
INSERT INTO `jeugenio25_MegaTime30`.`Tbbuscacampos` (`BuscaCampo_ControleHTML_id`, `BuscaCampo_TipoDado_id`, `BuscaCampo_buscaformulario_id`, `BuscaCampo_CampoDescricao`, `BuscaCampo_NomeCampo`, `BuscaCampo_Echave`, `BuscaCampo_Disabled` ) VALUES ('1', '1', '4', 'Código', 'Categoria_id', 1, 1);
INSERT INTO `jeugenio25_MegaTime30`.`Tbbuscacampos` (`BuscaCampo_ControleHTML_id`, `BuscaCampo_TipoDado_id`, `BuscaCampo_buscaformulario_id`, `BuscaCampo_CampoDescricao`, `BuscaCampo_NomeCampo`, `BuscaCampo_Echave`) VALUES ('2', '1', '4', 'Nome', 'Categoria_Nome', 0);
INSERT INTO `jeugenio25_MegaTime30`.`Tbbuscacampos` (`BuscaCampo_ControleHTML_id`, `BuscaCampo_TipoDado_id`, `BuscaCampo_buscaformulario_id`, `BuscaCampo_CampoDescricao`, `BuscaCampo_NomeCampo`, `BuscaCampo_Echave`) VALUES ('5', '1', '4', 'Ativo', 'Categoria_ativo', b'0');

 


-- Cadastro de Produtos Lista
INSERT INTO `jeugenio25_MegaTime30`.`Tbbuscatabelas` (`BuscaTabela_Perfil_Id`, `BuscaTabela_tabela`, `BuscaTabela_Descricao`, `BuscaTabela_condicao` , `_deleted_`) VALUES ('2', 'TbProdutos mn', 'Cadastro de Produtos', 'mn._deleted_ = 0', 0);
INSERT INTO `jeugenio25_MegaTime30`.`Tbbuscacampos` (`BuscaCampo_ControleHTML_id`, `BuscaCampo_TipoDado_id`, `BuscaCampo_BuscaTabela_id`, `BuscaCampo_CampoDescricao`, `BuscaCampo_NomeCampo`, `BuscaCampo_Echave`) VALUES ('1', '1', '5', 'Código', 'Produto_id', b'1');
INSERT INTO `jeugenio25_MegaTime30`.`Tbbuscacampos` (`BuscaCampo_ControleHTML_id`, `BuscaCampo_TipoDado_id`, `BuscaCampo_BuscaTabela_id`, `BuscaCampo_CampoDescricao`, `BuscaCampo_NomeCampo`, `BuscaCampo_Echave`) VALUES ('1', '1', '5', 'Categoria', 'Produto_Nome', b'1');

-- Cadastro de Produtos Menu
INSERT INTO `jeugenio25_MegaTime30`.`TbMenu` (`Menu_BuscaTabela_id`, `Menu_Descricao`, `Menu_Principal`, `_deleted_`, `Menu_Ordem`, `Menu_ClasseIcone` , `Menu_Menu_id`    ) VALUES (5, 'Cadastro de Produtos', 0, 0, 1, 'glyphicon glyphicon-th',2 );

-- Cadastro de Produtos Formulário
INSERT INTO `jeugenio25_MegaTime30`.`Tbbuscaformularios` (`BuscaFormulario_BuscaTabela_id`,   `BuscaFormulario_tabela`, `BuscaFormulario_Descricao`) VALUES ('5',   'TbProdutos', 'Edição Produtos');
INSERT INTO `jeugenio25_MegaTime30`.`Tbbuscacampos` (`BuscaCampo_ControleHTML_id`, `BuscaCampo_TipoDado_id`, `BuscaCampo_buscaformulario_id`, `BuscaCampo_CampoDescricao`, `BuscaCampo_NomeCampo`, `BuscaCampo_Echave`, `BuscaCampo_Disabled` ) VALUES ('1', '1', '5', 'Código', 'Produto_id', 1, 1);
INSERT INTO `jeugenio25_MegaTime30`.`Tbbuscacampos` (`BuscaCampo_ControleHTML_id`, `BuscaCampo_TipoDado_id`, `BuscaCampo_buscaformulario_id`, `BuscaCampo_CampoDescricao`, `BuscaCampo_NomeCampo`, `BuscaCampo_Echave`) VALUES ('2', '1', '5', 'Nome', 'Produto_Nome', 0);
INSERT INTO `jeugenio25_MegaTime30`.`Tbbuscacampos` (`BuscaCampo_ControleHTML_id`, `BuscaCampo_TipoDado_id`, `BuscaCampo_buscaformulario_id`, `BuscaCampo_CampoDescricao`, `BuscaCampo_NomeCampo`, `BuscaCampo_Echave`) VALUES ('5', '1', '5', 'Ativo', 'Produto_ativo', b'0');
INSERT INTO `jeugenio25_MegaTime30`.`Tbbuscacampos` (`BuscaCampo_ControleHTML_id`, `BuscaCampo_TipoDado_id`, `BuscaCampo_buscaformulario_id`, `BuscaCampo_CampoDescricao`, `BuscaCampo_NomeCampo`, `BuscaCampo_FonteDados` , `BuscaCampo_Echave`) VALUES ('4', '1', '5', 'Categoria', 'Produto_Categoria_id', ' select  Categoria_id ,  Categoria_Nome from   TbCategorias where _deleted_ = 0 ',  0); 

INSERT INTO `jeugenio25_MegaTime30`.`Tbbuscacampos` (`BuscaCampo_ControleHTML_id`, `BuscaCampo_TipoDado_id`, `BuscaCampo_buscaformulario_id`, `BuscaCampo_CampoDescricao`, `BuscaCampo_NomeCampo`, `BuscaCampo_Echave`) VALUES ('2', '1', '5', 'Icone', 'Produto_Icone', 0);
INSERT INTO `jeugenio25_MegaTime30`.`Tbbuscacampos` (`BuscaCampo_ControleHTML_id`, `BuscaCampo_TipoDado_id`, `BuscaCampo_buscaformulario_id`, `BuscaCampo_CampoDescricao`, `BuscaCampo_NomeCampo`, `BuscaCampo_Echave`) VALUES ('5', '1', '5', 'Mostrar Icone', 'Produto_mostrarIcone', b'0');
INSERT INTO `jeugenio25_MegaTime30`.`Tbbuscacampos` (`BuscaCampo_ControleHTML_id`, `BuscaCampo_TipoDado_id`, `BuscaCampo_buscaformulario_id`, `BuscaCampo_CampoDescricao`, `BuscaCampo_NomeCampo`, `BuscaCampo_Echave`) VALUES ('2', '1', '5', 'Descrição', 'Produto_Descricao', 0);

INSERT INTO `jeugenio25_MegaTime30`.`Tbbuscacampos` (`BuscaCampo_ControleHTML_id`, `BuscaCampo_TipoDado_id`, `BuscaCampo_buscaformulario_id`, `BuscaCampo_CampoDescricao`, `BuscaCampo_NomeCampo`, `BuscaCampo_Echave`) VALUES ('5', '1', '5', 'Abreviação', 'Produto_Abreviacao', b'0');
INSERT INTO `jeugenio25_MegaTime30`.`Tbbuscacampos` (`BuscaCampo_ControleHTML_id`, `BuscaCampo_TipoDado_id`, `BuscaCampo_buscaformulario_id`, `BuscaCampo_CampoDescricao`, `BuscaCampo_NomeCampo`, `BuscaCampo_Echave`) VALUES ('5', '1', '5', 'Gratúito', 'Produto_gratuito', b'0');

 
--


-- Cadastro de Conteúdo Lista
INSERT INTO `jeugenio25_MegaTime30`.`Tbbuscatabelas` (`BuscaTabela_Perfil_Id`, `BuscaTabela_tabela`, `BuscaTabela_Descricao`, `BuscaTabela_condicao` , `_deleted_`) VALUES ('2', 'TbConteudo mn', 'Cadastro de Conteúdo', 'mn._deleted_ = 0', 0);
INSERT INTO `jeugenio25_MegaTime30`.`Tbbuscacampos` (`BuscaCampo_ControleHTML_id`, `BuscaCampo_TipoDado_id`, `BuscaCampo_BuscaTabela_id`, `BuscaCampo_CampoDescricao`, `BuscaCampo_NomeCampo`, `BuscaCampo_Echave`) VALUES ('1', '1', '6', 'Código', 'Conteudo_id', b'1');
INSERT INTO `jeugenio25_MegaTime30`.`Tbbuscacampos` (`BuscaCampo_ControleHTML_id`, `BuscaCampo_TipoDado_id`, `BuscaCampo_BuscaTabela_id`, `BuscaCampo_CampoDescricao`, `BuscaCampo_NomeCampo`, `BuscaCampo_Echave`) VALUES ('1', '1', '6', 'Nome', 'Conteudo_Nome', b'1');

-- Cadastro de Conteúdo Menu
INSERT INTO `jeugenio25_MegaTime30`.`TbMenu` (`Menu_BuscaTabela_id`, `Menu_Descricao`, `Menu_Principal`, `_deleted_`, `Menu_Ordem`, `Menu_ClasseIcone` , `Menu_Menu_id`    ) VALUES (4, 'Cadastro de Categorias', 0, 0, 1, 'glyphicon glyphicon-th',2 );

-- Cadastro de Conteúdo Formulário
INSERT INTO `jeugenio25_MegaTime30`.`Tbbuscaformularios` (`BuscaFormulario_BuscaTabela_id`,   `BuscaFormulario_tabela`, `BuscaFormulario_Descricao`) VALUES ('6',   'TbConteudo', 'Edição de Conteúdo');
INSERT INTO `jeugenio25_MegaTime30`.`Tbbuscacampos` (`BuscaCampo_ControleHTML_id`, `BuscaCampo_TipoDado_id`, `BuscaCampo_buscaformulario_id`, `BuscaCampo_CampoDescricao`, `BuscaCampo_NomeCampo`, `BuscaCampo_Echave`, `BuscaCampo_Disabled` ) VALUES ('1', '1', '6', 'Código', 'Conteudo_id', 1, 1);
INSERT INTO `jeugenio25_MegaTime30`.`Tbbuscacampos` (`BuscaCampo_ControleHTML_id`, `BuscaCampo_TipoDado_id`, `BuscaCampo_buscaformulario_id`, `BuscaCampo_CampoDescricao`, `BuscaCampo_NomeCampo`, `BuscaCampo_Echave`) VALUES ('2', '1', '6', 'Nome', 'Conteudo_Nome', 0);
INSERT INTO `jeugenio25_MegaTime30`.`Tbbuscacampos` (`BuscaCampo_ControleHTML_id`, `BuscaCampo_TipoDado_id`, `BuscaCampo_buscaformulario_id`, `BuscaCampo_CampoDescricao`, `BuscaCampo_NomeCampo`, `BuscaCampo_Echave`) VALUES ('2', '1', '6', 'Descrição', 'Conteudo_Descricao', 0);
INSERT INTO `jeugenio25_MegaTime30`.`Tbbuscacampos` (`BuscaCampo_ControleHTML_id`, `BuscaCampo_TipoDado_id`, `BuscaCampo_buscaformulario_id`, `BuscaCampo_CampoDescricao`, `BuscaCampo_NomeCampo`, `BuscaCampo_Echave`) VALUES ('2', '1', '6', 'Resumo', 'Conteudo_Resumo', 0);
INSERT INTO `jeugenio25_MegaTime30`.`Tbbuscacampos` (`BuscaCampo_ControleHTML_id`, `BuscaCampo_TipoDado_id`, `BuscaCampo_buscaformulario_id`, `BuscaCampo_CampoDescricao`, `BuscaCampo_NomeCampo`, `BuscaCampo_Echave`) VALUES ('2', '1', '6', 'Conteúdo', 'Conteudo_Conteudo', 0);
INSERT INTO `jeugenio25_MegaTime30`.`Tbbuscacampos` (`BuscaCampo_ControleHTML_id`, `BuscaCampo_TipoDado_id`, `BuscaCampo_buscaformulario_id`, `BuscaCampo_CampoDescricao`, `BuscaCampo_NomeCampo`, `BuscaCampo_Echave`) VALUES ('2', '1', '6', 'URL', 'Conteudo_URL', 0);

INSERT INTO `jeugenio25_MegaTime30`.`Tbbuscacampos` (`BuscaCampo_ControleHTML_id`, `BuscaCampo_TipoDado_id`, `BuscaCampo_buscaformulario_id`, `BuscaCampo_CampoDescricao`, `BuscaCampo_NomeCampo`, `BuscaCampo_Echave`) VALUES ('5', '1', '6', 'Ativo', 'Conteudo_ativo', b'0');
INSERT INTO `jeugenio25_MegaTime30`.`Tbbuscacampos` (`BuscaCampo_ControleHTML_id`, `BuscaCampo_TipoDado_id`, `BuscaCampo_buscaformulario_id`, `BuscaCampo_CampoDescricao`, `BuscaCampo_NomeCampo`, `BuscaCampo_Echave`,  `BuscaCampo_Mascara`  ) VALUES ('6', '3', '6', 'Data de Início', 'Conteudo_dataInicioExibicao', 0, '' );
INSERT INTO `jeugenio25_MegaTime30`.`Tbbuscacampos` (`BuscaCampo_ControleHTML_id`, `BuscaCampo_TipoDado_id`, `BuscaCampo_buscaformulario_id`, `BuscaCampo_CampoDescricao`, `BuscaCampo_NomeCampo`, `BuscaCampo_Echave`,  `BuscaCampo_Mascara`  ) VALUES ('6', '3', '6', 'Data de Fim', 'Conteudo_dataFimExibicao', 0, '' );

INSERT INTO `jeugenio25_MegaTime30`.`Tbbuscacampos` (`BuscaCampo_ControleHTML_id`, `BuscaCampo_TipoDado_id`, `BuscaCampo_buscaformulario_id`, `BuscaCampo_CampoDescricao`, `BuscaCampo_NomeCampo`, `BuscaCampo_FonteDados` , `BuscaCampo_Echave`, `BuscaCampo_Obrigatorio`) VALUES ('4', '1', '6', 'Produto', 'Conteudo_Produto_id', ' select  Produto_id ,  Produto_Nome from    TbProdutos where _deleted_ = 0 ',  0, 1); 
INSERT INTO `jeugenio25_MegaTime30`.`Tbbuscacampos` (`BuscaCampo_ControleHTML_id`, `BuscaCampo_TipoDado_id`, `BuscaCampo_buscaformulario_id`, `BuscaCampo_CampoDescricao`, `BuscaCampo_NomeCampo`, `BuscaCampo_FonteDados` , `BuscaCampo_Echave`, `BuscaCampo_Obrigatorio`) VALUES ('4', '1', '6', 'Cidade', 'Conteudo_Cidade_id', ' select  Cidade_id ,  Cidade_Nome from    TbCidades where _deleted_ = 0 ',  0, 0); 
INSERT INTO `jeugenio25_MegaTime30`.`Tbbuscacampos` (`BuscaCampo_ControleHTML_id`, `BuscaCampo_TipoDado_id`, `BuscaCampo_buscaformulario_id`, `BuscaCampo_CampoDescricao`, `BuscaCampo_NomeCampo`, `BuscaCampo_FonteDados` , `BuscaCampo_Echave`, `BuscaCampo_Obrigatorio`) VALUES ('4', '1', '6', 'Estado', 'Conteudo_Estado_id', ' select  Estado_id ,  Estado_Nome from    TbEstados where _deleted_ = 0 ',  0, 0); 


-- INSERT INTO `jeugenio25_economia`.`Tbbuscacampos` (`BuscaCampo_ControleHTML_id`, `BuscaCampo_TipoDado_id`, `BuscaCampo_buscaformulario_id`, `BuscaCampo_CampoDescricao`, `BuscaCampo_NomeCampo`, `BuscaCampo_FonteDados` , `BuscaCampo_Echave`) VALUES ('4', '1', '3', 'Unidade', 'Local_Unidade_id', ' select Unidade_id , Unidade_Nome from  TbUnidades where _deleted_ = 0 ',  0); 


-- Cidades


-- Cadastro de Cidades Lista
INSERT INTO `jeugenio25_MegaTime30`.`Tbbuscatabelas` (`BuscaTabela_Perfil_Id`, `BuscaTabela_tabela`, `BuscaTabela_Descricao`, `BuscaTabela_condicao` , `_deleted_`) VALUES ('2', 'TbCidades mn', 'Cadastro de Cidades', 'mn._deleted_ = 0', 0);
INSERT INTO `jeugenio25_MegaTime30`.`Tbbuscacampos` (`BuscaCampo_ControleHTML_id`, `BuscaCampo_TipoDado_id`, `BuscaCampo_BuscaTabela_id`, `BuscaCampo_CampoDescricao`, `BuscaCampo_NomeCampo`, `BuscaCampo_Echave`) VALUES ('1', '1', '7', 'Código', 'Cidade_id', b'1');
INSERT INTO `jeugenio25_MegaTime30`.`Tbbuscacampos` (`BuscaCampo_ControleHTML_id`, `BuscaCampo_TipoDado_id`, `BuscaCampo_BuscaTabela_id`, `BuscaCampo_CampoDescricao`, `BuscaCampo_NomeCampo`, `BuscaCampo_Echave`) VALUES ('1', '1', '7', 'Cidade', 'Cidade_Nome', b'1');

-- Cadastro de Categorias Menu
INSERT INTO `jeugenio25_MegaTime30`.`TbMenu` (`Menu_BuscaTabela_id`, `Menu_Descricao`, `Menu_Principal`, `_deleted_`, `Menu_Ordem`, `Menu_ClasseIcone` , `Menu_Menu_id`    ) VALUES (7, 'Cadastro de Cidades', 0, 0, 1, 'glyphicon glyphicon-th',2 );

-- Cadastro de Categorias Formulário
INSERT INTO `jeugenio25_MegaTime30`.`Tbbuscaformularios` (`BuscaFormulario_BuscaTabela_id`,   `BuscaFormulario_tabela`, `BuscaFormulario_Descricao`) VALUES ('7',   'TbCidades', 'Edição Cidades');
INSERT INTO `jeugenio25_MegaTime30`.`Tbbuscacampos` (`BuscaCampo_ControleHTML_id`, `BuscaCampo_TipoDado_id`, `BuscaCampo_buscaformulario_id`, `BuscaCampo_CampoDescricao`, `BuscaCampo_NomeCampo`, `BuscaCampo_Echave`, `BuscaCampo_Disabled` ) VALUES ('1', '1', '7', 'Código', 'Cidade_id', 1, 1);
INSERT INTO `jeugenio25_MegaTime30`.`Tbbuscacampos` (`BuscaCampo_ControleHTML_id`, `BuscaCampo_TipoDado_id`, `BuscaCampo_buscaformulario_id`, `BuscaCampo_CampoDescricao`, `BuscaCampo_NomeCampo`, `BuscaCampo_Echave`) VALUES ('2', '1', '7', 'Nome', 'Cidade_Nome', 0);
INSERT INTO `jeugenio25_MegaTime30`.`Tbbuscacampos` (`BuscaCampo_ControleHTML_id`, `BuscaCampo_TipoDado_id`, `BuscaCampo_buscaformulario_id`, `BuscaCampo_CampoDescricao`, `BuscaCampo_NomeCampo`, `BuscaCampo_FonteDados` , `BuscaCampo_Echave`, `BuscaCampo_Obrigatorio`) VALUES ('4', '1', '7', 'Estado', 'Cidade_Estado_id', ' select  Estado_id ,  Estado_Nome from    TbEstados where _deleted_ = 0 ',  0, 1); 
 



-- POPULA  ADMINISTRACAO ####




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
Produto_Icone, Produto_mostrarIcone, Produto_Descricao , Produto_Abreviacao)
values(1, 'Portal G1' , 1, 'g1.png', true, 'Portal de Notícias da globo', 'G1');

insert into TbProdutos( Produto_id, Produto_Nome, Produto_Categoria_id, 
Produto_Icone, Produto_mostrarIcone, Produto_Descricao , Produto_Abreviacao)
values(2, 'Globo.com' , 1, 'gcom.png', true, 'Globo.com - Portal Globo.com', 'Gcom');


insert into TbProdutos( Produto_id, Produto_Nome, Produto_Categoria_id, 
Produto_Icone, Produto_mostrarIcone, Produto_Descricao , Produto_Abreviacao)
values(3, 'O globo' , 1, 'oglobo.png', true, 'Globo.com - Portal Globo.com', 'oglobo');

insert into TbProdutos( Produto_id, Produto_Nome, Produto_Categoria_id, 
Produto_Icone, Produto_mostrarIcone, Produto_Descricao , Produto_Abreviacao)
values(4, 'Globo News' , 1, 'gnews.png', true, 'Globo.com - Portal Globo.com', 'gnews');


 -- Esporte
 
 insert into TbProdutos( Produto_id, Produto_Nome, Produto_Categoria_id, 
Produto_Icone, Produto_mostrarIcone, Produto_Descricao , Produto_Abreviacao)
values(5, 'Globo Esporte' , 2, 'ge.png', true, 'Portal Globo Esporte - Esporte', 'ge');


 -- Entretenimento
 
 insert into TbProdutos( Produto_id, Produto_Nome, Produto_Categoria_id, 
Produto_Icone, Produto_mostrarIcone, Produto_Descricao , Produto_Abreviacao)
values(6, 'GSHOW' , 3, 'gshow.png', true, 'Portal Gshow Entretenimento', 'gshow');

 insert into TbProdutos( Produto_id, Produto_Nome, Produto_Categoria_id, 
Produto_Icone, Produto_mostrarIcone, Produto_Descricao , Produto_Abreviacao)
values(7, 'globo play' , 3, 'gplay.png', true, 'Portal Gshow Entretenimento', 'globoplay');

 insert into TbProdutos( Produto_id, Produto_Nome, Produto_Categoria_id, 
Produto_Icone, Produto_mostrarIcone, Produto_Descricao , Produto_Abreviacao)
values(8, 'MultShow' , 3, 'mshow.png', true, 'Multhow - Entretenimento', 'mshow');


 -- Infantis
 insert into TbProdutos( Produto_id, Produto_Nome, Produto_Categoria_id, 
Produto_Icone, Produto_mostrarIcone, Produto_Descricao , Produto_Abreviacao)
values(9, 'Gloob' , 4, 'Gloob.png', true, 'Multhow - Entretenimento', 'Gloob');


 -- Educação e Cultura
 insert into TbProdutos( Produto_id, Produto_Nome, Produto_Categoria_id, 
Produto_Icone, Produto_mostrarIcone, Produto_Descricao , Produto_Abreviacao)
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
 Usuario_DataDeNascimento, Usuario_Perfil_Id)
values(1, 1, 2, 'Jorge Eugenio', 'jeugenio25@gmail.com','1234','25561203',  '1988-10-30', 1);

insert into TbUsuarios(Usuario_id , Usuario_Categoria_id , 
Usuario_Cidade_id, Usuario_Nome ,Usuario_Email , Usuario_Senha , Usuario_cep,
 Usuario_DataDeNascimento, Usuario_Perfil_Id)
values(2, 1, 3, 'Pedro Junior', 'pedro.ideasfor@gmail.com','1234','26110335' ,  '1988-10-30', 1);

insert into TbUsuarios(Usuario_id , Usuario_Categoria_id , 
Usuario_Cidade_id, Usuario_Nome ,Usuario_Email , Usuario_Senha , Usuario_cep,
 Usuario_DataDeNascimento, Usuario_Perfil_Id)
values(3, 1, 6, 'Vitor Batista', 'vitinho.baptista@gmail.com','1234','25015190',  '1988-10-30' , 1);


insert into TbUsuarios(Usuario_id , Usuario_Categoria_id , 
Usuario_Cidade_id, Usuario_Nome ,Usuario_Email , Usuario_Senha , Usuario_cep,
 Usuario_DataDeNascimento, Usuario_Perfil_Id )
values(4, 1, 7, 'Fernando Ferreira', 'fernando@embratecc.com.br','1234','26221010',  '1988-10-30' , 1);


-- Conteudo


insert into TbConteudo(Conteudo_id ,     Conteudo_Produto_id,
Conteudo_Nome, Conteudo_Descricao,  
 Conteudo_dataInicioExibicao, Conteudo_dataFimExibicao , Conteudo_URL )
values(1, 1, 'G1 - Página principal', 'G1 - Página principal',
 '2020-05-01', '2021-10-30',  'https://g1.globo.com/') ;
 
 
 insert into TbConteudo(Conteudo_id ,     Conteudo_Produto_id,
Conteudo_Nome, Conteudo_Descricao,  
 Conteudo_dataInicioExibicao, Conteudo_dataFimExibicao , Conteudo_URL )
values(2, 1, 'G1 - Economia', 'G1 - Economia',
 '2020-05-01', '2021-10-30',  'https://g1.globo.com/economia/') ;
 
 insert into TbConteudo(Conteudo_id ,     Conteudo_Produto_id,
Conteudo_Nome, Conteudo_Descricao,  
 Conteudo_dataInicioExibicao, Conteudo_dataFimExibicao , Conteudo_URL )
values(3, 1, 'G1 - Mundo', 'G1 - Mundo',
 '2020-05-01', '2021-10-30',  'https://g1.globo.com/mundo/') ;
 
 

 
 
 
  




