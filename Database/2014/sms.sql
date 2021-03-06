USE [master]
GO
/****** Object:  Database [SMS]    Script Date: 30/08/2020 3:11:50 AM ******/
CREATE DATABASE [SMS]
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [SMS].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [SMS] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [SMS] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [SMS] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [SMS] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [SMS] SET ARITHABORT OFF 
GO
ALTER DATABASE [SMS] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [SMS] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [SMS] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [SMS] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [SMS] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [SMS] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [SMS] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [SMS] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [SMS] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [SMS] SET  DISABLE_BROKER 
GO
ALTER DATABASE [SMS] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [SMS] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [SMS] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [SMS] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [SMS] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [SMS] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [SMS] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [SMS] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [SMS] SET  MULTI_USER 
GO
ALTER DATABASE [SMS] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [SMS] SET DB_CHAINING OFF 
GO
ALTER DATABASE [SMS] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [SMS] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [SMS] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'SMS', N'ON'
GO
USE [SMS]
GO
/****** Object:  Table [dbo].[Admin]    Script Date: 30/08/2020 3:11:51 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Admin](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Username] [varchar](100) NOT NULL,
	[Password] [varchar](100) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Class]    Script Date: 30/08/2020 3:11:51 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Class](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](300) NOT NULL,
	[StartDate] [date] NOT NULL,
	[EndDate] [date] NULL,
 CONSTRAINT [PK_Class] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Student]    Script Date: 30/08/2020 3:11:51 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Student](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ImagePath] [nvarchar](max) NULL,
	[FirstName] [nvarchar](200) NOT NULL,
	[LastName] [nvarchar](200) NOT NULL,
	[Address] [nvarchar](500) NULL,
	[DoB] [date] NULL,
	[Phone] [varchar](12) NULL,
	[ClassId] [int] NULL,
 CONSTRAINT [PK_Student] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Admin] ON 

INSERT [dbo].[Admin] ([Id], [Username], [Password]) VALUES (1, N'user1', N'password1')
SET IDENTITY_INSERT [dbo].[Admin] OFF
SET IDENTITY_INSERT [dbo].[Class] ON 

INSERT [dbo].[Class] ([Id], [Name], [StartDate], [EndDate]) VALUES (1, N'Class1', CAST(N'2012-02-22' AS Date), CAST(N'2012-02-25' AS Date))
INSERT [dbo].[Class] ([Id], [Name], [StartDate], [EndDate]) VALUES (2, N'Class2', CAST(N'2015-03-12' AS Date), CAST(N'2015-03-30' AS Date))
INSERT [dbo].[Class] ([Id], [Name], [StartDate], [EndDate]) VALUES (3, N'Class3', CAST(N'2018-06-23' AS Date), CAST(N'2018-07-24' AS Date))
INSERT [dbo].[Class] ([Id], [Name], [StartDate], [EndDate]) VALUES (6, N'React', CAST(N'2020-08-25' AS Date), CAST(N'2020-08-25' AS Date))
INSERT [dbo].[Class] ([Id], [Name], [StartDate], [EndDate]) VALUES (11, N'Test', CAST(N'2020-08-25' AS Date), CAST(N'2020-08-25' AS Date))
INSERT [dbo].[Class] ([Id], [Name], [StartDate], [EndDate]) VALUES (13, N'test', CAST(N'2020-08-25' AS Date), CAST(N'2020-08-25' AS Date))
INSERT [dbo].[Class] ([Id], [Name], [StartDate], [EndDate]) VALUES (14, N'React Native', CAST(N'2020-08-25' AS Date), CAST(N'2020-05-09' AS Date))
INSERT [dbo].[Class] ([Id], [Name], [StartDate], [EndDate]) VALUES (15, N'string', CAST(N'2020-08-24' AS Date), CAST(N'2020-08-24' AS Date))
INSERT [dbo].[Class] ([Id], [Name], [StartDate], [EndDate]) VALUES (17, N'gagaga', CAST(N'2020-08-27' AS Date), CAST(N'2020-08-30' AS Date))
INSERT [dbo].[Class] ([Id], [Name], [StartDate], [EndDate]) VALUES (18, N'new', CAST(N'2020-08-27' AS Date), CAST(N'2020-08-28' AS Date))
SET IDENTITY_INSERT [dbo].[Class] OFF
SET IDENTITY_INSERT [dbo].[Student] ON 

INSERT [dbo].[Student] ([Id], [ImagePath], [FirstName], [LastName], [Address], [DoB], [Phone], [ClassId]) VALUES (3, NULL, N'Khanh Duy', N'Nguyen Tuan', N'Address1', CAST(N'1999-02-13' AS Date), N'12345455', 1)
INSERT [dbo].[Student] ([Id], [ImagePath], [FirstName], [LastName], [Address], [DoB], [Phone], [ClassId]) VALUES (4, NULL, N'Duc Duy', N'Hoang', N'Address2', CAST(N'1993-05-15' AS Date), N'2233111', 2)
INSERT [dbo].[Student] ([Id], [ImagePath], [FirstName], [LastName], [Address], [DoB], [Phone], [ClassId]) VALUES (5, NULL, N'Hoang Phung', N'Le', N'Address3', CAST(N'1993-05-15' AS Date), N'312521512', 1)
INSERT [dbo].[Student] ([Id], [ImagePath], [FirstName], [LastName], [Address], [DoB], [Phone], [ClassId]) VALUES (6, NULL, N'Kim Tram', N'Cay', N'Address4', CAST(N'1994-06-13' AS Date), N'151254345', 2)
INSERT [dbo].[Student] ([Id], [ImagePath], [FirstName], [LastName], [Address], [DoB], [Phone], [ClassId]) VALUES (7, N'test Update', N'Eden', N'Hoang', N'Thu Duc', CAST(N'2020-08-24' AS Date), N'0901547767', 1)
INSERT [dbo].[Student] ([Id], [ImagePath], [FirstName], [LastName], [Address], [DoB], [Phone], [ClassId]) VALUES (8, N'test', N'Eden', N'Hoang', N'Thu Duc', CAST(N'1998-12-28' AS Date), N'0901547767', 1)
SET IDENTITY_INSERT [dbo].[Student] OFF
ALTER TABLE [dbo].[Student]  WITH CHECK ADD  CONSTRAINT [FK_Student_Class] FOREIGN KEY([ClassId])
REFERENCES [dbo].[Class] ([Id])
GO
ALTER TABLE [dbo].[Student] CHECK CONSTRAINT [FK_Student_Class]
GO
USE [master]
GO
ALTER DATABASE [SMS] SET  READ_WRITE 
GO
