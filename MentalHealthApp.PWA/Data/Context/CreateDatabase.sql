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

IF SCHEMA_ID(N'my4blocks') IS NULL EXEC(N'CREATE SCHEMA [my4blocks];');
GO

CREATE TABLE [my4blocks].[Videos] (
    [Id] int NOT NULL IDENTITY,
    [Step] int NOT NULL,
    [Title] nvarchar(255) NULL,
    [Body] nvarchar(max) NULL,
    [TextPrompt] nvarchar(1024) NULL,
    [VideoUrl] nvarchar(512) NOT NULL,
    [PdfUrl] nvarchar(512) NULL,
    [VideoName] nvarchar(255) NULL,
    [Category] int NOT NULL,
    [IsActive] bit NOT NULL,
    [CreatorId] nvarchar(512) NOT NULL,
    [CreatedDateTimeUTC] datetime2 NOT NULL DEFAULT '2023-11-09T13:40:03.4040255Z',
    [LastModifiedByUserId] nvarchar(max) NULL,
    [LastModifiedDateTimeUTC] datetime2 NULL,
    CONSTRAINT [PK_Videos] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [my4blocks].[EmotionLogs] (
    [Id] int NOT NULL IDENTITY,
    [Content] nvarchar(2048) NOT NULL,
    [UserId] nvarchar(512) NOT NULL,
    [CreatedDateTimeUTC] datetime2 NOT NULL DEFAULT '2023-11-09T13:40:03.4041810Z',
    [LastModifiedDateTimeUTC] datetime2 NULL,
    [VideoId] int NULL,
    CONSTRAINT [PK_EmotionLogs] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_EmotionLogs_Videos_VideoId] FOREIGN KEY ([VideoId]) REFERENCES [my4blocks].[Videos] ([Id])
);
GO

CREATE INDEX [IX_EmotionLogs_VideoId] ON [my4blocks].[EmotionLogs] ([VideoId]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20231109134004_MigrationAlpha', N'7.0.13');
GO

COMMIT;
GO

