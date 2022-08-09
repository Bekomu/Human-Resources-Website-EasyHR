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

CREATE TABLE [AspNetRoles] (
    [Id] nvarchar(450) NOT NULL,
    [Name] nvarchar(256) NULL,
    [NormalizedName] nvarchar(256) NULL,
    [ConcurrencyStamp] nvarchar(max) NULL,
    CONSTRAINT [PK_AspNetRoles] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [Meslekler] (
    [Id] int NOT NULL IDENTITY,
    [MeslekAdi] nvarchar(100) NOT NULL,
    [MeslekKodu] nvarchar(7) NOT NULL,
    CONSTRAINT [PK_Meslekler] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [Sirketler] (
    [Id] int NOT NULL IDENTITY,
    [SirketAdi] nvarchar(max) NOT NULL,
    [TelefonNo] nvarchar(max) NOT NULL,
    [SirketInfo] nvarchar(140) NOT NULL,
    CONSTRAINT [PK_Sirketler] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [AspNetRoleClaims] (
    [Id] int NOT NULL IDENTITY,
    [RoleId] nvarchar(450) NOT NULL,
    [ClaimType] nvarchar(max) NULL,
    [ClaimValue] nvarchar(max) NULL,
    CONSTRAINT [PK_AspNetRoleClaims] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId] FOREIGN KEY ([RoleId]) REFERENCES [AspNetRoles] ([Id]) ON DELETE CASCADE
);
GO

CREATE TABLE [AspNetUsers] (
    [Id] nvarchar(450) NOT NULL,
    [Discriminator] nvarchar(max) NOT NULL,
    [Ad] nvarchar(25) NULL,
    [Soyad] nvarchar(25) NULL,
    [DogumTarihi] datetime2 NULL,
    [Adres] nvarchar(100) NULL,
    [Telefon] bigint NULL,
    [IseGirisTarihi] datetime2 NULL,
    [IstenCikisTarihi] datetime2 NULL,
    [TcNo] nvarchar(11) NULL,
    [FotografAdi] nvarchar(max) NULL,
    [Maas] decimal(18,2) NULL,
    [MinAvansHakki] decimal(18,2) NULL,
    [MaksAvansHakki] decimal(18,2) NULL,
    [Cinsiyet] int NULL,
    [Unvan] int NULL,
    [MedeniHali] int NULL,
    [KanGrubu] int NULL,
    [SirketId] int NULL,
    [MeslekId] int NULL,
    [YoneticiId] nvarchar(450) NULL,
    [UserName] nvarchar(256) NULL,
    [NormalizedUserName] nvarchar(256) NULL,
    [Email] nvarchar(256) NULL,
    [NormalizedEmail] nvarchar(256) NULL,
    [EmailConfirmed] bit NOT NULL,
    [PasswordHash] nvarchar(max) NULL,
    [SecurityStamp] nvarchar(max) NULL,
    [ConcurrencyStamp] nvarchar(max) NULL,
    [PhoneNumber] nvarchar(max) NULL,
    [PhoneNumberConfirmed] bit NOT NULL,
    [TwoFactorEnabled] bit NOT NULL,
    [LockoutEnd] datetimeoffset NULL,
    [LockoutEnabled] bit NOT NULL,
    [AccessFailedCount] int NOT NULL,
    CONSTRAINT [PK_AspNetUsers] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_AspNetUsers_AspNetUsers_YoneticiId] FOREIGN KEY ([YoneticiId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE NO ACTION,
    CONSTRAINT [FK_AspNetUsers_Meslekler_MeslekId] FOREIGN KEY ([MeslekId]) REFERENCES [Meslekler] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_AspNetUsers_Sirketler_SirketId] FOREIGN KEY ([SirketId]) REFERENCES [Sirketler] ([Id]) ON DELETE CASCADE
);
GO

CREATE TABLE [AspNetUserClaims] (
    [Id] int NOT NULL IDENTITY,
    [UserId] nvarchar(450) NOT NULL,
    [ClaimType] nvarchar(max) NULL,
    [ClaimValue] nvarchar(max) NULL,
    CONSTRAINT [PK_AspNetUserClaims] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE
);
GO

CREATE TABLE [AspNetUserLogins] (
    [LoginProvider] nvarchar(128) NOT NULL,
    [ProviderKey] nvarchar(128) NOT NULL,
    [ProviderDisplayName] nvarchar(max) NULL,
    [UserId] nvarchar(450) NOT NULL,
    CONSTRAINT [PK_AspNetUserLogins] PRIMARY KEY ([LoginProvider], [ProviderKey]),
    CONSTRAINT [FK_AspNetUserLogins_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE
);
GO

CREATE TABLE [AspNetUserRoles] (
    [UserId] nvarchar(450) NOT NULL,
    [RoleId] nvarchar(450) NOT NULL,
    CONSTRAINT [PK_AspNetUserRoles] PRIMARY KEY ([UserId], [RoleId]),
    CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId] FOREIGN KEY ([RoleId]) REFERENCES [AspNetRoles] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_AspNetUserRoles_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE
);
GO

CREATE TABLE [AspNetUserTokens] (
    [UserId] nvarchar(450) NOT NULL,
    [LoginProvider] nvarchar(128) NOT NULL,
    [Name] nvarchar(128) NOT NULL,
    [Value] nvarchar(max) NULL,
    CONSTRAINT [PK_AspNetUserTokens] PRIMARY KEY ([UserId], [LoginProvider], [Name]),
    CONSTRAINT [FK_AspNetUserTokens_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE
);
GO

CREATE TABLE [AvansTalepleri] (
    [Id] int NOT NULL IDENTITY,
    [AvansTutari] decimal(18,2) NOT NULL,
    [TalepTarihi] datetime2 NOT NULL,
    [AvansOnayDurumu] int NOT NULL,
    [Aciklama] nvarchar(140) NOT NULL,
    [SonuclanmaTarihi] datetime2 NULL,
    [PersonelId] nvarchar(450) NOT NULL,
    CONSTRAINT [PK_AvansTalepleri] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_AvansTalepleri_AspNetUsers_PersonelId] FOREIGN KEY ([PersonelId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE
);
GO

CREATE TABLE [HarcamaTalepleri] (
    [Id] int NOT NULL IDENTITY,
    [HarcamaTutari] decimal(18,2) NOT NULL,
    [Aciklama] nvarchar(140) NOT NULL,
    [DosyaAdi] nvarchar(max) NULL,
    [HarcamaOnayDurumu] int NOT NULL,
    [TalepTarihi] datetime2 NOT NULL,
    [SonuclanmaTarihi] datetime2 NULL,
    [PersonelId] nvarchar(450) NOT NULL,
    CONSTRAINT [PK_HarcamaTalepleri] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_HarcamaTalepleri_AspNetUsers_PersonelId] FOREIGN KEY ([PersonelId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE
);
GO

CREATE TABLE [IzinTalepleri] (
    [Id] int NOT NULL IDENTITY,
    [IzinTuru] int NOT NULL,
    [IzinBaslangicTarihi] datetime2 NOT NULL,
    [IzinBitisTarihi] datetime2 NOT NULL,
    [IzinGunSayisi] int NOT NULL,
    [TalepTarihi] datetime2 NOT NULL,
    [SonuclanmaTarihi] datetime2 NULL,
    [IzinOnayDurumu] int NOT NULL,
    [PersonelId] nvarchar(450) NOT NULL,
    CONSTRAINT [PK_IzinTalepleri] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_IzinTalepleri_AspNetUsers_PersonelId] FOREIGN KEY ([PersonelId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE
);
GO

CREATE INDEX [IX_AspNetRoleClaims_RoleId] ON [AspNetRoleClaims] ([RoleId]);
GO

CREATE UNIQUE INDEX [RoleNameIndex] ON [AspNetRoles] ([NormalizedName]) WHERE [NormalizedName] IS NOT NULL;
GO

CREATE INDEX [IX_AspNetUserClaims_UserId] ON [AspNetUserClaims] ([UserId]);
GO

CREATE INDEX [IX_AspNetUserLogins_UserId] ON [AspNetUserLogins] ([UserId]);
GO

CREATE INDEX [IX_AspNetUserRoles_RoleId] ON [AspNetUserRoles] ([RoleId]);
GO

CREATE INDEX [EmailIndex] ON [AspNetUsers] ([NormalizedEmail]);
GO

CREATE INDEX [IX_AspNetUsers_MeslekId] ON [AspNetUsers] ([MeslekId]);
GO

CREATE INDEX [IX_AspNetUsers_SirketId] ON [AspNetUsers] ([SirketId]);
GO

CREATE INDEX [IX_AspNetUsers_YoneticiId] ON [AspNetUsers] ([YoneticiId]);
GO

CREATE UNIQUE INDEX [UserNameIndex] ON [AspNetUsers] ([NormalizedUserName]) WHERE [NormalizedUserName] IS NOT NULL;
GO

CREATE INDEX [IX_AvansTalepleri_PersonelId] ON [AvansTalepleri] ([PersonelId]);
GO

CREATE INDEX [IX_HarcamaTalepleri_PersonelId] ON [HarcamaTalepleri] ([PersonelId]);
GO

CREATE INDEX [IX_IzinTalepleri_PersonelId] ON [IzinTalepleri] ([PersonelId]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20220617200044_InitialCreate', N'5.0.17');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

DECLARE @var0 sysname;
SELECT @var0 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Sirketler]') AND [c].[name] = N'TelefonNo');
IF @var0 IS NOT NULL EXEC(N'ALTER TABLE [Sirketler] DROP CONSTRAINT [' + @var0 + '];');
ALTER TABLE [Sirketler] ALTER COLUMN [TelefonNo] bigint NOT NULL;
GO

DECLARE @var1 sysname;
SELECT @var1 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Sirketler]') AND [c].[name] = N'SirketAdi');
IF @var1 IS NOT NULL EXEC(N'ALTER TABLE [Sirketler] DROP CONSTRAINT [' + @var1 + '];');
ALTER TABLE [Sirketler] ALTER COLUMN [SirketAdi] nvarchar(70) NOT NULL;
GO

ALTER TABLE [Sirketler] ADD [SirketKurulusTarihi] datetime2 NOT NULL DEFAULT '0001-01-01T00:00:00.0000000';
GO

ALTER TABLE [Sirketler] ADD [SirketUyeOlmaTarihi] datetime2 NOT NULL DEFAULT '0001-01-01T00:00:00.0000000';
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20220623211724_Second', N'5.0.17');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

ALTER TABLE [AspNetUsers] ADD [YillikIzinGunSayisi] int NULL;
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20220623220248_first', N'5.0.17');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

EXEC sp_rename N'[Sirketler].[TelefonNo]', N'SirketEmail', N'COLUMN';
GO

DECLARE @var2 sysname;
SELECT @var2 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Sirketler]') AND [c].[name] = N'SirketAdi');
IF @var2 IS NOT NULL EXEC(N'ALTER TABLE [Sirketler] DROP CONSTRAINT [' + @var2 + '];');
ALTER TABLE [Sirketler] ALTER COLUMN [SirketAdi] nvarchar(70) NOT NULL;
GO

ALTER TABLE [Sirketler] ADD [DosyaAdi] nvarchar(max) NOT NULL DEFAULT N'';
GO

ALTER TABLE [Sirketler] ADD [MersisNo] bigint NOT NULL DEFAULT CAST(0 AS bigint);
GO

ALTER TABLE [Sirketler] ADD [Sektor] int NOT NULL DEFAULT 0;
GO

ALTER TABLE [Sirketler] ADD [SirketAdres] nvarchar(100) NOT NULL DEFAULT N'';
GO

ALTER TABLE [Sirketler] ADD [SirketTelefonNo] bigint NOT NULL DEFAULT CAST(0 AS bigint);
GO

ALTER TABLE [Sirketler] ADD [SirketTuru] int NOT NULL DEFAULT 0;
GO

ALTER TABLE [Sirketler] ADD [SirketWebSitesi] nvarchar(253) NOT NULL DEFAULT N'';
GO

ALTER TABLE [Sirketler] ADD [VergiDairesi] nvarchar(100) NOT NULL DEFAULT N'';
GO

ALTER TABLE [Sirketler] ADD [VergiNo] bigint NOT NULL DEFAULT CAST(0 AS bigint);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20220630083352_Third', N'5.0.17');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

ALTER TABLE [Sirketler] ADD [PaketId] int NULL;
GO

CREATE TABLE [Cuzdanlar] (
    [Id] int NOT NULL IDENTITY,
    [ToplamBakiyeTRY] decimal(18,2) NOT NULL,
    [ToplamBakiyeUSD] decimal(18,2) NOT NULL,
    [ToplamBakiyeEUR] decimal(18,2) NOT NULL,
    [SirketId] int NOT NULL,
    CONSTRAINT [PK_Cuzdanlar] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Cuzdanlar_Sirketler_SirketId] FOREIGN KEY ([SirketId]) REFERENCES [Sirketler] ([Id]) ON DELETE CASCADE
);
GO

CREATE TABLE [Paketler] (
    [Id] int NOT NULL IDENTITY,
    [Ad] nvarchar(50) NOT NULL,
    [Tutar] decimal(18,2) NOT NULL,
    [ParaBirimi] nvarchar(max) NOT NULL,
    [KullaniciSayisi] int NOT NULL,
    [YayimlanmaBaslangic] datetime2 NOT NULL,
    [YayimlanmaBitis] datetime2 NOT NULL,
    [PaketSatistaMi] int NOT NULL,
    [OlusturulmaTarihi] datetime2 NOT NULL,
    [KullanilmaSuresi] datetime2 NOT NULL,
    [PaketFotografi] nvarchar(max) NOT NULL,
    CONSTRAINT [PK_Paketler] PRIMARY KEY ([Id])
);
GO

CREATE INDEX [IX_Sirketler_PaketId] ON [Sirketler] ([PaketId]);
GO

CREATE INDEX [IX_Cuzdanlar_SirketId] ON [Cuzdanlar] ([SirketId]);
GO

ALTER TABLE [Sirketler] ADD CONSTRAINT [FK_Sirketler_Paketler_PaketId] FOREIGN KEY ([PaketId]) REFERENCES [Paketler] ([Id]) ON DELETE NO ACTION;
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20220630123315_Fourth', N'5.0.17');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20220630203448_Fifth', N'5.0.17');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

DECLARE @var3 sysname;
SELECT @var3 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Sirketler]') AND [c].[name] = N'SirketEmail');
IF @var3 IS NOT NULL EXEC(N'ALTER TABLE [Sirketler] DROP CONSTRAINT [' + @var3 + '];');
ALTER TABLE [Sirketler] DROP COLUMN [SirketEmail];
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20220630210300_Sixth', N'5.0.17');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

ALTER TABLE [Sirketler] ADD [SirketEmail] nvarchar(max) NOT NULL DEFAULT N'';
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20220630210432_Seventh', N'5.0.17');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

ALTER TABLE [HarcamaTalepleri] ADD [HarcamaTuru] int NOT NULL DEFAULT 0;
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20220701172734_Eighth', N'5.0.17');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

DECLARE @var4 sysname;
SELECT @var4 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Paketler]') AND [c].[name] = N'KullanilmaSuresi');
IF @var4 IS NOT NULL EXEC(N'ALTER TABLE [Paketler] DROP CONSTRAINT [' + @var4 + '];');
ALTER TABLE [Paketler] DROP COLUMN [KullanilmaSuresi];
GO

