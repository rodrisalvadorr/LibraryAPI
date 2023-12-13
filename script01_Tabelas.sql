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

CREATE TABLE [TB_SERIES] (
    [Id] int NOT NULL IDENTITY,
    [Titulo] nvarchar(max) NOT NULL,
    [Autor] nvarchar(max) NOT NULL,
    [Foto] varbinary(max) NULL,
    [NroVolumes] int NOT NULL,
    CONSTRAINT [PK_TB_SERIES] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [TB_LIVROS] (
    [Id] int NOT NULL IDENTITY,
    [Titulo] nvarchar(max) NOT NULL,
    [Capa] nvarchar(max) NOT NULL,
    [Autor] nvarchar(max) NOT NULL,
    [Editora] nvarchar(max) NOT NULL,
    [Idioma] nvarchar(max) NOT NULL,
    [Categoria] nvarchar(max) NOT NULL,
    [SerieId] int NULL,
    [Status] nvarchar(max) NOT NULL,
    CONSTRAINT [PK_TB_LIVROS] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_TB_LIVROS_TB_SERIES_SerieId] FOREIGN KEY ([SerieId]) REFERENCES [TB_SERIES] ([Id])
);
GO

CREATE INDEX [IX_TB_LIVROS_SerieId] ON [TB_LIVROS] ([SerieId]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20231212140841_Tabelas', N'7.0.0');
GO

COMMIT;
GO

