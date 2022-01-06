
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 12/28/2021 02:36:31
-- Generated from EDMX file: G:\Kusach\KusachVER2\Kusach\EDM.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [gr692_gav];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK__DriversLi__IdDri__0C85DE4D]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[DriversList] DROP CONSTRAINT [FK__DriversLi__IdDri__0C85DE4D];
GO
IF OBJECT_ID(N'[dbo].[FK__DriversLi__IdRou__68487DD7]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[DriversList] DROP CONSTRAINT [FK__DriversLi__IdRou__68487DD7];
GO
IF OBJECT_ID(N'[dbo].[FK__PointsLis__IdPoi__6477ECF3]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PointsList] DROP CONSTRAINT [FK__PointsLis__IdPoi__6477ECF3];
GO
IF OBJECT_ID(N'[dbo].[FK__PointsLis__IdRou__66603565]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PointsList] DROP CONSTRAINT [FK__PointsLis__IdRou__66603565];
GO
IF OBJECT_ID(N'[dbo].[FK__RouteList__IdRou__628FA481]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[RouteList] DROP CONSTRAINT [FK__RouteList__IdRou__628FA481];
GO
IF OBJECT_ID(N'[dbo].[FK__RouteList__IdRou__6383C8BA]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[RouteList] DROP CONSTRAINT [FK__RouteList__IdRou__6383C8BA];
GO
IF OBJECT_ID(N'[dbo].[FK_Drivers_Transport]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Drivers] DROP CONSTRAINT [FK_Drivers_Transport];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Dispatcher]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Dispatcher];
GO
IF OBJECT_ID(N'[dbo].[Drivers]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Drivers];
GO
IF OBJECT_ID(N'[dbo].[DriversList]', 'U') IS NOT NULL
    DROP TABLE [dbo].[DriversList];
GO
IF OBJECT_ID(N'[dbo].[Points]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Points];
GO
IF OBJECT_ID(N'[dbo].[PointsList]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PointsList];
GO
IF OBJECT_ID(N'[dbo].[RouteList]', 'U') IS NOT NULL
    DROP TABLE [dbo].[RouteList];
GO
IF OBJECT_ID(N'[dbo].[Routes]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Routes];
GO
IF OBJECT_ID(N'[dbo].[Transport]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Transport];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Dispatcher'
CREATE TABLE [dbo].[Dispatcher] (
    [IdDispatcher] int  NOT NULL,
    [Login] nvarchar(50)  NOT NULL,
    [Password] nvarchar(50)  NOT NULL
);
GO

-- Creating table 'Drivers'
CREATE TABLE [dbo].[Drivers] (
    [IdDriver] int  NOT NULL,
    [IdTransport] int  NOT NULL,
    [Surname] nvarchar(50)  NOT NULL,
    [Name] nvarchar(50)  NOT NULL,
    [Patronymic] nvarchar(50)  NOT NULL
);
GO

-- Creating table 'DriversList'
CREATE TABLE [dbo].[DriversList] (
    [Id] int  NOT NULL,
    [IdDriver] int  NOT NULL,
    [IdRoute] int  NOT NULL
);
GO

-- Creating table 'Points'
CREATE TABLE [dbo].[Points] (
    [IdPoint] int  NOT NULL,
    [Name] nvarchar(50)  NOT NULL,
    [location] nvarchar(150)  NOT NULL
);
GO

-- Creating table 'PointsList'
CREATE TABLE [dbo].[PointsList] (
    [Id] int  NOT NULL,
    [IdPoint] int  NOT NULL,
    [IdRoute] int  NOT NULL
);
GO

-- Creating table 'RouteList'
CREATE TABLE [dbo].[RouteList] (
    [Id] int  NOT NULL,
    [IdRoute] int  NOT NULL,
    [IdDispatcher] int  NOT NULL
);
GO

-- Creating table 'Routes'
CREATE TABLE [dbo].[Routes] (
    [IdRoute] int  NOT NULL,
    [IdDriver] int  NOT NULL,
    [Name] nvarchar(50)  NOT NULL
);
GO

-- Creating table 'Transport'
CREATE TABLE [dbo].[Transport] (
    [IdTransport] int  NOT NULL,
    [NameOfTransport] nvarchar(50)  NOT NULL,
    [NumberPlate] nvarchar(10)  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [IdDispatcher] in table 'Dispatcher'
ALTER TABLE [dbo].[Dispatcher]
ADD CONSTRAINT [PK_Dispatcher]
    PRIMARY KEY CLUSTERED ([IdDispatcher] ASC);
GO

-- Creating primary key on [IdDriver] in table 'Drivers'
ALTER TABLE [dbo].[Drivers]
ADD CONSTRAINT [PK_Drivers]
    PRIMARY KEY CLUSTERED ([IdDriver] ASC);
GO

-- Creating primary key on [Id] in table 'DriversList'
ALTER TABLE [dbo].[DriversList]
ADD CONSTRAINT [PK_DriversList]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [IdPoint] in table 'Points'
ALTER TABLE [dbo].[Points]
ADD CONSTRAINT [PK_Points]
    PRIMARY KEY CLUSTERED ([IdPoint] ASC);
GO

-- Creating primary key on [Id] in table 'PointsList'
ALTER TABLE [dbo].[PointsList]
ADD CONSTRAINT [PK_PointsList]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'RouteList'
ALTER TABLE [dbo].[RouteList]
ADD CONSTRAINT [PK_RouteList]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [IdRoute] in table 'Routes'
ALTER TABLE [dbo].[Routes]
ADD CONSTRAINT [PK_Routes]
    PRIMARY KEY CLUSTERED ([IdRoute] ASC);
GO

-- Creating primary key on [IdTransport] in table 'Transport'
ALTER TABLE [dbo].[Transport]
ADD CONSTRAINT [PK_Transport]
    PRIMARY KEY CLUSTERED ([IdTransport] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [IdRoute] in table 'RouteList'
ALTER TABLE [dbo].[RouteList]
ADD CONSTRAINT [FK__RouteList__IdRou__6383C8BA]
    FOREIGN KEY ([IdRoute])
    REFERENCES [dbo].[Dispatcher]
        ([IdDispatcher])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__RouteList__IdRou__6383C8BA'
CREATE INDEX [IX_FK__RouteList__IdRou__6383C8BA]
ON [dbo].[RouteList]
    ([IdRoute]);
GO

-- Creating foreign key on [IdDriver] in table 'DriversList'
ALTER TABLE [dbo].[DriversList]
ADD CONSTRAINT [FK__DriversLi__IdDri__0C85DE4D]
    FOREIGN KEY ([IdDriver])
    REFERENCES [dbo].[Drivers]
        ([IdDriver])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__DriversLi__IdDri__0C85DE4D'
CREATE INDEX [IX_FK__DriversLi__IdDri__0C85DE4D]
ON [dbo].[DriversList]
    ([IdDriver]);
GO

-- Creating foreign key on [IdTransport] in table 'Drivers'
ALTER TABLE [dbo].[Drivers]
ADD CONSTRAINT [FK_Drivers_Transport]
    FOREIGN KEY ([IdTransport])
    REFERENCES [dbo].[Transport]
        ([IdTransport])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Drivers_Transport'
CREATE INDEX [IX_FK_Drivers_Transport]
ON [dbo].[Drivers]
    ([IdTransport]);
GO

-- Creating foreign key on [IdRoute] in table 'DriversList'
ALTER TABLE [dbo].[DriversList]
ADD CONSTRAINT [FK__DriversLi__IdRou__68487DD7]
    FOREIGN KEY ([IdRoute])
    REFERENCES [dbo].[Routes]
        ([IdRoute])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__DriversLi__IdRou__68487DD7'
CREATE INDEX [IX_FK__DriversLi__IdRou__68487DD7]
ON [dbo].[DriversList]
    ([IdRoute]);
GO

-- Creating foreign key on [IdPoint] in table 'PointsList'
ALTER TABLE [dbo].[PointsList]
ADD CONSTRAINT [FK__PointsLis__IdPoi__6477ECF3]
    FOREIGN KEY ([IdPoint])
    REFERENCES [dbo].[Points]
        ([IdPoint])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__PointsLis__IdPoi__6477ECF3'
CREATE INDEX [IX_FK__PointsLis__IdPoi__6477ECF3]
ON [dbo].[PointsList]
    ([IdPoint]);
GO

-- Creating foreign key on [IdRoute] in table 'PointsList'
ALTER TABLE [dbo].[PointsList]
ADD CONSTRAINT [FK__PointsLis__IdRou__66603565]
    FOREIGN KEY ([IdRoute])
    REFERENCES [dbo].[Routes]
        ([IdRoute])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__PointsLis__IdRou__66603565'
CREATE INDEX [IX_FK__PointsLis__IdRou__66603565]
ON [dbo].[PointsList]
    ([IdRoute]);
GO

-- Creating foreign key on [IdRoute] in table 'RouteList'
ALTER TABLE [dbo].[RouteList]
ADD CONSTRAINT [FK__RouteList__IdRou__628FA481]
    FOREIGN KEY ([IdRoute])
    REFERENCES [dbo].[Routes]
        ([IdRoute])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__RouteList__IdRou__628FA481'
CREATE INDEX [IX_FK__RouteList__IdRou__628FA481]
ON [dbo].[RouteList]
    ([IdRoute]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------