EXEC sp_rename N'[Paketler].[YayimlanmaBitis]', N'YayimlanmaTarihi', N'COLUMN';
GO

EXEC sp_rename N'[Paketler].[YayimlanmaBaslangic]', N'YayimdanAlmaTarihi', N'COLUMN';
GO

EXEC sp_rename N'[Paketler].[PaketSatistaMi]', N'KullanimSuresiGun', N'COLUMN';
GO

EXEC sp_rename N'[Paketler].[PaketFotografi]', N'FotografAdi', N'COLUMN';
GO

ALTER TABLE [Paketler] ADD [SatistaMi] bit NOT NULL DEFAULT CAST(0 AS bit);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20220703203503_Ninth', N'5.0.17');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

DECLARE @var5 sysname;
SELECT @var5 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Paketler]') AND [c].[name] = N'ParaBirimi');
IF @var5 IS NOT NULL EXEC(N'ALTER TABLE [Paketler] DROP CONSTRAINT [' + @var5 + '];');
ALTER TABLE [Paketler] DROP COLUMN [ParaBirimi];
GO

ALTER TABLE [Paketler] ADD [ParaBirimiEnum] int NOT NULL DEFAULT 0;
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20220704115620_paket', N'5.0.17');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

CREATE TABLE [Bakiyeler] (
    [Id] int NOT NULL IDENTITY,
    [Tutar] decimal(18,2) NOT NULL,
    [ParaBirimi] int NOT NULL,
    [YukleyenAdSoyad] nvarchar(max) NOT NULL,
    [YukeleyenSirketAdi] nvarchar(max) NOT NULL,
    CONSTRAINT [PK_Bakiyeler] PRIMARY KEY ([Id])
);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20220704174654_10th', N'5.0.17');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

