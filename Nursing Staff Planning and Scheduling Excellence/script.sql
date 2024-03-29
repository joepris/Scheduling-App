USE [NursingStaff]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[User]') AND type in (N'U'))
ALTER TABLE [dbo].[User] DROP CONSTRAINT IF EXISTS [FK_User_Role]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[User]') AND type in (N'U'))
ALTER TABLE [dbo].[User] DROP CONSTRAINT IF EXISTS [FK_User_MaritalStatus]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[User]') AND type in (N'U'))
ALTER TABLE [dbo].[User] DROP CONSTRAINT IF EXISTS [FK_User_Gender]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[MaritalStatus]') AND type in (N'U'))
ALTER TABLE [dbo].[MaritalStatus] DROP CONSTRAINT IF EXISTS [FK_MaritalStatus_MaritalStatus]
GO
/****** Object:  Table [dbo].[User]    Script Date: 03/04/2023 19:32:20 ******/
DROP TABLE IF EXISTS [dbo].[User]
GO
/****** Object:  Table [dbo].[ShiftSchedule]    Script Date: 03/04/2023 19:32:20 ******/
DROP TABLE IF EXISTS [dbo].[ShiftSchedule]
GO
/****** Object:  Table [dbo].[Role]    Script Date: 03/04/2023 19:32:20 ******/
DROP TABLE IF EXISTS [dbo].[Role]
GO
/****** Object:  Table [dbo].[MaritalStatus]    Script Date: 03/04/2023 19:32:20 ******/
DROP TABLE IF EXISTS [dbo].[MaritalStatus]
GO
/****** Object:  Table [dbo].[Gender]    Script Date: 03/04/2023 19:32:20 ******/
DROP TABLE IF EXISTS [dbo].[Gender]
GO
USE [master]
GO
/****** Object:  Database [NursingStaff]    Script Date: 03/04/2023 19:32:20 ******/
DROP DATABASE IF EXISTS [NursingStaff]
GO
/****** Object:  Database [NursingStaff]    Script Date: 03/04/2023 19:32:20 ******/
CREATE DATABASE [NursingStaff]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'NursingStaff', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\NursingStaff.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'NursingStaff_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\NursingStaff_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [NursingStaff] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [NursingStaff].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [NursingStaff] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [NursingStaff] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [NursingStaff] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [NursingStaff] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [NursingStaff] SET ARITHABORT OFF 
GO
ALTER DATABASE [NursingStaff] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [NursingStaff] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [NursingStaff] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [NursingStaff] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [NursingStaff] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [NursingStaff] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [NursingStaff] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [NursingStaff] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [NursingStaff] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [NursingStaff] SET  DISABLE_BROKER 
GO
ALTER DATABASE [NursingStaff] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [NursingStaff] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [NursingStaff] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [NursingStaff] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [NursingStaff] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [NursingStaff] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [NursingStaff] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [NursingStaff] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [NursingStaff] SET  MULTI_USER 
GO
ALTER DATABASE [NursingStaff] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [NursingStaff] SET DB_CHAINING OFF 
GO
ALTER DATABASE [NursingStaff] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [NursingStaff] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [NursingStaff] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [NursingStaff] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [NursingStaff] SET QUERY_STORE = OFF
GO
USE [NursingStaff]
GO
/****** Object:  Table [dbo].[Gender]    Script Date: 03/04/2023 19:32:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Gender](
	[GenderId] [int] IDENTITY(1,1) NOT NULL,
	[GenderName] [nvarchar](50) NULL,
 CONSTRAINT [PK_Gender] PRIMARY KEY CLUSTERED 
(
	[GenderId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MaritalStatus]    Script Date: 03/04/2023 19:32:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MaritalStatus](
	[MaritalStatusId] [int] IDENTITY(1,1) NOT NULL,
	[MaritalStatusName] [nvarchar](50) NULL,
 CONSTRAINT [PK_MaritalStatus] PRIMARY KEY CLUSTERED 
(
	[MaritalStatusId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Role]    Script Date: 03/04/2023 19:32:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Role](
	[RoleId] [int] IDENTITY(1,1) NOT NULL,
	[RoleName] [nvarchar](50) NULL,
 CONSTRAINT [PK_Role] PRIMARY KEY CLUSTERED 
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ShiftSchedule]    Script Date: 03/04/2023 19:32:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ShiftSchedule](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NULL,
	[StartDate] [datetime] NULL,
	[EndDate] [datetime] NULL,
	[StartTime] [time](7) NULL,
	[EndTime] [time](7) NULL,
	[ShiftId] [int] NULL,
 CONSTRAINT [PK_ShiftSchedule] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 03/04/2023 19:32:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[UserId] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](50) NULL,
	[LastName] [nvarchar](50) NULL,
	[UserName] [nvarchar](50) NULL,
	[Password] [nvarchar](50) NULL,
	[MaritalStatusId] [int] NOT NULL,
	[DOB] [datetime] NULL,
	[Sex] [int] NULL,
	[Address] [nvarchar](50) NULL,
	[City] [nvarchar](50) NULL,
	[Province] [nvarchar](50) NULL,
	[ZipCode] [nvarchar](50) NULL,
	[Email] [nvarchar](50) NULL,
	[HomePhone] [nvarchar](50) NULL,
	[CellPhone] [nvarchar](50) NULL,
	[UserRole] [int] NULL,
	[AccessLevel] [int] NULL,
	[Specialization] [nvarchar](50) NULL,
	[FullName] [nvarchar](50) NULL,
	[Image] [nvarchar](50) NULL,
	[Note] [nvarchar](50) NULL,
	[Fax] [nvarchar](50) NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Gender] ON 

INSERT [dbo].[Gender] ([GenderId], [GenderName]) VALUES (1, N'Male')
INSERT [dbo].[Gender] ([GenderId], [GenderName]) VALUES (2, N'Female')
SET IDENTITY_INSERT [dbo].[Gender] OFF
GO
SET IDENTITY_INSERT [dbo].[MaritalStatus] ON 

INSERT [dbo].[MaritalStatus] ([MaritalStatusId], [MaritalStatusName]) VALUES (1, N'Married')
INSERT [dbo].[MaritalStatus] ([MaritalStatusId], [MaritalStatusName]) VALUES (2, N'Unmaried')
SET IDENTITY_INSERT [dbo].[MaritalStatus] OFF
GO
SET IDENTITY_INSERT [dbo].[Role] ON 

INSERT [dbo].[Role] ([RoleId], [RoleName]) VALUES (1, N'Admin')
INSERT [dbo].[Role] ([RoleId], [RoleName]) VALUES (2, N'Staff')
SET IDENTITY_INSERT [dbo].[Role] OFF
GO
SET IDENTITY_INSERT [dbo].[ShiftSchedule] ON 

INSERT [dbo].[ShiftSchedule] ([Id], [UserId], [StartDate], [EndDate], [StartTime], [EndTime], [ShiftId]) VALUES (14, 9, CAST(N'2023-03-04T18:48:00.000' AS DateTime), CAST(N'2023-03-10T22:48:00.000' AS DateTime), CAST(N'18:48:00' AS Time), CAST(N'22:48:00' AS Time), 1)
INSERT [dbo].[ShiftSchedule] ([Id], [UserId], [StartDate], [EndDate], [StartTime], [EndTime], [ShiftId]) VALUES (15, 9, CAST(N'2023-03-11T22:48:00.000' AS DateTime), CAST(N'2023-03-22T18:49:00.000' AS DateTime), CAST(N'22:48:00' AS Time), CAST(N'18:49:00' AS Time), 3)
INSERT [dbo].[ShiftSchedule] ([Id], [UserId], [StartDate], [EndDate], [StartTime], [EndTime], [ShiftId]) VALUES (16, 9, CAST(N'2023-03-04T18:59:00.000' AS DateTime), CAST(N'2023-03-04T18:59:00.000' AS DateTime), CAST(N'18:59:00' AS Time), CAST(N'18:59:00' AS Time), 2)
INSERT [dbo].[ShiftSchedule] ([Id], [UserId], [StartDate], [EndDate], [StartTime], [EndTime], [ShiftId]) VALUES (17, 10, CAST(N'2023-03-04T18:59:00.000' AS DateTime), CAST(N'2023-03-29T18:59:00.000' AS DateTime), CAST(N'18:59:00' AS Time), CAST(N'18:59:00' AS Time), 1)
INSERT [dbo].[ShiftSchedule] ([Id], [UserId], [StartDate], [EndDate], [StartTime], [EndTime], [ShiftId]) VALUES (18, 10, CAST(N'2023-03-04T19:00:00.000' AS DateTime), CAST(N'2023-03-30T21:00:00.000' AS DateTime), CAST(N'19:00:00' AS Time), CAST(N'21:00:00' AS Time), 3)
INSERT [dbo].[ShiftSchedule] ([Id], [UserId], [StartDate], [EndDate], [StartTime], [EndTime], [ShiftId]) VALUES (21, 9, CAST(N'2023-03-04T19:26:00.000' AS DateTime), CAST(N'2023-03-04T19:26:00.000' AS DateTime), CAST(N'19:26:00' AS Time), CAST(N'19:26:00' AS Time), 2)
INSERT [dbo].[ShiftSchedule] ([Id], [UserId], [StartDate], [EndDate], [StartTime], [EndTime], [ShiftId]) VALUES (22, 9, CAST(N'2023-03-04T19:27:00.000' AS DateTime), CAST(N'2023-03-04T19:27:00.000' AS DateTime), CAST(N'19:27:00' AS Time), CAST(N'19:27:00' AS Time), 3)
SET IDENTITY_INSERT [dbo].[ShiftSchedule] OFF
GO
SET IDENTITY_INSERT [dbo].[User] ON 

INSERT [dbo].[User] ([UserId], [FirstName], [LastName], [UserName], [Password], [MaritalStatusId], [DOB], [Sex], [Address], [City], [Province], [ZipCode], [Email], [HomePhone], [CellPhone], [UserRole], [AccessLevel], [Specialization], [FullName], [Image], [Note], [Fax]) VALUES (8, N'admin', N'admin', N'Admin', N'123', 1, NULL, 1, N'test', N'test', N'test', N'12331', N'admin@gmail.com', N'9898989898', NULL, 1, 1, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[User] ([UserId], [FirstName], [LastName], [UserName], [Password], [MaritalStatusId], [DOB], [Sex], [Address], [City], [Province], [ZipCode], [Email], [HomePhone], [CellPhone], [UserRole], [AccessLevel], [Specialization], [FullName], [Image], [Note], [Fax]) VALUES (11, N'test t', N'test', N'test', N'test', 1, CAST(N'2023-03-04T00:00:00.000' AS DateTime), 1, N'test', N'test', N'test', N'1223', N'test', NULL, N'345345435', 2, NULL, NULL, NULL, NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[User] OFF
GO
ALTER TABLE [dbo].[MaritalStatus]  WITH CHECK ADD  CONSTRAINT [FK_MaritalStatus_MaritalStatus] FOREIGN KEY([MaritalStatusId])
REFERENCES [dbo].[MaritalStatus] ([MaritalStatusId])
GO
ALTER TABLE [dbo].[MaritalStatus] CHECK CONSTRAINT [FK_MaritalStatus_MaritalStatus]
GO
ALTER TABLE [dbo].[User]  WITH CHECK ADD  CONSTRAINT [FK_User_Gender] FOREIGN KEY([Sex])
REFERENCES [dbo].[Gender] ([GenderId])
GO
ALTER TABLE [dbo].[User] CHECK CONSTRAINT [FK_User_Gender]
GO
ALTER TABLE [dbo].[User]  WITH CHECK ADD  CONSTRAINT [FK_User_MaritalStatus] FOREIGN KEY([MaritalStatusId])
REFERENCES [dbo].[MaritalStatus] ([MaritalStatusId])
GO
ALTER TABLE [dbo].[User] CHECK CONSTRAINT [FK_User_MaritalStatus]
GO
ALTER TABLE [dbo].[User]  WITH CHECK ADD  CONSTRAINT [FK_User_Role] FOREIGN KEY([UserRole])
REFERENCES [dbo].[Role] ([RoleId])
GO
ALTER TABLE [dbo].[User] CHECK CONSTRAINT [FK_User_Role]
GO
USE [master]
GO
ALTER DATABASE [NursingStaff] SET  READ_WRITE 
GO
