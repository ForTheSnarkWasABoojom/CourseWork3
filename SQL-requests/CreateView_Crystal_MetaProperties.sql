USE [Crystal]
GO

/****** Object:  View [dbo].[MetaProperties]    Script Date: 14.04.2022 21:35:32 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

create view [dbo].[MetaProperties] as
select nazvprop as PropertyDescription
from Properties
GO