ALTER TABLE [AspNetUsers] ADD [IzinGuncellemeTarihi] datetime2 NULL;
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20220704214549_forBackgroundTasks', N'5.0.17');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

DECLARE @var6 sysname;
SELECT @var6 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[AspNetUsers]') AND [c].[name] = N'Discriminator');
IF @var6 IS NOT NULL EXEC(N'ALTER TABLE [AspNetUsers] DROP CONSTRAINT [' + @var6 + '];');
ALTER TABLE [AspNetUsers] DROP COLUMN [Discriminator];
GO

DECLARE @var7 sysname;
SELECT @var7 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[AspNetUsers]') AND [c].[name] = N'YillikIzinGunSayisi');
IF @var7 IS NOT NULL EXEC(N'ALTER TABLE [AspNetUsers] DROP CONSTRAINT [' + @var7 + '];');
ALTER TABLE [AspNetUsers] ALTER COLUMN [YillikIzinGunSayisi] int NOT NULL;
ALTER TABLE [AspNetUsers] ADD DEFAULT 0 FOR [YillikIzinGunSayisi];
GO

DECLARE @var8 sysname;
SELECT @var8 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[AspNetUsers]') AND [c].[name] = N'Unvan');
IF @var8 IS NOT NULL EXEC(N'ALTER TABLE [AspNetUsers] DROP CONSTRAINT [' + @var8 + '];');
ALTER TABLE [AspNetUsers] ALTER COLUMN [Unvan] int NOT NULL;
ALTER TABLE [AspNetUsers] ADD DEFAULT 0 FOR [Unvan];
GO

