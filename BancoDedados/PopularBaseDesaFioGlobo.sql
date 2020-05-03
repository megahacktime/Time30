

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
INSERT INTO `jeugenio25_MegaTime30`.`TbConfiguracoes` (  `Configuracao_chave` , `Configuracao_valor` , `Configuracao_Data`) VALUES ( 'URLRaizImagem' , 'http://ideiaspara.com.br/Time30Api/Imagens/', current_timestamp());


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


INSERT INTO `jeugenio25_MegaTime30`.`Tbbuscacampos` (`BuscaCampo_ControleHTML_id`, `BuscaCampo_TipoDado_id`, `BuscaCampo_buscaformulario_id`, `BuscaCampo_CampoDescricao`, `BuscaCampo_NomeCampo`, `BuscaCampo_FonteDados` , `BuscaCampo_Echave`) VALUES ('4', '1', '3', 'Produto de Preferência 1', 'Usuario_Produto_id1', ' select Produto_id  ,  Produto_Nome from   TbProdutos where _deleted_ = 0 ',  0); 
INSERT INTO `jeugenio25_MegaTime30`.`Tbbuscacampos` (`BuscaCampo_ControleHTML_id`, `BuscaCampo_TipoDado_id`, `BuscaCampo_buscaformulario_id`, `BuscaCampo_CampoDescricao`, `BuscaCampo_NomeCampo`, `BuscaCampo_FonteDados` , `BuscaCampo_Echave`) VALUES ('4', '1', '3', 'Produto de Preferência 1', 'Usuario_Produto_id2', ' select Produto_id  ,  Produto_Nome from   TbProdutos where _deleted_ = 0 ',  0); 
INSERT INTO `jeugenio25_MegaTime30`.`Tbbuscacampos` (`BuscaCampo_ControleHTML_id`, `BuscaCampo_TipoDado_id`, `BuscaCampo_buscaformulario_id`, `BuscaCampo_CampoDescricao`, `BuscaCampo_NomeCampo`, `BuscaCampo_FonteDados` , `BuscaCampo_Echave`) VALUES ('4', '1', '3', 'Produto de Preferência 1', 'Usuario_Produto_id3', ' select Produto_id  ,  Produto_Nome from   TbProdutos where _deleted_ = 0 ',  0); 


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
INSERT INTO `jeugenio25_MegaTime30`.`TbMenu` (`Menu_BuscaTabela_id`, `Menu_Descricao`, `Menu_Principal`, `_deleted_`, `Menu_Ordem`, `Menu_ClasseIcone` , `Menu_Menu_id`    ) VALUES (6, 'Cadastro de Conteúdo', 0, 0, 1, 'glyphicon glyphicon-th',2 );

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

-- Cadastro de Cidades Menu
INSERT INTO `jeugenio25_MegaTime30`.`TbMenu` (`Menu_BuscaTabela_id`, `Menu_Descricao`, `Menu_Principal`, `_deleted_`, `Menu_Ordem`, `Menu_ClasseIcone` , `Menu_Menu_id`    ) VALUES (7, 'Cadastro de Cidades', 0, 0, 1, 'glyphicon glyphicon-th',2 );

-- Cadastro de Cidades Formulário
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
insert into TbUsuarios(Usuario_id ,  
Usuario_Cidade_id, Usuario_Nome ,Usuario_Email , Usuario_Senha , Usuario_cep,
 Usuario_DataDeNascimento, Usuario_Perfil_Id)
values(1,  2, 'Jorge Eugenio', 'jeugenio25@gmail.com','1234','25561203',  '1988-10-30', 1);

insert into TbUsuarios(Usuario_id ,  
Usuario_Cidade_id, Usuario_Nome ,Usuario_Email , Usuario_Senha , Usuario_cep,
 Usuario_DataDeNascimento, Usuario_Perfil_Id)
values(2, 3, 'Pedro Junior', 'pedro.ideasfor@gmail.com','1234','26110335' ,  '1988-10-30', 1);

insert into TbUsuarios(Usuario_id ,  
Usuario_Cidade_id, Usuario_Nome ,Usuario_Email , Usuario_Senha , Usuario_cep,
 Usuario_DataDeNascimento, Usuario_Perfil_Id)
values(3, 6, 'Vitor Batista', 'vitinho.baptista@gmail.com','1234','25015190',  '1988-10-30' , 1);


insert into TbUsuarios(Usuario_id ,  
Usuario_Cidade_id, Usuario_Nome ,Usuario_Email , Usuario_Senha , Usuario_cep,
 Usuario_DataDeNascimento, Usuario_Perfil_Id )
values(4,  7, 'Fernando Ferreira', 'fernando@embratecc.com.br','1234','26221010',  '1988-10-30' , 1);


insert into TbUsuarios(Usuario_id ,  
Usuario_Cidade_id, Usuario_Nome ,Usuario_Email , Usuario_Senha , Usuario_cep,
 Usuario_DataDeNascimento, Usuario_Perfil_Id )
values(5,  7, 'Caue TbUsuarios', 'caueobuck@gmail.com','1234','14098331',  '1988-10-30' , 1);



-- Conteudo


insert into TbConteudo(Conteudo_id ,     Conteudo_Produto_id,
Conteudo_Nome, Conteudo_Descricao,  
 Conteudo_dataInicioExibicao, Conteudo_dataFimExibicao , Conteudo_URL, conteudo_principal )
