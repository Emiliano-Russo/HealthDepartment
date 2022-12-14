USE [master]
GO
/****** Object:  Database [ObligatorioDDA2]    Script Date: 15/6/2021 18:58:51 ******/
CREATE DATABASE [ObligatorioDDA2]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'ObligatorioDDA2', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\ObligatorioDDA2.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'ObligatorioDDA2_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\ObligatorioDDA2_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [ObligatorioDDA2] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [ObligatorioDDA2].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [ObligatorioDDA2] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [ObligatorioDDA2] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [ObligatorioDDA2] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [ObligatorioDDA2] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [ObligatorioDDA2] SET ARITHABORT OFF 
GO
ALTER DATABASE [ObligatorioDDA2] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [ObligatorioDDA2] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [ObligatorioDDA2] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [ObligatorioDDA2] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [ObligatorioDDA2] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [ObligatorioDDA2] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [ObligatorioDDA2] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [ObligatorioDDA2] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [ObligatorioDDA2] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [ObligatorioDDA2] SET  DISABLE_BROKER 
GO
ALTER DATABASE [ObligatorioDDA2] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [ObligatorioDDA2] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [ObligatorioDDA2] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [ObligatorioDDA2] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [ObligatorioDDA2] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [ObligatorioDDA2] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [ObligatorioDDA2] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [ObligatorioDDA2] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [ObligatorioDDA2] SET  MULTI_USER 
GO
ALTER DATABASE [ObligatorioDDA2] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [ObligatorioDDA2] SET DB_CHAINING OFF 
GO
ALTER DATABASE [ObligatorioDDA2] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [ObligatorioDDA2] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [ObligatorioDDA2] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [ObligatorioDDA2] SET QUERY_STORE = OFF
GO
USE [ObligatorioDDA2]
GO
/****** Object:  User [NT AUTHORITY\SYSTEM]    Script Date: 15/6/2021 18:58:51 ******/
CREATE USER [NT AUTHORITY\SYSTEM] FOR LOGIN [NT AUTHORITY\SYSTEM] WITH DEFAULT_SCHEMA=[dbo]
GO
/****** Object:  User [IIS APPPOOL\Obl Back-End]    Script Date: 15/6/2021 18:58:51 ******/
CREATE USER [IIS APPPOOL\Obl Back-End] FOR LOGIN [IIS APPPOOL\Obl Back-End] WITH DEFAULT_SCHEMA=[dbo]
GO
ALTER ROLE [db_owner] ADD MEMBER [NT AUTHORITY\SYSTEM]
GO
ALTER ROLE [db_owner] ADD MEMBER [IIS APPPOOL\Obl Back-End]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 15/6/2021 18:58:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Admin]    Script Date: 15/6/2021 18:58:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Admin](
	[Email] [nvarchar](450) NOT NULL,
	[Contrasenia] [nvarchar](max) NULL,
	[EsSuperAdmin] [bit] NOT NULL,
 CONSTRAINT [PK_Admin] PRIMARY KEY CLUSTERED 
(
	[Email] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Cancion]    Script Date: 15/6/2021 18:58:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cancion](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Titulo] [nvarchar](max) NULL,
	[Descripcion] [nvarchar](max) NULL,
	[Duracion] [real] NOT NULL,
	[Autor] [nvarchar](max) NULL,
	[LinkAudio] [nvarchar](max) NULL,
	[LinkImagen] [nvarchar](max) NULL,
 CONSTRAINT [PK_Cancion] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Cita]    Script Date: 15/6/2021 18:58:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cita](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[IdPsicologo] [int] NOT NULL,
	[NombrePsicologo] [nvarchar](max) NULL,
	[FormatoConsulta] [int] NOT NULL,
	[DireccionConsulta] [nvarchar](max) NULL,
	[FechaConsulta] [datetime2](7) NOT NULL,
	[PrecioFinal] [real] NOT NULL,
	[Descuento] [real] NOT NULL,
	[DuracionSesionHoras] [real] NOT NULL,
 CONSTRAINT [PK_Cita] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Credito]    Script Date: 15/6/2021 18:58:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Credito](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Email] [nvarchar](max) NULL,
	[Creditos] [int] NOT NULL,
 CONSTRAINT [PK_Credito] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Descuento]    Script Date: 15/6/2021 18:58:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Descuento](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Porcentaje] [int] NOT NULL,
	[Email] [nvarchar](max) NULL,
 CONSTRAINT [PK_Descuento] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[GaleriaMusical]    Script Date: 15/6/2021 18:58:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GaleriaMusical](
	[CategoriaMusical] [int] NOT NULL,
 CONSTRAINT [PK_GaleriaMusical] PRIMARY KEY CLUSTERED 
(
	[CategoriaMusical] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[IX_Cancion_Galeria]    Script Date: 15/6/2021 18:58:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[IX_Cancion_Galeria](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[IDCancion] [int] NOT NULL,
	[IDGaleria] [int] NOT NULL,
 CONSTRAINT [PK_IX_Cancion_Galeria] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[IX_Cancion_PlayList]    Script Date: 15/6/2021 18:58:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[IX_Cancion_PlayList](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[IDCancion] [int] NOT NULL,
	[IDPlayList] [int] NOT NULL,
 CONSTRAINT [PK_IX_Cancion_PlayList] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[IX_Galeria_PlayList]    Script Date: 15/6/2021 18:58:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[IX_Galeria_PlayList](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[IDPlaylist] [int] NOT NULL,
	[IDGaleria] [int] NOT NULL,
 CONSTRAINT [PK_IX_Galeria_PlayList] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[IX_Psicologo_Dolencia]    Script Date: 15/6/2021 18:58:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[IX_Psicologo_Dolencia](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[IDPsicologo] [int] NOT NULL,
	[IDDolencia] [int] NOT NULL,
 CONSTRAINT [PK_IX_Psicologo_Dolencia] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[IX_Video_Galeria]    Script Date: 15/6/2021 18:58:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[IX_Video_Galeria](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[IDVideo] [int] NOT NULL,
	[IDGaleria] [int] NOT NULL,
 CONSTRAINT [PK_IX_Video_Galeria] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[IX_Video_PlayList]    Script Date: 15/6/2021 18:58:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[IX_Video_PlayList](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[IDVideo] [int] NOT NULL,
	[IDPlayList] [int] NOT NULL,
 CONSTRAINT [PK_IX_Video_PlayList] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Playlist]    Script Date: 15/6/2021 18:58:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Playlist](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](max) NULL,
	[Descripcion] [nvarchar](max) NULL,
	[LinkImagen] [nvarchar](max) NULL,
 CONSTRAINT [PK_Playlist] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Psicologo]    Script Date: 15/6/2021 18:58:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Psicologo](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](max) NULL,
	[FormatoConsulta] [int] NOT NULL,
	[DireccionUrbana] [nvarchar](max) NULL,
	[PrecioHora] [real] NOT NULL,
 CONSTRAINT [PK_Psicologo] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Sesion]    Script Date: 15/6/2021 18:58:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sesion](
	[Token] [nvarchar](450) NOT NULL,
	[Email] [nvarchar](max) NULL,
	[EsSuperAdmin] [bit] NOT NULL,
 CONSTRAINT [PK_Sesion] PRIMARY KEY CLUSTERED 
(
	[Token] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Video]    Script Date: 15/6/2021 18:58:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Video](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](max) NULL,
	[DuracionMins] [int] NOT NULL,
	[LinkVideo] [nvarchar](max) NULL,
	[Autor] [nvarchar](max) NULL,
 CONSTRAINT [PK_Video] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
USE [master]
GO
ALTER DATABASE [ObligatorioDDA2] SET  READ_WRITE 
GO