DECLARE @var9 sysname;
SELECT @var9 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[AspNetUsers]') AND [c].[name] = N'Telefon');
IF @var9 IS NOT NULL EXEC(N'ALTER TABLE [AspNetUsers] DROP CONSTRAINT [' + @var9 + '];');
ALTER TABLE [AspNetUsers] ALTER COLUMN [Telefon] bigint NOT NULL;
ALTER TABLE [AspNetUsers] ADD DEFAULT CAST(0 AS bigint) FOR [Telefon];
GO

DECLARE @var10 sysname;
SELECT @var10 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[AspNetUsers]') AND [c].[name] = N'TcNo');
IF @var10 IS NOT NULL EXEC(N'ALTER TABLE [AspNetUsers] DROP CONSTRAINT [' + @var10 + '];');
ALTER TABLE [AspNetUsers] ALTER COLUMN [TcNo] nvarchar(11) NOT NULL;
ALTER TABLE [AspNetUsers] ADD DEFAULT N'' FOR [TcNo];
GO

DECLARE @var11 sysname;
SELECT @var11 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[AspNetUsers]') AND [c].[name] = N'Soyad');
IF @var11 IS NOT NULL EXEC(N'ALTER TABLE [AspNetUsers] DROP CONSTRAINT [' + @var11 + '];');
ALTER TABLE [AspNetUsers] ALTER COLUMN [Soyad] nvarchar(25) NOT NULL;
ALTER TABLE [AspNetUsers] ADD DEFAULT N'' FOR [Soyad];
GO

