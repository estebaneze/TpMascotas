/****** Object:  Table [dbo].[Adopcion]    Script Date: 28/5/2018 00:38:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Adopcion](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[personaId] [int] NOT NULL,
	[mascotaId] [int] NOT NULL,
	[personaAdoptaId] [int] NOT NULL,
	[fecha] [datetime] NOT NULL,
	[tipoContratoId] [int] NULL,
 CONSTRAINT [PK_Adopcion] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AdopcionEstado]    Script Date: 28/5/2018 00:38:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AdopcionEstado](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[adopcionId] [int] NOT NULL,
	[estadoId] [int] NOT NULL,
 CONSTRAINT [PK_AdopcionEstado_1] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Donacion]    Script Date: 28/5/2018 00:38:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Donacion](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[personaId] [int] NOT NULL,
	[mascotaId] [int] NOT NULL,
	[fecha] [date] NOT NULL,
	[monto] [money] NULL,
 CONSTRAINT [PK_Donacion] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Estado]    Script Date: 28/5/2018 00:38:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Estado](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[descripcion] [varchar](50) NULL,
 CONSTRAINT [PK_Estado] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Estudio]    Script Date: 28/5/2018 00:38:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Estudio](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[mascotaId] [int] NOT NULL,
	[tipoEstudioId] [int] NOT NULL,
	[fecha_realizacion] [date] NOT NULL,
	[veterinarioId] [int] NULL,
	[fecha_vencimiento] [date] NULL,
	[observaciones] [varchar](max) NULL,
 CONSTRAINT [PK_Estudio] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Local]    Script Date: 28/5/2018 00:38:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Local](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[provinciaId] [int] NULL,
	[localidadId] [int] NULL,
	[domicilio] [varchar](50) NULL,
	[razon_social] [varchar](50) NULL,
 CONSTRAINT [PK_Local] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Localidad]    Script Date: 28/5/2018 00:38:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Localidad](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](50) NULL,
	[provinciaId] [int] NULL,
 CONSTRAINT [PK_Localidad] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Mascota]    Script Date: 28/5/2018 00:38:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Mascota](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[razaId] [int] NULL,
	[nombre] [varchar](50) NULL,
	[sexo] [char](1) NULL,
	[fecha_nacimiento] [date] NULL,
	[color] [varchar](50) NULL,
	[tamañoId] [int] NULL,
	[caracter] [varchar](50) NULL,
	[observaciones] [varchar](100) NULL,
 CONSTRAINT [PK_Mascota] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Multimedia]    Script Date: 28/5/2018 00:38:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Multimedia](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[mascotaId] [int] NOT NULL,
	[tipo_archivo] [varchar](10) NULL,
	[ruta] [varchar](50) NOT NULL,
	[fecha_publicacion] [datetime] NULL,
 CONSTRAINT [PK_Multimedia] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Persona]    Script Date: 28/5/2018 00:38:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Persona](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[dni] [varchar](8) NULL,
	[apellido] [varchar](50) NULL,
	[nombre] [varchar](50) NULL,
	[fecha_nacimiento] [date] NULL,
	[cbu] [varchar](50) NULL,
	[calificacion] [float] NULL,
	[localidadId] [int] NULL,
	[domicilio] [varchar](50) NULL,
	[email] [varchar](50) NULL,
 CONSTRAINT [PK_Persona] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Provincia]    Script Date: 28/5/2018 00:38:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Provincia](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](50) NULL,
 CONSTRAINT [PK_Provincia] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Raza]    Script Date: 28/5/2018 00:38:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Raza](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[descripcion] [varchar](50) NULL,
 CONSTRAINT [PK_Raza] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tamaño]    Script Date: 28/5/2018 00:38:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tamaño](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[descripcion] [varchar](50) NULL,
 CONSTRAINT [PK_Tamaño] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TipoContrato]    Script Date: 28/5/2018 00:38:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TipoContrato](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[terminos] [varchar](max) NULL,
 CONSTRAINT [PK_TipoContrato] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TipoEstudio]    Script Date: 28/5/2018 00:38:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TipoEstudio](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[descripcion] [varchar](50) NULL,
	[periodo_validez] [int] NULL,
 CONSTRAINT [PK_TIpoEstudio] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Usuario]    Script Date: 28/5/2018 00:38:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuario](
	[usuarioId] [int] NOT NULL,
	[contraseña] [varchar](50) NULL,
	[habilitado] [bit] NULL,
	[ultima_conexion] [datetime] NULL,
 CONSTRAINT [PK_Usuario] PRIMARY KEY CLUSTERED 
(
	[usuarioId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Veterinario]    Script Date: 28/5/2018 00:38:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Veterinario](
	[veterinarioId] [int] NOT NULL,
	[matricula] [varchar](50) NULL,
	[habilitados] [bit] NULL,
 CONSTRAINT [PK_Veterinario] PRIMARY KEY CLUSTERED 
(
	[veterinarioId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[VeterinarioLocal]    Script Date: 28/5/2018 00:38:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[VeterinarioLocal](
	[veterinarioId] [int] NOT NULL,
	[localId] [int] NOT NULL,
 CONSTRAINT [PK_VeterinarioLocal] PRIMARY KEY CLUSTERED 
(
	[veterinarioId] ASC,
	[localId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Visita]    Script Date: 28/5/2018 00:38:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Visita](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[veterinarioId] [int] NOT NULL,
	[mascotaId] [int] NOT NULL,
	[fecha] [datetime] NOT NULL,
	[monto] [money] NULL,
 CONSTRAINT [PK_Visita] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Adopcion]  WITH CHECK ADD  CONSTRAINT [FK_Adopcion_Mascota] FOREIGN KEY([mascotaId])
REFERENCES [dbo].[Mascota] ([Id])
GO
ALTER TABLE [dbo].[Adopcion] CHECK CONSTRAINT [FK_Adopcion_Mascota]
GO
ALTER TABLE [dbo].[Adopcion]  WITH CHECK ADD  CONSTRAINT [FK_Adopcion_Persona] FOREIGN KEY([personaId])
REFERENCES [dbo].[Persona] ([Id])
GO
ALTER TABLE [dbo].[Adopcion] CHECK CONSTRAINT [FK_Adopcion_Persona]
GO
ALTER TABLE [dbo].[Adopcion]  WITH CHECK ADD  CONSTRAINT [FK_Adopcion_Persona1] FOREIGN KEY([personaAdoptaId])
REFERENCES [dbo].[Persona] ([Id])
GO
ALTER TABLE [dbo].[Adopcion] CHECK CONSTRAINT [FK_Adopcion_Persona1]
GO
ALTER TABLE [dbo].[Adopcion]  WITH CHECK ADD  CONSTRAINT [FK_Adopcion_TipoContrato] FOREIGN KEY([tipoContratoId])
REFERENCES [dbo].[TipoContrato] ([Id])
GO
ALTER TABLE [dbo].[Adopcion] CHECK CONSTRAINT [FK_Adopcion_TipoContrato]
GO
ALTER TABLE [dbo].[AdopcionEstado]  WITH CHECK ADD  CONSTRAINT [FK_AdopcionEstado_Adopcion1] FOREIGN KEY([adopcionId])
REFERENCES [dbo].[Adopcion] ([Id])
GO
ALTER TABLE [dbo].[AdopcionEstado] CHECK CONSTRAINT [FK_AdopcionEstado_Adopcion1]
GO
ALTER TABLE [dbo].[AdopcionEstado]  WITH CHECK ADD  CONSTRAINT [FK_AdopcionEstado_Estado] FOREIGN KEY([estadoId])
REFERENCES [dbo].[Estado] ([Id])
GO
ALTER TABLE [dbo].[AdopcionEstado] CHECK CONSTRAINT [FK_AdopcionEstado_Estado]
GO
ALTER TABLE [dbo].[Donacion]  WITH CHECK ADD  CONSTRAINT [FK_Donacion_Mascota] FOREIGN KEY([mascotaId])
REFERENCES [dbo].[Mascota] ([Id])
GO
ALTER TABLE [dbo].[Donacion] CHECK CONSTRAINT [FK_Donacion_Mascota]
GO
ALTER TABLE [dbo].[Donacion]  WITH CHECK ADD  CONSTRAINT [FK_Donacion_Persona] FOREIGN KEY([personaId])
REFERENCES [dbo].[Persona] ([Id])
GO
ALTER TABLE [dbo].[Donacion] CHECK CONSTRAINT [FK_Donacion_Persona]
GO
ALTER TABLE [dbo].[Estudio]  WITH CHECK ADD  CONSTRAINT [FK_Estudio_Mascota] FOREIGN KEY([mascotaId])
REFERENCES [dbo].[Mascota] ([Id])
GO
ALTER TABLE [dbo].[Estudio] CHECK CONSTRAINT [FK_Estudio_Mascota]
GO
ALTER TABLE [dbo].[Estudio]  WITH CHECK ADD  CONSTRAINT [FK_Estudio_TIpoEstudio] FOREIGN KEY([tipoEstudioId])
REFERENCES [dbo].[TipoEstudio] ([Id])
GO
ALTER TABLE [dbo].[Estudio] CHECK CONSTRAINT [FK_Estudio_TIpoEstudio]
GO
ALTER TABLE [dbo].[Estudio]  WITH CHECK ADD  CONSTRAINT [FK_Estudio_Veterinario] FOREIGN KEY([veterinarioId])
REFERENCES [dbo].[Veterinario] ([veterinarioId])
GO
ALTER TABLE [dbo].[Estudio] CHECK CONSTRAINT [FK_Estudio_Veterinario]
GO
ALTER TABLE [dbo].[Local]  WITH CHECK ADD  CONSTRAINT [FK_Local_Localidad] FOREIGN KEY([localidadId])
REFERENCES [dbo].[Localidad] ([Id])
GO
ALTER TABLE [dbo].[Local] CHECK CONSTRAINT [FK_Local_Localidad]
GO
ALTER TABLE [dbo].[Local]  WITH CHECK ADD  CONSTRAINT [FK_Local_Provincia] FOREIGN KEY([provinciaId])
REFERENCES [dbo].[Provincia] ([Id])
GO
ALTER TABLE [dbo].[Local] CHECK CONSTRAINT [FK_Local_Provincia]
GO
ALTER TABLE [dbo].[Localidad]  WITH CHECK ADD  CONSTRAINT [FK_Localidad_Provincia] FOREIGN KEY([provinciaId])
REFERENCES [dbo].[Provincia] ([Id])
GO
ALTER TABLE [dbo].[Localidad] CHECK CONSTRAINT [FK_Localidad_Provincia]
GO
ALTER TABLE [dbo].[Mascota]  WITH CHECK ADD  CONSTRAINT [FK_Mascota_Raza] FOREIGN KEY([razaId])
REFERENCES [dbo].[Raza] ([Id])
GO
ALTER TABLE [dbo].[Mascota] CHECK CONSTRAINT [FK_Mascota_Raza]
GO
ALTER TABLE [dbo].[Mascota]  WITH CHECK ADD  CONSTRAINT [FK_Mascota_Tamaño] FOREIGN KEY([tamañoId])
REFERENCES [dbo].[Tamaño] ([Id])
GO
ALTER TABLE [dbo].[Mascota] CHECK CONSTRAINT [FK_Mascota_Tamaño]
GO
ALTER TABLE [dbo].[Multimedia]  WITH CHECK ADD  CONSTRAINT [FK_Multimedia_Mascota] FOREIGN KEY([mascotaId])
REFERENCES [dbo].[Mascota] ([Id])
GO
ALTER TABLE [dbo].[Multimedia] CHECK CONSTRAINT [FK_Multimedia_Mascota]
GO
ALTER TABLE [dbo].[Persona]  WITH CHECK ADD  CONSTRAINT [FK_Persona_Localidad] FOREIGN KEY([localidadId])
REFERENCES [dbo].[Localidad] ([Id])
GO
ALTER TABLE [dbo].[Persona] CHECK CONSTRAINT [FK_Persona_Localidad]
GO
ALTER TABLE [dbo].[Usuario]  WITH CHECK ADD  CONSTRAINT [FK_Usuario_Persona] FOREIGN KEY([usuarioId])
REFERENCES [dbo].[Persona] ([Id])
GO
ALTER TABLE [dbo].[Usuario] CHECK CONSTRAINT [FK_Usuario_Persona]
GO
ALTER TABLE [dbo].[Veterinario]  WITH CHECK ADD  CONSTRAINT [FK_Veterinario_Persona] FOREIGN KEY([veterinarioId])
REFERENCES [dbo].[Persona] ([Id])
GO
ALTER TABLE [dbo].[Veterinario] CHECK CONSTRAINT [FK_Veterinario_Persona]
GO
ALTER TABLE [dbo].[VeterinarioLocal]  WITH CHECK ADD  CONSTRAINT [FK_VeterinarioLocal_Local] FOREIGN KEY([localId])
REFERENCES [dbo].[Local] ([Id])
GO
ALTER TABLE [dbo].[VeterinarioLocal] CHECK CONSTRAINT [FK_VeterinarioLocal_Local]
GO
ALTER TABLE [dbo].[VeterinarioLocal]  WITH CHECK ADD  CONSTRAINT [FK_VeterinarioLocal_Veterinario] FOREIGN KEY([veterinarioId])
REFERENCES [dbo].[Veterinario] ([veterinarioId])
GO
ALTER TABLE [dbo].[VeterinarioLocal] CHECK CONSTRAINT [FK_VeterinarioLocal_Veterinario]
GO
ALTER TABLE [dbo].[Visita]  WITH CHECK ADD  CONSTRAINT [FK_Visita_Mascota] FOREIGN KEY([mascotaId])
REFERENCES [dbo].[Mascota] ([Id])
GO
ALTER TABLE [dbo].[Visita] CHECK CONSTRAINT [FK_Visita_Mascota]
GO
ALTER TABLE [dbo].[Visita]  WITH CHECK ADD  CONSTRAINT [FK_Visita_Veterinario] FOREIGN KEY([veterinarioId])
REFERENCES [dbo].[Veterinario] ([veterinarioId])
GO
ALTER TABLE [dbo].[Visita] CHECK CONSTRAINT [FK_Visita_Veterinario]
GO
