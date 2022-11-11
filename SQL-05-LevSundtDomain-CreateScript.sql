USE [LevSundtDomain]
GO
/****** Object:  Schema [bmi]    Script Date: 07-11-2022 14:55:19 ******/
CREATE SCHEMA [bmi]
GO
/****** Object:  Table [bmi].[Bmi]    Script Date: 07-11-2022 14:55:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [bmi].[Bmi](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Height] [float] NOT NULL,
	[Weight] [float] NOT NULL,
	[Bmi] [float] NOT NULL,
	[Date] [datetime2](7) NOT NULL,
	[RowVersion] [timestamp] NOT NULL,
	[UserId] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Bmi] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 07-11-2022 14:55:19 ******/
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
SET IDENTITY_INSERT [bmi].[Bmi] ON 
GO
INSERT [bmi].[Bmi] ([Id], [Height], [Weight], [Bmi], [Date], [UserId]) VALUES (1, 200, 100, 25, CAST(N'2022-09-28T17:36:14.5240583' AS DateTime2), N'')
GO
INSERT [bmi].[Bmi] ([Id], [Height], [Weight], [Bmi], [Date], [UserId]) VALUES (2, 200, 100, 25, CAST(N'2022-10-10T13:58:40.3593417' AS DateTime2), N'kbr@ucl.dk')
GO
INSERT [bmi].[Bmi] ([Id], [Height], [Weight], [Bmi], [Date], [UserId]) VALUES (3, 200, 100, 25, CAST(N'2022-10-10T14:15:15.2815538' AS DateTime2), N'test@test.dk')
GO
INSERT [bmi].[Bmi] ([Id], [Height], [Weight], [Bmi], [Date], [UserId]) VALUES (1002, 177, 133, 42.452679625905709, CAST(N'2022-10-25T17:08:27.6610383' AS DateTime2), N'kbr@ucl.dk')
GO
INSERT [bmi].[Bmi] ([Id], [Height], [Weight], [Bmi], [Date], [UserId]) VALUES (1003, 177, 77, 24.577867151840145, CAST(N'2022-10-31T16:15:55.1405632' AS DateTime2), N'kbr@ucl.dk')
GO
SET IDENTITY_INSERT [bmi].[Bmi] OFF
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220927170655_InitialMigration', N'6.0.9')
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220928152256_RowVersionMigration', N'6.0.9')
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20221006135056_UserMigration', N'6.0.9')
GO
ALTER TABLE [bmi].[Bmi] ADD  DEFAULT (N'') FOR [UserId]
GO