DROP INDEX [IX_AspNetUsers_SirketId] ON [AspNetUsers];
DECLARE @var12 sysname;
SELECT @var12 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[AspNetUsers]') AND [c].[name] = N'SirketId');
IF @var12 IS NOT NULL EXEC(N'ALTER TABLE [AspNetUsers] DROP CONSTRAINT [' + @var12 + '];');
ALTER TABLE [AspNetUsers] ALTER COLUMN [SirketId] int NOT NULL;
ALTER TABLE [AspNetUsers] ADD DEFAULT 0 FOR [SirketId];
CREATE INDEX [IX_AspNetUsers_SirketId] ON [AspNetUsers] ([SirketId]);
GO

DECLARE @var13 sysname;
SELECT @var13 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[AspNetUsers]') AND [c].[name] = N'MinAvansHakki');
IF @var13 IS NOT NULL EXEC(N'ALTER TABLE [AspNetUsers] DROP CONSTRAINT [' + @var13 + '];');
ALTER TABLE [AspNetUsers] ALTER COLUMN [MinAvansHakki] decimal(18,2) NOT NULL;
ALTER TABLE [AspNetUsers] ADD DEFAULT 0.0 FOR [MinAvansHakki];
GO

DROP INDEX [IX_AspNetUsers_MeslekId] ON [AspNetUsers];
DECLARE @var14 sysname;
SELECT @var14 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[AspNetUsers]') AND [c].[name] = N'MeslekId');
IF @var14 IS NOT NULL EXEC(N'ALTER TABLE [AspNetUsers] DROP CONSTRAINT [' + @var14 + '];');
ALTER TABLE [AspNetUsers] ALTER COLUMN [MeslekId] int NOT NULL;
ALTER TABLE [AspNetUsers] ADD DEFAULT 0 FOR [MeslekId];
CREATE INDEX [IX_AspNetUsers_MeslekId] ON [AspNetUsers] ([MeslekId]);
GO

