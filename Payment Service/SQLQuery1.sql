create database Payment
go

use Payment
go

CREATE TABLE [dbo].[CardType](
	[CardTypeId]	[int] IDENTITY(1,1) NOT NULL,
	[Code]			[varchar](10) NULL,
	[Description]	[varchar](20) NULL

	PRIMARY KEY (CardTypeId)
)
go

CREATE TABLE [dbo].[Card](
	[CardId]		[int] IDENTITY(1,1) NOT NULL,
	[Number]		[varchar](16) NULL,
	[ExpireDate]	[datetime] NULL,
	[Cvv]			[varchar](4) NULL,
	[CardTypeId]	[int] NULL

	PRIMARY KEY (CardId)
)
go

CREATE TABLE [dbo].[Balance]
(
	[BalanceId] [int] IDENTITY(1,1) NOT NULL,
	[Balance]	[decimal](18, 6) NULL,
	[CardId]	[int] NULL

	PRIMARY KEY (BalanceId)
)
go

CREATE TABLE [dbo].[Transaction](
	[TransactionId]		[varchar](250) NOT NULL,
	[Date]				[datetime] NOT NULL,
	[Description]		[varchar](25) NULL,
	[Cost]				[decimal](18, 4) NULL,
	[InitialBalance]	[decimal](18, 4) NULL,
	[FinalBalance]		[decimal](18, 4) NULL,
	[CardId]			[int] NULL

	PRIMARY KEY (TransactionId)
)
go

INSERT [dbo].[CardType] ([Code], [Description]) VALUES (N'CREDIT', N'Credit Card')
INSERT [dbo].[CardType] ([Code], [Description]) VALUES (N'DEBIT', N'Debit Card')

INSERT [dbo].[Card] ([Number], [ExpireDate], [Cvv], [CardTypeId]) VALUES (N'1234567890123456', CAST(N'2022-10-01T00:00:00.000' AS DateTime), N'0441', 1)
INSERT [dbo].[Card] ([Number], [ExpireDate], [Cvv], [CardTypeId]) VALUES (N'9876543210987654', CAST(N'2023-11-01T00:00:00.000' AS DateTime), N'1012', 2)
INSERT [dbo].[Card] ([Number], [ExpireDate], [Cvv], [CardTypeId]) VALUES (N'0202021458785855', CAST(N'2023-10-01T00:00:00.000' AS DateTime), N'1012', 1)
INSERT [dbo].[Card] ([Number], [ExpireDate], [Cvv], [CardTypeId]) VALUES (N'7896541230852069', CAST(N'2018-10-01T00:00:00.000' AS DateTime), N'1414', 2)

INSERT [dbo].[Balance] ([Balance], [CardId]) VALUES (CAST(15000.000000 AS Decimal(18, 6)), 1)
INSERT [dbo].[Balance] ([Balance], [CardId]) VALUES (CAST(10000.000000 AS Decimal(18, 6)), 2)
INSERT [dbo].[Balance] ([Balance], [CardId]) VALUES (CAST(5000.000000 AS Decimal(18, 6)), 3)
INSERT [dbo].[Balance] ([Balance], [CardId]) VALUES (CAST(3500.000000 AS Decimal(18, 6)), 4)
