USE [master]
GO

/****** Object:  Database [dbsSurvey]    Script Date: 08/07/2023 10:08:31 AM ******/
CREATE DATABASE [dbsSurvey]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'dbsSurvey', FILENAME = N'D:\Databases\dbsSurvey.mdf' , SIZE = 4096KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'dbsSurvey_log', FILENAME = N'D:\Databases\dbsSurvey_log.ldf' , SIZE = 2560KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO

IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [dbsSurvey].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO

ALTER DATABASE [dbsSurvey] SET ANSI_NULL_DEFAULT OFF 
GO

ALTER DATABASE [dbsSurvey] SET ANSI_NULLS OFF 
GO

ALTER DATABASE [dbsSurvey] SET ANSI_PADDING OFF 
GO

ALTER DATABASE [dbsSurvey] SET ANSI_WARNINGS OFF 
GO

ALTER DATABASE [dbsSurvey] SET ARITHABORT OFF 
GO

ALTER DATABASE [dbsSurvey] SET AUTO_CLOSE ON 
GO

ALTER DATABASE [dbsSurvey] SET AUTO_SHRINK OFF 
GO

ALTER DATABASE [dbsSurvey] SET AUTO_UPDATE_STATISTICS ON 
GO

ALTER DATABASE [dbsSurvey] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO

ALTER DATABASE [dbsSurvey] SET CURSOR_DEFAULT  GLOBAL 
GO

ALTER DATABASE [dbsSurvey] SET CONCAT_NULL_YIELDS_NULL OFF 
GO

ALTER DATABASE [dbsSurvey] SET NUMERIC_ROUNDABORT OFF 
GO

ALTER DATABASE [dbsSurvey] SET QUOTED_IDENTIFIER OFF 
GO

ALTER DATABASE [dbsSurvey] SET RECURSIVE_TRIGGERS OFF 
GO

ALTER DATABASE [dbsSurvey] SET  DISABLE_BROKER 
GO

ALTER DATABASE [dbsSurvey] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO

ALTER DATABASE [dbsSurvey] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO

ALTER DATABASE [dbsSurvey] SET TRUSTWORTHY OFF 
GO

ALTER DATABASE [dbsSurvey] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO

ALTER DATABASE [dbsSurvey] SET PARAMETERIZATION SIMPLE 
GO

ALTER DATABASE [dbsSurvey] SET READ_COMMITTED_SNAPSHOT OFF 
GO

ALTER DATABASE [dbsSurvey] SET HONOR_BROKER_PRIORITY OFF 
GO

ALTER DATABASE [dbsSurvey] SET RECOVERY FULL 
GO

ALTER DATABASE [dbsSurvey] SET  MULTI_USER 
GO

ALTER DATABASE [dbsSurvey] SET PAGE_VERIFY CHECKSUM  
GO

ALTER DATABASE [dbsSurvey] SET DB_CHAINING OFF 
GO

ALTER DATABASE [dbsSurvey] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO

ALTER DATABASE [dbsSurvey] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO

ALTER DATABASE [dbsSurvey] SET DELAYED_DURABILITY = DISABLED 
GO

ALTER DATABASE [dbsSurvey] SET QUERY_STORE = OFF
GO

ALTER DATABASE [dbsSurvey] SET  READ_WRITE 
GO

USE [dbsSurvey]
GO

/****** Object:  Table [dbo].[tblCamat]    Script Date: 08/07/2023 10:09:44 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[tblCamat](
	[kodecamat] [int] IDENTITY(1,1) NOT NULL,
	[kecamatan] [char](75) NULL
) ON [PRIMARY]
GO


USE [dbsSurvey]
GO

/****** Object:  Table [dbo].[tblLogin]    Script Date: 08/07/2023 10:10:43 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[tblLogin](
	[username] [varchar](10) NULL,
	[password] [varchar](10) NULL,
	[Nama] [varchar](75) NULL,
	[HakAkses] [int] NULL
) ON [PRIMARY]
GO


USE [dbsSurvey]
GO

/****** Object:  Table [dbo].[tblLurah]    Script Date: 08/07/2023 10:10:55 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[tblLurah](
	[kodelurah] [int] IDENTITY(1,1) NOT NULL,
	[kodecamat] [int] NULL,
	[kelurahan] [char](75) NULL
) ON [PRIMARY]
GO



USE [dbsSurvey]
GO

/****** Object:  Table [dbo].[tblSurvey]    Script Date: 08/07/2023 10:11:49 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[tblSurvey](
	[id_survey] [bigint] IDENTITY(1,1) NOT NULL,
	[Survey_Nama] [varchar](75) NULL,
	[Survey_Alamat] [varchar](100) NULL,
	[Kodecamat] [int] NULL,
	[Kodelurah] [int] NULL,
	[Survey_RT] [int] NULL,
	[Survey_RW] [int] NULL,
	[Survey_NoHP] [varchar](100) NULL,
	[Survey_Ktp] [varchar](100) NULL,
	[Survey_Penghuni] [bigint] NULL,
	[Survey_Daya] [bigint] NULL,
	[Survey_Usaha] [int] NULL,
	[Survey_Jaringan] [int] NULL,
	[Survey_Jarak] [bigint] NULL,
	[Survey_Lokasi] [varchar](100) NULL,
	[Survey_Bangunan] [int] NULL,
	[Survey_Nometer] [varchar](50) NULL,
	[Survey_Keterangan] [varchar](250) NULL,
	[Survey_Tanggal] [datetime] NULL,
	[Survey_Init] [varchar](50) NULL,
	[Survey_TanggalEdit] [datetime] NULL,
 CONSTRAINT [PK_tblSurvey] PRIMARY KEY CLUSTERED 
(
	[id_survey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

USE [master]
GO

/* For security reasons the login is created disabled and with a random password. */
/****** Object:  Login [usersurvey]    Script Date: 08/07/2023 10:12:36 AM ******/
CREATE LOGIN [usersurvey] WITH PASSWORD=N'URgxMkl5FFb6fd9jOGpAl2N7ujFkX20YeDJbhidlJZo=', DEFAULT_DATABASE=[dbsSurvey], DEFAULT_LANGUAGE=[us_english], CHECK_EXPIRATION=OFF, CHECK_POLICY=OFF
GO

ALTER LOGIN [usersurvey] DISABLE
GO





USE [dbsSurvey]
GO

/****** Object:  User [usersurvey]    Script Date: 08/07/2023 10:12:10 AM ******/
CREATE USER [usersurvey] FOR LOGIN [usersurvey] WITH DEFAULT_SCHEMA=[dbo]
GO