DECLARE @var15 sysname;
SELECT @var15 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[AspNetUsers]') AND [c].[name] = N'MedeniHali');
IF @var15 IS NOT NULL EXEC(N'ALTER TABLE [AspNetUsers] DROP CONSTRAINT [' + @var15 + '];');
ALTER TABLE [AspNetUsers] ALTER COLUMN [MedeniHali] int NOT NULL;
ALTER TABLE [AspNetUsers] ADD DEFAULT 0 FOR [MedeniHali];
GO

DECLARE @var16 sysname;
SELECT @var16 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[AspNetUsers]') AND [c].[name] = N'MaksAvansHakki');
IF @var16 IS NOT NULL EXEC(N'ALTER TABLE [AspNetUsers] DROP CONSTRAINT [' + @var16 + '];');
ALTER TABLE [AspNetUsers] ALTER COLUMN [MaksAvansHakki] decimal(18,2) NOT NULL;
ALTER TABLE [AspNetUsers] ADD DEFAULT 0.0 FOR [MaksAvansHakki];
GO

DECLARE @var17 sysname;
SELECT @var17 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[AspNetUsers]') AND [c].[name] = N'Maas');
IF @var17 IS NOT NULL EXEC(N'ALTER TABLE [AspNetUsers] DROP CONSTRAINT [' + @var17 + '];');
ALTER TABLE [AspNetUsers] ALTER COLUMN [Maas] decimal(18,2) NOT NULL;
ALTER TABLE [AspNetUsers] ADD DEFAULT 0.0 FOR [Maas];
GO

DECLARE @var18 sysname;
SELECT @var18 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[AspNetUsers]') AND [c].[name] = N'KanGrubu');
IF @var18 IS NOT NULL EXEC(N'ALTER TABLE [AspNetUsers] DROP CONSTRAINT [' + @var18 + '];');
ALTER TABLE [AspNetUsers] ALTER COLUMN [KanGrubu] int NOT NULL;
ALTER TABLE [AspNetUsers] ADD DEFAULT 0 FOR [KanGrubu];
GO

DECLARE @var19 sysname;
SELECT @var19 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[AspNetUsers]') AND [c].[name] = N'IseGirisTarihi');
IF @var19 IS NOT NULL EXEC(N'ALTER TABLE [AspNetUsers] DROP CONSTRAINT [' + @var19 + '];');
ALTER TABLE [AspNetUsers] ALTER COLUMN [IseGirisTarihi] datetime2 NOT NULL;
ALTER TABLE [AspNetUsers] ADD DEFAULT '0001-01-01T00:00:00.0000000' FOR [IseGirisTarihi];
GO

DECLARE @var20 sysname;
SELECT @var20 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[AspNetUsers]') AND [c].[name] = N'FotografAdi');
IF @var20 IS NOT NULL EXEC(N'ALTER TABLE [AspNetUsers] DROP CONSTRAINT [' + @var20 + '];');
ALTER TABLE [AspNetUsers] ALTER COLUMN [FotografAdi] nvarchar(max) NOT NULL;
ALTER TABLE [AspNetUsers] ADD DEFAULT N'' FOR [FotografAdi];
GO

DECLARE @var21 sysname;
SELECT @var21 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[AspNetUsers]') AND [c].[name] = N'Email');
IF @var21 IS NOT NULL EXEC(N'ALTER TABLE [AspNetUsers] DROP CONSTRAINT [' + @var21 + '];');
ALTER TABLE [AspNetUsers] ALTER COLUMN [Email] nvarchar(256) NOT NULL;
ALTER TABLE [AspNetUsers] ADD DEFAULT N'' FOR [Email];
GO

DECLARE @var22 sysname;
SELECT @var22 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[AspNetUsers]') AND [c].[name] = N'DogumTarihi');
IF @var22 IS NOT NULL EXEC(N'ALTER TABLE [AspNetUsers] DROP CONSTRAINT [' + @var22 + '];');
ALTER TABLE [AspNetUsers] ALTER COLUMN [DogumTarihi] datetime2 NOT NULL;
ALTER TABLE [AspNetUsers] ADD DEFAULT '0001-01-01T00:00:00.0000000' FOR [DogumTarihi];
GO

DECLARE @var23 sysname;
SELECT @var23 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[AspNetUsers]') AND [c].[name] = N'Cinsiyet');
IF @var23 IS NOT NULL EXEC(N'ALTER TABLE [AspNetUsers] DROP CONSTRAINT [' + @var23 + '];');
ALTER TABLE [AspNetUsers] ALTER COLUMN [Cinsiyet] int NOT NULL;
ALTER TABLE [AspNetUsers] ADD DEFAULT 0 FOR [Cinsiyet];
GO

