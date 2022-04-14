USE [Crystal]
GO

/****** Object:  View [dbo].[MetaChemicalSystems]    Script Date: 14.04.2022 21:34:27 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

Create view [dbo].[MetaChemicalSystems] as select trim('-' from Help) as System
from  HeadTabl
GO


