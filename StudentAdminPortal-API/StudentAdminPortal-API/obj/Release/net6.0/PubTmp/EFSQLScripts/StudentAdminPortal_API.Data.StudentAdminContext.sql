IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230611163617_initial')
BEGIN
    CREATE TABLE [Gender] (
        [Id] uniqueidentifier NOT NULL,
        [Description] nvarchar(max) NULL,
        CONSTRAINT [PK_Gender] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230611163617_initial')
BEGIN
    CREATE TABLE [Student] (
        [Id] uniqueidentifier NOT NULL,
        [firstname] nvarchar(max) NOT NULL,
        [lastname] nvarchar(max) NULL,
        [DOB] datetime2 NOT NULL,
        [Email] nvarchar(max) NULL,
        [Mobile] bigint NULL,
        [ProfileImgUrl] nvarchar(max) NULL,
        [GenderID] uniqueidentifier NOT NULL,
        CONSTRAINT [PK_Student] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_Student_Gender_GenderID] FOREIGN KEY ([GenderID]) REFERENCES [Gender] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230611163617_initial')
BEGIN
    CREATE TABLE [Address] (
        [Id] uniqueidentifier NOT NULL,
        [PhysicalAddress] nvarchar(max) NULL,
        [PostalAddress] nvarchar(max) NULL,
        [StudentID] uniqueidentifier NOT NULL,
        CONSTRAINT [PK_Address] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_Address_Student_StudentID] FOREIGN KEY ([StudentID]) REFERENCES [Student] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230611163617_initial')
BEGIN
    CREATE UNIQUE INDEX [IX_Address_StudentID] ON [Address] ([StudentID]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230611163617_initial')
BEGIN
    CREATE INDEX [IX_Student_GenderID] ON [Student] ([GenderID]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230611163617_initial')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20230611163617_initial', N'7.0.5');
END;
GO

COMMIT;
GO

