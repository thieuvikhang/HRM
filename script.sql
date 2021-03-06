USE [master]
GO
/****** Object:  Database [HRM]    Script Date: 29/03/2017 1:00:40 CH ******/
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
/****** Object:  Table [dbo].[Absent]    Script Date: 29/03/2017 1:00:40 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Absent](
	[AbsentID] [int] IDENTITY(1,1) NOT NULL,
	[AbsentDay] [int] NULL,
	[FromDate] [datetime] NULL,
	[ToDate] [datetime] NULL,
	[AbsentType] [bit] NULL,
	[Note] [nvarchar](100) NULL,
	[StaffID] [char](6) NOT NULL,
 CONSTRAINT [PK__Absent__36998F47072453A8] PRIMARY KEY CLUSTERED 
(
	[AbsentID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Access]    Script Date: 29/03/2017 1:00:40 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Access](
	[AccessID] [int] IDENTITY(1,1) NOT NULL,
	[Form] [nvarchar](20) NULL,
	[Edit] [bit] NULL,
	[DescriptionAccess] [nvarchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[AccessID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Account]    Script Date: 29/03/2017 1:00:40 CH ******/
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
/****** Object:  Table [dbo].[CateAge]    Script Date: 29/03/2017 1:00:40 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CateAge](
	[id] [int] NOT NULL,
	[name] [nchar](10) NULL,
	[mount] [int] NULL,
 CONSTRAINT [PK_cateage] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Contract]    Script Date: 29/03/2017 1:00:40 CH ******/
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
	[ContractTypeID] [int] NOT NULL,
 CONSTRAINT [PK__Contract__C90D3409548261FD] PRIMARY KEY CLUSTERED 
