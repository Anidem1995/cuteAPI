USE [master]
GO
/****** Object:  Database [cute_home]    Script Date: 4/23/2021 7:35:00 AM ******/
CREATE DATABASE [cute_home]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'cute_home', FILENAME = N'D:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\cute_home.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'cute_home_log', FILENAME = N'D:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\cute_home_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [cute_home] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [cute_home].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [cute_home] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [cute_home] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [cute_home] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [cute_home] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [cute_home] SET ARITHABORT OFF 
GO
ALTER DATABASE [cute_home] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [cute_home] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [cute_home] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [cute_home] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [cute_home] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [cute_home] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [cute_home] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [cute_home] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [cute_home] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [cute_home] SET  ENABLE_BROKER 
GO
ALTER DATABASE [cute_home] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [cute_home] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [cute_home] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [cute_home] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [cute_home] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [cute_home] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [cute_home] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [cute_home] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [cute_home] SET  MULTI_USER 
GO
ALTER DATABASE [cute_home] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [cute_home] SET DB_CHAINING OFF 
GO
ALTER DATABASE [cute_home] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [cute_home] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [cute_home] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [cute_home] SET QUERY_STORE = OFF
GO
USE [cute_home]
GO
/****** Object:  Table [dbo].[appointment]    Script Date: 4/23/2021 7:35:00 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[appointment](
	[idUser] [int] NOT NULL,
	[idEmployee] [int] NOT NULL,
	[appointmentDate] [date] NOT NULL,
	[userObservations] [varchar](255) NULL,
	[employeeObservations] [varchar](255) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[collection]    Script Date: 4/23/2021 7:35:00 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[collection](
	[idCollection] [int] IDENTITY(1,1) NOT NULL,
	[idUser] [int] NOT NULL,
	[debt] [decimal](19, 4) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[idCollection] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[collectionDetail]    Script Date: 4/23/2021 7:35:00 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[collectionDetail](
	[idMovement] [int] IDENTITY(1,1) NOT NULL,
	[idCollection] [int] NOT NULL,
	[idContract] [int] NULL,
	[movementType] [varchar](2) NOT NULL,
	[ammount] [decimal](19, 4) NOT NULL,
	[createdAt] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[idMovement] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[commisionPayment]    Script Date: 4/23/2021 7:35:00 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[commisionPayment](
	[idEmployee] [int] NOT NULL,
	[idContract] [int] NOT NULL,
	[ammount] [decimal](19, 4) NOT NULL,
	[date] [datetime] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[employee]    Script Date: 4/23/2021 7:35:00 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[employee](
	[idEmployee] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](255) NOT NULL,
	[lastName] [varchar](255) NOT NULL,
	[username] [varchar](255) NOT NULL,
	[email] [varchar](320) NOT NULL,
	[hashedPassword] [varchar](64) NOT NULL,
	[commisionPercentage] [int] NULL,
	[hiringDate] [date] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[idEmployee] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[employeeRole]    Script Date: 4/23/2021 7:35:00 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[employeeRole](
	[idEmployee] [int] NOT NULL,
	[idRole] [int] NOT NULL,
	[active] [tinyint] NOT NULL,
	[createdAt] [datetime] NOT NULL,
	[updatedAt] [datetime] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[leasingContract]    Script Date: 4/23/2021 7:35:00 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[leasingContract](
	[idContract] [int] IDENTITY(1,1) NOT NULL,
	[idUser] [int] NOT NULL,
	[idEmployee] [int] NOT NULL,
	[idProperty] [int] NOT NULL,
	[monthlyRent] [decimal](19, 4) NOT NULL,
	[startDate] [date] NOT NULL,
	[endDate] [date] NOT NULL,
	[createdAt] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[idContract] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[property]    Script Date: 4/23/2021 7:35:00 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[property](
	[idProperty] [int] IDENTITY(1,1) NOT NULL,
	[address] [varchar](255) NOT NULL,
	[latitude] [varchar](255) NOT NULL,
	[longitude] [varchar](255) NOT NULL,
	[numberOfBaths] [float] NOT NULL,
	[numberOfRooms] [int] NOT NULL,
	[garage] [tinyint] NOT NULL,
	[surfaceInSquareMeters] [float] NOT NULL,
	[description] [varchar](255) NOT NULL,
	[monthlyRent] [decimal](19, 4) NULL,
PRIMARY KEY CLUSTERED 
(
	[idProperty] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[role]    Script Date: 4/23/2021 7:35:00 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[role](
	[idRole] [int] IDENTITY(1,1) NOT NULL,
	[description] [varchar](255) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[idRole] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[users]    Script Date: 4/23/2021 7:35:00 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[users](
	[idUser] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](255) NOT NULL,
	[lastName] [varchar](255) NOT NULL,
	[username] [varchar](255) NOT NULL,
	[email] [varchar](320) NOT NULL,
	[hashedPassword] [varchar](64) NOT NULL,
	[idEmployee] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[idUser] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[wallet]    Script Date: 4/23/2021 7:35:00 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[wallet](
	[idWallet] [int] IDENTITY(1,1) NOT NULL,
	[idEmployee] [int] NULL,
	[size] [int] NOT NULL,
	[availableProps] [int] NOT NULL,
	[createdAt] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[idWallet] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[walletDetail]    Script Date: 4/23/2021 7:35:00 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[walletDetail](
	[idDetail] [int] IDENTITY(1,1) NOT NULL,
	[idWallet] [int] NULL,
	[idProperty] [int] NULL,
	[available] [tinyint] NOT NULL,
	[createdAt] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[idDetail] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[collectionDetail] ADD  DEFAULT (getdate()) FOR [createdAt]
GO
ALTER TABLE [dbo].[commisionPayment] ADD  DEFAULT (getdate()) FOR [date]
GO
ALTER TABLE [dbo].[employeeRole] ADD  DEFAULT (getdate()) FOR [createdAt]
GO
ALTER TABLE [dbo].[employeeRole] ADD  DEFAULT (getdate()) FOR [updatedAt]
GO
ALTER TABLE [dbo].[leasingContract] ADD  DEFAULT (getdate()) FOR [createdAt]
GO
ALTER TABLE [dbo].[wallet] ADD  DEFAULT (getdate()) FOR [createdAt]
GO
ALTER TABLE [dbo].[walletDetail] ADD  DEFAULT (getdate()) FOR [createdAt]
GO
ALTER TABLE [dbo].[appointment]  WITH CHECK ADD FOREIGN KEY([idEmployee])
REFERENCES [dbo].[employee] ([idEmployee])
GO
ALTER TABLE [dbo].[appointment]  WITH CHECK ADD FOREIGN KEY([idUser])
REFERENCES [dbo].[users] ([idUser])
GO
ALTER TABLE [dbo].[collection]  WITH CHECK ADD FOREIGN KEY([idUser])
REFERENCES [dbo].[users] ([idUser])
GO
ALTER TABLE [dbo].[collectionDetail]  WITH CHECK ADD FOREIGN KEY([idCollection])
REFERENCES [dbo].[collection] ([idCollection])
GO
ALTER TABLE [dbo].[collectionDetail]  WITH CHECK ADD FOREIGN KEY([idContract])
REFERENCES [dbo].[leasingContract] ([idContract])
GO
ALTER TABLE [dbo].[commisionPayment]  WITH CHECK ADD FOREIGN KEY([idContract])
REFERENCES [dbo].[leasingContract] ([idContract])
GO
ALTER TABLE [dbo].[commisionPayment]  WITH CHECK ADD FOREIGN KEY([idEmployee])
REFERENCES [dbo].[users] ([idUser])
GO
ALTER TABLE [dbo].[employeeRole]  WITH CHECK ADD FOREIGN KEY([idEmployee])
REFERENCES [dbo].[employee] ([idEmployee])
GO
ALTER TABLE [dbo].[employeeRole]  WITH CHECK ADD FOREIGN KEY([idRole])
REFERENCES [dbo].[role] ([idRole])
GO
ALTER TABLE [dbo].[leasingContract]  WITH CHECK ADD FOREIGN KEY([idEmployee])
REFERENCES [dbo].[users] ([idUser])
GO
ALTER TABLE [dbo].[leasingContract]  WITH CHECK ADD FOREIGN KEY([idProperty])
REFERENCES [dbo].[property] ([idProperty])
GO
ALTER TABLE [dbo].[leasingContract]  WITH CHECK ADD FOREIGN KEY([idUser])
REFERENCES [dbo].[users] ([idUser])
GO
ALTER TABLE [dbo].[users]  WITH CHECK ADD FOREIGN KEY([idEmployee])
REFERENCES [dbo].[employee] ([idEmployee])
GO
ALTER TABLE [dbo].[wallet]  WITH CHECK ADD FOREIGN KEY([idEmployee])
REFERENCES [dbo].[employee] ([idEmployee])
GO
ALTER TABLE [dbo].[walletDetail]  WITH CHECK ADD FOREIGN KEY([idProperty])
REFERENCES [dbo].[property] ([idProperty])
GO
ALTER TABLE [dbo].[walletDetail]  WITH CHECK ADD FOREIGN KEY([idWallet])
REFERENCES [dbo].[wallet] ([idWallet])
GO
USE [master]
GO
ALTER DATABASE [cute_home] SET  READ_WRITE 
GO
