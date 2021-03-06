CREATE DATABASE [PortalClientes] 
GO
ALTER DATABASE PortalClientes MODIFY FILE 
( NAME = N'PortalClientes' , SIZE = 3048KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
GO
ALTER DATABASE POS MODIFY FILE 
( NAME = N'PortalClientes_log' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO

GO
EXEC sys.sp_dropextendedproperty @name=N'MS_Description' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tblCLI_ClienteAprobador', @level2type=N'CONSTRAINT',@level2name=N'FK_usuario'

GO
EXEC sys.sp_dropextendedproperty @name=N'MS_Description' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tblCLI_ClienteAprobador', @level2type=N'CONSTRAINT',@level2name=N'FK_precliente'

GO
/****** Object:  StoredProcedure [dbo].[tblCLI_UsuariosAduabook_SP]    Script Date: 17/7/2018 20:19:30 ******/
DROP PROCEDURE [dbo].[tblCLI_UsuariosAduabook_SP]
GO
/****** Object:  StoredProcedure [dbo].[tblCLI_Usuarios_SP]    Script Date: 17/7/2018 20:19:30 ******/
DROP PROCEDURE [dbo].[tblCLI_Usuarios_SP]
GO
/****** Object:  StoredProcedure [dbo].[tblCLI_RolesModulos_SP]    Script Date: 17/7/2018 20:19:30 ******/
DROP PROCEDURE [dbo].[tblCLI_RolesModulos_SP]
GO
/****** Object:  StoredProcedure [dbo].[tblCLI_Roles_SP]    Script Date: 17/7/2018 20:19:30 ******/
DROP PROCEDURE [dbo].[tblCLI_Roles_SP]
GO
/****** Object:  StoredProcedure [dbo].[tblCLI_Modulos_SP]    Script Date: 17/7/2018 20:19:30 ******/
DROP PROCEDURE [dbo].[tblCLI_Modulos_SP]
GO
/****** Object:  StoredProcedure [dbo].[tblCLI_GuardarDocumentoCliente_SP]    Script Date: 17/7/2018 20:19:30 ******/
DROP PROCEDURE [dbo].[tblCLI_GuardarDocumentoCliente_SP]
GO
/****** Object:  StoredProcedure [dbo].[tblCLI_GuardarDatoCliente_SP]    Script Date: 17/7/2018 20:19:30 ******/
DROP PROCEDURE [dbo].[tblCLI_GuardarDatoCliente_SP]
GO
/****** Object:  StoredProcedure [dbo].[tblCLI_GuardaDatosAdicionales_SP]    Script Date: 17/7/2018 20:19:30 ******/
DROP PROCEDURE [dbo].[tblCLI_GuardaDatosAdicionales_SP]
GO
/****** Object:  StoredProcedure [dbo].[csp_CLIValidaAudasis_SP]    Script Date: 17/7/2018 20:19:30 ******/
DROP PROCEDURE [dbo].[csp_CLIValidaAudasis_SP]
GO
/****** Object:  StoredProcedure [dbo].[csp_CLI_ValidaLogin]    Script Date: 17/7/2018 20:19:30 ******/
DROP PROCEDURE [dbo].[csp_CLI_ValidaLogin]
GO
/****** Object:  StoredProcedure [dbo].[csp_CLI_ObtieneDocumentosCargados]    Script Date: 17/7/2018 20:19:30 ******/
DROP PROCEDURE [dbo].[csp_CLI_ObtieneDocumentosCargados]
GO
/****** Object:  StoredProcedure [dbo].[csp_CLI_ObtieneDocumentos_SP]    Script Date: 17/7/2018 20:19:30 ******/
DROP PROCEDURE [dbo].[csp_CLI_ObtieneDocumentos_SP]
GO
/****** Object:  StoredProcedure [dbo].[csp_CLI_ObtenerUsuariosAduabookCliente]    Script Date: 17/7/2018 20:19:30 ******/
DROP PROCEDURE [dbo].[csp_CLI_ObtenerUsuariosAduabookCliente]
GO
/****** Object:  StoredProcedure [dbo].[csp_CLI_ObtenerTotalTabuladores]    Script Date: 17/7/2018 20:19:30 ******/
DROP PROCEDURE [dbo].[csp_CLI_ObtenerTotalTabuladores]
GO
/****** Object:  StoredProcedure [dbo].[csp_CLI_ObtenerRelacionPreclienteAprobador]    Script Date: 17/7/2018 20:19:30 ******/
DROP PROCEDURE [dbo].[csp_CLI_ObtenerRelacionPreclienteAprobador]
GO
/****** Object:  StoredProcedure [dbo].[csp_CLI_ObtenerPreclientes]    Script Date: 17/7/2018 20:19:30 ******/
DROP PROCEDURE [dbo].[csp_CLI_ObtenerPreclientes]
GO
/****** Object:  StoredProcedure [dbo].[csp_CLI_ObtenerPatentes]    Script Date: 17/7/2018 20:19:30 ******/
DROP PROCEDURE [dbo].[csp_CLI_ObtenerPatentes]
GO
/****** Object:  StoredProcedure [dbo].[csp_CLI_ObtenerPaises]    Script Date: 17/7/2018 20:19:30 ******/
DROP PROCEDURE [dbo].[csp_CLI_ObtenerPaises]
GO
/****** Object:  StoredProcedure [dbo].[csp_CLI_ObtenerNotificacionesUsuario]    Script Date: 17/7/2018 20:19:30 ******/
DROP PROCEDURE [dbo].[csp_CLI_ObtenerNotificacionesUsuario]
GO
/****** Object:  StoredProcedure [dbo].[csp_CLI_ObtenerInformacionCliente]    Script Date: 17/7/2018 20:19:30 ******/
DROP PROCEDURE [dbo].[csp_CLI_ObtenerInformacionCliente]
GO
/****** Object:  StoredProcedure [dbo].[csp_CLI_ObtenerInfoCartaEncomienda]    Script Date: 17/7/2018 20:19:30 ******/
DROP PROCEDURE [dbo].[csp_CLI_ObtenerInfoCartaEncomienda]
GO
/****** Object:  StoredProcedure [dbo].[csp_CLI_ObtenerEstatusTerminosCondiciones]    Script Date: 17/7/2018 20:19:30 ******/
DROP PROCEDURE [dbo].[csp_CLI_ObtenerEstatusTerminosCondiciones]
GO
/****** Object:  StoredProcedure [dbo].[csp_CLI_ObtenerEstados]    Script Date: 17/7/2018 20:19:30 ******/
DROP PROCEDURE [dbo].[csp_CLI_ObtenerEstados]
GO
/****** Object:  StoredProcedure [dbo].[csp_CLI_ObtenerDocumentosCliente]    Script Date: 17/7/2018 20:19:30 ******/
DROP PROCEDURE [dbo].[csp_CLI_ObtenerDocumentosCliente]
GO
/****** Object:  StoredProcedure [dbo].[csp_CLI_ObtenerDireccionCliente]    Script Date: 17/7/2018 20:19:30 ******/
DROP PROCEDURE [dbo].[csp_CLI_ObtenerDireccionCliente]
GO
/****** Object:  StoredProcedure [dbo].[csp_CLI_ObtenerDestinatariosNotificacion]    Script Date: 17/7/2018 20:19:30 ******/
DROP PROCEDURE [dbo].[csp_CLI_ObtenerDestinatariosNotificacion]
GO
/****** Object:  StoredProcedure [dbo].[csp_CLI_ObtenerDatosUsuario]    Script Date: 17/7/2018 20:19:30 ******/
DROP PROCEDURE [dbo].[csp_CLI_ObtenerDatosUsuario]
GO
/****** Object:  StoredProcedure [dbo].[csp_CLI_ObtenerCuestionarioCliente]    Script Date: 17/7/2018 20:19:30 ******/
DROP PROCEDURE [dbo].[csp_CLI_ObtenerCuestionarioCliente]
GO
/****** Object:  StoredProcedure [dbo].[csp_CLI_ObtenerCuentasBancariasPECACliente]    Script Date: 17/7/2018 20:19:30 ******/
DROP PROCEDURE [dbo].[csp_CLI_ObtenerCuentasBancariasPECACliente]
GO
/****** Object:  StoredProcedure [dbo].[csp_CLI_ObtenerContactosCliente]    Script Date: 17/7/2018 20:19:30 ******/
DROP PROCEDURE [dbo].[csp_CLI_ObtenerContactosCliente]
GO
/****** Object:  StoredProcedure [dbo].[csp_CLI_ObtenerCiudades]    Script Date: 17/7/2018 20:19:30 ******/
DROP PROCEDURE [dbo].[csp_CLI_ObtenerCiudades]
GO
/****** Object:  StoredProcedure [dbo].[csp_CLI_GuardarRevisionDocumentosCliente]    Script Date: 17/7/2018 20:19:30 ******/
DROP PROCEDURE [dbo].[csp_CLI_GuardarRevisionDocumentosCliente]
GO
/****** Object:  StoredProcedure [dbo].[csp_CLI_GuardarCuestionarioSeguridad]    Script Date: 17/7/2018 20:19:30 ******/
DROP PROCEDURE [dbo].[csp_CLI_GuardarCuestionarioSeguridad]
GO
/****** Object:  StoredProcedure [dbo].[csp_CLI_EnvioNotificacion]    Script Date: 17/7/2018 20:19:30 ******/
DROP PROCEDURE [dbo].[csp_CLI_EnvioNotificacion]
GO
/****** Object:  StoredProcedure [dbo].[csp_CLI_ActualizarValorTerminosCondiciones]    Script Date: 17/7/2018 20:19:30 ******/
DROP PROCEDURE [dbo].[csp_CLI_ActualizarValorTerminosCondiciones]
GO
/****** Object:  StoredProcedure [dbo].[csp_CLI_ActualizarNuevoEstatus]    Script Date: 17/7/2018 20:19:30 ******/
DROP PROCEDURE [dbo].[csp_CLI_ActualizarNuevoEstatus]
GO
/****** Object:  StoredProcedure [dbo].[csp_CLI_ActualizarEstatusAprobacionRevalidacion]    Script Date: 17/7/2018 20:19:30 ******/
DROP PROCEDURE [dbo].[csp_CLI_ActualizarEstatusAprobacionRevalidacion]
GO
/****** Object:  StoredProcedure [dbo].[csp_CLI_ActualizarCartaEncomienda]    Script Date: 17/7/2018 20:19:30 ******/
DROP PROCEDURE [dbo].[csp_CLI_ActualizarCartaEncomienda]
GO
/****** Object:  StoredProcedure [dbo].[csp_CLI_ActualizarBanderilla]    Script Date: 17/7/2018 20:19:30 ******/
DROP PROCEDURE [dbo].[csp_CLI_ActualizarBanderilla]
GO
ALTER TABLE [dbo].[tblCLI_TarifaVenta] DROP CONSTRAINT [FK_tarifa_tabulador]
GO
ALTER TABLE [dbo].[tblCLI_TabuladorCatalogo] DROP CONSTRAINT [FK_tabulador_catalogo_actividad]
GO
ALTER TABLE [dbo].[tblCLI_Tabulador] DROP CONSTRAINT [FK_usuario_tabulador]
GO
ALTER TABLE [dbo].[tblCLI_Tabulador] DROP CONSTRAINT [FK_precliente_tabulador]
GO
ALTER TABLE [dbo].[tblCLI_Tab] DROP CONSTRAINT [FK_tabs_tabuladores]
GO
ALTER TABLE [dbo].[tblCLI_Pago] DROP CONSTRAINT [FK_tabulador_pago]
GO
ALTER TABLE [dbo].[tblCLI_Pago] DROP CONSTRAINT [FK_tab_pago]
GO
ALTER TABLE [dbo].[tblCLI_InfoFinancieraCobranza] DROP CONSTRAINT [FK_info_tabulador]
GO
ALTER TABLE [dbo].[tblCLI_ClienteAprobador] DROP CONSTRAINT [FK_usuario]
GO
ALTER TABLE [dbo].[tblCLI_ClienteAprobador] DROP CONSTRAINT [FK_precliente]
GO
/****** Object:  Table [dbo].[tblCLI_UsuariosAduabook]    Script Date: 17/7/2018 20:19:30 ******/
DROP TABLE [dbo].[tblCLI_UsuariosAduabook]
GO
/****** Object:  Table [dbo].[tblCLI_Usuarios]    Script Date: 17/7/2018 20:19:30 ******/
DROP TABLE [dbo].[tblCLI_Usuarios]
GO
/****** Object:  Table [dbo].[tblCLI_TarifaVenta]    Script Date: 17/7/2018 20:19:30 ******/
DROP TABLE [dbo].[tblCLI_TarifaVenta]
GO
/****** Object:  Table [dbo].[tblCLI_TabuladorCatalogo]    Script Date: 17/7/2018 20:19:30 ******/
DROP TABLE [dbo].[tblCLI_TabuladorCatalogo]
GO
/****** Object:  Table [dbo].[tblCLI_Tabulador]    Script Date: 17/7/2018 20:19:30 ******/
DROP TABLE [dbo].[tblCLI_Tabulador]
GO
/****** Object:  Table [dbo].[tblCLI_Tab]    Script Date: 17/7/2018 20:19:30 ******/
DROP TABLE [dbo].[tblCLI_Tab]
GO
/****** Object:  Table [dbo].[tblCLI_RolesModulos]    Script Date: 17/7/2018 20:19:30 ******/
DROP TABLE [dbo].[tblCLI_RolesModulos]
GO
/****** Object:  Table [dbo].[tblCLI_RolesEstatus]    Script Date: 17/7/2018 20:19:30 ******/
DROP TABLE [dbo].[tblCLI_RolesEstatus]
GO
/****** Object:  Table [dbo].[tblCLI_Roles]    Script Date: 17/7/2018 20:19:30 ******/
DROP TABLE [dbo].[tblCLI_Roles]
GO
/****** Object:  Table [dbo].[tblCLI_Respuestas]    Script Date: 17/7/2018 20:19:30 ******/
DROP TABLE [dbo].[tblCLI_Respuestas]
GO
/****** Object:  Table [dbo].[tblCLI_Preguntas]    Script Date: 17/7/2018 20:19:30 ******/
DROP TABLE [dbo].[tblCLI_Preguntas]
GO
/****** Object:  Table [dbo].[tblCLI_Patentes]    Script Date: 17/7/2018 20:19:30 ******/
DROP TABLE [dbo].[tblCLI_Patentes]
GO
/****** Object:  Table [dbo].[tblCLI_Pago]    Script Date: 17/7/2018 20:19:30 ******/
DROP TABLE [dbo].[tblCLI_Pago]
GO
/****** Object:  Table [dbo].[tblCLI_NotificacionesUsuario]    Script Date: 17/7/2018 20:19:30 ******/
DROP TABLE [dbo].[tblCLI_NotificacionesUsuario]
GO
/****** Object:  Table [dbo].[tblCLI_Notificaciones]    Script Date: 17/7/2018 20:19:30 ******/
DROP TABLE [dbo].[tblCLI_Notificaciones]
GO
/****** Object:  Table [dbo].[tblCLI_Modulos]    Script Date: 17/7/2018 20:19:30 ******/
DROP TABLE [dbo].[tblCLI_Modulos]
GO
/****** Object:  Table [dbo].[tblCLI_InfoFinancieraCobranza]    Script Date: 17/7/2018 20:19:30 ******/
DROP TABLE [dbo].[tblCLI_InfoFinancieraCobranza]
GO
/****** Object:  Table [dbo].[tblCLI_Estatus]    Script Date: 17/7/2018 20:19:30 ******/
DROP TABLE [dbo].[tblCLI_Estatus]
GO
/****** Object:  Table [dbo].[tblCLI_DocumentosCliente]    Script Date: 17/7/2018 20:19:30 ******/
DROP TABLE [dbo].[tblCLI_DocumentosCliente]
GO
/****** Object:  Table [dbo].[tblCLI_Documentos]    Script Date: 17/7/2018 20:19:30 ******/
DROP TABLE [dbo].[tblCLI_Documentos]
GO
/****** Object:  Table [dbo].[tblCLI_CuentasBancariasPECA]    Script Date: 17/7/2018 20:19:30 ******/
DROP TABLE [dbo].[tblCLI_CuentasBancariasPECA]
GO
/****** Object:  Table [dbo].[tblCLI_Contactos]    Script Date: 17/7/2018 20:19:30 ******/
DROP TABLE [dbo].[tblCLI_Contactos]
GO
/****** Object:  Table [dbo].[tblCLI_Clientes]    Script Date: 17/7/2018 20:19:30 ******/
DROP TABLE [dbo].[tblCLI_Clientes]
GO
/****** Object:  Table [dbo].[tblCLI_ClienteAprobador]    Script Date: 17/7/2018 20:19:30 ******/
DROP TABLE [dbo].[tblCLI_ClienteAprobador]
GO
/****** Object:  UserDefinedTableType [dbo].[udt_tblCLI_DocumentosCliente]    Script Date: 17/7/2018 20:19:30 ******/
DROP TYPE [dbo].[udt_tblCLI_DocumentosCliente]
GO
/****** Object:  UserDefinedTableType [dbo].[udt_tblCLI_CuentasBancariasPECA]    Script Date: 17/7/2018 20:19:30 ******/
DROP TYPE [dbo].[udt_tblCLI_CuentasBancariasPECA]
GO
/****** Object:  UserDefinedTableType [dbo].[udt_tblCLI_Contactos]    Script Date: 17/7/2018 20:19:30 ******/
DROP TYPE [dbo].[udt_tblCLI_Contactos]
GO
/****** Object:  UserDefinedTableType [dbo].[udt_tblCLI_Clientes]    Script Date: 17/7/2018 20:19:30 ******/
DROP TYPE [dbo].[udt_tblCLI_Clientes]
GO
/****** Object:  User [surias]    Script Date: 17/7/2018 20:19:30 ******/
DROP USER [surias]
GO
USE [master]
GO
/****** Object:  Database [PortalClientes]    Script Date: 17/7/2018 20:19:30 ******/
DROP DATABASE [PortalClientes]
GO
/****** Object:  Database [PortalClientes]    Script Date: 17/7/2018 20:19:30 ******/
CREATE DATABASE [PortalClientes] ON  PRIMARY 
( NAME = N'PortalClientes', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL10_50.MSSQLSERVER\MSSQL\DATA\PortalClientes.mdf' , SIZE = 3072KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'PortalClientes_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL10_50.MSSQLSERVER\MSSQL\DATA\PortalClientes_log.ldf' , SIZE = 9216KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [PortalClientes] SET COMPATIBILITY_LEVEL = 100
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [PortalClientes].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [PortalClientes] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [PortalClientes] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [PortalClientes] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [PortalClientes] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [PortalClientes] SET ARITHABORT OFF 
GO
ALTER DATABASE [PortalClientes] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [PortalClientes] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [PortalClientes] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [PortalClientes] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [PortalClientes] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [PortalClientes] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [PortalClientes] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [PortalClientes] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [PortalClientes] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [PortalClientes] SET  DISABLE_BROKER 
GO
ALTER DATABASE [PortalClientes] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [PortalClientes] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [PortalClientes] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [PortalClientes] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [PortalClientes] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [PortalClientes] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [PortalClientes] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [PortalClientes] SET RECOVERY FULL 
GO
ALTER DATABASE [PortalClientes] SET  MULTI_USER 
GO
ALTER DATABASE [PortalClientes] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [PortalClientes] SET DB_CHAINING OFF 
GO
EXEC sys.sp_db_vardecimal_storage_format N'PortalClientes', N'ON'
GO
USE [PortalClientes]
GO
/****** Object:  User [surias]    Script Date: 17/7/2018 20:19:32 ******/
CREATE USER [surias] FOR LOGIN [surias] WITH DEFAULT_SCHEMA=[dbo]
GO
ALTER ROLE [db_owner] ADD MEMBER [surias]
GO
/****** Object:  UserDefinedTableType [dbo].[udt_tblCLI_Clientes]    Script Date: 17/7/2018 20:19:32 ******/
CREATE TYPE [dbo].[udt_tblCLI_Clientes] AS TABLE(
	[id_precliente] [int] NULL,
	[representante_legal] [varchar](50) NULL,
	[nombre_fiscal] [varchar](50) NULL,
	[rfc] [varchar](50) NULL,
	[nombre_comercial] [varchar](50) NULL,
	[calle] [varchar](100) NULL,
	[no_ext] [varchar](10) NULL,
	[no_int] [varchar](10) NULL,
	[colonia] [varchar](50) NULL,
	[id_ciudad] [varchar](50) NULL,
	[cp] [varchar](10) NULL,
	[id_estado] [varchar](50) NULL,
	[id_pais] [varchar](50) NULL,
	[telefono] [varchar](20) NULL,
	[banco] [varchar](15) NULL,
	[numero_cuenta] [int] NULL,
	[clabe_interbancaria] [int] NULL,
	[moneda] [varchar](10) NULL,
	[sucursal_banco] [varchar](20) NULL,
	[ciudad_banco] [varchar](20) NULL,
	[estatus] [int] NULL,
	[aceptacion_terminos_condiciones] [bit] NULL,
	[fecha_modificacion] [datetime] NULL,
	[usuario_modificacion] [varchar](50) NULL
)
GO
/****** Object:  UserDefinedTableType [dbo].[udt_tblCLI_Contactos]    Script Date: 17/7/2018 20:19:35 ******/
CREATE TYPE [dbo].[udt_tblCLI_Contactos] AS TABLE(
	[id_precliente] [int] NULL,
	[nombre] [varchar](100) NULL,
	[correo] [varchar](50) NULL,
	[telefono] [varchar](20) NULL,
	[area] [varchar](50) NULL,
	[puesto_departamento] [varchar](30) NULL,
	[fecha_creacion] [datetime] NULL,
	[usuario_creacion] [varchar](50) NULL,
	[fecha_modificacion] [datetime] NULL,
	[usuario_modificacion] [varchar](50) NULL
)
GO
/****** Object:  UserDefinedTableType [dbo].[udt_tblCLI_CuentasBancariasPECA]    Script Date: 17/7/2018 20:19:36 ******/
CREATE TYPE [dbo].[udt_tblCLI_CuentasBancariasPECA] AS TABLE(
	[id_precliente] [int] NULL,
	[banco] [varchar](15) NULL,
	[numero_cuenta] [int] NULL,
	[identificador] [varchar](20) NULL,
	[patentes_autorizadas] [varchar](50) NULL,
	[aduana] [varchar](30) NULL,
	[fecha_creacion] [datetime] NULL,
	[usuario_creacion] [varchar](50) NULL,
	[fecha_modificacion] [datetime] NULL,
	[usuario_modificacion] [varchar](50) NULL
)
GO
/****** Object:  UserDefinedTableType [dbo].[udt_tblCLI_DocumentosCliente]    Script Date: 17/7/2018 20:19:38 ******/
CREATE TYPE [dbo].[udt_tblCLI_DocumentosCliente] AS TABLE(
	[id_documento_cliente] [int] NULL,
	[id_documento] [int] NULL,
	[id_precliente] [int] NULL,
	[activo] [bit] NULL,
	[ruta_local] [varchar](300) NULL,
	[fecha_creacion] [datetime] NULL,
	[usuario_creacion] [varchar](50) NULL,
	[fecha_modificacion] [datetime] NULL,
	[usuario_modificacion] [varchar](50) NULL,
	[motivo_sin_carta_encomienda_respaldo] [varchar](100) NULL
)
GO
/****** Object:  Table [dbo].[tblCLI_ClienteAprobador]    Script Date: 17/7/2018 20:19:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblCLI_ClienteAprobador](
	[id_cliente_aprobador] [int] IDENTITY(1,1) NOT NULL,
	[precliente] [int] NOT NULL,
	[usuario] [int] NOT NULL,
	[observacion] [varchar](250) NOT NULL,
	[fecha_creacion] [datetime] NOT NULL,
	[usuario_creacion] [varchar](50) NOT NULL,
	[fecha_modificacion] [datetime] NULL,
	[usuario_modificacion] [varchar](50) NULL,
 CONSTRAINT [PK_tblCLI_Cliente_Aprobador] PRIMARY KEY CLUSTERED 
(
	[id_cliente_aprobador] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tblCLI_Clientes]    Script Date: 17/7/2018 20:19:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblCLI_Clientes](
	[id_precliente] [int] IDENTITY(1,1) NOT NULL,
	[id_usuario] [int] NOT NULL,
	[id_cliente_aduasis] [varchar](50) NULL,
	[id_cliente_gp] [varchar](50) NULL,
	[es_cliente] [bit] NOT NULL,
	[representante_legal] [varchar](50) NULL,
	[nombre_fiscal] [varchar](50) NULL,
	[rfc] [varchar](50) NULL,
	[nombre_comercial] [varchar](50) NULL,
	[calle] [varchar](100) NULL,
	[no_ext] [varchar](10) NULL,
	[no_int] [varchar](10) NULL,
	[colonia] [varchar](50) NULL,
	[id_ciudad] [varchar](50) NULL,
	[cp] [varchar](10) NULL,
	[id_estado] [varchar](50) NULL,
	[id_pais] [varchar](50) NULL,
	[telefono] [varchar](20) NULL,
	[giro] [varchar](30) NULL,
	[tiempo_establecido] [varchar](20) NULL,
	[numero_empleados] [int] NULL,
	[ventas_anuales] [decimal](18, 0) NULL,
	[pagina_web] [varchar](100) NULL,
	[patentes_operacion] [varchar](50) NULL,
	[frecuencia_embarques] [varchar](50) NULL,
	[vucem_cliente] [bit] NULL,
	[vucem_grupoei] [bit] NULL,
	[correos_arribo_embarque] [varchar](1000) NULL,
	[banco] [varchar](15) NULL,
	[numero_cuenta] [int] NULL,
	[clabe_interbancaria] [int] NULL,
	[moneda] [varchar](10) NULL,
	[sucursal_banco] [varchar](20) NULL,
	[ciudad_banco] [varchar](20) NULL,
	[certificacion1] [varchar](10) NULL,
	[certificacion2] [varchar](10) NULL,
	[numero_puertos] [varchar](3) NULL,
	[con_carta_encomienda_respaldo] [bit] NULL,
	[motivo_sin_carta_encomienda_respaldo] [varchar](100) NULL,
	[banderilla] [bit] NOT NULL,
	[estatus] [int] NOT NULL,
	[aceptacion_terminos_condiciones] [bit] NULL,
	[domicilio_fiscal_calle] [varchar](100) NULL,
	[domicilio_fiscal_ciudad] [varchar](50) NULL,
	[domicilio_fiscal_colonia] [varchar](50) NULL,
	[domicilio_fiscal_cp] [varchar](10) NULL,
	[domicilio_fiscal_estado] [varchar](50) NULL,
	[domicilio_fiscal_municipio] [varchar](50) NULL,
	[domicilio_fiscal_no_ext] [varchar](10) NULL,
	[domicilio_fiscal_no_int] [varchar](10) NULL,
	[numero_escritura] [varchar](10) NULL,
	[nombre_notario] [varchar](200) NULL,
	[numero_notaria] [varchar](10) NULL,
	[ciudad_notariado] [varchar](50) NULL,
	[estado_notariado] [varchar](50) NULL,
	[membrete_empresa] [varchar](50) NULL,
	[periodo_compredido_inicio] [datetime] NULL,
	[periodo_compredido_fin] [datetime] NULL,
	[fecha_creacion] [datetime] NOT NULL,
	[usuario_creacion] [varchar](50) NOT NULL,
	[fecha_modificacion] [datetime] NULL,
	[usuario_modificacion] [varchar](50) NULL,
	[patente_carta_encomienda] [varchar](4) NULL,
 CONSTRAINT [PK_tblCLI_Clientes] PRIMARY KEY CLUSTERED 
(
	[id_precliente] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tblCLI_Contactos]    Script Date: 17/7/2018 20:19:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblCLI_Contactos](
	[id_contacto] [int] IDENTITY(1,1) NOT NULL,
	[id_precliente] [int] NOT NULL,
	[nombre] [varchar](100) NOT NULL,
	[correo] [varchar](50) NOT NULL,
	[telefono] [varchar](20) NOT NULL,
	[area] [varchar](50) NOT NULL,
	[puesto_departamento] [varchar](30) NOT NULL,
	[fecha_creacion] [datetime] NOT NULL,
	[usuario_creacion] [varchar](50) NOT NULL,
	[fecha_modificacion] [datetime] NULL,
	[usuario_modificacion] [varchar](50) NULL,
 CONSTRAINT [PK_tblCLI_Contactos] PRIMARY KEY CLUSTERED 
(
	[id_contacto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tblCLI_CuentasBancariasPECA]    Script Date: 17/7/2018 20:19:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblCLI_CuentasBancariasPECA](
	[id_banco] [int] IDENTITY(1,1) NOT NULL,
	[id_precliente] [int] NOT NULL,
	[banco] [varchar](15) NOT NULL,
	[numero_cuenta] [int] NOT NULL,
	[identificador] [varchar](20) NOT NULL,
	[patentes_autorizadas] [varchar](50) NOT NULL,
	[aduana] [varchar](30) NOT NULL,
	[fecha_creacion] [datetime] NOT NULL,
	[usuario_creacion] [varchar](50) NOT NULL,
	[fecha_modificacion] [datetime] NULL,
	[usuario_modificacion] [varchar](50) NULL,
 CONSTRAINT [PK_tblCLI_Bancos] PRIMARY KEY CLUSTERED 
(
	[id_banco] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tblCLI_Documentos]    Script Date: 17/7/2018 20:19:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblCLI_Documentos](
	[id_documento] [int] IDENTITY(1,1) NOT NULL,
	[descripcion] [varchar](100) NOT NULL,
 CONSTRAINT [PK_tblCLI_Documentos] PRIMARY KEY CLUSTERED 
(
	[id_documento] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tblCLI_DocumentosCliente]    Script Date: 17/7/2018 20:19:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblCLI_DocumentosCliente](
	[id_documento_cliente] [int] IDENTITY(1,1) NOT NULL,
	[id_documento] [int] NOT NULL,
	[id_precliente] [int] NOT NULL,
	[activo] [bit] NOT NULL,
	[ruta_local] [varchar](300) NOT NULL,
	[fecha_creacion] [datetime] NOT NULL,
	[usuario_creacion] [varchar](50) NOT NULL,
	[fecha_modificacion] [datetime] NULL,
	[usuario_modificacion] [varchar](50) NULL,
	[id_usuario_revision] [varchar](50) NULL,
	[fecha_revision] [datetime] NULL,
 CONSTRAINT [PK_tblCLI_DocumentosCliente] PRIMARY KEY CLUSTERED 
(
	[id_documento_cliente] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tblCLI_Estatus]    Script Date: 17/7/2018 20:19:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblCLI_Estatus](
	[id_estatus] [int] IDENTITY(1,1) NOT NULL,
	[estatus] [int] NOT NULL,
	[descripcion] [varchar](100) NOT NULL,
 CONSTRAINT [PK_tblCLI_Estatus] PRIMARY KEY CLUSTERED 
(
	[id_estatus] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tblCLI_InfoFinancieraCobranza]    Script Date: 17/7/2018 20:19:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblCLI_InfoFinancieraCobranza](
	[id_info_fin_cob] [int] IDENTITY(1,1) NOT NULL,
	[tabulador] [int] NULL,
	[condiciones_pago] [varchar](20) NOT NULL,
	[periodi_gracia] [varchar](20) NOT NULL,
	[dias_pago] [varchar](15) NOT NULL,
	[horarios_pago] [varchar](15) NOT NULL,
	[suspender_cliente] [bit] NOT NULL,
	[fondo] [bit] NOT NULL,
	[monto_fondo] [int] NULL,
	[financiamiento] [bit] NOT NULL,
	[monto_financiamiento] [int] NULL,
	[para_uso_en] [varchar](20) NULL,
	[punto_reorden] [varchar](60) NULL,
	[recuperacion] [varchar](30) NULL,
	[plazo] [varchar](30) NULL,
	[condiciones] [varchar](200) NULL,
 CONSTRAINT [PK_tblCLI_InfoFinancieraCobranza] PRIMARY KEY CLUSTERED 
(
	[id_info_fin_cob] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tblCLI_Modulos]    Script Date: 17/7/2018 20:19:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblCLI_Modulos](
	[id_modulo] [int] IDENTITY(1,1) NOT NULL,
	[descripcion] [varchar](100) NOT NULL,
	[fecha_creacion] [datetime] NOT NULL,
	[usuario_creacion] [varchar](50) NOT NULL,
	[fecha_modificacion] [datetime] NULL,
	[usuario_modificacion] [varchar](50) NULL,
 CONSTRAINT [PK_tblCLI_Modulos] PRIMARY KEY CLUSTERED 
(
	[id_modulo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tblCLI_Notificaciones]    Script Date: 17/7/2018 20:19:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblCLI_Notificaciones](
	[id_notificacion] [int] IDENTITY(1,1) NOT NULL,
	[descripcion] [varchar](100) NOT NULL,
 CONSTRAINT [PK_tblCLI_Notificaciones] PRIMARY KEY CLUSTERED 
(
	[id_notificacion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tblCLI_NotificacionesUsuario]    Script Date: 17/7/2018 20:19:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblCLI_NotificacionesUsuario](
	[id_notificacion_usuario] [int] IDENTITY(1,1) NOT NULL,
	[id_notificacion] [int] NOT NULL,
	[activo] [bit] NOT NULL,
	[de_rol] [int] NOT NULL,
	[para_rol] [int] NOT NULL,
	[de_id_usuario] [int] NOT NULL,
	[para_id_usuario] [int] NOT NULL,
	[fecha_creacion] [datetime] NOT NULL,
	[usuario_creacion] [varchar](50) NOT NULL,
	[fecha_modificacion] [datetime] NULL,
	[usuario_modificacion] [varchar](50) NULL,
 CONSTRAINT [tblCLI_NotificacionesUsuario_] PRIMARY KEY CLUSTERED 
(
	[id_notificacion_usuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tblCLI_Pago]    Script Date: 17/7/2018 20:19:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblCLI_Pago](
	[id_pago] [int] NOT NULL,
	[tabulador] [int] IDENTITY(1,1) NOT NULL,
	[tabulador_tab] [int] NOT NULL,
	[empresa] [varchar](10) NOT NULL,
	[concepto_facturacion] [varchar](30) NOT NULL,
	[concepto_autofacturacion] [varchar](30) NOT NULL,
	[tarifa_venta] [varchar](15) NOT NULL,
	[moneda_venta] [varchar](3) NOT NULL,
	[tarifa_compra] [varchar](15) NOT NULL,
	[moneda_compra] [varchar](3) NOT NULL,
 CONSTRAINT [PK_tblCLI_Pago] PRIMARY KEY CLUSTERED 
(
	[id_pago] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tblCLI_Patentes]    Script Date: 17/7/2018 20:19:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblCLI_Patentes](
	[id_patente] [int] NOT NULL,
	[patente] [varchar](4) NOT NULL,
	[nombre] [varchar](100) NOT NULL,
	[direccion] [varchar](200) NULL,
 CONSTRAINT [PK_tblCLI_Patentes] PRIMARY KEY CLUSTERED 
(
	[id_patente] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tblCLI_Preguntas]    Script Date: 17/7/2018 20:19:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblCLI_Preguntas](
	[id_pregunta] [int] IDENTITY(1,1) NOT NULL,
	[pregunta] [varchar](300) NOT NULL,
 CONSTRAINT [PK_tblCLI_Cuestionario] PRIMARY KEY CLUSTERED 
(
	[id_pregunta] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tblCLI_Respuestas]    Script Date: 17/7/2018 20:19:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblCLI_Respuestas](
	[id_respuesta] [int] IDENTITY(1,1) NOT NULL,
	[id_pregunta] [int] NOT NULL,
	[id_precliente] [int] NOT NULL,
	[respuesta] [bit] NOT NULL,
	[observacion] [varchar](100) NOT NULL,
	[fecha_creacion] [datetime] NOT NULL,
	[usuario_creacion] [varchar](50) NOT NULL,
	[fecha_modificacion] [datetime] NULL,
	[usuario_modificacion] [varchar](50) NULL,
 CONSTRAINT [PK_tblCLI_Respuestas] PRIMARY KEY CLUSTERED 
(
	[id_respuesta] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tblCLI_Roles]    Script Date: 17/7/2018 20:19:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblCLI_Roles](
	[id_rol] [int] IDENTITY(1,1) NOT NULL,
	[descripcion] [varchar](100) NOT NULL,
	[fecha_creacion] [datetime] NOT NULL,
	[usuario_creacion] [varchar](50) NOT NULL,
	[fecha_modificacion] [datetime] NULL,
	[usuario_modificacion] [varchar](50) NULL,
 CONSTRAINT [PK_tblCLI_Roles] PRIMARY KEY CLUSTERED 
(
	[id_rol] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tblCLI_RolesEstatus]    Script Date: 17/7/2018 20:19:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblCLI_RolesEstatus](
	[id_rol_estatus] [int] IDENTITY(1,1) NOT NULL,
	[id_rol] [int] NOT NULL,
	[id_estatus] [int] NOT NULL,
	[fecha_creacion] [datetime] NOT NULL,
	[usuario_creacion] [varchar](50) NOT NULL,
	[fecha_modificacion] [datetime] NULL,
	[usuario_modificacion] [varchar](50) NULL,
 CONSTRAINT [PK_tblCLI_RolesEstatus] PRIMARY KEY CLUSTERED 
(
	[id_rol_estatus] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tblCLI_RolesModulos]    Script Date: 17/7/2018 20:19:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblCLI_RolesModulos](
	[id_rol_modulo] [int] IDENTITY(1,1) NOT NULL,
	[id_rol] [int] NOT NULL,
	[id_modulo] [int] NOT NULL,
	[fecha_creacion] [datetime] NOT NULL,
	[usuario_creacion] [varchar](50) NOT NULL,
	[fecha_modificacion] [datetime] NULL,
	[usuario_modificacion] [varchar](50) NULL,
 CONSTRAINT [PK_tblCLI_RolesModulos] PRIMARY KEY CLUSTERED 
(
	[id_rol_modulo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tblCLI_Tab]    Script Date: 17/7/2018 20:19:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblCLI_Tab](
	[id_tabuladores] [int] IDENTITY(1,1) NOT NULL,
	[tabulador] [int] NOT NULL,
	[tipo_operacion] [varchar](20) NOT NULL,
	[aduana] [varchar](20) NOT NULL,
	[clave_pedimiento] [varchar](20) NOT NULL,
	[moneda] [varchar](20) NOT NULL,
	[facturacion] [varchar](40) NOT NULL,
	[dias_libres] [varchar](20) NOT NULL,
	[datos_adicionales] [varchar](200) NOT NULL,
	[metodo_pago] [varchar](20) NOT NULL,
	[dig_cuenta] [int] NOT NULL,
	[instruccion_especial] [varchar](100) NOT NULL,
 CONSTRAINT [PK_tblCLI_Tab] PRIMARY KEY CLUSTERED 
(
	[id_tabuladores] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tblCLI_Tabulador]    Script Date: 17/7/2018 20:19:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblCLI_Tabulador](
	[id_tabulador] [int] IDENTITY(1,1) NOT NULL,
	[usuario] [int] NOT NULL,
	[precliente] [int] NOT NULL,
	[tipo_cliente] [int] NOT NULL,
	[RFC_servicio_sociedad] [varchar](25) NOT NULL,
	[nombre_cliente_alta] [varchar](50) NULL,
	[cliente_pedimiento] [varchar](50) NULL,
	[sitio_ftp_pagWeb] [bit] NOT NULL,
	[direccion_pag_web] [varchar](50) NOT NULL,
	[usuario_pag_web] [varchar](20) NOT NULL,
	[contrasena_pag_web] [varchar](15) NOT NULL,
	[entrega_fisica] [bit] NOT NULL,
	[dias_revision] [varchar](50) NULL,
	[horario_revision] [varchar](15) NULL,
	[personas_rec_facuras] [varchar](60) NULL,
	[no_copia] [varchar](5) NULL,
	[calle_numero] [varchar](60) NULL,
	[colonia] [varchar](15) NULL,
	[id_ciudad] [varchar](20) NULL,
	[id_estado] [varchar](10) NULL,
	[cp] [varchar](20) NULL,
	[estimado_venta] [varchar](15) NOT NULL,
	[fecha_creacion] [datetime] NOT NULL,
	[usuario_creacion] [varchar](50) NOT NULL,
	[fecha_modificacion] [datetime] NULL,
	[usuario_modificacion] [varchar](50) NULL,
 CONSTRAINT [PK_tblCLI_Tabulador] PRIMARY KEY CLUSTERED 
(
	[id_tabulador] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tblCLI_TabuladorCatalogo]    Script Date: 17/7/2018 20:19:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblCLI_TabuladorCatalogo](
	[id_tab_catalogo] [int] IDENTITY(1,1) NOT NULL,
	[tabulador] [int] NOT NULL,
	[concepto] [varchar](25) NOT NULL,
	[cte_pred] [bit] NOT NULL,
	[cte_fact] [bit] NOT NULL,
	[empresa_factura] [int] NOT NULL,
	[cta_ame_factura] [varchar](20) NOT NULL,
	[cta_ame_expedida_a] [int] NOT NULL,
	[cta_ame_expedida_por] [int] NOT NULL,
	[impuesto_peca] [bit] NOT NULL,
 CONSTRAINT [PK_tblCLI_TabuladorCatalogo] PRIMARY KEY CLUSTERED 
(
	[id_tab_catalogo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tblCLI_TarifaVenta]    Script Date: 17/7/2018 20:19:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblCLI_TarifaVenta](
	[id_tarifa] [int] IDENTITY(1,1) NOT NULL,
	[tabulador] [int] NOT NULL,
	[servicio] [varchar](20) NOT NULL,
	[tarifa] [varchar](15) NOT NULL,
	[notas] [varchar](60) NOT NULL,
 CONSTRAINT [PK_tblCLI_TarifaVenta] PRIMARY KEY CLUSTERED 
(
	[id_tarifa] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tblCLI_Usuarios]    Script Date: 17/7/2018 20:19:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblCLI_Usuarios](
	[id_usuario] [int] IDENTITY(1,1) NOT NULL,
	[id_rol] [int] NOT NULL,
	[nombre] [varchar](200) NOT NULL,
	[usuario] [varchar](50) NOT NULL,
	[contrasenia] [varchar](50) NOT NULL,
	[correo] [varchar](50) NOT NULL,
	[fecha_creacion] [datetime] NOT NULL,
	[usuario_creacion] [varchar](50) NOT NULL,
	[fecha_modificacion] [datetime] NULL,
	[usuario_modificacion] [varchar](50) NULL,
	[activo] [bit] NULL,
	[grupo] [varchar](100) NULL,
 CONSTRAINT [PK_tblCLI_Usuarios] PRIMARY KEY CLUSTERED 
(
	[id_usuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tblCLI_UsuariosAduabook]    Script Date: 17/7/2018 20:19:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblCLI_UsuariosAduabook](
	[id_usuario_aduabook] [int] IDENTITY(1,1) NOT NULL,
	[id_precliente] [int] NOT NULL,
	[nombre] [varchar](100) NOT NULL,
	[puesto_departamento] [varchar](30) NOT NULL,
	[telefono] [varchar](20) NOT NULL,
	[correo] [varchar](50) NOT NULL,
	[admon] [varchar](30) NOT NULL,
	[oper] [varchar](30) NOT NULL,
	[fecha_creacion] [datetime] NOT NULL,
	[usuario_creacion] [varchar](50) NOT NULL,
	[fecha_modificacion] [datetime] NULL,
	[usuario_modificacion] [varchar](50) NULL,
 CONSTRAINT [PK_tblCLI_UsuariosAduabook] PRIMARY KEY CLUSTERED 
(
	[id_usuario_aduabook] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[tblCLI_ClienteAprobador] ON 

INSERT [dbo].[tblCLI_ClienteAprobador] ([id_cliente_aprobador], [precliente], [usuario], [observacion], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (1, 1, 1, N'TEST DE OBSERVACIONES 01', CAST(N'2018-07-11T00:39:31.830' AS DateTime), N'Jose', NULL, NULL)
INSERT [dbo].[tblCLI_ClienteAprobador] ([id_cliente_aprobador], [precliente], [usuario], [observacion], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (2, 1, 1, N'observacion cliente', CAST(N'2018-07-11T01:08:45.807' AS DateTime), N'Jose', NULL, NULL)
INSERT [dbo].[tblCLI_ClienteAprobador] ([id_cliente_aprobador], [precliente], [usuario], [observacion], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (3, 1, 1, N'', CAST(N'2018-07-11T01:12:32.983' AS DateTime), N'Jose', NULL, NULL)
INSERT [dbo].[tblCLI_ClienteAprobador] ([id_cliente_aprobador], [precliente], [usuario], [observacion], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (4, 1, 1, N'dd', CAST(N'2018-07-11T12:17:35.810' AS DateTime), N'Jose', NULL, NULL)
INSERT [dbo].[tblCLI_ClienteAprobador] ([id_cliente_aprobador], [precliente], [usuario], [observacion], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (5, 1, 1, N'333', CAST(N'2018-07-11T12:20:47.567' AS DateTime), N'Jose', NULL, NULL)
SET IDENTITY_INSERT [dbo].[tblCLI_ClienteAprobador] OFF
SET IDENTITY_INSERT [dbo].[tblCLI_Clientes] ON 

INSERT [dbo].[tblCLI_Clientes] ([id_precliente], [id_usuario], [id_cliente_aduasis], [id_cliente_gp], [es_cliente], [representante_legal], [nombre_fiscal], [rfc], [nombre_comercial], [calle], [no_ext], [no_int], [colonia], [id_ciudad], [cp], [id_estado], [id_pais], [telefono], [giro], [tiempo_establecido], [numero_empleados], [ventas_anuales], [pagina_web], [patentes_operacion], [frecuencia_embarques], [vucem_cliente], [vucem_grupoei], [correos_arribo_embarque], [banco], [numero_cuenta], [clabe_interbancaria], [moneda], [sucursal_banco], [ciudad_banco], [certificacion1], [certificacion2], [numero_puertos], [con_carta_encomienda_respaldo], [motivo_sin_carta_encomienda_respaldo], [banderilla], [estatus], [aceptacion_terminos_condiciones], [domicilio_fiscal_calle], [domicilio_fiscal_ciudad], [domicilio_fiscal_colonia], [domicilio_fiscal_cp], [domicilio_fiscal_estado], [domicilio_fiscal_municipio], [domicilio_fiscal_no_ext], [domicilio_fiscal_no_int], [numero_escritura], [nombre_notario], [numero_notaria], [ciudad_notariado], [estado_notariado], [membrete_empresa], [periodo_compredido_inicio], [periodo_compredido_fin], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion], [patente_carta_encomienda]) VALUES (1, 2, NULL, NULL, 1, N'Representante', N'SOLUCIONES TI', N'HEMI900914tss', N'SOLUCIONES TI', N'Sandalo', N'213', N'1', N'Patria Nueva', N'TUXT', N'29000', N'07', N'N3', N'7771821872', NULL, NULL, 0, CAST(1 AS Decimal(18, 0)), NULL, NULL, NULL, NULL, NULL, NULL, N'Banco', 879894, 1616516, N'Pesos', N'Sucursal', N'Ciudad', N'', N'', N'', NULL, NULL, 1, 4, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(N'2018-06-29T00:09:12.000' AS DateTime), N'TEST', CAST(N'2018-07-11T12:33:11.587' AS DateTime), N'Jose', NULL)
INSERT [dbo].[tblCLI_Clientes] ([id_precliente], [id_usuario], [id_cliente_aduasis], [id_cliente_gp], [es_cliente], [representante_legal], [nombre_fiscal], [rfc], [nombre_comercial], [calle], [no_ext], [no_int], [colonia], [id_ciudad], [cp], [id_estado], [id_pais], [telefono], [giro], [tiempo_establecido], [numero_empleados], [ventas_anuales], [pagina_web], [patentes_operacion], [frecuencia_embarques], [vucem_cliente], [vucem_grupoei], [correos_arribo_embarque], [banco], [numero_cuenta], [clabe_interbancaria], [moneda], [sucursal_banco], [ciudad_banco], [certificacion1], [certificacion2], [numero_puertos], [con_carta_encomienda_respaldo], [motivo_sin_carta_encomienda_respaldo], [banderilla], [estatus], [aceptacion_terminos_condiciones], [domicilio_fiscal_calle], [domicilio_fiscal_ciudad], [domicilio_fiscal_colonia], [domicilio_fiscal_cp], [domicilio_fiscal_estado], [domicilio_fiscal_municipio], [domicilio_fiscal_no_ext], [domicilio_fiscal_no_int], [numero_escritura], [nombre_notario], [numero_notaria], [ciudad_notariado], [estado_notariado], [membrete_empresa], [periodo_compredido_inicio], [periodo_compredido_fin], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion], [patente_carta_encomienda]) VALUES (2, 1, NULL, NULL, 1, N'representante', N'SOLUCIONES TI2', N'HEMI900914tsstsstss', N'NombreComercial2', N'Sandalo2', N'482', N'562', N'Tuxlta Gutierrez2', N'0925', N'290002', N'19', N'N3', N'122', N'giro12', N'1', 111, CAST(1 AS Decimal(18, 0)), N'google1.com', N'1111', N'11', 1, 0, N'mai1l@noada.com;mail2@google.com', N'Banco', 79798, 213, N'Moneda', N'Sucursal', N'Ciudad', N'', N'NEEC', N'1', 1, N'', 1, 5, 1, N'Sandalo2', N'AGUALEGUAS', N'Tuxlta Gutierrez2', N'290002', N'NUEVO LEON', N'AGUALEGUAS', N'482', N'562', N'1233454654', N'juan luis lopez', N'78', N'villa de alvarez', N'colimassss', N'(Imprimir en membrete de la empresa importadora o ', CAST(N'2018-07-25T00:00:00.000' AS DateTime), CAST(N'2018-07-31T00:00:00.000' AS DateTime), CAST(N'2018-06-29T00:09:12.000' AS DateTime), N'TEST', CAST(N'2018-07-17T09:48:51.313' AS DateTime), N'Test', N'-- S')
INSERT [dbo].[tblCLI_Clientes] ([id_precliente], [id_usuario], [id_cliente_aduasis], [id_cliente_gp], [es_cliente], [representante_legal], [nombre_fiscal], [rfc], [nombre_comercial], [calle], [no_ext], [no_int], [colonia], [id_ciudad], [cp], [id_estado], [id_pais], [telefono], [giro], [tiempo_establecido], [numero_empleados], [ventas_anuales], [pagina_web], [patentes_operacion], [frecuencia_embarques], [vucem_cliente], [vucem_grupoei], [correos_arribo_embarque], [banco], [numero_cuenta], [clabe_interbancaria], [moneda], [sucursal_banco], [ciudad_banco], [certificacion1], [certificacion2], [numero_puertos], [con_carta_encomienda_respaldo], [motivo_sin_carta_encomienda_respaldo], [banderilla], [estatus], [aceptacion_terminos_condiciones], [domicilio_fiscal_calle], [domicilio_fiscal_ciudad], [domicilio_fiscal_colonia], [domicilio_fiscal_cp], [domicilio_fiscal_estado], [domicilio_fiscal_municipio], [domicilio_fiscal_no_ext], [domicilio_fiscal_no_int], [numero_escritura], [nombre_notario], [numero_notaria], [ciudad_notariado], [estado_notariado], [membrete_empresa], [periodo_compredido_inicio], [periodo_compredido_fin], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion], [patente_carta_encomienda]) VALUES (6, 16, NULL, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(N'2018-07-06T11:47:43.283' AS DateTime), N'', NULL, NULL, NULL)
INSERT [dbo].[tblCLI_Clientes] ([id_precliente], [id_usuario], [id_cliente_aduasis], [id_cliente_gp], [es_cliente], [representante_legal], [nombre_fiscal], [rfc], [nombre_comercial], [calle], [no_ext], [no_int], [colonia], [id_ciudad], [cp], [id_estado], [id_pais], [telefono], [giro], [tiempo_establecido], [numero_empleados], [ventas_anuales], [pagina_web], [patentes_operacion], [frecuencia_embarques], [vucem_cliente], [vucem_grupoei], [correos_arribo_embarque], [banco], [numero_cuenta], [clabe_interbancaria], [moneda], [sucursal_banco], [ciudad_banco], [certificacion1], [certificacion2], [numero_puertos], [con_carta_encomienda_respaldo], [motivo_sin_carta_encomienda_respaldo], [banderilla], [estatus], [aceptacion_terminos_condiciones], [domicilio_fiscal_calle], [domicilio_fiscal_ciudad], [domicilio_fiscal_colonia], [domicilio_fiscal_cp], [domicilio_fiscal_estado], [domicilio_fiscal_municipio], [domicilio_fiscal_no_ext], [domicilio_fiscal_no_int], [numero_escritura], [nombre_notario], [numero_notaria], [ciudad_notariado], [estado_notariado], [membrete_empresa], [periodo_compredido_inicio], [periodo_compredido_fin], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion], [patente_carta_encomienda]) VALUES (7, 22, NULL, NULL, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(N'2018-07-06T13:17:05.377' AS DateTime), N'', NULL, NULL, NULL)
INSERT [dbo].[tblCLI_Clientes] ([id_precliente], [id_usuario], [id_cliente_aduasis], [id_cliente_gp], [es_cliente], [representante_legal], [nombre_fiscal], [rfc], [nombre_comercial], [calle], [no_ext], [no_int], [colonia], [id_ciudad], [cp], [id_estado], [id_pais], [telefono], [giro], [tiempo_establecido], [numero_empleados], [ventas_anuales], [pagina_web], [patentes_operacion], [frecuencia_embarques], [vucem_cliente], [vucem_grupoei], [correos_arribo_embarque], [banco], [numero_cuenta], [clabe_interbancaria], [moneda], [sucursal_banco], [ciudad_banco], [certificacion1], [certificacion2], [numero_puertos], [con_carta_encomienda_respaldo], [motivo_sin_carta_encomienda_respaldo], [banderilla], [estatus], [aceptacion_terminos_condiciones], [domicilio_fiscal_calle], [domicilio_fiscal_ciudad], [domicilio_fiscal_colonia], [domicilio_fiscal_cp], [domicilio_fiscal_estado], [domicilio_fiscal_municipio], [domicilio_fiscal_no_ext], [domicilio_fiscal_no_int], [numero_escritura], [nombre_notario], [numero_notaria], [ciudad_notariado], [estado_notariado], [membrete_empresa], [periodo_compredido_inicio], [periodo_compredido_fin], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion], [patente_carta_encomienda]) VALUES (8, 23, NULL, NULL, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(N'2018-07-06T17:25:07.610' AS DateTime), N'', NULL, NULL, NULL)
INSERT [dbo].[tblCLI_Clientes] ([id_precliente], [id_usuario], [id_cliente_aduasis], [id_cliente_gp], [es_cliente], [representante_legal], [nombre_fiscal], [rfc], [nombre_comercial], [calle], [no_ext], [no_int], [colonia], [id_ciudad], [cp], [id_estado], [id_pais], [telefono], [giro], [tiempo_establecido], [numero_empleados], [ventas_anuales], [pagina_web], [patentes_operacion], [frecuencia_embarques], [vucem_cliente], [vucem_grupoei], [correos_arribo_embarque], [banco], [numero_cuenta], [clabe_interbancaria], [moneda], [sucursal_banco], [ciudad_banco], [certificacion1], [certificacion2], [numero_puertos], [con_carta_encomienda_respaldo], [motivo_sin_carta_encomienda_respaldo], [banderilla], [estatus], [aceptacion_terminos_condiciones], [domicilio_fiscal_calle], [domicilio_fiscal_ciudad], [domicilio_fiscal_colonia], [domicilio_fiscal_cp], [domicilio_fiscal_estado], [domicilio_fiscal_municipio], [domicilio_fiscal_no_ext], [domicilio_fiscal_no_int], [numero_escritura], [nombre_notario], [numero_notaria], [ciudad_notariado], [estado_notariado], [membrete_empresa], [periodo_compredido_inicio], [periodo_compredido_fin], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion], [patente_carta_encomienda]) VALUES (9, 35, NULL, NULL, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(N'2018-07-10T12:33:03.913' AS DateTime), N'', NULL, NULL, NULL)
INSERT [dbo].[tblCLI_Clientes] ([id_precliente], [id_usuario], [id_cliente_aduasis], [id_cliente_gp], [es_cliente], [representante_legal], [nombre_fiscal], [rfc], [nombre_comercial], [calle], [no_ext], [no_int], [colonia], [id_ciudad], [cp], [id_estado], [id_pais], [telefono], [giro], [tiempo_establecido], [numero_empleados], [ventas_anuales], [pagina_web], [patentes_operacion], [frecuencia_embarques], [vucem_cliente], [vucem_grupoei], [correos_arribo_embarque], [banco], [numero_cuenta], [clabe_interbancaria], [moneda], [sucursal_banco], [ciudad_banco], [certificacion1], [certificacion2], [numero_puertos], [con_carta_encomienda_respaldo], [motivo_sin_carta_encomienda_respaldo], [banderilla], [estatus], [aceptacion_terminos_condiciones], [domicilio_fiscal_calle], [domicilio_fiscal_ciudad], [domicilio_fiscal_colonia], [domicilio_fiscal_cp], [domicilio_fiscal_estado], [domicilio_fiscal_municipio], [domicilio_fiscal_no_ext], [domicilio_fiscal_no_int], [numero_escritura], [nombre_notario], [numero_notaria], [ciudad_notariado], [estado_notariado], [membrete_empresa], [periodo_compredido_inicio], [periodo_compredido_fin], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion], [patente_carta_encomienda]) VALUES (10, 36, NULL, NULL, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(N'2018-07-10T12:36:33.830' AS DateTime), N'', NULL, NULL, NULL)
INSERT [dbo].[tblCLI_Clientes] ([id_precliente], [id_usuario], [id_cliente_aduasis], [id_cliente_gp], [es_cliente], [representante_legal], [nombre_fiscal], [rfc], [nombre_comercial], [calle], [no_ext], [no_int], [colonia], [id_ciudad], [cp], [id_estado], [id_pais], [telefono], [giro], [tiempo_establecido], [numero_empleados], [ventas_anuales], [pagina_web], [patentes_operacion], [frecuencia_embarques], [vucem_cliente], [vucem_grupoei], [correos_arribo_embarque], [banco], [numero_cuenta], [clabe_interbancaria], [moneda], [sucursal_banco], [ciudad_banco], [certificacion1], [certificacion2], [numero_puertos], [con_carta_encomienda_respaldo], [motivo_sin_carta_encomienda_respaldo], [banderilla], [estatus], [aceptacion_terminos_condiciones], [domicilio_fiscal_calle], [domicilio_fiscal_ciudad], [domicilio_fiscal_colonia], [domicilio_fiscal_cp], [domicilio_fiscal_estado], [domicilio_fiscal_municipio], [domicilio_fiscal_no_ext], [domicilio_fiscal_no_int], [numero_escritura], [nombre_notario], [numero_notaria], [ciudad_notariado], [estado_notariado], [membrete_empresa], [periodo_compredido_inicio], [periodo_compredido_fin], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion], [patente_carta_encomienda]) VALUES (11, 37, NULL, NULL, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(N'2018-07-10T12:47:22.890' AS DateTime), N'', NULL, NULL, NULL)
INSERT [dbo].[tblCLI_Clientes] ([id_precliente], [id_usuario], [id_cliente_aduasis], [id_cliente_gp], [es_cliente], [representante_legal], [nombre_fiscal], [rfc], [nombre_comercial], [calle], [no_ext], [no_int], [colonia], [id_ciudad], [cp], [id_estado], [id_pais], [telefono], [giro], [tiempo_establecido], [numero_empleados], [ventas_anuales], [pagina_web], [patentes_operacion], [frecuencia_embarques], [vucem_cliente], [vucem_grupoei], [correos_arribo_embarque], [banco], [numero_cuenta], [clabe_interbancaria], [moneda], [sucursal_banco], [ciudad_banco], [certificacion1], [certificacion2], [numero_puertos], [con_carta_encomienda_respaldo], [motivo_sin_carta_encomienda_respaldo], [banderilla], [estatus], [aceptacion_terminos_condiciones], [domicilio_fiscal_calle], [domicilio_fiscal_ciudad], [domicilio_fiscal_colonia], [domicilio_fiscal_cp], [domicilio_fiscal_estado], [domicilio_fiscal_municipio], [domicilio_fiscal_no_ext], [domicilio_fiscal_no_int], [numero_escritura], [nombre_notario], [numero_notaria], [ciudad_notariado], [estado_notariado], [membrete_empresa], [periodo_compredido_inicio], [periodo_compredido_fin], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion], [patente_carta_encomienda]) VALUES (12, 38, NULL, NULL, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(N'2018-07-10T20:23:16.840' AS DateTime), N'', NULL, NULL, NULL)
INSERT [dbo].[tblCLI_Clientes] ([id_precliente], [id_usuario], [id_cliente_aduasis], [id_cliente_gp], [es_cliente], [representante_legal], [nombre_fiscal], [rfc], [nombre_comercial], [calle], [no_ext], [no_int], [colonia], [id_ciudad], [cp], [id_estado], [id_pais], [telefono], [giro], [tiempo_establecido], [numero_empleados], [ventas_anuales], [pagina_web], [patentes_operacion], [frecuencia_embarques], [vucem_cliente], [vucem_grupoei], [correos_arribo_embarque], [banco], [numero_cuenta], [clabe_interbancaria], [moneda], [sucursal_banco], [ciudad_banco], [certificacion1], [certificacion2], [numero_puertos], [con_carta_encomienda_respaldo], [motivo_sin_carta_encomienda_respaldo], [banderilla], [estatus], [aceptacion_terminos_condiciones], [domicilio_fiscal_calle], [domicilio_fiscal_ciudad], [domicilio_fiscal_colonia], [domicilio_fiscal_cp], [domicilio_fiscal_estado], [domicilio_fiscal_municipio], [domicilio_fiscal_no_ext], [domicilio_fiscal_no_int], [numero_escritura], [nombre_notario], [numero_notaria], [ciudad_notariado], [estado_notariado], [membrete_empresa], [periodo_compredido_inicio], [periodo_compredido_fin], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion], [patente_carta_encomienda]) VALUES (13, 39, NULL, NULL, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(N'2018-07-10T20:27:43.493' AS DateTime), N'', NULL, NULL, NULL)
INSERT [dbo].[tblCLI_Clientes] ([id_precliente], [id_usuario], [id_cliente_aduasis], [id_cliente_gp], [es_cliente], [representante_legal], [nombre_fiscal], [rfc], [nombre_comercial], [calle], [no_ext], [no_int], [colonia], [id_ciudad], [cp], [id_estado], [id_pais], [telefono], [giro], [tiempo_establecido], [numero_empleados], [ventas_anuales], [pagina_web], [patentes_operacion], [frecuencia_embarques], [vucem_cliente], [vucem_grupoei], [correos_arribo_embarque], [banco], [numero_cuenta], [clabe_interbancaria], [moneda], [sucursal_banco], [ciudad_banco], [certificacion1], [certificacion2], [numero_puertos], [con_carta_encomienda_respaldo], [motivo_sin_carta_encomienda_respaldo], [banderilla], [estatus], [aceptacion_terminos_condiciones], [domicilio_fiscal_calle], [domicilio_fiscal_ciudad], [domicilio_fiscal_colonia], [domicilio_fiscal_cp], [domicilio_fiscal_estado], [domicilio_fiscal_municipio], [domicilio_fiscal_no_ext], [domicilio_fiscal_no_int], [numero_escritura], [nombre_notario], [numero_notaria], [ciudad_notariado], [estado_notariado], [membrete_empresa], [periodo_compredido_inicio], [periodo_compredido_fin], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion], [patente_carta_encomienda]) VALUES (14, 40, NULL, NULL, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(N'2018-07-10T20:29:49.947' AS DateTime), N'', NULL, NULL, NULL)
INSERT [dbo].[tblCLI_Clientes] ([id_precliente], [id_usuario], [id_cliente_aduasis], [id_cliente_gp], [es_cliente], [representante_legal], [nombre_fiscal], [rfc], [nombre_comercial], [calle], [no_ext], [no_int], [colonia], [id_ciudad], [cp], [id_estado], [id_pais], [telefono], [giro], [tiempo_establecido], [numero_empleados], [ventas_anuales], [pagina_web], [patentes_operacion], [frecuencia_embarques], [vucem_cliente], [vucem_grupoei], [correos_arribo_embarque], [banco], [numero_cuenta], [clabe_interbancaria], [moneda], [sucursal_banco], [ciudad_banco], [certificacion1], [certificacion2], [numero_puertos], [con_carta_encomienda_respaldo], [motivo_sin_carta_encomienda_respaldo], [banderilla], [estatus], [aceptacion_terminos_condiciones], [domicilio_fiscal_calle], [domicilio_fiscal_ciudad], [domicilio_fiscal_colonia], [domicilio_fiscal_cp], [domicilio_fiscal_estado], [domicilio_fiscal_municipio], [domicilio_fiscal_no_ext], [domicilio_fiscal_no_int], [numero_escritura], [nombre_notario], [numero_notaria], [ciudad_notariado], [estado_notariado], [membrete_empresa], [periodo_compredido_inicio], [periodo_compredido_fin], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion], [patente_carta_encomienda]) VALUES (15, 41, NULL, NULL, 1, NULL, N'nfiscal', N'tfctss', N'name cmercial', N'nada', N'3', N'3', N'puebla', N'CHO', N'72500', N'21', N'N3', N'58', N'giro prueb EDITw', N'6663', 10, CAST(10 AS Decimal(18, 0)), N'facebook.com.mx', N'55', N'frecuenciua ', 1, 0, N'mail@mail.com', N'banco', 589655, 5655, N'mxp', N'cholula', N'cdx', N'CASCEM', N'BASC', N'12', 1, N'', 1, 1, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(N'2018-07-10T20:39:05.710' AS DateTime), N'', CAST(N'2018-07-10T22:30:03.590' AS DateTime), N'Test', NULL)
INSERT [dbo].[tblCLI_Clientes] ([id_precliente], [id_usuario], [id_cliente_aduasis], [id_cliente_gp], [es_cliente], [representante_legal], [nombre_fiscal], [rfc], [nombre_comercial], [calle], [no_ext], [no_int], [colonia], [id_ciudad], [cp], [id_estado], [id_pais], [telefono], [giro], [tiempo_establecido], [numero_empleados], [ventas_anuales], [pagina_web], [patentes_operacion], [frecuencia_embarques], [vucem_cliente], [vucem_grupoei], [correos_arribo_embarque], [banco], [numero_cuenta], [clabe_interbancaria], [moneda], [sucursal_banco], [ciudad_banco], [certificacion1], [certificacion2], [numero_puertos], [con_carta_encomienda_respaldo], [motivo_sin_carta_encomienda_respaldo], [banderilla], [estatus], [aceptacion_terminos_condiciones], [domicilio_fiscal_calle], [domicilio_fiscal_ciudad], [domicilio_fiscal_colonia], [domicilio_fiscal_cp], [domicilio_fiscal_estado], [domicilio_fiscal_municipio], [domicilio_fiscal_no_ext], [domicilio_fiscal_no_int], [numero_escritura], [nombre_notario], [numero_notaria], [ciudad_notariado], [estado_notariado], [membrete_empresa], [periodo_compredido_inicio], [periodo_compredido_fin], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion], [patente_carta_encomienda]) VALUES (16, 42, NULL, NULL, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(N'2018-07-10T20:40:34.650' AS DateTime), N'', NULL, NULL, NULL)
INSERT [dbo].[tblCLI_Clientes] ([id_precliente], [id_usuario], [id_cliente_aduasis], [id_cliente_gp], [es_cliente], [representante_legal], [nombre_fiscal], [rfc], [nombre_comercial], [calle], [no_ext], [no_int], [colonia], [id_ciudad], [cp], [id_estado], [id_pais], [telefono], [giro], [tiempo_establecido], [numero_empleados], [ventas_anuales], [pagina_web], [patentes_operacion], [frecuencia_embarques], [vucem_cliente], [vucem_grupoei], [correos_arribo_embarque], [banco], [numero_cuenta], [clabe_interbancaria], [moneda], [sucursal_banco], [ciudad_banco], [certificacion1], [certificacion2], [numero_puertos], [con_carta_encomienda_respaldo], [motivo_sin_carta_encomienda_respaldo], [banderilla], [estatus], [aceptacion_terminos_condiciones], [domicilio_fiscal_calle], [domicilio_fiscal_ciudad], [domicilio_fiscal_colonia], [domicilio_fiscal_cp], [domicilio_fiscal_estado], [domicilio_fiscal_municipio], [domicilio_fiscal_no_ext], [domicilio_fiscal_no_int], [numero_escritura], [nombre_notario], [numero_notaria], [ciudad_notariado], [estado_notariado], [membrete_empresa], [periodo_compredido_inicio], [periodo_compredido_fin], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion], [patente_carta_encomienda]) VALUES (17, 44, NULL, NULL, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(N'2018-07-12T10:20:23.870' AS DateTime), N'', NULL, NULL, NULL)
INSERT [dbo].[tblCLI_Clientes] ([id_precliente], [id_usuario], [id_cliente_aduasis], [id_cliente_gp], [es_cliente], [representante_legal], [nombre_fiscal], [rfc], [nombre_comercial], [calle], [no_ext], [no_int], [colonia], [id_ciudad], [cp], [id_estado], [id_pais], [telefono], [giro], [tiempo_establecido], [numero_empleados], [ventas_anuales], [pagina_web], [patentes_operacion], [frecuencia_embarques], [vucem_cliente], [vucem_grupoei], [correos_arribo_embarque], [banco], [numero_cuenta], [clabe_interbancaria], [moneda], [sucursal_banco], [ciudad_banco], [certificacion1], [certificacion2], [numero_puertos], [con_carta_encomienda_respaldo], [motivo_sin_carta_encomienda_respaldo], [banderilla], [estatus], [aceptacion_terminos_condiciones], [domicilio_fiscal_calle], [domicilio_fiscal_ciudad], [domicilio_fiscal_colonia], [domicilio_fiscal_cp], [domicilio_fiscal_estado], [domicilio_fiscal_municipio], [domicilio_fiscal_no_ext], [domicilio_fiscal_no_int], [numero_escritura], [nombre_notario], [numero_notaria], [ciudad_notariado], [estado_notariado], [membrete_empresa], [periodo_compredido_inicio], [periodo_compredido_fin], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion], [patente_carta_encomienda]) VALUES (18, 49, NULL, NULL, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(N'2018-07-12T15:22:34.717' AS DateTime), N'', NULL, NULL, NULL)
INSERT [dbo].[tblCLI_Clientes] ([id_precliente], [id_usuario], [id_cliente_aduasis], [id_cliente_gp], [es_cliente], [representante_legal], [nombre_fiscal], [rfc], [nombre_comercial], [calle], [no_ext], [no_int], [colonia], [id_ciudad], [cp], [id_estado], [id_pais], [telefono], [giro], [tiempo_establecido], [numero_empleados], [ventas_anuales], [pagina_web], [patentes_operacion], [frecuencia_embarques], [vucem_cliente], [vucem_grupoei], [correos_arribo_embarque], [banco], [numero_cuenta], [clabe_interbancaria], [moneda], [sucursal_banco], [ciudad_banco], [certificacion1], [certificacion2], [numero_puertos], [con_carta_encomienda_respaldo], [motivo_sin_carta_encomienda_respaldo], [banderilla], [estatus], [aceptacion_terminos_condiciones], [domicilio_fiscal_calle], [domicilio_fiscal_ciudad], [domicilio_fiscal_colonia], [domicilio_fiscal_cp], [domicilio_fiscal_estado], [domicilio_fiscal_municipio], [domicilio_fiscal_no_ext], [domicilio_fiscal_no_int], [numero_escritura], [nombre_notario], [numero_notaria], [ciudad_notariado], [estado_notariado], [membrete_empresa], [periodo_compredido_inicio], [periodo_compredido_fin], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion], [patente_carta_encomienda]) VALUES (19, 50, NULL, NULL, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0, CAST(0 AS Decimal(18, 0)), NULL, NULL, NULL, 1, 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 1, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(N'2018-07-12T15:42:09.063' AS DateTime), N'', NULL, NULL, NULL)
INSERT [dbo].[tblCLI_Clientes] ([id_precliente], [id_usuario], [id_cliente_aduasis], [id_cliente_gp], [es_cliente], [representante_legal], [nombre_fiscal], [rfc], [nombre_comercial], [calle], [no_ext], [no_int], [colonia], [id_ciudad], [cp], [id_estado], [id_pais], [telefono], [giro], [tiempo_establecido], [numero_empleados], [ventas_anuales], [pagina_web], [patentes_operacion], [frecuencia_embarques], [vucem_cliente], [vucem_grupoei], [correos_arribo_embarque], [banco], [numero_cuenta], [clabe_interbancaria], [moneda], [sucursal_banco], [ciudad_banco], [certificacion1], [certificacion2], [numero_puertos], [con_carta_encomienda_respaldo], [motivo_sin_carta_encomienda_respaldo], [banderilla], [estatus], [aceptacion_terminos_condiciones], [domicilio_fiscal_calle], [domicilio_fiscal_ciudad], [domicilio_fiscal_colonia], [domicilio_fiscal_cp], [domicilio_fiscal_estado], [domicilio_fiscal_municipio], [domicilio_fiscal_no_ext], [domicilio_fiscal_no_int], [numero_escritura], [nombre_notario], [numero_notaria], [ciudad_notariado], [estado_notariado], [membrete_empresa], [periodo_compredido_inicio], [periodo_compredido_fin], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion], [patente_carta_encomienda]) VALUES (20, 51, NULL, NULL, 1, N'eee', N'w', N'w', N'e', N'wewe', N'22', N'22', N'eee', N'1658', N'22', N'21', N'N3', N'33333', N'e', N'e', 3, CAST(3 AS Decimal(18, 0)), N'web', N'2', N'11', 1, 0, N'mail@mail.com', N'b', 33, 22, N'33', N'22', N'11', NULL, NULL, NULL, NULL, NULL, 1, 1, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(N'2018-07-12T16:14:02.567' AS DateTime), N'', CAST(N'2018-07-16T09:27:39.230' AS DateTime), N'Test', NULL)
INSERT [dbo].[tblCLI_Clientes] ([id_precliente], [id_usuario], [id_cliente_aduasis], [id_cliente_gp], [es_cliente], [representante_legal], [nombre_fiscal], [rfc], [nombre_comercial], [calle], [no_ext], [no_int], [colonia], [id_ciudad], [cp], [id_estado], [id_pais], [telefono], [giro], [tiempo_establecido], [numero_empleados], [ventas_anuales], [pagina_web], [patentes_operacion], [frecuencia_embarques], [vucem_cliente], [vucem_grupoei], [correos_arribo_embarque], [banco], [numero_cuenta], [clabe_interbancaria], [moneda], [sucursal_banco], [ciudad_banco], [certificacion1], [certificacion2], [numero_puertos], [con_carta_encomienda_respaldo], [motivo_sin_carta_encomienda_respaldo], [banderilla], [estatus], [aceptacion_terminos_condiciones], [domicilio_fiscal_calle], [domicilio_fiscal_ciudad], [domicilio_fiscal_colonia], [domicilio_fiscal_cp], [domicilio_fiscal_estado], [domicilio_fiscal_municipio], [domicilio_fiscal_no_ext], [domicilio_fiscal_no_int], [numero_escritura], [nombre_notario], [numero_notaria], [ciudad_notariado], [estado_notariado], [membrete_empresa], [periodo_compredido_inicio], [periodo_compredido_fin], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion], [patente_carta_encomienda]) VALUES (21, 61, NULL, NULL, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(N'2018-07-13T00:49:24.520' AS DateTime), N'', NULL, NULL, NULL)
INSERT [dbo].[tblCLI_Clientes] ([id_precliente], [id_usuario], [id_cliente_aduasis], [id_cliente_gp], [es_cliente], [representante_legal], [nombre_fiscal], [rfc], [nombre_comercial], [calle], [no_ext], [no_int], [colonia], [id_ciudad], [cp], [id_estado], [id_pais], [telefono], [giro], [tiempo_establecido], [numero_empleados], [ventas_anuales], [pagina_web], [patentes_operacion], [frecuencia_embarques], [vucem_cliente], [vucem_grupoei], [correos_arribo_embarque], [banco], [numero_cuenta], [clabe_interbancaria], [moneda], [sucursal_banco], [ciudad_banco], [certificacion1], [certificacion2], [numero_puertos], [con_carta_encomienda_respaldo], [motivo_sin_carta_encomienda_respaldo], [banderilla], [estatus], [aceptacion_terminos_condiciones], [domicilio_fiscal_calle], [domicilio_fiscal_ciudad], [domicilio_fiscal_colonia], [domicilio_fiscal_cp], [domicilio_fiscal_estado], [domicilio_fiscal_municipio], [domicilio_fiscal_no_ext], [domicilio_fiscal_no_int], [numero_escritura], [nombre_notario], [numero_notaria], [ciudad_notariado], [estado_notariado], [membrete_empresa], [periodo_compredido_inicio], [periodo_compredido_fin], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion], [patente_carta_encomienda]) VALUES (22, 63, NULL, NULL, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(N'2018-07-13T11:18:49.223' AS DateTime), N'', NULL, NULL, NULL)
INSERT [dbo].[tblCLI_Clientes] ([id_precliente], [id_usuario], [id_cliente_aduasis], [id_cliente_gp], [es_cliente], [representante_legal], [nombre_fiscal], [rfc], [nombre_comercial], [calle], [no_ext], [no_int], [colonia], [id_ciudad], [cp], [id_estado], [id_pais], [telefono], [giro], [tiempo_establecido], [numero_empleados], [ventas_anuales], [pagina_web], [patentes_operacion], [frecuencia_embarques], [vucem_cliente], [vucem_grupoei], [correos_arribo_embarque], [banco], [numero_cuenta], [clabe_interbancaria], [moneda], [sucursal_banco], [ciudad_banco], [certificacion1], [certificacion2], [numero_puertos], [con_carta_encomienda_respaldo], [motivo_sin_carta_encomienda_respaldo], [banderilla], [estatus], [aceptacion_terminos_condiciones], [domicilio_fiscal_calle], [domicilio_fiscal_ciudad], [domicilio_fiscal_colonia], [domicilio_fiscal_cp], [domicilio_fiscal_estado], [domicilio_fiscal_municipio], [domicilio_fiscal_no_ext], [domicilio_fiscal_no_int], [numero_escritura], [nombre_notario], [numero_notaria], [ciudad_notariado], [estado_notariado], [membrete_empresa], [periodo_compredido_inicio], [periodo_compredido_fin], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion], [patente_carta_encomienda]) VALUES (23, 64, NULL, NULL, 1, N'otro2', N'1', N'1', N'1', N'1', N'1', N'1', N'1', N'0962', N'1', N'19', N'N3', N'1', N'1', N'12', 2, CAST(5 AS Decimal(18, 0)), N'www.google.com', N'3438', N'12 ', 1, 0, N'roberto@gmail.com', N'1', 1, 1, N'1', N'1', N'1', NULL, NULL, NULL, NULL, NULL, 1, 1, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(N'2018-07-13T16:18:10.767' AS DateTime), N'', CAST(N'2018-07-16T10:41:42.333' AS DateTime), N'Test', NULL)
INSERT [dbo].[tblCLI_Clientes] ([id_precliente], [id_usuario], [id_cliente_aduasis], [id_cliente_gp], [es_cliente], [representante_legal], [nombre_fiscal], [rfc], [nombre_comercial], [calle], [no_ext], [no_int], [colonia], [id_ciudad], [cp], [id_estado], [id_pais], [telefono], [giro], [tiempo_establecido], [numero_empleados], [ventas_anuales], [pagina_web], [patentes_operacion], [frecuencia_embarques], [vucem_cliente], [vucem_grupoei], [correos_arribo_embarque], [banco], [numero_cuenta], [clabe_interbancaria], [moneda], [sucursal_banco], [ciudad_banco], [certificacion1], [certificacion2], [numero_puertos], [con_carta_encomienda_respaldo], [motivo_sin_carta_encomienda_respaldo], [banderilla], [estatus], [aceptacion_terminos_condiciones], [domicilio_fiscal_calle], [domicilio_fiscal_ciudad], [domicilio_fiscal_colonia], [domicilio_fiscal_cp], [domicilio_fiscal_estado], [domicilio_fiscal_municipio], [domicilio_fiscal_no_ext], [domicilio_fiscal_no_int], [numero_escritura], [nombre_notario], [numero_notaria], [ciudad_notariado], [estado_notariado], [membrete_empresa], [periodo_compredido_inicio], [periodo_compredido_fin], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion], [patente_carta_encomienda]) VALUES (25, 66, NULL, NULL, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 1, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(N'2018-07-14T00:49:10.990' AS DateTime), N'', NULL, NULL, NULL)
INSERT [dbo].[tblCLI_Clientes] ([id_precliente], [id_usuario], [id_cliente_aduasis], [id_cliente_gp], [es_cliente], [representante_legal], [nombre_fiscal], [rfc], [nombre_comercial], [calle], [no_ext], [no_int], [colonia], [id_ciudad], [cp], [id_estado], [id_pais], [telefono], [giro], [tiempo_establecido], [numero_empleados], [ventas_anuales], [pagina_web], [patentes_operacion], [frecuencia_embarques], [vucem_cliente], [vucem_grupoei], [correos_arribo_embarque], [banco], [numero_cuenta], [clabe_interbancaria], [moneda], [sucursal_banco], [ciudad_banco], [certificacion1], [certificacion2], [numero_puertos], [con_carta_encomienda_respaldo], [motivo_sin_carta_encomienda_respaldo], [banderilla], [estatus], [aceptacion_terminos_condiciones], [domicilio_fiscal_calle], [domicilio_fiscal_ciudad], [domicilio_fiscal_colonia], [domicilio_fiscal_cp], [domicilio_fiscal_estado], [domicilio_fiscal_municipio], [domicilio_fiscal_no_ext], [domicilio_fiscal_no_int], [numero_escritura], [nombre_notario], [numero_notaria], [ciudad_notariado], [estado_notariado], [membrete_empresa], [periodo_compredido_inicio], [periodo_compredido_fin], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion], [patente_carta_encomienda]) VALUES (26, 69, NULL, NULL, 1, N'1', N'1', N'11', N'1', N'1', N'1', N'1', N'1', N'0941', N'1', N'19', N'N3', N'1', N'1', N'1', 1, CAST(1 AS Decimal(18, 0)), N'1', N'11', N'1', 0, 1, N'1', N'1', 1, 1, N'1', N'1', N'1', N'C-TPAT', N'BASC', N'15', NULL, NULL, 1, 1, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(N'2018-07-16T10:43:16.123' AS DateTime), N'', CAST(N'2018-07-16T11:10:39.980' AS DateTime), N'Test', NULL)
INSERT [dbo].[tblCLI_Clientes] ([id_precliente], [id_usuario], [id_cliente_aduasis], [id_cliente_gp], [es_cliente], [representante_legal], [nombre_fiscal], [rfc], [nombre_comercial], [calle], [no_ext], [no_int], [colonia], [id_ciudad], [cp], [id_estado], [id_pais], [telefono], [giro], [tiempo_establecido], [numero_empleados], [ventas_anuales], [pagina_web], [patentes_operacion], [frecuencia_embarques], [vucem_cliente], [vucem_grupoei], [correos_arribo_embarque], [banco], [numero_cuenta], [clabe_interbancaria], [moneda], [sucursal_banco], [ciudad_banco], [certificacion1], [certificacion2], [numero_puertos], [con_carta_encomienda_respaldo], [motivo_sin_carta_encomienda_respaldo], [banderilla], [estatus], [aceptacion_terminos_condiciones], [domicilio_fiscal_calle], [domicilio_fiscal_ciudad], [domicilio_fiscal_colonia], [domicilio_fiscal_cp], [domicilio_fiscal_estado], [domicilio_fiscal_municipio], [domicilio_fiscal_no_ext], [domicilio_fiscal_no_int], [numero_escritura], [nombre_notario], [numero_notaria], [ciudad_notariado], [estado_notariado], [membrete_empresa], [periodo_compredido_inicio], [periodo_compredido_fin], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion], [patente_carta_encomienda]) VALUES (27, 70, NULL, NULL, 1, N'OTRO', N'A', N'A', N'A', N'A', N'1', N'1', N'A', N'3597', N'1', N'06', N'N3', N'A', N'1', N'1', 1, CAST(1 AS Decimal(18, 0)), N'1', N'1', N'1', 1, 0, N'1', N'A', 1, 1, N'A', N'A', N'A', N'', N'', N'', NULL, NULL, 1, 1, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(N'2018-07-16T14:03:28.527' AS DateTime), N'', CAST(N'2018-07-16T14:18:03.020' AS DateTime), N'Test', NULL)
INSERT [dbo].[tblCLI_Clientes] ([id_precliente], [id_usuario], [id_cliente_aduasis], [id_cliente_gp], [es_cliente], [representante_legal], [nombre_fiscal], [rfc], [nombre_comercial], [calle], [no_ext], [no_int], [colonia], [id_ciudad], [cp], [id_estado], [id_pais], [telefono], [giro], [tiempo_establecido], [numero_empleados], [ventas_anuales], [pagina_web], [patentes_operacion], [frecuencia_embarques], [vucem_cliente], [vucem_grupoei], [correos_arribo_embarque], [banco], [numero_cuenta], [clabe_interbancaria], [moneda], [sucursal_banco], [ciudad_banco], [certificacion1], [certificacion2], [numero_puertos], [con_carta_encomienda_respaldo], [motivo_sin_carta_encomienda_respaldo], [banderilla], [estatus], [aceptacion_terminos_condiciones], [domicilio_fiscal_calle], [domicilio_fiscal_ciudad], [domicilio_fiscal_colonia], [domicilio_fiscal_cp], [domicilio_fiscal_estado], [domicilio_fiscal_municipio], [domicilio_fiscal_no_ext], [domicilio_fiscal_no_int], [numero_escritura], [nombre_notario], [numero_notaria], [ciudad_notariado], [estado_notariado], [membrete_empresa], [periodo_compredido_inicio], [periodo_compredido_fin], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion], [patente_carta_encomienda]) VALUES (28, 71, NULL, NULL, 1, N'2', N'2', N'2', N'2', N'2', N'2', N'2', N'2', N'0935', N'2', N'19', N'N3', N'2', N'1', N'1', 1, CAST(11 AS Decimal(18, 0)), N'1', N'1', N'1', 1, 0, N'1', N'2', 2, 2, N'2', N'2', N'2', NULL, NULL, NULL, NULL, NULL, 1, 1, 1, N'2', N'CIENEGA DE FLORES', N'2', N'2', N'NUEVO LEON', N'CIENEGA DE FLORES', N'2', N'2', N'1', N'1', N'1', N'1', N'1', N'(Imprimir en membrete de la empresa importadora o ', CAST(N'2018-07-11T00:00:00.000' AS DateTime), CAST(N'2018-07-10T00:00:00.000' AS DateTime), CAST(N'2018-07-16T14:26:47.480' AS DateTime), N'', CAST(N'2018-07-16T14:27:51.357' AS DateTime), N'Test', N'3028')
INSERT [dbo].[tblCLI_Clientes] ([id_precliente], [id_usuario], [id_cliente_aduasis], [id_cliente_gp], [es_cliente], [representante_legal], [nombre_fiscal], [rfc], [nombre_comercial], [calle], [no_ext], [no_int], [colonia], [id_ciudad], [cp], [id_estado], [id_pais], [telefono], [giro], [tiempo_establecido], [numero_empleados], [ventas_anuales], [pagina_web], [patentes_operacion], [frecuencia_embarques], [vucem_cliente], [vucem_grupoei], [correos_arribo_embarque], [banco], [numero_cuenta], [clabe_interbancaria], [moneda], [sucursal_banco], [ciudad_banco], [certificacion1], [certificacion2], [numero_puertos], [con_carta_encomienda_respaldo], [motivo_sin_carta_encomienda_respaldo], [banderilla], [estatus], [aceptacion_terminos_condiciones], [domicilio_fiscal_calle], [domicilio_fiscal_ciudad], [domicilio_fiscal_colonia], [domicilio_fiscal_cp], [domicilio_fiscal_estado], [domicilio_fiscal_municipio], [domicilio_fiscal_no_ext], [domicilio_fiscal_no_int], [numero_escritura], [nombre_notario], [numero_notaria], [ciudad_notariado], [estado_notariado], [membrete_empresa], [periodo_compredido_inicio], [periodo_compredido_fin], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion], [patente_carta_encomienda]) VALUES (29, 73, NULL, NULL, 1, N'rep', N'nom', N'rfc', N'nom com', N'call', N'44', N'22', N'nada', N'1658', N'72590', N'21', N'N3', N'2233112233', N'3', N'3', 3, CAST(3 AS Decimal(18, 0)), N'e', N'44', N'3', 1, 0, N'333@mail.com', N'b', 33, 333, N'm', N'a', N'c', NULL, NULL, NULL, NULL, NULL, 1, 1, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(N'2018-07-16T15:38:20.130' AS DateTime), N'', CAST(N'2018-07-16T15:44:09.440' AS DateTime), N'Test', NULL)
INSERT [dbo].[tblCLI_Clientes] ([id_precliente], [id_usuario], [id_cliente_aduasis], [id_cliente_gp], [es_cliente], [representante_legal], [nombre_fiscal], [rfc], [nombre_comercial], [calle], [no_ext], [no_int], [colonia], [id_ciudad], [cp], [id_estado], [id_pais], [telefono], [giro], [tiempo_establecido], [numero_empleados], [ventas_anuales], [pagina_web], [patentes_operacion], [frecuencia_embarques], [vucem_cliente], [vucem_grupoei], [correos_arribo_embarque], [banco], [numero_cuenta], [clabe_interbancaria], [moneda], [sucursal_banco], [ciudad_banco], [certificacion1], [certificacion2], [numero_puertos], [con_carta_encomienda_respaldo], [motivo_sin_carta_encomienda_respaldo], [banderilla], [estatus], [aceptacion_terminos_condiciones], [domicilio_fiscal_calle], [domicilio_fiscal_ciudad], [domicilio_fiscal_colonia], [domicilio_fiscal_cp], [domicilio_fiscal_estado], [domicilio_fiscal_municipio], [domicilio_fiscal_no_ext], [domicilio_fiscal_no_int], [numero_escritura], [nombre_notario], [numero_notaria], [ciudad_notariado], [estado_notariado], [membrete_empresa], [periodo_compredido_inicio], [periodo_compredido_fin], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion], [patente_carta_encomienda]) VALUES (30, 74, NULL, NULL, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 1, 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(N'2018-07-17T09:19:36.470' AS DateTime), N'', NULL, NULL, NULL)
INSERT [dbo].[tblCLI_Clientes] ([id_precliente], [id_usuario], [id_cliente_aduasis], [id_cliente_gp], [es_cliente], [representante_legal], [nombre_fiscal], [rfc], [nombre_comercial], [calle], [no_ext], [no_int], [colonia], [id_ciudad], [cp], [id_estado], [id_pais], [telefono], [giro], [tiempo_establecido], [numero_empleados], [ventas_anuales], [pagina_web], [patentes_operacion], [frecuencia_embarques], [vucem_cliente], [vucem_grupoei], [correos_arribo_embarque], [banco], [numero_cuenta], [clabe_interbancaria], [moneda], [sucursal_banco], [ciudad_banco], [certificacion1], [certificacion2], [numero_puertos], [con_carta_encomienda_respaldo], [motivo_sin_carta_encomienda_respaldo], [banderilla], [estatus], [aceptacion_terminos_condiciones], [domicilio_fiscal_calle], [domicilio_fiscal_ciudad], [domicilio_fiscal_colonia], [domicilio_fiscal_cp], [domicilio_fiscal_estado], [domicilio_fiscal_municipio], [domicilio_fiscal_no_ext], [domicilio_fiscal_no_int], [numero_escritura], [nombre_notario], [numero_notaria], [ciudad_notariado], [estado_notariado], [membrete_empresa], [periodo_compredido_inicio], [periodo_compredido_fin], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion], [patente_carta_encomienda]) VALUES (31, 75, NULL, NULL, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 1, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(N'2018-07-17T09:51:23.893' AS DateTime), N'', NULL, NULL, NULL)
INSERT [dbo].[tblCLI_Clientes] ([id_precliente], [id_usuario], [id_cliente_aduasis], [id_cliente_gp], [es_cliente], [representante_legal], [nombre_fiscal], [rfc], [nombre_comercial], [calle], [no_ext], [no_int], [colonia], [id_ciudad], [cp], [id_estado], [id_pais], [telefono], [giro], [tiempo_establecido], [numero_empleados], [ventas_anuales], [pagina_web], [patentes_operacion], [frecuencia_embarques], [vucem_cliente], [vucem_grupoei], [correos_arribo_embarque], [banco], [numero_cuenta], [clabe_interbancaria], [moneda], [sucursal_banco], [ciudad_banco], [certificacion1], [certificacion2], [numero_puertos], [con_carta_encomienda_respaldo], [motivo_sin_carta_encomienda_respaldo], [banderilla], [estatus], [aceptacion_terminos_condiciones], [domicilio_fiscal_calle], [domicilio_fiscal_ciudad], [domicilio_fiscal_colonia], [domicilio_fiscal_cp], [domicilio_fiscal_estado], [domicilio_fiscal_municipio], [domicilio_fiscal_no_ext], [domicilio_fiscal_no_int], [numero_escritura], [nombre_notario], [numero_notaria], [ciudad_notariado], [estado_notariado], [membrete_empresa], [periodo_compredido_inicio], [periodo_compredido_fin], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion], [patente_carta_encomienda]) VALUES (32, 76, NULL, NULL, 1, N'Roberto Rentería', N'cas sa de cv', N'CAS55612456', N'TRANSPORTES SA', N'BOSQUES', N'123', N'545', N'VALLE', N'0949', N'671810', N'19', N'N3', N'994451236', N'OTRO', N'1', 1, CAST(1 AS Decimal(18, 0)), N'1', N'1', N'1', 1, 0, N'1', N'BANAMEX', 446, 565, N'56', N'565', N'5', N'', N'', N'', NULL, NULL, 1, 1, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(N'2018-07-17T11:50:33.420' AS DateTime), N'', CAST(N'2018-07-17T12:08:13.130' AS DateTime), N'Test', NULL)
INSERT [dbo].[tblCLI_Clientes] ([id_precliente], [id_usuario], [id_cliente_aduasis], [id_cliente_gp], [es_cliente], [representante_legal], [nombre_fiscal], [rfc], [nombre_comercial], [calle], [no_ext], [no_int], [colonia], [id_ciudad], [cp], [id_estado], [id_pais], [telefono], [giro], [tiempo_establecido], [numero_empleados], [ventas_anuales], [pagina_web], [patentes_operacion], [frecuencia_embarques], [vucem_cliente], [vucem_grupoei], [correos_arribo_embarque], [banco], [numero_cuenta], [clabe_interbancaria], [moneda], [sucursal_banco], [ciudad_banco], [certificacion1], [certificacion2], [numero_puertos], [con_carta_encomienda_respaldo], [motivo_sin_carta_encomienda_respaldo], [banderilla], [estatus], [aceptacion_terminos_condiciones], [domicilio_fiscal_calle], [domicilio_fiscal_ciudad], [domicilio_fiscal_colonia], [domicilio_fiscal_cp], [domicilio_fiscal_estado], [domicilio_fiscal_municipio], [domicilio_fiscal_no_ext], [domicilio_fiscal_no_int], [numero_escritura], [nombre_notario], [numero_notaria], [ciudad_notariado], [estado_notariado], [membrete_empresa], [periodo_compredido_inicio], [periodo_compredido_fin], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion], [patente_carta_encomienda]) VALUES (33, 81, NULL, NULL, 1, N'juan perez', N'1', N'1', N'1', N'1', N'1', N'1', N'1', N'0942', N'1', N'19', N'N3', N'1', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'1', 1, 1, N'1', N'1', N'1', NULL, NULL, NULL, NULL, NULL, 1, 1, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(N'2018-07-17T18:18:53.047' AS DateTime), N'', CAST(N'2018-07-17T18:20:10.167' AS DateTime), N'Test', NULL)
INSERT [dbo].[tblCLI_Clientes] ([id_precliente], [id_usuario], [id_cliente_aduasis], [id_cliente_gp], [es_cliente], [representante_legal], [nombre_fiscal], [rfc], [nombre_comercial], [calle], [no_ext], [no_int], [colonia], [id_ciudad], [cp], [id_estado], [id_pais], [telefono], [giro], [tiempo_establecido], [numero_empleados], [ventas_anuales], [pagina_web], [patentes_operacion], [frecuencia_embarques], [vucem_cliente], [vucem_grupoei], [correos_arribo_embarque], [banco], [numero_cuenta], [clabe_interbancaria], [moneda], [sucursal_banco], [ciudad_banco], [certificacion1], [certificacion2], [numero_puertos], [con_carta_encomienda_respaldo], [motivo_sin_carta_encomienda_respaldo], [banderilla], [estatus], [aceptacion_terminos_condiciones], [domicilio_fiscal_calle], [domicilio_fiscal_ciudad], [domicilio_fiscal_colonia], [domicilio_fiscal_cp], [domicilio_fiscal_estado], [domicilio_fiscal_municipio], [domicilio_fiscal_no_ext], [domicilio_fiscal_no_int], [numero_escritura], [nombre_notario], [numero_notaria], [ciudad_notariado], [estado_notariado], [membrete_empresa], [periodo_compredido_inicio], [periodo_compredido_fin], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion], [patente_carta_encomienda]) VALUES (34, 82, NULL, NULL, 1, N'1', N'1', N'1', N'1', N'1', N'1', N'1', N'1', N'0935', N'1', N'19', N'N3', N'1', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'1', 1, 1, N'1', N'1', N'1', NULL, NULL, NULL, NULL, NULL, 1, 1, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(N'2018-07-17T18:35:24.237' AS DateTime), N'', CAST(N'2018-07-17T18:38:52.567' AS DateTime), N'Test', NULL)
SET IDENTITY_INSERT [dbo].[tblCLI_Clientes] OFF
SET IDENTITY_INSERT [dbo].[tblCLI_Contactos] ON 

INSERT [dbo].[tblCLI_Contactos] ([id_contacto], [id_precliente], [nombre], [correo], [telefono], [area], [puesto_departamento], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (1, 0, N'Nombre', N'Email', N'Telefono', N'Area', N'Puesto', CAST(N'2018-06-30T02:21:34.930' AS DateTime), N'Test', NULL, NULL)
INSERT [dbo].[tblCLI_Contactos] ([id_contacto], [id_precliente], [nombre], [correo], [telefono], [area], [puesto_departamento], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (2, 0, N'Nombre', N'Email', N'Telefono', N'Area', N'Puesto', CAST(N'2018-06-30T02:21:59.823' AS DateTime), N'Test', NULL, NULL)
INSERT [dbo].[tblCLI_Contactos] ([id_contacto], [id_precliente], [nombre], [correo], [telefono], [area], [puesto_departamento], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (3, 1, N'Irving', N'irving@cenidet.edu.mx', N'017772148469', N'area1', N'puesto1', CAST(N'2018-07-01T23:15:23.493' AS DateTime), N'Test', NULL, NULL)
INSERT [dbo].[tblCLI_Contactos] ([id_contacto], [id_precliente], [nombre], [correo], [telefono], [area], [puesto_departamento], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (4, 0, N'Irving', N'irving@cenidet.edu.mx', N'017772148469', N'area1', N'puesto1', CAST(N'2018-07-01T23:16:07.883' AS DateTime), N'Test', NULL, NULL)
INSERT [dbo].[tblCLI_Contactos] ([id_contacto], [id_precliente], [nombre], [correo], [telefono], [area], [puesto_departamento], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (5, 1, N'Nombre', N'Email@test.com', N'878478', N'Area', N'Puesto', CAST(N'2018-07-04T00:42:20.967' AS DateTime), N'Test', NULL, NULL)
INSERT [dbo].[tblCLI_Contactos] ([id_contacto], [id_precliente], [nombre], [correo], [telefono], [area], [puesto_departamento], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (6, 0, N'Nombre', N'Email@test.com', N'878478', N'Area', N'Puesto', CAST(N'2018-07-04T00:44:28.770' AS DateTime), N'Test', NULL, NULL)
INSERT [dbo].[tblCLI_Contactos] ([id_contacto], [id_precliente], [nombre], [correo], [telefono], [area], [puesto_departamento], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (7, 0, N'Nombre', N'Email@test.com', N'878478', N'Area', N'Puesto', CAST(N'2018-07-04T00:44:40.033' AS DateTime), N'Test', NULL, NULL)
INSERT [dbo].[tblCLI_Contactos] ([id_contacto], [id_precliente], [nombre], [correo], [telefono], [area], [puesto_departamento], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (8, 0, N'Nombre', N'Email@test.com', N'878478', N'Area', N'Puesto', CAST(N'2018-07-04T00:49:46.460' AS DateTime), N'Test', NULL, NULL)
INSERT [dbo].[tblCLI_Contactos] ([id_contacto], [id_precliente], [nombre], [correo], [telefono], [area], [puesto_departamento], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (12, 0, N'Nombre', N'Email@test.com', N'878478', N'Area', N'Puesto', CAST(N'2018-07-04T00:56:18.097' AS DateTime), N'Test', NULL, NULL)
INSERT [dbo].[tblCLI_Contactos] ([id_contacto], [id_precliente], [nombre], [correo], [telefono], [area], [puesto_departamento], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (13, 0, N'Nombre', N'Email@test.com', N'87898978', N'Area', N'Puesto', CAST(N'2018-07-04T01:03:28.217' AS DateTime), N'Test', NULL, NULL)
INSERT [dbo].[tblCLI_Contactos] ([id_contacto], [id_precliente], [nombre], [correo], [telefono], [area], [puesto_departamento], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (14, 0, N'Nombre', N'Email@test.com', N'878478', N'Area', N'Puesto', CAST(N'2018-07-10T17:03:32.257' AS DateTime), N'Test', NULL, NULL)
INSERT [dbo].[tblCLI_Contactos] ([id_contacto], [id_precliente], [nombre], [correo], [telefono], [area], [puesto_departamento], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (15, 0, N'Nombre', N'Email@test.com', N'878478', N'Area', N'Puesto', CAST(N'2018-07-10T17:03:32.257' AS DateTime), N'Test', NULL, NULL)
INSERT [dbo].[tblCLI_Contactos] ([id_contacto], [id_precliente], [nombre], [correo], [telefono], [area], [puesto_departamento], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (16, 0, N'Nombre', N'Email@test.com', N'878478', N'Area', N'Puesto', CAST(N'2018-07-10T17:03:32.257' AS DateTime), N'Test', NULL, NULL)
INSERT [dbo].[tblCLI_Contactos] ([id_contacto], [id_precliente], [nombre], [correo], [telefono], [area], [puesto_departamento], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (17, 0, N'Nombre', N'Email@test.com', N'878478', N'Area', N'Puesto', CAST(N'2018-07-10T17:03:57.833' AS DateTime), N'Test', NULL, NULL)
INSERT [dbo].[tblCLI_Contactos] ([id_contacto], [id_precliente], [nombre], [correo], [telefono], [area], [puesto_departamento], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (18, 0, N'Nombre', N'Email@test.com', N'878478', N'Area', N'Puesto', CAST(N'2018-07-10T17:03:57.833' AS DateTime), N'Test', NULL, NULL)
INSERT [dbo].[tblCLI_Contactos] ([id_contacto], [id_precliente], [nombre], [correo], [telefono], [area], [puesto_departamento], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (19, 0, N'Nombre', N'Email@test.com', N'878478', N'Area', N'Puesto', CAST(N'2018-07-10T17:03:57.833' AS DateTime), N'Test', NULL, NULL)
INSERT [dbo].[tblCLI_Contactos] ([id_contacto], [id_precliente], [nombre], [correo], [telefono], [area], [puesto_departamento], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (20, 0, N'Nombre', N'Email@test.com', N'878478', N'Area', N'Puesto', CAST(N'2018-07-10T17:04:08.653' AS DateTime), N'Test', NULL, NULL)
INSERT [dbo].[tblCLI_Contactos] ([id_contacto], [id_precliente], [nombre], [correo], [telefono], [area], [puesto_departamento], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (21, 0, N'Nombre', N'Email@test.com', N'878478', N'Area', N'Puesto', CAST(N'2018-07-10T17:04:08.653' AS DateTime), N'Test', NULL, NULL)
INSERT [dbo].[tblCLI_Contactos] ([id_contacto], [id_precliente], [nombre], [correo], [telefono], [area], [puesto_departamento], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (22, 0, N'Nombre', N'Email@test.com', N'878478', N'Area', N'Puesto', CAST(N'2018-07-10T17:04:08.653' AS DateTime), N'Test', NULL, NULL)
INSERT [dbo].[tblCLI_Contactos] ([id_contacto], [id_precliente], [nombre], [correo], [telefono], [area], [puesto_departamento], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (23, 0, N'Nombre', N'Email@test.com', N'878478', N'Area', N'Puesto', CAST(N'2018-07-10T17:09:27.337' AS DateTime), N'Test', NULL, NULL)
INSERT [dbo].[tblCLI_Contactos] ([id_contacto], [id_precliente], [nombre], [correo], [telefono], [area], [puesto_departamento], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (24, 0, N'Nombre', N'Email@test.com', N'878478', N'Area', N'Puesto', CAST(N'2018-07-10T17:09:27.337' AS DateTime), N'Test', NULL, NULL)
INSERT [dbo].[tblCLI_Contactos] ([id_contacto], [id_precliente], [nombre], [correo], [telefono], [area], [puesto_departamento], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (25, 0, N'Nombre', N'Email@test.com', N'878478', N'Area', N'Puesto', CAST(N'2018-07-10T17:09:27.337' AS DateTime), N'Test', NULL, NULL)
INSERT [dbo].[tblCLI_Contactos] ([id_contacto], [id_precliente], [nombre], [correo], [telefono], [area], [puesto_departamento], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (26, 0, N'n', N'e@mail.com', N'556698', N'area', N'dpto', CAST(N'2018-07-10T22:30:03.590' AS DateTime), N'Test', NULL, NULL)
INSERT [dbo].[tblCLI_Contactos] ([id_contacto], [id_precliente], [nombre], [correo], [telefono], [area], [puesto_departamento], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (27, 0, N'Nombre', N'Email@test.com', N'878478', N'Area', N'Puesto', CAST(N'2018-07-13T22:51:18.313' AS DateTime), N'Test', NULL, NULL)
INSERT [dbo].[tblCLI_Contactos] ([id_contacto], [id_precliente], [nombre], [correo], [telefono], [area], [puesto_departamento], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (28, 0, N'Nombre', N'Email@test.com', N'878478', N'Area', N'Puesto', CAST(N'2018-07-13T22:51:18.313' AS DateTime), N'Test', NULL, NULL)
INSERT [dbo].[tblCLI_Contactos] ([id_contacto], [id_precliente], [nombre], [correo], [telefono], [area], [puesto_departamento], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (29, 0, N'Nombre', N'Email@test.com', N'878478', N'Area', N'Puesto', CAST(N'2018-07-13T22:51:18.313' AS DateTime), N'Test', NULL, NULL)
INSERT [dbo].[tblCLI_Contactos] ([id_contacto], [id_precliente], [nombre], [correo], [telefono], [area], [puesto_departamento], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (30, 0, N'Nombre', N'Email@test.com', N'878478', N'Area', N'Puesto', CAST(N'2018-07-13T23:10:29.093' AS DateTime), N'Test', NULL, NULL)
INSERT [dbo].[tblCLI_Contactos] ([id_contacto], [id_precliente], [nombre], [correo], [telefono], [area], [puesto_departamento], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (31, 0, N'Nombre', N'Email@test.com', N'878478', N'Area', N'Puesto', CAST(N'2018-07-13T23:10:29.093' AS DateTime), N'Test', NULL, NULL)
INSERT [dbo].[tblCLI_Contactos] ([id_contacto], [id_precliente], [nombre], [correo], [telefono], [area], [puesto_departamento], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (32, 0, N'Nombre', N'Email@test.com', N'878478', N'Area', N'Puesto', CAST(N'2018-07-13T23:10:29.093' AS DateTime), N'Test', NULL, NULL)
INSERT [dbo].[tblCLI_Contactos] ([id_contacto], [id_precliente], [nombre], [correo], [telefono], [area], [puesto_departamento], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (33, 0, N'Nombre', N'Email@test.com', N'878478', N'Area', N'Puesto', CAST(N'2018-07-14T00:02:04.653' AS DateTime), N'Test', NULL, NULL)
INSERT [dbo].[tblCLI_Contactos] ([id_contacto], [id_precliente], [nombre], [correo], [telefono], [area], [puesto_departamento], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (34, 0, N'Nombre', N'Email@test.com', N'878478', N'Area', N'Puesto', CAST(N'2018-07-14T00:02:04.653' AS DateTime), N'Test', NULL, NULL)
INSERT [dbo].[tblCLI_Contactos] ([id_contacto], [id_precliente], [nombre], [correo], [telefono], [area], [puesto_departamento], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (35, 0, N'Nombre', N'Email@test.com', N'878478', N'Area', N'Puesto', CAST(N'2018-07-14T00:02:04.653' AS DateTime), N'Test', NULL, NULL)
INSERT [dbo].[tblCLI_Contactos] ([id_contacto], [id_precliente], [nombre], [correo], [telefono], [area], [puesto_departamento], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (36, 0, N'Nombre', N'Email@test.com', N'878478', N'Area', N'Puesto', CAST(N'2018-07-14T00:21:17.140' AS DateTime), N'Test', NULL, NULL)
INSERT [dbo].[tblCLI_Contactos] ([id_contacto], [id_precliente], [nombre], [correo], [telefono], [area], [puesto_departamento], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (37, 0, N'Nombre', N'Email@test.com', N'878478', N'Area', N'Puesto', CAST(N'2018-07-14T00:21:17.140' AS DateTime), N'Test', NULL, NULL)
INSERT [dbo].[tblCLI_Contactos] ([id_contacto], [id_precliente], [nombre], [correo], [telefono], [area], [puesto_departamento], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (38, 0, N'Nombre', N'Email@test.com', N'878478', N'Area', N'Puesto', CAST(N'2018-07-14T00:21:17.140' AS DateTime), N'Test', NULL, NULL)
INSERT [dbo].[tblCLI_Contactos] ([id_contacto], [id_precliente], [nombre], [correo], [telefono], [area], [puesto_departamento], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (39, 0, N'Nombre', N'Email@test.com', N'878478', N'Area', N'Puesto', CAST(N'2018-07-14T00:22:57.947' AS DateTime), N'Test', NULL, NULL)
INSERT [dbo].[tblCLI_Contactos] ([id_contacto], [id_precliente], [nombre], [correo], [telefono], [area], [puesto_departamento], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (40, 0, N'Nombre', N'Email@test.com', N'878478', N'Area', N'Puesto', CAST(N'2018-07-14T00:22:57.947' AS DateTime), N'Test', NULL, NULL)
INSERT [dbo].[tblCLI_Contactos] ([id_contacto], [id_precliente], [nombre], [correo], [telefono], [area], [puesto_departamento], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (41, 0, N'Nombre', N'Email@test.com', N'878478', N'Area', N'Puesto', CAST(N'2018-07-14T00:22:57.947' AS DateTime), N'Test', NULL, NULL)
INSERT [dbo].[tblCLI_Contactos] ([id_contacto], [id_precliente], [nombre], [correo], [telefono], [area], [puesto_departamento], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (42, 0, N'Nombre', N'Email@test.com', N'878478', N'Area', N'Puesto', CAST(N'2018-07-14T00:23:39.187' AS DateTime), N'Test', NULL, NULL)
INSERT [dbo].[tblCLI_Contactos] ([id_contacto], [id_precliente], [nombre], [correo], [telefono], [area], [puesto_departamento], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (43, 0, N'Nombre', N'Email@test.com', N'878478', N'Area', N'Puesto', CAST(N'2018-07-14T00:23:39.187' AS DateTime), N'Test', NULL, NULL)
INSERT [dbo].[tblCLI_Contactos] ([id_contacto], [id_precliente], [nombre], [correo], [telefono], [area], [puesto_departamento], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (44, 0, N'Nombre', N'Email@test.com', N'878478', N'Area', N'Puesto', CAST(N'2018-07-14T00:23:39.187' AS DateTime), N'Test', NULL, NULL)
INSERT [dbo].[tblCLI_Contactos] ([id_contacto], [id_precliente], [nombre], [correo], [telefono], [area], [puesto_departamento], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (45, 0, N'Nombre', N'Email@test.com', N'878478', N'Area', N'Puesto', CAST(N'2018-07-14T01:20:08.937' AS DateTime), N'Test', NULL, NULL)
INSERT [dbo].[tblCLI_Contactos] ([id_contacto], [id_precliente], [nombre], [correo], [telefono], [area], [puesto_departamento], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (46, 0, N'Nombre', N'Email@test.com', N'878478', N'Area', N'Puesto', CAST(N'2018-07-14T01:20:08.937' AS DateTime), N'Test', NULL, NULL)
INSERT [dbo].[tblCLI_Contactos] ([id_contacto], [id_precliente], [nombre], [correo], [telefono], [area], [puesto_departamento], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (47, 0, N'Nombre', N'Email@test.com', N'878478', N'Area', N'Puesto', CAST(N'2018-07-14T01:20:08.937' AS DateTime), N'Test', NULL, NULL)
INSERT [dbo].[tblCLI_Contactos] ([id_contacto], [id_precliente], [nombre], [correo], [telefono], [area], [puesto_departamento], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (48, 0, N'Nombre', N'Email@test.com', N'878478', N'Area', N'Puesto', CAST(N'2018-07-14T01:27:43.947' AS DateTime), N'Test', NULL, NULL)
INSERT [dbo].[tblCLI_Contactos] ([id_contacto], [id_precliente], [nombre], [correo], [telefono], [area], [puesto_departamento], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (49, 0, N'Nombre', N'Email@test.com', N'878478', N'Area', N'Puesto', CAST(N'2018-07-14T01:27:43.947' AS DateTime), N'Test', NULL, NULL)
INSERT [dbo].[tblCLI_Contactos] ([id_contacto], [id_precliente], [nombre], [correo], [telefono], [area], [puesto_departamento], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (50, 0, N'Nombre', N'Email@test.com', N'878478', N'Area', N'Puesto', CAST(N'2018-07-14T01:27:43.947' AS DateTime), N'Test', NULL, NULL)
INSERT [dbo].[tblCLI_Contactos] ([id_contacto], [id_precliente], [nombre], [correo], [telefono], [area], [puesto_departamento], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (51, 0, N'Nombre', N'Email@test.com', N'878478', N'Area', N'Puesto', CAST(N'2018-07-14T01:31:15.730' AS DateTime), N'Test', NULL, NULL)
INSERT [dbo].[tblCLI_Contactos] ([id_contacto], [id_precliente], [nombre], [correo], [telefono], [area], [puesto_departamento], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (52, 0, N'Nombre', N'Email@test.com', N'878478', N'Area', N'Puesto', CAST(N'2018-07-14T01:31:15.730' AS DateTime), N'Test', NULL, NULL)
INSERT [dbo].[tblCLI_Contactos] ([id_contacto], [id_precliente], [nombre], [correo], [telefono], [area], [puesto_departamento], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (53, 0, N'Nombre', N'Email@test.com', N'878478', N'Area', N'Puesto', CAST(N'2018-07-14T01:31:15.730' AS DateTime), N'Test', NULL, NULL)
INSERT [dbo].[tblCLI_Contactos] ([id_contacto], [id_precliente], [nombre], [correo], [telefono], [area], [puesto_departamento], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (54, 0, N'Nombre', N'Email@test.com', N'878478', N'Area', N'Puesto', CAST(N'2018-07-14T01:33:11.910' AS DateTime), N'Test', NULL, NULL)
INSERT [dbo].[tblCLI_Contactos] ([id_contacto], [id_precliente], [nombre], [correo], [telefono], [area], [puesto_departamento], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (55, 0, N'Nombre', N'Email@test.com', N'878478', N'Area', N'Puesto', CAST(N'2018-07-14T01:33:11.910' AS DateTime), N'Test', NULL, NULL)
INSERT [dbo].[tblCLI_Contactos] ([id_contacto], [id_precliente], [nombre], [correo], [telefono], [area], [puesto_departamento], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (56, 0, N'Nombre', N'Email@test.com', N'878478', N'Area', N'Puesto', CAST(N'2018-07-14T01:33:11.910' AS DateTime), N'Test', NULL, NULL)
INSERT [dbo].[tblCLI_Contactos] ([id_contacto], [id_precliente], [nombre], [correo], [telefono], [area], [puesto_departamento], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (57, 0, N'Nombre', N'Email@test.com', N'878478', N'Area', N'Puesto', CAST(N'2018-07-14T01:33:14.083' AS DateTime), N'Test', NULL, NULL)
INSERT [dbo].[tblCLI_Contactos] ([id_contacto], [id_precliente], [nombre], [correo], [telefono], [area], [puesto_departamento], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (58, 0, N'Nombre', N'Email@test.com', N'878478', N'Area', N'Puesto', CAST(N'2018-07-14T01:33:14.083' AS DateTime), N'Test', NULL, NULL)
INSERT [dbo].[tblCLI_Contactos] ([id_contacto], [id_precliente], [nombre], [correo], [telefono], [area], [puesto_departamento], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (59, 0, N'Nombre', N'Email@test.com', N'878478', N'Area', N'Puesto', CAST(N'2018-07-14T01:33:14.083' AS DateTime), N'Test', NULL, NULL)
INSERT [dbo].[tblCLI_Contactos] ([id_contacto], [id_precliente], [nombre], [correo], [telefono], [area], [puesto_departamento], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (60, 0, N'Nombre', N'Email@test.com', N'878478', N'Area', N'Puesto', CAST(N'2018-07-14T01:35:20.540' AS DateTime), N'Test', NULL, NULL)
INSERT [dbo].[tblCLI_Contactos] ([id_contacto], [id_precliente], [nombre], [correo], [telefono], [area], [puesto_departamento], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (61, 0, N'Nombre', N'Email@test.com', N'878478', N'Area', N'Puesto', CAST(N'2018-07-14T01:35:20.540' AS DateTime), N'Test', NULL, NULL)
INSERT [dbo].[tblCLI_Contactos] ([id_contacto], [id_precliente], [nombre], [correo], [telefono], [area], [puesto_departamento], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (62, 0, N'Nombre', N'Email@test.com', N'878478', N'Area', N'Puesto', CAST(N'2018-07-14T01:35:20.540' AS DateTime), N'Test', NULL, NULL)
INSERT [dbo].[tblCLI_Contactos] ([id_contacto], [id_precliente], [nombre], [correo], [telefono], [area], [puesto_departamento], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (63, 0, N'Nombre', N'Email@test.com', N'878478', N'Area', N'Puesto', CAST(N'2018-07-14T01:35:30.760' AS DateTime), N'Test', NULL, NULL)
INSERT [dbo].[tblCLI_Contactos] ([id_contacto], [id_precliente], [nombre], [correo], [telefono], [area], [puesto_departamento], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (64, 0, N'Nombre', N'Email@test.com', N'878478', N'Area', N'Puesto', CAST(N'2018-07-14T01:35:30.760' AS DateTime), N'Test', NULL, NULL)
INSERT [dbo].[tblCLI_Contactos] ([id_contacto], [id_precliente], [nombre], [correo], [telefono], [area], [puesto_departamento], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (65, 0, N'Nombre', N'Email@test.com', N'878478', N'Area', N'Puesto', CAST(N'2018-07-14T01:35:30.760' AS DateTime), N'Test', NULL, NULL)
INSERT [dbo].[tblCLI_Contactos] ([id_contacto], [id_precliente], [nombre], [correo], [telefono], [area], [puesto_departamento], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (66, 0, N'Nombre', N'Email@test.com', N'878478', N'Area', N'Puesto', CAST(N'2018-07-14T01:35:31.563' AS DateTime), N'Test', NULL, NULL)
INSERT [dbo].[tblCLI_Contactos] ([id_contacto], [id_precliente], [nombre], [correo], [telefono], [area], [puesto_departamento], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (67, 0, N'Nombre', N'Email@test.com', N'878478', N'Area', N'Puesto', CAST(N'2018-07-14T01:35:31.563' AS DateTime), N'Test', NULL, NULL)
INSERT [dbo].[tblCLI_Contactos] ([id_contacto], [id_precliente], [nombre], [correo], [telefono], [area], [puesto_departamento], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (68, 0, N'Nombre', N'Email@test.com', N'878478', N'Area', N'Puesto', CAST(N'2018-07-14T01:35:31.563' AS DateTime), N'Test', NULL, NULL)
INSERT [dbo].[tblCLI_Contactos] ([id_contacto], [id_precliente], [nombre], [correo], [telefono], [area], [puesto_departamento], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (69, 0, N'Nombre', N'Email@test.com', N'878478', N'Area', N'Puesto', CAST(N'2018-07-14T01:50:26.550' AS DateTime), N'Test', NULL, NULL)
INSERT [dbo].[tblCLI_Contactos] ([id_contacto], [id_precliente], [nombre], [correo], [telefono], [area], [puesto_departamento], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (70, 0, N'Nombre', N'Email@test.com', N'878478', N'Area', N'Puesto', CAST(N'2018-07-14T01:50:26.550' AS DateTime), N'Test', NULL, NULL)
INSERT [dbo].[tblCLI_Contactos] ([id_contacto], [id_precliente], [nombre], [correo], [telefono], [area], [puesto_departamento], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (71, 0, N'Nombre', N'Email@test.com', N'878478', N'Area', N'Puesto', CAST(N'2018-07-14T01:50:26.550' AS DateTime), N'Test', NULL, NULL)
INSERT [dbo].[tblCLI_Contactos] ([id_contacto], [id_precliente], [nombre], [correo], [telefono], [area], [puesto_departamento], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (72, 0, N'Nombre', N'Email@test.com', N'878478', N'Area', N'Puesto', CAST(N'2018-07-14T01:58:19.220' AS DateTime), N'Test', NULL, NULL)
INSERT [dbo].[tblCLI_Contactos] ([id_contacto], [id_precliente], [nombre], [correo], [telefono], [area], [puesto_departamento], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (73, 0, N'Nombre', N'Email@test.com', N'878478', N'Area', N'Puesto', CAST(N'2018-07-14T01:58:19.220' AS DateTime), N'Test', NULL, NULL)
INSERT [dbo].[tblCLI_Contactos] ([id_contacto], [id_precliente], [nombre], [correo], [telefono], [area], [puesto_departamento], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (74, 0, N'Nombre', N'Email@test.com', N'878478', N'Area', N'Puesto', CAST(N'2018-07-14T01:58:19.220' AS DateTime), N'Test', NULL, NULL)
INSERT [dbo].[tblCLI_Contactos] ([id_contacto], [id_precliente], [nombre], [correo], [telefono], [area], [puesto_departamento], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (75, 0, N'Nombre', N'Email@test.com', N'878478', N'Area', N'Puesto', CAST(N'2018-07-14T01:58:38.480' AS DateTime), N'Test', NULL, NULL)
INSERT [dbo].[tblCLI_Contactos] ([id_contacto], [id_precliente], [nombre], [correo], [telefono], [area], [puesto_departamento], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (76, 0, N'Nombre', N'Email@test.com', N'878478', N'Area', N'Puesto', CAST(N'2018-07-14T01:58:38.480' AS DateTime), N'Test', NULL, NULL)
INSERT [dbo].[tblCLI_Contactos] ([id_contacto], [id_precliente], [nombre], [correo], [telefono], [area], [puesto_departamento], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (77, 0, N'Nombre', N'Email@test.com', N'878478', N'Area', N'Puesto', CAST(N'2018-07-14T01:58:38.480' AS DateTime), N'Test', NULL, NULL)
INSERT [dbo].[tblCLI_Contactos] ([id_contacto], [id_precliente], [nombre], [correo], [telefono], [area], [puesto_departamento], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (117, 20, N'w', N'e', N'r', N'w', N'w', CAST(N'2018-07-16T09:27:39.230' AS DateTime), N'Test', NULL, NULL)
INSERT [dbo].[tblCLI_Contactos] ([id_contacto], [id_precliente], [nombre], [correo], [telefono], [area], [puesto_departamento], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (122, 23, N'11', N'1', N'1', N'1', N'1', CAST(N'2018-07-16T10:41:42.333' AS DateTime), N'Test', NULL, NULL)
INSERT [dbo].[tblCLI_Contactos] ([id_contacto], [id_precliente], [nombre], [correo], [telefono], [area], [puesto_departamento], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (126, 26, N'1', N'11', N'1', N'1', N'1', CAST(N'2018-07-16T11:10:39.980' AS DateTime), N'Test', NULL, NULL)
INSERT [dbo].[tblCLI_Contactos] ([id_contacto], [id_precliente], [nombre], [correo], [telefono], [area], [puesto_departamento], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (129, 27, N'1', N'1', N'1', N'1', N'1', CAST(N'2018-07-16T14:18:03.020' AS DateTime), N'Test', NULL, NULL)
INSERT [dbo].[tblCLI_Contactos] ([id_contacto], [id_precliente], [nombre], [correo], [telefono], [area], [puesto_departamento], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (130, 28, N'2', N'2', N'2', N'2', N'2', CAST(N'2018-07-16T14:27:51.357' AS DateTime), N'Test', NULL, NULL)
INSERT [dbo].[tblCLI_Contactos] ([id_contacto], [id_precliente], [nombre], [correo], [telefono], [area], [puesto_departamento], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (132, 29, N'n', N'w', N't', N'a', N'p', CAST(N'2018-07-16T15:44:09.440' AS DateTime), N'Test', NULL, NULL)
INSERT [dbo].[tblCLI_Contactos] ([id_contacto], [id_precliente], [nombre], [correo], [telefono], [area], [puesto_departamento], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (133, 2, N'Nombre', N'Email@test.com', N'878478', N'Area', N'Puesto', CAST(N'2018-07-17T09:48:51.313' AS DateTime), N'Test', NULL, NULL)
INSERT [dbo].[tblCLI_Contactos] ([id_contacto], [id_precliente], [nombre], [correo], [telefono], [area], [puesto_departamento], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (136, 32, N'JUAN', N'1@gmail.com', N'887459', N'COMPRAS', N'JEFE', CAST(N'2018-07-17T12:08:13.130' AS DateTime), N'Test', NULL, NULL)
INSERT [dbo].[tblCLI_Contactos] ([id_contacto], [id_precliente], [nombre], [correo], [telefono], [area], [puesto_departamento], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (137, 33, N'1', N'1', N'1', N'1', N'1', CAST(N'2018-07-17T18:20:10.167' AS DateTime), N'Test', NULL, NULL)
INSERT [dbo].[tblCLI_Contactos] ([id_contacto], [id_precliente], [nombre], [correo], [telefono], [area], [puesto_departamento], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (138, 34, N'1', N'1', N'1', N'1', N'1', CAST(N'2018-07-17T18:38:52.567' AS DateTime), N'Test', NULL, NULL)
SET IDENTITY_INSERT [dbo].[tblCLI_Contactos] OFF
SET IDENTITY_INSERT [dbo].[tblCLI_CuentasBancariasPECA] ON 

INSERT [dbo].[tblCLI_CuentasBancariasPECA] ([id_banco], [id_precliente], [banco], [numero_cuenta], [identificador], [patentes_autorizadas], [aduana], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (1, 0, N'Banco', 9797, N'Indentificador', N'Patente', N'Aduana', CAST(N'2018-06-30T02:21:34.930' AS DateTime), N'Test', NULL, NULL)
INSERT [dbo].[tblCLI_CuentasBancariasPECA] ([id_banco], [id_precliente], [banco], [numero_cuenta], [identificador], [patentes_autorizadas], [aduana], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (2, 0, N'Banco', 9797, N'Indentificador', N'Patente', N'Aduana', CAST(N'2018-06-30T02:21:59.823' AS DateTime), N'Test', NULL, NULL)
INSERT [dbo].[tblCLI_CuentasBancariasPECA] ([id_banco], [id_precliente], [banco], [numero_cuenta], [identificador], [patentes_autorizadas], [aduana], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (3, 0, N'Banco', 79879, N'Identificador', N'Patente', N'Aduana', CAST(N'2018-06-30T02:25:42.370' AS DateTime), N'Test', NULL, NULL)
INSERT [dbo].[tblCLI_CuentasBancariasPECA] ([id_banco], [id_precliente], [banco], [numero_cuenta], [identificador], [patentes_autorizadas], [aduana], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (4, 0, N'bancox', 123456, N'b1', N'56', N'90', CAST(N'2018-07-01T23:15:23.493' AS DateTime), N'Test', NULL, NULL)
INSERT [dbo].[tblCLI_CuentasBancariasPECA] ([id_banco], [id_precliente], [banco], [numero_cuenta], [identificador], [patentes_autorizadas], [aduana], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (5, 0, N'bancox', 123456, N'b1', N'56', N'90', CAST(N'2018-07-01T23:16:07.883' AS DateTime), N'Test', NULL, NULL)
INSERT [dbo].[tblCLI_CuentasBancariasPECA] ([id_banco], [id_precliente], [banco], [numero_cuenta], [identificador], [patentes_autorizadas], [aduana], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (6, 0, N'Bancomer', 8787998, N'Identificador', N'Patente', N'Aduana', CAST(N'2018-07-04T00:42:20.967' AS DateTime), N'Test', NULL, NULL)
INSERT [dbo].[tblCLI_CuentasBancariasPECA] ([id_banco], [id_precliente], [banco], [numero_cuenta], [identificador], [patentes_autorizadas], [aduana], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (7, 0, N'Bancomer', 8787998, N'Identificador', N'Patente', N'Aduana', CAST(N'2018-07-04T00:44:28.770' AS DateTime), N'Test', NULL, NULL)
INSERT [dbo].[tblCLI_CuentasBancariasPECA] ([id_banco], [id_precliente], [banco], [numero_cuenta], [identificador], [patentes_autorizadas], [aduana], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (8, 0, N'Bancomer', 8787998, N'Identificador', N'Patente', N'Aduana', CAST(N'2018-07-04T00:44:40.033' AS DateTime), N'Test', NULL, NULL)
INSERT [dbo].[tblCLI_CuentasBancariasPECA] ([id_banco], [id_precliente], [banco], [numero_cuenta], [identificador], [patentes_autorizadas], [aduana], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (9, 0, N'Bancomer', 8787998, N'Identificador', N'Patente', N'Aduana', CAST(N'2018-07-04T00:49:46.460' AS DateTime), N'Test', NULL, NULL)
INSERT [dbo].[tblCLI_CuentasBancariasPECA] ([id_banco], [id_precliente], [banco], [numero_cuenta], [identificador], [patentes_autorizadas], [aduana], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (13, 0, N'Bancomer', 8787998, N'Identificador', N'Patente', N'Aduana', CAST(N'2018-07-04T00:56:18.097' AS DateTime), N'Test', NULL, NULL)
INSERT [dbo].[tblCLI_CuentasBancariasPECA] ([id_banco], [id_precliente], [banco], [numero_cuenta], [identificador], [patentes_autorizadas], [aduana], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (14, 0, N'Banco', 654944, N'Identificador', N'patente', N'Aduana', CAST(N'2018-07-04T01:03:28.217' AS DateTime), N'Test', NULL, NULL)
INSERT [dbo].[tblCLI_CuentasBancariasPECA] ([id_banco], [id_precliente], [banco], [numero_cuenta], [identificador], [patentes_autorizadas], [aduana], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (16, 0, N'Bancomer', 8787998, N'Identificador', N'Patente', N'Aduana', CAST(N'2018-07-10T17:03:32.257' AS DateTime), N'Test', NULL, NULL)
INSERT [dbo].[tblCLI_CuentasBancariasPECA] ([id_banco], [id_precliente], [banco], [numero_cuenta], [identificador], [patentes_autorizadas], [aduana], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (17, 0, N'Bancomer', 8787998, N'Identificador', N'Patente', N'Aduana', CAST(N'2018-07-10T17:03:32.257' AS DateTime), N'Test', NULL, NULL)
INSERT [dbo].[tblCLI_CuentasBancariasPECA] ([id_banco], [id_precliente], [banco], [numero_cuenta], [identificador], [patentes_autorizadas], [aduana], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (18, 0, N'Bancomer', 8787998, N'Identificador', N'Patente', N'Aduana', CAST(N'2018-07-10T17:03:32.257' AS DateTime), N'Test', NULL, NULL)
INSERT [dbo].[tblCLI_CuentasBancariasPECA] ([id_banco], [id_precliente], [banco], [numero_cuenta], [identificador], [patentes_autorizadas], [aduana], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (19, 0, N'Bancomer', 6548498, N'Identificador', N'Patente', N'Aduana', CAST(N'2018-07-10T17:03:32.257' AS DateTime), N'Test', NULL, NULL)
INSERT [dbo].[tblCLI_CuentasBancariasPECA] ([id_banco], [id_precliente], [banco], [numero_cuenta], [identificador], [patentes_autorizadas], [aduana], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (20, 0, N'Bancomer', 8787998, N'Identificador', N'Patente', N'Aduana', CAST(N'2018-07-10T17:03:57.833' AS DateTime), N'Test', NULL, NULL)
INSERT [dbo].[tblCLI_CuentasBancariasPECA] ([id_banco], [id_precliente], [banco], [numero_cuenta], [identificador], [patentes_autorizadas], [aduana], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (21, 0, N'Bancomer', 8787998, N'Identificador', N'Patente', N'Aduana', CAST(N'2018-07-10T17:03:57.833' AS DateTime), N'Test', NULL, NULL)
INSERT [dbo].[tblCLI_CuentasBancariasPECA] ([id_banco], [id_precliente], [banco], [numero_cuenta], [identificador], [patentes_autorizadas], [aduana], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (22, 0, N'Bancomer', 8787998, N'Identificador', N'Patente', N'Aduana', CAST(N'2018-07-10T17:03:57.833' AS DateTime), N'Test', NULL, NULL)
INSERT [dbo].[tblCLI_CuentasBancariasPECA] ([id_banco], [id_precliente], [banco], [numero_cuenta], [identificador], [patentes_autorizadas], [aduana], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (23, 0, N'Bancomer', 6548498, N'Identificador', N'Patente', N'Aduana', CAST(N'2018-07-10T17:03:57.833' AS DateTime), N'Test', NULL, NULL)
INSERT [dbo].[tblCLI_CuentasBancariasPECA] ([id_banco], [id_precliente], [banco], [numero_cuenta], [identificador], [patentes_autorizadas], [aduana], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (24, 0, N'Bancomer', 8787998, N'Identificador', N'Patente', N'Aduana', CAST(N'2018-07-10T17:04:08.653' AS DateTime), N'Test', NULL, NULL)
INSERT [dbo].[tblCLI_CuentasBancariasPECA] ([id_banco], [id_precliente], [banco], [numero_cuenta], [identificador], [patentes_autorizadas], [aduana], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (25, 0, N'Bancomer', 8787998, N'Identificador', N'Patente', N'Aduana', CAST(N'2018-07-10T17:04:08.653' AS DateTime), N'Test', NULL, NULL)
INSERT [dbo].[tblCLI_CuentasBancariasPECA] ([id_banco], [id_precliente], [banco], [numero_cuenta], [identificador], [patentes_autorizadas], [aduana], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (26, 0, N'Bancomer', 8787998, N'Identificador', N'Patente', N'Aduana', CAST(N'2018-07-10T17:04:08.653' AS DateTime), N'Test', NULL, NULL)
INSERT [dbo].[tblCLI_CuentasBancariasPECA] ([id_banco], [id_precliente], [banco], [numero_cuenta], [identificador], [patentes_autorizadas], [aduana], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (27, 0, N'Bancomer', 6548498, N'Identificador', N'Patente', N'Aduana', CAST(N'2018-07-10T17:04:08.653' AS DateTime), N'Test', NULL, NULL)
INSERT [dbo].[tblCLI_CuentasBancariasPECA] ([id_banco], [id_precliente], [banco], [numero_cuenta], [identificador], [patentes_autorizadas], [aduana], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (28, 0, N'Bancomer', 8787998, N'Identificador', N'Patente', N'Aduana', CAST(N'2018-07-10T17:09:27.337' AS DateTime), N'Test', NULL, NULL)
INSERT [dbo].[tblCLI_CuentasBancariasPECA] ([id_banco], [id_precliente], [banco], [numero_cuenta], [identificador], [patentes_autorizadas], [aduana], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (29, 0, N'Bancomer', 8787998, N'Identificador', N'Patente', N'Aduana', CAST(N'2018-07-10T17:09:27.337' AS DateTime), N'Test', NULL, NULL)
INSERT [dbo].[tblCLI_CuentasBancariasPECA] ([id_banco], [id_precliente], [banco], [numero_cuenta], [identificador], [patentes_autorizadas], [aduana], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (30, 0, N'Bancomer', 8787998, N'Identificador', N'Patente', N'Aduana', CAST(N'2018-07-10T17:09:27.337' AS DateTime), N'Test', NULL, NULL)
INSERT [dbo].[tblCLI_CuentasBancariasPECA] ([id_banco], [id_precliente], [banco], [numero_cuenta], [identificador], [patentes_autorizadas], [aduana], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (31, 0, N'Bancomer', 6548498, N'Identificador', N'Patente', N'Aduana', CAST(N'2018-07-10T17:09:27.337' AS DateTime), N'Test', NULL, NULL)
INSERT [dbo].[tblCLI_CuentasBancariasPECA] ([id_banco], [id_precliente], [banco], [numero_cuenta], [identificador], [patentes_autorizadas], [aduana], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (32, 0, N'bancomer', 34343, N'44', N'344', N'aduana', CAST(N'2018-07-10T22:30:03.590' AS DateTime), N'Test', NULL, NULL)
INSERT [dbo].[tblCLI_CuentasBancariasPECA] ([id_banco], [id_precliente], [banco], [numero_cuenta], [identificador], [patentes_autorizadas], [aduana], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (33, 0, N'Bancomer', 8787998, N'Identificador', N'Patente', N'Aduana', CAST(N'2018-07-13T22:51:18.313' AS DateTime), N'Test', NULL, NULL)
INSERT [dbo].[tblCLI_CuentasBancariasPECA] ([id_banco], [id_precliente], [banco], [numero_cuenta], [identificador], [patentes_autorizadas], [aduana], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (34, 0, N'Bancomer', 8787998, N'Identificador', N'Patente', N'Aduana', CAST(N'2018-07-13T22:51:18.313' AS DateTime), N'Test', NULL, NULL)
INSERT [dbo].[tblCLI_CuentasBancariasPECA] ([id_banco], [id_precliente], [banco], [numero_cuenta], [identificador], [patentes_autorizadas], [aduana], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (35, 0, N'Bancomer', 8787998, N'Identificador', N'Patente', N'Aduana', CAST(N'2018-07-13T22:51:18.313' AS DateTime), N'Test', NULL, NULL)
INSERT [dbo].[tblCLI_CuentasBancariasPECA] ([id_banco], [id_precliente], [banco], [numero_cuenta], [identificador], [patentes_autorizadas], [aduana], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (36, 0, N'Bancomer', 6548498, N'Identificador', N'Patente', N'Aduana', CAST(N'2018-07-13T22:51:18.313' AS DateTime), N'Test', NULL, NULL)
INSERT [dbo].[tblCLI_CuentasBancariasPECA] ([id_banco], [id_precliente], [banco], [numero_cuenta], [identificador], [patentes_autorizadas], [aduana], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (37, 0, N'Bancomer', 8787998, N'Identificador', N'Patente', N'Aduana', CAST(N'2018-07-13T23:10:29.093' AS DateTime), N'Test', NULL, NULL)
INSERT [dbo].[tblCLI_CuentasBancariasPECA] ([id_banco], [id_precliente], [banco], [numero_cuenta], [identificador], [patentes_autorizadas], [aduana], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (38, 0, N'Bancomer', 8787998, N'Identificador', N'Patente', N'Aduana', CAST(N'2018-07-13T23:10:29.093' AS DateTime), N'Test', NULL, NULL)
INSERT [dbo].[tblCLI_CuentasBancariasPECA] ([id_banco], [id_precliente], [banco], [numero_cuenta], [identificador], [patentes_autorizadas], [aduana], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (39, 0, N'Bancomer', 8787998, N'Identificador', N'Patente', N'Aduana', CAST(N'2018-07-13T23:10:29.093' AS DateTime), N'Test', NULL, NULL)
INSERT [dbo].[tblCLI_CuentasBancariasPECA] ([id_banco], [id_precliente], [banco], [numero_cuenta], [identificador], [patentes_autorizadas], [aduana], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (40, 0, N'Bancomer', 6548498, N'Identificador', N'Patente', N'Aduana', CAST(N'2018-07-13T23:10:29.093' AS DateTime), N'Test', NULL, NULL)
INSERT [dbo].[tblCLI_CuentasBancariasPECA] ([id_banco], [id_precliente], [banco], [numero_cuenta], [identificador], [patentes_autorizadas], [aduana], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (41, 0, N'Bancomer', 8787998, N'Identificador', N'Patente', N'Aduana', CAST(N'2018-07-14T00:02:04.653' AS DateTime), N'Test', NULL, NULL)
INSERT [dbo].[tblCLI_CuentasBancariasPECA] ([id_banco], [id_precliente], [banco], [numero_cuenta], [identificador], [patentes_autorizadas], [aduana], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (42, 0, N'Bancomer', 8787998, N'Identificador', N'Patente', N'Aduana', CAST(N'2018-07-14T00:02:04.653' AS DateTime), N'Test', NULL, NULL)
INSERT [dbo].[tblCLI_CuentasBancariasPECA] ([id_banco], [id_precliente], [banco], [numero_cuenta], [identificador], [patentes_autorizadas], [aduana], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (43, 0, N'Bancomer', 8787998, N'Identificador', N'Patente', N'Aduana', CAST(N'2018-07-14T00:02:04.653' AS DateTime), N'Test', NULL, NULL)
INSERT [dbo].[tblCLI_CuentasBancariasPECA] ([id_banco], [id_precliente], [banco], [numero_cuenta], [identificador], [patentes_autorizadas], [aduana], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (44, 0, N'Bancomer', 6548498, N'Identificador', N'Patente', N'Aduana', CAST(N'2018-07-14T00:02:04.653' AS DateTime), N'Test', NULL, NULL)
INSERT [dbo].[tblCLI_CuentasBancariasPECA] ([id_banco], [id_precliente], [banco], [numero_cuenta], [identificador], [patentes_autorizadas], [aduana], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (45, 0, N'Bancomer', 8787998, N'Identificador', N'Patente', N'Aduana', CAST(N'2018-07-14T00:21:17.140' AS DateTime), N'Test', NULL, NULL)
INSERT [dbo].[tblCLI_CuentasBancariasPECA] ([id_banco], [id_precliente], [banco], [numero_cuenta], [identificador], [patentes_autorizadas], [aduana], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (46, 0, N'Bancomer', 8787998, N'Identificador', N'Patente', N'Aduana', CAST(N'2018-07-14T00:21:17.140' AS DateTime), N'Test', NULL, NULL)
INSERT [dbo].[tblCLI_CuentasBancariasPECA] ([id_banco], [id_precliente], [banco], [numero_cuenta], [identificador], [patentes_autorizadas], [aduana], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (47, 0, N'Bancomer', 8787998, N'Identificador', N'Patente', N'Aduana', CAST(N'2018-07-14T00:21:17.140' AS DateTime), N'Test', NULL, NULL)
INSERT [dbo].[tblCLI_CuentasBancariasPECA] ([id_banco], [id_precliente], [banco], [numero_cuenta], [identificador], [patentes_autorizadas], [aduana], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (48, 0, N'Bancomer', 6548498, N'Identificador', N'Patente', N'Aduana', CAST(N'2018-07-14T00:21:17.140' AS DateTime), N'Test', NULL, NULL)
INSERT [dbo].[tblCLI_CuentasBancariasPECA] ([id_banco], [id_precliente], [banco], [numero_cuenta], [identificador], [patentes_autorizadas], [aduana], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (49, 0, N'Bancomer', 8787998, N'Identificador', N'Patente', N'Aduana', CAST(N'2018-07-14T00:22:57.947' AS DateTime), N'Test', NULL, NULL)
INSERT [dbo].[tblCLI_CuentasBancariasPECA] ([id_banco], [id_precliente], [banco], [numero_cuenta], [identificador], [patentes_autorizadas], [aduana], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (50, 0, N'Bancomer', 8787998, N'Identificador', N'Patente', N'Aduana', CAST(N'2018-07-14T00:22:57.947' AS DateTime), N'Test', NULL, NULL)
INSERT [dbo].[tblCLI_CuentasBancariasPECA] ([id_banco], [id_precliente], [banco], [numero_cuenta], [identificador], [patentes_autorizadas], [aduana], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (51, 0, N'Bancomer', 8787998, N'Identificador', N'Patente', N'Aduana', CAST(N'2018-07-14T00:22:57.947' AS DateTime), N'Test', NULL, NULL)
INSERT [dbo].[tblCLI_CuentasBancariasPECA] ([id_banco], [id_precliente], [banco], [numero_cuenta], [identificador], [patentes_autorizadas], [aduana], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (52, 0, N'Bancomer', 6548498, N'Identificador', N'Patente', N'Aduana', CAST(N'2018-07-14T00:22:57.947' AS DateTime), N'Test', NULL, NULL)
INSERT [dbo].[tblCLI_CuentasBancariasPECA] ([id_banco], [id_precliente], [banco], [numero_cuenta], [identificador], [patentes_autorizadas], [aduana], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (53, 0, N'Bancomer', 8787998, N'Identificador', N'Patente', N'Aduana', CAST(N'2018-07-14T00:23:39.187' AS DateTime), N'Test', NULL, NULL)
INSERT [dbo].[tblCLI_CuentasBancariasPECA] ([id_banco], [id_precliente], [banco], [numero_cuenta], [identificador], [patentes_autorizadas], [aduana], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (54, 0, N'Bancomer', 8787998, N'Identificador', N'Patente', N'Aduana', CAST(N'2018-07-14T00:23:39.187' AS DateTime), N'Test', NULL, NULL)
INSERT [dbo].[tblCLI_CuentasBancariasPECA] ([id_banco], [id_precliente], [banco], [numero_cuenta], [identificador], [patentes_autorizadas], [aduana], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (55, 0, N'Bancomer', 8787998, N'Identificador', N'Patente', N'Aduana', CAST(N'2018-07-14T00:23:39.187' AS DateTime), N'Test', NULL, NULL)
INSERT [dbo].[tblCLI_CuentasBancariasPECA] ([id_banco], [id_precliente], [banco], [numero_cuenta], [identificador], [patentes_autorizadas], [aduana], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (56, 0, N'Bancomer', 6548498, N'Identificador', N'Patente', N'Aduana', CAST(N'2018-07-14T00:23:39.187' AS DateTime), N'Test', NULL, NULL)
INSERT [dbo].[tblCLI_CuentasBancariasPECA] ([id_banco], [id_precliente], [banco], [numero_cuenta], [identificador], [patentes_autorizadas], [aduana], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (57, 0, N'Bancomer', 8787998, N'Identificador', N'Patente', N'Aduana', CAST(N'2018-07-14T01:20:08.937' AS DateTime), N'Test', NULL, NULL)
INSERT [dbo].[tblCLI_CuentasBancariasPECA] ([id_banco], [id_precliente], [banco], [numero_cuenta], [identificador], [patentes_autorizadas], [aduana], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (58, 0, N'Bancomer', 8787998, N'Identificador', N'Patente', N'Aduana', CAST(N'2018-07-14T01:20:08.937' AS DateTime), N'Test', NULL, NULL)
INSERT [dbo].[tblCLI_CuentasBancariasPECA] ([id_banco], [id_precliente], [banco], [numero_cuenta], [identificador], [patentes_autorizadas], [aduana], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (59, 0, N'Bancomer', 8787998, N'Identificador', N'Patente', N'Aduana', CAST(N'2018-07-14T01:20:08.937' AS DateTime), N'Test', NULL, NULL)
INSERT [dbo].[tblCLI_CuentasBancariasPECA] ([id_banco], [id_precliente], [banco], [numero_cuenta], [identificador], [patentes_autorizadas], [aduana], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (60, 0, N'Bancomer', 6548498, N'Identificador', N'Patente', N'Aduana', CAST(N'2018-07-14T01:20:08.937' AS DateTime), N'Test', NULL, NULL)
INSERT [dbo].[tblCLI_CuentasBancariasPECA] ([id_banco], [id_precliente], [banco], [numero_cuenta], [identificador], [patentes_autorizadas], [aduana], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (61, 0, N'Bancomer', 12345, N'identificador2', N'patente2', N'aduana2', CAST(N'2018-07-14T01:20:08.937' AS DateTime), N'Test', NULL, NULL)
INSERT [dbo].[tblCLI_CuentasBancariasPECA] ([id_banco], [id_precliente], [banco], [numero_cuenta], [identificador], [patentes_autorizadas], [aduana], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (62, 0, N'Bancomer', 8787998, N'Identificador', N'Patente', N'Aduana', CAST(N'2018-07-14T01:27:43.947' AS DateTime), N'Test', NULL, NULL)
INSERT [dbo].[tblCLI_CuentasBancariasPECA] ([id_banco], [id_precliente], [banco], [numero_cuenta], [identificador], [patentes_autorizadas], [aduana], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (63, 0, N'Bancomer', 8787998, N'Identificador', N'Patente', N'Aduana', CAST(N'2018-07-14T01:27:43.947' AS DateTime), N'Test', NULL, NULL)
INSERT [dbo].[tblCLI_CuentasBancariasPECA] ([id_banco], [id_precliente], [banco], [numero_cuenta], [identificador], [patentes_autorizadas], [aduana], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (64, 0, N'Bancomer', 8787998, N'Identificador', N'Patente', N'Aduana', CAST(N'2018-07-14T01:27:43.947' AS DateTime), N'Test', NULL, NULL)
INSERT [dbo].[tblCLI_CuentasBancariasPECA] ([id_banco], [id_precliente], [banco], [numero_cuenta], [identificador], [patentes_autorizadas], [aduana], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (65, 0, N'Bancomer', 6548498, N'Identificador', N'Patente', N'Aduana', CAST(N'2018-07-14T01:27:43.947' AS DateTime), N'Test', NULL, NULL)
INSERT [dbo].[tblCLI_CuentasBancariasPECA] ([id_banco], [id_precliente], [banco], [numero_cuenta], [identificador], [patentes_autorizadas], [aduana], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (66, 0, N'BANCO', 1234, N'IDENT', N'PANTENTE1', N'ADANA2', CAST(N'2018-07-14T01:27:43.947' AS DateTime), N'Test', NULL, NULL)
INSERT [dbo].[tblCLI_CuentasBancariasPECA] ([id_banco], [id_precliente], [banco], [numero_cuenta], [identificador], [patentes_autorizadas], [aduana], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (67, 0, N'Bancomer', 8787998, N'Identificador', N'Patente', N'Aduana', CAST(N'2018-07-14T01:31:15.730' AS DateTime), N'Test', NULL, NULL)
INSERT [dbo].[tblCLI_CuentasBancariasPECA] ([id_banco], [id_precliente], [banco], [numero_cuenta], [identificador], [patentes_autorizadas], [aduana], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (68, 0, N'Bancomer', 8787998, N'Identificador', N'Patente', N'Aduana', CAST(N'2018-07-14T01:31:15.730' AS DateTime), N'Test', NULL, NULL)
INSERT [dbo].[tblCLI_CuentasBancariasPECA] ([id_banco], [id_precliente], [banco], [numero_cuenta], [identificador], [patentes_autorizadas], [aduana], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (69, 0, N'Bancomer', 8787998, N'Identificador', N'Patente', N'Aduana', CAST(N'2018-07-14T01:31:15.730' AS DateTime), N'Test', NULL, NULL)
INSERT [dbo].[tblCLI_CuentasBancariasPECA] ([id_banco], [id_precliente], [banco], [numero_cuenta], [identificador], [patentes_autorizadas], [aduana], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (70, 0, N'Bancomer', 6548498, N'Identificador', N'Patente', N'Aduana', CAST(N'2018-07-14T01:31:15.730' AS DateTime), N'Test', NULL, NULL)
INSERT [dbo].[tblCLI_CuentasBancariasPECA] ([id_banco], [id_precliente], [banco], [numero_cuenta], [identificador], [patentes_autorizadas], [aduana], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (71, 0, N'BANCO', 1234, N'IDENT', N'PANTENTE1', N'ADANA2', CAST(N'2018-07-14T01:31:15.730' AS DateTime), N'Test', NULL, NULL)
INSERT [dbo].[tblCLI_CuentasBancariasPECA] ([id_banco], [id_precliente], [banco], [numero_cuenta], [identificador], [patentes_autorizadas], [aduana], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (72, 0, N'Bancomer', 8787998, N'Identificador', N'Patente', N'Aduana', CAST(N'2018-07-14T01:33:11.910' AS DateTime), N'Test', NULL, NULL)
INSERT [dbo].[tblCLI_CuentasBancariasPECA] ([id_banco], [id_precliente], [banco], [numero_cuenta], [identificador], [patentes_autorizadas], [aduana], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (73, 0, N'Bancomer', 8787998, N'Identificador', N'Patente', N'Aduana', CAST(N'2018-07-14T01:33:11.910' AS DateTime), N'Test', NULL, NULL)
INSERT [dbo].[tblCLI_CuentasBancariasPECA] ([id_banco], [id_precliente], [banco], [numero_cuenta], [identificador], [patentes_autorizadas], [aduana], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (74, 0, N'Bancomer', 8787998, N'Identificador', N'Patente', N'Aduana', CAST(N'2018-07-14T01:33:11.910' AS DateTime), N'Test', NULL, NULL)
INSERT [dbo].[tblCLI_CuentasBancariasPECA] ([id_banco], [id_precliente], [banco], [numero_cuenta], [identificador], [patentes_autorizadas], [aduana], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (75, 0, N'Bancomer', 6548498, N'Identificador', N'Patente', N'Aduana', CAST(N'2018-07-14T01:33:11.910' AS DateTime), N'Test', NULL, NULL)
INSERT [dbo].[tblCLI_CuentasBancariasPECA] ([id_banco], [id_precliente], [banco], [numero_cuenta], [identificador], [patentes_autorizadas], [aduana], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (76, 0, N'BANCO', 1234, N'IDENT', N'PANTENTE1', N'ADANA2', CAST(N'2018-07-14T01:33:11.910' AS DateTime), N'Test', NULL, NULL)
INSERT [dbo].[tblCLI_CuentasBancariasPECA] ([id_banco], [id_precliente], [banco], [numero_cuenta], [identificador], [patentes_autorizadas], [aduana], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (77, 0, N'Bancomer', 8787998, N'Identificador', N'Patente', N'Aduana', CAST(N'2018-07-14T01:33:14.083' AS DateTime), N'Test', NULL, NULL)
INSERT [dbo].[tblCLI_CuentasBancariasPECA] ([id_banco], [id_precliente], [banco], [numero_cuenta], [identificador], [patentes_autorizadas], [aduana], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (78, 0, N'Bancomer', 8787998, N'Identificador', N'Patente', N'Aduana', CAST(N'2018-07-14T01:33:14.083' AS DateTime), N'Test', NULL, NULL)
INSERT [dbo].[tblCLI_CuentasBancariasPECA] ([id_banco], [id_precliente], [banco], [numero_cuenta], [identificador], [patentes_autorizadas], [aduana], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (79, 0, N'Bancomer', 8787998, N'Identificador', N'Patente', N'Aduana', CAST(N'2018-07-14T01:33:14.083' AS DateTime), N'Test', NULL, NULL)
INSERT [dbo].[tblCLI_CuentasBancariasPECA] ([id_banco], [id_precliente], [banco], [numero_cuenta], [identificador], [patentes_autorizadas], [aduana], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (80, 0, N'Bancomer', 6548498, N'Identificador', N'Patente', N'Aduana', CAST(N'2018-07-14T01:33:14.083' AS DateTime), N'Test', NULL, NULL)
INSERT [dbo].[tblCLI_CuentasBancariasPECA] ([id_banco], [id_precliente], [banco], [numero_cuenta], [identificador], [patentes_autorizadas], [aduana], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (81, 0, N'BANCO', 1234, N'IDENT', N'PANTENTE1', N'ADANA2', CAST(N'2018-07-14T01:33:14.083' AS DateTime), N'Test', NULL, NULL)
INSERT [dbo].[tblCLI_CuentasBancariasPECA] ([id_banco], [id_precliente], [banco], [numero_cuenta], [identificador], [patentes_autorizadas], [aduana], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (82, 0, N'Bancomer', 8787998, N'Identificador', N'Patente', N'Aduana', CAST(N'2018-07-14T01:35:20.540' AS DateTime), N'Test', NULL, NULL)
INSERT [dbo].[tblCLI_CuentasBancariasPECA] ([id_banco], [id_precliente], [banco], [numero_cuenta], [identificador], [patentes_autorizadas], [aduana], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (83, 0, N'Bancomer', 8787998, N'Identificador', N'Patente', N'Aduana', CAST(N'2018-07-14T01:35:20.540' AS DateTime), N'Test', NULL, NULL)
INSERT [dbo].[tblCLI_CuentasBancariasPECA] ([id_banco], [id_precliente], [banco], [numero_cuenta], [identificador], [patentes_autorizadas], [aduana], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (84, 0, N'Bancomer', 8787998, N'Identificador', N'Patente', N'Aduana', CAST(N'2018-07-14T01:35:20.540' AS DateTime), N'Test', NULL, NULL)
INSERT [dbo].[tblCLI_CuentasBancariasPECA] ([id_banco], [id_precliente], [banco], [numero_cuenta], [identificador], [patentes_autorizadas], [aduana], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (85, 0, N'Bancomer', 6548498, N'Identificador', N'Patente', N'Aduana', CAST(N'2018-07-14T01:35:20.540' AS DateTime), N'Test', NULL, NULL)
INSERT [dbo].[tblCLI_CuentasBancariasPECA] ([id_banco], [id_precliente], [banco], [numero_cuenta], [identificador], [patentes_autorizadas], [aduana], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (86, 0, N'BANCO', 1234, N'IDENT', N'PANTENTE1', N'ADANA2', CAST(N'2018-07-14T01:35:20.540' AS DateTime), N'Test', NULL, NULL)
INSERT [dbo].[tblCLI_CuentasBancariasPECA] ([id_banco], [id_precliente], [banco], [numero_cuenta], [identificador], [patentes_autorizadas], [aduana], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (87, 0, N'Bancomer', 8787998, N'Identificador', N'Patente', N'Aduana', CAST(N'2018-07-14T01:35:30.760' AS DateTime), N'Test', NULL, NULL)
INSERT [dbo].[tblCLI_CuentasBancariasPECA] ([id_banco], [id_precliente], [banco], [numero_cuenta], [identificador], [patentes_autorizadas], [aduana], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (88, 0, N'Bancomer', 8787998, N'Identificador', N'Patente', N'Aduana', CAST(N'2018-07-14T01:35:30.760' AS DateTime), N'Test', NULL, NULL)
INSERT [dbo].[tblCLI_CuentasBancariasPECA] ([id_banco], [id_precliente], [banco], [numero_cuenta], [identificador], [patentes_autorizadas], [aduana], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (89, 0, N'Bancomer', 8787998, N'Identificador', N'Patente', N'Aduana', CAST(N'2018-07-14T01:35:30.760' AS DateTime), N'Test', NULL, NULL)
INSERT [dbo].[tblCLI_CuentasBancariasPECA] ([id_banco], [id_precliente], [banco], [numero_cuenta], [identificador], [patentes_autorizadas], [aduana], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (90, 0, N'Bancomer', 6548498, N'Identificador', N'Patente', N'Aduana', CAST(N'2018-07-14T01:35:30.760' AS DateTime), N'Test', NULL, NULL)
INSERT [dbo].[tblCLI_CuentasBancariasPECA] ([id_banco], [id_precliente], [banco], [numero_cuenta], [identificador], [patentes_autorizadas], [aduana], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (91, 0, N'BANCO', 1234, N'IDENT', N'PANTENTE1', N'ADANA2', CAST(N'2018-07-14T01:35:30.760' AS DateTime), N'Test', NULL, NULL)
INSERT [dbo].[tblCLI_CuentasBancariasPECA] ([id_banco], [id_precliente], [banco], [numero_cuenta], [identificador], [patentes_autorizadas], [aduana], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (92, 0, N'Bancomer', 8787998, N'Identificador', N'Patente', N'Aduana', CAST(N'2018-07-14T01:35:31.563' AS DateTime), N'Test', NULL, NULL)
INSERT [dbo].[tblCLI_CuentasBancariasPECA] ([id_banco], [id_precliente], [banco], [numero_cuenta], [identificador], [patentes_autorizadas], [aduana], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (93, 0, N'Bancomer', 8787998, N'Identificador', N'Patente', N'Aduana', CAST(N'2018-07-14T01:35:31.563' AS DateTime), N'Test', NULL, NULL)
INSERT [dbo].[tblCLI_CuentasBancariasPECA] ([id_banco], [id_precliente], [banco], [numero_cuenta], [identificador], [patentes_autorizadas], [aduana], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (94, 0, N'Bancomer', 8787998, N'Identificador', N'Patente', N'Aduana', CAST(N'2018-07-14T01:35:31.563' AS DateTime), N'Test', NULL, NULL)
INSERT [dbo].[tblCLI_CuentasBancariasPECA] ([id_banco], [id_precliente], [banco], [numero_cuenta], [identificador], [patentes_autorizadas], [aduana], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (95, 0, N'Bancomer', 6548498, N'Identificador', N'Patente', N'Aduana', CAST(N'2018-07-14T01:35:31.563' AS DateTime), N'Test', NULL, NULL)
INSERT [dbo].[tblCLI_CuentasBancariasPECA] ([id_banco], [id_precliente], [banco], [numero_cuenta], [identificador], [patentes_autorizadas], [aduana], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (96, 0, N'BANCO', 1234, N'IDENT', N'PANTENTE1', N'ADANA2', CAST(N'2018-07-14T01:35:31.563' AS DateTime), N'Test', NULL, NULL)
INSERT [dbo].[tblCLI_CuentasBancariasPECA] ([id_banco], [id_precliente], [banco], [numero_cuenta], [identificador], [patentes_autorizadas], [aduana], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (97, 0, N'Bancomer', 8787998, N'Identificador', N'Patente', N'Aduana', CAST(N'2018-07-14T01:50:26.550' AS DateTime), N'Test', NULL, NULL)
INSERT [dbo].[tblCLI_CuentasBancariasPECA] ([id_banco], [id_precliente], [banco], [numero_cuenta], [identificador], [patentes_autorizadas], [aduana], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (98, 0, N'Bancomer', 8787998, N'Identificador', N'Patente', N'Aduana', CAST(N'2018-07-14T01:50:26.550' AS DateTime), N'Test', NULL, NULL)
INSERT [dbo].[tblCLI_CuentasBancariasPECA] ([id_banco], [id_precliente], [banco], [numero_cuenta], [identificador], [patentes_autorizadas], [aduana], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (99, 0, N'Bancomer', 8787998, N'Identificador', N'Patente', N'Aduana', CAST(N'2018-07-14T01:50:26.550' AS DateTime), N'Test', NULL, NULL)
INSERT [dbo].[tblCLI_CuentasBancariasPECA] ([id_banco], [id_precliente], [banco], [numero_cuenta], [identificador], [patentes_autorizadas], [aduana], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (100, 0, N'Bancomer', 6548498, N'Identificador', N'Patente', N'Aduana', CAST(N'2018-07-14T01:50:26.550' AS DateTime), N'Test', NULL, NULL)
INSERT [dbo].[tblCLI_CuentasBancariasPECA] ([id_banco], [id_precliente], [banco], [numero_cuenta], [identificador], [patentes_autorizadas], [aduana], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (101, 0, N'BANCO', 1234, N'IDENT', N'PANTENTE1', N'ADANA2', CAST(N'2018-07-14T01:50:26.550' AS DateTime), N'Test', NULL, NULL)
INSERT [dbo].[tblCLI_CuentasBancariasPECA] ([id_banco], [id_precliente], [banco], [numero_cuenta], [identificador], [patentes_autorizadas], [aduana], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (102, 0, N'Bancomer', 8787998, N'Identificador', N'Patente', N'Aduana', CAST(N'2018-07-14T01:58:19.220' AS DateTime), N'Test', NULL, NULL)
INSERT [dbo].[tblCLI_CuentasBancariasPECA] ([id_banco], [id_precliente], [banco], [numero_cuenta], [identificador], [patentes_autorizadas], [aduana], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (103, 0, N'Bancomer', 8787998, N'Identificador', N'Patente', N'Aduana', CAST(N'2018-07-14T01:58:19.220' AS DateTime), N'Test', NULL, NULL)
GO
INSERT [dbo].[tblCLI_CuentasBancariasPECA] ([id_banco], [id_precliente], [banco], [numero_cuenta], [identificador], [patentes_autorizadas], [aduana], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (104, 0, N'Bancomer', 8787998, N'Identificador', N'Patente', N'Aduana', CAST(N'2018-07-14T01:58:19.220' AS DateTime), N'Test', NULL, NULL)
INSERT [dbo].[tblCLI_CuentasBancariasPECA] ([id_banco], [id_precliente], [banco], [numero_cuenta], [identificador], [patentes_autorizadas], [aduana], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (105, 0, N'Bancomer', 6548498, N'Identificador', N'Patente', N'Aduana', CAST(N'2018-07-14T01:58:19.220' AS DateTime), N'Test', NULL, NULL)
INSERT [dbo].[tblCLI_CuentasBancariasPECA] ([id_banco], [id_precliente], [banco], [numero_cuenta], [identificador], [patentes_autorizadas], [aduana], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (106, 0, N'Bancomer', 8787998, N'Identificador', N'Patente', N'Aduana', CAST(N'2018-07-14T01:58:38.480' AS DateTime), N'Test', NULL, NULL)
INSERT [dbo].[tblCLI_CuentasBancariasPECA] ([id_banco], [id_precliente], [banco], [numero_cuenta], [identificador], [patentes_autorizadas], [aduana], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (107, 0, N'Bancomer', 8787998, N'Identificador', N'Patente', N'Aduana', CAST(N'2018-07-14T01:58:38.480' AS DateTime), N'Test', NULL, NULL)
INSERT [dbo].[tblCLI_CuentasBancariasPECA] ([id_banco], [id_precliente], [banco], [numero_cuenta], [identificador], [patentes_autorizadas], [aduana], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (108, 0, N'Bancomer', 8787998, N'Identificador', N'Patente', N'Aduana', CAST(N'2018-07-14T01:58:38.480' AS DateTime), N'Test', NULL, NULL)
INSERT [dbo].[tblCLI_CuentasBancariasPECA] ([id_banco], [id_precliente], [banco], [numero_cuenta], [identificador], [patentes_autorizadas], [aduana], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (109, 0, N'Bancomer', 6548498, N'Identificador', N'Patente', N'Aduana', CAST(N'2018-07-14T01:58:38.480' AS DateTime), N'Test', NULL, NULL)
INSERT [dbo].[tblCLI_CuentasBancariasPECA] ([id_banco], [id_precliente], [banco], [numero_cuenta], [identificador], [patentes_autorizadas], [aduana], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (182, 20, N'b', 33, N'22', N'33', N'22323', CAST(N'2018-07-16T09:27:39.230' AS DateTime), N'Test', NULL, NULL)
INSERT [dbo].[tblCLI_CuentasBancariasPECA] ([id_banco], [id_precliente], [banco], [numero_cuenta], [identificador], [patentes_autorizadas], [aduana], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (188, 23, N'11', 1, N'1', N'1', N'1', CAST(N'2018-07-16T10:41:42.333' AS DateTime), N'Test', NULL, NULL)
INSERT [dbo].[tblCLI_CuentasBancariasPECA] ([id_banco], [id_precliente], [banco], [numero_cuenta], [identificador], [patentes_autorizadas], [aduana], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (192, 26, N'1', 1, N'11', N'1', N'1', CAST(N'2018-07-16T11:10:39.980' AS DateTime), N'Test', NULL, NULL)
INSERT [dbo].[tblCLI_CuentasBancariasPECA] ([id_banco], [id_precliente], [banco], [numero_cuenta], [identificador], [patentes_autorizadas], [aduana], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (196, 27, N'A', 1, N'A', N'A', N'A', CAST(N'2018-07-16T14:18:03.020' AS DateTime), N'Test', NULL, NULL)
INSERT [dbo].[tblCLI_CuentasBancariasPECA] ([id_banco], [id_precliente], [banco], [numero_cuenta], [identificador], [patentes_autorizadas], [aduana], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (197, 28, N'2', 2, N'2', N'2', N'2', CAST(N'2018-07-16T14:27:51.357' AS DateTime), N'Test', NULL, NULL)
INSERT [dbo].[tblCLI_CuentasBancariasPECA] ([id_banco], [id_precliente], [banco], [numero_cuenta], [identificador], [patentes_autorizadas], [aduana], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (199, 29, N'b', 333, N'qq', N'ww', N'ee', CAST(N'2018-07-16T15:44:09.440' AS DateTime), N'Test', NULL, NULL)
INSERT [dbo].[tblCLI_CuentasBancariasPECA] ([id_banco], [id_precliente], [banco], [numero_cuenta], [identificador], [patentes_autorizadas], [aduana], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (200, 2, N'Bancomer', 8787998, N'Identificador', N'Patente', N'Aduana', CAST(N'2018-07-17T09:48:51.313' AS DateTime), N'Test', NULL, NULL)
INSERT [dbo].[tblCLI_CuentasBancariasPECA] ([id_banco], [id_precliente], [banco], [numero_cuenta], [identificador], [patentes_autorizadas], [aduana], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (201, 2, N'Bancomer', 8787998, N'Identificador', N'Patente', N'Aduana', CAST(N'2018-07-17T09:48:51.313' AS DateTime), N'Test', NULL, NULL)
INSERT [dbo].[tblCLI_CuentasBancariasPECA] ([id_banco], [id_precliente], [banco], [numero_cuenta], [identificador], [patentes_autorizadas], [aduana], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (204, 32, N'5', 5, N'5', N'5', N'5', CAST(N'2018-07-17T12:08:13.130' AS DateTime), N'Test', NULL, NULL)
INSERT [dbo].[tblCLI_CuentasBancariasPECA] ([id_banco], [id_precliente], [banco], [numero_cuenta], [identificador], [patentes_autorizadas], [aduana], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (205, 33, N'1', 1, N'1', N'1', N'1', CAST(N'2018-07-17T18:20:10.167' AS DateTime), N'Test', NULL, NULL)
INSERT [dbo].[tblCLI_CuentasBancariasPECA] ([id_banco], [id_precliente], [banco], [numero_cuenta], [identificador], [patentes_autorizadas], [aduana], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (206, 34, N'1', 1, N'1', N'1', N'1', CAST(N'2018-07-17T18:38:52.567' AS DateTime), N'Test', NULL, NULL)
SET IDENTITY_INSERT [dbo].[tblCLI_CuentasBancariasPECA] OFF
SET IDENTITY_INSERT [dbo].[tblCLI_Documentos] ON 

INSERT [dbo].[tblCLI_Documentos] ([id_documento], [descripcion]) VALUES (1, N'Carta Encomienda')
INSERT [dbo].[tblCLI_Documentos] ([id_documento], [descripcion]) VALUES (2, N'Carta Encomienda Respaldo')
INSERT [dbo].[tblCLI_Documentos] ([id_documento], [descripcion]) VALUES (3, N'Constancia de situación del cliente')
INSERT [dbo].[tblCLI_Documentos] ([id_documento], [descripcion]) VALUES (4, N'Comprobante de domicilio de la empresa no mayor a 2 meses')
INSERT [dbo].[tblCLI_Documentos] ([id_documento], [descripcion]) VALUES (5, N'Acta constitutiva de la empresa')
INSERT [dbo].[tblCLI_Documentos] ([id_documento], [descripcion]) VALUES (6, N'Poder Notarial del representante y/o apoderado legal')
INSERT [dbo].[tblCLI_Documentos] ([id_documento], [descripcion]) VALUES (7, N'Identificación oficial con foto y firma')
INSERT [dbo].[tblCLI_Documentos] ([id_documento], [descripcion]) VALUES (8, N'RFC del representante lega')
INSERT [dbo].[tblCLI_Documentos] ([id_documento], [descripcion]) VALUES (9, N'Encargo Conferido a favor de cada uno de los agentes aduanales')
INSERT [dbo].[tblCLI_Documentos] ([id_documento], [descripcion]) VALUES (10, N'Fotografías recientes del establecimiento')
SET IDENTITY_INSERT [dbo].[tblCLI_Documentos] OFF
SET IDENTITY_INSERT [dbo].[tblCLI_DocumentosCliente] ON 

INSERT [dbo].[tblCLI_DocumentosCliente] ([id_documento_cliente], [id_documento], [id_precliente], [activo], [ruta_local], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion], [id_usuario_revision], [fecha_revision]) VALUES (1, 1, 1, 1, N'C:\portac\PortalCliente\PortalCliente.Web\Documentos\2\plantilla-reportes.pdf', CAST(N'2018-07-02T00:31:48.553' AS DateTime), N'test', CAST(N'2018-07-02T00:31:48.553' AS DateTime), N'testmod', N'2', CAST(N'2018-07-16T20:36:44.517' AS DateTime))
INSERT [dbo].[tblCLI_DocumentosCliente] ([id_documento_cliente], [id_documento], [id_precliente], [activo], [ruta_local], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion], [id_usuario_revision], [fecha_revision]) VALUES (3, 3, 1, 1, N'C:\portac\PortalCliente\PortalCliente.Web\Documentos\2\plantilla-reportes.pdf', CAST(N'2018-07-02T00:33:16.487' AS DateTime), N'test', CAST(N'2018-07-02T00:33:16.487' AS DateTime), N'testmod', N'2', CAST(N'2018-07-16T20:36:44.517' AS DateTime))
INSERT [dbo].[tblCLI_DocumentosCliente] ([id_documento_cliente], [id_documento], [id_precliente], [activo], [ruta_local], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion], [id_usuario_revision], [fecha_revision]) VALUES (4, 4, 1, 1, N'C:\portac\PortalCliente\PortalCliente.Web\Documentos\2\plantilla-reportes.pdf', CAST(N'2018-07-02T00:34:28.243' AS DateTime), N'test', CAST(N'2018-07-02T00:34:28.243' AS DateTime), N'testmod', N'2', CAST(N'2018-07-16T20:36:44.517' AS DateTime))
INSERT [dbo].[tblCLI_DocumentosCliente] ([id_documento_cliente], [id_documento], [id_precliente], [activo], [ruta_local], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion], [id_usuario_revision], [fecha_revision]) VALUES (5, 5, 1, 1, N'C:\portac\PortalCliente\PortalCliente.Web\Documentos\2\plantilla-reportes.pdf', CAST(N'2018-07-02T00:38:01.777' AS DateTime), N'test', CAST(N'2018-07-02T00:38:01.777' AS DateTime), N'testmod', N'2', CAST(N'2018-07-16T20:36:44.517' AS DateTime))
INSERT [dbo].[tblCLI_DocumentosCliente] ([id_documento_cliente], [id_documento], [id_precliente], [activo], [ruta_local], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion], [id_usuario_revision], [fecha_revision]) VALUES (6, 6, 1, 1, N'C:\portac\PortalCliente\PortalCliente.Web\Documentos\2\plantilla-reportes.pdf', CAST(N'2018-07-02T00:38:22.853' AS DateTime), N'test', CAST(N'2018-07-02T00:38:22.853' AS DateTime), N'testmod', N'2', CAST(N'2018-07-16T20:36:44.517' AS DateTime))
INSERT [dbo].[tblCLI_DocumentosCliente] ([id_documento_cliente], [id_documento], [id_precliente], [activo], [ruta_local], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion], [id_usuario_revision], [fecha_revision]) VALUES (7, 1, 2, 0, N'Documentos\2\plantilla-reportes.pdf', CAST(N'2018-07-04T19:29:30.850' AS DateTime), N'admin', CAST(N'2018-07-04T19:29:30.850' AS DateTime), N'admin', N'1', CAST(N'2018-07-15T19:08:05.683' AS DateTime))
INSERT [dbo].[tblCLI_DocumentosCliente] ([id_documento_cliente], [id_documento], [id_precliente], [activo], [ruta_local], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion], [id_usuario_revision], [fecha_revision]) VALUES (8, 2, 2, 0, N'Documentos\2\plantilla-reportes.pdf', CAST(N'2018-07-04T21:15:30.267' AS DateTime), N'admin', CAST(N'2018-07-04T21:15:30.267' AS DateTime), N'admin', N'1', CAST(N'2018-07-17T15:02:34.430' AS DateTime))
INSERT [dbo].[tblCLI_DocumentosCliente] ([id_documento_cliente], [id_documento], [id_precliente], [activo], [ruta_local], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion], [id_usuario_revision], [fecha_revision]) VALUES (9, 3, 2, 1, N'Documentos\2\plantilla-reportes.pdf', CAST(N'2018-07-05T16:43:14.427' AS DateTime), N'admin', CAST(N'2018-07-05T16:43:14.427' AS DateTime), N'admin', N'1', CAST(N'2018-07-17T15:02:34.430' AS DateTime))
INSERT [dbo].[tblCLI_DocumentosCliente] ([id_documento_cliente], [id_documento], [id_precliente], [activo], [ruta_local], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion], [id_usuario_revision], [fecha_revision]) VALUES (10, 4, 2, 1, N'Documentos\2\plantilla-reportes.pdf', CAST(N'2018-07-06T00:33:03.913' AS DateTime), N'admin', CAST(N'2018-07-06T00:33:03.913' AS DateTime), N'admin', N'1', CAST(N'2018-07-17T15:02:34.430' AS DateTime))
INSERT [dbo].[tblCLI_DocumentosCliente] ([id_documento_cliente], [id_documento], [id_precliente], [activo], [ruta_local], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion], [id_usuario_revision], [fecha_revision]) VALUES (11, 5, 2, 1, N'Documentos\2\plantilla-reportes.pdf', CAST(N'2018-07-06T18:25:00.117' AS DateTime), N'admin', CAST(N'2018-07-06T18:25:00.117' AS DateTime), N'admin', N'1', CAST(N'2018-07-17T15:02:34.430' AS DateTime))
INSERT [dbo].[tblCLI_DocumentosCliente] ([id_documento_cliente], [id_documento], [id_precliente], [activo], [ruta_local], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion], [id_usuario_revision], [fecha_revision]) VALUES (12, 6, 2, 1, N'Documentos\2\plantilla-reportes.pdf', CAST(N'2018-07-06T18:34:51.373' AS DateTime), N'admin', CAST(N'2018-07-06T18:34:51.373' AS DateTime), N'admin', N'1', CAST(N'2018-07-17T15:02:34.430' AS DateTime))
INSERT [dbo].[tblCLI_DocumentosCliente] ([id_documento_cliente], [id_documento], [id_precliente], [activo], [ruta_local], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion], [id_usuario_revision], [fecha_revision]) VALUES (13, 7, 2, 1, N'Documentos\2\plantilla-reportes.pdf', CAST(N'2018-07-06T18:35:23.930' AS DateTime), N'admin', CAST(N'2018-07-06T18:35:23.930' AS DateTime), N'admin', N'1', CAST(N'2018-07-17T15:02:34.430' AS DateTime))
INSERT [dbo].[tblCLI_DocumentosCliente] ([id_documento_cliente], [id_documento], [id_precliente], [activo], [ruta_local], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion], [id_usuario_revision], [fecha_revision]) VALUES (14, 8, 2, 1, N'Documentos\2\plantilla-reportes.pdf', CAST(N'2018-07-06T18:36:29.797' AS DateTime), N'admin', CAST(N'2018-07-06T18:36:29.797' AS DateTime), N'admin', N'1', CAST(N'2018-07-17T15:02:34.430' AS DateTime))
INSERT [dbo].[tblCLI_DocumentosCliente] ([id_documento_cliente], [id_documento], [id_precliente], [activo], [ruta_local], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion], [id_usuario_revision], [fecha_revision]) VALUES (15, 9, 2, 1, N'Documentos\2\plantilla-reportes.pdf', CAST(N'2018-07-06T18:36:38.263' AS DateTime), N'admin', CAST(N'2018-07-06T18:36:38.263' AS DateTime), N'admin', N'1', CAST(N'2018-07-17T15:02:34.430' AS DateTime))
INSERT [dbo].[tblCLI_DocumentosCliente] ([id_documento_cliente], [id_documento], [id_precliente], [activo], [ruta_local], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion], [id_usuario_revision], [fecha_revision]) VALUES (16, 10, 2, 1, N'Documentos\2\plantilla-reportes.pdf', CAST(N'2018-07-06T18:47:03.817' AS DateTime), N'admin', CAST(N'2018-07-06T18:47:03.817' AS DateTime), N'admin', N'1', CAST(N'2018-07-17T15:02:34.430' AS DateTime))
INSERT [dbo].[tblCLI_DocumentosCliente] ([id_documento_cliente], [id_documento], [id_precliente], [activo], [ruta_local], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion], [id_usuario_revision], [fecha_revision]) VALUES (22, 1, 15, 0, N'C:\ocfinal\Portal de Clientes\PortalCliente\PortalCliente.Web\Documentos\15\CV_RMV_201820187112052533.pdf', CAST(N'2018-07-11T20:52:05.077' AS DateTime), N'admin', CAST(N'2018-07-11T20:52:05.073' AS DateTime), N'admin', NULL, NULL)
INSERT [dbo].[tblCLI_DocumentosCliente] ([id_documento_cliente], [id_documento], [id_precliente], [activo], [ruta_local], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion], [id_usuario_revision], [fecha_revision]) VALUES (23, 1, 15, 0, N'C:\ocfinal\Portal de Clientes\PortalCliente\PortalCliente.Web\Documentos\15\CV_RMV_20182018711205243586.pdf', CAST(N'2018-07-11T20:52:43.587' AS DateTime), N'admin', CAST(N'2018-07-11T20:52:43.587' AS DateTime), N'admin', NULL, NULL)
INSERT [dbo].[tblCLI_DocumentosCliente] ([id_documento_cliente], [id_documento], [id_precliente], [activo], [ruta_local], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion], [id_usuario_revision], [fecha_revision]) VALUES (24, 1, 15, 0, N'C:\ocfinal\Portal de Clientes\PortalCliente\PortalCliente.Web\Documentos\15\C_PRUEBAWORD180405110444201871120549589.pdf', CAST(N'2018-07-11T20:54:09.597' AS DateTime), N'admin', CAST(N'2018-07-11T20:54:09.597' AS DateTime), N'admin', NULL, NULL)
INSERT [dbo].[tblCLI_DocumentosCliente] ([id_documento_cliente], [id_documento], [id_precliente], [activo], [ruta_local], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion], [id_usuario_revision], [fecha_revision]) VALUES (25, 1, 15, 0, N'C:\ocfinal\Portal de Clientes\PortalCliente\PortalCliente.Web\Documentos\15\CertificateOfCompletion_84f47df9-8cfb-4d43-9324-319688a363c3180321112052201871120552536.pdf', CAST(N'2018-07-11T20:55:02.550' AS DateTime), N'admin', CAST(N'2018-07-11T20:55:02.550' AS DateTime), N'admin', NULL, NULL)
INSERT [dbo].[tblCLI_DocumentosCliente] ([id_documento_cliente], [id_documento], [id_precliente], [activo], [ruta_local], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion], [id_usuario_revision], [fecha_revision]) VALUES (26, 1, 15, 0, N'C:\ocfinal\Portal de Clientes\PortalCliente\PortalCliente.Web\Documentos\15\C_PRUEBAWORD1804051104442018711205614733.pdf', CAST(N'2018-07-11T20:56:14.737' AS DateTime), N'admin', CAST(N'2018-07-11T20:56:14.737' AS DateTime), N'admin', NULL, NULL)
INSERT [dbo].[tblCLI_DocumentosCliente] ([id_documento_cliente], [id_documento], [id_precliente], [activo], [ruta_local], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion], [id_usuario_revision], [fecha_revision]) VALUES (27, 1, 15, 0, N'C:\ocfinal\Portal de Clientes\PortalCliente\PortalCliente.Web\Documentos\15\C_PRUEBAWORD180405110444201871120565241.pdf', CAST(N'2018-07-11T20:56:52.043' AS DateTime), N'admin', CAST(N'2018-07-11T20:56:52.043' AS DateTime), N'admin', NULL, NULL)
INSERT [dbo].[tblCLI_DocumentosCliente] ([id_documento_cliente], [id_documento], [id_precliente], [activo], [ruta_local], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion], [id_usuario_revision], [fecha_revision]) VALUES (28, 1, 15, 0, N'C:\ocfinal\Portal de Clientes\PortalCliente\PortalCliente.Web\Documentos\15\C_Demo_DS_NOM_151180404152644201871120582162.pdf', CAST(N'2018-07-11T20:58:02.167' AS DateTime), N'admin', CAST(N'2018-07-11T20:58:02.167' AS DateTime), N'admin', NULL, NULL)
INSERT [dbo].[tblCLI_DocumentosCliente] ([id_documento_cliente], [id_documento], [id_precliente], [activo], [ruta_local], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion], [id_usuario_revision], [fecha_revision]) VALUES (29, 1, 15, 0, N'C:\ocfinal\Portal de Clientes\PortalCliente\PortalCliente.Web\Documentos\15\C_Demo_DS_NOM_151180405102830201871120589213.pdf', CAST(N'2018-07-11T20:58:09.217' AS DateTime), N'admin', CAST(N'2018-07-11T20:58:09.217' AS DateTime), N'admin', NULL, NULL)
INSERT [dbo].[tblCLI_DocumentosCliente] ([id_documento_cliente], [id_documento], [id_precliente], [activo], [ruta_local], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion], [id_usuario_revision], [fecha_revision]) VALUES (30, 1, 15, 0, N'C:\ocfinal\Portal de Clientes\PortalCliente\PortalCliente.Web\Documentos\15\C_Demo_DS_NOM_151180404152644201871120590185.pdf', CAST(N'2018-07-11T20:59:00.187' AS DateTime), N'admin', CAST(N'2018-07-11T20:59:00.187' AS DateTime), N'admin', NULL, NULL)
INSERT [dbo].[tblCLI_DocumentosCliente] ([id_documento_cliente], [id_documento], [id_precliente], [activo], [ruta_local], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion], [id_usuario_revision], [fecha_revision]) VALUES (31, 1, 15, 0, N'C:\ocfinal\Portal de Clientes\PortalCliente\PortalCliente.Web\Documentos\15\CV_RMV_2018_1.pdf20187112106521.docx', CAST(N'2018-07-11T21:00:06.523' AS DateTime), N'admin', CAST(N'2018-07-11T21:00:06.523' AS DateTime), N'admin', NULL, NULL)
INSERT [dbo].[tblCLI_DocumentosCliente] ([id_documento_cliente], [id_documento], [id_precliente], [activo], [ruta_local], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion], [id_usuario_revision], [fecha_revision]) VALUES (32, 1, 15, 0, N'C:\ocfinal\Portal de Clientes\PortalCliente\PortalCliente.Web\Documentos\15\C_ARCHIVO DE WORD CON NO180409104612201871121759278.pdf', CAST(N'2018-07-11T21:07:59.283' AS DateTime), N'admin', CAST(N'2018-07-11T21:07:59.283' AS DateTime), N'admin', NULL, NULL)
INSERT [dbo].[tblCLI_DocumentosCliente] ([id_documento_cliente], [id_documento], [id_precliente], [activo], [ruta_local], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion], [id_usuario_revision], [fecha_revision]) VALUES (33, 3, 15, 0, N'C:\ocfinal\Portal de Clientes\PortalCliente\PortalCliente.Web\Documentos\15\C_ARCHIVO DE WORD CON NO180409104612201871121813316.pdf', CAST(N'2018-07-11T21:08:13.323' AS DateTime), N'admin', CAST(N'2018-07-11T21:08:13.320' AS DateTime), N'admin', NULL, NULL)
INSERT [dbo].[tblCLI_DocumentosCliente] ([id_documento_cliente], [id_documento], [id_precliente], [activo], [ruta_local], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion], [id_usuario_revision], [fecha_revision]) VALUES (34, 4, 15, 0, N'C:\ocfinal\Portal de Clientes\PortalCliente\PortalCliente.Web\Documentos\15\C_ARCHIVO DE WORD CON NO180409104612201871121820822.pdf', CAST(N'2018-07-11T21:08:20.823' AS DateTime), N'admin', CAST(N'2018-07-11T21:08:20.823' AS DateTime), N'admin', NULL, NULL)
INSERT [dbo].[tblCLI_DocumentosCliente] ([id_documento_cliente], [id_documento], [id_precliente], [activo], [ruta_local], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion], [id_usuario_revision], [fecha_revision]) VALUES (35, 5, 15, 0, N'C:\ocfinal\Portal de Clientes\PortalCliente\PortalCliente.Web\Documentos\15\C_PRUEBAWORD180405110444201871121827222.pdf', CAST(N'2018-07-11T21:08:27.227' AS DateTime), N'admin', CAST(N'2018-07-11T21:08:27.227' AS DateTime), N'admin', NULL, NULL)
INSERT [dbo].[tblCLI_DocumentosCliente] ([id_documento_cliente], [id_documento], [id_precliente], [activo], [ruta_local], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion], [id_usuario_revision], [fecha_revision]) VALUES (36, 6, 15, 1, N'C:\ocfinal\Portal de Clientes\PortalCliente\PortalCliente.Web\Documentos\15\CV_RMV_2018_1201871121836381.pdf', CAST(N'2018-07-11T21:08:36.387' AS DateTime), N'admin', CAST(N'2018-07-11T21:08:36.387' AS DateTime), N'admin', NULL, NULL)
INSERT [dbo].[tblCLI_DocumentosCliente] ([id_documento_cliente], [id_documento], [id_precliente], [activo], [ruta_local], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion], [id_usuario_revision], [fecha_revision]) VALUES (37, 7, 15, 1, N'C:\ocfinal\Portal de Clientes\PortalCliente\PortalCliente.Web\Documentos\15\dddd201871121843795.txt', CAST(N'2018-07-11T21:08:43.797' AS DateTime), N'admin', CAST(N'2018-07-11T21:08:43.797' AS DateTime), N'admin', NULL, NULL)
INSERT [dbo].[tblCLI_DocumentosCliente] ([id_documento_cliente], [id_documento], [id_precliente], [activo], [ruta_local], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion], [id_usuario_revision], [fecha_revision]) VALUES (38, 8, 15, 1, N'C:\ocfinal\Portal de Clientes\PortalCliente\PortalCliente.Web\Documentos\15\Demo_DS_NOM_151201871121851498.pdf', CAST(N'2018-07-11T21:08:51.500' AS DateTime), N'admin', CAST(N'2018-07-11T21:08:51.500' AS DateTime), N'admin', NULL, NULL)
INSERT [dbo].[tblCLI_DocumentosCliente] ([id_documento_cliente], [id_documento], [id_precliente], [activo], [ruta_local], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion], [id_usuario_revision], [fecha_revision]) VALUES (39, 9, 15, 1, N'C:\ocfinal\Portal de Clientes\PortalCliente\PortalCliente.Web\Documentos\15\C_Demo_DS_NOM_151180404152644201871121858156.pdf', CAST(N'2018-07-11T21:08:58.157' AS DateTime), N'admin', CAST(N'2018-07-11T21:08:58.157' AS DateTime), N'admin', NULL, NULL)
INSERT [dbo].[tblCLI_DocumentosCliente] ([id_documento_cliente], [id_documento], [id_precliente], [activo], [ruta_local], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion], [id_usuario_revision], [fecha_revision]) VALUES (40, 10, 15, 1, N'C:\ocfinal\Portal de Clientes\PortalCliente\PortalCliente.Web\Documentos\15\C_Demo_DS_NOM_151180405102830201871121916138.pdf', CAST(N'2018-07-11T21:09:16.140' AS DateTime), N'admin', CAST(N'2018-07-11T21:09:16.140' AS DateTime), N'admin', NULL, NULL)
INSERT [dbo].[tblCLI_DocumentosCliente] ([id_documento_cliente], [id_documento], [id_precliente], [activo], [ruta_local], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion], [id_usuario_revision], [fecha_revision]) VALUES (41, 1, 15, 0, N'C:\ocfinal\Portal de Clientes\PortalCliente\PortalCliente.Web\Documentos\15\C_ARCHIVO DE WORD CON NO180409104612201871121206110.pdf', CAST(N'2018-07-11T21:20:06.113' AS DateTime), N'admin', CAST(N'2018-07-11T21:20:06.113' AS DateTime), N'admin', NULL, NULL)
INSERT [dbo].[tblCLI_DocumentosCliente] ([id_documento_cliente], [id_documento], [id_precliente], [activo], [ruta_local], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion], [id_usuario_revision], [fecha_revision]) VALUES (42, 3, 15, 0, N'C:\ocfinal\Portal de Clientes\PortalCliente\PortalCliente.Web\Documentos\15\CertificateOfCompletion_84f47df9-8cfb-4d43-9324-319688a363c3180321112052201871121261436.pdf', CAST(N'2018-07-11T21:26:01.440' AS DateTime), N'admin', CAST(N'2018-07-11T21:26:01.440' AS DateTime), N'admin', NULL, NULL)
INSERT [dbo].[tblCLI_DocumentosCliente] ([id_documento_cliente], [id_documento], [id_precliente], [activo], [ruta_local], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion], [id_usuario_revision], [fecha_revision]) VALUES (43, 4, 15, 1, N'C:\ocfinal\Portal de Clientes\PortalCliente\PortalCliente.Web\Documentos\15\Canmbios EasyDB 1201871121268995.sql', CAST(N'2018-07-11T21:26:08.997' AS DateTime), N'admin', CAST(N'2018-07-11T21:26:08.997' AS DateTime), N'admin', NULL, NULL)
INSERT [dbo].[tblCLI_DocumentosCliente] ([id_documento_cliente], [id_documento], [id_precliente], [activo], [ruta_local], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion], [id_usuario_revision], [fecha_revision]) VALUES (44, 5, 15, 1, N'C:\ocfinal\Portal de Clientes\PortalCliente\PortalCliente.Web\Documentos\15\C_Demo_DS_NOM_151180404152644201871121292856.pdf', CAST(N'2018-07-11T21:29:02.860' AS DateTime), N'admin', CAST(N'2018-07-11T21:29:02.860' AS DateTime), N'admin', NULL, NULL)
INSERT [dbo].[tblCLI_DocumentosCliente] ([id_documento_cliente], [id_documento], [id_precliente], [activo], [ruta_local], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion], [id_usuario_revision], [fecha_revision]) VALUES (45, 1, 15, 0, N'C:\ocfinal\Portal de Clientes\PortalCliente\PortalCliente.Web\Documentos\15\2342018711222254903.pdf', CAST(N'2018-07-11T22:22:54.907' AS DateTime), N'admin', CAST(N'2018-07-11T22:22:54.907' AS DateTime), N'admin', NULL, NULL)
INSERT [dbo].[tblCLI_DocumentosCliente] ([id_documento_cliente], [id_documento], [id_precliente], [activo], [ruta_local], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion], [id_usuario_revision], [fecha_revision]) VALUES (46, 2, 15, 0, N'C:\ocfinal\Portal de Clientes\PortalCliente\PortalCliente.Web\Documentos\15\zend-framework-3-cookbook201871122257468.pdf', CAST(N'2018-07-11T22:25:07.473' AS DateTime), N'admin', CAST(N'2018-07-11T22:25:07.473' AS DateTime), N'admin', NULL, NULL)
INSERT [dbo].[tblCLI_DocumentosCliente] ([id_documento_cliente], [id_documento], [id_precliente], [activo], [ruta_local], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion], [id_usuario_revision], [fecha_revision]) VALUES (47, 1, 15, 0, N'C:\ocfinal\Portal de Clientes\PortalCliente\PortalCliente.Web\Documentos\15\2342018712144746431.pdf', CAST(N'2018-07-12T14:47:46.437' AS DateTime), N'admin', CAST(N'2018-07-12T14:47:46.437' AS DateTime), N'admin', NULL, NULL)
INSERT [dbo].[tblCLI_DocumentosCliente] ([id_documento_cliente], [id_documento], [id_precliente], [activo], [ruta_local], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion], [id_usuario_revision], [fecha_revision]) VALUES (48, 1, 15, 0, N'C:\ocfinal\Portal de Clientes\PortalCliente\PortalCliente.Web\Documentos\15\C_ARCHIVO DE WORD CON NO1804091046122018712144757807.pdf', CAST(N'2018-07-12T14:47:57.810' AS DateTime), N'admin', CAST(N'2018-07-12T14:47:57.810' AS DateTime), N'admin', NULL, NULL)
INSERT [dbo].[tblCLI_DocumentosCliente] ([id_documento_cliente], [id_documento], [id_precliente], [activo], [ruta_local], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion], [id_usuario_revision], [fecha_revision]) VALUES (49, 1, 15, 1, N'C:\ocfinal\Portal de Clientes\PortalCliente\PortalCliente.Web\Documentos\15\234201871215050886.pdf', CAST(N'2018-07-12T15:00:50.890' AS DateTime), N'admin', CAST(N'2018-07-12T15:00:50.890' AS DateTime), N'admin', NULL, NULL)
INSERT [dbo].[tblCLI_DocumentosCliente] ([id_documento_cliente], [id_documento], [id_precliente], [activo], [ruta_local], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion], [id_usuario_revision], [fecha_revision]) VALUES (50, 2, 15, 1, N'C:\ocfinal\Portal de Clientes\PortalCliente\PortalCliente.Web\Documentos\15\234201871215121933.pdf', CAST(N'2018-07-12T15:12:19.037' AS DateTime), N'admin', CAST(N'2018-07-12T15:12:19.037' AS DateTime), N'admin', NULL, NULL)
INSERT [dbo].[tblCLI_DocumentosCliente] ([id_documento_cliente], [id_documento], [id_precliente], [activo], [ruta_local], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion], [id_usuario_revision], [fecha_revision]) VALUES (51, 1, 20, 0, N'C:\ocfinal\Portal de Clientes\PortalCliente\PortalCliente.Web\Documentos\20\C_ARCHIVO DE WORD CON NO1804091046122018712161633143.pdf', CAST(N'2018-07-12T16:16:33.160' AS DateTime), N'admin', CAST(N'2018-07-12T16:16:33.157' AS DateTime), N'admin', NULL, NULL)
INSERT [dbo].[tblCLI_DocumentosCliente] ([id_documento_cliente], [id_documento], [id_precliente], [activo], [ruta_local], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion], [id_usuario_revision], [fecha_revision]) VALUES (52, 2, 20, 1, N'C:\ocfinal\Portal de Clientes\PortalCliente\PortalCliente.Web\Documentos\20\C_ARCHIVO DE WORD CON NO1804091046122018712162011985.pdf', CAST(N'2018-07-12T16:20:11.987' AS DateTime), N'admin', CAST(N'2018-07-12T16:20:11.987' AS DateTime), N'admin', NULL, NULL)
INSERT [dbo].[tblCLI_DocumentosCliente] ([id_documento_cliente], [id_documento], [id_precliente], [activo], [ruta_local], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion], [id_usuario_revision], [fecha_revision]) VALUES (53, 3, 20, 1, N'C:\ocfinal\Portal de Clientes\PortalCliente\PortalCliente.Web\Documentos\20\C_PRUEBAWORD1804051104442018712162348200.pdf', CAST(N'2018-07-12T16:23:48.210' AS DateTime), N'admin', CAST(N'2018-07-12T16:23:48.210' AS DateTime), N'admin', NULL, NULL)
INSERT [dbo].[tblCLI_DocumentosCliente] ([id_documento_cliente], [id_documento], [id_precliente], [activo], [ruta_local], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion], [id_usuario_revision], [fecha_revision]) VALUES (54, 1, 20, 0, N'C:\ocfinal\Portal de Clientes\PortalCliente\PortalCliente.Web\Documentos\20\2342018712163258931.pdf', CAST(N'2018-07-12T16:32:58.933' AS DateTime), N'admin', CAST(N'2018-07-12T16:32:58.933' AS DateTime), N'admin', NULL, NULL)
INSERT [dbo].[tblCLI_DocumentosCliente] ([id_documento_cliente], [id_documento], [id_precliente], [activo], [ruta_local], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion], [id_usuario_revision], [fecha_revision]) VALUES (55, 1, 20, 0, N'C:\ocfinal\Portal de Clientes\PortalCliente\PortalCliente.Web\Documentos\20\Demo_DS_NOM_151201871216336898.pdf', CAST(N'2018-07-12T16:33:06.900' AS DateTime), N'admin', CAST(N'2018-07-12T16:33:06.900' AS DateTime), N'admin', NULL, NULL)
INSERT [dbo].[tblCLI_DocumentosCliente] ([id_documento_cliente], [id_documento], [id_precliente], [activo], [ruta_local], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion], [id_usuario_revision], [fecha_revision]) VALUES (56, 4, 20, 1, N'C:\inetpub\wwwroot\PortalClientes\Documentos\20\shoes120187122019051.jpeg', CAST(N'2018-07-12T20:19:00.050' AS DateTime), N'admin', CAST(N'2018-07-12T20:19:00.050' AS DateTime), N'admin', NULL, NULL)
INSERT [dbo].[tblCLI_DocumentosCliente] ([id_documento_cliente], [id_documento], [id_precliente], [activo], [ruta_local], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion], [id_usuario_revision], [fecha_revision]) VALUES (57, 7, 1, 1, N'C:\portac\PortalCliente\PortalCliente.Web\Documentos\2\plantilla-reportes.pdf', CAST(N'2018-07-12T20:34:01.423' AS DateTime), N'test', CAST(N'2018-07-12T20:34:01.423' AS DateTime), N'testmod', N'2', CAST(N'2018-07-16T20:36:44.517' AS DateTime))
INSERT [dbo].[tblCLI_DocumentosCliente] ([id_documento_cliente], [id_documento], [id_precliente], [activo], [ruta_local], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion], [id_usuario_revision], [fecha_revision]) VALUES (58, 8, 1, 1, N'C:\portac\PortalCliente\PortalCliente.Web\Documentos\2\plantilla-reportes.pdf', CAST(N'2018-07-12T20:34:15.150' AS DateTime), N'test', CAST(N'2018-07-12T20:34:15.150' AS DateTime), N'testmod', N'2', CAST(N'2018-07-16T20:36:44.517' AS DateTime))
INSERT [dbo].[tblCLI_DocumentosCliente] ([id_documento_cliente], [id_documento], [id_precliente], [activo], [ruta_local], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion], [id_usuario_revision], [fecha_revision]) VALUES (60, 10, 1, 1, N'C:\portac\PortalCliente\PortalCliente.Web\Documentos\2\plantilla-reportes.pdf', CAST(N'2018-07-12T20:34:33.793' AS DateTime), N'test', CAST(N'2018-07-12T20:34:33.793' AS DateTime), N'testmod', N'2', CAST(N'2018-07-16T20:36:44.517' AS DateTime))
INSERT [dbo].[tblCLI_DocumentosCliente] ([id_documento_cliente], [id_documento], [id_precliente], [activo], [ruta_local], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion], [id_usuario_revision], [fecha_revision]) VALUES (61, 1, 19, 1, N'C:\inetpub\wwwroot\PortalClientes\Documentos\19\shoes1201871223355733.jpeg', CAST(N'2018-07-12T23:35:05.733' AS DateTime), N'admin', CAST(N'2018-07-12T23:35:05.733' AS DateTime), N'admin', NULL, NULL)
INSERT [dbo].[tblCLI_DocumentosCliente] ([id_documento_cliente], [id_documento], [id_precliente], [activo], [ruta_local], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion], [id_usuario_revision], [fecha_revision]) VALUES (62, 2, 19, 1, N'C:\inetpub\wwwroot\PortalClientes\Documentos\19\shoes12018712233519750.jpeg', CAST(N'2018-07-12T23:35:19.750' AS DateTime), N'admin', CAST(N'2018-07-12T23:35:19.750' AS DateTime), N'admin', NULL, NULL)
INSERT [dbo].[tblCLI_DocumentosCliente] ([id_documento_cliente], [id_documento], [id_precliente], [activo], [ruta_local], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion], [id_usuario_revision], [fecha_revision]) VALUES (63, 3, 19, 1, N'C:\inetpub\wwwroot\PortalClientes\Documentos\19\shoes12018712234340350.jpeg', CAST(N'2018-07-12T23:43:40.350' AS DateTime), N'admin', CAST(N'2018-07-12T23:43:40.350' AS DateTime), N'admin', NULL, NULL)
INSERT [dbo].[tblCLI_DocumentosCliente] ([id_documento_cliente], [id_documento], [id_precliente], [activo], [ruta_local], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion], [id_usuario_revision], [fecha_revision]) VALUES (64, 2, 1, 1, N'C:\portac\PortalCliente\PortalCliente.Web\Documentos\2\plantilla-reportes.pdf', CAST(N'2018-07-13T12:00:34.487' AS DateTime), N'test', CAST(N'2018-07-13T12:00:34.487' AS DateTime), N'testmod', N'2', CAST(N'2018-07-16T20:36:44.517' AS DateTime))
INSERT [dbo].[tblCLI_DocumentosCliente] ([id_documento_cliente], [id_documento], [id_precliente], [activo], [ruta_local], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion], [id_usuario_revision], [fecha_revision]) VALUES (68, 5, 20, 1, N'\Documentos\20\shoes1201871604242593.jpeg', CAST(N'2018-07-16T00:42:42.600' AS DateTime), N'admin', CAST(N'2018-07-16T00:42:42.600' AS DateTime), N'admin', NULL, NULL)
INSERT [dbo].[tblCLI_DocumentosCliente] ([id_documento_cliente], [id_documento], [id_precliente], [activo], [ruta_local], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion], [id_usuario_revision], [fecha_revision]) VALUES (69, 1, 20, 1, N'\Documentos\20\shoes12018716114635.jpeg', CAST(N'2018-07-16T01:01:46.040' AS DateTime), N'admin', CAST(N'2018-07-16T01:01:46.040' AS DateTime), N'admin', NULL, NULL)
INSERT [dbo].[tblCLI_DocumentosCliente] ([id_documento_cliente], [id_documento], [id_precliente], [activo], [ruta_local], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion], [id_usuario_revision], [fecha_revision]) VALUES (70, 6, 20, 1, N'\Documentos\20\234201871692714264.pdf', CAST(N'2018-07-16T09:27:14.267' AS DateTime), N'admin', CAST(N'2018-07-16T09:27:14.267' AS DateTime), N'admin', NULL, NULL)
INSERT [dbo].[tblCLI_DocumentosCliente] ([id_documento_cliente], [id_documento], [id_precliente], [activo], [ruta_local], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion], [id_usuario_revision], [fecha_revision]) VALUES (71, 7, 20, 1, N'\Documentos\20\C_ARCHIVO DE WORD CON NO18040910461220187169272291.pdf', CAST(N'2018-07-16T09:27:22.093' AS DateTime), N'admin', CAST(N'2018-07-16T09:27:22.093' AS DateTime), N'admin', NULL, NULL)
INSERT [dbo].[tblCLI_DocumentosCliente] ([id_documento_cliente], [id_documento], [id_precliente], [activo], [ruta_local], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion], [id_usuario_revision], [fecha_revision]) VALUES (72, 3, 26, 1, N'\Documentos\26\3246431920187161172418.pdf', CAST(N'2018-07-16T11:07:02.417' AS DateTime), N'admin', CAST(N'2018-07-16T11:07:02.417' AS DateTime), N'admin', NULL, NULL)
INSERT [dbo].[tblCLI_DocumentosCliente] ([id_documento_cliente], [id_documento], [id_precliente], [activo], [ruta_local], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion], [id_usuario_revision], [fecha_revision]) VALUES (73, 1, 29, 1, N'\Documentos\29\C_Demo_DS_NOM_1511804051028302018716155338476.pdf', CAST(N'2018-07-16T15:53:38.493' AS DateTime), N'admin', CAST(N'2018-07-16T15:53:38.493' AS DateTime), N'admin', N'73', CAST(N'2018-07-16T23:27:13.587' AS DateTime))
INSERT [dbo].[tblCLI_DocumentosCliente] ([id_documento_cliente], [id_documento], [id_precliente], [activo], [ruta_local], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion], [id_usuario_revision], [fecha_revision]) VALUES (74, 9, 29, 1, N'\Documentos\29\2342018716162555985.pdf', CAST(N'2018-07-16T16:25:55.987' AS DateTime), N'admin', CAST(N'2018-07-16T16:25:55.987' AS DateTime), N'admin', N'73', CAST(N'2018-07-16T23:27:13.587' AS DateTime))
INSERT [dbo].[tblCLI_DocumentosCliente] ([id_documento_cliente], [id_documento], [id_precliente], [activo], [ruta_local], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion], [id_usuario_revision], [fecha_revision]) VALUES (75, 8, 29, 1, N'\Documentos\29\2342018716171918745.pdf', CAST(N'2018-07-16T17:19:18.757' AS DateTime), N'admin', CAST(N'2018-07-16T17:19:18.757' AS DateTime), N'admin', N'73', CAST(N'2018-07-16T23:27:13.587' AS DateTime))
INSERT [dbo].[tblCLI_DocumentosCliente] ([id_documento_cliente], [id_documento], [id_precliente], [activo], [ruta_local], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion], [id_usuario_revision], [fecha_revision]) VALUES (76, 6, 29, 1, N'\Documentos\29\C_Demo_DS_NOM_15118032816075920187161719247.pdf', CAST(N'2018-07-16T17:19:24.010' AS DateTime), N'admin', CAST(N'2018-07-16T17:19:24.010' AS DateTime), N'admin', N'73', CAST(N'2018-07-16T23:27:13.587' AS DateTime))
INSERT [dbo].[tblCLI_DocumentosCliente] ([id_documento_cliente], [id_documento], [id_precliente], [activo], [ruta_local], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion], [id_usuario_revision], [fecha_revision]) VALUES (77, 5, 29, 1, N'\Documentos\29\Demo_DS_NOM_1512018716172225690.pdf', CAST(N'2018-07-16T17:22:25.697' AS DateTime), N'admin', CAST(N'2018-07-16T17:22:25.697' AS DateTime), N'admin', N'73', CAST(N'2018-07-16T23:27:13.587' AS DateTime))
INSERT [dbo].[tblCLI_DocumentosCliente] ([id_documento_cliente], [id_documento], [id_precliente], [activo], [ruta_local], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion], [id_usuario_revision], [fecha_revision]) VALUES (78, 10, 29, 1, N'\Documentos\29\shoes12018716192458726.jpeg', CAST(N'2018-07-16T19:24:58.767' AS DateTime), N'admin', CAST(N'2018-07-16T19:24:58.767' AS DateTime), N'admin', N'73', CAST(N'2018-07-16T23:27:13.587' AS DateTime))
INSERT [dbo].[tblCLI_DocumentosCliente] ([id_documento_cliente], [id_documento], [id_precliente], [activo], [ruta_local], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion], [id_usuario_revision], [fecha_revision]) VALUES (79, 1, 32, 1, N'\Documentos\32\Pruebas DODA Aduasis2018717115734645.docx', CAST(N'2018-07-17T11:57:34.660' AS DateTime), N'admin', CAST(N'2018-07-17T11:57:34.660' AS DateTime), N'admin', NULL, NULL)
INSERT [dbo].[tblCLI_DocumentosCliente] ([id_documento_cliente], [id_documento], [id_precliente], [activo], [ruta_local], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion], [id_usuario_revision], [fecha_revision]) VALUES (80, 2, 32, 1, N'\Documentos\32\Pruebas DODA Aduasis201871711585929.docx', CAST(N'2018-07-17T11:58:05.947' AS DateTime), N'admin', CAST(N'2018-07-17T11:58:05.947' AS DateTime), N'admin', NULL, NULL)
INSERT [dbo].[tblCLI_DocumentosCliente] ([id_documento_cliente], [id_documento], [id_precliente], [activo], [ruta_local], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion], [id_usuario_revision], [fecha_revision]) VALUES (81, 2, 2, 0, N'\Documentos\2\Introduccion-a-Xamarin-y-Xamarin.Forms_12018717184957472.pdf', CAST(N'2018-07-17T18:49:57.483' AS DateTime), N'admin', CAST(N'2018-07-17T18:49:57.483' AS DateTime), N'admin', NULL, NULL)
INSERT [dbo].[tblCLI_DocumentosCliente] ([id_documento_cliente], [id_documento], [id_precliente], [activo], [ruta_local], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion], [id_usuario_revision], [fecha_revision]) VALUES (82, 1, 2, 1, N'\Documentos\2\Introduccion-a-Xamarin-y-Xamarin.Forms_12018717191124341.pdf', CAST(N'2018-07-17T19:11:24.347' AS DateTime), N'admin', CAST(N'2018-07-17T19:11:24.347' AS DateTime), N'admin', NULL, NULL)
INSERT [dbo].[tblCLI_DocumentosCliente] ([id_documento_cliente], [id_documento], [id_precliente], [activo], [ruta_local], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion], [id_usuario_revision], [fecha_revision]) VALUES (83, 2, 2, 1, N'\Documentos\2\untitled2018717192748484.pdf', CAST(N'2018-07-17T19:27:48.487' AS DateTime), N'admin', CAST(N'2018-07-17T19:27:48.487' AS DateTime), N'admin', NULL, NULL)
SET IDENTITY_INSERT [dbo].[tblCLI_DocumentosCliente] OFF
SET IDENTITY_INSERT [dbo].[tblCLI_Estatus] ON 

INSERT [dbo].[tblCLI_Estatus] ([id_estatus], [estatus], [descripcion]) VALUES (1, 1, N'En registro')
INSERT [dbo].[tblCLI_Estatus] ([id_estatus], [estatus], [descripcion]) VALUES (2, 2, N'En captura')
INSERT [dbo].[tblCLI_Estatus] ([id_estatus], [estatus], [descripcion]) VALUES (3, 3, N'Para Aprobacion PreAlta')
INSERT [dbo].[tblCLI_Estatus] ([id_estatus], [estatus], [descripcion]) VALUES (4, 4, N'Revalidacion PreAlta')
INSERT [dbo].[tblCLI_Estatus] ([id_estatus], [estatus], [descripcion]) VALUES (5, 5, N'Aprobado sin procedimiento PreAlta')
INSERT [dbo].[tblCLI_Estatus] ([id_estatus], [estatus], [descripcion]) VALUES (6, 6, N'No Aprobado')
INSERT [dbo].[tblCLI_Estatus] ([id_estatus], [estatus], [descripcion]) VALUES (7, 7, N'Aprobado PreAlta')
INSERT [dbo].[tblCLI_Estatus] ([id_estatus], [estatus], [descripcion]) VALUES (8, 8, N'Cliente sin procedimiento')
INSERT [dbo].[tblCLI_Estatus] ([id_estatus], [estatus], [descripcion]) VALUES (9, 9, N'Cliente')
INSERT [dbo].[tblCLI_Estatus] ([id_estatus], [estatus], [descripcion]) VALUES (10, 10, N'Para aprobacion procedimiento Prealta')
INSERT [dbo].[tblCLI_Estatus] ([id_estatus], [estatus], [descripcion]) VALUES (11, 11, N'Para aprobacion procedimiento Cliente')
INSERT [dbo].[tblCLI_Estatus] ([id_estatus], [estatus], [descripcion]) VALUES (12, 12, N'Revalidacion procedimiento Prealta')
INSERT [dbo].[tblCLI_Estatus] ([id_estatus], [estatus], [descripcion]) VALUES (13, 13, N'Revalidacion procedimiento Cliente')
INSERT [dbo].[tblCLI_Estatus] ([id_estatus], [estatus], [descripcion]) VALUES (14, 14, N'Activo')
INSERT [dbo].[tblCLI_Estatus] ([id_estatus], [estatus], [descripcion]) VALUES (15, 15, N'Inactivo')
INSERT [dbo].[tblCLI_Estatus] ([id_estatus], [estatus], [descripcion]) VALUES (16, 16, N'Para aprobar actualización')
INSERT [dbo].[tblCLI_Estatus] ([id_estatus], [estatus], [descripcion]) VALUES (17, 17, N'Revalidación de actualización')
INSERT [dbo].[tblCLI_Estatus] ([id_estatus], [estatus], [descripcion]) VALUES (18, 18, N'Actualizado')
SET IDENTITY_INSERT [dbo].[tblCLI_Estatus] OFF
SET IDENTITY_INSERT [dbo].[tblCLI_Modulos] ON 

INSERT [dbo].[tblCLI_Modulos] ([id_modulo], [descripcion], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (13, N'Registro Cliente', CAST(N'2018-07-05T20:12:48.057' AS DateTime), N'admin', CAST(N'2018-07-05T20:12:48.057' AS DateTime), N'admin')
INSERT [dbo].[tblCLI_Modulos] ([id_modulo], [descripcion], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (14, N'Captura Cliente', CAST(N'2018-07-05T20:12:48.057' AS DateTime), N'admin', CAST(N'2018-07-05T20:12:48.057' AS DateTime), N'admin')
INSERT [dbo].[tblCLI_Modulos] ([id_modulo], [descripcion], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (15, N'Alta Cliente', CAST(N'2018-07-05T20:12:48.057' AS DateTime), N'admin', CAST(N'2018-07-05T20:12:48.057' AS DateTime), N'admin')
INSERT [dbo].[tblCLI_Modulos] ([id_modulo], [descripcion], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (16, N'Aprobación', CAST(N'2018-07-05T20:12:48.057' AS DateTime), N'admin', CAST(N'2018-07-05T20:12:48.057' AS DateTime), N'admin')
INSERT [dbo].[tblCLI_Modulos] ([id_modulo], [descripcion], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (17, N'Consultas', CAST(N'2018-07-05T20:12:48.057' AS DateTime), N'admin', CAST(N'2018-07-05T20:12:48.057' AS DateTime), N'admin')
INSERT [dbo].[tblCLI_Modulos] ([id_modulo], [descripcion], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (18, N'Actualizar Cliente', CAST(N'2018-07-05T20:12:48.057' AS DateTime), N'admin', CAST(N'2018-07-05T20:12:48.057' AS DateTime), N'admin')
INSERT [dbo].[tblCLI_Modulos] ([id_modulo], [descripcion], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (19, N'Impresiones', CAST(N'2018-07-05T20:12:48.057' AS DateTime), N'admin', CAST(N'2018-07-05T20:12:48.057' AS DateTime), N'admin')
SET IDENTITY_INSERT [dbo].[tblCLI_Modulos] OFF
SET IDENTITY_INSERT [dbo].[tblCLI_Notificaciones] ON 

INSERT [dbo].[tblCLI_Notificaciones] ([id_notificacion], [descripcion]) VALUES (1, N'Documentacion en proceso de revision')
INSERT [dbo].[tblCLI_Notificaciones] ([id_notificacion], [descripcion]) VALUES (2, N'Documentacion aceptada')
SET IDENTITY_INSERT [dbo].[tblCLI_Notificaciones] OFF
SET IDENTITY_INSERT [dbo].[tblCLI_NotificacionesUsuario] ON 

INSERT [dbo].[tblCLI_NotificacionesUsuario] ([id_notificacion_usuario], [id_notificacion], [activo], [de_rol], [para_rol], [de_id_usuario], [para_id_usuario], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (1, 1, 1, 3, 2, 77, 1, CAST(N'2018-07-05T02:08:13.290' AS DateTime), N'77', NULL, NULL)
SET IDENTITY_INSERT [dbo].[tblCLI_NotificacionesUsuario] OFF
INSERT [dbo].[tblCLI_Patentes] ([id_patente], [patente], [nombre], [direccion]) VALUES (1, N'3891', N'Carlos Miguel Reyes Simón', NULL)
INSERT [dbo].[tblCLI_Patentes] ([id_patente], [patente], [nombre], [direccion]) VALUES (2, N'3028', N'Manuel Ignacio de Unanue Rivero', NULL)
INSERT [dbo].[tblCLI_Patentes] ([id_patente], [patente], [nombre], [direccion]) VALUES (3, N'1693', N'Arturo García de la Cadena Pérez', NULL)
INSERT [dbo].[tblCLI_Patentes] ([id_patente], [patente], [nombre], [direccion]) VALUES (4, N'3438', N'Arnoldo Rafael Peña Palma', NULL)
INSERT [dbo].[tblCLI_Patentes] ([id_patente], [patente], [nombre], [direccion]) VALUES (5, N'3457', N'Eduardo Martiniano Villarreal Delgado', NULL)
SET IDENTITY_INSERT [dbo].[tblCLI_Preguntas] ON 

INSERT [dbo].[tblCLI_Preguntas] ([id_pregunta], [pregunta]) VALUES (1, N'¿Cuenta con certificación C-TPAT/CASCEM/BASC/NEEC o algún otro estándar en materia de seguridad?')
INSERT [dbo].[tblCLI_Preguntas] ([id_pregunta], [pregunta]) VALUES (2, N'¿Cuenta con alguna certificación de calidad, ambiental, seguridad o responsabilidad social?')
INSERT [dbo].[tblCLI_Preguntas] ([id_pregunta], [pregunta]) VALUES (3, N'¿Elabora análisis de riesgos periódicamente? (Se sugiere utilizar la técnica de evaluación de riesgos de la norma ISO 31000 e ISO 31010)')
INSERT [dbo].[tblCLI_Preguntas] ([id_pregunta], [pregunta]) VALUES (4, N'¿Realiza auditorias operativas y/o de seguridad de forma periódica?')
INSERT [dbo].[tblCLI_Preguntas] ([id_pregunta], [pregunta]) VALUES (5, N'¿Cuenta con planes de contingencia en caso de que alguna eventualidad ponga en riesgo su operación?')
INSERT [dbo].[tblCLI_Preguntas] ([id_pregunta], [pregunta]) VALUES (6, N'¿Realiza investigación y reportes de incidentes de seguridad?')
INSERT [dbo].[tblCLI_Preguntas] ([id_pregunta], [pregunta]) VALUES (7, N'¿Solicita documentación para verificar que sus proveedores o socios comerciales son confiables?')
INSERT [dbo].[tblCLI_Preguntas] ([id_pregunta], [pregunta]) VALUES (8, N'¿Su empresa verifica que las prácticas de sus proveedores o socios comerciales sean confiables, a través de visitas periódicas o alguna otra técnica de evaluación que lo garantice?')
INSERT [dbo].[tblCLI_Preguntas] ([id_pregunta], [pregunta]) VALUES (9, N'¿Su empresa cuenta con puertos de carga y descarga de contenedores, y realiza revisión de los contenedores previo a la carga o descarga para garantizar que sean seguros?')
INSERT [dbo].[tblCLI_Preguntas] ([id_pregunta], [pregunta]) VALUES (10, N'¿Cuenta con yarda de almacenamiento de cajas de tráiler y con seguridad mínima en esta área?')
INSERT [dbo].[tblCLI_Preguntas] ([id_pregunta], [pregunta]) VALUES (11, N'¿Cuenta con acceso controlados, tanto de personal como de visitantes? (Ya sea accesos magnéticos, candados o algún otro método de control)')
INSERT [dbo].[tblCLI_Preguntas] ([id_pregunta], [pregunta]) VALUES (12, N'¿Solicita carta de antecedentes no penales, estudio antidoping o algún otro tipo de estudio/examen que verifique la confiabilidad del personal a contratar o ya contratado?')
INSERT [dbo].[tblCLI_Preguntas] ([id_pregunta], [pregunta]) VALUES (13, N'¿Su empresa cuenta con procedimientos de verificación de la documentación emitida para recibo o envío de mercancía?')
INSERT [dbo].[tblCLI_Preguntas] ([id_pregunta], [pregunta]) VALUES (14, N'¿Realiza verificaciones periódicas de su documentación legal para realizar importaciones y/o exportaciones?')
INSERT [dbo].[tblCLI_Preguntas] ([id_pregunta], [pregunta]) VALUES (15, N'¿Su empresa cuenta con instalaciones con cercado perimetral, buena iluminación, área de estacionamiento, guardia de seguridad, cámaras y alarma de seguridad?')
INSERT [dbo].[tblCLI_Preguntas] ([id_pregunta], [pregunta]) VALUES (16, N'¿Se realiza alguna verificación periódica de las instalaciones? Favor de mencionar cada cuando')
INSERT [dbo].[tblCLI_Preguntas] ([id_pregunta], [pregunta]) VALUES (17, N'¿Implementa cursos de capacitación/entrenamiento al persona, en los cuales se haga difusión de la importancia de dar seguimiento a los procedimientos de seguridad de su empresa?')
INSERT [dbo].[tblCLI_Preguntas] ([id_pregunta], [pregunta]) VALUES (18, N'¿Sus equipos de cómputo cuentan con clave/contraseña de seguridad tanto para iniciar sesión como para tener acceso a sus sistemas operativos? (Se sugiere cambio trimestral o semestral para mejorar la seguridad de la información)')
INSERT [dbo].[tblCLI_Preguntas] ([id_pregunta], [pregunta]) VALUES (19, N'¿Cuenta con políticas para el uso de sistemas operativos/tecnológicos, así como con acciones disciplinarias contra el personal que no las haga cumplir?')
INSERT [dbo].[tblCLI_Preguntas] ([id_pregunta], [pregunta]) VALUES (20, N'¿Su empresa cuenta con pláticas para la protección de información sensible?')
SET IDENTITY_INSERT [dbo].[tblCLI_Preguntas] OFF
SET IDENTITY_INSERT [dbo].[tblCLI_Respuestas] ON 

INSERT [dbo].[tblCLI_Respuestas] ([id_respuesta], [id_pregunta], [id_precliente], [respuesta], [observacion], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (621, 1, 1, 1, N'observ1', CAST(N'2018-07-10T17:19:23.547' AS DateTime), N'2', NULL, NULL)
INSERT [dbo].[tblCLI_Respuestas] ([id_respuesta], [id_pregunta], [id_precliente], [respuesta], [observacion], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (622, 2, 1, 1, N'observ2', CAST(N'2018-07-10T17:19:23.560' AS DateTime), N'2', NULL, NULL)
INSERT [dbo].[tblCLI_Respuestas] ([id_respuesta], [id_pregunta], [id_precliente], [respuesta], [observacion], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (623, 3, 1, 1, N'observ3', CAST(N'2018-07-10T17:19:23.583' AS DateTime), N'2', NULL, NULL)
INSERT [dbo].[tblCLI_Respuestas] ([id_respuesta], [id_pregunta], [id_precliente], [respuesta], [observacion], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (624, 4, 1, 1, N'observ4', CAST(N'2018-07-10T17:19:23.603' AS DateTime), N'2', NULL, NULL)
INSERT [dbo].[tblCLI_Respuestas] ([id_respuesta], [id_pregunta], [id_precliente], [respuesta], [observacion], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (625, 5, 1, 1, N'observ5', CAST(N'2018-07-10T17:19:23.623' AS DateTime), N'2', NULL, NULL)
INSERT [dbo].[tblCLI_Respuestas] ([id_respuesta], [id_pregunta], [id_precliente], [respuesta], [observacion], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (626, 6, 1, 1, N'observ6', CAST(N'2018-07-10T17:19:23.633' AS DateTime), N'2', NULL, NULL)
INSERT [dbo].[tblCLI_Respuestas] ([id_respuesta], [id_pregunta], [id_precliente], [respuesta], [observacion], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (627, 7, 1, 1, N'observ7', CAST(N'2018-07-10T17:19:23.640' AS DateTime), N'2', NULL, NULL)
INSERT [dbo].[tblCLI_Respuestas] ([id_respuesta], [id_pregunta], [id_precliente], [respuesta], [observacion], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (628, 8, 1, 1, N'observ8', CAST(N'2018-07-10T17:19:23.650' AS DateTime), N'2', NULL, NULL)
INSERT [dbo].[tblCLI_Respuestas] ([id_respuesta], [id_pregunta], [id_precliente], [respuesta], [observacion], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (629, 9, 1, 1, N'observ9', CAST(N'2018-07-10T17:19:23.660' AS DateTime), N'2', NULL, NULL)
INSERT [dbo].[tblCLI_Respuestas] ([id_respuesta], [id_pregunta], [id_precliente], [respuesta], [observacion], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (630, 10, 1, 1, N'observ10', CAST(N'2018-07-10T17:19:23.667' AS DateTime), N'2', NULL, NULL)
INSERT [dbo].[tblCLI_Respuestas] ([id_respuesta], [id_pregunta], [id_precliente], [respuesta], [observacion], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (631, 11, 1, 1, N'observ11', CAST(N'2018-07-10T17:19:23.673' AS DateTime), N'2', NULL, NULL)
INSERT [dbo].[tblCLI_Respuestas] ([id_respuesta], [id_pregunta], [id_precliente], [respuesta], [observacion], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (632, 12, 1, 1, N'observ12', CAST(N'2018-07-10T17:19:23.683' AS DateTime), N'2', NULL, NULL)
INSERT [dbo].[tblCLI_Respuestas] ([id_respuesta], [id_pregunta], [id_precliente], [respuesta], [observacion], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (633, 13, 1, 1, N'observ13', CAST(N'2018-07-10T17:19:23.690' AS DateTime), N'2', NULL, NULL)
INSERT [dbo].[tblCLI_Respuestas] ([id_respuesta], [id_pregunta], [id_precliente], [respuesta], [observacion], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (634, 14, 1, 1, N'observ14', CAST(N'2018-07-10T17:19:23.700' AS DateTime), N'2', NULL, NULL)
INSERT [dbo].[tblCLI_Respuestas] ([id_respuesta], [id_pregunta], [id_precliente], [respuesta], [observacion], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (635, 15, 1, 1, N'observ15', CAST(N'2018-07-10T17:19:23.710' AS DateTime), N'2', NULL, NULL)
INSERT [dbo].[tblCLI_Respuestas] ([id_respuesta], [id_pregunta], [id_precliente], [respuesta], [observacion], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (636, 16, 1, 1, N'observ16', CAST(N'2018-07-10T17:19:23.717' AS DateTime), N'2', NULL, NULL)
INSERT [dbo].[tblCLI_Respuestas] ([id_respuesta], [id_pregunta], [id_precliente], [respuesta], [observacion], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (637, 17, 1, 1, N'observ17', CAST(N'2018-07-10T17:19:23.723' AS DateTime), N'2', NULL, NULL)
INSERT [dbo].[tblCLI_Respuestas] ([id_respuesta], [id_pregunta], [id_precliente], [respuesta], [observacion], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (638, 18, 1, 1, N'observ18', CAST(N'2018-07-10T17:19:23.733' AS DateTime), N'2', NULL, NULL)
INSERT [dbo].[tblCLI_Respuestas] ([id_respuesta], [id_pregunta], [id_precliente], [respuesta], [observacion], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (639, 19, 1, 1, N'observ19', CAST(N'2018-07-10T17:19:23.740' AS DateTime), N'2', NULL, NULL)
INSERT [dbo].[tblCLI_Respuestas] ([id_respuesta], [id_pregunta], [id_precliente], [respuesta], [observacion], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (640, 20, 1, 1, N'observ20', CAST(N'2018-07-10T17:19:23.750' AS DateTime), N'2', NULL, NULL)
INSERT [dbo].[tblCLI_Respuestas] ([id_respuesta], [id_pregunta], [id_precliente], [respuesta], [observacion], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (641, 1, 1, 1, N'observ1', CAST(N'2018-07-10T17:19:46.283' AS DateTime), N'2', NULL, NULL)
INSERT [dbo].[tblCLI_Respuestas] ([id_respuesta], [id_pregunta], [id_precliente], [respuesta], [observacion], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (642, 2, 1, 1, N'observ2', CAST(N'2018-07-10T17:19:46.303' AS DateTime), N'2', NULL, NULL)
INSERT [dbo].[tblCLI_Respuestas] ([id_respuesta], [id_pregunta], [id_precliente], [respuesta], [observacion], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (643, 3, 1, 1, N'observ3', CAST(N'2018-07-10T17:19:46.310' AS DateTime), N'2', NULL, NULL)
INSERT [dbo].[tblCLI_Respuestas] ([id_respuesta], [id_pregunta], [id_precliente], [respuesta], [observacion], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (644, 4, 1, 1, N'observ4', CAST(N'2018-07-10T17:19:46.320' AS DateTime), N'2', NULL, NULL)
INSERT [dbo].[tblCLI_Respuestas] ([id_respuesta], [id_pregunta], [id_precliente], [respuesta], [observacion], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (645, 5, 1, 1, N'observ5', CAST(N'2018-07-10T17:19:46.327' AS DateTime), N'2', NULL, NULL)
INSERT [dbo].[tblCLI_Respuestas] ([id_respuesta], [id_pregunta], [id_precliente], [respuesta], [observacion], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (646, 6, 1, 1, N'observ6', CAST(N'2018-07-10T17:19:46.337' AS DateTime), N'2', NULL, NULL)
INSERT [dbo].[tblCLI_Respuestas] ([id_respuesta], [id_pregunta], [id_precliente], [respuesta], [observacion], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (647, 7, 1, 1, N'observ7', CAST(N'2018-07-10T17:19:46.343' AS DateTime), N'2', NULL, NULL)
INSERT [dbo].[tblCLI_Respuestas] ([id_respuesta], [id_pregunta], [id_precliente], [respuesta], [observacion], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (648, 8, 1, 1, N'observ8', CAST(N'2018-07-10T17:19:46.353' AS DateTime), N'2', NULL, NULL)
INSERT [dbo].[tblCLI_Respuestas] ([id_respuesta], [id_pregunta], [id_precliente], [respuesta], [observacion], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (649, 9, 1, 1, N'observ9', CAST(N'2018-07-10T17:19:46.360' AS DateTime), N'2', NULL, NULL)
INSERT [dbo].[tblCLI_Respuestas] ([id_respuesta], [id_pregunta], [id_precliente], [respuesta], [observacion], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (650, 10, 1, 1, N'observ10', CAST(N'2018-07-10T17:19:46.370' AS DateTime), N'2', NULL, NULL)
INSERT [dbo].[tblCLI_Respuestas] ([id_respuesta], [id_pregunta], [id_precliente], [respuesta], [observacion], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (651, 11, 1, 1, N'observ11', CAST(N'2018-07-10T17:19:46.377' AS DateTime), N'2', NULL, NULL)
INSERT [dbo].[tblCLI_Respuestas] ([id_respuesta], [id_pregunta], [id_precliente], [respuesta], [observacion], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (652, 12, 1, 1, N'observ12', CAST(N'2018-07-10T17:19:46.387' AS DateTime), N'2', NULL, NULL)
INSERT [dbo].[tblCLI_Respuestas] ([id_respuesta], [id_pregunta], [id_precliente], [respuesta], [observacion], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (653, 13, 1, 1, N'observ13', CAST(N'2018-07-10T17:19:46.393' AS DateTime), N'2', NULL, NULL)
INSERT [dbo].[tblCLI_Respuestas] ([id_respuesta], [id_pregunta], [id_precliente], [respuesta], [observacion], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (654, 14, 1, 1, N'observ14', CAST(N'2018-07-10T17:19:46.403' AS DateTime), N'2', NULL, NULL)
INSERT [dbo].[tblCLI_Respuestas] ([id_respuesta], [id_pregunta], [id_precliente], [respuesta], [observacion], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (655, 15, 1, 1, N'observ15', CAST(N'2018-07-10T17:19:46.410' AS DateTime), N'2', NULL, NULL)
INSERT [dbo].[tblCLI_Respuestas] ([id_respuesta], [id_pregunta], [id_precliente], [respuesta], [observacion], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (656, 16, 1, 1, N'observ16', CAST(N'2018-07-10T17:19:46.420' AS DateTime), N'2', NULL, NULL)
INSERT [dbo].[tblCLI_Respuestas] ([id_respuesta], [id_pregunta], [id_precliente], [respuesta], [observacion], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (657, 17, 1, 1, N'observ17', CAST(N'2018-07-10T17:19:46.427' AS DateTime), N'2', NULL, NULL)
INSERT [dbo].[tblCLI_Respuestas] ([id_respuesta], [id_pregunta], [id_precliente], [respuesta], [observacion], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (658, 18, 1, 1, N'observ18', CAST(N'2018-07-10T17:19:46.437' AS DateTime), N'2', NULL, NULL)
INSERT [dbo].[tblCLI_Respuestas] ([id_respuesta], [id_pregunta], [id_precliente], [respuesta], [observacion], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (659, 19, 1, 1, N'observ19', CAST(N'2018-07-10T17:19:46.443' AS DateTime), N'2', NULL, NULL)
INSERT [dbo].[tblCLI_Respuestas] ([id_respuesta], [id_pregunta], [id_precliente], [respuesta], [observacion], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (660, 20, 1, 0, N'', CAST(N'2018-07-10T17:19:46.453' AS DateTime), N'2', NULL, NULL)
INSERT [dbo].[tblCLI_Respuestas] ([id_respuesta], [id_pregunta], [id_precliente], [respuesta], [observacion], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (661, 1, 1, 1, N'observ1', CAST(N'2018-07-10T17:20:02.770' AS DateTime), N'2', NULL, NULL)
INSERT [dbo].[tblCLI_Respuestas] ([id_respuesta], [id_pregunta], [id_precliente], [respuesta], [observacion], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (662, 2, 1, 1, N'observ2', CAST(N'2018-07-10T17:20:02.823' AS DateTime), N'2', NULL, NULL)
INSERT [dbo].[tblCLI_Respuestas] ([id_respuesta], [id_pregunta], [id_precliente], [respuesta], [observacion], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (663, 3, 1, 1, N'observ3', CAST(N'2018-07-10T17:20:02.830' AS DateTime), N'2', NULL, NULL)
INSERT [dbo].[tblCLI_Respuestas] ([id_respuesta], [id_pregunta], [id_precliente], [respuesta], [observacion], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (664, 4, 1, 1, N'observ4', CAST(N'2018-07-10T17:20:02.840' AS DateTime), N'2', NULL, NULL)
INSERT [dbo].[tblCLI_Respuestas] ([id_respuesta], [id_pregunta], [id_precliente], [respuesta], [observacion], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (665, 5, 1, 1, N'observ5', CAST(N'2018-07-10T17:20:02.847' AS DateTime), N'2', NULL, NULL)
INSERT [dbo].[tblCLI_Respuestas] ([id_respuesta], [id_pregunta], [id_precliente], [respuesta], [observacion], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (666, 6, 1, 1, N'observ6', CAST(N'2018-07-10T17:20:02.857' AS DateTime), N'2', NULL, NULL)
INSERT [dbo].[tblCLI_Respuestas] ([id_respuesta], [id_pregunta], [id_precliente], [respuesta], [observacion], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (667, 7, 1, 1, N'observ7', CAST(N'2018-07-10T17:20:02.863' AS DateTime), N'2', NULL, NULL)
INSERT [dbo].[tblCLI_Respuestas] ([id_respuesta], [id_pregunta], [id_precliente], [respuesta], [observacion], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (668, 8, 1, 1, N'observ8', CAST(N'2018-07-10T17:20:02.873' AS DateTime), N'2', NULL, NULL)
INSERT [dbo].[tblCLI_Respuestas] ([id_respuesta], [id_pregunta], [id_precliente], [respuesta], [observacion], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (669, 9, 1, 1, N'observ9', CAST(N'2018-07-10T17:20:02.880' AS DateTime), N'2', NULL, NULL)
INSERT [dbo].[tblCLI_Respuestas] ([id_respuesta], [id_pregunta], [id_precliente], [respuesta], [observacion], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (670, 10, 1, 1, N'observ10', CAST(N'2018-07-10T17:20:02.890' AS DateTime), N'2', NULL, NULL)
INSERT [dbo].[tblCLI_Respuestas] ([id_respuesta], [id_pregunta], [id_precliente], [respuesta], [observacion], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (671, 11, 1, 1, N'observ11', CAST(N'2018-07-10T17:20:02.897' AS DateTime), N'2', NULL, NULL)
INSERT [dbo].[tblCLI_Respuestas] ([id_respuesta], [id_pregunta], [id_precliente], [respuesta], [observacion], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (672, 12, 1, 1, N'observ12', CAST(N'2018-07-10T17:20:02.907' AS DateTime), N'2', NULL, NULL)
INSERT [dbo].[tblCLI_Respuestas] ([id_respuesta], [id_pregunta], [id_precliente], [respuesta], [observacion], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (673, 13, 1, 1, N'observ13', CAST(N'2018-07-10T17:20:02.913' AS DateTime), N'2', NULL, NULL)
INSERT [dbo].[tblCLI_Respuestas] ([id_respuesta], [id_pregunta], [id_precliente], [respuesta], [observacion], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (674, 14, 1, 1, N'observ14', CAST(N'2018-07-10T17:20:02.923' AS DateTime), N'2', NULL, NULL)
INSERT [dbo].[tblCLI_Respuestas] ([id_respuesta], [id_pregunta], [id_precliente], [respuesta], [observacion], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (675, 15, 1, 1, N'observ15', CAST(N'2018-07-10T17:20:02.930' AS DateTime), N'2', NULL, NULL)
INSERT [dbo].[tblCLI_Respuestas] ([id_respuesta], [id_pregunta], [id_precliente], [respuesta], [observacion], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (676, 16, 1, 1, N'observ16', CAST(N'2018-07-10T17:20:02.940' AS DateTime), N'2', NULL, NULL)
INSERT [dbo].[tblCLI_Respuestas] ([id_respuesta], [id_pregunta], [id_precliente], [respuesta], [observacion], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (677, 17, 1, 1, N'observ17', CAST(N'2018-07-10T17:20:02.947' AS DateTime), N'2', NULL, NULL)
INSERT [dbo].[tblCLI_Respuestas] ([id_respuesta], [id_pregunta], [id_precliente], [respuesta], [observacion], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (678, 18, 1, 1, N'observ18', CAST(N'2018-07-10T17:20:02.957' AS DateTime), N'2', NULL, NULL)
INSERT [dbo].[tblCLI_Respuestas] ([id_respuesta], [id_pregunta], [id_precliente], [respuesta], [observacion], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (679, 19, 1, 1, N'observ19', CAST(N'2018-07-10T17:20:02.963' AS DateTime), N'2', NULL, NULL)
INSERT [dbo].[tblCLI_Respuestas] ([id_respuesta], [id_pregunta], [id_precliente], [respuesta], [observacion], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (680, 20, 1, 1, N'45', CAST(N'2018-07-10T17:20:02.973' AS DateTime), N'2', NULL, NULL)
INSERT [dbo].[tblCLI_Respuestas] ([id_respuesta], [id_pregunta], [id_precliente], [respuesta], [observacion], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (681, 1, 15, 1, N'1', CAST(N'2018-07-11T12:20:11.357' AS DateTime), N'2', NULL, NULL)
INSERT [dbo].[tblCLI_Respuestas] ([id_respuesta], [id_pregunta], [id_precliente], [respuesta], [observacion], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (682, 2, 15, 1, N'2', CAST(N'2018-07-11T12:20:11.367' AS DateTime), N'2', NULL, NULL)
INSERT [dbo].[tblCLI_Respuestas] ([id_respuesta], [id_pregunta], [id_precliente], [respuesta], [observacion], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (683, 3, 15, 1, N'3', CAST(N'2018-07-11T12:20:11.373' AS DateTime), N'2', NULL, NULL)
INSERT [dbo].[tblCLI_Respuestas] ([id_respuesta], [id_pregunta], [id_precliente], [respuesta], [observacion], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (684, 4, 15, 1, N'4', CAST(N'2018-07-11T12:20:11.383' AS DateTime), N'2', NULL, NULL)
INSERT [dbo].[tblCLI_Respuestas] ([id_respuesta], [id_pregunta], [id_precliente], [respuesta], [observacion], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (685, 5, 15, 1, N'5', CAST(N'2018-07-11T12:20:11.390' AS DateTime), N'2', NULL, NULL)
INSERT [dbo].[tblCLI_Respuestas] ([id_respuesta], [id_pregunta], [id_precliente], [respuesta], [observacion], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (686, 6, 15, 1, N'6', CAST(N'2018-07-11T12:20:11.400' AS DateTime), N'2', NULL, NULL)
INSERT [dbo].[tblCLI_Respuestas] ([id_respuesta], [id_pregunta], [id_precliente], [respuesta], [observacion], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (687, 7, 15, 1, N'7', CAST(N'2018-07-11T12:20:11.410' AS DateTime), N'2', NULL, NULL)
INSERT [dbo].[tblCLI_Respuestas] ([id_respuesta], [id_pregunta], [id_precliente], [respuesta], [observacion], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (688, 8, 15, 1, N'8', CAST(N'2018-07-11T12:20:11.417' AS DateTime), N'2', NULL, NULL)
INSERT [dbo].[tblCLI_Respuestas] ([id_respuesta], [id_pregunta], [id_precliente], [respuesta], [observacion], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (689, 9, 15, 1, N'9', CAST(N'2018-07-11T12:20:11.423' AS DateTime), N'2', NULL, NULL)
INSERT [dbo].[tblCLI_Respuestas] ([id_respuesta], [id_pregunta], [id_precliente], [respuesta], [observacion], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (690, 10, 15, 1, N'10', CAST(N'2018-07-11T12:20:11.433' AS DateTime), N'2', NULL, NULL)
INSERT [dbo].[tblCLI_Respuestas] ([id_respuesta], [id_pregunta], [id_precliente], [respuesta], [observacion], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (691, 11, 15, 1, N'11', CAST(N'2018-07-11T12:20:11.440' AS DateTime), N'2', NULL, NULL)
INSERT [dbo].[tblCLI_Respuestas] ([id_respuesta], [id_pregunta], [id_precliente], [respuesta], [observacion], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (692, 12, 15, 1, N'12', CAST(N'2018-07-11T12:20:11.450' AS DateTime), N'2', NULL, NULL)
INSERT [dbo].[tblCLI_Respuestas] ([id_respuesta], [id_pregunta], [id_precliente], [respuesta], [observacion], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (693, 13, 15, 1, N'13', CAST(N'2018-07-11T12:20:11.460' AS DateTime), N'2', NULL, NULL)
INSERT [dbo].[tblCLI_Respuestas] ([id_respuesta], [id_pregunta], [id_precliente], [respuesta], [observacion], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (694, 14, 15, 1, N'14', CAST(N'2018-07-11T12:20:11.467' AS DateTime), N'2', NULL, NULL)
INSERT [dbo].[tblCLI_Respuestas] ([id_respuesta], [id_pregunta], [id_precliente], [respuesta], [observacion], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (695, 15, 15, 1, N'15', CAST(N'2018-07-11T12:20:11.473' AS DateTime), N'2', NULL, NULL)
INSERT [dbo].[tblCLI_Respuestas] ([id_respuesta], [id_pregunta], [id_precliente], [respuesta], [observacion], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (696, 16, 15, 1, N'16', CAST(N'2018-07-11T12:20:11.483' AS DateTime), N'2', NULL, NULL)
INSERT [dbo].[tblCLI_Respuestas] ([id_respuesta], [id_pregunta], [id_precliente], [respuesta], [observacion], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (697, 17, 15, 1, N'17', CAST(N'2018-07-11T12:20:11.490' AS DateTime), N'2', NULL, NULL)
INSERT [dbo].[tblCLI_Respuestas] ([id_respuesta], [id_pregunta], [id_precliente], [respuesta], [observacion], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (698, 18, 15, 1, N'18', CAST(N'2018-07-11T12:20:11.500' AS DateTime), N'2', NULL, NULL)
INSERT [dbo].[tblCLI_Respuestas] ([id_respuesta], [id_pregunta], [id_precliente], [respuesta], [observacion], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (699, 19, 15, 1, N'19', CAST(N'2018-07-11T12:20:11.510' AS DateTime), N'2', NULL, NULL)
INSERT [dbo].[tblCLI_Respuestas] ([id_respuesta], [id_pregunta], [id_precliente], [respuesta], [observacion], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (700, 20, 15, 1, N'20', CAST(N'2018-07-11T12:20:11.517' AS DateTime), N'2', NULL, NULL)
INSERT [dbo].[tblCLI_Respuestas] ([id_respuesta], [id_pregunta], [id_precliente], [respuesta], [observacion], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (701, 1, 1, 0, N'', CAST(N'2018-07-12T17:59:57.137' AS DateTime), N'2', NULL, NULL)
INSERT [dbo].[tblCLI_Respuestas] ([id_respuesta], [id_pregunta], [id_precliente], [respuesta], [observacion], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (702, 2, 1, 0, N'', CAST(N'2018-07-12T17:59:57.150' AS DateTime), N'2', NULL, NULL)
INSERT [dbo].[tblCLI_Respuestas] ([id_respuesta], [id_pregunta], [id_precliente], [respuesta], [observacion], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (703, 3, 1, 0, N'', CAST(N'2018-07-12T17:59:57.160' AS DateTime), N'2', NULL, NULL)
INSERT [dbo].[tblCLI_Respuestas] ([id_respuesta], [id_pregunta], [id_precliente], [respuesta], [observacion], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (704, 4, 1, 0, N'', CAST(N'2018-07-12T17:59:57.167' AS DateTime), N'2', NULL, NULL)
INSERT [dbo].[tblCLI_Respuestas] ([id_respuesta], [id_pregunta], [id_precliente], [respuesta], [observacion], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (705, 5, 1, 0, N'', CAST(N'2018-07-12T17:59:57.177' AS DateTime), N'2', NULL, NULL)
INSERT [dbo].[tblCLI_Respuestas] ([id_respuesta], [id_pregunta], [id_precliente], [respuesta], [observacion], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (706, 6, 1, 0, N'', CAST(N'2018-07-12T17:59:57.183' AS DateTime), N'2', NULL, NULL)
INSERT [dbo].[tblCLI_Respuestas] ([id_respuesta], [id_pregunta], [id_precliente], [respuesta], [observacion], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (707, 7, 1, 0, N'', CAST(N'2018-07-12T17:59:57.193' AS DateTime), N'2', NULL, NULL)
INSERT [dbo].[tblCLI_Respuestas] ([id_respuesta], [id_pregunta], [id_precliente], [respuesta], [observacion], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (708, 8, 1, 0, N'', CAST(N'2018-07-12T17:59:57.200' AS DateTime), N'2', NULL, NULL)
INSERT [dbo].[tblCLI_Respuestas] ([id_respuesta], [id_pregunta], [id_precliente], [respuesta], [observacion], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (709, 9, 1, 0, N'', CAST(N'2018-07-12T17:59:57.210' AS DateTime), N'2', NULL, NULL)
INSERT [dbo].[tblCLI_Respuestas] ([id_respuesta], [id_pregunta], [id_precliente], [respuesta], [observacion], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (710, 10, 1, 0, N'', CAST(N'2018-07-12T17:59:57.217' AS DateTime), N'2', NULL, NULL)
INSERT [dbo].[tblCLI_Respuestas] ([id_respuesta], [id_pregunta], [id_precliente], [respuesta], [observacion], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (711, 11, 1, 0, N'', CAST(N'2018-07-12T17:59:57.227' AS DateTime), N'2', NULL, NULL)
INSERT [dbo].[tblCLI_Respuestas] ([id_respuesta], [id_pregunta], [id_precliente], [respuesta], [observacion], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (712, 12, 1, 0, N'', CAST(N'2018-07-12T17:59:57.233' AS DateTime), N'2', NULL, NULL)
INSERT [dbo].[tblCLI_Respuestas] ([id_respuesta], [id_pregunta], [id_precliente], [respuesta], [observacion], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (713, 13, 1, 0, N'', CAST(N'2018-07-12T17:59:57.243' AS DateTime), N'2', NULL, NULL)
INSERT [dbo].[tblCLI_Respuestas] ([id_respuesta], [id_pregunta], [id_precliente], [respuesta], [observacion], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (714, 14, 1, 0, N'', CAST(N'2018-07-12T17:59:57.250' AS DateTime), N'2', NULL, NULL)
INSERT [dbo].[tblCLI_Respuestas] ([id_respuesta], [id_pregunta], [id_precliente], [respuesta], [observacion], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (715, 15, 1, 0, N'', CAST(N'2018-07-12T17:59:57.260' AS DateTime), N'2', NULL, NULL)
INSERT [dbo].[tblCLI_Respuestas] ([id_respuesta], [id_pregunta], [id_precliente], [respuesta], [observacion], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (716, 16, 1, 0, N'', CAST(N'2018-07-12T17:59:57.267' AS DateTime), N'2', NULL, NULL)
INSERT [dbo].[tblCLI_Respuestas] ([id_respuesta], [id_pregunta], [id_precliente], [respuesta], [observacion], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (717, 17, 1, 0, N'', CAST(N'2018-07-12T17:59:57.277' AS DateTime), N'2', NULL, NULL)
INSERT [dbo].[tblCLI_Respuestas] ([id_respuesta], [id_pregunta], [id_precliente], [respuesta], [observacion], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (718, 18, 1, 0, N'', CAST(N'2018-07-12T17:59:57.283' AS DateTime), N'2', NULL, NULL)
INSERT [dbo].[tblCLI_Respuestas] ([id_respuesta], [id_pregunta], [id_precliente], [respuesta], [observacion], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (719, 19, 1, 0, N'', CAST(N'2018-07-12T17:59:57.293' AS DateTime), N'2', NULL, NULL)
GO
INSERT [dbo].[tblCLI_Respuestas] ([id_respuesta], [id_pregunta], [id_precliente], [respuesta], [observacion], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (720, 20, 1, 0, N'', CAST(N'2018-07-12T17:59:57.300' AS DateTime), N'2', NULL, NULL)
INSERT [dbo].[tblCLI_Respuestas] ([id_respuesta], [id_pregunta], [id_precliente], [respuesta], [observacion], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (721, 1, 1, 0, N'', CAST(N'2018-07-12T18:00:23.050' AS DateTime), N'2', NULL, NULL)
INSERT [dbo].[tblCLI_Respuestas] ([id_respuesta], [id_pregunta], [id_precliente], [respuesta], [observacion], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (722, 2, 1, 0, N'', CAST(N'2018-07-12T18:00:23.070' AS DateTime), N'2', NULL, NULL)
INSERT [dbo].[tblCLI_Respuestas] ([id_respuesta], [id_pregunta], [id_precliente], [respuesta], [observacion], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (723, 3, 1, 0, N'', CAST(N'2018-07-12T18:00:23.077' AS DateTime), N'2', NULL, NULL)
INSERT [dbo].[tblCLI_Respuestas] ([id_respuesta], [id_pregunta], [id_precliente], [respuesta], [observacion], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (724, 4, 1, 0, N'', CAST(N'2018-07-12T18:00:23.083' AS DateTime), N'2', NULL, NULL)
INSERT [dbo].[tblCLI_Respuestas] ([id_respuesta], [id_pregunta], [id_precliente], [respuesta], [observacion], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (725, 5, 1, 0, N'', CAST(N'2018-07-12T18:00:23.093' AS DateTime), N'2', NULL, NULL)
INSERT [dbo].[tblCLI_Respuestas] ([id_respuesta], [id_pregunta], [id_precliente], [respuesta], [observacion], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (726, 6, 1, 0, N'', CAST(N'2018-07-12T18:00:23.100' AS DateTime), N'2', NULL, NULL)
INSERT [dbo].[tblCLI_Respuestas] ([id_respuesta], [id_pregunta], [id_precliente], [respuesta], [observacion], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (727, 7, 1, 0, N'', CAST(N'2018-07-12T18:00:23.110' AS DateTime), N'2', NULL, NULL)
INSERT [dbo].[tblCLI_Respuestas] ([id_respuesta], [id_pregunta], [id_precliente], [respuesta], [observacion], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (728, 8, 1, 0, N'', CAST(N'2018-07-12T18:00:23.120' AS DateTime), N'2', NULL, NULL)
INSERT [dbo].[tblCLI_Respuestas] ([id_respuesta], [id_pregunta], [id_precliente], [respuesta], [observacion], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (729, 9, 1, 0, N'', CAST(N'2018-07-12T18:00:23.127' AS DateTime), N'2', NULL, NULL)
INSERT [dbo].[tblCLI_Respuestas] ([id_respuesta], [id_pregunta], [id_precliente], [respuesta], [observacion], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (730, 10, 1, 0, N'', CAST(N'2018-07-12T18:00:23.137' AS DateTime), N'2', NULL, NULL)
INSERT [dbo].[tblCLI_Respuestas] ([id_respuesta], [id_pregunta], [id_precliente], [respuesta], [observacion], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (731, 11, 1, 0, N'', CAST(N'2018-07-12T18:00:23.143' AS DateTime), N'2', NULL, NULL)
INSERT [dbo].[tblCLI_Respuestas] ([id_respuesta], [id_pregunta], [id_precliente], [respuesta], [observacion], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (732, 12, 1, 0, N'', CAST(N'2018-07-12T18:00:23.150' AS DateTime), N'2', NULL, NULL)
INSERT [dbo].[tblCLI_Respuestas] ([id_respuesta], [id_pregunta], [id_precliente], [respuesta], [observacion], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (733, 13, 1, 0, N'', CAST(N'2018-07-12T18:00:23.160' AS DateTime), N'2', NULL, NULL)
INSERT [dbo].[tblCLI_Respuestas] ([id_respuesta], [id_pregunta], [id_precliente], [respuesta], [observacion], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (734, 14, 1, 0, N'', CAST(N'2018-07-12T18:00:23.170' AS DateTime), N'2', NULL, NULL)
INSERT [dbo].[tblCLI_Respuestas] ([id_respuesta], [id_pregunta], [id_precliente], [respuesta], [observacion], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (735, 15, 1, 0, N'', CAST(N'2018-07-12T18:00:23.177' AS DateTime), N'2', NULL, NULL)
INSERT [dbo].[tblCLI_Respuestas] ([id_respuesta], [id_pregunta], [id_precliente], [respuesta], [observacion], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (736, 16, 1, 0, N'', CAST(N'2018-07-12T18:00:23.187' AS DateTime), N'2', NULL, NULL)
INSERT [dbo].[tblCLI_Respuestas] ([id_respuesta], [id_pregunta], [id_precliente], [respuesta], [observacion], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (737, 17, 1, 0, N'', CAST(N'2018-07-12T18:00:23.193' AS DateTime), N'2', NULL, NULL)
INSERT [dbo].[tblCLI_Respuestas] ([id_respuesta], [id_pregunta], [id_precliente], [respuesta], [observacion], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (738, 18, 1, 0, N'', CAST(N'2018-07-12T18:00:23.200' AS DateTime), N'2', NULL, NULL)
INSERT [dbo].[tblCLI_Respuestas] ([id_respuesta], [id_pregunta], [id_precliente], [respuesta], [observacion], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (739, 19, 1, 0, N'', CAST(N'2018-07-12T18:00:23.210' AS DateTime), N'2', NULL, NULL)
INSERT [dbo].[tblCLI_Respuestas] ([id_respuesta], [id_pregunta], [id_precliente], [respuesta], [observacion], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (740, 20, 1, 0, N'', CAST(N'2018-07-12T18:00:23.220' AS DateTime), N'2', NULL, NULL)
INSERT [dbo].[tblCLI_Respuestas] ([id_respuesta], [id_pregunta], [id_precliente], [respuesta], [observacion], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (741, 1, 1, 0, N'', CAST(N'2018-07-12T18:01:30.913' AS DateTime), N'2', NULL, NULL)
INSERT [dbo].[tblCLI_Respuestas] ([id_respuesta], [id_pregunta], [id_precliente], [respuesta], [observacion], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (742, 2, 1, 0, N'', CAST(N'2018-07-12T18:01:30.930' AS DateTime), N'2', NULL, NULL)
INSERT [dbo].[tblCLI_Respuestas] ([id_respuesta], [id_pregunta], [id_precliente], [respuesta], [observacion], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (743, 3, 1, 0, N'', CAST(N'2018-07-12T18:01:30.940' AS DateTime), N'2', NULL, NULL)
INSERT [dbo].[tblCLI_Respuestas] ([id_respuesta], [id_pregunta], [id_precliente], [respuesta], [observacion], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (744, 4, 1, 0, N'', CAST(N'2018-07-12T18:01:30.947' AS DateTime), N'2', NULL, NULL)
INSERT [dbo].[tblCLI_Respuestas] ([id_respuesta], [id_pregunta], [id_precliente], [respuesta], [observacion], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (745, 5, 1, 0, N'', CAST(N'2018-07-12T18:01:30.957' AS DateTime), N'2', NULL, NULL)
INSERT [dbo].[tblCLI_Respuestas] ([id_respuesta], [id_pregunta], [id_precliente], [respuesta], [observacion], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (746, 6, 1, 0, N'', CAST(N'2018-07-12T18:01:30.963' AS DateTime), N'2', NULL, NULL)
INSERT [dbo].[tblCLI_Respuestas] ([id_respuesta], [id_pregunta], [id_precliente], [respuesta], [observacion], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (747, 7, 1, 0, N'', CAST(N'2018-07-12T18:01:30.973' AS DateTime), N'2', NULL, NULL)
INSERT [dbo].[tblCLI_Respuestas] ([id_respuesta], [id_pregunta], [id_precliente], [respuesta], [observacion], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (748, 8, 1, 0, N'', CAST(N'2018-07-12T18:01:30.980' AS DateTime), N'2', NULL, NULL)
INSERT [dbo].[tblCLI_Respuestas] ([id_respuesta], [id_pregunta], [id_precliente], [respuesta], [observacion], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (749, 9, 1, 0, N'', CAST(N'2018-07-12T18:01:30.990' AS DateTime), N'2', NULL, NULL)
INSERT [dbo].[tblCLI_Respuestas] ([id_respuesta], [id_pregunta], [id_precliente], [respuesta], [observacion], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (750, 10, 1, 0, N'', CAST(N'2018-07-12T18:01:30.997' AS DateTime), N'2', NULL, NULL)
INSERT [dbo].[tblCLI_Respuestas] ([id_respuesta], [id_pregunta], [id_precliente], [respuesta], [observacion], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (751, 11, 1, 0, N'', CAST(N'2018-07-12T18:01:31.007' AS DateTime), N'2', NULL, NULL)
INSERT [dbo].[tblCLI_Respuestas] ([id_respuesta], [id_pregunta], [id_precliente], [respuesta], [observacion], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (752, 12, 1, 0, N'', CAST(N'2018-07-12T18:01:31.013' AS DateTime), N'2', NULL, NULL)
INSERT [dbo].[tblCLI_Respuestas] ([id_respuesta], [id_pregunta], [id_precliente], [respuesta], [observacion], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (753, 13, 1, 0, N'', CAST(N'2018-07-12T18:01:31.023' AS DateTime), N'2', NULL, NULL)
INSERT [dbo].[tblCLI_Respuestas] ([id_respuesta], [id_pregunta], [id_precliente], [respuesta], [observacion], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (754, 14, 1, 0, N'', CAST(N'2018-07-12T18:01:31.030' AS DateTime), N'2', NULL, NULL)
INSERT [dbo].[tblCLI_Respuestas] ([id_respuesta], [id_pregunta], [id_precliente], [respuesta], [observacion], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (755, 15, 1, 0, N'', CAST(N'2018-07-12T18:01:31.040' AS DateTime), N'2', NULL, NULL)
INSERT [dbo].[tblCLI_Respuestas] ([id_respuesta], [id_pregunta], [id_precliente], [respuesta], [observacion], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (756, 16, 1, 0, N'', CAST(N'2018-07-12T18:01:31.047' AS DateTime), N'2', NULL, NULL)
INSERT [dbo].[tblCLI_Respuestas] ([id_respuesta], [id_pregunta], [id_precliente], [respuesta], [observacion], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (757, 17, 1, 0, N'', CAST(N'2018-07-12T18:01:31.057' AS DateTime), N'2', NULL, NULL)
INSERT [dbo].[tblCLI_Respuestas] ([id_respuesta], [id_pregunta], [id_precliente], [respuesta], [observacion], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (758, 18, 1, 0, N'', CAST(N'2018-07-12T18:01:31.063' AS DateTime), N'2', NULL, NULL)
INSERT [dbo].[tblCLI_Respuestas] ([id_respuesta], [id_pregunta], [id_precliente], [respuesta], [observacion], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (759, 19, 1, 0, N'', CAST(N'2018-07-12T18:01:31.073' AS DateTime), N'2', NULL, NULL)
INSERT [dbo].[tblCLI_Respuestas] ([id_respuesta], [id_pregunta], [id_precliente], [respuesta], [observacion], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (760, 20, 1, 0, N'', CAST(N'2018-07-12T18:01:31.080' AS DateTime), N'2', NULL, NULL)
INSERT [dbo].[tblCLI_Respuestas] ([id_respuesta], [id_pregunta], [id_precliente], [respuesta], [observacion], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (761, 1, 1, 0, N'3weew', CAST(N'2018-07-12T20:20:40.827' AS DateTime), N'2', NULL, NULL)
INSERT [dbo].[tblCLI_Respuestas] ([id_respuesta], [id_pregunta], [id_precliente], [respuesta], [observacion], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (762, 2, 1, 0, N'we', CAST(N'2018-07-12T20:20:40.840' AS DateTime), N'2', NULL, NULL)
INSERT [dbo].[tblCLI_Respuestas] ([id_respuesta], [id_pregunta], [id_precliente], [respuesta], [observacion], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (763, 3, 1, 0, N'we', CAST(N'2018-07-12T20:20:40.850' AS DateTime), N'2', NULL, NULL)
INSERT [dbo].[tblCLI_Respuestas] ([id_respuesta], [id_pregunta], [id_precliente], [respuesta], [observacion], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (764, 4, 1, 0, N'', CAST(N'2018-07-12T20:20:40.857' AS DateTime), N'2', NULL, NULL)
INSERT [dbo].[tblCLI_Respuestas] ([id_respuesta], [id_pregunta], [id_precliente], [respuesta], [observacion], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (765, 5, 1, 0, N'', CAST(N'2018-07-12T20:20:40.867' AS DateTime), N'2', NULL, NULL)
INSERT [dbo].[tblCLI_Respuestas] ([id_respuesta], [id_pregunta], [id_precliente], [respuesta], [observacion], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (766, 6, 1, 0, N'', CAST(N'2018-07-12T20:20:40.873' AS DateTime), N'2', NULL, NULL)
INSERT [dbo].[tblCLI_Respuestas] ([id_respuesta], [id_pregunta], [id_precliente], [respuesta], [observacion], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (767, 7, 1, 0, N'', CAST(N'2018-07-12T20:20:40.883' AS DateTime), N'2', NULL, NULL)
INSERT [dbo].[tblCLI_Respuestas] ([id_respuesta], [id_pregunta], [id_precliente], [respuesta], [observacion], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (768, 8, 1, 0, N'', CAST(N'2018-07-12T20:20:40.890' AS DateTime), N'2', NULL, NULL)
INSERT [dbo].[tblCLI_Respuestas] ([id_respuesta], [id_pregunta], [id_precliente], [respuesta], [observacion], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (769, 9, 1, 0, N'', CAST(N'2018-07-12T20:20:40.900' AS DateTime), N'2', NULL, NULL)
INSERT [dbo].[tblCLI_Respuestas] ([id_respuesta], [id_pregunta], [id_precliente], [respuesta], [observacion], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (770, 10, 1, 0, N'', CAST(N'2018-07-12T20:20:40.907' AS DateTime), N'2', NULL, NULL)
INSERT [dbo].[tblCLI_Respuestas] ([id_respuesta], [id_pregunta], [id_precliente], [respuesta], [observacion], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (771, 11, 1, 0, N'', CAST(N'2018-07-12T20:20:40.917' AS DateTime), N'2', NULL, NULL)
INSERT [dbo].[tblCLI_Respuestas] ([id_respuesta], [id_pregunta], [id_precliente], [respuesta], [observacion], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (772, 12, 1, 0, N'', CAST(N'2018-07-12T20:20:40.923' AS DateTime), N'2', NULL, NULL)
INSERT [dbo].[tblCLI_Respuestas] ([id_respuesta], [id_pregunta], [id_precliente], [respuesta], [observacion], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (773, 13, 1, 0, N'', CAST(N'2018-07-12T20:20:40.933' AS DateTime), N'2', NULL, NULL)
INSERT [dbo].[tblCLI_Respuestas] ([id_respuesta], [id_pregunta], [id_precliente], [respuesta], [observacion], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (774, 14, 1, 0, N'', CAST(N'2018-07-12T20:20:40.940' AS DateTime), N'2', NULL, NULL)
INSERT [dbo].[tblCLI_Respuestas] ([id_respuesta], [id_pregunta], [id_precliente], [respuesta], [observacion], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (775, 15, 1, 0, N'', CAST(N'2018-07-12T20:20:40.950' AS DateTime), N'2', NULL, NULL)
INSERT [dbo].[tblCLI_Respuestas] ([id_respuesta], [id_pregunta], [id_precliente], [respuesta], [observacion], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (776, 16, 1, 0, N'', CAST(N'2018-07-12T20:20:40.957' AS DateTime), N'2', NULL, NULL)
INSERT [dbo].[tblCLI_Respuestas] ([id_respuesta], [id_pregunta], [id_precliente], [respuesta], [observacion], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (777, 17, 1, 0, N'', CAST(N'2018-07-12T20:20:40.967' AS DateTime), N'2', NULL, NULL)
INSERT [dbo].[tblCLI_Respuestas] ([id_respuesta], [id_pregunta], [id_precliente], [respuesta], [observacion], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (778, 18, 1, 0, N'', CAST(N'2018-07-12T20:20:40.973' AS DateTime), N'2', NULL, NULL)
INSERT [dbo].[tblCLI_Respuestas] ([id_respuesta], [id_pregunta], [id_precliente], [respuesta], [observacion], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (779, 19, 1, 0, N'', CAST(N'2018-07-12T20:20:40.983' AS DateTime), N'2', NULL, NULL)
INSERT [dbo].[tblCLI_Respuestas] ([id_respuesta], [id_pregunta], [id_precliente], [respuesta], [observacion], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (780, 20, 1, 0, N'', CAST(N'2018-07-12T20:20:40.990' AS DateTime), N'2', NULL, NULL)
INSERT [dbo].[tblCLI_Respuestas] ([id_respuesta], [id_pregunta], [id_precliente], [respuesta], [observacion], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (941, 1, 1, 0, N'', CAST(N'2018-07-16T00:59:14.230' AS DateTime), N'2', NULL, NULL)
INSERT [dbo].[tblCLI_Respuestas] ([id_respuesta], [id_pregunta], [id_precliente], [respuesta], [observacion], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (942, 2, 1, 0, N'', CAST(N'2018-07-16T00:59:14.257' AS DateTime), N'2', NULL, NULL)
INSERT [dbo].[tblCLI_Respuestas] ([id_respuesta], [id_pregunta], [id_precliente], [respuesta], [observacion], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (943, 3, 1, 0, N'', CAST(N'2018-07-16T00:59:14.267' AS DateTime), N'2', NULL, NULL)
INSERT [dbo].[tblCLI_Respuestas] ([id_respuesta], [id_pregunta], [id_precliente], [respuesta], [observacion], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (944, 4, 1, 0, N'', CAST(N'2018-07-16T00:59:14.273' AS DateTime), N'2', NULL, NULL)
INSERT [dbo].[tblCLI_Respuestas] ([id_respuesta], [id_pregunta], [id_precliente], [respuesta], [observacion], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (945, 5, 1, 0, N'', CAST(N'2018-07-16T00:59:14.280' AS DateTime), N'2', NULL, NULL)
INSERT [dbo].[tblCLI_Respuestas] ([id_respuesta], [id_pregunta], [id_precliente], [respuesta], [observacion], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (946, 6, 1, 0, N'', CAST(N'2018-07-16T00:59:14.290' AS DateTime), N'2', NULL, NULL)
INSERT [dbo].[tblCLI_Respuestas] ([id_respuesta], [id_pregunta], [id_precliente], [respuesta], [observacion], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (947, 7, 1, 0, N'', CAST(N'2018-07-16T00:59:14.300' AS DateTime), N'2', NULL, NULL)
INSERT [dbo].[tblCLI_Respuestas] ([id_respuesta], [id_pregunta], [id_precliente], [respuesta], [observacion], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (948, 8, 1, 0, N'', CAST(N'2018-07-16T00:59:14.307' AS DateTime), N'2', NULL, NULL)
INSERT [dbo].[tblCLI_Respuestas] ([id_respuesta], [id_pregunta], [id_precliente], [respuesta], [observacion], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (949, 9, 1, 0, N'', CAST(N'2018-07-16T00:59:14.317' AS DateTime), N'2', NULL, NULL)
INSERT [dbo].[tblCLI_Respuestas] ([id_respuesta], [id_pregunta], [id_precliente], [respuesta], [observacion], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (950, 10, 1, 0, N'', CAST(N'2018-07-16T00:59:14.323' AS DateTime), N'2', NULL, NULL)
INSERT [dbo].[tblCLI_Respuestas] ([id_respuesta], [id_pregunta], [id_precliente], [respuesta], [observacion], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (951, 11, 1, 0, N'', CAST(N'2018-07-16T00:59:14.330' AS DateTime), N'2', NULL, NULL)
INSERT [dbo].[tblCLI_Respuestas] ([id_respuesta], [id_pregunta], [id_precliente], [respuesta], [observacion], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (952, 12, 1, 0, N'', CAST(N'2018-07-16T00:59:14.340' AS DateTime), N'2', NULL, NULL)
INSERT [dbo].[tblCLI_Respuestas] ([id_respuesta], [id_pregunta], [id_precliente], [respuesta], [observacion], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (953, 13, 1, 0, N'', CAST(N'2018-07-16T00:59:14.350' AS DateTime), N'2', NULL, NULL)
INSERT [dbo].[tblCLI_Respuestas] ([id_respuesta], [id_pregunta], [id_precliente], [respuesta], [observacion], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (954, 14, 1, 0, N'', CAST(N'2018-07-16T00:59:14.357' AS DateTime), N'2', NULL, NULL)
INSERT [dbo].[tblCLI_Respuestas] ([id_respuesta], [id_pregunta], [id_precliente], [respuesta], [observacion], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (955, 15, 1, 0, N'', CAST(N'2018-07-16T00:59:14.367' AS DateTime), N'2', NULL, NULL)
INSERT [dbo].[tblCLI_Respuestas] ([id_respuesta], [id_pregunta], [id_precliente], [respuesta], [observacion], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (956, 16, 1, 0, N'', CAST(N'2018-07-16T00:59:14.373' AS DateTime), N'2', NULL, NULL)
INSERT [dbo].[tblCLI_Respuestas] ([id_respuesta], [id_pregunta], [id_precliente], [respuesta], [observacion], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (957, 17, 1, 0, N'', CAST(N'2018-07-16T00:59:14.380' AS DateTime), N'2', NULL, NULL)
INSERT [dbo].[tblCLI_Respuestas] ([id_respuesta], [id_pregunta], [id_precliente], [respuesta], [observacion], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (958, 18, 1, 0, N'', CAST(N'2018-07-16T00:59:14.390' AS DateTime), N'2', NULL, NULL)
INSERT [dbo].[tblCLI_Respuestas] ([id_respuesta], [id_pregunta], [id_precliente], [respuesta], [observacion], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (959, 19, 1, 0, N'', CAST(N'2018-07-16T00:59:14.400' AS DateTime), N'2', NULL, NULL)
INSERT [dbo].[tblCLI_Respuestas] ([id_respuesta], [id_pregunta], [id_precliente], [respuesta], [observacion], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (960, 20, 1, 0, N'', CAST(N'2018-07-16T00:59:14.407' AS DateTime), N'2', NULL, NULL)
INSERT [dbo].[tblCLI_Respuestas] ([id_respuesta], [id_pregunta], [id_precliente], [respuesta], [observacion], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (1001, 1, 26, 1, N'dede', CAST(N'2018-07-16T10:58:53.703' AS DateTime), N'69', NULL, NULL)
INSERT [dbo].[tblCLI_Respuestas] ([id_respuesta], [id_pregunta], [id_precliente], [respuesta], [observacion], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (1002, 2, 26, 1, N'dede', CAST(N'2018-07-16T10:58:53.730' AS DateTime), N'69', NULL, NULL)
INSERT [dbo].[tblCLI_Respuestas] ([id_respuesta], [id_pregunta], [id_precliente], [respuesta], [observacion], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (1003, 3, 26, 0, N'', CAST(N'2018-07-16T10:58:53.737' AS DateTime), N'69', NULL, NULL)
INSERT [dbo].[tblCLI_Respuestas] ([id_respuesta], [id_pregunta], [id_precliente], [respuesta], [observacion], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (1004, 4, 26, 0, N'', CAST(N'2018-07-16T10:58:53.747' AS DateTime), N'69', NULL, NULL)
INSERT [dbo].[tblCLI_Respuestas] ([id_respuesta], [id_pregunta], [id_precliente], [respuesta], [observacion], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (1005, 5, 26, 0, N'', CAST(N'2018-07-16T10:58:53.753' AS DateTime), N'69', NULL, NULL)
INSERT [dbo].[tblCLI_Respuestas] ([id_respuesta], [id_pregunta], [id_precliente], [respuesta], [observacion], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (1006, 6, 26, 0, N'', CAST(N'2018-07-16T10:58:53.763' AS DateTime), N'69', NULL, NULL)
INSERT [dbo].[tblCLI_Respuestas] ([id_respuesta], [id_pregunta], [id_precliente], [respuesta], [observacion], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (1007, 7, 26, 0, N'', CAST(N'2018-07-16T10:58:53.770' AS DateTime), N'69', NULL, NULL)
INSERT [dbo].[tblCLI_Respuestas] ([id_respuesta], [id_pregunta], [id_precliente], [respuesta], [observacion], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (1008, 8, 26, 0, N'', CAST(N'2018-07-16T10:58:53.780' AS DateTime), N'69', NULL, NULL)
INSERT [dbo].[tblCLI_Respuestas] ([id_respuesta], [id_pregunta], [id_precliente], [respuesta], [observacion], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (1009, 9, 26, 1, N'dede', CAST(N'2018-07-16T10:58:53.787' AS DateTime), N'69', NULL, NULL)
INSERT [dbo].[tblCLI_Respuestas] ([id_respuesta], [id_pregunta], [id_precliente], [respuesta], [observacion], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (1010, 10, 26, 0, N'', CAST(N'2018-07-16T10:58:53.797' AS DateTime), N'69', NULL, NULL)
INSERT [dbo].[tblCLI_Respuestas] ([id_respuesta], [id_pregunta], [id_precliente], [respuesta], [observacion], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (1011, 11, 26, 0, N'', CAST(N'2018-07-16T10:58:53.803' AS DateTime), N'69', NULL, NULL)
INSERT [dbo].[tblCLI_Respuestas] ([id_respuesta], [id_pregunta], [id_precliente], [respuesta], [observacion], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (1012, 12, 26, 0, N'', CAST(N'2018-07-16T10:58:53.813' AS DateTime), N'69', NULL, NULL)
INSERT [dbo].[tblCLI_Respuestas] ([id_respuesta], [id_pregunta], [id_precliente], [respuesta], [observacion], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (1013, 13, 26, 0, N'', CAST(N'2018-07-16T10:58:53.820' AS DateTime), N'69', NULL, NULL)
INSERT [dbo].[tblCLI_Respuestas] ([id_respuesta], [id_pregunta], [id_precliente], [respuesta], [observacion], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (1014, 14, 26, 0, N'', CAST(N'2018-07-16T10:58:53.830' AS DateTime), N'69', NULL, NULL)
INSERT [dbo].[tblCLI_Respuestas] ([id_respuesta], [id_pregunta], [id_precliente], [respuesta], [observacion], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (1015, 15, 26, 0, N'', CAST(N'2018-07-16T10:58:53.837' AS DateTime), N'69', NULL, NULL)
INSERT [dbo].[tblCLI_Respuestas] ([id_respuesta], [id_pregunta], [id_precliente], [respuesta], [observacion], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (1016, 16, 26, 0, N'', CAST(N'2018-07-16T10:58:53.867' AS DateTime), N'69', NULL, NULL)
INSERT [dbo].[tblCLI_Respuestas] ([id_respuesta], [id_pregunta], [id_precliente], [respuesta], [observacion], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (1017, 17, 26, 0, N'', CAST(N'2018-07-16T10:58:53.877' AS DateTime), N'69', NULL, NULL)
INSERT [dbo].[tblCLI_Respuestas] ([id_respuesta], [id_pregunta], [id_precliente], [respuesta], [observacion], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (1018, 18, 26, 0, N'', CAST(N'2018-07-16T10:58:53.883' AS DateTime), N'69', NULL, NULL)
INSERT [dbo].[tblCLI_Respuestas] ([id_respuesta], [id_pregunta], [id_precliente], [respuesta], [observacion], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (1019, 19, 26, 0, N'', CAST(N'2018-07-16T10:58:53.890' AS DateTime), N'69', NULL, NULL)
GO
INSERT [dbo].[tblCLI_Respuestas] ([id_respuesta], [id_pregunta], [id_precliente], [respuesta], [observacion], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (1020, 20, 26, 0, N'', CAST(N'2018-07-16T10:58:53.900' AS DateTime), N'69', NULL, NULL)
INSERT [dbo].[tblCLI_Respuestas] ([id_respuesta], [id_pregunta], [id_precliente], [respuesta], [observacion], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (1021, 1, 26, 1, N'dede', CAST(N'2018-07-16T11:10:54.303' AS DateTime), N'69', NULL, NULL)
INSERT [dbo].[tblCLI_Respuestas] ([id_respuesta], [id_pregunta], [id_precliente], [respuesta], [observacion], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (1022, 2, 26, 1, N'dede', CAST(N'2018-07-16T11:10:54.320' AS DateTime), N'69', NULL, NULL)
INSERT [dbo].[tblCLI_Respuestas] ([id_respuesta], [id_pregunta], [id_precliente], [respuesta], [observacion], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (1023, 3, 26, 0, N'', CAST(N'2018-07-16T11:10:54.330' AS DateTime), N'69', NULL, NULL)
INSERT [dbo].[tblCLI_Respuestas] ([id_respuesta], [id_pregunta], [id_precliente], [respuesta], [observacion], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (1024, 4, 26, 0, N'', CAST(N'2018-07-16T11:10:54.337' AS DateTime), N'69', NULL, NULL)
INSERT [dbo].[tblCLI_Respuestas] ([id_respuesta], [id_pregunta], [id_precliente], [respuesta], [observacion], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (1025, 5, 26, 0, N'', CAST(N'2018-07-16T11:10:54.343' AS DateTime), N'69', NULL, NULL)
INSERT [dbo].[tblCLI_Respuestas] ([id_respuesta], [id_pregunta], [id_precliente], [respuesta], [observacion], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (1026, 6, 26, 0, N'', CAST(N'2018-07-16T11:10:54.353' AS DateTime), N'69', NULL, NULL)
INSERT [dbo].[tblCLI_Respuestas] ([id_respuesta], [id_pregunta], [id_precliente], [respuesta], [observacion], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (1027, 7, 26, 0, N'', CAST(N'2018-07-16T11:10:54.360' AS DateTime), N'69', NULL, NULL)
INSERT [dbo].[tblCLI_Respuestas] ([id_respuesta], [id_pregunta], [id_precliente], [respuesta], [observacion], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (1028, 8, 26, 0, N'', CAST(N'2018-07-16T11:10:54.370' AS DateTime), N'69', NULL, NULL)
INSERT [dbo].[tblCLI_Respuestas] ([id_respuesta], [id_pregunta], [id_precliente], [respuesta], [observacion], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (1029, 9, 26, 1, N'dede', CAST(N'2018-07-16T11:10:54.380' AS DateTime), N'69', NULL, NULL)
INSERT [dbo].[tblCLI_Respuestas] ([id_respuesta], [id_pregunta], [id_precliente], [respuesta], [observacion], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (1030, 10, 26, 0, N'', CAST(N'2018-07-16T11:10:54.387' AS DateTime), N'69', NULL, NULL)
INSERT [dbo].[tblCLI_Respuestas] ([id_respuesta], [id_pregunta], [id_precliente], [respuesta], [observacion], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (1031, 11, 26, 0, N'', CAST(N'2018-07-16T11:10:54.393' AS DateTime), N'69', NULL, NULL)
INSERT [dbo].[tblCLI_Respuestas] ([id_respuesta], [id_pregunta], [id_precliente], [respuesta], [observacion], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (1032, 12, 26, 0, N'', CAST(N'2018-07-16T11:10:54.403' AS DateTime), N'69', NULL, NULL)
INSERT [dbo].[tblCLI_Respuestas] ([id_respuesta], [id_pregunta], [id_precliente], [respuesta], [observacion], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (1033, 13, 26, 0, N'', CAST(N'2018-07-16T11:10:54.410' AS DateTime), N'69', NULL, NULL)
INSERT [dbo].[tblCLI_Respuestas] ([id_respuesta], [id_pregunta], [id_precliente], [respuesta], [observacion], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (1034, 14, 26, 0, N'', CAST(N'2018-07-16T11:10:54.420' AS DateTime), N'69', NULL, NULL)
INSERT [dbo].[tblCLI_Respuestas] ([id_respuesta], [id_pregunta], [id_precliente], [respuesta], [observacion], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (1035, 15, 26, 0, N'', CAST(N'2018-07-16T11:10:54.430' AS DateTime), N'69', NULL, NULL)
INSERT [dbo].[tblCLI_Respuestas] ([id_respuesta], [id_pregunta], [id_precliente], [respuesta], [observacion], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (1036, 16, 26, 0, N'', CAST(N'2018-07-16T11:10:54.437' AS DateTime), N'69', NULL, NULL)
INSERT [dbo].[tblCLI_Respuestas] ([id_respuesta], [id_pregunta], [id_precliente], [respuesta], [observacion], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (1037, 17, 26, 0, N'', CAST(N'2018-07-16T11:10:54.447' AS DateTime), N'69', NULL, NULL)
INSERT [dbo].[tblCLI_Respuestas] ([id_respuesta], [id_pregunta], [id_precliente], [respuesta], [observacion], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (1038, 18, 26, 0, N'', CAST(N'2018-07-16T11:10:54.453' AS DateTime), N'69', NULL, NULL)
INSERT [dbo].[tblCLI_Respuestas] ([id_respuesta], [id_pregunta], [id_precliente], [respuesta], [observacion], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (1039, 19, 26, 0, N'', CAST(N'2018-07-16T11:10:54.460' AS DateTime), N'69', NULL, NULL)
INSERT [dbo].[tblCLI_Respuestas] ([id_respuesta], [id_pregunta], [id_precliente], [respuesta], [observacion], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (1040, 20, 26, 0, N'', CAST(N'2018-07-16T11:10:54.470' AS DateTime), N'69', NULL, NULL)
INSERT [dbo].[tblCLI_Respuestas] ([id_respuesta], [id_pregunta], [id_precliente], [respuesta], [observacion], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (1041, 1, 27, 0, N'', CAST(N'2018-07-16T14:25:06.387' AS DateTime), N'70', NULL, NULL)
INSERT [dbo].[tblCLI_Respuestas] ([id_respuesta], [id_pregunta], [id_precliente], [respuesta], [observacion], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (1042, 2, 27, 0, N'', CAST(N'2018-07-16T14:25:06.417' AS DateTime), N'70', NULL, NULL)
INSERT [dbo].[tblCLI_Respuestas] ([id_respuesta], [id_pregunta], [id_precliente], [respuesta], [observacion], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (1043, 3, 27, 0, N'', CAST(N'2018-07-16T14:25:06.427' AS DateTime), N'70', NULL, NULL)
INSERT [dbo].[tblCLI_Respuestas] ([id_respuesta], [id_pregunta], [id_precliente], [respuesta], [observacion], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (1044, 4, 27, 0, N'', CAST(N'2018-07-16T14:25:06.433' AS DateTime), N'70', NULL, NULL)
INSERT [dbo].[tblCLI_Respuestas] ([id_respuesta], [id_pregunta], [id_precliente], [respuesta], [observacion], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (1045, 5, 27, 0, N'', CAST(N'2018-07-16T14:25:06.450' AS DateTime), N'70', NULL, NULL)
INSERT [dbo].[tblCLI_Respuestas] ([id_respuesta], [id_pregunta], [id_precliente], [respuesta], [observacion], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (1046, 6, 27, 0, N'', CAST(N'2018-07-16T14:25:06.490' AS DateTime), N'70', NULL, NULL)
INSERT [dbo].[tblCLI_Respuestas] ([id_respuesta], [id_pregunta], [id_precliente], [respuesta], [observacion], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (1047, 7, 27, 0, N'', CAST(N'2018-07-16T14:25:06.510' AS DateTime), N'70', NULL, NULL)
INSERT [dbo].[tblCLI_Respuestas] ([id_respuesta], [id_pregunta], [id_precliente], [respuesta], [observacion], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (1048, 8, 27, 0, N'', CAST(N'2018-07-16T14:25:06.540' AS DateTime), N'70', NULL, NULL)
INSERT [dbo].[tblCLI_Respuestas] ([id_respuesta], [id_pregunta], [id_precliente], [respuesta], [observacion], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (1049, 9, 27, 0, N'', CAST(N'2018-07-16T14:25:06.557' AS DateTime), N'70', NULL, NULL)
INSERT [dbo].[tblCLI_Respuestas] ([id_respuesta], [id_pregunta], [id_precliente], [respuesta], [observacion], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (1050, 10, 27, 0, N'', CAST(N'2018-07-16T14:25:06.583' AS DateTime), N'70', NULL, NULL)
INSERT [dbo].[tblCLI_Respuestas] ([id_respuesta], [id_pregunta], [id_precliente], [respuesta], [observacion], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (1051, 11, 27, 0, N'', CAST(N'2018-07-16T14:25:06.617' AS DateTime), N'70', NULL, NULL)
INSERT [dbo].[tblCLI_Respuestas] ([id_respuesta], [id_pregunta], [id_precliente], [respuesta], [observacion], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (1052, 12, 27, 0, N'', CAST(N'2018-07-16T14:25:06.633' AS DateTime), N'70', NULL, NULL)
INSERT [dbo].[tblCLI_Respuestas] ([id_respuesta], [id_pregunta], [id_precliente], [respuesta], [observacion], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (1053, 13, 27, 0, N'', CAST(N'2018-07-16T14:25:06.657' AS DateTime), N'70', NULL, NULL)
INSERT [dbo].[tblCLI_Respuestas] ([id_respuesta], [id_pregunta], [id_precliente], [respuesta], [observacion], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (1054, 14, 27, 0, N'', CAST(N'2018-07-16T14:25:06.683' AS DateTime), N'70', NULL, NULL)
INSERT [dbo].[tblCLI_Respuestas] ([id_respuesta], [id_pregunta], [id_precliente], [respuesta], [observacion], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (1055, 15, 27, 0, N'', CAST(N'2018-07-16T14:25:06.983' AS DateTime), N'70', NULL, NULL)
INSERT [dbo].[tblCLI_Respuestas] ([id_respuesta], [id_pregunta], [id_precliente], [respuesta], [observacion], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (1056, 16, 27, 0, N'', CAST(N'2018-07-16T14:25:07.027' AS DateTime), N'70', NULL, NULL)
INSERT [dbo].[tblCLI_Respuestas] ([id_respuesta], [id_pregunta], [id_precliente], [respuesta], [observacion], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (1057, 17, 27, 0, N'', CAST(N'2018-07-16T14:25:07.050' AS DateTime), N'70', NULL, NULL)
INSERT [dbo].[tblCLI_Respuestas] ([id_respuesta], [id_pregunta], [id_precliente], [respuesta], [observacion], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (1058, 18, 27, 0, N'', CAST(N'2018-07-16T14:25:07.073' AS DateTime), N'70', NULL, NULL)
INSERT [dbo].[tblCLI_Respuestas] ([id_respuesta], [id_pregunta], [id_precliente], [respuesta], [observacion], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (1059, 19, 27, 0, N'', CAST(N'2018-07-16T14:25:07.110' AS DateTime), N'70', NULL, NULL)
INSERT [dbo].[tblCLI_Respuestas] ([id_respuesta], [id_pregunta], [id_precliente], [respuesta], [observacion], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (1060, 20, 27, 0, N'', CAST(N'2018-07-16T14:25:07.123' AS DateTime), N'70', NULL, NULL)
INSERT [dbo].[tblCLI_Respuestas] ([id_respuesta], [id_pregunta], [id_precliente], [respuesta], [observacion], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (1061, 1, 32, 0, N'', CAST(N'2018-07-17T11:57:07.030' AS DateTime), N'76', NULL, NULL)
INSERT [dbo].[tblCLI_Respuestas] ([id_respuesta], [id_pregunta], [id_precliente], [respuesta], [observacion], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (1062, 2, 32, 0, N'', CAST(N'2018-07-17T11:57:07.040' AS DateTime), N'76', NULL, NULL)
INSERT [dbo].[tblCLI_Respuestas] ([id_respuesta], [id_pregunta], [id_precliente], [respuesta], [observacion], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (1063, 3, 32, 0, N'', CAST(N'2018-07-17T11:57:07.050' AS DateTime), N'76', NULL, NULL)
INSERT [dbo].[tblCLI_Respuestas] ([id_respuesta], [id_pregunta], [id_precliente], [respuesta], [observacion], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (1064, 4, 32, 0, N'', CAST(N'2018-07-17T11:57:07.057' AS DateTime), N'76', NULL, NULL)
INSERT [dbo].[tblCLI_Respuestas] ([id_respuesta], [id_pregunta], [id_precliente], [respuesta], [observacion], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (1065, 5, 32, 0, N'', CAST(N'2018-07-17T11:57:07.067' AS DateTime), N'76', NULL, NULL)
INSERT [dbo].[tblCLI_Respuestas] ([id_respuesta], [id_pregunta], [id_precliente], [respuesta], [observacion], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (1066, 6, 32, 0, N'', CAST(N'2018-07-17T11:57:07.073' AS DateTime), N'76', NULL, NULL)
INSERT [dbo].[tblCLI_Respuestas] ([id_respuesta], [id_pregunta], [id_precliente], [respuesta], [observacion], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (1067, 7, 32, 0, N'', CAST(N'2018-07-17T11:57:07.083' AS DateTime), N'76', NULL, NULL)
INSERT [dbo].[tblCLI_Respuestas] ([id_respuesta], [id_pregunta], [id_precliente], [respuesta], [observacion], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (1068, 8, 32, 0, N'', CAST(N'2018-07-17T11:57:07.090' AS DateTime), N'76', NULL, NULL)
INSERT [dbo].[tblCLI_Respuestas] ([id_respuesta], [id_pregunta], [id_precliente], [respuesta], [observacion], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (1069, 9, 32, 0, N'', CAST(N'2018-07-17T11:57:07.100' AS DateTime), N'76', NULL, NULL)
INSERT [dbo].[tblCLI_Respuestas] ([id_respuesta], [id_pregunta], [id_precliente], [respuesta], [observacion], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (1070, 10, 32, 0, N'', CAST(N'2018-07-17T11:57:07.107' AS DateTime), N'76', NULL, NULL)
INSERT [dbo].[tblCLI_Respuestas] ([id_respuesta], [id_pregunta], [id_precliente], [respuesta], [observacion], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (1071, 11, 32, 0, N'', CAST(N'2018-07-17T11:57:07.117' AS DateTime), N'76', NULL, NULL)
INSERT [dbo].[tblCLI_Respuestas] ([id_respuesta], [id_pregunta], [id_precliente], [respuesta], [observacion], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (1072, 12, 32, 0, N'', CAST(N'2018-07-17T11:57:07.123' AS DateTime), N'76', NULL, NULL)
INSERT [dbo].[tblCLI_Respuestas] ([id_respuesta], [id_pregunta], [id_precliente], [respuesta], [observacion], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (1073, 13, 32, 0, N'', CAST(N'2018-07-17T11:57:07.133' AS DateTime), N'76', NULL, NULL)
INSERT [dbo].[tblCLI_Respuestas] ([id_respuesta], [id_pregunta], [id_precliente], [respuesta], [observacion], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (1074, 14, 32, 0, N'', CAST(N'2018-07-17T11:57:07.140' AS DateTime), N'76', NULL, NULL)
INSERT [dbo].[tblCLI_Respuestas] ([id_respuesta], [id_pregunta], [id_precliente], [respuesta], [observacion], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (1075, 15, 32, 0, N'', CAST(N'2018-07-17T11:57:07.150' AS DateTime), N'76', NULL, NULL)
INSERT [dbo].[tblCLI_Respuestas] ([id_respuesta], [id_pregunta], [id_precliente], [respuesta], [observacion], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (1076, 16, 32, 0, N'', CAST(N'2018-07-17T11:57:07.157' AS DateTime), N'76', NULL, NULL)
INSERT [dbo].[tblCLI_Respuestas] ([id_respuesta], [id_pregunta], [id_precliente], [respuesta], [observacion], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (1077, 17, 32, 0, N'', CAST(N'2018-07-17T11:57:07.167' AS DateTime), N'76', NULL, NULL)
INSERT [dbo].[tblCLI_Respuestas] ([id_respuesta], [id_pregunta], [id_precliente], [respuesta], [observacion], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (1078, 18, 32, 0, N'', CAST(N'2018-07-17T11:57:07.173' AS DateTime), N'76', NULL, NULL)
INSERT [dbo].[tblCLI_Respuestas] ([id_respuesta], [id_pregunta], [id_precliente], [respuesta], [observacion], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (1079, 19, 32, 0, N'', CAST(N'2018-07-17T11:57:07.183' AS DateTime), N'76', NULL, NULL)
INSERT [dbo].[tblCLI_Respuestas] ([id_respuesta], [id_pregunta], [id_precliente], [respuesta], [observacion], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (1080, 20, 32, 0, N'', CAST(N'2018-07-17T11:57:07.190' AS DateTime), N'76', NULL, NULL)
INSERT [dbo].[tblCLI_Respuestas] ([id_respuesta], [id_pregunta], [id_precliente], [respuesta], [observacion], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (1081, 1, 2, 0, N'observacion-1', CAST(N'2018-07-17T13:50:36.507' AS DateTime), N'2', NULL, NULL)
INSERT [dbo].[tblCLI_Respuestas] ([id_respuesta], [id_pregunta], [id_precliente], [respuesta], [observacion], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (1082, 2, 2, 1, N'observacion-2', CAST(N'2018-07-17T13:54:03.223' AS DateTime), N'2', NULL, NULL)
INSERT [dbo].[tblCLI_Respuestas] ([id_respuesta], [id_pregunta], [id_precliente], [respuesta], [observacion], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (1083, 3, 2, 1, N'observacion-3', CAST(N'2018-07-17T13:54:03.233' AS DateTime), N'2', NULL, NULL)
INSERT [dbo].[tblCLI_Respuestas] ([id_respuesta], [id_pregunta], [id_precliente], [respuesta], [observacion], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (1084, 4, 2, 0, N'observacion-4', CAST(N'2018-07-17T13:54:03.243' AS DateTime), N'2', NULL, NULL)
INSERT [dbo].[tblCLI_Respuestas] ([id_respuesta], [id_pregunta], [id_precliente], [respuesta], [observacion], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (1085, 5, 2, 1, N'observacion-5', CAST(N'2018-07-17T13:54:03.250' AS DateTime), N'2', NULL, NULL)
INSERT [dbo].[tblCLI_Respuestas] ([id_respuesta], [id_pregunta], [id_precliente], [respuesta], [observacion], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (1086, 6, 2, 0, N'observacion-6', CAST(N'2018-07-17T13:54:03.260' AS DateTime), N'2', NULL, NULL)
INSERT [dbo].[tblCLI_Respuestas] ([id_respuesta], [id_pregunta], [id_precliente], [respuesta], [observacion], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (1087, 7, 2, 1, N'observacion-7', CAST(N'2018-07-17T13:54:03.267' AS DateTime), N'2', NULL, NULL)
INSERT [dbo].[tblCLI_Respuestas] ([id_respuesta], [id_pregunta], [id_precliente], [respuesta], [observacion], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (1088, 8, 2, 1, N'observacion-8', CAST(N'2018-07-17T13:54:03.277' AS DateTime), N'2', NULL, NULL)
INSERT [dbo].[tblCLI_Respuestas] ([id_respuesta], [id_pregunta], [id_precliente], [respuesta], [observacion], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (1089, 9, 2, 0, N'observacion-9', CAST(N'2018-07-17T13:54:03.283' AS DateTime), N'2', NULL, NULL)
INSERT [dbo].[tblCLI_Respuestas] ([id_respuesta], [id_pregunta], [id_precliente], [respuesta], [observacion], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (1090, 10, 2, 1, N'observacion-10', CAST(N'2018-07-17T13:54:03.293' AS DateTime), N'2', NULL, NULL)
INSERT [dbo].[tblCLI_Respuestas] ([id_respuesta], [id_pregunta], [id_precliente], [respuesta], [observacion], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (1091, 11, 2, 1, N'observacion-11', CAST(N'2018-07-17T13:54:03.300' AS DateTime), N'2', NULL, NULL)
INSERT [dbo].[tblCLI_Respuestas] ([id_respuesta], [id_pregunta], [id_precliente], [respuesta], [observacion], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (1092, 12, 2, 0, N'observacion-12', CAST(N'2018-07-17T13:54:03.310' AS DateTime), N'2', NULL, NULL)
INSERT [dbo].[tblCLI_Respuestas] ([id_respuesta], [id_pregunta], [id_precliente], [respuesta], [observacion], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (1093, 13, 2, 0, N'observacion-13', CAST(N'2018-07-17T13:54:03.317' AS DateTime), N'2', NULL, NULL)
INSERT [dbo].[tblCLI_Respuestas] ([id_respuesta], [id_pregunta], [id_precliente], [respuesta], [observacion], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (1094, 14, 2, 1, N'observacion-14', CAST(N'2018-07-17T13:54:03.327' AS DateTime), N'2', NULL, NULL)
INSERT [dbo].[tblCLI_Respuestas] ([id_respuesta], [id_pregunta], [id_precliente], [respuesta], [observacion], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (1095, 15, 2, 0, N'observacion-15', CAST(N'2018-07-17T13:54:03.333' AS DateTime), N'2', NULL, NULL)
INSERT [dbo].[tblCLI_Respuestas] ([id_respuesta], [id_pregunta], [id_precliente], [respuesta], [observacion], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (1096, 16, 2, 1, N'observacion-16', CAST(N'2018-07-17T13:54:03.353' AS DateTime), N'2', NULL, NULL)
INSERT [dbo].[tblCLI_Respuestas] ([id_respuesta], [id_pregunta], [id_precliente], [respuesta], [observacion], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (1097, 17, 2, 0, N'observacion-17', CAST(N'2018-07-17T13:54:03.363' AS DateTime), N'2', NULL, NULL)
INSERT [dbo].[tblCLI_Respuestas] ([id_respuesta], [id_pregunta], [id_precliente], [respuesta], [observacion], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (1098, 18, 2, 1, N'observacion-18', CAST(N'2018-07-17T13:54:03.370' AS DateTime), N'2', NULL, NULL)
INSERT [dbo].[tblCLI_Respuestas] ([id_respuesta], [id_pregunta], [id_precliente], [respuesta], [observacion], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (1099, 19, 2, 1, N'observacion-19', CAST(N'2018-07-17T13:54:03.380' AS DateTime), N'2', NULL, NULL)
INSERT [dbo].[tblCLI_Respuestas] ([id_respuesta], [id_pregunta], [id_precliente], [respuesta], [observacion], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (1100, 20, 2, 1, N'observacion-20', CAST(N'2018-07-17T13:54:25.790' AS DateTime), N'2', NULL, NULL)
SET IDENTITY_INSERT [dbo].[tblCLI_Respuestas] OFF
SET IDENTITY_INSERT [dbo].[tblCLI_Roles] ON 

INSERT [dbo].[tblCLI_Roles] ([id_rol], [descripcion], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (1, N'Administrador', CAST(N'2018-06-27T00:00:00.000' AS DateTime), N'admin', CAST(N'2018-07-05T00:00:00.000' AS DateTime), N'admin')
INSERT [dbo].[tblCLI_Roles] ([id_rol], [descripcion], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (2, N'Cliente', CAST(N'2018-06-27T23:41:01.000' AS DateTime), N'admin', CAST(N'2018-06-27T23:41:01.000' AS DateTime), N'admin')
INSERT [dbo].[tblCLI_Roles] ([id_rol], [descripcion], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (3, N'Lider', CAST(N'2018-06-27T23:41:01.000' AS DateTime), N'admin', CAST(N'2018-06-27T23:41:01.000' AS DateTime), N'admin')
INSERT [dbo].[tblCLI_Roles] ([id_rol], [descripcion], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (4, N'Ejecutivo ventas', CAST(N'2018-06-27T23:41:01.000' AS DateTime), N'admin', CAST(N'2018-06-27T23:41:01.000' AS DateTime), N'admin')
INSERT [dbo].[tblCLI_Roles] ([id_rol], [descripcion], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (5, N'Gerente comercializacion', CAST(N'2018-06-27T23:41:01.000' AS DateTime), N'admin', CAST(N'2018-06-27T23:41:01.000' AS DateTime), N'admin')
INSERT [dbo].[tblCLI_Roles] ([id_rol], [descripcion], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (6, N'Aprobacion', CAST(N'2018-06-27T23:41:01.000' AS DateTime), N'admin', CAST(N'2018-06-27T23:41:01.000' AS DateTime), N'admin')
INSERT [dbo].[tblCLI_Roles] ([id_rol], [descripcion], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (7, N'Alta cliente', CAST(N'2018-06-27T23:41:01.000' AS DateTime), N'admin', CAST(N'2018-06-27T23:41:01.000' AS DateTime), N'admin')
SET IDENTITY_INSERT [dbo].[tblCLI_Roles] OFF
SET IDENTITY_INSERT [dbo].[tblCLI_RolesEstatus] ON 

INSERT [dbo].[tblCLI_RolesEstatus] ([id_rol_estatus], [id_rol], [id_estatus], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (1, 1, 2, CAST(N'2018-06-28T05:27:30.000' AS DateTime), N'admin', CAST(N'2018-06-28T05:27:30.000' AS DateTime), N'admin')
INSERT [dbo].[tblCLI_RolesEstatus] ([id_rol_estatus], [id_rol], [id_estatus], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (2, 4, 2, CAST(N'2018-06-28T05:27:30.000' AS DateTime), N'admin', CAST(N'2018-06-28T05:27:30.000' AS DateTime), N'admin')
INSERT [dbo].[tblCLI_RolesEstatus] ([id_rol_estatus], [id_rol], [id_estatus], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (3, 6, 3, CAST(N'2018-06-28T05:27:30.000' AS DateTime), N'admin', CAST(N'2018-06-28T05:27:30.000' AS DateTime), N'admin')
INSERT [dbo].[tblCLI_RolesEstatus] ([id_rol_estatus], [id_rol], [id_estatus], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (4, 4, 4, CAST(N'2018-06-28T05:27:30.000' AS DateTime), N'admin', CAST(N'2018-06-28T05:27:30.000' AS DateTime), N'admin')
INSERT [dbo].[tblCLI_RolesEstatus] ([id_rol_estatus], [id_rol], [id_estatus], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (5, 6, 5, CAST(N'2018-06-28T05:27:30.000' AS DateTime), N'admin', CAST(N'2018-06-28T05:27:30.000' AS DateTime), N'admin')
INSERT [dbo].[tblCLI_RolesEstatus] ([id_rol_estatus], [id_rol], [id_estatus], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (6, 4, 6, CAST(N'2018-06-28T05:27:30.000' AS DateTime), N'admin', CAST(N'2018-06-28T05:27:30.000' AS DateTime), N'admin')
INSERT [dbo].[tblCLI_RolesEstatus] ([id_rol_estatus], [id_rol], [id_estatus], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (7, 6, 6, CAST(N'2018-06-28T05:27:30.000' AS DateTime), N'admin', CAST(N'2018-06-28T05:27:30.000' AS DateTime), N'admin')
INSERT [dbo].[tblCLI_RolesEstatus] ([id_rol_estatus], [id_rol], [id_estatus], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (8, 6, 7, CAST(N'2018-06-28T05:27:30.000' AS DateTime), N'admin', CAST(N'2018-06-28T05:27:30.000' AS DateTime), N'admin')
INSERT [dbo].[tblCLI_RolesEstatus] ([id_rol_estatus], [id_rol], [id_estatus], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (9, 7, 8, CAST(N'2018-06-28T05:27:30.000' AS DateTime), N'admin', CAST(N'2018-06-28T05:27:30.000' AS DateTime), N'admin')
INSERT [dbo].[tblCLI_RolesEstatus] ([id_rol_estatus], [id_rol], [id_estatus], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (10, 7, 9, CAST(N'2018-06-28T05:27:30.000' AS DateTime), N'admin', CAST(N'2018-06-28T05:27:30.000' AS DateTime), N'admin')
INSERT [dbo].[tblCLI_RolesEstatus] ([id_rol_estatus], [id_rol], [id_estatus], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (11, 5, 10, CAST(N'2018-06-28T05:27:30.000' AS DateTime), N'admin', CAST(N'2018-06-28T05:27:30.000' AS DateTime), N'admin')
INSERT [dbo].[tblCLI_RolesEstatus] ([id_rol_estatus], [id_rol], [id_estatus], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (12, 3, 10, CAST(N'2018-06-28T05:27:30.000' AS DateTime), N'admin', CAST(N'2018-06-28T05:27:30.000' AS DateTime), N'admin')
INSERT [dbo].[tblCLI_RolesEstatus] ([id_rol_estatus], [id_rol], [id_estatus], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (13, 3, 11, CAST(N'2018-06-28T05:27:30.000' AS DateTime), N'admin', CAST(N'2018-06-28T05:27:30.000' AS DateTime), N'admin')
INSERT [dbo].[tblCLI_RolesEstatus] ([id_rol_estatus], [id_rol], [id_estatus], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (14, 5, 11, CAST(N'2018-06-28T05:27:30.000' AS DateTime), N'admin', CAST(N'2018-06-28T05:27:30.000' AS DateTime), N'admin')
INSERT [dbo].[tblCLI_RolesEstatus] ([id_rol_estatus], [id_rol], [id_estatus], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (15, 6, 11, CAST(N'2018-06-28T05:27:30.000' AS DateTime), N'admin', CAST(N'2018-06-28T05:27:30.000' AS DateTime), N'admin')
INSERT [dbo].[tblCLI_RolesEstatus] ([id_rol_estatus], [id_rol], [id_estatus], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (16, 4, 12, CAST(N'2018-06-28T05:27:30.000' AS DateTime), N'admin', CAST(N'2018-06-28T05:27:30.000' AS DateTime), N'admin')
INSERT [dbo].[tblCLI_RolesEstatus] ([id_rol_estatus], [id_rol], [id_estatus], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (17, 4, 13, CAST(N'2018-06-28T05:27:30.000' AS DateTime), N'admin', CAST(N'2018-06-28T05:27:30.000' AS DateTime), N'admin')
INSERT [dbo].[tblCLI_RolesEstatus] ([id_rol_estatus], [id_rol], [id_estatus], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (18, 5, 14, CAST(N'2018-06-28T05:27:30.000' AS DateTime), N'admin', CAST(N'2018-06-28T05:27:30.000' AS DateTime), N'admin')
INSERT [dbo].[tblCLI_RolesEstatus] ([id_rol_estatus], [id_rol], [id_estatus], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (19, 7, 14, CAST(N'2018-06-28T05:27:30.000' AS DateTime), N'admin', CAST(N'2018-06-28T05:27:30.000' AS DateTime), N'admin')
INSERT [dbo].[tblCLI_RolesEstatus] ([id_rol_estatus], [id_rol], [id_estatus], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (20, 7, 15, CAST(N'2018-06-28T05:27:30.000' AS DateTime), N'admin', CAST(N'2018-06-28T05:27:30.000' AS DateTime), N'admin')
INSERT [dbo].[tblCLI_RolesEstatus] ([id_rol_estatus], [id_rol], [id_estatus], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (21, 6, 16, CAST(N'2018-06-28T05:27:30.000' AS DateTime), N'admin', CAST(N'2018-06-28T05:27:30.000' AS DateTime), N'admin')
INSERT [dbo].[tblCLI_RolesEstatus] ([id_rol_estatus], [id_rol], [id_estatus], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (22, 7, 17, CAST(N'2018-06-28T05:27:30.000' AS DateTime), N'admin', CAST(N'2018-06-28T05:27:30.000' AS DateTime), N'admin')
INSERT [dbo].[tblCLI_RolesEstatus] ([id_rol_estatus], [id_rol], [id_estatus], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (23, 6, 18, CAST(N'2018-06-28T05:27:30.000' AS DateTime), N'admin', CAST(N'2018-06-28T05:27:30.000' AS DateTime), N'admin')
SET IDENTITY_INSERT [dbo].[tblCLI_RolesEstatus] OFF
SET IDENTITY_INSERT [dbo].[tblCLI_RolesModulos] ON 

INSERT [dbo].[tblCLI_RolesModulos] ([id_rol_modulo], [id_rol], [id_modulo], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (71, 5, 16, CAST(N'2018-07-05T00:00:00.000' AS DateTime), N'admin', CAST(N'2018-07-05T00:00:00.000' AS DateTime), N'admin')
INSERT [dbo].[tblCLI_RolesModulos] ([id_rol_modulo], [id_rol], [id_modulo], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (72, 5, 19, CAST(N'2018-07-05T00:00:00.000' AS DateTime), N'admin', CAST(N'2018-07-05T00:00:00.000' AS DateTime), N'admin')
INSERT [dbo].[tblCLI_RolesModulos] ([id_rol_modulo], [id_rol], [id_modulo], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (90, 6, 16, CAST(N'2018-07-09T00:00:00.000' AS DateTime), N'admin', CAST(N'2018-07-09T00:00:00.000' AS DateTime), N'admin')
INSERT [dbo].[tblCLI_RolesModulos] ([id_rol_modulo], [id_rol], [id_modulo], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (91, 7, 15, CAST(N'2018-07-09T00:00:00.000' AS DateTime), N'admin', CAST(N'2018-07-09T00:00:00.000' AS DateTime), N'admin')
INSERT [dbo].[tblCLI_RolesModulos] ([id_rol_modulo], [id_rol], [id_modulo], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (99, 2, 13, CAST(N'2018-07-09T00:00:00.000' AS DateTime), N'admin', CAST(N'2018-07-09T00:00:00.000' AS DateTime), N'admin')
INSERT [dbo].[tblCLI_RolesModulos] ([id_rol_modulo], [id_rol], [id_modulo], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (100, 2, 14, CAST(N'2018-07-09T00:00:00.000' AS DateTime), N'admin', CAST(N'2018-07-09T00:00:00.000' AS DateTime), N'admin')
INSERT [dbo].[tblCLI_RolesModulos] ([id_rol_modulo], [id_rol], [id_modulo], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (101, 2, 17, CAST(N'2018-07-09T00:00:00.000' AS DateTime), N'admin', CAST(N'2018-07-09T00:00:00.000' AS DateTime), N'admin')
INSERT [dbo].[tblCLI_RolesModulos] ([id_rol_modulo], [id_rol], [id_modulo], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (102, 3, 13, CAST(N'2018-07-09T00:00:00.000' AS DateTime), N'admin', CAST(N'2018-07-09T00:00:00.000' AS DateTime), N'admin')
INSERT [dbo].[tblCLI_RolesModulos] ([id_rol_modulo], [id_rol], [id_modulo], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (103, 3, 14, CAST(N'2018-07-09T00:00:00.000' AS DateTime), N'admin', CAST(N'2018-07-09T00:00:00.000' AS DateTime), N'admin')
INSERT [dbo].[tblCLI_RolesModulos] ([id_rol_modulo], [id_rol], [id_modulo], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (104, 3, 15, CAST(N'2018-07-09T00:00:00.000' AS DateTime), N'admin', CAST(N'2018-07-09T00:00:00.000' AS DateTime), N'admin')
INSERT [dbo].[tblCLI_RolesModulos] ([id_rol_modulo], [id_rol], [id_modulo], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (105, 4, 18, CAST(N'2018-07-09T00:00:00.000' AS DateTime), N'admin', CAST(N'2018-07-09T00:00:00.000' AS DateTime), N'admin')
INSERT [dbo].[tblCLI_RolesModulos] ([id_rol_modulo], [id_rol], [id_modulo], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (112, 1, 13, CAST(N'2018-07-10T00:00:00.000' AS DateTime), N'admin', CAST(N'2018-07-10T00:00:00.000' AS DateTime), N'admin')
INSERT [dbo].[tblCLI_RolesModulos] ([id_rol_modulo], [id_rol], [id_modulo], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (113, 1, 14, CAST(N'2018-07-10T00:00:00.000' AS DateTime), N'admin', CAST(N'2018-07-10T00:00:00.000' AS DateTime), N'admin')
INSERT [dbo].[tblCLI_RolesModulos] ([id_rol_modulo], [id_rol], [id_modulo], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (114, 1, 15, CAST(N'2018-07-10T00:00:00.000' AS DateTime), N'admin', CAST(N'2018-07-10T00:00:00.000' AS DateTime), N'admin')
INSERT [dbo].[tblCLI_RolesModulos] ([id_rol_modulo], [id_rol], [id_modulo], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (115, 1, 16, CAST(N'2018-07-10T00:00:00.000' AS DateTime), N'admin', CAST(N'2018-07-10T00:00:00.000' AS DateTime), N'admin')
INSERT [dbo].[tblCLI_RolesModulos] ([id_rol_modulo], [id_rol], [id_modulo], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (116, 1, 17, CAST(N'2018-07-10T00:00:00.000' AS DateTime), N'admin', CAST(N'2018-07-10T00:00:00.000' AS DateTime), N'admin')
INSERT [dbo].[tblCLI_RolesModulos] ([id_rol_modulo], [id_rol], [id_modulo], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (117, 1, 18, CAST(N'2018-07-10T00:00:00.000' AS DateTime), N'admin', CAST(N'2018-07-10T00:00:00.000' AS DateTime), N'admin')
INSERT [dbo].[tblCLI_RolesModulos] ([id_rol_modulo], [id_rol], [id_modulo], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (118, 1, 19, CAST(N'2018-07-10T00:00:00.000' AS DateTime), N'admin', CAST(N'2018-07-10T00:00:00.000' AS DateTime), N'admin')
SET IDENTITY_INSERT [dbo].[tblCLI_RolesModulos] OFF
SET IDENTITY_INSERT [dbo].[tblCLI_Tab] ON 

INSERT [dbo].[tblCLI_Tab] ([id_tabuladores], [tabulador], [tipo_operacion], [aduana], [clave_pedimiento], [moneda], [facturacion], [dias_libres], [datos_adicionales], [metodo_pago], [dig_cuenta], [instruccion_especial]) VALUES (2, 1, N'tipo_operacion', N'aduana', N'clave_pedimiento', N'moneda', N'factura', N'dias_libres', N'datos_adicionales', N'metodo pago', 123, N'instruccion')
INSERT [dbo].[tblCLI_Tab] ([id_tabuladores], [tabulador], [tipo_operacion], [aduana], [clave_pedimiento], [moneda], [facturacion], [dias_libres], [datos_adicionales], [metodo_pago], [dig_cuenta], [instruccion_especial]) VALUES (3, 1, N'tipo_operacion', N'aduana', N'clave_pedimiento', N'moneda', N'factura', N'dias_libres', N'datos_adicionales', N'metodo pago', 1234, N'instruccion')
INSERT [dbo].[tblCLI_Tab] ([id_tabuladores], [tabulador], [tipo_operacion], [aduana], [clave_pedimiento], [moneda], [facturacion], [dias_libres], [datos_adicionales], [metodo_pago], [dig_cuenta], [instruccion_especial]) VALUES (4, 1, N'tipo_operacion', N'aduana', N'clave_pedimiento', N'moneda', N'factura', N'dias_libres', N'datos_adicionales', N'metodo pago', 12345, N'instruccion')
INSERT [dbo].[tblCLI_Tab] ([id_tabuladores], [tabulador], [tipo_operacion], [aduana], [clave_pedimiento], [moneda], [facturacion], [dias_libres], [datos_adicionales], [metodo_pago], [dig_cuenta], [instruccion_especial]) VALUES (5, 1, N'tipo_operacion', N'aduana', N'clave pedimento', N'moneda', N'factura', N'dias libres ', N'datos adicionales', N'metodo pago', 1234567, N'instruccion')
SET IDENTITY_INSERT [dbo].[tblCLI_Tab] OFF
SET IDENTITY_INSERT [dbo].[tblCLI_Tabulador] ON 

INSERT [dbo].[tblCLI_Tabulador] ([id_tabulador], [usuario], [precliente], [tipo_cliente], [RFC_servicio_sociedad], [nombre_cliente_alta], [cliente_pedimiento], [sitio_ftp_pagWeb], [direccion_pag_web], [usuario_pag_web], [contrasena_pag_web], [entrega_fisica], [dias_revision], [horario_revision], [personas_rec_facuras], [no_copia], [calle_numero], [colonia], [id_ciudad], [id_estado], [cp], [estimado_venta], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (1, 1, 1, 1, N'HENM900914', N'nombre_cluente', N'cliente_pedimiento', 1, N'direccion', N'usuario web', N'contraseña web', 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'estimado', CAST(N'2018-07-11T00:00:00.000' AS DateTime), N'usuario_creacion', NULL, NULL)
SET IDENTITY_INSERT [dbo].[tblCLI_Tabulador] OFF
SET IDENTITY_INSERT [dbo].[tblCLI_Usuarios] ON 

INSERT [dbo].[tblCLI_Usuarios] ([id_usuario], [id_rol], [nombre], [usuario], [contrasenia], [correo], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion], [activo], [grupo]) VALUES (1, 2, N'Jose Sanchez', N'Jose', N'1', N'a@a.net', CAST(N'2018-06-28T18:12:22.000' AS DateTime), N'admin', CAST(N'2018-06-28T18:12:22.000' AS DateTime), N'admin', 1, NULL)
INSERT [dbo].[tblCLI_Usuarios] ([id_usuario], [id_rol], [nombre], [usuario], [contrasenia], [correo], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion], [activo], [grupo]) VALUES (7, 1, N'Fernando Vargas', N'fvargas', N'vargas', N'fvargas021@gmail.com', CAST(N'2018-07-05T00:00:00.000' AS DateTime), N'sistema', CAST(N'2018-07-09T00:00:00.000' AS DateTime), NULL, 1, NULL)
INSERT [dbo].[tblCLI_Usuarios] ([id_usuario], [id_rol], [nombre], [usuario], [contrasenia], [correo], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion], [activo], [grupo]) VALUES (70, 2, N'Roberto', N'renteria', N'otro', N'renteria@gmail.com', CAST(N'2018-07-16T00:00:00.000' AS DateTime), N'', CAST(N'2018-07-16T00:00:00.000' AS DateTime), N'', 1, NULL)
INSERT [dbo].[tblCLI_Usuarios] ([id_usuario], [id_rol], [nombre], [usuario], [contrasenia], [correo], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion], [activo], [grupo]) VALUES (71, 2, N'1', N'rent', N'1', N'1', CAST(N'2018-07-16T00:00:00.000' AS DateTime), N'', CAST(N'2018-07-16T00:00:00.000' AS DateTime), N'', 1, NULL)
INSERT [dbo].[tblCLI_Usuarios] ([id_usuario], [id_rol], [nombre], [usuario], [contrasenia], [correo], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion], [activo], [grupo]) VALUES (72, 4, N'Orlando Vargas', N'ovargas', N'', N'fvargas021@gmail.com', CAST(N'2018-07-16T00:00:00.000' AS DateTime), N'', CAST(N'2018-07-16T00:00:00.000' AS DateTime), N'', 1, NULL)
INSERT [dbo].[tblCLI_Usuarios] ([id_usuario], [id_rol], [nombre], [usuario], [contrasenia], [correo], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion], [activo], [grupo]) VALUES (73, 2, N'rodrigo', N'rodrigo', N'rodrigo123', N'rodrigofin@hotmail.com', CAST(N'2018-07-16T00:00:00.000' AS DateTime), N'', CAST(N'2018-07-16T00:00:00.000' AS DateTime), N'', 1, NULL)
INSERT [dbo].[tblCLI_Usuarios] ([id_usuario], [id_rol], [nombre], [usuario], [contrasenia], [correo], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion], [activo], [grupo]) VALUES (74, 2, N'rodrigo', N'rodrigo2', N'12345678', N'n@m.com', CAST(N'2018-07-17T00:00:00.000' AS DateTime), N'', CAST(N'2018-07-17T00:00:00.000' AS DateTime), N'', 1, NULL)
INSERT [dbo].[tblCLI_Usuarios] ([id_usuario], [id_rol], [nombre], [usuario], [contrasenia], [correo], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion], [activo], [grupo]) VALUES (75, 2, N'cliente', N'cliente', N'1', N'fvargas021@gmail.com', CAST(N'2018-07-17T00:00:00.000' AS DateTime), N'', CAST(N'2018-07-17T00:00:00.000' AS DateTime), N'', 1, NULL)
INSERT [dbo].[tblCLI_Usuarios] ([id_usuario], [id_rol], [nombre], [usuario], [contrasenia], [correo], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion], [activo], [grupo]) VALUES (76, 2, N'test', N'test', N'test', N'test@test.com', CAST(N'2018-07-17T00:00:00.000' AS DateTime), N'', CAST(N'2018-07-17T00:00:00.000' AS DateTime), N'', 1, NULL)
INSERT [dbo].[tblCLI_Usuarios] ([id_usuario], [id_rol], [nombre], [usuario], [contrasenia], [correo], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion], [activo], [grupo]) VALUES (77, 3, N'm', N'nmontes.mty', N'', N'nmontes.mty@grupoei.com.mx', CAST(N'2018-07-17T00:00:00.000' AS DateTime), N'', CAST(N'2018-07-17T00:00:00.000' AS DateTime), N'', 1, N'm')
INSERT [dbo].[tblCLI_Usuarios] ([id_usuario], [id_rol], [nombre], [usuario], [contrasenia], [correo], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion], [activo], [grupo]) VALUES (78, 4, N'eee', N'acontreras.lrd', N'', N'geivucem@gmail.com', CAST(N'2018-07-17T00:00:00.000' AS DateTime), N'', CAST(N'2018-07-17T00:00:00.000' AS DateTime), N'', 1, NULL)
INSERT [dbo].[tblCLI_Usuarios] ([id_usuario], [id_rol], [nombre], [usuario], [contrasenia], [correo], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion], [activo], [grupo]) VALUES (79, 1, N'jaime.mendoza.lrd', N'jaime.mendoza.lrd', N'', N'', CAST(N'2018-07-17T00:00:00.000' AS DateTime), N'', CAST(N'2018-07-17T00:00:00.000' AS DateTime), N'', 1, NULL)
INSERT [dbo].[tblCLI_Usuarios] ([id_usuario], [id_rol], [nombre], [usuario], [contrasenia], [correo], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion], [activo], [grupo]) VALUES (80, 5, N'jamartinez.mty', N'jamartinez.mty', N'', N'jamartinez.mty2@grupoei.com.mx', CAST(N'2018-07-17T00:00:00.000' AS DateTime), N'', CAST(N'2018-07-17T00:00:00.000' AS DateTime), N'', 1, NULL)
INSERT [dbo].[tblCLI_Usuarios] ([id_usuario], [id_rol], [nombre], [usuario], [contrasenia], [correo], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion], [activo], [grupo]) VALUES (81, 2, N'a', N'roberto', N'roberto', N'1', CAST(N'2018-07-17T00:00:00.000' AS DateTime), N'', CAST(N'2018-07-17T00:00:00.000' AS DateTime), N'', 1, NULL)
INSERT [dbo].[tblCLI_Usuarios] ([id_usuario], [id_rol], [nombre], [usuario], [contrasenia], [correo], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion], [activo], [grupo]) VALUES (82, 2, N'q', N'test1', N'test1', N'1', CAST(N'2018-07-17T00:00:00.000' AS DateTime), N'', CAST(N'2018-07-17T00:00:00.000' AS DateTime), N'', 1, NULL)
SET IDENTITY_INSERT [dbo].[tblCLI_Usuarios] OFF
SET IDENTITY_INSERT [dbo].[tblCLI_UsuariosAduabook] ON 

INSERT [dbo].[tblCLI_UsuariosAduabook] ([id_usuario_aduabook], [id_precliente], [nombre], [puesto_departamento], [telefono], [correo], [admon], [oper], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (29, 0, N'D', N'S', N'D', N'A', N'SD', N'D', CAST(N'2018-07-12T00:00:00.000' AS DateTime), N'admin', CAST(N'2018-07-12T00:00:00.000' AS DateTime), N'admin')
INSERT [dbo].[tblCLI_UsuariosAduabook] ([id_usuario_aduabook], [id_precliente], [nombre], [puesto_departamento], [telefono], [correo], [admon], [oper], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (30, 0, N'name', N'p', N'teldir', N'mail@mail.com', N'admon', N'p', CAST(N'2018-07-12T00:00:00.000' AS DateTime), N'admin', CAST(N'2018-07-12T00:00:00.000' AS DateTime), N'admin')
INSERT [dbo].[tblCLI_UsuariosAduabook] ([id_usuario_aduabook], [id_precliente], [nombre], [puesto_departamento], [telefono], [correo], [admon], [oper], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (31, 0, N'dos', N'uu', N'teldir', N'mail@mail.com', N'dmo', N'o', CAST(N'2018-07-12T00:00:00.000' AS DateTime), N'admin', CAST(N'2018-07-12T00:00:00.000' AS DateTime), N'admin')
INSERT [dbo].[tblCLI_UsuariosAduabook] ([id_usuario_aduabook], [id_precliente], [nombre], [puesto_departamento], [telefono], [correo], [admon], [oper], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (32, 0, N's', N'd', N'f', N's', N'd', N'f', CAST(N'2018-07-12T00:00:00.000' AS DateTime), N'admin', CAST(N'2018-07-12T00:00:00.000' AS DateTime), N'admin')
INSERT [dbo].[tblCLI_UsuariosAduabook] ([id_usuario_aduabook], [id_precliente], [nombre], [puesto_departamento], [telefono], [correo], [admon], [oper], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (33, 0, N'5', N'5', N'5', N'5', N'5', N'5', CAST(N'2018-07-12T00:00:00.000' AS DateTime), N'admin', CAST(N'2018-07-12T00:00:00.000' AS DateTime), N'admin')
INSERT [dbo].[tblCLI_UsuariosAduabook] ([id_usuario_aduabook], [id_precliente], [nombre], [puesto_departamento], [telefono], [correo], [admon], [oper], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (34, 15, N'dos', N'uu', N'teldir', N'mail@mail.com', N'dmo', N'o', CAST(N'2018-07-12T00:00:00.000' AS DateTime), N'admin', CAST(N'2018-07-12T00:00:00.000' AS DateTime), N'admin')
INSERT [dbo].[tblCLI_UsuariosAduabook] ([id_usuario_aduabook], [id_precliente], [nombre], [puesto_departamento], [telefono], [correo], [admon], [oper], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (35, 15, N's', N'd', N'f', N's', N'd', N'f', CAST(N'2018-07-12T00:00:00.000' AS DateTime), N'admin', CAST(N'2018-07-12T00:00:00.000' AS DateTime), N'admin')
INSERT [dbo].[tblCLI_UsuariosAduabook] ([id_usuario_aduabook], [id_precliente], [nombre], [puesto_departamento], [telefono], [correo], [admon], [oper], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (36, 15, N'5', N'5', N'5', N'5', N'5', N'5', CAST(N'2018-07-12T00:00:00.000' AS DateTime), N'admin', CAST(N'2018-07-12T00:00:00.000' AS DateTime), N'admin')
INSERT [dbo].[tblCLI_UsuariosAduabook] ([id_usuario_aduabook], [id_precliente], [nombre], [puesto_departamento], [telefono], [correo], [admon], [oper], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (151, 20, N'e', N'er', N'2', N'2', N'2', N'2', CAST(N'2018-07-16T00:00:00.000' AS DateTime), N'admin', CAST(N'2018-07-16T00:00:00.000' AS DateTime), N'admin')
INSERT [dbo].[tblCLI_UsuariosAduabook] ([id_usuario_aduabook], [id_precliente], [nombre], [puesto_departamento], [telefono], [correo], [admon], [oper], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (174, 26, N'1', N'1', N'1', N'1', N'1', N'1', CAST(N'2018-07-16T00:00:00.000' AS DateTime), N'admin', CAST(N'2018-07-16T00:00:00.000' AS DateTime), N'admin')
INSERT [dbo].[tblCLI_UsuariosAduabook] ([id_usuario_aduabook], [id_precliente], [nombre], [puesto_departamento], [telefono], [correo], [admon], [oper], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (175, 27, N'1', N'1', N'11', N'1', N'1', N'1', CAST(N'2018-07-16T00:00:00.000' AS DateTime), N'admin', CAST(N'2018-07-16T00:00:00.000' AS DateTime), N'admin')
INSERT [dbo].[tblCLI_UsuariosAduabook] ([id_usuario_aduabook], [id_precliente], [nombre], [puesto_departamento], [telefono], [correo], [admon], [oper], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (176, 28, N'1', N'1', N'1', N'12', N'2', N'2', CAST(N'2018-07-16T00:00:00.000' AS DateTime), N'admin', CAST(N'2018-07-16T00:00:00.000' AS DateTime), N'admin')
INSERT [dbo].[tblCLI_UsuariosAduabook] ([id_usuario_aduabook], [id_precliente], [nombre], [puesto_departamento], [telefono], [correo], [admon], [oper], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (178, 29, N'4', N'4', N'4', N'4', N'4', N'4', CAST(N'2018-07-16T00:00:00.000' AS DateTime), N'admin', CAST(N'2018-07-16T00:00:00.000' AS DateTime), N'admin')
INSERT [dbo].[tblCLI_UsuariosAduabook] ([id_usuario_aduabook], [id_precliente], [nombre], [puesto_departamento], [telefono], [correo], [admon], [oper], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (179, 2, N'juan', N'admin', N'334343', N'mail@mail.com', N'sitest', N'opertest', CAST(N'2018-07-17T00:00:00.000' AS DateTime), N'admin', CAST(N'2018-07-17T00:00:00.000' AS DateTime), N'admin')
INSERT [dbo].[tblCLI_UsuariosAduabook] ([id_usuario_aduabook], [id_precliente], [nombre], [puesto_departamento], [telefono], [correo], [admon], [oper], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (180, 2, N'pedro', N'admin', N'33434', N'mail@mail.com', N'sitest', N'opertest', CAST(N'2018-07-17T00:00:00.000' AS DateTime), N'admin', CAST(N'2018-07-17T00:00:00.000' AS DateTime), N'admin')
INSERT [dbo].[tblCLI_UsuariosAduabook] ([id_usuario_aduabook], [id_precliente], [nombre], [puesto_departamento], [telefono], [correo], [admon], [oper], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (181, 2, N'luis', N'emp', N'334343', N'mail@mail.com', N'sitest', N'opertest', CAST(N'2018-07-17T00:00:00.000' AS DateTime), N'admin', CAST(N'2018-07-17T00:00:00.000' AS DateTime), N'admin')
INSERT [dbo].[tblCLI_UsuariosAduabook] ([id_usuario_aduabook], [id_precliente], [nombre], [puesto_departamento], [telefono], [correo], [admon], [oper], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (182, 2, N'fernnado', N'boss', N'229', N'fvargas@gmail.com', N'sistemas', N'operacion', CAST(N'2018-07-17T00:00:00.000' AS DateTime), N'admin', CAST(N'2018-07-17T00:00:00.000' AS DateTime), N'admin')
INSERT [dbo].[tblCLI_UsuariosAduabook] ([id_usuario_aduabook], [id_precliente], [nombre], [puesto_departamento], [telefono], [correo], [admon], [oper], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (183, 32, N'1', N'1', N'1', N'1', N'1', N'1', CAST(N'2018-07-17T00:00:00.000' AS DateTime), N'admin', CAST(N'2018-07-17T00:00:00.000' AS DateTime), N'admin')
SET IDENTITY_INSERT [dbo].[tblCLI_UsuariosAduabook] OFF
ALTER TABLE [dbo].[tblCLI_ClienteAprobador]  WITH CHECK ADD  CONSTRAINT [FK_precliente] FOREIGN KEY([precliente])
REFERENCES [dbo].[tblCLI_Clientes] ([id_precliente])
GO
ALTER TABLE [dbo].[tblCLI_ClienteAprobador] CHECK CONSTRAINT [FK_precliente]
GO
ALTER TABLE [dbo].[tblCLI_ClienteAprobador]  WITH CHECK ADD  CONSTRAINT [FK_usuario] FOREIGN KEY([usuario])
REFERENCES [dbo].[tblCLI_Usuarios] ([id_usuario])
GO
ALTER TABLE [dbo].[tblCLI_ClienteAprobador] CHECK CONSTRAINT [FK_usuario]
GO
ALTER TABLE [dbo].[tblCLI_InfoFinancieraCobranza]  WITH CHECK ADD  CONSTRAINT [FK_info_tabulador] FOREIGN KEY([tabulador])
REFERENCES [dbo].[tblCLI_Tabulador] ([id_tabulador])
GO
ALTER TABLE [dbo].[tblCLI_InfoFinancieraCobranza] CHECK CONSTRAINT [FK_info_tabulador]
GO
ALTER TABLE [dbo].[tblCLI_Pago]  WITH CHECK ADD  CONSTRAINT [FK_tab_pago] FOREIGN KEY([tabulador_tab])
REFERENCES [dbo].[tblCLI_Tab] ([id_tabuladores])
GO
ALTER TABLE [dbo].[tblCLI_Pago] CHECK CONSTRAINT [FK_tab_pago]
GO
ALTER TABLE [dbo].[tblCLI_Pago]  WITH CHECK ADD  CONSTRAINT [FK_tabulador_pago] FOREIGN KEY([tabulador])
REFERENCES [dbo].[tblCLI_Tabulador] ([id_tabulador])
GO
ALTER TABLE [dbo].[tblCLI_Pago] CHECK CONSTRAINT [FK_tabulador_pago]
GO
ALTER TABLE [dbo].[tblCLI_Tab]  WITH CHECK ADD  CONSTRAINT [FK_tabs_tabuladores] FOREIGN KEY([tabulador])
REFERENCES [dbo].[tblCLI_Tabulador] ([id_tabulador])
GO
ALTER TABLE [dbo].[tblCLI_Tab] CHECK CONSTRAINT [FK_tabs_tabuladores]
GO
ALTER TABLE [dbo].[tblCLI_Tabulador]  WITH CHECK ADD  CONSTRAINT [FK_precliente_tabulador] FOREIGN KEY([precliente])
REFERENCES [dbo].[tblCLI_Clientes] ([id_precliente])
GO
ALTER TABLE [dbo].[tblCLI_Tabulador] CHECK CONSTRAINT [FK_precliente_tabulador]
GO
ALTER TABLE [dbo].[tblCLI_Tabulador]  WITH CHECK ADD  CONSTRAINT [FK_usuario_tabulador] FOREIGN KEY([usuario])
REFERENCES [dbo].[tblCLI_Usuarios] ([id_usuario])
GO
ALTER TABLE [dbo].[tblCLI_Tabulador] CHECK CONSTRAINT [FK_usuario_tabulador]
GO
ALTER TABLE [dbo].[tblCLI_TabuladorCatalogo]  WITH CHECK ADD  CONSTRAINT [FK_tabulador_catalogo_actividad] FOREIGN KEY([tabulador])
REFERENCES [dbo].[tblCLI_Tabulador] ([id_tabulador])
GO
ALTER TABLE [dbo].[tblCLI_TabuladorCatalogo] CHECK CONSTRAINT [FK_tabulador_catalogo_actividad]
GO
ALTER TABLE [dbo].[tblCLI_TarifaVenta]  WITH CHECK ADD  CONSTRAINT [FK_tarifa_tabulador] FOREIGN KEY([tabulador])
REFERENCES [dbo].[tblCLI_Tabulador] ([id_tabulador])
GO
ALTER TABLE [dbo].[tblCLI_TarifaVenta] CHECK CONSTRAINT [FK_tarifa_tabulador]
GO
/****** Object:  StoredProcedure [dbo].[csp_CLI_ActualizarBanderilla]    Script Date: 17/7/2018 20:19:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- ====================================================
-- Author:      Fernando Vargas  
-- Create date: 02/07/2018  
-- Description: Actualiza la banderilla del precliente.
-- ====================================================
CREATE PROCEDURE [dbo].[csp_CLI_ActualizarBanderilla] 
	@id_usuario INT,
	@banderilla BIT
AS
	BEGIN
		UPDATE PortalClientes..tblCLI_Clientes
		SET    banderilla = @banderilla
		WHERE  id_usuario = @id_usuario;
	END

GO
/****** Object:  StoredProcedure [dbo].[csp_CLI_ActualizarCartaEncomienda]    Script Date: 17/7/2018 20:19:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =================================================================
-- Author:      Fernando Vargas  
-- Create date: 02/07/2018  
-- Description: Actualiza la información de la carta del precliente.
-- =================================================================
CREATE PROCEDURE [dbo].[csp_CLI_ActualizarCartaEncomienda] 
	@id_usuario                 INT,
	@domicilio_fiscal_calle     VARCHAR(100),
	@domicilio_fiscal_ciudad    VARCHAR(50),
	@domicilio_fiscal_colonia   VARCHAR(50),
	@domicilio_fiscal_cp        VARCHAR(10),
	@domicilio_fiscal_estado    VARCHAR(50),
	@domicilio_fiscal_municipio VARCHAR(50),
	@domicilio_fiscal_no_ext    VARCHAR(10),
	@domicilio_fiscal_no_int    VARCHAR(10),
	@numero_escritura           VARCHAR(10),
	@nombre_notario             VARCHAR(200),
	@numero_notaria             VARCHAR(10),
	@ciudad_notariado           VARCHAR(50),
	@estado_notariado           VARCHAR(50),
	@membrete_empresa           VARCHAR(50),
	@periodo_compredido_inicio  DATETIME,
	@periodo_compredido_fin     DATETIME,
	@patente_carta_encomienda   VARCHAR(4)
AS
	BEGIN
		UPDATE PortalClientes..tblCLI_Clientes
		SET domicilio_fiscal_calle = @domicilio_fiscal_calle,
			domicilio_fiscal_ciudad  = @domicilio_fiscal_ciudad,
			domicilio_fiscal_colonia = @domicilio_fiscal_colonia,
			domicilio_fiscal_cp = @domicilio_fiscal_cp,
			domicilio_fiscal_estado = @domicilio_fiscal_estado,
			domicilio_fiscal_municipio = @domicilio_fiscal_municipio,
			domicilio_fiscal_no_ext = @domicilio_fiscal_no_ext,
			domicilio_fiscal_no_int = @domicilio_fiscal_no_int,
			numero_escritura = @numero_escritura,
			nombre_notario = @nombre_notario,
			numero_notaria = @numero_notaria,
			ciudad_notariado = @ciudad_notariado,
			estado_notariado = @estado_notariado,
			membrete_empresa = @membrete_empresa,
			periodo_compredido_inicio = @periodo_compredido_inicio,
			periodo_compredido_fin = @periodo_compredido_fin,
			patente_carta_encomienda = @patente_carta_encomienda
		WHERE  id_usuario = @id_usuario;
	END

GO
/****** Object:  StoredProcedure [dbo].[csp_CLI_ActualizarEstatusAprobacionRevalidacion]    Script Date: 17/7/2018 20:19:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		IUHM
-- Create date: 06/JULIO/2018
-- Description: Actualiza al nuevo estatus del "precliente"
--				Revalidacion/Aprobacion 
-- =============================================
CREATE PROCEDURE [dbo].[csp_CLI_ActualizarEstatusAprobacionRevalidacion]	
	 @id_usuario    INT
	,@id_precliente INT
	,@nuevo_estatus INT
	,@observaciones VARCHAR(250)
AS
BEGIN
	--DEBUG 
	--EXEC csp_CLI_ActualizarEstatusAprobacionRevalidacion 1, 1, 6, 'TEST DE OBSERVACIONES 01'

	BEGIN TRAN
	BEGIN TRY
	
	DECLARE @usuario_modificacion VARCHAR(50)

	SET @usuario_modificacion = (	SELECT usuario 
									FROM tblCLI_Usuarios
									WHERE tblCLI_Usuarios.id_usuario = @id_usuario )

	--1. Actualizar estatus en tabla: tblCLI_Clientes
		UPDATE tblCLI_Clientes
		SET estatus = @nuevo_estatus
			,fecha_modificacion= GETDATE()
			,usuario_modificacion =  @usuario_modificacion		
		WHERE tblCLI_Clientes.id_precliente = @id_precliente;


	--2. Insert en tabla: tblCLI_ClienteAprobador 
		INSERT INTO tblCLI_ClienteAprobador(				
				precliente, 
				usuario, 
				observacion, 
				fecha_creacion, 
				usuario_creacion, 
				fecha_modificacion, 
				usuario_modificacion
			)
		VALUES (				
				@id_precliente, 
				@id_usuario, 
				@observaciones, 
				GETDATE(), 
				@usuario_modificacion,
				NULL,
				NULL
			)
	--3. Consumir SP para envio de correos: csp_CLI_EnvioNotificacion

		--EXEC csp_CLI_EnvioNotificacion  @id_precliente
		
		COMMIT TRAN;
		END TRY
	BEGIN CATCH

	ROLLBACK TRAN; 

	DECLARE @ErrorNumber    INT,
			@ErrorMessage   NVARCHAR(4000),
			@ErrorSeverity  INT,
			@ErrorState     INT,
			@ErrorProcedure NVARCHAR(126),
			@msg            NVARCHAR(2000)

	SELECT  @ErrorNumber = ERROR_NUMBER(),
			@ErrorMessage = ERROR_MESSAGE(),
			@ErrorSeverity = ERROR_SEVERITY(),
			@ErrorState = ERROR_STATE(),
			@ErrorProcedure = ERROR_PROCEDURE()

	SELECT  @msg = 'Error No. '
			+ CONVERT (NVARCHAR(10), @ErrorNumber)
			+ ' Descripcion: ' + @ErrorMessage
			+ ' Origen del Error: ' + @ErrorProcedure

	RAISERROR ( @msg,@ErrorSeverity,@ErrorState )

	END CATCH 

END

GO
/****** Object:  StoredProcedure [dbo].[csp_CLI_ActualizarNuevoEstatus]    Script Date: 17/7/2018 20:19:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =======================================================
-- Author:      Fernando Vargas  
-- Create date: 02/07/2018  
-- Description: Actualiza el nuevo estatus del precliente.
-- =======================================================
CREATE PROCEDURE [dbo].[csp_CLI_ActualizarNuevoEstatus] 
	@id_usuario    INT,
	@nuevo_estatus INT
AS
	BEGIN
		UPDATE PortalClientes..tblCLI_Clientes
		SET    estatus = @nuevo_estatus
		WHERE  id_usuario = @id_usuario;
	END

GO
/****** Object:  StoredProcedure [dbo].[csp_CLI_ActualizarValorTerminosCondiciones]    Script Date: 17/7/2018 20:19:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================================================
-- Author:      Fernando Vargas  
-- Create date: 29/06/2018  
-- Description: Actualiza el valor de los términos y condiciones por precliente.
-- =============================================================================
CREATE PROCEDURE [dbo].[csp_CLI_ActualizarValorTerminosCondiciones] 
	@id_precliente                   INT,
	@aceptacion_terminos_condiciones BIT
AS
	BEGIN
		UPDATE dbo.tblCLI_Clientes
		SET    aceptacion_terminos_condiciones = @aceptacion_terminos_condiciones
		WHERE  id_precliente = @id_precliente;
	END

GO
/****** Object:  StoredProcedure [dbo].[csp_CLI_EnvioNotificacion]    Script Date: 17/7/2018 20:19:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--USE PortalClientes
--SELECT * FROM dbo.tblCLI_Clientes
CREATE procedure [dbo].[csp_CLI_EnvioNotificacion]
(
	@IdPrecliente AS INT
)
AS
--DECLARE @IdPrecliente AS INT
--SET @IdPrecliente = 1

DECLARE @PARA AS VARCHAR(MAX) ,
    @ASUNTO AS VARCHAR(MAX) ,
    @CUERPO AS VARCHAR(MAX) ,
    @NombreComercial AS VARCHAR(50) ,
    @EstatusDescr AS VARCHAR(100),
	@IdEstatus AS INT

SELECT  @NombreComercial = CLI.nombre_comercial ,
        @EstatusDescr = EST.descripcion,
		@IdEstatus=CLI.estatus
FROM    dbo.tblCLI_Clientes CLI
        LEFT JOIN dbo.tblCLI_Estatus EST ON EST.id_estatus = CLI.estatus
WHERE   id_precliente = @IdPrecliente

IF @NombreComercial IS NULL
    BEGIN
        SET @NombreComercial = ''
    END
IF @EstatusDescr IS NULL
    BEGIN
        SET @EstatusDescr = ''
    END                              

--obtener correos destinatarios
--*****************************
SELECT  @PARA = ISNULL(( STUFF(REPLACE(( SELECT '#!' + LTRIM(RTRIM(CLI.correo)) AS 'data()'
                                         FROM   [PortalClientes].[dbo].[tblCLI_RolesEstatus] RST
                                                RIGHT JOIN PortalClientes.dbo.tblCLI_Usuarios CLI ON RST.id_rol = CLI.id_rol
                                         WHERE  RST.id_estatus = @IdEstatus
                                       FOR
                                         XML PATH('')
                                       ), ' #!', ';'), 1, 2, '') ), '')

SET @ASUNTO = @EstatusDescr + ' (' + CAST(@IdPrecliente AS VARCHAR(20)) + ')'

SET @CUERPO = '<table>'
    + '<tr><td style=''width:150px''>Id precliente</td><td>'
    + CAST(@IdPrecliente AS VARCHAR(30)) + '</td></tr>'
    + '<tr><td>Nombre comercial</td><td>' + @NombreComercial + '</td></tr>'
    + '<tr><td>Estatus</td><td>' + @EstatusDescr + '</td></tr>' + '</table>'

--PRINT 'destinatarios:' + @PARA
--PRINT 'subject:' + @ASUNTO
--PRINT 'body:' + @CUERPO

INSERT  INTO [ADUASIS].[dbo].[Exception_Emails]
        ( [From] ,
          [To] ,
          [Subject] ,
          [Body] ,
          [Smtp] ,
          [User] ,
          [date] ,
          [sent]
        )
VALUES  ( 'serviciosit.int@grupoei.com.mx' ,
          @PARA ,
          @ASUNTO ,
          @CUERPO ,
          'smtp-relay.gmail.com' ,
          'portalclientes@onecore.mx' ,
          GETDATE() ,
          '0'
        )

GO
/****** Object:  StoredProcedure [dbo].[csp_CLI_GuardarCuestionarioSeguridad]    Script Date: 17/7/2018 20:19:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- ================================================================================
-- Author:      Fernando Vargas  
-- Create date: 02/07/2018  
-- Description: Guarda las observacions a las cuestiones de seguridad del precliente.
-- ================================================================================
CREATE PROCEDURE [dbo].[csp_CLI_GuardarCuestionarioSeguridad] 
	@id_precliente  INT,
	@id_usuario     INT,
	@respuesta01    BIT,
	@respuesta02    BIT,
	@respuesta03    BIT,
	@respuesta04    BIT,
	@respuesta05    BIT,
	@respuesta06    BIT,
	@respuesta07    BIT,
	@respuesta08    BIT,
	@respuesta09    BIT,
	@respuesta10    BIT,
	@respuesta11    BIT,
	@respuesta12    BIT,
	@respuesta13    BIT,
	@respuesta14    BIT,
	@respuesta15    BIT,
	@respuesta16    BIT,
	@respuesta17    BIT,
	@respuesta18    BIT,
	@respuesta19    BIT,
	@respuesta20    BIT,
	@observacion01  VARCHAR(100),
	@observacion02  VARCHAR(100),
	@observacion03  VARCHAR(100),
	@observacion04  VARCHAR(100),
	@observacion05  VARCHAR(100),
	@observacion06  VARCHAR(100),
	@observacion07  VARCHAR(100),
	@observacion08  VARCHAR(100),
	@observacion09  VARCHAR(100),
	@observacion10  VARCHAR(100),
	@observacion11  VARCHAR(100),
	@observacion12  VARCHAR(100),
	@observacion13  VARCHAR(100),
	@observacion14  VARCHAR(100),
	@observacion15  VARCHAR(100),
	@observacion16  VARCHAR(100),
	@observacion17  VARCHAR(100),
	@observacion18  VARCHAR(100),
	@observacion19  VARCHAR(100),
	@observacion20  VARCHAR(100),
	@certificacion1 VARCHAR(10),
	@certificacion2 VARCHAR(10),
	@numero_puertos VARCHAR(3)
AS
	BEGIN
		-- Pregunta 01
		INSERT PortalClientes..tblCLI_Respuestas
		(id_precliente
		,id_pregunta
		,respuesta
		,observacion
		,fecha_creacion
		,usuario_creacion)
		VALUES
		(@id_precliente
		,1
		,@respuesta01
		,@observacion01
		,GETDATE()
		,@id_usuario);
		
		-- Pregunta 02
		INSERT PortalClientes..tblCLI_Respuestas
		(id_precliente
		,id_pregunta
		,respuesta
		,observacion
		,fecha_creacion
		,usuario_creacion)
		VALUES
		(@id_precliente
		,2
		,@respuesta02
		,@observacion02
		,GETDATE()
		,@id_usuario);
		
		-- Pregunta 03
		INSERT PortalClientes..tblCLI_Respuestas
		(id_precliente
		,id_pregunta
		,respuesta
		,observacion
		,fecha_creacion
		,usuario_creacion)
		VALUES
		(@id_precliente
		,3
		,@respuesta03
		,@observacion03
		,GETDATE()
		,@id_usuario);
		
		-- Pregunta 04
		INSERT PortalClientes..tblCLI_Respuestas
		(id_precliente
		,id_pregunta
		,respuesta
		,observacion
		,fecha_creacion
		,usuario_creacion)
		VALUES
		(@id_precliente
		,4
		,@respuesta04
		,@observacion04
		,GETDATE()
		,@id_usuario);
		
		-- Pregunta 05
		INSERT PortalClientes..tblCLI_Respuestas
		(id_precliente
		,id_pregunta
		,respuesta
		,observacion
		,fecha_creacion
		,usuario_creacion)
		VALUES
		(@id_precliente
		,5
		,@respuesta05
		,@observacion05
		,GETDATE()
		,@id_usuario);
		
		-- Pregunta 06
		INSERT PortalClientes..tblCLI_Respuestas
		(id_precliente
		,id_pregunta
		,respuesta
		,observacion
		,fecha_creacion
		,usuario_creacion)
		VALUES
		(@id_precliente
		,6
		,@respuesta06
		,@observacion06
		,GETDATE()
		,@id_usuario);
		
		-- Pregunta 07
		INSERT PortalClientes..tblCLI_Respuestas
		(id_precliente
		,id_pregunta
		,respuesta
		,observacion
		,fecha_creacion
		,usuario_creacion)
		VALUES
		(@id_precliente
		,7
		,@respuesta07
		,@observacion07
		,GETDATE()
		,@id_usuario);
		
		-- Pregunta 08
		INSERT PortalClientes..tblCLI_Respuestas
		(id_precliente
		,id_pregunta
		,respuesta
		,observacion
		,fecha_creacion
		,usuario_creacion)
		VALUES
		(@id_precliente
		,8
		,@respuesta08
		,@observacion08
		,GETDATE()
		,@id_usuario);
		
		-- Pregunta 09
		INSERT PortalClientes..tblCLI_Respuestas
		(id_precliente
		,id_pregunta
		,respuesta
		,observacion
		,fecha_creacion
		,usuario_creacion)
		VALUES
		(@id_precliente
		,9
		,@respuesta09
		,@observacion09
		,GETDATE()
		,@id_usuario);
		
		-- Pregunta 10
		INSERT PortalClientes..tblCLI_Respuestas
		(id_precliente
		,id_pregunta
		,respuesta
		,observacion
		,fecha_creacion
		,usuario_creacion)
		VALUES
		(@id_precliente
		,10
		,@respuesta10
		,@observacion10
		,GETDATE()
		,@id_usuario
		);
		
		-- Pregunta 11
		INSERT PortalClientes..tblCLI_Respuestas
		(id_precliente
		,id_pregunta
		,respuesta
		,observacion
		,fecha_creacion
		,usuario_creacion)
		VALUES
		(@id_precliente
		,11
		,@respuesta11
		,@observacion11
		,GETDATE()
		,@id_usuario);
		
		-- Pregunta 12
		INSERT PortalClientes..tblCLI_Respuestas
		(id_precliente
		,id_pregunta
		,respuesta
		,observacion
		,fecha_creacion
		,usuario_creacion)
		VALUES
		(@id_precliente
		,12
		,@respuesta12
		,@observacion12
		,GETDATE()
		,@id_usuario);
		
		-- Pregunta 13
		INSERT PortalClientes..tblCLI_Respuestas
		(id_precliente
		,id_pregunta
		,respuesta
		,observacion
		,fecha_creacion
		,usuario_creacion)
		VALUES
		(@id_precliente
		,13
		,@respuesta13
		,@observacion13
		,GETDATE()
		,@id_usuario);
		
		-- Pregunta 14
		INSERT PortalClientes..tblCLI_Respuestas
		(id_precliente
		,id_pregunta
		,respuesta
		,observacion
		,fecha_creacion
		,usuario_creacion)
		VALUES
		(@id_precliente
		,14
		,@respuesta14
		,@observacion14
		,GETDATE()
		,@id_usuario);
		
		-- Pregunta 15
		INSERT PortalClientes..tblCLI_Respuestas
		(id_precliente
		,id_pregunta
		,respuesta
		,observacion
		,fecha_creacion
		,usuario_creacion)
		VALUES
		(
		@id_precliente
		,15
		,@respuesta15
		,@observacion15
		,GETDATE()
		,@id_usuario);
		
		-- Pregunta 16
		INSERT PortalClientes..tblCLI_Respuestas
		(id_precliente
		,id_pregunta
		,respuesta
		,observacion
		,fecha_creacion
		,usuario_creacion)
		VALUES
		(@id_precliente
		,16
		,@respuesta16
		,@observacion16
		,GETDATE()
		,@id_usuario);
		
		-- Pregunta 17
		INSERT PortalClientes..tblCLI_Respuestas
		(id_precliente
		,id_pregunta
		,respuesta
		,observacion
		,fecha_creacion
		,usuario_creacion)
		VALUES
		(@id_precliente
		,17
		,@respuesta17
		,@observacion17
		,GETDATE()
		,@id_usuario);
		
		-- Pregunta 18
		INSERT PortalClientes..tblCLI_Respuestas
		(id_precliente
		,id_pregunta
		,respuesta
		,observacion
		,fecha_creacion
		,usuario_creacion)
		VALUES
		(@id_precliente
		,18
		,@respuesta18
		,@observacion18
		,GETDATE()
		,@id_usuario
		);
		
		-- Pregunta 19
		INSERT PortalClientes..tblCLI_Respuestas
		(id_precliente
		,id_pregunta
		,respuesta
		,observacion
		,fecha_creacion
		,usuario_creacion)
		VALUES
		(@id_precliente
		,19
		,@respuesta19
		,@observacion19
		,GETDATE()
		,@id_usuario);
		
		-- Pregunta 20
		INSERT PortalClientes..tblCLI_Respuestas
		(id_precliente
		,id_pregunta
		,respuesta
		,observacion
		,fecha_creacion
		,usuario_creacion)
		VALUES
		(@id_precliente
		,20
		,@respuesta20
		,@observacion20
		,GETDATE()
		,@id_usuario);
		
		UPDATE PortalClientes..tblCLI_Clientes
		SET    certificacion1 = @certificacion1,
	           certificacion2 = @certificacion2,
	           numero_puertos = @numero_puertos
		WHERE id_usuario = @id_usuario;
		
	END

GO
/****** Object:  StoredProcedure [dbo].[csp_CLI_GuardarRevisionDocumentosCliente]    Script Date: 17/7/2018 20:19:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =================================================
-- Author:      GDLS  
-- Create date: 13/07/2018  
-- Description: Guarda la aprobacion de la revision de los documentos.
-- =================================================
CREATE PROCEDURE [dbo].[csp_CLI_GuardarRevisionDocumentosCliente] 
	@id_precliente INT,
	@id_usuario varchar (50)
AS
BEGIN
	BEGIN TRY
		BEGIN TRAN
       update dbo.tblCLI_DocumentosCliente 
       	set id_usuario_revision=@id_usuario,
       	fecha_revision=GETDATE()
        WHERE id_precliente= @id_precliente 
		and activo=1 ;
	SELECT 1 AS Resultado;
		COMMIT TRAN;
	END TRY
	BEGIN CATCH

	ROLLBACK TRAN; 
	DECLARE @ErrorNumber    INT,
			@ErrorMessage   NVARCHAR(4000),
			@ErrorSeverity  INT,
			@ErrorState     INT,
			@ErrorProcedure NVARCHAR(126),
			@msg            NVARCHAR(2000)

	SELECT  @ErrorNumber = ERROR_NUMBER(),
			@ErrorMessage = ERROR_MESSAGE(),
			@ErrorSeverity = ERROR_SEVERITY(),
			@ErrorState = ERROR_STATE(),
			@ErrorProcedure = ERROR_PROCEDURE()

	SELECT  @msg = 'Error No. '
			+ CONVERT (NVARCHAR(10), @ErrorNumber)
			+ ' Descripcion: ' + @ErrorMessage
			+ ' Origen del Error: ' + @ErrorProcedure

	RAISERROR ( @msg,@ErrorSeverity,@ErrorState )

	END CATCH 

END
GO
/****** Object:  StoredProcedure [dbo].[csp_CLI_ObtenerCiudades]    Script Date: 17/7/2018 20:19:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- ===============================================================================================
-- Author:      Fernando Vargas  
-- Create date: 30/06/2018  
-- Description: Se obtiene el nombre de las ciudades del catálogo de ADUASIS de acuerdo al estado.
-- ===============================================================================================
CREATE PROCEDURE [dbo].[csp_CLI_ObtenerCiudades] 
	@id_estado VARCHAR(50)
AS
	BEGIN
		SELECT   id_municipio, descripcion AS ciudad
		FROM     Aduasis..FMunicipio
		WHERE    id_estado = @id_estado
		AND      (ISNUMERIC(id_municipio) = 1)
		ORDER BY descripcion ASC;
	END

GO
/****** Object:  StoredProcedure [dbo].[csp_CLI_ObtenerContactosCliente]    Script Date: 17/7/2018 20:19:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- ===============================================
-- Author:      Fernando Vargas  
-- Create date: 04/07/2018  
-- Description: Obtiene los contactos del cliente.
-- ===============================================
CREATE PROCEDURE [dbo].[csp_CLI_ObtenerContactosCliente] 
	@id_precliente INT
AS
	BEGIN
		SELECT nombre, correo, telefono, area, puesto_departamento
		FROM   PortalClientes..tblCLI_Contactos
		WHERE  id_precliente = @id_precliente;
	END

GO
/****** Object:  StoredProcedure [dbo].[csp_CLI_ObtenerCuentasBancariasPECACliente]    Script Date: 17/7/2018 20:19:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =========================================================================
-- Author:      Fernando Vargas  
-- Create date: 04/07/2018  
-- Description: Obtiene los datos bancarios de las cuentas PECA del cliente.
-- =========================================================================
CREATE PROCEDURE [dbo].[csp_CLI_ObtenerCuentasBancariasPECACliente] 
	@id_precliente INT
AS
	BEGIN
		SELECT banco, numero_cuenta, identificador, patentes_autorizadas, aduana, id_banco
		FROM   PortalClientes..tblCLI_CuentasBancariasPECA
		WHERE  id_precliente = @id_precliente;
	END

GO
/****** Object:  StoredProcedure [dbo].[csp_CLI_ObtenerCuestionarioCliente]    Script Date: 17/7/2018 20:19:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =================================================
-- Author:      Fernando Vargas  
-- Create date: 04/07/2018  
-- Description: Obtiene el cuestionario del cliente.
-- =================================================
CREATE PROCEDURE [dbo].[csp_CLI_ObtenerCuestionarioCliente] 
	@id_precliente INT
AS
	BEGIN
		SELECT   id_pregunta, respuesta, observacion
		FROM     PortalClientes..tblCLI_Respuestas
		WHERE    id_precliente = @id_precliente
		ORDER BY id_pregunta ASC;
	END

GO
/****** Object:  StoredProcedure [dbo].[csp_CLI_ObtenerDatosUsuario]    Script Date: 17/7/2018 20:19:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =======================================================
-- Author:      Fernando Vargas  
-- Create date: 29/06/2018  
-- Description: Se obtiene los datos del usuario logueado.
-- =======================================================
CREATE PROCEDURE [dbo].[csp_CLI_ObtenerDatosUsuario] 
	@usuario VARCHAR(50)
AS
	BEGIN
	
		DECLARE @id_precliente INT;
		DECLARE @id_usuario    INT;
		DECLARE @datos_usuario TABLE
		(
		  id_usuario INT,
		  id_rol     INT,
		  nombre     VARCHAR(200),
		  usuario    VARCHAR(50),
		  correo     VARCHAR(50)
		);
		
		INSERT @datos_usuario(id_usuario, id_rol, nombre, usuario, correo)
			SELECT id_usuario, id_rol, nombre, usuario, correo
			FROM   PortalClientes..tblCLI_Usuarios
			WHERE  usuario = @usuario;
		
		SET @id_usuario =
		(
			SELECT id_usuario
			FROM   @datos_usuario
		);
		
		SET @id_precliente = 
		(
			SELECT id_precliente
			FROM   PortalClientes..tblCLI_Clientes
			WHERE  id_usuario = @id_usuario
		);
		
		IF @id_precliente IS NULL
			BEGIN
				SET @id_precliente = '';
			END
		
		SELECT id_usuario, id_rol, nombre, usuario, correo, @id_precliente AS id_precliente
		FROM   @datos_usuario;
			
	END

GO
/****** Object:  StoredProcedure [dbo].[csp_CLI_ObtenerDestinatariosNotificacion]    Script Date: 17/7/2018 20:19:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- ===========================================================================================
-- Author:      Fernando Vargas  
-- Create date: 29/06/2018  
-- Description: Se obtiene los destinatarios para la notificación de acuerdo al nuevo estatus.
-- ===========================================================================================
CREATE PROCEDURE [dbo].[csp_CLI_ObtenerDestinatariosNotificacion] 
	@id_nuevo_estatus INT,
	@id_precliente    INT
AS
	BEGIN
		DECLARE @nombre_comercial          VARCHAR(50);
		DECLARE @descripcion_nuevo_estatus VARCHAR(100);
		DECLARE @correos                   VARCHAR(500);
		
		SET @nombre_comercial = 
		(
			SELECT nombre_comercial
			FROM   PortalClientes..tblCLI_Clientes
			WHERE  id_precliente = @id_precliente
		);
		
		SET @descripcion_nuevo_estatus =
		(
			SELECT descripcion
			FROM   PortalClientes..tblCLI_Estatus
			WHERE  id_estatus = @id_nuevo_estatus
		);
		
		SET @correos =
		(
			SELECT STUFF
			((
				SELECT     ',' + US.correo
				FROM       PortalClientes..tblCLI_RolesEstatus REST
				INNER JOIN PortalClientes..tblCLI_Usuarios US
				ON         US.id_rol = REST.id_rol
				WHERE      REST.id_estatus = @id_nuevo_estatus
				FOR XML PATH('')
			) ,1,1,'')
		);
		
		SELECT @nombre_comercial AS nombre_comercial, @descripcion_nuevo_estatus AS estatus, @correos AS correos;
		
	END

GO
/****** Object:  StoredProcedure [dbo].[csp_CLI_ObtenerDireccionCliente]    Script Date: 17/7/2018 20:19:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- ==============================================
-- Author:      Fernando Vargas  
-- Create date: 06/07/2018  
-- Description: Obtener la dirección del cliente.
-- ==============================================
CREATE PROCEDURE [dbo].[csp_CLI_ObtenerDireccionCliente] 
	@id_precliente INT
AS
	BEGIN
		SELECT    CLI.nombre_comercial,
			      ISNULL((CLI.calle + ' ' + CLI.no_ext + ' ' + CLI.no_int + ' ' + CLI.colonia + ' ' + MU.descripcion + ' ' + ES.descripcion + ' ' + PA.descripcion),'') AS direccion
		FROM      PortalClientes..tblCLI_Clientes CLI
		LEFT JOIN Aduasis..Fpais PA
		ON        PA.id_pais = CLI.id_pais
		LEFT JOIN Aduasis..Festado ES
		ON        ES.id_estado = CLI.id_estado
		LEFT JOIN Aduasis..Fmunicipio MU
		ON        MU.id_municipio = CLI.id_ciudad
		WHERE     id_precliente = @id_precliente;
	END

GO
/****** Object:  StoredProcedure [dbo].[csp_CLI_ObtenerDocumentosCliente]    Script Date: 17/7/2018 20:19:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =================================================
-- Author:      GDLS  
-- Create date: 10/07/2018  
-- Description: Obtiene los documentos del cliente.
-- =================================================
CREATE PROCEDURE [dbo].[csp_CLI_ObtenerDocumentosCliente] 
	@id_precliente INT
AS
	BEGIN

		SELECT id_precliente, id_documento,REPLACE(ruta_local,'C:\portac\PortalCliente\PortalCliente.Web\','') as ruta_local
		FROM dbo.tblCLI_DocumentosCliente
        WHERE id_precliente= @id_precliente 
		and activo=1 
        ORDER BY id_documento ASC;
	END

GO
/****** Object:  StoredProcedure [dbo].[csp_CLI_ObtenerEstados]    Script Date: 17/7/2018 20:19:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- ============================================================================================
-- Author:      Fernando Vargas  
-- Create date: 30/06/2018  
-- Description: Se obtiene el nombre de los estatos del catálogo de ADUASIS de acuerdo al país.
-- ============================================================================================
CREATE PROCEDURE [dbo].[csp_CLI_ObtenerEstados] 
	@id_pais VARCHAR(50)
AS
	BEGIN
		SELECT   id_estado, descripcion AS estado
		FROM     Aduasis..FEstado
		WHERE    id_pais = @id_pais
		AND      (ISNUMERIC(id_estado) = 1)
		ORDER BY descripcion ASC;
	END

GO
/****** Object:  StoredProcedure [dbo].[csp_CLI_ObtenerEstatusTerminosCondiciones]    Script Date: 17/7/2018 20:19:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- ==============================================================================
-- Author:      Fernando Vargas  
-- Create date: 29/06/2018  
-- Description: Se obtiene el valor de los términos y condiciones por precliente.
-- ==============================================================================
CREATE PROCEDURE [dbo].[csp_CLI_ObtenerEstatusTerminosCondiciones] 
	@id_usuario INT
AS
	BEGIN
		SELECT aceptacion_terminos_condiciones
		FROM   PortalClientes..tblCLI_Clientes
		WHERE  id_usuario = @id_usuario;
	END

GO
/****** Object:  StoredProcedure [dbo].[csp_CLI_ObtenerInfoCartaEncomienda]    Script Date: 17/7/2018 20:19:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =================================================================
-- Author:      José Antonio González  
-- Create date: 11/07/2018  
-- Description: Obtiene la información de la carta del precliente.
-- =================================================================
--exec csp_CLI_ObtenerInfoCartaEncomienda 1
CREATE PROCEDURE [dbo].[csp_CLI_ObtenerInfoCartaEncomienda] @id_usuario INT
AS
    BEGIN
        SELECT  domicilio_fiscal_calle ,
                domicilio_fiscal_ciudad ,
                domicilio_fiscal_colonia ,
                domicilio_fiscal_cp ,
                domicilio_fiscal_estado ,
                domicilio_fiscal_municipio ,
                domicilio_fiscal_no_ext ,
                domicilio_fiscal_no_int ,
                numero_escritura ,
                nombre_notario ,
                numero_notaria ,
                ciudad_notariado ,
                estado_notariado ,
                membrete_empresa ,
                CONVERT(NVARCHAR(MAX), periodo_compredido_inicio, 103) periodo_compredido_inicio ,
                CONVERT(NVARCHAR(MAX), periodo_compredido_fin, 103) periodo_compredido_fin ,
                patente_carta_encomienda + '|' + ISNULL(PAT.nombre, '') + '|'
                + ISNULL(PAT.direccion, 'DIRECCION EJEMPLO') patente_carta_encomienda
        FROM    PortalClientes..tblCLI_Clientes CLI
                LEFT JOIN PortalClientes..tblCLI_Patentes PAT ON CLI.patente_carta_encomienda = PAT.patente
        WHERE   id_usuario = @id_usuario;
    END

GO
/****** Object:  StoredProcedure [dbo].[csp_CLI_ObtenerInformacionCliente]    Script Date: 17/7/2018 20:19:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- ================================================
-- Author:      Fernando Vargas  
-- Create date: 02/07/2018  
-- Description: Obtener la información del cliente.
-- ================================================
CREATE PROCEDURE [dbo].[csp_CLI_ObtenerInformacionCliente] 
	@id_usuario INT
AS
	BEGIN
		SELECT    CLI.id_precliente,
			      CLI.id_usuario,
			      CLI.id_cliente_aduasis,
			      CLI.id_cliente_gp,
			      CLI.es_cliente,
			      CLI.representante_legal,
			      CLI.nombre_fiscal,
			      CLI.rfc,
			      CLI.nombre_comercial,
			      CLI.calle,
			      CLI.no_ext,
			      CLI.no_int,
			      CLI.colonia,
			      CLI.id_ciudad,
				  MU.descripcion AS ciudad,
			      CLI.cp,
			      CLI.id_estado,
				  ES.descripcion AS estado,
			      CLI.id_pais,
				  PA.descripcion AS pais,
			      CLI.telefono,
			      CLI.giro,
			      CLI.tiempo_establecido,
			      CLI.numero_empleados,
			      CLI.ventas_anuales,
			      CLI.pagina_web,
			      CLI.patentes_operacion,
			      CLI.frecuencia_embarques,
			      CLI.vucem_cliente,
			      CLI.vucem_grupoei,
			      CLI.correos_arribo_embarque,
			      CLI.banco,
			      CLI.numero_cuenta,
			      CLI.clabe_interbancaria,
			      CLI.moneda,
			      CLI.sucursal_banco,
			      CLI.ciudad_banco,
			      CLI.certificacion1,
			      CLI.certificacion2,
			      CLI.numero_puertos,
			      CLI.con_carta_encomienda_respaldo,
			      CLI.motivo_sin_carta_encomienda_respaldo,
			      CLI.banderilla,
			      CLI.estatus,
			      CLI.aceptacion_terminos_condiciones,
			      CLI.domicilio_fiscal_calle,
			      CLI.domicilio_fiscal_ciudad,
			      CLI.domicilio_fiscal_colonia,
			      CLI.domicilio_fiscal_cp,
			      CLI.domicilio_fiscal_estado,
			      CLI.domicilio_fiscal_municipio,
			      CLI.domicilio_fiscal_no_ext,
			      CLI.domicilio_fiscal_no_int,
			      CLI.numero_escritura,
			      CLI.nombre_notario,
			      CLI.numero_notaria,
			      CLI.ciudad_notariado,
			      CLI.estado_notariado,
			      CLI.membrete_empresa,
			      CLI.periodo_compredido_inicio,
			      CLI.periodo_compredido_fin,
			      PAT.patente,
			      PAT.nombre
		FROM      PortalClientes..tblCLI_Clientes CLI
		LEFT JOIN PortalClientes..tblCLI_Patentes PAT
		ON        PAT.patente = CLI.patente_carta_encomienda
		LEFT JOIN Aduasis..Fpais PA
		ON        PA.id_pais = CLI.id_pais
		LEFT JOIN Aduasis..Festado ES
		ON        ES.id_estado = CLI.id_estado
		LEFT JOIN Aduasis..Fmunicipio MU
		ON        MU.id_municipio = CLI.id_ciudad
		WHERE     id_usuario = @id_usuario;
	END

GO
/****** Object:  StoredProcedure [dbo].[csp_CLI_ObtenerNotificacionesUsuario]    Script Date: 17/7/2018 20:19:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- ===============================================================
-- Author:      Fernando Vargas  
-- Create date: 29/06/2018  
-- Description: Se obtiene las notificaciones activas del usuario.
-- ===============================================================
CREATE PROCEDURE [dbo].[csp_CLI_ObtenerNotificacionesUsuario] 
	@id_usuario INT,
	@id_rol     INT
AS
	BEGIN
		IF @id_rol = '2' -- Pre/Cliente
			BEGIN
				SELECT     US.id_notificacion_usuario, CLI.id_precliente, CLI.nombre_comercial, NOTI.descripcion AS Notificacion, CLI.estatus 
				FROM       PortalClientes..tblCLI_NotificacionesUsuario US
				INNER JOIN PortalClientes..tblCLI_Clientes CLI
				ON         CLI.id_usuario = US.para_id_usuario
				INNER JOIN PortalClientes..tblCLI_Notificaciones NOTI
				ON         NOTI.id_notificacion = US.id_notificacion
				WHERE      US.para_id_usuario = @id_usuario
				AND        US.activo = '1';
			END
		ELSE -- Diferente a Pre/Cliente
			BEGIN
				SELECT     US.id_notificacion_usuario, CLI.id_precliente, CLI.nombre_comercial, NOTI.descripcion AS Notificacion, CLI.estatus
				FROM       PortalClientes..tblCLI_NotificacionesUsuario US
				INNER JOIN PortalClientes..tblCLI_Clientes CLI
				ON         CLI.id_usuario = US.de_id_usuario
				INNER JOIN PortalClientes..tblCLI_Notificaciones NOTI
				ON         NOTI.id_notificacion = US.id_notificacion
				WHERE      US.para_rol = @id_rol
				AND        US.activo = '1';
			END
	END

GO
/****** Object:  StoredProcedure [dbo].[csp_CLI_ObtenerPaises]    Script Date: 17/7/2018 20:19:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- ========================================================================
-- Author:      Fernando Vargas  
-- Create date: 30/06/2018  
-- Description: Se obtiene el nombre de los países del catálogo de ADUASIS.
-- ========================================================================
CREATE PROCEDURE [dbo].[csp_CLI_ObtenerPaises] 
AS
	BEGIN
		SELECT   id_pais, descripcion AS pais
		FROM     Aduasis..FPais
		WHERE    descripcion <> ''
		ORDER BY descripcion ASC;
	END

GO
/****** Object:  StoredProcedure [dbo].[csp_CLI_ObtenerPatentes]    Script Date: 17/7/2018 20:19:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- ===============================================================
-- Author:      Fernando Vargas  
-- Create date: 03/07/2018  
-- Description: Se obtienen las patentes de acuerdo a su catálogo.
-- ===============================================================
CREATE PROCEDURE [dbo].[csp_CLI_ObtenerPatentes] 
AS
	BEGIN
		SELECT id_patente, patente, nombre, ISNULL(direccion,'DIRECCION EJEMPLO') AS direccion
		FROM   PortalClientes..tblCLI_Patentes;
	END

GO
/****** Object:  StoredProcedure [dbo].[csp_CLI_ObtenerPreclientes]    Script Date: 17/7/2018 20:19:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- ===============================================================================================
-- Author:	Irving Ulises Herrera Molina
-- Create date: 04/07/2018  
-- Description: Obtiene la lista de preclientes para el combo de busqueda.
-- EXEC [dbo].[csp_CLI_ObtenerPreclientes] 
-- ===============================================================================================
CREATE PROCEDURE [dbo].[csp_CLI_ObtenerPreclientes] 
AS
	BEGIN
		SELECT
		id_precliente,
		id_usuario,
		estatus,
		nombre_comercial
		FROM PortalClientes.dbo.tblCLI_Clientes
		ORDER BY nombre_comercial ASC;
	END

GO
/****** Object:  StoredProcedure [dbo].[csp_CLI_ObtenerRelacionPreclienteAprobador]    Script Date: 17/7/2018 20:19:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- ===============================================================================================
-- Author:	Irving Ulises Herrera Molina
-- Create date: 12/07/2018  
-- Description: Obtiene la lista de aprobadores de un precliente en especifico
-- EXEC [dbo].[csp_CLI_ObtenerRelacionPreclienteAprobador] 1
-- ===============================================================================================
CREATE PROCEDURE [dbo].[csp_CLI_ObtenerRelacionPreclienteAprobador] 
@id_precliente INT
AS
	BEGIN
		SELECT 
		tblCLI_ClienteAprobador.precliente,
		tblCLI_ClienteAprobador.usuario,
		tblCLI_Usuarios.nombre AS aprobador,
		tblCLI_ClienteAprobador.observacion
		FROM tblCLI_ClienteAprobador
		INNER JOIN tblCLI_Usuarios
		ON tblCLI_Usuarios.id_usuario = tblCLI_ClienteAprobador.usuario
		WHERE tblCLI_ClienteAprobador.precliente = @id_precliente
	END

GO
/****** Object:  StoredProcedure [dbo].[csp_CLI_ObtenerTotalTabuladores]    Script Date: 17/7/2018 20:19:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- ============================================================================================
-- Author:      IUHM
-- Create date: 11-08-2018 
-- Description: Se obtiene el numero de tabuladores correspondiente al usuario y precliente especificado.
-- EXEC [dbo].[csp_CLI_ObtenerTotalTabuladores] 1, 1
-- ============================================================================================
CREATE PROCEDURE [dbo].[csp_CLI_ObtenerTotalTabuladores] 
	@id_usuario INT,
	@id_precliente int
AS
	BEGIN
		SELECT COUNT(*) AS total_tab
		FROM dbo.tblCLI_Tabulador tTabulador
		INNER JOIN tblCLI_Tab tTab
		ON tTab.tabulador = tTabulador.id_tabulador
		WHERE tTabulador.usuario = @id_usuario
		AND tTabulador.precliente = @id_precliente

	END

GO
/****** Object:  StoredProcedure [dbo].[csp_CLI_ObtenerUsuariosAduabookCliente]    Script Date: 17/7/2018 20:19:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- ==========================================================
-- Author:      Fernando Vargas  
-- Create date: 04/07/2018  
-- Description: Obtiene los usuarios de aduabook del cliente.
-- ==========================================================
CREATE PROCEDURE [dbo].[csp_CLI_ObtenerUsuariosAduabookCliente] 
	@id_precliente INT
AS
	BEGIN
		SELECT nombre, puesto_departamento, telefono, correo, admon, oper
		FROM   PortalClientes..tblCLI_UsuariosAduabook
		WHERE  id_precliente = @id_precliente;
	END

GO
/****** Object:  StoredProcedure [dbo].[csp_CLI_ObtieneDocumentos_SP]    Script Date: 17/7/2018 20:19:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/****** Object:  StoredProcedure [dbo].[csp_CLI_ObtieneDocumentos_SP]    
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- ===============================================================
-- Author:      RODRIGO MORA VAZQUEZ
-- Create date: 11/07/2018  
-- Description: Se obtienen las patentes de acuerdo a su catálogo.
-- ===============================================================
*/


CREATE PROCEDURE [dbo].[csp_CLI_ObtieneDocumentos_SP] 

  @idprecliente AS int = NULL
AS
	BEGIN

				SELECT [id_documento_cliente]
					  ,[id_documento]
					  ,[id_precliente]
					  ,[activo]
					  ,[ruta_local]
					  ,[fecha_creacion]
					  ,[usuario_creacion]
					  ,[fecha_modificacion]
					  ,[usuario_modificacion]
				  FROM [dbo].[tblCLI_DocumentosCliente]
				  WHERE id_precliente = @idprecliente
				  and activo = 1 

	END

GO
/****** Object:  StoredProcedure [dbo].[csp_CLI_ObtieneDocumentosCargados]    Script Date: 17/7/2018 20:19:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Rodrigo Mora
-- Create date: 12/07/2017
-- Description:	
-- =============================================
CREATE PROCEDURE [dbo].[csp_CLI_ObtieneDocumentosCargados]
@idprecliente as integer = null
AS
BEGIN
	 select  b.descripcion from [dbo].[tblCLI_DocumentosCliente] a 
	 inner join tblCLI_Documentos b 
	 on a.id_documento = b.id_documento 
	 where a.activo = 1 
	 and a.id_precliente = @idprecliente
	 order by b.id_documento
END

GO
/****** Object:  StoredProcedure [dbo].[csp_CLI_ValidaLogin]    Script Date: 17/7/2018 20:19:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- ==================================================================
-- Author:      Fernando Vargas  
-- Create date: 04/07/2018  
-- Description: Valida si las credenciales del usuario son correctas.
-- ==================================================================
CREATE PROCEDURE [dbo].[csp_CLI_ValidaLogin] 
	@usuario     VARCHAR(50),
	@contrasenia VARCHAR(50)
AS
	BEGIN
	IF EXISTS
	(
		SELECT id_usuario
		FROM   PortalClientes..tblCLI_Usuarios
		WHERE  usuario = @usuario
		AND    contrasenia = @contrasenia
		AND    activo = '1'
	)
		BEGIN
			SELECT 1 AS Resultado;
		END
	ELSE
		IF EXISTS
		(
			SELECT usuario
			FROM   ADUASIS..FUsuario
			WHERE  usuario = @usuario
			AND    password = @contrasenia
		)
			BEGIN
				DECLARE @Activo VARCHAR(1);
				SET @Activo =
				(
					SELECT activo
					FROM   PortalClientes..tblCLI_Usuarios
		            WHERE  usuario = @usuario
				);
				IF @Activo = '1'
					BEGIN
						SELECT 1 AS Resultado;
					END
				ELSE
					BEGIN
						SELECT 0 AS Resultado;
					END
			END
		ELSE
			BEGIN
				SELECT 0 AS Resultado;
			END
	END

GO
/****** Object:  StoredProcedure [dbo].[csp_CLIValidaAudasis_SP]    Script Date: 17/7/2018 20:19:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- ===============================================================
-- Author: Rodrigo Mora Vázquez

-- Create Date:13/07/2018
-- Sp de mantenimiento a la tabla tblCLI_Usuarios
-- ===============================================================
CREATE  PROCEDURE [dbo].[csp_CLIValidaAudasis_SP]
   @usuariodesc AS varchar(200) = NULL
AS
BEGIN
 
         DECLARE @EXISTE AS INTEGER = 0
         SELECT  @EXISTE =  COUNT(1) FROM ADUASIS.DBO.FUSUARIO WHERE UPPER(LTRIM(RTRIM(USUARIO))) = UPPER(LTRIM(RTRIM(@usuariodesc)))
		 select  @EXISTE 'CANT'

END
GO
/****** Object:  StoredProcedure [dbo].[tblCLI_GuardaDatosAdicionales_SP]    Script Date: 17/7/2018 20:19:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Rodrigo Mora Vázquez>
-- Create date: <30/06/2018>
-- Description:	<>
-- =============================================
CREATE PROCEDURE [dbo].[tblCLI_GuardaDatosAdicionales_SP] 	
	@VTelefono as varchar(20) = null,
	@Vid_precliente as integer = null,
	@Vgiro as varchar(30) = null,
	@Vtiempo_establecido as varchar(10) = null,
	@Vnumero_empleados as integer = null,
	@Vventas_anuales as integer = null,
	@Vpagina_web as varchar(100) = null,
	@vpatemtes_operacion as varchar(50) = null,
	@Vfrecuencia as varchar(50) = null,
	@vcorreoarribo as varchar(1000) = null,
	@vvucem_cliente as bit = null ,
	@vvucem_grupoei as bit = null 

AS
BEGIN
      update tblCLI_Clientes
	     set --telefono = @VTelefono,
	         giro = @Vgiro,
	         tiempo_establecido = @Vtiempo_establecido,
	         numero_empleados = @Vnumero_empleados,
	         ventas_anuales = @Vventas_anuales,
	         pagina_web = @Vpagina_web,
	         patentes_operacion = @vpatemtes_operacion,
	         frecuencia_embarques = @Vfrecuencia,
	         correos_arribo_embarque = @vcorreoarribo,
			 vucem_cliente = @vvucem_cliente,
			 vucem_grupoei = @vvucem_grupoei
	   where id_precliente = @Vid_precliente
END



GO
/****** Object:  StoredProcedure [dbo].[tblCLI_GuardarDatoCliente_SP]    Script Date: 17/7/2018 20:19:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		IUHM
-- Create date: 27-06-2018
-- Description:	Guarda los datos de la pestaña datos clientes del menú registro cliente
-- =============================================
CREATE PROCEDURE [dbo].[tblCLI_GuardarDatoCliente_SP]
@cliente dbo.udt_tblCLI_Clientes READONLY,
@contacto dbo.udt_tblCLI_Contactos READONLY,
@cuenta dbo.udt_tblCLI_CuentasBancariasPECA READONLY
AS
BEGIN
	
	BEGIN TRAN
		BEGIN TRY


		--insertar datos cliente
		UPDATE dbo.tblCLI_Clientes
		SET 
			representante_legal = udtCliente.representante_legal,
			nombre_fiscal = udtCliente.nombre_fiscal,
			rfc = udtCliente.rfc, 
			--rfc = udtCliente.rfc + 'tss', 
			nombre_comercial = udtCliente.nombre_comercial, 
			calle = udtCliente.calle, 
			no_ext = udtCliente.no_ext, 
			no_int = udtCliente.no_int, 
			colonia = udtCliente.colonia, 
			id_ciudad = udtCliente.id_ciudad, 
			cp = udtCliente.cp, 
			id_estado = udtCliente.id_estado, 
			id_pais = udtCliente.id_pais, 
			telefono = udtCliente.telefono, 
			banco = udtCliente.banco, 
			numero_cuenta = udtCliente.numero_cuenta, 
			clabe_interbancaria = udtCliente.clabe_interbancaria, 
			moneda = udtCliente.moneda, 
			sucursal_banco = udtCliente.sucursal_banco, 
			ciudad_banco = udtCliente.ciudad_banco, 
			fecha_modificacion = GETDATE(), 
			usuario_modificacion = udtCliente.usuario_modificacion
		FROM dbo.tblCLI_Clientes
		INNER JOIN @cliente udtCliente
		ON udtCliente.id_precliente = dbo.tblCLI_Clientes.id_precliente

		-- obtentemos IDPrecliente
		DECLARE @IDPreCliente INT;
		SET @IDPreCliente = 
		(
			SELECT TOP 1 id_precliente
			FROM @cuenta
		);

		-- eliminamos contactos
		DELETE dbo.tblCLI_Contactos WHERE id_precliente = @IDPreCliente;
		--insertar contactos
		INSERT INTO dbo.tblCLI_Contactos 
			(id_precliente, nombre, correo, telefono, area, puesto_departamento, fecha_creacion, usuario_creacion)
		SELECT 
			id_precliente,
			nombre,
			correo,
			telefono,
			area,
			puesto_departamento,
			GETDATE(),
			usuario_creacion
		FROM @contacto

		-- eliminamos cuentas
		DELETE dbo.tblCLI_CuentasBancariasPECA WHERE id_precliente = @IDPreCliente;
		--insertar cuentas
		INSERT INTO dbo.tblCLI_CuentasBancariasPECA
		(id_precliente, banco, numero_cuenta, identificador, patentes_autorizadas, aduana, fecha_creacion, usuario_creacion)
		SELECT
			id_precliente,
			banco,
			numero_cuenta,
			identificador,
			patentes_autorizadas,
			aduana,
			GETDATE(),
			usuario_creacion
		FROM @cuenta


		COMMIT TRAN;
		END TRY
	BEGIN CATCH

	ROLLBACK TRAN; 

	DECLARE @ErrorNumber    INT,
			@ErrorMessage   NVARCHAR(4000),
			@ErrorSeverity  INT,
			@ErrorState     INT,
			@ErrorProcedure NVARCHAR(126),
			@msg            NVARCHAR(2000)

	SELECT  @ErrorNumber = ERROR_NUMBER(),
			@ErrorMessage = ERROR_MESSAGE(),
			@ErrorSeverity = ERROR_SEVERITY(),
			@ErrorState = ERROR_STATE(),
			@ErrorProcedure = ERROR_PROCEDURE()

	SELECT  @msg = 'Error No. '
			+ CONVERT (NVARCHAR(10), @ErrorNumber)
			+ ' Descripcion: ' + @ErrorMessage
			+ ' Origen del Error: ' + @ErrorProcedure

	RAISERROR ( @msg,@ErrorSeverity,@ErrorState )

	END CATCH 

END



GO
/****** Object:  StoredProcedure [dbo].[tblCLI_GuardarDocumentoCliente_SP]    Script Date: 17/7/2018 20:19:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		IUHM
-- Create date: 29-06-2018
-- Description:	Guarda la relación del precliente con la ubicación de los documentos
-- =============================================
CREATE PROCEDURE [dbo].[tblCLI_GuardarDocumentoCliente_SP]
	@documento dbo.udt_tblCLI_DocumentosCliente READONLY
		
AS
BEGIN

	BEGIN TRAN
		BEGIN TRY

		declare @idprecte as integer = 0 
		declare @iddoc as integer = 0 
		declare @activo as bit = 0 

		SELECT 
			 @iddoc = id_documento,
			 @idprecte = id_precliente, 
			 @activo = activo
		FROM @documento 

		declare @existe as integer = 0 

		select @existe = count(1)
		       from dbo.tblCLI_DocumentosCliente
			   where id_documento = @iddoc and id_precliente = @idprecte and activo = @activo 

		if(@existe > 0)
		begin
		    update dbo.tblCLI_DocumentosCliente
			   set activo = 0 
			   where  id_documento = @iddoc and id_precliente = @idprecte and activo = @activo 
		end 

--insertar documento
		INSERT INTO dbo.tblCLI_DocumentosCliente
			(id_documento, id_precliente, activo, ruta_local, fecha_creacion, usuario_creacion, fecha_modificacion, usuario_modificacion)			
		SELECT 
			id_documento,
			id_precliente, 
			activo, 
			ruta_local, 
			fecha_creacion, 
			usuario_creacion, 
			fecha_modificacion, 
			usuario_modificacion
		FROM @documento
		--WHERE id_documento <> 2
		--AND motivo_sin_carta_encomienda_respaldo IS NULL
		--WHERE motivo_sin_carta_encomienda_respaldo <> ''

		UPDATE tblCLI_Clientes 
		SET tblCLI_Clientes.con_carta_encomienda_respaldo = 1,
			tblCLI_Clientes.motivo_sin_carta_encomienda_respaldo = tblDocumento.motivo_sin_carta_encomienda_respaldo
		FROM tblCLI_Clientes
		INNER JOIN @documento tblDocumento
		ON tblDocumento.id_precliente = tblCLI_Clientes.id_precliente
		WHERE tblDocumento.id_documento = 2
		AND tblDocumento.motivo_sin_carta_encomienda_respaldo IS NOT NULL

				COMMIT TRAN;
		END TRY
	BEGIN CATCH

	ROLLBACK TRAN; 

	DECLARE @ErrorNumber    INT,
			@ErrorMessage   NVARCHAR(4000),
			@ErrorSeverity  INT,
			@ErrorState     INT,
			@ErrorProcedure NVARCHAR(126),
			@msg            NVARCHAR(2000)

	SELECT  @ErrorNumber = ERROR_NUMBER(),
			@ErrorMessage = ERROR_MESSAGE(),
			@ErrorSeverity = ERROR_SEVERITY(),
			@ErrorState = ERROR_STATE(),
			@ErrorProcedure = ERROR_PROCEDURE()

	SELECT  @msg = 'Error No. '
			+ CONVERT (NVARCHAR(10), @ErrorNumber)
			+ ' Descripcion: ' + @ErrorMessage
			+ ' Origen del Error: ' + @ErrorProcedure

	RAISERROR ( @msg,@ErrorSeverity,@ErrorState )

	END CATCH 

END

GO
/****** Object:  StoredProcedure [dbo].[tblCLI_Modulos_SP]    Script Date: 17/7/2018 20:19:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- ===============================================================
-- Author: Rodrigo Mora Vázquez
-- Create Date:28/06/2018
-- Sp de mantenimiento a la tabla tblCLI_Modulos
-- ===============================================================

CREATE PROCEDURE [dbo].[tblCLI_Modulos_SP]
@VOPCION AS INT = 0,
   @Vid_modulo AS int = NULL,
   @Vdescripcion AS varchar(100) = NULL,
   @Vfecha_creacion AS datetime = NULL,
   @Vusuario_creacion AS varchar(50) = NULL,
   @Vfecha_modificacion AS datetime = NULL,
   @Vusuario_modificacion AS varchar(50) = NULL

AS
BEGIN
-- SET NOCOUNT ON added to prevent extra result sets from
  SET NOCOUNT ON;
  BEGIN TRAN
  BEGIN TRY

--======================OPCIONES DEL SP=========================
  -- 1.- GUARDAR
  -- 2.- ACTUALIZAR
  -- 3.- ELIMINAR
  -- 4.- REGRESA TODOS
  -- 5.- REGRESA POR PRIMARY KEY
--==============================================================


  IF(@VOPCION = 1)
  BEGIN
       INSERT INTO tblCLI_Modulos (         
                 descripcion,
                 fecha_creacion,
                 usuario_creacion,
                 fecha_modificacion,
                 usuario_modificacion)

VALUES (            
                 @Vdescripcion,
                 @Vfecha_creacion,
                 @Vusuario_creacion,
                 @Vfecha_modificacion,
                 @Vusuario_modificacion)
  SELECT CAST(SCOPE_IDENTITY()  AS int)

END
  IF(@VOPCION = 2)
  BEGIN
      
         UPDATE tblCLI_Modulos
         SET 
         descripcion = @Vdescripcion,
         fecha_creacion = @Vfecha_creacion,
         usuario_creacion = @Vusuario_creacion,
         fecha_modificacion = @Vfecha_modificacion,
         usuario_modificacion = @Vusuario_modificacion
         WHERE  id_modulo = @Vid_modulo
  END


  IF(@VOPCION = 3)
  BEGIN
      DELETE FROM tblCLI_Modulos
      WHERE id_modulo = @Vid_modulo
  END
  IF(@VOPCION = 4)
  BEGIN
      SELECT 
      id_modulo,
      descripcion,
      fecha_creacion,
      usuario_creacion,
      fecha_modificacion,
      usuario_modificacion
     FROM tblCLI_Modulos
  END
  IF(@VOPCION = 5)
  BEGIN
      SELECT 
      id_modulo,
      descripcion,
      fecha_creacion,
      usuario_creacion,
      fecha_modificacion,
      usuario_modificacion
      FROM tblCLI_Modulos
      WHERE id_modulo = @Vid_modulo
  END
COMMIT TRAN;
END TRY
BEGIN CATCH

ROLLBACK TRAN; 

DECLARE @ErrorNumber    INT,
        @ErrorMessage   NVARCHAR(4000),
        @ErrorSeverity  INT,
        @ErrorState     INT,
        @ErrorProcedure NVARCHAR(126),
        @msg            NVARCHAR(2000)

SELECT  @ErrorNumber = ERROR_NUMBER(),
        @ErrorMessage = ERROR_MESSAGE(),
        @ErrorSeverity = ERROR_SEVERITY(),
        @ErrorState = ERROR_STATE(),
        @ErrorProcedure = ERROR_PROCEDURE()

SELECT  @msg = 'Error No. '
        + CONVERT (NVARCHAR(10), @ErrorNumber)
        + ' Descripcion: ' + @ErrorMessage
        + ' Origen del Error: ' + @ErrorProcedure

RAISERROR ( @msg,@ErrorSeverity,@ErrorState )

END CATCH 

END


GO
/****** Object:  StoredProcedure [dbo].[tblCLI_Roles_SP]    Script Date: 17/7/2018 20:19:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- ===============================================================
-- Author: Rodrigo Mora Vázquez
-- Create Date:27/06/2018
-- Sp de mantenimiento a la tabla tblCLI_Roles
-- ===============================================================

CREATE PROCEDURE [dbo].[tblCLI_Roles_SP]
   @VOPCION AS INT = 0,
   @Vid_rol AS int = NULL,
   @Vdescripcion AS varchar(100) = NULL,
   @Vfecha_creacion AS datetime = NULL,
   @Vusuario_creacion AS varchar(50) = NULL,
   @Vfecha_modificacion AS datetime = NULL,
   @Vusuario_modificacion AS varchar(50) = NULL

AS
BEGIN
-- SET NOCOUNT ON added to prevent extra result sets from
  SET NOCOUNT ON;
  BEGIN TRAN
  BEGIN TRY

--======================OPCIONES DEL SP=========================
  -- 1.- GUARDAR
  -- 2.- ACTUALIZAR
  -- 3.- ELIMINAR
  -- 4.- REGRESA TODOS
  -- 5.- REGRESA POR PRIMARY KEY
--==============================================================


  IF(@VOPCION = 1)
  BEGIN
       INSERT INTO tblCLI_Roles ( 
                   descripcion,
                   fecha_creacion,
                   usuario_creacion,
                   fecha_modificacion,
                   usuario_modificacion)

    VALUES (     @Vdescripcion,
                 @Vfecha_creacion,
                 @Vusuario_creacion,
                 @Vfecha_modificacion,
                 @Vusuario_modificacion)
  SELECT CAST(SCOPE_IDENTITY()  AS int)

END
  IF(@VOPCION = 2)
  BEGIN
      
      UPDATE tblCLI_Roles
         SET 
         descripcion = @Vdescripcion,
         fecha_creacion = @Vfecha_creacion,
         usuario_creacion = @Vusuario_creacion,
         fecha_modificacion = @Vfecha_modificacion,
         usuario_modificacion = @Vusuario_modificacion
WHERE    id_rol = @Vid_rol

  END
  IF(@VOPCION = 3)
  BEGIN
      
      DELETE FROM tblCLI_Roles
      WHERE id_rol = @Vid_rol
  END
  IF(@VOPCION = 4)
  BEGIN
      SELECT 
      id_rol,
      descripcion,
      fecha_creacion,
      usuario_creacion,
      fecha_modificacion,
      usuario_modificacion
     FROM tblCLI_Roles
  END
  IF(@VOPCION = 5)
  BEGIN
      SELECT 
      id_rol,
      descripcion,
      fecha_creacion,
      usuario_creacion,
      fecha_modificacion,
      usuario_modificacion
      FROM tblCLI_Roles
      WHERE id_rol = @Vid_rol
  END
COMMIT TRAN;
END TRY
BEGIN CATCH

ROLLBACK TRAN; 

DECLARE @ErrorNumber    INT,
        @ErrorMessage   NVARCHAR(4000),
        @ErrorSeverity  INT,
        @ErrorState     INT,
        @ErrorProcedure NVARCHAR(126),
        @msg            NVARCHAR(2000)

SELECT  @ErrorNumber = ERROR_NUMBER(),
        @ErrorMessage = ERROR_MESSAGE(),
        @ErrorSeverity = ERROR_SEVERITY(),
        @ErrorState = ERROR_STATE(),
        @ErrorProcedure = ERROR_PROCEDURE()

SELECT  @msg = 'Error No. '
        + CONVERT (NVARCHAR(10), @ErrorNumber)
        + ' Descripcion: ' + @ErrorMessage
        + ' Origen del Error: ' + @ErrorProcedure

RAISERROR ( @msg,@ErrorSeverity,@ErrorState )

END CATCH 

END


GO
/****** Object:  StoredProcedure [dbo].[tblCLI_RolesModulos_SP]    Script Date: 17/7/2018 20:19:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- ===============================================================
-- Author: Rodrigo Mora Vázquez
-- Create Date:27/06/2018
-- Sp de mantenimiento a la tabla tblCLI_RolesModulos
-- ===============================================================

CREATE PROCEDURE [dbo].[tblCLI_RolesModulos_SP]
   @VOPCION AS INT = 0,
   @Vid_rol_modulo AS int = NULL,
   @Vid_rol AS int = NULL,
   @Vid_modulo AS int = NULL,
   @Vfecha_creacion AS datetime = NULL,
   @Vusuario_creacion AS varchar(50) = NULL,
   @Vfecha_modificacion AS datetime = NULL,
   @Vusuario_modificacion AS varchar(50) = NULL

AS
BEGIN
-- SET NOCOUNT ON added to prevent extra result sets from
  SET NOCOUNT ON;
  BEGIN TRAN
  BEGIN TRY

--======================OPCIONES DEL SP=========================
  -- 1.- GUARDAR
  -- 2.- ACTUALIZAR
  -- 3.- ELIMINAR
  -- 4.- REGRESA TODOS
  -- 5.- REGRESA POR PRIMARY KEY
--==============================================================


  IF(@VOPCION = 1)
  BEGIN
       INSERT INTO tblCLI_RolesModulos (    
                 id_rol,
                 id_modulo,
                 fecha_creacion,
                 usuario_creacion,
                 fecha_modificacion,
                 usuario_modificacion)
VALUES (                 
                 @Vid_rol,
                 @Vid_modulo,
                 @Vfecha_creacion,
                 @Vusuario_creacion,
                 @Vfecha_modificacion,
                 @Vusuario_modificacion)
  SELECT CAST(SCOPE_IDENTITY()  AS int)

END
  IF(@VOPCION = 2)
  BEGIN
      UPDATE tblCLI_RolesModulos
         SET 
         id_rol = @Vid_rol,
         id_modulo = @Vid_modulo,
         fecha_creacion = @Vfecha_creacion,
         usuario_creacion = @Vusuario_creacion,
         fecha_modificacion = @Vfecha_modificacion,
         usuario_modificacion = @Vusuario_modificacion
WHERE    id_rol_modulo = @Vid_rol_modulo

  END
  IF(@VOPCION = 3)
  BEGIN
      DELETE FROM tblCLI_RolesModulos
      WHERE id_rol_modulo = @Vid_rol_modulo
  END
  IF(@VOPCION = 4)
  BEGIN
      SELECT 
      id_rol_modulo,
      id_rol,
      id_modulo,
      fecha_creacion,
      usuario_creacion,
      fecha_modificacion,
      usuario_modificacion
     FROM tblCLI_RolesModulos
  END
  IF(@VOPCION = 5)
  BEGIN
      SELECT 
      id_rol_modulo,
      id_rol,
      id_modulo,
      fecha_creacion,
      usuario_creacion,
      fecha_modificacion,
      usuario_modificacion
      FROM tblCLI_RolesModulos
      WHERE id_rol_modulo = @Vid_rol_modulo
  END
COMMIT TRAN;
END TRY
BEGIN CATCH

ROLLBACK TRAN; 

DECLARE @ErrorNumber    INT,
        @ErrorMessage   NVARCHAR(4000),
        @ErrorSeverity  INT,
        @ErrorState     INT,
        @ErrorProcedure NVARCHAR(126),
        @msg            NVARCHAR(2000)

SELECT  @ErrorNumber = ERROR_NUMBER(),
        @ErrorMessage = ERROR_MESSAGE(),
        @ErrorSeverity = ERROR_SEVERITY(),
        @ErrorState = ERROR_STATE(),
        @ErrorProcedure = ERROR_PROCEDURE()

SELECT  @msg = 'Error No. '
        + CONVERT (NVARCHAR(10), @ErrorNumber)
        + ' Descripcion: ' + @ErrorMessage
        + ' Origen del Error: ' + @ErrorProcedure

RAISERROR ( @msg,@ErrorSeverity,@ErrorState )

END CATCH 

END


GO
/****** Object:  StoredProcedure [dbo].[tblCLI_Usuarios_SP]    Script Date: 17/7/2018 20:19:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- ===============================================================
-- Author: Rodrigo Mora Vázquez
-- Create Date:27/06/2018
-- Sp de mantenimiento a la tabla tblCLI_Usuarios
-- ===============================================================

CREATE PROCEDURE [dbo].[tblCLI_Usuarios_SP]
   @VOPCION AS INT = 0,
   @Vid_usuario AS int = NULL,
   @Vid_rol AS int = NULL,
   @Vnombre AS varchar(200) = NULL,
   @Vusuario AS varchar(50) = NULL,
   @Vcontrasenia AS varchar(50) = NULL,
   @Vcorreo AS varchar(50) = NULL,
   @Vfecha_creacion AS datetime = NULL,
   @Vusuario_creacion AS varchar(50) = NULL,
   @Vfecha_modificacion AS datetime = NULL,
   @Vusuario_modificacion AS varchar(50) = NULL,
   @Vactivo as bit = null ,
   @Vgrupo as varchar(100) = null 

AS
BEGIN
-- SET NOCOUNT ON added to prevent extra result sets from
  SET NOCOUNT ON;
  	 --declare @err as varchar(200);
     
  
  BEGIN TRAN
  BEGIN TRY

--======================OPCIONES DEL SP=========================
  -- 1.- GUARDAR
  -- 2.- ACTUALIZAR
  -- 3.- ELIMINAR
  -- 4.- REGRESA TODOS
  -- 5.- REGRESA POR PRIMARY KEY
--==============================================================


  IF(@VOPCION = 1)
  BEGIN

  IF(@Vid_rol <> 2) -- NO ES CLIENTE
  BEGIN
         DECLARE @EXISTE AS INTEGER = 0
         SELECT @EXISTE =  COUNT(1) FROM ADUASIS.DBO.FUSUARIO WHERE UPPER(LTRIM(RTRIM(USUARIO))) = UPPER(LTRIM(RTRIM(@Vusuario)))
		 IF(@EXISTE = 0)
		 BEGIN
	
	         	 declare @err as varchar(200);
				 set @err = N'Cuenta de usuario no existe en Aduasis';
                 RAISERROR (@err, -- Message text.
                              16, -- Severity.
                                1 -- State.
                            );
     		 
		 END  
		 ELSE -- SI EXISTE ENTONCES GUARDARA EL CORREO DE AUDASIS EN PORTAL CLIENTES COMO CORREO 
		 BEGIN
		    SET @Vcorreo = ''
			SELECT @Vcorreo =  isnull(correo_electronico,'sincorreo@enaudasis.com') FROM ADUASIS.DBO.FUSUARIO WHERE UPPER(LTRIM(RTRIM(USUARIO))) = UPPER(LTRIM(RTRIM(@Vusuario)))
		 END 
  END 


  declare @idusr as integer = 0

       INSERT INTO tblCLI_Usuarios (                
                 id_rol,
                 nombre,
                 usuario,
                 contrasenia,
                 correo,
                 fecha_creacion,
                 usuario_creacion,
                 fecha_modificacion,
                 usuario_modificacion,activo, grupo)

VALUES (         @Vid_rol,
                 @Vnombre,
                 @Vusuario,
                 @Vcontrasenia,
                 @Vcorreo,
                 @Vfecha_creacion,
                 @Vusuario_creacion,
                 @Vfecha_modificacion,
                 @Vusuario_modificacion,@Vactivo,@Vgrupo)

  SELECT @idusr  =  CAST(SCOPE_IDENTITY()  AS int)
  
  IF(@Vid_rol = 2) -- ES CLIENTE
  BEGIN
         
            INSERT INTO [dbo].[tblCLI_Clientes]
            (id_usuario,es_cliente,banderilla,estatus,fecha_creacion,usuario_creacion,aceptacion_terminos_condiciones)
			values (@idusr,1,1,1,getdate(),@Vusuario_creacion,0)
  END 

   SELECT @idusr

END
  IF(@VOPCION = 2)
  BEGIN
      
      UPDATE tblCLI_Usuarios
         SET 
         id_rol = @Vid_rol,
         nombre = @Vnombre,
         usuario = @Vusuario,
         contrasenia = @Vcontrasenia,
         correo = @Vcorreo,
         fecha_creacion = @Vfecha_creacion,
         usuario_creacion = @Vusuario_creacion,
         fecha_modificacion = @Vfecha_modificacion,
         usuario_modificacion = @Vusuario_modificacion,
		 activo = @Vactivo,
		 grupo = @Vgrupo
WHERE    id_usuario = @Vid_usuario

  END
  IF(@VOPCION = 3)
  BEGIN
  
      --DELETE FROM tblCLI_Usuarios
      --WHERE id_usuario = @Vid_usuario
	   
	   update tblCLI_Usuarios 
	     set activo = @Vactivo where id_usuario = @Vid_usuario

  END
  IF(@VOPCION = 4)
  BEGIN
      SELECT 
      id_usuario,
      id_rol,
      nombre,
      usuario,
      contrasenia,
      correo,
      fecha_creacion,
      usuario_creacion,
      fecha_modificacion,
      usuario_modificacion,activo, grupo
     FROM tblCLI_Usuarios
	 --where activo = 1 
  END
  IF(@VOPCION = 5)
  BEGIN
      SELECT 
      id_usuario,
      id_rol,
      nombre,
      usuario,
      contrasenia,
      correo,
      fecha_creacion,
      usuario_creacion,
      fecha_modificacion,
      usuario_modificacion, grupo,activo
      FROM tblCLI_Usuarios
      WHERE id_usuario = @Vid_usuario
  END

  IF(@VOPCION = 6) -- OBTIENE SIGUIENTE PRECLIENTE
  BEGIN
      DECLARE @NEXT AS INTEGER = 0 
      SELECT  @NEXT =  MAX(ID_PRECLIENTE) FROM TBLCLI_CLIENTES
	  SELECT (@NEXT + 1) AS Id_PreclienteNext

  END
  
COMMIT TRAN;
END TRY
BEGIN CATCH

ROLLBACK TRAN; 

DECLARE @ErrorNumber    INT,
        @ErrorMessage   NVARCHAR(4000),
        @ErrorSeverity  INT,
        @ErrorState     INT,
        @ErrorProcedure NVARCHAR(126),
        @msg            NVARCHAR(2000)

SELECT  @ErrorNumber = ERROR_NUMBER(),
        @ErrorMessage = ERROR_MESSAGE(),
        @ErrorSeverity = ERROR_SEVERITY(),
        @ErrorState = ERROR_STATE(),
        @ErrorProcedure = ERROR_PROCEDURE()

SELECT  @msg = 'Error No. '
        + CONVERT (NVARCHAR(10), @ErrorNumber)
        + ' Descripcion: ' + @ErrorMessage
        + ' Origen del Error: ' + @ErrorProcedure

RAISERROR ( @msg,@ErrorSeverity,@ErrorState )

END CATCH 

END


GO
/****** Object:  StoredProcedure [dbo].[tblCLI_UsuariosAduabook_SP]    Script Date: 17/7/2018 20:19:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- ===============================================================
-- Author: Rodrigo Mora Vázquez
-- Create Date:02/07/2018
-- Sp de mantenimiento a la tabla tblCLI_UsuariosAduabook
-- ===============================================================

CREATE PROCEDURE [dbo].[tblCLI_UsuariosAduabook_SP]
   @VOPCION AS INT = 0,
   @Vid_usuario_aduabook AS int = NULL,
   @Vid_precliente AS int = NULL,
   @Vnombre AS varchar(100) = NULL,
   @Vpuesto_departamento AS varchar(30) = NULL,
   @Vtelefono AS varchar(20) = NULL,
   @Vcorreo AS varchar(50) = NULL,
   @Vadmon AS varchar(30) = NULL,
   @Voper AS varchar(30) = NULL,
   @Vfecha_creacion AS datetime = NULL,
   @Vusuario_creacion AS varchar(50) = NULL,
   @Vfecha_modificacion AS datetime = NULL,
   @Vusuario_modificacion AS varchar(50) = NULL
AS
BEGIN
-- SET NOCOUNT ON added to prevent extra result sets from
  SET NOCOUNT ON;
  BEGIN TRAN
  BEGIN TRY

--======================OPCIONES DEL SP=========================
  -- 1.- GUARDAR
  -- 2.- OBTNER POR ID PRECLIENTE
--==============================================================


  IF(@VOPCION = 1)
  BEGIN
       INSERT INTO tblCLI_UsuariosAduabook (                 
	              
                 id_precliente,
                 nombre,
                 puesto_departamento,
                 telefono,
                 correo,
                 admon,
                 oper,
                 fecha_creacion,
                 usuario_creacion,
                 fecha_modificacion,
                 usuario_modificacion)

VALUES (        
                 @Vid_precliente,
                 @Vnombre,
                 @Vpuesto_departamento,
                 @Vtelefono,
                 @Vcorreo,
                 @Vadmon,
                 @Voper,
                 @Vfecha_creacion,
                 @Vusuario_creacion,
                 @Vfecha_modificacion,
                 @Vusuario_modificacion)
  SELECT CAST(SCOPE_IDENTITY()  AS int)

  END


  IF(@VOPCION = 2)
  BEGIN
     SELECT     id_precliente,
                 nombre,
                 puesto_departamento,
                 telefono,
                 correo,
                 admon,
                 oper,
                 fecha_creacion,
                 usuario_creacion,
                 fecha_modificacion,
                 usuario_modificacion
				 FROM tblCLI_UsuariosAduabook
				 WHERE id_precliente = @Vid_precliente
  END 


  if(@VOPCION = 3) -- elimina por idprecliente
  begin
     delete from tblCLI_UsuariosAduabook
	 where id_precliente = @Vid_precliente
  end 

COMMIT TRAN;
END TRY
BEGIN CATCH

ROLLBACK TRAN; 

DECLARE @ErrorNumber    INT,
        @ErrorMessage   NVARCHAR(4000),
        @ErrorSeverity  INT,
        @ErrorState     INT,
        @ErrorProcedure NVARCHAR(126),
        @msg            NVARCHAR(2000)

SELECT  @ErrorNumber = ERROR_NUMBER(),
        @ErrorMessage = ERROR_MESSAGE(),
        @ErrorSeverity = ERROR_SEVERITY(),
        @ErrorState = ERROR_STATE(),
        @ErrorProcedure = ERROR_PROCEDURE()

SELECT  @msg = 'Error No. '
        + CONVERT (NVARCHAR(10), @ErrorNumber)
        + ' Descripcion: ' + @ErrorMessage
        + ' Origen del Error: ' + @ErrorProcedure

RAISERROR ( @msg,@ErrorSeverity,@ErrorState )

END CATCH 

END


GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'realcion de la tabla cliente-aprobador con la tabla cliente' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tblCLI_ClienteAprobador', @level2type=N'CONSTRAINT',@level2name=N'FK_precliente'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Relacion de la tabla cliente-apobador con al tabla usuairo quien sera el usuario aprobador' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tblCLI_ClienteAprobador', @level2type=N'CONSTRAINT',@level2name=N'FK_usuario'
GO
USE [master]
GO
ALTER DATABASE [PortalClientes] SET  READ_WRITE 
GO
