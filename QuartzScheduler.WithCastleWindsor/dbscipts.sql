USE [master]
GO
/****** Object:  Database [quartz]    Script Date: 03/03/2015 20:04:31 ******/
CREATE DATABASE [quartz] ON  PRIMARY 
( NAME = N'quartz', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL10_50.MSSQLSERVER\MSSQL\DATA\quartz.mdf' , SIZE = 3072KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'quartz_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL10_50.MSSQLSERVER\MSSQL\DATA\quartz_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [quartz] SET COMPATIBILITY_LEVEL = 100
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [quartz].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [quartz] SET ANSI_NULL_DEFAULT OFF
GO
ALTER DATABASE [quartz] SET ANSI_NULLS OFF
GO
ALTER DATABASE [quartz] SET ANSI_PADDING OFF
GO
ALTER DATABASE [quartz] SET ANSI_WARNINGS OFF
GO
ALTER DATABASE [quartz] SET ARITHABORT OFF
GO
ALTER DATABASE [quartz] SET AUTO_CLOSE OFF
GO
ALTER DATABASE [quartz] SET AUTO_CREATE_STATISTICS ON
GO
ALTER DATABASE [quartz] SET AUTO_SHRINK OFF
GO
ALTER DATABASE [quartz] SET AUTO_UPDATE_STATISTICS ON
GO
ALTER DATABASE [quartz] SET CURSOR_CLOSE_ON_COMMIT OFF
GO
ALTER DATABASE [quartz] SET CURSOR_DEFAULT  GLOBAL
GO
ALTER DATABASE [quartz] SET CONCAT_NULL_YIELDS_NULL OFF
GO
ALTER DATABASE [quartz] SET NUMERIC_ROUNDABORT OFF
GO
ALTER DATABASE [quartz] SET QUOTED_IDENTIFIER OFF
GO
ALTER DATABASE [quartz] SET RECURSIVE_TRIGGERS OFF
GO
ALTER DATABASE [quartz] SET  DISABLE_BROKER
GO
ALTER DATABASE [quartz] SET AUTO_UPDATE_STATISTICS_ASYNC OFF
GO
ALTER DATABASE [quartz] SET DATE_CORRELATION_OPTIMIZATION OFF
GO
ALTER DATABASE [quartz] SET TRUSTWORTHY OFF
GO
ALTER DATABASE [quartz] SET ALLOW_SNAPSHOT_ISOLATION OFF
GO
ALTER DATABASE [quartz] SET PARAMETERIZATION SIMPLE
GO
ALTER DATABASE [quartz] SET READ_COMMITTED_SNAPSHOT OFF
GO
ALTER DATABASE [quartz] SET HONOR_BROKER_PRIORITY OFF
GO
ALTER DATABASE [quartz] SET  READ_WRITE
GO
ALTER DATABASE [quartz] SET RECOVERY FULL
GO
ALTER DATABASE [quartz] SET  MULTI_USER
GO
ALTER DATABASE [quartz] SET PAGE_VERIFY CHECKSUM
GO
ALTER DATABASE [quartz] SET DB_CHAINING OFF
GO
EXEC sys.sp_db_vardecimal_storage_format N'quartz', N'ON'
GO
USE [quartz]
GO
/****** Object:  Schema [LOGGER]    Script Date: 03/03/2015 20:04:31 ******/
CREATE SCHEMA [LOGGER] AUTHORIZATION [dbo]
GO
/****** Object:  Table [dbo].[QRTZ_CALENDARS]    Script Date: 03/03/2015 20:04:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[QRTZ_CALENDARS](
	[SCHED_NAME] [nvarchar](100) NOT NULL,
	[CALENDAR_NAME] [nvarchar](200) NOT NULL,
	[CALENDAR] [image] NOT NULL,
 CONSTRAINT [PK_QRTZ_CALENDARS] PRIMARY KEY CLUSTERED 
(
	[SCHED_NAME] ASC,
	[CALENDAR_NAME] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[QRTZ_BLOB_TRIGGERS]    Script Date: 03/03/2015 20:04:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[QRTZ_BLOB_TRIGGERS](
	[SCHED_NAME] [nvarchar](100) NOT NULL,
	[TRIGGER_NAME] [nvarchar](150) NOT NULL,
	[TRIGGER_GROUP] [nvarchar](150) NOT NULL,
	[BLOB_DATA] [image] NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [LOGGER].[NLOG]    Script Date: 03/03/2015 20:04:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [LOGGER].[NLOG](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[TIME_STAMP] [datetime] NULL,
	[MESSAGE] [nvarchar](max) NULL,
	[LEVEL] [nvarchar](10) NULL,
	[LOGGER] [nvarchar](128) NULL,
	[TRACE_ID] [int] NULL,
	[MODULE_NAME] [nvarchar](50) NULL,
	[METHOD_NAME] [nvarchar](50) NULL,
	[REQUEST_ID] [nvarchar](50) NULL,
	[SESSION_ID] [nvarchar](50) NULL,
	[APPLICATION_ID] [int] NULL,
	[CHANNEL_ID] [int] NULL,
	[LINE_NUMBER] [int] NULL,
	[FILE_NAME] [nvarchar](300) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[QRTZ_SCHEDULER_STATE]    Script Date: 03/03/2015 20:04:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[QRTZ_SCHEDULER_STATE](
	[SCHED_NAME] [nvarchar](100) NOT NULL,
	[INSTANCE_NAME] [nvarchar](200) NOT NULL,
	[LAST_CHECKIN_TIME] [bigint] NOT NULL,
	[CHECKIN_INTERVAL] [bigint] NOT NULL,
 CONSTRAINT [PK_QRTZ_SCHEDULER_STATE] PRIMARY KEY CLUSTERED 
(
	[SCHED_NAME] ASC,
	[INSTANCE_NAME] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[QRTZ_PAUSED_TRIGGER_GRPS]    Script Date: 03/03/2015 20:04:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[QRTZ_PAUSED_TRIGGER_GRPS](
	[SCHED_NAME] [nvarchar](100) NOT NULL,
	[TRIGGER_GROUP] [nvarchar](150) NOT NULL,
 CONSTRAINT [PK_QRTZ_PAUSED_TRIGGER_GRPS] PRIMARY KEY CLUSTERED 
(
	[SCHED_NAME] ASC,
	[TRIGGER_GROUP] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[QRTZ_LOCKS]    Script Date: 03/03/2015 20:04:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[QRTZ_LOCKS](
	[SCHED_NAME] [nvarchar](100) NOT NULL,
	[LOCK_NAME] [nvarchar](40) NOT NULL,
 CONSTRAINT [PK_QRTZ_LOCKS] PRIMARY KEY CLUSTERED 
(
	[SCHED_NAME] ASC,
	[LOCK_NAME] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[QRTZ_JOB_DETAILS]    Script Date: 03/03/2015 20:04:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[QRTZ_JOB_DETAILS](
	[SCHED_NAME] [nvarchar](100) NOT NULL,
	[JOB_NAME] [nvarchar](150) NOT NULL,
	[JOB_GROUP] [nvarchar](150) NOT NULL,
	[DESCRIPTION] [nvarchar](250) NULL,
	[JOB_CLASS_NAME] [nvarchar](250) NOT NULL,
	[IS_DURABLE] [bit] NOT NULL,
	[IS_NONCONCURRENT] [bit] NOT NULL,
	[IS_UPDATE_DATA] [bit] NOT NULL,
	[REQUESTS_RECOVERY] [bit] NOT NULL,
	[JOB_DATA] [image] NULL,
 CONSTRAINT [PK_QRTZ_JOB_DETAILS] PRIMARY KEY CLUSTERED 
(
	[SCHED_NAME] ASC,
	[JOB_NAME] ASC,
	[JOB_GROUP] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[QRTZ_FIRED_TRIGGERS]    Script Date: 03/03/2015 20:04:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[QRTZ_FIRED_TRIGGERS](
	[SCHED_NAME] [nvarchar](100) NOT NULL,
	[ENTRY_ID] [nvarchar](95) NOT NULL,
	[TRIGGER_NAME] [nvarchar](150) NOT NULL,
	[TRIGGER_GROUP] [nvarchar](150) NOT NULL,
	[INSTANCE_NAME] [nvarchar](200) NOT NULL,
	[FIRED_TIME] [bigint] NOT NULL,
	[PRIORITY] [int] NOT NULL,
	[STATE] [nvarchar](16) NOT NULL,
	[JOB_NAME] [nvarchar](150) NULL,
	[JOB_GROUP] [nvarchar](150) NULL,
	[IS_NONCONCURRENT] [bit] NULL,
	[REQUESTS_RECOVERY] [bit] NULL,
	[SCHED_TIME] [bigint] NULL,
 CONSTRAINT [PK_QRTZ_FIRED_TRIGGERS] PRIMARY KEY CLUSTERED 
(
	[SCHED_NAME] ASC,
	[ENTRY_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IDX_QRTZ_FT_INST_JOB_REQ_RCVRY] ON [dbo].[QRTZ_FIRED_TRIGGERS] 
(
	[SCHED_NAME] ASC,
	[INSTANCE_NAME] ASC,
	[REQUESTS_RECOVERY] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IDX_QRTZ_FT_J_G] ON [dbo].[QRTZ_FIRED_TRIGGERS] 
(
	[SCHED_NAME] ASC,
	[JOB_NAME] ASC,
	[JOB_GROUP] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IDX_QRTZ_FT_JG] ON [dbo].[QRTZ_FIRED_TRIGGERS] 
(
	[SCHED_NAME] ASC,
	[JOB_GROUP] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IDX_QRTZ_FT_T_G] ON [dbo].[QRTZ_FIRED_TRIGGERS] 
(
	[SCHED_NAME] ASC,
	[TRIGGER_NAME] ASC,
	[TRIGGER_GROUP] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IDX_QRTZ_FT_TG] ON [dbo].[QRTZ_FIRED_TRIGGERS] 
(
	[SCHED_NAME] ASC,
	[TRIGGER_GROUP] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IDX_QRTZ_FT_TRIG_INST_NAME] ON [dbo].[QRTZ_FIRED_TRIGGERS] 
(
	[SCHED_NAME] ASC,
	[INSTANCE_NAME] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[QRTZ_TRIGGERS]    Script Date: 03/03/2015 20:04:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[QRTZ_TRIGGERS](
	[SCHED_NAME] [nvarchar](100) NOT NULL,
	[TRIGGER_NAME] [nvarchar](150) NOT NULL,
	[TRIGGER_GROUP] [nvarchar](150) NOT NULL,
	[JOB_NAME] [nvarchar](150) NOT NULL,
	[JOB_GROUP] [nvarchar](150) NOT NULL,
	[DESCRIPTION] [nvarchar](250) NULL,
	[NEXT_FIRE_TIME] [bigint] NULL,
	[PREV_FIRE_TIME] [bigint] NULL,
	[PRIORITY] [int] NULL,
	[TRIGGER_STATE] [nvarchar](16) NOT NULL,
	[TRIGGER_TYPE] [nvarchar](8) NOT NULL,
	[START_TIME] [bigint] NOT NULL,
	[END_TIME] [bigint] NULL,
	[CALENDAR_NAME] [nvarchar](200) NULL,
	[MISFIRE_INSTR] [int] NULL,
	[JOB_DATA] [image] NULL,
 CONSTRAINT [PK_QRTZ_TRIGGERS] PRIMARY KEY CLUSTERED 
(
	[SCHED_NAME] ASC,
	[TRIGGER_NAME] ASC,
	[TRIGGER_GROUP] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IDX_QRTZ_T_C] ON [dbo].[QRTZ_TRIGGERS] 
(
	[SCHED_NAME] ASC,
	[CALENDAR_NAME] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IDX_QRTZ_T_G] ON [dbo].[QRTZ_TRIGGERS] 
(
	[SCHED_NAME] ASC,
	[TRIGGER_GROUP] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IDX_QRTZ_T_J] ON [dbo].[QRTZ_TRIGGERS] 
(
	[SCHED_NAME] ASC,
	[JOB_NAME] ASC,
	[JOB_GROUP] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IDX_QRTZ_T_JG] ON [dbo].[QRTZ_TRIGGERS] 
(
	[SCHED_NAME] ASC,
	[JOB_GROUP] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IDX_QRTZ_T_N_G_STATE] ON [dbo].[QRTZ_TRIGGERS] 
(
	[SCHED_NAME] ASC,
	[TRIGGER_GROUP] ASC,
	[TRIGGER_STATE] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IDX_QRTZ_T_N_STATE] ON [dbo].[QRTZ_TRIGGERS] 
(
	[SCHED_NAME] ASC,
	[TRIGGER_NAME] ASC,
	[TRIGGER_GROUP] ASC,
	[TRIGGER_STATE] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IDX_QRTZ_T_NEXT_FIRE_TIME] ON [dbo].[QRTZ_TRIGGERS] 
(
	[SCHED_NAME] ASC,
	[NEXT_FIRE_TIME] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IDX_QRTZ_T_NFT_MISFIRE] ON [dbo].[QRTZ_TRIGGERS] 
(
	[SCHED_NAME] ASC,
	[MISFIRE_INSTR] ASC,
	[NEXT_FIRE_TIME] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IDX_QRTZ_T_NFT_ST] ON [dbo].[QRTZ_TRIGGERS] 
(
	[SCHED_NAME] ASC,
	[TRIGGER_STATE] ASC,
	[NEXT_FIRE_TIME] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IDX_QRTZ_T_NFT_ST_MISFIRE] ON [dbo].[QRTZ_TRIGGERS] 
(
	[SCHED_NAME] ASC,
	[MISFIRE_INSTR] ASC,
	[NEXT_FIRE_TIME] ASC,
	[TRIGGER_STATE] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IDX_QRTZ_T_NFT_ST_MISFIRE_GRP] ON [dbo].[QRTZ_TRIGGERS] 
(
	[SCHED_NAME] ASC,
	[MISFIRE_INSTR] ASC,
	[NEXT_FIRE_TIME] ASC,
	[TRIGGER_GROUP] ASC,
	[TRIGGER_STATE] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IDX_QRTZ_T_STATE] ON [dbo].[QRTZ_TRIGGERS] 
(
	[SCHED_NAME] ASC,
	[TRIGGER_STATE] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[QRTZ_SIMPROP_TRIGGERS]    Script Date: 03/03/2015 20:04:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[QRTZ_SIMPROP_TRIGGERS](
	[SCHED_NAME] [nvarchar](100) NOT NULL,
	[TRIGGER_NAME] [nvarchar](150) NOT NULL,
	[TRIGGER_GROUP] [nvarchar](150) NOT NULL,
	[STR_PROP_1] [nvarchar](512) NULL,
	[STR_PROP_2] [nvarchar](512) NULL,
	[STR_PROP_3] [nvarchar](512) NULL,
	[INT_PROP_1] [int] NULL,
	[INT_PROP_2] [int] NULL,
	[LONG_PROP_1] [bigint] NULL,
	[LONG_PROP_2] [bigint] NULL,
	[DEC_PROP_1] [numeric](13, 4) NULL,
	[DEC_PROP_2] [numeric](13, 4) NULL,
	[BOOL_PROP_1] [bit] NULL,
	[BOOL_PROP_2] [bit] NULL,
 CONSTRAINT [PK_QRTZ_SIMPROP_TRIGGERS] PRIMARY KEY CLUSTERED 
(
	[SCHED_NAME] ASC,
	[TRIGGER_NAME] ASC,
	[TRIGGER_GROUP] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[QRTZ_SIMPLE_TRIGGERS]    Script Date: 03/03/2015 20:04:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[QRTZ_SIMPLE_TRIGGERS](
	[SCHED_NAME] [nvarchar](100) NOT NULL,
	[TRIGGER_NAME] [nvarchar](150) NOT NULL,
	[TRIGGER_GROUP] [nvarchar](150) NOT NULL,
	[REPEAT_COUNT] [int] NOT NULL,
	[REPEAT_INTERVAL] [bigint] NOT NULL,
	[TIMES_TRIGGERED] [int] NOT NULL,
 CONSTRAINT [PK_QRTZ_SIMPLE_TRIGGERS] PRIMARY KEY CLUSTERED 
(
	[SCHED_NAME] ASC,
	[TRIGGER_NAME] ASC,
	[TRIGGER_GROUP] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[QRTZ_CRON_TRIGGERS]    Script Date: 03/03/2015 20:04:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[QRTZ_CRON_TRIGGERS](
	[SCHED_NAME] [nvarchar](100) NOT NULL,
	[TRIGGER_NAME] [nvarchar](150) NOT NULL,
	[TRIGGER_GROUP] [nvarchar](150) NOT NULL,
	[CRON_EXPRESSION] [nvarchar](120) NOT NULL,
	[TIME_ZONE_ID] [nvarchar](80) NULL,
 CONSTRAINT [PK_QRTZ_CRON_TRIGGERS] PRIMARY KEY CLUSTERED 
(
	[SCHED_NAME] ASC,
	[TRIGGER_NAME] ASC,
	[TRIGGER_GROUP] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  ForeignKey [FK_QRTZ_TRIGGERS_QRTZ_JOB_DETAILS]    Script Date: 03/03/2015 20:04:32 ******/
ALTER TABLE [dbo].[QRTZ_TRIGGERS]  WITH CHECK ADD  CONSTRAINT [FK_QRTZ_TRIGGERS_QRTZ_JOB_DETAILS] FOREIGN KEY([SCHED_NAME], [JOB_NAME], [JOB_GROUP])
REFERENCES [dbo].[QRTZ_JOB_DETAILS] ([SCHED_NAME], [JOB_NAME], [JOB_GROUP])
GO
ALTER TABLE [dbo].[QRTZ_TRIGGERS] CHECK CONSTRAINT [FK_QRTZ_TRIGGERS_QRTZ_JOB_DETAILS]
GO
/****** Object:  ForeignKey [FK_QRTZ_SIMPROP_TRIGGERS_QRTZ_TRIGGERS]    Script Date: 03/03/2015 20:04:32 ******/
ALTER TABLE [dbo].[QRTZ_SIMPROP_TRIGGERS]  WITH CHECK ADD  CONSTRAINT [FK_QRTZ_SIMPROP_TRIGGERS_QRTZ_TRIGGERS] FOREIGN KEY([SCHED_NAME], [TRIGGER_NAME], [TRIGGER_GROUP])
REFERENCES [dbo].[QRTZ_TRIGGERS] ([SCHED_NAME], [TRIGGER_NAME], [TRIGGER_GROUP])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[QRTZ_SIMPROP_TRIGGERS] CHECK CONSTRAINT [FK_QRTZ_SIMPROP_TRIGGERS_QRTZ_TRIGGERS]
GO
/****** Object:  ForeignKey [FK_QRTZ_SIMPLE_TRIGGERS_QRTZ_TRIGGERS]    Script Date: 03/03/2015 20:04:32 ******/
ALTER TABLE [dbo].[QRTZ_SIMPLE_TRIGGERS]  WITH CHECK ADD  CONSTRAINT [FK_QRTZ_SIMPLE_TRIGGERS_QRTZ_TRIGGERS] FOREIGN KEY([SCHED_NAME], [TRIGGER_NAME], [TRIGGER_GROUP])
REFERENCES [dbo].[QRTZ_TRIGGERS] ([SCHED_NAME], [TRIGGER_NAME], [TRIGGER_GROUP])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[QRTZ_SIMPLE_TRIGGERS] CHECK CONSTRAINT [FK_QRTZ_SIMPLE_TRIGGERS_QRTZ_TRIGGERS]
GO
/****** Object:  ForeignKey [FK_QRTZ_CRON_TRIGGERS_QRTZ_TRIGGERS]    Script Date: 03/03/2015 20:04:32 ******/
ALTER TABLE [dbo].[QRTZ_CRON_TRIGGERS]  WITH CHECK ADD  CONSTRAINT [FK_QRTZ_CRON_TRIGGERS_QRTZ_TRIGGERS] FOREIGN KEY([SCHED_NAME], [TRIGGER_NAME], [TRIGGER_GROUP])
REFERENCES [dbo].[QRTZ_TRIGGERS] ([SCHED_NAME], [TRIGGER_NAME], [TRIGGER_GROUP])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[QRTZ_CRON_TRIGGERS] CHECK CONSTRAINT [FK_QRTZ_CRON_TRIGGERS_QRTZ_TRIGGERS]
GO
