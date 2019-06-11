
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 06/11/2019 11:29:14
-- Generated from EDMX file: C:\Projects\BMS\BMS.DA\BMSModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [BMS];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_BestellingBestellingPrutuct]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[BestellingProtucten] DROP CONSTRAINT [FK_BestellingBestellingPrutuct];
GO
IF OBJECT_ID(N'[dbo].[FK_BierTypeBier]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Producten_Bier] DROP CONSTRAINT [FK_BierTypeBier];
GO
IF OBJECT_ID(N'[dbo].[FK_BierGistingBier]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Producten_Bier] DROP CONSTRAINT [FK_BierGistingBier];
GO
IF OBJECT_ID(N'[dbo].[FK_BrouwerijBier]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Producten_Bier] DROP CONSTRAINT [FK_BrouwerijBier];
GO
IF OBJECT_ID(N'[dbo].[FK_ProductBierkroeg_Product]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ProductBierkroeg] DROP CONSTRAINT [FK_ProductBierkroeg_Product];
GO
IF OBJECT_ID(N'[dbo].[FK_ProductBierkroeg_Bierkroeg]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ProductBierkroeg] DROP CONSTRAINT [FK_ProductBierkroeg_Bierkroeg];
GO
IF OBJECT_ID(N'[dbo].[FK_BierkroegDag]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Dagen] DROP CONSTRAINT [FK_BierkroegDag];
GO
IF OBJECT_ID(N'[dbo].[FK_DagBestelling]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Bestellingen] DROP CONSTRAINT [FK_DagBestelling];
GO
IF OBJECT_ID(N'[dbo].[FK_ProductBestellingProtuct]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[BestellingProtucten] DROP CONSTRAINT [FK_ProductBestellingProtuct];
GO
IF OBJECT_ID(N'[dbo].[FK_ProductProductCategorie]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Producten] DROP CONSTRAINT [FK_ProductProductCategorie];
GO
IF OBJECT_ID(N'[dbo].[FK_BierkroegOpdiener]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Opdieneren] DROP CONSTRAINT [FK_BierkroegOpdiener];
GO
IF OBJECT_ID(N'[dbo].[FK_OpdienerBestelling]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Bestellingen] DROP CONSTRAINT [FK_OpdienerBestelling];
GO
IF OBJECT_ID(N'[dbo].[FK_Bier_inherits_Product]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Producten_Bier] DROP CONSTRAINT [FK_Bier_inherits_Product];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Bierkroegen]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Bierkroegen];
GO
IF OBJECT_ID(N'[dbo].[Dagen]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Dagen];
GO
IF OBJECT_ID(N'[dbo].[Opdieneren]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Opdieneren];
GO
IF OBJECT_ID(N'[dbo].[Bestellingen]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Bestellingen];
GO
IF OBJECT_ID(N'[dbo].[BestellingProtucten]', 'U') IS NOT NULL
    DROP TABLE [dbo].[BestellingProtucten];
GO
IF OBJECT_ID(N'[dbo].[ProductCategorieen]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ProductCategorieen];
GO
IF OBJECT_ID(N'[dbo].[BierTypes]', 'U') IS NOT NULL
    DROP TABLE [dbo].[BierTypes];
GO
IF OBJECT_ID(N'[dbo].[BierGistingen]', 'U') IS NOT NULL
    DROP TABLE [dbo].[BierGistingen];
GO
IF OBJECT_ID(N'[dbo].[Brouwerijen]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Brouwerijen];
GO
IF OBJECT_ID(N'[dbo].[Producten]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Producten];
GO
IF OBJECT_ID(N'[dbo].[Producten_Bier]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Producten_Bier];
GO
IF OBJECT_ID(N'[dbo].[ProductBierkroeg]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ProductBierkroeg];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Bierkroegen'
CREATE TABLE [dbo].[Bierkroegen] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Naam] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Dagen'
CREATE TABLE [dbo].[Dagen] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Naam] nvarchar(max)  NOT NULL,
    [TS] nvarchar(max)  NULL,
    [BierkroegId] int  NOT NULL
);
GO

-- Creating table 'Opdieneren'
CREATE TABLE [dbo].[Opdieneren] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Naam] nvarchar(max)  NOT NULL,
    [TS] nvarchar(max)  NULL,
    [BierkroegId] int  NOT NULL
);
GO

-- Creating table 'Bestellingen'
CREATE TABLE [dbo].[Bestellingen] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Tafel] nvarchar(max)  NOT NULL,
    [Totaal] decimal(18,0)  NOT NULL,
    [IsBezorcht] bit  NOT NULL,
    [IsBezorchtTS] nvarchar(max)  NULL,
    [IsKlaarKeuken] bit  NOT NULL,
    [IsKlaarKeukenTS] nvarchar(max)  NULL,
    [IsPrinted] bit  NOT NULL,
    [TS] nvarchar(max)  NULL,
    [DagId] int  NOT NULL,
    [OpdienerId] int  NULL
);
GO

-- Creating table 'BestellingProtucten'
CREATE TABLE [dbo].[BestellingProtucten] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Aantal] smallint  NOT NULL,
    [Totaal] decimal(18,0)  NOT NULL,
    [BestellingId] int  NOT NULL,
    [ProductId] int  NOT NULL
);
GO

-- Creating table 'ProductCategorieen'
CREATE TABLE [dbo].[ProductCategorieen] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Naam] nvarchar(max)  NOT NULL,
    [Isbier] bit  NOT NULL
);
GO

-- Creating table 'BierTypes'
CREATE TABLE [dbo].[BierTypes] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Type] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'BierGistingen'
CREATE TABLE [dbo].[BierGistingen] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Gisting] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Brouwerijen'
CREATE TABLE [dbo].[Brouwerijen] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Naam] nvarchar(max)  NOT NULL,
    [Locatie] nvarchar(max)  NOT NULL,
    [Beschrijving] nvarchar(max)  NULL
);
GO

-- Creating table 'Producten'
CREATE TABLE [dbo].[Producten] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [ProductNaam] nvarchar(max)  NOT NULL,
    [Prijs] decimal(10,2)  NOT NULL,
    [Beschrijving] nvarchar(max)  NULL,
    [InVoorraad] bit  NOT NULL,
    [IMG] varbinary(max)  NULL,
    [ProductCategorieId] int  NOT NULL
);
GO

-- Creating table 'Producten_Bier'
CREATE TABLE [dbo].[Producten_Bier] (
    [Alcohol] decimal(10,2)  NOT NULL,
    [Inhoud] decimal(10,2)  NOT NULL,
    [Aantal] int  NOT NULL,
    [BierTypeId] int  NOT NULL,
    [BierGistingId] int  NOT NULL,
    [BrouwerijId] int  NOT NULL,
    [Id] int  NOT NULL
);
GO

-- Creating table 'ProductBierkroeg'
CREATE TABLE [dbo].[ProductBierkroeg] (
    [Producten_Id] int  NOT NULL,
    [Bierkroegen_Id] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'Bierkroegen'
ALTER TABLE [dbo].[Bierkroegen]
ADD CONSTRAINT [PK_Bierkroegen]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Dagen'
ALTER TABLE [dbo].[Dagen]
ADD CONSTRAINT [PK_Dagen]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Opdieneren'
ALTER TABLE [dbo].[Opdieneren]
ADD CONSTRAINT [PK_Opdieneren]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Bestellingen'
ALTER TABLE [dbo].[Bestellingen]
ADD CONSTRAINT [PK_Bestellingen]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'BestellingProtucten'
ALTER TABLE [dbo].[BestellingProtucten]
ADD CONSTRAINT [PK_BestellingProtucten]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'ProductCategorieen'
ALTER TABLE [dbo].[ProductCategorieen]
ADD CONSTRAINT [PK_ProductCategorieen]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'BierTypes'
ALTER TABLE [dbo].[BierTypes]
ADD CONSTRAINT [PK_BierTypes]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'BierGistingen'
ALTER TABLE [dbo].[BierGistingen]
ADD CONSTRAINT [PK_BierGistingen]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Brouwerijen'
ALTER TABLE [dbo].[Brouwerijen]
ADD CONSTRAINT [PK_Brouwerijen]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Producten'
ALTER TABLE [dbo].[Producten]
ADD CONSTRAINT [PK_Producten]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Producten_Bier'
ALTER TABLE [dbo].[Producten_Bier]
ADD CONSTRAINT [PK_Producten_Bier]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Producten_Id], [Bierkroegen_Id] in table 'ProductBierkroeg'
ALTER TABLE [dbo].[ProductBierkroeg]
ADD CONSTRAINT [PK_ProductBierkroeg]
    PRIMARY KEY CLUSTERED ([Producten_Id], [Bierkroegen_Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [BestellingId] in table 'BestellingProtucten'
ALTER TABLE [dbo].[BestellingProtucten]
ADD CONSTRAINT [FK_BestellingBestellingPrutuct]
    FOREIGN KEY ([BestellingId])
    REFERENCES [dbo].[Bestellingen]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_BestellingBestellingPrutuct'
CREATE INDEX [IX_FK_BestellingBestellingPrutuct]
ON [dbo].[BestellingProtucten]
    ([BestellingId]);
GO

-- Creating foreign key on [BierTypeId] in table 'Producten_Bier'
ALTER TABLE [dbo].[Producten_Bier]
ADD CONSTRAINT [FK_BierTypeBier]
    FOREIGN KEY ([BierTypeId])
    REFERENCES [dbo].[BierTypes]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_BierTypeBier'
CREATE INDEX [IX_FK_BierTypeBier]
ON [dbo].[Producten_Bier]
    ([BierTypeId]);
GO

-- Creating foreign key on [BierGistingId] in table 'Producten_Bier'
ALTER TABLE [dbo].[Producten_Bier]
ADD CONSTRAINT [FK_BierGistingBier]
    FOREIGN KEY ([BierGistingId])
    REFERENCES [dbo].[BierGistingen]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_BierGistingBier'
CREATE INDEX [IX_FK_BierGistingBier]
ON [dbo].[Producten_Bier]
    ([BierGistingId]);
GO

-- Creating foreign key on [BrouwerijId] in table 'Producten_Bier'
ALTER TABLE [dbo].[Producten_Bier]
ADD CONSTRAINT [FK_BrouwerijBier]
    FOREIGN KEY ([BrouwerijId])
    REFERENCES [dbo].[Brouwerijen]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_BrouwerijBier'
CREATE INDEX [IX_FK_BrouwerijBier]
ON [dbo].[Producten_Bier]
    ([BrouwerijId]);
GO

-- Creating foreign key on [Producten_Id] in table 'ProductBierkroeg'
ALTER TABLE [dbo].[ProductBierkroeg]
ADD CONSTRAINT [FK_ProductBierkroeg_Product]
    FOREIGN KEY ([Producten_Id])
    REFERENCES [dbo].[Producten]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Bierkroegen_Id] in table 'ProductBierkroeg'
ALTER TABLE [dbo].[ProductBierkroeg]
ADD CONSTRAINT [FK_ProductBierkroeg_Bierkroeg]
    FOREIGN KEY ([Bierkroegen_Id])
    REFERENCES [dbo].[Bierkroegen]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ProductBierkroeg_Bierkroeg'
CREATE INDEX [IX_FK_ProductBierkroeg_Bierkroeg]
ON [dbo].[ProductBierkroeg]
    ([Bierkroegen_Id]);
GO

-- Creating foreign key on [BierkroegId] in table 'Dagen'
ALTER TABLE [dbo].[Dagen]
ADD CONSTRAINT [FK_BierkroegDag]
    FOREIGN KEY ([BierkroegId])
    REFERENCES [dbo].[Bierkroegen]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_BierkroegDag'
CREATE INDEX [IX_FK_BierkroegDag]
ON [dbo].[Dagen]
    ([BierkroegId]);
GO

-- Creating foreign key on [DagId] in table 'Bestellingen'
ALTER TABLE [dbo].[Bestellingen]
ADD CONSTRAINT [FK_DagBestelling]
    FOREIGN KEY ([DagId])
    REFERENCES [dbo].[Dagen]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_DagBestelling'
CREATE INDEX [IX_FK_DagBestelling]
ON [dbo].[Bestellingen]
    ([DagId]);
GO

-- Creating foreign key on [ProductId] in table 'BestellingProtucten'
ALTER TABLE [dbo].[BestellingProtucten]
ADD CONSTRAINT [FK_ProductBestellingProtuct]
    FOREIGN KEY ([ProductId])
    REFERENCES [dbo].[Producten]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ProductBestellingProtuct'
CREATE INDEX [IX_FK_ProductBestellingProtuct]
ON [dbo].[BestellingProtucten]
    ([ProductId]);
GO

-- Creating foreign key on [ProductCategorieId] in table 'Producten'
ALTER TABLE [dbo].[Producten]
ADD CONSTRAINT [FK_ProductProductCategorie]
    FOREIGN KEY ([ProductCategorieId])
    REFERENCES [dbo].[ProductCategorieen]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ProductProductCategorie'
CREATE INDEX [IX_FK_ProductProductCategorie]
ON [dbo].[Producten]
    ([ProductCategorieId]);
GO

-- Creating foreign key on [BierkroegId] in table 'Opdieneren'
ALTER TABLE [dbo].[Opdieneren]
ADD CONSTRAINT [FK_BierkroegOpdiener]
    FOREIGN KEY ([BierkroegId])
    REFERENCES [dbo].[Bierkroegen]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_BierkroegOpdiener'
CREATE INDEX [IX_FK_BierkroegOpdiener]
ON [dbo].[Opdieneren]
    ([BierkroegId]);
GO

-- Creating foreign key on [OpdienerId] in table 'Bestellingen'
ALTER TABLE [dbo].[Bestellingen]
ADD CONSTRAINT [FK_OpdienerBestelling]
    FOREIGN KEY ([OpdienerId])
    REFERENCES [dbo].[Opdieneren]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_OpdienerBestelling'
CREATE INDEX [IX_FK_OpdienerBestelling]
ON [dbo].[Bestellingen]
    ([OpdienerId]);
GO

-- Creating foreign key on [Id] in table 'Producten_Bier'
ALTER TABLE [dbo].[Producten_Bier]
ADD CONSTRAINT [FK_Bier_inherits_Product]
    FOREIGN KEY ([Id])
    REFERENCES [dbo].[Producten]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------