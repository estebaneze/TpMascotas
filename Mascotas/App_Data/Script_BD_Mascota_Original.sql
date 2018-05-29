/****** Object:  Table [dbo].[Adopcion]    Script Date: 25/5/2018 22:44:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Adopcion](
	[persona_id] [int] NOT NULL,
	[mascota_id] [int] NOT NULL,
	[persona_adopta_id] [int] NOT NULL,
	[fecha] [datetime] NOT NULL,
	[tipo_contrato_adopcion_id] [int] NULL,
 CONSTRAINT [PK_Adopcion] PRIMARY KEY CLUSTERED 
(
	[persona_id] ASC,
	[mascota_id] ASC,
	[persona_adopta_id] ASC,
	[fecha] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AdopcionEstado]    Script Date: 25/5/2018 22:44:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AdopcionEstado](
	[persona_id] [int] NOT NULL,
	[mascota_id] [int] NOT NULL,
	[persona_adopta_id] [int] NOT NULL,
	[fecha] [datetime] NOT NULL,
	[estado_id] [int] NOT NULL,
 CONSTRAINT [PK_AdopcionEstado] PRIMARY KEY CLUSTERED 
(
	[persona_id] ASC,
	[mascota_id] ASC,
	[persona_adopta_id] ASC,
	[fecha] ASC,
	[estado_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Donacion]    Script Date: 25/5/2018 22:44:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Donacion](
	[persona_id] [int] NOT NULL,
	[mascota_id] [int] NOT NULL,
	[fecha] [date] NOT NULL,
	[monto] [money] NULL,
 CONSTRAINT [PK_Donacion] PRIMARY KEY CLUSTERED 
(
	[persona_id] ASC,
	[mascota_id] ASC,
	[fecha] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Estado]    Script Date: 25/5/2018 22:44:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Estado](
	[estado_id] [int] NOT NULL,
	[descripcion] [varchar](50) NULL,
 CONSTRAINT [PK_Estado] PRIMARY KEY CLUSTERED 
(
	[estado_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Estudio]    Script Date: 25/5/2018 22:44:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Estudio](
	[mascota_id] [int] NOT NULL,
	[tipo_estudio_id] [int] NOT NULL,
	[fecha_realizacion] [date] NOT NULL,
	[persona_id] [int] NULL,
	[fecha_vencimiento] [date] NULL,
	[observaciones] [varchar](max) NULL,
 CONSTRAINT [PK_Estudio] PRIMARY KEY CLUSTERED 
(
	[mascota_id] ASC,
	[tipo_estudio_id] ASC,
	[fecha_realizacion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Local]    Script Date: 25/5/2018 22:44:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Local](
	[local_id] [int] NOT NULL,
	[provincia_id] [int] NULL,
	[localidad_id] [int] NULL,
	[domicilio] [varchar](50) NULL,
	[razon_social] [varchar](50) NULL,
 CONSTRAINT [PK_Local] PRIMARY KEY CLUSTERED 
(
	[local_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Localidad]    Script Date: 25/5/2018 22:44:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Localidad](
	[localidad_id] [int] NOT NULL,
	[nombre] [varchar](50) NULL,
	[provincia_id] [int] NULL,
 CONSTRAINT [PK_Localidad] PRIMARY KEY CLUSTERED 
(
	[localidad_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Mascota]    Script Date: 25/5/2018 22:44:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Mascota](
	[mascota_id] [int] NOT NULL,
	[raza_id] [int] NULL,
	[nombre] [varchar](50) NULL,
	[sexo] [char](1) NULL,
	[fecha_nacimiento] [date] NULL,
	[color] [varchar](50) NULL,
	[tamaño_id] [int] NULL,
	[caracter] [varchar](50) NULL,
	[observaciones] [varchar](100) NULL,
 CONSTRAINT [PK_Mascota] PRIMARY KEY CLUSTERED 
(
	[mascota_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Multimedia]    Script Date: 25/5/2018 22:44:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Multimedia](
	[mascota_id] [int] NOT NULL,
	[tipo_archivo] [varchar](10) NULL,
	[ruta] [varchar](50) NOT NULL,
	[fecha_publicacion] [datetime] NULL,
 CONSTRAINT [PK_Multimedia] PRIMARY KEY CLUSTERED 
(
	[mascota_id] ASC,
	[ruta] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Persona]    Script Date: 25/5/2018 22:44:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Persona](
	[persona_id] [int] NOT NULL,
	[dni] [varchar](8) NULL,
	[apellido] [varchar](50) NULL,
	[nombre] [varchar](50) NULL,
	[fecha_nacimiento] [date] NULL,
	[cbu] [varchar](50) NULL,
	[calificacion] [float] NULL,
	[localidad_id] [int] NULL,
	[domicilio] [varchar](50) NULL,
	[email] [varchar](50) NULL,
 CONSTRAINT [PK_Persona] PRIMARY KEY CLUSTERED 
(
	[persona_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Provincia]    Script Date: 25/5/2018 22:44:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Provincia](
	[provincia_id] [int] NOT NULL,
	[nombre] [varchar](50) NULL,
 CONSTRAINT [PK_Provincia] PRIMARY KEY CLUSTERED 
(
	[provincia_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Raza]    Script Date: 25/5/2018 22:44:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Raza](
	[raza_id] [int] NOT NULL,
	[descripcion] [varchar](50) NULL,
 CONSTRAINT [PK_Raza] PRIMARY KEY CLUSTERED 
(
	[raza_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tamaño]    Script Date: 25/5/2018 22:44:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tamaño](
	[tamaño_id] [int] NOT NULL,
	[descripcion] [varchar](50) NULL,
 CONSTRAINT [PK_Tamaño] PRIMARY KEY CLUSTERED 
(
	[tamaño_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TipoContrato]    Script Date: 25/5/2018 22:44:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TipoContrato](
	[tipo_contrato_adopcion_id] [int] NOT NULL,
	[terminos] [varchar](max) NULL,
 CONSTRAINT [PK_TipoContrato] PRIMARY KEY CLUSTERED 
(
	[tipo_contrato_adopcion_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TIpoEstudio]    Script Date: 25/5/2018 22:44:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TIpoEstudio](
	[tipo_estudio_id] [int] NOT NULL,
	[descripcion] [varchar](50) NULL,
	[periodo_validez] [int] NULL,
 CONSTRAINT [PK_TIpoEstudio] PRIMARY KEY CLUSTERED 
(
	[tipo_estudio_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Usuario]    Script Date: 25/5/2018 22:44:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuario](
	[persona_id] [int] NOT NULL,
	[contraseña] [varchar](50) NULL,
	[habilitado] [bit] NULL,
	[ultima_conexion] [datetime] NULL,
 CONSTRAINT [PK_Usuario] PRIMARY KEY CLUSTERED 
(
	[persona_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Veterinario]    Script Date: 25/5/2018 22:44:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Veterinario](
	[persona_id] [int] NOT NULL,
	[matricula] [varchar](50) NULL,
	[habilitados] [bit] NULL,
 CONSTRAINT [PK_Veterinario] PRIMARY KEY CLUSTERED 
(
	[persona_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[VeterinarioLocal]    Script Date: 25/5/2018 22:44:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[VeterinarioLocal](
	[persona_id] [int] NOT NULL,
	[local_id] [int] NOT NULL,
 CONSTRAINT [PK_VeterinarioLocal] PRIMARY KEY CLUSTERED 
(
	[persona_id] ASC,
	[local_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Visita]    Script Date: 25/5/2018 22:44:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Visita](
	[persona_id] [int] NOT NULL,
	[mascota_id] [int] NOT NULL,
	[fecha] [datetime] NOT NULL,
	[monto] [money] NULL,
 CONSTRAINT [PK_Visita] PRIMARY KEY CLUSTERED 
(
	[persona_id] ASC,
	[mascota_id] ASC,
	[fecha] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Adopcion]  WITH CHECK ADD  CONSTRAINT [FK_Adopcion_Mascota] FOREIGN KEY([mascota_id])
REFERENCES [dbo].[Mascota] ([mascota_id])
GO
ALTER TABLE [dbo].[Adopcion] CHECK CONSTRAINT [FK_Adopcion_Mascota]
GO
ALTER TABLE [dbo].[Adopcion]  WITH CHECK ADD  CONSTRAINT [FK_Adopcion_Persona] FOREIGN KEY([persona_id])
REFERENCES [dbo].[Persona] ([persona_id])
GO
ALTER TABLE [dbo].[Adopcion] CHECK CONSTRAINT [FK_Adopcion_Persona]
GO
ALTER TABLE [dbo].[Adopcion]  WITH CHECK ADD  CONSTRAINT [FK_Adopcion_Persona1] FOREIGN KEY([persona_adopta_id])
REFERENCES [dbo].[Persona] ([persona_id])
GO
ALTER TABLE [dbo].[Adopcion] CHECK CONSTRAINT [FK_Adopcion_Persona1]
GO
ALTER TABLE [dbo].[Adopcion]  WITH CHECK ADD  CONSTRAINT [FK_Adopcion_TipoContrato] FOREIGN KEY([tipo_contrato_adopcion_id])
REFERENCES [dbo].[TipoContrato] ([tipo_contrato_adopcion_id])
GO
ALTER TABLE [dbo].[Adopcion] CHECK CONSTRAINT [FK_Adopcion_TipoContrato]
GO
ALTER TABLE [dbo].[AdopcionEstado]  WITH CHECK ADD  CONSTRAINT [FK_AdopcionEstado_Adopcion] FOREIGN KEY([persona_id], [mascota_id], [persona_adopta_id], [fecha])
REFERENCES [dbo].[Adopcion] ([persona_id], [mascota_id], [persona_adopta_id], [fecha])
GO
ALTER TABLE [dbo].[AdopcionEstado] CHECK CONSTRAINT [FK_AdopcionEstado_Adopcion]
GO
ALTER TABLE [dbo].[AdopcionEstado]  WITH CHECK ADD  CONSTRAINT [FK_AdopcionEstado_Estado] FOREIGN KEY([estado_id])
REFERENCES [dbo].[Estado] ([estado_id])
GO
ALTER TABLE [dbo].[AdopcionEstado] CHECK CONSTRAINT [FK_AdopcionEstado_Estado]
GO
ALTER TABLE [dbo].[Donacion]  WITH CHECK ADD  CONSTRAINT [FK_Donacion_Mascota] FOREIGN KEY([mascota_id])
REFERENCES [dbo].[Mascota] ([mascota_id])
GO
ALTER TABLE [dbo].[Donacion] CHECK CONSTRAINT [FK_Donacion_Mascota]
GO
ALTER TABLE [dbo].[Donacion]  WITH CHECK ADD  CONSTRAINT [FK_Donacion_Persona] FOREIGN KEY([persona_id])
REFERENCES [dbo].[Persona] ([persona_id])
GO
ALTER TABLE [dbo].[Donacion] CHECK CONSTRAINT [FK_Donacion_Persona]
GO
ALTER TABLE [dbo].[Estudio]  WITH CHECK ADD  CONSTRAINT [FK_Estudio_Mascota] FOREIGN KEY([mascota_id])
REFERENCES [dbo].[Mascota] ([mascota_id])
GO
ALTER TABLE [dbo].[Estudio] CHECK CONSTRAINT [FK_Estudio_Mascota]
GO
ALTER TABLE [dbo].[Estudio]  WITH CHECK ADD  CONSTRAINT [FK_Estudio_TIpoEstudio] FOREIGN KEY([tipo_estudio_id])
REFERENCES [dbo].[TIpoEstudio] ([tipo_estudio_id])
GO
ALTER TABLE [dbo].[Estudio] CHECK CONSTRAINT [FK_Estudio_TIpoEstudio]
GO
ALTER TABLE [dbo].[Estudio]  WITH CHECK ADD  CONSTRAINT [FK_Estudio_Veterinario] FOREIGN KEY([persona_id])
REFERENCES [dbo].[Veterinario] ([persona_id])
GO
ALTER TABLE [dbo].[Estudio] CHECK CONSTRAINT [FK_Estudio_Veterinario]
GO
ALTER TABLE [dbo].[Local]  WITH CHECK ADD  CONSTRAINT [FK_Local_Localidad] FOREIGN KEY([localidad_id])
REFERENCES [dbo].[Localidad] ([localidad_id])
GO
ALTER TABLE [dbo].[Local] CHECK CONSTRAINT [FK_Local_Localidad]
GO
ALTER TABLE [dbo].[Local]  WITH CHECK ADD  CONSTRAINT [FK_Local_Provincia] FOREIGN KEY([provincia_id])
REFERENCES [dbo].[Provincia] ([provincia_id])
GO
ALTER TABLE [dbo].[Local] CHECK CONSTRAINT [FK_Local_Provincia]
GO
ALTER TABLE [dbo].[Localidad]  WITH CHECK ADD  CONSTRAINT [FK_Localidad_Provincia] FOREIGN KEY([provincia_id])
REFERENCES [dbo].[Provincia] ([provincia_id])
GO
ALTER TABLE [dbo].[Localidad] CHECK CONSTRAINT [FK_Localidad_Provincia]
GO
ALTER TABLE [dbo].[Mascota]  WITH CHECK ADD  CONSTRAINT [FK_Mascota_Raza] FOREIGN KEY([raza_id])
REFERENCES [dbo].[Raza] ([raza_id])
GO
ALTER TABLE [dbo].[Mascota] CHECK CONSTRAINT [FK_Mascota_Raza]
GO
ALTER TABLE [dbo].[Mascota]  WITH CHECK ADD  CONSTRAINT [FK_Mascota_Tamaño] FOREIGN KEY([tamaño_id])
REFERENCES [dbo].[Tamaño] ([tamaño_id])
GO
ALTER TABLE [dbo].[Mascota] CHECK CONSTRAINT [FK_Mascota_Tamaño]
GO
ALTER TABLE [dbo].[Multimedia]  WITH CHECK ADD  CONSTRAINT [FK_Multimedia_Mascota] FOREIGN KEY([mascota_id])
REFERENCES [dbo].[Mascota] ([mascota_id])
GO
ALTER TABLE [dbo].[Multimedia] CHECK CONSTRAINT [FK_Multimedia_Mascota]
GO
ALTER TABLE [dbo].[Persona]  WITH CHECK ADD  CONSTRAINT [FK_Persona_Localidad] FOREIGN KEY([localidad_id])
REFERENCES [dbo].[Localidad] ([localidad_id])
GO
ALTER TABLE [dbo].[Persona] CHECK CONSTRAINT [FK_Persona_Localidad]
GO
ALTER TABLE [dbo].[Usuario]  WITH CHECK ADD  CONSTRAINT [FK_Usuario_Persona] FOREIGN KEY([persona_id])
REFERENCES [dbo].[Persona] ([persona_id])
GO
ALTER TABLE [dbo].[Usuario] CHECK CONSTRAINT [FK_Usuario_Persona]
GO
ALTER TABLE [dbo].[Veterinario]  WITH CHECK ADD  CONSTRAINT [FK_Veterinario_Persona] FOREIGN KEY([persona_id])
REFERENCES [dbo].[Persona] ([persona_id])
GO
ALTER TABLE [dbo].[Veterinario] CHECK CONSTRAINT [FK_Veterinario_Persona]
GO
ALTER TABLE [dbo].[VeterinarioLocal]  WITH CHECK ADD  CONSTRAINT [FK_VeterinarioLocal_Local] FOREIGN KEY([local_id])
REFERENCES [dbo].[Local] ([local_id])
GO
ALTER TABLE [dbo].[VeterinarioLocal] CHECK CONSTRAINT [FK_VeterinarioLocal_Local]
GO
ALTER TABLE [dbo].[VeterinarioLocal]  WITH CHECK ADD  CONSTRAINT [FK_VeterinarioLocal_Veterinario] FOREIGN KEY([persona_id])
REFERENCES [dbo].[Veterinario] ([persona_id])
GO
ALTER TABLE [dbo].[VeterinarioLocal] CHECK CONSTRAINT [FK_VeterinarioLocal_Veterinario]
GO
ALTER TABLE [dbo].[Visita]  WITH CHECK ADD  CONSTRAINT [FK_Visita_Mascota] FOREIGN KEY([mascota_id])
REFERENCES [dbo].[Mascota] ([mascota_id])
GO
ALTER TABLE [dbo].[Visita] CHECK CONSTRAINT [FK_Visita_Mascota]
GO
ALTER TABLE [dbo].[Visita]  WITH CHECK ADD  CONSTRAINT [FK_Visita_Veterinario] FOREIGN KEY([persona_id])
REFERENCES [dbo].[Veterinario] ([persona_id])
GO
ALTER TABLE [dbo].[Visita] CHECK CONSTRAINT [FK_Visita_Veterinario]
GO