(
	[ContractID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[DaysRemain]    Script Date: 29/03/2017 1:00:40 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[DaysRemain](
	[DaysRemainID] [int] IDENTITY(1,1) NOT NULL,
	[LeaveAYear] [int] NULL,
	[UsedInYear] [int] NULL,
	[Year] [int] NULL,
	[StaffID] [char](6) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[DaysRemainID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[DetailAccess]    Script Date: 29/03/2017 1:00:40 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DetailAccess](
	[AccessD] [int] NOT NULL,
	[GroupAccessID] [int] NOT NULL,
 CONSTRAINT [PK_GroupAccess] PRIMARY KEY CLUSTERED 
(
	[AccessD] ASC,
	[GroupAccessID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[GroupAccess]    Script Date: 29/03/2017 1:00:40 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GroupAccess](
	[GroupAccessID] [int] NOT NULL,
	[GroupAccessName] [nvarchar](50) NULL,
	[Description] [nvarchar](100) NULL,
 CONSTRAINT [PK_GroupAccess_1] PRIMARY KEY CLUSTERED 
(
	[GroupAccessID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Position]    Script Date: 29/03/2017 1:00:40 CH ******/
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
/****** Object:  Table [dbo].[Rule]    Script Date: 29/03/2017 1:00:40 CH ******/
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
/****** Object:  Table [dbo].[Salary]    Script Date: 29/03/2017 1:00:40 CH ******/
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
/****** Object:  Table [dbo].[Section]    Script Date: 29/03/2017 1:00:40 CH ******/
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
/****** Object:  Table [dbo].[SocialInsurance]    Script Date: 29/03/2017 1:00:40 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[SocialInsurance](
	[InsuranceID] [varchar](15) NOT NULL,
	[SIStartDate] [datetime] NULL,
	[PayRate] [float] NULL,
	[Price] [decimal](20, 2) NULL,
	[Payment] [nvarchar](50) NULL,
	[StaffID] [char](6) NOT NULL,
 CONSTRAINT [PK__SocialIn__74231BC43B20A15A] PRIMARY KEY CLUSTERED 
(
	[InsuranceID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Staff]    Script Date: 29/03/2017 1:00:40 CH ******/
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
	[Address] [nvarchar](100) NULL,
	[Education] [nvarchar](30) NULL,
	[StartDate] [datetime] NULL CONSTRAINT [DF_Staff_StartDate]  DEFAULT (NULL),
	[EndDate] [datetime] NULL,
	[ManagerID] [char](6) NULL,
	[Email] [char](20) NULL,
	[DaysRemain] [int] NULL,
	[PostID] [char](6) NOT NULL,
	[SectionID] [char](6) NOT NULL,
 CONSTRAINT [PK__Staff__96D4AAF7401D8EAB] PRIMARY KEY CLUSTERED 
(
	[StaffID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  View [dbo].[NewEmployees]    Script Date: 29/03/2017 1:00:40 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[NewEmployees]
AS
SELECT       Staff.StaffID, Staff.StaffName, Staff.Gender, Staff.BirthDay, Section.SectionName, Position.PostName, Staff.Education, Staff.StartDate, Staff.Phone
FROM            dbo.Staff AS Staff INNER JOIN
                         dbo.Section AS Section ON Section.SectionID = Staff.SectionID INNER JOIN
                         dbo.Position AS Position ON Position.PostID = Staff.PostID

GO
SET IDENTITY_INSERT [dbo].[Absent] ON 

INSERT [dbo].[Absent] ([AbsentID], [AbsentDay], [FromDate], [ToDate], [AbsentType], [Note], [StaffID]) VALUES (6, 9, CAST(N'2017-03-20 09:30:26.667' AS DateTime), CAST(N'2017-03-30 09:30:26.667' AS DateTime), 1, N'', N'NV6   ')
INSERT [dbo].[Absent] ([AbsentID], [AbsentDay], [FromDate], [ToDate], [AbsentType], [Note], [StaffID]) VALUES (8, 13, CAST(N'2017-03-09 00:00:00.000' AS DateTime), CAST(N'2017-03-24 00:00:00.000' AS DateTime), 0, N'', N'NV003 ')
INSERT [dbo].[Absent] ([AbsentID], [AbsentDay], [FromDate], [ToDate], [AbsentType], [Note], [StaffID]) VALUES (9, 2, CAST(N'2017-03-28 00:00:00.000' AS DateTime), CAST(N'2017-03-30 00:00:00.000' AS DateTime), 0, N'', N'NV004 ')
INSERT [dbo].[Absent] ([AbsentID], [AbsentDay], [FromDate], [ToDate], [AbsentType], [Note], [StaffID]) VALUES (10, 15, CAST(N'2017-03-01 00:00:00.000' AS DateTime), CAST(N'2017-03-18 00:00:00.000' AS DateTime), 0, N'', N'NV8   ')
SET IDENTITY_INSERT [dbo].[Absent] OFF
SET IDENTITY_INSERT [dbo].[Access] ON 

INSERT [dbo].[Access] ([AccessID], [Form], [Edit], [DescriptionAccess]) VALUES (1, N'barEmployees', 1, N'Tạo nhân viên')
INSERT [dbo].[Access] ([AccessID], [Form], [Edit], [DescriptionAccess]) VALUES (2, N'barEmployees', 0, NULL)
INSERT [dbo].[Access] ([AccessID], [Form], [Edit], [DescriptionAccess]) VALUES (3, N'barSection', 1, NULL)
INSERT [dbo].[Access] ([AccessID], [Form], [Edit], [DescriptionAccess]) VALUES (4, N'barSection', 0, NULL)
INSERT [dbo].[Access] ([AccessID], [Form], [Edit], [DescriptionAccess]) VALUES (5, N'barPostion', 1, NULL)
INSERT [dbo].[Access] ([AccessID], [Form], [Edit], [DescriptionAccess]) VALUES (6, N'barPostion', 0, NULL)
INSERT [dbo].[Access] ([AccessID], [Form], [Edit], [DescriptionAccess]) VALUES (7, N'barContract', 1, NULL)
INSERT [dbo].[Access] ([AccessID], [Form], [Edit], [DescriptionAccess]) VALUES (8, N'barContract', 0, NULL)
INSERT [dbo].[Access] ([AccessID], [Form], [Edit], [DescriptionAccess]) VALUES (9, N'barSI', 1, NULL)
INSERT [dbo].[Access] ([AccessID], [Form], [Edit], [DescriptionAccess]) VALUES (10, N'barSI', 0, NULL)
INSERT [dbo].[Access] ([AccessID], [Form], [Edit], [DescriptionAccess]) VALUES (11, N'barAbsent', 1, NULL)
INSERT [dbo].[Access] ([AccessID], [Form], [Edit], [DescriptionAccess]) VALUES (12, N'barAbsent', 0, NULL)
INSERT [dbo].[Access] ([AccessID], [Form], [Edit], [DescriptionAccess]) VALUES (13, N'barSalary', 1, NULL)
INSERT [dbo].[Access] ([AccessID], [Form], [Edit], [DescriptionAccess]) VALUES (14, N'barSalary', 0, NULL)
INSERT [dbo].[Access] ([AccessID], [Form], [Edit], [DescriptionAccess]) VALUES (15, N'barAccess', 1, NULL)
INSERT [dbo].[Access] ([AccessID], [Form], [Edit], [DescriptionAccess]) VALUES (16, N'barAccess', 0, NULL)
SET IDENTITY_INSERT [dbo].[Access] OFF
SET IDENTITY_INSERT [dbo].[Account] ON 

INSERT [dbo].[Account] ([AccID], [UserName], [Password], [GroupAccessID], [StaffID]) VALUES (1, N'abc                 ', N'123                           ', 1, N'NV001 ')
SET IDENTITY_INSERT [dbo].[Account] OFF
INSERT [dbo].[CateAge] ([id], [name], [mount]) VALUES (1, N'<= 20     ', 0)
INSERT [dbo].[CateAge] ([id], [name], [mount]) VALUES (2, N'21 ➝ 30   ', 3)
INSERT [dbo].[CateAge] ([id], [name], [mount]) VALUES (3, N'31 ➝ 40   ', 0)
INSERT [dbo].[CateAge] ([id], [name], [mount]) VALUES (4, N'41 ➝ 50   ', 2)
INSERT [dbo].[CateAge] ([id], [name], [mount]) VALUES (5, N'> 50      ', 1)
INSERT [dbo].[Contract] ([ContractID], [Date], [Currency], [StartDate], [EndDate], [Status], [BasicPay], [Payment], [Note], [StaffID], [ContractTypeID]) VALUES (N'HD2702', CAST(N'2017-03-10 00:00:00.000' AS DateTime), N'VND', CAST(N'2017-03-23 00:00:00.000' AS DateTime), CAST(N'2017-03-23 00:00:00.000' AS DateTime), 1, CAST(9000000000.00 AS Decimal(20, 2)), N'Tiền mặt', N'', N'NV004 ', 12)
INSERT [dbo].[Contract] ([ContractID], [Date], [Currency], [StartDate], [EndDate], [Status], [BasicPay], [Payment], [Note], [StaffID], [ContractTypeID]) VALUES (N'HD3694', CAST(N'2017-03-09 00:00:00.000' AS DateTime), N'VND', CAST(N'2017-03-09 00:00:00.000' AS DateTime), CAST(N'2017-03-21 00:00:00.000' AS DateTime), 1, CAST(999999999.00 AS Decimal(20, 2)), N'Tiền mặt', N'', N'NV001 ', 3)
INSERT [dbo].[Contract] ([ContractID], [Date], [Currency], [StartDate], [EndDate], [Status], [BasicPay], [Payment], [Note], [StaffID], [ContractTypeID]) VALUES (N'HD8869', CAST(N'2017-03-29 12:21:05.097' AS DateTime), N'VND', CAST(N'2017-04-01 12:21:05.097' AS DateTime), CAST(N'2018-04-01 12:21:05.097' AS DateTime), 1, CAST(675676.00 AS Decimal(20, 2)), N'Thẻ ATM', N'', N'NV001 ', 12)
INSERT [dbo].[Contract] ([ContractID], [Date], [Currency], [StartDate], [EndDate], [Status], [BasicPay], [Payment], [Note], [StaffID], [ContractTypeID]) VALUES (N'HD8915', CAST(N'2017-03-29 12:21:58.523' AS DateTime), N'VND', CAST(N'2017-03-31 12:21:58.523' AS DateTime), NULL, 1, CAST(99999999.00 AS Decimal(20, 2)), N'Tiền mặt', N'', N'NV001 ', 0)
INSERT [dbo].[Contract] ([ContractID], [Date], [Currency], [StartDate], [EndDate], [Status], [BasicPay], [Payment], [Note], [StaffID], [ContractTypeID]) VALUES (N'HD9862', CAST(N'2017-03-29 00:00:00.000' AS DateTime), N'VND', CAST(N'2017-04-07 12:56:51.243' AS DateTime), NULL, 1, CAST(999.00 AS Decimal(20, 2)), N'Tiền mặt', N'', N'NV001 ', 0)
SET IDENTITY_INSERT [dbo].[DaysRemain] ON 

INSERT [dbo].[DaysRemain] ([DaysRemainID], [LeaveAYear], [UsedInYear], [Year], [StaffID]) VALUES (2, 12, 2, 2017, N'NV004 ')
INSERT [dbo].[DaysRemain] ([DaysRemainID], [LeaveAYear], [UsedInYear], [Year], [StaffID]) VALUES (3, 12, 0, 2017, N'NV8   ')
SET IDENTITY_INSERT [dbo].[DaysRemain] OFF
INSERT [dbo].[DetailAccess] ([AccessD], [GroupAccessID]) VALUES (1, 1)
INSERT [dbo].[GroupAccess] ([GroupAccessID], [GroupAccessName], [Description]) VALUES (1, N'QLNV', NULL)
INSERT [dbo].[Position] ([PostID], [PostName], [Description]) VALUES (N'CV01  ', N'Nhân viên', N'Ko')
INSERT [dbo].[Position] ([PostID], [PostName], [Description]) VALUES (N'CV02  ', N'Trưởng phòng', N'')
INSERT [dbo].[Position] ([PostID], [PostName], [Description]) VALUES (N'CV03  ', N'kkk', N'')
SET IDENTITY_INSERT [dbo].[Rule] ON 

INSERT [dbo].[Rule] ([RuleID], [SIPayRate], [LeaveAYear]) VALUES (1, 8, 12)
SET IDENTITY_INSERT [dbo].[Rule] OFF
SET IDENTITY_INSERT [dbo].[Salary] ON 

INSERT [dbo].[Salary] ([SalaryID], [BasicPay], [SalaryMonth], [Workdays], [Allowance], [AllowanceDescription], [StandardWorkdays], [RealPay], [StaffID]) VALUES (2, CAST(9000.00 AS Decimal(20, 2)), CAST(N'2017-02-01 00:00:00.000' AS DateTime), 24, CAST(7.00 AS Decimal(20, 2)), N'', 24, CAST(9007.00 AS Decimal(20, 2)), N'NV6   ')
INSERT [dbo].[Salary] ([SalaryID], [BasicPay], [SalaryMonth], [Workdays], [Allowance], [AllowanceDescription], [StandardWorkdays], [RealPay], [StaffID]) VALUES (3, CAST(5000000000.00 AS Decimal(20, 2)), CAST(N'2017-02-01 00:00:00.000' AS DateTime), 24, CAST(3000.00 AS Decimal(20, 2)), N'', 24, CAST(5000003000.00 AS Decimal(20, 2)), N'NV001 ')
INSERT [dbo].[Salary] ([SalaryID], [BasicPay], [SalaryMonth], [Workdays], [Allowance], [AllowanceDescription], [StandardWorkdays], [RealPay], [StaffID]) VALUES (4, CAST(0.00 AS Decimal(20, 2)), CAST(N'2017-02-01 00:00:00.000' AS DateTime), 24, CAST(0.00 AS Decimal(20, 2)), N'', 24, CAST(0.00 AS Decimal(20, 2)), N'NV003 ')
INSERT [dbo].[Salary] ([SalaryID], [BasicPay], [SalaryMonth], [Workdays], [Allowance], [AllowanceDescription], [StandardWorkdays], [RealPay], [StaffID]) VALUES (5, CAST(0.00 AS Decimal(20, 2)), CAST(N'2017-02-01 00:00:00.000' AS DateTime), 24, CAST(0.00 AS Decimal(20, 2)), N'', 24, CAST(0.00 AS Decimal(20, 2)), N'NV004 ')
SET IDENTITY_INSERT [dbo].[Salary] OFF
INSERT [dbo].[Section] ([SectionID], [SectionName], [Description], [StandardWorkdays], [Phone]) VALUES (N'PB01  ', N'Phòng nhân sự', N'Ko', 24, N'012354152')
INSERT [dbo].[Section] ([SectionID], [SectionName], [Description], [StandardWorkdays], [Phone]) VALUES (N'PB02  ', N'Kinh doanh', N'Ko', 24, N'0132233')
INSERT [dbo].[SocialInsurance] ([InsuranceID], [SIStartDate], [PayRate], [Price], [Payment], [StaffID]) VALUES (N'BH2586', CAST(N'2017-03-10 00:00:00.000' AS DateTime), 8, CAST(720000.00 AS Decimal(20, 2)), NULL, N'NV001 ')
INSERT [dbo].[Staff] ([StaffID], [StaffName], [Image], [Gender], [BirthDay], [CardID], [Phone], [Address], [Education], [StartDate], [EndDate], [ManagerID], [Email], [DaysRemain], [PostID], [SectionID]) VALUES (N'NV001 ', N'Trần Văn B', NULL, 1, CAST(N'1995-10-18 00:00:00.000' AS DateTime), N'', N'', N'132', N'', CAST(N'2017-03-18 00:00:00.000' AS DateTime), NULL, N'NV001 ', N'                    ', 10, N'CV01  ', N'PB01  ')
INSERT [dbo].[Staff] ([StaffID], [StaffName], [Image], [Gender], [BirthDay], [CardID], [Phone], [Address], [Education], [StartDate], [EndDate], [ManagerID], [Email], [DaysRemain], [PostID], [SectionID]) VALUES (N'NV003 ', N'Khang', NULL, 1, CAST(N'1950-03-18 00:00:00.000' AS DateTime), N'', N'', N'', N'Đại học', NULL, NULL, N'NV001 ', N'                    ', 10, N'CV01  ', N'PB02  ')
INSERT [dbo].[Staff] ([StaffID], [StaffName], [Image], [Gender], [BirthDay], [CardID], [Phone], [Address], [Education], [StartDate], [EndDate], [ManagerID], [Email], [DaysRemain], [PostID], [SectionID]) VALUES (N'NV004 ', N'khang', NULL, 1, NULL, N'', N'', N'', N'Đại học', NULL, NULL, N'NV001 ', N'                    ', 10, N'CV02  ', N'PB02  ')
INSERT [dbo].[Staff] ([StaffID], [StaffName], [Image], [Gender], [BirthDay], [CardID], [Phone], [Address], [Education], [StartDate], [EndDate], [ManagerID], [Email], [DaysRemain], [PostID], [SectionID]) VALUES (N'NV005 ', N'C', NULL, 1, CAST(N'1989-03-18 00:00:00.000' AS DateTime), N'', N'', N'', N'Đại học', NULL, NULL, N'NV001 ', N'                    ', 10, N'CV01  ', N'PB02  ')
INSERT [dbo].[Staff] ([StaffID], [StaffName], [Image], [Gender], [BirthDay], [CardID], [Phone], [Address], [Education], [StartDate], [EndDate], [ManagerID], [Email], [DaysRemain], [PostID], [SectionID]) VALUES (N'NV007 ', N'Kha', NULL, 1, CAST(N'1995-03-18 00:00:00.000' AS DateTime), N'', N'', N'', N'Đại học', NULL, NULL, N'NV001 ', N'                    ', 10, N'CV01  ', N'PB02  ')
INSERT [dbo].[Staff] ([StaffID], [StaffName], [Image], [Gender], [BirthDay], [CardID], [Phone], [Address], [Education], [StartDate], [EndDate], [ManagerID], [Email], [DaysRemain], [PostID], [SectionID]) VALUES (N'NV6   ', N'Cường', NULL, 0, CAST(N'1969-03-15 00:00:00.000' AS DateTime), N'', N'', N'hdoihdaios', N'Đại học', NULL, NULL, N'NV001 ', N'                    ', 10, N'CV01  ', N'PB02  ')
INSERT [dbo].[Staff] ([StaffID], [StaffName], [Image], [Gender], [BirthDay], [CardID], [Phone], [Address], [Education], [StartDate], [EndDate], [ManagerID], [Email], [DaysRemain], [PostID], [SectionID]) VALUES (N'NV7   ', N'Toàn', NULL, 1, CAST(N'1970-03-15 00:00:00.000' AS DateTime), N'', N'', N'', N'Đại học', NULL, NULL, N'NV001 ', N'                    ', NULL, N'CV01  ', N'PB01  ')
INSERT [dbo].[Staff] ([StaffID], [StaffName], [Image], [Gender], [BirthDay], [CardID], [Phone], [Address], [Education], [StartDate], [EndDate], [ManagerID], [Email], [DaysRemain], [PostID], [SectionID]) VALUES (N'NV8   ', N'Khang Test', NULL, 1, CAST(N'2017-03-27 00:00:00.000' AS DateTime), N'012161615166', N'', N'', N'Đại học', CAST(N'2017-03-09 00:00:00.000' AS DateTime), NULL, N'NV6   ', N'                    ', NULL, N'CV01  ', N'PB02  ')
SET ANSI_PADDING ON

GO
/****** Object:  Index [UQ__Section__8DACF8BE61732A55]    Script Date: 29/03/2017 1:00:40 CH ******/
ALTER TABLE [dbo].[Section] ADD UNIQUE NONCLUSTERED 
(
	[SectionName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Absent]  WITH CHECK ADD  CONSTRAINT [FK_Absent_Staff] FOREIGN KEY([StaffID])
REFERENCES [dbo].[Staff] ([StaffID])
GO
ALTER TABLE [dbo].[Absent] CHECK CONSTRAINT [FK_Absent_Staff]
GO
ALTER TABLE [dbo].[Account]  WITH CHECK ADD  CONSTRAINT [FK__Account__StaffID__2A4B4B5E] FOREIGN KEY([StaffID])
REFERENCES [dbo].[Staff] ([StaffID])
GO
ALTER TABLE [dbo].[Account] CHECK CONSTRAINT [FK__Account__StaffID__2A4B4B5E]
GO
ALTER TABLE [dbo].[Account]  WITH CHECK ADD  CONSTRAINT [FK_Account_GroupAccess] FOREIGN KEY([GroupAccessID])
REFERENCES [dbo].[GroupAccess] ([GroupAccessID])
GO
ALTER TABLE [dbo].[Account] CHECK CONSTRAINT [FK_Account_GroupAccess]
GO
ALTER TABLE [dbo].[Contract]  WITH CHECK ADD  CONSTRAINT [FK__Contract__StaffI__2C3393D0] FOREIGN KEY([StaffID])
REFERENCES [dbo].[Staff] ([StaffID])
GO
ALTER TABLE [dbo].[Contract] CHECK CONSTRAINT [FK__Contract__StaffI__2C3393D0]
GO
ALTER TABLE [dbo].[DaysRemain]  WITH CHECK ADD FOREIGN KEY([StaffID])
REFERENCES [dbo].[Staff] ([StaffID])
GO
ALTER TABLE [dbo].[DetailAccess]  WITH CHECK ADD  CONSTRAINT [FK_DetailAccess_Access] FOREIGN KEY([AccessD])
REFERENCES [dbo].[Access] ([AccessID])
GO
ALTER TABLE [dbo].[DetailAccess] CHECK CONSTRAINT [FK_DetailAccess_Access]
GO
ALTER TABLE [dbo].[DetailAccess]  WITH CHECK ADD  CONSTRAINT [FK_DetailAccess_GroupAccess] FOREIGN KEY([GroupAccessID])
REFERENCES [dbo].[GroupAccess] ([GroupAccessID])
GO
ALTER TABLE [dbo].[DetailAccess] CHECK CONSTRAINT [FK_DetailAccess_GroupAccess]
GO
ALTER TABLE [dbo].[Salary]  WITH CHECK ADD  CONSTRAINT [FK__Salary__StaffID__2D27B809] FOREIGN KEY([StaffID])
REFERENCES [dbo].[Staff] ([StaffID])
GO
ALTER TABLE [dbo].[Salary] CHECK CONSTRAINT [FK__Salary__StaffID__2D27B809]
GO
ALTER TABLE [dbo].[SocialInsurance]  WITH CHECK ADD  CONSTRAINT [FK__SocialIns__Staff__2E1BDC42] FOREIGN KEY([StaffID])
REFERENCES [dbo].[Staff] ([StaffID])
GO
ALTER TABLE [dbo].[SocialInsurance] CHECK CONSTRAINT [FK__SocialIns__Staff__2E1BDC42]
GO
ALTER TABLE [dbo].[Staff]  WITH CHECK ADD  CONSTRAINT [FK__Staff__PostID__2F10007B] FOREIGN KEY([PostID])
REFERENCES [dbo].[Position] ([PostID])
GO
ALTER TABLE [dbo].[Staff] CHECK CONSTRAINT [FK__Staff__PostID__2F10007B]
GO
ALTER TABLE [dbo].[Staff]  WITH CHECK ADD  CONSTRAINT [FK__Staff__SectionID__300424B4] FOREIGN KEY([SectionID])
REFERENCES [dbo].[Section] ([SectionID])
GO
ALTER TABLE [dbo].[Staff] CHECK CONSTRAINT [FK__Staff__SectionID__300424B4]
GO
/****** Object:  StoredProcedure [dbo].[Age_Range]    Script Date: 29/03/2017 1:00:40 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create Procedure [dbo].[Age_Range]
as
begin
update CateAge 
set mount = case id
when 1 then (select count(StaffID) from Staff where datediff(YEAR, birthday, getdate()) <= 20)
when 2 then (select count(StaffID) from Staff where datediff(YEAR, birthday, getdate()) > 20 and datediff(YEAR, birthday, getdate()) <= 30)
when 3 then (select count(StaffID) from Staff where datediff(YEAR, birthday, getdate()) > 30 and datediff(YEAR, birthday, getdate()) <= 40)
when 4 then (select count(StaffID) from Staff where datediff(YEAR, birthday, getdate()) > 40 and datediff(YEAR, birthday, getdate()) <= 50)
when 5 then (select count(StaffID) from Staff where datediff(YEAR, birthday, getdate()) > 50)
end
where id in (1,2,3,4,5)
end
GO
/****** Object:  StoredProcedure [dbo].[Sp_absent]    Script Date: 29/03/2017 1:00:40 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[Sp_absent]

as

begin
	select AbsentType,
	case
	when AbsentType = 1 then N'Có phép' 
	 when AbsentType = 0 then N'Không phép'
	 else N'Không xác định'
	 end as Name
	from Absent
	
end
GO
/****** Object:  StoredProcedure [dbo].[test]    Script Date: 29/03/2017 1:00:40 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[test]
as
select
count(case when datediff(YEAR, birthday, getdate()) > 40 then 1 else null end) as '< 40',
count(case when datediff(YEAR, birthday, getdate()) < 20 then 1 else null end) as '< 20'
from Staff


GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "Staff"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 136
               Right = 208
            End
            DisplayFlags = 280
            TopColumn = 5
         End
         Begin Table = "Section"
            Begin Extent = 
               Top = 6
               Left = 246
               Bottom = 136
               Right = 434
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Position"
            Begin Extent = 
               Top = 138
               Left = 38
               Bottom = 251
               Right = 208
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'NewEmployees'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'NewEmployees'
GO
USE [master]
GO
ALTER DATABASE [HRM] SET  READ_WRITE 
GO
