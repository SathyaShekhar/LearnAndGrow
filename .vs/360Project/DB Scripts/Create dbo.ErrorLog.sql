USE [ERA]
GO

/****** Object: Table [dbo].[ErrorLog] Script Date: 8/23/2021 8:49:55 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[ErrorLog] (
    [ErrorID]        INT             IDENTITY (1, 1) NOT NULL,
    [MethodName]     NVARCHAR (250)  NULL,
    [ErrorMessage]   NVARCHAR (MAX)  NULL,
    [Source]         NVARCHAR (1000) NULL,
    [InnerException] NVARCHAR (MAX)  NULL,
    [StackTrace]     NVARCHAR (MAX)  NULL,
    [ErrorDateTime]  DATETIME        NULL
);


