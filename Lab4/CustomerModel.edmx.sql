
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 11/15/2022 22:39:15
-- Generated from EDMX file: C:\Users\User\Desktop\Fall 2022\Programming 3 - COMP 212 - 402\301201477(Gjini)_Lab#4\Lab4\Lab4\CustomerModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [Customers];
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

-- Creating table 'Customers'
CREATE TABLE [dbo].[Customers] (
    [CustomerId] int IDENTITY(1,1) NOT NULL,
    [NameStyle] nvarchar(max)  NOT NULL,
    [Title] nvarchar(max)  NOT NULL,
    [FirstName] nvarchar(max)  NOT NULL,
    [MiddleName] nvarchar(max)  NULL,
    [LastName] nvarchar(max)  NOT NULL,
    [CompanyName] nvarchar(max)  NOT NULL,
    [SalesPerson] nvarchar(max)  NOT NULL,
    [EmailAddress] nvarchar(max)  NOT NULL,
    [Phone] nvarchar(max)  NOT NULL,
    [Password] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'CustomerAddresses'
CREATE TABLE [dbo].[CustomerAddresses] (
    [AddressType] nvarchar(max)  NOT NULL,
    [ModifiedDate] datetime  NOT NULL,
    [CustomerId] int  NOT NULL,
    [AddressId] int  NOT NULL
);
GO

-- Creating table 'Addresses'
CREATE TABLE [dbo].[Addresses] (
    [AddressId] int IDENTITY(1,1) NOT NULL,
    [AddressLine1] nvarchar(max)  NOT NULL,
    [AddressLine2] nvarchar(max)  NOT NULL,
    [City] nvarchar(max)  NOT NULL,
    [StateProvince] nvarchar(max)  NOT NULL,
    [CountryRegion] nvarchar(max)  NOT NULL,
    [PostalCode] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'UserLogins'
CREATE TABLE [dbo].[UserLogins] (
    [EmployeeId] int IDENTITY(1,1) NOT NULL,
    [FirstName] nvarchar(max)  NOT NULL,
    [LastName] nvarchar(max)  NOT NULL,
    [Department] nvarchar(max)  NOT NULL,
    [PhoneNumber] nvarchar(max)  NOT NULL,
    [UserName] nvarchar(max)  NOT NULL,
    [Password] nvarchar(max)  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [CustomerId] in table 'Customers'
ALTER TABLE [dbo].[Customers]
ADD CONSTRAINT [PK_Customers]
    PRIMARY KEY CLUSTERED ([CustomerId] ASC);
GO

-- Creating primary key on [AddressId], [CustomerId] in table 'CustomerAddresses'
ALTER TABLE [dbo].[CustomerAddresses]
ADD CONSTRAINT [PK_CustomerAddresses]
    PRIMARY KEY CLUSTERED ([AddressId], [CustomerId] ASC);
GO

-- Creating primary key on [AddressId] in table 'Addresses'
ALTER TABLE [dbo].[Addresses]
ADD CONSTRAINT [PK_Addresses]
    PRIMARY KEY CLUSTERED ([AddressId] ASC);
GO

-- Creating primary key on [EmployeeId] in table 'UserLogins'
ALTER TABLE [dbo].[UserLogins]
ADD CONSTRAINT [PK_UserLogins]
    PRIMARY KEY CLUSTERED ([EmployeeId] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [CustomerId] in table 'CustomerAddresses'
ALTER TABLE [dbo].[CustomerAddresses]
ADD CONSTRAINT [FK_CustomerCustomerAddress]
    FOREIGN KEY ([CustomerId])
    REFERENCES [dbo].[Customers]
        ([CustomerId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CustomerCustomerAddress'
CREATE INDEX [IX_FK_CustomerCustomerAddress]
ON [dbo].[CustomerAddresses]
    ([CustomerId]);
GO

-- Creating foreign key on [AddressId] in table 'CustomerAddresses'
ALTER TABLE [dbo].[CustomerAddresses]
ADD CONSTRAINT [FK_AddressCustomerAddress]
    FOREIGN KEY ([AddressId])
    REFERENCES [dbo].[Addresses]
        ([AddressId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------