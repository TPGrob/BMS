
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 06/02/2019 18:03:32
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


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------


-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Bierkroegen'
CREATE TABLE [dbo].[Bierkroegen] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Naam] nvarchar(max)  NOT NULL,
    [OpdienerId] int  NOT NULL
);
GO

-- Creating table 'Dagen'
CREATE TABLE [dbo].[Dagen] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Naam] nvarchar(max)  NOT NULL,
    [TS] datetime  NOT NULL,
    [BierkroegId] int  NOT NULL,
    [OpdienerId] int  NOT NULL
);
GO

-- Creating table 'Opdieners'
CREATE TABLE [dbo].[Opdieners] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Naam] nvarchar(max)  NOT NULL,
    [TS] datetime  NOT NULL
);
GO

-- Creating table 'Bestellings'
CREATE TABLE [dbo].[Bestellings] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Tafel] nvarchar(max)  NOT NULL,
    [Totaal] decimal(18,0)  NOT NULL,
    [IsBezorcht] bit  NOT NULL,
    [IsBezorchtTS] datetime  NOT NULL,
    [IsKlaarKeuken] bit  NOT NULL,
    [IsKlaarKeukenTS] datetime  NOT NULL,
    [IsPrinted] bit  NOT NULL,
    [OpdienerId] int  NOT NULL,
    [DagId] int  NOT NULL,
    [TS] datetime  NOT NULL
);
GO

-- Creating table 'BestellingProtucts'
CREATE TABLE [dbo].[BestellingProtucts] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Aantal] smallint  NOT NULL,
    [Totaal] nvarchar(max)  NOT NULL,
    [BestellingId] int  NOT NULL,
    [ProductId] int  NOT NULL
);
GO

-- Creating table 'ProductCategories'
CREATE TABLE [dbo].[ProductCategories] (
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

-- Creating table 'BierGistings'
CREATE TABLE [dbo].[BierGistings] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Gisting] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Brouwerijs'
CREATE TABLE [dbo].[Brouwerijs] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Naam] nvarchar(max)  NOT NULL,
    [Locatie] nvarchar(max)  NOT NULL,
    [Beschrijving] nvarchar(max)  NULL
);
GO

-- Creating table 'Products'
CREATE TABLE [dbo].[Products] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [ProductNaam] nvarchar(max)  NOT NULL,
    [Prijs] decimal(10,2)  NOT NULL,
    [Beschrijving] nvarchar(max)  NULL,
    [InVoorraad] bit  NOT NULL,
    [TS] int  NULL,
    [IMG] varbinary(max)  NULL,
    [ProductCategorieId] int  NOT NULL,
    [BestellingProtuctId] int  NOT NULL
);
GO

