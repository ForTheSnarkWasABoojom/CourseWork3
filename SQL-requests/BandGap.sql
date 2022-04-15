USE [BandGap]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create OR ALTER view [dbo].[MetaChemicalSystems] as 
-- select * from [dbo].[MetaChemicalSystems]
select distinct dbo.NormalizeElements(dbo.GetElements(NumElements, El1, El2, El3, El4, [Elements], Compound)) System
	  from Substances
GO




SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create OR ALTER view [dbo].[MetaProperties] as
-- select * from [dbo].[MetaProperties]
select 'Bandgap' as PropertyDescription
GO


SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create OR ALTER view [dbo].[MetaSystemProperties] as 
-- select * from [dbo].[MetaSystemProperties]
select [System], 'Bandgap' as Property
	  from dbo.MetaChemicalSystems
GO