values(1, 1, 'G1 - Página principal', 'G1 - Página principal',
 '2020-05-01', '2021-10-30',  'https://g1.globo.com/', 1) ;
 
 
 insert into TbConteudo(Conteudo_id ,     Conteudo_Produto_id,
Conteudo_Nome, Conteudo_Descricao,  
 Conteudo_dataInicioExibicao, Conteudo_dataFimExibicao , Conteudo_URL , conteudo_principal )
values(2, 1, 'G1 - Economia', 'G1 - Economia',
 '2020-05-01', '2021-10-30',  'https://g1.globo.com/economia/' , 0) ;
 
 insert into TbConteudo(Conteudo_id ,     Conteudo_Produto_id,
Conteudo_Nome, Conteudo_Descricao,  
 Conteudo_dataInicioExibicao, Conteudo_dataFimExibicao , Conteudo_URL, conteudo_principal )
values(3, 1, 'G1 - Mundo', 'G1 - Mundo',
 '2020-05-01', '2021-10-30',  'https://g1.globo.com/mundo/', 0) ;
 
 -- Dados Fernando 
 
-- UPDATE `jeugenio25_MegaTime30`.`TbProdutos` SET `Produto_Nome` = 'Multishow', `Produto_Descricao` = 'Multishow - Entretenimento' WHERE (`Produto_id` = '8');
-- UPDATE `jeugenio25_MegaTime30`.`TbProdutos` SET `Produto_Descricao` = 'Multishow - Entretenimento' WHERE (`Produto_id` = '9');
-- INSERT INTO `jeugenio25_MegaTime30`.`TbProdutos` (`Produto_Nome`, `Produto_Categoria_id`, `Produto_Icone`, `Produto_Data`, `Produto_Ativo`, `Produto_mostrarIcone`, `Produto_Descricao`, `Produto_Abreviacao`, `Produto_gratuito`, `_deleted_`) VALUES ('Cartola FC', 2, 'Cartola.png', '2020-05-02 11:33:29', 1, 1, 'Cartola FC - Escale seu Time', 'Cartola', '1', 0);


 
 UPDATE `jeugenio25_MegaTime30`.`TbProdutos` SET `Produto_Nome` = 'Multishow', `Produto_Descricao` = 'Multishow - Entretenimento' WHERE (`Produto_id` = '8');
UPDATE `jeugenio25_MegaTime30`.`TbProdutos` SET `Produto_Descricao` = 'Multishow - Entretenimento' WHERE (`Produto_id` = '9');

INSERT INTO `jeugenio25_MegaTime30`.`TbProdutos` (`Produto_Nome`, `Produto_Categoria_id`, `Produto_Icone`, `Produto_Data`, `Produto_Ativo`, `Produto_mostrarIcone`, `Produto_Descricao`, `Produto_A reviacao`, `Produto_gratuito`, `_deleted_`) VALUES ('Cartola FC', 2, 'Cartola.png', '2020-05-02 11:33:29', 1, 1, 'Cartola FC - Escale seu Time', 'Cartola', 0, 0);

UPDATE `jeugenio25_MegaTime30`.`TbProdutos` SET `Produto_Nome` = 'Globoplay', `Produto_Descricao` = 'Assine agora o Globoplay' WHERE (`Produto_id` = '7');
UPDATE `jeugenio25_MegaTime30`.`TbProdutos` SET `Produto_Nome` = 'O Globo', `Produto_Descricao` = 'Confira as Principais Notícias do Brasil e do Mundo' WHERE (`Produto_id` = '3');
UPDATE `jeugenio25_MegaTime30`.`TbProdutos` SET `Produto_Descricao` = 'A solutamente tudo sobre noticias, esportes...' WHERE (`Produto_id` = '2');
UPDATE `jeugenio25_MegaTime30`.`TbProdutos` SET `Produto_Descricao` = 'Canal de notícias 24 horas no ar. Nunca Desliga.' WHERE (`Produto_id` = '4');
UPDATE `jeugenio25_MegaTime30`.`TbProdutos` SET `Produto_Descricao` = 'As histórias das histórias que a gente conta' WHERE (`Produto_id` = '6');
UPDATE `jeugenio25_MegaTime30`.`TbProdutos` SET `Produto_Descricao` = 'Ao Vivo, Música, Humor, Viagem...' WHERE (`Produto_id` = '8');
UPDATE `jeugenio25_MegaTime30`.`TbProdutos` SET `Produto_Descricao` = 'Seus personagens favoritos, quando e onde ...' WHERE (`Produto_id` = '9');
UPDATE `jeugenio25_MegaTime30`.`TbProdutos` SET `Produto_Descricao` = 'Educação para transformar' WHERE (`Produto_id` = '10');
INSERT INTO `jeugenio25_MegaTime30`.`TbProdutos` (`Produto_Nome`, `Produto_Categoria_id`, `Produto_Icone`, `Produto_Data`, `Produto_Ativo`, `Produto_mostrarIcone`, `Produto_Descricao`, `Produto_Abreviacao`, `Produto_gratuito`, `_deleted_`) VALUES ('Glo osat Play', 3, 'globosat.png', '2020-05-02 11:33:29', 1, 1, 'Mais Globosat', 'Globosat', 1, 0);
INSERT INTO `jeugenio25_MegaTime30`.`TbProdutos` (`Produto_Nome`, `Produto_Categoria_id`, `Produto_Icone`, `Produto_Data`, `Produto_Ativo`, `Produto_mostrarIcone`, `Produto_Descricao`, `Produto_Abreviacao`, `Produto_gratuito`, `_deleted_`) VALUES ('Glo o Rural',1, 'grural.png', '2020-05-02 11:33:29', 1, 1, 'G1 - Globo Rural', 'GRural', 1, 0);
INSERT INTO `jeugenio25_MegaTime30`.`TbProdutos` (`Produto_Nome`, `Produto_Categoria_id`, `Produto_Icone`, `Produto_Data`, `Produto_Ativo`, `Produto_mostrarIcone`, `Produto_Descricao`, `Produto_Abreviacao`, `Produto_gratuito`, `_deleted_`) VALUES ('Philos', 3, 'philos.png', '2020-05-02 11:33:29', 1, 1, 'Contamos Histórias', 'Philos', 1, 0);
INSERT INTO `jeugenio25_MegaTime30`.`TbProdutos` (`Produto_Nome`, `Produto_Categoria_id`, `Produto_Icone`, `Produto_Data`, `Produto_Ativo`, `Produto_mostrarIcone`, `Produto_Descricao`, `Produto_Abreviacao`, `Produto_gratuito`, `_deleted_`) VALUES ('Premiere', 2, 'premiere.png', '2020-05-02 11:33:29', 1, 1,'Premiere | GloboEsporte.com', 'Premiere', 1, 0);


