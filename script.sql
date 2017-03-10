USE [master]
GO
/****** Object:  Database [HRM]    Script Date: 09/03/2017 7:44:34 CH ******/
CREATE DATABASE [HRM]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'HRM', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\HRM.mdf' , SIZE = 5120KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'HRM_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\HRM_log.ldf' , SIZE = 2048KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [HRM] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [HRM].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [HRM] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [HRM] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [HRM] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [HRM] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [HRM] SET ARITHABORT OFF 
GO
ALTER DATABASE [HRM] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [HRM] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [HRM] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [HRM] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [HRM] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [HRM] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [HRM] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [HRM] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [HRM] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [HRM] SET  DISABLE_BROKER 
GO
ALTER DATABASE [HRM] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [HRM] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [HRM] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [HRM] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [HRM] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [HRM] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [HRM] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [HRM] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [HRM] SET  MULTI_USER 
GO
ALTER DATABASE [HRM] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [HRM] SET DB_CHAINING OFF 
GO
ALTER DATABASE [HRM] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [HRM] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [HRM] SET DELAYED_DURABILITY = DISABLED 
GO
USE [HRM]
GO
/****** Object:  Table [dbo].[Absent]    Script Date: 09/03/2017 7:44:34 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Absent](
	[AbsentID] [int] IDENTITY(1,1) NOT NULL,
	[AmountDay] [int] NULL,
	[FromDate] [datetime] NULL,
	[ToDate] [datetime] NULL,
	[AbsentType] [bit] NULL,
	[Note] [nvarchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[AbsentID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Access]    Script Date: 09/03/2017 7:44:35 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Access](
	[AccessID] [int] IDENTITY(1,1) NOT NULL,
	[Form] [nvarchar](20) NULL,
	[Edit] [bit] NULL,
	[GroupAccessID] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[AccessID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Account]    Script Date: 09/03/2017 7:44:35 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Account](
	[AccID] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [char](20) NULL,
	[Password] [char](30) NULL,
	[GroupAccessID] [int] NOT NULL,
	[StaffID] [char](6) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[AccID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Contract]    Script Date: 09/03/2017 7:44:35 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Contract](
	[ContractID] [char](6) NOT NULL,
	[Date] [datetime] NULL,
	[Currency] [nvarchar](10) NULL,
	[StartDate] [datetime] NULL,
	[EndDate] [datetime] NULL,
	[Status] [bit] NULL,
	[BasicPay] [decimal](20, 2) NULL,
	[Payment] [nvarchar](20) NULL,
	[Note] [nvarchar](100) NULL,
	[StaffID] [char](6) NOT NULL,
	[ContractTypeID] [char](6) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ContractID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ContractType]    Script Date: 09/03/2017 7:44:35 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ContractType](
	[ContractTypeID] [char](6) NOT NULL,
	[ContractTypeName] [nvarchar](20) NULL,
PRIMARY KEY CLUSTERED 
(
	[ContractTypeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[DetailAbsent]    Script Date: 09/03/2017 7:44:35 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[DetailAbsent](
	[StaffID] [char](6) NOT NULL,
	[AbsentID] [int] NOT NULL,
	[AbsentMonth] [datetime] NULL,
	[AbsentDays] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[StaffID] ASC,
	[AbsentID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[GroupAccess]    Script Date: 09/03/2017 7:44:35 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GroupAccess](
	[GroupAccessID] [int] IDENTITY(1,1) NOT NULL,
	[GroupAccessName] [nvarchar](20) NULL,
	[Description] [nvarchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[GroupAccessID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Position]    Script Date: 09/03/2017 7:44:35 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Position](
	[PostID] [char](6) NOT NULL,
	[PostName] [nvarchar](20) NULL,
	[Description] [nvarchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[PostID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Rule]    Script Date: 09/03/2017 7:44:35 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Rule](
	[RuleID] [int] IDENTITY(1,1) NOT NULL,
	[SIPayRate] [float] NULL,
	[LeaveAYear] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[RuleID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Salary]    Script Date: 09/03/2017 7:44:35 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Salary](
	[SalaryID] [int] IDENTITY(1,1) NOT NULL,
	[BasicPay] [decimal](20, 2) NULL,
	[SalaryMonth] [datetime] NULL,
	[Workdays] [int] NULL,
	[Allowance] [decimal](20, 2) NULL,
	[AllowanceDescription] [nvarchar](50) NULL,
	[StandardWorkdays] [int] NULL,
	[RealPay] [decimal](20, 2) NULL,
	[StaffID] [char](6) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[SalaryID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Section]    Script Date: 09/03/2017 7:44:35 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Section](
	[SectionID] [char](6) NOT NULL,
	[SectionName] [nvarchar](20) NULL,
	[Description] [nvarchar](50) NULL,
	[StandardWorkdays] [int] NULL,
	[Phone] [varchar](11) NULL,
PRIMARY KEY CLUSTERED 
(
	[SectionID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[SocialInsurance]    Script Date: 09/03/2017 7:44:35 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[SocialInsurance](
	[InsuranceID] [varchar](15) NOT NULL,
	[SIMonth] [datetime] NULL,
	[PayRate] [int] NULL,
	[Price] [decimal](20, 2) NULL,
	[Payment] [nvarchar](20) NULL,
	[StaffID] [char](6) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[InsuranceID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Staff]    Script Date: 09/03/2017 7:44:35 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Staff](
	[StaffID] [char](6) NOT NULL,
	[StaffName] [nvarchar](30) NULL,
	[Image] [varchar](50) NULL,
	[Gender] [bit] NULL,
	[BirthDay] [datetime] NULL,
	[CardID] [varchar](12) NULL,
	[Phone] [varchar](11) NULL,
	[Address] [nvarchar](50) NULL,
	[Education] [nvarchar](30) NULL,
	[StartDate] [datetime] NULL,
	[EndDate] [datetime] NULL,
	[ManagerID] [char](6) NULL,
	[Email] [char](20) NULL,
	[DaysRemain] [int] NULL,
	[PostID] [char](6) NOT NULL,
	[SectionID] [char](6) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[StaffID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[Contract] ([ContractID], [Date], [Currency], [StartDate], [EndDate], [Status], [BasicPay], [Payment], [Note], [StaffID], [ContractTypeID]) VALUES (N'1     ', CAST(N'2017-02-16 00:00:00.000' AS DateTime), N'USD', CAST(N'2017-02-16 00:00:00.000' AS DateTime), CAST(N'2017-02-18 00:00:00.000' AS DateTime), 1, CAST(500000.00 AS Decimal(20, 2)), N'Tiền mặt', NULL, N'NV001 ', N'1     ')
INSERT [dbo].[ContractType] ([ContractTypeID], [ContractTypeName]) VALUES (N'1     ', N'Hợp đồng 6 tháng')
INSERT [dbo].[Position] ([PostID], [PostName], [Description]) VALUES (N'CV01  ', N'Nhân viên', N'Ko')
INSERT [dbo].[Section] ([SectionID], [SectionName], [Description], [StandardWorkdays], [Phone]) VALUES (N'asod  ', N'asd', N'sad', 26, N'2392372387')
INSERT [dbo].[Section] ([SectionID], [SectionName], [Description], [StandardWorkdays], [Phone]) VALUES (N'ddrgt6', N'fgd', N'dfs', 26, N'5657')
INSERT [dbo].[Section] ([SectionID], [SectionName], [Description], [StandardWorkdays], [Phone]) VALUES (N'PB01  ', N'Phòng nhân sự', N'Ko', 24, N'012354152')
INSERT [dbo].[Section] ([SectionID], [SectionName], [Description], [StandardWorkdays], [Phone]) VALUES (N'PB02  ', N'Kinh doanh1', N'Ko', 11, N'0132233')
INSERT [dbo].[Section] ([SectionID], [SectionName], [Description], [StandardWorkdays], [Phone]) VALUES (N'PB07  ', N'asdasdad', N'sa', 26, N'88888888888')
INSERT [dbo].[Section] ([SectionID], [SectionName], [Description], [StandardWorkdays], [Phone]) VALUES (N'Pb09  ', N'asdasd', N'sadasdd', 26, N'65555')
INSERT [dbo].[Section] ([SectionID], [SectionName], [Description], [StandardWorkdays], [Phone]) VALUES (N'PB10  ', N'asidjo', N'ugiuhui', 26, N'23343599')
INSERT [dbo].[Section] ([SectionID], [SectionName], [Description], [StandardWorkdays], [Phone]) VALUES (N'Phone ', N'asdadsds', N'sajdoijsdoi', 26, N'2949429')
INSERT [dbo].[Section] ([SectionID], [SectionName], [Description], [StandardWorkdays], [Phone]) VALUES (N'sda   ', N'sda', N'asd', 26, N'2323')
INSERT [dbo].[Staff] ([StaffID], [StaffName], [Image], [Gender], [BirthDay], [CardID], [Phone], [Address], [Education], [StartDate], [EndDate], [ManagerID], [Email], [DaysRemain], [PostID], [SectionID]) VALUES (N'NV001 ', N'Trần Văn B', NULL, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'CV01  ', N'PB01  ')
SET ANSI_PADDING ON

GO
/****** Object:  Index [UQ__Section__5C7E359E17A12E56]    Script Date: 09/03/2017 7:44:35 CH ******/
ALTER TABLE [dbo].[Section] ADD UNIQUE NONCLUSTERED 
(
	[Phone] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [UQ__Section__737584F6161F7FC7]    Script Date: 09/03/2017 7:44:35 CH ******/
ALTER TABLE [dbo].[Section] ADD UNIQUE NONCLUSTERED 
(
	[SectionName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Access]  WITH CHECK ADD FOREIGN KEY([GroupAccessID])
REFERENCES [dbo].[GroupAccess] ([GroupAccessID])
GO
ALTER TABLE [dbo].[Account]  WITH CHECK ADD FOREIGN KEY([GroupAccessID])
REFERENCES [dbo].[GroupAccess] ([GroupAccessID])
GO
ALTER TABLE [dbo].[Account]  WITH CHECK ADD FOREIGN KEY([StaffID])
REFERENCES [dbo].[Staff] ([StaffID])
GO
ALTER TABLE [dbo].[Contract]  WITH CHECK ADD FOREIGN KEY([ContractTypeID])
REFERENCES [dbo].[ContractType] ([ContractTypeID])
GO
ALTER TABLE [dbo].[Contract]  WITH CHECK ADD FOREIGN KEY([StaffID])
REFERENCES [dbo].[Staff] ([StaffID])
GO
ALTER TABLE [dbo].[DetailAbsent]  WITH CHECK ADD FOREIGN KEY([AbsentID])
REFERENCES [dbo].[Absent] ([AbsentID])
GO
ALTER TABLE [dbo].[DetailAbsent]  WITH CHECK ADD FOREIGN KEY([StaffID])
REFERENCES [dbo].[Staff] ([StaffID])
GO
ALTER TABLE [dbo].[Salary]  WITH CHECK ADD FOREIGN KEY([StaffID])
REFERENCES [dbo].[Staff] ([StaffID])
GO
ALTER TABLE [dbo].[SocialInsurance]  WITH CHECK ADD FOREIGN KEY([StaffID])
REFERENCES [dbo].[Staff] ([StaffID])
GO
ALTER TABLE [dbo].[Staff]  WITH CHECK ADD FOREIGN KEY([PostID])
REFERENCES [dbo].[Position] ([PostID])
GO
ALTER TABLE [dbo].[Staff]  WITH CHECK ADD FOREIGN KEY([SectionID])
REFERENCES [dbo].[Section] ([SectionID])
GO
USE [master]
GO
ALTER DATABASE [HRM] SET  READ_WRITE 
GO
