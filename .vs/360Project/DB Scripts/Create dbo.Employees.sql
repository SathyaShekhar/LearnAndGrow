USE [ERA]
GO

/****** Object: Table [dbo].[Employees] Script Date: 8/23/2021 8:44:56 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Employees] (
    [EmployeeID]   INT            IDENTITY (1, 1) NOT NULL,
    [EmployeeName] NVARCHAR (250) NULL,
    [Email]        NVARCHAR (250) NULL,
    [LocationID]   INT            NULL,
    [RoleID]       INT            NULL,
    [RewardPoints] INT            NULL,
    [IsActive]     BIT            NULL
);


