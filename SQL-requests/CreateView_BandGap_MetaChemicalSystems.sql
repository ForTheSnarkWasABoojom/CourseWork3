USE [BandGap]
GO

/****** Object:  View [dbo].[MetaChemicalSystems]    Script Date: 14.04.2022 21:18:18 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



create view [dbo].[MetaChemicalSystems] as 
select dbo.NormalizeElements( dbo.GetSortedElementsFromString (case 
	  when El2 = ''
	  then '-'+El1+'-'
	  when el3=''
	  then '-'+el1+'-'+El2+'-'
	  when el4 = ''
	  then '-'+el1+'-'+El2+'-'+El3+'-'
	  else '-'+ el1 +'-'+ el2 +'-'+El3+'-'+El4+'-'
	  end)) System
	  from Substances
GO


