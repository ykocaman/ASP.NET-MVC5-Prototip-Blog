
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 11/02/2016 00:43:40
-- Generated from EDMX file: C:\Users\yusuf\Documents\Visual Studio 2013\Projects\Blog\Data\db.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [db];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_UserPost]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PostSet] DROP CONSTRAINT [FK_UserPost];
GO
IF OBJECT_ID(N'[dbo].[FK_PostCategory]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PostSet] DROP CONSTRAINT [FK_PostCategory];
GO
IF OBJECT_ID(N'[dbo].[FK_PostComment]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CommentSet] DROP CONSTRAINT [FK_PostComment];
GO
IF OBJECT_ID(N'[dbo].[FK_CommentUser]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CommentSet] DROP CONSTRAINT [FK_CommentUser];
GO
IF OBJECT_ID(N'[dbo].[FK_UserLog]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[LogSet] DROP CONSTRAINT [FK_UserLog];
GO
IF OBJECT_ID(N'[dbo].[FK_UserPayment]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PaymentSet] DROP CONSTRAINT [FK_UserPayment];
GO
IF OBJECT_ID(N'[dbo].[FK_UserProject]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ProjectSet] DROP CONSTRAINT [FK_UserProject];
GO
IF OBJECT_ID(N'[dbo].[FK_UserUserType]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[UserSet] DROP CONSTRAINT [FK_UserUserType];
GO
IF OBJECT_ID(N'[dbo].[FK_ProjectProjectAccess]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ProjectAccessSet] DROP CONSTRAINT [FK_ProjectProjectAccess];
GO
IF OBJECT_ID(N'[dbo].[FK_UserProjectAccess]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ProjectAccessSet] DROP CONSTRAINT [FK_UserProjectAccess];
GO
IF OBJECT_ID(N'[dbo].[FK_ProjectAccessPayment]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PaymentSet] DROP CONSTRAINT [FK_ProjectAccessPayment];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[UserSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[UserSet];
GO
IF OBJECT_ID(N'[dbo].[PostSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PostSet];
GO
IF OBJECT_ID(N'[dbo].[CategorySet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CategorySet];
GO
IF OBJECT_ID(N'[dbo].[CommentSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CommentSet];
GO
IF OBJECT_ID(N'[dbo].[UserTypeSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[UserTypeSet];
GO
IF OBJECT_ID(N'[dbo].[PaymentSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PaymentSet];
GO
IF OBJECT_ID(N'[dbo].[LogSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[LogSet];
GO
IF OBJECT_ID(N'[dbo].[ProjectSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ProjectSet];
GO
IF OBJECT_ID(N'[dbo].[ProjectAccessSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ProjectAccessSet];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'UserSet'
CREATE TABLE [dbo].[UserSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [UserTypeId] int  NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Mail] nvarchar(max)  NOT NULL,
    [Password] nvarchar(max)  NOT NULL,
    [Avatar] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'PostSet'
CREATE TABLE [dbo].[PostSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [UserId] int  NOT NULL,
    [CategoryId] int  NOT NULL,
    [Title] nvarchar(max)  NOT NULL,
    [Text] nvarchar(max)  NOT NULL,
    [Date] datetime  NOT NULL
);
GO

-- Creating table 'CategorySet'
CREATE TABLE [dbo].[CategorySet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Title] nvarchar(max)  NOT NULL,
    [Slug] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'CommentSet'
CREATE TABLE [dbo].[CommentSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [PostId] int  NOT NULL,
    [UserId] int  NOT NULL,
    [Text] nvarchar(max)  NOT NULL,
    [Date] datetime  NOT NULL,
    [Verified] bit  NOT NULL
);
GO

-- Creating table 'UserTypeSet'
CREATE TABLE [dbo].[UserTypeSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Title] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'PaymentSet'
CREATE TABLE [dbo].[PaymentSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [UserId] int  NOT NULL,
    [Amount] decimal(18,0)  NOT NULL,
    [Date] datetime  NOT NULL,
    [ProjectAccess_Id] int  NOT NULL
);
GO

-- Creating table 'LogSet'
CREATE TABLE [dbo].[LogSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [UserId] int  NOT NULL,
    [Subject] nvarchar(max)  NOT NULL,
    [Detail] nvarchar(max)  NOT NULL,
    [Date] datetime  NOT NULL
);
GO

-- Creating table 'ProjectSet'
CREATE TABLE [dbo].[ProjectSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [UserId] int  NOT NULL,
    [Title] nvarchar(max)  NOT NULL,
    [Text] nvarchar(max)  NOT NULL,
    [Link] nvarchar(max)  NOT NULL,
    [Price] decimal(18,0)  NOT NULL
);
GO

-- Creating table 'ProjectAccessSet'
CREATE TABLE [dbo].[ProjectAccessSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [ProjectId] int  NOT NULL,
    [UserId] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'UserSet'
ALTER TABLE [dbo].[UserSet]
ADD CONSTRAINT [PK_UserSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'PostSet'
ALTER TABLE [dbo].[PostSet]
ADD CONSTRAINT [PK_PostSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'CategorySet'
ALTER TABLE [dbo].[CategorySet]
ADD CONSTRAINT [PK_CategorySet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'CommentSet'
ALTER TABLE [dbo].[CommentSet]
ADD CONSTRAINT [PK_CommentSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'UserTypeSet'
ALTER TABLE [dbo].[UserTypeSet]
ADD CONSTRAINT [PK_UserTypeSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'PaymentSet'
ALTER TABLE [dbo].[PaymentSet]
ADD CONSTRAINT [PK_PaymentSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'LogSet'
ALTER TABLE [dbo].[LogSet]
ADD CONSTRAINT [PK_LogSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'ProjectSet'
ALTER TABLE [dbo].[ProjectSet]
ADD CONSTRAINT [PK_ProjectSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'ProjectAccessSet'
ALTER TABLE [dbo].[ProjectAccessSet]
ADD CONSTRAINT [PK_ProjectAccessSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [UserId] in table 'PostSet'
ALTER TABLE [dbo].[PostSet]
ADD CONSTRAINT [FK_UserPost]
    FOREIGN KEY ([UserId])
    REFERENCES [dbo].[UserSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UserPost'
CREATE INDEX [IX_FK_UserPost]
ON [dbo].[PostSet]
    ([UserId]);
GO

-- Creating foreign key on [CategoryId] in table 'PostSet'
ALTER TABLE [dbo].[PostSet]
ADD CONSTRAINT [FK_PostCategory]
    FOREIGN KEY ([CategoryId])
    REFERENCES [dbo].[CategorySet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PostCategory'
CREATE INDEX [IX_FK_PostCategory]
ON [dbo].[PostSet]
    ([CategoryId]);
GO

-- Creating foreign key on [PostId] in table 'CommentSet'
ALTER TABLE [dbo].[CommentSet]
ADD CONSTRAINT [FK_PostComment]
    FOREIGN KEY ([PostId])
    REFERENCES [dbo].[PostSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PostComment'
CREATE INDEX [IX_FK_PostComment]
ON [dbo].[CommentSet]
    ([PostId]);
GO

-- Creating foreign key on [UserId] in table 'CommentSet'
ALTER TABLE [dbo].[CommentSet]
ADD CONSTRAINT [FK_CommentUser]
    FOREIGN KEY ([UserId])
    REFERENCES [dbo].[UserSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CommentUser'
CREATE INDEX [IX_FK_CommentUser]
ON [dbo].[CommentSet]
    ([UserId]);
GO

-- Creating foreign key on [UserId] in table 'LogSet'
ALTER TABLE [dbo].[LogSet]
ADD CONSTRAINT [FK_UserLog]
    FOREIGN KEY ([UserId])
    REFERENCES [dbo].[UserSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UserLog'
CREATE INDEX [IX_FK_UserLog]
ON [dbo].[LogSet]
    ([UserId]);
GO

-- Creating foreign key on [UserId] in table 'PaymentSet'
ALTER TABLE [dbo].[PaymentSet]
ADD CONSTRAINT [FK_UserPayment]
    FOREIGN KEY ([UserId])
    REFERENCES [dbo].[UserSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UserPayment'
CREATE INDEX [IX_FK_UserPayment]
ON [dbo].[PaymentSet]
    ([UserId]);
GO

-- Creating foreign key on [UserId] in table 'ProjectSet'
ALTER TABLE [dbo].[ProjectSet]
ADD CONSTRAINT [FK_UserProject]
    FOREIGN KEY ([UserId])
    REFERENCES [dbo].[UserSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UserProject'
CREATE INDEX [IX_FK_UserProject]
ON [dbo].[ProjectSet]
    ([UserId]);
GO

-- Creating foreign key on [UserTypeId] in table 'UserSet'
ALTER TABLE [dbo].[UserSet]
ADD CONSTRAINT [FK_UserUserType]
    FOREIGN KEY ([UserTypeId])
    REFERENCES [dbo].[UserTypeSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UserUserType'
CREATE INDEX [IX_FK_UserUserType]
ON [dbo].[UserSet]
    ([UserTypeId]);
GO

-- Creating foreign key on [ProjectId] in table 'ProjectAccessSet'
ALTER TABLE [dbo].[ProjectAccessSet]
ADD CONSTRAINT [FK_ProjectProjectAccess]
    FOREIGN KEY ([ProjectId])
    REFERENCES [dbo].[ProjectSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ProjectProjectAccess'
CREATE INDEX [IX_FK_ProjectProjectAccess]
ON [dbo].[ProjectAccessSet]
    ([ProjectId]);
GO

-- Creating foreign key on [UserId] in table 'ProjectAccessSet'
ALTER TABLE [dbo].[ProjectAccessSet]
ADD CONSTRAINT [FK_UserProjectAccess]
    FOREIGN KEY ([UserId])
    REFERENCES [dbo].[UserSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UserProjectAccess'
CREATE INDEX [IX_FK_UserProjectAccess]
ON [dbo].[ProjectAccessSet]
    ([UserId]);
GO

-- Creating foreign key on [ProjectAccess_Id] in table 'PaymentSet'
ALTER TABLE [dbo].[PaymentSet]
ADD CONSTRAINT [FK_ProjectAccessPayment]
    FOREIGN KEY ([ProjectAccess_Id])
    REFERENCES [dbo].[ProjectAccessSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ProjectAccessPayment'
CREATE INDEX [IX_FK_ProjectAccessPayment]
ON [dbo].[PaymentSet]
    ([ProjectAccess_Id]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------