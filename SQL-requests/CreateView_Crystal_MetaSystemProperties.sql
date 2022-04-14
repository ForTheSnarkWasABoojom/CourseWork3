USE [Crystal]
GO

/****** Object:  View [dbo].[MetaSystemProperties]    Script Date: 14.04.2022 21:35:52 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

create view [dbo].[MetaSystemProperties] as

	SELECT distinct trim('-' from Help) as System, 'Аналитический обзор' as Property  FROM RefrTabl
inner join HeadTabl on
HeadTabl.HeadClue=RefrTabl.HeadClue
	union all
	SELECT distinct trim('-' from Help) as System, 'Cостав соединения' as Property  FROM SistTabl
inner join HeadTabl on
HeadTabl.HeadClue=SistTabl.HeadClue
	union all
	SELECT distinct trim('-' from Help) as System, 'Удельная теплоемкость' as Property  FROM HeatTabl
inner join HeadTabl on
HeadTabl.HeadClue=HeatTabl.HeadClue
	
	union all
	SELECT distinct trim('-' from Help) as System, 'Плотность' as Property  FROM DensTabl
inner join HeadTabl on
HeadTabl.HeadClue=DensTabl.HeadClue
	union all
	SELECT distinct trim('-' from Help) as System, 'Твердость' as Property  FROM HardTabl
inner join HeadTabl on
HeadTabl.HeadClue=HardTabl.HeadClue
	union all
	SELECT distinct trim('-' from Help) as System, 'Растворимость' as Property  FROM SuspTabl
inner join HeadTabl on
HeadTabl.HeadClue=SuspTabl.HeadClue
	union all
	SELECT distinct trim('-' from Help) as System, 'Температура плавления' as Property  FROM PlavTabl
inner join HeadTabl on
HeadTabl.HeadClue=PlavTabl.HeadClue
	union all
	SELECT distinct trim('-' from Help) as System, 'Температура Кюри' as Property  FROM CuryTabl
inner join HeadTabl on
HeadTabl.HeadClue=CuryTabl.HeadClue
	union all
	SELECT distinct trim('-' from Help) as System, 'Характеристика кристаллической структуры' as Property  FROM ModfTabl
inner join HeadTabl on
HeadTabl.HeadClue=ModfTabl.HeadClue
	union all
	SELECT distinct trim('-' from Help) as System, 'Параметры элементарной ячейки' as Property  FROM ElemTabl
inner join HeadTabl on
HeadTabl.HeadClue=ElemTabl.HeadClue
	union all
	SELECT distinct trim('-' from Help) as System, 'Тепловое расширение' as Property  FROM HeatExpn
inner join HeadTabl on
HeadTabl.HeadClue=HeatExpn.HeadClue
 WHERE DataType=0
	union all
	SELECT distinct trim('-' from Help) as System, 'Теплопроводность' as Property  FROM HeatExpn
inner join HeadTabl on
HeadTabl.HeadClue=HeatExpn.HeadClue
 WHERE DataType=1
	union all
	SELECT distinct trim('-' from Help) as System, 'Диэлектрическая проницаемость' as Property  FROM Dielectr
inner join HeadTabl on
HeadTabl.HeadClue=Dielectr.HeadClue
	union all
	SELECT distinct trim('-' from Help) as System, 'Тангенс угла диэлектрических потерь' as Property  FROM DielDiss
inner join HeadTabl on
HeadTabl.HeadClue=DielDiss.HeadClue
	union all
	SELECT distinct trim('-' from Help) as System, 'Пьезоэлектрические коэффициенты' as Property  FROM PzElTabl
inner join HeadTabl on
HeadTabl.HeadClue=PzElTabl.HeadClue
	union all
	SELECT distinct trim('-' from Help) as System, 'Коэффициенты электромеханической связи' as Property  FROM MechTabl
inner join HeadTabl on
HeadTabl.HeadClue=MechTabl.HeadClue
	union all
	SELECT distinct trim('-' from Help) as System, 'Упругие постоянные' as Property  FROM Elastic1
inner join HeadTabl on
HeadTabl.HeadClue=Elastic1.HeadClue
	union all
	SELECT distinct trim('-' from Help) as System, 'Полоса пропускания' as Property  FROM Wavepure
inner join HeadTabl on
HeadTabl.HeadClue=Wavepure.HeadClue
	union all
	SELECT distinct trim('-' from Help) as System, 'Показатели преломления' as Property  FROM RefrcInd
inner join HeadTabl on
HeadTabl.HeadClue=RefrcInd.HeadClue
	union all
	SELECT distinct trim('-' from Help) as System, 'Коэффициенты Селмейера' as Property  FROM ConstSel
inner join HeadTabl on
HeadTabl.HeadClue=ConstSel.HeadClue
	union all
	SELECT distinct trim('-' from Help) as System, 'Коэффициенты линейного электрооптического эффекта' as Property  FROM ElOpTabl
inner join HeadTabl on
HeadTabl.HeadClue=ElOpTabl.HeadClue
	union all
	SELECT distinct trim('-' from Help) as System, 'Нелинейные оптические свойства' as Property  FROM NlOpTabl
inner join HeadTabl on
HeadTabl.HeadClue=NlOpTabl.HeadClue
	union all
	SELECT distinct trim('-' from Help) as System, 'Пьезооптические и упругооптические коэффициенты' as Property  FROM EsOpTabl
inner join HeadTabl on
HeadTabl.HeadClue=EsOpTabl.HeadClue
	union all
	SELECT distinct trim('-' from Help) as System, 'Распространение и затухание упругих волн' as Property  FROM DecrTabl
inner join HeadTabl on
HeadTabl.HeadClue=DecrTabl.HeadClue
	union all
	SELECT distinct trim('-' from Help) as System, 'Акустооптические свойства' as Property  FROM AcOpTabl
inner join HeadTabl on
HeadTabl.HeadClue=AcOpTabl.HeadClue
	union all
	SELECT distinct trim('-' from Help) as System, 'Литература' as Property  FROM LitrTabl
inner join HeadTabl on
HeadTabl.HeadClue=LitrTabl.HeadClue
GO