DECLARE @var24 sysname;
SELECT @var24 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[AspNetUsers]') AND [c].[name] = N'Adres');
IF @var24 IS NOT NULL EXEC(N'ALTER TABLE [AspNetUsers] DROP CONSTRAINT [' + @var24 + '];');
ALTER TABLE [AspNetUsers] ALTER COLUMN [Adres] nvarchar(100) NOT NULL;
ALTER TABLE [AspNetUsers] ADD DEFAULT N'' FOR [Adres];
GO

DECLARE @var25 sysname;
SELECT @var25 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[AspNetUsers]') AND [c].[name] = N'Ad');
IF @var25 IS NOT NULL EXEC(N'ALTER TABLE [AspNetUsers] DROP CONSTRAINT [' + @var25 + '];');
ALTER TABLE [AspNetUsers] ALTER COLUMN [Ad] nvarchar(25) NOT NULL;
ALTER TABLE [AspNetUsers] ADD DEFAULT N'' FOR [Ad];
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20220705104351_genericli', N'5.0.17');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

DECLARE @var26 sysname;
SELECT @var26 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[AspNetUsers]') AND [c].[name] = N'IzinGuncellemeTarihi');
IF @var26 IS NOT NULL EXEC(N'ALTER TABLE [AspNetUsers] DROP CONSTRAINT [' + @var26 + '];');
ALTER TABLE [AspNetUsers] ALTER COLUMN [IzinGuncellemeTarihi] datetime2 NOT NULL;
ALTER TABLE [AspNetUsers] ADD DEFAULT '0001-01-01T00:00:00.0000000' FOR [IzinGuncellemeTarihi];
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20220705110908_ekleee', N'5.0.17');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

CREATE TABLE [Kart] (
    [Id] int NOT NULL IDENTITY,
    [SahipAdi] nvarchar(max) NOT NULL,
    [SahipSoyadi] nvarchar(max) NOT NULL,
    [SonKullanmaTarihi] nvarchar(max) NOT NULL,
    [CVC2] nvarchar(max) NOT NULL,
    [PersonelId] nvarchar(450) NULL,
    CONSTRAINT [PK_Kart] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Kart_AspNetUsers_PersonelId] FOREIGN KEY ([PersonelId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE NO ACTION
);
GO

CREATE INDEX [IX_Kart_PersonelId] ON [Kart] ([PersonelId]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20220705164838_personelKart', N'5.0.17');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

ALTER TABLE [Kart] DROP CONSTRAINT [FK_Kart_AspNetUsers_PersonelId];
GO

ALTER TABLE [Kart] DROP CONSTRAINT [PK_Kart];
GO

EXEC sp_rename N'[Kart]', N'Kartlar';
GO

EXEC sp_rename N'[Kartlar].[IX_Kart_PersonelId]', N'IX_Kartlar_PersonelId', N'INDEX';
GO

ALTER TABLE [Kartlar] ADD CONSTRAINT [PK_Kartlar] PRIMARY KEY ([Id]);
GO

ALTER TABLE [Kartlar] ADD CONSTRAINT [FK_Kartlar_AspNetUsers_PersonelId] FOREIGN KEY ([PersonelId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE NO ACTION;
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20220705165519_personelKartdbset', N'5.0.17');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

DECLARE @var27 sysname;
SELECT @var27 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Kartlar]') AND [c].[name] = N'SahipAdi');
IF @var27 IS NOT NULL EXEC(N'ALTER TABLE [Kartlar] DROP CONSTRAINT [' + @var27 + '];');
ALTER TABLE [Kartlar] DROP COLUMN [SahipAdi];
GO

EXEC sp_rename N'[Kartlar].[SahipSoyadi]', N'AdSoyad', N'COLUMN';
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20220705201710_adsoyadkart', N'5.0.17');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

ALTER TABLE [Kartlar] ADD [KartNumarasi] nvarchar(max) NULL;
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20220705205228_kartnumarasi', N'5.0.17');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

DECLARE @var28 sysname;
SELECT @var28 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Kartlar]') AND [c].[name] = N'AdSoyad');
IF @var28 IS NOT NULL EXEC(N'ALTER TABLE [Kartlar] DROP CONSTRAINT [' + @var28 + '];');
ALTER TABLE [Kartlar] ALTER COLUMN [AdSoyad] nvarchar(max) NULL;
GO

ALTER TABLE [Kartlar] ADD [KartIsmi] nvarchar(max) NULL;
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20220706072309_kartismi', N'5.0.17');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

DECLARE @var29 sysname;
SELECT @var29 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Kartlar]') AND [c].[name] = N'SonKullanmaTarihi');
IF @var29 IS NOT NULL EXEC(N'ALTER TABLE [Kartlar] DROP CONSTRAINT [' + @var29 + '];');
ALTER TABLE [Kartlar] DROP COLUMN [SonKullanmaTarihi];
GO

DECLARE @var30 sysname;
SELECT @var30 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Kartlar]') AND [c].[name] = N'CVC2');
IF @var30 IS NOT NULL EXEC(N'ALTER TABLE [Kartlar] DROP CONSTRAINT [' + @var30 + '];');
ALTER TABLE [Kartlar] ALTER COLUMN [CVC2] nvarchar(max) NULL;
GO

