SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[personas](
	[Identificacion] [varchar](12) NOT NULL,
	[Nombre] [varchar](30) NULL,
	[Apellidos] [varchar](50) NULL,
	[Sexo] [varchar](17) NULL,
	[Edad] [int] NULL,
	[Departamento] [varchar](50) NULL,
	[Ciudad] [varchar](50) NULL,
	[ValorApoyo] [decimal](18, 0) NULL,
	[Modalidad] [varchar](25) NULL,
	[Fecha] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[Identificacion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO