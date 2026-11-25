USE [master];
GO

IF EXISTS (SELECT name FROM sys.databases WHERE name = N'BASE')
BEGIN
    ALTER DATABASE [BASE] SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
    DROP DATABASE [BASE];
END
GO

CREATE DATABASE [BASE];
GO

USE [BASE];
GO
/****** Object:  Table [dbo].[ASIGNACION_PERSONAL]    Script Date: 24/11/2026 19:46:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ASIGNACION_PERSONAL](
	[Id_Asignacion] [int] IDENTITY(1,1) NOT NULL,
	[Id_Reserva] [int] NOT NULL,
	[Id_Personal] [int] NOT NULL,
 CONSTRAINT [PK_ASIGNACION_PERSONAL] PRIMARY KEY CLUSTERED 
(
	[Id_Asignacion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[BITACORA]    Script Date: 24/11/2026 19:46:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BITACORA](
	[ID_BITACORA] [int] NOT NULL,
	[FECHA] [datetime] NOT NULL,
	[USUARIO] [varchar](50) NOT NULL,
	[MODULO] [varchar](50) NOT NULL,
	[OPERACION] [varchar](50) NOT NULL,
	[CRITICIDAD] [int] NOT NULL,
 CONSTRAINT [PK_BITACORA] PRIMARY KEY CLUSTERED 
(
	[ID_BITACORA] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CLIENTE]    Script Date: 24/11/2026 19:46:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CLIENTE](
	[Id_Cliente] [int] IDENTITY(1,1) NOT NULL,
	[Nombre_Completo] [varchar](100) NOT NULL,
	[Telefono] [bigint] NOT NULL,
	[Email] [varchar](100) NOT NULL,
	[Dni] [int] NOT NULL,
 CONSTRAINT [PK__CLIENTE__3DD0A8CBF1D4CA81] PRIMARY KEY CLUSTERED 
(
	[Id_Cliente] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CONTROL]    Script Date: 24/11/2026 19:46:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CONTROL](
	[ID_CONTROL] [int] IDENTITY(1,1) NOT NULL,
	[NOMBRE_CONTROL] [varchar](100) NOT NULL,
	[NOMBRE_FORMULARIO] [varchar](100) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID_CONTROL] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DETALLE_OC]    Script Date: 24/11/2026 19:46:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DETALLE_OC](
	[Id_Detalle] [int] IDENTITY(1,1) NOT NULL,
	[Id_OrdenCompra] [int] NOT NULL,
	[Nombre_Insumo] [varchar](100) NOT NULL,
	[Cantidad_Solicitada] [int] NOT NULL,
	[Cantidad_Recibida] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id_Detalle] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DIGITO_VERIFICADOR]    Script Date: 24/11/2026 19:46:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DIGITO_VERIFICADOR](
	[TABLA] [varchar](50) NOT NULL,
	[DVV] [varchar](max) NULL,
 CONSTRAINT [PK_DIGITO_VERIFICADOR] PRIMARY KEY CLUSTERED 
(
	[TABLA] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[FICHA_PRESTADORES]    Script Date: 24/11/2026 19:46:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FICHA_PRESTADORES](
	[Id_Ficha] [int] NOT NULL,
	[Id_Prestador] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id_Ficha] ASC,
	[Id_Prestador] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[FICHA_TECNICA]    Script Date: 24/11/2026 19:46:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FICHA_TECNICA](
	[Id_Ficha] [int] IDENTITY(1,1) NOT NULL,
	[Id_Reserva] [int] NOT NULL,
	[Id_Usuario] [int] NOT NULL,
	[Id_Servicio] [int] NOT NULL,
	[Cantidad_Invitados_Final] [int] NOT NULL,
	[Tipo_Evento] [varchar](50) NOT NULL,
	[Observaciones] [varchar](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id_Ficha] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[HISTORIAL_PRODUCTO]    Script Date: 24/11/2026 19:46:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HISTORIAL_PRODUCTO](
	[Id_Historial] [int] IDENTITY(1,1) NOT NULL,
	[Id_Producto] [int] NOT NULL,
	[Usuario_Accion] [varchar](50) NOT NULL,
	[Fecha_Cambio] [datetime] NOT NULL,
	[Tipo_Accion] [varchar](20) NOT NULL,
	[Nombre] [varchar](100) NOT NULL,
	[Precio] [decimal](18, 2) NOT NULL,
	[Stock] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id_Historial] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[HISTORIAL_USUARIO]    Script Date: 24/11/2026 19:46:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HISTORIAL_USUARIO](
	[id_historial] [int] IDENTITY(1,1) NOT NULL,
	[id_usuario] [int] NULL,
	[usuario] [varchar](50) NULL,
	[contraseña] [varchar](max) NULL,
	[dni] [int] NULL,
	[email] [varchar](100) NULL,
	[estadobloqueado] [bit] NULL,
	[intentosfallidos] [int] NULL,
	[id_idioma] [int] NULL,
	[dvh] [varchar](255) NULL,
	[fecha_cambio] [datetime] NULL,
	[usuario_accion] [varchar](50) NULL,
	[tipo_accion] [varchar](50) NULL,
	[ACTIVO] [bit] NOT NULL,
 CONSTRAINT [PK__HISTORIA__76E6C5024A1ED62D] PRIMARY KEY CLUSTERED 
(
	[id_historial] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[IDIOMA]    Script Date: 24/11/2026 19:46:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[IDIOMA](
	[ID_IDIOMA] [int] IDENTITY(1,1) NOT NULL,
	[NOMBRE] [varchar](50) NOT NULL,
	[ESTADISPONIBLE] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID_IDIOMA] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[INSUMO]    Script Date: 24/11/2026 19:46:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[INSUMO](
	[Id_Insumo] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](100) NOT NULL,
	[Rubro] [varchar](50) NULL,
	[Unidad_Medida] [varchar](30) NOT NULL,
	[Stock_Actual] [decimal](18, 2) NULL,
	[Stock_Minimo] [decimal](18, 2) NULL,
	[Estado] [varchar](20) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id_Insumo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[INVENTARIO]    Script Date: 24/11/2026 19:46:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[INVENTARIO](
	[Id_Insumo] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](100) NOT NULL,
	[Stock_Actual] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id_Insumo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ORDEN_COMPRA]    Script Date: 24/11/2026 19:46:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ORDEN_COMPRA](
	[Id_OrdenCompra] [int] IDENTITY(1,1) NOT NULL,
	[Id_Ficha] [int] NULL,
	[Id_Proveedor] [int] NOT NULL,
	[Fecha_Emision] [datetime] NOT NULL,
	[Estado] [varchar](50) NOT NULL,
	[Motivo_Anulacion] [varchar](250) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id_OrdenCompra] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PARAMETRO_RATIO]    Script Date: 24/11/2026 19:46:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PARAMETRO_RATIO](
	[Id_Ratio] [int] IDENTITY(1,1) NOT NULL,
	[Categoria] [varchar](50) NOT NULL,
	[Cantidad_Invitados_Por_Personal] [int] NOT NULL,
	[Estado] [varchar](20) NOT NULL,
 CONSTRAINT [PK_PARAMETRO_RATIO] PRIMARY KEY CLUSTERED 
(
	[Id_Ratio] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PERMISO]    Script Date: 24/11/2026 19:46:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PERMISO](
	[ID] [int] NOT NULL,
	[NOMBRE] [varchar](100) NOT NULL,
	[ESCOMPUESTO] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PERMISO_PERMISO]    Script Date: 24/11/2026 19:46:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PERMISO_PERMISO](
	[ID_PADRE] [int] NOT NULL,
	[ID_HIJO] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID_PADRE] ASC,
	[ID_HIJO] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PERSONAL]    Script Date: 24/11/2026 19:46:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PERSONAL](
	[Id_Personal] [int] IDENTITY(1,1) NOT NULL,
	[DNI] [varchar](20) NOT NULL,
	[Nombre] [varchar](100) NOT NULL,
	[Apellido] [varchar](100) NOT NULL,
	[Categoria] [varchar](50) NOT NULL,
	[Telefono] [varchar](50) NULL,
	[Direccion] [varchar](200) NULL,
	[Email] [varchar](100) NULL,
	[Estado] [varchar](20) NOT NULL,
 CONSTRAINT [PK_PERSONAL] PRIMARY KEY CLUSTERED 
(
	[Id_Personal] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PRESTADOR_SERVICIO]    Script Date: 24/11/2026 19:46:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PRESTADOR_SERVICIO](
	[Id_Prestador] [int] IDENTITY(1,1) NOT NULL,
	[Rubro] [varchar](50) NOT NULL,
	[Nombre_Fantasia] [varchar](100) NOT NULL,
	[Estado] [varchar](20) NOT NULL,
	[Precio_Servicio] [decimal](18, 2) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id_Prestador] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PRESUPUESTO]    Script Date: 24/11/2026 19:46:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PRESUPUESTO](
	[Id_Presupuesto] [int] IDENTITY(1,1) NOT NULL,
	[Id_Cliente] [int] NOT NULL,
	[Id_Usuario] [int] NOT NULL,
	[Cantidad_Invitados_Estimada] [int] NOT NULL,
	[Tipo_Evento] [varchar](50) NOT NULL,
	[Subtotal] [decimal](18, 2) NOT NULL,
	[Estado] [varchar](20) NOT NULL,
	[Fecha_Evento] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id_Presupuesto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PRODUCTO]    Script Date: 24/11/2026 19:46:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PRODUCTO](
	[ID_PRODUCTO] [int] NOT NULL,
	[NOMBRE] [varchar](100) NOT NULL,
	[PRECIO] [decimal](18, 2) NOT NULL,
	[STOCK] [int] NOT NULL,
	[ACTIVO] [bit] NOT NULL,
 CONSTRAINT [PK_PRODUCTO] PRIMARY KEY CLUSTERED 
(
	[ID_PRODUCTO] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PROVEEDOR_INSUMO]    Script Date: 24/11/2026 19:46:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PROVEEDOR_INSUMO](
	[Id_Proveedor] [int] IDENTITY(1,1) NOT NULL,
	[Razon_Social] [varchar](100) NOT NULL,
	[CUIT] [varchar](20) NOT NULL,
	[Rubro] [varchar](50) NULL,
	[Telefono] [varchar](30) NULL,
	[Direccion] [varchar](100) NULL,
	[Email] [varchar](100) NULL,
	[Estado] [varchar](20) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id_Proveedor] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RECETARIO]    Script Date: 24/11/2026 19:46:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RECETARIO](
	[Id_Detalle_Recetario] [int] IDENTITY(1,1) NOT NULL,
	[Id_Servicio] [int] NOT NULL,
	[Id_Insumo] [int] NOT NULL,
	[Cantidad_Por_Persona] [decimal](18, 4) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id_Detalle_Recetario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RESERVA]    Script Date: 24/11/2026 19:46:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RESERVA](
	[Id_Reserva] [int] IDENTITY(1,1) NOT NULL,
	[Id_Cliente] [int] NOT NULL,
	[Id_Usuario] [int] NOT NULL,
	[Id_Presupuesto] [int] NOT NULL,
	[Fecha_Evento] [datetime] NOT NULL,
	[Monto_Senia] [decimal](18, 2) NOT NULL,
	[Estado] [varchar](20) NOT NULL,
	[Costo_Total_Real] [decimal](18, 2) NULL,
	[Saldo_Pendiente] [decimal](18, 2) NULL,
	[Evaluacion_Personal] [int] NULL,
	[Observaciones_Personal] [varchar](500) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id_Reserva] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SERVICIO_CATERING]    Script Date: 24/11/2026 19:46:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SERVICIO_CATERING](
	[Id_Servicio] [int] IDENTITY(1,1) NOT NULL,
	[Tipo_Menu] [varchar](100) NOT NULL,
	[Precio_Por_Persona] [decimal](18, 2) NOT NULL,
	[Nombre_Servicio] [varchar](100) NULL,
	[Descripcion] [varchar](255) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id_Servicio] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TARIFA_EVENTO]    Script Date: 24/11/2026 19:46:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TARIFA_EVENTO](
	[Id_Tarifa] [int] IDENTITY(1,1) NOT NULL,
	[Tipo_Evento] [varchar](50) NOT NULL,
	[TarifaBase] [decimal](18, 2) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id_Tarifa] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TRADUCCION]    Script Date: 24/11/2026 19:46:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TRADUCCION](
	[ID_TRADUCCION] [int] IDENTITY(1,1) NOT NULL,
	[ID_CONTROL] [int] NOT NULL,
	[ID_IDIOMA] [int] NOT NULL,
	[TEXTO_TRADUCIDO] [nvarchar](255) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID_TRADUCCION] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[USUARIO]    Script Date: 24/11/2026 19:46:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[USUARIO](
	[ID] [int] NOT NULL,
	[USUARIO] [varchar](50) NOT NULL,
	[CONTRASEÑA] [varchar](max) NOT NULL,
	[ESTADOBLOQUEADO] [bit] NOT NULL,
	[INTENTOSFALLIDOS] [int] NOT NULL,
	[DNI] [int] NOT NULL,
	[EMAIL] [varchar](50) NOT NULL,
	[ID_IDIOMA] [int] NULL,
	[DVH] [varchar](max) NULL,
	[ACTIVO] [bit] NOT NULL,
 CONSTRAINT [PK_USUARIO] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[USUARIO_PERMISO]    Script Date: 24/11/2026 19:46:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[USUARIO_PERMISO](
	[ID_USUARIO] [int] NOT NULL,
	[ID_PERMISO] [int] NOT NULL,
 CONSTRAINT [PK_USUARIO_PERMISO] PRIMARY KEY CLUSTERED 
(
	[ID_USUARIO] ASC,
	[ID_PERMISO] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[ASIGNACION_PERSONAL] ON 

INSERT [dbo].[ASIGNACION_PERSONAL] ([Id_Asignacion], [Id_Reserva], [Id_Personal]) VALUES (7, 10, 1)
INSERT [dbo].[ASIGNACION_PERSONAL] ([Id_Asignacion], [Id_Reserva], [Id_Personal]) VALUES (8, 10, 2)
INSERT [dbo].[ASIGNACION_PERSONAL] ([Id_Asignacion], [Id_Reserva], [Id_Personal]) VALUES (9, 10, 18)
INSERT [dbo].[ASIGNACION_PERSONAL] ([Id_Asignacion], [Id_Reserva], [Id_Personal]) VALUES (10, 10, 11)
INSERT [dbo].[ASIGNACION_PERSONAL] ([Id_Asignacion], [Id_Reserva], [Id_Personal]) VALUES (11, 10, 21)
INSERT [dbo].[ASIGNACION_PERSONAL] ([Id_Asignacion], [Id_Reserva], [Id_Personal]) VALUES (12, 11, 3)
INSERT [dbo].[ASIGNACION_PERSONAL] ([Id_Asignacion], [Id_Reserva], [Id_Personal]) VALUES (13, 11, 4)
INSERT [dbo].[ASIGNACION_PERSONAL] ([Id_Asignacion], [Id_Reserva], [Id_Personal]) VALUES (14, 11, 19)
INSERT [dbo].[ASIGNACION_PERSONAL] ([Id_Asignacion], [Id_Reserva], [Id_Personal]) VALUES (15, 11, 12)
INSERT [dbo].[ASIGNACION_PERSONAL] ([Id_Asignacion], [Id_Reserva], [Id_Personal]) VALUES (16, 11, 15)
INSERT [dbo].[ASIGNACION_PERSONAL] ([Id_Asignacion], [Id_Reserva], [Id_Personal]) VALUES (17, 13, 1)
INSERT [dbo].[ASIGNACION_PERSONAL] ([Id_Asignacion], [Id_Reserva], [Id_Personal]) VALUES (18, 13, 2)
INSERT [dbo].[ASIGNACION_PERSONAL] ([Id_Asignacion], [Id_Reserva], [Id_Personal]) VALUES (19, 13, 18)
INSERT [dbo].[ASIGNACION_PERSONAL] ([Id_Asignacion], [Id_Reserva], [Id_Personal]) VALUES (20, 13, 21)
INSERT [dbo].[ASIGNACION_PERSONAL] ([Id_Asignacion], [Id_Reserva], [Id_Personal]) VALUES (21, 14, 3)
INSERT [dbo].[ASIGNACION_PERSONAL] ([Id_Asignacion], [Id_Reserva], [Id_Personal]) VALUES (22, 14, 19)
INSERT [dbo].[ASIGNACION_PERSONAL] ([Id_Asignacion], [Id_Reserva], [Id_Personal]) VALUES (23, 14, 20)
INSERT [dbo].[ASIGNACION_PERSONAL] ([Id_Asignacion], [Id_Reserva], [Id_Personal]) VALUES (24, 15, 1)
INSERT [dbo].[ASIGNACION_PERSONAL] ([Id_Asignacion], [Id_Reserva], [Id_Personal]) VALUES (25, 15, 2)
INSERT [dbo].[ASIGNACION_PERSONAL] ([Id_Asignacion], [Id_Reserva], [Id_Personal]) VALUES (26, 15, 3)
INSERT [dbo].[ASIGNACION_PERSONAL] ([Id_Asignacion], [Id_Reserva], [Id_Personal]) VALUES (27, 15, 18)
INSERT [dbo].[ASIGNACION_PERSONAL] ([Id_Asignacion], [Id_Reserva], [Id_Personal]) VALUES (28, 15, 21)
INSERT [dbo].[ASIGNACION_PERSONAL] ([Id_Asignacion], [Id_Reserva], [Id_Personal]) VALUES (29, 16, 4)
INSERT [dbo].[ASIGNACION_PERSONAL] ([Id_Asignacion], [Id_Reserva], [Id_Personal]) VALUES (30, 16, 19)
INSERT [dbo].[ASIGNACION_PERSONAL] ([Id_Asignacion], [Id_Reserva], [Id_Personal]) VALUES (31, 17, 1)
INSERT [dbo].[ASIGNACION_PERSONAL] ([Id_Asignacion], [Id_Reserva], [Id_Personal]) VALUES (32, 17, 20)
INSERT [dbo].[ASIGNACION_PERSONAL] ([Id_Asignacion], [Id_Reserva], [Id_Personal]) VALUES (33, 18, 2)
INSERT [dbo].[ASIGNACION_PERSONAL] ([Id_Asignacion], [Id_Reserva], [Id_Personal]) VALUES (34, 18, 18)
INSERT [dbo].[ASIGNACION_PERSONAL] ([Id_Asignacion], [Id_Reserva], [Id_Personal]) VALUES (35, 18, 21)
INSERT [dbo].[ASIGNACION_PERSONAL] ([Id_Asignacion], [Id_Reserva], [Id_Personal]) VALUES (36, 19, 1)
INSERT [dbo].[ASIGNACION_PERSONAL] ([Id_Asignacion], [Id_Reserva], [Id_Personal]) VALUES (37, 19, 18)
INSERT [dbo].[ASIGNACION_PERSONAL] ([Id_Asignacion], [Id_Reserva], [Id_Personal]) VALUES (38, 20, 2)
INSERT [dbo].[ASIGNACION_PERSONAL] ([Id_Asignacion], [Id_Reserva], [Id_Personal]) VALUES (39, 20, 19)
INSERT [dbo].[ASIGNACION_PERSONAL] ([Id_Asignacion], [Id_Reserva], [Id_Personal]) VALUES (40, 20, 21)
INSERT [dbo].[ASIGNACION_PERSONAL] ([Id_Asignacion], [Id_Reserva], [Id_Personal]) VALUES (41, 21, 3)
INSERT [dbo].[ASIGNACION_PERSONAL] ([Id_Asignacion], [Id_Reserva], [Id_Personal]) VALUES (42, 21, 4)
INSERT [dbo].[ASIGNACION_PERSONAL] ([Id_Asignacion], [Id_Reserva], [Id_Personal]) VALUES (43, 21, 20)
INSERT [dbo].[ASIGNACION_PERSONAL] ([Id_Asignacion], [Id_Reserva], [Id_Personal]) VALUES (44, 22, 1)
INSERT [dbo].[ASIGNACION_PERSONAL] ([Id_Asignacion], [Id_Reserva], [Id_Personal]) VALUES (45, 23, 2)
INSERT [dbo].[ASIGNACION_PERSONAL] ([Id_Asignacion], [Id_Reserva], [Id_Personal]) VALUES (46, 23, 18)
INSERT [dbo].[ASIGNACION_PERSONAL] ([Id_Asignacion], [Id_Reserva], [Id_Personal]) VALUES (47, 23, 21)
INSERT [dbo].[ASIGNACION_PERSONAL] ([Id_Asignacion], [Id_Reserva], [Id_Personal]) VALUES (48, 24, 3)
INSERT [dbo].[ASIGNACION_PERSONAL] ([Id_Asignacion], [Id_Reserva], [Id_Personal]) VALUES (49, 25, 19)
INSERT [dbo].[ASIGNACION_PERSONAL] ([Id_Asignacion], [Id_Reserva], [Id_Personal]) VALUES (50, 26, 4)
INSERT [dbo].[ASIGNACION_PERSONAL] ([Id_Asignacion], [Id_Reserva], [Id_Personal]) VALUES (51, 27, 1)
INSERT [dbo].[ASIGNACION_PERSONAL] ([Id_Asignacion], [Id_Reserva], [Id_Personal]) VALUES (52, 28, 2)
INSERT [dbo].[ASIGNACION_PERSONAL] ([Id_Asignacion], [Id_Reserva], [Id_Personal]) VALUES (53, 28, 18)
INSERT [dbo].[ASIGNACION_PERSONAL] ([Id_Asignacion], [Id_Reserva], [Id_Personal]) VALUES (54, 28, 21)
INSERT [dbo].[ASIGNACION_PERSONAL] ([Id_Asignacion], [Id_Reserva], [Id_Personal]) VALUES (55, 29, 1)
INSERT [dbo].[ASIGNACION_PERSONAL] ([Id_Asignacion], [Id_Reserva], [Id_Personal]) VALUES (56, 30, 20)
INSERT [dbo].[ASIGNACION_PERSONAL] ([Id_Asignacion], [Id_Reserva], [Id_Personal]) VALUES (57, 31, 2)
INSERT [dbo].[ASIGNACION_PERSONAL] ([Id_Asignacion], [Id_Reserva], [Id_Personal]) VALUES (58, 31, 18)
INSERT [dbo].[ASIGNACION_PERSONAL] ([Id_Asignacion], [Id_Reserva], [Id_Personal]) VALUES (59, 32, 3)
INSERT [dbo].[ASIGNACION_PERSONAL] ([Id_Asignacion], [Id_Reserva], [Id_Personal]) VALUES (60, 33, 21)
INSERT [dbo].[ASIGNACION_PERSONAL] ([Id_Asignacion], [Id_Reserva], [Id_Personal]) VALUES (61, 34, 19)
INSERT [dbo].[ASIGNACION_PERSONAL] ([Id_Asignacion], [Id_Reserva], [Id_Personal]) VALUES (62, 35, 4)
INSERT [dbo].[ASIGNACION_PERSONAL] ([Id_Asignacion], [Id_Reserva], [Id_Personal]) VALUES (63, 36, 1)
INSERT [dbo].[ASIGNACION_PERSONAL] ([Id_Asignacion], [Id_Reserva], [Id_Personal]) VALUES (64, 37, 18)
INSERT [dbo].[ASIGNACION_PERSONAL] ([Id_Asignacion], [Id_Reserva], [Id_Personal]) VALUES (65, 38, 2)
INSERT [dbo].[ASIGNACION_PERSONAL] ([Id_Asignacion], [Id_Reserva], [Id_Personal]) VALUES (66, 38, 21)
INSERT [dbo].[ASIGNACION_PERSONAL] ([Id_Asignacion], [Id_Reserva], [Id_Personal]) VALUES (67, 39, 1)
INSERT [dbo].[ASIGNACION_PERSONAL] ([Id_Asignacion], [Id_Reserva], [Id_Personal]) VALUES (68, 40, 18)
INSERT [dbo].[ASIGNACION_PERSONAL] ([Id_Asignacion], [Id_Reserva], [Id_Personal]) VALUES (69, 41, 2)
INSERT [dbo].[ASIGNACION_PERSONAL] ([Id_Asignacion], [Id_Reserva], [Id_Personal]) VALUES (70, 41, 20)
INSERT [dbo].[ASIGNACION_PERSONAL] ([Id_Asignacion], [Id_Reserva], [Id_Personal]) VALUES (71, 42, 3)
INSERT [dbo].[ASIGNACION_PERSONAL] ([Id_Asignacion], [Id_Reserva], [Id_Personal]) VALUES (72, 43, 4)
INSERT [dbo].[ASIGNACION_PERSONAL] ([Id_Asignacion], [Id_Reserva], [Id_Personal]) VALUES (73, 43, 21)
INSERT [dbo].[ASIGNACION_PERSONAL] ([Id_Asignacion], [Id_Reserva], [Id_Personal]) VALUES (74, 45, 14)
INSERT [dbo].[ASIGNACION_PERSONAL] ([Id_Asignacion], [Id_Reserva], [Id_Personal]) VALUES (75, 45, 13)
INSERT [dbo].[ASIGNACION_PERSONAL] ([Id_Asignacion], [Id_Reserva], [Id_Personal]) VALUES (76, 45, 20)
INSERT [dbo].[ASIGNACION_PERSONAL] ([Id_Asignacion], [Id_Reserva], [Id_Personal]) VALUES (77, 45, 12)
INSERT [dbo].[ASIGNACION_PERSONAL] ([Id_Asignacion], [Id_Reserva], [Id_Personal]) VALUES (78, 45, 17)
INSERT [dbo].[ASIGNACION_PERSONAL] ([Id_Asignacion], [Id_Reserva], [Id_Personal]) VALUES (79, 45, 10)
INSERT [dbo].[ASIGNACION_PERSONAL] ([Id_Asignacion], [Id_Reserva], [Id_Personal]) VALUES (80, 45, 9)
INSERT [dbo].[ASIGNACION_PERSONAL] ([Id_Asignacion], [Id_Reserva], [Id_Personal]) VALUES (81, 45, 4)
INSERT [dbo].[ASIGNACION_PERSONAL] ([Id_Asignacion], [Id_Reserva], [Id_Personal]) VALUES (82, 45, 2)
INSERT [dbo].[ASIGNACION_PERSONAL] ([Id_Asignacion], [Id_Reserva], [Id_Personal]) VALUES (83, 45, 5)
INSERT [dbo].[ASIGNACION_PERSONAL] ([Id_Asignacion], [Id_Reserva], [Id_Personal]) VALUES (84, 45, 6)
INSERT [dbo].[ASIGNACION_PERSONAL] ([Id_Asignacion], [Id_Reserva], [Id_Personal]) VALUES (85, 45, 18)
INSERT [dbo].[ASIGNACION_PERSONAL] ([Id_Asignacion], [Id_Reserva], [Id_Personal]) VALUES (86, 45, 1)
INSERT [dbo].[ASIGNACION_PERSONAL] ([Id_Asignacion], [Id_Reserva], [Id_Personal]) VALUES (87, 45, 19)
INSERT [dbo].[ASIGNACION_PERSONAL] ([Id_Asignacion], [Id_Reserva], [Id_Personal]) VALUES (88, 45, 3)
INSERT [dbo].[ASIGNACION_PERSONAL] ([Id_Asignacion], [Id_Reserva], [Id_Personal]) VALUES (89, 45, 15)
INSERT [dbo].[ASIGNACION_PERSONAL] ([Id_Asignacion], [Id_Reserva], [Id_Personal]) VALUES (90, 45, 16)
INSERT [dbo].[ASIGNACION_PERSONAL] ([Id_Asignacion], [Id_Reserva], [Id_Personal]) VALUES (91, 53, 21)
INSERT [dbo].[ASIGNACION_PERSONAL] ([Id_Asignacion], [Id_Reserva], [Id_Personal]) VALUES (92, 54, 1)
INSERT [dbo].[ASIGNACION_PERSONAL] ([Id_Asignacion], [Id_Reserva], [Id_Personal]) VALUES (93, 54, 18)
INSERT [dbo].[ASIGNACION_PERSONAL] ([Id_Asignacion], [Id_Reserva], [Id_Personal]) VALUES (94, 55, 1)
INSERT [dbo].[ASIGNACION_PERSONAL] ([Id_Asignacion], [Id_Reserva], [Id_Personal]) VALUES (95, 55, 18)
INSERT [dbo].[ASIGNACION_PERSONAL] ([Id_Asignacion], [Id_Reserva], [Id_Personal]) VALUES (96, 56, 20)
INSERT [dbo].[ASIGNACION_PERSONAL] ([Id_Asignacion], [Id_Reserva], [Id_Personal]) VALUES (97, 57, 2)
INSERT [dbo].[ASIGNACION_PERSONAL] ([Id_Asignacion], [Id_Reserva], [Id_Personal]) VALUES (98, 57, 3)
INSERT [dbo].[ASIGNACION_PERSONAL] ([Id_Asignacion], [Id_Reserva], [Id_Personal]) VALUES (99, 57, 21)
INSERT [dbo].[ASIGNACION_PERSONAL] ([Id_Asignacion], [Id_Reserva], [Id_Personal]) VALUES (108, 47, 14)
INSERT [dbo].[ASIGNACION_PERSONAL] ([Id_Asignacion], [Id_Reserva], [Id_Personal]) VALUES (109, 47, 13)
INSERT [dbo].[ASIGNACION_PERSONAL] ([Id_Asignacion], [Id_Reserva], [Id_Personal]) VALUES (110, 47, 21)
INSERT [dbo].[ASIGNACION_PERSONAL] ([Id_Asignacion], [Id_Reserva], [Id_Personal]) VALUES (111, 47, 10)
INSERT [dbo].[ASIGNACION_PERSONAL] ([Id_Asignacion], [Id_Reserva], [Id_Personal]) VALUES (112, 47, 9)
INSERT [dbo].[ASIGNACION_PERSONAL] ([Id_Asignacion], [Id_Reserva], [Id_Personal]) VALUES (113, 47, 4)
GO
INSERT [dbo].[ASIGNACION_PERSONAL] ([Id_Asignacion], [Id_Reserva], [Id_Personal]) VALUES (114, 47, 2)
INSERT [dbo].[ASIGNACION_PERSONAL] ([Id_Asignacion], [Id_Reserva], [Id_Personal]) VALUES (115, 47, 5)
INSERT [dbo].[ASIGNACION_PERSONAL] ([Id_Asignacion], [Id_Reserva], [Id_Personal]) VALUES (116, 47, 6)
INSERT [dbo].[ASIGNACION_PERSONAL] ([Id_Asignacion], [Id_Reserva], [Id_Personal]) VALUES (117, 47, 18)
INSERT [dbo].[ASIGNACION_PERSONAL] ([Id_Asignacion], [Id_Reserva], [Id_Personal]) VALUES (118, 47, 15)
INSERT [dbo].[ASIGNACION_PERSONAL] ([Id_Asignacion], [Id_Reserva], [Id_Personal]) VALUES (119, 47, 16)
INSERT [dbo].[ASIGNACION_PERSONAL] ([Id_Asignacion], [Id_Reserva], [Id_Personal]) VALUES (142, 1062, 14)
INSERT [dbo].[ASIGNACION_PERSONAL] ([Id_Asignacion], [Id_Reserva], [Id_Personal]) VALUES (143, 1062, 13)
INSERT [dbo].[ASIGNACION_PERSONAL] ([Id_Asignacion], [Id_Reserva], [Id_Personal]) VALUES (144, 1062, 17)
INSERT [dbo].[ASIGNACION_PERSONAL] ([Id_Asignacion], [Id_Reserva], [Id_Personal]) VALUES (145, 1062, 10)
INSERT [dbo].[ASIGNACION_PERSONAL] ([Id_Asignacion], [Id_Reserva], [Id_Personal]) VALUES (146, 1062, 9)
INSERT [dbo].[ASIGNACION_PERSONAL] ([Id_Asignacion], [Id_Reserva], [Id_Personal]) VALUES (147, 1062, 4)
INSERT [dbo].[ASIGNACION_PERSONAL] ([Id_Asignacion], [Id_Reserva], [Id_Personal]) VALUES (148, 1062, 2)
INSERT [dbo].[ASIGNACION_PERSONAL] ([Id_Asignacion], [Id_Reserva], [Id_Personal]) VALUES (149, 1062, 5)
INSERT [dbo].[ASIGNACION_PERSONAL] ([Id_Asignacion], [Id_Reserva], [Id_Personal]) VALUES (150, 1062, 6)
INSERT [dbo].[ASIGNACION_PERSONAL] ([Id_Asignacion], [Id_Reserva], [Id_Personal]) VALUES (151, 1062, 18)
INSERT [dbo].[ASIGNACION_PERSONAL] ([Id_Asignacion], [Id_Reserva], [Id_Personal]) VALUES (152, 1062, 15)
INSERT [dbo].[ASIGNACION_PERSONAL] ([Id_Asignacion], [Id_Reserva], [Id_Personal]) VALUES (153, 1062, 22)
INSERT [dbo].[ASIGNACION_PERSONAL] ([Id_Asignacion], [Id_Reserva], [Id_Personal]) VALUES (154, 1063, 1)
INSERT [dbo].[ASIGNACION_PERSONAL] ([Id_Asignacion], [Id_Reserva], [Id_Personal]) VALUES (155, 1064, 1)
INSERT [dbo].[ASIGNACION_PERSONAL] ([Id_Asignacion], [Id_Reserva], [Id_Personal]) VALUES (156, 1065, 1)
INSERT [dbo].[ASIGNACION_PERSONAL] ([Id_Asignacion], [Id_Reserva], [Id_Personal]) VALUES (157, 1066, 1)
INSERT [dbo].[ASIGNACION_PERSONAL] ([Id_Asignacion], [Id_Reserva], [Id_Personal]) VALUES (158, 1067, 1)
INSERT [dbo].[ASIGNACION_PERSONAL] ([Id_Asignacion], [Id_Reserva], [Id_Personal]) VALUES (159, 1068, 1)
INSERT [dbo].[ASIGNACION_PERSONAL] ([Id_Asignacion], [Id_Reserva], [Id_Personal]) VALUES (160, 1069, 1)
INSERT [dbo].[ASIGNACION_PERSONAL] ([Id_Asignacion], [Id_Reserva], [Id_Personal]) VALUES (161, 1070, 1)
INSERT [dbo].[ASIGNACION_PERSONAL] ([Id_Asignacion], [Id_Reserva], [Id_Personal]) VALUES (162, 1071, 1)
INSERT [dbo].[ASIGNACION_PERSONAL] ([Id_Asignacion], [Id_Reserva], [Id_Personal]) VALUES (163, 1072, 1)
INSERT [dbo].[ASIGNACION_PERSONAL] ([Id_Asignacion], [Id_Reserva], [Id_Personal]) VALUES (164, 1073, 1)
INSERT [dbo].[ASIGNACION_PERSONAL] ([Id_Asignacion], [Id_Reserva], [Id_Personal]) VALUES (165, 1074, 1)
INSERT [dbo].[ASIGNACION_PERSONAL] ([Id_Asignacion], [Id_Reserva], [Id_Personal]) VALUES (166, 1075, 1)
INSERT [dbo].[ASIGNACION_PERSONAL] ([Id_Asignacion], [Id_Reserva], [Id_Personal]) VALUES (167, 1076, 1)
INSERT [dbo].[ASIGNACION_PERSONAL] ([Id_Asignacion], [Id_Reserva], [Id_Personal]) VALUES (168, 1077, 1)
INSERT [dbo].[ASIGNACION_PERSONAL] ([Id_Asignacion], [Id_Reserva], [Id_Personal]) VALUES (169, 1078, 1)
INSERT [dbo].[ASIGNACION_PERSONAL] ([Id_Asignacion], [Id_Reserva], [Id_Personal]) VALUES (170, 1079, 1)
INSERT [dbo].[ASIGNACION_PERSONAL] ([Id_Asignacion], [Id_Reserva], [Id_Personal]) VALUES (171, 1080, 1)
INSERT [dbo].[ASIGNACION_PERSONAL] ([Id_Asignacion], [Id_Reserva], [Id_Personal]) VALUES (172, 1081, 1)
INSERT [dbo].[ASIGNACION_PERSONAL] ([Id_Asignacion], [Id_Reserva], [Id_Personal]) VALUES (173, 1082, 1)
INSERT [dbo].[ASIGNACION_PERSONAL] ([Id_Asignacion], [Id_Reserva], [Id_Personal]) VALUES (174, 1083, 1)
INSERT [dbo].[ASIGNACION_PERSONAL] ([Id_Asignacion], [Id_Reserva], [Id_Personal]) VALUES (175, 1084, 1)
INSERT [dbo].[ASIGNACION_PERSONAL] ([Id_Asignacion], [Id_Reserva], [Id_Personal]) VALUES (176, 1085, 1)
INSERT [dbo].[ASIGNACION_PERSONAL] ([Id_Asignacion], [Id_Reserva], [Id_Personal]) VALUES (177, 1086, 1)
INSERT [dbo].[ASIGNACION_PERSONAL] ([Id_Asignacion], [Id_Reserva], [Id_Personal]) VALUES (178, 1087, 1)
INSERT [dbo].[ASIGNACION_PERSONAL] ([Id_Asignacion], [Id_Reserva], [Id_Personal]) VALUES (179, 1088, 1)
INSERT [dbo].[ASIGNACION_PERSONAL] ([Id_Asignacion], [Id_Reserva], [Id_Personal]) VALUES (180, 1089, 1)
INSERT [dbo].[ASIGNACION_PERSONAL] ([Id_Asignacion], [Id_Reserva], [Id_Personal]) VALUES (181, 1090, 1)
INSERT [dbo].[ASIGNACION_PERSONAL] ([Id_Asignacion], [Id_Reserva], [Id_Personal]) VALUES (182, 1091, 1)
INSERT [dbo].[ASIGNACION_PERSONAL] ([Id_Asignacion], [Id_Reserva], [Id_Personal]) VALUES (183, 1092, 1)
INSERT [dbo].[ASIGNACION_PERSONAL] ([Id_Asignacion], [Id_Reserva], [Id_Personal]) VALUES (184, 1093, 1)
INSERT [dbo].[ASIGNACION_PERSONAL] ([Id_Asignacion], [Id_Reserva], [Id_Personal]) VALUES (185, 1094, 1)
INSERT [dbo].[ASIGNACION_PERSONAL] ([Id_Asignacion], [Id_Reserva], [Id_Personal]) VALUES (186, 1095, 1)
INSERT [dbo].[ASIGNACION_PERSONAL] ([Id_Asignacion], [Id_Reserva], [Id_Personal]) VALUES (187, 1096, 1)
INSERT [dbo].[ASIGNACION_PERSONAL] ([Id_Asignacion], [Id_Reserva], [Id_Personal]) VALUES (188, 1097, 1)
INSERT [dbo].[ASIGNACION_PERSONAL] ([Id_Asignacion], [Id_Reserva], [Id_Personal]) VALUES (189, 1098, 1)
INSERT [dbo].[ASIGNACION_PERSONAL] ([Id_Asignacion], [Id_Reserva], [Id_Personal]) VALUES (190, 1099, 1)
INSERT [dbo].[ASIGNACION_PERSONAL] ([Id_Asignacion], [Id_Reserva], [Id_Personal]) VALUES (191, 1100, 1)
INSERT [dbo].[ASIGNACION_PERSONAL] ([Id_Asignacion], [Id_Reserva], [Id_Personal]) VALUES (192, 1101, 1)
INSERT [dbo].[ASIGNACION_PERSONAL] ([Id_Asignacion], [Id_Reserva], [Id_Personal]) VALUES (193, 1102, 1)
INSERT [dbo].[ASIGNACION_PERSONAL] ([Id_Asignacion], [Id_Reserva], [Id_Personal]) VALUES (194, 1103, 1)
INSERT [dbo].[ASIGNACION_PERSONAL] ([Id_Asignacion], [Id_Reserva], [Id_Personal]) VALUES (195, 1104, 1)
INSERT [dbo].[ASIGNACION_PERSONAL] ([Id_Asignacion], [Id_Reserva], [Id_Personal]) VALUES (196, 1105, 1)
INSERT [dbo].[ASIGNACION_PERSONAL] ([Id_Asignacion], [Id_Reserva], [Id_Personal]) VALUES (197, 1106, 1)
INSERT [dbo].[ASIGNACION_PERSONAL] ([Id_Asignacion], [Id_Reserva], [Id_Personal]) VALUES (198, 1107, 1)
INSERT [dbo].[ASIGNACION_PERSONAL] ([Id_Asignacion], [Id_Reserva], [Id_Personal]) VALUES (199, 1108, 1)
INSERT [dbo].[ASIGNACION_PERSONAL] ([Id_Asignacion], [Id_Reserva], [Id_Personal]) VALUES (200, 1109, 1)
INSERT [dbo].[ASIGNACION_PERSONAL] ([Id_Asignacion], [Id_Reserva], [Id_Personal]) VALUES (201, 1110, 1)
INSERT [dbo].[ASIGNACION_PERSONAL] ([Id_Asignacion], [Id_Reserva], [Id_Personal]) VALUES (202, 1111, 1)
INSERT [dbo].[ASIGNACION_PERSONAL] ([Id_Asignacion], [Id_Reserva], [Id_Personal]) VALUES (203, 1112, 1)
INSERT [dbo].[ASIGNACION_PERSONAL] ([Id_Asignacion], [Id_Reserva], [Id_Personal]) VALUES (204, 1113, 1)
INSERT [dbo].[ASIGNACION_PERSONAL] ([Id_Asignacion], [Id_Reserva], [Id_Personal]) VALUES (205, 1114, 1)
INSERT [dbo].[ASIGNACION_PERSONAL] ([Id_Asignacion], [Id_Reserva], [Id_Personal]) VALUES (206, 1115, 1)
INSERT [dbo].[ASIGNACION_PERSONAL] ([Id_Asignacion], [Id_Reserva], [Id_Personal]) VALUES (207, 1116, 1)
SET IDENTITY_INSERT [dbo].[ASIGNACION_PERSONAL] OFF
GO
INSERT [dbo].[BITACORA] ([ID_BITACORA], [FECHA], [USUARIO], [MODULO], [OPERACION], [CRITICIDAD]) VALUES (1, CAST(N'2026-07-10T20:18:06.773' AS DateTime), N'tp', N'Seguridad', N'Inicio de sesión exitoso', 1)
INSERT [dbo].[BITACORA] ([ID_BITACORA], [FECHA], [USUARIO], [MODULO], [OPERACION], [CRITICIDAD]) VALUES (2, CAST(N'2026-07-10T20:18:28.213' AS DateTime), N'tp', N'Seguridad', N'Cierre de sesión automatico', 1)
INSERT [dbo].[BITACORA] ([ID_BITACORA], [FECHA], [USUARIO], [MODULO], [OPERACION], [CRITICIDAD]) VALUES (3, CAST(N'2026-07-11T18:17:40.827' AS DateTime), N'tp', N'Seguridad', N'Inicio de sesión exitoso', 1)
INSERT [dbo].[BITACORA] ([ID_BITACORA], [FECHA], [USUARIO], [MODULO], [OPERACION], [CRITICIDAD]) VALUES (4, CAST(N'2026-07-11T18:18:12.690' AS DateTime), N'tp', N'Inventario', N'Se dio de alta el producto yerba', 2)
INSERT [dbo].[BITACORA] ([ID_BITACORA], [FECHA], [USUARIO], [MODULO], [OPERACION], [CRITICIDAD]) VALUES (5, CAST(N'2026-07-11T18:19:23.653' AS DateTime), N'tp', N'Seguridad', N'Cierre de sesión automatico', 1)
INSERT [dbo].[BITACORA] ([ID_BITACORA], [FECHA], [USUARIO], [MODULO], [OPERACION], [CRITICIDAD]) VALUES (6, CAST(N'2026-07-11T18:23:56.947' AS DateTime), N'tp', N'Seguridad', N'Inicio de sesión exitoso', 1)
INSERT [dbo].[BITACORA] ([ID_BITACORA], [FECHA], [USUARIO], [MODULO], [OPERACION], [CRITICIDAD]) VALUES (7, CAST(N'2026-07-11T18:24:12.307' AS DateTime), N'tp', N'Seguridad', N'Cierre de sesión automatico', 1)
INSERT [dbo].[BITACORA] ([ID_BITACORA], [FECHA], [USUARIO], [MODULO], [OPERACION], [CRITICIDAD]) VALUES (8, CAST(N'2026-07-11T18:26:40.567' AS DateTime), N'tp', N'Seguridad', N'Inicio de sesión exitoso', 1)
INSERT [dbo].[BITACORA] ([ID_BITACORA], [FECHA], [USUARIO], [MODULO], [OPERACION], [CRITICIDAD]) VALUES (9, CAST(N'2026-07-11T18:26:55.057' AS DateTime), N'tp', N'Inventario', N'Se dio de alta el producto coca', 2)
INSERT [dbo].[BITACORA] ([ID_BITACORA], [FECHA], [USUARIO], [MODULO], [OPERACION], [CRITICIDAD]) VALUES (10, CAST(N'2026-07-11T18:27:28.790' AS DateTime), N'tp', N'Seguridad', N'Cierre de sesión automatico', 1)
INSERT [dbo].[BITACORA] ([ID_BITACORA], [FECHA], [USUARIO], [MODULO], [OPERACION], [CRITICIDAD]) VALUES (11, CAST(N'2026-07-11T18:31:26.877' AS DateTime), N'tp', N'Seguridad', N'Inicio de sesión exitoso', 1)
INSERT [dbo].[BITACORA] ([ID_BITACORA], [FECHA], [USUARIO], [MODULO], [OPERACION], [CRITICIDAD]) VALUES (12, CAST(N'2026-07-11T18:31:52.467' AS DateTime), N'tp', N'Inventario', N'Se dio de alta el producto sprite', 2)
INSERT [dbo].[BITACORA] ([ID_BITACORA], [FECHA], [USUARIO], [MODULO], [OPERACION], [CRITICIDAD]) VALUES (13, CAST(N'2026-07-11T18:35:20.987' AS DateTime), N'tp', N'Seguridad', N'Inicio de sesión exitoso', 1)
INSERT [dbo].[BITACORA] ([ID_BITACORA], [FECHA], [USUARIO], [MODULO], [OPERACION], [CRITICIDAD]) VALUES (14, CAST(N'2026-07-11T18:35:30.080' AS DateTime), N'tp', N'Inventario', N'Se dio de baja el producto coca', 2)
INSERT [dbo].[BITACORA] ([ID_BITACORA], [FECHA], [USUARIO], [MODULO], [OPERACION], [CRITICIDAD]) VALUES (15, CAST(N'2026-07-11T18:37:17.650' AS DateTime), N'tp', N'Inventario', N'Se reactivó el producto: coca', 3)
INSERT [dbo].[BITACORA] ([ID_BITACORA], [FECHA], [USUARIO], [MODULO], [OPERACION], [CRITICIDAD]) VALUES (16, CAST(N'2026-07-11T18:37:40.800' AS DateTime), N'tp', N'Inventario', N'Se dio de baja el producto coca', 2)
INSERT [dbo].[BITACORA] ([ID_BITACORA], [FECHA], [USUARIO], [MODULO], [OPERACION], [CRITICIDAD]) VALUES (17, CAST(N'2026-07-11T18:43:02.643' AS DateTime), N'tp', N'Inventario', N'Se reactivó el producto: coca', 3)
INSERT [dbo].[BITACORA] ([ID_BITACORA], [FECHA], [USUARIO], [MODULO], [OPERACION], [CRITICIDAD]) VALUES (18, CAST(N'2026-07-11T19:00:11.777' AS DateTime), N'tp', N'Seguridad', N'Cierre de sesión automatico', 1)
INSERT [dbo].[BITACORA] ([ID_BITACORA], [FECHA], [USUARIO], [MODULO], [OPERACION], [CRITICIDAD]) VALUES (19, CAST(N'2026-07-11T19:16:44.353' AS DateTime), N'tp', N'Seguridad', N'Inicio de sesión exitoso', 1)
INSERT [dbo].[BITACORA] ([ID_BITACORA], [FECHA], [USUARIO], [MODULO], [OPERACION], [CRITICIDAD]) VALUES (20, CAST(N'2026-07-11T19:17:00.723' AS DateTime), N'tp', N'Seguridad', N'Cierre de sesión automatico', 1)
INSERT [dbo].[BITACORA] ([ID_BITACORA], [FECHA], [USUARIO], [MODULO], [OPERACION], [CRITICIDAD]) VALUES (21, CAST(N'2026-07-11T19:35:04.363' AS DateTime), N'tp', N'Seguridad', N'Inicio de sesión exitoso', 1)
INSERT [dbo].[BITACORA] ([ID_BITACORA], [FECHA], [USUARIO], [MODULO], [OPERACION], [CRITICIDAD]) VALUES (22, CAST(N'2026-07-11T19:35:55.293' AS DateTime), N'tp', N'Inventario', N'Se dio de baja el producto coca', 2)
INSERT [dbo].[BITACORA] ([ID_BITACORA], [FECHA], [USUARIO], [MODULO], [OPERACION], [CRITICIDAD]) VALUES (23, CAST(N'2026-07-11T19:36:43.363' AS DateTime), N'tp', N'Seguridad', N'Cierre de sesión automatico', 1)
INSERT [dbo].[BITACORA] ([ID_BITACORA], [FECHA], [USUARIO], [MODULO], [OPERACION], [CRITICIDAD]) VALUES (24, CAST(N'2026-07-11T19:41:12.323' AS DateTime), N'tp', N'Seguridad', N'Inicio de sesión exitoso', 1)
INSERT [dbo].[BITACORA] ([ID_BITACORA], [FECHA], [USUARIO], [MODULO], [OPERACION], [CRITICIDAD]) VALUES (25, CAST(N'2026-07-11T19:41:26.563' AS DateTime), N'tp', N'Inventario', N'Se reactivó el producto: coca', 3)
INSERT [dbo].[BITACORA] ([ID_BITACORA], [FECHA], [USUARIO], [MODULO], [OPERACION], [CRITICIDAD]) VALUES (26, CAST(N'2026-07-11T19:41:36.720' AS DateTime), N'tp', N'Seguridad', N'Cierre de sesión automatico', 1)
INSERT [dbo].[BITACORA] ([ID_BITACORA], [FECHA], [USUARIO], [MODULO], [OPERACION], [CRITICIDAD]) VALUES (27, CAST(N'2026-07-11T19:43:15.447' AS DateTime), N'tp', N'Seguridad', N'Inicio de sesión exitoso', 1)
INSERT [dbo].[BITACORA] ([ID_BITACORA], [FECHA], [USUARIO], [MODULO], [OPERACION], [CRITICIDAD]) VALUES (28, CAST(N'2026-07-11T19:43:25.807' AS DateTime), N'tp', N'Administracion', N'Se reactivó al usuario inactivo', 3)
INSERT [dbo].[BITACORA] ([ID_BITACORA], [FECHA], [USUARIO], [MODULO], [OPERACION], [CRITICIDAD]) VALUES (29, CAST(N'2026-07-11T19:51:52.050' AS DateTime), N'tp', N'Seguridad', N'Cierre de sesión automatico', 1)
INSERT [dbo].[BITACORA] ([ID_BITACORA], [FECHA], [USUARIO], [MODULO], [OPERACION], [CRITICIDAD]) VALUES (30, CAST(N'2026-07-11T19:57:27.630' AS DateTime), N'tp', N'Seguridad', N'Inicio de sesión exitoso', 1)
INSERT [dbo].[BITACORA] ([ID_BITACORA], [FECHA], [USUARIO], [MODULO], [OPERACION], [CRITICIDAD]) VALUES (31, CAST(N'2026-07-11T19:58:10.260' AS DateTime), N'tp', N'Seguridad', N'Cierre de sesión automatico', 1)
INSERT [dbo].[BITACORA] ([ID_BITACORA], [FECHA], [USUARIO], [MODULO], [OPERACION], [CRITICIDAD]) VALUES (32, CAST(N'2026-07-11T19:58:17.810' AS DateTime), N'tp', N'Seguridad', N'Inicio de sesión exitoso', 1)
INSERT [dbo].[BITACORA] ([ID_BITACORA], [FECHA], [USUARIO], [MODULO], [OPERACION], [CRITICIDAD]) VALUES (33, CAST(N'2026-07-11T20:03:14.110' AS DateTime), N'tp', N'Seguridad', N'Inicio de sesión exitoso', 1)
INSERT [dbo].[BITACORA] ([ID_BITACORA], [FECHA], [USUARIO], [MODULO], [OPERACION], [CRITICIDAD]) VALUES (34, CAST(N'2026-07-11T20:04:05.090' AS DateTime), N'tp', N'Seguridad', N'Cierre de sesión automatico', 1)
INSERT [dbo].[BITACORA] ([ID_BITACORA], [FECHA], [USUARIO], [MODULO], [OPERACION], [CRITICIDAD]) VALUES (35, CAST(N'2026-07-11T20:14:53.557' AS DateTime), N'tp', N'Seguridad', N'Inicio de sesión exitoso', 1)
INSERT [dbo].[BITACORA] ([ID_BITACORA], [FECHA], [USUARIO], [MODULO], [OPERACION], [CRITICIDAD]) VALUES (36, CAST(N'2026-07-11T20:15:07.780' AS DateTime), N'tp', N'Seguridad', N'Cierre de sesión automatico', 1)
INSERT [dbo].[BITACORA] ([ID_BITACORA], [FECHA], [USUARIO], [MODULO], [OPERACION], [CRITICIDAD]) VALUES (37, CAST(N'2026-07-11T20:40:03.503' AS DateTime), N'tp', N'Seguridad', N'Inicio de sesión exitoso', 1)
INSERT [dbo].[BITACORA] ([ID_BITACORA], [FECHA], [USUARIO], [MODULO], [OPERACION], [CRITICIDAD]) VALUES (38, CAST(N'2026-07-11T20:40:15.263' AS DateTime), N'tp', N'Inventario', N'Se dio de baja el producto sprite', 2)
INSERT [dbo].[BITACORA] ([ID_BITACORA], [FECHA], [USUARIO], [MODULO], [OPERACION], [CRITICIDAD]) VALUES (39, CAST(N'2026-07-11T20:56:00.843' AS DateTime), N'tp', N'Seguridad', N'Cierre de sesión automatico', 1)
INSERT [dbo].[BITACORA] ([ID_BITACORA], [FECHA], [USUARIO], [MODULO], [OPERACION], [CRITICIDAD]) VALUES (40, CAST(N'2026-07-16T12:35:55.567' AS DateTime), N'tp', N'Seguridad', N'Inicio de sesión exitoso', 1)
INSERT [dbo].[BITACORA] ([ID_BITACORA], [FECHA], [USUARIO], [MODULO], [OPERACION], [CRITICIDAD]) VALUES (41, CAST(N'2026-07-16T12:36:19.767' AS DateTime), N'tp', N'Seguridad', N'Cierre de sesión automatico', 1)
INSERT [dbo].[BITACORA] ([ID_BITACORA], [FECHA], [USUARIO], [MODULO], [OPERACION], [CRITICIDAD]) VALUES (42, CAST(N'2026-07-16T14:56:28.307' AS DateTime), N'tp', N'Seguridad', N'Inicio de sesión exitoso', 1)
INSERT [dbo].[BITACORA] ([ID_BITACORA], [FECHA], [USUARIO], [MODULO], [OPERACION], [CRITICIDAD]) VALUES (43, CAST(N'2026-07-16T14:56:53.600' AS DateTime), N'tp', N'Administracion', N'Se dio de alta al usuario usuinactivo', 2)
INSERT [dbo].[BITACORA] ([ID_BITACORA], [FECHA], [USUARIO], [MODULO], [OPERACION], [CRITICIDAD]) VALUES (44, CAST(N'2026-07-16T14:57:00.133' AS DateTime), N'tp', N'Administracion', N'Se dio de baja al usuario usuinactivo', 4)
INSERT [dbo].[BITACORA] ([ID_BITACORA], [FECHA], [USUARIO], [MODULO], [OPERACION], [CRITICIDAD]) VALUES (45, CAST(N'2026-07-16T14:57:31.330' AS DateTime), N'tp', N'Seguridad', N'Cierre de sesión manual', 1)
INSERT [dbo].[BITACORA] ([ID_BITACORA], [FECHA], [USUARIO], [MODULO], [OPERACION], [CRITICIDAD]) VALUES (46, CAST(N'2026-07-16T14:57:35.933' AS DateTime), N'Usuario no autenticado', N'Seguridad', N'Intento de acceso con usuario inexistente:', 3)
INSERT [dbo].[BITACORA] ([ID_BITACORA], [FECHA], [USUARIO], [MODULO], [OPERACION], [CRITICIDAD]) VALUES (47, CAST(N'2026-07-16T14:57:41.080' AS DateTime), N'tp', N'Seguridad', N'Inicio de sesión exitoso', 1)
INSERT [dbo].[BITACORA] ([ID_BITACORA], [FECHA], [USUARIO], [MODULO], [OPERACION], [CRITICIDAD]) VALUES (48, CAST(N'2026-07-16T14:57:51.047' AS DateTime), N'tp', N'Administracion', N'Se reactivó al usuario usuinactivo', 3)
INSERT [dbo].[BITACORA] ([ID_BITACORA], [FECHA], [USUARIO], [MODULO], [OPERACION], [CRITICIDAD]) VALUES (49, CAST(N'2026-07-16T14:57:56.713' AS DateTime), N'tp', N'Seguridad', N'Cierre de sesión manual', 1)
INSERT [dbo].[BITACORA] ([ID_BITACORA], [FECHA], [USUARIO], [MODULO], [OPERACION], [CRITICIDAD]) VALUES (50, CAST(N'2026-07-16T14:57:59.827' AS DateTime), N'usuinactivo', N'Seguridad', N'Inicio de sesión exitoso', 1)
INSERT [dbo].[BITACORA] ([ID_BITACORA], [FECHA], [USUARIO], [MODULO], [OPERACION], [CRITICIDAD]) VALUES (51, CAST(N'2026-07-16T14:58:03.340' AS DateTime), N'usuinactivo', N'Seguridad', N'Cierre de sesión automatico', 1)
INSERT [dbo].[BITACORA] ([ID_BITACORA], [FECHA], [USUARIO], [MODULO], [OPERACION], [CRITICIDAD]) VALUES (52, CAST(N'2026-09-03T16:02:09.313' AS DateTime), N'tp', N'Seguridad', N'Inicio de sesión exitoso', 1)
INSERT [dbo].[BITACORA] ([ID_BITACORA], [FECHA], [USUARIO], [MODULO], [OPERACION], [CRITICIDAD]) VALUES (53, CAST(N'2026-09-03T16:02:46.183' AS DateTime), N'tp', N'Seguridad', N'Cierre de sesión automatico', 1)
INSERT [dbo].[BITACORA] ([ID_BITACORA], [FECHA], [USUARIO], [MODULO], [OPERACION], [CRITICIDAD]) VALUES (54, CAST(N'2026-10-04T11:11:15.920' AS DateTime), N'tp', N'Seguridad', N'Inicio de sesión exitoso', 1)
INSERT [dbo].[BITACORA] ([ID_BITACORA], [FECHA], [USUARIO], [MODULO], [OPERACION], [CRITICIDAD]) VALUES (55, CAST(N'2026-10-04T11:11:35.920' AS DateTime), N'tp', N'Seguridad', N'Cierre de sesión manual', 1)
INSERT [dbo].[BITACORA] ([ID_BITACORA], [FECHA], [USUARIO], [MODULO], [OPERACION], [CRITICIDAD]) VALUES (56, CAST(N'2026-10-04T13:56:03.717' AS DateTime), N'tp', N'Seguridad', N'Inicio de sesión exitoso', 1)
INSERT [dbo].[BITACORA] ([ID_BITACORA], [FECHA], [USUARIO], [MODULO], [OPERACION], [CRITICIDAD]) VALUES (57, CAST(N'2026-10-17T23:00:08.503' AS DateTime), N'tp', N'Seguridad', N'Inicio de sesión exitoso', 1)
INSERT [dbo].[BITACORA] ([ID_BITACORA], [FECHA], [USUARIO], [MODULO], [OPERACION], [CRITICIDAD]) VALUES (58, CAST(N'2026-10-17T23:00:13.257' AS DateTime), N'tp', N'Seguridad', N'Cierre de sesión automatico', 1)
INSERT [dbo].[BITACORA] ([ID_BITACORA], [FECHA], [USUARIO], [MODULO], [OPERACION], [CRITICIDAD]) VALUES (59, CAST(N'2026-10-17T23:08:46.260' AS DateTime), N'tp', N'Seguridad', N'Inicio de sesión exitoso', 1)
INSERT [dbo].[BITACORA] ([ID_BITACORA], [FECHA], [USUARIO], [MODULO], [OPERACION], [CRITICIDAD]) VALUES (60, CAST(N'2026-10-17T23:10:31.120' AS DateTime), N'tp', N'Seguridad', N'Inicio de sesión exitoso', 1)
INSERT [dbo].[BITACORA] ([ID_BITACORA], [FECHA], [USUARIO], [MODULO], [OPERACION], [CRITICIDAD]) VALUES (61, CAST(N'2026-10-17T23:14:09.247' AS DateTime), N'tp', N'Seguridad', N'Inicio de sesión exitoso', 1)
INSERT [dbo].[BITACORA] ([ID_BITACORA], [FECHA], [USUARIO], [MODULO], [OPERACION], [CRITICIDAD]) VALUES (62, CAST(N'2026-10-17T23:17:55.827' AS DateTime), N'tp', N'Seguridad', N'Inicio de sesión exitoso', 1)
INSERT [dbo].[BITACORA] ([ID_BITACORA], [FECHA], [USUARIO], [MODULO], [OPERACION], [CRITICIDAD]) VALUES (63, CAST(N'2026-10-17T23:24:32.687' AS DateTime), N'tp', N'Seguridad', N'Inicio de sesión exitoso', 1)
INSERT [dbo].[BITACORA] ([ID_BITACORA], [FECHA], [USUARIO], [MODULO], [OPERACION], [CRITICIDAD]) VALUES (64, CAST(N'2026-10-17T23:25:00.350' AS DateTime), N'tp', N'Seguridad', N'Cierre de sesión automatico', 1)
INSERT [dbo].[BITACORA] ([ID_BITACORA], [FECHA], [USUARIO], [MODULO], [OPERACION], [CRITICIDAD]) VALUES (65, CAST(N'2026-10-17T23:29:52.627' AS DateTime), N'tp', N'Seguridad', N'Inicio de sesión exitoso', 1)
INSERT [dbo].[BITACORA] ([ID_BITACORA], [FECHA], [USUARIO], [MODULO], [OPERACION], [CRITICIDAD]) VALUES (66, CAST(N'2026-10-17T23:35:23.383' AS DateTime), N'tp', N'Seguridad', N'Inicio de sesión exitoso', 1)
INSERT [dbo].[BITACORA] ([ID_BITACORA], [FECHA], [USUARIO], [MODULO], [OPERACION], [CRITICIDAD]) VALUES (67, CAST(N'2026-10-17T23:39:36.863' AS DateTime), N'tp', N'Seguridad', N'Inicio de sesión exitoso', 1)
INSERT [dbo].[BITACORA] ([ID_BITACORA], [FECHA], [USUARIO], [MODULO], [OPERACION], [CRITICIDAD]) VALUES (68, CAST(N'2026-10-17T23:42:50.527' AS DateTime), N'tp', N'Seguridad', N'Inicio de sesión exitoso', 1)
INSERT [dbo].[BITACORA] ([ID_BITACORA], [FECHA], [USUARIO], [MODULO], [OPERACION], [CRITICIDAD]) VALUES (69, CAST(N'2026-10-17T23:43:45.350' AS DateTime), N'tp', N'Seguridad', N'Inicio de sesión exitoso', 1)
INSERT [dbo].[BITACORA] ([ID_BITACORA], [FECHA], [USUARIO], [MODULO], [OPERACION], [CRITICIDAD]) VALUES (70, CAST(N'2026-10-17T23:44:27.417' AS DateTime), N'tp', N'Seguridad', N'Inicio de sesión exitoso', 1)
INSERT [dbo].[BITACORA] ([ID_BITACORA], [FECHA], [USUARIO], [MODULO], [OPERACION], [CRITICIDAD]) VALUES (71, CAST(N'2026-10-23T18:01:50.473' AS DateTime), N'tp', N'Seguridad', N'Inicio de sesión exitoso', 1)
INSERT [dbo].[BITACORA] ([ID_BITACORA], [FECHA], [USUARIO], [MODULO], [OPERACION], [CRITICIDAD]) VALUES (72, CAST(N'2026-10-23T18:16:39.420' AS DateTime), N'tp', N'Seguridad', N'Inicio de sesión exitoso', 1)
INSERT [dbo].[BITACORA] ([ID_BITACORA], [FECHA], [USUARIO], [MODULO], [OPERACION], [CRITICIDAD]) VALUES (73, CAST(N'2026-10-23T18:20:27.880' AS DateTime), N'tp', N'Seguridad', N'Inicio de sesión exitoso', 1)
INSERT [dbo].[BITACORA] ([ID_BITACORA], [FECHA], [USUARIO], [MODULO], [OPERACION], [CRITICIDAD]) VALUES (74, CAST(N'2026-10-23T18:33:42.703' AS DateTime), N'tp', N'Seguridad', N'Inicio de sesión exitoso', 1)
INSERT [dbo].[BITACORA] ([ID_BITACORA], [FECHA], [USUARIO], [MODULO], [OPERACION], [CRITICIDAD]) VALUES (75, CAST(N'2026-10-23T18:35:42.017' AS DateTime), N'tp', N'Seguridad', N'Inicio de sesión exitoso', 1)
INSERT [dbo].[BITACORA] ([ID_BITACORA], [FECHA], [USUARIO], [MODULO], [OPERACION], [CRITICIDAD]) VALUES (76, CAST(N'2026-10-24T03:30:16.127' AS DateTime), N'tp', N'Seguridad', N'Inicio de sesión exitoso', 1)
INSERT [dbo].[BITACORA] ([ID_BITACORA], [FECHA], [USUARIO], [MODULO], [OPERACION], [CRITICIDAD]) VALUES (77, CAST(N'2026-10-24T03:32:13.757' AS DateTime), N'tp', N'Seguridad', N'Inicio de sesión exitoso', 1)
INSERT [dbo].[BITACORA] ([ID_BITACORA], [FECHA], [USUARIO], [MODULO], [OPERACION], [CRITICIDAD]) VALUES (78, CAST(N'2026-10-24T03:33:28.410' AS DateTime), N'tp', N'Seguridad', N'Inicio de sesión exitoso', 1)
INSERT [dbo].[BITACORA] ([ID_BITACORA], [FECHA], [USUARIO], [MODULO], [OPERACION], [CRITICIDAD]) VALUES (79, CAST(N'2026-10-24T03:40:08.980' AS DateTime), N'tp', N'Seguridad', N'Inicio de sesión exitoso', 1)
INSERT [dbo].[BITACORA] ([ID_BITACORA], [FECHA], [USUARIO], [MODULO], [OPERACION], [CRITICIDAD]) VALUES (80, CAST(N'2026-10-24T03:47:40.073' AS DateTime), N'tp', N'Seguridad', N'Inicio de sesión exitoso', 1)
INSERT [dbo].[BITACORA] ([ID_BITACORA], [FECHA], [USUARIO], [MODULO], [OPERACION], [CRITICIDAD]) VALUES (81, CAST(N'2026-10-24T03:49:40.230' AS DateTime), N'tp', N'Seguridad', N'Inicio de sesión exitoso', 1)
INSERT [dbo].[BITACORA] ([ID_BITACORA], [FECHA], [USUARIO], [MODULO], [OPERACION], [CRITICIDAD]) VALUES (82, CAST(N'2026-10-24T03:50:43.310' AS DateTime), N'tp', N'Seguridad', N'Inicio de sesión exitoso', 1)
INSERT [dbo].[BITACORA] ([ID_BITACORA], [FECHA], [USUARIO], [MODULO], [OPERACION], [CRITICIDAD]) VALUES (83, CAST(N'2026-10-24T03:51:42.810' AS DateTime), N'tp', N'Seguridad', N'Cierre de sesión automatico', 1)
INSERT [dbo].[BITACORA] ([ID_BITACORA], [FECHA], [USUARIO], [MODULO], [OPERACION], [CRITICIDAD]) VALUES (84, CAST(N'2026-10-24T03:53:10.530' AS DateTime), N'tp', N'Seguridad', N'Inicio de sesión exitoso', 1)
INSERT [dbo].[BITACORA] ([ID_BITACORA], [FECHA], [USUARIO], [MODULO], [OPERACION], [CRITICIDAD]) VALUES (85, CAST(N'2026-10-24T04:08:36.677' AS DateTime), N'tp', N'Seguridad', N'Inicio de sesión exitoso', 1)
INSERT [dbo].[BITACORA] ([ID_BITACORA], [FECHA], [USUARIO], [MODULO], [OPERACION], [CRITICIDAD]) VALUES (86, CAST(N'2026-10-24T04:11:33.813' AS DateTime), N'tp', N'Seguridad', N'Inicio de sesión exitoso', 1)
INSERT [dbo].[BITACORA] ([ID_BITACORA], [FECHA], [USUARIO], [MODULO], [OPERACION], [CRITICIDAD]) VALUES (87, CAST(N'2026-10-24T11:32:00.070' AS DateTime), N'tp', N'Seguridad', N'Inicio de sesión exitoso', 1)
INSERT [dbo].[BITACORA] ([ID_BITACORA], [FECHA], [USUARIO], [MODULO], [OPERACION], [CRITICIDAD]) VALUES (88, CAST(N'2026-10-25T00:10:20.583' AS DateTime), N'tp', N'Seguridad', N'Inicio de sesión exitoso', 1)
INSERT [dbo].[BITACORA] ([ID_BITACORA], [FECHA], [USUARIO], [MODULO], [OPERACION], [CRITICIDAD]) VALUES (89, CAST(N'2026-10-25T00:14:21.480' AS DateTime), N'tp', N'Seguridad', N'Inicio de sesión exitoso', 1)
INSERT [dbo].[BITACORA] ([ID_BITACORA], [FECHA], [USUARIO], [MODULO], [OPERACION], [CRITICIDAD]) VALUES (90, CAST(N'2026-10-25T00:20:07.520' AS DateTime), N'tp', N'Seguridad', N'Inicio de sesión exitoso', 1)
INSERT [dbo].[BITACORA] ([ID_BITACORA], [FECHA], [USUARIO], [MODULO], [OPERACION], [CRITICIDAD]) VALUES (91, CAST(N'2026-10-25T00:21:19.103' AS DateTime), N'tp', N'Seguridad', N'Inicio de sesión exitoso', 1)
INSERT [dbo].[BITACORA] ([ID_BITACORA], [FECHA], [USUARIO], [MODULO], [OPERACION], [CRITICIDAD]) VALUES (92, CAST(N'2026-10-25T00:23:08.533' AS DateTime), N'tp', N'Seguridad', N'Inicio de sesión exitoso', 1)
INSERT [dbo].[BITACORA] ([ID_BITACORA], [FECHA], [USUARIO], [MODULO], [OPERACION], [CRITICIDAD]) VALUES (93, CAST(N'2026-10-25T00:25:19.613' AS DateTime), N'tp', N'Seguridad', N'Inicio de sesión exitoso', 1)
INSERT [dbo].[BITACORA] ([ID_BITACORA], [FECHA], [USUARIO], [MODULO], [OPERACION], [CRITICIDAD]) VALUES (94, CAST(N'2026-10-25T00:27:17.927' AS DateTime), N'tp', N'Seguridad', N'Inicio de sesión exitoso', 1)
INSERT [dbo].[BITACORA] ([ID_BITACORA], [FECHA], [USUARIO], [MODULO], [OPERACION], [CRITICIDAD]) VALUES (95, CAST(N'2026-10-25T00:28:27.387' AS DateTime), N'tp', N'Seguridad', N'Cierre de sesión automatico', 1)
INSERT [dbo].[BITACORA] ([ID_BITACORA], [FECHA], [USUARIO], [MODULO], [OPERACION], [CRITICIDAD]) VALUES (96, CAST(N'2026-10-25T00:38:28.920' AS DateTime), N'tp', N'Seguridad', N'Inicio de sesión exitoso', 1)
INSERT [dbo].[BITACORA] ([ID_BITACORA], [FECHA], [USUARIO], [MODULO], [OPERACION], [CRITICIDAD]) VALUES (97, CAST(N'2026-10-25T10:32:57.690' AS DateTime), N'tp', N'Seguridad', N'Inicio de sesión exitoso', 1)
INSERT [dbo].[BITACORA] ([ID_BITACORA], [FECHA], [USUARIO], [MODULO], [OPERACION], [CRITICIDAD]) VALUES (98, CAST(N'2026-10-25T10:39:14.310' AS DateTime), N'tp', N'Seguridad', N'Inicio de sesión exitoso', 1)
INSERT [dbo].[BITACORA] ([ID_BITACORA], [FECHA], [USUARIO], [MODULO], [OPERACION], [CRITICIDAD]) VALUES (99, CAST(N'2026-10-25T12:45:06.047' AS DateTime), N'tp', N'Seguridad', N'Inicio de sesión exitoso', 1)
INSERT [dbo].[BITACORA] ([ID_BITACORA], [FECHA], [USUARIO], [MODULO], [OPERACION], [CRITICIDAD]) VALUES (100, CAST(N'2026-10-25T12:46:12.793' AS DateTime), N'tp', N'Seguridad', N'Cierre de sesión automatico', 1)
GO
INSERT [dbo].[BITACORA] ([ID_BITACORA], [FECHA], [USUARIO], [MODULO], [OPERACION], [CRITICIDAD]) VALUES (101, CAST(N'2026-10-25T12:51:12.663' AS DateTime), N'tp', N'Seguridad', N'Inicio de sesión exitoso', 1)
INSERT [dbo].[BITACORA] ([ID_BITACORA], [FECHA], [USUARIO], [MODULO], [OPERACION], [CRITICIDAD]) VALUES (102, CAST(N'2026-10-27T19:54:06.413' AS DateTime), N'tp', N'Seguridad', N'Inicio de sesión exitoso', 1)
INSERT [dbo].[BITACORA] ([ID_BITACORA], [FECHA], [USUARIO], [MODULO], [OPERACION], [CRITICIDAD]) VALUES (103, CAST(N'2026-10-27T20:23:58.530' AS DateTime), N'tp', N'Seguridad', N'Inicio de sesión exitoso', 1)
INSERT [dbo].[BITACORA] ([ID_BITACORA], [FECHA], [USUARIO], [MODULO], [OPERACION], [CRITICIDAD]) VALUES (104, CAST(N'2026-10-27T20:27:33.617' AS DateTime), N'tp', N'Seguridad', N'Cierre de sesión automatico', 1)
INSERT [dbo].[BITACORA] ([ID_BITACORA], [FECHA], [USUARIO], [MODULO], [OPERACION], [CRITICIDAD]) VALUES (105, CAST(N'2026-10-27T20:32:08.780' AS DateTime), N'tp', N'Seguridad', N'Inicio de sesión exitoso', 1)
INSERT [dbo].[BITACORA] ([ID_BITACORA], [FECHA], [USUARIO], [MODULO], [OPERACION], [CRITICIDAD]) VALUES (106, CAST(N'2026-10-27T20:48:02.653' AS DateTime), N'tp', N'Seguridad', N'Inicio de sesión exitoso', 1)
INSERT [dbo].[BITACORA] ([ID_BITACORA], [FECHA], [USUARIO], [MODULO], [OPERACION], [CRITICIDAD]) VALUES (107, CAST(N'2026-10-27T21:06:22.377' AS DateTime), N'tp', N'Seguridad', N'Inicio de sesión exitoso', 1)
INSERT [dbo].[BITACORA] ([ID_BITACORA], [FECHA], [USUARIO], [MODULO], [OPERACION], [CRITICIDAD]) VALUES (108, CAST(N'2026-10-27T21:07:06.297' AS DateTime), N'tp', N'Seguridad', N'Inicio de sesión exitoso', 1)
INSERT [dbo].[BITACORA] ([ID_BITACORA], [FECHA], [USUARIO], [MODULO], [OPERACION], [CRITICIDAD]) VALUES (109, CAST(N'2026-10-27T21:09:21.277' AS DateTime), N'tp', N'Seguridad', N'Inicio de sesión exitoso', 1)
INSERT [dbo].[BITACORA] ([ID_BITACORA], [FECHA], [USUARIO], [MODULO], [OPERACION], [CRITICIDAD]) VALUES (110, CAST(N'2026-10-27T21:10:44.970' AS DateTime), N'tp', N'Seguridad', N'Inicio de sesión exitoso', 1)
INSERT [dbo].[BITACORA] ([ID_BITACORA], [FECHA], [USUARIO], [MODULO], [OPERACION], [CRITICIDAD]) VALUES (111, CAST(N'2026-10-27T21:19:59.433' AS DateTime), N'tp', N'Seguridad', N'Inicio de sesión exitoso', 1)
INSERT [dbo].[BITACORA] ([ID_BITACORA], [FECHA], [USUARIO], [MODULO], [OPERACION], [CRITICIDAD]) VALUES (112, CAST(N'2026-10-27T21:24:49.773' AS DateTime), N'tp', N'Seguridad', N'Inicio de sesión exitoso', 1)
INSERT [dbo].[BITACORA] ([ID_BITACORA], [FECHA], [USUARIO], [MODULO], [OPERACION], [CRITICIDAD]) VALUES (113, CAST(N'2026-10-27T21:26:17.390' AS DateTime), N'tp', N'Seguridad', N'Inicio de sesión exitoso', 1)
INSERT [dbo].[BITACORA] ([ID_BITACORA], [FECHA], [USUARIO], [MODULO], [OPERACION], [CRITICIDAD]) VALUES (114, CAST(N'2026-10-27T21:30:33.423' AS DateTime), N'tp', N'Seguridad', N'Inicio de sesión exitoso', 1)
INSERT [dbo].[BITACORA] ([ID_BITACORA], [FECHA], [USUARIO], [MODULO], [OPERACION], [CRITICIDAD]) VALUES (115, CAST(N'2026-10-27T21:40:05.790' AS DateTime), N'tp', N'Seguridad', N'Inicio de sesión exitoso', 1)
INSERT [dbo].[BITACORA] ([ID_BITACORA], [FECHA], [USUARIO], [MODULO], [OPERACION], [CRITICIDAD]) VALUES (116, CAST(N'2026-10-27T21:43:51.593' AS DateTime), N'tp', N'Seguridad', N'Inicio de sesión exitoso', 1)
INSERT [dbo].[BITACORA] ([ID_BITACORA], [FECHA], [USUARIO], [MODULO], [OPERACION], [CRITICIDAD]) VALUES (117, CAST(N'2026-10-29T08:29:36.680' AS DateTime), N'tp', N'Seguridad', N'Inicio de sesión exitoso', 1)
INSERT [dbo].[BITACORA] ([ID_BITACORA], [FECHA], [USUARIO], [MODULO], [OPERACION], [CRITICIDAD]) VALUES (118, CAST(N'2026-10-29T08:29:58.770' AS DateTime), N'tp', N'Seguridad', N'Cierre de sesión automatico', 1)
INSERT [dbo].[BITACORA] ([ID_BITACORA], [FECHA], [USUARIO], [MODULO], [OPERACION], [CRITICIDAD]) VALUES (119, CAST(N'2026-10-29T08:31:54.440' AS DateTime), N'tp', N'Seguridad', N'Inicio de sesión exitoso', 1)
INSERT [dbo].[BITACORA] ([ID_BITACORA], [FECHA], [USUARIO], [MODULO], [OPERACION], [CRITICIDAD]) VALUES (120, CAST(N'2026-10-29T16:39:26.547' AS DateTime), N'tp', N'Seguridad', N'Inicio de sesión exitoso', 1)
INSERT [dbo].[BITACORA] ([ID_BITACORA], [FECHA], [USUARIO], [MODULO], [OPERACION], [CRITICIDAD]) VALUES (121, CAST(N'2026-10-29T17:50:02.447' AS DateTime), N'tp', N'Seguridad', N'Inicio de sesión exitoso', 1)
INSERT [dbo].[BITACORA] ([ID_BITACORA], [FECHA], [USUARIO], [MODULO], [OPERACION], [CRITICIDAD]) VALUES (122, CAST(N'2026-10-29T19:01:19.540' AS DateTime), N'tp', N'Seguridad', N'Inicio de sesión exitoso', 1)
INSERT [dbo].[BITACORA] ([ID_BITACORA], [FECHA], [USUARIO], [MODULO], [OPERACION], [CRITICIDAD]) VALUES (123, CAST(N'2026-10-29T19:03:02.820' AS DateTime), N'tp', N'Seguridad', N'Cierre de sesión automatico', 1)
INSERT [dbo].[BITACORA] ([ID_BITACORA], [FECHA], [USUARIO], [MODULO], [OPERACION], [CRITICIDAD]) VALUES (124, CAST(N'2026-10-29T22:13:01.233' AS DateTime), N'tp', N'Seguridad', N'Inicio de sesión exitoso', 1)
INSERT [dbo].[BITACORA] ([ID_BITACORA], [FECHA], [USUARIO], [MODULO], [OPERACION], [CRITICIDAD]) VALUES (125, CAST(N'2026-10-29T22:14:58.477' AS DateTime), N'tp', N'Seguridad', N'Cierre de sesión automatico', 1)
INSERT [dbo].[BITACORA] ([ID_BITACORA], [FECHA], [USUARIO], [MODULO], [OPERACION], [CRITICIDAD]) VALUES (126, CAST(N'2026-10-30T20:34:33.600' AS DateTime), N'tp', N'Seguridad', N'Inicio de sesión exitoso', 1)
INSERT [dbo].[BITACORA] ([ID_BITACORA], [FECHA], [USUARIO], [MODULO], [OPERACION], [CRITICIDAD]) VALUES (127, CAST(N'2026-10-31T05:28:53.843' AS DateTime), N'tp', N'Seguridad', N'Inicio de sesión exitoso', 1)
INSERT [dbo].[BITACORA] ([ID_BITACORA], [FECHA], [USUARIO], [MODULO], [OPERACION], [CRITICIDAD]) VALUES (128, CAST(N'2026-10-31T06:00:24.227' AS DateTime), N'tp', N'Seguridad', N'Inicio de sesión exitoso', 1)
INSERT [dbo].[BITACORA] ([ID_BITACORA], [FECHA], [USUARIO], [MODULO], [OPERACION], [CRITICIDAD]) VALUES (129, CAST(N'2026-10-31T06:04:21.557' AS DateTime), N'tp', N'Seguridad', N'Inicio de sesión exitoso', 1)
INSERT [dbo].[BITACORA] ([ID_BITACORA], [FECHA], [USUARIO], [MODULO], [OPERACION], [CRITICIDAD]) VALUES (130, CAST(N'2026-10-31T06:12:55.070' AS DateTime), N'tp', N'Seguridad', N'Inicio de sesión exitoso', 1)
INSERT [dbo].[BITACORA] ([ID_BITACORA], [FECHA], [USUARIO], [MODULO], [OPERACION], [CRITICIDAD]) VALUES (131, CAST(N'2026-10-31T06:18:07.030' AS DateTime), N'tp', N'Seguridad', N'Inicio de sesión exitoso', 1)
INSERT [dbo].[BITACORA] ([ID_BITACORA], [FECHA], [USUARIO], [MODULO], [OPERACION], [CRITICIDAD]) VALUES (132, CAST(N'2026-10-31T06:22:58.230' AS DateTime), N'tp', N'Seguridad', N'Inicio de sesión exitoso', 1)
INSERT [dbo].[BITACORA] ([ID_BITACORA], [FECHA], [USUARIO], [MODULO], [OPERACION], [CRITICIDAD]) VALUES (133, CAST(N'2026-10-31T15:58:53.720' AS DateTime), N'tp', N'Seguridad', N'Inicio de sesión exitoso', 1)
INSERT [dbo].[BITACORA] ([ID_BITACORA], [FECHA], [USUARIO], [MODULO], [OPERACION], [CRITICIDAD]) VALUES (134, CAST(N'2026-10-31T16:08:30.493' AS DateTime), N'tp', N'Seguridad', N'Inicio de sesión exitoso', 1)
INSERT [dbo].[BITACORA] ([ID_BITACORA], [FECHA], [USUARIO], [MODULO], [OPERACION], [CRITICIDAD]) VALUES (135, CAST(N'2026-10-31T16:23:11.317' AS DateTime), N'tp', N'Seguridad', N'Inicio de sesión exitoso', 1)
INSERT [dbo].[BITACORA] ([ID_BITACORA], [FECHA], [USUARIO], [MODULO], [OPERACION], [CRITICIDAD]) VALUES (136, CAST(N'2026-10-31T16:28:44.437' AS DateTime), N'tp', N'Seguridad', N'Inicio de sesión exitoso', 1)
INSERT [dbo].[BITACORA] ([ID_BITACORA], [FECHA], [USUARIO], [MODULO], [OPERACION], [CRITICIDAD]) VALUES (137, CAST(N'2026-10-31T16:30:34.720' AS DateTime), N'tp', N'Seguridad', N'Inicio de sesión exitoso', 1)
INSERT [dbo].[BITACORA] ([ID_BITACORA], [FECHA], [USUARIO], [MODULO], [OPERACION], [CRITICIDAD]) VALUES (138, CAST(N'2026-10-31T16:42:15.560' AS DateTime), N'tp', N'Seguridad', N'Inicio de sesión exitoso', 1)
INSERT [dbo].[BITACORA] ([ID_BITACORA], [FECHA], [USUARIO], [MODULO], [OPERACION], [CRITICIDAD]) VALUES (139, CAST(N'2026-10-31T16:56:04.763' AS DateTime), N'tp', N'Seguridad', N'Inicio de sesión exitoso', 1)
INSERT [dbo].[BITACORA] ([ID_BITACORA], [FECHA], [USUARIO], [MODULO], [OPERACION], [CRITICIDAD]) VALUES (140, CAST(N'2026-10-31T17:15:23.763' AS DateTime), N'tp', N'Seguridad', N'Inicio de sesión exitoso', 1)
INSERT [dbo].[BITACORA] ([ID_BITACORA], [FECHA], [USUARIO], [MODULO], [OPERACION], [CRITICIDAD]) VALUES (141, CAST(N'2026-10-31T17:23:36.260' AS DateTime), N'tp', N'Seguridad', N'Inicio de sesión exitoso', 1)
INSERT [dbo].[BITACORA] ([ID_BITACORA], [FECHA], [USUARIO], [MODULO], [OPERACION], [CRITICIDAD]) VALUES (142, CAST(N'2026-10-31T17:37:01.880' AS DateTime), N'tp', N'Seguridad', N'Inicio de sesión exitoso', 1)
INSERT [dbo].[BITACORA] ([ID_BITACORA], [FECHA], [USUARIO], [MODULO], [OPERACION], [CRITICIDAD]) VALUES (143, CAST(N'2026-10-31T21:45:45.593' AS DateTime), N'tp', N'Seguridad', N'Inicio de sesión exitoso', 1)
INSERT [dbo].[BITACORA] ([ID_BITACORA], [FECHA], [USUARIO], [MODULO], [OPERACION], [CRITICIDAD]) VALUES (144, CAST(N'2026-10-31T21:46:22.560' AS DateTime), N'tp', N'Seguridad', N'Inicio de sesión exitoso', 1)
INSERT [dbo].[BITACORA] ([ID_BITACORA], [FECHA], [USUARIO], [MODULO], [OPERACION], [CRITICIDAD]) VALUES (145, CAST(N'2026-10-31T21:47:03.640' AS DateTime), N'tp', N'Seguridad', N'Inicio de sesión exitoso', 1)
INSERT [dbo].[BITACORA] ([ID_BITACORA], [FECHA], [USUARIO], [MODULO], [OPERACION], [CRITICIDAD]) VALUES (146, CAST(N'2026-10-31T21:50:35.173' AS DateTime), N'tp', N'Seguridad', N'Inicio de sesión exitoso', 1)
INSERT [dbo].[BITACORA] ([ID_BITACORA], [FECHA], [USUARIO], [MODULO], [OPERACION], [CRITICIDAD]) VALUES (147, CAST(N'2026-10-31T21:51:46.920' AS DateTime), N'tp', N'Seguridad', N'Inicio de sesión exitoso', 1)
INSERT [dbo].[BITACORA] ([ID_BITACORA], [FECHA], [USUARIO], [MODULO], [OPERACION], [CRITICIDAD]) VALUES (148, CAST(N'2026-10-31T21:54:40.557' AS DateTime), N'tp', N'Seguridad', N'Inicio de sesión exitoso', 1)
INSERT [dbo].[BITACORA] ([ID_BITACORA], [FECHA], [USUARIO], [MODULO], [OPERACION], [CRITICIDAD]) VALUES (149, CAST(N'2026-10-31T22:01:43.270' AS DateTime), N'tp', N'Seguridad', N'Inicio de sesión exitoso', 1)
INSERT [dbo].[BITACORA] ([ID_BITACORA], [FECHA], [USUARIO], [MODULO], [OPERACION], [CRITICIDAD]) VALUES (150, CAST(N'2026-10-31T23:50:30.417' AS DateTime), N'tp', N'Seguridad', N'Inicio de sesión exitoso', 1)
INSERT [dbo].[BITACORA] ([ID_BITACORA], [FECHA], [USUARIO], [MODULO], [OPERACION], [CRITICIDAD]) VALUES (151, CAST(N'2026-11-01T01:02:51.693' AS DateTime), N'tp', N'Seguridad', N'Inicio de sesión exitoso', 1)
INSERT [dbo].[BITACORA] ([ID_BITACORA], [FECHA], [USUARIO], [MODULO], [OPERACION], [CRITICIDAD]) VALUES (152, CAST(N'2026-11-01T01:09:07.233' AS DateTime), N'tp', N'Seguridad', N'Inicio de sesión exitoso', 1)
INSERT [dbo].[BITACORA] ([ID_BITACORA], [FECHA], [USUARIO], [MODULO], [OPERACION], [CRITICIDAD]) VALUES (153, CAST(N'2026-11-01T10:48:40.007' AS DateTime), N'tp', N'Seguridad', N'Inicio de sesión exitoso', 1)
INSERT [dbo].[BITACORA] ([ID_BITACORA], [FECHA], [USUARIO], [MODULO], [OPERACION], [CRITICIDAD]) VALUES (154, CAST(N'2026-11-01T10:50:17.610' AS DateTime), N'tp', N'Seguridad', N'Inicio de sesión exitoso', 1)
INSERT [dbo].[BITACORA] ([ID_BITACORA], [FECHA], [USUARIO], [MODULO], [OPERACION], [CRITICIDAD]) VALUES (155, CAST(N'2026-11-02T09:26:25.263' AS DateTime), N'tp', N'Seguridad', N'Inicio de sesión exitoso', 1)
INSERT [dbo].[BITACORA] ([ID_BITACORA], [FECHA], [USUARIO], [MODULO], [OPERACION], [CRITICIDAD]) VALUES (156, CAST(N'2026-11-02T09:26:51.073' AS DateTime), N'tp', N'Seguridad', N'Inicio de sesión exitoso', 1)
INSERT [dbo].[BITACORA] ([ID_BITACORA], [FECHA], [USUARIO], [MODULO], [OPERACION], [CRITICIDAD]) VALUES (157, CAST(N'2026-11-02T09:34:23.753' AS DateTime), N'tp', N'Seguridad', N'Inicio de sesión exitoso', 1)
INSERT [dbo].[BITACORA] ([ID_BITACORA], [FECHA], [USUARIO], [MODULO], [OPERACION], [CRITICIDAD]) VALUES (158, CAST(N'2026-11-02T12:30:23.850' AS DateTime), N'tp', N'Seguridad', N'Inicio de sesión exitoso', 1)
INSERT [dbo].[BITACORA] ([ID_BITACORA], [FECHA], [USUARIO], [MODULO], [OPERACION], [CRITICIDAD]) VALUES (159, CAST(N'2026-11-02T12:30:57.410' AS DateTime), N'tp', N'Seguridad', N'Inicio de sesión exitoso', 1)
INSERT [dbo].[BITACORA] ([ID_BITACORA], [FECHA], [USUARIO], [MODULO], [OPERACION], [CRITICIDAD]) VALUES (160, CAST(N'2026-11-02T12:35:18.313' AS DateTime), N'tp', N'Seguridad', N'Inicio de sesión exitoso', 1)
INSERT [dbo].[BITACORA] ([ID_BITACORA], [FECHA], [USUARIO], [MODULO], [OPERACION], [CRITICIDAD]) VALUES (161, CAST(N'2026-11-02T12:48:05.720' AS DateTime), N'tp', N'Seguridad', N'Inicio de sesión exitoso', 1)
INSERT [dbo].[BITACORA] ([ID_BITACORA], [FECHA], [USUARIO], [MODULO], [OPERACION], [CRITICIDAD]) VALUES (162, CAST(N'2026-11-02T14:06:05.543' AS DateTime), N'tp', N'Seguridad', N'Inicio de sesión exitoso', 1)
INSERT [dbo].[BITACORA] ([ID_BITACORA], [FECHA], [USUARIO], [MODULO], [OPERACION], [CRITICIDAD]) VALUES (163, CAST(N'2026-11-02T14:13:22.130' AS DateTime), N'tp', N'Seguridad', N'Inicio de sesión exitoso', 1)
INSERT [dbo].[BITACORA] ([ID_BITACORA], [FECHA], [USUARIO], [MODULO], [OPERACION], [CRITICIDAD]) VALUES (164, CAST(N'2026-11-02T14:17:21.223' AS DateTime), N'tp', N'Seguridad', N'Inicio de sesión exitoso', 1)
INSERT [dbo].[BITACORA] ([ID_BITACORA], [FECHA], [USUARIO], [MODULO], [OPERACION], [CRITICIDAD]) VALUES (165, CAST(N'2026-11-02T14:21:59.890' AS DateTime), N'tp', N'Seguridad', N'Inicio de sesión exitoso', 1)
INSERT [dbo].[BITACORA] ([ID_BITACORA], [FECHA], [USUARIO], [MODULO], [OPERACION], [CRITICIDAD]) VALUES (166, CAST(N'2026-11-02T14:24:20.543' AS DateTime), N'tp', N'Seguridad', N'Inicio de sesión exitoso', 1)
INSERT [dbo].[BITACORA] ([ID_BITACORA], [FECHA], [USUARIO], [MODULO], [OPERACION], [CRITICIDAD]) VALUES (167, CAST(N'2026-11-02T14:24:46.517' AS DateTime), N'tp', N'Seguridad', N'Inicio de sesión exitoso', 1)
INSERT [dbo].[BITACORA] ([ID_BITACORA], [FECHA], [USUARIO], [MODULO], [OPERACION], [CRITICIDAD]) VALUES (168, CAST(N'2026-11-02T14:30:41.963' AS DateTime), N'tp', N'Seguridad', N'Inicio de sesión exitoso', 1)
INSERT [dbo].[BITACORA] ([ID_BITACORA], [FECHA], [USUARIO], [MODULO], [OPERACION], [CRITICIDAD]) VALUES (169, CAST(N'2026-11-02T14:31:55.343' AS DateTime), N'tp', N'Seguridad', N'Inicio de sesión exitoso', 1)
INSERT [dbo].[BITACORA] ([ID_BITACORA], [FECHA], [USUARIO], [MODULO], [OPERACION], [CRITICIDAD]) VALUES (170, CAST(N'2026-11-02T15:25:38.990' AS DateTime), N'tp', N'Seguridad', N'Inicio de sesión exitoso', 1)
INSERT [dbo].[BITACORA] ([ID_BITACORA], [FECHA], [USUARIO], [MODULO], [OPERACION], [CRITICIDAD]) VALUES (171, CAST(N'2026-11-02T15:29:44.767' AS DateTime), N'tp', N'Seguridad', N'Inicio de sesión exitoso', 1)
INSERT [dbo].[BITACORA] ([ID_BITACORA], [FECHA], [USUARIO], [MODULO], [OPERACION], [CRITICIDAD]) VALUES (172, CAST(N'2026-11-02T15:33:04.520' AS DateTime), N'tp', N'Seguridad', N'Inicio de sesión exitoso', 1)
INSERT [dbo].[BITACORA] ([ID_BITACORA], [FECHA], [USUARIO], [MODULO], [OPERACION], [CRITICIDAD]) VALUES (173, CAST(N'2026-11-02T16:01:00.390' AS DateTime), N'tp', N'Seguridad', N'Inicio de sesión exitoso', 1)
INSERT [dbo].[BITACORA] ([ID_BITACORA], [FECHA], [USUARIO], [MODULO], [OPERACION], [CRITICIDAD]) VALUES (174, CAST(N'2026-11-02T16:09:58.377' AS DateTime), N'tp', N'Seguridad', N'Inicio de sesión exitoso', 1)
INSERT [dbo].[BITACORA] ([ID_BITACORA], [FECHA], [USUARIO], [MODULO], [OPERACION], [CRITICIDAD]) VALUES (175, CAST(N'2026-11-02T16:15:35.203' AS DateTime), N'tp', N'Seguridad', N'Inicio de sesión exitoso', 1)
INSERT [dbo].[BITACORA] ([ID_BITACORA], [FECHA], [USUARIO], [MODULO], [OPERACION], [CRITICIDAD]) VALUES (176, CAST(N'2026-11-02T16:18:37.780' AS DateTime), N'tp', N'Seguridad', N'Inicio de sesión exitoso', 1)
INSERT [dbo].[BITACORA] ([ID_BITACORA], [FECHA], [USUARIO], [MODULO], [OPERACION], [CRITICIDAD]) VALUES (177, CAST(N'2026-11-02T16:19:03.687' AS DateTime), N'tp', N'Seguridad', N'Inicio de sesión exitoso', 1)
INSERT [dbo].[BITACORA] ([ID_BITACORA], [FECHA], [USUARIO], [MODULO], [OPERACION], [CRITICIDAD]) VALUES (178, CAST(N'2026-11-02T16:39:59.233' AS DateTime), N'tp', N'Seguridad', N'Inicio de sesión exitoso', 1)
INSERT [dbo].[BITACORA] ([ID_BITACORA], [FECHA], [USUARIO], [MODULO], [OPERACION], [CRITICIDAD]) VALUES (179, CAST(N'2026-11-02T16:43:12.093' AS DateTime), N'tp', N'Seguridad', N'Inicio de sesión exitoso', 1)
INSERT [dbo].[BITACORA] ([ID_BITACORA], [FECHA], [USUARIO], [MODULO], [OPERACION], [CRITICIDAD]) VALUES (180, CAST(N'2026-11-02T17:08:33.443' AS DateTime), N'tp', N'Seguridad', N'Inicio de sesión exitoso', 1)
INSERT [dbo].[BITACORA] ([ID_BITACORA], [FECHA], [USUARIO], [MODULO], [OPERACION], [CRITICIDAD]) VALUES (181, CAST(N'2026-11-02T18:56:10.180' AS DateTime), N'tp', N'Seguridad', N'Inicio de sesión exitoso', 1)
INSERT [dbo].[BITACORA] ([ID_BITACORA], [FECHA], [USUARIO], [MODULO], [OPERACION], [CRITICIDAD]) VALUES (182, CAST(N'2026-11-02T19:07:09.533' AS DateTime), N'tp', N'Seguridad', N'Inicio de sesión exitoso', 1)
INSERT [dbo].[BITACORA] ([ID_BITACORA], [FECHA], [USUARIO], [MODULO], [OPERACION], [CRITICIDAD]) VALUES (183, CAST(N'2026-11-02T19:10:54.347' AS DateTime), N'tp', N'Seguridad', N'Inicio de sesión exitoso', 1)
INSERT [dbo].[BITACORA] ([ID_BITACORA], [FECHA], [USUARIO], [MODULO], [OPERACION], [CRITICIDAD]) VALUES (184, CAST(N'2026-11-02T19:19:05.840' AS DateTime), N'tp', N'Seguridad', N'Inicio de sesión exitoso', 1)
INSERT [dbo].[BITACORA] ([ID_BITACORA], [FECHA], [USUARIO], [MODULO], [OPERACION], [CRITICIDAD]) VALUES (185, CAST(N'2026-11-02T19:20:32.907' AS DateTime), N'tp', N'Seguridad', N'Inicio de sesión exitoso', 1)
INSERT [dbo].[BITACORA] ([ID_BITACORA], [FECHA], [USUARIO], [MODULO], [OPERACION], [CRITICIDAD]) VALUES (186, CAST(N'2026-11-02T19:25:01.217' AS DateTime), N'tp', N'Seguridad', N'Inicio de sesión exitoso', 1)
INSERT [dbo].[BITACORA] ([ID_BITACORA], [FECHA], [USUARIO], [MODULO], [OPERACION], [CRITICIDAD]) VALUES (187, CAST(N'2026-11-02T19:25:40.660' AS DateTime), N'tp', N'Seguridad', N'Cierre de sesión automatico', 1)
INSERT [dbo].[BITACORA] ([ID_BITACORA], [FECHA], [USUARIO], [MODULO], [OPERACION], [CRITICIDAD]) VALUES (188, CAST(N'2026-11-02T19:26:43.213' AS DateTime), N'tp', N'Seguridad', N'Inicio de sesión exitoso', 1)
INSERT [dbo].[BITACORA] ([ID_BITACORA], [FECHA], [USUARIO], [MODULO], [OPERACION], [CRITICIDAD]) VALUES (189, CAST(N'2026-11-02T19:27:02.270' AS DateTime), N'tp', N'Seguridad', N'Inicio de sesión exitoso', 1)
INSERT [dbo].[BITACORA] ([ID_BITACORA], [FECHA], [USUARIO], [MODULO], [OPERACION], [CRITICIDAD]) VALUES (190, CAST(N'2026-11-02T20:13:29.973' AS DateTime), N'tp', N'Seguridad', N'Inicio de sesión exitoso', 1)
INSERT [dbo].[BITACORA] ([ID_BITACORA], [FECHA], [USUARIO], [MODULO], [OPERACION], [CRITICIDAD]) VALUES (191, CAST(N'2026-11-02T21:19:54.867' AS DateTime), N'tp', N'Seguridad', N'Inicio de sesión exitoso', 1)
INSERT [dbo].[BITACORA] ([ID_BITACORA], [FECHA], [USUARIO], [MODULO], [OPERACION], [CRITICIDAD]) VALUES (192, CAST(N'2026-11-02T21:20:11.903' AS DateTime), N'tp', N'Seguridad', N'Cierre de sesión automatico', 1)
INSERT [dbo].[BITACORA] ([ID_BITACORA], [FECHA], [USUARIO], [MODULO], [OPERACION], [CRITICIDAD]) VALUES (193, CAST(N'2026-11-06T14:39:42.350' AS DateTime), N'tp', N'Seguridad', N'Inicio de sesión exitoso', 1)
INSERT [dbo].[BITACORA] ([ID_BITACORA], [FECHA], [USUARIO], [MODULO], [OPERACION], [CRITICIDAD]) VALUES (194, CAST(N'2026-11-06T14:39:58.987' AS DateTime), N'tp', N'Seguridad', N'Cierre de sesión automatico', 1)
INSERT [dbo].[BITACORA] ([ID_BITACORA], [FECHA], [USUARIO], [MODULO], [OPERACION], [CRITICIDAD]) VALUES (195, CAST(N'2026-11-06T14:55:08.817' AS DateTime), N'tp', N'Seguridad', N'Inicio de sesión exitoso', 1)
INSERT [dbo].[BITACORA] ([ID_BITACORA], [FECHA], [USUARIO], [MODULO], [OPERACION], [CRITICIDAD]) VALUES (196, CAST(N'2026-11-06T14:56:40.260' AS DateTime), N'tp', N'Seguridad', N'Cierre de sesión automatico', 1)
INSERT [dbo].[BITACORA] ([ID_BITACORA], [FECHA], [USUARIO], [MODULO], [OPERACION], [CRITICIDAD]) VALUES (197, CAST(N'2026-11-06T14:58:37.007' AS DateTime), N'tp', N'Seguridad', N'Inicio de sesión exitoso', 1)
INSERT [dbo].[BITACORA] ([ID_BITACORA], [FECHA], [USUARIO], [MODULO], [OPERACION], [CRITICIDAD]) VALUES (198, CAST(N'2026-11-06T15:03:33.283' AS DateTime), N'tp', N'Seguridad', N'Inicio de sesión exitoso', 1)
INSERT [dbo].[BITACORA] ([ID_BITACORA], [FECHA], [USUARIO], [MODULO], [OPERACION], [CRITICIDAD]) VALUES (199, CAST(N'2026-11-06T15:04:11.567' AS DateTime), N'tp', N'Seguridad', N'Cierre de sesión automatico', 1)
INSERT [dbo].[BITACORA] ([ID_BITACORA], [FECHA], [USUARIO], [MODULO], [OPERACION], [CRITICIDAD]) VALUES (200, CAST(N'2026-11-06T18:55:42.827' AS DateTime), N'tp', N'Seguridad', N'Inicio de sesión exitoso', 1)
GO
INSERT [dbo].[BITACORA] ([ID_BITACORA], [FECHA], [USUARIO], [MODULO], [OPERACION], [CRITICIDAD]) VALUES (201, CAST(N'2026-11-06T18:56:04.100' AS DateTime), N'tp', N'Seguridad', N'Cierre de sesión automatico', 1)
INSERT [dbo].[BITACORA] ([ID_BITACORA], [FECHA], [USUARIO], [MODULO], [OPERACION], [CRITICIDAD]) VALUES (202, CAST(N'2026-11-06T19:44:28.800' AS DateTime), N'tp', N'Seguridad', N'Inicio de sesión exitoso', 1)
INSERT [dbo].[BITACORA] ([ID_BITACORA], [FECHA], [USUARIO], [MODULO], [OPERACION], [CRITICIDAD]) VALUES (203, CAST(N'2026-11-06T20:06:49.787' AS DateTime), N'Usuario no autenticado', N'Seguridad', N'Intento de acceso con usuario inexistente:', 3)
INSERT [dbo].[BITACORA] ([ID_BITACORA], [FECHA], [USUARIO], [MODULO], [OPERACION], [CRITICIDAD]) VALUES (204, CAST(N'2026-11-06T20:06:56.803' AS DateTime), N'tp', N'Seguridad', N'Inicio de sesión exitoso', 1)
INSERT [dbo].[BITACORA] ([ID_BITACORA], [FECHA], [USUARIO], [MODULO], [OPERACION], [CRITICIDAD]) VALUES (205, CAST(N'2026-11-06T20:07:15.147' AS DateTime), N'tp', N'Seguridad', N'Cierre de sesión automatico', 1)
INSERT [dbo].[BITACORA] ([ID_BITACORA], [FECHA], [USUARIO], [MODULO], [OPERACION], [CRITICIDAD]) VALUES (206, CAST(N'2026-11-10T18:27:05.437' AS DateTime), N'tp', N'Seguridad', N'Inicio de sesión exitoso', 1)
INSERT [dbo].[BITACORA] ([ID_BITACORA], [FECHA], [USUARIO], [MODULO], [OPERACION], [CRITICIDAD]) VALUES (207, CAST(N'2026-11-10T19:29:33.080' AS DateTime), N'tp', N'Seguridad', N'Inicio de sesión exitoso', 1)
INSERT [dbo].[BITACORA] ([ID_BITACORA], [FECHA], [USUARIO], [MODULO], [OPERACION], [CRITICIDAD]) VALUES (208, CAST(N'2026-11-12T19:10:53.380' AS DateTime), N'tp', N'Seguridad', N'Inicio de sesión exitoso', 1)
INSERT [dbo].[BITACORA] ([ID_BITACORA], [FECHA], [USUARIO], [MODULO], [OPERACION], [CRITICIDAD]) VALUES (209, CAST(N'2026-11-12T19:51:27.163' AS DateTime), N'tp', N'Seguridad', N'Cierre de sesión automatico', 1)
INSERT [dbo].[BITACORA] ([ID_BITACORA], [FECHA], [USUARIO], [MODULO], [OPERACION], [CRITICIDAD]) VALUES (210, CAST(N'2026-11-12T19:58:52.747' AS DateTime), N'tp', N'Seguridad', N'Inicio de sesión exitoso', 1)
INSERT [dbo].[BITACORA] ([ID_BITACORA], [FECHA], [USUARIO], [MODULO], [OPERACION], [CRITICIDAD]) VALUES (211, CAST(N'2026-11-12T20:00:13.960' AS DateTime), N'tp', N'Seguridad', N'Inicio de sesión exitoso', 1)
INSERT [dbo].[BITACORA] ([ID_BITACORA], [FECHA], [USUARIO], [MODULO], [OPERACION], [CRITICIDAD]) VALUES (212, CAST(N'2026-11-12T20:08:10.433' AS DateTime), N'tp', N'Seguridad', N'Inicio de sesión exitoso', 1)
INSERT [dbo].[BITACORA] ([ID_BITACORA], [FECHA], [USUARIO], [MODULO], [OPERACION], [CRITICIDAD]) VALUES (213, CAST(N'2026-11-12T20:10:45.177' AS DateTime), N'tp', N'Seguridad', N'Inicio de sesión exitoso', 1)
INSERT [dbo].[BITACORA] ([ID_BITACORA], [FECHA], [USUARIO], [MODULO], [OPERACION], [CRITICIDAD]) VALUES (214, CAST(N'2026-11-14T00:09:14.303' AS DateTime), N'tp', N'Seguridad', N'Inicio de sesión exitoso', 1)
INSERT [dbo].[BITACORA] ([ID_BITACORA], [FECHA], [USUARIO], [MODULO], [OPERACION], [CRITICIDAD]) VALUES (215, CAST(N'2026-11-14T00:10:54.603' AS DateTime), N'tp', N'Seguridad', N'Inicio de sesión exitoso', 1)
INSERT [dbo].[BITACORA] ([ID_BITACORA], [FECHA], [USUARIO], [MODULO], [OPERACION], [CRITICIDAD]) VALUES (216, CAST(N'2026-11-14T00:12:35.043' AS DateTime), N'tp', N'Seguridad', N'Inicio de sesión exitoso', 1)
INSERT [dbo].[BITACORA] ([ID_BITACORA], [FECHA], [USUARIO], [MODULO], [OPERACION], [CRITICIDAD]) VALUES (217, CAST(N'2026-11-14T00:23:17.227' AS DateTime), N'tp', N'Seguridad', N'Inicio de sesión exitoso', 1)
INSERT [dbo].[BITACORA] ([ID_BITACORA], [FECHA], [USUARIO], [MODULO], [OPERACION], [CRITICIDAD]) VALUES (218, CAST(N'2026-11-14T00:28:44.867' AS DateTime), N'tp', N'Seguridad', N'Inicio de sesión exitoso', 1)
INSERT [dbo].[BITACORA] ([ID_BITACORA], [FECHA], [USUARIO], [MODULO], [OPERACION], [CRITICIDAD]) VALUES (219, CAST(N'2026-11-14T00:29:14.230' AS DateTime), N'tp', N'Seguridad', N'Inicio de sesión exitoso', 1)
INSERT [dbo].[BITACORA] ([ID_BITACORA], [FECHA], [USUARIO], [MODULO], [OPERACION], [CRITICIDAD]) VALUES (220, CAST(N'2026-11-14T00:35:34.867' AS DateTime), N'tp', N'Seguridad', N'Inicio de sesión exitoso', 1)
INSERT [dbo].[BITACORA] ([ID_BITACORA], [FECHA], [USUARIO], [MODULO], [OPERACION], [CRITICIDAD]) VALUES (221, CAST(N'2026-11-14T00:37:19.123' AS DateTime), N'tp', N'Seguridad', N'Inicio de sesión exitoso', 1)
INSERT [dbo].[BITACORA] ([ID_BITACORA], [FECHA], [USUARIO], [MODULO], [OPERACION], [CRITICIDAD]) VALUES (222, CAST(N'2026-11-14T00:45:57.263' AS DateTime), N'tp', N'Seguridad', N'Inicio de sesión exitoso', 1)
INSERT [dbo].[BITACORA] ([ID_BITACORA], [FECHA], [USUARIO], [MODULO], [OPERACION], [CRITICIDAD]) VALUES (223, CAST(N'2026-11-14T00:47:41.527' AS DateTime), N'tp', N'Seguridad', N'Inicio de sesión exitoso', 1)
INSERT [dbo].[BITACORA] ([ID_BITACORA], [FECHA], [USUARIO], [MODULO], [OPERACION], [CRITICIDAD]) VALUES (224, CAST(N'2026-11-14T00:49:14.803' AS DateTime), N'tp', N'Seguridad', N'Inicio de sesión exitoso', 1)
INSERT [dbo].[BITACORA] ([ID_BITACORA], [FECHA], [USUARIO], [MODULO], [OPERACION], [CRITICIDAD]) VALUES (225, CAST(N'2026-11-14T00:54:38.353' AS DateTime), N'tp', N'Seguridad', N'Inicio de sesión exitoso', 1)
INSERT [dbo].[BITACORA] ([ID_BITACORA], [FECHA], [USUARIO], [MODULO], [OPERACION], [CRITICIDAD]) VALUES (226, CAST(N'2026-11-14T00:56:16.533' AS DateTime), N'tp', N'Seguridad', N'Inicio de sesión exitoso', 1)
INSERT [dbo].[BITACORA] ([ID_BITACORA], [FECHA], [USUARIO], [MODULO], [OPERACION], [CRITICIDAD]) VALUES (227, CAST(N'2026-11-14T00:56:42.123' AS DateTime), N'tp', N'Seguridad', N'Inicio de sesión exitoso', 1)
INSERT [dbo].[BITACORA] ([ID_BITACORA], [FECHA], [USUARIO], [MODULO], [OPERACION], [CRITICIDAD]) VALUES (228, CAST(N'2026-11-14T00:57:30.470' AS DateTime), N'tp', N'Seguridad', N'Inicio de sesión exitoso', 1)
INSERT [dbo].[BITACORA] ([ID_BITACORA], [FECHA], [USUARIO], [MODULO], [OPERACION], [CRITICIDAD]) VALUES (229, CAST(N'2026-11-14T00:58:02.447' AS DateTime), N'tp', N'Seguridad', N'Inicio de sesión exitoso', 1)
INSERT [dbo].[BITACORA] ([ID_BITACORA], [FECHA], [USUARIO], [MODULO], [OPERACION], [CRITICIDAD]) VALUES (230, CAST(N'2026-11-14T01:00:14.070' AS DateTime), N'tp', N'Seguridad', N'Inicio de sesión exitoso', 1)
INSERT [dbo].[BITACORA] ([ID_BITACORA], [FECHA], [USUARIO], [MODULO], [OPERACION], [CRITICIDAD]) VALUES (231, CAST(N'2026-11-14T01:00:47.367' AS DateTime), N'tp', N'Seguridad', N'Inicio de sesión exitoso', 1)
INSERT [dbo].[BITACORA] ([ID_BITACORA], [FECHA], [USUARIO], [MODULO], [OPERACION], [CRITICIDAD]) VALUES (232, CAST(N'2026-11-14T01:04:23.170' AS DateTime), N'tp', N'Seguridad', N'Inicio de sesión exitoso', 1)
INSERT [dbo].[BITACORA] ([ID_BITACORA], [FECHA], [USUARIO], [MODULO], [OPERACION], [CRITICIDAD]) VALUES (233, CAST(N'2026-11-14T01:05:26.287' AS DateTime), N'tp', N'Seguridad', N'Inicio de sesión exitoso', 1)
INSERT [dbo].[BITACORA] ([ID_BITACORA], [FECHA], [USUARIO], [MODULO], [OPERACION], [CRITICIDAD]) VALUES (234, CAST(N'2026-11-14T01:10:52.920' AS DateTime), N'tp', N'Seguridad', N'Inicio de sesión exitoso', 1)
INSERT [dbo].[BITACORA] ([ID_BITACORA], [FECHA], [USUARIO], [MODULO], [OPERACION], [CRITICIDAD]) VALUES (235, CAST(N'2026-11-14T01:20:48.540' AS DateTime), N'tp', N'Seguridad', N'Inicio de sesión exitoso', 1)
INSERT [dbo].[BITACORA] ([ID_BITACORA], [FECHA], [USUARIO], [MODULO], [OPERACION], [CRITICIDAD]) VALUES (236, CAST(N'2026-11-14T01:22:26.340' AS DateTime), N'tp', N'Seguridad', N'Inicio de sesión exitoso', 1)
INSERT [dbo].[BITACORA] ([ID_BITACORA], [FECHA], [USUARIO], [MODULO], [OPERACION], [CRITICIDAD]) VALUES (237, CAST(N'2026-11-14T01:29:29.140' AS DateTime), N'tp', N'Seguridad', N'Inicio de sesión exitoso', 1)
INSERT [dbo].[BITACORA] ([ID_BITACORA], [FECHA], [USUARIO], [MODULO], [OPERACION], [CRITICIDAD]) VALUES (238, CAST(N'2026-11-14T01:31:50.247' AS DateTime), N'tp', N'Seguridad', N'Inicio de sesión exitoso', 1)
INSERT [dbo].[BITACORA] ([ID_BITACORA], [FECHA], [USUARIO], [MODULO], [OPERACION], [CRITICIDAD]) VALUES (239, CAST(N'2026-11-14T01:32:48.163' AS DateTime), N'tp', N'Seguridad', N'Inicio de sesión exitoso', 1)
INSERT [dbo].[BITACORA] ([ID_BITACORA], [FECHA], [USUARIO], [MODULO], [OPERACION], [CRITICIDAD]) VALUES (240, CAST(N'2026-11-14T01:33:21.493' AS DateTime), N'tp', N'Seguridad', N'Cierre de sesión automatico', 1)
INSERT [dbo].[BITACORA] ([ID_BITACORA], [FECHA], [USUARIO], [MODULO], [OPERACION], [CRITICIDAD]) VALUES (241, CAST(N'2026-11-14T01:37:10.660' AS DateTime), N'tp', N'Seguridad', N'Inicio de sesión exitoso', 1)
INSERT [dbo].[BITACORA] ([ID_BITACORA], [FECHA], [USUARIO], [MODULO], [OPERACION], [CRITICIDAD]) VALUES (242, CAST(N'2026-11-14T19:01:05.097' AS DateTime), N'tp', N'Seguridad', N'Inicio de sesión exitoso', 1)
INSERT [dbo].[BITACORA] ([ID_BITACORA], [FECHA], [USUARIO], [MODULO], [OPERACION], [CRITICIDAD]) VALUES (243, CAST(N'2026-11-14T19:05:16.607' AS DateTime), N'tp', N'Seguridad', N'Inicio de sesión exitoso', 1)
INSERT [dbo].[BITACORA] ([ID_BITACORA], [FECHA], [USUARIO], [MODULO], [OPERACION], [CRITICIDAD]) VALUES (244, CAST(N'2026-11-14T19:06:15.430' AS DateTime), N'tp', N'Seguridad', N'Inicio de sesión exitoso', 1)
INSERT [dbo].[BITACORA] ([ID_BITACORA], [FECHA], [USUARIO], [MODULO], [OPERACION], [CRITICIDAD]) VALUES (245, CAST(N'2026-11-14T19:21:02.450' AS DateTime), N'tp', N'Seguridad', N'Inicio de sesión exitoso', 1)
INSERT [dbo].[BITACORA] ([ID_BITACORA], [FECHA], [USUARIO], [MODULO], [OPERACION], [CRITICIDAD]) VALUES (246, CAST(N'2026-11-14T19:38:58.380' AS DateTime), N'tp', N'Seguridad', N'Inicio de sesión exitoso', 1)
INSERT [dbo].[BITACORA] ([ID_BITACORA], [FECHA], [USUARIO], [MODULO], [OPERACION], [CRITICIDAD]) VALUES (247, CAST(N'2026-11-14T19:39:20.227' AS DateTime), N'tp', N'Seguridad', N'Cierre de sesión automatico', 1)
INSERT [dbo].[BITACORA] ([ID_BITACORA], [FECHA], [USUARIO], [MODULO], [OPERACION], [CRITICIDAD]) VALUES (248, CAST(N'2026-11-15T02:19:11.143' AS DateTime), N'tp', N'Seguridad', N'Inicio de sesión exitoso', 1)
INSERT [dbo].[BITACORA] ([ID_BITACORA], [FECHA], [USUARIO], [MODULO], [OPERACION], [CRITICIDAD]) VALUES (249, CAST(N'2026-11-15T12:16:07.197' AS DateTime), N'tp', N'Seguridad', N'Inicio de sesión exitoso', 1)
INSERT [dbo].[BITACORA] ([ID_BITACORA], [FECHA], [USUARIO], [MODULO], [OPERACION], [CRITICIDAD]) VALUES (250, CAST(N'2026-11-15T12:28:07.647' AS DateTime), N'tp', N'Seguridad', N'Inicio de sesión exitoso', 1)
INSERT [dbo].[BITACORA] ([ID_BITACORA], [FECHA], [USUARIO], [MODULO], [OPERACION], [CRITICIDAD]) VALUES (251, CAST(N'2026-11-15T12:28:31.960' AS DateTime), N'tp', N'Seguridad', N'Cierre de sesión automatico', 1)
INSERT [dbo].[BITACORA] ([ID_BITACORA], [FECHA], [USUARIO], [MODULO], [OPERACION], [CRITICIDAD]) VALUES (252, CAST(N'2026-11-15T12:29:38.957' AS DateTime), N'tp', N'Seguridad', N'Inicio de sesión exitoso', 1)
INSERT [dbo].[BITACORA] ([ID_BITACORA], [FECHA], [USUARIO], [MODULO], [OPERACION], [CRITICIDAD]) VALUES (253, CAST(N'2026-11-15T12:31:10.527' AS DateTime), N'tp', N'Seguridad', N'Inicio de sesión exitoso', 1)
INSERT [dbo].[BITACORA] ([ID_BITACORA], [FECHA], [USUARIO], [MODULO], [OPERACION], [CRITICIDAD]) VALUES (254, CAST(N'2026-11-15T12:37:50.003' AS DateTime), N'tp', N'Seguridad', N'Inicio de sesión exitoso', 1)
INSERT [dbo].[BITACORA] ([ID_BITACORA], [FECHA], [USUARIO], [MODULO], [OPERACION], [CRITICIDAD]) VALUES (255, CAST(N'2026-11-16T11:22:34.400' AS DateTime), N'tp', N'Seguridad', N'Inicio de sesión exitoso', 1)
INSERT [dbo].[BITACORA] ([ID_BITACORA], [FECHA], [USUARIO], [MODULO], [OPERACION], [CRITICIDAD]) VALUES (256, CAST(N'2026-11-16T12:29:20.593' AS DateTime), N'tp', N'Seguridad', N'Inicio de sesión exitoso', 1)
INSERT [dbo].[BITACORA] ([ID_BITACORA], [FECHA], [USUARIO], [MODULO], [OPERACION], [CRITICIDAD]) VALUES (257, CAST(N'2026-11-16T12:32:19.053' AS DateTime), N'tp', N'Seguridad', N'Inicio de sesión exitoso', 1)
INSERT [dbo].[BITACORA] ([ID_BITACORA], [FECHA], [USUARIO], [MODULO], [OPERACION], [CRITICIDAD]) VALUES (258, CAST(N'2026-11-16T12:39:47.247' AS DateTime), N'tp', N'Seguridad', N'Inicio de sesión exitoso', 1)
INSERT [dbo].[BITACORA] ([ID_BITACORA], [FECHA], [USUARIO], [MODULO], [OPERACION], [CRITICIDAD]) VALUES (259, CAST(N'2026-11-16T12:44:54.417' AS DateTime), N'tp', N'Seguridad', N'Cierre de sesión manual', 1)
INSERT [dbo].[BITACORA] ([ID_BITACORA], [FECHA], [USUARIO], [MODULO], [OPERACION], [CRITICIDAD]) VALUES (260, CAST(N'2026-11-16T12:45:25.300' AS DateTime), N'tp', N'Seguridad', N'Inicio de sesión exitoso', 1)
INSERT [dbo].[BITACORA] ([ID_BITACORA], [FECHA], [USUARIO], [MODULO], [OPERACION], [CRITICIDAD]) VALUES (261, CAST(N'2026-11-16T12:45:26.383' AS DateTime), N'tp', N'Seguridad', N'Cierre de sesión automatico', 1)
INSERT [dbo].[BITACORA] ([ID_BITACORA], [FECHA], [USUARIO], [MODULO], [OPERACION], [CRITICIDAD]) VALUES (262, CAST(N'2026-11-16T12:55:49.920' AS DateTime), N'tp', N'Seguridad', N'Inicio de sesión exitoso', 1)
INSERT [dbo].[BITACORA] ([ID_BITACORA], [FECHA], [USUARIO], [MODULO], [OPERACION], [CRITICIDAD]) VALUES (263, CAST(N'2026-11-16T12:58:35.187' AS DateTime), N'tp', N'Seguridad', N'Cierre de sesión automatico', 1)
INSERT [dbo].[BITACORA] ([ID_BITACORA], [FECHA], [USUARIO], [MODULO], [OPERACION], [CRITICIDAD]) VALUES (264, CAST(N'2026-11-16T13:01:58.697' AS DateTime), N'tp', N'Seguridad', N'Inicio de sesión exitoso', 1)
INSERT [dbo].[BITACORA] ([ID_BITACORA], [FECHA], [USUARIO], [MODULO], [OPERACION], [CRITICIDAD]) VALUES (265, CAST(N'2026-11-16T13:02:55.887' AS DateTime), N'tp', N'Seguridad', N'Cierre de sesión automatico', 1)
INSERT [dbo].[BITACORA] ([ID_BITACORA], [FECHA], [USUARIO], [MODULO], [OPERACION], [CRITICIDAD]) VALUES (266, CAST(N'2026-11-16T13:03:33.270' AS DateTime), N'tp', N'Seguridad', N'Inicio de sesión exitoso', 1)
INSERT [dbo].[BITACORA] ([ID_BITACORA], [FECHA], [USUARIO], [MODULO], [OPERACION], [CRITICIDAD]) VALUES (267, CAST(N'2026-11-16T13:03:40.273' AS DateTime), N'tp', N'Seguridad', N'Cierre de sesión automatico', 1)
INSERT [dbo].[BITACORA] ([ID_BITACORA], [FECHA], [USUARIO], [MODULO], [OPERACION], [CRITICIDAD]) VALUES (268, CAST(N'2026-11-16T13:04:58.613' AS DateTime), N'tp', N'Seguridad', N'Inicio de sesión exitoso', 1)
INSERT [dbo].[BITACORA] ([ID_BITACORA], [FECHA], [USUARIO], [MODULO], [OPERACION], [CRITICIDAD]) VALUES (269, CAST(N'2026-11-16T13:05:15.063' AS DateTime), N'tp', N'Seguridad', N'Cierre de sesión automatico', 1)
INSERT [dbo].[BITACORA] ([ID_BITACORA], [FECHA], [USUARIO], [MODULO], [OPERACION], [CRITICIDAD]) VALUES (270, CAST(N'2026-11-16T13:12:34.423' AS DateTime), N'tp', N'Seguridad', N'Inicio de sesión exitoso', 1)
INSERT [dbo].[BITACORA] ([ID_BITACORA], [FECHA], [USUARIO], [MODULO], [OPERACION], [CRITICIDAD]) VALUES (271, CAST(N'2026-11-16T13:13:02.317' AS DateTime), N'tp', N'Seguridad', N'Cierre de sesión automatico', 1)
INSERT [dbo].[BITACORA] ([ID_BITACORA], [FECHA], [USUARIO], [MODULO], [OPERACION], [CRITICIDAD]) VALUES (272, CAST(N'2026-11-16T13:13:52.627' AS DateTime), N'tp', N'Seguridad', N'Inicio de sesión exitoso', 1)
INSERT [dbo].[BITACORA] ([ID_BITACORA], [FECHA], [USUARIO], [MODULO], [OPERACION], [CRITICIDAD]) VALUES (273, CAST(N'2026-11-16T13:14:03.380' AS DateTime), N'tp', N'Seguridad', N'Cierre de sesión automatico', 1)
INSERT [dbo].[BITACORA] ([ID_BITACORA], [FECHA], [USUARIO], [MODULO], [OPERACION], [CRITICIDAD]) VALUES (274, CAST(N'2026-11-16T13:14:26.983' AS DateTime), N'tp', N'Seguridad', N'Inicio de sesión exitoso', 1)
INSERT [dbo].[BITACORA] ([ID_BITACORA], [FECHA], [USUARIO], [MODULO], [OPERACION], [CRITICIDAD]) VALUES (275, CAST(N'2026-11-16T13:14:37.777' AS DateTime), N'tp', N'Seguridad', N'Cierre de sesión automatico', 1)
INSERT [dbo].[BITACORA] ([ID_BITACORA], [FECHA], [USUARIO], [MODULO], [OPERACION], [CRITICIDAD]) VALUES (276, CAST(N'2026-11-16T13:15:05.643' AS DateTime), N'tp', N'Seguridad', N'Inicio de sesión exitoso', 1)
INSERT [dbo].[BITACORA] ([ID_BITACORA], [FECHA], [USUARIO], [MODULO], [OPERACION], [CRITICIDAD]) VALUES (277, CAST(N'2026-11-16T13:15:14.650' AS DateTime), N'tp', N'Seguridad', N'Cierre de sesión automatico', 1)
INSERT [dbo].[BITACORA] ([ID_BITACORA], [FECHA], [USUARIO], [MODULO], [OPERACION], [CRITICIDAD]) VALUES (278, CAST(N'2026-11-16T13:15:25.660' AS DateTime), N'tp', N'Seguridad', N'Inicio de sesión exitoso', 1)
INSERT [dbo].[BITACORA] ([ID_BITACORA], [FECHA], [USUARIO], [MODULO], [OPERACION], [CRITICIDAD]) VALUES (279, CAST(N'2026-11-16T13:15:34.783' AS DateTime), N'tp', N'Seguridad', N'Cierre de sesión automatico', 1)
INSERT [dbo].[BITACORA] ([ID_BITACORA], [FECHA], [USUARIO], [MODULO], [OPERACION], [CRITICIDAD]) VALUES (280, CAST(N'2026-11-16T13:16:27.657' AS DateTime), N'tp', N'Seguridad', N'Inicio de sesión exitoso', 1)
INSERT [dbo].[BITACORA] ([ID_BITACORA], [FECHA], [USUARIO], [MODULO], [OPERACION], [CRITICIDAD]) VALUES (281, CAST(N'2026-11-16T13:16:33.643' AS DateTime), N'tp', N'Seguridad', N'Cierre de sesión automatico', 1)
INSERT [dbo].[BITACORA] ([ID_BITACORA], [FECHA], [USUARIO], [MODULO], [OPERACION], [CRITICIDAD]) VALUES (282, CAST(N'2026-11-16T13:41:45.533' AS DateTime), N'tp', N'Seguridad', N'Inicio de sesión exitoso', 1)
INSERT [dbo].[BITACORA] ([ID_BITACORA], [FECHA], [USUARIO], [MODULO], [OPERACION], [CRITICIDAD]) VALUES (283, CAST(N'2026-11-16T13:42:13.963' AS DateTime), N'tp', N'Seguridad', N'Cierre de sesión automatico', 1)
INSERT [dbo].[BITACORA] ([ID_BITACORA], [FECHA], [USUARIO], [MODULO], [OPERACION], [CRITICIDAD]) VALUES (284, CAST(N'2026-11-16T13:42:44.207' AS DateTime), N'tp', N'Seguridad', N'Inicio de sesión exitoso', 1)
INSERT [dbo].[BITACORA] ([ID_BITACORA], [FECHA], [USUARIO], [MODULO], [OPERACION], [CRITICIDAD]) VALUES (285, CAST(N'2026-11-16T13:43:05.267' AS DateTime), N'tp', N'Seguridad', N'Inicio de sesión exitoso', 1)
INSERT [dbo].[BITACORA] ([ID_BITACORA], [FECHA], [USUARIO], [MODULO], [OPERACION], [CRITICIDAD]) VALUES (286, CAST(N'2026-11-16T13:43:13.010' AS DateTime), N'tp', N'Seguridad', N'Cierre de sesión manual', 1)
INSERT [dbo].[BITACORA] ([ID_BITACORA], [FECHA], [USUARIO], [MODULO], [OPERACION], [CRITICIDAD]) VALUES (287, CAST(N'2026-11-16T13:53:53.643' AS DateTime), N'tp', N'Seguridad', N'Inicio de sesión exitoso', 1)
INSERT [dbo].[BITACORA] ([ID_BITACORA], [FECHA], [USUARIO], [MODULO], [OPERACION], [CRITICIDAD]) VALUES (288, CAST(N'2026-11-16T13:54:12.593' AS DateTime), N'tp', N'Seguridad', N'Cierre de sesión automatico', 1)
INSERT [dbo].[BITACORA] ([ID_BITACORA], [FECHA], [USUARIO], [MODULO], [OPERACION], [CRITICIDAD]) VALUES (289, CAST(N'2026-11-16T13:56:40.173' AS DateTime), N'tp', N'Seguridad', N'Inicio de sesión exitoso', 1)
INSERT [dbo].[BITACORA] ([ID_BITACORA], [FECHA], [USUARIO], [MODULO], [OPERACION], [CRITICIDAD]) VALUES (290, CAST(N'2026-11-16T13:57:00.710' AS DateTime), N'tp', N'Seguridad', N'Cierre de sesión automatico', 1)
INSERT [dbo].[BITACORA] ([ID_BITACORA], [FECHA], [USUARIO], [MODULO], [OPERACION], [CRITICIDAD]) VALUES (291, CAST(N'2026-11-16T14:00:52.867' AS DateTime), N'tp', N'Seguridad', N'Inicio de sesión exitoso', 1)
INSERT [dbo].[BITACORA] ([ID_BITACORA], [FECHA], [USUARIO], [MODULO], [OPERACION], [CRITICIDAD]) VALUES (292, CAST(N'2026-11-16T14:01:14.610' AS DateTime), N'tp', N'Seguridad', N'Cierre de sesión automatico', 1)
INSERT [dbo].[BITACORA] ([ID_BITACORA], [FECHA], [USUARIO], [MODULO], [OPERACION], [CRITICIDAD]) VALUES (293, CAST(N'2026-11-16T14:09:23.223' AS DateTime), N'tp', N'Seguridad', N'Inicio de sesión exitoso', 1)
INSERT [dbo].[BITACORA] ([ID_BITACORA], [FECHA], [USUARIO], [MODULO], [OPERACION], [CRITICIDAD]) VALUES (294, CAST(N'2026-11-16T14:09:24.750' AS DateTime), N'tp', N'Seguridad', N'Cierre de sesión automatico', 1)
INSERT [dbo].[BITACORA] ([ID_BITACORA], [FECHA], [USUARIO], [MODULO], [OPERACION], [CRITICIDAD]) VALUES (295, CAST(N'2026-11-16T14:10:39.707' AS DateTime), N'tp', N'Seguridad', N'Inicio de sesión exitoso', 1)
INSERT [dbo].[BITACORA] ([ID_BITACORA], [FECHA], [USUARIO], [MODULO], [OPERACION], [CRITICIDAD]) VALUES (296, CAST(N'2026-11-16T14:10:41.260' AS DateTime), N'tp', N'Seguridad', N'Cierre de sesión automatico', 1)
INSERT [dbo].[BITACORA] ([ID_BITACORA], [FECHA], [USUARIO], [MODULO], [OPERACION], [CRITICIDAD]) VALUES (297, CAST(N'2026-11-16T14:15:02.063' AS DateTime), N'tp', N'Seguridad', N'Inicio de sesión exitoso', 1)
INSERT [dbo].[BITACORA] ([ID_BITACORA], [FECHA], [USUARIO], [MODULO], [OPERACION], [CRITICIDAD]) VALUES (298, CAST(N'2026-11-16T14:15:17.937' AS DateTime), N'tp', N'Seguridad', N'Cierre de sesión automatico', 1)
INSERT [dbo].[BITACORA] ([ID_BITACORA], [FECHA], [USUARIO], [MODULO], [OPERACION], [CRITICIDAD]) VALUES (299, CAST(N'2026-11-16T14:17:28.487' AS DateTime), N'tp', N'Seguridad', N'Inicio de sesión exitoso', 1)
INSERT [dbo].[BITACORA] ([ID_BITACORA], [FECHA], [USUARIO], [MODULO], [OPERACION], [CRITICIDAD]) VALUES (300, CAST(N'2026-11-16T14:17:29.523' AS DateTime), N'tp', N'Seguridad', N'Cierre de sesión automatico', 1)
GO
INSERT [dbo].[BITACORA] ([ID_BITACORA], [FECHA], [USUARIO], [MODULO], [OPERACION], [CRITICIDAD]) VALUES (301, CAST(N'2026-11-16T16:26:44.543' AS DateTime), N'tp', N'Seguridad', N'Inicio de sesión exitoso', 1)
INSERT [dbo].[BITACORA] ([ID_BITACORA], [FECHA], [USUARIO], [MODULO], [OPERACION], [CRITICIDAD]) VALUES (302, CAST(N'2026-11-16T16:32:13.563' AS DateTime), N'tp', N'Seguridad', N'Inicio de sesión exitoso', 1)
INSERT [dbo].[BITACORA] ([ID_BITACORA], [FECHA], [USUARIO], [MODULO], [OPERACION], [CRITICIDAD]) VALUES (303, CAST(N'2026-11-16T16:32:38.713' AS DateTime), N'tp', N'Seguridad', N'Cierre de sesión automatico', 1)
INSERT [dbo].[BITACORA] ([ID_BITACORA], [FECHA], [USUARIO], [MODULO], [OPERACION], [CRITICIDAD]) VALUES (304, CAST(N'2026-11-16T16:36:18.127' AS DateTime), N'tp', N'Seguridad', N'Inicio de sesión exitoso', 1)
INSERT [dbo].[BITACORA] ([ID_BITACORA], [FECHA], [USUARIO], [MODULO], [OPERACION], [CRITICIDAD]) VALUES (305, CAST(N'2026-11-16T17:01:01.130' AS DateTime), N'tp', N'Seguridad', N'Cierre de sesión manual', 1)
INSERT [dbo].[BITACORA] ([ID_BITACORA], [FECHA], [USUARIO], [MODULO], [OPERACION], [CRITICIDAD]) VALUES (306, CAST(N'2026-11-16T17:02:18.663' AS DateTime), N'tp', N'Seguridad', N'Inicio de sesión exitoso', 1)
INSERT [dbo].[BITACORA] ([ID_BITACORA], [FECHA], [USUARIO], [MODULO], [OPERACION], [CRITICIDAD]) VALUES (307, CAST(N'2026-11-16T17:02:59.073' AS DateTime), N'tp', N'Seguridad', N'Cierre de sesión automatico', 1)
INSERT [dbo].[BITACORA] ([ID_BITACORA], [FECHA], [USUARIO], [MODULO], [OPERACION], [CRITICIDAD]) VALUES (308, CAST(N'2026-11-16T17:14:49.987' AS DateTime), N'tp', N'Seguridad', N'Inicio de sesión exitoso', 1)
INSERT [dbo].[BITACORA] ([ID_BITACORA], [FECHA], [USUARIO], [MODULO], [OPERACION], [CRITICIDAD]) VALUES (309, CAST(N'2026-11-16T17:15:54.763' AS DateTime), N'tp', N'Seguridad', N'Cierre de sesión manual', 1)
INSERT [dbo].[BITACORA] ([ID_BITACORA], [FECHA], [USUARIO], [MODULO], [OPERACION], [CRITICIDAD]) VALUES (310, CAST(N'2026-11-16T17:16:30.787' AS DateTime), N'tp', N'Seguridad', N'Inicio de sesión exitoso', 1)
INSERT [dbo].[BITACORA] ([ID_BITACORA], [FECHA], [USUARIO], [MODULO], [OPERACION], [CRITICIDAD]) VALUES (311, CAST(N'2026-11-16T17:21:29.833' AS DateTime), N'tp', N'Seguridad', N'Cierre de sesión automatico', 1)
INSERT [dbo].[BITACORA] ([ID_BITACORA], [FECHA], [USUARIO], [MODULO], [OPERACION], [CRITICIDAD]) VALUES (312, CAST(N'2026-11-16T17:59:59.967' AS DateTime), N'tp', N'Seguridad', N'Inicio de sesión exitoso', 1)
INSERT [dbo].[BITACORA] ([ID_BITACORA], [FECHA], [USUARIO], [MODULO], [OPERACION], [CRITICIDAD]) VALUES (313, CAST(N'2026-11-16T18:06:22.413' AS DateTime), N'tp', N'Seguridad', N'Inicio de sesión exitoso', 1)
INSERT [dbo].[BITACORA] ([ID_BITACORA], [FECHA], [USUARIO], [MODULO], [OPERACION], [CRITICIDAD]) VALUES (314, CAST(N'2026-11-16T18:06:56.240' AS DateTime), N'tp', N'Seguridad', N'Cierre de sesión automatico', 1)
INSERT [dbo].[BITACORA] ([ID_BITACORA], [FECHA], [USUARIO], [MODULO], [OPERACION], [CRITICIDAD]) VALUES (315, CAST(N'2026-11-16T18:09:19.667' AS DateTime), N'tp', N'Seguridad', N'Inicio de sesión exitoso', 1)
INSERT [dbo].[BITACORA] ([ID_BITACORA], [FECHA], [USUARIO], [MODULO], [OPERACION], [CRITICIDAD]) VALUES (316, CAST(N'2026-11-16T18:12:46.633' AS DateTime), N'tp', N'Seguridad', N'Cierre de sesión automatico', 1)
INSERT [dbo].[BITACORA] ([ID_BITACORA], [FECHA], [USUARIO], [MODULO], [OPERACION], [CRITICIDAD]) VALUES (317, CAST(N'2026-11-16T18:13:27.077' AS DateTime), N'tp', N'Seguridad', N'Inicio de sesión exitoso', 1)
INSERT [dbo].[BITACORA] ([ID_BITACORA], [FECHA], [USUARIO], [MODULO], [OPERACION], [CRITICIDAD]) VALUES (318, CAST(N'2026-11-16T18:13:46.577' AS DateTime), N'tp', N'Seguridad', N'Cierre de sesión automatico', 1)
INSERT [dbo].[BITACORA] ([ID_BITACORA], [FECHA], [USUARIO], [MODULO], [OPERACION], [CRITICIDAD]) VALUES (319, CAST(N'2026-11-16T18:14:44.680' AS DateTime), N'tp', N'Seguridad', N'Inicio de sesión exitoso', 1)
INSERT [dbo].[BITACORA] ([ID_BITACORA], [FECHA], [USUARIO], [MODULO], [OPERACION], [CRITICIDAD]) VALUES (320, CAST(N'2026-11-16T18:18:43.633' AS DateTime), N'tp', N'Seguridad', N'Cierre de sesión automatico', 1)
INSERT [dbo].[BITACORA] ([ID_BITACORA], [FECHA], [USUARIO], [MODULO], [OPERACION], [CRITICIDAD]) VALUES (321, CAST(N'2026-11-16T18:19:54.693' AS DateTime), N'tp', N'Seguridad', N'Inicio de sesión exitoso', 1)
INSERT [dbo].[BITACORA] ([ID_BITACORA], [FECHA], [USUARIO], [MODULO], [OPERACION], [CRITICIDAD]) VALUES (322, CAST(N'2026-11-16T18:20:20.373' AS DateTime), N'tp', N'Seguridad', N'Inicio de sesión exitoso', 1)
INSERT [dbo].[BITACORA] ([ID_BITACORA], [FECHA], [USUARIO], [MODULO], [OPERACION], [CRITICIDAD]) VALUES (323, CAST(N'2026-11-16T18:21:02.853' AS DateTime), N'tp', N'Seguridad', N'Cierre de sesión automatico', 1)
INSERT [dbo].[BITACORA] ([ID_BITACORA], [FECHA], [USUARIO], [MODULO], [OPERACION], [CRITICIDAD]) VALUES (324, CAST(N'2026-11-16T18:22:40.743' AS DateTime), N'tp', N'Seguridad', N'Inicio de sesión exitoso', 1)
INSERT [dbo].[BITACORA] ([ID_BITACORA], [FECHA], [USUARIO], [MODULO], [OPERACION], [CRITICIDAD]) VALUES (325, CAST(N'2026-11-16T18:22:57.977' AS DateTime), N'tp', N'Seguridad', N'Cierre de sesión automatico', 1)
INSERT [dbo].[BITACORA] ([ID_BITACORA], [FECHA], [USUARIO], [MODULO], [OPERACION], [CRITICIDAD]) VALUES (326, CAST(N'2026-11-16T18:23:51.197' AS DateTime), N'tp', N'Seguridad', N'Inicio de sesión exitoso', 1)
INSERT [dbo].[BITACORA] ([ID_BITACORA], [FECHA], [USUARIO], [MODULO], [OPERACION], [CRITICIDAD]) VALUES (327, CAST(N'2026-11-16T18:26:11.563' AS DateTime), N'tp', N'Seguridad', N'Cierre de sesión automatico', 1)
INSERT [dbo].[BITACORA] ([ID_BITACORA], [FECHA], [USUARIO], [MODULO], [OPERACION], [CRITICIDAD]) VALUES (328, CAST(N'2026-11-16T18:26:43.420' AS DateTime), N'tp', N'Seguridad', N'Inicio de sesión exitoso', 1)
INSERT [dbo].[BITACORA] ([ID_BITACORA], [FECHA], [USUARIO], [MODULO], [OPERACION], [CRITICIDAD]) VALUES (329, CAST(N'2026-11-16T18:26:52.280' AS DateTime), N'tp', N'Seguridad', N'Cierre de sesión automatico', 1)
INSERT [dbo].[BITACORA] ([ID_BITACORA], [FECHA], [USUARIO], [MODULO], [OPERACION], [CRITICIDAD]) VALUES (330, CAST(N'2026-11-16T18:35:45.593' AS DateTime), N'tp', N'Seguridad', N'Inicio de sesión exitoso', 1)
INSERT [dbo].[BITACORA] ([ID_BITACORA], [FECHA], [USUARIO], [MODULO], [OPERACION], [CRITICIDAD]) VALUES (331, CAST(N'2026-11-16T18:35:54.823' AS DateTime), N'tp', N'Seguridad', N'Cierre de sesión automatico', 1)
INSERT [dbo].[BITACORA] ([ID_BITACORA], [FECHA], [USUARIO], [MODULO], [OPERACION], [CRITICIDAD]) VALUES (332, CAST(N'2026-11-16T18:38:35.987' AS DateTime), N'tp', N'Seguridad', N'Inicio de sesión exitoso', 1)
INSERT [dbo].[BITACORA] ([ID_BITACORA], [FECHA], [USUARIO], [MODULO], [OPERACION], [CRITICIDAD]) VALUES (333, CAST(N'2026-11-16T18:38:43.480' AS DateTime), N'tp', N'Seguridad', N'Cierre de sesión automatico', 1)
INSERT [dbo].[BITACORA] ([ID_BITACORA], [FECHA], [USUARIO], [MODULO], [OPERACION], [CRITICIDAD]) VALUES (334, CAST(N'2026-11-19T22:16:02.387' AS DateTime), N'tp', N'Seguridad', N'Inicio de sesión exitoso', 1)
INSERT [dbo].[BITACORA] ([ID_BITACORA], [FECHA], [USUARIO], [MODULO], [OPERACION], [CRITICIDAD]) VALUES (335, CAST(N'2026-11-19T22:16:07.290' AS DateTime), N'tp', N'Seguridad', N'Cierre de sesión automatico', 1)
INSERT [dbo].[BITACORA] ([ID_BITACORA], [FECHA], [USUARIO], [MODULO], [OPERACION], [CRITICIDAD]) VALUES (336, CAST(N'2026-11-20T19:28:33.027' AS DateTime), N'tp', N'Seguridad', N'Inicio de sesión exitoso', 1)
INSERT [dbo].[BITACORA] ([ID_BITACORA], [FECHA], [USUARIO], [MODULO], [OPERACION], [CRITICIDAD]) VALUES (337, CAST(N'2026-11-20T19:28:38.060' AS DateTime), N'tp', N'Seguridad', N'Cierre de sesión automatico', 1)
INSERT [dbo].[BITACORA] ([ID_BITACORA], [FECHA], [USUARIO], [MODULO], [OPERACION], [CRITICIDAD]) VALUES (338, CAST(N'2026-11-20T19:28:46.603' AS DateTime), N'tp', N'Seguridad', N'Inicio de sesión exitoso', 1)
INSERT [dbo].[BITACORA] ([ID_BITACORA], [FECHA], [USUARIO], [MODULO], [OPERACION], [CRITICIDAD]) VALUES (339, CAST(N'2026-11-20T19:28:49.370' AS DateTime), N'tp', N'Seguridad', N'Cierre de sesión automatico', 1)
INSERT [dbo].[BITACORA] ([ID_BITACORA], [FECHA], [USUARIO], [MODULO], [OPERACION], [CRITICIDAD]) VALUES (340, CAST(N'2026-11-20T19:30:06.433' AS DateTime), N'tp', N'Seguridad', N'Inicio de sesión exitoso', 1)
INSERT [dbo].[BITACORA] ([ID_BITACORA], [FECHA], [USUARIO], [MODULO], [OPERACION], [CRITICIDAD]) VALUES (341, CAST(N'2026-11-20T19:30:10.280' AS DateTime), N'tp', N'Seguridad', N'Cierre de sesión automatico', 1)
INSERT [dbo].[BITACORA] ([ID_BITACORA], [FECHA], [USUARIO], [MODULO], [OPERACION], [CRITICIDAD]) VALUES (342, CAST(N'2026-11-21T20:23:03.363' AS DateTime), N'tp', N'Seguridad', N'Inicio de sesión exitoso', 1)
INSERT [dbo].[BITACORA] ([ID_BITACORA], [FECHA], [USUARIO], [MODULO], [OPERACION], [CRITICIDAD]) VALUES (343, CAST(N'2026-11-21T20:23:30.800' AS DateTime), N'tp', N'Seguridad', N'Cierre de sesión automatico', 1)
INSERT [dbo].[BITACORA] ([ID_BITACORA], [FECHA], [USUARIO], [MODULO], [OPERACION], [CRITICIDAD]) VALUES (344, CAST(N'2026-11-21T20:28:53.720' AS DateTime), N'tp', N'Seguridad', N'Inicio de sesión exitoso', 1)
INSERT [dbo].[BITACORA] ([ID_BITACORA], [FECHA], [USUARIO], [MODULO], [OPERACION], [CRITICIDAD]) VALUES (345, CAST(N'2026-11-21T20:42:51.223' AS DateTime), N'tp', N'Seguridad', N'Inicio de sesión exitoso', 1)
INSERT [dbo].[BITACORA] ([ID_BITACORA], [FECHA], [USUARIO], [MODULO], [OPERACION], [CRITICIDAD]) VALUES (346, CAST(N'2026-11-21T21:08:48.667' AS DateTime), N'tp', N'Seguridad', N'Inicio de sesión exitoso', 1)
INSERT [dbo].[BITACORA] ([ID_BITACORA], [FECHA], [USUARIO], [MODULO], [OPERACION], [CRITICIDAD]) VALUES (347, CAST(N'2026-11-22T10:56:30.983' AS DateTime), N'tp', N'Seguridad', N'Inicio de sesión exitoso', 1)
INSERT [dbo].[BITACORA] ([ID_BITACORA], [FECHA], [USUARIO], [MODULO], [OPERACION], [CRITICIDAD]) VALUES (348, CAST(N'2026-11-22T10:57:16.763' AS DateTime), N'tp', N'Administracion', N'Se desasigno HISTORIAL_CAMBIOS, dentro del rol ADM', 2)
INSERT [dbo].[BITACORA] ([ID_BITACORA], [FECHA], [USUARIO], [MODULO], [OPERACION], [CRITICIDAD]) VALUES (349, CAST(N'2026-11-22T10:57:23.907' AS DateTime), N'tp', N'Administracion', N'Se desasigno ABM_PRODUCTOS, dentro del rol ADMIN', 2)
INSERT [dbo].[BITACORA] ([ID_BITACORA], [FECHA], [USUARIO], [MODULO], [OPERACION], [CRITICIDAD]) VALUES (350, CAST(N'2026-11-22T10:58:05.830' AS DateTime), N'tp', N'Administracion', N'Se asigno ABM_PRODUCTOS, dentro del rol ADMIN', 2)
INSERT [dbo].[BITACORA] ([ID_BITACORA], [FECHA], [USUARIO], [MODULO], [OPERACION], [CRITICIDAD]) VALUES (351, CAST(N'2026-11-22T11:05:15.037' AS DateTime), N'tp', N'Administracion', N'Se dio de alta el nuevo rol GERENTE_OPERACIONES', 2)
INSERT [dbo].[BITACORA] ([ID_BITACORA], [FECHA], [USUARIO], [MODULO], [OPERACION], [CRITICIDAD]) VALUES (352, CAST(N'2026-11-22T11:05:45.957' AS DateTime), N'tp', N'Administracion', N'Se dio de alta el nuevo rol EJECUTIVO_VENTAS', 2)
INSERT [dbo].[BITACORA] ([ID_BITACORA], [FECHA], [USUARIO], [MODULO], [OPERACION], [CRITICIDAD]) VALUES (353, CAST(N'2026-11-22T11:06:05.693' AS DateTime), N'tp', N'Administracion', N'Se dio de alta el nuevo rol ORGANIZADOR_EVENTOS', 2)
INSERT [dbo].[BITACORA] ([ID_BITACORA], [FECHA], [USUARIO], [MODULO], [OPERACION], [CRITICIDAD]) VALUES (354, CAST(N'2026-11-22T11:06:28.493' AS DateTime), N'tp', N'Administracion', N'Se dio de alta el nuevo rol ENCARGADO_DEPOSITO', 2)
INSERT [dbo].[BITACORA] ([ID_BITACORA], [FECHA], [USUARIO], [MODULO], [OPERACION], [CRITICIDAD]) VALUES (355, CAST(N'2026-11-22T11:07:22.573' AS DateTime), N'tp', N'Administracion', N'Se asigno ABM_PRODUCTOS, dentro del rol ENCARGADO_', 2)
INSERT [dbo].[BITACORA] ([ID_BITACORA], [FECHA], [USUARIO], [MODULO], [OPERACION], [CRITICIDAD]) VALUES (356, CAST(N'2026-11-22T11:07:26.493' AS DateTime), N'tp', N'Administracion', N'Se desasigno ABM_PRODUCTOS, dentro del rol ENCARGA', 2)
INSERT [dbo].[BITACORA] ([ID_BITACORA], [FECHA], [USUARIO], [MODULO], [OPERACION], [CRITICIDAD]) VALUES (357, CAST(N'2026-11-22T11:08:09.643' AS DateTime), N'tp', N'Administracion', N'Se asigno ABM_PERMISOS, dentro del rol GERENTE_OPE', 2)
INSERT [dbo].[BITACORA] ([ID_BITACORA], [FECHA], [USUARIO], [MODULO], [OPERACION], [CRITICIDAD]) VALUES (358, CAST(N'2026-11-22T11:08:17.777' AS DateTime), N'tp', N'Administracion', N'Se desasigno ABM_PERMISOS, dentro del rol GERENTE_', 2)
INSERT [dbo].[BITACORA] ([ID_BITACORA], [FECHA], [USUARIO], [MODULO], [OPERACION], [CRITICIDAD]) VALUES (359, CAST(N'2026-11-22T11:09:11.177' AS DateTime), N'tp', N'Seguridad', N'Cierre de sesión automatico', 1)
INSERT [dbo].[BITACORA] ([ID_BITACORA], [FECHA], [USUARIO], [MODULO], [OPERACION], [CRITICIDAD]) VALUES (360, CAST(N'2026-11-22T11:09:37.633' AS DateTime), N'tp', N'Seguridad', N'Inicio de sesión exitoso', 1)
INSERT [dbo].[BITACORA] ([ID_BITACORA], [FECHA], [USUARIO], [MODULO], [OPERACION], [CRITICIDAD]) VALUES (361, CAST(N'2026-11-22T11:10:07.927' AS DateTime), N'tp', N'Seguridad', N'Cierre de sesión automatico', 1)
INSERT [dbo].[BITACORA] ([ID_BITACORA], [FECHA], [USUARIO], [MODULO], [OPERACION], [CRITICIDAD]) VALUES (362, CAST(N'2026-11-22T11:10:36.127' AS DateTime), N'tp', N'Seguridad', N'Inicio de sesión exitoso', 1)
INSERT [dbo].[BITACORA] ([ID_BITACORA], [FECHA], [USUARIO], [MODULO], [OPERACION], [CRITICIDAD]) VALUES (363, CAST(N'2026-11-22T11:31:50.213' AS DateTime), N'tp', N'Seguridad', N'Inicio de sesión exitoso', 1)
INSERT [dbo].[BITACORA] ([ID_BITACORA], [FECHA], [USUARIO], [MODULO], [OPERACION], [CRITICIDAD]) VALUES (364, CAST(N'2026-11-22T11:46:16.657' AS DateTime), N'tp', N'Seguridad', N'Cierre de sesión automatico', 1)
INSERT [dbo].[BITACORA] ([ID_BITACORA], [FECHA], [USUARIO], [MODULO], [OPERACION], [CRITICIDAD]) VALUES (365, CAST(N'2026-11-22T11:52:17.603' AS DateTime), N'tp', N'Seguridad', N'Inicio de sesión exitoso', 1)
INSERT [dbo].[BITACORA] ([ID_BITACORA], [FECHA], [USUARIO], [MODULO], [OPERACION], [CRITICIDAD]) VALUES (366, CAST(N'2026-11-22T11:52:41.257' AS DateTime), N'tp', N'Administracion', N'Se asigno GESTION_CALENDARIO, dentro del rol ADMIN', 2)
INSERT [dbo].[BITACORA] ([ID_BITACORA], [FECHA], [USUARIO], [MODULO], [OPERACION], [CRITICIDAD]) VALUES (367, CAST(N'2026-11-22T11:52:50.337' AS DateTime), N'tp', N'Administracion', N'Se asigno GESTION_PRESUPUESTO, dentro del rol ADMI', 2)
INSERT [dbo].[BITACORA] ([ID_BITACORA], [FECHA], [USUARIO], [MODULO], [OPERACION], [CRITICIDAD]) VALUES (368, CAST(N'2026-11-22T11:52:52.677' AS DateTime), N'tp', N'Administracion', N'Se asigno GESTION_FICHA_TECNICA, dentro del rol AD', 2)
INSERT [dbo].[BITACORA] ([ID_BITACORA], [FECHA], [USUARIO], [MODULO], [OPERACION], [CRITICIDAD]) VALUES (369, CAST(N'2026-11-22T11:52:55.043' AS DateTime), N'tp', N'Administracion', N'Se asigno GESTION_RATIOS, dentro del rol ADMIN', 2)
INSERT [dbo].[BITACORA] ([ID_BITACORA], [FECHA], [USUARIO], [MODULO], [OPERACION], [CRITICIDAD]) VALUES (370, CAST(N'2026-11-22T11:52:56.660' AS DateTime), N'tp', N'Administracion', N'Se asigno GESTION_PERSONAL, dentro del rol ADMIN', 2)
INSERT [dbo].[BITACORA] ([ID_BITACORA], [FECHA], [USUARIO], [MODULO], [OPERACION], [CRITICIDAD]) VALUES (371, CAST(N'2026-11-22T11:52:58.507' AS DateTime), N'tp', N'Administracion', N'Se asigno VER_DASHBOARD, dentro del rol ADMIN', 2)
INSERT [dbo].[BITACORA] ([ID_BITACORA], [FECHA], [USUARIO], [MODULO], [OPERACION], [CRITICIDAD]) VALUES (372, CAST(N'2026-11-22T11:53:00.147' AS DateTime), N'tp', N'Administracion', N'Se asigno ABM_INSUMOS, dentro del rol ADMIN', 2)
INSERT [dbo].[BITACORA] ([ID_BITACORA], [FECHA], [USUARIO], [MODULO], [OPERACION], [CRITICIDAD]) VALUES (373, CAST(N'2026-11-22T11:53:01.670' AS DateTime), N'tp', N'Administracion', N'Se asigno ABM_PERSONAL, dentro del rol ADMIN', 2)
INSERT [dbo].[BITACORA] ([ID_BITACORA], [FECHA], [USUARIO], [MODULO], [OPERACION], [CRITICIDAD]) VALUES (374, CAST(N'2026-11-22T11:53:03.340' AS DateTime), N'tp', N'Administracion', N'Se asigno ABM_PROVEEDOR_INSUMO, dentro del rol ADM', 2)
INSERT [dbo].[BITACORA] ([ID_BITACORA], [FECHA], [USUARIO], [MODULO], [OPERACION], [CRITICIDAD]) VALUES (375, CAST(N'2026-11-22T11:53:05.207' AS DateTime), N'tp', N'Administracion', N'Se asigno GESTION_RECETARIO, dentro del rol ADMIN', 2)
INSERT [dbo].[BITACORA] ([ID_BITACORA], [FECHA], [USUARIO], [MODULO], [OPERACION], [CRITICIDAD]) VALUES (376, CAST(N'2026-11-22T11:53:06.793' AS DateTime), N'tp', N'Administracion', N'Se asigno GESTION_LIQUIDACION_FINAL, dentro del ro', 2)
INSERT [dbo].[BITACORA] ([ID_BITACORA], [FECHA], [USUARIO], [MODULO], [OPERACION], [CRITICIDAD]) VALUES (377, CAST(N'2026-11-22T11:53:08.617' AS DateTime), N'tp', N'Administracion', N'Se asigno ABM_CLIENTE, dentro del rol ADMIN', 2)
INSERT [dbo].[BITACORA] ([ID_BITACORA], [FECHA], [USUARIO], [MODULO], [OPERACION], [CRITICIDAD]) VALUES (378, CAST(N'2026-11-22T11:53:10.117' AS DateTime), N'tp', N'Administracion', N'Se asigno GESTION_EVALUACION, dentro del rol ADMIN', 2)
INSERT [dbo].[BITACORA] ([ID_BITACORA], [FECHA], [USUARIO], [MODULO], [OPERACION], [CRITICIDAD]) VALUES (379, CAST(N'2026-11-22T11:53:11.760' AS DateTime), N'tp', N'Administracion', N'Se asigno GESTION_ORDEN_COMPRA, dentro del rol ADM', 2)
INSERT [dbo].[BITACORA] ([ID_BITACORA], [FECHA], [USUARIO], [MODULO], [OPERACION], [CRITICIDAD]) VALUES (380, CAST(N'2026-11-22T11:53:13.557' AS DateTime), N'tp', N'Administracion', N'Se asigno GESTION_PAGO, dentro del rol ADMIN', 2)
INSERT [dbo].[BITACORA] ([ID_BITACORA], [FECHA], [USUARIO], [MODULO], [OPERACION], [CRITICIDAD]) VALUES (381, CAST(N'2026-11-22T11:53:15.517' AS DateTime), N'tp', N'Administracion', N'Se asigno GESTION_RECEPCIONAR_STOCK, dentro del ro', 2)
INSERT [dbo].[BITACORA] ([ID_BITACORA], [FECHA], [USUARIO], [MODULO], [OPERACION], [CRITICIDAD]) VALUES (382, CAST(N'2026-11-22T11:53:17.377' AS DateTime), N'tp', N'Administracion', N'Se asigno GESTION_ANULAR_REASIGNAR_ORDEN_COMPRA, d', 2)
INSERT [dbo].[BITACORA] ([ID_BITACORA], [FECHA], [USUARIO], [MODULO], [OPERACION], [CRITICIDAD]) VALUES (383, CAST(N'2026-11-22T11:54:29.860' AS DateTime), N'tp', N'Administracion', N'Se asigno GESTION_CALENDARIO, dentro del rol EJECU', 2)
INSERT [dbo].[BITACORA] ([ID_BITACORA], [FECHA], [USUARIO], [MODULO], [OPERACION], [CRITICIDAD]) VALUES (384, CAST(N'2026-11-22T11:54:42.673' AS DateTime), N'tp', N'Administracion', N'Se asigno GESTION_PRESUPUESTO, dentro del rol EJEC', 2)
INSERT [dbo].[BITACORA] ([ID_BITACORA], [FECHA], [USUARIO], [MODULO], [OPERACION], [CRITICIDAD]) VALUES (385, CAST(N'2026-11-22T11:54:55.653' AS DateTime), N'tp', N'Administracion', N'Se asigno GESTION_PAGO, dentro del rol EJECUTIVO_V', 2)
INSERT [dbo].[BITACORA] ([ID_BITACORA], [FECHA], [USUARIO], [MODULO], [OPERACION], [CRITICIDAD]) VALUES (386, CAST(N'2026-11-22T11:55:08.470' AS DateTime), N'tp', N'Administracion', N'Se asigno ABM_CLIENTE, dentro del rol EJECUTIVO_VE', 2)
INSERT [dbo].[BITACORA] ([ID_BITACORA], [FECHA], [USUARIO], [MODULO], [OPERACION], [CRITICIDAD]) VALUES (387, CAST(N'2026-11-22T11:55:19.713' AS DateTime), N'tp', N'Administracion', N'Se asigno GESTION_LIQUIDACION_FINAL, dentro del ro', 2)
INSERT [dbo].[BITACORA] ([ID_BITACORA], [FECHA], [USUARIO], [MODULO], [OPERACION], [CRITICIDAD]) VALUES (388, CAST(N'2026-11-22T11:56:03.427' AS DateTime), N'tp', N'Administracion', N'Se asigno ABM_PERSONAL, dentro del rol EJECUTIVO_V', 2)
INSERT [dbo].[BITACORA] ([ID_BITACORA], [FECHA], [USUARIO], [MODULO], [OPERACION], [CRITICIDAD]) VALUES (389, CAST(N'2026-11-22T14:23:19.870' AS DateTime), N'tp', N'Administracion', N'Se asigno GESTION_RECEPCIONAR_STOCK, dentro del ro', 2)
INSERT [dbo].[BITACORA] ([ID_BITACORA], [FECHA], [USUARIO], [MODULO], [OPERACION], [CRITICIDAD]) VALUES (390, CAST(N'2026-11-22T14:23:36.303' AS DateTime), N'tp', N'Administracion', N'Se asigno CONSULTAR_STOCK, dentro del rol ENCARGAD', 2)
INSERT [dbo].[BITACORA] ([ID_BITACORA], [FECHA], [USUARIO], [MODULO], [OPERACION], [CRITICIDAD]) VALUES (391, CAST(N'2026-11-22T14:23:45.270' AS DateTime), N'tp', N'Administracion', N'Se asigno GESTION_EVALUACION, dentro del rol ENCAR', 2)
INSERT [dbo].[BITACORA] ([ID_BITACORA], [FECHA], [USUARIO], [MODULO], [OPERACION], [CRITICIDAD]) VALUES (392, CAST(N'2026-11-22T14:24:55.853' AS DateTime), N'tp', N'Administracion', N'Se asigno GESTION_RATIOS, dentro del rol GERENTE_O', 2)
INSERT [dbo].[BITACORA] ([ID_BITACORA], [FECHA], [USUARIO], [MODULO], [OPERACION], [CRITICIDAD]) VALUES (393, CAST(N'2026-11-22T14:25:10.347' AS DateTime), N'tp', N'Administracion', N'Se asigno CONSULTAR_STOCK, dentro del rol GERENTE_', 2)
INSERT [dbo].[BITACORA] ([ID_BITACORA], [FECHA], [USUARIO], [MODULO], [OPERACION], [CRITICIDAD]) VALUES (394, CAST(N'2026-11-22T14:25:21.707' AS DateTime), N'tp', N'Administracion', N'Se asigno GESTION_ANULAR_REASIGNAR_ORDEN_COMPRA, d', 2)
INSERT [dbo].[BITACORA] ([ID_BITACORA], [FECHA], [USUARIO], [MODULO], [OPERACION], [CRITICIDAD]) VALUES (395, CAST(N'2026-11-22T14:25:27.467' AS DateTime), N'tp', N'Administracion', N'Se asigno VER_DASHBOARD, dentro del rol GERENTE_OP', 2)
INSERT [dbo].[BITACORA] ([ID_BITACORA], [FECHA], [USUARIO], [MODULO], [OPERACION], [CRITICIDAD]) VALUES (396, CAST(N'2026-11-22T14:25:37.253' AS DateTime), N'tp', N'Administracion', N'Se asigno ABM_PROVEEDOR_INSUMO, dentro del rol GER', 2)
INSERT [dbo].[BITACORA] ([ID_BITACORA], [FECHA], [USUARIO], [MODULO], [OPERACION], [CRITICIDAD]) VALUES (397, CAST(N'2026-11-22T14:25:48.447' AS DateTime), N'tp', N'Administracion', N'Se asigno GESTION_PERSONAL, dentro del rol GERENTE', 2)
INSERT [dbo].[BITACORA] ([ID_BITACORA], [FECHA], [USUARIO], [MODULO], [OPERACION], [CRITICIDAD]) VALUES (398, CAST(N'2026-11-22T14:26:04.413' AS DateTime), N'tp', N'Administracion', N'Se asigno GESTION_EVALUACION, dentro del rol GEREN', 2)
INSERT [dbo].[BITACORA] ([ID_BITACORA], [FECHA], [USUARIO], [MODULO], [OPERACION], [CRITICIDAD]) VALUES (399, CAST(N'2026-11-22T15:01:16.553' AS DateTime), N'tp', N'Administracion', N'Se asigno GESTION_CALENDARIO, dentro del rol ORGAN', 2)
INSERT [dbo].[BITACORA] ([ID_BITACORA], [FECHA], [USUARIO], [MODULO], [OPERACION], [CRITICIDAD]) VALUES (400, CAST(N'2026-11-22T15:01:23.417' AS DateTime), N'tp', N'Administracion', N'Se asigno GESTION_FICHA_TECNICA, dentro del rol OR', 2)
GO
INSERT [dbo].[BITACORA] ([ID_BITACORA], [FECHA], [USUARIO], [MODULO], [OPERACION], [CRITICIDAD]) VALUES (401, CAST(N'2026-11-22T15:01:37.723' AS DateTime), N'tp', N'Administracion', N'Se asigno GESTION_RECETARIO, dentro del rol ORGANI', 2)
INSERT [dbo].[BITACORA] ([ID_BITACORA], [FECHA], [USUARIO], [MODULO], [OPERACION], [CRITICIDAD]) VALUES (402, CAST(N'2026-11-22T15:01:54.993' AS DateTime), N'tp', N'Administracion', N'Se asigno ABM_CLIENTE, dentro del rol ORGANIZADOR_', 2)
INSERT [dbo].[BITACORA] ([ID_BITACORA], [FECHA], [USUARIO], [MODULO], [OPERACION], [CRITICIDAD]) VALUES (403, CAST(N'2026-11-22T15:02:10.380' AS DateTime), N'tp', N'Seguridad', N'Cierre de sesión automatico', 1)
INSERT [dbo].[BITACORA] ([ID_BITACORA], [FECHA], [USUARIO], [MODULO], [OPERACION], [CRITICIDAD]) VALUES (404, CAST(N'2026-11-22T21:35:45.720' AS DateTime), N'tp', N'Seguridad', N'Inicio de sesión exitoso', 1)
INSERT [dbo].[BITACORA] ([ID_BITACORA], [FECHA], [USUARIO], [MODULO], [OPERACION], [CRITICIDAD]) VALUES (405, CAST(N'2026-11-22T21:42:53.977' AS DateTime), N'tp', N'Seguridad', N'Cierre de sesión automatico', 1)
INSERT [dbo].[BITACORA] ([ID_BITACORA], [FECHA], [USUARIO], [MODULO], [OPERACION], [CRITICIDAD]) VALUES (406, CAST(N'2026-11-22T22:15:56.950' AS DateTime), N'tp', N'Seguridad', N'Inicio de sesión exitoso', 1)
INSERT [dbo].[BITACORA] ([ID_BITACORA], [FECHA], [USUARIO], [MODULO], [OPERACION], [CRITICIDAD]) VALUES (407, CAST(N'2026-11-22T22:18:20.503' AS DateTime), N'tp', N'Seguridad', N'Cierre de sesión automatico', 1)
INSERT [dbo].[BITACORA] ([ID_BITACORA], [FECHA], [USUARIO], [MODULO], [OPERACION], [CRITICIDAD]) VALUES (408, CAST(N'2026-11-22T22:19:05.227' AS DateTime), N'tp', N'Seguridad', N'Inicio de sesión exitoso', 1)
INSERT [dbo].[BITACORA] ([ID_BITACORA], [FECHA], [USUARIO], [MODULO], [OPERACION], [CRITICIDAD]) VALUES (409, CAST(N'2026-11-22T22:19:51.173' AS DateTime), N'tp', N'Administracion', N'Se modificó al usuario: mg', 3)
INSERT [dbo].[BITACORA] ([ID_BITACORA], [FECHA], [USUARIO], [MODULO], [OPERACION], [CRITICIDAD]) VALUES (410, CAST(N'2026-11-22T22:20:15.413' AS DateTime), N'tp', N'Seguridad', N'Cierre de sesión manual', 1)
INSERT [dbo].[BITACORA] ([ID_BITACORA], [FECHA], [USUARIO], [MODULO], [OPERACION], [CRITICIDAD]) VALUES (411, CAST(N'2026-11-22T22:20:18.903' AS DateTime), N'mg', N'Seguridad', N'Inicio de sesión exitoso', 1)
INSERT [dbo].[BITACORA] ([ID_BITACORA], [FECHA], [USUARIO], [MODULO], [OPERACION], [CRITICIDAD]) VALUES (412, CAST(N'2026-11-22T22:21:25.993' AS DateTime), N'mg', N'Seguridad', N'Cierre de sesión manual', 1)
INSERT [dbo].[BITACORA] ([ID_BITACORA], [FECHA], [USUARIO], [MODULO], [OPERACION], [CRITICIDAD]) VALUES (413, CAST(N'2026-11-22T22:21:28.923' AS DateTime), N'tp', N'Seguridad', N'Inicio de sesión exitoso', 1)
INSERT [dbo].[BITACORA] ([ID_BITACORA], [FECHA], [USUARIO], [MODULO], [OPERACION], [CRITICIDAD]) VALUES (414, CAST(N'2026-11-22T22:21:52.890' AS DateTime), N'tp', N'Seguridad', N'Cierre de sesión automatico', 1)
INSERT [dbo].[BITACORA] ([ID_BITACORA], [FECHA], [USUARIO], [MODULO], [OPERACION], [CRITICIDAD]) VALUES (415, CAST(N'2026-11-22T22:22:43.343' AS DateTime), N'tp', N'Seguridad', N'Inicio de sesión exitoso', 1)
INSERT [dbo].[BITACORA] ([ID_BITACORA], [FECHA], [USUARIO], [MODULO], [OPERACION], [CRITICIDAD]) VALUES (416, CAST(N'2026-11-22T22:29:12.503' AS DateTime), N'tp', N'Seguridad', N'Inicio de sesión exitoso', 1)
INSERT [dbo].[BITACORA] ([ID_BITACORA], [FECHA], [USUARIO], [MODULO], [OPERACION], [CRITICIDAD]) VALUES (417, CAST(N'2026-11-22T22:29:19.877' AS DateTime), N'tp', N'Seguridad', N'Cierre de sesión automatico', 1)
INSERT [dbo].[BITACORA] ([ID_BITACORA], [FECHA], [USUARIO], [MODULO], [OPERACION], [CRITICIDAD]) VALUES (418, CAST(N'2026-11-22T23:26:13.260' AS DateTime), N'tp', N'Seguridad', N'Inicio de sesión exitoso', 1)
INSERT [dbo].[BITACORA] ([ID_BITACORA], [FECHA], [USUARIO], [MODULO], [OPERACION], [CRITICIDAD]) VALUES (419, CAST(N'2026-11-22T23:26:17.197' AS DateTime), N'tp', N'Seguridad', N'Cierre de sesión automatico', 1)
INSERT [dbo].[BITACORA] ([ID_BITACORA], [FECHA], [USUARIO], [MODULO], [OPERACION], [CRITICIDAD]) VALUES (420, CAST(N'2026-11-22T23:26:45.187' AS DateTime), N'tp', N'Seguridad', N'Inicio de sesión exitoso', 1)
INSERT [dbo].[BITACORA] ([ID_BITACORA], [FECHA], [USUARIO], [MODULO], [OPERACION], [CRITICIDAD]) VALUES (421, CAST(N'2026-11-22T23:26:48.213' AS DateTime), N'tp', N'Seguridad', N'Cierre de sesión automatico', 1)
INSERT [dbo].[BITACORA] ([ID_BITACORA], [FECHA], [USUARIO], [MODULO], [OPERACION], [CRITICIDAD]) VALUES (422, CAST(N'2026-11-22T23:27:21.483' AS DateTime), N'tp', N'Seguridad', N'Inicio de sesión exitoso', 1)
INSERT [dbo].[BITACORA] ([ID_BITACORA], [FECHA], [USUARIO], [MODULO], [OPERACION], [CRITICIDAD]) VALUES (423, CAST(N'2026-11-22T23:27:41.743' AS DateTime), N'tp', N'Seguridad', N'Inicio de sesión exitoso', 1)
INSERT [dbo].[BITACORA] ([ID_BITACORA], [FECHA], [USUARIO], [MODULO], [OPERACION], [CRITICIDAD]) VALUES (424, CAST(N'2026-11-22T23:28:01.977' AS DateTime), N'tp', N'Seguridad', N'Cierre de sesión automatico', 1)
INSERT [dbo].[BITACORA] ([ID_BITACORA], [FECHA], [USUARIO], [MODULO], [OPERACION], [CRITICIDAD]) VALUES (425, CAST(N'2026-11-22T23:28:06.547' AS DateTime), N'mg', N'Seguridad', N'Inicio de sesión exitoso', 1)
INSERT [dbo].[BITACORA] ([ID_BITACORA], [FECHA], [USUARIO], [MODULO], [OPERACION], [CRITICIDAD]) VALUES (426, CAST(N'2026-11-22T23:28:25.813' AS DateTime), N'mg', N'Seguridad', N'Cierre de sesión manual', 1)
INSERT [dbo].[BITACORA] ([ID_BITACORA], [FECHA], [USUARIO], [MODULO], [OPERACION], [CRITICIDAD]) VALUES (427, CAST(N'2026-11-22T23:30:35.537' AS DateTime), N'tp', N'Seguridad', N'Inicio de sesión exitoso', 1)
INSERT [dbo].[BITACORA] ([ID_BITACORA], [FECHA], [USUARIO], [MODULO], [OPERACION], [CRITICIDAD]) VALUES (428, CAST(N'2026-11-22T23:30:37.343' AS DateTime), N'tp', N'Seguridad', N'Cierre de sesión automatico', 1)
INSERT [dbo].[BITACORA] ([ID_BITACORA], [FECHA], [USUARIO], [MODULO], [OPERACION], [CRITICIDAD]) VALUES (429, CAST(N'2026-11-22T23:30:45.217' AS DateTime), N'tp', N'Seguridad', N'Inicio de sesión exitoso', 1)
INSERT [dbo].[BITACORA] ([ID_BITACORA], [FECHA], [USUARIO], [MODULO], [OPERACION], [CRITICIDAD]) VALUES (430, CAST(N'2026-11-22T23:30:53.953' AS DateTime), N'tp', N'Administracion', N'Se asigno CONSULTAR_STOCK, dentro del rol ADMIN', 2)
INSERT [dbo].[BITACORA] ([ID_BITACORA], [FECHA], [USUARIO], [MODULO], [OPERACION], [CRITICIDAD]) VALUES (431, CAST(N'2026-11-22T23:31:01.680' AS DateTime), N'tp', N'Seguridad', N'Cierre de sesión manual', 1)
INSERT [dbo].[BITACORA] ([ID_BITACORA], [FECHA], [USUARIO], [MODULO], [OPERACION], [CRITICIDAD]) VALUES (432, CAST(N'2026-11-22T23:31:07.677' AS DateTime), N'tp', N'Seguridad', N'Inicio de sesión exitoso', 1)
INSERT [dbo].[BITACORA] ([ID_BITACORA], [FECHA], [USUARIO], [MODULO], [OPERACION], [CRITICIDAD]) VALUES (433, CAST(N'2026-11-22T23:31:12.757' AS DateTime), N'tp', N'Seguridad', N'Cierre de sesión automatico', 1)
INSERT [dbo].[BITACORA] ([ID_BITACORA], [FECHA], [USUARIO], [MODULO], [OPERACION], [CRITICIDAD]) VALUES (434, CAST(N'2026-11-22T23:31:27.697' AS DateTime), N'mg', N'Seguridad', N'Inicio de sesión exitoso', 1)
INSERT [dbo].[BITACORA] ([ID_BITACORA], [FECHA], [USUARIO], [MODULO], [OPERACION], [CRITICIDAD]) VALUES (435, CAST(N'2026-11-22T23:31:33.467' AS DateTime), N'mg', N'Seguridad', N'Cierre de sesión automatico', 1)
INSERT [dbo].[BITACORA] ([ID_BITACORA], [FECHA], [USUARIO], [MODULO], [OPERACION], [CRITICIDAD]) VALUES (436, CAST(N'2026-11-24T19:24:37.883' AS DateTime), N'mg', N'Seguridad', N'Inicio de sesión exitoso', 1)
INSERT [dbo].[BITACORA] ([ID_BITACORA], [FECHA], [USUARIO], [MODULO], [OPERACION], [CRITICIDAD]) VALUES (437, CAST(N'2026-11-24T19:24:46.447' AS DateTime), N'mg', N'Seguridad', N'Cierre de sesión manual', 1)
INSERT [dbo].[BITACORA] ([ID_BITACORA], [FECHA], [USUARIO], [MODULO], [OPERACION], [CRITICIDAD]) VALUES (438, CAST(N'2026-11-24T19:24:48.260' AS DateTime), N'tp', N'Seguridad', N'Inicio de sesión exitoso', 1)
INSERT [dbo].[BITACORA] ([ID_BITACORA], [FECHA], [USUARIO], [MODULO], [OPERACION], [CRITICIDAD]) VALUES (439, CAST(N'2026-11-24T19:27:16.357' AS DateTime), N'tp', N'Seguridad', N'Inicio de sesión exitoso', 1)
INSERT [dbo].[BITACORA] ([ID_BITACORA], [FECHA], [USUARIO], [MODULO], [OPERACION], [CRITICIDAD]) VALUES (440, CAST(N'2026-11-24T19:27:17.463' AS DateTime), N'tp', N'Seguridad', N'Cierre de sesión automatico', 1)
INSERT [dbo].[BITACORA] ([ID_BITACORA], [FECHA], [USUARIO], [MODULO], [OPERACION], [CRITICIDAD]) VALUES (441, CAST(N'2026-11-24T19:34:41.117' AS DateTime), N'tp', N'Seguridad', N'Inicio de sesión exitoso', 1)
INSERT [dbo].[BITACORA] ([ID_BITACORA], [FECHA], [USUARIO], [MODULO], [OPERACION], [CRITICIDAD]) VALUES (442, CAST(N'2026-11-24T19:34:59.703' AS DateTime), N'tp', N'Seguridad', N'Cierre de sesión automatico', 1)
INSERT [dbo].[BITACORA] ([ID_BITACORA], [FECHA], [USUARIO], [MODULO], [OPERACION], [CRITICIDAD]) VALUES (443, CAST(N'2026-11-24T19:35:36.990' AS DateTime), N'tp', N'Seguridad', N'Inicio de sesión exitoso', 1)
INSERT [dbo].[BITACORA] ([ID_BITACORA], [FECHA], [USUARIO], [MODULO], [OPERACION], [CRITICIDAD]) VALUES (444, CAST(N'2026-11-24T19:35:47.287' AS DateTime), N'tp', N'Seguridad', N'Cierre de sesión automatico', 1)
INSERT [dbo].[BITACORA] ([ID_BITACORA], [FECHA], [USUARIO], [MODULO], [OPERACION], [CRITICIDAD]) VALUES (445, CAST(N'2026-11-24T19:40:23.660' AS DateTime), N'Usuario no autenticado', N'Seguridad', N'Intento de acceso con usuario inexistente:', 3)
INSERT [dbo].[BITACORA] ([ID_BITACORA], [FECHA], [USUARIO], [MODULO], [OPERACION], [CRITICIDAD]) VALUES (446, CAST(N'2026-11-24T19:40:25.953' AS DateTime), N'tp', N'Seguridad', N'Inicio de sesión exitoso', 1)
INSERT [dbo].[BITACORA] ([ID_BITACORA], [FECHA], [USUARIO], [MODULO], [OPERACION], [CRITICIDAD]) VALUES (447, CAST(N'2026-11-24T19:40:34.177' AS DateTime), N'tp', N'Seguridad', N'Cierre de sesión manual', 1)
INSERT [dbo].[BITACORA] ([ID_BITACORA], [FECHA], [USUARIO], [MODULO], [OPERACION], [CRITICIDAD]) VALUES (448, CAST(N'2026-11-24T19:40:37.780' AS DateTime), N'mg', N'Seguridad', N'Inicio de sesión exitoso', 1)
INSERT [dbo].[BITACORA] ([ID_BITACORA], [FECHA], [USUARIO], [MODULO], [OPERACION], [CRITICIDAD]) VALUES (449, CAST(N'2026-11-24T19:41:21.193' AS DateTime), N'mg', N'Seguridad', N'Cierre de sesión manual', 1)
INSERT [dbo].[BITACORA] ([ID_BITACORA], [FECHA], [USUARIO], [MODULO], [OPERACION], [CRITICIDAD]) VALUES (450, CAST(N'2026-11-24T19:41:23.290' AS DateTime), N'tp', N'Seguridad', N'Inicio de sesión exitoso', 1)
INSERT [dbo].[BITACORA] ([ID_BITACORA], [FECHA], [USUARIO], [MODULO], [OPERACION], [CRITICIDAD]) VALUES (451, CAST(N'2026-11-24T19:42:04.157' AS DateTime), N'tp', N'Administracion', N'Se modificó al usuario: mg', 3)
INSERT [dbo].[BITACORA] ([ID_BITACORA], [FECHA], [USUARIO], [MODULO], [OPERACION], [CRITICIDAD]) VALUES (452, CAST(N'2026-11-24T19:42:10.410' AS DateTime), N'tp', N'Seguridad', N'Cierre de sesión manual', 1)
INSERT [dbo].[BITACORA] ([ID_BITACORA], [FECHA], [USUARIO], [MODULO], [OPERACION], [CRITICIDAD]) VALUES (453, CAST(N'2026-11-24T19:42:12.793' AS DateTime), N'mg', N'Seguridad', N'Inicio de sesión exitoso', 1)
INSERT [dbo].[BITACORA] ([ID_BITACORA], [FECHA], [USUARIO], [MODULO], [OPERACION], [CRITICIDAD]) VALUES (454, CAST(N'2026-11-24T19:42:38.150' AS DateTime), N'mg', N'Seguridad', N'Cierre de sesión manual', 1)
INSERT [dbo].[BITACORA] ([ID_BITACORA], [FECHA], [USUARIO], [MODULO], [OPERACION], [CRITICIDAD]) VALUES (455, CAST(N'2026-11-24T19:42:40.363' AS DateTime), N'tp', N'Seguridad', N'Inicio de sesión exitoso', 1)
INSERT [dbo].[BITACORA] ([ID_BITACORA], [FECHA], [USUARIO], [MODULO], [OPERACION], [CRITICIDAD]) VALUES (456, CAST(N'2026-11-24T19:42:59.130' AS DateTime), N'tp', N'Seguridad', N'Cierre de sesión manual', 1)
INSERT [dbo].[BITACORA] ([ID_BITACORA], [FECHA], [USUARIO], [MODULO], [OPERACION], [CRITICIDAD]) VALUES (457, CAST(N'2026-11-24T19:43:01.420' AS DateTime), N'mg', N'Seguridad', N'Inicio de sesión exitoso', 1)
INSERT [dbo].[BITACORA] ([ID_BITACORA], [FECHA], [USUARIO], [MODULO], [OPERACION], [CRITICIDAD]) VALUES (458, CAST(N'2026-11-24T19:43:20.697' AS DateTime), N'mg', N'Seguridad', N'Cierre de sesión manual', 1)
INSERT [dbo].[BITACORA] ([ID_BITACORA], [FECHA], [USUARIO], [MODULO], [OPERACION], [CRITICIDAD]) VALUES (459, CAST(N'2026-11-24T19:43:23.583' AS DateTime), N'tp', N'Seguridad', N'Inicio de sesión exitoso', 1)
INSERT [dbo].[BITACORA] ([ID_BITACORA], [FECHA], [USUARIO], [MODULO], [OPERACION], [CRITICIDAD]) VALUES (460, CAST(N'2026-11-24T19:44:56.380' AS DateTime), N'tp', N'Seguridad', N'Cierre de sesión automatico', 1)
INSERT [dbo].[BITACORA] ([ID_BITACORA], [FECHA], [USUARIO], [MODULO], [OPERACION], [CRITICIDAD]) VALUES (461, CAST(N'2026-11-24T19:45:18.320' AS DateTime), N'tp', N'Seguridad', N'Inicio de sesión exitoso', 1)
INSERT [dbo].[BITACORA] ([ID_BITACORA], [FECHA], [USUARIO], [MODULO], [OPERACION], [CRITICIDAD]) VALUES (462, CAST(N'2026-11-24T19:45:27.647' AS DateTime), N'tp', N'Seguridad', N'Cierre de sesión automatico', 1)
GO
SET IDENTITY_INSERT [dbo].[CLIENTE] ON 

INSERT [dbo].[CLIENTE] ([Id_Cliente], [Nombre_Completo], [Telefono], [Email], [Dni]) VALUES (1, N'Cacho Castaña', 1123094990, N'homero@gmail.com', 12349489)
INSERT [dbo].[CLIENTE] ([Id_Cliente], [Nombre_Completo], [Telefono], [Email], [Dni]) VALUES (2, N'Hector Valbuena', 141414, N'barsinso@gmail.com', 22222)
INSERT [dbo].[CLIENTE] ([Id_Cliente], [Nombre_Completo], [Telefono], [Email], [Dni]) VALUES (3, N'Nicole Ramirez', 1135986789, N'nicolr2213@gmail.com', 42661512)
INSERT [dbo].[CLIENTE] ([Id_Cliente], [Nombre_Completo], [Telefono], [Email], [Dni]) VALUES (4, N'Matias Gramajo', 1512030230, N'matias.gramajo123@gmail.com', 421001430)
INSERT [dbo].[CLIENTE] ([Id_Cliente], [Nombre_Completo], [Telefono], [Email], [Dni]) VALUES (5, N'Laura Fernández', 1144556677, N'laura.fernandez@gmail.com', 35123456)
INSERT [dbo].[CLIENTE] ([Id_Cliente], [Nombre_Completo], [Telefono], [Email], [Dni]) VALUES (6, N'Carlos Gómez', 1133221100, N'carlos.gomez@gmail.com', 28987654)
INSERT [dbo].[CLIENTE] ([Id_Cliente], [Nombre_Completo], [Telefono], [Email], [Dni]) VALUES (7, N'Empresa Tech S.A.', 1155667788, N'eventos@techsa.com', 30712345)
INSERT [dbo].[CLIENTE] ([Id_Cliente], [Nombre_Completo], [Telefono], [Email], [Dni]) VALUES (8, N'Martín Palermo', 1166778899, N'martin.palermo@gmail.com', 25111222)
INSERT [dbo].[CLIENTE] ([Id_Cliente], [Nombre_Completo], [Telefono], [Email], [Dni]) VALUES (9, N'Sofia Martinez', 1144332211, N'sofia.martinez@hotmail.com', 33444555)
INSERT [dbo].[CLIENTE] ([Id_Cliente], [Nombre_Completo], [Telefono], [Email], [Dni]) VALUES (10, N'Grupo Financiero Sur S.A.', 1155443322, N'eventos@finansur.com', 30708899)
INSERT [dbo].[CLIENTE] ([Id_Cliente], [Nombre_Completo], [Telefono], [Email], [Dni]) VALUES (11, N'Lucía Pereyra', 1122334455, N'lucia.pereyra@yahoo.com', 31222333)
INSERT [dbo].[CLIENTE] ([Id_Cliente], [Nombre_Completo], [Telefono], [Email], [Dni]) VALUES (12, N'Esteban Quito', 1199887766, N'esteban.quito@gmail.com', 27888999)
INSERT [dbo].[CLIENTE] ([Id_Cliente], [Nombre_Completo], [Telefono], [Email], [Dni]) VALUES (13, N'Mariana Rossi', 1122114455, N'mariana.rossi@gmail.com', 29444333)
INSERT [dbo].[CLIENTE] ([Id_Cliente], [Nombre_Completo], [Telefono], [Email], [Dni]) VALUES (14, N'Javier Zanetti', 1133445566, N'j.zanetti@hotmail.com', 24111999)
INSERT [dbo].[CLIENTE] ([Id_Cliente], [Nombre_Completo], [Telefono], [Email], [Dni]) VALUES (15, N'Telecom Argentina S.A.', 1144556688, N'eventos@telecom.com.ar', 30701122)
INSERT [dbo].[CLIENTE] ([Id_Cliente], [Nombre_Completo], [Telefono], [Email], [Dni]) VALUES (16, N'Gonzalo Higuaín', 1155667799, N'ghiguain@gmail.com', 32888777)
INSERT [dbo].[CLIENTE] ([Id_Cliente], [Nombre_Completo], [Telefono], [Email], [Dni]) VALUES (17, N'Banco Galicia S.A.', 1166778800, N'institucional@bancogalicia.com.ar', 30500011)
INSERT [dbo].[CLIENTE] ([Id_Cliente], [Nombre_Completo], [Telefono], [Email], [Dni]) VALUES (18, N'Romina Gaetani', 1177889911, N'romina.gaetani@yahoo.com', 28333444)
INSERT [dbo].[CLIENTE] ([Id_Cliente], [Nombre_Completo], [Telefono], [Email], [Dni]) VALUES (19, N'Gabriel Batistuta', 1188990022, N'gabriel.bati@gmail.com', 21555666)
INSERT [dbo].[CLIENTE] ([Id_Cliente], [Nombre_Completo], [Telefono], [Email], [Dni]) VALUES (20, N'Eventos Globales SRL', 1199001133, N'contacto@eventosglobales.com', 30715544)
INSERT [dbo].[CLIENTE] ([Id_Cliente], [Nombre_Completo], [Telefono], [Email], [Dni]) VALUES (21, N'Andrea Frigerio', 1122003344, N'afrigerio@gmail.com', 23666777)
INSERT [dbo].[CLIENTE] ([Id_Cliente], [Nombre_Completo], [Telefono], [Email], [Dni]) VALUES (22, N'Marcelo Tinelli', 1133112233, N'mtinelli@laflia.com', 18999000)
INSERT [dbo].[CLIENTE] ([Id_Cliente], [Nombre_Completo], [Telefono], [Email], [Dni]) VALUES (23, N'Fernando Gago', 1122338899, N'fgago@gmail.com', 31555444)
INSERT [dbo].[CLIENTE] ([Id_Cliente], [Nombre_Completo], [Telefono], [Email], [Dni]) VALUES (24, N'Patricia Sosa', 1133449900, N'psosa@hotmail.com', 22111333)
INSERT [dbo].[CLIENTE] ([Id_Cliente], [Nombre_Completo], [Telefono], [Email], [Dni]) VALUES (25, N'Consultora B&B S.A.', 1144550011, N'eventos@consultorabyb.com', 30718899)
INSERT [dbo].[CLIENTE] ([Id_Cliente], [Nombre_Completo], [Telefono], [Email], [Dni]) VALUES (26, N'Diego Latorre', 1155661122, N'diegolatorre@gmail.com', 20444555)
INSERT [dbo].[CLIENTE] ([Id_Cliente], [Nombre_Completo], [Telefono], [Email], [Dni]) VALUES (27, N'Fundación Esperanza', 1166772233, N'contacto@fundacionesperanza.org', 30699887)
INSERT [dbo].[CLIENTE] ([Id_Cliente], [Nombre_Completo], [Telefono], [Email], [Dni]) VALUES (28, N'Claudia Villafañe', 1177883344, N'claudia.v@gmail.com', 17888999)
INSERT [dbo].[CLIENTE] ([Id_Cliente], [Nombre_Completo], [Telefono], [Email], [Dni]) VALUES (29, N'Agustín Pichot', 1188994455, N'apichot@rugby.com', 23999111)
INSERT [dbo].[CLIENTE] ([Id_Cliente], [Nombre_Completo], [Telefono], [Email], [Dni]) VALUES (30, N'Laboratorios Bagó S.A.', 1199005566, N'institucional@bago.com.ar', 30501122)
INSERT [dbo].[CLIENTE] ([Id_Cliente], [Nombre_Completo], [Telefono], [Email], [Dni]) VALUES (31, N'Valeria Mazza', 1122116677, N'vmazza@gmail.com', 22777888)
INSERT [dbo].[CLIENTE] ([Id_Cliente], [Nombre_Completo], [Telefono], [Email], [Dni]) VALUES (32, N'Marcos Maidana', 1133227788, N'chino.maidana@gmail.com', 29888111)
INSERT [dbo].[CLIENTE] ([Id_Cliente], [Nombre_Completo], [Telefono], [Email], [Dni]) VALUES (33, N'Carolina Ardohain', 1144112233, N'pampita@gmail.com', 26111222)
INSERT [dbo].[CLIENTE] ([Id_Cliente], [Nombre_Completo], [Telefono], [Email], [Dni]) VALUES (34, N'Guillermo Francella', 1155223344, N'gfrancella@hotmail.com', 16333444)
INSERT [dbo].[CLIENTE] ([Id_Cliente], [Nombre_Completo], [Telefono], [Email], [Dni]) VALUES (35, N'Fundación San Martín', 1166334455, N'contacto@sanmartin.org', 30721100)
INSERT [dbo].[CLIENTE] ([Id_Cliente], [Nombre_Completo], [Telefono], [Email], [Dni]) VALUES (36, N'Nicolás Cabré', 1177445566, N'ncabre@gmail.com', 27999888)
INSERT [dbo].[CLIENTE] ([Id_Cliente], [Nombre_Completo], [Telefono], [Email], [Dni]) VALUES (37, N'Grupo Arcor S.A.', 1188556677, N'eventos@arcor.com', 30502233)
INSERT [dbo].[CLIENTE] ([Id_Cliente], [Nombre_Completo], [Telefono], [Email], [Dni]) VALUES (38, N'Federico Ramirez', 14141, N'asdsasd', 123923949)
INSERT [dbo].[CLIENTE] ([Id_Cliente], [Nombre_Completo], [Telefono], [Email], [Dni]) VALUES (39, N'Natalia Oreiro', 1133445522, N'noreiro@hotmail.com', 25666777)
INSERT [dbo].[CLIENTE] ([Id_Cliente], [Nombre_Completo], [Telefono], [Email], [Dni]) VALUES (40, N'Sindicato de Comercio', 1144556633, N'eventos@comercio.org.ar', 30503344)
INSERT [dbo].[CLIENTE] ([Id_Cliente], [Nombre_Completo], [Telefono], [Email], [Dni]) VALUES (41, N'Diego Peretti', 1155667744, N'dperetti@gmail.com', 18777888)
INSERT [dbo].[CLIENTE] ([Id_Cliente], [Nombre_Completo], [Telefono], [Email], [Dni]) VALUES (42, N'Guillermo Francella', 1122446688, N'gfrancella@gmail.com', 16444555)
INSERT [dbo].[CLIENTE] ([Id_Cliente], [Nombre_Completo], [Telefono], [Email], [Dni]) VALUES (43, N'Mirtha Legrand', 1133557799, N'mlegrand@hotmail.com', 10111222)
INSERT [dbo].[CLIENTE] ([Id_Cliente], [Nombre_Completo], [Telefono], [Email], [Dni]) VALUES (44, N'Adrián Suar', 1144556677, N'asuar@gmail.com', 18111222)
INSERT [dbo].[CLIENTE] ([Id_Cliente], [Nombre_Completo], [Telefono], [Email], [Dni]) VALUES (45, N'Valeria Mazza', 1155667788, N'vmazza@hotmail.com', 22333444)
INSERT [dbo].[CLIENTE] ([Id_Cliente], [Nombre_Completo], [Telefono], [Email], [Dni]) VALUES (46, N'Techint S.A.', 1166778899, N'eventos@techint.com', 30501122)
INSERT [dbo].[CLIENTE] ([Id_Cliente], [Nombre_Completo], [Telefono], [Email], [Dni]) VALUES (47, N'Marcelo Tinelli', 1177889900, N'mtinelli@gmail.com', 17444555)
INSERT [dbo].[CLIENTE] ([Id_Cliente], [Nombre_Completo], [Telefono], [Email], [Dni]) VALUES (48, N'Banco Galicia', 1188990011, N'institucional@galicia.com.ar', 30504455)
INSERT [dbo].[CLIENTE] ([Id_Cliente], [Nombre_Completo], [Telefono], [Email], [Dni]) VALUES (49, N'Chino Darín', 1133221100, N'chinodarin@gmail.com', 32111222)
INSERT [dbo].[CLIENTE] ([Id_Cliente], [Nombre_Completo], [Telefono], [Email], [Dni]) VALUES (50, N'Susana Giménez', 1122113300, N'sgimenez@hotmail.com', 12333444)
INSERT [dbo].[CLIENTE] ([Id_Cliente], [Nombre_Completo], [Telefono], [Email], [Dni]) VALUES (51, N'Globant S.A.', 1144332211, N'eventos@globant.com', 30708899)
INSERT [dbo].[CLIENTE] ([Id_Cliente], [Nombre_Completo], [Telefono], [Email], [Dni]) VALUES (52, N'Cliente Evento 1', 1140000001, N'cliente.evento1@gmail.com', 30000001)
INSERT [dbo].[CLIENTE] ([Id_Cliente], [Nombre_Completo], [Telefono], [Email], [Dni]) VALUES (53, N'Cliente Evento 2', 1140000002, N'cliente.evento2@gmail.com', 30000002)
INSERT [dbo].[CLIENTE] ([Id_Cliente], [Nombre_Completo], [Telefono], [Email], [Dni]) VALUES (54, N'Cliente Evento 3', 1140000003, N'cliente.evento3@gmail.com', 30000003)
INSERT [dbo].[CLIENTE] ([Id_Cliente], [Nombre_Completo], [Telefono], [Email], [Dni]) VALUES (55, N'Cliente Evento 4', 1140000004, N'cliente.evento4@gmail.com', 30000004)
INSERT [dbo].[CLIENTE] ([Id_Cliente], [Nombre_Completo], [Telefono], [Email], [Dni]) VALUES (56, N'Cliente Evento 5', 1140000005, N'cliente.evento5@gmail.com', 30000005)
INSERT [dbo].[CLIENTE] ([Id_Cliente], [Nombre_Completo], [Telefono], [Email], [Dni]) VALUES (57, N'Cliente Evento 6', 1140000006, N'cliente.evento6@gmail.com', 30000006)
INSERT [dbo].[CLIENTE] ([Id_Cliente], [Nombre_Completo], [Telefono], [Email], [Dni]) VALUES (58, N'Cliente Evento 7', 1140000007, N'cliente.evento7@gmail.com', 30000007)
INSERT [dbo].[CLIENTE] ([Id_Cliente], [Nombre_Completo], [Telefono], [Email], [Dni]) VALUES (59, N'Cliente Evento 8', 1140000008, N'cliente.evento8@gmail.com', 30000008)
INSERT [dbo].[CLIENTE] ([Id_Cliente], [Nombre_Completo], [Telefono], [Email], [Dni]) VALUES (60, N'Cliente Evento 9', 1140000009, N'cliente.evento9@gmail.com', 30000009)
INSERT [dbo].[CLIENTE] ([Id_Cliente], [Nombre_Completo], [Telefono], [Email], [Dni]) VALUES (61, N'Cliente Evento 10', 1140000010, N'cliente.evento10@gmail.com', 30000010)
INSERT [dbo].[CLIENTE] ([Id_Cliente], [Nombre_Completo], [Telefono], [Email], [Dni]) VALUES (62, N'Cliente Evento 11', 1140000011, N'cliente.evento11@gmail.com', 30000011)
INSERT [dbo].[CLIENTE] ([Id_Cliente], [Nombre_Completo], [Telefono], [Email], [Dni]) VALUES (63, N'Cliente Evento 12', 1140000012, N'cliente.evento12@gmail.com', 30000012)
INSERT [dbo].[CLIENTE] ([Id_Cliente], [Nombre_Completo], [Telefono], [Email], [Dni]) VALUES (64, N'Cliente Evento 13', 1140000013, N'cliente.evento13@gmail.com', 30000013)
INSERT [dbo].[CLIENTE] ([Id_Cliente], [Nombre_Completo], [Telefono], [Email], [Dni]) VALUES (65, N'Cliente Evento 14', 1140000014, N'cliente.evento14@gmail.com', 30000014)
INSERT [dbo].[CLIENTE] ([Id_Cliente], [Nombre_Completo], [Telefono], [Email], [Dni]) VALUES (66, N'Cliente Evento 15', 1140000015, N'cliente.evento15@gmail.com', 30000015)
INSERT [dbo].[CLIENTE] ([Id_Cliente], [Nombre_Completo], [Telefono], [Email], [Dni]) VALUES (67, N'Cliente Evento 16', 1140000016, N'cliente.evento16@gmail.com', 30000016)
INSERT [dbo].[CLIENTE] ([Id_Cliente], [Nombre_Completo], [Telefono], [Email], [Dni]) VALUES (68, N'Cliente Evento 17', 1140000017, N'cliente.evento17@gmail.com', 30000017)
INSERT [dbo].[CLIENTE] ([Id_Cliente], [Nombre_Completo], [Telefono], [Email], [Dni]) VALUES (69, N'Cliente Evento 18', 1140000018, N'cliente.evento18@gmail.com', 30000018)
INSERT [dbo].[CLIENTE] ([Id_Cliente], [Nombre_Completo], [Telefono], [Email], [Dni]) VALUES (70, N'Cliente Evento 19', 1140000019, N'cliente.evento19@gmail.com', 30000019)
INSERT [dbo].[CLIENTE] ([Id_Cliente], [Nombre_Completo], [Telefono], [Email], [Dni]) VALUES (71, N'Cliente Evento 20', 1140000020, N'cliente.evento20@gmail.com', 30000020)
INSERT [dbo].[CLIENTE] ([Id_Cliente], [Nombre_Completo], [Telefono], [Email], [Dni]) VALUES (72, N'Cliente Evento 21', 1140000021, N'cliente.evento21@gmail.com', 30000021)
INSERT [dbo].[CLIENTE] ([Id_Cliente], [Nombre_Completo], [Telefono], [Email], [Dni]) VALUES (73, N'Cliente Evento 22', 1140000022, N'cliente.evento22@gmail.com', 30000022)
INSERT [dbo].[CLIENTE] ([Id_Cliente], [Nombre_Completo], [Telefono], [Email], [Dni]) VALUES (74, N'Cliente Evento 23', 1140000023, N'cliente.evento23@gmail.com', 30000023)
INSERT [dbo].[CLIENTE] ([Id_Cliente], [Nombre_Completo], [Telefono], [Email], [Dni]) VALUES (75, N'Cliente Evento 24', 1140000024, N'cliente.evento24@gmail.com', 30000024)
INSERT [dbo].[CLIENTE] ([Id_Cliente], [Nombre_Completo], [Telefono], [Email], [Dni]) VALUES (76, N'Cliente Evento 25', 1140000025, N'cliente.evento25@gmail.com', 30000025)
INSERT [dbo].[CLIENTE] ([Id_Cliente], [Nombre_Completo], [Telefono], [Email], [Dni]) VALUES (77, N'Cliente Evento 26', 1140000026, N'cliente.evento26@gmail.com', 30000026)
INSERT [dbo].[CLIENTE] ([Id_Cliente], [Nombre_Completo], [Telefono], [Email], [Dni]) VALUES (78, N'Cliente Evento 27', 1140000027, N'cliente.evento27@gmail.com', 30000027)
INSERT [dbo].[CLIENTE] ([Id_Cliente], [Nombre_Completo], [Telefono], [Email], [Dni]) VALUES (79, N'Cliente Evento 28', 1140000028, N'cliente.evento28@gmail.com', 30000028)
INSERT [dbo].[CLIENTE] ([Id_Cliente], [Nombre_Completo], [Telefono], [Email], [Dni]) VALUES (80, N'Cliente Evento 29', 1140000029, N'cliente.evento29@gmail.com', 30000029)
INSERT [dbo].[CLIENTE] ([Id_Cliente], [Nombre_Completo], [Telefono], [Email], [Dni]) VALUES (81, N'Cliente Evento 30', 1140000030, N'cliente.evento30@gmail.com', 30000030)
INSERT [dbo].[CLIENTE] ([Id_Cliente], [Nombre_Completo], [Telefono], [Email], [Dni]) VALUES (82, N'Cliente Evento 31', 1140000031, N'cliente.evento31@gmail.com', 30000031)
INSERT [dbo].[CLIENTE] ([Id_Cliente], [Nombre_Completo], [Telefono], [Email], [Dni]) VALUES (83, N'Cliente Evento 32', 1140000032, N'cliente.evento32@gmail.com', 30000032)
INSERT [dbo].[CLIENTE] ([Id_Cliente], [Nombre_Completo], [Telefono], [Email], [Dni]) VALUES (84, N'Cliente Evento 33', 1140000033, N'cliente.evento33@gmail.com', 30000033)
INSERT [dbo].[CLIENTE] ([Id_Cliente], [Nombre_Completo], [Telefono], [Email], [Dni]) VALUES (85, N'Cliente Evento 34', 1140000034, N'cliente.evento34@gmail.com', 30000034)
INSERT [dbo].[CLIENTE] ([Id_Cliente], [Nombre_Completo], [Telefono], [Email], [Dni]) VALUES (86, N'Cliente Evento 35', 1140000035, N'cliente.evento35@gmail.com', 30000035)
INSERT [dbo].[CLIENTE] ([Id_Cliente], [Nombre_Completo], [Telefono], [Email], [Dni]) VALUES (87, N'Cliente Evento 36', 1140000036, N'cliente.evento36@gmail.com', 30000036)
INSERT [dbo].[CLIENTE] ([Id_Cliente], [Nombre_Completo], [Telefono], [Email], [Dni]) VALUES (88, N'Cliente Evento 37', 1140000037, N'cliente.evento37@gmail.com', 30000037)
INSERT [dbo].[CLIENTE] ([Id_Cliente], [Nombre_Completo], [Telefono], [Email], [Dni]) VALUES (89, N'Cliente Evento 38', 1140000038, N'cliente.evento38@gmail.com', 30000038)
INSERT [dbo].[CLIENTE] ([Id_Cliente], [Nombre_Completo], [Telefono], [Email], [Dni]) VALUES (90, N'Cliente Evento 39', 1140000039, N'cliente.evento39@gmail.com', 30000039)
INSERT [dbo].[CLIENTE] ([Id_Cliente], [Nombre_Completo], [Telefono], [Email], [Dni]) VALUES (91, N'Cliente Evento 40', 1140000040, N'cliente.evento40@gmail.com', 30000040)
INSERT [dbo].[CLIENTE] ([Id_Cliente], [Nombre_Completo], [Telefono], [Email], [Dni]) VALUES (92, N'Cliente Evento 41', 1140000041, N'cliente.evento41@gmail.com', 30000041)
INSERT [dbo].[CLIENTE] ([Id_Cliente], [Nombre_Completo], [Telefono], [Email], [Dni]) VALUES (93, N'Cliente Evento 42', 1140000042, N'cliente.evento42@gmail.com', 30000042)
INSERT [dbo].[CLIENTE] ([Id_Cliente], [Nombre_Completo], [Telefono], [Email], [Dni]) VALUES (94, N'Cliente Evento 43', 1140000043, N'cliente.evento43@gmail.com', 30000043)
INSERT [dbo].[CLIENTE] ([Id_Cliente], [Nombre_Completo], [Telefono], [Email], [Dni]) VALUES (95, N'Cliente Evento 44', 1140000044, N'cliente.evento44@gmail.com', 30000044)
INSERT [dbo].[CLIENTE] ([Id_Cliente], [Nombre_Completo], [Telefono], [Email], [Dni]) VALUES (96, N'Cliente Evento 45', 1140000045, N'cliente.evento45@gmail.com', 30000045)
INSERT [dbo].[CLIENTE] ([Id_Cliente], [Nombre_Completo], [Telefono], [Email], [Dni]) VALUES (97, N'Cliente Evento 46', 1140000046, N'cliente.evento46@gmail.com', 30000046)
INSERT [dbo].[CLIENTE] ([Id_Cliente], [Nombre_Completo], [Telefono], [Email], [Dni]) VALUES (98, N'Cliente Evento 47', 1140000047, N'cliente.evento47@gmail.com', 30000047)
INSERT [dbo].[CLIENTE] ([Id_Cliente], [Nombre_Completo], [Telefono], [Email], [Dni]) VALUES (99, N'Cliente Evento 48', 1140000048, N'cliente.evento48@gmail.com', 30000048)
GO
INSERT [dbo].[CLIENTE] ([Id_Cliente], [Nombre_Completo], [Telefono], [Email], [Dni]) VALUES (100, N'Cliente Evento 49', 1140000049, N'cliente.evento49@gmail.com', 30000049)
INSERT [dbo].[CLIENTE] ([Id_Cliente], [Nombre_Completo], [Telefono], [Email], [Dni]) VALUES (101, N'Cliente Evento 50', 1140000050, N'cliente.evento50@gmail.com', 30000050)
INSERT [dbo].[CLIENTE] ([Id_Cliente], [Nombre_Completo], [Telefono], [Email], [Dni]) VALUES (102, N'Cliente Evento 51', 1140000051, N'cliente.evento51@gmail.com', 30000051)
INSERT [dbo].[CLIENTE] ([Id_Cliente], [Nombre_Completo], [Telefono], [Email], [Dni]) VALUES (103, N'Cliente Evento 52', 1140000052, N'cliente.evento52@gmail.com', 30000052)
INSERT [dbo].[CLIENTE] ([Id_Cliente], [Nombre_Completo], [Telefono], [Email], [Dni]) VALUES (104, N'Cliente Evento 53', 1140000053, N'cliente.evento53@gmail.com', 30000053)
INSERT [dbo].[CLIENTE] ([Id_Cliente], [Nombre_Completo], [Telefono], [Email], [Dni]) VALUES (105, N'Cliente Evento 54', 1140000054, N'cliente.evento54@gmail.com', 30000054)
INSERT [dbo].[CLIENTE] ([Id_Cliente], [Nombre_Completo], [Telefono], [Email], [Dni]) VALUES (106, N'Cliente Evento 55', 1140000055, N'cliente.evento55@gmail.com', 30000055)
INSERT [dbo].[CLIENTE] ([Id_Cliente], [Nombre_Completo], [Telefono], [Email], [Dni]) VALUES (107, N'Cliente Evento 1', 1140000001, N'cliente.evento1@gmail.com', 30000001)
INSERT [dbo].[CLIENTE] ([Id_Cliente], [Nombre_Completo], [Telefono], [Email], [Dni]) VALUES (108, N'Cliente Evento 2', 1140000002, N'cliente.evento2@gmail.com', 30000002)
INSERT [dbo].[CLIENTE] ([Id_Cliente], [Nombre_Completo], [Telefono], [Email], [Dni]) VALUES (109, N'Cliente Evento 3', 1140000003, N'cliente.evento3@gmail.com', 30000003)
INSERT [dbo].[CLIENTE] ([Id_Cliente], [Nombre_Completo], [Telefono], [Email], [Dni]) VALUES (110, N'Cliente Evento 4', 1140000004, N'cliente.evento4@gmail.com', 30000004)
INSERT [dbo].[CLIENTE] ([Id_Cliente], [Nombre_Completo], [Telefono], [Email], [Dni]) VALUES (111, N'Cliente Evento 5', 1140000005, N'cliente.evento5@gmail.com', 30000005)
INSERT [dbo].[CLIENTE] ([Id_Cliente], [Nombre_Completo], [Telefono], [Email], [Dni]) VALUES (112, N'Cliente Evento 6', 1140000006, N'cliente.evento6@gmail.com', 30000006)
INSERT [dbo].[CLIENTE] ([Id_Cliente], [Nombre_Completo], [Telefono], [Email], [Dni]) VALUES (113, N'Cliente Evento 7', 1140000007, N'cliente.evento7@gmail.com', 30000007)
INSERT [dbo].[CLIENTE] ([Id_Cliente], [Nombre_Completo], [Telefono], [Email], [Dni]) VALUES (114, N'Cliente Evento 8', 1140000008, N'cliente.evento8@gmail.com', 30000008)
INSERT [dbo].[CLIENTE] ([Id_Cliente], [Nombre_Completo], [Telefono], [Email], [Dni]) VALUES (115, N'Cliente Evento 9', 1140000009, N'cliente.evento9@gmail.com', 30000009)
INSERT [dbo].[CLIENTE] ([Id_Cliente], [Nombre_Completo], [Telefono], [Email], [Dni]) VALUES (116, N'Cliente Evento 10', 1140000010, N'cliente.evento10@gmail.com', 30000010)
INSERT [dbo].[CLIENTE] ([Id_Cliente], [Nombre_Completo], [Telefono], [Email], [Dni]) VALUES (117, N'Cliente Evento 11', 1140000011, N'cliente.evento11@gmail.com', 30000011)
INSERT [dbo].[CLIENTE] ([Id_Cliente], [Nombre_Completo], [Telefono], [Email], [Dni]) VALUES (118, N'Cliente Evento 12', 1140000012, N'cliente.evento12@gmail.com', 30000012)
INSERT [dbo].[CLIENTE] ([Id_Cliente], [Nombre_Completo], [Telefono], [Email], [Dni]) VALUES (119, N'Cliente Evento 13', 1140000013, N'cliente.evento13@gmail.com', 30000013)
INSERT [dbo].[CLIENTE] ([Id_Cliente], [Nombre_Completo], [Telefono], [Email], [Dni]) VALUES (120, N'Cliente Evento 14', 1140000014, N'cliente.evento14@gmail.com', 30000014)
INSERT [dbo].[CLIENTE] ([Id_Cliente], [Nombre_Completo], [Telefono], [Email], [Dni]) VALUES (121, N'Cliente Evento 15', 1140000015, N'cliente.evento15@gmail.com', 30000015)
INSERT [dbo].[CLIENTE] ([Id_Cliente], [Nombre_Completo], [Telefono], [Email], [Dni]) VALUES (122, N'Cliente Evento 16', 1140000016, N'cliente.evento16@gmail.com', 30000016)
INSERT [dbo].[CLIENTE] ([Id_Cliente], [Nombre_Completo], [Telefono], [Email], [Dni]) VALUES (123, N'Cliente Evento 17', 1140000017, N'cliente.evento17@gmail.com', 30000017)
INSERT [dbo].[CLIENTE] ([Id_Cliente], [Nombre_Completo], [Telefono], [Email], [Dni]) VALUES (124, N'Cliente Evento 18', 1140000018, N'cliente.evento18@gmail.com', 30000018)
INSERT [dbo].[CLIENTE] ([Id_Cliente], [Nombre_Completo], [Telefono], [Email], [Dni]) VALUES (125, N'Cliente Evento 19', 1140000019, N'cliente.evento19@gmail.com', 30000019)
INSERT [dbo].[CLIENTE] ([Id_Cliente], [Nombre_Completo], [Telefono], [Email], [Dni]) VALUES (126, N'Cliente Evento 20', 1140000020, N'cliente.evento20@gmail.com', 30000020)
INSERT [dbo].[CLIENTE] ([Id_Cliente], [Nombre_Completo], [Telefono], [Email], [Dni]) VALUES (127, N'Cliente Evento 21', 1140000021, N'cliente.evento21@gmail.com', 30000021)
INSERT [dbo].[CLIENTE] ([Id_Cliente], [Nombre_Completo], [Telefono], [Email], [Dni]) VALUES (128, N'Cliente Evento 22', 1140000022, N'cliente.evento22@gmail.com', 30000022)
INSERT [dbo].[CLIENTE] ([Id_Cliente], [Nombre_Completo], [Telefono], [Email], [Dni]) VALUES (129, N'Cliente Evento 23', 1140000023, N'cliente.evento23@gmail.com', 30000023)
INSERT [dbo].[CLIENTE] ([Id_Cliente], [Nombre_Completo], [Telefono], [Email], [Dni]) VALUES (130, N'Cliente Evento 24', 1140000024, N'cliente.evento24@gmail.com', 30000024)
INSERT [dbo].[CLIENTE] ([Id_Cliente], [Nombre_Completo], [Telefono], [Email], [Dni]) VALUES (131, N'Cliente Evento 25', 1140000025, N'cliente.evento25@gmail.com', 30000025)
INSERT [dbo].[CLIENTE] ([Id_Cliente], [Nombre_Completo], [Telefono], [Email], [Dni]) VALUES (132, N'Cliente Evento 26', 1140000026, N'cliente.evento26@gmail.com', 30000026)
INSERT [dbo].[CLIENTE] ([Id_Cliente], [Nombre_Completo], [Telefono], [Email], [Dni]) VALUES (133, N'Cliente Evento 27', 1140000027, N'cliente.evento27@gmail.com', 30000027)
INSERT [dbo].[CLIENTE] ([Id_Cliente], [Nombre_Completo], [Telefono], [Email], [Dni]) VALUES (134, N'Cliente Evento 28', 1140000028, N'cliente.evento28@gmail.com', 30000028)
INSERT [dbo].[CLIENTE] ([Id_Cliente], [Nombre_Completo], [Telefono], [Email], [Dni]) VALUES (135, N'Cliente Evento 29', 1140000029, N'cliente.evento29@gmail.com', 30000029)
INSERT [dbo].[CLIENTE] ([Id_Cliente], [Nombre_Completo], [Telefono], [Email], [Dni]) VALUES (136, N'Cliente Evento 30', 1140000030, N'cliente.evento30@gmail.com', 30000030)
INSERT [dbo].[CLIENTE] ([Id_Cliente], [Nombre_Completo], [Telefono], [Email], [Dni]) VALUES (137, N'Cliente Evento 31', 1140000031, N'cliente.evento31@gmail.com', 30000031)
INSERT [dbo].[CLIENTE] ([Id_Cliente], [Nombre_Completo], [Telefono], [Email], [Dni]) VALUES (138, N'Cliente Evento 32', 1140000032, N'cliente.evento32@gmail.com', 30000032)
INSERT [dbo].[CLIENTE] ([Id_Cliente], [Nombre_Completo], [Telefono], [Email], [Dni]) VALUES (139, N'Cliente Evento 33', 1140000033, N'cliente.evento33@gmail.com', 30000033)
INSERT [dbo].[CLIENTE] ([Id_Cliente], [Nombre_Completo], [Telefono], [Email], [Dni]) VALUES (140, N'Cliente Evento 34', 1140000034, N'cliente.evento34@gmail.com', 30000034)
INSERT [dbo].[CLIENTE] ([Id_Cliente], [Nombre_Completo], [Telefono], [Email], [Dni]) VALUES (141, N'Cliente Evento 35', 1140000035, N'cliente.evento35@gmail.com', 30000035)
INSERT [dbo].[CLIENTE] ([Id_Cliente], [Nombre_Completo], [Telefono], [Email], [Dni]) VALUES (142, N'Cliente Evento 36', 1140000036, N'cliente.evento36@gmail.com', 30000036)
INSERT [dbo].[CLIENTE] ([Id_Cliente], [Nombre_Completo], [Telefono], [Email], [Dni]) VALUES (143, N'Cliente Evento 37', 1140000037, N'cliente.evento37@gmail.com', 30000037)
INSERT [dbo].[CLIENTE] ([Id_Cliente], [Nombre_Completo], [Telefono], [Email], [Dni]) VALUES (144, N'Cliente Evento 38', 1140000038, N'cliente.evento38@gmail.com', 30000038)
INSERT [dbo].[CLIENTE] ([Id_Cliente], [Nombre_Completo], [Telefono], [Email], [Dni]) VALUES (145, N'Cliente Evento 39', 1140000039, N'cliente.evento39@gmail.com', 30000039)
INSERT [dbo].[CLIENTE] ([Id_Cliente], [Nombre_Completo], [Telefono], [Email], [Dni]) VALUES (146, N'Cliente Evento 40', 1140000040, N'cliente.evento40@gmail.com', 30000040)
INSERT [dbo].[CLIENTE] ([Id_Cliente], [Nombre_Completo], [Telefono], [Email], [Dni]) VALUES (147, N'Cliente Evento 41', 1140000041, N'cliente.evento41@gmail.com', 30000041)
INSERT [dbo].[CLIENTE] ([Id_Cliente], [Nombre_Completo], [Telefono], [Email], [Dni]) VALUES (148, N'Cliente Evento 42', 1140000042, N'cliente.evento42@gmail.com', 30000042)
INSERT [dbo].[CLIENTE] ([Id_Cliente], [Nombre_Completo], [Telefono], [Email], [Dni]) VALUES (149, N'Cliente Evento 43', 1140000043, N'cliente.evento43@gmail.com', 30000043)
INSERT [dbo].[CLIENTE] ([Id_Cliente], [Nombre_Completo], [Telefono], [Email], [Dni]) VALUES (150, N'Cliente Evento 44', 1140000044, N'cliente.evento44@gmail.com', 30000044)
INSERT [dbo].[CLIENTE] ([Id_Cliente], [Nombre_Completo], [Telefono], [Email], [Dni]) VALUES (151, N'Cliente Evento 45', 1140000045, N'cliente.evento45@gmail.com', 30000045)
INSERT [dbo].[CLIENTE] ([Id_Cliente], [Nombre_Completo], [Telefono], [Email], [Dni]) VALUES (152, N'Cliente Evento 46', 1140000046, N'cliente.evento46@gmail.com', 30000046)
INSERT [dbo].[CLIENTE] ([Id_Cliente], [Nombre_Completo], [Telefono], [Email], [Dni]) VALUES (153, N'Cliente Evento 47', 1140000047, N'cliente.evento47@gmail.com', 30000047)
INSERT [dbo].[CLIENTE] ([Id_Cliente], [Nombre_Completo], [Telefono], [Email], [Dni]) VALUES (154, N'Cliente Evento 48', 1140000048, N'cliente.evento48@gmail.com', 30000048)
INSERT [dbo].[CLIENTE] ([Id_Cliente], [Nombre_Completo], [Telefono], [Email], [Dni]) VALUES (155, N'Cliente Evento 49', 1140000049, N'cliente.evento49@gmail.com', 30000049)
INSERT [dbo].[CLIENTE] ([Id_Cliente], [Nombre_Completo], [Telefono], [Email], [Dni]) VALUES (156, N'Cliente Evento 50', 1140000050, N'cliente.evento50@gmail.com', 30000050)
INSERT [dbo].[CLIENTE] ([Id_Cliente], [Nombre_Completo], [Telefono], [Email], [Dni]) VALUES (157, N'Cliente Evento 51', 1140000051, N'cliente.evento51@gmail.com', 30000051)
INSERT [dbo].[CLIENTE] ([Id_Cliente], [Nombre_Completo], [Telefono], [Email], [Dni]) VALUES (158, N'Cliente Evento 52', 1140000052, N'cliente.evento52@gmail.com', 30000052)
INSERT [dbo].[CLIENTE] ([Id_Cliente], [Nombre_Completo], [Telefono], [Email], [Dni]) VALUES (159, N'Cliente Evento 53', 1140000053, N'cliente.evento53@gmail.com', 30000053)
INSERT [dbo].[CLIENTE] ([Id_Cliente], [Nombre_Completo], [Telefono], [Email], [Dni]) VALUES (160, N'Cliente Evento 54', 1140000054, N'cliente.evento54@gmail.com', 30000054)
INSERT [dbo].[CLIENTE] ([Id_Cliente], [Nombre_Completo], [Telefono], [Email], [Dni]) VALUES (161, N'Cliente Evento 55', 1140000055, N'cliente.evento55@gmail.com', 30000055)
SET IDENTITY_INSERT [dbo].[CLIENTE] OFF
GO
SET IDENTITY_INSERT [dbo].[CONTROL] ON 

INSERT [dbo].[CONTROL] ([ID_CONTROL], [NOMBRE_CONTROL], [NOMBRE_FORMULARIO]) VALUES (1, N'LBLusuario', N'FrmLogIn')
INSERT [dbo].[CONTROL] ([ID_CONTROL], [NOMBRE_CONTROL], [NOMBRE_FORMULARIO]) VALUES (2, N'LBLpassword', N'FrmLogIn')
INSERT [dbo].[CONTROL] ([ID_CONTROL], [NOMBRE_CONTROL], [NOMBRE_FORMULARIO]) VALUES (3, N'LBLidiomas', N'FrmLogIn')
INSERT [dbo].[CONTROL] ([ID_CONTROL], [NOMBRE_CONTROL], [NOMBRE_FORMULARIO]) VALUES (4, N'BTN_IniciarSesion', N'FrmLogIn')
INSERT [dbo].[CONTROL] ([ID_CONTROL], [NOMBRE_CONTROL], [NOMBRE_FORMULARIO]) VALUES (5, N'LBLbienvenida', N'FrmMenuPrincipal')
INSERT [dbo].[CONTROL] ([ID_CONTROL], [NOMBRE_CONTROL], [NOMBRE_FORMULARIO]) VALUES (6, N'BtnCerrarSesion', N'FrmMenuPrincipal')
INSERT [dbo].[CONTROL] ([ID_CONTROL], [NOMBRE_CONTROL], [NOMBRE_FORMULARIO]) VALUES (7, N'AdministracionMenuItem', N'FrmMenuPrincipal')
INSERT [dbo].[CONTROL] ([ID_CONTROL], [NOMBRE_CONTROL], [NOMBRE_FORMULARIO]) VALUES (8, N'BitacoraToolStripMenuItem', N'FrmMenuPrincipal')
INSERT [dbo].[CONTROL] ([ID_CONTROL], [NOMBRE_CONTROL], [NOMBRE_FORMULARIO]) VALUES (9, N'controlDeUsuariosToolStripMenuItem', N'FrmMenuPrincipal')
INSERT [dbo].[CONTROL] ([ID_CONTROL], [NOMBRE_CONTROL], [NOMBRE_FORMULARIO]) VALUES (10, N'controlDePermisosToolStripMenuItem', N'FrmMenuPrincipal')
INSERT [dbo].[CONTROL] ([ID_CONTROL], [NOMBRE_CONTROL], [NOMBRE_FORMULARIO]) VALUES (11, N'LBLusuario', N'FrmCTRLUsuario')
INSERT [dbo].[CONTROL] ([ID_CONTROL], [NOMBRE_CONTROL], [NOMBRE_FORMULARIO]) VALUES (12, N'LBLcontraseña', N'FrmCTRLUsuario')
INSERT [dbo].[CONTROL] ([ID_CONTROL], [NOMBRE_CONTROL], [NOMBRE_FORMULARIO]) VALUES (13, N'LBLdni', N'FrmCTRLUsuario')
INSERT [dbo].[CONTROL] ([ID_CONTROL], [NOMBRE_CONTROL], [NOMBRE_FORMULARIO]) VALUES (14, N'LBLemail', N'FrmCTRLUsuario')
INSERT [dbo].[CONTROL] ([ID_CONTROL], [NOMBRE_CONTROL], [NOMBRE_FORMULARIO]) VALUES (15, N'LBLrol', N'FrmCTRLUsuario')
INSERT [dbo].[CONTROL] ([ID_CONTROL], [NOMBRE_CONTROL], [NOMBRE_FORMULARIO]) VALUES (16, N'Cb_CTRLUsuarioRol', N'FrmCTRLUsuario')
INSERT [dbo].[CONTROL] ([ID_CONTROL], [NOMBRE_CONTROL], [NOMBRE_FORMULARIO]) VALUES (17, N'CKXmostrarbloqueados', N'FrmCTRLUsuario')
INSERT [dbo].[CONTROL] ([ID_CONTROL], [NOMBRE_CONTROL], [NOMBRE_FORMULARIO]) VALUES (18, N'BTNCtrlUsuAlta', N'FrmCTRLUsuario')
INSERT [dbo].[CONTROL] ([ID_CONTROL], [NOMBRE_CONTROL], [NOMBRE_FORMULARIO]) VALUES (19, N'BTNCtrlUsuBaja', N'FrmCTRLUsuario')
INSERT [dbo].[CONTROL] ([ID_CONTROL], [NOMBRE_CONTROL], [NOMBRE_FORMULARIO]) VALUES (20, N'BTNCtrlUsuModificar', N'FrmCTRLUsuario')
INSERT [dbo].[CONTROL] ([ID_CONTROL], [NOMBRE_CONTROL], [NOMBRE_FORMULARIO]) VALUES (21, N'BTNCtrlUsuDesbloquear', N'FrmCTRLUsuario')
INSERT [dbo].[CONTROL] ([ID_CONTROL], [NOMBRE_CONTROL], [NOMBRE_FORMULARIO]) VALUES (22, N'BTNCtrlUsuVolverMenu', N'FrmCTRLUsuario')
INSERT [dbo].[CONTROL] ([ID_CONTROL], [NOMBRE_CONTROL], [NOMBRE_FORMULARIO]) VALUES (23, N'LBLnombre', N'FrmCTRLPermiso')
INSERT [dbo].[CONTROL] ([ID_CONTROL], [NOMBRE_CONTROL], [NOMBRE_FORMULARIO]) VALUES (24, N'BTNCtrlPermisoAsignar', N'FrmCTRLPermiso')
INSERT [dbo].[CONTROL] ([ID_CONTROL], [NOMBRE_CONTROL], [NOMBRE_FORMULARIO]) VALUES (25, N'BTNCtrlPermisoDesasignar', N'FrmCTRLPermiso')
INSERT [dbo].[CONTROL] ([ID_CONTROL], [NOMBRE_CONTROL], [NOMBRE_FORMULARIO]) VALUES (26, N'BTNCtrlPermisoCrearRol', N'FrmCTRLPermiso')
INSERT [dbo].[CONTROL] ([ID_CONTROL], [NOMBRE_CONTROL], [NOMBRE_FORMULARIO]) VALUES (27, N'GB_Bitacora', N'FrmBitacora')
INSERT [dbo].[CONTROL] ([ID_CONTROL], [NOMBRE_CONTROL], [NOMBRE_FORMULARIO]) VALUES (28, N'GBfiltros', N'FrmBitacora')
INSERT [dbo].[CONTROL] ([ID_CONTROL], [NOMBRE_CONTROL], [NOMBRE_FORMULARIO]) VALUES (29, N'LBLusuario', N'FrmBitacora')
INSERT [dbo].[CONTROL] ([ID_CONTROL], [NOMBRE_CONTROL], [NOMBRE_FORMULARIO]) VALUES (30, N'LBLmodulo', N'FrmBitacora')
INSERT [dbo].[CONTROL] ([ID_CONTROL], [NOMBRE_CONTROL], [NOMBRE_FORMULARIO]) VALUES (31, N'LBLcriticidad', N'FrmBitacora')
INSERT [dbo].[CONTROL] ([ID_CONTROL], [NOMBRE_CONTROL], [NOMBRE_FORMULARIO]) VALUES (32, N'LBLfechainicial', N'FrmBitacora')
INSERT [dbo].[CONTROL] ([ID_CONTROL], [NOMBRE_CONTROL], [NOMBRE_FORMULARIO]) VALUES (33, N'LBLfechafinal', N'FrmBitacora')
INSERT [dbo].[CONTROL] ([ID_CONTROL], [NOMBRE_CONTROL], [NOMBRE_FORMULARIO]) VALUES (34, N'CKXincluirfechas', N'FrmBitacora')
INSERT [dbo].[CONTROL] ([ID_CONTROL], [NOMBRE_CONTROL], [NOMBRE_FORMULARIO]) VALUES (35, N'BTN_CargarBitacora', N'FrmBitacora')
INSERT [dbo].[CONTROL] ([ID_CONTROL], [NOMBRE_CONTROL], [NOMBRE_FORMULARIO]) VALUES (36, N'BTN_BitacoraVolverAlMenu', N'FrmBitacora')
INSERT [dbo].[CONTROL] ([ID_CONTROL], [NOMBRE_CONTROL], [NOMBRE_FORMULARIO]) VALUES (37, N'LBLidioma', N'FrmMenuPrincipal')
INSERT [dbo].[CONTROL] ([ID_CONTROL], [NOMBRE_CONTROL], [NOMBRE_FORMULARIO]) VALUES (38, N'CBXidiomas', N'FrmMenuPrincipal')
INSERT [dbo].[CONTROL] ([ID_CONTROL], [NOMBRE_CONTROL], [NOMBRE_FORMULARIO]) VALUES (39, N'LBLidiomas', N'FrmCTRLUsuario')
INSERT [dbo].[CONTROL] ([ID_CONTROL], [NOMBRE_CONTROL], [NOMBRE_FORMULARIO]) VALUES (40, N'CBXidiomas', N'FrmCTRLUsuario')
INSERT [dbo].[CONTROL] ([ID_CONTROL], [NOMBRE_CONTROL], [NOMBRE_FORMULARIO]) VALUES (41, N'LBLidiomas', N'FrmCTRLPermiso')
INSERT [dbo].[CONTROL] ([ID_CONTROL], [NOMBRE_CONTROL], [NOMBRE_FORMULARIO]) VALUES (42, N'CBXidiomas', N'FrmCTRLPermiso')
INSERT [dbo].[CONTROL] ([ID_CONTROL], [NOMBRE_CONTROL], [NOMBRE_FORMULARIO]) VALUES (43, N'LBLidiomas', N'FrmBitacora')
INSERT [dbo].[CONTROL] ([ID_CONTROL], [NOMBRE_CONTROL], [NOMBRE_FORMULARIO]) VALUES (44, N'CBXidiomas', N'FrmBitacora')
INSERT [dbo].[CONTROL] ([ID_CONTROL], [NOMBRE_CONTROL], [NOMBRE_FORMULARIO]) VALUES (45, N'controlDeIdiomasToolStripMenuItem', N'FrmMenuPrincipal')
INSERT [dbo].[CONTROL] ([ID_CONTROL], [NOMBRE_CONTROL], [NOMBRE_FORMULARIO]) VALUES (46, N'LBLidiomas', N'FrmIdioma')
INSERT [dbo].[CONTROL] ([ID_CONTROL], [NOMBRE_CONTROL], [NOMBRE_FORMULARIO]) VALUES (47, N'LBLidiomas2', N'FrmIdioma')
INSERT [dbo].[CONTROL] ([ID_CONTROL], [NOMBRE_CONTROL], [NOMBRE_FORMULARIO]) VALUES (48, N'LBLnombre', N'FrmIdioma')
INSERT [dbo].[CONTROL] ([ID_CONTROL], [NOMBRE_CONTROL], [NOMBRE_FORMULARIO]) VALUES (49, N'LBLsufijo', N'FrmIdioma')
INSERT [dbo].[CONTROL] ([ID_CONTROL], [NOMBRE_CONTROL], [NOMBRE_FORMULARIO]) VALUES (50, N'BTNcrear', N'FrmIdioma')
INSERT [dbo].[CONTROL] ([ID_CONTROL], [NOMBRE_CONTROL], [NOMBRE_FORMULARIO]) VALUES (51, N'BTNdeshabilitar', N'FrmIdioma')
INSERT [dbo].[CONTROL] ([ID_CONTROL], [NOMBRE_CONTROL], [NOMBRE_FORMULARIO]) VALUES (52, N'BTNvolveralmenu', N'FrmIdioma')
INSERT [dbo].[CONTROL] ([ID_CONTROL], [NOMBRE_CONTROL], [NOMBRE_FORMULARIO]) VALUES (53, N'BTNCtrlPermisoModifRol', N'FrmCTRLPermiso')
INSERT [dbo].[CONTROL] ([ID_CONTROL], [NOMBRE_CONTROL], [NOMBRE_FORMULARIO]) VALUES (54, N'BTNCtrlPermisoBorrarRol', N'FrmCTRLPermiso')
INSERT [dbo].[CONTROL] ([ID_CONTROL], [NOMBRE_CONTROL], [NOMBRE_FORMULARIO]) VALUES (55, N'BG_ListRolesPermisos', N'FrmCTRLPermiso')
INSERT [dbo].[CONTROL] ([ID_CONTROL], [NOMBRE_CONTROL], [NOMBRE_FORMULARIO]) VALUES (56, N'GB_TreeViewRoles', N'FrmCTRLPermiso')
INSERT [dbo].[CONTROL] ([ID_CONTROL], [NOMBRE_CONTROL], [NOMBRE_FORMULARIO]) VALUES (57, N'Titulo', N'FrmLogIn')
INSERT [dbo].[CONTROL] ([ID_CONTROL], [NOMBRE_CONTROL], [NOMBRE_FORMULARIO]) VALUES (58, N'Titulo', N'FrmMenuPrincipal')
INSERT [dbo].[CONTROL] ([ID_CONTROL], [NOMBRE_CONTROL], [NOMBRE_FORMULARIO]) VALUES (59, N'Titulo', N'FrmIdioma')
INSERT [dbo].[CONTROL] ([ID_CONTROL], [NOMBRE_CONTROL], [NOMBRE_FORMULARIO]) VALUES (60, N'Titulo', N'FrmCTRLUsuario')
INSERT [dbo].[CONTROL] ([ID_CONTROL], [NOMBRE_CONTROL], [NOMBRE_FORMULARIO]) VALUES (61, N'Titulo', N'FrmCTRLPermiso')
INSERT [dbo].[CONTROL] ([ID_CONTROL], [NOMBRE_CONTROL], [NOMBRE_FORMULARIO]) VALUES (62, N'Titulo', N'FrmBitacora')
INSERT [dbo].[CONTROL] ([ID_CONTROL], [NOMBRE_CONTROL], [NOMBRE_FORMULARIO]) VALUES (63, N'BTNhabilitar', N'FrmIdioma')
INSERT [dbo].[CONTROL] ([ID_CONTROL], [NOMBRE_CONTROL], [NOMBRE_FORMULARIO]) VALUES (64, N'LBLidiomas', N'FrmHistorial')
INSERT [dbo].[CONTROL] ([ID_CONTROL], [NOMBRE_CONTROL], [NOMBRE_FORMULARIO]) VALUES (65, N'LBLhistorial', N'FrmHistorial')
INSERT [dbo].[CONTROL] ([ID_CONTROL], [NOMBRE_CONTROL], [NOMBRE_FORMULARIO]) VALUES (66, N'LBLusuario', N'FrmHistorial')
INSERT [dbo].[CONTROL] ([ID_CONTROL], [NOMBRE_CONTROL], [NOMBRE_FORMULARIO]) VALUES (67, N'BTNrestaurar', N'FrmHistorial')
INSERT [dbo].[CONTROL] ([ID_CONTROL], [NOMBRE_CONTROL], [NOMBRE_FORMULARIO]) VALUES (68, N'BTNvolveralmenu', N'FrmHistorial')
INSERT [dbo].[CONTROL] ([ID_CONTROL], [NOMBRE_CONTROL], [NOMBRE_FORMULARIO]) VALUES (69, N'Titulo', N'FrmHistorial')
INSERT [dbo].[CONTROL] ([ID_CONTROL], [NOMBRE_CONTROL], [NOMBRE_FORMULARIO]) VALUES (70, N'LBLidiomas', N'FrmRestauracionBase')
INSERT [dbo].[CONTROL] ([ID_CONTROL], [NOMBRE_CONTROL], [NOMBRE_FORMULARIO]) VALUES (71, N'LBMensajeError', N'FrmRestauracionBase')
INSERT [dbo].[CONTROL] ([ID_CONTROL], [NOMBRE_CONTROL], [NOMBRE_FORMULARIO]) VALUES (72, N'BTNHacerBackUp', N'FrmRestauracionBase')
INSERT [dbo].[CONTROL] ([ID_CONTROL], [NOMBRE_CONTROL], [NOMBRE_FORMULARIO]) VALUES (73, N'BTNExaminarBackUp', N'FrmRestauracionBase')
INSERT [dbo].[CONTROL] ([ID_CONTROL], [NOMBRE_CONTROL], [NOMBRE_FORMULARIO]) VALUES (74, N'BTNRestaurarBase', N'FrmRestauracionBase')
INSERT [dbo].[CONTROL] ([ID_CONTROL], [NOMBRE_CONTROL], [NOMBRE_FORMULARIO]) VALUES (75, N'BTNRecalcularDigito', N'FrmRestauracionBase')
INSERT [dbo].[CONTROL] ([ID_CONTROL], [NOMBRE_CONTROL], [NOMBRE_FORMULARIO]) VALUES (76, N'BTNRestauracionVolverMenu', N'FrmRestauracionBase')
INSERT [dbo].[CONTROL] ([ID_CONTROL], [NOMBRE_CONTROL], [NOMBRE_FORMULARIO]) VALUES (77, N'Titulo', N'FrmRestauracionBase')
INSERT [dbo].[CONTROL] ([ID_CONTROL], [NOMBRE_CONTROL], [NOMBRE_FORMULARIO]) VALUES (78, N'GB_NuevoRol', N'FrmCTRLPermiso')
INSERT [dbo].[CONTROL] ([ID_CONTROL], [NOMBRE_CONTROL], [NOMBRE_FORMULARIO]) VALUES (79, N'restauracionDeBaseToolStripMenuItem', N'FrmMenuPrincipal')
INSERT [dbo].[CONTROL] ([ID_CONTROL], [NOMBRE_CONTROL], [NOMBRE_FORMULARIO]) VALUES (80, N'historialDeCambiosToolStripMenuItem', N'FrmMenuPrincipal')
INSERT [dbo].[CONTROL] ([ID_CONTROL], [NOMBRE_CONTROL], [NOMBRE_FORMULARIO]) VALUES (81, N'GB_Historial', N'FrmHistorial')
INSERT [dbo].[CONTROL] ([ID_CONTROL], [NOMBRE_CONTROL], [NOMBRE_FORMULARIO]) VALUES (82, N'GB_FiltrarHistorial', N'FrmHistorial')
INSERT [dbo].[CONTROL] ([ID_CONTROL], [NOMBRE_CONTROL], [NOMBRE_FORMULARIO]) VALUES (83, N'BTN_LimpiarFiltrosHist', N'FrmHistorial')
INSERT [dbo].[CONTROL] ([ID_CONTROL], [NOMBRE_CONTROL], [NOMBRE_FORMULARIO]) VALUES (84, N'GB_Usuarios', N'FrmCTRLUsuario')
INSERT [dbo].[CONTROL] ([ID_CONTROL], [NOMBRE_CONTROL], [NOMBRE_FORMULARIO]) VALUES (85, N'GB_Datos', N'FrmCTRLUsuario')
INSERT [dbo].[CONTROL] ([ID_CONTROL], [NOMBRE_CONTROL], [NOMBRE_FORMULARIO]) VALUES (86, N'GB_ListRoles', N'FrmCTRLPermiso')
INSERT [dbo].[CONTROL] ([ID_CONTROL], [NOMBRE_CONTROL], [NOMBRE_FORMULARIO]) VALUES (88, N'GB_ListPermisos', N'FrmCTRLPermiso')
INSERT [dbo].[CONTROL] ([ID_CONTROL], [NOMBRE_CONTROL], [NOMBRE_FORMULARIO]) VALUES (89, N'GB_Idiomas', N'FrmIdioma')
INSERT [dbo].[CONTROL] ([ID_CONTROL], [NOMBRE_CONTROL], [NOMBRE_FORMULARIO]) VALUES (90, N'GB_NuevoIdioma', N'FrmIdioma')
INSERT [dbo].[CONTROL] ([ID_CONTROL], [NOMBRE_CONTROL], [NOMBRE_FORMULARIO]) VALUES (91, N'GB_Traducciones', N'FrmIdioma')
INSERT [dbo].[CONTROL] ([ID_CONTROL], [NOMBRE_CONTROL], [NOMBRE_FORMULARIO]) VALUES (92, N'LBLidiomas', N'FrmProducto')
INSERT [dbo].[CONTROL] ([ID_CONTROL], [NOMBRE_CONTROL], [NOMBRE_FORMULARIO]) VALUES (93, N'LBLNombreProducto', N'FrmProducto')
INSERT [dbo].[CONTROL] ([ID_CONTROL], [NOMBRE_CONTROL], [NOMBRE_FORMULARIO]) VALUES (94, N'LBLPrecioProducto', N'FrmProducto')
INSERT [dbo].[CONTROL] ([ID_CONTROL], [NOMBRE_CONTROL], [NOMBRE_FORMULARIO]) VALUES (95, N'LBLStockProducto', N'FrmProducto')
INSERT [dbo].[CONTROL] ([ID_CONTROL], [NOMBRE_CONTROL], [NOMBRE_FORMULARIO]) VALUES (96, N'BTN_ProductoAlta', N'FrmProducto')
INSERT [dbo].[CONTROL] ([ID_CONTROL], [NOMBRE_CONTROL], [NOMBRE_FORMULARIO]) VALUES (97, N'BTN_ProductoBaja', N'FrmProducto')
INSERT [dbo].[CONTROL] ([ID_CONTROL], [NOMBRE_CONTROL], [NOMBRE_FORMULARIO]) VALUES (98, N'BTN_ProductoModificar', N'FrmProducto')
INSERT [dbo].[CONTROL] ([ID_CONTROL], [NOMBRE_CONTROL], [NOMBRE_FORMULARIO]) VALUES (99, N'BTNvolveralmenu', N'FrmProducto')
INSERT [dbo].[CONTROL] ([ID_CONTROL], [NOMBRE_CONTROL], [NOMBRE_FORMULARIO]) VALUES (100, N'GB_Productos', N'FrmProducto')
GO
INSERT [dbo].[CONTROL] ([ID_CONTROL], [NOMBRE_CONTROL], [NOMBRE_FORMULARIO]) VALUES (101, N'GB_Producto', N'FrmProducto')
INSERT [dbo].[CONTROL] ([ID_CONTROL], [NOMBRE_CONTROL], [NOMBRE_FORMULARIO]) VALUES (102, N'productosToolStripMenuItem', N'FrmMenuPrincipal')
SET IDENTITY_INSERT [dbo].[CONTROL] OFF
GO
SET IDENTITY_INSERT [dbo].[DETALLE_OC] ON 

INSERT [dbo].[DETALLE_OC] ([Id_Detalle], [Id_OrdenCompra], [Nombre_Insumo], [Cantidad_Solicitada], [Cantidad_Recibida]) VALUES (1, 3, N'Lays', 100, 100)
INSERT [dbo].[DETALLE_OC] ([Id_Detalle], [Id_OrdenCompra], [Nombre_Insumo], [Cantidad_Solicitada], [Cantidad_Recibida]) VALUES (2, 3, N'Papas para Guarnición', 200, 200)
INSERT [dbo].[DETALLE_OC] ([Id_Detalle], [Id_OrdenCompra], [Nombre_Insumo], [Cantidad_Solicitada], [Cantidad_Recibida]) VALUES (3, 4, N'Gaseosa Cola', 67, 0)
INSERT [dbo].[DETALLE_OC] ([Id_Detalle], [Id_OrdenCompra], [Nombre_Insumo], [Cantidad_Solicitada], [Cantidad_Recibida]) VALUES (4, 4, N'Papas para Guarnición', 67, 0)
INSERT [dbo].[DETALLE_OC] ([Id_Detalle], [Id_OrdenCompra], [Nombre_Insumo], [Cantidad_Solicitada], [Cantidad_Recibida]) VALUES (5, 5, N'Gaseosa Cola', 67, 65)
INSERT [dbo].[DETALLE_OC] ([Id_Detalle], [Id_OrdenCompra], [Nombre_Insumo], [Cantidad_Solicitada], [Cantidad_Recibida]) VALUES (6, 5, N'Papas para Guarnición', 67, 65)
INSERT [dbo].[DETALLE_OC] ([Id_Detalle], [Id_OrdenCompra], [Nombre_Insumo], [Cantidad_Solicitada], [Cantidad_Recibida]) VALUES (7, 6, N'Lomo de Ternera', 200, 200)
INSERT [dbo].[DETALLE_OC] ([Id_Detalle], [Id_OrdenCompra], [Nombre_Insumo], [Cantidad_Solicitada], [Cantidad_Recibida]) VALUES (8, 6, N'Helado de Dulce de Leche', 150, 150)
INSERT [dbo].[DETALLE_OC] ([Id_Detalle], [Id_OrdenCompra], [Nombre_Insumo], [Cantidad_Solicitada], [Cantidad_Recibida]) VALUES (9, 7, N'Lomo de Ternera', 300, 300)
INSERT [dbo].[DETALLE_OC] ([Id_Detalle], [Id_OrdenCompra], [Nombre_Insumo], [Cantidad_Solicitada], [Cantidad_Recibida]) VALUES (10, 7, N'Helado de Dulce de Leche', 185, 185)
INSERT [dbo].[DETALLE_OC] ([Id_Detalle], [Id_OrdenCompra], [Nombre_Insumo], [Cantidad_Solicitada], [Cantidad_Recibida]) VALUES (11, 8, N'Lomo de Ternera', 60, 30)
INSERT [dbo].[DETALLE_OC] ([Id_Detalle], [Id_OrdenCompra], [Nombre_Insumo], [Cantidad_Solicitada], [Cantidad_Recibida]) VALUES (12, 8, N'Vino Malbec Premium', 40, 0)
INSERT [dbo].[DETALLE_OC] ([Id_Detalle], [Id_OrdenCompra], [Nombre_Insumo], [Cantidad_Solicitada], [Cantidad_Recibida]) VALUES (13, 9, N'Papas para Guarnición', 120, 120)
INSERT [dbo].[DETALLE_OC] ([Id_Detalle], [Id_OrdenCompra], [Nombre_Insumo], [Cantidad_Solicitada], [Cantidad_Recibida]) VALUES (14, 9, N'Helado de Dulce de Leche', 50, 50)
INSERT [dbo].[DETALLE_OC] ([Id_Detalle], [Id_OrdenCompra], [Nombre_Insumo], [Cantidad_Solicitada], [Cantidad_Recibida]) VALUES (15, 10, N'Gaseosa Cola', 50, 0)
INSERT [dbo].[DETALLE_OC] ([Id_Detalle], [Id_OrdenCompra], [Nombre_Insumo], [Cantidad_Solicitada], [Cantidad_Recibida]) VALUES (16, 11, N'Lomo de Ternera', 75, 75)
INSERT [dbo].[DETALLE_OC] ([Id_Detalle], [Id_OrdenCompra], [Nombre_Insumo], [Cantidad_Solicitada], [Cantidad_Recibida]) VALUES (17, 11, N'Vino Malbec Premium', 50, 50)
INSERT [dbo].[DETALLE_OC] ([Id_Detalle], [Id_OrdenCompra], [Nombre_Insumo], [Cantidad_Solicitada], [Cantidad_Recibida]) VALUES (18, 12, N'Papas para Guarnición', 80, 80)
INSERT [dbo].[DETALLE_OC] ([Id_Detalle], [Id_OrdenCompra], [Nombre_Insumo], [Cantidad_Solicitada], [Cantidad_Recibida]) VALUES (19, 13, N'Lomo de Ternera', 120, 120)
INSERT [dbo].[DETALLE_OC] ([Id_Detalle], [Id_OrdenCompra], [Nombre_Insumo], [Cantidad_Solicitada], [Cantidad_Recibida]) VALUES (20, 14, N'Queso Tybo', 30, 30)
INSERT [dbo].[DETALLE_OC] ([Id_Detalle], [Id_OrdenCompra], [Nombre_Insumo], [Cantidad_Solicitada], [Cantidad_Recibida]) VALUES (21, 15, N'Jamón Cocido', 20, 20)
INSERT [dbo].[DETALLE_OC] ([Id_Detalle], [Id_OrdenCompra], [Nombre_Insumo], [Cantidad_Solicitada], [Cantidad_Recibida]) VALUES (22, 16, N'Helado de Dulce de Leche', 60, 60)
INSERT [dbo].[DETALLE_OC] ([Id_Detalle], [Id_OrdenCompra], [Nombre_Insumo], [Cantidad_Solicitada], [Cantidad_Recibida]) VALUES (23, 17, N'Lomo de Ternera', 50, 50)
INSERT [dbo].[DETALLE_OC] ([Id_Detalle], [Id_OrdenCompra], [Nombre_Insumo], [Cantidad_Solicitada], [Cantidad_Recibida]) VALUES (24, 18, N'Vino Malbec Premium', 90, 90)
INSERT [dbo].[DETALLE_OC] ([Id_Detalle], [Id_OrdenCompra], [Nombre_Insumo], [Cantidad_Solicitada], [Cantidad_Recibida]) VALUES (25, 19, N'Papas para Guarnición', 150, 150)
INSERT [dbo].[DETALLE_OC] ([Id_Detalle], [Id_OrdenCompra], [Nombre_Insumo], [Cantidad_Solicitada], [Cantidad_Recibida]) VALUES (26, 20, N'Jamón Cocido', 15, 15)
INSERT [dbo].[DETALLE_OC] ([Id_Detalle], [Id_OrdenCompra], [Nombre_Insumo], [Cantidad_Solicitada], [Cantidad_Recibida]) VALUES (27, 21, N'Lomo de Ternera', 100, 100)
INSERT [dbo].[DETALLE_OC] ([Id_Detalle], [Id_OrdenCompra], [Nombre_Insumo], [Cantidad_Solicitada], [Cantidad_Recibida]) VALUES (28, 22, N'Helado de Dulce de Leche', 60, 60)
INSERT [dbo].[DETALLE_OC] ([Id_Detalle], [Id_OrdenCompra], [Nombre_Insumo], [Cantidad_Solicitada], [Cantidad_Recibida]) VALUES (29, 23, N'Vino Malbec Premium', 70, 70)
INSERT [dbo].[DETALLE_OC] ([Id_Detalle], [Id_OrdenCompra], [Nombre_Insumo], [Cantidad_Solicitada], [Cantidad_Recibida]) VALUES (30, 24, N'Queso Tybo', 40, 40)
INSERT [dbo].[DETALLE_OC] ([Id_Detalle], [Id_OrdenCompra], [Nombre_Insumo], [Cantidad_Solicitada], [Cantidad_Recibida]) VALUES (31, 25, N'Papas para Guarnición', 50, 50)
INSERT [dbo].[DETALLE_OC] ([Id_Detalle], [Id_OrdenCompra], [Nombre_Insumo], [Cantidad_Solicitada], [Cantidad_Recibida]) VALUES (32, 26, N'Lomo de Ternera', 110, 110)
INSERT [dbo].[DETALLE_OC] ([Id_Detalle], [Id_OrdenCompra], [Nombre_Insumo], [Cantidad_Solicitada], [Cantidad_Recibida]) VALUES (33, 27, N'Lomo de Ternera', 60, 60)
INSERT [dbo].[DETALLE_OC] ([Id_Detalle], [Id_OrdenCompra], [Nombre_Insumo], [Cantidad_Solicitada], [Cantidad_Recibida]) VALUES (34, 28, N'Papas para Guarnición', 70, 70)
INSERT [dbo].[DETALLE_OC] ([Id_Detalle], [Id_OrdenCompra], [Nombre_Insumo], [Cantidad_Solicitada], [Cantidad_Recibida]) VALUES (35, 29, N'Vino Malbec Premium', 140, 140)
INSERT [dbo].[DETALLE_OC] ([Id_Detalle], [Id_OrdenCompra], [Nombre_Insumo], [Cantidad_Solicitada], [Cantidad_Recibida]) VALUES (36, 30, N'Lomo de Ternera', 80, 80)
INSERT [dbo].[DETALLE_OC] ([Id_Detalle], [Id_OrdenCompra], [Nombre_Insumo], [Cantidad_Solicitada], [Cantidad_Recibida]) VALUES (37, 31, N'Queso Tybo', 45, 45)
INSERT [dbo].[DETALLE_OC] ([Id_Detalle], [Id_OrdenCompra], [Nombre_Insumo], [Cantidad_Solicitada], [Cantidad_Recibida]) VALUES (38, 32, N'Helado de Dulce de Leche', 55, 55)
INSERT [dbo].[DETALLE_OC] ([Id_Detalle], [Id_OrdenCompra], [Nombre_Insumo], [Cantidad_Solicitada], [Cantidad_Recibida]) VALUES (39, 33, N'Lomo de Ternera', 90, 90)
INSERT [dbo].[DETALLE_OC] ([Id_Detalle], [Id_OrdenCompra], [Nombre_Insumo], [Cantidad_Solicitada], [Cantidad_Recibida]) VALUES (40, 34, N'Papas para Guarnición', 130, 130)
INSERT [dbo].[DETALLE_OC] ([Id_Detalle], [Id_OrdenCompra], [Nombre_Insumo], [Cantidad_Solicitada], [Cantidad_Recibida]) VALUES (41, 35, N'Jamón Cocido', 25, 25)
INSERT [dbo].[DETALLE_OC] ([Id_Detalle], [Id_OrdenCompra], [Nombre_Insumo], [Cantidad_Solicitada], [Cantidad_Recibida]) VALUES (42, 36, N'Vino Malbec Premium', 100, 100)
INSERT [dbo].[DETALLE_OC] ([Id_Detalle], [Id_OrdenCompra], [Nombre_Insumo], [Cantidad_Solicitada], [Cantidad_Recibida]) VALUES (43, 37, N'Lomo de Ternera', 65, 65)
INSERT [dbo].[DETALLE_OC] ([Id_Detalle], [Id_OrdenCompra], [Nombre_Insumo], [Cantidad_Solicitada], [Cantidad_Recibida]) VALUES (44, 38, N'Papas para Guarnición', 60, 60)
INSERT [dbo].[DETALLE_OC] ([Id_Detalle], [Id_OrdenCompra], [Nombre_Insumo], [Cantidad_Solicitada], [Cantidad_Recibida]) VALUES (45, 39, N'Vino Malbec Premium', 110, 110)
INSERT [dbo].[DETALLE_OC] ([Id_Detalle], [Id_OrdenCompra], [Nombre_Insumo], [Cantidad_Solicitada], [Cantidad_Recibida]) VALUES (46, 40, N'Lomo de Ternera', 50, 50)
INSERT [dbo].[DETALLE_OC] ([Id_Detalle], [Id_OrdenCompra], [Nombre_Insumo], [Cantidad_Solicitada], [Cantidad_Recibida]) VALUES (47, 41, N'Queso Tybo', 50, 50)
INSERT [dbo].[DETALLE_OC] ([Id_Detalle], [Id_OrdenCompra], [Nombre_Insumo], [Cantidad_Solicitada], [Cantidad_Recibida]) VALUES (48, 42, N'Papas para Guarnición', 50, 50)
INSERT [dbo].[DETALLE_OC] ([Id_Detalle], [Id_OrdenCompra], [Nombre_Insumo], [Cantidad_Solicitada], [Cantidad_Recibida]) VALUES (49, 43, N'Gaseosa Cola', 30, 30)
INSERT [dbo].[DETALLE_OC] ([Id_Detalle], [Id_OrdenCompra], [Nombre_Insumo], [Cantidad_Solicitada], [Cantidad_Recibida]) VALUES (50, 44, N'Vino Malbec Premium', 150, 150)
INSERT [dbo].[DETALLE_OC] ([Id_Detalle], [Id_OrdenCompra], [Nombre_Insumo], [Cantidad_Solicitada], [Cantidad_Recibida]) VALUES (51, 45, N'Queso Tybo', 35, 35)
INSERT [dbo].[DETALLE_OC] ([Id_Detalle], [Id_OrdenCompra], [Nombre_Insumo], [Cantidad_Solicitada], [Cantidad_Recibida]) VALUES (52, 46, N'Lomo de Ternera', 60, 60)
INSERT [dbo].[DETALLE_OC] ([Id_Detalle], [Id_OrdenCompra], [Nombre_Insumo], [Cantidad_Solicitada], [Cantidad_Recibida]) VALUES (53, 47, N'Papas para Guarnición', 50, 50)
INSERT [dbo].[DETALLE_OC] ([Id_Detalle], [Id_OrdenCompra], [Nombre_Insumo], [Cantidad_Solicitada], [Cantidad_Recibida]) VALUES (54, 48, N'Lomo de Ternera', 70, 70)
INSERT [dbo].[DETALLE_OC] ([Id_Detalle], [Id_OrdenCompra], [Nombre_Insumo], [Cantidad_Solicitada], [Cantidad_Recibida]) VALUES (55, 49, N'Papas para Guarnición', 60, 60)
INSERT [dbo].[DETALLE_OC] ([Id_Detalle], [Id_OrdenCompra], [Nombre_Insumo], [Cantidad_Solicitada], [Cantidad_Recibida]) VALUES (56, 50, N'Vino Malbec Premium', 120, 120)
INSERT [dbo].[DETALLE_OC] ([Id_Detalle], [Id_OrdenCompra], [Nombre_Insumo], [Cantidad_Solicitada], [Cantidad_Recibida]) VALUES (57, 51, N'Lomo de Ternera', 55, 55)
INSERT [dbo].[DETALLE_OC] ([Id_Detalle], [Id_OrdenCompra], [Nombre_Insumo], [Cantidad_Solicitada], [Cantidad_Recibida]) VALUES (58, 52, N'Queso Tybo', 45, 45)
INSERT [dbo].[DETALLE_OC] ([Id_Detalle], [Id_OrdenCompra], [Nombre_Insumo], [Cantidad_Solicitada], [Cantidad_Recibida]) VALUES (59, 53, N'Lomo de Ternera', 60, 60)
INSERT [dbo].[DETALLE_OC] ([Id_Detalle], [Id_OrdenCompra], [Nombre_Insumo], [Cantidad_Solicitada], [Cantidad_Recibida]) VALUES (60, 54, N'Papas para Guarnición', 50, 50)
INSERT [dbo].[DETALLE_OC] ([Id_Detalle], [Id_OrdenCompra], [Nombre_Insumo], [Cantidad_Solicitada], [Cantidad_Recibida]) VALUES (61, 55, N'Vino Malbec Premium', 150, 150)
INSERT [dbo].[DETALLE_OC] ([Id_Detalle], [Id_OrdenCompra], [Nombre_Insumo], [Cantidad_Solicitada], [Cantidad_Recibida]) VALUES (1059, 1053, N'Lomo de Ternera', 100, 50)
INSERT [dbo].[DETALLE_OC] ([Id_Detalle], [Id_OrdenCompra], [Nombre_Insumo], [Cantidad_Solicitada], [Cantidad_Recibida]) VALUES (1060, 1053, N'Gaseosa Cola', 30, 0)
INSERT [dbo].[DETALLE_OC] ([Id_Detalle], [Id_OrdenCompra], [Nombre_Insumo], [Cantidad_Solicitada], [Cantidad_Recibida]) VALUES (1061, 1053, N'Helado de Dulce de Leche', 50, 0)
INSERT [dbo].[DETALLE_OC] ([Id_Detalle], [Id_OrdenCompra], [Nombre_Insumo], [Cantidad_Solicitada], [Cantidad_Recibida]) VALUES (1062, 1054, N'Gaseosa Cola', 259, 100)
INSERT [dbo].[DETALLE_OC] ([Id_Detalle], [Id_OrdenCompra], [Nombre_Insumo], [Cantidad_Solicitada], [Cantidad_Recibida]) VALUES (1063, 1054, N'Lomo de Ternera', 150, 20)
INSERT [dbo].[DETALLE_OC] ([Id_Detalle], [Id_OrdenCompra], [Nombre_Insumo], [Cantidad_Solicitada], [Cantidad_Recibida]) VALUES (1064, 1055, N'Lomo de Ternera', 120, 50)
INSERT [dbo].[DETALLE_OC] ([Id_Detalle], [Id_OrdenCompra], [Nombre_Insumo], [Cantidad_Solicitada], [Cantidad_Recibida]) VALUES (1065, 1055, N'Papas para Guarnición', 100, 30)
INSERT [dbo].[DETALLE_OC] ([Id_Detalle], [Id_OrdenCompra], [Nombre_Insumo], [Cantidad_Solicitada], [Cantidad_Recibida]) VALUES (1066, 1056, N'Vino Malbec Premium', 10, 0)
INSERT [dbo].[DETALLE_OC] ([Id_Detalle], [Id_OrdenCompra], [Nombre_Insumo], [Cantidad_Solicitada], [Cantidad_Recibida]) VALUES (1067, 1056, N'Gaseosa Cola', 20, 0)
INSERT [dbo].[DETALLE_OC] ([Id_Detalle], [Id_OrdenCompra], [Nombre_Insumo], [Cantidad_Solicitada], [Cantidad_Recibida]) VALUES (1068, 1056, N'Queso Tybo', 30, 0)
INSERT [dbo].[DETALLE_OC] ([Id_Detalle], [Id_OrdenCompra], [Nombre_Insumo], [Cantidad_Solicitada], [Cantidad_Recibida]) VALUES (1069, 1057, N'Vino Malbec Premium', 100, 0)
INSERT [dbo].[DETALLE_OC] ([Id_Detalle], [Id_OrdenCompra], [Nombre_Insumo], [Cantidad_Solicitada], [Cantidad_Recibida]) VALUES (1070, 1058, N'Lomo de Ternera', 50, 0)
INSERT [dbo].[DETALLE_OC] ([Id_Detalle], [Id_OrdenCompra], [Nombre_Insumo], [Cantidad_Solicitada], [Cantidad_Recibida]) VALUES (1071, 1059, N'Lomo de Ternera', 52, 52)
INSERT [dbo].[DETALLE_OC] ([Id_Detalle], [Id_OrdenCompra], [Nombre_Insumo], [Cantidad_Solicitada], [Cantidad_Recibida]) VALUES (1072, 1060, N'Lomo de Ternera', 65, 65)
INSERT [dbo].[DETALLE_OC] ([Id_Detalle], [Id_OrdenCompra], [Nombre_Insumo], [Cantidad_Solicitada], [Cantidad_Recibida]) VALUES (1073, 1061, N'Lomo de Ternera', 77, 77)
INSERT [dbo].[DETALLE_OC] ([Id_Detalle], [Id_OrdenCompra], [Nombre_Insumo], [Cantidad_Solicitada], [Cantidad_Recibida]) VALUES (1074, 1062, N'Lomo de Ternera', 90, 90)
INSERT [dbo].[DETALLE_OC] ([Id_Detalle], [Id_OrdenCompra], [Nombre_Insumo], [Cantidad_Solicitada], [Cantidad_Recibida]) VALUES (1075, 1063, N'Lomo de Ternera', 40, 40)
INSERT [dbo].[DETALLE_OC] ([Id_Detalle], [Id_OrdenCompra], [Nombre_Insumo], [Cantidad_Solicitada], [Cantidad_Recibida]) VALUES (1076, 1064, N'Lomo de Ternera', 52, 52)
INSERT [dbo].[DETALLE_OC] ([Id_Detalle], [Id_OrdenCompra], [Nombre_Insumo], [Cantidad_Solicitada], [Cantidad_Recibida]) VALUES (1077, 1065, N'Lomo de Ternera', 65, 65)
INSERT [dbo].[DETALLE_OC] ([Id_Detalle], [Id_OrdenCompra], [Nombre_Insumo], [Cantidad_Solicitada], [Cantidad_Recibida]) VALUES (1078, 1066, N'Lomo de Ternera', 77, 77)
INSERT [dbo].[DETALLE_OC] ([Id_Detalle], [Id_OrdenCompra], [Nombre_Insumo], [Cantidad_Solicitada], [Cantidad_Recibida]) VALUES (1079, 1067, N'Lomo de Ternera', 90, 90)
INSERT [dbo].[DETALLE_OC] ([Id_Detalle], [Id_OrdenCompra], [Nombre_Insumo], [Cantidad_Solicitada], [Cantidad_Recibida]) VALUES (1080, 1068, N'Lomo de Ternera', 40, 40)
INSERT [dbo].[DETALLE_OC] ([Id_Detalle], [Id_OrdenCompra], [Nombre_Insumo], [Cantidad_Solicitada], [Cantidad_Recibida]) VALUES (1081, 1069, N'Lomo de Ternera', 52, 52)
INSERT [dbo].[DETALLE_OC] ([Id_Detalle], [Id_OrdenCompra], [Nombre_Insumo], [Cantidad_Solicitada], [Cantidad_Recibida]) VALUES (1082, 1070, N'Lomo de Ternera', 65, 65)
INSERT [dbo].[DETALLE_OC] ([Id_Detalle], [Id_OrdenCompra], [Nombre_Insumo], [Cantidad_Solicitada], [Cantidad_Recibida]) VALUES (1083, 1071, N'Lomo de Ternera', 77, 77)
INSERT [dbo].[DETALLE_OC] ([Id_Detalle], [Id_OrdenCompra], [Nombre_Insumo], [Cantidad_Solicitada], [Cantidad_Recibida]) VALUES (1084, 1072, N'Lomo de Ternera', 90, 90)
INSERT [dbo].[DETALLE_OC] ([Id_Detalle], [Id_OrdenCompra], [Nombre_Insumo], [Cantidad_Solicitada], [Cantidad_Recibida]) VALUES (1085, 1073, N'Lomo de Ternera', 40, 40)
INSERT [dbo].[DETALLE_OC] ([Id_Detalle], [Id_OrdenCompra], [Nombre_Insumo], [Cantidad_Solicitada], [Cantidad_Recibida]) VALUES (1086, 1074, N'Lomo de Ternera', 52, 52)
INSERT [dbo].[DETALLE_OC] ([Id_Detalle], [Id_OrdenCompra], [Nombre_Insumo], [Cantidad_Solicitada], [Cantidad_Recibida]) VALUES (1087, 1075, N'Lomo de Ternera', 65, 65)
INSERT [dbo].[DETALLE_OC] ([Id_Detalle], [Id_OrdenCompra], [Nombre_Insumo], [Cantidad_Solicitada], [Cantidad_Recibida]) VALUES (1088, 1076, N'Lomo de Ternera', 77, 77)
INSERT [dbo].[DETALLE_OC] ([Id_Detalle], [Id_OrdenCompra], [Nombre_Insumo], [Cantidad_Solicitada], [Cantidad_Recibida]) VALUES (1089, 1077, N'Lomo de Ternera', 90, 90)
INSERT [dbo].[DETALLE_OC] ([Id_Detalle], [Id_OrdenCompra], [Nombre_Insumo], [Cantidad_Solicitada], [Cantidad_Recibida]) VALUES (1090, 1078, N'Lomo de Ternera', 40, 40)
INSERT [dbo].[DETALLE_OC] ([Id_Detalle], [Id_OrdenCompra], [Nombre_Insumo], [Cantidad_Solicitada], [Cantidad_Recibida]) VALUES (1091, 1079, N'Lomo de Ternera', 52, 52)
INSERT [dbo].[DETALLE_OC] ([Id_Detalle], [Id_OrdenCompra], [Nombre_Insumo], [Cantidad_Solicitada], [Cantidad_Recibida]) VALUES (1092, 1080, N'Lomo de Ternera', 65, 65)
INSERT [dbo].[DETALLE_OC] ([Id_Detalle], [Id_OrdenCompra], [Nombre_Insumo], [Cantidad_Solicitada], [Cantidad_Recibida]) VALUES (1093, 1081, N'Lomo de Ternera', 77, 77)
INSERT [dbo].[DETALLE_OC] ([Id_Detalle], [Id_OrdenCompra], [Nombre_Insumo], [Cantidad_Solicitada], [Cantidad_Recibida]) VALUES (1094, 1082, N'Lomo de Ternera', 90, 90)
INSERT [dbo].[DETALLE_OC] ([Id_Detalle], [Id_OrdenCompra], [Nombre_Insumo], [Cantidad_Solicitada], [Cantidad_Recibida]) VALUES (1095, 1083, N'Lomo de Ternera', 40, 40)
INSERT [dbo].[DETALLE_OC] ([Id_Detalle], [Id_OrdenCompra], [Nombre_Insumo], [Cantidad_Solicitada], [Cantidad_Recibida]) VALUES (1096, 1084, N'Lomo de Ternera', 52, 52)
GO
INSERT [dbo].[DETALLE_OC] ([Id_Detalle], [Id_OrdenCompra], [Nombre_Insumo], [Cantidad_Solicitada], [Cantidad_Recibida]) VALUES (1097, 1085, N'Lomo de Ternera', 65, 65)
INSERT [dbo].[DETALLE_OC] ([Id_Detalle], [Id_OrdenCompra], [Nombre_Insumo], [Cantidad_Solicitada], [Cantidad_Recibida]) VALUES (1098, 1086, N'Lomo de Ternera', 77, 77)
INSERT [dbo].[DETALLE_OC] ([Id_Detalle], [Id_OrdenCompra], [Nombre_Insumo], [Cantidad_Solicitada], [Cantidad_Recibida]) VALUES (1099, 1087, N'Lomo de Ternera', 90, 90)
INSERT [dbo].[DETALLE_OC] ([Id_Detalle], [Id_OrdenCompra], [Nombre_Insumo], [Cantidad_Solicitada], [Cantidad_Recibida]) VALUES (1100, 1088, N'Lomo de Ternera', 40, 40)
INSERT [dbo].[DETALLE_OC] ([Id_Detalle], [Id_OrdenCompra], [Nombre_Insumo], [Cantidad_Solicitada], [Cantidad_Recibida]) VALUES (1101, 1089, N'Lomo de Ternera', 52, 52)
INSERT [dbo].[DETALLE_OC] ([Id_Detalle], [Id_OrdenCompra], [Nombre_Insumo], [Cantidad_Solicitada], [Cantidad_Recibida]) VALUES (1102, 1090, N'Lomo de Ternera', 65, 65)
INSERT [dbo].[DETALLE_OC] ([Id_Detalle], [Id_OrdenCompra], [Nombre_Insumo], [Cantidad_Solicitada], [Cantidad_Recibida]) VALUES (1103, 1091, N'Lomo de Ternera', 77, 77)
INSERT [dbo].[DETALLE_OC] ([Id_Detalle], [Id_OrdenCompra], [Nombre_Insumo], [Cantidad_Solicitada], [Cantidad_Recibida]) VALUES (1104, 1092, N'Lomo de Ternera', 90, 90)
INSERT [dbo].[DETALLE_OC] ([Id_Detalle], [Id_OrdenCompra], [Nombre_Insumo], [Cantidad_Solicitada], [Cantidad_Recibida]) VALUES (1105, 1093, N'Lomo de Ternera', 40, 40)
INSERT [dbo].[DETALLE_OC] ([Id_Detalle], [Id_OrdenCompra], [Nombre_Insumo], [Cantidad_Solicitada], [Cantidad_Recibida]) VALUES (1106, 1094, N'Lomo de Ternera', 52, 52)
INSERT [dbo].[DETALLE_OC] ([Id_Detalle], [Id_OrdenCompra], [Nombre_Insumo], [Cantidad_Solicitada], [Cantidad_Recibida]) VALUES (1107, 1095, N'Lomo de Ternera', 65, 65)
INSERT [dbo].[DETALLE_OC] ([Id_Detalle], [Id_OrdenCompra], [Nombre_Insumo], [Cantidad_Solicitada], [Cantidad_Recibida]) VALUES (1108, 1096, N'Lomo de Ternera', 77, 77)
INSERT [dbo].[DETALLE_OC] ([Id_Detalle], [Id_OrdenCompra], [Nombre_Insumo], [Cantidad_Solicitada], [Cantidad_Recibida]) VALUES (1109, 1097, N'Lomo de Ternera', 90, 90)
INSERT [dbo].[DETALLE_OC] ([Id_Detalle], [Id_OrdenCompra], [Nombre_Insumo], [Cantidad_Solicitada], [Cantidad_Recibida]) VALUES (1110, 1098, N'Lomo de Ternera', 40, 40)
INSERT [dbo].[DETALLE_OC] ([Id_Detalle], [Id_OrdenCompra], [Nombre_Insumo], [Cantidad_Solicitada], [Cantidad_Recibida]) VALUES (1111, 1099, N'Lomo de Ternera', 52, 52)
INSERT [dbo].[DETALLE_OC] ([Id_Detalle], [Id_OrdenCompra], [Nombre_Insumo], [Cantidad_Solicitada], [Cantidad_Recibida]) VALUES (1112, 1100, N'Lomo de Ternera', 65, 65)
INSERT [dbo].[DETALLE_OC] ([Id_Detalle], [Id_OrdenCompra], [Nombre_Insumo], [Cantidad_Solicitada], [Cantidad_Recibida]) VALUES (1113, 1101, N'Lomo de Ternera', 77, 77)
INSERT [dbo].[DETALLE_OC] ([Id_Detalle], [Id_OrdenCompra], [Nombre_Insumo], [Cantidad_Solicitada], [Cantidad_Recibida]) VALUES (1114, 1102, N'Lomo de Ternera', 90, 90)
INSERT [dbo].[DETALLE_OC] ([Id_Detalle], [Id_OrdenCompra], [Nombre_Insumo], [Cantidad_Solicitada], [Cantidad_Recibida]) VALUES (1115, 1103, N'Lomo de Ternera', 40, 40)
INSERT [dbo].[DETALLE_OC] ([Id_Detalle], [Id_OrdenCompra], [Nombre_Insumo], [Cantidad_Solicitada], [Cantidad_Recibida]) VALUES (1116, 1104, N'Lomo de Ternera', 52, 52)
INSERT [dbo].[DETALLE_OC] ([Id_Detalle], [Id_OrdenCompra], [Nombre_Insumo], [Cantidad_Solicitada], [Cantidad_Recibida]) VALUES (1117, 1105, N'Lomo de Ternera', 65, 65)
INSERT [dbo].[DETALLE_OC] ([Id_Detalle], [Id_OrdenCompra], [Nombre_Insumo], [Cantidad_Solicitada], [Cantidad_Recibida]) VALUES (1118, 1106, N'Lomo de Ternera', 77, 77)
INSERT [dbo].[DETALLE_OC] ([Id_Detalle], [Id_OrdenCompra], [Nombre_Insumo], [Cantidad_Solicitada], [Cantidad_Recibida]) VALUES (1119, 1107, N'Lomo de Ternera', 90, 90)
INSERT [dbo].[DETALLE_OC] ([Id_Detalle], [Id_OrdenCompra], [Nombre_Insumo], [Cantidad_Solicitada], [Cantidad_Recibida]) VALUES (1120, 1108, N'Lomo de Ternera', 40, 40)
INSERT [dbo].[DETALLE_OC] ([Id_Detalle], [Id_OrdenCompra], [Nombre_Insumo], [Cantidad_Solicitada], [Cantidad_Recibida]) VALUES (1121, 1109, N'Lomo de Ternera', 52, 52)
INSERT [dbo].[DETALLE_OC] ([Id_Detalle], [Id_OrdenCompra], [Nombre_Insumo], [Cantidad_Solicitada], [Cantidad_Recibida]) VALUES (1122, 1110, N'Lomo de Ternera', 65, 65)
INSERT [dbo].[DETALLE_OC] ([Id_Detalle], [Id_OrdenCompra], [Nombre_Insumo], [Cantidad_Solicitada], [Cantidad_Recibida]) VALUES (1123, 1111, N'Lomo de Ternera', 77, 77)
INSERT [dbo].[DETALLE_OC] ([Id_Detalle], [Id_OrdenCompra], [Nombre_Insumo], [Cantidad_Solicitada], [Cantidad_Recibida]) VALUES (1124, 1112, N'Lomo de Ternera', 90, 90)
INSERT [dbo].[DETALLE_OC] ([Id_Detalle], [Id_OrdenCompra], [Nombre_Insumo], [Cantidad_Solicitada], [Cantidad_Recibida]) VALUES (1181, 1169, N'Lomo de Ternera', 100, 0)
INSERT [dbo].[DETALLE_OC] ([Id_Detalle], [Id_OrdenCompra], [Nombre_Insumo], [Cantidad_Solicitada], [Cantidad_Recibida]) VALUES (1182, 1169, N'Papas para Guarnición', 200, 0)
INSERT [dbo].[DETALLE_OC] ([Id_Detalle], [Id_OrdenCompra], [Nombre_Insumo], [Cantidad_Solicitada], [Cantidad_Recibida]) VALUES (1183, 1169, N'Helado de Dulce de Leche', 150, 0)
INSERT [dbo].[DETALLE_OC] ([Id_Detalle], [Id_OrdenCompra], [Nombre_Insumo], [Cantidad_Solicitada], [Cantidad_Recibida]) VALUES (1184, 1169, N'Vino Malbec Premium', 25, 0)
SET IDENTITY_INSERT [dbo].[DETALLE_OC] OFF
GO
INSERT [dbo].[DIGITO_VERIFICADOR] ([TABLA], [DVV]) VALUES (N'USUARIO', N'e9ed7a5641a3d754064d47dd1a9f117f3f861dd297882c43411fbdce49e18560')
GO
INSERT [dbo].[FICHA_PRESTADORES] ([Id_Ficha], [Id_Prestador]) VALUES (3, 1)
INSERT [dbo].[FICHA_PRESTADORES] ([Id_Ficha], [Id_Prestador]) VALUES (3, 4)
INSERT [dbo].[FICHA_PRESTADORES] ([Id_Ficha], [Id_Prestador]) VALUES (4, 1)
INSERT [dbo].[FICHA_PRESTADORES] ([Id_Ficha], [Id_Prestador]) VALUES (4, 2)
INSERT [dbo].[FICHA_PRESTADORES] ([Id_Ficha], [Id_Prestador]) VALUES (4, 3)
INSERT [dbo].[FICHA_PRESTADORES] ([Id_Ficha], [Id_Prestador]) VALUES (4, 4)
INSERT [dbo].[FICHA_PRESTADORES] ([Id_Ficha], [Id_Prestador]) VALUES (5, 4)
INSERT [dbo].[FICHA_PRESTADORES] ([Id_Ficha], [Id_Prestador]) VALUES (8, 1)
INSERT [dbo].[FICHA_PRESTADORES] ([Id_Ficha], [Id_Prestador]) VALUES (8, 2)
INSERT [dbo].[FICHA_PRESTADORES] ([Id_Ficha], [Id_Prestador]) VALUES (9, 1)
INSERT [dbo].[FICHA_PRESTADORES] ([Id_Ficha], [Id_Prestador]) VALUES (9, 2)
INSERT [dbo].[FICHA_PRESTADORES] ([Id_Ficha], [Id_Prestador]) VALUES (10, 1)
INSERT [dbo].[FICHA_PRESTADORES] ([Id_Ficha], [Id_Prestador]) VALUES (10, 4)
INSERT [dbo].[FICHA_PRESTADORES] ([Id_Ficha], [Id_Prestador]) VALUES (11, 3)
INSERT [dbo].[FICHA_PRESTADORES] ([Id_Ficha], [Id_Prestador]) VALUES (12, 1)
INSERT [dbo].[FICHA_PRESTADORES] ([Id_Ficha], [Id_Prestador]) VALUES (12, 2)
INSERT [dbo].[FICHA_PRESTADORES] ([Id_Ficha], [Id_Prestador]) VALUES (13, 3)
INSERT [dbo].[FICHA_PRESTADORES] ([Id_Ficha], [Id_Prestador]) VALUES (14, 1)
INSERT [dbo].[FICHA_PRESTADORES] ([Id_Ficha], [Id_Prestador]) VALUES (14, 4)
INSERT [dbo].[FICHA_PRESTADORES] ([Id_Ficha], [Id_Prestador]) VALUES (15, 2)
INSERT [dbo].[FICHA_PRESTADORES] ([Id_Ficha], [Id_Prestador]) VALUES (16, 3)
INSERT [dbo].[FICHA_PRESTADORES] ([Id_Ficha], [Id_Prestador]) VALUES (17, 1)
INSERT [dbo].[FICHA_PRESTADORES] ([Id_Ficha], [Id_Prestador]) VALUES (18, 1)
INSERT [dbo].[FICHA_PRESTADORES] ([Id_Ficha], [Id_Prestador]) VALUES (19, 1)
INSERT [dbo].[FICHA_PRESTADORES] ([Id_Ficha], [Id_Prestador]) VALUES (19, 2)
INSERT [dbo].[FICHA_PRESTADORES] ([Id_Ficha], [Id_Prestador]) VALUES (20, 3)
INSERT [dbo].[FICHA_PRESTADORES] ([Id_Ficha], [Id_Prestador]) VALUES (20, 4)
INSERT [dbo].[FICHA_PRESTADORES] ([Id_Ficha], [Id_Prestador]) VALUES (21, 2)
INSERT [dbo].[FICHA_PRESTADORES] ([Id_Ficha], [Id_Prestador]) VALUES (22, 1)
INSERT [dbo].[FICHA_PRESTADORES] ([Id_Ficha], [Id_Prestador]) VALUES (23, 3)
INSERT [dbo].[FICHA_PRESTADORES] ([Id_Ficha], [Id_Prestador]) VALUES (24, 2)
INSERT [dbo].[FICHA_PRESTADORES] ([Id_Ficha], [Id_Prestador]) VALUES (25, 4)
INSERT [dbo].[FICHA_PRESTADORES] ([Id_Ficha], [Id_Prestador]) VALUES (26, 1)
INSERT [dbo].[FICHA_PRESTADORES] ([Id_Ficha], [Id_Prestador]) VALUES (27, 1)
INSERT [dbo].[FICHA_PRESTADORES] ([Id_Ficha], [Id_Prestador]) VALUES (27, 2)
INSERT [dbo].[FICHA_PRESTADORES] ([Id_Ficha], [Id_Prestador]) VALUES (43, 1)
INSERT [dbo].[FICHA_PRESTADORES] ([Id_Ficha], [Id_Prestador]) VALUES (43, 2)
INSERT [dbo].[FICHA_PRESTADORES] ([Id_Ficha], [Id_Prestador]) VALUES (44, 1)
INSERT [dbo].[FICHA_PRESTADORES] ([Id_Ficha], [Id_Prestador]) VALUES (44, 3)
INSERT [dbo].[FICHA_PRESTADORES] ([Id_Ficha], [Id_Prestador]) VALUES (44, 4)
INSERT [dbo].[FICHA_PRESTADORES] ([Id_Ficha], [Id_Prestador]) VALUES (46, 1)
INSERT [dbo].[FICHA_PRESTADORES] ([Id_Ficha], [Id_Prestador]) VALUES (46, 2)
INSERT [dbo].[FICHA_PRESTADORES] ([Id_Ficha], [Id_Prestador]) VALUES (48, 3)
INSERT [dbo].[FICHA_PRESTADORES] ([Id_Ficha], [Id_Prestador]) VALUES (49, 1)
INSERT [dbo].[FICHA_PRESTADORES] ([Id_Ficha], [Id_Prestador]) VALUES (49, 2)
INSERT [dbo].[FICHA_PRESTADORES] ([Id_Ficha], [Id_Prestador]) VALUES (50, 3)
INSERT [dbo].[FICHA_PRESTADORES] ([Id_Ficha], [Id_Prestador]) VALUES (51, 1)
INSERT [dbo].[FICHA_PRESTADORES] ([Id_Ficha], [Id_Prestador]) VALUES (51, 4)
INSERT [dbo].[FICHA_PRESTADORES] ([Id_Ficha], [Id_Prestador]) VALUES (52, 2)
INSERT [dbo].[FICHA_PRESTADORES] ([Id_Ficha], [Id_Prestador]) VALUES (53, 1)
INSERT [dbo].[FICHA_PRESTADORES] ([Id_Ficha], [Id_Prestador]) VALUES (54, 1)
INSERT [dbo].[FICHA_PRESTADORES] ([Id_Ficha], [Id_Prestador]) VALUES (54, 2)
INSERT [dbo].[FICHA_PRESTADORES] ([Id_Ficha], [Id_Prestador]) VALUES (55, 3)
INSERT [dbo].[FICHA_PRESTADORES] ([Id_Ficha], [Id_Prestador]) VALUES (56, 1)
INSERT [dbo].[FICHA_PRESTADORES] ([Id_Ficha], [Id_Prestador]) VALUES (56, 4)
INSERT [dbo].[FICHA_PRESTADORES] ([Id_Ficha], [Id_Prestador]) VALUES (1055, 1)
INSERT [dbo].[FICHA_PRESTADORES] ([Id_Ficha], [Id_Prestador]) VALUES (1055, 2)
INSERT [dbo].[FICHA_PRESTADORES] ([Id_Ficha], [Id_Prestador]) VALUES (1055, 3)
INSERT [dbo].[FICHA_PRESTADORES] ([Id_Ficha], [Id_Prestador]) VALUES (1055, 4)
INSERT [dbo].[FICHA_PRESTADORES] ([Id_Ficha], [Id_Prestador]) VALUES (1056, 1)
INSERT [dbo].[FICHA_PRESTADORES] ([Id_Ficha], [Id_Prestador]) VALUES (1057, 1)
INSERT [dbo].[FICHA_PRESTADORES] ([Id_Ficha], [Id_Prestador]) VALUES (1058, 1)
INSERT [dbo].[FICHA_PRESTADORES] ([Id_Ficha], [Id_Prestador]) VALUES (1059, 1)
INSERT [dbo].[FICHA_PRESTADORES] ([Id_Ficha], [Id_Prestador]) VALUES (1060, 1)
INSERT [dbo].[FICHA_PRESTADORES] ([Id_Ficha], [Id_Prestador]) VALUES (1061, 1)
INSERT [dbo].[FICHA_PRESTADORES] ([Id_Ficha], [Id_Prestador]) VALUES (1062, 1)
INSERT [dbo].[FICHA_PRESTADORES] ([Id_Ficha], [Id_Prestador]) VALUES (1063, 1)
INSERT [dbo].[FICHA_PRESTADORES] ([Id_Ficha], [Id_Prestador]) VALUES (1064, 1)
INSERT [dbo].[FICHA_PRESTADORES] ([Id_Ficha], [Id_Prestador]) VALUES (1065, 1)
INSERT [dbo].[FICHA_PRESTADORES] ([Id_Ficha], [Id_Prestador]) VALUES (1066, 1)
INSERT [dbo].[FICHA_PRESTADORES] ([Id_Ficha], [Id_Prestador]) VALUES (1067, 1)
INSERT [dbo].[FICHA_PRESTADORES] ([Id_Ficha], [Id_Prestador]) VALUES (1068, 1)
INSERT [dbo].[FICHA_PRESTADORES] ([Id_Ficha], [Id_Prestador]) VALUES (1069, 1)
INSERT [dbo].[FICHA_PRESTADORES] ([Id_Ficha], [Id_Prestador]) VALUES (1070, 1)
INSERT [dbo].[FICHA_PRESTADORES] ([Id_Ficha], [Id_Prestador]) VALUES (1071, 1)
INSERT [dbo].[FICHA_PRESTADORES] ([Id_Ficha], [Id_Prestador]) VALUES (1072, 1)
INSERT [dbo].[FICHA_PRESTADORES] ([Id_Ficha], [Id_Prestador]) VALUES (1073, 1)
INSERT [dbo].[FICHA_PRESTADORES] ([Id_Ficha], [Id_Prestador]) VALUES (1074, 1)
INSERT [dbo].[FICHA_PRESTADORES] ([Id_Ficha], [Id_Prestador]) VALUES (1075, 1)
INSERT [dbo].[FICHA_PRESTADORES] ([Id_Ficha], [Id_Prestador]) VALUES (1076, 1)
INSERT [dbo].[FICHA_PRESTADORES] ([Id_Ficha], [Id_Prestador]) VALUES (1077, 1)
INSERT [dbo].[FICHA_PRESTADORES] ([Id_Ficha], [Id_Prestador]) VALUES (1078, 1)
INSERT [dbo].[FICHA_PRESTADORES] ([Id_Ficha], [Id_Prestador]) VALUES (1079, 1)
INSERT [dbo].[FICHA_PRESTADORES] ([Id_Ficha], [Id_Prestador]) VALUES (1080, 1)
INSERT [dbo].[FICHA_PRESTADORES] ([Id_Ficha], [Id_Prestador]) VALUES (1081, 1)
INSERT [dbo].[FICHA_PRESTADORES] ([Id_Ficha], [Id_Prestador]) VALUES (1082, 1)
INSERT [dbo].[FICHA_PRESTADORES] ([Id_Ficha], [Id_Prestador]) VALUES (1083, 1)
INSERT [dbo].[FICHA_PRESTADORES] ([Id_Ficha], [Id_Prestador]) VALUES (1084, 1)
INSERT [dbo].[FICHA_PRESTADORES] ([Id_Ficha], [Id_Prestador]) VALUES (1085, 1)
INSERT [dbo].[FICHA_PRESTADORES] ([Id_Ficha], [Id_Prestador]) VALUES (1086, 1)
INSERT [dbo].[FICHA_PRESTADORES] ([Id_Ficha], [Id_Prestador]) VALUES (1087, 1)
INSERT [dbo].[FICHA_PRESTADORES] ([Id_Ficha], [Id_Prestador]) VALUES (1088, 1)
INSERT [dbo].[FICHA_PRESTADORES] ([Id_Ficha], [Id_Prestador]) VALUES (1089, 1)
INSERT [dbo].[FICHA_PRESTADORES] ([Id_Ficha], [Id_Prestador]) VALUES (1090, 1)
INSERT [dbo].[FICHA_PRESTADORES] ([Id_Ficha], [Id_Prestador]) VALUES (1091, 1)
INSERT [dbo].[FICHA_PRESTADORES] ([Id_Ficha], [Id_Prestador]) VALUES (1092, 1)
INSERT [dbo].[FICHA_PRESTADORES] ([Id_Ficha], [Id_Prestador]) VALUES (1093, 1)
INSERT [dbo].[FICHA_PRESTADORES] ([Id_Ficha], [Id_Prestador]) VALUES (1094, 1)
INSERT [dbo].[FICHA_PRESTADORES] ([Id_Ficha], [Id_Prestador]) VALUES (1095, 1)
INSERT [dbo].[FICHA_PRESTADORES] ([Id_Ficha], [Id_Prestador]) VALUES (1096, 1)
GO
INSERT [dbo].[FICHA_PRESTADORES] ([Id_Ficha], [Id_Prestador]) VALUES (1097, 1)
INSERT [dbo].[FICHA_PRESTADORES] ([Id_Ficha], [Id_Prestador]) VALUES (1098, 1)
INSERT [dbo].[FICHA_PRESTADORES] ([Id_Ficha], [Id_Prestador]) VALUES (1099, 1)
INSERT [dbo].[FICHA_PRESTADORES] ([Id_Ficha], [Id_Prestador]) VALUES (1100, 1)
INSERT [dbo].[FICHA_PRESTADORES] ([Id_Ficha], [Id_Prestador]) VALUES (1101, 1)
INSERT [dbo].[FICHA_PRESTADORES] ([Id_Ficha], [Id_Prestador]) VALUES (1102, 1)
INSERT [dbo].[FICHA_PRESTADORES] ([Id_Ficha], [Id_Prestador]) VALUES (1103, 1)
INSERT [dbo].[FICHA_PRESTADORES] ([Id_Ficha], [Id_Prestador]) VALUES (1104, 1)
INSERT [dbo].[FICHA_PRESTADORES] ([Id_Ficha], [Id_Prestador]) VALUES (1105, 1)
INSERT [dbo].[FICHA_PRESTADORES] ([Id_Ficha], [Id_Prestador]) VALUES (1106, 1)
INSERT [dbo].[FICHA_PRESTADORES] ([Id_Ficha], [Id_Prestador]) VALUES (1107, 1)
INSERT [dbo].[FICHA_PRESTADORES] ([Id_Ficha], [Id_Prestador]) VALUES (1108, 1)
INSERT [dbo].[FICHA_PRESTADORES] ([Id_Ficha], [Id_Prestador]) VALUES (1109, 1)
GO
SET IDENTITY_INSERT [dbo].[FICHA_TECNICA] ON 

INSERT [dbo].[FICHA_TECNICA] ([Id_Ficha], [Id_Reserva], [Id_Usuario], [Id_Servicio], [Cantidad_Invitados_Final], [Tipo_Evento], [Observaciones]) VALUES (1, 5, 1, 1, 100, N'Casamiento', NULL)
INSERT [dbo].[FICHA_TECNICA] ([Id_Ficha], [Id_Reserva], [Id_Usuario], [Id_Servicio], [Cantidad_Invitados_Final], [Tipo_Evento], [Observaciones]) VALUES (2, 5, 1, 1, 100, N'Casamiento', NULL)
INSERT [dbo].[FICHA_TECNICA] ([Id_Ficha], [Id_Reserva], [Id_Usuario], [Id_Servicio], [Cantidad_Invitados_Final], [Tipo_Evento], [Observaciones]) VALUES (3, 6, 1, 1, 100, N'Casamiento', NULL)
INSERT [dbo].[FICHA_TECNICA] ([Id_Ficha], [Id_Reserva], [Id_Usuario], [Id_Servicio], [Cantidad_Invitados_Final], [Tipo_Evento], [Observaciones]) VALUES (4, 7, 1, 4, 19, N'Casamiento', NULL)
INSERT [dbo].[FICHA_TECNICA] ([Id_Ficha], [Id_Reserva], [Id_Usuario], [Id_Servicio], [Cantidad_Invitados_Final], [Tipo_Evento], [Observaciones]) VALUES (5, 5, 1, 6, 50, N'Casamiento', NULL)
INSERT [dbo].[FICHA_TECNICA] ([Id_Ficha], [Id_Reserva], [Id_Usuario], [Id_Servicio], [Cantidad_Invitados_Final], [Tipo_Evento], [Observaciones]) VALUES (8, 9, 1, 6, 100, N'Evento Corporativo', NULL)
INSERT [dbo].[FICHA_TECNICA] ([Id_Ficha], [Id_Reserva], [Id_Usuario], [Id_Servicio], [Cantidad_Invitados_Final], [Tipo_Evento], [Observaciones]) VALUES (9, 10, 1, 2, 120, N'Casamiento', N'Menú Premium con recepción ampliada y barra libre')
INSERT [dbo].[FICHA_TECNICA] ([Id_Ficha], [Id_Reserva], [Id_Usuario], [Id_Servicio], [Cantidad_Invitados_Final], [Tipo_Evento], [Observaciones]) VALUES (10, 11, 1, 7, 200, N'Evento Corporativo', N'Cena formal con maridaje corporativo anual')
INSERT [dbo].[FICHA_TECNICA] ([Id_Ficha], [Id_Reserva], [Id_Usuario], [Id_Servicio], [Cantidad_Invitados_Final], [Tipo_Evento], [Observaciones]) VALUES (11, 12, 1, 6, 50, N'Casamiento', N'Evento íntimo, menú criollo tradicional')
INSERT [dbo].[FICHA_TECNICA] ([Id_Ficha], [Id_Reserva], [Id_Usuario], [Id_Servicio], [Cantidad_Invitados_Final], [Tipo_Evento], [Observaciones]) VALUES (12, 13, 1, 2, 150, N'Casamiento', N'Menú Premium 3 pasos con recepción completa.')
INSERT [dbo].[FICHA_TECNICA] ([Id_Ficha], [Id_Reserva], [Id_Usuario], [Id_Servicio], [Cantidad_Invitados_Final], [Tipo_Evento], [Observaciones]) VALUES (13, 14, 1, 1, 90, N'Cumpleaños 15', N'Menú informal, finger food y barra de tragos.')
INSERT [dbo].[FICHA_TECNICA] ([Id_Ficha], [Id_Reserva], [Id_Usuario], [Id_Servicio], [Cantidad_Invitados_Final], [Tipo_Evento], [Observaciones]) VALUES (14, 15, 1, 7, 250, N'Evento Corporativo', N'Cena formal ejecutiva con islas gastronómicas.')
INSERT [dbo].[FICHA_TECNICA] ([Id_Ficha], [Id_Reserva], [Id_Usuario], [Id_Servicio], [Cantidad_Invitados_Final], [Tipo_Evento], [Observaciones]) VALUES (15, 16, 1, 6, 110, N'Aniversario', N'Servicio criollo tradicional con parrilla completa.')
INSERT [dbo].[FICHA_TECNICA] ([Id_Ficha], [Id_Reserva], [Id_Usuario], [Id_Servicio], [Cantidad_Invitados_Final], [Tipo_Evento], [Observaciones]) VALUES (16, 17, 1, 2, 70, N'Casamiento', N'Menú vegetariano y gourmet.')
INSERT [dbo].[FICHA_TECNICA] ([Id_Ficha], [Id_Reserva], [Id_Usuario], [Id_Servicio], [Cantidad_Invitados_Final], [Tipo_Evento], [Observaciones]) VALUES (17, 18, 1, 7, 130, N'Fiesta Empresarial', N'Servicio de gala formal.')
INSERT [dbo].[FICHA_TECNICA] ([Id_Ficha], [Id_Reserva], [Id_Usuario], [Id_Servicio], [Cantidad_Invitados_Final], [Tipo_Evento], [Observaciones]) VALUES (18, 19, 1, 1, 100, N'Cumpleaños 50', N'Recepción en jardín y menú formal 2 pasos.')
INSERT [dbo].[FICHA_TECNICA] ([Id_Ficha], [Id_Reserva], [Id_Usuario], [Id_Servicio], [Cantidad_Invitados_Final], [Tipo_Evento], [Observaciones]) VALUES (19, 20, 1, 2, 180, N'Casamiento', N'Menú Premium 3 pasos con mesa dulce.')
INSERT [dbo].[FICHA_TECNICA] ([Id_Ficha], [Id_Reserva], [Id_Usuario], [Id_Servicio], [Cantidad_Invitados_Final], [Tipo_Evento], [Observaciones]) VALUES (20, 21, 1, 7, 300, N'Evento Corporativo', N'Cocktail reception con islas de comida gourmet.')
INSERT [dbo].[FICHA_TECNICA] ([Id_Ficha], [Id_Reserva], [Id_Usuario], [Id_Servicio], [Cantidad_Invitados_Final], [Tipo_Evento], [Observaciones]) VALUES (21, 22, 1, 6, 60, N'Aniversario', N'Servicio criollo íntimo.')
INSERT [dbo].[FICHA_TECNICA] ([Id_Ficha], [Id_Reserva], [Id_Usuario], [Id_Servicio], [Cantidad_Invitados_Final], [Tipo_Evento], [Observaciones]) VALUES (22, 23, 1, 7, 200, N'Fiesta Fin de Año', N'Cena formal corporativa y barra libre toda la noche.')
INSERT [dbo].[FICHA_TECNICA] ([Id_Ficha], [Id_Reserva], [Id_Usuario], [Id_Servicio], [Cantidad_Invitados_Final], [Tipo_Evento], [Observaciones]) VALUES (23, 24, 1, 1, 120, N'Cumpleaños 15', N'Menú informal juvenil y finger food para adultos.')
INSERT [dbo].[FICHA_TECNICA] ([Id_Ficha], [Id_Reserva], [Id_Usuario], [Id_Servicio], [Cantidad_Invitados_Final], [Tipo_Evento], [Observaciones]) VALUES (24, 25, 1, 2, 140, N'Casamiento', N'Plato principal gourmet y cascada de chocolate.')
INSERT [dbo].[FICHA_TECNICA] ([Id_Ficha], [Id_Reserva], [Id_Usuario], [Id_Servicio], [Cantidad_Invitados_Final], [Tipo_Evento], [Observaciones]) VALUES (25, 26, 1, 7, 160, N'Congreso', N'Catering para jornadas con coffee breaks e islas saladas.')
INSERT [dbo].[FICHA_TECNICA] ([Id_Ficha], [Id_Reserva], [Id_Usuario], [Id_Servicio], [Cantidad_Invitados_Final], [Tipo_Evento], [Observaciones]) VALUES (26, 27, 1, 6, 85, N'Bautismo', N'Menú criollo familiar en salón principal.')
INSERT [dbo].[FICHA_TECNICA] ([Id_Ficha], [Id_Reserva], [Id_Usuario], [Id_Servicio], [Cantidad_Invitados_Final], [Tipo_Evento], [Observaciones]) VALUES (27, 28, 1, 2, 220, N'Gala Benéfica', N'Cena de gala de 4 pasos con maridaje de vinos.')
INSERT [dbo].[FICHA_TECNICA] ([Id_Ficha], [Id_Reserva], [Id_Usuario], [Id_Servicio], [Cantidad_Invitados_Final], [Tipo_Evento], [Observaciones]) VALUES (28, 29, 1, 2, 120, N'Casamiento', N'Menú Premium 3 pasos.')
INSERT [dbo].[FICHA_TECNICA] ([Id_Ficha], [Id_Reserva], [Id_Usuario], [Id_Servicio], [Cantidad_Invitados_Final], [Tipo_Evento], [Observaciones]) VALUES (29, 30, 1, 1, 95, N'Cumpleaños 50', N'Menú informal y finger food.')
INSERT [dbo].[FICHA_TECNICA] ([Id_Ficha], [Id_Reserva], [Id_Usuario], [Id_Servicio], [Cantidad_Invitados_Final], [Tipo_Evento], [Observaciones]) VALUES (30, 31, 1, 7, 280, N'Evento Corporativo', N'Cocktail y cena formal.')
INSERT [dbo].[FICHA_TECNICA] ([Id_Ficha], [Id_Reserva], [Id_Usuario], [Id_Servicio], [Cantidad_Invitados_Final], [Tipo_Evento], [Observaciones]) VALUES (31, 32, 1, 6, 150, N'Aniversario', N'Servicio criollo a las brasas.')
INSERT [dbo].[FICHA_TECNICA] ([Id_Ficha], [Id_Reserva], [Id_Usuario], [Id_Servicio], [Cantidad_Invitados_Final], [Tipo_Evento], [Observaciones]) VALUES (32, 33, 1, 7, 180, N'Gala Benéfica', N'Cena formal ejecutiva.')
INSERT [dbo].[FICHA_TECNICA] ([Id_Ficha], [Id_Reserva], [Id_Usuario], [Id_Servicio], [Cantidad_Invitados_Final], [Tipo_Evento], [Observaciones]) VALUES (33, 34, 1, 1, 110, N'Cumpleaños 15', N'Menú tradicional.')
INSERT [dbo].[FICHA_TECNICA] ([Id_Ficha], [Id_Reserva], [Id_Usuario], [Id_Servicio], [Cantidad_Invitados_Final], [Tipo_Evento], [Observaciones]) VALUES (34, 35, 1, 2, 160, N'Casamiento', N'Cena 3 pasos gourmet.')
INSERT [dbo].[FICHA_TECNICA] ([Id_Ficha], [Id_Reserva], [Id_Usuario], [Id_Servicio], [Cantidad_Invitados_Final], [Tipo_Evento], [Observaciones]) VALUES (35, 36, 1, 7, 240, N'Congreso', N'Jornada completa con coffee break e islas.')
INSERT [dbo].[FICHA_TECNICA] ([Id_Ficha], [Id_Reserva], [Id_Usuario], [Id_Servicio], [Cantidad_Invitados_Final], [Tipo_Evento], [Observaciones]) VALUES (36, 37, 1, 6, 75, N'Bautismo', N'Almuerzo criollo familiar.')
INSERT [dbo].[FICHA_TECNICA] ([Id_Ficha], [Id_Reserva], [Id_Usuario], [Id_Servicio], [Cantidad_Invitados_Final], [Tipo_Evento], [Observaciones]) VALUES (37, 38, 1, 2, 200, N'Fiesta Empresarial', N'Cena de gala y barra libre.')
INSERT [dbo].[FICHA_TECNICA] ([Id_Ficha], [Id_Reserva], [Id_Usuario], [Id_Servicio], [Cantidad_Invitados_Final], [Tipo_Evento], [Observaciones]) VALUES (38, 39, 1, 2, 130, N'Casamiento', N'Menú Premium 3 pasos.')
INSERT [dbo].[FICHA_TECNICA] ([Id_Ficha], [Id_Reserva], [Id_Usuario], [Id_Servicio], [Cantidad_Invitados_Final], [Tipo_Evento], [Observaciones]) VALUES (39, 40, 1, 1, 80, N'Cumpleaños 60', N'Menú informal y finger food.')
INSERT [dbo].[FICHA_TECNICA] ([Id_Ficha], [Id_Reserva], [Id_Usuario], [Id_Servicio], [Cantidad_Invitados_Final], [Tipo_Evento], [Observaciones]) VALUES (40, 41, 1, 7, 210, N'Evento Corporativo', N'Cena formal ejecutiva.')
INSERT [dbo].[FICHA_TECNICA] ([Id_Ficha], [Id_Reserva], [Id_Usuario], [Id_Servicio], [Cantidad_Invitados_Final], [Tipo_Evento], [Observaciones]) VALUES (41, 42, 1, 6, 100, N'Aniversario', N'Servicio criollo tradicional.')
INSERT [dbo].[FICHA_TECNICA] ([Id_Ficha], [Id_Reserva], [Id_Usuario], [Id_Servicio], [Cantidad_Invitados_Final], [Tipo_Evento], [Observaciones]) VALUES (42, 43, 1, 7, 260, N'Fiesta Empresarial', N'Cena de gala con islas gourmet.')
INSERT [dbo].[FICHA_TECNICA] ([Id_Ficha], [Id_Reserva], [Id_Usuario], [Id_Servicio], [Cantidad_Invitados_Final], [Tipo_Evento], [Observaciones]) VALUES (43, 44, 1, 7, 100, N'Casamiento', NULL)
INSERT [dbo].[FICHA_TECNICA] ([Id_Ficha], [Id_Reserva], [Id_Usuario], [Id_Servicio], [Cantidad_Invitados_Final], [Tipo_Evento], [Observaciones]) VALUES (44, 45, 1, 6, 95, N'Casamiento', NULL)
INSERT [dbo].[FICHA_TECNICA] ([Id_Ficha], [Id_Reserva], [Id_Usuario], [Id_Servicio], [Cantidad_Invitados_Final], [Tipo_Evento], [Observaciones]) VALUES (46, 47, 1, 2, 50, N'Casamiento', NULL)
INSERT [dbo].[FICHA_TECNICA] ([Id_Ficha], [Id_Reserva], [Id_Usuario], [Id_Servicio], [Cantidad_Invitados_Final], [Tipo_Evento], [Observaciones]) VALUES (48, 49, 1, 1, 80, N'Aniversario', N'Servicio informal cocktail.')
INSERT [dbo].[FICHA_TECNICA] ([Id_Ficha], [Id_Reserva], [Id_Usuario], [Id_Servicio], [Cantidad_Invitados_Final], [Tipo_Evento], [Observaciones]) VALUES (49, 50, 1, 2, 140, N'Casamiento', N'Menú Premium 3 pasos con recepción VIP.')
INSERT [dbo].[FICHA_TECNICA] ([Id_Ficha], [Id_Reserva], [Id_Usuario], [Id_Servicio], [Cantidad_Invitados_Final], [Tipo_Evento], [Observaciones]) VALUES (50, 51, 1, 1, 95, N'Cumpleaños 15', N'Menú informal finger food e islas temáticas.')
INSERT [dbo].[FICHA_TECNICA] ([Id_Ficha], [Id_Reserva], [Id_Usuario], [Id_Servicio], [Cantidad_Invitados_Final], [Tipo_Evento], [Observaciones]) VALUES (51, 52, 1, 7, 250, N'Evento Corporativo', N'Cena formal ejecutiva con banquete.')
INSERT [dbo].[FICHA_TECNICA] ([Id_Ficha], [Id_Reserva], [Id_Usuario], [Id_Servicio], [Cantidad_Invitados_Final], [Tipo_Evento], [Observaciones]) VALUES (52, 53, 1, 6, 110, N'Aniversario', N'Servicio criollo gourmet.')
INSERT [dbo].[FICHA_TECNICA] ([Id_Ficha], [Id_Reserva], [Id_Usuario], [Id_Servicio], [Cantidad_Invitados_Final], [Tipo_Evento], [Observaciones]) VALUES (53, 54, 1, 7, 200, N'Fiesta Empresarial', N'Cena de gala con menú internacional.')
INSERT [dbo].[FICHA_TECNICA] ([Id_Ficha], [Id_Reserva], [Id_Usuario], [Id_Servicio], [Cantidad_Invitados_Final], [Tipo_Evento], [Observaciones]) VALUES (54, 55, 1, 2, 120, N'Casamiento', N'Menú Premium 3 pasos.')
INSERT [dbo].[FICHA_TECNICA] ([Id_Ficha], [Id_Reserva], [Id_Usuario], [Id_Servicio], [Cantidad_Invitados_Final], [Tipo_Evento], [Observaciones]) VALUES (55, 56, 1, 1, 80, N'Cumpleaños', N'Menú finger food.')
INSERT [dbo].[FICHA_TECNICA] ([Id_Ficha], [Id_Reserva], [Id_Usuario], [Id_Servicio], [Cantidad_Invitados_Final], [Tipo_Evento], [Observaciones]) VALUES (56, 57, 1, 7, 300, N'Evento Corporativo', N'Cena formal ejecutiva.')
INSERT [dbo].[FICHA_TECNICA] ([Id_Ficha], [Id_Reserva], [Id_Usuario], [Id_Servicio], [Cantidad_Invitados_Final], [Tipo_Evento], [Observaciones]) VALUES (1054, 1056, 1, 2, 100, N'Evento Corporativo', NULL)
INSERT [dbo].[FICHA_TECNICA] ([Id_Ficha], [Id_Reserva], [Id_Usuario], [Id_Servicio], [Cantidad_Invitados_Final], [Tipo_Evento], [Observaciones]) VALUES (1055, 1062, 1, 2, 50, N'Cumpleaños 15', NULL)
INSERT [dbo].[FICHA_TECNICA] ([Id_Ficha], [Id_Reserva], [Id_Usuario], [Id_Servicio], [Cantidad_Invitados_Final], [Tipo_Evento], [Observaciones]) VALUES (1056, 1063, 1, 1, 105, N'Cumpleaños 15', N'Servicio completo ejecutado sin inconvenientes.')
INSERT [dbo].[FICHA_TECNICA] ([Id_Ficha], [Id_Reserva], [Id_Usuario], [Id_Servicio], [Cantidad_Invitados_Final], [Tipo_Evento], [Observaciones]) VALUES (1057, 1064, 1, 1, 130, N'Evento Corporativo', N'Servicio completo ejecutado sin inconvenientes.')
INSERT [dbo].[FICHA_TECNICA] ([Id_Ficha], [Id_Reserva], [Id_Usuario], [Id_Servicio], [Cantidad_Invitados_Final], [Tipo_Evento], [Observaciones]) VALUES (1058, 1065, 1, 1, 155, N'Casamiento', N'Servicio completo ejecutado sin inconvenientes.')
INSERT [dbo].[FICHA_TECNICA] ([Id_Ficha], [Id_Reserva], [Id_Usuario], [Id_Servicio], [Cantidad_Invitados_Final], [Tipo_Evento], [Observaciones]) VALUES (1059, 1066, 1, 1, 180, N'Cumpleaños 15', N'Servicio completo ejecutado sin inconvenientes.')
INSERT [dbo].[FICHA_TECNICA] ([Id_Ficha], [Id_Reserva], [Id_Usuario], [Id_Servicio], [Cantidad_Invitados_Final], [Tipo_Evento], [Observaciones]) VALUES (1060, 1067, 1, 1, 80, N'Evento Corporativo', N'Servicio completo ejecutado sin inconvenientes.')
INSERT [dbo].[FICHA_TECNICA] ([Id_Ficha], [Id_Reserva], [Id_Usuario], [Id_Servicio], [Cantidad_Invitados_Final], [Tipo_Evento], [Observaciones]) VALUES (1061, 1068, 1, 1, 105, N'Casamiento', N'Servicio completo ejecutado sin inconvenientes.')
INSERT [dbo].[FICHA_TECNICA] ([Id_Ficha], [Id_Reserva], [Id_Usuario], [Id_Servicio], [Cantidad_Invitados_Final], [Tipo_Evento], [Observaciones]) VALUES (1062, 1069, 1, 1, 130, N'Cumpleaños 15', N'Servicio completo ejecutado sin inconvenientes.')
INSERT [dbo].[FICHA_TECNICA] ([Id_Ficha], [Id_Reserva], [Id_Usuario], [Id_Servicio], [Cantidad_Invitados_Final], [Tipo_Evento], [Observaciones]) VALUES (1063, 1070, 1, 1, 155, N'Evento Corporativo', N'Servicio completo ejecutado sin inconvenientes.')
INSERT [dbo].[FICHA_TECNICA] ([Id_Ficha], [Id_Reserva], [Id_Usuario], [Id_Servicio], [Cantidad_Invitados_Final], [Tipo_Evento], [Observaciones]) VALUES (1064, 1071, 1, 1, 180, N'Casamiento', N'Servicio completo ejecutado sin inconvenientes.')
INSERT [dbo].[FICHA_TECNICA] ([Id_Ficha], [Id_Reserva], [Id_Usuario], [Id_Servicio], [Cantidad_Invitados_Final], [Tipo_Evento], [Observaciones]) VALUES (1065, 1072, 1, 1, 80, N'Cumpleaños 15', N'Servicio completo ejecutado sin inconvenientes.')
INSERT [dbo].[FICHA_TECNICA] ([Id_Ficha], [Id_Reserva], [Id_Usuario], [Id_Servicio], [Cantidad_Invitados_Final], [Tipo_Evento], [Observaciones]) VALUES (1066, 1073, 1, 1, 105, N'Evento Corporativo', N'Servicio completo ejecutado sin inconvenientes.')
INSERT [dbo].[FICHA_TECNICA] ([Id_Ficha], [Id_Reserva], [Id_Usuario], [Id_Servicio], [Cantidad_Invitados_Final], [Tipo_Evento], [Observaciones]) VALUES (1067, 1074, 1, 1, 130, N'Casamiento', N'Servicio completo ejecutado sin inconvenientes.')
INSERT [dbo].[FICHA_TECNICA] ([Id_Ficha], [Id_Reserva], [Id_Usuario], [Id_Servicio], [Cantidad_Invitados_Final], [Tipo_Evento], [Observaciones]) VALUES (1068, 1075, 1, 1, 155, N'Cumpleaños 15', N'Servicio completo ejecutado sin inconvenientes.')
INSERT [dbo].[FICHA_TECNICA] ([Id_Ficha], [Id_Reserva], [Id_Usuario], [Id_Servicio], [Cantidad_Invitados_Final], [Tipo_Evento], [Observaciones]) VALUES (1069, 1076, 1, 1, 180, N'Evento Corporativo', N'Servicio completo ejecutado sin inconvenientes.')
INSERT [dbo].[FICHA_TECNICA] ([Id_Ficha], [Id_Reserva], [Id_Usuario], [Id_Servicio], [Cantidad_Invitados_Final], [Tipo_Evento], [Observaciones]) VALUES (1070, 1077, 1, 1, 80, N'Casamiento', N'Servicio completo ejecutado sin inconvenientes.')
INSERT [dbo].[FICHA_TECNICA] ([Id_Ficha], [Id_Reserva], [Id_Usuario], [Id_Servicio], [Cantidad_Invitados_Final], [Tipo_Evento], [Observaciones]) VALUES (1071, 1078, 1, 1, 105, N'Cumpleaños 15', N'Servicio completo ejecutado sin inconvenientes.')
INSERT [dbo].[FICHA_TECNICA] ([Id_Ficha], [Id_Reserva], [Id_Usuario], [Id_Servicio], [Cantidad_Invitados_Final], [Tipo_Evento], [Observaciones]) VALUES (1072, 1079, 1, 1, 130, N'Evento Corporativo', N'Servicio completo ejecutado sin inconvenientes.')
INSERT [dbo].[FICHA_TECNICA] ([Id_Ficha], [Id_Reserva], [Id_Usuario], [Id_Servicio], [Cantidad_Invitados_Final], [Tipo_Evento], [Observaciones]) VALUES (1073, 1080, 1, 1, 155, N'Casamiento', N'Servicio completo ejecutado sin inconvenientes.')
INSERT [dbo].[FICHA_TECNICA] ([Id_Ficha], [Id_Reserva], [Id_Usuario], [Id_Servicio], [Cantidad_Invitados_Final], [Tipo_Evento], [Observaciones]) VALUES (1074, 1081, 1, 1, 180, N'Cumpleaños 15', N'Servicio completo ejecutado sin inconvenientes.')
INSERT [dbo].[FICHA_TECNICA] ([Id_Ficha], [Id_Reserva], [Id_Usuario], [Id_Servicio], [Cantidad_Invitados_Final], [Tipo_Evento], [Observaciones]) VALUES (1075, 1082, 1, 1, 80, N'Evento Corporativo', N'Servicio completo ejecutado sin inconvenientes.')
INSERT [dbo].[FICHA_TECNICA] ([Id_Ficha], [Id_Reserva], [Id_Usuario], [Id_Servicio], [Cantidad_Invitados_Final], [Tipo_Evento], [Observaciones]) VALUES (1076, 1083, 1, 1, 105, N'Casamiento', N'Servicio completo ejecutado sin inconvenientes.')
INSERT [dbo].[FICHA_TECNICA] ([Id_Ficha], [Id_Reserva], [Id_Usuario], [Id_Servicio], [Cantidad_Invitados_Final], [Tipo_Evento], [Observaciones]) VALUES (1077, 1084, 1, 1, 130, N'Cumpleaños 15', N'Servicio completo ejecutado sin inconvenientes.')
INSERT [dbo].[FICHA_TECNICA] ([Id_Ficha], [Id_Reserva], [Id_Usuario], [Id_Servicio], [Cantidad_Invitados_Final], [Tipo_Evento], [Observaciones]) VALUES (1078, 1085, 1, 1, 155, N'Evento Corporativo', N'Servicio completo ejecutado sin inconvenientes.')
INSERT [dbo].[FICHA_TECNICA] ([Id_Ficha], [Id_Reserva], [Id_Usuario], [Id_Servicio], [Cantidad_Invitados_Final], [Tipo_Evento], [Observaciones]) VALUES (1079, 1086, 1, 1, 180, N'Casamiento', N'Servicio completo ejecutado sin inconvenientes.')
INSERT [dbo].[FICHA_TECNICA] ([Id_Ficha], [Id_Reserva], [Id_Usuario], [Id_Servicio], [Cantidad_Invitados_Final], [Tipo_Evento], [Observaciones]) VALUES (1080, 1087, 1, 1, 80, N'Cumpleaños 15', N'Servicio completo ejecutado sin inconvenientes.')
INSERT [dbo].[FICHA_TECNICA] ([Id_Ficha], [Id_Reserva], [Id_Usuario], [Id_Servicio], [Cantidad_Invitados_Final], [Tipo_Evento], [Observaciones]) VALUES (1081, 1088, 1, 1, 105, N'Evento Corporativo', N'Servicio completo ejecutado sin inconvenientes.')
INSERT [dbo].[FICHA_TECNICA] ([Id_Ficha], [Id_Reserva], [Id_Usuario], [Id_Servicio], [Cantidad_Invitados_Final], [Tipo_Evento], [Observaciones]) VALUES (1082, 1089, 1, 1, 130, N'Casamiento', N'Servicio completo ejecutado sin inconvenientes.')
INSERT [dbo].[FICHA_TECNICA] ([Id_Ficha], [Id_Reserva], [Id_Usuario], [Id_Servicio], [Cantidad_Invitados_Final], [Tipo_Evento], [Observaciones]) VALUES (1083, 1090, 1, 1, 155, N'Cumpleaños 15', N'Servicio completo ejecutado sin inconvenientes.')
INSERT [dbo].[FICHA_TECNICA] ([Id_Ficha], [Id_Reserva], [Id_Usuario], [Id_Servicio], [Cantidad_Invitados_Final], [Tipo_Evento], [Observaciones]) VALUES (1084, 1091, 1, 1, 180, N'Evento Corporativo', N'Servicio completo ejecutado sin inconvenientes.')
INSERT [dbo].[FICHA_TECNICA] ([Id_Ficha], [Id_Reserva], [Id_Usuario], [Id_Servicio], [Cantidad_Invitados_Final], [Tipo_Evento], [Observaciones]) VALUES (1085, 1092, 1, 1, 80, N'Casamiento', N'Servicio completo ejecutado sin inconvenientes.')
INSERT [dbo].[FICHA_TECNICA] ([Id_Ficha], [Id_Reserva], [Id_Usuario], [Id_Servicio], [Cantidad_Invitados_Final], [Tipo_Evento], [Observaciones]) VALUES (1086, 1093, 1, 1, 105, N'Cumpleaños 15', N'Servicio completo ejecutado sin inconvenientes.')
INSERT [dbo].[FICHA_TECNICA] ([Id_Ficha], [Id_Reserva], [Id_Usuario], [Id_Servicio], [Cantidad_Invitados_Final], [Tipo_Evento], [Observaciones]) VALUES (1087, 1094, 1, 1, 130, N'Evento Corporativo', N'Servicio completo ejecutado sin inconvenientes.')
INSERT [dbo].[FICHA_TECNICA] ([Id_Ficha], [Id_Reserva], [Id_Usuario], [Id_Servicio], [Cantidad_Invitados_Final], [Tipo_Evento], [Observaciones]) VALUES (1088, 1095, 1, 1, 155, N'Casamiento', N'Servicio completo ejecutado sin inconvenientes.')
INSERT [dbo].[FICHA_TECNICA] ([Id_Ficha], [Id_Reserva], [Id_Usuario], [Id_Servicio], [Cantidad_Invitados_Final], [Tipo_Evento], [Observaciones]) VALUES (1089, 1096, 1, 1, 180, N'Cumpleaños 15', N'Servicio completo ejecutado sin inconvenientes.')
INSERT [dbo].[FICHA_TECNICA] ([Id_Ficha], [Id_Reserva], [Id_Usuario], [Id_Servicio], [Cantidad_Invitados_Final], [Tipo_Evento], [Observaciones]) VALUES (1090, 1097, 1, 1, 80, N'Evento Corporativo', N'Servicio completo ejecutado sin inconvenientes.')
INSERT [dbo].[FICHA_TECNICA] ([Id_Ficha], [Id_Reserva], [Id_Usuario], [Id_Servicio], [Cantidad_Invitados_Final], [Tipo_Evento], [Observaciones]) VALUES (1091, 1098, 1, 1, 105, N'Casamiento', N'Servicio completo ejecutado sin inconvenientes.')
INSERT [dbo].[FICHA_TECNICA] ([Id_Ficha], [Id_Reserva], [Id_Usuario], [Id_Servicio], [Cantidad_Invitados_Final], [Tipo_Evento], [Observaciones]) VALUES (1092, 1099, 1, 1, 130, N'Cumpleaños 15', N'Servicio completo ejecutado sin inconvenientes.')
INSERT [dbo].[FICHA_TECNICA] ([Id_Ficha], [Id_Reserva], [Id_Usuario], [Id_Servicio], [Cantidad_Invitados_Final], [Tipo_Evento], [Observaciones]) VALUES (1093, 1100, 1, 1, 155, N'Evento Corporativo', N'Servicio completo ejecutado sin inconvenientes.')
INSERT [dbo].[FICHA_TECNICA] ([Id_Ficha], [Id_Reserva], [Id_Usuario], [Id_Servicio], [Cantidad_Invitados_Final], [Tipo_Evento], [Observaciones]) VALUES (1094, 1101, 1, 1, 180, N'Casamiento', N'Servicio completo ejecutado sin inconvenientes.')
INSERT [dbo].[FICHA_TECNICA] ([Id_Ficha], [Id_Reserva], [Id_Usuario], [Id_Servicio], [Cantidad_Invitados_Final], [Tipo_Evento], [Observaciones]) VALUES (1095, 1102, 1, 1, 80, N'Cumpleaños 15', N'Servicio completo ejecutado sin inconvenientes.')
INSERT [dbo].[FICHA_TECNICA] ([Id_Ficha], [Id_Reserva], [Id_Usuario], [Id_Servicio], [Cantidad_Invitados_Final], [Tipo_Evento], [Observaciones]) VALUES (1096, 1103, 1, 1, 105, N'Evento Corporativo', N'Servicio completo ejecutado sin inconvenientes.')
INSERT [dbo].[FICHA_TECNICA] ([Id_Ficha], [Id_Reserva], [Id_Usuario], [Id_Servicio], [Cantidad_Invitados_Final], [Tipo_Evento], [Observaciones]) VALUES (1097, 1104, 1, 1, 130, N'Casamiento', N'Servicio completo ejecutado sin inconvenientes.')
INSERT [dbo].[FICHA_TECNICA] ([Id_Ficha], [Id_Reserva], [Id_Usuario], [Id_Servicio], [Cantidad_Invitados_Final], [Tipo_Evento], [Observaciones]) VALUES (1098, 1105, 1, 1, 155, N'Cumpleaños 15', N'Servicio completo ejecutado sin inconvenientes.')
INSERT [dbo].[FICHA_TECNICA] ([Id_Ficha], [Id_Reserva], [Id_Usuario], [Id_Servicio], [Cantidad_Invitados_Final], [Tipo_Evento], [Observaciones]) VALUES (1099, 1106, 1, 1, 180, N'Evento Corporativo', N'Servicio completo ejecutado sin inconvenientes.')
INSERT [dbo].[FICHA_TECNICA] ([Id_Ficha], [Id_Reserva], [Id_Usuario], [Id_Servicio], [Cantidad_Invitados_Final], [Tipo_Evento], [Observaciones]) VALUES (1100, 1107, 1, 1, 80, N'Casamiento', N'Servicio completo ejecutado sin inconvenientes.')
GO
INSERT [dbo].[FICHA_TECNICA] ([Id_Ficha], [Id_Reserva], [Id_Usuario], [Id_Servicio], [Cantidad_Invitados_Final], [Tipo_Evento], [Observaciones]) VALUES (1101, 1108, 1, 1, 105, N'Cumpleaños 15', N'Servicio completo ejecutado sin inconvenientes.')
INSERT [dbo].[FICHA_TECNICA] ([Id_Ficha], [Id_Reserva], [Id_Usuario], [Id_Servicio], [Cantidad_Invitados_Final], [Tipo_Evento], [Observaciones]) VALUES (1102, 1109, 1, 1, 130, N'Evento Corporativo', N'Servicio completo ejecutado sin inconvenientes.')
INSERT [dbo].[FICHA_TECNICA] ([Id_Ficha], [Id_Reserva], [Id_Usuario], [Id_Servicio], [Cantidad_Invitados_Final], [Tipo_Evento], [Observaciones]) VALUES (1103, 1110, 1, 1, 155, N'Casamiento', N'Servicio completo ejecutado sin inconvenientes.')
INSERT [dbo].[FICHA_TECNICA] ([Id_Ficha], [Id_Reserva], [Id_Usuario], [Id_Servicio], [Cantidad_Invitados_Final], [Tipo_Evento], [Observaciones]) VALUES (1104, 1111, 1, 1, 180, N'Cumpleaños 15', N'Servicio completo ejecutado sin inconvenientes.')
INSERT [dbo].[FICHA_TECNICA] ([Id_Ficha], [Id_Reserva], [Id_Usuario], [Id_Servicio], [Cantidad_Invitados_Final], [Tipo_Evento], [Observaciones]) VALUES (1105, 1112, 1, 1, 80, N'Evento Corporativo', N'Servicio completo ejecutado sin inconvenientes.')
INSERT [dbo].[FICHA_TECNICA] ([Id_Ficha], [Id_Reserva], [Id_Usuario], [Id_Servicio], [Cantidad_Invitados_Final], [Tipo_Evento], [Observaciones]) VALUES (1106, 1113, 1, 1, 105, N'Casamiento', N'Servicio completo ejecutado sin inconvenientes.')
INSERT [dbo].[FICHA_TECNICA] ([Id_Ficha], [Id_Reserva], [Id_Usuario], [Id_Servicio], [Cantidad_Invitados_Final], [Tipo_Evento], [Observaciones]) VALUES (1107, 1114, 1, 1, 130, N'Cumpleaños 15', N'Servicio completo ejecutado sin inconvenientes.')
INSERT [dbo].[FICHA_TECNICA] ([Id_Ficha], [Id_Reserva], [Id_Usuario], [Id_Servicio], [Cantidad_Invitados_Final], [Tipo_Evento], [Observaciones]) VALUES (1108, 1115, 1, 1, 155, N'Evento Corporativo', N'Servicio completo ejecutado sin inconvenientes.')
INSERT [dbo].[FICHA_TECNICA] ([Id_Ficha], [Id_Reserva], [Id_Usuario], [Id_Servicio], [Cantidad_Invitados_Final], [Tipo_Evento], [Observaciones]) VALUES (1109, 1116, 1, 1, 180, N'Casamiento', N'Servicio completo ejecutado sin inconvenientes.')
SET IDENTITY_INSERT [dbo].[FICHA_TECNICA] OFF
GO
SET IDENTITY_INSERT [dbo].[HISTORIAL_PRODUCTO] ON 

INSERT [dbo].[HISTORIAL_PRODUCTO] ([Id_Historial], [Id_Producto], [Usuario_Accion], [Fecha_Cambio], [Tipo_Accion], [Nombre], [Precio], [Stock]) VALUES (13, 1, N'tp', CAST(N'2026-07-11T18:18:12.687' AS DateTime), N'ALTA', N'yerba', CAST(1000.00 AS Decimal(18, 2)), 3)
INSERT [dbo].[HISTORIAL_PRODUCTO] ([Id_Historial], [Id_Producto], [Usuario_Accion], [Fecha_Cambio], [Tipo_Accion], [Nombre], [Precio], [Stock]) VALUES (14, 2, N'tp', CAST(N'2026-07-11T18:26:55.053' AS DateTime), N'ALTA', N'coca', CAST(33.00 AS Decimal(18, 2)), 1)
INSERT [dbo].[HISTORIAL_PRODUCTO] ([Id_Historial], [Id_Producto], [Usuario_Accion], [Fecha_Cambio], [Tipo_Accion], [Nombre], [Precio], [Stock]) VALUES (15, 3, N'tp', CAST(N'2026-07-11T18:31:52.463' AS DateTime), N'ALTA', N'sprite', CAST(33.00 AS Decimal(18, 2)), 1)
INSERT [dbo].[HISTORIAL_PRODUCTO] ([Id_Historial], [Id_Producto], [Usuario_Accion], [Fecha_Cambio], [Tipo_Accion], [Nombre], [Precio], [Stock]) VALUES (16, 2, N'tp', CAST(N'2026-07-11T18:35:30.070' AS DateTime), N'BAJA', N'coca', CAST(33.00 AS Decimal(18, 2)), 1)
INSERT [dbo].[HISTORIAL_PRODUCTO] ([Id_Historial], [Id_Producto], [Usuario_Accion], [Fecha_Cambio], [Tipo_Accion], [Nombre], [Precio], [Stock]) VALUES (17, 2, N'tp', CAST(N'2026-07-11T18:37:40.797' AS DateTime), N'BAJA', N'coca', CAST(33.00 AS Decimal(18, 2)), 1)
INSERT [dbo].[HISTORIAL_PRODUCTO] ([Id_Historial], [Id_Producto], [Usuario_Accion], [Fecha_Cambio], [Tipo_Accion], [Nombre], [Precio], [Stock]) VALUES (18, 2, N'tp', CAST(N'2026-07-11T19:35:55.287' AS DateTime), N'BAJA', N'coca', CAST(33.00 AS Decimal(18, 2)), 1)
INSERT [dbo].[HISTORIAL_PRODUCTO] ([Id_Historial], [Id_Producto], [Usuario_Accion], [Fecha_Cambio], [Tipo_Accion], [Nombre], [Precio], [Stock]) VALUES (19, 2, N'tp', CAST(N'2026-07-11T19:41:26.563' AS DateTime), N'REACTIVACION', N'coca', CAST(33.00 AS Decimal(18, 2)), 1)
INSERT [dbo].[HISTORIAL_PRODUCTO] ([Id_Historial], [Id_Producto], [Usuario_Accion], [Fecha_Cambio], [Tipo_Accion], [Nombre], [Precio], [Stock]) VALUES (20, 3, N'tp', CAST(N'2026-07-11T20:40:15.257' AS DateTime), N'BAJA', N'sprite', CAST(33.00 AS Decimal(18, 2)), 1)
SET IDENTITY_INSERT [dbo].[HISTORIAL_PRODUCTO] OFF
GO
SET IDENTITY_INSERT [dbo].[HISTORIAL_USUARIO] ON 

INSERT [dbo].[HISTORIAL_USUARIO] ([id_historial], [id_usuario], [usuario], [contraseña], [dni], [email], [estadobloqueado], [intentosfallidos], [id_idioma], [dvh], [fecha_cambio], [usuario_accion], [tipo_accion], [ACTIVO]) VALUES (1, 4, N'inactivo', N'99acacf317cc8ef9e7b0ade6590d491fe247381679e7e131582055e00d9b0345', 12345, N'ccc', 0, 0, 1, N'62d8bb55b99d56f0e02efef0e2ec23e3c975d76c2f3f25d0bc5e8f0c1ab1b3ff', CAST(N'2026-07-11T19:43:25.803' AS DateTime), N'tp', N'REACTIVACION', 1)
INSERT [dbo].[HISTORIAL_USUARIO] ([id_historial], [id_usuario], [usuario], [contraseña], [dni], [email], [estadobloqueado], [intentosfallidos], [id_idioma], [dvh], [fecha_cambio], [usuario_accion], [tipo_accion], [ACTIVO]) VALUES (2, 1, N'tp', N'3abd807250d1b53741c345896f2d79faf6e7dcdb75860e98a2f84e38e874c236', 23423423, N'admin123@gmail.com', 0, 0, 2, N'72c3a94756ff8e89beffaa021fe4761bca1cdb9a22cec4f94487dca840f4d543', CAST(N'2026-07-16T12:36:00.270' AS DateTime), N'tp', N'CAMBIO_IDIOMA', 1)
INSERT [dbo].[HISTORIAL_USUARIO] ([id_historial], [id_usuario], [usuario], [contraseña], [dni], [email], [estadobloqueado], [intentosfallidos], [id_idioma], [dvh], [fecha_cambio], [usuario_accion], [tipo_accion], [ACTIVO]) VALUES (3, 1, N'tp', N'3abd807250d1b53741c345896f2d79faf6e7dcdb75860e98a2f84e38e874c236', 23423423, N'admin123@gmail.com', 0, 0, 3, N'b5899297af2ef4d98c3c1195a41d1182957923b24411350b10d38af8cf0ddeb4', CAST(N'2026-07-16T12:36:14.260' AS DateTime), N'tp', N'CAMBIO_IDIOMA', 1)
INSERT [dbo].[HISTORIAL_USUARIO] ([id_historial], [id_usuario], [usuario], [contraseña], [dni], [email], [estadobloqueado], [intentosfallidos], [id_idioma], [dvh], [fecha_cambio], [usuario_accion], [tipo_accion], [ACTIVO]) VALUES (4, 1, N'tp', N'3abd807250d1b53741c345896f2d79faf6e7dcdb75860e98a2f84e38e874c236', 23423423, N'admin123@gmail.com', 0, 0, 1, N'05bdb046c99decba811a2018ff52c642ed2eae293975df39fd09d60a025eba60', CAST(N'2026-07-16T14:56:30.013' AS DateTime), N'tp', N'CAMBIO_IDIOMA', 1)
INSERT [dbo].[HISTORIAL_USUARIO] ([id_historial], [id_usuario], [usuario], [contraseña], [dni], [email], [estadobloqueado], [intentosfallidos], [id_idioma], [dvh], [fecha_cambio], [usuario_accion], [tipo_accion], [ACTIVO]) VALUES (5, 5, N'usuinactivo', N'3abd807250d1b53741c345896f2d79faf6e7dcdb75860e98a2f84e38e874c236', 123444, N'asdddd@gmail.com', 0, 0, 1, N'07a2a6a628290670f1e2b23bba8302db0b846947976aa069a0406da68eb0deea', CAST(N'2026-07-16T14:56:53.597' AS DateTime), N'tp', N'ALTA', 1)
INSERT [dbo].[HISTORIAL_USUARIO] ([id_historial], [id_usuario], [usuario], [contraseña], [dni], [email], [estadobloqueado], [intentosfallidos], [id_idioma], [dvh], [fecha_cambio], [usuario_accion], [tipo_accion], [ACTIVO]) VALUES (6, 5, N'usuinactivo', N'3abd807250d1b53741c345896f2d79faf6e7dcdb75860e98a2f84e38e874c236', 123444, N'asdddd@gmail.com', 0, 0, 1, N'617fbb6dea945e59a1c54fdc401271a7318182880e82c30bbf39ad10545ea1d5', CAST(N'2026-07-16T14:57:00.130' AS DateTime), N'tp', N'BAJA_LOGICA', 1)
INSERT [dbo].[HISTORIAL_USUARIO] ([id_historial], [id_usuario], [usuario], [contraseña], [dni], [email], [estadobloqueado], [intentosfallidos], [id_idioma], [dvh], [fecha_cambio], [usuario_accion], [tipo_accion], [ACTIVO]) VALUES (7, 1, N'tp', N'3abd807250d1b53741c345896f2d79faf6e7dcdb75860e98a2f84e38e874c236', 23423423, N'admin123@gmail.com', 0, 0, 2, N'72c3a94756ff8e89beffaa021fe4761bca1cdb9a22cec4f94487dca840f4d543', CAST(N'2026-07-16T14:57:17.310' AS DateTime), N'tp', N'CAMBIO_IDIOMA', 1)
INSERT [dbo].[HISTORIAL_USUARIO] ([id_historial], [id_usuario], [usuario], [contraseña], [dni], [email], [estadobloqueado], [intentosfallidos], [id_idioma], [dvh], [fecha_cambio], [usuario_accion], [tipo_accion], [ACTIVO]) VALUES (8, 1, N'tp', N'3abd807250d1b53741c345896f2d79faf6e7dcdb75860e98a2f84e38e874c236', 23423423, N'admin123@gmail.com', 0, 0, 1, N'05bdb046c99decba811a2018ff52c642ed2eae293975df39fd09d60a025eba60', CAST(N'2026-07-16T14:57:24.563' AS DateTime), N'tp', N'CAMBIO_IDIOMA', 1)
INSERT [dbo].[HISTORIAL_USUARIO] ([id_historial], [id_usuario], [usuario], [contraseña], [dni], [email], [estadobloqueado], [intentosfallidos], [id_idioma], [dvh], [fecha_cambio], [usuario_accion], [tipo_accion], [ACTIVO]) VALUES (9, 5, N'usuinactivo', N'3abd807250d1b53741c345896f2d79faf6e7dcdb75860e98a2f84e38e874c236', 123444, N'asdddd@gmail.com', 0, 0, 1, N'07a2a6a628290670f1e2b23bba8302db0b846947976aa069a0406da68eb0deea', CAST(N'2026-07-16T14:57:51.043' AS DateTime), N'tp', N'REACTIVACION', 1)
INSERT [dbo].[HISTORIAL_USUARIO] ([id_historial], [id_usuario], [usuario], [contraseña], [dni], [email], [estadobloqueado], [intentosfallidos], [id_idioma], [dvh], [fecha_cambio], [usuario_accion], [tipo_accion], [ACTIVO]) VALUES (10, 1, N'tp', N'3abd807250d1b53741c345896f2d79faf6e7dcdb75860e98a2f84e38e874c236', 23423423, N'admin123@gmail.com', 0, 0, 1, N'05bdb046c99decba811a2018ff52c642ed2eae293975df39fd09d60a025eba60', CAST(N'2026-09-03T16:02:09.330' AS DateTime), N'tp', N'CAMBIO_IDIOMA', 1)
INSERT [dbo].[HISTORIAL_USUARIO] ([id_historial], [id_usuario], [usuario], [contraseña], [dni], [email], [estadobloqueado], [intentosfallidos], [id_idioma], [dvh], [fecha_cambio], [usuario_accion], [tipo_accion], [ACTIVO]) VALUES (1010, 1, N'tp', N'3abd807250d1b53741c345896f2d79faf6e7dcdb75860e98a2f84e38e874c236', 23423423, N'admin123@gmail.com', 0, 0, 2, N'72c3a94756ff8e89beffaa021fe4761bca1cdb9a22cec4f94487dca840f4d543', CAST(N'2026-10-04T13:56:21.723' AS DateTime), N'tp', N'CAMBIO_IDIOMA', 1)
INSERT [dbo].[HISTORIAL_USUARIO] ([id_historial], [id_usuario], [usuario], [contraseña], [dni], [email], [estadobloqueado], [intentosfallidos], [id_idioma], [dvh], [fecha_cambio], [usuario_accion], [tipo_accion], [ACTIVO]) VALUES (1011, 1, N'tp', N'3abd807250d1b53741c345896f2d79faf6e7dcdb75860e98a2f84e38e874c236', 23423423, N'admin123@gmail.com', 0, 0, 1, N'05bdb046c99decba811a2018ff52c642ed2eae293975df39fd09d60a025eba60', CAST(N'2026-10-04T13:56:25.733' AS DateTime), N'tp', N'CAMBIO_IDIOMA', 1)
INSERT [dbo].[HISTORIAL_USUARIO] ([id_historial], [id_usuario], [usuario], [contraseña], [dni], [email], [estadobloqueado], [intentosfallidos], [id_idioma], [dvh], [fecha_cambio], [usuario_accion], [tipo_accion], [ACTIVO]) VALUES (1012, 1, N'tp', N'3abd807250d1b53741c345896f2d79faf6e7dcdb75860e98a2f84e38e874c236', 23423423, N'admin123@gmail.com', 0, 0, 2, N'72c3a94756ff8e89beffaa021fe4761bca1cdb9a22cec4f94487dca840f4d543', CAST(N'2026-10-25T00:27:19.677' AS DateTime), N'tp', N'CAMBIO_IDIOMA', 1)
INSERT [dbo].[HISTORIAL_USUARIO] ([id_historial], [id_usuario], [usuario], [contraseña], [dni], [email], [estadobloqueado], [intentosfallidos], [id_idioma], [dvh], [fecha_cambio], [usuario_accion], [tipo_accion], [ACTIVO]) VALUES (1013, 1, N'tp', N'3abd807250d1b53741c345896f2d79faf6e7dcdb75860e98a2f84e38e874c236', 23423423, N'admin123@gmail.com', 0, 0, 1, N'05bdb046c99decba811a2018ff52c642ed2eae293975df39fd09d60a025eba60', CAST(N'2026-10-25T00:27:20.887' AS DateTime), N'tp', N'CAMBIO_IDIOMA', 1)
INSERT [dbo].[HISTORIAL_USUARIO] ([id_historial], [id_usuario], [usuario], [contraseña], [dni], [email], [estadobloqueado], [intentosfallidos], [id_idioma], [dvh], [fecha_cambio], [usuario_accion], [tipo_accion], [ACTIVO]) VALUES (1014, 1, N'tp', N'3abd807250d1b53741c345896f2d79faf6e7dcdb75860e98a2f84e38e874c236', 23423423, N'admin123@gmail.com', 0, 0, 3, N'b5899297af2ef4d98c3c1195a41d1182957923b24411350b10d38af8cf0ddeb4', CAST(N'2026-10-29T08:31:54.447' AS DateTime), N'tp', N'CAMBIO_IDIOMA', 1)
INSERT [dbo].[HISTORIAL_USUARIO] ([id_historial], [id_usuario], [usuario], [contraseña], [dni], [email], [estadobloqueado], [intentosfallidos], [id_idioma], [dvh], [fecha_cambio], [usuario_accion], [tipo_accion], [ACTIVO]) VALUES (1015, 1, N'tp', N'3abd807250d1b53741c345896f2d79faf6e7dcdb75860e98a2f84e38e874c236', 23423423, N'admin123@gmail.com', 0, 0, 1, N'05bdb046c99decba811a2018ff52c642ed2eae293975df39fd09d60a025eba60', CAST(N'2026-10-29T17:50:04.290' AS DateTime), N'tp', N'CAMBIO_IDIOMA', 1)
INSERT [dbo].[HISTORIAL_USUARIO] ([id_historial], [id_usuario], [usuario], [contraseña], [dni], [email], [estadobloqueado], [intentosfallidos], [id_idioma], [dvh], [fecha_cambio], [usuario_accion], [tipo_accion], [ACTIVO]) VALUES (1016, 1, N'tp', N'3abd807250d1b53741c345896f2d79faf6e7dcdb75860e98a2f84e38e874c236', 23423423, N'admin123@gmail.com', 0, 0, 2, N'72c3a94756ff8e89beffaa021fe4761bca1cdb9a22cec4f94487dca840f4d543', CAST(N'2026-11-01T10:50:21.377' AS DateTime), N'tp', N'CAMBIO_IDIOMA', 1)
INSERT [dbo].[HISTORIAL_USUARIO] ([id_historial], [id_usuario], [usuario], [contraseña], [dni], [email], [estadobloqueado], [intentosfallidos], [id_idioma], [dvh], [fecha_cambio], [usuario_accion], [tipo_accion], [ACTIVO]) VALUES (1017, 1, N'tp', N'3abd807250d1b53741c345896f2d79faf6e7dcdb75860e98a2f84e38e874c236', 23423423, N'admin123@gmail.com', 0, 0, 1, N'05bdb046c99decba811a2018ff52c642ed2eae293975df39fd09d60a025eba60', CAST(N'2026-11-02T09:26:27.607' AS DateTime), N'tp', N'CAMBIO_IDIOMA', 1)
INSERT [dbo].[HISTORIAL_USUARIO] ([id_historial], [id_usuario], [usuario], [contraseña], [dni], [email], [estadobloqueado], [intentosfallidos], [id_idioma], [dvh], [fecha_cambio], [usuario_accion], [tipo_accion], [ACTIVO]) VALUES (1018, 1, N'tp', N'3abd807250d1b53741c345896f2d79faf6e7dcdb75860e98a2f84e38e874c236', 23423423, N'admin123@gmail.com', 0, 0, 2, N'72c3a94756ff8e89beffaa021fe4761bca1cdb9a22cec4f94487dca840f4d543', CAST(N'2026-11-14T19:39:08.600' AS DateTime), N'tp', N'CAMBIO_IDIOMA', 1)
INSERT [dbo].[HISTORIAL_USUARIO] ([id_historial], [id_usuario], [usuario], [contraseña], [dni], [email], [estadobloqueado], [intentosfallidos], [id_idioma], [dvh], [fecha_cambio], [usuario_accion], [tipo_accion], [ACTIVO]) VALUES (1019, 1, N'tp', N'3abd807250d1b53741c345896f2d79faf6e7dcdb75860e98a2f84e38e874c236', 23423423, N'admin123@gmail.com', 0, 0, 1, N'05bdb046c99decba811a2018ff52c642ed2eae293975df39fd09d60a025eba60', CAST(N'2026-11-14T19:39:18.293' AS DateTime), N'tp', N'CAMBIO_IDIOMA', 1)
INSERT [dbo].[HISTORIAL_USUARIO] ([id_historial], [id_usuario], [usuario], [contraseña], [dni], [email], [estadobloqueado], [intentosfallidos], [id_idioma], [dvh], [fecha_cambio], [usuario_accion], [tipo_accion], [ACTIVO]) VALUES (1020, 1, N'tp', N'3abd807250d1b53741c345896f2d79faf6e7dcdb75860e98a2f84e38e874c236', 23423423, N'admin123@gmail.com', 0, 0, 2, N'72c3a94756ff8e89beffaa021fe4761bca1cdb9a22cec4f94487dca840f4d543', CAST(N'2026-11-15T12:28:27.153' AS DateTime), N'tp', N'CAMBIO_IDIOMA', 1)
INSERT [dbo].[HISTORIAL_USUARIO] ([id_historial], [id_usuario], [usuario], [contraseña], [dni], [email], [estadobloqueado], [intentosfallidos], [id_idioma], [dvh], [fecha_cambio], [usuario_accion], [tipo_accion], [ACTIVO]) VALUES (1021, 1, N'tp', N'3abd807250d1b53741c345896f2d79faf6e7dcdb75860e98a2f84e38e874c236', 23423423, N'admin123@gmail.com', 0, 0, 1, N'05bdb046c99decba811a2018ff52c642ed2eae293975df39fd09d60a025eba60', CAST(N'2026-11-15T12:28:31.057' AS DateTime), N'tp', N'CAMBIO_IDIOMA', 1)
INSERT [dbo].[HISTORIAL_USUARIO] ([id_historial], [id_usuario], [usuario], [contraseña], [dni], [email], [estadobloqueado], [intentosfallidos], [id_idioma], [dvh], [fecha_cambio], [usuario_accion], [tipo_accion], [ACTIVO]) VALUES (1022, 1, N'tp', N'3abd807250d1b53741c345896f2d79faf6e7dcdb75860e98a2f84e38e874c236', 23423423, N'admin123@gmail.com', 0, 0, 2, N'72c3a94756ff8e89beffaa021fe4761bca1cdb9a22cec4f94487dca840f4d543', CAST(N'2026-11-16T14:01:02.640' AS DateTime), N'tp', N'CAMBIO_IDIOMA', 1)
INSERT [dbo].[HISTORIAL_USUARIO] ([id_historial], [id_usuario], [usuario], [contraseña], [dni], [email], [estadobloqueado], [intentosfallidos], [id_idioma], [dvh], [fecha_cambio], [usuario_accion], [tipo_accion], [ACTIVO]) VALUES (1023, 1, N'tp', N'3abd807250d1b53741c345896f2d79faf6e7dcdb75860e98a2f84e38e874c236', 23423423, N'admin123@gmail.com', 0, 0, 1, N'05bdb046c99decba811a2018ff52c642ed2eae293975df39fd09d60a025eba60', CAST(N'2026-11-16T14:01:08.913' AS DateTime), N'tp', N'CAMBIO_IDIOMA', 1)
INSERT [dbo].[HISTORIAL_USUARIO] ([id_historial], [id_usuario], [usuario], [contraseña], [dni], [email], [estadobloqueado], [intentosfallidos], [id_idioma], [dvh], [fecha_cambio], [usuario_accion], [tipo_accion], [ACTIVO]) VALUES (1024, 2, N'mg', N'e9949d904d436e1fd21b1ac234c1fad20b0939f0d6f4292f78625cebaf267ed8', 1234, N'mg@gmail,com', 0, 0, 1, N'f008720f82f2a40b75f11bd49b7be32ae65f4e5f3ae452cc12dfb94e4db5deff', CAST(N'2026-11-22T22:19:51.163' AS DateTime), N'tp', N'MODIFICACION', 1)
INSERT [dbo].[HISTORIAL_USUARIO] ([id_historial], [id_usuario], [usuario], [contraseña], [dni], [email], [estadobloqueado], [intentosfallidos], [id_idioma], [dvh], [fecha_cambio], [usuario_accion], [tipo_accion], [ACTIVO]) VALUES (1025, 1, N'tp', N'3abd807250d1b53741c345896f2d79faf6e7dcdb75860e98a2f84e38e874c236', 23423423, N'admin123@gmail.com', 0, 0, 3, N'b5899297af2ef4d98c3c1195a41d1182957923b24411350b10d38af8cf0ddeb4', CAST(N'2026-11-24T19:34:47.377' AS DateTime), N'tp', N'CAMBIO_IDIOMA', 1)
INSERT [dbo].[HISTORIAL_USUARIO] ([id_historial], [id_usuario], [usuario], [contraseña], [dni], [email], [estadobloqueado], [intentosfallidos], [id_idioma], [dvh], [fecha_cambio], [usuario_accion], [tipo_accion], [ACTIVO]) VALUES (1026, 1, N'tp', N'3abd807250d1b53741c345896f2d79faf6e7dcdb75860e98a2f84e38e874c236', 23423423, N'admin123@gmail.com', 0, 0, 1, N'05bdb046c99decba811a2018ff52c642ed2eae293975df39fd09d60a025eba60', CAST(N'2026-11-24T19:34:52.003' AS DateTime), N'tp', N'CAMBIO_IDIOMA', 1)
INSERT [dbo].[HISTORIAL_USUARIO] ([id_historial], [id_usuario], [usuario], [contraseña], [dni], [email], [estadobloqueado], [intentosfallidos], [id_idioma], [dvh], [fecha_cambio], [usuario_accion], [tipo_accion], [ACTIVO]) VALUES (1027, 2, N'mg', N'e9949d904d436e1fd21b1ac234c1fad20b0939f0d6f4292f78625cebaf267ed8', 1234, N'mg@gmail,com', 0, 0, 1, N'f008720f82f2a40b75f11bd49b7be32ae65f4e5f3ae452cc12dfb94e4db5deff', CAST(N'2026-11-24T19:42:04.150' AS DateTime), N'tp', N'MODIFICACION', 1)
SET IDENTITY_INSERT [dbo].[HISTORIAL_USUARIO] OFF
GO
SET IDENTITY_INSERT [dbo].[IDIOMA] ON 

INSERT [dbo].[IDIOMA] ([ID_IDIOMA], [NOMBRE], [ESTADISPONIBLE]) VALUES (1, N'Español', 1)
INSERT [dbo].[IDIOMA] ([ID_IDIOMA], [NOMBRE], [ESTADISPONIBLE]) VALUES (2, N'English', 1)
INSERT [dbo].[IDIOMA] ([ID_IDIOMA], [NOMBRE], [ESTADISPONIBLE]) VALUES (3, N'Frances', 1)
SET IDENTITY_INSERT [dbo].[IDIOMA] OFF
GO
SET IDENTITY_INSERT [dbo].[INSUMO] ON 

INSERT [dbo].[INSUMO] ([Id_Insumo], [Nombre], [Rubro], [Unidad_Medida], [Stock_Actual], [Stock_Minimo], [Estado]) VALUES (1, N'Lays', N'Snacks', N'Gramos', CAST(10.00 AS Decimal(18, 2)), CAST(1.00 AS Decimal(18, 2)), N'Activo')
INSERT [dbo].[INSUMO] ([Id_Insumo], [Nombre], [Rubro], [Unidad_Medida], [Stock_Actual], [Stock_Minimo], [Estado]) VALUES (2, N'Lomo de Ternera', N'Carnes', N'Kg', CAST(470.00 AS Decimal(18, 2)), CAST(5.00 AS Decimal(18, 2)), N'Activo')
INSERT [dbo].[INSUMO] ([Id_Insumo], [Nombre], [Rubro], [Unidad_Medida], [Stock_Actual], [Stock_Minimo], [Estado]) VALUES (3, N'Vino Malbec Premium', N'Bebidas', N'Litros', CAST(50.00 AS Decimal(18, 2)), CAST(12.00 AS Decimal(18, 2)), N'Activo')
INSERT [dbo].[INSUMO] ([Id_Insumo], [Nombre], [Rubro], [Unidad_Medida], [Stock_Actual], [Stock_Minimo], [Estado]) VALUES (4, N'Gaseosa Cola', N'Bebidas', N'Litros', CAST(210.00 AS Decimal(18, 2)), CAST(20.00 AS Decimal(18, 2)), N'Activo')
INSERT [dbo].[INSUMO] ([Id_Insumo], [Nombre], [Rubro], [Unidad_Medida], [Stock_Actual], [Stock_Minimo], [Estado]) VALUES (5, N'Papas para Guarnición', N'Verduras', N'Kg', CAST(110.00 AS Decimal(18, 2)), CAST(10.00 AS Decimal(18, 2)), N'Activo')
INSERT [dbo].[INSUMO] ([Id_Insumo], [Nombre], [Rubro], [Unidad_Medida], [Stock_Actual], [Stock_Minimo], [Estado]) VALUES (6, N'Helado de Dulce de Leche', N'Postres', N'Kg', CAST(200.00 AS Decimal(18, 2)), CAST(4.00 AS Decimal(18, 2)), N'Activo')
INSERT [dbo].[INSUMO] ([Id_Insumo], [Nombre], [Rubro], [Unidad_Medida], [Stock_Actual], [Stock_Minimo], [Estado]) VALUES (7, N'Queso Tybo', N'Lácteos', N'Kg', CAST(15.00 AS Decimal(18, 2)), CAST(5.00 AS Decimal(18, 2)), N'Activo')
INSERT [dbo].[INSUMO] ([Id_Insumo], [Nombre], [Rubro], [Unidad_Medida], [Stock_Actual], [Stock_Minimo], [Estado]) VALUES (8, N'Jamón Cocido', N'Fiambrería', N'Kg', CAST(12.00 AS Decimal(18, 2)), CAST(4.00 AS Decimal(18, 2)), N'Activo')
SET IDENTITY_INSERT [dbo].[INSUMO] OFF
GO
SET IDENTITY_INSERT [dbo].[ORDEN_COMPRA] ON 

INSERT [dbo].[ORDEN_COMPRA] ([Id_OrdenCompra], [Id_Ficha], [Id_Proveedor], [Fecha_Emision], [Estado], [Motivo_Anulacion]) VALUES (2, NULL, 2, CAST(N'2026-10-31T21:54:54.820' AS DateTime), N'Anulada', N'no se')
INSERT [dbo].[ORDEN_COMPRA] ([Id_OrdenCompra], [Id_Ficha], [Id_Proveedor], [Fecha_Emision], [Estado], [Motivo_Anulacion]) VALUES (3, NULL, 2, CAST(N'2026-10-31T22:01:57.890' AS DateTime), N'Recibida', NULL)
INSERT [dbo].[ORDEN_COMPRA] ([Id_OrdenCompra], [Id_Ficha], [Id_Proveedor], [Fecha_Emision], [Estado], [Motivo_Anulacion]) VALUES (4, NULL, 1, CAST(N'2026-10-31T23:51:18.680' AS DateTime), N'Anulada', N'Sansa tiene papitas caras')
INSERT [dbo].[ORDEN_COMPRA] ([Id_OrdenCompra], [Id_Ficha], [Id_Proveedor], [Fecha_Emision], [Estado], [Motivo_Anulacion]) VALUES (5, NULL, 2, CAST(N'2026-10-31T23:51:46.070' AS DateTime), N'Recibida', NULL)
INSERT [dbo].[ORDEN_COMPRA] ([Id_OrdenCompra], [Id_Ficha], [Id_Proveedor], [Fecha_Emision], [Estado], [Motivo_Anulacion]) VALUES (6, NULL, 1, CAST(N'2026-11-01T01:05:49.790' AS DateTime), N'Recibida', NULL)
INSERT [dbo].[ORDEN_COMPRA] ([Id_OrdenCompra], [Id_Ficha], [Id_Proveedor], [Fecha_Emision], [Estado], [Motivo_Anulacion]) VALUES (7, NULL, 2, CAST(N'2026-11-01T01:09:53.417' AS DateTime), N'Recibida', NULL)
INSERT [dbo].[ORDEN_COMPRA] ([Id_OrdenCompra], [Id_Ficha], [Id_Proveedor], [Fecha_Emision], [Estado], [Motivo_Anulacion]) VALUES (8, 9, 1, CAST(N'2026-11-02T10:00:00.000' AS DateTime), N'Recibida', NULL)
INSERT [dbo].[ORDEN_COMPRA] ([Id_OrdenCompra], [Id_Ficha], [Id_Proveedor], [Fecha_Emision], [Estado], [Motivo_Anulacion]) VALUES (9, 10, 2, CAST(N'2026-11-01T15:30:00.000' AS DateTime), N'Recibida', NULL)
INSERT [dbo].[ORDEN_COMPRA] ([Id_OrdenCompra], [Id_Ficha], [Id_Proveedor], [Fecha_Emision], [Estado], [Motivo_Anulacion]) VALUES (10, 11, 1, CAST(N'2026-10-05T11:20:00.000' AS DateTime), N'Anulada', N'Reemplazo por falta de insumos de stock')
INSERT [dbo].[ORDEN_COMPRA] ([Id_OrdenCompra], [Id_Ficha], [Id_Proveedor], [Fecha_Emision], [Estado], [Motivo_Anulacion]) VALUES (11, 12, 1, CAST(N'2025-03-01T09:00:00.000' AS DateTime), N'Recibida', NULL)
INSERT [dbo].[ORDEN_COMPRA] ([Id_OrdenCompra], [Id_Ficha], [Id_Proveedor], [Fecha_Emision], [Estado], [Motivo_Anulacion]) VALUES (12, 13, 2, CAST(N'2025-05-10T11:00:00.000' AS DateTime), N'Recibida', NULL)
INSERT [dbo].[ORDEN_COMPRA] ([Id_OrdenCompra], [Id_Ficha], [Id_Proveedor], [Fecha_Emision], [Estado], [Motivo_Anulacion]) VALUES (13, 14, 1, CAST(N'2025-08-01T08:30:00.000' AS DateTime), N'Recibida', NULL)
INSERT [dbo].[ORDEN_COMPRA] ([Id_OrdenCompra], [Id_Ficha], [Id_Proveedor], [Fecha_Emision], [Estado], [Motivo_Anulacion]) VALUES (14, 15, 2, CAST(N'2025-10-25T14:00:00.000' AS DateTime), N'Recibida', NULL)
INSERT [dbo].[ORDEN_COMPRA] ([Id_OrdenCompra], [Id_Ficha], [Id_Proveedor], [Fecha_Emision], [Estado], [Motivo_Anulacion]) VALUES (15, 16, 1, CAST(N'2026-01-05T10:00:00.000' AS DateTime), N'Recibida', NULL)
INSERT [dbo].[ORDEN_COMPRA] ([Id_OrdenCompra], [Id_Ficha], [Id_Proveedor], [Fecha_Emision], [Estado], [Motivo_Anulacion]) VALUES (16, 17, 2, CAST(N'2026-04-01T16:00:00.000' AS DateTime), N'Recibida', NULL)
INSERT [dbo].[ORDEN_COMPRA] ([Id_OrdenCompra], [Id_Ficha], [Id_Proveedor], [Fecha_Emision], [Estado], [Motivo_Anulacion]) VALUES (17, 18, 1, CAST(N'2024-04-01T09:00:00.000' AS DateTime), N'Recibida', NULL)
INSERT [dbo].[ORDEN_COMPRA] ([Id_OrdenCompra], [Id_Ficha], [Id_Proveedor], [Fecha_Emision], [Estado], [Motivo_Anulacion]) VALUES (18, 19, 2, CAST(N'2024-06-10T11:00:00.000' AS DateTime), N'Recibida', NULL)
INSERT [dbo].[ORDEN_COMPRA] ([Id_OrdenCompra], [Id_Ficha], [Id_Proveedor], [Fecha_Emision], [Estado], [Motivo_Anulacion]) VALUES (19, 20, 1, CAST(N'2024-09-01T08:30:00.000' AS DateTime), N'Recibida', NULL)
INSERT [dbo].[ORDEN_COMPRA] ([Id_OrdenCompra], [Id_Ficha], [Id_Proveedor], [Fecha_Emision], [Estado], [Motivo_Anulacion]) VALUES (20, 21, 2, CAST(N'2024-11-15T14:00:00.000' AS DateTime), N'Recibida', NULL)
INSERT [dbo].[ORDEN_COMPRA] ([Id_OrdenCompra], [Id_Ficha], [Id_Proveedor], [Fecha_Emision], [Estado], [Motivo_Anulacion]) VALUES (21, 22, 1, CAST(N'2024-12-05T10:00:00.000' AS DateTime), N'Recibida', NULL)
INSERT [dbo].[ORDEN_COMPRA] ([Id_OrdenCompra], [Id_Ficha], [Id_Proveedor], [Fecha_Emision], [Estado], [Motivo_Anulacion]) VALUES (22, 23, 2, CAST(N'2025-02-01T16:00:00.000' AS DateTime), N'Recibida', NULL)
INSERT [dbo].[ORDEN_COMPRA] ([Id_OrdenCompra], [Id_Ficha], [Id_Proveedor], [Fecha_Emision], [Estado], [Motivo_Anulacion]) VALUES (23, 24, 1, CAST(N'2025-03-25T11:30:00.000' AS DateTime), N'Recibida', NULL)
INSERT [dbo].[ORDEN_COMPRA] ([Id_OrdenCompra], [Id_Ficha], [Id_Proveedor], [Fecha_Emision], [Estado], [Motivo_Anulacion]) VALUES (24, 25, 2, CAST(N'2025-07-05T09:15:00.000' AS DateTime), N'Recibida', NULL)
INSERT [dbo].[ORDEN_COMPRA] ([Id_OrdenCompra], [Id_Ficha], [Id_Proveedor], [Fecha_Emision], [Estado], [Motivo_Anulacion]) VALUES (25, 26, 1, CAST(N'2025-10-01T10:00:00.000' AS DateTime), N'Recibida', NULL)
INSERT [dbo].[ORDEN_COMPRA] ([Id_OrdenCompra], [Id_Ficha], [Id_Proveedor], [Fecha_Emision], [Estado], [Motivo_Anulacion]) VALUES (26, 27, 2, CAST(N'2026-02-15T14:45:00.000' AS DateTime), N'Recibida', NULL)
INSERT [dbo].[ORDEN_COMPRA] ([Id_OrdenCompra], [Id_Ficha], [Id_Proveedor], [Fecha_Emision], [Estado], [Motivo_Anulacion]) VALUES (27, 28, 1, CAST(N'2024-05-01T09:00:00.000' AS DateTime), N'Recibida', NULL)
INSERT [dbo].[ORDEN_COMPRA] ([Id_OrdenCompra], [Id_Ficha], [Id_Proveedor], [Fecha_Emision], [Estado], [Motivo_Anulacion]) VALUES (28, 29, 2, CAST(N'2024-07-05T10:00:00.000' AS DateTime), N'Recibida', NULL)
INSERT [dbo].[ORDEN_COMPRA] ([Id_OrdenCompra], [Id_Ficha], [Id_Proveedor], [Fecha_Emision], [Estado], [Motivo_Anulacion]) VALUES (29, 30, 1, CAST(N'2024-09-20T11:00:00.000' AS DateTime), N'Recibida', NULL)
INSERT [dbo].[ORDEN_COMPRA] ([Id_OrdenCompra], [Id_Ficha], [Id_Proveedor], [Fecha_Emision], [Estado], [Motivo_Anulacion]) VALUES (30, 31, 2, CAST(N'2024-11-20T14:00:00.000' AS DateTime), N'Recibida', NULL)
INSERT [dbo].[ORDEN_COMPRA] ([Id_OrdenCompra], [Id_Ficha], [Id_Proveedor], [Fecha_Emision], [Estado], [Motivo_Anulacion]) VALUES (31, 32, 1, CAST(N'2025-01-10T08:30:00.000' AS DateTime), N'Recibida', NULL)
INSERT [dbo].[ORDEN_COMPRA] ([Id_OrdenCompra], [Id_Ficha], [Id_Proveedor], [Fecha_Emision], [Estado], [Motivo_Anulacion]) VALUES (32, 33, 2, CAST(N'2025-03-10T15:00:00.000' AS DateTime), N'Recibida', NULL)
INSERT [dbo].[ORDEN_COMPRA] ([Id_OrdenCompra], [Id_Ficha], [Id_Proveedor], [Fecha_Emision], [Estado], [Motivo_Anulacion]) VALUES (33, 34, 1, CAST(N'2025-06-01T10:00:00.000' AS DateTime), N'Recibida', NULL)
INSERT [dbo].[ORDEN_COMPRA] ([Id_OrdenCompra], [Id_Ficha], [Id_Proveedor], [Fecha_Emision], [Estado], [Motivo_Anulacion]) VALUES (34, 35, 2, CAST(N'2025-08-25T12:00:00.000' AS DateTime), N'Recibida', NULL)
INSERT [dbo].[ORDEN_COMPRA] ([Id_OrdenCompra], [Id_Ficha], [Id_Proveedor], [Fecha_Emision], [Estado], [Motivo_Anulacion]) VALUES (35, 36, 1, CAST(N'2025-11-01T09:30:00.000' AS DateTime), N'Recibida', NULL)
INSERT [dbo].[ORDEN_COMPRA] ([Id_OrdenCompra], [Id_Ficha], [Id_Proveedor], [Fecha_Emision], [Estado], [Motivo_Anulacion]) VALUES (36, 37, 2, CAST(N'2026-02-20T11:00:00.000' AS DateTime), N'Recibida', NULL)
INSERT [dbo].[ORDEN_COMPRA] ([Id_OrdenCompra], [Id_Ficha], [Id_Proveedor], [Fecha_Emision], [Estado], [Motivo_Anulacion]) VALUES (37, 38, 1, CAST(N'2024-08-01T09:00:00.000' AS DateTime), N'Recibida', NULL)
INSERT [dbo].[ORDEN_COMPRA] ([Id_OrdenCompra], [Id_Ficha], [Id_Proveedor], [Fecha_Emision], [Estado], [Motivo_Anulacion]) VALUES (38, 39, 2, CAST(N'2024-11-01T10:00:00.000' AS DateTime), N'Recibida', NULL)
INSERT [dbo].[ORDEN_COMPRA] ([Id_OrdenCompra], [Id_Ficha], [Id_Proveedor], [Fecha_Emision], [Estado], [Motivo_Anulacion]) VALUES (39, 40, 1, CAST(N'2025-04-05T11:00:00.000' AS DateTime), N'Recibida', NULL)
INSERT [dbo].[ORDEN_COMPRA] ([Id_OrdenCompra], [Id_Ficha], [Id_Proveedor], [Fecha_Emision], [Estado], [Motivo_Anulacion]) VALUES (40, 41, 2, CAST(N'2025-08-10T14:00:00.000' AS DateTime), N'Recibida', NULL)
INSERT [dbo].[ORDEN_COMPRA] ([Id_OrdenCompra], [Id_Ficha], [Id_Proveedor], [Fecha_Emision], [Estado], [Motivo_Anulacion]) VALUES (41, 42, 1, CAST(N'2026-01-02T08:30:00.000' AS DateTime), N'Recibida', NULL)
INSERT [dbo].[ORDEN_COMPRA] ([Id_OrdenCompra], [Id_Ficha], [Id_Proveedor], [Fecha_Emision], [Estado], [Motivo_Anulacion]) VALUES (42, NULL, 1, CAST(N'2026-11-02T16:12:12.713' AS DateTime), N'Recibida', NULL)
INSERT [dbo].[ORDEN_COMPRA] ([Id_OrdenCompra], [Id_Ficha], [Id_Proveedor], [Fecha_Emision], [Estado], [Motivo_Anulacion]) VALUES (43, NULL, 1, CAST(N'2026-11-02T16:47:13.747' AS DateTime), N'Recibida', NULL)
INSERT [dbo].[ORDEN_COMPRA] ([Id_OrdenCompra], [Id_Ficha], [Id_Proveedor], [Fecha_Emision], [Estado], [Motivo_Anulacion]) VALUES (44, NULL, 1, CAST(N'2025-05-10T11:00:00.000' AS DateTime), N'Recibida', NULL)
INSERT [dbo].[ORDEN_COMPRA] ([Id_OrdenCompra], [Id_Ficha], [Id_Proveedor], [Fecha_Emision], [Estado], [Motivo_Anulacion]) VALUES (45, 46, 2, CAST(N'2026-02-01T14:00:00.000' AS DateTime), N'Recibida', NULL)
INSERT [dbo].[ORDEN_COMPRA] ([Id_OrdenCompra], [Id_Ficha], [Id_Proveedor], [Fecha_Emision], [Estado], [Motivo_Anulacion]) VALUES (46, NULL, 1, CAST(N'2026-05-01T09:00:00.000' AS DateTime), N'Recibida', NULL)
INSERT [dbo].[ORDEN_COMPRA] ([Id_OrdenCompra], [Id_Ficha], [Id_Proveedor], [Fecha_Emision], [Estado], [Motivo_Anulacion]) VALUES (47, 48, 2, CAST(N'2026-06-05T10:00:00.000' AS DateTime), N'Recibida', NULL)
INSERT [dbo].[ORDEN_COMPRA] ([Id_OrdenCompra], [Id_Ficha], [Id_Proveedor], [Fecha_Emision], [Estado], [Motivo_Anulacion]) VALUES (48, 49, 1, CAST(N'2026-07-01T09:00:00.000' AS DateTime), N'Recibida', NULL)
INSERT [dbo].[ORDEN_COMPRA] ([Id_OrdenCompra], [Id_Ficha], [Id_Proveedor], [Fecha_Emision], [Estado], [Motivo_Anulacion]) VALUES (49, 50, 2, CAST(N'2026-08-10T10:00:00.000' AS DateTime), N'Recibida', NULL)
INSERT [dbo].[ORDEN_COMPRA] ([Id_OrdenCompra], [Id_Ficha], [Id_Proveedor], [Fecha_Emision], [Estado], [Motivo_Anulacion]) VALUES (50, 51, 1, CAST(N'2026-09-01T11:00:00.000' AS DateTime), N'Recibida', NULL)
INSERT [dbo].[ORDEN_COMPRA] ([Id_OrdenCompra], [Id_Ficha], [Id_Proveedor], [Fecha_Emision], [Estado], [Motivo_Anulacion]) VALUES (51, 52, 2, CAST(N'2026-09-25T14:00:00.000' AS DateTime), N'Recibida', NULL)
INSERT [dbo].[ORDEN_COMPRA] ([Id_OrdenCompra], [Id_Ficha], [Id_Proveedor], [Fecha_Emision], [Estado], [Motivo_Anulacion]) VALUES (52, 53, 1, CAST(N'2026-10-15T08:30:00.000' AS DateTime), N'Recibida', NULL)
INSERT [dbo].[ORDEN_COMPRA] ([Id_OrdenCompra], [Id_Ficha], [Id_Proveedor], [Fecha_Emision], [Estado], [Motivo_Anulacion]) VALUES (53, 54, 1, CAST(N'2026-11-01T09:00:00.000' AS DateTime), N'Recibida', NULL)
INSERT [dbo].[ORDEN_COMPRA] ([Id_OrdenCompra], [Id_Ficha], [Id_Proveedor], [Fecha_Emision], [Estado], [Motivo_Anulacion]) VALUES (54, 55, 2, CAST(N'2026-11-10T10:00:00.000' AS DateTime), N'Recibida', NULL)
INSERT [dbo].[ORDEN_COMPRA] ([Id_OrdenCompra], [Id_Ficha], [Id_Proveedor], [Fecha_Emision], [Estado], [Motivo_Anulacion]) VALUES (55, 56, 1, CAST(N'2026-11-25T11:00:00.000' AS DateTime), N'Recibida', NULL)
INSERT [dbo].[ORDEN_COMPRA] ([Id_OrdenCompra], [Id_Ficha], [Id_Proveedor], [Fecha_Emision], [Estado], [Motivo_Anulacion]) VALUES (1053, NULL, 2, CAST(N'2026-11-14T00:52:42.163' AS DateTime), N'Recibida', NULL)
INSERT [dbo].[ORDEN_COMPRA] ([Id_OrdenCompra], [Id_Ficha], [Id_Proveedor], [Fecha_Emision], [Estado], [Motivo_Anulacion]) VALUES (1054, NULL, 1, CAST(N'2026-11-14T01:12:49.823' AS DateTime), N'Recibida', NULL)
INSERT [dbo].[ORDEN_COMPRA] ([Id_OrdenCompra], [Id_Ficha], [Id_Proveedor], [Fecha_Emision], [Estado], [Motivo_Anulacion]) VALUES (1055, NULL, 2, CAST(N'2026-11-14T01:15:03.030' AS DateTime), N'Recibida', NULL)
INSERT [dbo].[ORDEN_COMPRA] ([Id_OrdenCompra], [Id_Ficha], [Id_Proveedor], [Fecha_Emision], [Estado], [Motivo_Anulacion]) VALUES (1056, NULL, 2, CAST(N'2026-11-15T12:16:25.987' AS DateTime), N'Emitida', NULL)
INSERT [dbo].[ORDEN_COMPRA] ([Id_OrdenCompra], [Id_Ficha], [Id_Proveedor], [Fecha_Emision], [Estado], [Motivo_Anulacion]) VALUES (1057, NULL, 2, CAST(N'2026-11-15T12:28:19.917' AS DateTime), N'Emitida', NULL)
INSERT [dbo].[ORDEN_COMPRA] ([Id_OrdenCompra], [Id_Ficha], [Id_Proveedor], [Fecha_Emision], [Estado], [Motivo_Anulacion]) VALUES (1058, NULL, 1, CAST(N'2026-11-15T12:31:34.283' AS DateTime), N'Emitida', NULL)
INSERT [dbo].[ORDEN_COMPRA] ([Id_OrdenCompra], [Id_Ficha], [Id_Proveedor], [Fecha_Emision], [Estado], [Motivo_Anulacion]) VALUES (1059, 1056, 1, CAST(N'2026-10-20T00:00:00.000' AS DateTime), N'Recibida', NULL)
INSERT [dbo].[ORDEN_COMPRA] ([Id_OrdenCompra], [Id_Ficha], [Id_Proveedor], [Fecha_Emision], [Estado], [Motivo_Anulacion]) VALUES (1060, 1057, 1, CAST(N'2026-10-17T00:00:00.000' AS DateTime), N'Recibida', NULL)
INSERT [dbo].[ORDEN_COMPRA] ([Id_OrdenCompra], [Id_Ficha], [Id_Proveedor], [Fecha_Emision], [Estado], [Motivo_Anulacion]) VALUES (1061, 1058, 1, CAST(N'2026-10-14T00:00:00.000' AS DateTime), N'Recibida', NULL)
INSERT [dbo].[ORDEN_COMPRA] ([Id_OrdenCompra], [Id_Ficha], [Id_Proveedor], [Fecha_Emision], [Estado], [Motivo_Anulacion]) VALUES (1062, 1059, 1, CAST(N'2026-10-11T00:00:00.000' AS DateTime), N'Recibida', NULL)
INSERT [dbo].[ORDEN_COMPRA] ([Id_OrdenCompra], [Id_Ficha], [Id_Proveedor], [Fecha_Emision], [Estado], [Motivo_Anulacion]) VALUES (1063, 1060, 1, CAST(N'2026-10-08T00:00:00.000' AS DateTime), N'Recibida', NULL)
INSERT [dbo].[ORDEN_COMPRA] ([Id_OrdenCompra], [Id_Ficha], [Id_Proveedor], [Fecha_Emision], [Estado], [Motivo_Anulacion]) VALUES (1064, 1061, 1, CAST(N'2026-10-05T00:00:00.000' AS DateTime), N'Recibida', NULL)
INSERT [dbo].[ORDEN_COMPRA] ([Id_OrdenCompra], [Id_Ficha], [Id_Proveedor], [Fecha_Emision], [Estado], [Motivo_Anulacion]) VALUES (1065, 1062, 1, CAST(N'2026-10-02T00:00:00.000' AS DateTime), N'Recibida', NULL)
INSERT [dbo].[ORDEN_COMPRA] ([Id_OrdenCompra], [Id_Ficha], [Id_Proveedor], [Fecha_Emision], [Estado], [Motivo_Anulacion]) VALUES (1066, 1063, 1, CAST(N'2026-09-29T00:00:00.000' AS DateTime), N'Recibida', NULL)
INSERT [dbo].[ORDEN_COMPRA] ([Id_OrdenCompra], [Id_Ficha], [Id_Proveedor], [Fecha_Emision], [Estado], [Motivo_Anulacion]) VALUES (1067, 1064, 1, CAST(N'2026-09-26T00:00:00.000' AS DateTime), N'Recibida', NULL)
INSERT [dbo].[ORDEN_COMPRA] ([Id_OrdenCompra], [Id_Ficha], [Id_Proveedor], [Fecha_Emision], [Estado], [Motivo_Anulacion]) VALUES (1068, 1065, 1, CAST(N'2026-09-23T00:00:00.000' AS DateTime), N'Recibida', NULL)
INSERT [dbo].[ORDEN_COMPRA] ([Id_OrdenCompra], [Id_Ficha], [Id_Proveedor], [Fecha_Emision], [Estado], [Motivo_Anulacion]) VALUES (1069, 1066, 1, CAST(N'2026-09-20T00:00:00.000' AS DateTime), N'Recibida', NULL)
INSERT [dbo].[ORDEN_COMPRA] ([Id_OrdenCompra], [Id_Ficha], [Id_Proveedor], [Fecha_Emision], [Estado], [Motivo_Anulacion]) VALUES (1070, 1067, 1, CAST(N'2026-09-17T00:00:00.000' AS DateTime), N'Recibida', NULL)
INSERT [dbo].[ORDEN_COMPRA] ([Id_OrdenCompra], [Id_Ficha], [Id_Proveedor], [Fecha_Emision], [Estado], [Motivo_Anulacion]) VALUES (1071, 1068, 1, CAST(N'2026-09-14T00:00:00.000' AS DateTime), N'Recibida', NULL)
INSERT [dbo].[ORDEN_COMPRA] ([Id_OrdenCompra], [Id_Ficha], [Id_Proveedor], [Fecha_Emision], [Estado], [Motivo_Anulacion]) VALUES (1072, 1069, 1, CAST(N'2026-09-11T00:00:00.000' AS DateTime), N'Recibida', NULL)
INSERT [dbo].[ORDEN_COMPRA] ([Id_OrdenCompra], [Id_Ficha], [Id_Proveedor], [Fecha_Emision], [Estado], [Motivo_Anulacion]) VALUES (1073, 1070, 1, CAST(N'2026-09-08T00:00:00.000' AS DateTime), N'Recibida', NULL)
INSERT [dbo].[ORDEN_COMPRA] ([Id_OrdenCompra], [Id_Ficha], [Id_Proveedor], [Fecha_Emision], [Estado], [Motivo_Anulacion]) VALUES (1074, 1071, 1, CAST(N'2026-09-05T00:00:00.000' AS DateTime), N'Recibida', NULL)
INSERT [dbo].[ORDEN_COMPRA] ([Id_OrdenCompra], [Id_Ficha], [Id_Proveedor], [Fecha_Emision], [Estado], [Motivo_Anulacion]) VALUES (1075, 1072, 1, CAST(N'2026-09-02T00:00:00.000' AS DateTime), N'Recibida', NULL)
INSERT [dbo].[ORDEN_COMPRA] ([Id_OrdenCompra], [Id_Ficha], [Id_Proveedor], [Fecha_Emision], [Estado], [Motivo_Anulacion]) VALUES (1076, 1073, 1, CAST(N'2026-08-30T00:00:00.000' AS DateTime), N'Recibida', NULL)
INSERT [dbo].[ORDEN_COMPRA] ([Id_OrdenCompra], [Id_Ficha], [Id_Proveedor], [Fecha_Emision], [Estado], [Motivo_Anulacion]) VALUES (1077, 1074, 1, CAST(N'2026-08-27T00:00:00.000' AS DateTime), N'Recibida', NULL)
INSERT [dbo].[ORDEN_COMPRA] ([Id_OrdenCompra], [Id_Ficha], [Id_Proveedor], [Fecha_Emision], [Estado], [Motivo_Anulacion]) VALUES (1078, 1075, 1, CAST(N'2026-08-24T00:00:00.000' AS DateTime), N'Recibida', NULL)
INSERT [dbo].[ORDEN_COMPRA] ([Id_OrdenCompra], [Id_Ficha], [Id_Proveedor], [Fecha_Emision], [Estado], [Motivo_Anulacion]) VALUES (1079, 1076, 1, CAST(N'2026-08-21T00:00:00.000' AS DateTime), N'Recibida', NULL)
INSERT [dbo].[ORDEN_COMPRA] ([Id_OrdenCompra], [Id_Ficha], [Id_Proveedor], [Fecha_Emision], [Estado], [Motivo_Anulacion]) VALUES (1080, 1077, 1, CAST(N'2026-08-18T00:00:00.000' AS DateTime), N'Recibida', NULL)
INSERT [dbo].[ORDEN_COMPRA] ([Id_OrdenCompra], [Id_Ficha], [Id_Proveedor], [Fecha_Emision], [Estado], [Motivo_Anulacion]) VALUES (1081, 1078, 1, CAST(N'2026-08-15T00:00:00.000' AS DateTime), N'Recibida', NULL)
INSERT [dbo].[ORDEN_COMPRA] ([Id_OrdenCompra], [Id_Ficha], [Id_Proveedor], [Fecha_Emision], [Estado], [Motivo_Anulacion]) VALUES (1082, 1079, 1, CAST(N'2026-08-12T00:00:00.000' AS DateTime), N'Recibida', NULL)
INSERT [dbo].[ORDEN_COMPRA] ([Id_OrdenCompra], [Id_Ficha], [Id_Proveedor], [Fecha_Emision], [Estado], [Motivo_Anulacion]) VALUES (1083, 1080, 1, CAST(N'2026-08-09T00:00:00.000' AS DateTime), N'Recibida', NULL)
INSERT [dbo].[ORDEN_COMPRA] ([Id_OrdenCompra], [Id_Ficha], [Id_Proveedor], [Fecha_Emision], [Estado], [Motivo_Anulacion]) VALUES (1084, 1081, 1, CAST(N'2026-08-06T00:00:00.000' AS DateTime), N'Recibida', NULL)
INSERT [dbo].[ORDEN_COMPRA] ([Id_OrdenCompra], [Id_Ficha], [Id_Proveedor], [Fecha_Emision], [Estado], [Motivo_Anulacion]) VALUES (1085, 1082, 1, CAST(N'2026-08-03T00:00:00.000' AS DateTime), N'Recibida', NULL)
INSERT [dbo].[ORDEN_COMPRA] ([Id_OrdenCompra], [Id_Ficha], [Id_Proveedor], [Fecha_Emision], [Estado], [Motivo_Anulacion]) VALUES (1086, 1083, 1, CAST(N'2026-07-31T00:00:00.000' AS DateTime), N'Recibida', NULL)
INSERT [dbo].[ORDEN_COMPRA] ([Id_OrdenCompra], [Id_Ficha], [Id_Proveedor], [Fecha_Emision], [Estado], [Motivo_Anulacion]) VALUES (1087, 1084, 1, CAST(N'2026-07-28T00:00:00.000' AS DateTime), N'Recibida', NULL)
INSERT [dbo].[ORDEN_COMPRA] ([Id_OrdenCompra], [Id_Ficha], [Id_Proveedor], [Fecha_Emision], [Estado], [Motivo_Anulacion]) VALUES (1088, 1085, 1, CAST(N'2026-07-25T00:00:00.000' AS DateTime), N'Recibida', NULL)
INSERT [dbo].[ORDEN_COMPRA] ([Id_OrdenCompra], [Id_Ficha], [Id_Proveedor], [Fecha_Emision], [Estado], [Motivo_Anulacion]) VALUES (1089, 1086, 1, CAST(N'2026-07-22T00:00:00.000' AS DateTime), N'Recibida', NULL)
INSERT [dbo].[ORDEN_COMPRA] ([Id_OrdenCompra], [Id_Ficha], [Id_Proveedor], [Fecha_Emision], [Estado], [Motivo_Anulacion]) VALUES (1090, 1087, 1, CAST(N'2026-07-19T00:00:00.000' AS DateTime), N'Recibida', NULL)
INSERT [dbo].[ORDEN_COMPRA] ([Id_OrdenCompra], [Id_Ficha], [Id_Proveedor], [Fecha_Emision], [Estado], [Motivo_Anulacion]) VALUES (1091, 1088, 1, CAST(N'2026-07-16T00:00:00.000' AS DateTime), N'Recibida', NULL)
INSERT [dbo].[ORDEN_COMPRA] ([Id_OrdenCompra], [Id_Ficha], [Id_Proveedor], [Fecha_Emision], [Estado], [Motivo_Anulacion]) VALUES (1092, 1089, 1, CAST(N'2026-07-13T00:00:00.000' AS DateTime), N'Recibida', NULL)
INSERT [dbo].[ORDEN_COMPRA] ([Id_OrdenCompra], [Id_Ficha], [Id_Proveedor], [Fecha_Emision], [Estado], [Motivo_Anulacion]) VALUES (1093, 1090, 1, CAST(N'2026-07-10T00:00:00.000' AS DateTime), N'Recibida', NULL)
INSERT [dbo].[ORDEN_COMPRA] ([Id_OrdenCompra], [Id_Ficha], [Id_Proveedor], [Fecha_Emision], [Estado], [Motivo_Anulacion]) VALUES (1094, 1091, 1, CAST(N'2026-07-07T00:00:00.000' AS DateTime), N'Recibida', NULL)
INSERT [dbo].[ORDEN_COMPRA] ([Id_OrdenCompra], [Id_Ficha], [Id_Proveedor], [Fecha_Emision], [Estado], [Motivo_Anulacion]) VALUES (1095, 1092, 1, CAST(N'2026-07-04T00:00:00.000' AS DateTime), N'Recibida', NULL)
INSERT [dbo].[ORDEN_COMPRA] ([Id_OrdenCompra], [Id_Ficha], [Id_Proveedor], [Fecha_Emision], [Estado], [Motivo_Anulacion]) VALUES (1096, 1093, 1, CAST(N'2026-07-01T00:00:00.000' AS DateTime), N'Recibida', NULL)
INSERT [dbo].[ORDEN_COMPRA] ([Id_OrdenCompra], [Id_Ficha], [Id_Proveedor], [Fecha_Emision], [Estado], [Motivo_Anulacion]) VALUES (1097, 1094, 1, CAST(N'2026-06-28T00:00:00.000' AS DateTime), N'Recibida', NULL)
GO
INSERT [dbo].[ORDEN_COMPRA] ([Id_OrdenCompra], [Id_Ficha], [Id_Proveedor], [Fecha_Emision], [Estado], [Motivo_Anulacion]) VALUES (1098, 1095, 1, CAST(N'2026-06-25T00:00:00.000' AS DateTime), N'Recibida', NULL)
INSERT [dbo].[ORDEN_COMPRA] ([Id_OrdenCompra], [Id_Ficha], [Id_Proveedor], [Fecha_Emision], [Estado], [Motivo_Anulacion]) VALUES (1099, 1096, 1, CAST(N'2026-06-22T00:00:00.000' AS DateTime), N'Recibida', NULL)
INSERT [dbo].[ORDEN_COMPRA] ([Id_OrdenCompra], [Id_Ficha], [Id_Proveedor], [Fecha_Emision], [Estado], [Motivo_Anulacion]) VALUES (1100, 1097, 1, CAST(N'2026-06-19T00:00:00.000' AS DateTime), N'Recibida', NULL)
INSERT [dbo].[ORDEN_COMPRA] ([Id_OrdenCompra], [Id_Ficha], [Id_Proveedor], [Fecha_Emision], [Estado], [Motivo_Anulacion]) VALUES (1101, 1098, 1, CAST(N'2026-06-16T00:00:00.000' AS DateTime), N'Recibida', NULL)
INSERT [dbo].[ORDEN_COMPRA] ([Id_OrdenCompra], [Id_Ficha], [Id_Proveedor], [Fecha_Emision], [Estado], [Motivo_Anulacion]) VALUES (1102, 1099, 1, CAST(N'2026-06-13T00:00:00.000' AS DateTime), N'Recibida', NULL)
INSERT [dbo].[ORDEN_COMPRA] ([Id_OrdenCompra], [Id_Ficha], [Id_Proveedor], [Fecha_Emision], [Estado], [Motivo_Anulacion]) VALUES (1103, 1100, 1, CAST(N'2026-06-10T00:00:00.000' AS DateTime), N'Recibida', NULL)
INSERT [dbo].[ORDEN_COMPRA] ([Id_OrdenCompra], [Id_Ficha], [Id_Proveedor], [Fecha_Emision], [Estado], [Motivo_Anulacion]) VALUES (1104, 1101, 1, CAST(N'2026-06-07T00:00:00.000' AS DateTime), N'Recibida', NULL)
INSERT [dbo].[ORDEN_COMPRA] ([Id_OrdenCompra], [Id_Ficha], [Id_Proveedor], [Fecha_Emision], [Estado], [Motivo_Anulacion]) VALUES (1105, 1102, 1, CAST(N'2026-06-04T00:00:00.000' AS DateTime), N'Recibida', NULL)
INSERT [dbo].[ORDEN_COMPRA] ([Id_OrdenCompra], [Id_Ficha], [Id_Proveedor], [Fecha_Emision], [Estado], [Motivo_Anulacion]) VALUES (1106, 1103, 1, CAST(N'2026-06-01T00:00:00.000' AS DateTime), N'Recibida', NULL)
INSERT [dbo].[ORDEN_COMPRA] ([Id_OrdenCompra], [Id_Ficha], [Id_Proveedor], [Fecha_Emision], [Estado], [Motivo_Anulacion]) VALUES (1107, 1104, 1, CAST(N'2026-05-29T00:00:00.000' AS DateTime), N'Recibida', NULL)
INSERT [dbo].[ORDEN_COMPRA] ([Id_OrdenCompra], [Id_Ficha], [Id_Proveedor], [Fecha_Emision], [Estado], [Motivo_Anulacion]) VALUES (1108, 1105, 1, CAST(N'2026-05-26T00:00:00.000' AS DateTime), N'Recibida', NULL)
INSERT [dbo].[ORDEN_COMPRA] ([Id_OrdenCompra], [Id_Ficha], [Id_Proveedor], [Fecha_Emision], [Estado], [Motivo_Anulacion]) VALUES (1109, 1106, 1, CAST(N'2026-05-23T00:00:00.000' AS DateTime), N'Recibida', NULL)
INSERT [dbo].[ORDEN_COMPRA] ([Id_OrdenCompra], [Id_Ficha], [Id_Proveedor], [Fecha_Emision], [Estado], [Motivo_Anulacion]) VALUES (1110, 1107, 1, CAST(N'2026-05-20T00:00:00.000' AS DateTime), N'Recibida', NULL)
INSERT [dbo].[ORDEN_COMPRA] ([Id_OrdenCompra], [Id_Ficha], [Id_Proveedor], [Fecha_Emision], [Estado], [Motivo_Anulacion]) VALUES (1111, 1108, 1, CAST(N'2026-05-17T00:00:00.000' AS DateTime), N'Recibida', NULL)
INSERT [dbo].[ORDEN_COMPRA] ([Id_OrdenCompra], [Id_Ficha], [Id_Proveedor], [Fecha_Emision], [Estado], [Motivo_Anulacion]) VALUES (1112, 1109, 1, CAST(N'2026-05-14T00:00:00.000' AS DateTime), N'Recibida', NULL)
INSERT [dbo].[ORDEN_COMPRA] ([Id_OrdenCompra], [Id_Ficha], [Id_Proveedor], [Fecha_Emision], [Estado], [Motivo_Anulacion]) VALUES (1169, NULL, 2, CAST(N'2026-11-21T20:43:21.120' AS DateTime), N'Emitida', NULL)
SET IDENTITY_INSERT [dbo].[ORDEN_COMPRA] OFF
GO
SET IDENTITY_INSERT [dbo].[PARAMETRO_RATIO] ON 

INSERT [dbo].[PARAMETRO_RATIO] ([Id_Ratio], [Categoria], [Cantidad_Invitados_Por_Personal], [Estado]) VALUES (1, N'Mozo', 12, N'Activo')
INSERT [dbo].[PARAMETRO_RATIO] ([Id_Ratio], [Categoria], [Cantidad_Invitados_Por_Personal], [Estado]) VALUES (2, N'Cocinero', 32, N'Activo')
INSERT [dbo].[PARAMETRO_RATIO] ([Id_Ratio], [Categoria], [Cantidad_Invitados_Por_Personal], [Estado]) VALUES (3, N'Seguridad', 52, N'Activo')
INSERT [dbo].[PARAMETRO_RATIO] ([Id_Ratio], [Categoria], [Cantidad_Invitados_Por_Personal], [Estado]) VALUES (4, N'Maitre', 102, N'Activo')
SET IDENTITY_INSERT [dbo].[PARAMETRO_RATIO] OFF
GO
INSERT [dbo].[PERMISO] ([ID], [NOMBRE], [ESCOMPUESTO]) VALUES (1, N'ADMIN', 1)
INSERT [dbo].[PERMISO] ([ID], [NOMBRE], [ESCOMPUESTO]) VALUES (3, N'ABM_PERMISOS', 0)
INSERT [dbo].[PERMISO] ([ID], [NOMBRE], [ESCOMPUESTO]) VALUES (4, N'ABM_USUARIO', 0)
INSERT [dbo].[PERMISO] ([ID], [NOMBRE], [ESCOMPUESTO]) VALUES (6, N'BITACORA', 0)
INSERT [dbo].[PERMISO] ([ID], [NOMBRE], [ESCOMPUESTO]) VALUES (8, N'RESTAURACION_BASE', 0)
INSERT [dbo].[PERMISO] ([ID], [NOMBRE], [ESCOMPUESTO]) VALUES (9, N'ABM_IDIOMAS', 0)
INSERT [dbo].[PERMISO] ([ID], [NOMBRE], [ESCOMPUESTO]) VALUES (10, N'HISTORIAL_CAMBIOS', 0)
INSERT [dbo].[PERMISO] ([ID], [NOMBRE], [ESCOMPUESTO]) VALUES (11, N'ABM_PRODUCTOS', 0)
INSERT [dbo].[PERMISO] ([ID], [NOMBRE], [ESCOMPUESTO]) VALUES (12, N'GERENTE_OPERACIONES', 1)
INSERT [dbo].[PERMISO] ([ID], [NOMBRE], [ESCOMPUESTO]) VALUES (13, N'EJECUTIVO_VENTAS', 1)
INSERT [dbo].[PERMISO] ([ID], [NOMBRE], [ESCOMPUESTO]) VALUES (14, N'ORGANIZADOR_EVENTOS', 1)
INSERT [dbo].[PERMISO] ([ID], [NOMBRE], [ESCOMPUESTO]) VALUES (15, N'ENCARGADO_DEPOSITO', 1)
INSERT [dbo].[PERMISO] ([ID], [NOMBRE], [ESCOMPUESTO]) VALUES (16, N'GESTION_CALENDARIO', 0)
INSERT [dbo].[PERMISO] ([ID], [NOMBRE], [ESCOMPUESTO]) VALUES (17, N'GESTION_PRESUPUESTO', 0)
INSERT [dbo].[PERMISO] ([ID], [NOMBRE], [ESCOMPUESTO]) VALUES (18, N'GESTION_FICHA_TECNICA', 0)
INSERT [dbo].[PERMISO] ([ID], [NOMBRE], [ESCOMPUESTO]) VALUES (19, N'GESTION_PERSONAL', 0)
INSERT [dbo].[PERMISO] ([ID], [NOMBRE], [ESCOMPUESTO]) VALUES (20, N'GESTION_RATIOS', 0)
INSERT [dbo].[PERMISO] ([ID], [NOMBRE], [ESCOMPUESTO]) VALUES (21, N'CONSULTAR_STOCK', 0)
INSERT [dbo].[PERMISO] ([ID], [NOMBRE], [ESCOMPUESTO]) VALUES (22, N'VER_DASHBOARD', 0)
INSERT [dbo].[PERMISO] ([ID], [NOMBRE], [ESCOMPUESTO]) VALUES (23, N'ABM_INSUMOS', 0)
INSERT [dbo].[PERMISO] ([ID], [NOMBRE], [ESCOMPUESTO]) VALUES (24, N'ABM_PERSONAL', 0)
INSERT [dbo].[PERMISO] ([ID], [NOMBRE], [ESCOMPUESTO]) VALUES (25, N'ABM_PROVEEDOR_INSUMO', 0)
INSERT [dbo].[PERMISO] ([ID], [NOMBRE], [ESCOMPUESTO]) VALUES (26, N'GESTION_RECETARIO', 0)
INSERT [dbo].[PERMISO] ([ID], [NOMBRE], [ESCOMPUESTO]) VALUES (27, N'GESTION_LIQUIDACION_FINAL', 0)
INSERT [dbo].[PERMISO] ([ID], [NOMBRE], [ESCOMPUESTO]) VALUES (28, N'ABM_CLIENTE', 0)
INSERT [dbo].[PERMISO] ([ID], [NOMBRE], [ESCOMPUESTO]) VALUES (29, N'GESTION_EVALUACION', 0)
INSERT [dbo].[PERMISO] ([ID], [NOMBRE], [ESCOMPUESTO]) VALUES (30, N'GESTION_ORDEN_COMPRA', 0)
INSERT [dbo].[PERMISO] ([ID], [NOMBRE], [ESCOMPUESTO]) VALUES (31, N'GESTION_PAGO', 0)
INSERT [dbo].[PERMISO] ([ID], [NOMBRE], [ESCOMPUESTO]) VALUES (32, N'GESTION_RECEPCIONAR_STOCK', 0)
INSERT [dbo].[PERMISO] ([ID], [NOMBRE], [ESCOMPUESTO]) VALUES (33, N'GESTION_ANULAR_REASIGNAR_ORDEN_COMPRA', 0)
GO
INSERT [dbo].[PERMISO_PERMISO] ([ID_PADRE], [ID_HIJO]) VALUES (1, 3)
INSERT [dbo].[PERMISO_PERMISO] ([ID_PADRE], [ID_HIJO]) VALUES (1, 4)
INSERT [dbo].[PERMISO_PERMISO] ([ID_PADRE], [ID_HIJO]) VALUES (1, 6)
INSERT [dbo].[PERMISO_PERMISO] ([ID_PADRE], [ID_HIJO]) VALUES (1, 8)
INSERT [dbo].[PERMISO_PERMISO] ([ID_PADRE], [ID_HIJO]) VALUES (1, 9)
INSERT [dbo].[PERMISO_PERMISO] ([ID_PADRE], [ID_HIJO]) VALUES (1, 10)
INSERT [dbo].[PERMISO_PERMISO] ([ID_PADRE], [ID_HIJO]) VALUES (1, 11)
INSERT [dbo].[PERMISO_PERMISO] ([ID_PADRE], [ID_HIJO]) VALUES (1, 16)
INSERT [dbo].[PERMISO_PERMISO] ([ID_PADRE], [ID_HIJO]) VALUES (1, 17)
INSERT [dbo].[PERMISO_PERMISO] ([ID_PADRE], [ID_HIJO]) VALUES (1, 18)
INSERT [dbo].[PERMISO_PERMISO] ([ID_PADRE], [ID_HIJO]) VALUES (1, 19)
INSERT [dbo].[PERMISO_PERMISO] ([ID_PADRE], [ID_HIJO]) VALUES (1, 20)
INSERT [dbo].[PERMISO_PERMISO] ([ID_PADRE], [ID_HIJO]) VALUES (1, 21)
INSERT [dbo].[PERMISO_PERMISO] ([ID_PADRE], [ID_HIJO]) VALUES (1, 22)
INSERT [dbo].[PERMISO_PERMISO] ([ID_PADRE], [ID_HIJO]) VALUES (1, 23)
INSERT [dbo].[PERMISO_PERMISO] ([ID_PADRE], [ID_HIJO]) VALUES (1, 24)
INSERT [dbo].[PERMISO_PERMISO] ([ID_PADRE], [ID_HIJO]) VALUES (1, 25)
INSERT [dbo].[PERMISO_PERMISO] ([ID_PADRE], [ID_HIJO]) VALUES (1, 26)
INSERT [dbo].[PERMISO_PERMISO] ([ID_PADRE], [ID_HIJO]) VALUES (1, 27)
INSERT [dbo].[PERMISO_PERMISO] ([ID_PADRE], [ID_HIJO]) VALUES (1, 28)
INSERT [dbo].[PERMISO_PERMISO] ([ID_PADRE], [ID_HIJO]) VALUES (1, 29)
INSERT [dbo].[PERMISO_PERMISO] ([ID_PADRE], [ID_HIJO]) VALUES (1, 30)
INSERT [dbo].[PERMISO_PERMISO] ([ID_PADRE], [ID_HIJO]) VALUES (1, 31)
INSERT [dbo].[PERMISO_PERMISO] ([ID_PADRE], [ID_HIJO]) VALUES (1, 32)
INSERT [dbo].[PERMISO_PERMISO] ([ID_PADRE], [ID_HIJO]) VALUES (1, 33)
INSERT [dbo].[PERMISO_PERMISO] ([ID_PADRE], [ID_HIJO]) VALUES (12, 19)
INSERT [dbo].[PERMISO_PERMISO] ([ID_PADRE], [ID_HIJO]) VALUES (12, 20)
INSERT [dbo].[PERMISO_PERMISO] ([ID_PADRE], [ID_HIJO]) VALUES (12, 21)
INSERT [dbo].[PERMISO_PERMISO] ([ID_PADRE], [ID_HIJO]) VALUES (12, 22)
INSERT [dbo].[PERMISO_PERMISO] ([ID_PADRE], [ID_HIJO]) VALUES (12, 25)
INSERT [dbo].[PERMISO_PERMISO] ([ID_PADRE], [ID_HIJO]) VALUES (12, 29)
INSERT [dbo].[PERMISO_PERMISO] ([ID_PADRE], [ID_HIJO]) VALUES (12, 33)
INSERT [dbo].[PERMISO_PERMISO] ([ID_PADRE], [ID_HIJO]) VALUES (13, 16)
INSERT [dbo].[PERMISO_PERMISO] ([ID_PADRE], [ID_HIJO]) VALUES (13, 17)
INSERT [dbo].[PERMISO_PERMISO] ([ID_PADRE], [ID_HIJO]) VALUES (13, 24)
INSERT [dbo].[PERMISO_PERMISO] ([ID_PADRE], [ID_HIJO]) VALUES (13, 27)
INSERT [dbo].[PERMISO_PERMISO] ([ID_PADRE], [ID_HIJO]) VALUES (13, 28)
INSERT [dbo].[PERMISO_PERMISO] ([ID_PADRE], [ID_HIJO]) VALUES (13, 31)
INSERT [dbo].[PERMISO_PERMISO] ([ID_PADRE], [ID_HIJO]) VALUES (14, 16)
INSERT [dbo].[PERMISO_PERMISO] ([ID_PADRE], [ID_HIJO]) VALUES (14, 18)
INSERT [dbo].[PERMISO_PERMISO] ([ID_PADRE], [ID_HIJO]) VALUES (14, 26)
INSERT [dbo].[PERMISO_PERMISO] ([ID_PADRE], [ID_HIJO]) VALUES (14, 28)
INSERT [dbo].[PERMISO_PERMISO] ([ID_PADRE], [ID_HIJO]) VALUES (15, 21)
INSERT [dbo].[PERMISO_PERMISO] ([ID_PADRE], [ID_HIJO]) VALUES (15, 29)
INSERT [dbo].[PERMISO_PERMISO] ([ID_PADRE], [ID_HIJO]) VALUES (15, 32)
GO
SET IDENTITY_INSERT [dbo].[PERSONAL] ON 

INSERT [dbo].[PERSONAL] ([Id_Personal], [DNI], [Nombre], [Apellido], [Categoria], [Telefono], [Direccion], [Email], [Estado]) VALUES (1, N'30000001', N'Juan', N'Pérez', N'Mozo', N'11111111', N'Calle 1', N'juan@test.com', N'Activo')
INSERT [dbo].[PERSONAL] ([Id_Personal], [DNI], [Nombre], [Apellido], [Categoria], [Telefono], [Direccion], [Email], [Estado]) VALUES (2, N'30000002', N'Carlos', N'Gómez', N'Mozo', N'11111112', N'Calle 2', N'carlos@test.com', N'Activo')
INSERT [dbo].[PERSONAL] ([Id_Personal], [DNI], [Nombre], [Apellido], [Categoria], [Telefono], [Direccion], [Email], [Estado]) VALUES (3, N'30000003', N'Luis', N'Rodríguez', N'Mozo', N'11111113', N'Calle 3', N'luis@test.com', N'Activo')
INSERT [dbo].[PERSONAL] ([Id_Personal], [DNI], [Nombre], [Apellido], [Categoria], [Telefono], [Direccion], [Email], [Estado]) VALUES (4, N'30000004', N'Diego', N'Fernández', N'Mozo', N'11111114', N'Calle 4', N'diego@test.com', N'Activo')
INSERT [dbo].[PERSONAL] ([Id_Personal], [DNI], [Nombre], [Apellido], [Categoria], [Telefono], [Direccion], [Email], [Estado]) VALUES (5, N'30000005', N'Mateo', N'López', N'Mozo', N'11111115', N'Calle 5', N'mateo@test.com', N'Activo')
INSERT [dbo].[PERSONAL] ([Id_Personal], [DNI], [Nombre], [Apellido], [Categoria], [Telefono], [Direccion], [Email], [Estado]) VALUES (6, N'30000006', N'Nicolás', N'Martínez', N'Mozo', N'11111116', N'Calle 6', N'nicolas@test.com', N'Activo')
INSERT [dbo].[PERSONAL] ([Id_Personal], [DNI], [Nombre], [Apellido], [Categoria], [Telefono], [Direccion], [Email], [Estado]) VALUES (7, N'30000007', N'Lucas', N'Sánchez', N'Mozo', N'11111117', N'Calle 7', N'lucas@test.com', N'Activo')
INSERT [dbo].[PERSONAL] ([Id_Personal], [DNI], [Nombre], [Apellido], [Categoria], [Telefono], [Direccion], [Email], [Estado]) VALUES (8, N'30000008', N'Javier', N'Romero', N'Mozo', N'11111118', N'Calle 8', N'javier@test.com', N'Activo')
INSERT [dbo].[PERSONAL] ([Id_Personal], [DNI], [Nombre], [Apellido], [Categoria], [Telefono], [Direccion], [Email], [Estado]) VALUES (9, N'30000009', N'Gonzalo', N'Díaz', N'Mozo', N'11111119', N'Calle 9', N'gonzalo@test.com', N'Activo')
INSERT [dbo].[PERSONAL] ([Id_Personal], [DNI], [Nombre], [Apellido], [Categoria], [Telefono], [Direccion], [Email], [Estado]) VALUES (10, N'30000010', N'Agustín', N'Álvarez', N'Mozo', N'11111120', N'Calle 10', N'agustin@test.com', N'Activo')
INSERT [dbo].[PERSONAL] ([Id_Personal], [DNI], [Nombre], [Apellido], [Categoria], [Telefono], [Direccion], [Email], [Estado]) VALUES (11, N'30000011', N'Martín', N'Torres', N'Cocinero', N'11111121', N'Calle 11', N'martin@test.com', N'Activo')
INSERT [dbo].[PERSONAL] ([Id_Personal], [DNI], [Nombre], [Apellido], [Categoria], [Telefono], [Direccion], [Email], [Estado]) VALUES (12, N'30000012', N'Esteban', N'Ruiz', N'Cocinero', N'11111122', N'Calle 12', N'esteban@test.com', N'Activo')
INSERT [dbo].[PERSONAL] ([Id_Personal], [DNI], [Nombre], [Apellido], [Categoria], [Telefono], [Direccion], [Email], [Estado]) VALUES (13, N'30000013', N'Pablo', N'Benítez', N'Cocinero', N'11111123', N'Calle 13', N'pablo@test.com', N'Activo')
INSERT [dbo].[PERSONAL] ([Id_Personal], [DNI], [Nombre], [Apellido], [Categoria], [Telefono], [Direccion], [Email], [Estado]) VALUES (14, N'30000014', N'Franco', N'Acosta', N'Cocinero', N'11111124', N'Calle 14', N'franco@test.com', N'Activo')
INSERT [dbo].[PERSONAL] ([Id_Personal], [DNI], [Nombre], [Apellido], [Categoria], [Telefono], [Direccion], [Email], [Estado]) VALUES (15, N'30000015', N'Hernán', N'Giménez', N'Seguridad', N'11111125', N'Calle 15', N'hernan@test.com', N'Activo')
INSERT [dbo].[PERSONAL] ([Id_Personal], [DNI], [Nombre], [Apellido], [Categoria], [Telefono], [Direccion], [Email], [Estado]) VALUES (16, N'30000016', N'Sebastián', N'Medina', N'Seguridad', N'11111126', N'Calle 16', N'sebastian@test.com', N'Activo')
INSERT [dbo].[PERSONAL] ([Id_Personal], [DNI], [Nombre], [Apellido], [Categoria], [Telefono], [Direccion], [Email], [Estado]) VALUES (17, N'30000017', N'Roberto', N'Mendoza', N'Maitre', N'11111127', N'Calle 17', N'roberto@test.com', N'Activo')
INSERT [dbo].[PERSONAL] ([Id_Personal], [DNI], [Nombre], [Apellido], [Categoria], [Telefono], [Direccion], [Email], [Estado]) VALUES (18, N'30000018', N'Rodrigo', N'Morales', N'Mozo', N'11111128', N'Calle 18', N'rodrigo@test.com', N'Activo')
INSERT [dbo].[PERSONAL] ([Id_Personal], [DNI], [Nombre], [Apellido], [Categoria], [Telefono], [Direccion], [Email], [Estado]) VALUES (19, N'30000019', N'Camila', N'Rios', N'Mozo', N'11111129', N'Calle 19', N'camila@test.com', N'Activo')
INSERT [dbo].[PERSONAL] ([Id_Personal], [DNI], [Nombre], [Apellido], [Categoria], [Telefono], [Direccion], [Email], [Estado]) VALUES (20, N'30000020', N'Valeria', N'Navarro', N'Cocinero', N'11111130', N'Calle 20', N'valeria@test.com', N'Activo')
INSERT [dbo].[PERSONAL] ([Id_Personal], [DNI], [Nombre], [Apellido], [Categoria], [Telefono], [Direccion], [Email], [Estado]) VALUES (21, N'30000021', N'Esteban', N'Paz', N'Maitre', N'11111131', N'Calle 21', N'esteban.paz@test.com', N'Activo')
INSERT [dbo].[PERSONAL] ([Id_Personal], [DNI], [Nombre], [Apellido], [Categoria], [Telefono], [Direccion], [Email], [Estado]) VALUES (22, N'235235235', N'Federico', N'Lorenzo', N'Seguridad', N'124124', N'calle falsa 123', N'lorenzo@gmail.com', N'Activo')
INSERT [dbo].[PERSONAL] ([Id_Personal], [DNI], [Nombre], [Apellido], [Categoria], [Telefono], [Direccion], [Email], [Estado]) VALUES (23, N'12342525', N'Lorena', N'perez', N'Mozo', N'12414', N'hola123', N'asdmasd@gmail.com', N'Activo')
SET IDENTITY_INSERT [dbo].[PERSONAL] OFF
GO
SET IDENTITY_INSERT [dbo].[PRESTADOR_SERVICIO] ON 

INSERT [dbo].[PRESTADOR_SERVICIO] ([Id_Prestador], [Rubro], [Nombre_Fantasia], [Estado], [Precio_Servicio]) VALUES (1, N'DJ / Sonido', N'DJ Maxi Eventos', N'Activo', CAST(250000.00 AS Decimal(18, 2)))
INSERT [dbo].[PRESTADOR_SERVICIO] ([Id_Prestador], [Rubro], [Nombre_Fantasia], [Estado], [Precio_Servicio]) VALUES (2, N'Fotografía y Video', N'Estudio Flash Producciones', N'Activo', CAST(180000.00 AS Decimal(18, 2)))
INSERT [dbo].[PRESTADOR_SERVICIO] ([Id_Prestador], [Rubro], [Nombre_Fantasia], [Estado], [Precio_Servicio]) VALUES (3, N'Show / Animación', N'Robot LED & Cotillón Premium', N'Activo', CAST(120000.00 AS Decimal(18, 2)))
INSERT [dbo].[PRESTADOR_SERVICIO] ([Id_Prestador], [Rubro], [Nombre_Fantasia], [Estado], [Precio_Servicio]) VALUES (4, N'Ambientación', N'DecoFest Iluminación', N'Activo', CAST(150000.00 AS Decimal(18, 2)))
INSERT [dbo].[PRESTADOR_SERVICIO] ([Id_Prestador], [Rubro], [Nombre_Fantasia], [Estado], [Precio_Servicio]) VALUES (5, N'Barra de Tragos', N'Cocktail Bar Móvil', N'Inactivo', CAST(200000.00 AS Decimal(18, 2)))
SET IDENTITY_INSERT [dbo].[PRESTADOR_SERVICIO] OFF
GO
SET IDENTITY_INSERT [dbo].[PRESUPUESTO] ON 

INSERT [dbo].[PRESUPUESTO] ([Id_Presupuesto], [Id_Cliente], [Id_Usuario], [Cantidad_Invitados_Estimada], [Tipo_Evento], [Subtotal], [Estado], [Fecha_Evento]) VALUES (3, 1, 1, 150, N'Casamiento', CAST(2250000.00 AS Decimal(18, 2)), N'Aprobado', CAST(N'2026-10-25T00:22:50.430' AS DateTime))
INSERT [dbo].[PRESUPUESTO] ([Id_Presupuesto], [Id_Cliente], [Id_Usuario], [Cantidad_Invitados_Estimada], [Tipo_Evento], [Subtotal], [Estado], [Fecha_Evento]) VALUES (4, 1, 1, 150, N'Casamiento', CAST(2250000.00 AS Decimal(18, 2)), N'Aprobado', CAST(N'2026-10-25T00:22:50.430' AS DateTime))
INSERT [dbo].[PRESUPUESTO] ([Id_Presupuesto], [Id_Cliente], [Id_Usuario], [Cantidad_Invitados_Estimada], [Tipo_Evento], [Subtotal], [Estado], [Fecha_Evento]) VALUES (5, 1, 1, 100, N'Evento Corporativo', CAST(2000000.00 AS Decimal(18, 2)), N'Aprobado', CAST(N'2026-10-25T00:22:50.430' AS DateTime))
INSERT [dbo].[PRESUPUESTO] ([Id_Presupuesto], [Id_Cliente], [Id_Usuario], [Cantidad_Invitados_Estimada], [Tipo_Evento], [Subtotal], [Estado], [Fecha_Evento]) VALUES (6, 1, 1, 100, N'Casamiento', CAST(1500000.00 AS Decimal(18, 2)), N'Aprobado', CAST(N'2026-10-31T00:00:00.000' AS DateTime))
INSERT [dbo].[PRESUPUESTO] ([Id_Presupuesto], [Id_Cliente], [Id_Usuario], [Cantidad_Invitados_Estimada], [Tipo_Evento], [Subtotal], [Estado], [Fecha_Evento]) VALUES (7, 1, 1, 10, N'Casamiento', CAST(150000.00 AS Decimal(18, 2)), N'Aprobado', CAST(N'2026-10-31T00:00:00.000' AS DateTime))
INSERT [dbo].[PRESUPUESTO] ([Id_Presupuesto], [Id_Cliente], [Id_Usuario], [Cantidad_Invitados_Estimada], [Tipo_Evento], [Subtotal], [Estado], [Fecha_Evento]) VALUES (8, 2, 1, 1, N'Evento Corporativo', CAST(20000.00 AS Decimal(18, 2)), N'Aprobado', CAST(N'2028-02-26T00:00:00.000' AS DateTime))
INSERT [dbo].[PRESUPUESTO] ([Id_Presupuesto], [Id_Cliente], [Id_Usuario], [Cantidad_Invitados_Estimada], [Tipo_Evento], [Subtotal], [Estado], [Fecha_Evento]) VALUES (9, 2, 1, 5, N'Casamiento', CAST(75000.00 AS Decimal(18, 2)), N'Aprobado', CAST(N'2027-01-16T00:00:00.000' AS DateTime))
INSERT [dbo].[PRESUPUESTO] ([Id_Presupuesto], [Id_Cliente], [Id_Usuario], [Cantidad_Invitados_Estimada], [Tipo_Evento], [Subtotal], [Estado], [Fecha_Evento]) VALUES (10, 2, 1, 100, N'Casamiento', CAST(1500000.00 AS Decimal(18, 2)), N'Aprobado', CAST(N'2026-11-07T00:00:00.000' AS DateTime))
INSERT [dbo].[PRESUPUESTO] ([Id_Presupuesto], [Id_Cliente], [Id_Usuario], [Cantidad_Invitados_Estimada], [Tipo_Evento], [Subtotal], [Estado], [Fecha_Evento]) VALUES (11, 3, 1, 166, N'Casamiento', CAST(2490000.00 AS Decimal(18, 2)), N'Aprobado', CAST(N'2026-12-09T00:00:00.000' AS DateTime))
INSERT [dbo].[PRESUPUESTO] ([Id_Presupuesto], [Id_Cliente], [Id_Usuario], [Cantidad_Invitados_Estimada], [Tipo_Evento], [Subtotal], [Estado], [Fecha_Evento]) VALUES (12, 3, 1, 30, N'Casamiento', CAST(450000.00 AS Decimal(18, 2)), N'Aprobado', CAST(N'2026-11-01T00:00:00.000' AS DateTime))
INSERT [dbo].[PRESUPUESTO] ([Id_Presupuesto], [Id_Cliente], [Id_Usuario], [Cantidad_Invitados_Estimada], [Tipo_Evento], [Subtotal], [Estado], [Fecha_Evento]) VALUES (13, 4, 1, 100, N'Evento Corporativo', CAST(2000000.00 AS Decimal(18, 2)), N'Aprobado', CAST(N'2026-11-28T00:00:00.000' AS DateTime))
INSERT [dbo].[PRESUPUESTO] ([Id_Presupuesto], [Id_Cliente], [Id_Usuario], [Cantidad_Invitados_Estimada], [Tipo_Evento], [Subtotal], [Estado], [Fecha_Evento]) VALUES (14, 5, 1, 80, N'Cumpleaños 15', CAST(1200000.00 AS Decimal(18, 2)), N'Aprobado', CAST(N'2026-12-15T00:00:00.000' AS DateTime))
INSERT [dbo].[PRESUPUESTO] ([Id_Presupuesto], [Id_Cliente], [Id_Usuario], [Cantidad_Invitados_Estimada], [Tipo_Evento], [Subtotal], [Estado], [Fecha_Evento]) VALUES (15, 5, 1, 120, N'Casamiento', CAST(1800000.00 AS Decimal(18, 2)), N'Aprobado', CAST(N'2026-12-20T00:00:00.000' AS DateTime))
INSERT [dbo].[PRESUPUESTO] ([Id_Presupuesto], [Id_Cliente], [Id_Usuario], [Cantidad_Invitados_Estimada], [Tipo_Evento], [Subtotal], [Estado], [Fecha_Evento]) VALUES (16, 7, 1, 200, N'Evento Corporativo', CAST(4000000.00 AS Decimal(18, 2)), N'Aprobado', CAST(N'2026-11-20T00:00:00.000' AS DateTime))
INSERT [dbo].[PRESUPUESTO] ([Id_Presupuesto], [Id_Cliente], [Id_Usuario], [Cantidad_Invitados_Estimada], [Tipo_Evento], [Subtotal], [Estado], [Fecha_Evento]) VALUES (17, 6, 1, 50, N'Casamiento', CAST(750000.00 AS Decimal(18, 2)), N'Aprobado', CAST(N'2026-10-10T00:00:00.000' AS DateTime))
INSERT [dbo].[PRESUPUESTO] ([Id_Presupuesto], [Id_Cliente], [Id_Usuario], [Cantidad_Invitados_Estimada], [Tipo_Evento], [Subtotal], [Estado], [Fecha_Evento]) VALUES (18, 8, 1, 150, N'Casamiento', CAST(1500000.00 AS Decimal(18, 2)), N'Aprobado', CAST(N'2025-03-15T00:00:00.000' AS DateTime))
INSERT [dbo].[PRESUPUESTO] ([Id_Presupuesto], [Id_Cliente], [Id_Usuario], [Cantidad_Invitados_Estimada], [Tipo_Evento], [Subtotal], [Estado], [Fecha_Evento]) VALUES (19, 9, 1, 90, N'Cumpleaños 15', CAST(950000.00 AS Decimal(18, 2)), N'Aprobado', CAST(N'2025-05-20T00:00:00.000' AS DateTime))
INSERT [dbo].[PRESUPUESTO] ([Id_Presupuesto], [Id_Cliente], [Id_Usuario], [Cantidad_Invitados_Estimada], [Tipo_Evento], [Subtotal], [Estado], [Fecha_Evento]) VALUES (20, 10, 1, 250, N'Evento Corporativo', CAST(3200000.00 AS Decimal(18, 2)), N'Aprobado', CAST(N'2025-08-12T00:00:00.000' AS DateTime))
INSERT [dbo].[PRESUPUESTO] ([Id_Presupuesto], [Id_Cliente], [Id_Usuario], [Cantidad_Invitados_Estimada], [Tipo_Evento], [Subtotal], [Estado], [Fecha_Evento]) VALUES (21, 11, 1, 110, N'Aniversario', CAST(1100000.00 AS Decimal(18, 2)), N'Aprobado', CAST(N'2025-11-05T00:00:00.000' AS DateTime))
INSERT [dbo].[PRESUPUESTO] ([Id_Presupuesto], [Id_Cliente], [Id_Usuario], [Cantidad_Invitados_Estimada], [Tipo_Evento], [Subtotal], [Estado], [Fecha_Evento]) VALUES (22, 12, 1, 70, N'Casamiento', CAST(800000.00 AS Decimal(18, 2)), N'Aprobado', CAST(N'2026-01-18T00:00:00.000' AS DateTime))
INSERT [dbo].[PRESUPUESTO] ([Id_Presupuesto], [Id_Cliente], [Id_Usuario], [Cantidad_Invitados_Estimada], [Tipo_Evento], [Subtotal], [Estado], [Fecha_Evento]) VALUES (23, 8, 1, 130, N'Fiesta Empresarial', CAST(1600000.00 AS Decimal(18, 2)), N'Aprobado', CAST(N'2026-04-10T00:00:00.000' AS DateTime))
INSERT [dbo].[PRESUPUESTO] ([Id_Presupuesto], [Id_Cliente], [Id_Usuario], [Cantidad_Invitados_Estimada], [Tipo_Evento], [Subtotal], [Estado], [Fecha_Evento]) VALUES (24, 13, 1, 100, N'Cumpleaños 50', CAST(1100000.00 AS Decimal(18, 2)), N'Aprobado', CAST(N'2024-04-12T00:00:00.000' AS DateTime))
INSERT [dbo].[PRESUPUESTO] ([Id_Presupuesto], [Id_Cliente], [Id_Usuario], [Cantidad_Invitados_Estimada], [Tipo_Evento], [Subtotal], [Estado], [Fecha_Evento]) VALUES (25, 14, 1, 180, N'Casamiento', CAST(2200000.00 AS Decimal(18, 2)), N'Aprobado', CAST(N'2024-06-22T00:00:00.000' AS DateTime))
INSERT [dbo].[PRESUPUESTO] ([Id_Presupuesto], [Id_Cliente], [Id_Usuario], [Cantidad_Invitados_Estimada], [Tipo_Evento], [Subtotal], [Estado], [Fecha_Evento]) VALUES (26, 15, 1, 300, N'Evento Corporativo', CAST(4500000.00 AS Decimal(18, 2)), N'Aprobado', CAST(N'2024-09-15T00:00:00.000' AS DateTime))
INSERT [dbo].[PRESUPUESTO] ([Id_Presupuesto], [Id_Cliente], [Id_Usuario], [Cantidad_Invitados_Estimada], [Tipo_Evento], [Subtotal], [Estado], [Fecha_Evento]) VALUES (27, 16, 1, 60, N'Aniversario', CAST(750000.00 AS Decimal(18, 2)), N'Aprobado', CAST(N'2024-11-30T00:00:00.000' AS DateTime))
INSERT [dbo].[PRESUPUESTO] ([Id_Presupuesto], [Id_Cliente], [Id_Usuario], [Cantidad_Invitados_Estimada], [Tipo_Evento], [Subtotal], [Estado], [Fecha_Evento]) VALUES (28, 17, 1, 200, N'Fiesta Fin de Año', CAST(3800000.00 AS Decimal(18, 2)), N'Aprobado', CAST(N'2024-12-18T00:00:00.000' AS DateTime))
INSERT [dbo].[PRESUPUESTO] ([Id_Presupuesto], [Id_Cliente], [Id_Usuario], [Cantidad_Invitados_Estimada], [Tipo_Evento], [Subtotal], [Estado], [Fecha_Evento]) VALUES (29, 18, 1, 120, N'Cumpleaños 15', CAST(1400000.00 AS Decimal(18, 2)), N'Aprobado', CAST(N'2025-02-14T00:00:00.000' AS DateTime))
INSERT [dbo].[PRESUPUESTO] ([Id_Presupuesto], [Id_Cliente], [Id_Usuario], [Cantidad_Invitados_Estimada], [Tipo_Evento], [Subtotal], [Estado], [Fecha_Evento]) VALUES (30, 19, 1, 140, N'Casamiento', CAST(1800000.00 AS Decimal(18, 2)), N'Aprobado', CAST(N'2025-04-05T00:00:00.000' AS DateTime))
INSERT [dbo].[PRESUPUESTO] ([Id_Presupuesto], [Id_Cliente], [Id_Usuario], [Cantidad_Invitados_Estimada], [Tipo_Evento], [Subtotal], [Estado], [Fecha_Evento]) VALUES (31, 20, 1, 160, N'Congreso', CAST(2900000.00 AS Decimal(18, 2)), N'Aprobado', CAST(N'2025-07-20T00:00:00.000' AS DateTime))
INSERT [dbo].[PRESUPUESTO] ([Id_Presupuesto], [Id_Cliente], [Id_Usuario], [Cantidad_Invitados_Estimada], [Tipo_Evento], [Subtotal], [Estado], [Fecha_Evento]) VALUES (32, 21, 1, 85, N'Bautismo', CAST(920000.00 AS Decimal(18, 2)), N'Aprobado', CAST(N'2025-10-12T00:00:00.000' AS DateTime))
INSERT [dbo].[PRESUPUESTO] ([Id_Presupuesto], [Id_Cliente], [Id_Usuario], [Cantidad_Invitados_Estimada], [Tipo_Evento], [Subtotal], [Estado], [Fecha_Evento]) VALUES (33, 22, 1, 220, N'Gala Benéfica', CAST(4100000.00 AS Decimal(18, 2)), N'Aprobado', CAST(N'2026-02-28T00:00:00.000' AS DateTime))
INSERT [dbo].[PRESUPUESTO] ([Id_Presupuesto], [Id_Cliente], [Id_Usuario], [Cantidad_Invitados_Estimada], [Tipo_Evento], [Subtotal], [Estado], [Fecha_Evento]) VALUES (34, 23, 1, 120, N'Casamiento', CAST(1800000.00 AS Decimal(18, 2)), N'Aprobado', CAST(N'2024-05-10T00:00:00.000' AS DateTime))
INSERT [dbo].[PRESUPUESTO] ([Id_Presupuesto], [Id_Cliente], [Id_Usuario], [Cantidad_Invitados_Estimada], [Tipo_Evento], [Subtotal], [Estado], [Fecha_Evento]) VALUES (35, 24, 1, 95, N'Cumpleaños 50', CAST(1150000.00 AS Decimal(18, 2)), N'Aprobado', CAST(N'2024-07-18T00:00:00.000' AS DateTime))
INSERT [dbo].[PRESUPUESTO] ([Id_Presupuesto], [Id_Cliente], [Id_Usuario], [Cantidad_Invitados_Estimada], [Tipo_Evento], [Subtotal], [Estado], [Fecha_Evento]) VALUES (36, 25, 1, 280, N'Evento Corporativo', CAST(4200000.00 AS Decimal(18, 2)), N'Aprobado', CAST(N'2024-10-05T00:00:00.000' AS DateTime))
INSERT [dbo].[PRESUPUESTO] ([Id_Presupuesto], [Id_Cliente], [Id_Usuario], [Cantidad_Invitados_Estimada], [Tipo_Evento], [Subtotal], [Estado], [Fecha_Evento]) VALUES (37, 26, 1, 150, N'Aniversario', CAST(1900000.00 AS Decimal(18, 2)), N'Aprobado', CAST(N'2024-12-01T00:00:00.000' AS DateTime))
INSERT [dbo].[PRESUPUESTO] ([Id_Presupuesto], [Id_Cliente], [Id_Usuario], [Cantidad_Invitados_Estimada], [Tipo_Evento], [Subtotal], [Estado], [Fecha_Evento]) VALUES (38, 27, 1, 180, N'Gala Benéfica', CAST(3100000.00 AS Decimal(18, 2)), N'Aprobado', CAST(N'2025-01-20T00:00:00.000' AS DateTime))
INSERT [dbo].[PRESUPUESTO] ([Id_Presupuesto], [Id_Cliente], [Id_Usuario], [Cantidad_Invitados_Estimada], [Tipo_Evento], [Subtotal], [Estado], [Fecha_Evento]) VALUES (39, 28, 1, 110, N'Cumpleaños 15', CAST(1350000.00 AS Decimal(18, 2)), N'Aprobado', CAST(N'2025-03-22T00:00:00.000' AS DateTime))
INSERT [dbo].[PRESUPUESTO] ([Id_Presupuesto], [Id_Cliente], [Id_Usuario], [Cantidad_Invitados_Estimada], [Tipo_Evento], [Subtotal], [Estado], [Fecha_Evento]) VALUES (40, 29, 1, 160, N'Casamiento', CAST(2100000.00 AS Decimal(18, 2)), N'Aprobado', CAST(N'2025-06-14T00:00:00.000' AS DateTime))
INSERT [dbo].[PRESUPUESTO] ([Id_Presupuesto], [Id_Cliente], [Id_Usuario], [Cantidad_Invitados_Estimada], [Tipo_Evento], [Subtotal], [Estado], [Fecha_Evento]) VALUES (41, 30, 1, 240, N'Congreso', CAST(3900000.00 AS Decimal(18, 2)), N'Aprobado', CAST(N'2025-09-08T00:00:00.000' AS DateTime))
INSERT [dbo].[PRESUPUESTO] ([Id_Presupuesto], [Id_Cliente], [Id_Usuario], [Cantidad_Invitados_Estimada], [Tipo_Evento], [Subtotal], [Estado], [Fecha_Evento]) VALUES (42, 31, 1, 75, N'Bautismo', CAST(850000.00 AS Decimal(18, 2)), N'Aprobado', CAST(N'2025-11-15T00:00:00.000' AS DateTime))
INSERT [dbo].[PRESUPUESTO] ([Id_Presupuesto], [Id_Cliente], [Id_Usuario], [Cantidad_Invitados_Estimada], [Tipo_Evento], [Subtotal], [Estado], [Fecha_Evento]) VALUES (43, 32, 1, 200, N'Fiesta Empresarial', CAST(3600000.00 AS Decimal(18, 2)), N'Aprobado', CAST(N'2026-03-10T00:00:00.000' AS DateTime))
INSERT [dbo].[PRESUPUESTO] ([Id_Presupuesto], [Id_Cliente], [Id_Usuario], [Cantidad_Invitados_Estimada], [Tipo_Evento], [Subtotal], [Estado], [Fecha_Evento]) VALUES (44, 33, 1, 130, N'Casamiento', CAST(1950000.00 AS Decimal(18, 2)), N'Aprobado', CAST(N'2024-08-10T00:00:00.000' AS DateTime))
INSERT [dbo].[PRESUPUESTO] ([Id_Presupuesto], [Id_Cliente], [Id_Usuario], [Cantidad_Invitados_Estimada], [Tipo_Evento], [Subtotal], [Estado], [Fecha_Evento]) VALUES (45, 34, 1, 80, N'Cumpleaños 60', CAST(980000.00 AS Decimal(18, 2)), N'Aprobado', CAST(N'2024-11-12T00:00:00.000' AS DateTime))
INSERT [dbo].[PRESUPUESTO] ([Id_Presupuesto], [Id_Cliente], [Id_Usuario], [Cantidad_Invitados_Estimada], [Tipo_Evento], [Subtotal], [Estado], [Fecha_Evento]) VALUES (46, 35, 1, 210, N'Evento Corporativo', CAST(3400000.00 AS Decimal(18, 2)), N'Aprobado', CAST(N'2025-04-18T00:00:00.000' AS DateTime))
INSERT [dbo].[PRESUPUESTO] ([Id_Presupuesto], [Id_Cliente], [Id_Usuario], [Cantidad_Invitados_Estimada], [Tipo_Evento], [Subtotal], [Estado], [Fecha_Evento]) VALUES (47, 36, 1, 100, N'Aniversario', CAST(1250000.00 AS Decimal(18, 2)), N'Aprobado', CAST(N'2025-08-22T00:00:00.000' AS DateTime))
INSERT [dbo].[PRESUPUESTO] ([Id_Presupuesto], [Id_Cliente], [Id_Usuario], [Cantidad_Invitados_Estimada], [Tipo_Evento], [Subtotal], [Estado], [Fecha_Evento]) VALUES (48, 37, 1, 260, N'Fiesta Empresarial', CAST(4800000.00 AS Decimal(18, 2)), N'Aprobado', CAST(N'2026-01-15T00:00:00.000' AS DateTime))
INSERT [dbo].[PRESUPUESTO] ([Id_Presupuesto], [Id_Cliente], [Id_Usuario], [Cantidad_Invitados_Estimada], [Tipo_Evento], [Subtotal], [Estado], [Fecha_Evento]) VALUES (49, 38, 1, 100, N'Casamiento', CAST(1500000.00 AS Decimal(18, 2)), N'Aprobado', CAST(N'2026-11-08T00:00:00.000' AS DateTime))
INSERT [dbo].[PRESUPUESTO] ([Id_Presupuesto], [Id_Cliente], [Id_Usuario], [Cantidad_Invitados_Estimada], [Tipo_Evento], [Subtotal], [Estado], [Fecha_Evento]) VALUES (50, 38, 1, 100, N'Casamiento', CAST(1500000.00 AS Decimal(18, 2)), N'Aprobado', CAST(N'2026-11-14T00:00:00.000' AS DateTime))
INSERT [dbo].[PRESUPUESTO] ([Id_Presupuesto], [Id_Cliente], [Id_Usuario], [Cantidad_Invitados_Estimada], [Tipo_Evento], [Subtotal], [Estado], [Fecha_Evento]) VALUES (51, 26, 1, 100, N'Casamiento', CAST(1500000.00 AS Decimal(18, 2)), N'Aprobado', CAST(N'2026-11-02T00:00:00.000' AS DateTime))
INSERT [dbo].[PRESUPUESTO] ([Id_Presupuesto], [Id_Cliente], [Id_Usuario], [Cantidad_Invitados_Estimada], [Tipo_Evento], [Subtotal], [Estado], [Fecha_Evento]) VALUES (52, 4, 1, 50, N'Casamiento', CAST(750000.00 AS Decimal(18, 2)), N'Aprobado', CAST(N'2026-11-03T00:00:00.000' AS DateTime))
INSERT [dbo].[PRESUPUESTO] ([Id_Presupuesto], [Id_Cliente], [Id_Usuario], [Cantidad_Invitados_Estimada], [Tipo_Evento], [Subtotal], [Estado], [Fecha_Evento]) VALUES (53, 1, 1, 100, N'Casamiento', CAST(1500000.00 AS Decimal(18, 2)), N'Aprobado', CAST(N'2026-11-02T00:00:00.000' AS DateTime))
INSERT [dbo].[PRESUPUESTO] ([Id_Presupuesto], [Id_Cliente], [Id_Usuario], [Cantidad_Invitados_Estimada], [Tipo_Evento], [Subtotal], [Estado], [Fecha_Evento]) VALUES (54, 43, 1, 80, N'Aniversario', CAST(1800000.00 AS Decimal(18, 2)), N'Aprobado', CAST(N'2026-06-15T00:00:00.000' AS DateTime))
INSERT [dbo].[PRESUPUESTO] ([Id_Presupuesto], [Id_Cliente], [Id_Usuario], [Cantidad_Invitados_Estimada], [Tipo_Evento], [Subtotal], [Estado], [Fecha_Evento]) VALUES (55, 44, 1, 140, N'Casamiento', CAST(2400000.00 AS Decimal(18, 2)), N'Aprobado', CAST(N'2026-07-10T00:00:00.000' AS DateTime))
INSERT [dbo].[PRESUPUESTO] ([Id_Presupuesto], [Id_Cliente], [Id_Usuario], [Cantidad_Invitados_Estimada], [Tipo_Evento], [Subtotal], [Estado], [Fecha_Evento]) VALUES (56, 45, 1, 95, N'Cumpleaños 15', CAST(1300000.00 AS Decimal(18, 2)), N'Aprobado', CAST(N'2026-08-20T00:00:00.000' AS DateTime))
INSERT [dbo].[PRESUPUESTO] ([Id_Presupuesto], [Id_Cliente], [Id_Usuario], [Cantidad_Invitados_Estimada], [Tipo_Evento], [Subtotal], [Estado], [Fecha_Evento]) VALUES (57, 46, 1, 250, N'Evento Corporativo', CAST(4200000.00 AS Decimal(18, 2)), N'Aprobado', CAST(N'2026-09-12T00:00:00.000' AS DateTime))
INSERT [dbo].[PRESUPUESTO] ([Id_Presupuesto], [Id_Cliente], [Id_Usuario], [Cantidad_Invitados_Estimada], [Tipo_Evento], [Subtotal], [Estado], [Fecha_Evento]) VALUES (58, 47, 1, 110, N'Aniversario', CAST(1600000.00 AS Decimal(18, 2)), N'Aprobado', CAST(N'2026-10-05T00:00:00.000' AS DateTime))
INSERT [dbo].[PRESUPUESTO] ([Id_Presupuesto], [Id_Cliente], [Id_Usuario], [Cantidad_Invitados_Estimada], [Tipo_Evento], [Subtotal], [Estado], [Fecha_Evento]) VALUES (59, 48, 1, 200, N'Fiesta Empresarial', CAST(3800000.00 AS Decimal(18, 2)), N'Aprobado', CAST(N'2026-10-25T00:00:00.000' AS DateTime))
INSERT [dbo].[PRESUPUESTO] ([Id_Presupuesto], [Id_Cliente], [Id_Usuario], [Cantidad_Invitados_Estimada], [Tipo_Evento], [Subtotal], [Estado], [Fecha_Evento]) VALUES (60, 49, 1, 120, N'Casamiento', CAST(2100000.00 AS Decimal(18, 2)), N'Aprobado', CAST(N'2026-11-10T00:00:00.000' AS DateTime))
INSERT [dbo].[PRESUPUESTO] ([Id_Presupuesto], [Id_Cliente], [Id_Usuario], [Cantidad_Invitados_Estimada], [Tipo_Evento], [Subtotal], [Estado], [Fecha_Evento]) VALUES (61, 50, 1, 80, N'Cumpleaños', CAST(1100000.00 AS Decimal(18, 2)), N'Aprobado', CAST(N'2026-11-20T00:00:00.000' AS DateTime))
INSERT [dbo].[PRESUPUESTO] ([Id_Presupuesto], [Id_Cliente], [Id_Usuario], [Cantidad_Invitados_Estimada], [Tipo_Evento], [Subtotal], [Estado], [Fecha_Evento]) VALUES (62, 51, 1, 300, N'Evento Corporativo', CAST(5200000.00 AS Decimal(18, 2)), N'Aprobado', CAST(N'2026-12-05T00:00:00.000' AS DateTime))
INSERT [dbo].[PRESUPUESTO] ([Id_Presupuesto], [Id_Cliente], [Id_Usuario], [Cantidad_Invitados_Estimada], [Tipo_Evento], [Subtotal], [Estado], [Fecha_Evento]) VALUES (1060, 51, 1, 100, N'Evento Corporativo', CAST(2000000.00 AS Decimal(18, 2)), N'Aprobado', CAST(N'2027-01-01T00:00:00.000' AS DateTime))
INSERT [dbo].[PRESUPUESTO] ([Id_Presupuesto], [Id_Cliente], [Id_Usuario], [Cantidad_Invitados_Estimada], [Tipo_Evento], [Subtotal], [Estado], [Fecha_Evento]) VALUES (1061, 36, 1, 50, N'Cumpleaños 15', CAST(600000.00 AS Decimal(18, 2)), N'Aprobado', CAST(N'2026-11-29T00:00:00.000' AS DateTime))
INSERT [dbo].[PRESUPUESTO] ([Id_Presupuesto], [Id_Cliente], [Id_Usuario], [Cantidad_Invitados_Estimada], [Tipo_Evento], [Subtotal], [Estado], [Fecha_Evento]) VALUES (1062, 52, 1, 105, N'Cumpleaños 15', CAST(1575000.00 AS Decimal(18, 2)), N'Aprobado', CAST(N'2026-10-27T00:00:00.000' AS DateTime))
INSERT [dbo].[PRESUPUESTO] ([Id_Presupuesto], [Id_Cliente], [Id_Usuario], [Cantidad_Invitados_Estimada], [Tipo_Evento], [Subtotal], [Estado], [Fecha_Evento]) VALUES (1063, 53, 1, 130, N'Evento Corporativo', CAST(1950000.00 AS Decimal(18, 2)), N'Aprobado', CAST(N'2026-10-24T00:00:00.000' AS DateTime))
INSERT [dbo].[PRESUPUESTO] ([Id_Presupuesto], [Id_Cliente], [Id_Usuario], [Cantidad_Invitados_Estimada], [Tipo_Evento], [Subtotal], [Estado], [Fecha_Evento]) VALUES (1064, 54, 1, 155, N'Casamiento', CAST(2325000.00 AS Decimal(18, 2)), N'Aprobado', CAST(N'2026-10-21T00:00:00.000' AS DateTime))
INSERT [dbo].[PRESUPUESTO] ([Id_Presupuesto], [Id_Cliente], [Id_Usuario], [Cantidad_Invitados_Estimada], [Tipo_Evento], [Subtotal], [Estado], [Fecha_Evento]) VALUES (1065, 55, 1, 180, N'Cumpleaños 15', CAST(2700000.00 AS Decimal(18, 2)), N'Aprobado', CAST(N'2026-10-18T00:00:00.000' AS DateTime))
INSERT [dbo].[PRESUPUESTO] ([Id_Presupuesto], [Id_Cliente], [Id_Usuario], [Cantidad_Invitados_Estimada], [Tipo_Evento], [Subtotal], [Estado], [Fecha_Evento]) VALUES (1066, 56, 1, 80, N'Evento Corporativo', CAST(1200000.00 AS Decimal(18, 2)), N'Aprobado', CAST(N'2026-10-15T00:00:00.000' AS DateTime))
INSERT [dbo].[PRESUPUESTO] ([Id_Presupuesto], [Id_Cliente], [Id_Usuario], [Cantidad_Invitados_Estimada], [Tipo_Evento], [Subtotal], [Estado], [Fecha_Evento]) VALUES (1067, 57, 1, 105, N'Casamiento', CAST(1575000.00 AS Decimal(18, 2)), N'Aprobado', CAST(N'2026-10-12T00:00:00.000' AS DateTime))
INSERT [dbo].[PRESUPUESTO] ([Id_Presupuesto], [Id_Cliente], [Id_Usuario], [Cantidad_Invitados_Estimada], [Tipo_Evento], [Subtotal], [Estado], [Fecha_Evento]) VALUES (1068, 58, 1, 130, N'Cumpleaños 15', CAST(1950000.00 AS Decimal(18, 2)), N'Aprobado', CAST(N'2026-10-09T00:00:00.000' AS DateTime))
INSERT [dbo].[PRESUPUESTO] ([Id_Presupuesto], [Id_Cliente], [Id_Usuario], [Cantidad_Invitados_Estimada], [Tipo_Evento], [Subtotal], [Estado], [Fecha_Evento]) VALUES (1069, 59, 1, 155, N'Evento Corporativo', CAST(2325000.00 AS Decimal(18, 2)), N'Aprobado', CAST(N'2026-10-06T00:00:00.000' AS DateTime))
INSERT [dbo].[PRESUPUESTO] ([Id_Presupuesto], [Id_Cliente], [Id_Usuario], [Cantidad_Invitados_Estimada], [Tipo_Evento], [Subtotal], [Estado], [Fecha_Evento]) VALUES (1070, 60, 1, 180, N'Casamiento', CAST(2700000.00 AS Decimal(18, 2)), N'Aprobado', CAST(N'2026-10-03T00:00:00.000' AS DateTime))
INSERT [dbo].[PRESUPUESTO] ([Id_Presupuesto], [Id_Cliente], [Id_Usuario], [Cantidad_Invitados_Estimada], [Tipo_Evento], [Subtotal], [Estado], [Fecha_Evento]) VALUES (1071, 61, 1, 80, N'Cumpleaños 15', CAST(1200000.00 AS Decimal(18, 2)), N'Aprobado', CAST(N'2026-09-30T00:00:00.000' AS DateTime))
INSERT [dbo].[PRESUPUESTO] ([Id_Presupuesto], [Id_Cliente], [Id_Usuario], [Cantidad_Invitados_Estimada], [Tipo_Evento], [Subtotal], [Estado], [Fecha_Evento]) VALUES (1072, 62, 1, 105, N'Evento Corporativo', CAST(1575000.00 AS Decimal(18, 2)), N'Aprobado', CAST(N'2026-09-27T00:00:00.000' AS DateTime))
INSERT [dbo].[PRESUPUESTO] ([Id_Presupuesto], [Id_Cliente], [Id_Usuario], [Cantidad_Invitados_Estimada], [Tipo_Evento], [Subtotal], [Estado], [Fecha_Evento]) VALUES (1073, 63, 1, 130, N'Casamiento', CAST(1950000.00 AS Decimal(18, 2)), N'Aprobado', CAST(N'2026-09-24T00:00:00.000' AS DateTime))
INSERT [dbo].[PRESUPUESTO] ([Id_Presupuesto], [Id_Cliente], [Id_Usuario], [Cantidad_Invitados_Estimada], [Tipo_Evento], [Subtotal], [Estado], [Fecha_Evento]) VALUES (1074, 64, 1, 155, N'Cumpleaños 15', CAST(2325000.00 AS Decimal(18, 2)), N'Aprobado', CAST(N'2026-09-21T00:00:00.000' AS DateTime))
INSERT [dbo].[PRESUPUESTO] ([Id_Presupuesto], [Id_Cliente], [Id_Usuario], [Cantidad_Invitados_Estimada], [Tipo_Evento], [Subtotal], [Estado], [Fecha_Evento]) VALUES (1075, 65, 1, 180, N'Evento Corporativo', CAST(2700000.00 AS Decimal(18, 2)), N'Aprobado', CAST(N'2026-09-18T00:00:00.000' AS DateTime))
INSERT [dbo].[PRESUPUESTO] ([Id_Presupuesto], [Id_Cliente], [Id_Usuario], [Cantidad_Invitados_Estimada], [Tipo_Evento], [Subtotal], [Estado], [Fecha_Evento]) VALUES (1076, 66, 1, 80, N'Casamiento', CAST(1200000.00 AS Decimal(18, 2)), N'Aprobado', CAST(N'2026-09-15T00:00:00.000' AS DateTime))
INSERT [dbo].[PRESUPUESTO] ([Id_Presupuesto], [Id_Cliente], [Id_Usuario], [Cantidad_Invitados_Estimada], [Tipo_Evento], [Subtotal], [Estado], [Fecha_Evento]) VALUES (1077, 67, 1, 105, N'Cumpleaños 15', CAST(1575000.00 AS Decimal(18, 2)), N'Aprobado', CAST(N'2026-09-12T00:00:00.000' AS DateTime))
INSERT [dbo].[PRESUPUESTO] ([Id_Presupuesto], [Id_Cliente], [Id_Usuario], [Cantidad_Invitados_Estimada], [Tipo_Evento], [Subtotal], [Estado], [Fecha_Evento]) VALUES (1078, 68, 1, 130, N'Evento Corporativo', CAST(1950000.00 AS Decimal(18, 2)), N'Aprobado', CAST(N'2026-09-09T00:00:00.000' AS DateTime))
INSERT [dbo].[PRESUPUESTO] ([Id_Presupuesto], [Id_Cliente], [Id_Usuario], [Cantidad_Invitados_Estimada], [Tipo_Evento], [Subtotal], [Estado], [Fecha_Evento]) VALUES (1079, 69, 1, 155, N'Casamiento', CAST(2325000.00 AS Decimal(18, 2)), N'Aprobado', CAST(N'2026-09-06T00:00:00.000' AS DateTime))
INSERT [dbo].[PRESUPUESTO] ([Id_Presupuesto], [Id_Cliente], [Id_Usuario], [Cantidad_Invitados_Estimada], [Tipo_Evento], [Subtotal], [Estado], [Fecha_Evento]) VALUES (1080, 70, 1, 180, N'Cumpleaños 15', CAST(2700000.00 AS Decimal(18, 2)), N'Aprobado', CAST(N'2026-09-03T00:00:00.000' AS DateTime))
INSERT [dbo].[PRESUPUESTO] ([Id_Presupuesto], [Id_Cliente], [Id_Usuario], [Cantidad_Invitados_Estimada], [Tipo_Evento], [Subtotal], [Estado], [Fecha_Evento]) VALUES (1081, 71, 1, 80, N'Evento Corporativo', CAST(1200000.00 AS Decimal(18, 2)), N'Aprobado', CAST(N'2026-08-31T00:00:00.000' AS DateTime))
INSERT [dbo].[PRESUPUESTO] ([Id_Presupuesto], [Id_Cliente], [Id_Usuario], [Cantidad_Invitados_Estimada], [Tipo_Evento], [Subtotal], [Estado], [Fecha_Evento]) VALUES (1082, 72, 1, 105, N'Casamiento', CAST(1575000.00 AS Decimal(18, 2)), N'Aprobado', CAST(N'2026-08-28T00:00:00.000' AS DateTime))
INSERT [dbo].[PRESUPUESTO] ([Id_Presupuesto], [Id_Cliente], [Id_Usuario], [Cantidad_Invitados_Estimada], [Tipo_Evento], [Subtotal], [Estado], [Fecha_Evento]) VALUES (1083, 73, 1, 130, N'Cumpleaños 15', CAST(1950000.00 AS Decimal(18, 2)), N'Aprobado', CAST(N'2026-08-25T00:00:00.000' AS DateTime))
INSERT [dbo].[PRESUPUESTO] ([Id_Presupuesto], [Id_Cliente], [Id_Usuario], [Cantidad_Invitados_Estimada], [Tipo_Evento], [Subtotal], [Estado], [Fecha_Evento]) VALUES (1084, 74, 1, 155, N'Evento Corporativo', CAST(2325000.00 AS Decimal(18, 2)), N'Aprobado', CAST(N'2026-08-22T00:00:00.000' AS DateTime))
INSERT [dbo].[PRESUPUESTO] ([Id_Presupuesto], [Id_Cliente], [Id_Usuario], [Cantidad_Invitados_Estimada], [Tipo_Evento], [Subtotal], [Estado], [Fecha_Evento]) VALUES (1085, 75, 1, 180, N'Casamiento', CAST(2700000.00 AS Decimal(18, 2)), N'Aprobado', CAST(N'2026-08-19T00:00:00.000' AS DateTime))
INSERT [dbo].[PRESUPUESTO] ([Id_Presupuesto], [Id_Cliente], [Id_Usuario], [Cantidad_Invitados_Estimada], [Tipo_Evento], [Subtotal], [Estado], [Fecha_Evento]) VALUES (1086, 76, 1, 80, N'Cumpleaños 15', CAST(1200000.00 AS Decimal(18, 2)), N'Aprobado', CAST(N'2026-08-16T00:00:00.000' AS DateTime))
INSERT [dbo].[PRESUPUESTO] ([Id_Presupuesto], [Id_Cliente], [Id_Usuario], [Cantidad_Invitados_Estimada], [Tipo_Evento], [Subtotal], [Estado], [Fecha_Evento]) VALUES (1087, 77, 1, 105, N'Evento Corporativo', CAST(1575000.00 AS Decimal(18, 2)), N'Aprobado', CAST(N'2026-08-13T00:00:00.000' AS DateTime))
INSERT [dbo].[PRESUPUESTO] ([Id_Presupuesto], [Id_Cliente], [Id_Usuario], [Cantidad_Invitados_Estimada], [Tipo_Evento], [Subtotal], [Estado], [Fecha_Evento]) VALUES (1088, 78, 1, 130, N'Casamiento', CAST(1950000.00 AS Decimal(18, 2)), N'Aprobado', CAST(N'2026-08-10T00:00:00.000' AS DateTime))
INSERT [dbo].[PRESUPUESTO] ([Id_Presupuesto], [Id_Cliente], [Id_Usuario], [Cantidad_Invitados_Estimada], [Tipo_Evento], [Subtotal], [Estado], [Fecha_Evento]) VALUES (1089, 79, 1, 155, N'Cumpleaños 15', CAST(2325000.00 AS Decimal(18, 2)), N'Aprobado', CAST(N'2026-08-07T00:00:00.000' AS DateTime))
INSERT [dbo].[PRESUPUESTO] ([Id_Presupuesto], [Id_Cliente], [Id_Usuario], [Cantidad_Invitados_Estimada], [Tipo_Evento], [Subtotal], [Estado], [Fecha_Evento]) VALUES (1090, 80, 1, 180, N'Evento Corporativo', CAST(2700000.00 AS Decimal(18, 2)), N'Aprobado', CAST(N'2026-08-04T00:00:00.000' AS DateTime))
INSERT [dbo].[PRESUPUESTO] ([Id_Presupuesto], [Id_Cliente], [Id_Usuario], [Cantidad_Invitados_Estimada], [Tipo_Evento], [Subtotal], [Estado], [Fecha_Evento]) VALUES (1091, 81, 1, 80, N'Casamiento', CAST(1200000.00 AS Decimal(18, 2)), N'Aprobado', CAST(N'2026-08-01T00:00:00.000' AS DateTime))
INSERT [dbo].[PRESUPUESTO] ([Id_Presupuesto], [Id_Cliente], [Id_Usuario], [Cantidad_Invitados_Estimada], [Tipo_Evento], [Subtotal], [Estado], [Fecha_Evento]) VALUES (1092, 82, 1, 105, N'Cumpleaños 15', CAST(1575000.00 AS Decimal(18, 2)), N'Aprobado', CAST(N'2026-07-29T00:00:00.000' AS DateTime))
INSERT [dbo].[PRESUPUESTO] ([Id_Presupuesto], [Id_Cliente], [Id_Usuario], [Cantidad_Invitados_Estimada], [Tipo_Evento], [Subtotal], [Estado], [Fecha_Evento]) VALUES (1093, 83, 1, 130, N'Evento Corporativo', CAST(1950000.00 AS Decimal(18, 2)), N'Aprobado', CAST(N'2026-07-26T00:00:00.000' AS DateTime))
INSERT [dbo].[PRESUPUESTO] ([Id_Presupuesto], [Id_Cliente], [Id_Usuario], [Cantidad_Invitados_Estimada], [Tipo_Evento], [Subtotal], [Estado], [Fecha_Evento]) VALUES (1094, 84, 1, 155, N'Casamiento', CAST(2325000.00 AS Decimal(18, 2)), N'Aprobado', CAST(N'2026-07-23T00:00:00.000' AS DateTime))
INSERT [dbo].[PRESUPUESTO] ([Id_Presupuesto], [Id_Cliente], [Id_Usuario], [Cantidad_Invitados_Estimada], [Tipo_Evento], [Subtotal], [Estado], [Fecha_Evento]) VALUES (1095, 85, 1, 180, N'Cumpleaños 15', CAST(2700000.00 AS Decimal(18, 2)), N'Aprobado', CAST(N'2026-07-20T00:00:00.000' AS DateTime))
INSERT [dbo].[PRESUPUESTO] ([Id_Presupuesto], [Id_Cliente], [Id_Usuario], [Cantidad_Invitados_Estimada], [Tipo_Evento], [Subtotal], [Estado], [Fecha_Evento]) VALUES (1096, 86, 1, 80, N'Evento Corporativo', CAST(1200000.00 AS Decimal(18, 2)), N'Aprobado', CAST(N'2026-07-17T00:00:00.000' AS DateTime))
INSERT [dbo].[PRESUPUESTO] ([Id_Presupuesto], [Id_Cliente], [Id_Usuario], [Cantidad_Invitados_Estimada], [Tipo_Evento], [Subtotal], [Estado], [Fecha_Evento]) VALUES (1097, 87, 1, 105, N'Casamiento', CAST(1575000.00 AS Decimal(18, 2)), N'Aprobado', CAST(N'2026-07-14T00:00:00.000' AS DateTime))
INSERT [dbo].[PRESUPUESTO] ([Id_Presupuesto], [Id_Cliente], [Id_Usuario], [Cantidad_Invitados_Estimada], [Tipo_Evento], [Subtotal], [Estado], [Fecha_Evento]) VALUES (1098, 88, 1, 130, N'Cumpleaños 15', CAST(1950000.00 AS Decimal(18, 2)), N'Aprobado', CAST(N'2026-07-11T00:00:00.000' AS DateTime))
GO
INSERT [dbo].[PRESUPUESTO] ([Id_Presupuesto], [Id_Cliente], [Id_Usuario], [Cantidad_Invitados_Estimada], [Tipo_Evento], [Subtotal], [Estado], [Fecha_Evento]) VALUES (1099, 89, 1, 155, N'Evento Corporativo', CAST(2325000.00 AS Decimal(18, 2)), N'Aprobado', CAST(N'2026-07-08T00:00:00.000' AS DateTime))
INSERT [dbo].[PRESUPUESTO] ([Id_Presupuesto], [Id_Cliente], [Id_Usuario], [Cantidad_Invitados_Estimada], [Tipo_Evento], [Subtotal], [Estado], [Fecha_Evento]) VALUES (1100, 90, 1, 180, N'Casamiento', CAST(2700000.00 AS Decimal(18, 2)), N'Aprobado', CAST(N'2026-07-05T00:00:00.000' AS DateTime))
INSERT [dbo].[PRESUPUESTO] ([Id_Presupuesto], [Id_Cliente], [Id_Usuario], [Cantidad_Invitados_Estimada], [Tipo_Evento], [Subtotal], [Estado], [Fecha_Evento]) VALUES (1101, 91, 1, 80, N'Cumpleaños 15', CAST(1200000.00 AS Decimal(18, 2)), N'Aprobado', CAST(N'2026-07-02T00:00:00.000' AS DateTime))
INSERT [dbo].[PRESUPUESTO] ([Id_Presupuesto], [Id_Cliente], [Id_Usuario], [Cantidad_Invitados_Estimada], [Tipo_Evento], [Subtotal], [Estado], [Fecha_Evento]) VALUES (1102, 92, 1, 105, N'Evento Corporativo', CAST(1575000.00 AS Decimal(18, 2)), N'Aprobado', CAST(N'2026-06-29T00:00:00.000' AS DateTime))
INSERT [dbo].[PRESUPUESTO] ([Id_Presupuesto], [Id_Cliente], [Id_Usuario], [Cantidad_Invitados_Estimada], [Tipo_Evento], [Subtotal], [Estado], [Fecha_Evento]) VALUES (1103, 93, 1, 130, N'Casamiento', CAST(1950000.00 AS Decimal(18, 2)), N'Aprobado', CAST(N'2026-06-26T00:00:00.000' AS DateTime))
INSERT [dbo].[PRESUPUESTO] ([Id_Presupuesto], [Id_Cliente], [Id_Usuario], [Cantidad_Invitados_Estimada], [Tipo_Evento], [Subtotal], [Estado], [Fecha_Evento]) VALUES (1104, 94, 1, 155, N'Cumpleaños 15', CAST(2325000.00 AS Decimal(18, 2)), N'Aprobado', CAST(N'2026-06-23T00:00:00.000' AS DateTime))
INSERT [dbo].[PRESUPUESTO] ([Id_Presupuesto], [Id_Cliente], [Id_Usuario], [Cantidad_Invitados_Estimada], [Tipo_Evento], [Subtotal], [Estado], [Fecha_Evento]) VALUES (1105, 95, 1, 180, N'Evento Corporativo', CAST(2700000.00 AS Decimal(18, 2)), N'Aprobado', CAST(N'2026-06-20T00:00:00.000' AS DateTime))
INSERT [dbo].[PRESUPUESTO] ([Id_Presupuesto], [Id_Cliente], [Id_Usuario], [Cantidad_Invitados_Estimada], [Tipo_Evento], [Subtotal], [Estado], [Fecha_Evento]) VALUES (1106, 96, 1, 80, N'Casamiento', CAST(1200000.00 AS Decimal(18, 2)), N'Aprobado', CAST(N'2026-06-17T00:00:00.000' AS DateTime))
INSERT [dbo].[PRESUPUESTO] ([Id_Presupuesto], [Id_Cliente], [Id_Usuario], [Cantidad_Invitados_Estimada], [Tipo_Evento], [Subtotal], [Estado], [Fecha_Evento]) VALUES (1107, 97, 1, 105, N'Cumpleaños 15', CAST(1575000.00 AS Decimal(18, 2)), N'Aprobado', CAST(N'2026-06-14T00:00:00.000' AS DateTime))
INSERT [dbo].[PRESUPUESTO] ([Id_Presupuesto], [Id_Cliente], [Id_Usuario], [Cantidad_Invitados_Estimada], [Tipo_Evento], [Subtotal], [Estado], [Fecha_Evento]) VALUES (1108, 98, 1, 130, N'Evento Corporativo', CAST(1950000.00 AS Decimal(18, 2)), N'Aprobado', CAST(N'2026-06-11T00:00:00.000' AS DateTime))
INSERT [dbo].[PRESUPUESTO] ([Id_Presupuesto], [Id_Cliente], [Id_Usuario], [Cantidad_Invitados_Estimada], [Tipo_Evento], [Subtotal], [Estado], [Fecha_Evento]) VALUES (1109, 99, 1, 155, N'Casamiento', CAST(2325000.00 AS Decimal(18, 2)), N'Aprobado', CAST(N'2026-06-08T00:00:00.000' AS DateTime))
INSERT [dbo].[PRESUPUESTO] ([Id_Presupuesto], [Id_Cliente], [Id_Usuario], [Cantidad_Invitados_Estimada], [Tipo_Evento], [Subtotal], [Estado], [Fecha_Evento]) VALUES (1110, 100, 1, 180, N'Cumpleaños 15', CAST(2700000.00 AS Decimal(18, 2)), N'Aprobado', CAST(N'2026-06-05T00:00:00.000' AS DateTime))
INSERT [dbo].[PRESUPUESTO] ([Id_Presupuesto], [Id_Cliente], [Id_Usuario], [Cantidad_Invitados_Estimada], [Tipo_Evento], [Subtotal], [Estado], [Fecha_Evento]) VALUES (1111, 101, 1, 80, N'Evento Corporativo', CAST(1200000.00 AS Decimal(18, 2)), N'Aprobado', CAST(N'2026-06-02T00:00:00.000' AS DateTime))
INSERT [dbo].[PRESUPUESTO] ([Id_Presupuesto], [Id_Cliente], [Id_Usuario], [Cantidad_Invitados_Estimada], [Tipo_Evento], [Subtotal], [Estado], [Fecha_Evento]) VALUES (1112, 102, 1, 105, N'Casamiento', CAST(1575000.00 AS Decimal(18, 2)), N'Aprobado', CAST(N'2026-05-30T00:00:00.000' AS DateTime))
INSERT [dbo].[PRESUPUESTO] ([Id_Presupuesto], [Id_Cliente], [Id_Usuario], [Cantidad_Invitados_Estimada], [Tipo_Evento], [Subtotal], [Estado], [Fecha_Evento]) VALUES (1113, 103, 1, 130, N'Cumpleaños 15', CAST(1950000.00 AS Decimal(18, 2)), N'Aprobado', CAST(N'2026-05-27T00:00:00.000' AS DateTime))
INSERT [dbo].[PRESUPUESTO] ([Id_Presupuesto], [Id_Cliente], [Id_Usuario], [Cantidad_Invitados_Estimada], [Tipo_Evento], [Subtotal], [Estado], [Fecha_Evento]) VALUES (1114, 104, 1, 155, N'Evento Corporativo', CAST(2325000.00 AS Decimal(18, 2)), N'Aprobado', CAST(N'2026-05-24T00:00:00.000' AS DateTime))
INSERT [dbo].[PRESUPUESTO] ([Id_Presupuesto], [Id_Cliente], [Id_Usuario], [Cantidad_Invitados_Estimada], [Tipo_Evento], [Subtotal], [Estado], [Fecha_Evento]) VALUES (1115, 105, 1, 180, N'Casamiento', CAST(2700000.00 AS Decimal(18, 2)), N'Aprobado', CAST(N'2026-05-21T00:00:00.000' AS DateTime))
INSERT [dbo].[PRESUPUESTO] ([Id_Presupuesto], [Id_Cliente], [Id_Usuario], [Cantidad_Invitados_Estimada], [Tipo_Evento], [Subtotal], [Estado], [Fecha_Evento]) VALUES (1116, 106, 1, 80, N'Cumpleaños 15', CAST(1200000.00 AS Decimal(18, 2)), N'Aprobado', CAST(N'2026-05-18T00:00:00.000' AS DateTime))
INSERT [dbo].[PRESUPUESTO] ([Id_Presupuesto], [Id_Cliente], [Id_Usuario], [Cantidad_Invitados_Estimada], [Tipo_Evento], [Subtotal], [Estado], [Fecha_Evento]) VALUES (1117, 107, 1, 105, N'Cumpleaños 15', CAST(1575000.00 AS Decimal(18, 2)), N'Aprobado', CAST(N'2026-10-27T00:00:00.000' AS DateTime))
INSERT [dbo].[PRESUPUESTO] ([Id_Presupuesto], [Id_Cliente], [Id_Usuario], [Cantidad_Invitados_Estimada], [Tipo_Evento], [Subtotal], [Estado], [Fecha_Evento]) VALUES (1118, 108, 1, 130, N'Evento Corporativo', CAST(1950000.00 AS Decimal(18, 2)), N'Aprobado', CAST(N'2026-10-24T00:00:00.000' AS DateTime))
INSERT [dbo].[PRESUPUESTO] ([Id_Presupuesto], [Id_Cliente], [Id_Usuario], [Cantidad_Invitados_Estimada], [Tipo_Evento], [Subtotal], [Estado], [Fecha_Evento]) VALUES (1119, 109, 1, 155, N'Casamiento', CAST(2325000.00 AS Decimal(18, 2)), N'Aprobado', CAST(N'2026-10-21T00:00:00.000' AS DateTime))
INSERT [dbo].[PRESUPUESTO] ([Id_Presupuesto], [Id_Cliente], [Id_Usuario], [Cantidad_Invitados_Estimada], [Tipo_Evento], [Subtotal], [Estado], [Fecha_Evento]) VALUES (1120, 110, 1, 180, N'Cumpleaños 15', CAST(2700000.00 AS Decimal(18, 2)), N'Aprobado', CAST(N'2026-10-18T00:00:00.000' AS DateTime))
INSERT [dbo].[PRESUPUESTO] ([Id_Presupuesto], [Id_Cliente], [Id_Usuario], [Cantidad_Invitados_Estimada], [Tipo_Evento], [Subtotal], [Estado], [Fecha_Evento]) VALUES (1121, 111, 1, 80, N'Evento Corporativo', CAST(1200000.00 AS Decimal(18, 2)), N'Aprobado', CAST(N'2026-10-15T00:00:00.000' AS DateTime))
INSERT [dbo].[PRESUPUESTO] ([Id_Presupuesto], [Id_Cliente], [Id_Usuario], [Cantidad_Invitados_Estimada], [Tipo_Evento], [Subtotal], [Estado], [Fecha_Evento]) VALUES (1122, 112, 1, 105, N'Casamiento', CAST(1575000.00 AS Decimal(18, 2)), N'Aprobado', CAST(N'2026-10-12T00:00:00.000' AS DateTime))
INSERT [dbo].[PRESUPUESTO] ([Id_Presupuesto], [Id_Cliente], [Id_Usuario], [Cantidad_Invitados_Estimada], [Tipo_Evento], [Subtotal], [Estado], [Fecha_Evento]) VALUES (1123, 113, 1, 130, N'Cumpleaños 15', CAST(1950000.00 AS Decimal(18, 2)), N'Aprobado', CAST(N'2026-10-09T00:00:00.000' AS DateTime))
INSERT [dbo].[PRESUPUESTO] ([Id_Presupuesto], [Id_Cliente], [Id_Usuario], [Cantidad_Invitados_Estimada], [Tipo_Evento], [Subtotal], [Estado], [Fecha_Evento]) VALUES (1124, 114, 1, 155, N'Evento Corporativo', CAST(2325000.00 AS Decimal(18, 2)), N'Aprobado', CAST(N'2026-10-06T00:00:00.000' AS DateTime))
INSERT [dbo].[PRESUPUESTO] ([Id_Presupuesto], [Id_Cliente], [Id_Usuario], [Cantidad_Invitados_Estimada], [Tipo_Evento], [Subtotal], [Estado], [Fecha_Evento]) VALUES (1125, 115, 1, 180, N'Casamiento', CAST(2700000.00 AS Decimal(18, 2)), N'Aprobado', CAST(N'2026-10-03T00:00:00.000' AS DateTime))
INSERT [dbo].[PRESUPUESTO] ([Id_Presupuesto], [Id_Cliente], [Id_Usuario], [Cantidad_Invitados_Estimada], [Tipo_Evento], [Subtotal], [Estado], [Fecha_Evento]) VALUES (1126, 116, 1, 80, N'Cumpleaños 15', CAST(1200000.00 AS Decimal(18, 2)), N'Aprobado', CAST(N'2026-09-30T00:00:00.000' AS DateTime))
INSERT [dbo].[PRESUPUESTO] ([Id_Presupuesto], [Id_Cliente], [Id_Usuario], [Cantidad_Invitados_Estimada], [Tipo_Evento], [Subtotal], [Estado], [Fecha_Evento]) VALUES (1127, 117, 1, 105, N'Evento Corporativo', CAST(1575000.00 AS Decimal(18, 2)), N'Aprobado', CAST(N'2026-09-27T00:00:00.000' AS DateTime))
INSERT [dbo].[PRESUPUESTO] ([Id_Presupuesto], [Id_Cliente], [Id_Usuario], [Cantidad_Invitados_Estimada], [Tipo_Evento], [Subtotal], [Estado], [Fecha_Evento]) VALUES (1128, 118, 1, 130, N'Casamiento', CAST(1950000.00 AS Decimal(18, 2)), N'Aprobado', CAST(N'2026-09-24T00:00:00.000' AS DateTime))
INSERT [dbo].[PRESUPUESTO] ([Id_Presupuesto], [Id_Cliente], [Id_Usuario], [Cantidad_Invitados_Estimada], [Tipo_Evento], [Subtotal], [Estado], [Fecha_Evento]) VALUES (1129, 119, 1, 155, N'Cumpleaños 15', CAST(2325000.00 AS Decimal(18, 2)), N'Aprobado', CAST(N'2026-09-21T00:00:00.000' AS DateTime))
INSERT [dbo].[PRESUPUESTO] ([Id_Presupuesto], [Id_Cliente], [Id_Usuario], [Cantidad_Invitados_Estimada], [Tipo_Evento], [Subtotal], [Estado], [Fecha_Evento]) VALUES (1130, 120, 1, 180, N'Evento Corporativo', CAST(2700000.00 AS Decimal(18, 2)), N'Aprobado', CAST(N'2026-09-18T00:00:00.000' AS DateTime))
INSERT [dbo].[PRESUPUESTO] ([Id_Presupuesto], [Id_Cliente], [Id_Usuario], [Cantidad_Invitados_Estimada], [Tipo_Evento], [Subtotal], [Estado], [Fecha_Evento]) VALUES (1131, 121, 1, 80, N'Casamiento', CAST(1200000.00 AS Decimal(18, 2)), N'Aprobado', CAST(N'2026-09-15T00:00:00.000' AS DateTime))
INSERT [dbo].[PRESUPUESTO] ([Id_Presupuesto], [Id_Cliente], [Id_Usuario], [Cantidad_Invitados_Estimada], [Tipo_Evento], [Subtotal], [Estado], [Fecha_Evento]) VALUES (1132, 122, 1, 105, N'Cumpleaños 15', CAST(1575000.00 AS Decimal(18, 2)), N'Aprobado', CAST(N'2026-09-12T00:00:00.000' AS DateTime))
INSERT [dbo].[PRESUPUESTO] ([Id_Presupuesto], [Id_Cliente], [Id_Usuario], [Cantidad_Invitados_Estimada], [Tipo_Evento], [Subtotal], [Estado], [Fecha_Evento]) VALUES (1133, 123, 1, 130, N'Evento Corporativo', CAST(1950000.00 AS Decimal(18, 2)), N'Aprobado', CAST(N'2026-09-09T00:00:00.000' AS DateTime))
INSERT [dbo].[PRESUPUESTO] ([Id_Presupuesto], [Id_Cliente], [Id_Usuario], [Cantidad_Invitados_Estimada], [Tipo_Evento], [Subtotal], [Estado], [Fecha_Evento]) VALUES (1134, 124, 1, 155, N'Casamiento', CAST(2325000.00 AS Decimal(18, 2)), N'Aprobado', CAST(N'2026-09-06T00:00:00.000' AS DateTime))
INSERT [dbo].[PRESUPUESTO] ([Id_Presupuesto], [Id_Cliente], [Id_Usuario], [Cantidad_Invitados_Estimada], [Tipo_Evento], [Subtotal], [Estado], [Fecha_Evento]) VALUES (1135, 125, 1, 180, N'Cumpleaños 15', CAST(2700000.00 AS Decimal(18, 2)), N'Aprobado', CAST(N'2026-09-03T00:00:00.000' AS DateTime))
INSERT [dbo].[PRESUPUESTO] ([Id_Presupuesto], [Id_Cliente], [Id_Usuario], [Cantidad_Invitados_Estimada], [Tipo_Evento], [Subtotal], [Estado], [Fecha_Evento]) VALUES (1136, 126, 1, 80, N'Evento Corporativo', CAST(1200000.00 AS Decimal(18, 2)), N'Aprobado', CAST(N'2026-08-31T00:00:00.000' AS DateTime))
INSERT [dbo].[PRESUPUESTO] ([Id_Presupuesto], [Id_Cliente], [Id_Usuario], [Cantidad_Invitados_Estimada], [Tipo_Evento], [Subtotal], [Estado], [Fecha_Evento]) VALUES (1137, 127, 1, 105, N'Casamiento', CAST(1575000.00 AS Decimal(18, 2)), N'Aprobado', CAST(N'2026-08-28T00:00:00.000' AS DateTime))
INSERT [dbo].[PRESUPUESTO] ([Id_Presupuesto], [Id_Cliente], [Id_Usuario], [Cantidad_Invitados_Estimada], [Tipo_Evento], [Subtotal], [Estado], [Fecha_Evento]) VALUES (1138, 128, 1, 130, N'Cumpleaños 15', CAST(1950000.00 AS Decimal(18, 2)), N'Aprobado', CAST(N'2026-08-25T00:00:00.000' AS DateTime))
INSERT [dbo].[PRESUPUESTO] ([Id_Presupuesto], [Id_Cliente], [Id_Usuario], [Cantidad_Invitados_Estimada], [Tipo_Evento], [Subtotal], [Estado], [Fecha_Evento]) VALUES (1139, 129, 1, 155, N'Evento Corporativo', CAST(2325000.00 AS Decimal(18, 2)), N'Aprobado', CAST(N'2026-08-22T00:00:00.000' AS DateTime))
INSERT [dbo].[PRESUPUESTO] ([Id_Presupuesto], [Id_Cliente], [Id_Usuario], [Cantidad_Invitados_Estimada], [Tipo_Evento], [Subtotal], [Estado], [Fecha_Evento]) VALUES (1140, 130, 1, 180, N'Casamiento', CAST(2700000.00 AS Decimal(18, 2)), N'Aprobado', CAST(N'2026-08-19T00:00:00.000' AS DateTime))
INSERT [dbo].[PRESUPUESTO] ([Id_Presupuesto], [Id_Cliente], [Id_Usuario], [Cantidad_Invitados_Estimada], [Tipo_Evento], [Subtotal], [Estado], [Fecha_Evento]) VALUES (1141, 131, 1, 80, N'Cumpleaños 15', CAST(1200000.00 AS Decimal(18, 2)), N'Aprobado', CAST(N'2026-08-16T00:00:00.000' AS DateTime))
INSERT [dbo].[PRESUPUESTO] ([Id_Presupuesto], [Id_Cliente], [Id_Usuario], [Cantidad_Invitados_Estimada], [Tipo_Evento], [Subtotal], [Estado], [Fecha_Evento]) VALUES (1142, 132, 1, 105, N'Evento Corporativo', CAST(1575000.00 AS Decimal(18, 2)), N'Aprobado', CAST(N'2026-08-13T00:00:00.000' AS DateTime))
INSERT [dbo].[PRESUPUESTO] ([Id_Presupuesto], [Id_Cliente], [Id_Usuario], [Cantidad_Invitados_Estimada], [Tipo_Evento], [Subtotal], [Estado], [Fecha_Evento]) VALUES (1143, 133, 1, 130, N'Casamiento', CAST(1950000.00 AS Decimal(18, 2)), N'Aprobado', CAST(N'2026-08-10T00:00:00.000' AS DateTime))
INSERT [dbo].[PRESUPUESTO] ([Id_Presupuesto], [Id_Cliente], [Id_Usuario], [Cantidad_Invitados_Estimada], [Tipo_Evento], [Subtotal], [Estado], [Fecha_Evento]) VALUES (1144, 134, 1, 155, N'Cumpleaños 15', CAST(2325000.00 AS Decimal(18, 2)), N'Aprobado', CAST(N'2026-08-07T00:00:00.000' AS DateTime))
INSERT [dbo].[PRESUPUESTO] ([Id_Presupuesto], [Id_Cliente], [Id_Usuario], [Cantidad_Invitados_Estimada], [Tipo_Evento], [Subtotal], [Estado], [Fecha_Evento]) VALUES (1145, 135, 1, 180, N'Evento Corporativo', CAST(2700000.00 AS Decimal(18, 2)), N'Aprobado', CAST(N'2026-08-04T00:00:00.000' AS DateTime))
INSERT [dbo].[PRESUPUESTO] ([Id_Presupuesto], [Id_Cliente], [Id_Usuario], [Cantidad_Invitados_Estimada], [Tipo_Evento], [Subtotal], [Estado], [Fecha_Evento]) VALUES (1146, 136, 1, 80, N'Casamiento', CAST(1200000.00 AS Decimal(18, 2)), N'Aprobado', CAST(N'2026-08-01T00:00:00.000' AS DateTime))
INSERT [dbo].[PRESUPUESTO] ([Id_Presupuesto], [Id_Cliente], [Id_Usuario], [Cantidad_Invitados_Estimada], [Tipo_Evento], [Subtotal], [Estado], [Fecha_Evento]) VALUES (1147, 137, 1, 105, N'Cumpleaños 15', CAST(1575000.00 AS Decimal(18, 2)), N'Aprobado', CAST(N'2026-07-29T00:00:00.000' AS DateTime))
INSERT [dbo].[PRESUPUESTO] ([Id_Presupuesto], [Id_Cliente], [Id_Usuario], [Cantidad_Invitados_Estimada], [Tipo_Evento], [Subtotal], [Estado], [Fecha_Evento]) VALUES (1148, 138, 1, 130, N'Evento Corporativo', CAST(1950000.00 AS Decimal(18, 2)), N'Aprobado', CAST(N'2026-07-26T00:00:00.000' AS DateTime))
INSERT [dbo].[PRESUPUESTO] ([Id_Presupuesto], [Id_Cliente], [Id_Usuario], [Cantidad_Invitados_Estimada], [Tipo_Evento], [Subtotal], [Estado], [Fecha_Evento]) VALUES (1149, 139, 1, 155, N'Casamiento', CAST(2325000.00 AS Decimal(18, 2)), N'Aprobado', CAST(N'2026-07-23T00:00:00.000' AS DateTime))
INSERT [dbo].[PRESUPUESTO] ([Id_Presupuesto], [Id_Cliente], [Id_Usuario], [Cantidad_Invitados_Estimada], [Tipo_Evento], [Subtotal], [Estado], [Fecha_Evento]) VALUES (1150, 140, 1, 180, N'Cumpleaños 15', CAST(2700000.00 AS Decimal(18, 2)), N'Aprobado', CAST(N'2026-07-20T00:00:00.000' AS DateTime))
INSERT [dbo].[PRESUPUESTO] ([Id_Presupuesto], [Id_Cliente], [Id_Usuario], [Cantidad_Invitados_Estimada], [Tipo_Evento], [Subtotal], [Estado], [Fecha_Evento]) VALUES (1151, 141, 1, 80, N'Evento Corporativo', CAST(1200000.00 AS Decimal(18, 2)), N'Aprobado', CAST(N'2026-07-17T00:00:00.000' AS DateTime))
INSERT [dbo].[PRESUPUESTO] ([Id_Presupuesto], [Id_Cliente], [Id_Usuario], [Cantidad_Invitados_Estimada], [Tipo_Evento], [Subtotal], [Estado], [Fecha_Evento]) VALUES (1152, 142, 1, 105, N'Casamiento', CAST(1575000.00 AS Decimal(18, 2)), N'Aprobado', CAST(N'2026-07-14T00:00:00.000' AS DateTime))
INSERT [dbo].[PRESUPUESTO] ([Id_Presupuesto], [Id_Cliente], [Id_Usuario], [Cantidad_Invitados_Estimada], [Tipo_Evento], [Subtotal], [Estado], [Fecha_Evento]) VALUES (1153, 143, 1, 130, N'Cumpleaños 15', CAST(1950000.00 AS Decimal(18, 2)), N'Aprobado', CAST(N'2026-07-11T00:00:00.000' AS DateTime))
INSERT [dbo].[PRESUPUESTO] ([Id_Presupuesto], [Id_Cliente], [Id_Usuario], [Cantidad_Invitados_Estimada], [Tipo_Evento], [Subtotal], [Estado], [Fecha_Evento]) VALUES (1154, 144, 1, 155, N'Evento Corporativo', CAST(2325000.00 AS Decimal(18, 2)), N'Aprobado', CAST(N'2026-07-08T00:00:00.000' AS DateTime))
INSERT [dbo].[PRESUPUESTO] ([Id_Presupuesto], [Id_Cliente], [Id_Usuario], [Cantidad_Invitados_Estimada], [Tipo_Evento], [Subtotal], [Estado], [Fecha_Evento]) VALUES (1155, 145, 1, 180, N'Casamiento', CAST(2700000.00 AS Decimal(18, 2)), N'Aprobado', CAST(N'2026-07-05T00:00:00.000' AS DateTime))
INSERT [dbo].[PRESUPUESTO] ([Id_Presupuesto], [Id_Cliente], [Id_Usuario], [Cantidad_Invitados_Estimada], [Tipo_Evento], [Subtotal], [Estado], [Fecha_Evento]) VALUES (1156, 146, 1, 80, N'Cumpleaños 15', CAST(1200000.00 AS Decimal(18, 2)), N'Aprobado', CAST(N'2026-07-02T00:00:00.000' AS DateTime))
INSERT [dbo].[PRESUPUESTO] ([Id_Presupuesto], [Id_Cliente], [Id_Usuario], [Cantidad_Invitados_Estimada], [Tipo_Evento], [Subtotal], [Estado], [Fecha_Evento]) VALUES (1157, 147, 1, 105, N'Evento Corporativo', CAST(1575000.00 AS Decimal(18, 2)), N'Aprobado', CAST(N'2026-06-29T00:00:00.000' AS DateTime))
INSERT [dbo].[PRESUPUESTO] ([Id_Presupuesto], [Id_Cliente], [Id_Usuario], [Cantidad_Invitados_Estimada], [Tipo_Evento], [Subtotal], [Estado], [Fecha_Evento]) VALUES (1158, 148, 1, 130, N'Casamiento', CAST(1950000.00 AS Decimal(18, 2)), N'Aprobado', CAST(N'2026-06-26T00:00:00.000' AS DateTime))
INSERT [dbo].[PRESUPUESTO] ([Id_Presupuesto], [Id_Cliente], [Id_Usuario], [Cantidad_Invitados_Estimada], [Tipo_Evento], [Subtotal], [Estado], [Fecha_Evento]) VALUES (1159, 149, 1, 155, N'Cumpleaños 15', CAST(2325000.00 AS Decimal(18, 2)), N'Aprobado', CAST(N'2026-06-23T00:00:00.000' AS DateTime))
INSERT [dbo].[PRESUPUESTO] ([Id_Presupuesto], [Id_Cliente], [Id_Usuario], [Cantidad_Invitados_Estimada], [Tipo_Evento], [Subtotal], [Estado], [Fecha_Evento]) VALUES (1160, 150, 1, 180, N'Evento Corporativo', CAST(2700000.00 AS Decimal(18, 2)), N'Aprobado', CAST(N'2026-06-20T00:00:00.000' AS DateTime))
INSERT [dbo].[PRESUPUESTO] ([Id_Presupuesto], [Id_Cliente], [Id_Usuario], [Cantidad_Invitados_Estimada], [Tipo_Evento], [Subtotal], [Estado], [Fecha_Evento]) VALUES (1161, 151, 1, 80, N'Casamiento', CAST(1200000.00 AS Decimal(18, 2)), N'Aprobado', CAST(N'2026-06-17T00:00:00.000' AS DateTime))
INSERT [dbo].[PRESUPUESTO] ([Id_Presupuesto], [Id_Cliente], [Id_Usuario], [Cantidad_Invitados_Estimada], [Tipo_Evento], [Subtotal], [Estado], [Fecha_Evento]) VALUES (1162, 152, 1, 105, N'Cumpleaños 15', CAST(1575000.00 AS Decimal(18, 2)), N'Aprobado', CAST(N'2026-06-14T00:00:00.000' AS DateTime))
INSERT [dbo].[PRESUPUESTO] ([Id_Presupuesto], [Id_Cliente], [Id_Usuario], [Cantidad_Invitados_Estimada], [Tipo_Evento], [Subtotal], [Estado], [Fecha_Evento]) VALUES (1163, 153, 1, 130, N'Evento Corporativo', CAST(1950000.00 AS Decimal(18, 2)), N'Aprobado', CAST(N'2026-06-11T00:00:00.000' AS DateTime))
INSERT [dbo].[PRESUPUESTO] ([Id_Presupuesto], [Id_Cliente], [Id_Usuario], [Cantidad_Invitados_Estimada], [Tipo_Evento], [Subtotal], [Estado], [Fecha_Evento]) VALUES (1164, 154, 1, 155, N'Casamiento', CAST(2325000.00 AS Decimal(18, 2)), N'Aprobado', CAST(N'2026-06-08T00:00:00.000' AS DateTime))
INSERT [dbo].[PRESUPUESTO] ([Id_Presupuesto], [Id_Cliente], [Id_Usuario], [Cantidad_Invitados_Estimada], [Tipo_Evento], [Subtotal], [Estado], [Fecha_Evento]) VALUES (1165, 155, 1, 180, N'Cumpleaños 15', CAST(2700000.00 AS Decimal(18, 2)), N'Aprobado', CAST(N'2026-06-05T00:00:00.000' AS DateTime))
INSERT [dbo].[PRESUPUESTO] ([Id_Presupuesto], [Id_Cliente], [Id_Usuario], [Cantidad_Invitados_Estimada], [Tipo_Evento], [Subtotal], [Estado], [Fecha_Evento]) VALUES (1166, 156, 1, 80, N'Evento Corporativo', CAST(1200000.00 AS Decimal(18, 2)), N'Aprobado', CAST(N'2026-06-02T00:00:00.000' AS DateTime))
INSERT [dbo].[PRESUPUESTO] ([Id_Presupuesto], [Id_Cliente], [Id_Usuario], [Cantidad_Invitados_Estimada], [Tipo_Evento], [Subtotal], [Estado], [Fecha_Evento]) VALUES (1167, 157, 1, 105, N'Casamiento', CAST(1575000.00 AS Decimal(18, 2)), N'Aprobado', CAST(N'2026-05-30T00:00:00.000' AS DateTime))
INSERT [dbo].[PRESUPUESTO] ([Id_Presupuesto], [Id_Cliente], [Id_Usuario], [Cantidad_Invitados_Estimada], [Tipo_Evento], [Subtotal], [Estado], [Fecha_Evento]) VALUES (1168, 158, 1, 130, N'Cumpleaños 15', CAST(1950000.00 AS Decimal(18, 2)), N'Aprobado', CAST(N'2026-05-27T00:00:00.000' AS DateTime))
INSERT [dbo].[PRESUPUESTO] ([Id_Presupuesto], [Id_Cliente], [Id_Usuario], [Cantidad_Invitados_Estimada], [Tipo_Evento], [Subtotal], [Estado], [Fecha_Evento]) VALUES (1169, 159, 1, 155, N'Evento Corporativo', CAST(2325000.00 AS Decimal(18, 2)), N'Aprobado', CAST(N'2026-05-24T00:00:00.000' AS DateTime))
INSERT [dbo].[PRESUPUESTO] ([Id_Presupuesto], [Id_Cliente], [Id_Usuario], [Cantidad_Invitados_Estimada], [Tipo_Evento], [Subtotal], [Estado], [Fecha_Evento]) VALUES (1170, 160, 1, 180, N'Casamiento', CAST(2700000.00 AS Decimal(18, 2)), N'Aprobado', CAST(N'2026-05-21T00:00:00.000' AS DateTime))
INSERT [dbo].[PRESUPUESTO] ([Id_Presupuesto], [Id_Cliente], [Id_Usuario], [Cantidad_Invitados_Estimada], [Tipo_Evento], [Subtotal], [Estado], [Fecha_Evento]) VALUES (1171, 161, 1, 80, N'Cumpleaños 15', CAST(1200000.00 AS Decimal(18, 2)), N'Aprobado', CAST(N'2026-05-18T00:00:00.000' AS DateTime))
INSERT [dbo].[PRESUPUESTO] ([Id_Presupuesto], [Id_Cliente], [Id_Usuario], [Cantidad_Invitados_Estimada], [Tipo_Evento], [Subtotal], [Estado], [Fecha_Evento]) VALUES (1172, 9, 1, 50, N'Evento Corporativo', CAST(1000000.00 AS Decimal(18, 2)), N'Aprobado', CAST(N'2026-11-16T00:00:00.000' AS DateTime))
INSERT [dbo].[PRESUPUESTO] ([Id_Presupuesto], [Id_Cliente], [Id_Usuario], [Cantidad_Invitados_Estimada], [Tipo_Evento], [Subtotal], [Estado], [Fecha_Evento]) VALUES (1173, 3, 1, 50, N'Casamiento', CAST(750000.00 AS Decimal(18, 2)), N'Aprobado', CAST(N'2026-11-16T00:00:00.000' AS DateTime))
INSERT [dbo].[PRESUPUESTO] ([Id_Presupuesto], [Id_Cliente], [Id_Usuario], [Cantidad_Invitados_Estimada], [Tipo_Evento], [Subtotal], [Estado], [Fecha_Evento]) VALUES (1174, 50, 1, 50, N'Casamiento', CAST(750000.00 AS Decimal(18, 2)), N'Aprobado', CAST(N'2026-11-24T00:00:00.000' AS DateTime))
SET IDENTITY_INSERT [dbo].[PRESUPUESTO] OFF
GO
INSERT [dbo].[PRODUCTO] ([ID_PRODUCTO], [NOMBRE], [PRECIO], [STOCK], [ACTIVO]) VALUES (1, N'yerba', CAST(1000.00 AS Decimal(18, 2)), 3, 1)
INSERT [dbo].[PRODUCTO] ([ID_PRODUCTO], [NOMBRE], [PRECIO], [STOCK], [ACTIVO]) VALUES (2, N'coca', CAST(33.00 AS Decimal(18, 2)), 1, 1)
INSERT [dbo].[PRODUCTO] ([ID_PRODUCTO], [NOMBRE], [PRECIO], [STOCK], [ACTIVO]) VALUES (3, N'sprite', CAST(33.00 AS Decimal(18, 2)), 1, 0)
GO
SET IDENTITY_INSERT [dbo].[PROVEEDOR_INSUMO] ON 

INSERT [dbo].[PROVEEDOR_INSUMO] ([Id_Proveedor], [Razon_Social], [CUIT], [Rubro], [Telefono], [Direccion], [Email], [Estado]) VALUES (1, N'Sansa', N'30421004499', N'Panaderia', N'1125599059', N'Av Caseros 1990', N'sansita@gmail.com', N'Activo')
INSERT [dbo].[PROVEEDOR_INSUMO] ([Id_Proveedor], [Razon_Social], [CUIT], [Rubro], [Telefono], [Direccion], [Email], [Estado]) VALUES (2, N'Muraca', N'3041930909', N'Carniceria', N'14141414', N'caseros 1999', N'muru@gmail.com', N'Activo')
SET IDENTITY_INSERT [dbo].[PROVEEDOR_INSUMO] OFF
GO
SET IDENTITY_INSERT [dbo].[RECETARIO] ON 

INSERT [dbo].[RECETARIO] ([Id_Detalle_Recetario], [Id_Servicio], [Id_Insumo], [Cantidad_Por_Persona]) VALUES (8, 7, 2, CAST(0.5000 AS Decimal(18, 4)))
INSERT [dbo].[RECETARIO] ([Id_Detalle_Recetario], [Id_Servicio], [Id_Insumo], [Cantidad_Por_Persona]) VALUES (9, 7, 3, CAST(0.2000 AS Decimal(18, 4)))
INSERT [dbo].[RECETARIO] ([Id_Detalle_Recetario], [Id_Servicio], [Id_Insumo], [Cantidad_Por_Persona]) VALUES (10, 7, 6, CAST(0.2500 AS Decimal(18, 4)))
INSERT [dbo].[RECETARIO] ([Id_Detalle_Recetario], [Id_Servicio], [Id_Insumo], [Cantidad_Por_Persona]) VALUES (11, 8, 5, CAST(1.0000 AS Decimal(18, 4)))
INSERT [dbo].[RECETARIO] ([Id_Detalle_Recetario], [Id_Servicio], [Id_Insumo], [Cantidad_Por_Persona]) VALUES (12, 8, 4, CAST(0.5000 AS Decimal(18, 4)))
INSERT [dbo].[RECETARIO] ([Id_Detalle_Recetario], [Id_Servicio], [Id_Insumo], [Cantidad_Por_Persona]) VALUES (13, 8, 6, CAST(0.2500 AS Decimal(18, 4)))
INSERT [dbo].[RECETARIO] ([Id_Detalle_Recetario], [Id_Servicio], [Id_Insumo], [Cantidad_Por_Persona]) VALUES (14, 1, 1, CAST(0.2500 AS Decimal(18, 4)))
INSERT [dbo].[RECETARIO] ([Id_Detalle_Recetario], [Id_Servicio], [Id_Insumo], [Cantidad_Por_Persona]) VALUES (15, 4, 1, CAST(0.1500 AS Decimal(18, 4)))
INSERT [dbo].[RECETARIO] ([Id_Detalle_Recetario], [Id_Servicio], [Id_Insumo], [Cantidad_Por_Persona]) VALUES (16, 1, 2, CAST(0.2500 AS Decimal(18, 4)))
INSERT [dbo].[RECETARIO] ([Id_Detalle_Recetario], [Id_Servicio], [Id_Insumo], [Cantidad_Por_Persona]) VALUES (17, 4, 2, CAST(0.1500 AS Decimal(18, 4)))
INSERT [dbo].[RECETARIO] ([Id_Detalle_Recetario], [Id_Servicio], [Id_Insumo], [Cantidad_Por_Persona]) VALUES (18, 6, 2, CAST(0.3000 AS Decimal(18, 4)))
INSERT [dbo].[RECETARIO] ([Id_Detalle_Recetario], [Id_Servicio], [Id_Insumo], [Cantidad_Por_Persona]) VALUES (19, 6, 3, CAST(0.5000 AS Decimal(18, 4)))
INSERT [dbo].[RECETARIO] ([Id_Detalle_Recetario], [Id_Servicio], [Id_Insumo], [Cantidad_Por_Persona]) VALUES (20, 6, 5, CAST(0.6000 AS Decimal(18, 4)))
INSERT [dbo].[RECETARIO] ([Id_Detalle_Recetario], [Id_Servicio], [Id_Insumo], [Cantidad_Por_Persona]) VALUES (25, 2, 2, CAST(0.5000 AS Decimal(18, 4)))
INSERT [dbo].[RECETARIO] ([Id_Detalle_Recetario], [Id_Servicio], [Id_Insumo], [Cantidad_Por_Persona]) VALUES (26, 2, 5, CAST(0.3000 AS Decimal(18, 4)))
INSERT [dbo].[RECETARIO] ([Id_Detalle_Recetario], [Id_Servicio], [Id_Insumo], [Cantidad_Por_Persona]) VALUES (27, 2, 6, CAST(0.2500 AS Decimal(18, 4)))
INSERT [dbo].[RECETARIO] ([Id_Detalle_Recetario], [Id_Servicio], [Id_Insumo], [Cantidad_Por_Persona]) VALUES (28, 2, 4, CAST(1.0000 AS Decimal(18, 4)))
SET IDENTITY_INSERT [dbo].[RECETARIO] OFF
GO
SET IDENTITY_INSERT [dbo].[RESERVA] ON 

INSERT [dbo].[RESERVA] ([Id_Reserva], [Id_Cliente], [Id_Usuario], [Id_Presupuesto], [Fecha_Evento], [Monto_Senia], [Estado], [Costo_Total_Real], [Saldo_Pendiente], [Evaluacion_Personal], [Observaciones_Personal]) VALUES (5, 2, 1, 9, CAST(N'2027-01-16T00:00:00.000' AS DateTime), CAST(50000.00 AS Decimal(18, 2)), N'Planificado', CAST(775000.00 AS Decimal(18, 2)), CAST(725000.00 AS Decimal(18, 2)), NULL, NULL)
INSERT [dbo].[RESERVA] ([Id_Reserva], [Id_Cliente], [Id_Usuario], [Id_Presupuesto], [Fecha_Evento], [Monto_Senia], [Estado], [Costo_Total_Real], [Saldo_Pendiente], [Evaluacion_Personal], [Observaciones_Personal]) VALUES (6, 2, 1, 10, CAST(N'2026-11-07T00:00:00.000' AS DateTime), CAST(50000.00 AS Decimal(18, 2)), N'Finalizado', CAST(1900000.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 1, N'AA')
INSERT [dbo].[RESERVA] ([Id_Reserva], [Id_Cliente], [Id_Usuario], [Id_Presupuesto], [Fecha_Evento], [Monto_Senia], [Estado], [Costo_Total_Real], [Saldo_Pendiente], [Evaluacion_Personal], [Observaciones_Personal]) VALUES (7, 3, 1, 11, CAST(N'2026-12-09T00:00:00.000' AS DateTime), CAST(2.00 AS Decimal(18, 2)), N'Saldado', CAST(1042000.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), NULL, NULL)
INSERT [dbo].[RESERVA] ([Id_Reserva], [Id_Cliente], [Id_Usuario], [Id_Presupuesto], [Fecha_Evento], [Monto_Senia], [Estado], [Costo_Total_Real], [Saldo_Pendiente], [Evaluacion_Personal], [Observaciones_Personal]) VALUES (9, 4, 1, 13, CAST(N'2026-11-28T00:00:00.000' AS DateTime), CAST(900000.00 AS Decimal(18, 2)), N'Planificado', CAST(1680000.00 AS Decimal(18, 2)), CAST(780000.00 AS Decimal(18, 2)), NULL, NULL)
INSERT [dbo].[RESERVA] ([Id_Reserva], [Id_Cliente], [Id_Usuario], [Id_Presupuesto], [Fecha_Evento], [Monto_Senia], [Estado], [Costo_Total_Real], [Saldo_Pendiente], [Evaluacion_Personal], [Observaciones_Personal]) VALUES (10, 5, 1, 15, CAST(N'2026-12-20T00:00:00.000' AS DateTime), CAST(300000.00 AS Decimal(18, 2)), N'Saldado', CAST(2100000.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), NULL, NULL)
INSERT [dbo].[RESERVA] ([Id_Reserva], [Id_Cliente], [Id_Usuario], [Id_Presupuesto], [Fecha_Evento], [Monto_Senia], [Estado], [Costo_Total_Real], [Saldo_Pendiente], [Evaluacion_Personal], [Observaciones_Personal]) VALUES (11, 7, 1, 16, CAST(N'2026-11-20T00:00:00.000' AS DateTime), CAST(1000000.00 AS Decimal(18, 2)), N'Saldado', CAST(4200000.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), NULL, NULL)
INSERT [dbo].[RESERVA] ([Id_Reserva], [Id_Cliente], [Id_Usuario], [Id_Presupuesto], [Fecha_Evento], [Monto_Senia], [Estado], [Costo_Total_Real], [Saldo_Pendiente], [Evaluacion_Personal], [Observaciones_Personal]) VALUES (12, 6, 1, 17, CAST(N'2026-10-10T00:00:00.000' AS DateTime), CAST(200000.00 AS Decimal(18, 2)), N'Finalizado', CAST(850000.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 1, N'Excelente desempeño del personal de salón y cocina')
INSERT [dbo].[RESERVA] ([Id_Reserva], [Id_Cliente], [Id_Usuario], [Id_Presupuesto], [Fecha_Evento], [Monto_Senia], [Estado], [Costo_Total_Real], [Saldo_Pendiente], [Evaluacion_Personal], [Observaciones_Personal]) VALUES (13, 8, 1, 18, CAST(N'2025-03-15T00:00:00.000' AS DateTime), CAST(300000.00 AS Decimal(18, 2)), N'Finalizado', CAST(1550000.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 1, N'Excelente servicio en salón y cocina, el cliente quedó muy conforme.')
INSERT [dbo].[RESERVA] ([Id_Reserva], [Id_Cliente], [Id_Usuario], [Id_Presupuesto], [Fecha_Evento], [Monto_Senia], [Estado], [Costo_Total_Real], [Saldo_Pendiente], [Evaluacion_Personal], [Observaciones_Personal]) VALUES (14, 9, 1, 19, CAST(N'2025-05-20T00:00:00.000' AS DateTime), CAST(200000.00 AS Decimal(18, 2)), N'Finalizado', CAST(980000.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 1, N'Puntualidad perfecta del personal y muy buena predisposición.')
INSERT [dbo].[RESERVA] ([Id_Reserva], [Id_Cliente], [Id_Usuario], [Id_Presupuesto], [Fecha_Evento], [Monto_Senia], [Estado], [Costo_Total_Real], [Saldo_Pendiente], [Evaluacion_Personal], [Observaciones_Personal]) VALUES (15, 10, 1, 20, CAST(N'2025-08-12T00:00:00.000' AS DateTime), CAST(800000.00 AS Decimal(18, 2)), N'Finalizado', CAST(3350000.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 1, N'Evento corporativo masivo finalizado con éxito total.')
INSERT [dbo].[RESERVA] ([Id_Reserva], [Id_Cliente], [Id_Usuario], [Id_Presupuesto], [Fecha_Evento], [Monto_Senia], [Estado], [Costo_Total_Real], [Saldo_Pendiente], [Evaluacion_Personal], [Observaciones_Personal]) VALUES (16, 11, 1, 21, CAST(N'2025-11-05T00:00:00.000' AS DateTime), CAST(250000.00 AS Decimal(18, 2)), N'Finalizado', CAST(1120000.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 1, N'Servicio impecable en el timing de platos.')
INSERT [dbo].[RESERVA] ([Id_Reserva], [Id_Cliente], [Id_Usuario], [Id_Presupuesto], [Fecha_Evento], [Monto_Senia], [Estado], [Costo_Total_Real], [Saldo_Pendiente], [Evaluacion_Personal], [Observaciones_Personal]) VALUES (17, 12, 1, 22, CAST(N'2026-01-18T00:00:00.000' AS DateTime), CAST(200000.00 AS Decimal(18, 2)), N'Finalizado', CAST(820000.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 1, N'Casamiento íntimo sin contratiempos.')
INSERT [dbo].[RESERVA] ([Id_Reserva], [Id_Cliente], [Id_Usuario], [Id_Presupuesto], [Fecha_Evento], [Monto_Senia], [Estado], [Costo_Total_Real], [Saldo_Pendiente], [Evaluacion_Personal], [Observaciones_Personal]) VALUES (18, 8, 1, 23, CAST(N'2026-04-10T00:00:00.000' AS DateTime), CAST(400000.00 AS Decimal(18, 2)), N'Finalizado', CAST(1650000.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 1, N'Desempeño correcto de mozos y barman.')
INSERT [dbo].[RESERVA] ([Id_Reserva], [Id_Cliente], [Id_Usuario], [Id_Presupuesto], [Fecha_Evento], [Monto_Senia], [Estado], [Costo_Total_Real], [Saldo_Pendiente], [Evaluacion_Personal], [Observaciones_Personal]) VALUES (19, 13, 1, 24, CAST(N'2024-04-12T00:00:00.000' AS DateTime), CAST(200000.00 AS Decimal(18, 2)), N'Finalizado', CAST(1150000.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 1, N'Excelente organización y coordinación con salón.')
INSERT [dbo].[RESERVA] ([Id_Reserva], [Id_Cliente], [Id_Usuario], [Id_Presupuesto], [Fecha_Evento], [Monto_Senia], [Estado], [Costo_Total_Real], [Saldo_Pendiente], [Evaluacion_Personal], [Observaciones_Personal]) VALUES (20, 14, 1, 25, CAST(N'2024-06-22T00:00:00.000' AS DateTime), CAST(450000.00 AS Decimal(18, 2)), N'Finalizado', CAST(2250000.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 1, N'Gran servicio en barra y cocina.')
INSERT [dbo].[RESERVA] ([Id_Reserva], [Id_Cliente], [Id_Usuario], [Id_Presupuesto], [Fecha_Evento], [Monto_Senia], [Estado], [Costo_Total_Real], [Saldo_Pendiente], [Evaluacion_Personal], [Observaciones_Personal]) VALUES (21, 15, 1, 26, CAST(N'2024-09-15T00:00:00.000' AS DateTime), CAST(1000000.00 AS Decimal(18, 2)), N'Finalizado', CAST(4600000.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 1, N'Evento corporativo atendido impecablemente.')
INSERT [dbo].[RESERVA] ([Id_Reserva], [Id_Cliente], [Id_Usuario], [Id_Presupuesto], [Fecha_Evento], [Monto_Senia], [Estado], [Costo_Total_Real], [Saldo_Pendiente], [Evaluacion_Personal], [Observaciones_Personal]) VALUES (22, 16, 1, 27, CAST(N'2024-11-30T00:00:00.000' AS DateTime), CAST(150000.00 AS Decimal(18, 2)), N'Finalizado', CAST(780000.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 1, N'Atención personalizada de 10.')
INSERT [dbo].[RESERVA] ([Id_Reserva], [Id_Cliente], [Id_Usuario], [Id_Presupuesto], [Fecha_Evento], [Monto_Senia], [Estado], [Costo_Total_Real], [Saldo_Pendiente], [Evaluacion_Personal], [Observaciones_Personal]) VALUES (23, 17, 1, 28, CAST(N'2024-12-18T00:00:00.000' AS DateTime), CAST(800000.00 AS Decimal(18, 2)), N'Finalizado', CAST(3900000.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 1, N'Fiesta masiva finalizada con felicitación de directivos.')
INSERT [dbo].[RESERVA] ([Id_Reserva], [Id_Cliente], [Id_Usuario], [Id_Presupuesto], [Fecha_Evento], [Monto_Senia], [Estado], [Costo_Total_Real], [Saldo_Pendiente], [Evaluacion_Personal], [Observaciones_Personal]) VALUES (24, 18, 1, 29, CAST(N'2025-02-14T00:00:00.000' AS DateTime), CAST(300000.00 AS Decimal(18, 2)), N'Finalizado', CAST(1450000.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 1, N'Excelente ritmo de despacho de platos.')
INSERT [dbo].[RESERVA] ([Id_Reserva], [Id_Cliente], [Id_Usuario], [Id_Presupuesto], [Fecha_Evento], [Monto_Senia], [Estado], [Costo_Total_Real], [Saldo_Pendiente], [Evaluacion_Personal], [Observaciones_Personal]) VALUES (25, 19, 1, 30, CAST(N'2025-04-05T00:00:00.000' AS DateTime), CAST(350000.00 AS Decimal(18, 2)), N'Finalizado', CAST(1850000.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 1, N'Servicio impecable.')
INSERT [dbo].[RESERVA] ([Id_Reserva], [Id_Cliente], [Id_Usuario], [Id_Presupuesto], [Fecha_Evento], [Monto_Senia], [Estado], [Costo_Total_Real], [Saldo_Pendiente], [Evaluacion_Personal], [Observaciones_Personal]) VALUES (26, 20, 1, 31, CAST(N'2025-07-20T00:00:00.000' AS DateTime), CAST(600000.00 AS Decimal(18, 2)), N'Finalizado', CAST(2950000.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 1, N'Catering continuado tipo coctel muy elogiado.')
INSERT [dbo].[RESERVA] ([Id_Reserva], [Id_Cliente], [Id_Usuario], [Id_Presupuesto], [Fecha_Evento], [Monto_Senia], [Estado], [Costo_Total_Real], [Saldo_Pendiente], [Evaluacion_Personal], [Observaciones_Personal]) VALUES (27, 21, 1, 32, CAST(N'2025-10-12T00:00:00.000' AS DateTime), CAST(200000.00 AS Decimal(18, 2)), N'Finalizado', CAST(930000.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 1, N'Almuerzo familiar muy bien asistido.')
INSERT [dbo].[RESERVA] ([Id_Reserva], [Id_Cliente], [Id_Usuario], [Id_Presupuesto], [Fecha_Evento], [Monto_Senia], [Estado], [Costo_Total_Real], [Saldo_Pendiente], [Evaluacion_Personal], [Observaciones_Personal]) VALUES (28, 22, 1, 33, CAST(N'2026-02-28T00:00:00.000' AS DateTime), CAST(900000.00 AS Decimal(18, 2)), N'Finalizado', CAST(4200000.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 1, N'Gala Benéfica con 220 platos servidos sin demoras.')
INSERT [dbo].[RESERVA] ([Id_Reserva], [Id_Cliente], [Id_Usuario], [Id_Presupuesto], [Fecha_Evento], [Monto_Senia], [Estado], [Costo_Total_Real], [Saldo_Pendiente], [Evaluacion_Personal], [Observaciones_Personal]) VALUES (29, 23, 1, 34, CAST(N'2024-05-10T00:00:00.000' AS DateTime), CAST(350000.00 AS Decimal(18, 2)), N'Finalizado', CAST(1850000.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 0, N'Demoras excesivas en el servicio de platos. Falta de mozos en salón.')
INSERT [dbo].[RESERVA] ([Id_Reserva], [Id_Cliente], [Id_Usuario], [Id_Presupuesto], [Fecha_Evento], [Monto_Senia], [Estado], [Costo_Total_Real], [Saldo_Pendiente], [Evaluacion_Personal], [Observaciones_Personal]) VALUES (30, 24, 1, 35, CAST(N'2024-07-18T00:00:00.000' AS DateTime), CAST(200000.00 AS Decimal(18, 2)), N'Finalizado', CAST(1200000.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 0, N'Personal de cocina desbordado, salieron platos fríos a la mesa.')
INSERT [dbo].[RESERVA] ([Id_Reserva], [Id_Cliente], [Id_Usuario], [Id_Presupuesto], [Fecha_Evento], [Monto_Senia], [Estado], [Costo_Total_Real], [Saldo_Pendiente], [Evaluacion_Personal], [Observaciones_Personal]) VALUES (31, 25, 1, 36, CAST(N'2024-10-05T00:00:00.000' AS DateTime), CAST(1000000.00 AS Decimal(18, 2)), N'Finalizado', CAST(4300000.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 1, N'Servicio correcto y muy profesional en el área vip.')
INSERT [dbo].[RESERVA] ([Id_Reserva], [Id_Cliente], [Id_Usuario], [Id_Presupuesto], [Fecha_Evento], [Monto_Senia], [Estado], [Costo_Total_Real], [Saldo_Pendiente], [Evaluacion_Personal], [Observaciones_Personal]) VALUES (32, 26, 1, 37, CAST(N'2024-12-01T00:00:00.000' AS DateTime), CAST(400000.00 AS Decimal(18, 2)), N'Finalizado', CAST(1950000.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 0, N'Quejas de invitados por falta de atención en la barra y mesas sin despejar.')
INSERT [dbo].[RESERVA] ([Id_Reserva], [Id_Cliente], [Id_Usuario], [Id_Presupuesto], [Fecha_Evento], [Monto_Senia], [Estado], [Costo_Total_Real], [Saldo_Pendiente], [Evaluacion_Personal], [Observaciones_Personal]) VALUES (33, 27, 1, 38, CAST(N'2025-01-20T00:00:00.000' AS DateTime), CAST(600000.00 AS Decimal(18, 2)), N'Finalizado', CAST(3200000.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 0, N'Coordinación deficiente entre maitre y personal de recepción.')
INSERT [dbo].[RESERVA] ([Id_Reserva], [Id_Cliente], [Id_Usuario], [Id_Presupuesto], [Fecha_Evento], [Monto_Senia], [Estado], [Costo_Total_Real], [Saldo_Pendiente], [Evaluacion_Personal], [Observaciones_Personal]) VALUES (34, 28, 1, 39, CAST(N'2025-03-22T00:00:00.000' AS DateTime), CAST(300000.00 AS Decimal(18, 2)), N'Finalizado', CAST(1400000.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 1, N'Cumpleaños asistido en tiempo y forma.')
INSERT [dbo].[RESERVA] ([Id_Reserva], [Id_Cliente], [Id_Usuario], [Id_Presupuesto], [Fecha_Evento], [Monto_Senia], [Estado], [Costo_Total_Real], [Saldo_Pendiente], [Evaluacion_Personal], [Observaciones_Personal]) VALUES (35, 29, 1, 40, CAST(N'2025-06-14T00:00:00.000' AS DateTime), CAST(500000.00 AS Decimal(18, 2)), N'Finalizado', CAST(2150000.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 0, N'Cantidad insuficiente de mozos para cubrir las 16 mesas asignadas.')
INSERT [dbo].[RESERVA] ([Id_Reserva], [Id_Cliente], [Id_Usuario], [Id_Presupuesto], [Fecha_Evento], [Monto_Senia], [Estado], [Costo_Total_Real], [Saldo_Pendiente], [Evaluacion_Personal], [Observaciones_Personal]) VALUES (36, 30, 1, 41, CAST(N'2025-09-08T00:00:00.000' AS DateTime), CAST(800000.00 AS Decimal(18, 2)), N'Finalizado', CAST(4000000.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 0, N'Retrasos acumulados en el despacho del coffee break y almuerzo.')
INSERT [dbo].[RESERVA] ([Id_Reserva], [Id_Cliente], [Id_Usuario], [Id_Presupuesto], [Fecha_Evento], [Monto_Senia], [Estado], [Costo_Total_Real], [Saldo_Pendiente], [Evaluacion_Personal], [Observaciones_Personal]) VALUES (37, 31, 1, 42, CAST(N'2025-11-15T00:00:00.000' AS DateTime), CAST(200000.00 AS Decimal(18, 2)), N'Finalizado', CAST(880000.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 1, N'Buen ambiente y mozos bien predispuestos.')
INSERT [dbo].[RESERVA] ([Id_Reserva], [Id_Cliente], [Id_Usuario], [Id_Presupuesto], [Fecha_Evento], [Monto_Senia], [Estado], [Costo_Total_Real], [Saldo_Pendiente], [Evaluacion_Personal], [Observaciones_Personal]) VALUES (38, 32, 1, 43, CAST(N'2026-03-10T00:00:00.000' AS DateTime), CAST(700000.00 AS Decimal(18, 2)), N'Finalizado', CAST(3700000.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 0, N'Superada la capacidad del personal asignado para 200 invitados.')
INSERT [dbo].[RESERVA] ([Id_Reserva], [Id_Cliente], [Id_Usuario], [Id_Presupuesto], [Fecha_Evento], [Monto_Senia], [Estado], [Costo_Total_Real], [Saldo_Pendiente], [Evaluacion_Personal], [Observaciones_Personal]) VALUES (39, 33, 1, 44, CAST(N'2024-08-10T00:00:00.000' AS DateTime), CAST(400000.00 AS Decimal(18, 2)), N'Finalizado', CAST(2000000.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 0, N'Falta de mozos en las mesas de la recepción, atención demorada.')
INSERT [dbo].[RESERVA] ([Id_Reserva], [Id_Cliente], [Id_Usuario], [Id_Presupuesto], [Fecha_Evento], [Monto_Senia], [Estado], [Costo_Total_Real], [Saldo_Pendiente], [Evaluacion_Personal], [Observaciones_Personal]) VALUES (40, 34, 1, 45, CAST(N'2024-11-12T00:00:00.000' AS DateTime), CAST(200000.00 AS Decimal(18, 2)), N'Finalizado', CAST(990000.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 1, N'Excelente predisposición del personal y buena coordinación.')
INSERT [dbo].[RESERVA] ([Id_Reserva], [Id_Cliente], [Id_Usuario], [Id_Presupuesto], [Fecha_Evento], [Monto_Senia], [Estado], [Costo_Total_Real], [Saldo_Pendiente], [Evaluacion_Personal], [Observaciones_Personal]) VALUES (41, 35, 1, 46, CAST(N'2025-04-18T00:00:00.000' AS DateTime), CAST(700000.00 AS Decimal(18, 2)), N'Finalizado', CAST(3500000.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 0, N'Demoras considerables en el despacho de cocina para un volumen de 210 comensales.')
INSERT [dbo].[RESERVA] ([Id_Reserva], [Id_Cliente], [Id_Usuario], [Id_Presupuesto], [Fecha_Evento], [Monto_Senia], [Estado], [Costo_Total_Real], [Saldo_Pendiente], [Evaluacion_Personal], [Observaciones_Personal]) VALUES (42, 36, 1, 47, CAST(N'2025-08-22T00:00:00.000' AS DateTime), CAST(300000.00 AS Decimal(18, 2)), N'Finalizado', CAST(1280000.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 1, N'Servicio impecable y rápido.')
INSERT [dbo].[RESERVA] ([Id_Reserva], [Id_Cliente], [Id_Usuario], [Id_Presupuesto], [Fecha_Evento], [Monto_Senia], [Estado], [Costo_Total_Real], [Saldo_Pendiente], [Evaluacion_Personal], [Observaciones_Personal]) VALUES (43, 37, 1, 48, CAST(N'2026-01-15T00:00:00.000' AS DateTime), CAST(1000000.00 AS Decimal(18, 2)), N'Finalizado', CAST(4900000.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 0, N'Personal sobrepasado por la cantidad de comensales en la fiesta empresarial.')
INSERT [dbo].[RESERVA] ([Id_Reserva], [Id_Cliente], [Id_Usuario], [Id_Presupuesto], [Fecha_Evento], [Monto_Senia], [Estado], [Costo_Total_Real], [Saldo_Pendiente], [Evaluacion_Personal], [Observaciones_Personal]) VALUES (44, 38, 1, 49, CAST(N'2026-11-08T00:00:00.000' AS DateTime), CAST(900000.00 AS Decimal(18, 2)), N'Finalizado', CAST(2100000.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 1, N'A')
INSERT [dbo].[RESERVA] ([Id_Reserva], [Id_Cliente], [Id_Usuario], [Id_Presupuesto], [Fecha_Evento], [Monto_Senia], [Estado], [Costo_Total_Real], [Saldo_Pendiente], [Evaluacion_Personal], [Observaciones_Personal]) VALUES (45, 38, 1, 50, CAST(N'2026-11-14T00:00:00.000' AS DateTime), CAST(850000.00 AS Decimal(18, 2)), N'Finalizado', CAST(1587500.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 1, N'personas piolas')
INSERT [dbo].[RESERVA] ([Id_Reserva], [Id_Cliente], [Id_Usuario], [Id_Presupuesto], [Fecha_Evento], [Monto_Senia], [Estado], [Costo_Total_Real], [Saldo_Pendiente], [Evaluacion_Personal], [Observaciones_Personal]) VALUES (47, 4, 1, 52, CAST(N'2026-11-03T00:00:00.000' AS DateTime), CAST(250000.00 AS Decimal(18, 2)), N'Finalizado', CAST(1500000.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 0, N'no me gusto')
INSERT [dbo].[RESERVA] ([Id_Reserva], [Id_Cliente], [Id_Usuario], [Id_Presupuesto], [Fecha_Evento], [Monto_Senia], [Estado], [Costo_Total_Real], [Saldo_Pendiente], [Evaluacion_Personal], [Observaciones_Personal]) VALUES (49, 43, 1, 54, CAST(N'2026-06-15T00:00:00.000' AS DateTime), CAST(400000.00 AS Decimal(18, 2)), N'Finalizado', CAST(1820000.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 0, N'Demoras en la entrega de bebidas durante el plato principal.')
INSERT [dbo].[RESERVA] ([Id_Reserva], [Id_Cliente], [Id_Usuario], [Id_Presupuesto], [Fecha_Evento], [Monto_Senia], [Estado], [Costo_Total_Real], [Saldo_Pendiente], [Evaluacion_Personal], [Observaciones_Personal]) VALUES (50, 44, 1, 55, CAST(N'2026-07-10T00:00:00.000' AS DateTime), CAST(500000.00 AS Decimal(18, 2)), N'Finalizado', CAST(2450000.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 1, N'Servicio impecable, excelente atención de mozos y puntualidad en la salida de platos.')
INSERT [dbo].[RESERVA] ([Id_Reserva], [Id_Cliente], [Id_Usuario], [Id_Presupuesto], [Fecha_Evento], [Monto_Senia], [Estado], [Costo_Total_Real], [Saldo_Pendiente], [Evaluacion_Personal], [Observaciones_Personal]) VALUES (51, 45, 1, 56, CAST(N'2026-08-20T00:00:00.000' AS DateTime), CAST(300000.00 AS Decimal(18, 2)), N'Finalizado', CAST(1320000.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 1, N'Coordinación brillante del evento y gran predisposición del personal de salón.')
INSERT [dbo].[RESERVA] ([Id_Reserva], [Id_Cliente], [Id_Usuario], [Id_Presupuesto], [Fecha_Evento], [Monto_Senia], [Estado], [Costo_Total_Real], [Saldo_Pendiente], [Evaluacion_Personal], [Observaciones_Personal]) VALUES (52, 46, 1, 57, CAST(N'2026-09-12T00:00:00.000' AS DateTime), CAST(1000000.00 AS Decimal(18, 2)), N'Finalizado', CAST(4250000.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 1, N'Organización perfecta para volumen alto de comensales. Felicitaciones expresas del cliente.')
INSERT [dbo].[RESERVA] ([Id_Reserva], [Id_Cliente], [Id_Usuario], [Id_Presupuesto], [Fecha_Evento], [Monto_Senia], [Estado], [Costo_Total_Real], [Saldo_Pendiente], [Evaluacion_Personal], [Observaciones_Personal]) VALUES (53, 47, 1, 58, CAST(N'2026-10-05T00:00:00.000' AS DateTime), CAST(400000.00 AS Decimal(18, 2)), N'Finalizado', CAST(1630000.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 1, N'Atención personalizada de excelencia, tiempo de respuesta en cocina sobresaliente.')
INSERT [dbo].[RESERVA] ([Id_Reserva], [Id_Cliente], [Id_Usuario], [Id_Presupuesto], [Fecha_Evento], [Monto_Senia], [Estado], [Costo_Total_Real], [Saldo_Pendiente], [Evaluacion_Personal], [Observaciones_Personal]) VALUES (54, 48, 1, 59, CAST(N'2026-10-25T00:00:00.000' AS DateTime), CAST(800000.00 AS Decimal(18, 2)), N'Finalizado', CAST(3850000.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 1, N'Despliegue de brigada de cocina y mozos totalmente sincronizado.')
INSERT [dbo].[RESERVA] ([Id_Reserva], [Id_Cliente], [Id_Usuario], [Id_Presupuesto], [Fecha_Evento], [Monto_Senia], [Estado], [Costo_Total_Real], [Saldo_Pendiente], [Evaluacion_Personal], [Observaciones_Personal]) VALUES (55, 49, 1, 60, CAST(N'2026-11-10T00:00:00.000' AS DateTime), CAST(450000.00 AS Decimal(18, 2)), N'Finalizado', CAST(2150000.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 0, N'Falta de coordinación en la entrada de platos y faltante de personal de salón.')
INSERT [dbo].[RESERVA] ([Id_Reserva], [Id_Cliente], [Id_Usuario], [Id_Presupuesto], [Fecha_Evento], [Monto_Senia], [Estado], [Costo_Total_Real], [Saldo_Pendiente], [Evaluacion_Personal], [Observaciones_Personal]) VALUES (56, 50, 1, 61, CAST(N'2026-11-20T00:00:00.000' AS DateTime), CAST(250000.00 AS Decimal(18, 2)), N'Finalizado', CAST(1120000.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 0, N'Quejas por demora en la barra de tragos y falta de vajilla limpia durante el evento.')
INSERT [dbo].[RESERVA] ([Id_Reserva], [Id_Cliente], [Id_Usuario], [Id_Presupuesto], [Fecha_Evento], [Monto_Senia], [Estado], [Costo_Total_Real], [Saldo_Pendiente], [Evaluacion_Personal], [Observaciones_Personal]) VALUES (57, 51, 1, 62, CAST(N'2026-12-05T00:00:00.000' AS DateTime), CAST(1200000.00 AS Decimal(18, 2)), N'Finalizado', CAST(5250000.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 0, N'Insuficiente cantidad de mozos para atender a 300 personas y errores en la entrega del menú especial.')
INSERT [dbo].[RESERVA] ([Id_Reserva], [Id_Cliente], [Id_Usuario], [Id_Presupuesto], [Fecha_Evento], [Monto_Senia], [Estado], [Costo_Total_Real], [Saldo_Pendiente], [Evaluacion_Personal], [Observaciones_Personal]) VALUES (1055, 5, 1, 14, CAST(N'2026-12-15T00:00:00.000' AS DateTime), CAST(900000.00 AS Decimal(18, 2)), N'Confirmada', NULL, NULL, NULL, NULL)
INSERT [dbo].[RESERVA] ([Id_Reserva], [Id_Cliente], [Id_Usuario], [Id_Presupuesto], [Fecha_Evento], [Monto_Senia], [Estado], [Costo_Total_Real], [Saldo_Pendiente], [Evaluacion_Personal], [Observaciones_Personal]) VALUES (1056, 51, 1, 1060, CAST(N'2027-01-01T00:00:00.000' AS DateTime), CAST(1000000.00 AS Decimal(18, 2)), N'Saldado', CAST(2500000.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), NULL, NULL)
INSERT [dbo].[RESERVA] ([Id_Reserva], [Id_Cliente], [Id_Usuario], [Id_Presupuesto], [Fecha_Evento], [Monto_Senia], [Estado], [Costo_Total_Real], [Saldo_Pendiente], [Evaluacion_Personal], [Observaciones_Personal]) VALUES (1057, 1, 1, 3, CAST(N'2026-10-25T00:22:50.430' AS DateTime), CAST(7500000.00 AS Decimal(18, 2)), N'Confirmada', NULL, NULL, NULL, NULL)
INSERT [dbo].[RESERVA] ([Id_Reserva], [Id_Cliente], [Id_Usuario], [Id_Presupuesto], [Fecha_Evento], [Monto_Senia], [Estado], [Costo_Total_Real], [Saldo_Pendiente], [Evaluacion_Personal], [Observaciones_Personal]) VALUES (1058, 1, 1, 5, CAST(N'2026-10-25T00:22:50.430' AS DateTime), CAST(32000.00 AS Decimal(18, 2)), N'Confirmada', NULL, NULL, NULL, NULL)
INSERT [dbo].[RESERVA] ([Id_Reserva], [Id_Cliente], [Id_Usuario], [Id_Presupuesto], [Fecha_Evento], [Monto_Senia], [Estado], [Costo_Total_Real], [Saldo_Pendiente], [Evaluacion_Personal], [Observaciones_Personal]) VALUES (1059, 1, 1, 6, CAST(N'2026-10-31T00:00:00.000' AS DateTime), CAST(150000.00 AS Decimal(18, 2)), N'Confirmada', NULL, NULL, NULL, NULL)
INSERT [dbo].[RESERVA] ([Id_Reserva], [Id_Cliente], [Id_Usuario], [Id_Presupuesto], [Fecha_Evento], [Monto_Senia], [Estado], [Costo_Total_Real], [Saldo_Pendiente], [Evaluacion_Personal], [Observaciones_Personal]) VALUES (1060, 1, 1, 7, CAST(N'2026-10-31T00:00:00.000' AS DateTime), CAST(100.00 AS Decimal(18, 2)), N'Confirmada', NULL, NULL, NULL, NULL)
INSERT [dbo].[RESERVA] ([Id_Reserva], [Id_Cliente], [Id_Usuario], [Id_Presupuesto], [Fecha_Evento], [Monto_Senia], [Estado], [Costo_Total_Real], [Saldo_Pendiente], [Evaluacion_Personal], [Observaciones_Personal]) VALUES (1061, 2, 1, 8, CAST(N'2028-02-26T00:00:00.000' AS DateTime), CAST(10.00 AS Decimal(18, 2)), N'Confirmada', NULL, NULL, NULL, NULL)
INSERT [dbo].[RESERVA] ([Id_Reserva], [Id_Cliente], [Id_Usuario], [Id_Presupuesto], [Fecha_Evento], [Monto_Senia], [Estado], [Costo_Total_Real], [Saldo_Pendiente], [Evaluacion_Personal], [Observaciones_Personal]) VALUES (1062, 36, 1, 1061, CAST(N'2026-11-29T00:00:00.000' AS DateTime), CAST(300000.00 AS Decimal(18, 2)), N'Saldado', CAST(1950000.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), NULL, NULL)
INSERT [dbo].[RESERVA] ([Id_Reserva], [Id_Cliente], [Id_Usuario], [Id_Presupuesto], [Fecha_Evento], [Monto_Senia], [Estado], [Costo_Total_Real], [Saldo_Pendiente], [Evaluacion_Personal], [Observaciones_Personal]) VALUES (1063, 52, 1, 1062, CAST(N'2026-10-27T00:00:00.000' AS DateTime), CAST(393750.00 AS Decimal(18, 2)), N'Finalizado', CAST(1625000.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 1, N'Excelente atención y coordinación general.')
INSERT [dbo].[RESERVA] ([Id_Reserva], [Id_Cliente], [Id_Usuario], [Id_Presupuesto], [Fecha_Evento], [Monto_Senia], [Estado], [Costo_Total_Real], [Saldo_Pendiente], [Evaluacion_Personal], [Observaciones_Personal]) VALUES (1064, 53, 1, 1063, CAST(N'2026-10-24T00:00:00.000' AS DateTime), CAST(487500.00 AS Decimal(18, 2)), N'Finalizado', CAST(2000000.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 1, N'Servicio sobresaliente, personal muy atento y predispuesto durante toda la jornada.')
INSERT [dbo].[RESERVA] ([Id_Reserva], [Id_Cliente], [Id_Usuario], [Id_Presupuesto], [Fecha_Evento], [Monto_Senia], [Estado], [Costo_Total_Real], [Saldo_Pendiente], [Evaluacion_Personal], [Observaciones_Personal]) VALUES (1065, 54, 1, 1064, CAST(N'2026-10-21T00:00:00.000' AS DateTime), CAST(581250.00 AS Decimal(18, 2)), N'Finalizado', CAST(2375000.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 1, N'Organización perfecta, el equipo de salón y recepción superó las expectativas.')
INSERT [dbo].[RESERVA] ([Id_Reserva], [Id_Cliente], [Id_Usuario], [Id_Presupuesto], [Fecha_Evento], [Monto_Senia], [Estado], [Costo_Total_Real], [Saldo_Pendiente], [Evaluacion_Personal], [Observaciones_Personal]) VALUES (1066, 55, 1, 1065, CAST(N'2026-10-18T00:00:00.000' AS DateTime), CAST(675000.00 AS Decimal(18, 2)), N'Finalizado', CAST(2750000.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 1, N'Excelente atención de los mozos y tiempos impecables en el servicio de salón.')
INSERT [dbo].[RESERVA] ([Id_Reserva], [Id_Cliente], [Id_Usuario], [Id_Presupuesto], [Fecha_Evento], [Monto_Senia], [Estado], [Costo_Total_Real], [Saldo_Pendiente], [Evaluacion_Personal], [Observaciones_Personal]) VALUES (1067, 56, 1, 1066, CAST(N'2026-10-15T00:00:00.000' AS DateTime), CAST(300000.00 AS Decimal(18, 2)), N'Finalizado', CAST(1250000.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 1, N'Muy buena coordinación general del personal y rapidez en el despacho de cocina.')
INSERT [dbo].[RESERVA] ([Id_Reserva], [Id_Cliente], [Id_Usuario], [Id_Presupuesto], [Fecha_Evento], [Monto_Senia], [Estado], [Costo_Total_Real], [Saldo_Pendiente], [Evaluacion_Personal], [Observaciones_Personal]) VALUES (1068, 57, 1, 1067, CAST(N'2026-10-12T00:00:00.000' AS DateTime), CAST(393750.00 AS Decimal(18, 2)), N'Finalizado', CAST(1625000.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 1, N'Servicio sobresaliente, personal muy atento y predispuesto durante toda la jornada.')
INSERT [dbo].[RESERVA] ([Id_Reserva], [Id_Cliente], [Id_Usuario], [Id_Presupuesto], [Fecha_Evento], [Monto_Senia], [Estado], [Costo_Total_Real], [Saldo_Pendiente], [Evaluacion_Personal], [Observaciones_Personal]) VALUES (1069, 58, 1, 1068, CAST(N'2026-10-09T00:00:00.000' AS DateTime), CAST(487500.00 AS Decimal(18, 2)), N'Finalizado', CAST(2000000.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 1, N'Organización perfecta, el equipo de salón y recepción superó las expectativas.')
INSERT [dbo].[RESERVA] ([Id_Reserva], [Id_Cliente], [Id_Usuario], [Id_Presupuesto], [Fecha_Evento], [Monto_Senia], [Estado], [Costo_Total_Real], [Saldo_Pendiente], [Evaluacion_Personal], [Observaciones_Personal]) VALUES (1070, 59, 1, 1069, CAST(N'2026-10-06T00:00:00.000' AS DateTime), CAST(581250.00 AS Decimal(18, 2)), N'Finalizado', CAST(2375000.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 1, N'Excelente atención de los mozos y tiempos impecables en el servicio de salón.')
INSERT [dbo].[RESERVA] ([Id_Reserva], [Id_Cliente], [Id_Usuario], [Id_Presupuesto], [Fecha_Evento], [Monto_Senia], [Estado], [Costo_Total_Real], [Saldo_Pendiente], [Evaluacion_Personal], [Observaciones_Personal]) VALUES (1071, 60, 1, 1070, CAST(N'2026-10-03T00:00:00.000' AS DateTime), CAST(675000.00 AS Decimal(18, 2)), N'Finalizado', CAST(2750000.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 1, N'Muy buena coordinación general del personal y rapidez en el despacho de cocina.')
INSERT [dbo].[RESERVA] ([Id_Reserva], [Id_Cliente], [Id_Usuario], [Id_Presupuesto], [Fecha_Evento], [Monto_Senia], [Estado], [Costo_Total_Real], [Saldo_Pendiente], [Evaluacion_Personal], [Observaciones_Personal]) VALUES (1072, 61, 1, 1071, CAST(N'2026-09-30T00:00:00.000' AS DateTime), CAST(300000.00 AS Decimal(18, 2)), N'Finalizado', CAST(1250000.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 1, N'Servicio sobresaliente, personal muy atento y predispuesto durante toda la jornada.')
INSERT [dbo].[RESERVA] ([Id_Reserva], [Id_Cliente], [Id_Usuario], [Id_Presupuesto], [Fecha_Evento], [Monto_Senia], [Estado], [Costo_Total_Real], [Saldo_Pendiente], [Evaluacion_Personal], [Observaciones_Personal]) VALUES (1073, 62, 1, 1072, CAST(N'2026-09-27T00:00:00.000' AS DateTime), CAST(393750.00 AS Decimal(18, 2)), N'Finalizado', CAST(1625000.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 1, N'Organización perfecta, el equipo de salón y recepción superó las expectativas.')
INSERT [dbo].[RESERVA] ([Id_Reserva], [Id_Cliente], [Id_Usuario], [Id_Presupuesto], [Fecha_Evento], [Monto_Senia], [Estado], [Costo_Total_Real], [Saldo_Pendiente], [Evaluacion_Personal], [Observaciones_Personal]) VALUES (1074, 63, 1, 1073, CAST(N'2026-09-24T00:00:00.000' AS DateTime), CAST(487500.00 AS Decimal(18, 2)), N'Finalizado', CAST(2000000.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 1, N'Excelente atención de los mozos y tiempos impecables en el servicio de salón.')
INSERT [dbo].[RESERVA] ([Id_Reserva], [Id_Cliente], [Id_Usuario], [Id_Presupuesto], [Fecha_Evento], [Monto_Senia], [Estado], [Costo_Total_Real], [Saldo_Pendiente], [Evaluacion_Personal], [Observaciones_Personal]) VALUES (1075, 64, 1, 1074, CAST(N'2026-09-21T00:00:00.000' AS DateTime), CAST(581250.00 AS Decimal(18, 2)), N'Finalizado', CAST(2375000.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 1, N'Muy buena coordinación general del personal y rapidez en el despacho de cocina.')
INSERT [dbo].[RESERVA] ([Id_Reserva], [Id_Cliente], [Id_Usuario], [Id_Presupuesto], [Fecha_Evento], [Monto_Senia], [Estado], [Costo_Total_Real], [Saldo_Pendiente], [Evaluacion_Personal], [Observaciones_Personal]) VALUES (1076, 65, 1, 1075, CAST(N'2026-09-18T00:00:00.000' AS DateTime), CAST(675000.00 AS Decimal(18, 2)), N'Finalizado', CAST(2750000.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 1, N'Servicio sobresaliente, personal muy atento y predispuesto durante toda la jornada.')
INSERT [dbo].[RESERVA] ([Id_Reserva], [Id_Cliente], [Id_Usuario], [Id_Presupuesto], [Fecha_Evento], [Monto_Senia], [Estado], [Costo_Total_Real], [Saldo_Pendiente], [Evaluacion_Personal], [Observaciones_Personal]) VALUES (1077, 66, 1, 1076, CAST(N'2026-09-15T00:00:00.000' AS DateTime), CAST(300000.00 AS Decimal(18, 2)), N'Finalizado', CAST(1250000.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 1, N'Organización perfecta, el equipo de salón y recepción superó las expectativas.')
INSERT [dbo].[RESERVA] ([Id_Reserva], [Id_Cliente], [Id_Usuario], [Id_Presupuesto], [Fecha_Evento], [Monto_Senia], [Estado], [Costo_Total_Real], [Saldo_Pendiente], [Evaluacion_Personal], [Observaciones_Personal]) VALUES (1078, 67, 1, 1077, CAST(N'2026-09-12T00:00:00.000' AS DateTime), CAST(393750.00 AS Decimal(18, 2)), N'Finalizado', CAST(1625000.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 1, N'Excelente atención de los mozos y tiempos impecables en el servicio de salón.')
INSERT [dbo].[RESERVA] ([Id_Reserva], [Id_Cliente], [Id_Usuario], [Id_Presupuesto], [Fecha_Evento], [Monto_Senia], [Estado], [Costo_Total_Real], [Saldo_Pendiente], [Evaluacion_Personal], [Observaciones_Personal]) VALUES (1079, 68, 1, 1078, CAST(N'2026-09-09T00:00:00.000' AS DateTime), CAST(487500.00 AS Decimal(18, 2)), N'Finalizado', CAST(2000000.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 1, N'Muy buena coordinación general del personal y rapidez en el despacho de cocina.')
INSERT [dbo].[RESERVA] ([Id_Reserva], [Id_Cliente], [Id_Usuario], [Id_Presupuesto], [Fecha_Evento], [Monto_Senia], [Estado], [Costo_Total_Real], [Saldo_Pendiente], [Evaluacion_Personal], [Observaciones_Personal]) VALUES (1080, 69, 1, 1079, CAST(N'2026-09-06T00:00:00.000' AS DateTime), CAST(581250.00 AS Decimal(18, 2)), N'Finalizado', CAST(2375000.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 1, N'Servicio sobresaliente, personal muy atento y predispuesto durante toda la jornada.')
INSERT [dbo].[RESERVA] ([Id_Reserva], [Id_Cliente], [Id_Usuario], [Id_Presupuesto], [Fecha_Evento], [Monto_Senia], [Estado], [Costo_Total_Real], [Saldo_Pendiente], [Evaluacion_Personal], [Observaciones_Personal]) VALUES (1081, 70, 1, 1080, CAST(N'2026-09-03T00:00:00.000' AS DateTime), CAST(675000.00 AS Decimal(18, 2)), N'Finalizado', CAST(2750000.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 1, N'Organización perfecta, el equipo de salón y recepción superó las expectativas.')
INSERT [dbo].[RESERVA] ([Id_Reserva], [Id_Cliente], [Id_Usuario], [Id_Presupuesto], [Fecha_Evento], [Monto_Senia], [Estado], [Costo_Total_Real], [Saldo_Pendiente], [Evaluacion_Personal], [Observaciones_Personal]) VALUES (1082, 71, 1, 1081, CAST(N'2026-08-31T00:00:00.000' AS DateTime), CAST(300000.00 AS Decimal(18, 2)), N'Finalizado', CAST(1250000.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 1, N'Excelente atención de los mozos y tiempos impecables en el servicio de salón.')
INSERT [dbo].[RESERVA] ([Id_Reserva], [Id_Cliente], [Id_Usuario], [Id_Presupuesto], [Fecha_Evento], [Monto_Senia], [Estado], [Costo_Total_Real], [Saldo_Pendiente], [Evaluacion_Personal], [Observaciones_Personal]) VALUES (1083, 72, 1, 1082, CAST(N'2026-08-28T00:00:00.000' AS DateTime), CAST(393750.00 AS Decimal(18, 2)), N'Finalizado', CAST(1625000.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 1, N'Muy buena coordinación general del personal y rapidez en el despacho de cocina.')
INSERT [dbo].[RESERVA] ([Id_Reserva], [Id_Cliente], [Id_Usuario], [Id_Presupuesto], [Fecha_Evento], [Monto_Senia], [Estado], [Costo_Total_Real], [Saldo_Pendiente], [Evaluacion_Personal], [Observaciones_Personal]) VALUES (1084, 73, 1, 1083, CAST(N'2026-08-25T00:00:00.000' AS DateTime), CAST(487500.00 AS Decimal(18, 2)), N'Finalizado', CAST(2000000.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 1, N'Servicio sobresaliente, personal muy atento y predispuesto durante toda la jornada.')
INSERT [dbo].[RESERVA] ([Id_Reserva], [Id_Cliente], [Id_Usuario], [Id_Presupuesto], [Fecha_Evento], [Monto_Senia], [Estado], [Costo_Total_Real], [Saldo_Pendiente], [Evaluacion_Personal], [Observaciones_Personal]) VALUES (1085, 74, 1, 1084, CAST(N'2026-08-22T00:00:00.000' AS DateTime), CAST(581250.00 AS Decimal(18, 2)), N'Finalizado', CAST(2375000.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 1, N'Organización perfecta, el equipo de salón y recepción superó las expectativas.')
INSERT [dbo].[RESERVA] ([Id_Reserva], [Id_Cliente], [Id_Usuario], [Id_Presupuesto], [Fecha_Evento], [Monto_Senia], [Estado], [Costo_Total_Real], [Saldo_Pendiente], [Evaluacion_Personal], [Observaciones_Personal]) VALUES (1086, 75, 1, 1085, CAST(N'2026-08-19T00:00:00.000' AS DateTime), CAST(675000.00 AS Decimal(18, 2)), N'Finalizado', CAST(2750000.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 1, N'Excelente atención de los mozos y tiempos impecables en el servicio de salón.')
INSERT [dbo].[RESERVA] ([Id_Reserva], [Id_Cliente], [Id_Usuario], [Id_Presupuesto], [Fecha_Evento], [Monto_Senia], [Estado], [Costo_Total_Real], [Saldo_Pendiente], [Evaluacion_Personal], [Observaciones_Personal]) VALUES (1087, 76, 1, 1086, CAST(N'2026-08-16T00:00:00.000' AS DateTime), CAST(300000.00 AS Decimal(18, 2)), N'Finalizado', CAST(1250000.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 1, N'Muy buena coordinación general del personal y rapidez en el despacho de cocina.')
INSERT [dbo].[RESERVA] ([Id_Reserva], [Id_Cliente], [Id_Usuario], [Id_Presupuesto], [Fecha_Evento], [Monto_Senia], [Estado], [Costo_Total_Real], [Saldo_Pendiente], [Evaluacion_Personal], [Observaciones_Personal]) VALUES (1088, 77, 1, 1087, CAST(N'2026-08-13T00:00:00.000' AS DateTime), CAST(393750.00 AS Decimal(18, 2)), N'Finalizado', CAST(1625000.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 1, N'Servicio sobresaliente, personal muy atento y predispuesto durante toda la jornada.')
INSERT [dbo].[RESERVA] ([Id_Reserva], [Id_Cliente], [Id_Usuario], [Id_Presupuesto], [Fecha_Evento], [Monto_Senia], [Estado], [Costo_Total_Real], [Saldo_Pendiente], [Evaluacion_Personal], [Observaciones_Personal]) VALUES (1089, 78, 1, 1088, CAST(N'2026-08-10T00:00:00.000' AS DateTime), CAST(487500.00 AS Decimal(18, 2)), N'Finalizado', CAST(2000000.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 1, N'Organización perfecta, el equipo de salón y recepción superó las expectativas.')
INSERT [dbo].[RESERVA] ([Id_Reserva], [Id_Cliente], [Id_Usuario], [Id_Presupuesto], [Fecha_Evento], [Monto_Senia], [Estado], [Costo_Total_Real], [Saldo_Pendiente], [Evaluacion_Personal], [Observaciones_Personal]) VALUES (1090, 79, 1, 1089, CAST(N'2026-08-07T00:00:00.000' AS DateTime), CAST(581250.00 AS Decimal(18, 2)), N'Finalizado', CAST(2375000.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 1, N'Excelente atención de los mozos y tiempos impecables en el servicio de salón.')
INSERT [dbo].[RESERVA] ([Id_Reserva], [Id_Cliente], [Id_Usuario], [Id_Presupuesto], [Fecha_Evento], [Monto_Senia], [Estado], [Costo_Total_Real], [Saldo_Pendiente], [Evaluacion_Personal], [Observaciones_Personal]) VALUES (1091, 80, 1, 1090, CAST(N'2026-08-04T00:00:00.000' AS DateTime), CAST(675000.00 AS Decimal(18, 2)), N'Finalizado', CAST(2750000.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 1, N'Muy buena coordinación general del personal y rapidez en el despacho de cocina.')
INSERT [dbo].[RESERVA] ([Id_Reserva], [Id_Cliente], [Id_Usuario], [Id_Presupuesto], [Fecha_Evento], [Monto_Senia], [Estado], [Costo_Total_Real], [Saldo_Pendiente], [Evaluacion_Personal], [Observaciones_Personal]) VALUES (1092, 81, 1, 1091, CAST(N'2026-08-01T00:00:00.000' AS DateTime), CAST(300000.00 AS Decimal(18, 2)), N'Finalizado', CAST(1250000.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 1, N'Servicio sobresaliente, personal muy atento y predispuesto durante toda la jornada.')
INSERT [dbo].[RESERVA] ([Id_Reserva], [Id_Cliente], [Id_Usuario], [Id_Presupuesto], [Fecha_Evento], [Monto_Senia], [Estado], [Costo_Total_Real], [Saldo_Pendiente], [Evaluacion_Personal], [Observaciones_Personal]) VALUES (1093, 82, 1, 1092, CAST(N'2026-07-29T00:00:00.000' AS DateTime), CAST(393750.00 AS Decimal(18, 2)), N'Finalizado', CAST(1625000.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 1, N'Organización perfecta, el equipo de salón y recepción superó las expectativas.')
INSERT [dbo].[RESERVA] ([Id_Reserva], [Id_Cliente], [Id_Usuario], [Id_Presupuesto], [Fecha_Evento], [Monto_Senia], [Estado], [Costo_Total_Real], [Saldo_Pendiente], [Evaluacion_Personal], [Observaciones_Personal]) VALUES (1094, 83, 1, 1093, CAST(N'2026-07-26T00:00:00.000' AS DateTime), CAST(487500.00 AS Decimal(18, 2)), N'Finalizado', CAST(2000000.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 1, N'Excelente atención de los mozos y tiempos impecables en el servicio de salón.')
INSERT [dbo].[RESERVA] ([Id_Reserva], [Id_Cliente], [Id_Usuario], [Id_Presupuesto], [Fecha_Evento], [Monto_Senia], [Estado], [Costo_Total_Real], [Saldo_Pendiente], [Evaluacion_Personal], [Observaciones_Personal]) VALUES (1095, 84, 1, 1094, CAST(N'2026-07-23T00:00:00.000' AS DateTime), CAST(581250.00 AS Decimal(18, 2)), N'Finalizado', CAST(2375000.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 1, N'Muy buena coordinación general del personal y rapidez en el despacho de cocina.')
INSERT [dbo].[RESERVA] ([Id_Reserva], [Id_Cliente], [Id_Usuario], [Id_Presupuesto], [Fecha_Evento], [Monto_Senia], [Estado], [Costo_Total_Real], [Saldo_Pendiente], [Evaluacion_Personal], [Observaciones_Personal]) VALUES (1096, 85, 1, 1095, CAST(N'2026-07-20T00:00:00.000' AS DateTime), CAST(675000.00 AS Decimal(18, 2)), N'Finalizado', CAST(2750000.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 1, N'Servicio sobresaliente, personal muy atento y predispuesto durante toda la jornada.')
INSERT [dbo].[RESERVA] ([Id_Reserva], [Id_Cliente], [Id_Usuario], [Id_Presupuesto], [Fecha_Evento], [Monto_Senia], [Estado], [Costo_Total_Real], [Saldo_Pendiente], [Evaluacion_Personal], [Observaciones_Personal]) VALUES (1097, 86, 1, 1096, CAST(N'2026-07-17T00:00:00.000' AS DateTime), CAST(300000.00 AS Decimal(18, 2)), N'Finalizado', CAST(1250000.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 1, N'Organización perfecta, el equipo de salón y recepción superó las expectativas.')
INSERT [dbo].[RESERVA] ([Id_Reserva], [Id_Cliente], [Id_Usuario], [Id_Presupuesto], [Fecha_Evento], [Monto_Senia], [Estado], [Costo_Total_Real], [Saldo_Pendiente], [Evaluacion_Personal], [Observaciones_Personal]) VALUES (1098, 87, 1, 1097, CAST(N'2026-07-14T00:00:00.000' AS DateTime), CAST(393750.00 AS Decimal(18, 2)), N'Finalizado', CAST(1625000.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 1, N'Excelente atención de los mozos y tiempos impecables en el servicio de salón.')
INSERT [dbo].[RESERVA] ([Id_Reserva], [Id_Cliente], [Id_Usuario], [Id_Presupuesto], [Fecha_Evento], [Monto_Senia], [Estado], [Costo_Total_Real], [Saldo_Pendiente], [Evaluacion_Personal], [Observaciones_Personal]) VALUES (1099, 88, 1, 1098, CAST(N'2026-07-11T00:00:00.000' AS DateTime), CAST(487500.00 AS Decimal(18, 2)), N'Finalizado', CAST(2000000.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 1, N'Muy buena coordinación general del personal y rapidez en el despacho de cocina.')
INSERT [dbo].[RESERVA] ([Id_Reserva], [Id_Cliente], [Id_Usuario], [Id_Presupuesto], [Fecha_Evento], [Monto_Senia], [Estado], [Costo_Total_Real], [Saldo_Pendiente], [Evaluacion_Personal], [Observaciones_Personal]) VALUES (1100, 89, 1, 1099, CAST(N'2026-07-08T00:00:00.000' AS DateTime), CAST(581250.00 AS Decimal(18, 2)), N'Finalizado', CAST(2375000.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 1, N'Servicio sobresaliente, personal muy atento y predispuesto durante toda la jornada.')
INSERT [dbo].[RESERVA] ([Id_Reserva], [Id_Cliente], [Id_Usuario], [Id_Presupuesto], [Fecha_Evento], [Monto_Senia], [Estado], [Costo_Total_Real], [Saldo_Pendiente], [Evaluacion_Personal], [Observaciones_Personal]) VALUES (1101, 90, 1, 1100, CAST(N'2026-07-05T00:00:00.000' AS DateTime), CAST(675000.00 AS Decimal(18, 2)), N'Finalizado', CAST(2750000.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 1, N'Organización perfecta, el equipo de salón y recepción superó las expectativas.')
INSERT [dbo].[RESERVA] ([Id_Reserva], [Id_Cliente], [Id_Usuario], [Id_Presupuesto], [Fecha_Evento], [Monto_Senia], [Estado], [Costo_Total_Real], [Saldo_Pendiente], [Evaluacion_Personal], [Observaciones_Personal]) VALUES (1102, 91, 1, 1101, CAST(N'2026-07-02T00:00:00.000' AS DateTime), CAST(300000.00 AS Decimal(18, 2)), N'Finalizado', CAST(1250000.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 1, N'Excelente atención de los mozos y tiempos impecables en el servicio de salón.')
INSERT [dbo].[RESERVA] ([Id_Reserva], [Id_Cliente], [Id_Usuario], [Id_Presupuesto], [Fecha_Evento], [Monto_Senia], [Estado], [Costo_Total_Real], [Saldo_Pendiente], [Evaluacion_Personal], [Observaciones_Personal]) VALUES (1103, 92, 1, 1102, CAST(N'2026-06-29T00:00:00.000' AS DateTime), CAST(393750.00 AS Decimal(18, 2)), N'Finalizado', CAST(1625000.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 1, N'Muy buena coordinación general del personal y rapidez en el despacho de cocina.')
GO
INSERT [dbo].[RESERVA] ([Id_Reserva], [Id_Cliente], [Id_Usuario], [Id_Presupuesto], [Fecha_Evento], [Monto_Senia], [Estado], [Costo_Total_Real], [Saldo_Pendiente], [Evaluacion_Personal], [Observaciones_Personal]) VALUES (1104, 93, 1, 1103, CAST(N'2026-06-26T00:00:00.000' AS DateTime), CAST(487500.00 AS Decimal(18, 2)), N'Finalizado', CAST(2000000.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 1, N'Servicio sobresaliente, personal muy atento y predispuesto durante toda la jornada.')
INSERT [dbo].[RESERVA] ([Id_Reserva], [Id_Cliente], [Id_Usuario], [Id_Presupuesto], [Fecha_Evento], [Monto_Senia], [Estado], [Costo_Total_Real], [Saldo_Pendiente], [Evaluacion_Personal], [Observaciones_Personal]) VALUES (1105, 94, 1, 1104, CAST(N'2026-06-23T00:00:00.000' AS DateTime), CAST(581250.00 AS Decimal(18, 2)), N'Finalizado', CAST(2375000.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 1, N'Organización perfecta, el equipo de salón y recepción superó las expectativas.')
INSERT [dbo].[RESERVA] ([Id_Reserva], [Id_Cliente], [Id_Usuario], [Id_Presupuesto], [Fecha_Evento], [Monto_Senia], [Estado], [Costo_Total_Real], [Saldo_Pendiente], [Evaluacion_Personal], [Observaciones_Personal]) VALUES (1106, 95, 1, 1105, CAST(N'2026-06-20T00:00:00.000' AS DateTime), CAST(675000.00 AS Decimal(18, 2)), N'Finalizado', CAST(2750000.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 1, N'Excelente atención de los mozos y tiempos impecables en el servicio de salón.')
INSERT [dbo].[RESERVA] ([Id_Reserva], [Id_Cliente], [Id_Usuario], [Id_Presupuesto], [Fecha_Evento], [Monto_Senia], [Estado], [Costo_Total_Real], [Saldo_Pendiente], [Evaluacion_Personal], [Observaciones_Personal]) VALUES (1107, 96, 1, 1106, CAST(N'2026-06-17T00:00:00.000' AS DateTime), CAST(300000.00 AS Decimal(18, 2)), N'Finalizado', CAST(1250000.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 1, N'Muy buena coordinación general del personal y rapidez en el despacho de cocina.')
INSERT [dbo].[RESERVA] ([Id_Reserva], [Id_Cliente], [Id_Usuario], [Id_Presupuesto], [Fecha_Evento], [Monto_Senia], [Estado], [Costo_Total_Real], [Saldo_Pendiente], [Evaluacion_Personal], [Observaciones_Personal]) VALUES (1108, 97, 1, 1107, CAST(N'2026-06-14T00:00:00.000' AS DateTime), CAST(393750.00 AS Decimal(18, 2)), N'Finalizado', CAST(1625000.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 1, N'Servicio sobresaliente, personal muy atento y predispuesto durante toda la jornada.')
INSERT [dbo].[RESERVA] ([Id_Reserva], [Id_Cliente], [Id_Usuario], [Id_Presupuesto], [Fecha_Evento], [Monto_Senia], [Estado], [Costo_Total_Real], [Saldo_Pendiente], [Evaluacion_Personal], [Observaciones_Personal]) VALUES (1109, 98, 1, 1108, CAST(N'2026-06-11T00:00:00.000' AS DateTime), CAST(487500.00 AS Decimal(18, 2)), N'Finalizado', CAST(2000000.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 1, N'Organización perfecta, el equipo de salón y recepción superó las expectativas.')
INSERT [dbo].[RESERVA] ([Id_Reserva], [Id_Cliente], [Id_Usuario], [Id_Presupuesto], [Fecha_Evento], [Monto_Senia], [Estado], [Costo_Total_Real], [Saldo_Pendiente], [Evaluacion_Personal], [Observaciones_Personal]) VALUES (1110, 99, 1, 1109, CAST(N'2026-06-08T00:00:00.000' AS DateTime), CAST(581250.00 AS Decimal(18, 2)), N'Finalizado', CAST(2375000.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 1, N'Excelente atención de los mozos y tiempos impecables en el servicio de salón.')
INSERT [dbo].[RESERVA] ([Id_Reserva], [Id_Cliente], [Id_Usuario], [Id_Presupuesto], [Fecha_Evento], [Monto_Senia], [Estado], [Costo_Total_Real], [Saldo_Pendiente], [Evaluacion_Personal], [Observaciones_Personal]) VALUES (1111, 100, 1, 1110, CAST(N'2026-06-05T00:00:00.000' AS DateTime), CAST(675000.00 AS Decimal(18, 2)), N'Finalizado', CAST(2750000.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 1, N'Muy buena coordinación general del personal y rapidez en el despacho de cocina.')
INSERT [dbo].[RESERVA] ([Id_Reserva], [Id_Cliente], [Id_Usuario], [Id_Presupuesto], [Fecha_Evento], [Monto_Senia], [Estado], [Costo_Total_Real], [Saldo_Pendiente], [Evaluacion_Personal], [Observaciones_Personal]) VALUES (1112, 101, 1, 1111, CAST(N'2026-06-02T00:00:00.000' AS DateTime), CAST(300000.00 AS Decimal(18, 2)), N'Finalizado', CAST(1250000.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 1, N'Servicio sobresaliente, personal muy atento y predispuesto durante toda la jornada.')
INSERT [dbo].[RESERVA] ([Id_Reserva], [Id_Cliente], [Id_Usuario], [Id_Presupuesto], [Fecha_Evento], [Monto_Senia], [Estado], [Costo_Total_Real], [Saldo_Pendiente], [Evaluacion_Personal], [Observaciones_Personal]) VALUES (1113, 102, 1, 1112, CAST(N'2026-05-30T00:00:00.000' AS DateTime), CAST(393750.00 AS Decimal(18, 2)), N'Finalizado', CAST(1625000.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 1, N'Organización perfecta, el equipo de salón y recepción superó las expectativas.')
INSERT [dbo].[RESERVA] ([Id_Reserva], [Id_Cliente], [Id_Usuario], [Id_Presupuesto], [Fecha_Evento], [Monto_Senia], [Estado], [Costo_Total_Real], [Saldo_Pendiente], [Evaluacion_Personal], [Observaciones_Personal]) VALUES (1114, 103, 1, 1113, CAST(N'2026-05-27T00:00:00.000' AS DateTime), CAST(487500.00 AS Decimal(18, 2)), N'Finalizado', CAST(2000000.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 1, N'Excelente atención de los mozos y tiempos impecables en el servicio de salón.')
INSERT [dbo].[RESERVA] ([Id_Reserva], [Id_Cliente], [Id_Usuario], [Id_Presupuesto], [Fecha_Evento], [Monto_Senia], [Estado], [Costo_Total_Real], [Saldo_Pendiente], [Evaluacion_Personal], [Observaciones_Personal]) VALUES (1115, 104, 1, 1114, CAST(N'2026-05-24T00:00:00.000' AS DateTime), CAST(581250.00 AS Decimal(18, 2)), N'Finalizado', CAST(2375000.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 1, N'Muy buena coordinación general del personal y rapidez en el despacho de cocina.')
INSERT [dbo].[RESERVA] ([Id_Reserva], [Id_Cliente], [Id_Usuario], [Id_Presupuesto], [Fecha_Evento], [Monto_Senia], [Estado], [Costo_Total_Real], [Saldo_Pendiente], [Evaluacion_Personal], [Observaciones_Personal]) VALUES (1116, 105, 1, 1115, CAST(N'2026-05-21T00:00:00.000' AS DateTime), CAST(675000.00 AS Decimal(18, 2)), N'Finalizado', CAST(2750000.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 1, N'Servicio sobresaliente, personal muy atento y predispuesto durante toda la jornada.')
SET IDENTITY_INSERT [dbo].[RESERVA] OFF
GO
SET IDENTITY_INSERT [dbo].[SERVICIO_CATERING] ON 

INSERT [dbo].[SERVICIO_CATERING] ([Id_Servicio], [Tipo_Menu], [Precio_Por_Persona], [Nombre_Servicio], [Descripcion]) VALUES (1, N'Menú Clásico (Entrada, Principal y Postre)', CAST(15000.00 AS Decimal(18, 2)), N'Menu Clasico', NULL)
INSERT [dbo].[SERVICIO_CATERING] ([Id_Servicio], [Tipo_Menu], [Precio_Por_Persona], [Nombre_Servicio], [Descripcion]) VALUES (2, N'Menú Premium (Recepción, Clásico y Pernil)', CAST(25000.00 AS Decimal(18, 2)), N'Menu Premium', N'plato principal y no se q mas')
INSERT [dbo].[SERVICIO_CATERING] ([Id_Servicio], [Tipo_Menu], [Precio_Por_Persona], [Nombre_Servicio], [Descripcion]) VALUES (3, N'Menú Infantil (Hamburguesas, Papas Fritas y Helado)', CAST(9000.00 AS Decimal(18, 2)), N'Menu Infantil', NULL)
INSERT [dbo].[SERVICIO_CATERING] ([Id_Servicio], [Tipo_Menu], [Precio_Por_Persona], [Nombre_Servicio], [Descripcion]) VALUES (4, N'Menú Vegano / Celíaco Special', CAST(18000.00 AS Decimal(18, 2)), N'Menu Vegano', NULL)
INSERT [dbo].[SERVICIO_CATERING] ([Id_Servicio], [Tipo_Menu], [Precio_Por_Persona], [Nombre_Servicio], [Descripcion]) VALUES (6, N'Criollo', CAST(12500.00 AS Decimal(18, 2)), N'Menú Criollo Tradicional', N'Plato principal asado con ensalada y postre')
INSERT [dbo].[SERVICIO_CATERING] ([Id_Servicio], [Tipo_Menu], [Precio_Por_Persona], [Nombre_Servicio], [Descripcion]) VALUES (7, N'Formal', CAST(18500.00 AS Decimal(18, 2)), N'Menú Formal Premium', N'Cena de 3 pasos con maridaje de vinos')
INSERT [dbo].[SERVICIO_CATERING] ([Id_Servicio], [Tipo_Menu], [Precio_Por_Persona], [Nombre_Servicio], [Descripcion]) VALUES (8, N'Informal', CAST(9800.00 AS Decimal(18, 2)), N'Menú Finger Food', N'Recepción informal con cazuelas y tragos')
SET IDENTITY_INSERT [dbo].[SERVICIO_CATERING] OFF
GO
SET IDENTITY_INSERT [dbo].[TARIFA_EVENTO] ON 

INSERT [dbo].[TARIFA_EVENTO] ([Id_Tarifa], [Tipo_Evento], [TarifaBase]) VALUES (1, N'Casamiento', CAST(15000.00 AS Decimal(18, 2)))
INSERT [dbo].[TARIFA_EVENTO] ([Id_Tarifa], [Tipo_Evento], [TarifaBase]) VALUES (2, N'Cumpleaños 15', CAST(12000.00 AS Decimal(18, 2)))
INSERT [dbo].[TARIFA_EVENTO] ([Id_Tarifa], [Tipo_Evento], [TarifaBase]) VALUES (3, N'Evento Corporativo', CAST(20000.00 AS Decimal(18, 2)))
SET IDENTITY_INSERT [dbo].[TARIFA_EVENTO] OFF
GO
SET IDENTITY_INSERT [dbo].[TRADUCCION] ON 

INSERT [dbo].[TRADUCCION] ([ID_TRADUCCION], [ID_CONTROL], [ID_IDIOMA], [TEXTO_TRADUCIDO]) VALUES (1, 1, 1, N'Usuario')
INSERT [dbo].[TRADUCCION] ([ID_TRADUCCION], [ID_CONTROL], [ID_IDIOMA], [TEXTO_TRADUCIDO]) VALUES (2, 2, 1, N'Contraseña')
INSERT [dbo].[TRADUCCION] ([ID_TRADUCCION], [ID_CONTROL], [ID_IDIOMA], [TEXTO_TRADUCIDO]) VALUES (3, 3, 1, N'Idioma')
INSERT [dbo].[TRADUCCION] ([ID_TRADUCCION], [ID_CONTROL], [ID_IDIOMA], [TEXTO_TRADUCIDO]) VALUES (4, 4, 1, N'Iniciar Sesion')
INSERT [dbo].[TRADUCCION] ([ID_TRADUCCION], [ID_CONTROL], [ID_IDIOMA], [TEXTO_TRADUCIDO]) VALUES (5, 5, 1, N'Bienvenido: {0}')
INSERT [dbo].[TRADUCCION] ([ID_TRADUCCION], [ID_CONTROL], [ID_IDIOMA], [TEXTO_TRADUCIDO]) VALUES (6, 6, 1, N'Cerrar Sesion')
INSERT [dbo].[TRADUCCION] ([ID_TRADUCCION], [ID_CONTROL], [ID_IDIOMA], [TEXTO_TRADUCIDO]) VALUES (7, 7, 1, N'Administracion')
INSERT [dbo].[TRADUCCION] ([ID_TRADUCCION], [ID_CONTROL], [ID_IDIOMA], [TEXTO_TRADUCIDO]) VALUES (8, 8, 1, N'Bitacora')
INSERT [dbo].[TRADUCCION] ([ID_TRADUCCION], [ID_CONTROL], [ID_IDIOMA], [TEXTO_TRADUCIDO]) VALUES (9, 9, 1, N'Control de Usuarios')
INSERT [dbo].[TRADUCCION] ([ID_TRADUCCION], [ID_CONTROL], [ID_IDIOMA], [TEXTO_TRADUCIDO]) VALUES (10, 10, 1, N'Control de Permisos')
INSERT [dbo].[TRADUCCION] ([ID_TRADUCCION], [ID_CONTROL], [ID_IDIOMA], [TEXTO_TRADUCIDO]) VALUES (11, 11, 1, N'Usuario')
INSERT [dbo].[TRADUCCION] ([ID_TRADUCCION], [ID_CONTROL], [ID_IDIOMA], [TEXTO_TRADUCIDO]) VALUES (12, 12, 1, N'Contraseña')
INSERT [dbo].[TRADUCCION] ([ID_TRADUCCION], [ID_CONTROL], [ID_IDIOMA], [TEXTO_TRADUCIDO]) VALUES (13, 13, 1, N'DNI')
INSERT [dbo].[TRADUCCION] ([ID_TRADUCCION], [ID_CONTROL], [ID_IDIOMA], [TEXTO_TRADUCIDO]) VALUES (14, 14, 1, N'Email')
INSERT [dbo].[TRADUCCION] ([ID_TRADUCCION], [ID_CONTROL], [ID_IDIOMA], [TEXTO_TRADUCIDO]) VALUES (15, 15, 1, N'Rol')
INSERT [dbo].[TRADUCCION] ([ID_TRADUCCION], [ID_CONTROL], [ID_IDIOMA], [TEXTO_TRADUCIDO]) VALUES (16, 16, 1, N'Rol de Usuario')
INSERT [dbo].[TRADUCCION] ([ID_TRADUCCION], [ID_CONTROL], [ID_IDIOMA], [TEXTO_TRADUCIDO]) VALUES (17, 17, 1, N'Mostrar Bloqueados')
INSERT [dbo].[TRADUCCION] ([ID_TRADUCCION], [ID_CONTROL], [ID_IDIOMA], [TEXTO_TRADUCIDO]) VALUES (18, 18, 1, N'Alta')
INSERT [dbo].[TRADUCCION] ([ID_TRADUCCION], [ID_CONTROL], [ID_IDIOMA], [TEXTO_TRADUCIDO]) VALUES (19, 19, 1, N'Baja')
INSERT [dbo].[TRADUCCION] ([ID_TRADUCCION], [ID_CONTROL], [ID_IDIOMA], [TEXTO_TRADUCIDO]) VALUES (20, 20, 1, N'Modificar')
INSERT [dbo].[TRADUCCION] ([ID_TRADUCCION], [ID_CONTROL], [ID_IDIOMA], [TEXTO_TRADUCIDO]) VALUES (21, 21, 1, N'Desbloquear')
INSERT [dbo].[TRADUCCION] ([ID_TRADUCCION], [ID_CONTROL], [ID_IDIOMA], [TEXTO_TRADUCIDO]) VALUES (22, 22, 1, N'Volver al Menu')
INSERT [dbo].[TRADUCCION] ([ID_TRADUCCION], [ID_CONTROL], [ID_IDIOMA], [TEXTO_TRADUCIDO]) VALUES (23, 23, 1, N'Nombre')
INSERT [dbo].[TRADUCCION] ([ID_TRADUCCION], [ID_CONTROL], [ID_IDIOMA], [TEXTO_TRADUCIDO]) VALUES (24, 24, 1, N'Asignar')
INSERT [dbo].[TRADUCCION] ([ID_TRADUCCION], [ID_CONTROL], [ID_IDIOMA], [TEXTO_TRADUCIDO]) VALUES (25, 25, 1, N'Desasignar')
INSERT [dbo].[TRADUCCION] ([ID_TRADUCCION], [ID_CONTROL], [ID_IDIOMA], [TEXTO_TRADUCIDO]) VALUES (26, 26, 1, N'Crear Rol')
INSERT [dbo].[TRADUCCION] ([ID_TRADUCCION], [ID_CONTROL], [ID_IDIOMA], [TEXTO_TRADUCIDO]) VALUES (27, 27, 1, N'Bitacora')
INSERT [dbo].[TRADUCCION] ([ID_TRADUCCION], [ID_CONTROL], [ID_IDIOMA], [TEXTO_TRADUCIDO]) VALUES (28, 28, 1, N'Filtros')
INSERT [dbo].[TRADUCCION] ([ID_TRADUCCION], [ID_CONTROL], [ID_IDIOMA], [TEXTO_TRADUCIDO]) VALUES (29, 29, 1, N'Usuario')
INSERT [dbo].[TRADUCCION] ([ID_TRADUCCION], [ID_CONTROL], [ID_IDIOMA], [TEXTO_TRADUCIDO]) VALUES (30, 30, 1, N'Modulo')
INSERT [dbo].[TRADUCCION] ([ID_TRADUCCION], [ID_CONTROL], [ID_IDIOMA], [TEXTO_TRADUCIDO]) VALUES (31, 31, 1, N'Criticidad')
INSERT [dbo].[TRADUCCION] ([ID_TRADUCCION], [ID_CONTROL], [ID_IDIOMA], [TEXTO_TRADUCIDO]) VALUES (32, 32, 1, N'Fecha Inicial')
INSERT [dbo].[TRADUCCION] ([ID_TRADUCCION], [ID_CONTROL], [ID_IDIOMA], [TEXTO_TRADUCIDO]) VALUES (33, 33, 1, N'Fecha Final')
INSERT [dbo].[TRADUCCION] ([ID_TRADUCCION], [ID_CONTROL], [ID_IDIOMA], [TEXTO_TRADUCIDO]) VALUES (34, 34, 1, N'Incluir Fechas')
INSERT [dbo].[TRADUCCION] ([ID_TRADUCCION], [ID_CONTROL], [ID_IDIOMA], [TEXTO_TRADUCIDO]) VALUES (35, 35, 1, N'Filtrar')
INSERT [dbo].[TRADUCCION] ([ID_TRADUCCION], [ID_CONTROL], [ID_IDIOMA], [TEXTO_TRADUCIDO]) VALUES (36, 36, 1, N'Volver al Menu Principal')
INSERT [dbo].[TRADUCCION] ([ID_TRADUCCION], [ID_CONTROL], [ID_IDIOMA], [TEXTO_TRADUCIDO]) VALUES (37, 1, 2, N'User')
INSERT [dbo].[TRADUCCION] ([ID_TRADUCCION], [ID_CONTROL], [ID_IDIOMA], [TEXTO_TRADUCIDO]) VALUES (38, 2, 2, N'Password')
INSERT [dbo].[TRADUCCION] ([ID_TRADUCCION], [ID_CONTROL], [ID_IDIOMA], [TEXTO_TRADUCIDO]) VALUES (39, 3, 2, N'Language')
INSERT [dbo].[TRADUCCION] ([ID_TRADUCCION], [ID_CONTROL], [ID_IDIOMA], [TEXTO_TRADUCIDO]) VALUES (40, 4, 2, N'Log In')
INSERT [dbo].[TRADUCCION] ([ID_TRADUCCION], [ID_CONTROL], [ID_IDIOMA], [TEXTO_TRADUCIDO]) VALUES (41, 5, 2, N'Welcome: {0}')
INSERT [dbo].[TRADUCCION] ([ID_TRADUCCION], [ID_CONTROL], [ID_IDIOMA], [TEXTO_TRADUCIDO]) VALUES (42, 6, 2, N'Log Out')
INSERT [dbo].[TRADUCCION] ([ID_TRADUCCION], [ID_CONTROL], [ID_IDIOMA], [TEXTO_TRADUCIDO]) VALUES (43, 7, 2, N'Admin')
INSERT [dbo].[TRADUCCION] ([ID_TRADUCCION], [ID_CONTROL], [ID_IDIOMA], [TEXTO_TRADUCIDO]) VALUES (44, 8, 2, N'Log')
INSERT [dbo].[TRADUCCION] ([ID_TRADUCCION], [ID_CONTROL], [ID_IDIOMA], [TEXTO_TRADUCIDO]) VALUES (45, 9, 2, N'User Control')
INSERT [dbo].[TRADUCCION] ([ID_TRADUCCION], [ID_CONTROL], [ID_IDIOMA], [TEXTO_TRADUCIDO]) VALUES (46, 10, 2, N'Permissin Control')
INSERT [dbo].[TRADUCCION] ([ID_TRADUCCION], [ID_CONTROL], [ID_IDIOMA], [TEXTO_TRADUCIDO]) VALUES (47, 11, 2, N'User')
INSERT [dbo].[TRADUCCION] ([ID_TRADUCCION], [ID_CONTROL], [ID_IDIOMA], [TEXTO_TRADUCIDO]) VALUES (48, 12, 2, N'Password')
INSERT [dbo].[TRADUCCION] ([ID_TRADUCCION], [ID_CONTROL], [ID_IDIOMA], [TEXTO_TRADUCIDO]) VALUES (49, 13, 2, N'DNI')
INSERT [dbo].[TRADUCCION] ([ID_TRADUCCION], [ID_CONTROL], [ID_IDIOMA], [TEXTO_TRADUCIDO]) VALUES (50, 14, 2, N'Email')
INSERT [dbo].[TRADUCCION] ([ID_TRADUCCION], [ID_CONTROL], [ID_IDIOMA], [TEXTO_TRADUCIDO]) VALUES (51, 15, 2, N'Rol')
INSERT [dbo].[TRADUCCION] ([ID_TRADUCCION], [ID_CONTROL], [ID_IDIOMA], [TEXTO_TRADUCIDO]) VALUES (52, 16, 2, N'combo')
INSERT [dbo].[TRADUCCION] ([ID_TRADUCCION], [ID_CONTROL], [ID_IDIOMA], [TEXTO_TRADUCIDO]) VALUES (53, 17, 2, N'Show user blocked')
INSERT [dbo].[TRADUCCION] ([ID_TRADUCCION], [ID_CONTROL], [ID_IDIOMA], [TEXTO_TRADUCIDO]) VALUES (54, 18, 2, N'Insert')
INSERT [dbo].[TRADUCCION] ([ID_TRADUCCION], [ID_CONTROL], [ID_IDIOMA], [TEXTO_TRADUCIDO]) VALUES (55, 19, 2, N'Delete')
INSERT [dbo].[TRADUCCION] ([ID_TRADUCCION], [ID_CONTROL], [ID_IDIOMA], [TEXTO_TRADUCIDO]) VALUES (56, 20, 2, N'Modify')
INSERT [dbo].[TRADUCCION] ([ID_TRADUCCION], [ID_CONTROL], [ID_IDIOMA], [TEXTO_TRADUCIDO]) VALUES (57, 21, 2, N'Unlock')
INSERT [dbo].[TRADUCCION] ([ID_TRADUCCION], [ID_CONTROL], [ID_IDIOMA], [TEXTO_TRADUCIDO]) VALUES (58, 22, 2, N'Back to the Menu')
INSERT [dbo].[TRADUCCION] ([ID_TRADUCCION], [ID_CONTROL], [ID_IDIOMA], [TEXTO_TRADUCIDO]) VALUES (59, 23, 2, N'Name')
INSERT [dbo].[TRADUCCION] ([ID_TRADUCCION], [ID_CONTROL], [ID_IDIOMA], [TEXTO_TRADUCIDO]) VALUES (133, 24, 2, N'Assign')
INSERT [dbo].[TRADUCCION] ([ID_TRADUCCION], [ID_CONTROL], [ID_IDIOMA], [TEXTO_TRADUCIDO]) VALUES (134, 25, 2, N'Unassign')
INSERT [dbo].[TRADUCCION] ([ID_TRADUCCION], [ID_CONTROL], [ID_IDIOMA], [TEXTO_TRADUCIDO]) VALUES (135, 26, 2, N'Create role')
INSERT [dbo].[TRADUCCION] ([ID_TRADUCCION], [ID_CONTROL], [ID_IDIOMA], [TEXTO_TRADUCIDO]) VALUES (136, 27, 2, N'Logs')
INSERT [dbo].[TRADUCCION] ([ID_TRADUCCION], [ID_CONTROL], [ID_IDIOMA], [TEXTO_TRADUCIDO]) VALUES (137, 28, 2, N'Filters')
INSERT [dbo].[TRADUCCION] ([ID_TRADUCCION], [ID_CONTROL], [ID_IDIOMA], [TEXTO_TRADUCIDO]) VALUES (138, 29, 2, N'User')
INSERT [dbo].[TRADUCCION] ([ID_TRADUCCION], [ID_CONTROL], [ID_IDIOMA], [TEXTO_TRADUCIDO]) VALUES (139, 30, 2, N'Module')
INSERT [dbo].[TRADUCCION] ([ID_TRADUCCION], [ID_CONTROL], [ID_IDIOMA], [TEXTO_TRADUCIDO]) VALUES (140, 31, 2, N'Criticality')
INSERT [dbo].[TRADUCCION] ([ID_TRADUCCION], [ID_CONTROL], [ID_IDIOMA], [TEXTO_TRADUCIDO]) VALUES (141, 32, 2, N'Starting date')
INSERT [dbo].[TRADUCCION] ([ID_TRADUCCION], [ID_CONTROL], [ID_IDIOMA], [TEXTO_TRADUCIDO]) VALUES (142, 33, 2, N'End date')
INSERT [dbo].[TRADUCCION] ([ID_TRADUCCION], [ID_CONTROL], [ID_IDIOMA], [TEXTO_TRADUCIDO]) VALUES (143, 34, 2, N'Include dates')
INSERT [dbo].[TRADUCCION] ([ID_TRADUCCION], [ID_CONTROL], [ID_IDIOMA], [TEXTO_TRADUCIDO]) VALUES (144, 35, 2, N'Filter')
INSERT [dbo].[TRADUCCION] ([ID_TRADUCCION], [ID_CONTROL], [ID_IDIOMA], [TEXTO_TRADUCIDO]) VALUES (145, 36, 2, N'Back to the menu')
INSERT [dbo].[TRADUCCION] ([ID_TRADUCCION], [ID_CONTROL], [ID_IDIOMA], [TEXTO_TRADUCIDO]) VALUES (146, 37, 2, N'Language')
INSERT [dbo].[TRADUCCION] ([ID_TRADUCCION], [ID_CONTROL], [ID_IDIOMA], [TEXTO_TRADUCIDO]) VALUES (147, 39, 2, N'Language')
INSERT [dbo].[TRADUCCION] ([ID_TRADUCCION], [ID_CONTROL], [ID_IDIOMA], [TEXTO_TRADUCIDO]) VALUES (148, 41, 2, N'Language')
INSERT [dbo].[TRADUCCION] ([ID_TRADUCCION], [ID_CONTROL], [ID_IDIOMA], [TEXTO_TRADUCIDO]) VALUES (149, 43, 2, N'Language')
INSERT [dbo].[TRADUCCION] ([ID_TRADUCCION], [ID_CONTROL], [ID_IDIOMA], [TEXTO_TRADUCIDO]) VALUES (150, 45, 2, N'Language control')
INSERT [dbo].[TRADUCCION] ([ID_TRADUCCION], [ID_CONTROL], [ID_IDIOMA], [TEXTO_TRADUCIDO]) VALUES (151, 46, 2, N'Language')
INSERT [dbo].[TRADUCCION] ([ID_TRADUCCION], [ID_CONTROL], [ID_IDIOMA], [TEXTO_TRADUCIDO]) VALUES (152, 47, 2, N'Language')
INSERT [dbo].[TRADUCCION] ([ID_TRADUCCION], [ID_CONTROL], [ID_IDIOMA], [TEXTO_TRADUCIDO]) VALUES (153, 48, 2, N'Name')
INSERT [dbo].[TRADUCCION] ([ID_TRADUCCION], [ID_CONTROL], [ID_IDIOMA], [TEXTO_TRADUCIDO]) VALUES (154, 49, 2, N'Suffix')
INSERT [dbo].[TRADUCCION] ([ID_TRADUCCION], [ID_CONTROL], [ID_IDIOMA], [TEXTO_TRADUCIDO]) VALUES (155, 50, 2, N'Create')
INSERT [dbo].[TRADUCCION] ([ID_TRADUCCION], [ID_CONTROL], [ID_IDIOMA], [TEXTO_TRADUCIDO]) VALUES (156, 51, 2, N'Disable')
INSERT [dbo].[TRADUCCION] ([ID_TRADUCCION], [ID_CONTROL], [ID_IDIOMA], [TEXTO_TRADUCIDO]) VALUES (157, 52, 2, N'Back to the menu')
INSERT [dbo].[TRADUCCION] ([ID_TRADUCCION], [ID_CONTROL], [ID_IDIOMA], [TEXTO_TRADUCIDO]) VALUES (158, 53, 2, N'Modify')
INSERT [dbo].[TRADUCCION] ([ID_TRADUCCION], [ID_CONTROL], [ID_IDIOMA], [TEXTO_TRADUCIDO]) VALUES (159, 54, 2, N'Delete')
INSERT [dbo].[TRADUCCION] ([ID_TRADUCCION], [ID_CONTROL], [ID_IDIOMA], [TEXTO_TRADUCIDO]) VALUES (160, 55, 2, N'All roles and permissions')
INSERT [dbo].[TRADUCCION] ([ID_TRADUCCION], [ID_CONTROL], [ID_IDIOMA], [TEXTO_TRADUCIDO]) VALUES (161, 56, 2, N'Role tree')
INSERT [dbo].[TRADUCCION] ([ID_TRADUCCION], [ID_CONTROL], [ID_IDIOMA], [TEXTO_TRADUCIDO]) VALUES (162, 57, 2, N'Log In')
INSERT [dbo].[TRADUCCION] ([ID_TRADUCCION], [ID_CONTROL], [ID_IDIOMA], [TEXTO_TRADUCIDO]) VALUES (163, 58, 2, N'Main Menu')
INSERT [dbo].[TRADUCCION] ([ID_TRADUCCION], [ID_CONTROL], [ID_IDIOMA], [TEXTO_TRADUCIDO]) VALUES (164, 59, 2, N'Language Control')
INSERT [dbo].[TRADUCCION] ([ID_TRADUCCION], [ID_CONTROL], [ID_IDIOMA], [TEXTO_TRADUCIDO]) VALUES (165, 60, 2, N'User Control')
INSERT [dbo].[TRADUCCION] ([ID_TRADUCCION], [ID_CONTROL], [ID_IDIOMA], [TEXTO_TRADUCIDO]) VALUES (166, 61, 2, N'Permission Control')
INSERT [dbo].[TRADUCCION] ([ID_TRADUCCION], [ID_CONTROL], [ID_IDIOMA], [TEXTO_TRADUCIDO]) VALUES (167, 62, 2, N'Log')
INSERT [dbo].[TRADUCCION] ([ID_TRADUCCION], [ID_CONTROL], [ID_IDIOMA], [TEXTO_TRADUCIDO]) VALUES (168, 37, 1, N'Idiomas')
INSERT [dbo].[TRADUCCION] ([ID_TRADUCCION], [ID_CONTROL], [ID_IDIOMA], [TEXTO_TRADUCIDO]) VALUES (170, 39, 1, N'Idiomas')
INSERT [dbo].[TRADUCCION] ([ID_TRADUCCION], [ID_CONTROL], [ID_IDIOMA], [TEXTO_TRADUCIDO]) VALUES (171, 41, 1, N'Idiomas')
INSERT [dbo].[TRADUCCION] ([ID_TRADUCCION], [ID_CONTROL], [ID_IDIOMA], [TEXTO_TRADUCIDO]) VALUES (172, 43, 1, N'Idiomas')
INSERT [dbo].[TRADUCCION] ([ID_TRADUCCION], [ID_CONTROL], [ID_IDIOMA], [TEXTO_TRADUCIDO]) VALUES (173, 45, 1, N'Control de Idioma')
GO
INSERT [dbo].[TRADUCCION] ([ID_TRADUCCION], [ID_CONTROL], [ID_IDIOMA], [TEXTO_TRADUCIDO]) VALUES (174, 46, 1, N'Idiomas')
INSERT [dbo].[TRADUCCION] ([ID_TRADUCCION], [ID_CONTROL], [ID_IDIOMA], [TEXTO_TRADUCIDO]) VALUES (175, 47, 1, N'Idiomas')
INSERT [dbo].[TRADUCCION] ([ID_TRADUCCION], [ID_CONTROL], [ID_IDIOMA], [TEXTO_TRADUCIDO]) VALUES (176, 48, 1, N'Nombre')
INSERT [dbo].[TRADUCCION] ([ID_TRADUCCION], [ID_CONTROL], [ID_IDIOMA], [TEXTO_TRADUCIDO]) VALUES (177, 49, 1, N'Sufijo')
INSERT [dbo].[TRADUCCION] ([ID_TRADUCCION], [ID_CONTROL], [ID_IDIOMA], [TEXTO_TRADUCIDO]) VALUES (178, 50, 1, N'Crear')
INSERT [dbo].[TRADUCCION] ([ID_TRADUCCION], [ID_CONTROL], [ID_IDIOMA], [TEXTO_TRADUCIDO]) VALUES (179, 51, 1, N'Deshabilitar')
INSERT [dbo].[TRADUCCION] ([ID_TRADUCCION], [ID_CONTROL], [ID_IDIOMA], [TEXTO_TRADUCIDO]) VALUES (180, 52, 1, N'Volver al menu')
INSERT [dbo].[TRADUCCION] ([ID_TRADUCCION], [ID_CONTROL], [ID_IDIOMA], [TEXTO_TRADUCIDO]) VALUES (181, 53, 1, N'Modificar')
INSERT [dbo].[TRADUCCION] ([ID_TRADUCCION], [ID_CONTROL], [ID_IDIOMA], [TEXTO_TRADUCIDO]) VALUES (182, 54, 1, N'Borrar')
INSERT [dbo].[TRADUCCION] ([ID_TRADUCCION], [ID_CONTROL], [ID_IDIOMA], [TEXTO_TRADUCIDO]) VALUES (183, 55, 1, N'Todos los roles y permisos')
INSERT [dbo].[TRADUCCION] ([ID_TRADUCCION], [ID_CONTROL], [ID_IDIOMA], [TEXTO_TRADUCIDO]) VALUES (184, 56, 1, N'Arbol de roles')
INSERT [dbo].[TRADUCCION] ([ID_TRADUCCION], [ID_CONTROL], [ID_IDIOMA], [TEXTO_TRADUCIDO]) VALUES (185, 57, 1, N'Iniciar Sesion')
INSERT [dbo].[TRADUCCION] ([ID_TRADUCCION], [ID_CONTROL], [ID_IDIOMA], [TEXTO_TRADUCIDO]) VALUES (186, 58, 1, N'Menu Principal')
INSERT [dbo].[TRADUCCION] ([ID_TRADUCCION], [ID_CONTROL], [ID_IDIOMA], [TEXTO_TRADUCIDO]) VALUES (187, 59, 1, N'Control de idiomas')
INSERT [dbo].[TRADUCCION] ([ID_TRADUCCION], [ID_CONTROL], [ID_IDIOMA], [TEXTO_TRADUCIDO]) VALUES (188, 60, 1, N'Control de usuarios')
INSERT [dbo].[TRADUCCION] ([ID_TRADUCCION], [ID_CONTROL], [ID_IDIOMA], [TEXTO_TRADUCIDO]) VALUES (189, 61, 1, N'Control de Permisos')
INSERT [dbo].[TRADUCCION] ([ID_TRADUCCION], [ID_CONTROL], [ID_IDIOMA], [TEXTO_TRADUCIDO]) VALUES (190, 62, 1, N'Bitacora')
INSERT [dbo].[TRADUCCION] ([ID_TRADUCCION], [ID_CONTROL], [ID_IDIOMA], [TEXTO_TRADUCIDO]) VALUES (250, 63, 1, N'Habilitar')
INSERT [dbo].[TRADUCCION] ([ID_TRADUCCION], [ID_CONTROL], [ID_IDIOMA], [TEXTO_TRADUCIDO]) VALUES (251, 63, 2, N'Enable')
INSERT [dbo].[TRADUCCION] ([ID_TRADUCCION], [ID_CONTROL], [ID_IDIOMA], [TEXTO_TRADUCIDO]) VALUES (372, 64, 1, N'Idiomas')
INSERT [dbo].[TRADUCCION] ([ID_TRADUCCION], [ID_CONTROL], [ID_IDIOMA], [TEXTO_TRADUCIDO]) VALUES (373, 65, 1, N'Historial')
INSERT [dbo].[TRADUCCION] ([ID_TRADUCCION], [ID_CONTROL], [ID_IDIOMA], [TEXTO_TRADUCIDO]) VALUES (374, 66, 1, N'Usuario')
INSERT [dbo].[TRADUCCION] ([ID_TRADUCCION], [ID_CONTROL], [ID_IDIOMA], [TEXTO_TRADUCIDO]) VALUES (375, 67, 1, N'Restaurar')
INSERT [dbo].[TRADUCCION] ([ID_TRADUCCION], [ID_CONTROL], [ID_IDIOMA], [TEXTO_TRADUCIDO]) VALUES (376, 68, 1, N'Volver al menu')
INSERT [dbo].[TRADUCCION] ([ID_TRADUCCION], [ID_CONTROL], [ID_IDIOMA], [TEXTO_TRADUCIDO]) VALUES (377, 69, 1, N'Historial de cambios')
INSERT [dbo].[TRADUCCION] ([ID_TRADUCCION], [ID_CONTROL], [ID_IDIOMA], [TEXTO_TRADUCIDO]) VALUES (378, 70, 1, N'Idiomas')
INSERT [dbo].[TRADUCCION] ([ID_TRADUCCION], [ID_CONTROL], [ID_IDIOMA], [TEXTO_TRADUCIDO]) VALUES (379, 71, 1, N'Mensaje de error')
INSERT [dbo].[TRADUCCION] ([ID_TRADUCCION], [ID_CONTROL], [ID_IDIOMA], [TEXTO_TRADUCIDO]) VALUES (380, 72, 1, N'Crear Back Up')
INSERT [dbo].[TRADUCCION] ([ID_TRADUCCION], [ID_CONTROL], [ID_IDIOMA], [TEXTO_TRADUCIDO]) VALUES (381, 73, 1, N'Examinar')
INSERT [dbo].[TRADUCCION] ([ID_TRADUCCION], [ID_CONTROL], [ID_IDIOMA], [TEXTO_TRADUCIDO]) VALUES (382, 74, 1, N'Restaurar Base')
INSERT [dbo].[TRADUCCION] ([ID_TRADUCCION], [ID_CONTROL], [ID_IDIOMA], [TEXTO_TRADUCIDO]) VALUES (383, 75, 1, N'Recalcular digito verificador')
INSERT [dbo].[TRADUCCION] ([ID_TRADUCCION], [ID_CONTROL], [ID_IDIOMA], [TEXTO_TRADUCIDO]) VALUES (384, 76, 1, N'Volver al menu')
INSERT [dbo].[TRADUCCION] ([ID_TRADUCCION], [ID_CONTROL], [ID_IDIOMA], [TEXTO_TRADUCIDO]) VALUES (385, 77, 1, N'Control de restauracion')
INSERT [dbo].[TRADUCCION] ([ID_TRADUCCION], [ID_CONTROL], [ID_IDIOMA], [TEXTO_TRADUCIDO]) VALUES (386, 78, 1, N'Rol')
INSERT [dbo].[TRADUCCION] ([ID_TRADUCCION], [ID_CONTROL], [ID_IDIOMA], [TEXTO_TRADUCIDO]) VALUES (387, 64, 2, N'Language')
INSERT [dbo].[TRADUCCION] ([ID_TRADUCCION], [ID_CONTROL], [ID_IDIOMA], [TEXTO_TRADUCIDO]) VALUES (388, 65, 2, N'History')
INSERT [dbo].[TRADUCCION] ([ID_TRADUCCION], [ID_CONTROL], [ID_IDIOMA], [TEXTO_TRADUCIDO]) VALUES (389, 66, 2, N'User')
INSERT [dbo].[TRADUCCION] ([ID_TRADUCCION], [ID_CONTROL], [ID_IDIOMA], [TEXTO_TRADUCIDO]) VALUES (390, 67, 2, N'Restore')
INSERT [dbo].[TRADUCCION] ([ID_TRADUCCION], [ID_CONTROL], [ID_IDIOMA], [TEXTO_TRADUCIDO]) VALUES (392, 68, 2, N'Back to the menu')
INSERT [dbo].[TRADUCCION] ([ID_TRADUCCION], [ID_CONTROL], [ID_IDIOMA], [TEXTO_TRADUCIDO]) VALUES (393, 69, 2, N'Change history')
INSERT [dbo].[TRADUCCION] ([ID_TRADUCCION], [ID_CONTROL], [ID_IDIOMA], [TEXTO_TRADUCIDO]) VALUES (394, 70, 2, N'Language')
INSERT [dbo].[TRADUCCION] ([ID_TRADUCCION], [ID_CONTROL], [ID_IDIOMA], [TEXTO_TRADUCIDO]) VALUES (395, 71, 2, N'Error message')
INSERT [dbo].[TRADUCCION] ([ID_TRADUCCION], [ID_CONTROL], [ID_IDIOMA], [TEXTO_TRADUCIDO]) VALUES (396, 72, 2, N'Create Back Up')
INSERT [dbo].[TRADUCCION] ([ID_TRADUCCION], [ID_CONTROL], [ID_IDIOMA], [TEXTO_TRADUCIDO]) VALUES (397, 73, 2, N'Examine')
INSERT [dbo].[TRADUCCION] ([ID_TRADUCCION], [ID_CONTROL], [ID_IDIOMA], [TEXTO_TRADUCIDO]) VALUES (398, 74, 2, N'Restore Base')
INSERT [dbo].[TRADUCCION] ([ID_TRADUCCION], [ID_CONTROL], [ID_IDIOMA], [TEXTO_TRADUCIDO]) VALUES (399, 75, 2, N'Recalculate check digit')
INSERT [dbo].[TRADUCCION] ([ID_TRADUCCION], [ID_CONTROL], [ID_IDIOMA], [TEXTO_TRADUCIDO]) VALUES (400, 76, 2, N'Back to the menu')
INSERT [dbo].[TRADUCCION] ([ID_TRADUCCION], [ID_CONTROL], [ID_IDIOMA], [TEXTO_TRADUCIDO]) VALUES (401, 77, 2, N'Restore control')
INSERT [dbo].[TRADUCCION] ([ID_TRADUCCION], [ID_CONTROL], [ID_IDIOMA], [TEXTO_TRADUCIDO]) VALUES (402, 78, 2, N'Role')
INSERT [dbo].[TRADUCCION] ([ID_TRADUCCION], [ID_CONTROL], [ID_IDIOMA], [TEXTO_TRADUCIDO]) VALUES (403, 79, 1, N'Control de restauracion')
INSERT [dbo].[TRADUCCION] ([ID_TRADUCCION], [ID_CONTROL], [ID_IDIOMA], [TEXTO_TRADUCIDO]) VALUES (404, 80, 1, N'Historial de cambios')
INSERT [dbo].[TRADUCCION] ([ID_TRADUCCION], [ID_CONTROL], [ID_IDIOMA], [TEXTO_TRADUCIDO]) VALUES (405, 79, 2, N'Restore control')
INSERT [dbo].[TRADUCCION] ([ID_TRADUCCION], [ID_CONTROL], [ID_IDIOMA], [TEXTO_TRADUCIDO]) VALUES (407, 80, 2, N'Change history')
INSERT [dbo].[TRADUCCION] ([ID_TRADUCCION], [ID_CONTROL], [ID_IDIOMA], [TEXTO_TRADUCIDO]) VALUES (408, 81, 1, N'Historial de cambios')
INSERT [dbo].[TRADUCCION] ([ID_TRADUCCION], [ID_CONTROL], [ID_IDIOMA], [TEXTO_TRADUCIDO]) VALUES (409, 82, 1, N'Filtrar')
INSERT [dbo].[TRADUCCION] ([ID_TRADUCCION], [ID_CONTROL], [ID_IDIOMA], [TEXTO_TRADUCIDO]) VALUES (410, 83, 1, N'Ver todo')
INSERT [dbo].[TRADUCCION] ([ID_TRADUCCION], [ID_CONTROL], [ID_IDIOMA], [TEXTO_TRADUCIDO]) VALUES (411, 81, 2, N'Change history')
INSERT [dbo].[TRADUCCION] ([ID_TRADUCCION], [ID_CONTROL], [ID_IDIOMA], [TEXTO_TRADUCIDO]) VALUES (412, 82, 2, N'Filter')
INSERT [dbo].[TRADUCCION] ([ID_TRADUCCION], [ID_CONTROL], [ID_IDIOMA], [TEXTO_TRADUCIDO]) VALUES (413, 83, 2, N'Show all')
INSERT [dbo].[TRADUCCION] ([ID_TRADUCCION], [ID_CONTROL], [ID_IDIOMA], [TEXTO_TRADUCIDO]) VALUES (414, 84, 1, N'Usuarios')
INSERT [dbo].[TRADUCCION] ([ID_TRADUCCION], [ID_CONTROL], [ID_IDIOMA], [TEXTO_TRADUCIDO]) VALUES (415, 85, 1, N'Datos de usuario')
INSERT [dbo].[TRADUCCION] ([ID_TRADUCCION], [ID_CONTROL], [ID_IDIOMA], [TEXTO_TRADUCIDO]) VALUES (416, 86, 1, N'Todos los roles')
INSERT [dbo].[TRADUCCION] ([ID_TRADUCCION], [ID_CONTROL], [ID_IDIOMA], [TEXTO_TRADUCIDO]) VALUES (417, 88, 1, N'Todos los permisos')
INSERT [dbo].[TRADUCCION] ([ID_TRADUCCION], [ID_CONTROL], [ID_IDIOMA], [TEXTO_TRADUCIDO]) VALUES (418, 89, 1, N'Idiomas')
INSERT [dbo].[TRADUCCION] ([ID_TRADUCCION], [ID_CONTROL], [ID_IDIOMA], [TEXTO_TRADUCIDO]) VALUES (419, 90, 1, N'Nuevo Idioma')
INSERT [dbo].[TRADUCCION] ([ID_TRADUCCION], [ID_CONTROL], [ID_IDIOMA], [TEXTO_TRADUCIDO]) VALUES (420, 91, 1, N'Traducciones')
INSERT [dbo].[TRADUCCION] ([ID_TRADUCCION], [ID_CONTROL], [ID_IDIOMA], [TEXTO_TRADUCIDO]) VALUES (421, 92, 1, N'Idiomas')
INSERT [dbo].[TRADUCCION] ([ID_TRADUCCION], [ID_CONTROL], [ID_IDIOMA], [TEXTO_TRADUCIDO]) VALUES (422, 93, 1, N'Nombre')
INSERT [dbo].[TRADUCCION] ([ID_TRADUCCION], [ID_CONTROL], [ID_IDIOMA], [TEXTO_TRADUCIDO]) VALUES (423, 94, 1, N'Precio')
INSERT [dbo].[TRADUCCION] ([ID_TRADUCCION], [ID_CONTROL], [ID_IDIOMA], [TEXTO_TRADUCIDO]) VALUES (424, 95, 1, N'Stock')
INSERT [dbo].[TRADUCCION] ([ID_TRADUCCION], [ID_CONTROL], [ID_IDIOMA], [TEXTO_TRADUCIDO]) VALUES (425, 96, 1, N'Alta')
INSERT [dbo].[TRADUCCION] ([ID_TRADUCCION], [ID_CONTROL], [ID_IDIOMA], [TEXTO_TRADUCIDO]) VALUES (426, 97, 1, N'Baja')
INSERT [dbo].[TRADUCCION] ([ID_TRADUCCION], [ID_CONTROL], [ID_IDIOMA], [TEXTO_TRADUCIDO]) VALUES (427, 98, 1, N'Modificar')
INSERT [dbo].[TRADUCCION] ([ID_TRADUCCION], [ID_CONTROL], [ID_IDIOMA], [TEXTO_TRADUCIDO]) VALUES (428, 99, 1, N'Volver al Menu')
INSERT [dbo].[TRADUCCION] ([ID_TRADUCCION], [ID_CONTROL], [ID_IDIOMA], [TEXTO_TRADUCIDO]) VALUES (429, 100, 1, N'Productos')
INSERT [dbo].[TRADUCCION] ([ID_TRADUCCION], [ID_CONTROL], [ID_IDIOMA], [TEXTO_TRADUCIDO]) VALUES (430, 101, 1, N'Datos del producto')
INSERT [dbo].[TRADUCCION] ([ID_TRADUCCION], [ID_CONTROL], [ID_IDIOMA], [TEXTO_TRADUCIDO]) VALUES (431, 84, 2, N'Users')
INSERT [dbo].[TRADUCCION] ([ID_TRADUCCION], [ID_CONTROL], [ID_IDIOMA], [TEXTO_TRADUCIDO]) VALUES (432, 85, 2, N'User data')
INSERT [dbo].[TRADUCCION] ([ID_TRADUCCION], [ID_CONTROL], [ID_IDIOMA], [TEXTO_TRADUCIDO]) VALUES (433, 86, 2, N'All roles')
INSERT [dbo].[TRADUCCION] ([ID_TRADUCCION], [ID_CONTROL], [ID_IDIOMA], [TEXTO_TRADUCIDO]) VALUES (439, 88, 2, N'All permissions')
INSERT [dbo].[TRADUCCION] ([ID_TRADUCCION], [ID_CONTROL], [ID_IDIOMA], [TEXTO_TRADUCIDO]) VALUES (440, 89, 2, N'Language')
INSERT [dbo].[TRADUCCION] ([ID_TRADUCCION], [ID_CONTROL], [ID_IDIOMA], [TEXTO_TRADUCIDO]) VALUES (441, 90, 2, N'New language')
INSERT [dbo].[TRADUCCION] ([ID_TRADUCCION], [ID_CONTROL], [ID_IDIOMA], [TEXTO_TRADUCIDO]) VALUES (442, 91, 2, N'Translations')
INSERT [dbo].[TRADUCCION] ([ID_TRADUCCION], [ID_CONTROL], [ID_IDIOMA], [TEXTO_TRADUCIDO]) VALUES (443, 92, 2, N'Language')
INSERT [dbo].[TRADUCCION] ([ID_TRADUCCION], [ID_CONTROL], [ID_IDIOMA], [TEXTO_TRADUCIDO]) VALUES (444, 93, 2, N'Name')
INSERT [dbo].[TRADUCCION] ([ID_TRADUCCION], [ID_CONTROL], [ID_IDIOMA], [TEXTO_TRADUCIDO]) VALUES (445, 94, 2, N'Price')
INSERT [dbo].[TRADUCCION] ([ID_TRADUCCION], [ID_CONTROL], [ID_IDIOMA], [TEXTO_TRADUCIDO]) VALUES (446, 95, 2, N'Stock')
INSERT [dbo].[TRADUCCION] ([ID_TRADUCCION], [ID_CONTROL], [ID_IDIOMA], [TEXTO_TRADUCIDO]) VALUES (447, 96, 2, N'Insert')
INSERT [dbo].[TRADUCCION] ([ID_TRADUCCION], [ID_CONTROL], [ID_IDIOMA], [TEXTO_TRADUCIDO]) VALUES (448, 97, 2, N'Delete')
INSERT [dbo].[TRADUCCION] ([ID_TRADUCCION], [ID_CONTROL], [ID_IDIOMA], [TEXTO_TRADUCIDO]) VALUES (449, 98, 2, N'Modify')
INSERT [dbo].[TRADUCCION] ([ID_TRADUCCION], [ID_CONTROL], [ID_IDIOMA], [TEXTO_TRADUCIDO]) VALUES (450, 99, 2, N'Back to the menu')
INSERT [dbo].[TRADUCCION] ([ID_TRADUCCION], [ID_CONTROL], [ID_IDIOMA], [TEXTO_TRADUCIDO]) VALUES (451, 100, 2, N'Products')
INSERT [dbo].[TRADUCCION] ([ID_TRADUCCION], [ID_CONTROL], [ID_IDIOMA], [TEXTO_TRADUCIDO]) VALUES (452, 101, 2, N'Product data')
INSERT [dbo].[TRADUCCION] ([ID_TRADUCCION], [ID_CONTROL], [ID_IDIOMA], [TEXTO_TRADUCIDO]) VALUES (453, 102, 1, N'Productos')
INSERT [dbo].[TRADUCCION] ([ID_TRADUCCION], [ID_CONTROL], [ID_IDIOMA], [TEXTO_TRADUCIDO]) VALUES (454, 102, 2, N'Products')
INSERT [dbo].[TRADUCCION] ([ID_TRADUCCION], [ID_CONTROL], [ID_IDIOMA], [TEXTO_TRADUCIDO]) VALUES (455, 1, 3, N'Usuario_FRA')
INSERT [dbo].[TRADUCCION] ([ID_TRADUCCION], [ID_CONTROL], [ID_IDIOMA], [TEXTO_TRADUCIDO]) VALUES (456, 2, 3, N'Contraseña_FRA')
INSERT [dbo].[TRADUCCION] ([ID_TRADUCCION], [ID_CONTROL], [ID_IDIOMA], [TEXTO_TRADUCIDO]) VALUES (457, 3, 3, N'Idioma_FRA')
INSERT [dbo].[TRADUCCION] ([ID_TRADUCCION], [ID_CONTROL], [ID_IDIOMA], [TEXTO_TRADUCIDO]) VALUES (458, 4, 3, N'Iniciar Sesion_FRA')
INSERT [dbo].[TRADUCCION] ([ID_TRADUCCION], [ID_CONTROL], [ID_IDIOMA], [TEXTO_TRADUCIDO]) VALUES (459, 5, 3, N'Bienvenido: {0}_FRA')
GO
INSERT [dbo].[TRADUCCION] ([ID_TRADUCCION], [ID_CONTROL], [ID_IDIOMA], [TEXTO_TRADUCIDO]) VALUES (460, 6, 3, N'Cerrar Sesion_FRA')
INSERT [dbo].[TRADUCCION] ([ID_TRADUCCION], [ID_CONTROL], [ID_IDIOMA], [TEXTO_TRADUCIDO]) VALUES (461, 7, 3, N'Administracion_FRA')
INSERT [dbo].[TRADUCCION] ([ID_TRADUCCION], [ID_CONTROL], [ID_IDIOMA], [TEXTO_TRADUCIDO]) VALUES (462, 8, 3, N'Bitacora_FRA')
INSERT [dbo].[TRADUCCION] ([ID_TRADUCCION], [ID_CONTROL], [ID_IDIOMA], [TEXTO_TRADUCIDO]) VALUES (463, 9, 3, N'Control de Usuarios_FRA')
INSERT [dbo].[TRADUCCION] ([ID_TRADUCCION], [ID_CONTROL], [ID_IDIOMA], [TEXTO_TRADUCIDO]) VALUES (464, 10, 3, N'Control de Permisos_FRA')
INSERT [dbo].[TRADUCCION] ([ID_TRADUCCION], [ID_CONTROL], [ID_IDIOMA], [TEXTO_TRADUCIDO]) VALUES (465, 11, 3, N'Usuario_FRA')
INSERT [dbo].[TRADUCCION] ([ID_TRADUCCION], [ID_CONTROL], [ID_IDIOMA], [TEXTO_TRADUCIDO]) VALUES (466, 12, 3, N'Contraseña_FRA')
INSERT [dbo].[TRADUCCION] ([ID_TRADUCCION], [ID_CONTROL], [ID_IDIOMA], [TEXTO_TRADUCIDO]) VALUES (467, 13, 3, N'DNI_FRA')
INSERT [dbo].[TRADUCCION] ([ID_TRADUCCION], [ID_CONTROL], [ID_IDIOMA], [TEXTO_TRADUCIDO]) VALUES (468, 14, 3, N'Email_FRA')
INSERT [dbo].[TRADUCCION] ([ID_TRADUCCION], [ID_CONTROL], [ID_IDIOMA], [TEXTO_TRADUCIDO]) VALUES (469, 15, 3, N'Rol_FRA')
INSERT [dbo].[TRADUCCION] ([ID_TRADUCCION], [ID_CONTROL], [ID_IDIOMA], [TEXTO_TRADUCIDO]) VALUES (470, 16, 3, N'Rol de Usuario_FRA')
INSERT [dbo].[TRADUCCION] ([ID_TRADUCCION], [ID_CONTROL], [ID_IDIOMA], [TEXTO_TRADUCIDO]) VALUES (471, 17, 3, N'Mostrar Bloqueados_FRA')
INSERT [dbo].[TRADUCCION] ([ID_TRADUCCION], [ID_CONTROL], [ID_IDIOMA], [TEXTO_TRADUCIDO]) VALUES (472, 18, 3, N'Alta_FRA')
INSERT [dbo].[TRADUCCION] ([ID_TRADUCCION], [ID_CONTROL], [ID_IDIOMA], [TEXTO_TRADUCIDO]) VALUES (473, 19, 3, N'Baja_FRA')
INSERT [dbo].[TRADUCCION] ([ID_TRADUCCION], [ID_CONTROL], [ID_IDIOMA], [TEXTO_TRADUCIDO]) VALUES (474, 20, 3, N'Modificar_FRA')
INSERT [dbo].[TRADUCCION] ([ID_TRADUCCION], [ID_CONTROL], [ID_IDIOMA], [TEXTO_TRADUCIDO]) VALUES (475, 21, 3, N'Desbloquear_FRA')
INSERT [dbo].[TRADUCCION] ([ID_TRADUCCION], [ID_CONTROL], [ID_IDIOMA], [TEXTO_TRADUCIDO]) VALUES (476, 22, 3, N'Volver al Menu_FRA')
INSERT [dbo].[TRADUCCION] ([ID_TRADUCCION], [ID_CONTROL], [ID_IDIOMA], [TEXTO_TRADUCIDO]) VALUES (477, 23, 3, N'Nombre_FRA')
INSERT [dbo].[TRADUCCION] ([ID_TRADUCCION], [ID_CONTROL], [ID_IDIOMA], [TEXTO_TRADUCIDO]) VALUES (478, 24, 3, N'Asignar_FRA')
INSERT [dbo].[TRADUCCION] ([ID_TRADUCCION], [ID_CONTROL], [ID_IDIOMA], [TEXTO_TRADUCIDO]) VALUES (479, 25, 3, N'Desasignar_FRA')
INSERT [dbo].[TRADUCCION] ([ID_TRADUCCION], [ID_CONTROL], [ID_IDIOMA], [TEXTO_TRADUCIDO]) VALUES (480, 26, 3, N'Crear Rol_FRA')
INSERT [dbo].[TRADUCCION] ([ID_TRADUCCION], [ID_CONTROL], [ID_IDIOMA], [TEXTO_TRADUCIDO]) VALUES (481, 27, 3, N'Bitacora_FRA')
INSERT [dbo].[TRADUCCION] ([ID_TRADUCCION], [ID_CONTROL], [ID_IDIOMA], [TEXTO_TRADUCIDO]) VALUES (482, 28, 3, N'Filtros_FRA')
INSERT [dbo].[TRADUCCION] ([ID_TRADUCCION], [ID_CONTROL], [ID_IDIOMA], [TEXTO_TRADUCIDO]) VALUES (483, 29, 3, N'Usuario_FRA')
INSERT [dbo].[TRADUCCION] ([ID_TRADUCCION], [ID_CONTROL], [ID_IDIOMA], [TEXTO_TRADUCIDO]) VALUES (484, 30, 3, N'Modulo_FRA')
INSERT [dbo].[TRADUCCION] ([ID_TRADUCCION], [ID_CONTROL], [ID_IDIOMA], [TEXTO_TRADUCIDO]) VALUES (485, 31, 3, N'Criticidad_FRA')
INSERT [dbo].[TRADUCCION] ([ID_TRADUCCION], [ID_CONTROL], [ID_IDIOMA], [TEXTO_TRADUCIDO]) VALUES (486, 32, 3, N'Fecha Inicial_FRA')
INSERT [dbo].[TRADUCCION] ([ID_TRADUCCION], [ID_CONTROL], [ID_IDIOMA], [TEXTO_TRADUCIDO]) VALUES (487, 33, 3, N'Fecha Final_FRA')
INSERT [dbo].[TRADUCCION] ([ID_TRADUCCION], [ID_CONTROL], [ID_IDIOMA], [TEXTO_TRADUCIDO]) VALUES (488, 34, 3, N'Incluir Fechas_FRA')
INSERT [dbo].[TRADUCCION] ([ID_TRADUCCION], [ID_CONTROL], [ID_IDIOMA], [TEXTO_TRADUCIDO]) VALUES (489, 35, 3, N'Filtrar_FRA')
INSERT [dbo].[TRADUCCION] ([ID_TRADUCCION], [ID_CONTROL], [ID_IDIOMA], [TEXTO_TRADUCIDO]) VALUES (490, 36, 3, N'Volver al Menu Principal_FRA')
INSERT [dbo].[TRADUCCION] ([ID_TRADUCCION], [ID_CONTROL], [ID_IDIOMA], [TEXTO_TRADUCIDO]) VALUES (491, 37, 3, N'Idiomas_FRA')
INSERT [dbo].[TRADUCCION] ([ID_TRADUCCION], [ID_CONTROL], [ID_IDIOMA], [TEXTO_TRADUCIDO]) VALUES (492, 39, 3, N'Idiomas_FRA')
INSERT [dbo].[TRADUCCION] ([ID_TRADUCCION], [ID_CONTROL], [ID_IDIOMA], [TEXTO_TRADUCIDO]) VALUES (493, 41, 3, N'Idiomas_FRA')
INSERT [dbo].[TRADUCCION] ([ID_TRADUCCION], [ID_CONTROL], [ID_IDIOMA], [TEXTO_TRADUCIDO]) VALUES (494, 43, 3, N'Idiomas_FRA')
INSERT [dbo].[TRADUCCION] ([ID_TRADUCCION], [ID_CONTROL], [ID_IDIOMA], [TEXTO_TRADUCIDO]) VALUES (495, 45, 3, N'Control de Idioma_FRA')
INSERT [dbo].[TRADUCCION] ([ID_TRADUCCION], [ID_CONTROL], [ID_IDIOMA], [TEXTO_TRADUCIDO]) VALUES (496, 46, 3, N'Idiomas_FRA')
INSERT [dbo].[TRADUCCION] ([ID_TRADUCCION], [ID_CONTROL], [ID_IDIOMA], [TEXTO_TRADUCIDO]) VALUES (497, 47, 3, N'Idiomas_FRA')
INSERT [dbo].[TRADUCCION] ([ID_TRADUCCION], [ID_CONTROL], [ID_IDIOMA], [TEXTO_TRADUCIDO]) VALUES (498, 48, 3, N'Nombre_FRA')
INSERT [dbo].[TRADUCCION] ([ID_TRADUCCION], [ID_CONTROL], [ID_IDIOMA], [TEXTO_TRADUCIDO]) VALUES (499, 49, 3, N'Sufijo_FRA')
INSERT [dbo].[TRADUCCION] ([ID_TRADUCCION], [ID_CONTROL], [ID_IDIOMA], [TEXTO_TRADUCIDO]) VALUES (500, 50, 3, N'Crear_FRA')
INSERT [dbo].[TRADUCCION] ([ID_TRADUCCION], [ID_CONTROL], [ID_IDIOMA], [TEXTO_TRADUCIDO]) VALUES (501, 51, 3, N'Deshabilitar_FRA')
INSERT [dbo].[TRADUCCION] ([ID_TRADUCCION], [ID_CONTROL], [ID_IDIOMA], [TEXTO_TRADUCIDO]) VALUES (502, 52, 3, N'Volver al menu_FRA')
INSERT [dbo].[TRADUCCION] ([ID_TRADUCCION], [ID_CONTROL], [ID_IDIOMA], [TEXTO_TRADUCIDO]) VALUES (503, 53, 3, N'Modificar_FRA')
INSERT [dbo].[TRADUCCION] ([ID_TRADUCCION], [ID_CONTROL], [ID_IDIOMA], [TEXTO_TRADUCIDO]) VALUES (504, 54, 3, N'Borrar_FRA')
INSERT [dbo].[TRADUCCION] ([ID_TRADUCCION], [ID_CONTROL], [ID_IDIOMA], [TEXTO_TRADUCIDO]) VALUES (505, 55, 3, N'Todos los roles y permisos_FRA')
INSERT [dbo].[TRADUCCION] ([ID_TRADUCCION], [ID_CONTROL], [ID_IDIOMA], [TEXTO_TRADUCIDO]) VALUES (506, 56, 3, N'Arbol de roles_FRA')
INSERT [dbo].[TRADUCCION] ([ID_TRADUCCION], [ID_CONTROL], [ID_IDIOMA], [TEXTO_TRADUCIDO]) VALUES (507, 57, 3, N'Iniciar Sesion_FRA')
INSERT [dbo].[TRADUCCION] ([ID_TRADUCCION], [ID_CONTROL], [ID_IDIOMA], [TEXTO_TRADUCIDO]) VALUES (508, 58, 3, N'Menu Principal_FRA')
INSERT [dbo].[TRADUCCION] ([ID_TRADUCCION], [ID_CONTROL], [ID_IDIOMA], [TEXTO_TRADUCIDO]) VALUES (509, 59, 3, N'Control de idiomas_FRA')
INSERT [dbo].[TRADUCCION] ([ID_TRADUCCION], [ID_CONTROL], [ID_IDIOMA], [TEXTO_TRADUCIDO]) VALUES (510, 60, 3, N'Control de usuarios_FRA')
INSERT [dbo].[TRADUCCION] ([ID_TRADUCCION], [ID_CONTROL], [ID_IDIOMA], [TEXTO_TRADUCIDO]) VALUES (511, 61, 3, N'Control de Permisos_FRA')
INSERT [dbo].[TRADUCCION] ([ID_TRADUCCION], [ID_CONTROL], [ID_IDIOMA], [TEXTO_TRADUCIDO]) VALUES (512, 62, 3, N'Bitacora_FRA')
INSERT [dbo].[TRADUCCION] ([ID_TRADUCCION], [ID_CONTROL], [ID_IDIOMA], [TEXTO_TRADUCIDO]) VALUES (513, 63, 3, N'Habilitar_FRA')
INSERT [dbo].[TRADUCCION] ([ID_TRADUCCION], [ID_CONTROL], [ID_IDIOMA], [TEXTO_TRADUCIDO]) VALUES (514, 64, 3, N'Idiomas_FRA')
INSERT [dbo].[TRADUCCION] ([ID_TRADUCCION], [ID_CONTROL], [ID_IDIOMA], [TEXTO_TRADUCIDO]) VALUES (515, 65, 3, N'Historial_FRA')
INSERT [dbo].[TRADUCCION] ([ID_TRADUCCION], [ID_CONTROL], [ID_IDIOMA], [TEXTO_TRADUCIDO]) VALUES (516, 66, 3, N'Usuario_FRA')
INSERT [dbo].[TRADUCCION] ([ID_TRADUCCION], [ID_CONTROL], [ID_IDIOMA], [TEXTO_TRADUCIDO]) VALUES (517, 67, 3, N'Restaurar_FRA')
INSERT [dbo].[TRADUCCION] ([ID_TRADUCCION], [ID_CONTROL], [ID_IDIOMA], [TEXTO_TRADUCIDO]) VALUES (518, 68, 3, N'Volver al menu_FRA')
INSERT [dbo].[TRADUCCION] ([ID_TRADUCCION], [ID_CONTROL], [ID_IDIOMA], [TEXTO_TRADUCIDO]) VALUES (519, 69, 3, N'Historial de cambios_FRA')
INSERT [dbo].[TRADUCCION] ([ID_TRADUCCION], [ID_CONTROL], [ID_IDIOMA], [TEXTO_TRADUCIDO]) VALUES (520, 70, 3, N'Idiomas_FRA')
INSERT [dbo].[TRADUCCION] ([ID_TRADUCCION], [ID_CONTROL], [ID_IDIOMA], [TEXTO_TRADUCIDO]) VALUES (521, 71, 3, N'Mensaje de error_FRA')
INSERT [dbo].[TRADUCCION] ([ID_TRADUCCION], [ID_CONTROL], [ID_IDIOMA], [TEXTO_TRADUCIDO]) VALUES (522, 72, 3, N'Crear Back Up_FRA')
INSERT [dbo].[TRADUCCION] ([ID_TRADUCCION], [ID_CONTROL], [ID_IDIOMA], [TEXTO_TRADUCIDO]) VALUES (523, 73, 3, N'Examinar_FRA')
INSERT [dbo].[TRADUCCION] ([ID_TRADUCCION], [ID_CONTROL], [ID_IDIOMA], [TEXTO_TRADUCIDO]) VALUES (524, 74, 3, N'Restaurar Base_FRA')
INSERT [dbo].[TRADUCCION] ([ID_TRADUCCION], [ID_CONTROL], [ID_IDIOMA], [TEXTO_TRADUCIDO]) VALUES (525, 75, 3, N'Recalcular digito verificador_FRA')
INSERT [dbo].[TRADUCCION] ([ID_TRADUCCION], [ID_CONTROL], [ID_IDIOMA], [TEXTO_TRADUCIDO]) VALUES (526, 76, 3, N'Volver al menu_FRA')
INSERT [dbo].[TRADUCCION] ([ID_TRADUCCION], [ID_CONTROL], [ID_IDIOMA], [TEXTO_TRADUCIDO]) VALUES (527, 77, 3, N'Control de restauracion_FRA')
INSERT [dbo].[TRADUCCION] ([ID_TRADUCCION], [ID_CONTROL], [ID_IDIOMA], [TEXTO_TRADUCIDO]) VALUES (528, 78, 3, N'Rol_FRA')
INSERT [dbo].[TRADUCCION] ([ID_TRADUCCION], [ID_CONTROL], [ID_IDIOMA], [TEXTO_TRADUCIDO]) VALUES (529, 79, 3, N'Control de restauracion_FRA')
INSERT [dbo].[TRADUCCION] ([ID_TRADUCCION], [ID_CONTROL], [ID_IDIOMA], [TEXTO_TRADUCIDO]) VALUES (530, 80, 3, N'Historial de cambios_FRA')
INSERT [dbo].[TRADUCCION] ([ID_TRADUCCION], [ID_CONTROL], [ID_IDIOMA], [TEXTO_TRADUCIDO]) VALUES (531, 81, 3, N'Historial de cambios_FRA')
INSERT [dbo].[TRADUCCION] ([ID_TRADUCCION], [ID_CONTROL], [ID_IDIOMA], [TEXTO_TRADUCIDO]) VALUES (532, 82, 3, N'Filtrar_FRA')
INSERT [dbo].[TRADUCCION] ([ID_TRADUCCION], [ID_CONTROL], [ID_IDIOMA], [TEXTO_TRADUCIDO]) VALUES (533, 83, 3, N'Ver todo_FRA')
INSERT [dbo].[TRADUCCION] ([ID_TRADUCCION], [ID_CONTROL], [ID_IDIOMA], [TEXTO_TRADUCIDO]) VALUES (534, 84, 3, N'Usuarios_FRA')
INSERT [dbo].[TRADUCCION] ([ID_TRADUCCION], [ID_CONTROL], [ID_IDIOMA], [TEXTO_TRADUCIDO]) VALUES (535, 85, 3, N'Datos de usuario_FRA')
INSERT [dbo].[TRADUCCION] ([ID_TRADUCCION], [ID_CONTROL], [ID_IDIOMA], [TEXTO_TRADUCIDO]) VALUES (536, 86, 3, N'Todos los roles_FRA')
INSERT [dbo].[TRADUCCION] ([ID_TRADUCCION], [ID_CONTROL], [ID_IDIOMA], [TEXTO_TRADUCIDO]) VALUES (537, 88, 3, N'Todos los permisos_FRA')
INSERT [dbo].[TRADUCCION] ([ID_TRADUCCION], [ID_CONTROL], [ID_IDIOMA], [TEXTO_TRADUCIDO]) VALUES (538, 89, 3, N'Idiomas_FRA')
INSERT [dbo].[TRADUCCION] ([ID_TRADUCCION], [ID_CONTROL], [ID_IDIOMA], [TEXTO_TRADUCIDO]) VALUES (539, 90, 3, N'Nuevo Idioma_FRA')
INSERT [dbo].[TRADUCCION] ([ID_TRADUCCION], [ID_CONTROL], [ID_IDIOMA], [TEXTO_TRADUCIDO]) VALUES (540, 91, 3, N'Traducciones_FRA')
INSERT [dbo].[TRADUCCION] ([ID_TRADUCCION], [ID_CONTROL], [ID_IDIOMA], [TEXTO_TRADUCIDO]) VALUES (541, 92, 3, N'Idiomas_FRA')
INSERT [dbo].[TRADUCCION] ([ID_TRADUCCION], [ID_CONTROL], [ID_IDIOMA], [TEXTO_TRADUCIDO]) VALUES (542, 93, 3, N'Nombre_FRA')
INSERT [dbo].[TRADUCCION] ([ID_TRADUCCION], [ID_CONTROL], [ID_IDIOMA], [TEXTO_TRADUCIDO]) VALUES (543, 94, 3, N'Precio_FRA')
INSERT [dbo].[TRADUCCION] ([ID_TRADUCCION], [ID_CONTROL], [ID_IDIOMA], [TEXTO_TRADUCIDO]) VALUES (544, 95, 3, N'Stock_FRA')
INSERT [dbo].[TRADUCCION] ([ID_TRADUCCION], [ID_CONTROL], [ID_IDIOMA], [TEXTO_TRADUCIDO]) VALUES (545, 96, 3, N'Alta_FRA')
INSERT [dbo].[TRADUCCION] ([ID_TRADUCCION], [ID_CONTROL], [ID_IDIOMA], [TEXTO_TRADUCIDO]) VALUES (546, 97, 3, N'Baja_FRA')
INSERT [dbo].[TRADUCCION] ([ID_TRADUCCION], [ID_CONTROL], [ID_IDIOMA], [TEXTO_TRADUCIDO]) VALUES (547, 98, 3, N'Modificar_FRA')
INSERT [dbo].[TRADUCCION] ([ID_TRADUCCION], [ID_CONTROL], [ID_IDIOMA], [TEXTO_TRADUCIDO]) VALUES (548, 99, 3, N'Volver al Menu_FRA')
INSERT [dbo].[TRADUCCION] ([ID_TRADUCCION], [ID_CONTROL], [ID_IDIOMA], [TEXTO_TRADUCIDO]) VALUES (549, 100, 3, N'Productos_FRA')
INSERT [dbo].[TRADUCCION] ([ID_TRADUCCION], [ID_CONTROL], [ID_IDIOMA], [TEXTO_TRADUCIDO]) VALUES (550, 101, 3, N'Datos del producto_FRA')
INSERT [dbo].[TRADUCCION] ([ID_TRADUCCION], [ID_CONTROL], [ID_IDIOMA], [TEXTO_TRADUCIDO]) VALUES (551, 102, 3, N'Productos_FRA')
SET IDENTITY_INSERT [dbo].[TRADUCCION] OFF
GO
INSERT [dbo].[USUARIO] ([ID], [USUARIO], [CONTRASEÑA], [ESTADOBLOQUEADO], [INTENTOSFALLIDOS], [DNI], [EMAIL], [ID_IDIOMA], [DVH], [ACTIVO]) VALUES (1, N'tp', N'3abd807250d1b53741c345896f2d79faf6e7dcdb75860e98a2f84e38e874c236', 0, 0, 23423423, N'admin123@gmail.com', 1, N'05bdb046c99decba811a2018ff52c642ed2eae293975df39fd09d60a025eba60', 1)
INSERT [dbo].[USUARIO] ([ID], [USUARIO], [CONTRASEÑA], [ESTADOBLOQUEADO], [INTENTOSFALLIDOS], [DNI], [EMAIL], [ID_IDIOMA], [DVH], [ACTIVO]) VALUES (2, N'mg', N'e9949d904d436e1fd21b1ac234c1fad20b0939f0d6f4292f78625cebaf267ed8', 0, 0, 1234, N'mg@gmail,com', 1, N'f008720f82f2a40b75f11bd49b7be32ae65f4e5f3ae452cc12dfb94e4db5deff', 1)
INSERT [dbo].[USUARIO] ([ID], [USUARIO], [CONTRASEÑA], [ESTADOBLOQUEADO], [INTENTOSFALLIDOS], [DNI], [EMAIL], [ID_IDIOMA], [DVH], [ACTIVO]) VALUES (3, N'PruebaBaja', N'655e786674d9d3e77bc05ed1de37b4b6bc89f788829f9f3c679e7687b410c89b', 0, 0, 123, N'prueba', 1, N'34743c25529e91232097ce0359d2c95c017b16a24c3af324cd803cc36d1160d4', 1)
INSERT [dbo].[USUARIO] ([ID], [USUARIO], [CONTRASEÑA], [ESTADOBLOQUEADO], [INTENTOSFALLIDOS], [DNI], [EMAIL], [ID_IDIOMA], [DVH], [ACTIVO]) VALUES (4, N'inactivo', N'99acacf317cc8ef9e7b0ade6590d491fe247381679e7e131582055e00d9b0345', 0, 0, 12345, N'ccc', 1, N'62d8bb55b99d56f0e02efef0e2ec23e3c975d76c2f3f25d0bc5e8f0c1ab1b3ff', 1)
INSERT [dbo].[USUARIO] ([ID], [USUARIO], [CONTRASEÑA], [ESTADOBLOQUEADO], [INTENTOSFALLIDOS], [DNI], [EMAIL], [ID_IDIOMA], [DVH], [ACTIVO]) VALUES (5, N'usuinactivo', N'3abd807250d1b53741c345896f2d79faf6e7dcdb75860e98a2f84e38e874c236', 0, 0, 123444, N'asdddd@gmail.com', 1, N'07a2a6a628290670f1e2b23bba8302db0b846947976aa069a0406da68eb0deea', 1)
GO
INSERT [dbo].[USUARIO_PERMISO] ([ID_USUARIO], [ID_PERMISO]) VALUES (1, 1)
INSERT [dbo].[USUARIO_PERMISO] ([ID_USUARIO], [ID_PERMISO]) VALUES (2, 14)
INSERT [dbo].[USUARIO_PERMISO] ([ID_USUARIO], [ID_PERMISO]) VALUES (3, 1)
INSERT [dbo].[USUARIO_PERMISO] ([ID_USUARIO], [ID_PERMISO]) VALUES (4, 1)
INSERT [dbo].[USUARIO_PERMISO] ([ID_USUARIO], [ID_PERMISO]) VALUES (5, 1)
GO
ALTER TABLE [dbo].[DETALLE_OC] ADD  DEFAULT ((0)) FOR [Cantidad_Recibida]
GO
ALTER TABLE [dbo].[HISTORIAL_PRODUCTO] ADD  DEFAULT (getdate()) FOR [Fecha_Cambio]
GO
ALTER TABLE [dbo].[HISTORIAL_USUARIO] ADD  DEFAULT ((1)) FOR [ACTIVO]
GO
ALTER TABLE [dbo].[IDIOMA] ADD  DEFAULT ((1)) FOR [ESTADISPONIBLE]
GO
ALTER TABLE [dbo].[INSUMO] ADD  DEFAULT ((0)) FOR [Stock_Actual]
GO
ALTER TABLE [dbo].[INSUMO] ADD  DEFAULT ((0)) FOR [Stock_Minimo]
GO
ALTER TABLE [dbo].[INSUMO] ADD  DEFAULT ('Activo') FOR [Estado]
GO
ALTER TABLE [dbo].[INVENTARIO] ADD  DEFAULT ((0)) FOR [Stock_Actual]
GO
ALTER TABLE [dbo].[PARAMETRO_RATIO] ADD  DEFAULT ('Activo') FOR [Estado]
GO
ALTER TABLE [dbo].[PERSONAL] ADD  DEFAULT ('Activo') FOR [Estado]
GO
ALTER TABLE [dbo].[PRESTADOR_SERVICIO] ADD  DEFAULT ((0)) FOR [Precio_Servicio]
GO
ALTER TABLE [dbo].[PRODUCTO] ADD  DEFAULT ((1)) FOR [ACTIVO]
GO
ALTER TABLE [dbo].[PROVEEDOR_INSUMO] ADD  DEFAULT ('Activo') FOR [Estado]
GO
ALTER TABLE [dbo].[USUARIO] ADD  CONSTRAINT [DF_USUARIO_ESTADOBLOQUEADO]  DEFAULT ((0)) FOR [ESTADOBLOQUEADO]
GO
ALTER TABLE [dbo].[USUARIO] ADD  CONSTRAINT [DF_USUARIO_INTENTOSFALLIDOS]  DEFAULT ((0)) FOR [INTENTOSFALLIDOS]
GO
ALTER TABLE [dbo].[USUARIO] ADD  CONSTRAINT [DF_USUARIO_DNI]  DEFAULT ((0)) FOR [DNI]
GO
ALTER TABLE [dbo].[USUARIO] ADD  DEFAULT ((1)) FOR [ACTIVO]
GO
ALTER TABLE [dbo].[DETALLE_OC]  WITH CHECK ADD FOREIGN KEY([Id_OrdenCompra])
REFERENCES [dbo].[ORDEN_COMPRA] ([Id_OrdenCompra])
GO
ALTER TABLE [dbo].[FICHA_PRESTADORES]  WITH CHECK ADD FOREIGN KEY([Id_Ficha])
REFERENCES [dbo].[FICHA_TECNICA] ([Id_Ficha])
GO
ALTER TABLE [dbo].[FICHA_PRESTADORES]  WITH CHECK ADD FOREIGN KEY([Id_Prestador])
REFERENCES [dbo].[PRESTADOR_SERVICIO] ([Id_Prestador])
GO
ALTER TABLE [dbo].[FICHA_TECNICA]  WITH CHECK ADD FOREIGN KEY([Id_Reserva])
REFERENCES [dbo].[RESERVA] ([Id_Reserva])
GO
ALTER TABLE [dbo].[FICHA_TECNICA]  WITH CHECK ADD FOREIGN KEY([Id_Servicio])
REFERENCES [dbo].[SERVICIO_CATERING] ([Id_Servicio])
GO
ALTER TABLE [dbo].[ORDEN_COMPRA]  WITH CHECK ADD FOREIGN KEY([Id_Ficha])
REFERENCES [dbo].[FICHA_TECNICA] ([Id_Ficha])
GO
ALTER TABLE [dbo].[ORDEN_COMPRA]  WITH CHECK ADD FOREIGN KEY([Id_Proveedor])
REFERENCES [dbo].[PRESTADOR_SERVICIO] ([Id_Prestador])
GO
ALTER TABLE [dbo].[PERMISO_PERMISO]  WITH CHECK ADD FOREIGN KEY([ID_HIJO])
REFERENCES [dbo].[PERMISO] ([ID])
GO
ALTER TABLE [dbo].[PERMISO_PERMISO]  WITH CHECK ADD FOREIGN KEY([ID_HIJO])
REFERENCES [dbo].[PERMISO] ([ID])
GO
ALTER TABLE [dbo].[PERMISO_PERMISO]  WITH CHECK ADD FOREIGN KEY([ID_HIJO])
REFERENCES [dbo].[PERMISO] ([ID])
GO
ALTER TABLE [dbo].[PERMISO_PERMISO]  WITH CHECK ADD FOREIGN KEY([ID_PADRE])
REFERENCES [dbo].[PERMISO] ([ID])
GO
ALTER TABLE [dbo].[PERMISO_PERMISO]  WITH CHECK ADD FOREIGN KEY([ID_PADRE])
REFERENCES [dbo].[PERMISO] ([ID])
GO
ALTER TABLE [dbo].[PERMISO_PERMISO]  WITH CHECK ADD FOREIGN KEY([ID_PADRE])
REFERENCES [dbo].[PERMISO] ([ID])
GO
ALTER TABLE [dbo].[RECETARIO]  WITH CHECK ADD  CONSTRAINT [FK_Recetario_Insumo] FOREIGN KEY([Id_Insumo])
REFERENCES [dbo].[INSUMO] ([Id_Insumo])
GO
ALTER TABLE [dbo].[RECETARIO] CHECK CONSTRAINT [FK_Recetario_Insumo]
GO
ALTER TABLE [dbo].[RECETARIO]  WITH CHECK ADD  CONSTRAINT [FK_Recetario_Servicio] FOREIGN KEY([Id_Servicio])
REFERENCES [dbo].[SERVICIO_CATERING] ([Id_Servicio])
GO
ALTER TABLE [dbo].[RECETARIO] CHECK CONSTRAINT [FK_Recetario_Servicio]
GO
ALTER TABLE [dbo].[RESERVA]  WITH CHECK ADD  CONSTRAINT [FK__RESERVA__Id_Clie__1EA48E88] FOREIGN KEY([Id_Cliente])
REFERENCES [dbo].[CLIENTE] ([Id_Cliente])
GO
ALTER TABLE [dbo].[RESERVA] CHECK CONSTRAINT [FK__RESERVA__Id_Clie__1EA48E88]
GO
ALTER TABLE [dbo].[RESERVA]  WITH CHECK ADD FOREIGN KEY([Id_Presupuesto])
REFERENCES [dbo].[PRESUPUESTO] ([Id_Presupuesto])
GO
ALTER TABLE [dbo].[TRADUCCION]  WITH CHECK ADD FOREIGN KEY([ID_CONTROL])
REFERENCES [dbo].[CONTROL] ([ID_CONTROL])
GO
ALTER TABLE [dbo].[TRADUCCION]  WITH CHECK ADD FOREIGN KEY([ID_IDIOMA])
REFERENCES [dbo].[IDIOMA] ([ID_IDIOMA])
GO
ALTER TABLE [dbo].[USUARIO_PERMISO]  WITH CHECK ADD  CONSTRAINT [FK_USUARIO_PERMISO_PERMISO] FOREIGN KEY([ID_PERMISO])
REFERENCES [dbo].[PERMISO] ([ID])
GO
ALTER TABLE [dbo].[USUARIO_PERMISO] CHECK CONSTRAINT [FK_USUARIO_PERMISO_PERMISO]
GO
ALTER TABLE [dbo].[USUARIO_PERMISO]  WITH CHECK ADD  CONSTRAINT [FK_USUARIO_PERMISO_USUARIO] FOREIGN KEY([ID_USUARIO])
REFERENCES [dbo].[USUARIO] ([ID])
GO
ALTER TABLE [dbo].[USUARIO_PERMISO] CHECK CONSTRAINT [FK_USUARIO_PERMISO_USUARIO]
GO
/****** Object:  StoredProcedure [dbo].[ACTUALIZAR_CANTIDAD_RECIBIDA_DETALLE]    Script Date: 24/11/2026 19:46:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   PROCEDURE [dbo].[ACTUALIZAR_CANTIDAD_RECIBIDA_DETALLE]
    @Id_Detalle INT,
    @Cantidad_Recibida INT
AS
BEGIN
    UPDATE DETALLE_OC
    SET Cantidad_Recibida = @Cantidad_Recibida
    WHERE Id_Detalle = @Id_Detalle;
END;

GO
/****** Object:  StoredProcedure [dbo].[ACTUALIZAR_DVH_USUARIO]    Script Date: 24/11/2026 19:46:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[ACTUALIZAR_DVH_USUARIO]
@id int,
@dvh varchar(max)
AS
BEGIN
    UPDATE USUARIO SET DVH = @dvh WHERE ID = @id
END

GO
/****** Object:  StoredProcedure [dbo].[ACTUALIZAR_DVV]    Script Date: 24/11/2026 19:46:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[ACTUALIZAR_DVV]
@tabla varchar(50), 
@dvv varchar(max)
AS
BEGIN
    IF EXISTS (SELECT 1 FROM DIGITO_VERIFICADOR WHERE TABLA = @tabla)
    BEGIN
        UPDATE DIGITO_VERIFICADOR 
        SET DVV = @dvv 
        WHERE TABLA = @tabla
    END
    ELSE
    BEGIN
        INSERT INTO DIGITO_VERIFICADOR (TABLA, DVV)
        VALUES (@tabla, @dvv)
    END
END

GO
/****** Object:  StoredProcedure [dbo].[ACTUALIZAR_ESTADO_OC]    Script Date: 24/11/2026 19:46:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- Para CU-06: Cambiar estado de la Orden
CREATE PROCEDURE [dbo].[ACTUALIZAR_ESTADO_OC]
    @Id_OrdenCompra INT,
    @Estado VARCHAR(50)
AS
BEGIN
    UPDATE ORDEN_COMPRA SET Estado = @Estado WHERE Id_OrdenCompra = @Id_OrdenCompra;
END;

GO
/****** Object:  StoredProcedure [dbo].[ACTUALIZAR_ESTADO_PRESUPUESTO]    Script Date: 24/11/2026 19:46:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- 2. SP PARA ACTUALIZAR EL ESTADO DEL PRESUPUESTO
CREATE   PROCEDURE [dbo].[ACTUALIZAR_ESTADO_PRESUPUESTO]
    @Id_Presupuesto INT,
    @Estado VARCHAR(20)
AS
BEGIN
    UPDATE PRESUPUESTO
    SET Estado = @Estado
    WHERE Id_Presupuesto = @Id_Presupuesto;
END;

GO
/****** Object:  StoredProcedure [dbo].[ACTUALIZAR_ESTADOBLOQUEADO]    Script Date: 24/11/2026 19:46:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[ACTUALIZAR_ESTADOBLOQUEADO]
@id int, @estadobloqueado bit,@intentos int,@dvh varchar(max)
as
begin
update USUARIO set
ESTADOBLOQUEADO=@estadobloqueado,
INTENTOSFALLIDOS = @intentos,
DVH = @dvh
where USUARIO.ID = @id 
end
GO
/****** Object:  StoredProcedure [dbo].[ACTUALIZAR_IDIOMA_USUARIO]    Script Date: 24/11/2026 19:46:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[ACTUALIZAR_IDIOMA_USUARIO]
@id_usuario int,
@id_idioma int,
@dvh varchar(max) -- Agregamos el parámetro entrante
AS
BEGIN
    UPDATE USUARIO 
    SET 
        id_idioma = @id_idioma,
        DVH = @dvh              -- Actualizamos la firma de seguridad
    WHERE ID = @id_usuario
END

GO
/****** Object:  StoredProcedure [dbo].[ACTUALIZAR_INSUMO]    Script Date: 24/11/2026 19:46:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- 5. SP: ACTUALIZAR_INSUMO (Soporte para Modificación)
CREATE   PROCEDURE [dbo].[ACTUALIZAR_INSUMO]
    @Id_Insumo INT,
    @Nombre VARCHAR(100),
    @Rubro VARCHAR(50),
    @Unidad_Medida VARCHAR(30),
    @Stock_Actual DECIMAL(18,2),
    @Stock_Minimo DECIMAL(18,2),
    @Estado VARCHAR(20)
AS
BEGIN
    UPDATE INSUMO
    SET Nombre = @Nombre,
        Rubro = @Rubro,
        Unidad_Medida = @Unidad_Medida,
        Stock_Actual = @Stock_Actual,
        Stock_Minimo = @Stock_Minimo,
        Estado = @Estado
    WHERE Id_Insumo = @Id_Insumo;
END;

GO
/****** Object:  StoredProcedure [dbo].[ACTUALIZAR_INTENTOS_FALLIDOS]    Script Date: 24/11/2026 19:46:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[ACTUALIZAR_INTENTOS_FALLIDOS]
@id int, @intentos int,@dvh varchar(max)
AS
BEGIN
update USUARIO set
INTENTOSFALLIDOS=@intentos,
DVH = @dvh
where USUARIO.ID = @id
END
GO
/****** Object:  StoredProcedure [dbo].[ACTUALIZAR_PERSONAL]    Script Date: 24/11/2026 19:46:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- 5. Stored Procedure para actualizar un empleado
CREATE   PROCEDURE [dbo].[ACTUALIZAR_PERSONAL]
    @Id_Personal INT,
    @DNI VARCHAR(20),
    @Nombre VARCHAR(100),
    @Apellido VARCHAR(100),
    @Categoria VARCHAR(50),
    @Telefono VARCHAR(50),
    @Direccion VARCHAR(200),
    @Email VARCHAR(100),
    @Estado VARCHAR(20)
AS
BEGIN
    UPDATE PERSONAL
    SET DNI = @DNI,
        Nombre = @Nombre,
        Apellido = @Apellido,
        Categoria = @Categoria,
        Telefono = @Telefono,
        Direccion = @Direccion,
        Email = @Email,
        Estado = @Estado
    WHERE Id_Personal = @Id_Personal;
END;

GO
/****** Object:  StoredProcedure [dbo].[ACTUALIZAR_PROVEEDOR_INSUMO]    Script Date: 24/11/2026 19:46:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   PROCEDURE [dbo].[ACTUALIZAR_PROVEEDOR_INSUMO]
    @Id_Proveedor INT,
    @Razon_Social VARCHAR(100),
    @CUIT VARCHAR(20),
    @Rubro VARCHAR(50),
    @Telefono VARCHAR(30),
    @Direccion VARCHAR(100),
    @Email VARCHAR(100),
    @Estado VARCHAR(20)
AS
BEGIN
    UPDATE PROVEEDOR_INSUMO
    SET Razon_Social = @Razon_Social,
        CUIT = @CUIT,
        Rubro = @Rubro,
        Telefono = @Telefono,
        Direccion = @Direccion,
        Email = @Email,
        Estado = @Estado
    WHERE Id_Proveedor = @Id_Proveedor;
END;

GO
/****** Object:  StoredProcedure [dbo].[ACTUALIZAR_SALDOS_ESTADO_RESERVA]    Script Date: 24/11/2026 19:46:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- 3. SP para actualizar la plata y el estado cuando se Guarda la Ficha Técnica
CREATE PROCEDURE [dbo].[ACTUALIZAR_SALDOS_ESTADO_RESERVA]
    @Id_Reserva INT,
    @Costo_Total_Real DECIMAL(18,2),
    @Saldo_Pendiente DECIMAL(18,2),
    @Estado VARCHAR(20)
AS
BEGIN
    UPDATE RESERVA
    SET Costo_Total_Real = @Costo_Total_Real,
        Saldo_Pendiente = @Saldo_Pendiente,
        Estado = @Estado
    WHERE Id_Reserva = @Id_Reserva;
END;

GO
/****** Object:  StoredProcedure [dbo].[ACTUALIZAR_STOCK_INSUMO]    Script Date: 24/11/2026 19:46:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- Para CU-06: Actualizar Stock en Inventario
CREATE PROCEDURE [dbo].[ACTUALIZAR_STOCK_INSUMO]
    @Id_Insumo INT,
    @Cantidad_Sumar INT
AS
BEGIN
    UPDATE INVENTARIO 
    SET Stock_Actual = Stock_Actual + @Cantidad_Sumar 
    WHERE Id_Insumo = @Id_Insumo;
END;

GO
/****** Object:  StoredProcedure [dbo].[ALTA_IDIOMA_CON_SUFIJO]    Script Date: 24/11/2026 19:46:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ALTA_IDIOMA_CON_SUFIJO]
    @nombre VARCHAR(50),
    @sufijo VARCHAR(10)
AS
BEGIN

    INSERT INTO IDIOMA (nombre, ESTADISPONIBLE) 
    VALUES (@nombre, 1);
    
    DECLARE @nuevoId INT = SCOPE_IDENTITY();

    INSERT INTO TRADUCCION (id_control, id_idioma, texto_traducido)
    SELECT id_control, @nuevoId, texto_traducido + @sufijo
    FROM TRADUCCION
    WHERE id_idioma = 1;
END;
GO
/****** Object:  StoredProcedure [dbo].[ANULAR_ORDEN_COMPRA]    Script Date: 24/11/2026 19:46:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   PROCEDURE [dbo].[ANULAR_ORDEN_COMPRA]
    @Id_OrdenCompra INT,
    @Motivo_Anulacion VARCHAR(250)
AS
BEGIN
    UPDATE ORDEN_COMPRA
    SET Estado = 'Anulada',
        Motivo_Anulacion = @Motivo_Anulacion
    WHERE Id_OrdenCompra = @Id_OrdenCompra;
END;

GO
/****** Object:  StoredProcedure [dbo].[ASIGNAR_PRESTADOR_FICHA]    Script Date: 24/11/2026 19:46:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE   PROCEDURE [dbo].[ASIGNAR_PRESTADOR_FICHA]
    @Id_Ficha INT,
    @Id_Prestador INT
AS
BEGIN
    INSERT INTO FICHA_PRESTADORES (Id_Ficha, Id_Prestador)
    VALUES (@Id_Ficha, @Id_Prestador);
END;

GO
/****** Object:  StoredProcedure [dbo].[ASIGNAR_PROVEEDOR_FICHA]    Script Date: 24/11/2026 19:46:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ASIGNAR_PROVEEDOR_FICHA]
    @Id_Ficha INT,
    @Id_Proveedor INT
AS
BEGIN
    INSERT INTO FICHA_PROVEEDORES (Id_Ficha, Id_Proveedor)
    VALUES (@Id_Ficha, @Id_Proveedor);
END;

GO
/****** Object:  StoredProcedure [dbo].[BAJA_LOGICA_IDIOMA]    Script Date: 24/11/2026 19:46:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[BAJA_LOGICA_IDIOMA]
    @id_idioma INT
AS
BEGIN
    UPDATE IDIOMA 
    SET estadisponible = 0 
    WHERE id_idioma = @id_idioma;
END
GO
/****** Object:  StoredProcedure [dbo].[BORRAR_PERMISO_PERMISO]    Script Date: 24/11/2026 19:46:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[BORRAR_PERMISO_PERMISO]
    @idPadre INT,
    @idHijo INT
AS
BEGIN
    DELETE FROM PERMISO_PERMISO 
    WHERE ID_PADRE = @idPadre AND ID_HIJO = @idHijo
END

GO
/****** Object:  StoredProcedure [dbo].[BORRAR_PERMISOS_USUARIO]    Script Date: 24/11/2026 19:46:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[BORRAR_PERMISOS_USUARIO]
@idUsuario int
as
begin
    DELETE FROM USUARIO_PERMISO WHERE Id_Usuario = @idUsuario;
end
GO
/****** Object:  StoredProcedure [dbo].[BORRAR_PRODUCTO]    Script Date: 24/11/2026 19:46:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[BORRAR_PRODUCTO]
@id int
as
begin
   UPDATE PRODUCTO SET ACTIVO = 0 WHERE ID_PRODUCTO = @id
end
GO
/****** Object:  StoredProcedure [dbo].[BORRAR_ROL_COMPLETO]    Script Date: 24/11/2026 19:46:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[BORRAR_ROL_COMPLETO]
    @idRol INT
AS
BEGIN
    -- Validar si hay usuarios usando este Rol (Lanzamos un error si los hay)
    /*IF EXISTS (SELECT 1 FROM USUARIO_PERMISO WHERE Id_Permiso = @idRol)
    BEGIN
        RAISERROR('No se puede eliminar este Rol porque hay usuarios que lo tienen asignado. Quítele el rol a los usuarios primero.', 16, 1);
        RETURN;
    END*/

    -- 1. Borramos las relaciones donde este Rol es PADRE (Vaciamos su contenido)
    DELETE FROM PERMISO_PERMISO WHERE Id_Padre = @idRol;

    -- 2. Borramos las relaciones donde este Rol es HIJO (Lo sacamos de otros roles más grandes)
    DELETE FROM PERMISO_PERMISO WHERE Id_Hijo = @idRol;

    -- 3. Finalmente, borramos el Rol de la tabla maestra
    DELETE FROM PERMISO WHERE Id = @idRol;
END

GO
/****** Object:  StoredProcedure [dbo].[BORRAR_USUARIO]    Script Date: 24/11/2026 19:46:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[BORRAR_USUARIO]
@id int
as
begin
	UPDATE USUARIO SET ACTIVO = 0 WHERE ID = @id
    --DELETE FROM USUARIO WHERE ID = @id;
end
GO
/****** Object:  StoredProcedure [dbo].[CAMBIAR_ESTADO_INSUMO]    Script Date: 24/11/2026 19:46:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   PROCEDURE [dbo].[CAMBIAR_ESTADO_INSUMO]
    @Id_Insumo INT,
    @Estado VARCHAR(20)
AS
BEGIN
    UPDATE INSUMO
    SET Estado = @Estado
    WHERE Id_Insumo = @Id_Insumo;
END;

GO
/****** Object:  StoredProcedure [dbo].[CAMBIAR_ESTADO_PERSONAL]    Script Date: 24/11/2026 19:46:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- 6. Stored Procedure para cambiar el estado (Baja Lógica)
CREATE   PROCEDURE [dbo].[CAMBIAR_ESTADO_PERSONAL]
    @Id_Personal INT,
    @Estado VARCHAR(20)
AS
BEGIN
    UPDATE PERSONAL
    SET Estado = @Estado
    WHERE Id_Personal = @Id_Personal;
END;

GO
/****** Object:  StoredProcedure [dbo].[CAMBIAR_ESTADO_PROVEEDOR_INSUMO]    Script Date: 24/11/2026 19:46:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   PROCEDURE [dbo].[CAMBIAR_ESTADO_PROVEEDOR_INSUMO]
    @Id_Proveedor INT,
    @Estado VARCHAR(20)
AS
BEGIN
    UPDATE PROVEEDOR_INSUMO
    SET Estado = @Estado
    WHERE Id_Proveedor = @Id_Proveedor;
END;

GO
/****** Object:  StoredProcedure [dbo].[ELIMINAR_ASIGNACION_RESERVA]    Script Date: 24/11/2026 19:46:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   PROCEDURE [dbo].[ELIMINAR_ASIGNACION_RESERVA]
    @Id_Reserva INT
AS
BEGIN
    DELETE FROM ASIGNACION_PERSONAL WHERE Id_Reserva = @Id_Reserva;
END;

GO
/****** Object:  StoredProcedure [dbo].[ELIMINAR_RECETARIO_SERVICIO]    Script Date: 24/11/2026 19:46:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   PROCEDURE [dbo].[ELIMINAR_RECETARIO_SERVICIO]
    @Id_Servicio INT
AS
BEGIN
    DELETE FROM RECETARIO
    WHERE Id_Servicio = @Id_Servicio;
END;

GO
/****** Object:  StoredProcedure [dbo].[GUARDAR_ASIGNACION_PERSONAL]    Script Date: 24/11/2026 19:46:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   PROCEDURE [dbo].[GUARDAR_ASIGNACION_PERSONAL]
    @Id_Reserva INT,
    @Id_Personal INT
AS
BEGIN
    INSERT INTO ASIGNACION_PERSONAL (Id_Reserva, Id_Personal)
    VALUES (@Id_Reserva, @Id_Personal);
END;

GO
/****** Object:  StoredProcedure [dbo].[GUARDAR_PARAMETRO_RATIO]    Script Date: 24/11/2026 19:46:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   PROCEDURE [dbo].[GUARDAR_PARAMETRO_RATIO]
    @Categoria VARCHAR(50),
    @Cantidad_Invitados_Por_Personal INT
AS
BEGIN
    UPDATE PARAMETRO_RATIO
    SET Cantidad_Invitados_Por_Personal = @Cantidad_Invitados_Por_Personal
    WHERE Categoria = @Categoria;
END;

GO
/****** Object:  StoredProcedure [dbo].[HABILITAR_IDIOMA]    Script Date: 24/11/2026 19:46:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[HABILITAR_IDIOMA]
    @id_idioma INT
AS
BEGIN
    UPDATE IDIOMA 
    SET estadisponible = 1 
    WHERE id_idioma = @id_idioma;
END
GO
/****** Object:  StoredProcedure [dbo].[INCREMENTAR_STOCK_INSUMO]    Script Date: 24/11/2026 19:46:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   PROCEDURE [dbo].[INCREMENTAR_STOCK_INSUMO]
    @Nombre_Insumo VARCHAR(100),
    @Cantidad_Recibida DECIMAL(18,2)
AS
BEGIN
    UPDATE INSUMO
    SET Stock_Actual = Stock_Actual + @Cantidad_Recibida
    WHERE Nombre = @Nombre_Insumo;
END;

GO
/****** Object:  StoredProcedure [dbo].[INSERTAR_BITACORA]    Script Date: 24/11/2026 19:46:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[INSERTAR_BITACORA]
 @fecha datetime, @usuario varchar(50), @modulo varchar(50), @operacion varchar(50) ,@criticidad int
AS
BEGIN
declare @id_bitacora int
set
@id_bitacora=(select ISNULL(max(ID_BITACORA),0) +1 from BITACORA)
insert into BITACORA (ID_BITACORA, FECHA, USUARIO, MODULO, OPERACION, CRITICIDAD)
values(@id_bitacora, @fecha, @usuario, @modulo, @operacion, @criticidad)

END
GO
/****** Object:  StoredProcedure [dbo].[INSERTAR_CLIENTE]    Script Date: 24/11/2026 19:46:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[INSERTAR_CLIENTE]
    @nombre_completo VARCHAR(100),
    @dni INT,
    @telefono BIGINT, -- AQUI CAMBIAMOS A BIGINT
    @email VARCHAR(100)
AS
BEGIN
    INSERT INTO CLIENTE (Nombre_Completo, Telefono, Email, Dni)
    VALUES (@nombre_completo, @telefono, @email, @dni);
END;

GO
/****** Object:  StoredProcedure [dbo].[INSERTAR_DETALLE_ORDEN_COMPRA]    Script Date: 24/11/2026 19:46:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   PROCEDURE [dbo].[INSERTAR_DETALLE_ORDEN_COMPRA]
    @Id_OrdenCompra INT,
    @Nombre_Insumo VARCHAR(100),
    @Cantidad_Solicitada INT
AS
BEGIN
    INSERT INTO DETALLE_OC (Id_OrdenCompra, Nombre_Insumo, Cantidad_Solicitada, Cantidad_Recibida)
    VALUES (@Id_OrdenCompra, @Nombre_Insumo, @Cantidad_Solicitada, 0);
END;

GO
/****** Object:  StoredProcedure [dbo].[INSERTAR_DETALLE_RECETARIO]    Script Date: 24/11/2026 19:46:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   PROCEDURE [dbo].[INSERTAR_DETALLE_RECETARIO]
    @Id_Servicio INT,
    @Id_Insumo INT,
    @Cantidad_Por_Persona DECIMAL(18,4)
AS
BEGIN
    INSERT INTO RECETARIO (Id_Servicio, Id_Insumo, Cantidad_Por_Persona)
    VALUES (@Id_Servicio, @Id_Insumo, @Cantidad_Por_Persona);
END;

GO
/****** Object:  StoredProcedure [dbo].[INSERTAR_FICHA_TECNICA]    Script Date: 24/11/2026 19:46:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[INSERTAR_FICHA_TECNICA]
    @Id_Reserva INT,
    @Id_Usuario INT,
    @Id_Servicio INT,
    @Cantidad_Invitados_Final INT,
    @Tipo_Evento VARCHAR(50)
AS
BEGIN
    INSERT INTO FICHA_TECNICA (Id_Reserva, Id_Usuario, Id_Servicio, Cantidad_Invitados_Final, Tipo_Evento)
    VALUES (@Id_Reserva, @Id_Usuario, @Id_Servicio, @Cantidad_Invitados_Final, @Tipo_Evento);

    SELECT CAST(SCOPE_IDENTITY() AS INT);
END;

GO
/****** Object:  StoredProcedure [dbo].[INSERTAR_HISTORIAL_PRODUCTO]    Script Date: 24/11/2026 19:46:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[INSERTAR_HISTORIAL_PRODUCTO]
    @id_producto INT,
    @usuario_accion VARCHAR(50),
    @tipo_accion VARCHAR(20)
AS
BEGIN
    INSERT INTO HISTORIAL_PRODUCTO 
    (Id_Producto, Usuario_Accion, Tipo_Accion, Nombre, Precio, Stock)
    SELECT @id_producto, @usuario_accion, @tipo_accion, NOMBRE, PRECIO, STOCK
	FROM PRODUCTO
	WHERE ID_PRODUCTO = @id_producto
END
GO
/****** Object:  StoredProcedure [dbo].[INSERTAR_HISTORIAL_USUARIO]    Script Date: 24/11/2026 19:46:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[INSERTAR_HISTORIAL_USUARIO]
    @id_usuario INT,
    @usuario_responsable VARCHAR(50),
    @tipo_accion VARCHAR(50)
AS
BEGIN
    INSERT INTO HISTORIAL_USUARIO (id_usuario, usuario, contraseña, dni, email, estadobloqueado, intentosfallidos, id_idioma, dvh, fecha_cambio, usuario_accion, tipo_accion)
    SELECT id, usuario, contraseña, dni, email, estadobloqueado, intentosfallidos, id_idioma, dvh, GETDATE(), @usuario_responsable, @tipo_accion
    FROM USUARIO 
    WHERE id = @id_usuario;
END

GO
/****** Object:  StoredProcedure [dbo].[INSERTAR_INSUMO]    Script Date: 24/11/2026 19:46:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   PROCEDURE [dbo].[INSERTAR_INSUMO]
    @Nombre VARCHAR(100),
    @Rubro VARCHAR(50),
    @Unidad_Medida VARCHAR(30),
    @Stock_Actual DECIMAL(18,2),
    @Stock_Minimo DECIMAL(18,2),
    @Estado VARCHAR(20)
AS
BEGIN
    INSERT INTO INSUMO (Nombre, Rubro, Unidad_Medida, Stock_Actual, Stock_Minimo, Estado)
    VALUES (@Nombre, @Rubro, @Unidad_Medida, @Stock_Actual, @Stock_Minimo, @Estado);
END;

GO
/****** Object:  StoredProcedure [dbo].[INSERTAR_ORDEN_COMPRA]    Script Date: 24/11/2026 19:46:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[INSERTAR_ORDEN_COMPRA]
    @Id_Proveedor INT,
    @Fecha_Emision DATETIME,
    @Estado VARCHAR(50),
    @Id_Ficha INT = NULL
AS
BEGIN
    INSERT INTO ORDEN_COMPRA (Id_Proveedor, Fecha_Emision, Estado, Id_Ficha)
    VALUES (@Id_Proveedor, @Fecha_Emision, @Estado, @Id_Ficha);
    
    SELECT SCOPE_IDENTITY();
END;
GO
/****** Object:  StoredProcedure [dbo].[INSERTAR_PERMISO]    Script Date: 24/11/2026 19:46:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[INSERTAR_PERMISO]
    @nombre VARCHAR(100),
    @esCompuesto BIT
AS
BEGIN
declare @id int set
@id=(select ISNULL(max(ID),0)+1 from PERMISO)
    INSERT INTO PERMISO (ID,NOMBRE, ESCOMPUESTO)
    VALUES (@id,@nombre, @esCompuesto)
END

GO
/****** Object:  StoredProcedure [dbo].[INSERTAR_PERMISO_PERMISO]    Script Date: 24/11/2026 19:46:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[INSERTAR_PERMISO_PERMISO]
    @idPadre INT,
    @idHijo INT
AS
BEGIN

    IF NOT EXISTS (SELECT 1 FROM PERMISO_PERMISO WHERE ID_PADRE = @idPadre AND ID_HIJO = @idHijo)
    BEGIN
        INSERT INTO PERMISO_PERMISO (ID_PADRE, ID_HIJO)
        VALUES (@idPadre, @idHijo)
    END
END
GO
/****** Object:  StoredProcedure [dbo].[INSERTAR_PERSONAL]    Script Date: 24/11/2026 19:46:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   PROCEDURE [dbo].[INSERTAR_PERSONAL]
    @DNI VARCHAR(20),
    @Nombre VARCHAR(100),
    @Apellido VARCHAR(100),
    @Categoria VARCHAR(50),
    @Telefono VARCHAR(50),
    @Direccion VARCHAR(200),
    @Email VARCHAR(100),
    @Estado VARCHAR(20)
AS
BEGIN
    INSERT INTO PERSONAL (DNI, Nombre, Apellido, Categoria, Telefono, Direccion, Email, Estado)
    VALUES (@DNI, @Nombre, @Apellido, @Categoria, @Telefono, @Direccion, @Email, @Estado);
END;

GO
/****** Object:  StoredProcedure [dbo].[INSERTAR_PRESUPUESTO]    Script Date: 24/11/2026 19:46:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- 2. Actualizamos el SP de insertar
CREATE PROCEDURE [dbo].[INSERTAR_PRESUPUESTO]
    @Id_Cliente INT,
    @Cantidad_Invitados_Estimada INT,
    @Tipo_Evento VARCHAR(100),
    @Subtotal DECIMAL(18,2),
    @Id_Usuario INT,
    @Estado VARCHAR(20),
    @Fecha_Evento DATETIME -- NUEVO PARAMETRO
AS
BEGIN
    INSERT INTO PRESUPUESTO (Id_Cliente, Cantidad_Invitados_Estimada, Tipo_Evento, Subtotal, Id_Usuario, Estado, Fecha_Evento)
    VALUES (@Id_Cliente, @Cantidad_Invitados_Estimada, @Tipo_Evento, @Subtotal, @Id_Usuario, @Estado, @Fecha_Evento);
    
    SELECT CAST(SCOPE_IDENTITY() AS INT);
END;

GO
/****** Object:  StoredProcedure [dbo].[INSERTAR_PRODUCTO]    Script Date: 24/11/2026 19:46:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[INSERTAR_PRODUCTO]
    @nombre VARCHAR(100),
    @precio DECIMAL(18,2),
    @stock INT
AS
BEGIN
    DECLARE @id int 
    SET @id = (SELECT ISNULL(MAX(ID_PRODUCTO), 0) + 1 FROM PRODUCTO)

    INSERT INTO PRODUCTO (ID_PRODUCTO,NOMBRE, PRECIO, STOCK) 
    VALUES (@id,@nombre, @precio, @stock)
    SELECT @id
END

GO
/****** Object:  StoredProcedure [dbo].[INSERTAR_PROVEEDOR_INSUMO]    Script Date: 24/11/2026 19:46:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   PROCEDURE [dbo].[INSERTAR_PROVEEDOR_INSUMO]
    @Razon_Social VARCHAR(100),
    @CUIT VARCHAR(20),
    @Rubro VARCHAR(50),
    @Telefono VARCHAR(30),
    @Direccion VARCHAR(100),
    @Email VARCHAR(100),
    @Estado VARCHAR(20)
AS
BEGIN
    INSERT INTO PROVEEDOR_INSUMO (Razon_Social, CUIT, Rubro, Telefono, Direccion, Email, Estado)
    VALUES (@Razon_Social, @CUIT, @Rubro, @Telefono, @Direccion, @Email, @Estado);
END;

GO
/****** Object:  StoredProcedure [dbo].[INSERTAR_RESERVA]    Script Date: 24/11/2026 19:46:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[INSERTAR_RESERVA]
    @Id_Cliente INT,
    @Id_Usuario INT,
    @Id_Presupuesto INT,
    @Fecha_Evento DATETIME,
    @Monto_Senia DECIMAL(18,2),
    @Estado VARCHAR(20)
AS
BEGIN
    INSERT INTO RESERVA (Id_Cliente, Id_Usuario, Id_Presupuesto, Fecha_Evento, Monto_Senia, Estado)
    VALUES (@Id_Cliente, @Id_Usuario, @Id_Presupuesto, @Fecha_Evento, @Monto_Senia, @Estado);

    -- Regla de negocio encapsulada: Al señar, el presupuesto original queda aprobado
    UPDATE PRESUPUESTO 
    SET Estado = 'Aprobado' 
    WHERE Id_Presupuesto = @Id_Presupuesto;

    SELECT CAST(SCOPE_IDENTITY() AS INT);
END;

GO
/****** Object:  StoredProcedure [dbo].[INSERTAR_USUARIO]    Script Date: 24/11/2026 19:46:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[INSERTAR_USUARIO]
@usu varchar(50), 
@contra varchar(max), 
@dni int, 
@email varchar(50),
--@id_idioma int,   -- Nuevo: Para guardar el idioma por defecto del usuario
@dvh varchar(max) -- Nuevo: Para guardar el candado horizontal inicial calculado por la BLL
AS
BEGIN
    DECLARE @id int 
    SET @id = (SELECT ISNULL(MAX(ID), 0) + 1 FROM USUARIO)
    
    INSERT INTO USUARIO(ID, USUARIO, CONTRASEÑA, DNI, EMAIL, ID_IDIOMA, DVH, ACTIVO)
    VALUES(@id, @usu, @contra, @dni, @email,1, @dvh,1)

    SELECT @id

END
GO
/****** Object:  StoredProcedure [dbo].[INSERTAR_USUARIO_PERMISO]    Script Date: 24/11/2026 19:46:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[INSERTAR_USUARIO_PERMISO]
    @idUsuario INT,
    @idPermiso INT
AS
BEGIN
    INSERT INTO USUARIO_PERMISO (Id_Usuario, Id_Permiso)
    VALUES (@idUsuario, @idPermiso)
END

GO
/****** Object:  StoredProcedure [dbo].[LISTAR_CATERING]    Script Date: 24/11/2026 19:46:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- 1. SP para que el ComboBox de la interfaz muestre las opciones de Catering
CREATE PROCEDURE [dbo].[LISTAR_CATERING]
AS
BEGIN
    SELECT Id_Servicio, Tipo_Menu, Precio_Por_Persona, Nombre_Servicio, Descripcion
    FROM SERVICIO_CATERING;
END;
GO
/****** Object:  StoredProcedure [dbo].[LISTAR_CLIENTES]    Script Date: 24/11/2026 19:46:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- 3. SP PARA LISTAR CLIENTES (Requerido por el método Listar del Mapper)
CREATE   PROCEDURE [dbo].[LISTAR_CLIENTES]
AS
BEGIN
    SELECT Id_Cliente, Nombre_Completo, Dni, Telefono, Email
    FROM CLIENTE;
END;

GO
/****** Object:  StoredProcedure [dbo].[LISTAR_DETALLES_POR_ORDEN]    Script Date: 24/11/2026 19:46:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   PROCEDURE [dbo].[LISTAR_DETALLES_POR_ORDEN]
    @Id_OrdenCompra INT
AS
BEGIN
    SELECT 
        Id_Detalle,
        Id_OrdenCompra,
        Nombre_Insumo,
        Cantidad_Solicitada,
        Cantidad_Recibida
    FROM DETALLE_OC
    WHERE Id_OrdenCompra = @Id_OrdenCompra;
END;

GO
/****** Object:  StoredProcedure [dbo].[LISTAR_EVALUADOS]    Script Date: 24/11/2026 19:46:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   PROCEDURE [dbo].[LISTAR_EVALUADOS]
AS
BEGIN
    SELECT 
        Id_Reserva,
        Fecha_Evento,
        Estado,
        Evaluacion_Personal, -- 1: Aprobado, 0: No Aprobado
        Observaciones_Personal
    FROM RESERVA
    WHERE Estado = 'Finalizado' 
      AND Evaluacion_Personal IS NOT NULL
    ORDER BY Fecha_Evento DESC;
END;

GO
/****** Object:  StoredProcedure [dbo].[LISTAR_EVENTOS_PLANIFICADOS]    Script Date: 24/11/2026 19:46:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[LISTAR_EVENTOS_PLANIFICADOS]
    @FechaDesde DATETIME = NULL,
    @FechaHasta DATETIME = NULL
AS
BEGIN
    SELECT 
        R.Id_Reserva, 
        R.Id_Cliente, 
        R.Id_Presupuesto, 
        R.Id_Usuario, 
        R.Fecha_Evento, 
        R.Monto_Senia, 
        R.Costo_Total_Real, 
        R.Saldo_Pendiente, 
        R.Estado,
        C.Nombre_Completo AS ClienteNombre,
        P.Cantidad_Invitados_Estimada AS Cantidad_Invitados,
        P.Tipo_Evento
    FROM RESERVA R
    INNER JOIN CLIENTE C ON R.Id_Cliente = C.Id_Cliente
    INNER JOIN PRESUPUESTO P ON R.Id_Presupuesto = P.Id_Presupuesto
    WHERE R.Estado = 'Planificado'
      AND (@FechaDesde IS NULL OR R.Fecha_Evento >= @FechaDesde)
      AND (@FechaHasta IS NULL OR R.Fecha_Evento <= @FechaHasta)
    ORDER BY R.Fecha_Evento ASC;
END;

GO
/****** Object:  StoredProcedure [dbo].[LISTAR_HISTORIAL_PRODUCTOS]    Script Date: 24/11/2026 19:46:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[LISTAR_HISTORIAL_PRODUCTOS]
AS
BEGIN
    SELECT *
    FROM HISTORIAL_PRODUCTO
    ORDER BY Fecha_Cambio DESC
END

GO
/****** Object:  StoredProcedure [dbo].[LISTAR_HISTORIAL_USUARIO]    Script Date: 24/11/2026 19:46:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[LISTAR_HISTORIAL_USUARIO]
AS
BEGIN
    SELECT *
    FROM HISTORIAL_USUARIO
    ORDER BY fecha_cambio DESC
END

GO
/****** Object:  StoredProcedure [dbo].[LISTAR_IDIOMAS]    Script Date: 24/11/2026 19:46:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- SP 1: Listar Idiomas (Para llenar tu ComboBox)
CREATE PROCEDURE [dbo].[LISTAR_IDIOMAS]
AS
BEGIN
    -- Solo trae los idiomas que el administrador tiene activados (IsDisponible = 1)
    SELECT ID_IDIOMA, NOMBRE, ESTADISPONIBLE 
    FROM IDIOMA
    WHERE ESTADISPONIBLE = 1;
END;

GO
/****** Object:  StoredProcedure [dbo].[LISTAR_INSUMOS]    Script Date: 24/11/2026 19:46:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   PROCEDURE [dbo].[LISTAR_INSUMOS]
AS
BEGIN
    SELECT Id_Insumo, Nombre, Rubro, Unidad_Medida, Stock_Actual, Stock_Minimo, Estado
    FROM INSUMO;
END;

GO
/****** Object:  StoredProcedure [dbo].[LISTAR_ORDENES_COMPRA_EMITIDAS]    Script Date: 24/11/2026 19:46:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   PROCEDURE [dbo].[LISTAR_ORDENES_COMPRA_EMITIDAS]
AS
BEGIN
    SELECT 
        Id_OrdenCompra,
        Id_Proveedor,
        Fecha_Emision,
        Estado,
        Motivo_Anulacion
    FROM ORDEN_COMPRA
    WHERE Estado = 'Emitida'
    ORDER BY Fecha_Emision DESC;
END;

GO
/****** Object:  StoredProcedure [dbo].[LISTAR_PENDIENTES_EVALUACION]    Script Date: 24/11/2026 19:46:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   PROCEDURE [dbo].[LISTAR_PENDIENTES_EVALUACION]
AS
BEGIN
    SELECT 
        R.Id_Reserva, 
        R.Id_Cliente, 
        R.Id_Presupuesto, 
        R.Id_Usuario, 
        R.Fecha_Evento, 
        R.Monto_Senia, 
        R.Costo_Total_Real, 
        R.Saldo_Pendiente, 
        R.Estado,
        C.Nombre_Completo AS ClienteNombre,
        P.Cantidad_Invitados_Estimada AS Cantidad_Invitados,
        P.Tipo_Evento
    FROM RESERVA R
    INNER JOIN CLIENTE C ON R.Id_Cliente = C.Id_Cliente
    INNER JOIN PRESUPUESTO P ON R.Id_Presupuesto = P.Id_Presupuesto
    WHERE (R.Estado = 'Saldado' OR R.Estado = 'Planificado')
      AND R.Fecha_Evento <= GETDATE()
      AND R.Evaluacion_Personal IS NULL
    ORDER BY R.Fecha_Evento ASC;
END;

GO
/****** Object:  StoredProcedure [dbo].[LISTAR_PERMISOS]    Script Date: 24/11/2026 19:46:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[LISTAR_PERMISOS]
AS
BEGIN
    SELECT 
        ID, 
        NOMBRE, 
        ESCOMPUESTO
    FROM PERMISO
END

GO
/****** Object:  StoredProcedure [dbo].[LISTAR_PERSONAL]    Script Date: 24/11/2026 19:46:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   PROCEDURE [dbo].[LISTAR_PERSONAL]
AS
BEGIN
    SELECT 
        Id_Personal,
        DNI,
        Nombre,
        Apellido,
        Categoria,
        Telefono,
        Direccion,
        Email,
        Estado
    FROM PERSONAL
    ORDER BY Apellido, Nombre;
END;

GO
/****** Object:  StoredProcedure [dbo].[LISTAR_PERSONAL_ACTIVO]    Script Date: 24/11/2026 19:46:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   PROCEDURE [dbo].[LISTAR_PERSONAL_ACTIVO]
AS
BEGIN
    SELECT 
        Id_Personal,
        DNI,
        Nombre,
        Apellido,
        Categoria,
        Telefono,
        Direccion,
        Email,
        Estado
    FROM PERSONAL
    WHERE Estado = 'Activo'
    ORDER BY Categoria, Apellido;
END;

GO
/****** Object:  StoredProcedure [dbo].[LISTAR_PRESTADORES_SERVICIOS]    Script Date: 24/11/2026 19:46:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- 3. Stored Procedures actualizados
CREATE   PROCEDURE [dbo].[LISTAR_PRESTADORES_SERVICIOS]
AS
BEGIN
    SELECT Id_Prestador, Rubro, Nombre_Fantasia, Estado, Precio_Servicio 
    FROM PRESTADOR_SERVICIO;
END;

GO
/****** Object:  StoredProcedure [dbo].[LISTAR_PRESUPUESTOS_PENDIENTES]    Script Date: 24/11/2026 19:46:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[LISTAR_PRESUPUESTOS_PENDIENTES]
AS
BEGIN
    SELECT Id_Presupuesto, Id_Cliente, Cantidad_Invitados_Estimada, Tipo_Evento, Subtotal, Estado, Fecha_Evento
    FROM PRESUPUESTO
    WHERE Estado = 'Pendiente';
END;

GO
/****** Object:  StoredProcedure [dbo].[LISTAR_PRODUCTOS]    Script Date: 24/11/2026 19:46:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[LISTAR_PRODUCTOS]
AS
BEGIN
    SELECT * FROM PRODUCTO
END

GO
/****** Object:  StoredProcedure [dbo].[LISTAR_PROVEEDORES]    Script Date: 24/11/2026 19:46:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[LISTAR_PROVEEDORES]
AS
BEGIN
    SELECT Id_Proveedor, Rubro, Nombre_Fantasia, Estado, Precio_Servicio 
    FROM PROVEEDOR_EXTERNO;
END;

GO
/****** Object:  StoredProcedure [dbo].[LISTAR_PROVEEDORES_INSUMOS]    Script Date: 24/11/2026 19:46:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   PROCEDURE [dbo].[LISTAR_PROVEEDORES_INSUMOS]
AS
BEGIN
    SELECT Id_Proveedor, Razon_Social, CUIT, Rubro, Telefono, Direccion, Email, Estado
    FROM PROVEEDOR_INSUMO;
END;

GO
/****** Object:  StoredProcedure [dbo].[LISTAR_RATIOS_PARAMETROS]    Script Date: 24/11/2026 19:46:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   PROCEDURE [dbo].[LISTAR_RATIOS_PARAMETROS]
AS
BEGIN
    SELECT 
        Id_Ratio,
        Categoria,
        Cantidad_Invitados_Por_Personal,
        Estado
    FROM PARAMETRO_RATIO
    WHERE Estado = 'Activo';
END;

GO
/****** Object:  StoredProcedure [dbo].[LISTAR_RESERVAS_CONFIRMADAS]    Script Date: 24/11/2026 19:46:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[LISTAR_RESERVAS_CONFIRMADAS]
AS
BEGIN
    SELECT 
        R.Id_Reserva, 
        R.Id_Cliente, 
        R.Id_Usuario, 
        R.Id_Presupuesto,
        R.Fecha_Evento, 
        R.Monto_Senia, 
        R.Estado,
        C.Nombre_Completo AS ClienteNombre,
        P.Tipo_Evento
    FROM RESERVA R
    INNER JOIN CLIENTE C ON R.Id_Cliente = C.Id_Cliente
    INNER JOIN PRESUPUESTO P ON R.Id_Presupuesto = P.Id_Presupuesto
    WHERE R.Estado = 'Confirmada';
END;

GO
/****** Object:  StoredProcedure [dbo].[LISTAR_TODO_HISTORIAL_USUARIOS]    Script Date: 24/11/2026 19:46:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[LISTAR_TODO_HISTORIAL_USUARIOS]
AS
BEGIN
    SELECT *
    FROM HISTORIAL_USUARIO
    ORDER BY fecha_cambio DESC
END

GO
/****** Object:  StoredProcedure [dbo].[LISTAR_USUARIOS]    Script Date: 24/11/2026 19:46:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[LISTAR_USUARIOS]
as
begin
select * from USUARIO 
ORDER BY ID ASC
end
GO
/****** Object:  StoredProcedure [dbo].[MIGRAR_USUARIOS_IDIOMA]    Script Date: 24/11/2026 19:46:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[MIGRAR_USUARIOS_IDIOMA]
    @viejo INT,
    @nuevo INT
AS
BEGIN
    UPDATE USUARIO 
    SET id_idioma = @nuevo 
    WHERE id_idioma = @viejo;
END
GO
/****** Object:  StoredProcedure [dbo].[MODIFICAR_PERMISO]    Script Date: 24/11/2026 19:46:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[MODIFICAR_PERMISO]
    @id INT,
    @nombre VARCHAR(50)
AS
BEGIN
    UPDATE PERMISO SET Nombre = @nombre WHERE Id = @id;
END

GO
/****** Object:  StoredProcedure [dbo].[MODIFICAR_PRODUCTO]    Script Date: 24/11/2026 19:46:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[MODIFICAR_PRODUCTO]
    @id INT,
    @nombre VARCHAR(100),
    @precio DECIMAL(18,2),
    @stock INT
AS
BEGIN
    UPDATE PRODUCTO
    SET Nombre = @nombre,
        Precio = @precio,
        Stock = @stock
    WHERE ID_PRODUCTO = @id
END

GO
/****** Object:  StoredProcedure [dbo].[MODIFICAR_USUARIO]    Script Date: 24/11/2026 19:46:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[MODIFICAR_USUARIO]
@id int, 
@usu varchar(50), -- Corrección: Cambiado de INT a VARCHAR(50) para que coincida con la tabla
@contra varchar(max), 
@dni int, 
@email varchar(50),
@dvh varchar(max) -- Nuevo: Recibe el nuevo hash horizontal recalculado en la BLL
AS
BEGIN
    UPDATE USUARIO SET
        USUARIO = @usu,
        CONTRASEÑA = @contra,
        DNI = @dni,
        EMAIL = @email,
        DVH = @dvh -- Actualizamos el candado horizontal para mantener la integridad
    WHERE ID = @id
END

GO
/****** Object:  StoredProcedure [dbo].[MOSTRAR_TRADUCCIONES]    Script Date: 24/11/2026 19:46:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[MOSTRAR_TRADUCCIONES]
AS
BEGIN
SELECT * FROM TRADUCCION
END
GO
/****** Object:  StoredProcedure [dbo].[OBTENER_BITACORA]    Script Date: 24/11/2026 19:46:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[OBTENER_BITACORA]
@desde datetime, @hasta datetime 
AS
BEGIN
select ID_BITACORA, FECHA, USUARIO, MODULO, OPERACION, CRITICIDAD 
FROM BITACORA
WHERE FECHA BETWEEN @desde AND @hasta
ORDER BY FECHA DESC
END
GO
/****** Object:  StoredProcedure [dbo].[OBTENER_BITACORA_TOTAL]    Script Date: 24/11/2026 19:46:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[OBTENER_BITACORA_TOTAL]
AS
BEGIN
SELECT * FROM BITACORA
ORDER BY FECHA DESC
END
GO
/****** Object:  StoredProcedure [dbo].[OBTENER_CRITICIDAD_BITACORA]    Script Date: 24/11/2026 19:46:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[OBTENER_CRITICIDAD_BITACORA]
as
begin
SELECT DISTINCT CRITICIDAD FROM BITACORA
ORDER BY CRITICIDAD ASC
end
GO
/****** Object:  StoredProcedure [dbo].[OBTENER_DEMANDA_TIPOS_EVENTO]    Script Date: 24/11/2026 19:46:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   PROCEDURE [dbo].[OBTENER_DEMANDA_TIPOS_EVENTO]
    @FechaDesde DATETIME,
    @FechaHasta DATETIME
AS
BEGIN
    SELECT 
        P.tipo_evento AS TipoEvento,
        COUNT(R.id_Reserva) AS CantidadEventos
    FROM RESERVA R
    INNER JOIN PRESUPUESTO P ON R.id_Presupuesto = P.id_Presupuesto
    WHERE R.fecha_Evento BETWEEN @FechaDesde AND @FechaHasta
      AND R.estado != 'Cancelado'
    GROUP BY P.tipo_evento
    ORDER BY CantidadEventos DESC;
END;

GO
/****** Object:  StoredProcedure [dbo].[OBTENER_DISTRIBUCION_CATEGORIA_PERSONAL]    Script Date: 24/11/2026 19:46:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   PROCEDURE [dbo].[OBTENER_DISTRIBUCION_CATEGORIA_PERSONAL]
    @FechaDesde DATETIME,
    @FechaHasta DATETIME
AS
BEGIN
    SELECT 
        P.categoria AS Categoria,
        COUNT(AP.id_Asignacion) AS CantidadAsignaciones
    FROM ASIGNACION_PERSONAL AP
    INNER JOIN PERSONAL P ON AP.id_Personal = P.id_Personal
    INNER JOIN RESERVA R ON AP.id_Reserva = R.id_Reserva
    WHERE R.fecha_Evento BETWEEN @FechaDesde AND @FechaHasta
      AND R.estado != 'Cancelado'
    GROUP BY P.categoria;
END;

GO
/****** Object:  StoredProcedure [dbo].[OBTENER_DVV]    Script Date: 24/11/2026 19:46:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[OBTENER_DVV]
@tabla varchar(50)
AS
BEGIN
    SELECT DVV FROM DIGITO_VERIFICADOR WHERE TABLA = @tabla
END

GO
/****** Object:  StoredProcedure [dbo].[OBTENER_ESTADISTICAS_PRESUPUESTOS]    Script Date: 24/11/2026 19:46:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[OBTENER_ESTADISTICAS_PRESUPUESTOS]
    @Desde DATETIME,
    @Hasta DATETIME
AS
BEGIN
    SELECT 
        ISNULL(SUM(CASE WHEN estado = 'Aprobado' THEN 1 ELSE 0 END), 0) AS Aprobados,
        ISNULL(SUM(CASE WHEN estado = 'Pendiente' THEN 1 ELSE 0 END), 0) AS Pendientes,
        ISNULL(SUM(CASE WHEN estado = 'Rechazado' THEN 1 ELSE 0 END), 0) AS Rechazados,
        COUNT(*) AS Total
    FROM PRESUPUESTO
    -- OJO: Reemplaza "fecha_Emision" por el nombre real de la columna de fecha en tu tabla PRESUPUESTO
    WHERE Fecha_Evento BETWEEN @Desde AND @Hasta; 
END;

GO
/****** Object:  StoredProcedure [dbo].[OBTENER_FECHAS_ALTERNATIVAS]    Script Date: 24/11/2026 19:46:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[OBTENER_FECHAS_ALTERNATIVAS]
    @Fecha_Evento DATETIME
AS
BEGIN
    -- Generamos un calendario virtual de 30 días a partir del día siguiente al solicitado
    WITH CalendarioVirtual AS (
        SELECT DATEADD(DAY, 1, CONVERT(DATE, @Fecha_Evento)) AS FechaDisponible, 1 AS Dia
        UNION ALL
        SELECT DATEADD(DAY, 1, FechaDisponible), Dia + 1
        FROM CalendarioVirtual
        WHERE Dia < 30
    )
    
    -- Seleccionamos solo las primeras 5 fechas que NO existan en la tabla RESERVA
    SELECT TOP 5 FechaDisponible
    FROM CalendarioVirtual
    WHERE NOT EXISTS (
        SELECT 1 
        FROM RESERVA R 
        WHERE CONVERT(DATE, R.Fecha_Evento) = CalendarioVirtual.FechaDisponible
          AND R.Estado != 'Cancelada'
    )
    ORDER BY FechaDisponible;
END;

GO
/****** Object:  StoredProcedure [dbo].[OBTENER_FECHAS_OCUPADAS]    Script Date: 24/11/2026 19:46:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   PROCEDURE [dbo].[OBTENER_FECHAS_OCUPADAS]
AS
BEGIN
    -- Usamos DISTINCT para que devuelva cada fecha ocupada una sola vez
    SELECT DISTINCT Fecha_Evento 
    FROM RESERVA 
    WHERE Estado = 'Confirmada';
END;

GO
/****** Object:  StoredProcedure [dbo].[OBTENER_FICHA_TECNICA_POR_RESERVA]    Script Date: 24/11/2026 19:46:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[OBTENER_FICHA_TECNICA_POR_RESERVA]
    @Id_Reserva INT
AS
BEGIN
    SELECT 
        Id_Ficha, 
        Id_Reserva, 
        Id_Servicio, 
        Cantidad_Invitados_Final
    FROM FICHA_TECNICA
    WHERE Id_Reserva = @Id_Reserva;
END;
GO
/****** Object:  StoredProcedure [dbo].[OBTENER_IDIOMA]    Script Date: 24/11/2026 19:46:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROC [dbo].[OBTENER_IDIOMA]
AS
BEGIN
SELECT * FROM IDIOMA
END
GO
/****** Object:  StoredProcedure [dbo].[OBTENER_INGRESOS_FINANCIEROS]    Script Date: 24/11/2026 19:46:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[OBTENER_INGRESOS_FINANCIEROS]
    @Desde DATETIME,
    @Hasta DATETIME
AS
BEGIN
    SELECT 
        ISNULL(SUM(monto_Senia), 0) AS TotalCobrado,
        ISNULL(SUM(saldo_Pendiente), 0) AS TotalPendiente,
        ISNULL(SUM(costo_Total_Real), 0) AS TotalProyectado
    FROM RESERVA
    WHERE estado != 'Cancelado'
      AND fecha_Evento BETWEEN @Desde AND @Hasta;
END;

GO
/****** Object:  StoredProcedure [dbo].[OBTENER_MODULO_BITACORA]    Script Date: 24/11/2026 19:46:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[OBTENER_MODULO_BITACORA]
AS
BEGIN
SELECT DISTINCT MODULO FROM BITACORA
ORDER BY MODULO ASC
END
GO
/****** Object:  StoredProcedure [dbo].[OBTENER_PERMISOS_DE_USUARIO]    Script Date: 24/11/2026 19:46:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[OBTENER_PERMISOS_DE_USUARIO]
    @idUsuario INT
AS
BEGIN
    SELECT Id_Permiso FROM USUARIO_PERMISO WHERE Id_Usuario = @idUsuario
END

GO
/****** Object:  StoredProcedure [dbo].[OBTENER_PERSONAL_ASIGNADO]    Script Date: 24/11/2026 19:46:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[OBTENER_PERSONAL_ASIGNADO]
    @Id_Reserva INT
AS
BEGIN
    SELECT 
        P.Id_Personal,
        P.DNI,
        P.Nombre,
        P.Apellido,
        P.Categoria
    FROM ASIGNACION_PERSONAL A
    INNER JOIN PERSONAL P ON A.Id_Personal = P.Id_Personal
    WHERE A.Id_Reserva = @Id_Reserva
    ORDER BY P.Categoria, P.Apellido;
END;

GO
/****** Object:  StoredProcedure [dbo].[OBTENER_RECETARIO_SERVICIO]    Script Date: 24/11/2026 19:46:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   PROCEDURE [dbo].[OBTENER_RECETARIO_SERVICIO]
    @Id_Servicio INT
AS
BEGIN
    SELECT 
        r.Id_Detalle_Recetario,
        r.Id_Servicio,
        r.Id_Insumo,
        r.Cantidad_Por_Persona,
        i.Nombre AS Nombre_Insumo,
        i.Rubro AS Rubro_Insumo,
        i.Unidad_Medida AS Unidad_Medida_Insumo
    FROM RECETARIO r
    INNER JOIN INSUMO i ON r.Id_Insumo = i.Id_Insumo
    WHERE r.Id_Servicio = @Id_Servicio;
END;

GO
/****** Object:  StoredProcedure [dbo].[OBTENER_RELACIONES_PERMISOS]    Script Date: 24/11/2026 19:46:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[OBTENER_RELACIONES_PERMISOS]
AS
BEGIN
    SELECT 
        ID_PADRE, 
        ID_HIJO 
    FROM PERMISO_PERMISO
END

GO
/****** Object:  StoredProcedure [dbo].[OBTENER_SALDOS_PENDIENTES_CLIENTES]    Script Date: 24/11/2026 19:46:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[OBTENER_SALDOS_PENDIENTES_CLIENTES]
    @Desde DATETIME,
    @Hasta DATETIME
AS
BEGIN
    SELECT 
        R.Id_Reserva,
        C.nombre_completo AS Cliente,
        R.fecha_Evento AS Fecha_Evento,
        R.costo_Total_Real AS Costo_Total,
        R.monto_Senia AS Monto_Senia,
        R.saldo_Pendiente AS Saldo_Pendiente
    FROM RESERVA R
    INNER JOIN CLIENTE C ON R.id_Cliente = C.id_Cliente
    WHERE R.saldo_Pendiente > 0 
      AND R.estado != 'Cancelado'
      AND R.fecha_Evento BETWEEN @Desde AND @Hasta
    ORDER BY R.fecha_Evento ASC;
END;

GO
/****** Object:  StoredProcedure [dbo].[OBTENER_TARIFA_EVENTO]    Script Date: 24/11/2026 19:46:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- AHORA SÍ, CREAMOS EL STORED PROCEDURE QUE PIDE EL C#
CREATE   PROCEDURE [dbo].[OBTENER_TARIFA_EVENTO]
    @Tipo_Evento VARCHAR(50)
AS
BEGIN
    SELECT TarifaBase
    FROM TARIFA_EVENTO
    WHERE Tipo_Evento = @Tipo_Evento;
END;

GO
/****** Object:  StoredProcedure [dbo].[OBTENER_TODOS_DVH_USUARIO]    Script Date: 24/11/2026 19:46:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[OBTENER_TODOS_DVH_USUARIO]
AS
BEGIN
    
    SELECT DVH FROM USUARIO ORDER BY ID ASC 
END
GO
/****** Object:  StoredProcedure [dbo].[OBTENER_TOP_PERSONAL_ASISTENCIA]    Script Date: 24/11/2026 19:46:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   PROCEDURE [dbo].[OBTENER_TOP_PERSONAL_ASISTENCIA]
    @FechaDesde DATETIME,
    @FechaHasta DATETIME
AS
BEGIN
    SELECT TOP 10
        P.nombre + ' ' + P.apellido AS NombreCompleto,
        P.categoria AS Categoria,
        COUNT(AP.id_Asignacion) AS CantidadEventos
    FROM ASIGNACION_PERSONAL AP
    INNER JOIN PERSONAL P ON AP.id_Personal = P.id_Personal
    INNER JOIN RESERVA R ON AP.id_Reserva = R.id_Reserva
    WHERE R.fecha_Evento BETWEEN @FechaDesde AND @FechaHasta
      AND R.estado != 'Cancelado'
    GROUP BY P.nombre, P.apellido, P.categoria
    ORDER BY CantidadEventos DESC;
END;

GO
/****** Object:  StoredProcedure [dbo].[OBTENER_TRADUCCIONES]    Script Date: 24/11/2026 19:46:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- SP 2: El Motor de Traducción (Hace el INNER JOIN de las 3 tablas)
CREATE PROCEDURE [dbo].[OBTENER_TRADUCCIONES]
    @id_idioma INT
AS
BEGIN
    SELECT
	    T.ID_TRADUCCION,
        C.nombre_formulario, 
        C.nombre_control, 
        T.texto_traducido 
    FROM CONTROL C
    INNER JOIN TRADUCCION T ON C.id_control = T.id_control
    WHERE T.id_idioma = @id_idioma;
END;

GO
/****** Object:  StoredProcedure [dbo].[OBTENER_USUARIO_POR_NOMBRE]    Script Date: 24/11/2026 19:46:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[OBTENER_USUARIO_POR_NOMBRE]
@usu varchar(50)
AS
BEGIN
SELECT * FROM USUARIO 
WHERE USUARIO= @usu AND ACTIVO = 1
END
GO
/****** Object:  StoredProcedure [dbo].[OBTENER_USUARIOS_BITACORA]    Script Date: 24/11/2026 19:46:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[OBTENER_USUARIOS_BITACORA]
AS
BEGIN
SELECT DISTINCT USUARIO FROM BITACORA
ORDER BY USUARIO ASC
END
GO
/****** Object:  StoredProcedure [dbo].[OBTENER_VOLUMEN_EVENTOS_POR_MES]    Script Date: 24/11/2026 19:46:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   PROCEDURE [dbo].[OBTENER_VOLUMEN_EVENTOS_POR_MES]
    @FechaDesde DATETIME,
    @FechaHasta DATETIME
AS
BEGIN
    SELECT 
        FORMAT(fecha_Evento, 'yyyy-MM') AS MesAño,
        COUNT(id_Reserva) AS CantidadEventos
    FROM RESERVA
    WHERE fecha_Evento BETWEEN @FechaDesde AND @FechaHasta
      AND estado != 'Cancelado'
    GROUP BY FORMAT(fecha_Evento, 'yyyy-MM')
    ORDER BY MesAño ASC;
END;

GO
/****** Object:  StoredProcedure [dbo].[REACTIVAR_PRODUCTO]    Script Date: 24/11/2026 19:46:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[REACTIVAR_PRODUCTO]
@id int
AS BEGIN
    UPDATE PRODUCTO SET ACTIVO = 1 WHERE ID_PRODUCTO = @id
END

GO
/****** Object:  StoredProcedure [dbo].[REACTIVAR_USUARIO]    Script Date: 24/11/2026 19:46:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[REACTIVAR_USUARIO]
@id int
AS BEGIN
    UPDATE USUARIO SET ACTIVO = 1 WHERE ID = @id
END

GO
/****** Object:  StoredProcedure [dbo].[REGISTRAR_EVALUACION_Y_FINALIZAR]    Script Date: 24/11/2026 19:46:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- 2. SP para guardar el feedback y finalizar la reserva
CREATE   PROCEDURE [dbo].[REGISTRAR_EVALUACION_Y_FINALIZAR]
    @Id_Reserva INT,
    @Resultado INT,
    @Observaciones VARCHAR(500)
AS
BEGIN
    UPDATE RESERVA
    SET 
        Evaluacion_Personal = @Resultado,
        Observaciones_Personal = @Observaciones,
        Estado = 'Finalizado'
    WHERE Id_Reserva = @Id_Reserva;
END;

GO
/****** Object:  StoredProcedure [dbo].[REGISTRAR_RECEPCION_ORDEN_COMPRA]    Script Date: 24/11/2026 19:46:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   PROCEDURE [dbo].[REGISTRAR_RECEPCION_ORDEN_COMPRA]
    @Id_OrdenCompra INT
AS
BEGIN
    UPDATE ORDEN_COMPRA
    SET Estado = 'Recibida'
    WHERE Id_OrdenCompra = @Id_OrdenCompra;
END;

GO
/****** Object:  StoredProcedure [dbo].[RESTAURAR_PRODUCTO_DESDE_HISTORIAL]    Script Date: 24/11/2026 19:46:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[RESTAURAR_PRODUCTO_DESDE_HISTORIAL]
    @id_historial INT,
    @usuario_accion VARCHAR(50)
AS
BEGIN
    -- 1. Actualizamos el producto con los datos de esa "foto" del pasado
    UPDATE P
    SET P.Nombre = H.Nombre,
        P.Precio = H.Precio,
        P.Stock = H.Stock
    FROM PRODUCTO P
    INNER JOIN HISTORIAL_PRODUCTO H ON P.ID_PRODUCTO = H.Id_Producto
    WHERE H.Id_Historial = @id_historial;

    -- 2. Le sacamos una foto nueva indicando que fue una RESTAURACIÓN
    DECLARE @id_prod INT;
    SELECT @id_prod = Id_Producto FROM HISTORIAL_PRODUCTO WHERE Id_Historial = @id_historial;

    -- Llamamos al SP de alta de historial que creamos antes
    EXEC INSERTAR_HISTORIAL_PRODUCTO @id_prod, @usuario_accion, 'RESTAURACION';
END

GO
/****** Object:  StoredProcedure [dbo].[RESTAURAR_USUARIO_DESDE_HISTORIAL]    Script Date: 24/11/2026 19:46:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[RESTAURAR_USUARIO_DESDE_HISTORIAL]
    @id_historial INT,
    @usuario_responsable VARCHAR(50)
AS
BEGIN
    -- Actualizamos la tabla original con los datos de la foto vieja
    UPDATE U
    SET U.usuario = H.usuario, U.contraseña = H.contraseña, U.dni = H.dni, 
        U.email = H.email, U.estadobloqueado = H.estadobloqueado, 
        U.intentosfallidos = H.intentosfallidos, U.id_idioma = H.id_idioma, U.dvh = H.dvh
    FROM USUARIO U
    INNER JOIN HISTORIAL_USUARIO H ON U.id = H.id_usuario
    WHERE H.id_historial = @id_historial;

    -- Le sacamos una foto nueva diciendo que fue una RESTAURACIÓN
    DECLARE @id_usu INT;
    SELECT @id_usu = id_usuario FROM HISTORIAL_USUARIO WHERE id_historial = @id_historial;

    EXEC INSERTAR_HISTORIAL_USUARIO @id_usu, @usuario_responsable, 'RESTAURACION';
END;
GO
/****** Object:  StoredProcedure [dbo].[SALDAR_RESERVA]    Script Date: 24/11/2026 19:46:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   PROCEDURE [dbo].[SALDAR_RESERVA]
    @Id_Reserva INT
AS
BEGIN
    UPDATE RESERVA
    SET Saldo_Pendiente = 0,
        Estado = 'Saldado'
    WHERE Id_Reserva = @Id_Reserva;
END;

GO
/****** Object:  StoredProcedure [dbo].[VALIDAR_DNI_CLIENTE]    Script Date: 24/11/2026 19:46:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   PROCEDURE [dbo].[VALIDAR_DNI_CLIENTE]
    @dni INT
AS
BEGIN
    SELECT Id_Cliente 
    FROM CLIENTE 
    WHERE Dni = @dni;
END;

GO
/****** Object:  StoredProcedure [dbo].[VALIDAR_USO_ROL]    Script Date: 24/11/2026 19:46:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[VALIDAR_USO_ROL]
@idPer int

AS
BEGIN
SELECT COUNT(*) FROM USUARIO_PERMISO WHERE Id_Permiso = @idPer
END

GO
/****** Object:  StoredProcedure [dbo].[VERIFICAR_CUIT_PROVEEDOR]    Script Date: 24/11/2026 19:46:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   PROCEDURE [dbo].[VERIFICAR_CUIT_PROVEEDOR]
    @CUIT VARCHAR(20),
    @Id_Proveedor INT = 0
AS
BEGIN
    SELECT Id_Proveedor
    FROM PROVEEDOR_INSUMO
    WHERE CUIT = @CUIT AND Id_Proveedor <> @Id_Proveedor;
END;

GO
/****** Object:  StoredProcedure [dbo].[VERIFICAR_DISPONIBILIDAD_FECHA]    Script Date: 24/11/2026 19:46:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   PROCEDURE [dbo].[VERIFICAR_DISPONIBILIDAD_FECHA]
    @Fecha_Evento DATETIME
AS
BEGIN
    -- En vez de COUNT, traemos el ID. 
    -- Si no hay reservas ese día, SQL devolverá 0 filas (Tabla vacía).
    -- Si hay reservas, devolverá 1 o más filas.
    SELECT Id_Reserva 
    FROM RESERVA 
    WHERE CONVERT(DATE, Fecha_Evento) = CONVERT(DATE, @Fecha_Evento)
      AND Estado != 'Cancelada';
END;

GO
/****** Object:  StoredProcedure [dbo].[VERIFICAR_DNI_PERSONAL]    Script Date: 24/11/2026 19:46:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   PROCEDURE [dbo].[VERIFICAR_DNI_PERSONAL]
    @DNI VARCHAR(20),
    @Id_Personal INT
AS
BEGIN
    SELECT Id_Personal 
    FROM PERSONAL 
    WHERE DNI = @DNI AND Id_Personal <> @Id_Personal;
END;

GO
/****** Object:  StoredProcedure [dbo].[VERIFICAR_ESTADO_PROVEEDOR]    Script Date: 24/11/2026 19:46:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[VERIFICAR_ESTADO_PROVEEDOR]
    @Id_Proveedor INT
AS
BEGIN
    SELECT Estado FROM PROVEEDOR WHERE Id_Proveedor = @Id_Proveedor;
END;

GO
/****** Object:  StoredProcedure [dbo].[VERIFICAR_NOMBRE_INSUMO]    Script Date: 24/11/2026 19:46:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- 3. SP: VERIFICAR_NOMBRE_INSUMO
CREATE   PROCEDURE [dbo].[VERIFICAR_NOMBRE_INSUMO]
    @Nombre VARCHAR(100),
    @Id_Insumo INT = 0
AS
BEGIN
    SELECT Id_Insumo
    FROM INSUMO
    WHERE Nombre = @Nombre AND Id_Insumo <> @Id_Insumo;
END;

GO
/****** Object:  StoredProcedure [dbo].[VERIFICAR_USUARIO]    Script Date: 24/11/2026 19:46:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[VERIFICAR_USUARIO]

@usu varchar(50), @contra varchar(50)
as

SELECT * FROM USUARIO
WHERE USUARIO.USUARIO =@usu AND USUARIO.CONTRASEÑA= @contra
GO
USE [master]
GO
ALTER DATABASE [BASE] SET  READ_WRITE 
GO
