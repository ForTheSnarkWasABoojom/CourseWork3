USE [BandGap]
GO

/****** Object:  View [dbo].[MetaSystemProperties]    Script Date: 14.04.2022 21:26:48 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

create view [dbo].[MetaSystemProperties] as 
select distinct dbo.NormalizeElements( dbo.GetSortedElementsFromString (case 
	  when El2 = ''
	  then '-'+El1+'-'
	  when el3=''
	  then '-'+el1+'-'+El2+'-'
	  when el4 = ''
	  then '-'+el1+'-'+El2+'-'+El3+'-'
	  else '-'+ el1 +'-'+ el2 +'-'+El3+'-'+El4+'-'
	  end)) System, 'BandGap' as Property
	  from Substances
GO


