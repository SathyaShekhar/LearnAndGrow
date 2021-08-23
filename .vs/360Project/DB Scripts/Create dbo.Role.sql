USE [ERA]
GO

/****** Object: Table [dbo].[Role] Script Date: 8/23/2021 8:49:08 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Role] (
    [RoleID]          INT            NOT NULL,
    [RoleDescription] NVARCHAR (100) NULL,
    [IsActive]        BIT            NULL
);