-- Creating table 'Products_Bier'
CREATE TABLE [dbo].[Products_Bier] (
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

-- Creating primary key on [Id] in table 'Opdieners'
ALTER TABLE [dbo].[Opdieners]
ADD CONSTRAINT [PK_Opdieners]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Bestellings'
ALTER TABLE [dbo].[Bestellings]
ADD CONSTRAINT [PK_Bestellings]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'BestellingProtucts'
ALTER TABLE [dbo].[BestellingProtucts]
ADD CONSTRAINT [PK_BestellingProtucts]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'ProductCategories'
ALTER TABLE [dbo].[ProductCategories]
ADD CONSTRAINT [PK_ProductCategories]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'BierTypes'
ALTER TABLE [dbo].[BierTypes]
ADD CONSTRAINT [PK_BierTypes]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'BierGistings'
ALTER TABLE [dbo].[BierGistings]
ADD CONSTRAINT [PK_BierGistings]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Brouwerijs'
ALTER TABLE [dbo].[Brouwerijs]
ADD CONSTRAINT [PK_Brouwerijs]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Products'
ALTER TABLE [dbo].[Products]
ADD CONSTRAINT [PK_Products]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Products_Bier'
ALTER TABLE [dbo].[Products_Bier]
ADD CONSTRAINT [PK_Products_Bier]
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

-- Creating foreign key on [OpdienerId] in table 'Dagen'
ALTER TABLE [dbo].[Dagen]
ADD CONSTRAINT [FK_OpdienerDag]
    FOREIGN KEY ([OpdienerId])
    REFERENCES [dbo].[Opdieners]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_OpdienerDag'
CREATE INDEX [IX_FK_OpdienerDag]
ON [dbo].[Dagen]
    ([OpdienerId]);
GO

-- Creating foreign key on [OpdienerId] in table 'Bestellings'
ALTER TABLE [dbo].[Bestellings]
ADD CONSTRAINT [FK_OpdienerBestelling]
    FOREIGN KEY ([OpdienerId])
    REFERENCES [dbo].[Opdieners]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_OpdienerBestelling'
CREATE INDEX [IX_FK_OpdienerBestelling]
ON [dbo].[Bestellings]
    ([OpdienerId]);
GO

-- Creating foreign key on [DagId] in table 'Bestellings'
ALTER TABLE [dbo].[Bestellings]
ADD CONSTRAINT [FK_DagBestelling]
    FOREIGN KEY ([DagId])
    REFERENCES [dbo].[Dagen]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_DagBestelling'
CREATE INDEX [IX_FK_DagBestelling]
ON [dbo].[Bestellings]
    ([DagId]);
GO

-- Creating foreign key on [BestellingId] in table 'BestellingProtucts'
ALTER TABLE [dbo].[BestellingProtucts]
ADD CONSTRAINT [FK_BestellingBestellingPrutuct]
    FOREIGN KEY ([BestellingId])
    REFERENCES [dbo].[Bestellings]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_BestellingBestellingPrutuct'
CREATE INDEX [IX_FK_BestellingBestellingPrutuct]
ON [dbo].[BestellingProtucts]
    ([BestellingId]);
GO

-- Creating foreign key on [BierTypeId] in table 'Products_Bier'
ALTER TABLE [dbo].[Products_Bier]
ADD CONSTRAINT [FK_BierTypeBier]
    FOREIGN KEY ([BierTypeId])
    REFERENCES [dbo].[BierTypes]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_BierTypeBier'
CREATE INDEX [IX_FK_BierTypeBier]
ON [dbo].[Products_Bier]
    ([BierTypeId]);
GO

-- Creating foreign key on [BierGistingId] in table 'Products_Bier'
ALTER TABLE [dbo].[Products_Bier]
ADD CONSTRAINT [FK_BierGistingBier]
    FOREIGN KEY ([BierGistingId])
    REFERENCES [dbo].[BierGistings]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_BierGistingBier'
CREATE INDEX [IX_FK_BierGistingBier]
ON [dbo].[Products_Bier]
    ([BierGistingId]);
GO

-- Creating foreign key on [BrouwerijId] in table 'Products_Bier'
ALTER TABLE [dbo].[Products_Bier]
ADD CONSTRAINT [FK_BrouwerijBier]
    FOREIGN KEY ([BrouwerijId])
    REFERENCES [dbo].[Brouwerijs]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_BrouwerijBier'
CREATE INDEX [IX_FK_BrouwerijBier]
ON [dbo].[Products_Bier]
    ([BrouwerijId]);
GO

-- Creating foreign key on [ProductCategorieId] in table 'Products'
ALTER TABLE [dbo].[Products]
ADD CONSTRAINT [FK_ProductCategorieProduct]
    FOREIGN KEY ([ProductCategorieId])
    REFERENCES [dbo].[ProductCategories]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ProductCategorieProduct'
CREATE INDEX [IX_FK_ProductCategorieProduct]
ON [dbo].[Products]
    ([ProductCategorieId]);
GO

-- Creating foreign key on [BestellingProtuctId] in table 'Products'
ALTER TABLE [dbo].[Products]
ADD CONSTRAINT [FK_BestellingPrutuctProduct]
    FOREIGN KEY ([BestellingProtuctId])
    REFERENCES [dbo].[BestellingProtucts]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_BestellingPrutuctProduct'
CREATE INDEX [IX_FK_BestellingPrutuctProduct]
ON [dbo].[Products]
    ([BestellingProtuctId]);
GO

-- Creating foreign key on [Producten_Id] in table 'ProductBierkroeg'
ALTER TABLE [dbo].[ProductBierkroeg]
ADD CONSTRAINT [FK_ProductBierkroeg_Product]
    FOREIGN KEY ([Producten_Id])
    REFERENCES [dbo].[Products]
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

-- Creating foreign key on [Id] in table 'Products_Bier'
ALTER TABLE [dbo].[Products_Bier]
ADD CONSTRAINT [FK_Bier_inherits_Product]
    FOREIGN KEY ([Id])
    REFERENCES [dbo].[Products]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------