ALTER TABLE [Kartlar] ADD [Ay] int NOT NULL DEFAULT 0;
GO

ALTER TABLE [Kartlar] ADD [Yil] int NOT NULL DEFAULT 0;
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20220706080055_qweqweqweqweqwe', N'5.0.17');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

ALTER TABLE [Kartlar] ADD [Limit] decimal(18,2) NOT NULL DEFAULT 0.0;
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20220706081051_qweqweqweqweq12312', N'5.0.17');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

ALTER TABLE [Kartlar] DROP CONSTRAINT [FK_Kartlar_AspNetUsers_PersonelId];
GO

DROP INDEX [IX_Kartlar_PersonelId] ON [Kartlar];
GO

DECLARE @var31 sysname;
SELECT @var31 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Kartlar]') AND [c].[name] = N'PersonelId');
IF @var31 IS NOT NULL EXEC(N'ALTER TABLE [Kartlar] DROP CONSTRAINT [' + @var31 + '];');
ALTER TABLE [Kartlar] DROP COLUMN [PersonelId];
GO

ALTER TABLE [Kartlar] ADD [SirketId] int NULL;
GO

CREATE INDEX [IX_Kartlar_SirketId] ON [Kartlar] ([SirketId]);
GO

ALTER TABLE [Kartlar] ADD CONSTRAINT [FK_Kartlar_Sirketler_SirketId] FOREIGN KEY ([SirketId]) REFERENCES [Sirketler] ([Id]) ON DELETE NO ACTION;
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20220706185031_kartlarsirket', N'5.0.17');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

DECLARE @var32 sysname;
SELECT @var32 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Kartlar]') AND [c].[name] = N'Ay');
IF @var32 IS NOT NULL EXEC(N'ALTER TABLE [Kartlar] DROP CONSTRAINT [' + @var32 + '];');
ALTER TABLE [Kartlar] DROP COLUMN [Ay];
GO

DECLARE @var33 sysname;
SELECT @var33 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Kartlar]') AND [c].[name] = N'Yil');
IF @var33 IS NOT NULL EXEC(N'ALTER TABLE [Kartlar] DROP CONSTRAINT [' + @var33 + '];');
ALTER TABLE [Kartlar] DROP COLUMN [Yil];
GO

ALTER TABLE [Kartlar] ADD [SKT] nvarchar(max) NULL;
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20220706191900_stringSKT', N'5.0.17');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

DECLARE @var34 sysname;
SELECT @var34 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Cuzdanlar]') AND [c].[name] = N'ToplamBakiyeEUR');
IF @var34 IS NOT NULL EXEC(N'ALTER TABLE [Cuzdanlar] DROP CONSTRAINT [' + @var34 + '];');
ALTER TABLE [Cuzdanlar] DROP COLUMN [ToplamBakiyeEUR];
GO

DECLARE @var35 sysname;
SELECT @var35 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Cuzdanlar]') AND [c].[name] = N'ToplamBakiyeTRY');
IF @var35 IS NOT NULL EXEC(N'ALTER TABLE [Cuzdanlar] DROP CONSTRAINT [' + @var35 + '];');
ALTER TABLE [Cuzdanlar] DROP COLUMN [ToplamBakiyeTRY];
GO

EXEC sp_rename N'[Cuzdanlar].[ToplamBakiyeUSD]', N'ToplamBakiye', N'COLUMN';
GO

ALTER TABLE [Sirketler] ADD [CuzdanId] int NULL;
GO

CREATE INDEX [IX_Sirketler_CuzdanId] ON [Sirketler] ([CuzdanId]);
GO

ALTER TABLE [Sirketler] ADD CONSTRAINT [FK_Sirketler_Cuzdanlar_CuzdanId] FOREIGN KEY ([CuzdanId]) REFERENCES [Cuzdanlar] ([Id]) ON DELETE NO ACTION;
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20220706203603_cuzdanSirket', N'5.0.17');
GO

COMMIT;
GO

