USE [WeeCompany]
GO

/****** Object:  Table [dbo].[WCParticipantes]    Script Date: 24/06/2023 11:28:06 a. m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[WCParticipantes](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[nombreCompania] [varchar](80) NOT NULL,
	[cedula] [varchar](10) NOT NULL,
	[nombreContacto] [varchar](80) NOT NULL,
	[titulo] [varchar](80) NOT NULL,
	[correoElectronico] [varchar](30) NOT NULL,
	[telefono] [varchar](12) NOT NULL,
	[fecha] [datetime] NOT NULL,
	[estatus] [char](1) NOT NULL,
 CONSTRAINT [PK_WCParticipantes] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[WCParticipantes] ADD  CONSTRAINT [DF_WCParticipantes_estatus]  DEFAULT ((1)) FOR [estatus]
GO


