 select  * from (select  * from (
 SELECT pd.* FROM  TbProdutos pd
	inner join (
	select LogUso_Usuario_id,  LogUso_Produto_id    ,    count(0) QtdUsos FROM TbLogUso lg
	where  lg.LogUso_Usuario_id =1
    -- lg.LogUso_Usuario_id = 2
    group by LogUso_Usuario_id,  LogUso_Produto_id 
	) a on LogUso_Produto_id = Produto_id    order by QtdUsos desc
) Cb
 union   
SELECT * FROM  TbProdutos pd where produto_ativo = 1) j limit 10

 -- Sem IA
 
 select * from (SELECT * FROM  TbProdutos where Produto_Ativo = 1 and produto_id = 1
union
SELECT * FROM  TbProdutos where Produto_Ativo = 1 and produto_id = 3
union
SELECT * FROM  TbProdutos where Produto_Ativo = 1 and produto_id = 2
union
SELECT * FROM TbProdutos where Produto_Ativo = 1 and produto_id not in (1,3,2)
 ) a limit 1
 
 
 
 select LogUso_Usuario_id,  LogUso_Produto_id    ,    count(0) QtdUsos FROM TbLogUso lg
	where  lg.LogUso_Usuario_id =1
    -- lg.LogUso_Usuario_id = 1
    group by LogUso_Usuario_id,  LogUso_Produto_id 
 