INSERT INTO `jeugenio25_MegaTime30`.`TbConteudo` (`Conteudo_dataFimExibicao`, `Conteudo_Produto_id`, `Conteudo_Nome`, `Conteudo_Descricao`, `Conteudo_dataCadastro`, `Conteudo_dataInicioExibicao`, `_deleted_`, `Conteudo_URL`, `Conteudo_Principal`) VALUES ('2021-10-30 00:00:00', 1, 'G1 - Podcast', 'G1 - Podcast', '2020-05-02 22:28:41', '2020-05-01 00:00:00',  0,  'https://g1.globo.com/podcast/',  0);
INSERT INTO `jeugenio25_MegaTime30`.`TbConteudo` (`Conteudo_dataFimExibicao`, `Conteudo_Produto_id`, `Conteudo_Nome`, `Conteudo_Descricao`, `Conteudo_dataCadastro`, `Conteudo_dataInicioExibicao`, `_deleted_`, `Conteudo_URL`, `Conteudo_Principal`) VALUES ('2021-10-30 00:00:00', 2, 'Globo.com - Página Principal', 'Globo.com - Página Principal', '2020-05-02 22:28:41',  '2020-05-01 00:00:00',  0,  'https://www.globo.com/',  0);
INSERT INTO `jeugenio25_MegaTime30`.`TbConteudo` (`Conteudo_dataFimExibicao`, `Conteudo_Produto_id`, `Conteudo_Nome`, `Conteudo_Descricao`, `Conteudo_dataCadastro`, `Conteudo_dataInicioExibicao`, `_deleted_`, `Conteudo_URL`, `Conteudo_Principal`) VALUES ('2021-10-30 00:00:00', 2, 'Globo.com - Notícias', 'Depoimento de Moro termina após mais de 8h',  '2020-05-02 22:28:41',  '2020-05-01 00:00:00',  0,  'https://g1.globo.com/pr/parana/noticia/2020/05/02/ex-ministro-sergio-moro-presta-depoimento-de-mais-de-8-horas-na-pf-em-curitiba.ghtml',  0);
INSERT INTO `jeugenio25_MegaTime30`.`TbConteudo` (`Conteudo_dataFimExibicao`, `Conteudo_Produto_id`, `Conteudo_Nome`, `Conteudo_Descricao`, `Conteudo_dataCadastro`, `Conteudo_dataInicioExibicao`, `_deleted_`, `Conteudo_URL`, `Conteudo_Principal`) VALUES ('2021-10-30 00:00:00', 2, 'Globo.com - Notícias', ' Bolsonaristas xingam defronte a casa de Moraes',  '2020-05-02 22:28:41',  '2020-05-01 00:00:00',  0,  'https://g1.globo.com/sp/sao-paulo/noticia/2020/05/02/manifestantes-fazem-protesto-contra-ministro-do-stf-em-sp-e-policia-e-chamada.ghtml',  0);
INSERT INTO `jeugenio25_MegaTime30`.`TbConteudo` (`Conteudo_dataFimExibicao`, `Conteudo_Produto_id`, `Conteudo_Nome`, `Conteudo_Descricao`, `Conteudo_dataCadastro`, `Conteudo_dataInicioExibicao`, `_deleted_`, `Conteudo_URL`, `Conteudo_Principal`) VALUES ('2021-10-30 00:00:00', 2, 'Globo.com - Esportes', 'Hulk deixa futuro aberto e não descarta voltar ao  Brasil',  '2020-05-02 22:28:41',  '2020-05-01 00:00:00',  0,  'https://globoesporte.globo.com/pb/futebol/noticia/vai-para-o-palmeiras-hulk-deixa-futuro-aberto-e-nao-descarta-voltar-ao-brasil-ja-em-2021.ghtml',  0);
INSERT INTO `jeugenio25_MegaTime30`.`TbConteudo` (`Conteudo_dataFimExibicao`, `Conteudo_Produto_id`, `Conteudo_Nome`, `Conteudo_Descricao`, `Conteudo_dataCadastro`, `Conteudo_dataInicioExibicao`, `_deleted_`, `Conteudo_URL`, `Conteudo_Principal`) VALUES ('2021-10-30 00:00:00', 3, 'O Globo - Página Principal', 'O Globo - Página Principal', '2020-05-02 22:28:41', '2020-05-01 00:00:00',  0,  'https://oglobo.globo.com/',  0);
INSERT INTO `jeugenio25_MegaTime30`.`TbConteudo` (`Conteudo_dataFimExibicao`, `Conteudo_Produto_id`, `Conteudo_Nome`, `Conteudo_Descricao`, `Conteudo_dataCadastro`, `Conteudo_dataInicioExibicao`, `_deleted_`, `Conteudo_URL`, `Conteudo_Principal`) VALUES ('2021-10-30 00:00:00', 3, 'O Globo - Rio', 'O Globo - Rio', '2020-05-02 22:28:41', '2020-05-01 00:00:00',  0,  'https://oglobo.globo.com/rio/',  0);
INSERT INTO `jeugenio25_MegaTime30`.`TbConteudo` (`Conteudo_dataFimExibicao`, `Conteudo_Produto_id`, `Conteudo_Nome`, `Conteudo_Descricao`, `Conteudo_dataCadastro`, `Conteudo_dataInicioExibicao`, `_deleted_`, `Conteudo_URL`, `Conteudo_Principal`) VALUES ('2021-10-30 00:00:00', 3, 'O Globo -  rasil', 'O Globo -  Brasil', '2020-05-02 22:28:41', '2020-05-01 00:00:00',  0,  'https://oglobo.globo.com/brasil/',  0);
INSERT INTO `jeugenio25_MegaTime30`.`TbConteudo` (`Conteudo_dataFimExibicao`, `Conteudo_Produto_id`, `Conteudo_Nome`, `Conteudo_Descricao`, `Conteudo_dataCadastro`, `Conteudo_dataInicioExibicao`, `_deleted_`, `Conteudo_URL`, `Conteudo_Principal`) VALUES ('2021-10-30 00:00:00', 3, 'O Globo - Mundo',  'O Globo - Mundo',  '2020-05-02 22:28:41',  '2020-05-01 00:00:00',  0,  'https://oglobo.globo.com/mundo/',  0);
INSERT INTO `jeugenio25_MegaTime30`.`TbConteudo` (`Conteudo_dataFimExibicao`, `Conteudo_Produto_id`, `Conteudo_Nome`, `Conteudo_Descricao`, `Conteudo_dataCadastro`, `Conteudo_dataInicioExibicao`, `_deleted_`, `Conteudo_URL`, `Conteudo_Principal`) VALUES ('2021-10-30 00:00:00', 4, 'G1 - Globonews',  'Globonews - Página Principal',  '2020-05-02 22:28:41',  '2020-05-01 00:00:00',  0,  'https://g1.globo.com/globonews/',  0);
INSERT INTO `jeugenio25_MegaTime30`.`TbConteudo` (`Conteudo_dataFimExibicao`, `Conteudo_Produto_id`, `Conteudo_Nome`, `Conteudo_Descricao`, `Conteudo_dataCadastro`, `Conteudo_dataInicioExibicao`, `_deleted_`, `Conteudo_URL`, `Conteudo_Principal`) VALUES ('2021-10-30 00:00:00', 4, 'Globonews - Noticia',  'Nos Estados Unidos, estados americanos começam a relaxar restrições',  '2020-05-02 22:28:41',  '2020-05-01 00:00:00',  0,  'https://g1.globo.com/globonews/jornal-globonews/video/nos-estados-unidos-estados-americanos-comecam-a-relaxar-restricoes-8527637.ghtml',  0);
INSERT INTO `jeugenio25_MegaTime30`.`TbConteudo` (`Conteudo_dataFimExibicao`, `Conteudo_Produto_id`, `Conteudo_Nome`, `Conteudo_Descricao`, `Conteudo_dataCadastro`, `Conteudo_dataInicioExibicao`, `_deleted_`, `Conteudo_URL`, `Conteudo_Principal`) VALUES ('2021-10-30 00:00:00', 4, 'Globonews - Noticia',  'Como a pandemia do coronavírus afeta outros setores além da saúde',  '2020-05-02 22:28:41',  '2020-05-01 00:00:00',  0,  'https://g1.globo.com/globonews/jornal-globonews-edicao-das-16/video/infectologista-explica-como-a-pandemia-do-coronavirus-afeta-outros-setores-alem-da-saude-8443386.ghtml',  0);
INSERT INTO `jeugenio25_MegaTime30`.`TbConteudo` (`Conteudo_dataFimExibicao`, `Conteudo_Produto_id`, `Conteudo_Nome`, `Conteudo_Descricao`, `Conteudo_dataCadastro`, `Conteudo_dataInicioExibicao`, `_deleted_`, `Conteudo_URL`, `Conteudo_Principal`) VALUES ('2021-10-30 00:00:00', 4, 'Globonews - Noticia',  'Entenda quais  enefícios a Caixa vai conceder durante a crise',  '2020-05-02 22:28:41',  '2020-05-01 00:00:00',  0,  'https://g1.globo.com/globonews/jornal-globonews-edicao-das-16/video/entenda-quais-os-beneficios-que-a-caixa-vai-conceder-durante-crise-do-coronavirus-8438024.ghtml',  0);
INSERT INTO `jeugenio25_MegaTime30`.`TbConteudo` (`Conteudo_dataFimExibicao`, `Conteudo_Produto_id`, `Conteudo_Nome`, `Conteudo_Descricao`, `Conteudo_dataCadastro`, `Conteudo_dataInicioExibicao`, `_deleted_`, `Conteudo_URL`, `Conteudo_Principal`) VALUES ('2021-10-30 00:00:00', 5, 'Globoesporte - Página Principal',  'Globoesporte - Página Principal',  '2020-05-02 22:28:41',  '2020-05-01 00:00:00',  0,  'https://globoesporte.globo.com/',  0);
INSERT INTO `jeugenio25_MegaTime30`.`TbConteudo` (`Conteudo_dataFimExibicao`, `Conteudo_Produto_id`, `Conteudo_Nome`, `Conteudo_Descricao`, `Conteudo_dataCadastro`, `Conteudo_dataInicioExibicao`, `_deleted_`, `Conteudo_URL`, `Conteudo_Principal`) VALUES ('2021-10-30 00:00:00', 5, 'Globoeporte - Fute ol Internacional',  'Globoeporte - Futebol Internacional',  '2020-05-02 22:28:41',  '2020-05-01 00:00:00',  0,  'https://globoesporte.globo.com/futebol/futebol-internacional/',  0);
INSERT INTO `jeugenio25_MegaTime30`.`TbConteudo` (`Conteudo_dataFimExibicao`, `Conteudo_Produto_id`, `Conteudo_Nome`, `Conteudo_Descricao`, `Conteudo_dataCadastro`, `Conteudo_dataInicioExibicao`, `_deleted_`, `Conteudo_URL`, `Conteudo_Principal`) VALUES ('2021-10-30 00:00:00', 5, 'Globoeporte - Vasco',  'Glo oeporte - Vasco',  '2020-05-02 22:28:41',  '2020-05-01 00:00:00',  0,  'https://globoesporte.globo.com/futebol/times/vasco/',  0);
INSERT INTO `jeugenio25_MegaTime30`.`TbConteudo` (`Conteudo_dataFimExibicao`, `Conteudo_Produto_id`, `Conteudo_Nome`, `Conteudo_Descricao`, `Conteudo_dataCadastro`, `Conteudo_dataInicioExibicao`, `_deleted_`, `Conteudo_URL`, `Conteudo_Principal`) VALUES ('2021-10-30 00:00:00', 6, 'Gshow - Página Principal',  'Gshow - Página Principal',  '2020-05-02 22:28:41',  '2020-05-01 00:00:00',  0,  'https://gshow.globo.com/',  0);
INSERT INTO `jeugenio25_MegaTime30`.`TbConteudo` (`Conteudo_dataFimExibicao`, `Conteudo_Produto_id`, `Conteudo_Nome`, `Conteudo_Descricao`, `Conteudo_dataCadastro`, `Conteudo_dataInicioExibicao`, `_deleted_`, `Conteudo_URL`, `Conteudo_Principal`) VALUES ('2021-10-30 00:00:00', 6, 'Gshow - Noticias',  'Pequenos Gênios: estreia impressiona internautas com crianças muito inteligentes',  '2020-05-02 22:28:41',  '2020-05-01 00:00:00',  0,  'https://gshow.globo.com/programas/caldeirao-do-huck/noticia/pequenos-genios-estreia-impressiona-internautas-com-criancas-muito-inteligentes.ghtml',  0);
INSERT INTO `jeugenio25_MegaTime30`.`TbConteudo` (`Conteudo_dataFimExibicao`, `Conteudo_Produto_id`, `Conteudo_Nome`, `Conteudo_Descricao`, `Conteudo_dataCadastro`, `Conteudo_dataInicioExibicao`, `_deleted_`, `Conteudo_URL`, `Conteudo_Principal`) VALUES ('2021-10-30 00:00:00', 6, 'Gshow - Noticias',  'Vídeo mostra os  bastidores da primeira prova do concurso garota Totalmente Demais',  '2020-05-02 22:28:41',  '2020-05-01 00:00:00',  0,  'https://gshow.globo.com/novelas/totalmente-demais/noticia/video-mostra-os-bastidores-da-primeira-prova-do-concurso-garota-totalmente-demais.ghtml',  0);
INSERT INTO `jeugenio25_MegaTime30`.`TbConteudo` (`Conteudo_dataFimExibicao`, `Conteudo_Produto_id`, `Conteudo_Nome`, `Conteudo_Descricao`, `Conteudo_dataCadastro`, `Conteudo_dataInicioExibicao`, `_deleted_`, `Conteudo_URL`, `Conteudo_Principal`) VALUES ('2021-10-30 00:00:00', 7, 'GloboPlay - Página Principal',  'GloboPlay - Página Principal',  '2020-05-02 22:28:41',  '2020-05-01 00:00:00',  0,  'https://globoplay.globo.com/',  0);
INSERT INTO `jeugenio25_MegaTime30`.`TbConteudo` (`Conteudo_dataFimExibicao`, `Conteudo_Produto_id`, `Conteudo_Nome`, `Conteudo_Descricao`, `Conteudo_dataCadastro`, `Conteudo_dataInicioExibicao`, `_deleted_`, `Conteudo_URL`, `Conteudo_Principal`) VALUES ('2021-10-30 00:00:00', 7, 'GloboPlay - Novelas',  'GloboPlay - Novelas',  '2020-05-02 22:28:41',  '2020-05-01 00:00:00',  0,  'https://globoplay.globo.com/categorias/novelas/',  0);
INSERT INTO `jeugenio25_MegaTime30`.`TbConteudo` (`Conteudo_dataFimExibicao`, `Conteudo_Produto_id`, `Conteudo_Nome`, `Conteudo_Descricao`, `Conteudo_dataCadastro`, `Conteudo_dataInicioExibicao`, `_deleted_`, `Conteudo_URL`, `Conteudo_Principal`) VALUES ('2021-10-30 00:00:00', 7, 'GloboPlay - Series',  'GloboPlay - Series',  '2020-05-02 22:28:41',  '2020-05-01 00:00:00',  0,  'https://globoplay.globo.com/categorias/series/',  0);
INSERT INTO `jeugenio25_MegaTime30`.`TbConteudo` (`Conteudo_dataFimExibicao`, `Conteudo_Produto_id`, `Conteudo_Nome`, `Conteudo_Descricao`, `Conteudo_dataCadastro`, `Conteudo_dataInicioExibicao`, `_deleted_`, `Conteudo_URL`, `Conteudo_Principal`) VALUES ('2021-10-30 00:00:00', 8, 'Multishow - Página Principal',  'Multishow - Página Principal',  '2020-05-02 22:28:41',  '2020-05-01 00:00:00',  0,  'http://multishow.globo.com/',  0);
INSERT INTO `jeugenio25_MegaTime30`.`TbConteudo` (`Conteudo_dataFimExibicao`, `Conteudo_Produto_id`, `Conteudo_Nome`, `Conteudo_Descricao`, `Conteudo_dataCadastro`, `Conteudo_dataInicioExibicao`, `_deleted_`, `Conteudo_URL`, `Conteudo_Principal`) VALUES ('2021-10-30 00:00:00', 8, 'Multishow - Humor',  'Multishow - Humor',  '2020-05-02 22:28:41',  '2020-05-01 00:00:00',  0,  'http://multishow.globo.com/humor',  0);
INSERT INTO `jeugenio25_MegaTime30`.`TbConteudo` (`Conteudo_dataFimExibicao`, `Conteudo_Produto_id`, `Conteudo_Nome`, `Conteudo_Descricao`, `Conteudo_dataCadastro`, `Conteudo_dataInicioExibicao`, `_deleted_`, `Conteudo_URL`, `Conteudo_Principal`) VALUES ('2021-10-30 00:00:00', 8, 'Multishow - Música',  'Multishow - Música',  '2020-05-02 22:28:41',  '2020-05-01 00:00:00',  0,  'http://multishow.globo.com/musica',  0);
INSERT INTO `jeugenio25_MegaTime30`.`TbConteudo` (`Conteudo_dataFimExibicao`, `Conteudo_Produto_id`, `Conteudo_Nome`, `Conteudo_Descricao`, `Conteudo_dataCadastro`, `Conteudo_dataInicioExibicao`, `_deleted_`, `Conteudo_URL`, `Conteudo_Principal`) VALUES ('2021-10-30 00:00:00', 9, 'Gloob  - Página Principal',  'Mundo Gloob ',  '2020-05-02 22:28:41',  '2020-05-01 00:00:00',  0,  'http://mundogloob.globo.com/',  0);
INSERT INTO `jeugenio25_MegaTime30`.`TbConteudo` (`Conteudo_dataFimExibicao`, `Conteudo_Produto_id`, `Conteudo_Nome`, `Conteudo_Descricao`, `Conteudo_dataCadastro`, `Conteudo_dataInicioExibicao`, `_deleted_`, `Conteudo_URL`, `Conteudo_Principal`) VALUES ('2021-10-30 00:00:00', 9, 'Gloob  - Jogos',  'Gloob  - Jogos',  '2020-05-02 22:28:41',  '2020-05-01 00:00:00',  0,  'http://mundogloob.globo.com/jogos',  0);
INSERT INTO `jeugenio25_MegaTime30`.`TbConteudo` (`Conteudo_dataFimExibicao`, `Conteudo_Produto_id`, `Conteudo_Nome`, `Conteudo_Descricao`, `Conteudo_dataCadastro`, `Conteudo_dataInicioExibicao`, `_deleted_`, `Conteudo_URL`, `Conteudo_Principal`) VALUES ('2021-10-30 00:00:00', 9, 'Gloob  - Eventos',  'Gloob  - Eventos',  '2020-05-02 22:28:41',  '2020-05-01 00:00:00',  0,  'http://mundogloob.globo.com/eventos',  0);
INSERT INTO `jeugenio25_MegaTime30`.`TbConteudo` (`Conteudo_dataFimExibicao`, `Conteudo_Produto_id`, `Conteudo_Nome`, `Conteudo_Descricao`, `Conteudo_dataCadastro`, `Conteudo_dataInicioExibicao`, `_deleted_`, `Conteudo_URL`, `Conteudo_Principal`) VALUES ('2021-10-30 00:00:00', 10, 'Futura - Página Principal',  'Futura - Página Principal',  '2020-05-02 22:28:41',  '2020-05-01 00:00:00',  0,  'https://www.futura.org.br/',  0);
INSERT INTO `jeugenio25_MegaTime30`.`TbConteudo` (`Conteudo_dataFimExibicao`, `Conteudo_Produto_id`, `Conteudo_Nome`, `Conteudo_Descricao`, `Conteudo_dataCadastro`, `Conteudo_dataInicioExibicao`, `_deleted_`, `Conteudo_URL`, `Conteudo_Principal`) VALUES ('2021-10-30 00:00:00', 10, 'Futura - Estude em casa',  'Futura - Estude em casa',  '2020-05-02 22:28:41',  '2020-05-01 00:00:00',  0,  'https://www.futura.org.br/10-conteudos-do-futura-para-estudar-em-casa/',  0);
INSERT INTO `jeugenio25_MegaTime30`.`TbConteudo` (`Conteudo_dataFimExibicao`, `Conteudo_Produto_id`, `Conteudo_Nome`, `Conteudo_Descricao`, `Conteudo_dataCadastro`, `Conteudo_dataInicioExibicao`, `_deleted_`, `Conteudo_URL`, `Conteudo_Principal`) VALUES ('2021-10-30 00:00:00', 10, 'Futura - Cursos online',  'Futura - Cursos online',  '2020-05-02 22:28:41',  '2020-05-01 00:00:00',  0,  'https://www.futura.org.br/cursos',  0);
INSERT INTO `jeugenio25_MegaTime30`.`TbConteudo` (`Conteudo_dataFimExibicao`, `Conteudo_Produto_id`, `Conteudo_Nome`, `Conteudo_Descricao`, `Conteudo_dataCadastro`, `Conteudo_dataInicioExibicao`, `_deleted_`, `Conteudo_URL`, `Conteudo_Principal`) VALUES ('2021-10-30 00:00:00', 11, 'Cartola FC - Página Principal',  'Cartola FC - Página Principal',  '2020-05-02 22:28:41',  '2020-05-01 00:00:00',  0,  'https://globoesporte.globo.com/cartola-fc/',  0);
INSERT INTO `jeugenio25_MegaTime30`.`TbConteudo` (`Conteudo_dataFimExibicao`, `Conteudo_Produto_id`, `Conteudo_Nome`, `Conteudo_Descricao`, `Conteudo_dataCadastro`, `Conteudo_dataInicioExibicao`, `_deleted_`, `Conteudo_URL`, `Conteudo_Principal`) VALUES ('2021-10-30 00:00:00', 11, 'Cartola FC - Dicas Valiosas',  'Cartola FC - Dicas Valiosas',  '2020-05-02 22:28:41',  '2020-05-01 00:00:00',  0,  'https://globoesporte.globo.com/cartola-fc/noticia/campeao-do-cartola-pro-2018-conta-sua-estrategia-na-hora-de-escolher-capitao.ghtml',  0);
INSERT INTO `jeugenio25_MegaTime30`.`TbConteudo` (`Conteudo_dataFimExibicao`, `Conteudo_Produto_id`, `Conteudo_Nome`, `Conteudo_Descricao`, `Conteudo_dataCadastro`, `Conteudo_dataInicioExibicao`, `_deleted_`, `Conteudo_URL`, `Conteudo_Principal`) VALUES ('2021-10-30 00:00:00', 11, 'Cartola FC - Saudade das cartoletas',  'Cartola FC - Saudade das cartoletas',  '2020-05-02 22:28:41',  '2020-05-01 00:00:00',  0,  'https://globoesporte.globo.com/cartola-fc/noticia/bom-e-barato-mais-valorizado-participe-do-quiz-de-precos-do-cartola-fc.ghtml',  0);
INSERT INTO `jeugenio25_MegaTime30`.`TbConteudo` (`Conteudo_dataFimExibicao`, `Conteudo_Produto_id`, `Conteudo_Nome`, `Conteudo_Descricao`, `Conteudo_dataCadastro`, `Conteudo_dataInicioExibicao`, `_deleted_`, `Conteudo_URL`, `Conteudo_Principal`) VALUES ('2021-10-30 00:00:00', 12, 'GlobosatPlay - Página Principal',  'GlobosatPlay - Página Principal',  '2020-05-02 22:28:41',  '2020-05-01 00:00:00',  0,  'https://globosatplay.globo.com/',  0);
INSERT INTO `jeugenio25_MegaTime30`.`TbConteudo` (`Conteudo_dataFimExibicao`, `Conteudo_Produto_id`, `Conteudo_Nome`, `Conteudo_Descricao`, `Conteudo_dataCadastro`, `Conteudo_dataInicioExibicao`, `_deleted_`, `Conteudo_URL`, `Conteudo_Principal`) VALUES ('2021-10-30 00:00:00', 12, 'GlobosatPlay - Agora na TV',  'GlobosatPlay - Agora na TV',  '2020-05-02 22:28:41',  '2020-05-01 00:00:00',  0,  'https://globosatplay.globo.com/',  0);
INSERT INTO `jeugenio25_MegaTime30`.`TbConteudo` (`Conteudo_dataFimExibicao`, `Conteudo_Produto_id`, `Conteudo_Nome`, `Conteudo_Descricao`, `Conteudo_dataCadastro`, `Conteudo_dataInicioExibicao`, `_deleted_`, `Conteudo_URL`, `Conteudo_Principal`) VALUES ('2021-10-30 00:00:00', 12, 'GlobosatPlay - Explore',  'GlobosatPlay - Explore',  '2020-05-02 22:28:41',  '2020-05-01 00:00:00',  0,  'https://globosatplay.globo.com/explore',  0);
INSERT INTO `jeugenio25_MegaTime30`.`TbConteudo` (`Conteudo_dataFimExibicao`, `Conteudo_Produto_id`, `Conteudo_Nome`, `Conteudo_Descricao`, `Conteudo_dataCadastro`, `Conteudo_dataInicioExibicao`, `_deleted_`, `Conteudo_URL`, `Conteudo_Principal`) VALUES ('2021-10-30 00:00:00', 13, 'GloboRural - Página Principal',  'GloboRural - Página Principal',  '2020-05-02 22:28:41',  '2020-05-01 00:00:00',  0,  'https://g1.globo.com/economia/agronegocios/globo-rural/',  0);
INSERT INTO `jeugenio25_MegaTime30`.`TbConteudo` (`Conteudo_dataFimExibicao`, `Conteudo_Produto_id`, `Conteudo_Nome`, `Conteudo_Descricao`, `Conteudo_dataCadastro`, `Conteudo_dataInicioExibicao`, `_deleted_`, `Conteudo_URL`, `Conteudo_Principal`) VALUES ('2021-10-30 00:00:00', 13, 'GloboRural - Noticias',  'Conheça a  Bomba Rosário, um equipamento que pode ajudar produtores do sertão do Nordeste',  '2020-05-02 22:28:41',  '2020-05-01 00:00:00',  0,  'https://g1.globo.com/economia/agronegocios/globo-rural/noticia/2020/04/26/conheca-a-bomba-rosario-um-equipamento-que-pode-ajudar-produtores-do-sertao-do-nordeste.ghtml',  0);
INSERT INTO `jeugenio25_MegaTime30`.`TbConteudo` (`Conteudo_dataFimExibicao`, `Conteudo_Produto_id`, `Conteudo_Nome`, `Conteudo_Descricao`, `Conteudo_dataCadastro`, `Conteudo_dataInicioExibicao`, `_deleted_`, `Conteudo_URL`, `Conteudo_Principal`) VALUES ('2021-10-30 00:00:00', 13, 'GloboRural - Noticias',  'Produtores de algodão de Mato Grosso estão preocupados com os preços',  '2020-05-02 22:28:41',  '2020-05-01 00:00:00',  0,  'https://g1.globo.com/economia/agronegocios/globo-rural/noticia/2020/04/26/produtores-de-algodao-de-mato-grosso-estao-preocupados-com-os-precos.ghtml',  0);
INSERT INTO `jeugenio25_MegaTime30`.`TbConteudo` (`Conteudo_dataFimExibicao`, `Conteudo_Produto_id`, `Conteudo_Nome`, `Conteudo_Descricao`, `Conteudo_dataCadastro`, `Conteudo_dataInicioExibicao`, `_deleted_`, `Conteudo_URL`, `Conteudo_Principal`) VALUES ('2021-10-30 00:00:00', 14, 'Philos - Página Principal',  'Philos - Página Principal',  '2020-05-02 22:28:41',  '2020-05-01 00:00:00',  0,  'https://philos.tv/',  0);
INSERT INTO `jeugenio25_MegaTime30`.`TbConteudo` (`Conteudo_dataFimExibicao`, `Conteudo_Produto_id`, `Conteudo_Nome`, `Conteudo_Descricao`, `Conteudo_dataCadastro`, `Conteudo_dataInicioExibicao`, `_deleted_`, `Conteudo_URL`, `Conteudo_Principal`) VALUES ('2021-10-30 00:00:00', 14, 'Philos - Programação',  'Philos - Programação',  '2020-05-02 22:28:41',  '2020-05-01 00:00:00',  0,  'https://philos.tv/programacao/',  0);
INSERT INTO `jeugenio25_MegaTime30`.`TbConteudo` (`Conteudo_dataFimExibicao`, `Conteudo_Produto_id`, `Conteudo_Nome`, `Conteudo_Descricao`, `Conteudo_dataCadastro`, `Conteudo_dataInicioExibicao`, `_deleted_`, `Conteudo_URL`, `Conteudo_Principal`) VALUES ('2021-10-30 00:00:00', 14, 'Philos - Sobre',  'Philos - Sobre',  '2020-05-02 22:28:41',  '2020-05-01 00:00:00',  0,  'https://philos.tv/sobre/',  0);
INSERT INTO `jeugenio25_MegaTime30`.`TbConteudo` (`Conteudo_dataFimExibicao`, `Conteudo_Produto_id`, `Conteudo_Nome`, `Conteudo_Descricao`, `Conteudo_dataCadastro`, `Conteudo_dataInicioExibicao`, `_deleted_`, `Conteudo_URL`, `Conteudo_Principal`) VALUES ('2021-10-30 00:00:00', 15, 'Premiere - Página Principal',  'Premiere - Página Principal',  '2020-05-02 22:28:41',  '2020-05-01 00:00:00',  0,  'https://globoesporte.globo.com/premiere/',  0);

DELETE FROM `jeugenio25_MegaTime30`.`TbConteudo` 
WHERE Conteudo_id >= 4 AND Conteudo_id <= 47

 
 
 
  




