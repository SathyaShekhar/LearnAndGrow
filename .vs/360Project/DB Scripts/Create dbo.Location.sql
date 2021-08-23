USE [ERA]
GO

/****** Object: Table [dbo].[Location] Script Date: 8/23/2021 8:48:11 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Location] (
    [LocationID]          INT            NOT NULL,
    [LocationDescription] NVARCHAR (100) NULL,
    [IsActive]            BIT            NULL
);


