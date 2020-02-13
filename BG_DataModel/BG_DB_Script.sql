USE [BG_DB]
GO
/****** Object:  UserDefinedTableType [dbo].[ExcelTbl]    Script Date: 2/13/2020 11:17:01 PM ******/
CREATE TYPE [dbo].[ExcelTbl] AS TABLE(
	[PId] [varchar](100) NOT NULL,
	PRIMARY KEY CLUSTERED 
(
	[PId] ASC
)WITH (IGNORE_DUP_KEY = OFF)
)
GO
/****** Object:  Table [dbo].[__MigrationHistory]    Script Date: 2/13/2020 11:17:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[__MigrationHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ContextKey] [nvarchar](300) NOT NULL,
	[Model] [varbinary](max) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK_dbo.__MigrationHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC,
	[ContextKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[AspNetRoles]    Script Date: 2/13/2020 11:17:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetRoles](
	[Id] [nvarchar](128) NOT NULL,
	[Name] [nvarchar](256) NOT NULL,
 CONSTRAINT [PK_dbo.AspNetRoles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AspNetUserClaims]    Script Date: 2/13/2020 11:17:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [nvarchar](128) NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.AspNetUserClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AspNetUserLogins]    Script Date: 2/13/2020 11:17:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserLogins](
	[LoginProvider] [nvarchar](128) NOT NULL,
	[ProviderKey] [nvarchar](128) NOT NULL,
	[UserId] [nvarchar](128) NOT NULL,
 CONSTRAINT [PK_dbo.AspNetUserLogins] PRIMARY KEY CLUSTERED 
(
	[LoginProvider] ASC,
	[ProviderKey] ASC,
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AspNetUserRoles]    Script Date: 2/13/2020 11:17:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserRoles](
	[UserId] [nvarchar](128) NOT NULL,
	[RoleId] [nvarchar](128) NOT NULL,
 CONSTRAINT [PK_dbo.AspNetUserRoles] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AspNetUsers]    Script Date: 2/13/2020 11:17:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[AspNetUsers](
	[Id] [nvarchar](128) NOT NULL,
	[Email] [nvarchar](256) NULL,
	[EmailConfirmed] [bit] NOT NULL,
	[PasswordHash] [nvarchar](max) NULL,
	[SecurityStamp] [nvarchar](max) NULL,
	[PhoneNumber] [nvarchar](max) NULL,
	[PhoneNumberConfirmed] [bit] NOT NULL,
	[TwoFactorEnabled] [bit] NOT NULL,
	[LockoutEndDateUtc] [datetime] NULL,
	[LockoutEnabled] [bit] NOT NULL,
	[AccessFailedCount] [int] NOT NULL,
	[UserName] [nvarchar](256) NOT NULL,
	[FirstName] [varchar](100) NULL,
 CONSTRAINT [PK_dbo.AspNetUsers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[CertificateMst]    Script Date: 2/13/2020 11:17:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CertificateMst](
	[CertificateCode] [int] IDENTITY(1,1) NOT NULL,
	[CertificateName] [nvarchar](50) NULL,
	[SortID] [int] NULL,
	[Logid] [int] NULL,
	[Pcid] [nvarchar](50) NULL,
	[Sdate] [datetime] NULL,
	[CompanyCode] [int] NULL,
	[Active] [bit] NULL,
 CONSTRAINT [PK_CertificateMst] PRIMARY KEY CLUSTERED 
(
	[CertificateCode] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ColorMst]    Script Date: 2/13/2020 11:17:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ColorMst](
	[ColorCode] [int] IDENTITY(1,1) NOT NULL,
	[ColorName] [nvarchar](50) NULL,
	[ColorAliasName] [nvarchar](100) NULL,
	[SortID] [int] NULL,
	[Logid] [int] NULL,
	[Pcid] [nvarchar](50) NULL,
	[Sdate] [datetime] NULL,
	[CompanyCode] [int] NULL,
	[Active] [bit] NULL,
 CONSTRAINT [PK_ColorMst] PRIMARY KEY CLUSTERED 
(
	[ColorCode] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[CompanyMst]    Script Date: 2/13/2020 11:17:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CompanyMst](
	[CompanyMstId] [int] IDENTITY(1,1) NOT NULL,
	[CompanyCode] [int] NOT NULL,
	[Cdate] [datetime] NULL,
	[CompanyName] [nvarchar](50) NOT NULL,
	[AlName] [nvarchar](50) NOT NULL,
	[Add1] [nvarchar](50) NOT NULL,
	[Add2] [nvarchar](50) NULL,
	[City] [nvarchar](50) NULL,
	[State] [nvarchar](50) NULL,
	[PhNo1] [nvarchar](15) NULL,
	[PhNo2] [nvarchar](15) NULL,
	[FaxNo] [nvarchar](15) NULL,
	[MobNo] [nvarchar](50) NULL,
	[Email] [nvarchar](50) NULL,
	[GST] [nvarchar](50) NULL,
	[CST] [nvarchar](50) NULL,
	[LST] [nvarchar](50) NULL,
	[PAN] [nvarchar](50) NULL,
	[TAN] [nvarchar](50) NULL,
	[FDate] [datetime] NULL,
	[TDate] [datetime] NULL,
	[Logid] [int] NULL,
	[Pcid] [nvarchar](50) NULL,
	[Sdate] [datetime] NULL,
	[CompanyLogo] [image] NULL,
	[CPATH] [nvarchar](max) NULL,
	[Active] [bit] NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[CutMst]    Script Date: 2/13/2020 11:17:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CutMst](
	[CutCode] [int] IDENTITY(1,1) NOT NULL,
	[CutName] [nvarchar](50) NULL,
	[CutAliasName] [nvarchar](100) NULL,
	[SortID] [int] NULL,
	[Logid] [int] NULL,
	[Pcid] [nvarchar](50) NULL,
	[Sdate] [datetime] NULL,
	[CompanyCode] [int] NULL,
	[Active] [bit] NULL,
 CONSTRAINT [PK_CutMst] PRIMARY KEY CLUSTERED 
(
	[CutCode] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[FancyColorMst]    Script Date: 2/13/2020 11:17:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FancyColorMst](
	[FancyColorCode] [int] IDENTITY(1,1) NOT NULL,
	[FancyColorName] [nvarchar](50) NULL,
	[SortID] [int] NULL,
	[Logid] [int] NULL,
	[Pcid] [nvarchar](50) NULL,
	[Sdate] [datetime] NULL,
	[CompanyCode] [int] NULL,
	[Active] [bit] NULL,
 CONSTRAINT [PK_FancyColorMst] PRIMARY KEY CLUSTERED 
(
	[FancyColorCode] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[FancyOTMst]    Script Date: 2/13/2020 11:17:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FancyOTMst](
	[FancyOTCode] [int] IDENTITY(1,1) NOT NULL,
	[FancyOTName] [nvarchar](50) NULL,
	[SortID] [int] NULL,
	[Logid] [int] NULL,
	[Pcid] [nvarchar](50) NULL,
	[Sdate] [datetime] NULL,
	[CompanyCode] [int] NULL,
	[Active] [bit] NULL,
 CONSTRAINT [PK_FancyOTMst] PRIMARY KEY CLUSTERED 
(
	[FancyOTCode] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[FlouMst]    Script Date: 2/13/2020 11:17:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FlouMst](
	[FlouCode] [int] IDENTITY(1,1) NOT NULL,
	[FlouName] [nvarchar](50) NULL,
	[FlouAliasName] [nvarchar](100) NULL,
	[SortID] [int] NULL,
	[Logid] [int] NULL,
	[Pcid] [nvarchar](50) NULL,
	[Sdate] [datetime] NULL,
	[CompanyCode] [int] NULL,
	[Active] [bit] NULL,
 CONSTRAINT [PK_FlouMst] PRIMARY KEY CLUSTERED 
(
	[FlouCode] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[HAMst]    Script Date: 2/13/2020 11:17:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HAMst](
	[HACode] [int] IDENTITY(1,1) NOT NULL,
	[HAName] [nvarchar](50) NULL,
	[HAAliasName] [nvarchar](100) NULL,
	[SortID] [int] NULL,
	[Logid] [int] NULL,
	[Pcid] [nvarchar](50) NULL,
	[Sdate] [datetime] NULL,
	[CompanyCode] [int] NULL,
	[Active] [bit] NULL,
 CONSTRAINT [PK_HAMst] PRIMARY KEY CLUSTERED 
(
	[HACode] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[PartyMst]    Script Date: 2/13/2020 11:17:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PartyMst](
	[PartyCode] [int] IDENTITY(1,1) NOT NULL,
	[PartyName] [nvarchar](50) NULL,
	[Add1] [nvarchar](50) NULL,
	[Add2] [nvarchar](50) NULL,
	[Add3] [nvarchar](50) NULL,
	[City] [nvarchar](50) NULL,
	[PhNo1] [nvarchar](15) NULL,
	[PhNo2] [nvarchar](15) NULL,
	[MobNo1] [nvarchar](15) NULL,
	[MobNo2] [nvarchar](15) NULL,
	[FaxNo] [nvarchar](15) NULL,
	[Email] [nvarchar](50) NULL,
	[PanNo] [nvarchar](50) NULL,
	[SortID] [int] NULL,
	[Active] [nchar](1) NULL,
	[Logid] [int] NULL,
	[Pcid] [nvarchar](50) NULL,
	[Sdate] [datetime] NULL,
	[CompanyCode] [int] NULL,
	[TypeCode] [int] NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[PurityMst]    Script Date: 2/13/2020 11:17:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PurityMst](
	[PurityCode] [int] IDENTITY(1,1) NOT NULL,
	[PurityName] [nvarchar](50) NULL,
	[PurityAliasName] [nvarchar](100) NULL,
	[SortID] [int] NULL,
	[Logid] [int] NULL,
	[Pcid] [nvarchar](50) NULL,
	[Sdate] [datetime] NULL,
	[CompanyCode] [int] NULL,
	[Active] [bit] NULL,
 CONSTRAINT [PK_PurityMst] PRIMARY KEY CLUSTERED 
(
	[PurityCode] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ShapeMst]    Script Date: 2/13/2020 11:17:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ShapeMst](
	[ShapeCode] [int] IDENTITY(1,1) NOT NULL,
	[ShapeName] [nvarchar](50) NULL,
	[ShapeAliasName] [nvarchar](100) NULL,
	[SortID] [int] NULL,
	[Logid] [int] NULL,
	[Pcid] [nvarchar](50) NULL,
	[Sdate] [datetime] NULL,
	[CompanyCode] [int] NULL,
	[Active] [bit] NULL,
 CONSTRAINT [PK_ShapeMst] PRIMARY KEY CLUSTERED 
(
	[ShapeCode] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[SizeMst]    Script Date: 2/13/2020 11:17:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SizeMst](
	[SizeMstID] [int] IDENTITY(1,1) NOT NULL,
	[FromSize] [numeric](18, 3) NULL,
	[ToSize] [numeric](18, 3) NULL,
	[SizeAlias] [nvarchar](20) NULL,
	[SortID] [int] NULL,
	[Logid] [int] NULL,
	[Pcid] [nvarchar](50) NULL,
	[Sdate] [datetime] NULL,
	[CompanyCode] [int] NULL,
	[Active] [bit] NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TypeMst]    Script Date: 2/13/2020 11:17:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TypeMst](
	[TypeCode] [int] NULL,
	[Type] [nvarchar](50) NULL,
	[Active] [bit] NULL
) ON [PRIMARY]

GO
INSERT [dbo].[__MigrationHistory] ([MigrationId], [ContextKey], [Model], [ProductVersion]) VALUES (N'202002061544079_InitialCreate', N'BG.Models.ApplicationDbContext', 0x1F8B0800000000000400DD5CDB6EE336107D2FD07F10F4D416A9954B77B10DEC165927D906CD0DEB6CD1B7052DD18EB012A595A86C82A25FD6877E527FA14389BAF1A28BADD8CEA240B116876786C321391C1DE5BF7FFE1DFFFAE87BC6038E62372013F360B46F1A98D881E392E5C44CE8E2C737E6AFBF7CFBCDF8CCF11F8D3F72B92326073D493C31EF290D8F2D2BB6EFB18FE291EFDA5110070B3AB203DF424E601DEEEFFF6C1D1C5818204CC0328CF1FB8450D7C7E90FF8390D888D439A20EF2A70B017F3E7D0324B518D6BE4E33844369E986FDF8D3221D338F15C0406CCB0B7300D4448401105F38E3FC47846A3802C67213C40DEDD5388416E81BC1873B38F4BF1AE23D83F6423B0CA8E39949DC434F07B021E1C71975862F7951C6B162E03A79D8173E9131B75EAB88979E1E0F4D1FBC00307880A8FA75EC48427E655A1E2240EAF311DE51D4719E47904705F82E8D3A88AB86774EEB75784D0E1689FFDB7674C138F26119E109CD008797BC66D32F75CFB77FC74177CC2647274305F1CBD79F51A3947AF7FC247AFAA2385B1825CED013CBA8D821047601B5E14E3370DABDECF123B16DD2A7D32AF402CC16A308D2BF47889C992DEC33A397C631AE7EE2376F2273CB83E1017160F74A251023FAF13CF43730F17ED56A34EF6FF06AD87AF5E0FA2F51A3DB8CB74EA05FDB070225857EFB197B6C6F76E982DAFDA7C7FE462E751E0B3DFF5F8CA5A3FCE8224B2D96002ADC81D8A9698D6AD1B5B65F0760A6906357C58E7A8BB1FDACC5239BC95A26C40ABAC845CC5A657436EEFF3EAED1C7127610893978616F34853C01567D448E8B467BC7D5706CA41D740213080AF79DF3BF391EB0DB0F175D002A9C6C28D7C5C8CF26D006186486F9B6F511CC3BA777E43F17D83E9F0CF014C9F613B89201C6714F9E1B36BBBBD0F08BE4EFC398BF2CDE91A6C6AEEBE04E7C8A641744658AFB5F12E03FB5390D033E29C228A3F503B07643FEF5CBF3BC020E69CD8368EE3730866EC4C03C8A473C00B428F0E7BC3B17D69DB89C7D443AEAFCE3C841DF4632E5A661F6A092903D188A9B29026532F83A54BBA999A8BEA4DCD245A4DE5627D4D6560DD2CE5927A435381563B33A9C1F2BA7486864FEC52D8DDCFECD63BBC757B41C58D33D821F13B4C7004DB98738B28C5112967A0CBBEB18D64219D3EA6F4D9CFA654D31FC84B8656B5D26A483781E157430ABBFBAB2135131E3FB80ECB4A3A5C77726180EF24AFBE49B5AF39C1B24D2F87DA3037AD7C337B806EB99CC47160BBE92A5014BA7899A26E3FE470467BCD221B8D58F7808141A0BBECC883273036530CAA1B728A3D4CB171626785C0298A6DE4C86E8401393D0CCB4F54856165FDA36EDC0F924E88741CB14E885D826258A92EA1F2B27089ED86C86BF592D0B3E311C6C65EE8105B4E71880953D8EA892ECAD5E50E6640A1479894360F8DAD4AC43507A2266BD5CD795B0A5BCEBB5485D8484CB6E4CE9AB8E4F9DBB30466B3C736109CCD2EE96280B674B78D00E57795AE01205E5C762D40851B932640794AB59100AD7B6C0B015A77C98B0BD0EC8ADA75FE85FBEAAE8567FDA2BCF963BDD15D5B88CD9A3F762C34B3DC13FA50E88123393C4FE7AC113F52C5E50CECE4F7B398A7BA628830F019A6F5924D99EF2AF350AB19440CA226C032D05A40F94B3F09485A503D8CCB6B798DD6F12CA2076C5E776B84E57BBF005B890119BBFAF2B322A87F452A0667A7DB4731B2221AA420EF7459A8E0280242DCBCEA03EFE0145D5D56764C975CB84F365C19189F8C0607B564AE1A27E58319DC4B7968B67B499590F549C9D6F292903E69BC940F66702FF1186D77922229E89116ACE5A2FA113ED062CB2B1DC56953B48DAD8C0AC51F8C2D0D676A7C85C2D025CB0A878A3F316619816AFAE3AC3FC5C8CF302C3B56308D0A6B0B4D3488D0120BADA01A2C3D77A3989E228AE688D579A68E2F8929CF56CDF69FABAC1E9FF224E6E7402ECDFE9DF5285FD5D78E583907E15DCF61603E4B64D2EAB962DAD5DD0D4665431E8A1405FB69E0253ED1E755FADED96BBB6AFFEC898C30B604FBA5BC49729294DDD63DDE693EE4B5B0DEDC14D9CAEAF3A387D07939CF35AB7ED6E59F7A94BC1C5545D195A8B6365FBAB4A5CB1C898960FF296A45789E55C4D9275500FEA8274685C0208155DABAA3D6392655CC7A4B774481485285149A7A5859A58BD48CAC36AC84A7F1A85AA2BB0699205245975BBB232BA822556845F30AD80A9BC5B6EEA80A36491558D1DC1DBBA496887BE70E9F53DAEB49DF832ABBB8AE775269309E67231CE6A0ABBC9FAF02551EF7C4E26FE02530FE7C2783487B7BEB1B44599962BD20D260E8F799DA0BEDFA36D3F8165E8F597B4B5DDBCA9BDED2EBF1FA85EAB30684746713450AEDC5DD4DB8A38DF97DA9FDE317E90295899846EE4638C69F628AFD111318CD3E7B53CFC56CD3CE05AE10711738A61933C33CDC3F38143EA4D99D8F5AAC38763CC57D53F7654B7DCE3640B2220F28B2EF5124531ED6F8F0A30495AAC917C4C18F13F3AFB4D7715A9860FF4A1FEF1917F107E27E4EA0E12E4AB0F1B74CE11C8608DF7C93DAD1CF16BA7BF5E2CF8F59D73DE3268215736CEC0BBE5C6586EB1F33F4B226EBBA86352B7FE2F0721754ED8B0225AAB02056FF8060EED2413E1EC8ADFCCE478FDFF7354DF981C05A888A8F0086C21BC4853A92FF2A585A82BF033F694AF0EF375835E17F15D3B4647F97F40713A9FEDDB7A1BCE7168F1AC55568135B52EAE756AAF45ABCC96D9F4D12A37AAD852EB3A67BC0ADC18C5E21325E18A978B0D351C1191E0C7B9BA1FDEC44E15DE10697AC8DED528237C9026E78F7F355917F7780AEA6A0DF6C9FE2BBE958D3956F779C27D98FC8BB63C1C64959DBA7EB6E3AD87465DE1D0FB65EA4DC1D8BB56D9D9F5B8EB4CE47E8D629B6325B48F31A46550B6EA3D0668573B8E1CF0308822CA3CCBE7C5473B69AF8A62D0A4B11BD523D594C542C2D1C49AF24D1ACB6DF58F981DF38582ED3AC5643B16CD2CDF7FF46DD5CA659B786B8B80DF2AF923AA82264B7EC634D4CA79744F6AD8DA4855BDE96B336BE537F49DCDE419C525B3D9A77C42F87CA3B884B865C3A3DA8BBF2EB5E383B2B7F1111CEEFD85D9610ECEF23126CD74ECD42E6822C82FCF0162CCA45840ACD15A6C88123F524A2EE02D9149A598D39FD743BADDBB1371D73EC5C909B8486098521637FEED50A5E2C0968D29FF293EB368F6FC2F4AF900C310430D365B5F91BF236713DA7B0FB5C5113D240B0EC825774D95C5256D95D3E1548D701E908C4DD57244577D80F3D008B6FC80C3DE0556C83F0BBC44B643F9515401D48FB44D4DD3E3E75D132427ECC31CAFEF01362D8F11F7FF91F6669C4A618540000, N'6.1.3-40302')
INSERT [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName], [FirstName]) VALUES (N'fdf3666c-7fa6-43ba-a6e6-6cca94dd73dc', N'rajujikadra@gmail.com', 0, N'AGW5L2EjTObq5WkKki+9L02g4GW+FnUQtgA/XJa1ArnNSSmqYNr764/BcwavjoHwYg==', N'e11bb92e-b9d3-47ee-b3fc-2eb2c28410c5', NULL, 0, 0, CAST(0x0000AB5E01268C63 AS DateTime), 1, 0, N'rajujikadra@gmail.com', NULL)
SET IDENTITY_INSERT [dbo].[CertificateMst] ON 

INSERT [dbo].[CertificateMst] ([CertificateCode], [CertificateName], [SortID], [Logid], [Pcid], [Sdate], [CompanyCode], [Active]) VALUES (1, N'GIA', 1, 1, N'192.168.0.1', CAST(0x0000AB6000000000 AS DateTime), 1, 1)
INSERT [dbo].[CertificateMst] ([CertificateCode], [CertificateName], [SortID], [Logid], [Pcid], [Sdate], [CompanyCode], [Active]) VALUES (2, N'IGI', 1, 1, N'192.168.0.1', CAST(0x0000AB6000000000 AS DateTime), 1, 1)
INSERT [dbo].[CertificateMst] ([CertificateCode], [CertificateName], [SortID], [Logid], [Pcid], [Sdate], [CompanyCode], [Active]) VALUES (3, N'HRD', 1, 1, N'192.168.0.1', CAST(0x0000AB6000000000 AS DateTime), 1, 1)
SET IDENTITY_INSERT [dbo].[CertificateMst] OFF
SET IDENTITY_INSERT [dbo].[ColorMst] ON 

INSERT [dbo].[ColorMst] ([ColorCode], [ColorName], [ColorAliasName], [SortID], [Logid], [Pcid], [Sdate], [CompanyCode], [Active]) VALUES (1, N'D', N'D', 1, 1, N'192.168.0.1', CAST(0x0000AB6000000000 AS DateTime), 1, 1)
INSERT [dbo].[ColorMst] ([ColorCode], [ColorName], [ColorAliasName], [SortID], [Logid], [Pcid], [Sdate], [CompanyCode], [Active]) VALUES (2, N'E', N'E', 1, 1, N'192.168.0.1', CAST(0x0000AB6000000000 AS DateTime), 1, 1)
INSERT [dbo].[ColorMst] ([ColorCode], [ColorName], [ColorAliasName], [SortID], [Logid], [Pcid], [Sdate], [CompanyCode], [Active]) VALUES (3, N'F', N'F', 1, 1, N'192.168.0.1', CAST(0x0000AB6000000000 AS DateTime), 1, 1)
INSERT [dbo].[ColorMst] ([ColorCode], [ColorName], [ColorAliasName], [SortID], [Logid], [Pcid], [Sdate], [CompanyCode], [Active]) VALUES (4, N'G', N'G', 1, 1, N'192.168.0.1', CAST(0x0000AB6000000000 AS DateTime), 1, 1)
INSERT [dbo].[ColorMst] ([ColorCode], [ColorName], [ColorAliasName], [SortID], [Logid], [Pcid], [Sdate], [CompanyCode], [Active]) VALUES (5, N'H', N'H', 1, 1, N'192.168.0.1', CAST(0x0000AB6000000000 AS DateTime), 1, 1)
INSERT [dbo].[ColorMst] ([ColorCode], [ColorName], [ColorAliasName], [SortID], [Logid], [Pcid], [Sdate], [CompanyCode], [Active]) VALUES (6, N'I', N'I', 1, 1, N'192.168.0.1', CAST(0x0000AB6000000000 AS DateTime), 1, 1)
INSERT [dbo].[ColorMst] ([ColorCode], [ColorName], [ColorAliasName], [SortID], [Logid], [Pcid], [Sdate], [CompanyCode], [Active]) VALUES (7, N'J', N'J', 1, 1, N'192.168.0.1', CAST(0x0000AB6000000000 AS DateTime), 1, 1)
INSERT [dbo].[ColorMst] ([ColorCode], [ColorName], [ColorAliasName], [SortID], [Logid], [Pcid], [Sdate], [CompanyCode], [Active]) VALUES (8, N'K', N'K', 1, 1, N'192.168.0.1', CAST(0x0000AB6000000000 AS DateTime), 1, 1)
INSERT [dbo].[ColorMst] ([ColorCode], [ColorName], [ColorAliasName], [SortID], [Logid], [Pcid], [Sdate], [CompanyCode], [Active]) VALUES (9, N'L', N'L', 1, 1, N'192.168.0.1', CAST(0x0000AB6000000000 AS DateTime), 1, 1)
INSERT [dbo].[ColorMst] ([ColorCode], [ColorName], [ColorAliasName], [SortID], [Logid], [Pcid], [Sdate], [CompanyCode], [Active]) VALUES (10, N'M', N'M', 1, 1, N'192.168.0.1', CAST(0x0000AB6000000000 AS DateTime), 1, 1)
INSERT [dbo].[ColorMst] ([ColorCode], [ColorName], [ColorAliasName], [SortID], [Logid], [Pcid], [Sdate], [CompanyCode], [Active]) VALUES (11, N'N', N'N', 1, 1, N'192.168.0.1', CAST(0x0000AB6000000000 AS DateTime), 1, 1)
SET IDENTITY_INSERT [dbo].[ColorMst] OFF
SET IDENTITY_INSERT [dbo].[CompanyMst] ON 

INSERT [dbo].[CompanyMst] ([CompanyMstId], [CompanyCode], [Cdate], [CompanyName], [AlName], [Add1], [Add2], [City], [State], [PhNo1], [PhNo2], [FaxNo], [MobNo], [Email], [GST], [CST], [LST], [PAN], [TAN], [FDate], [TDate], [Logid], [Pcid], [Sdate], [CompanyLogo], [CPATH], [Active]) VALUES (1, 1, CAST(0x0000AB6000000000 AS DateTime), N'RUDRA | NEW ERA OF TECHNOLOGY', N'RUDRA', N'SRT', N'SRT', N'SRT', N'GUJARAT', N'9876543210', N'7698669934', NULL, NULL, N'AKCHODVADIYA@GMAIL.COM', NULL, NULL, NULL, NULL, NULL, CAST(0x0000AB6000000000 AS DateTime), CAST(0x0000AB6000000000 AS DateTime), 1, N'192.168.0.1', CAST(0x0000AB6000000000 AS DateTime), NULL, NULL, 1)
SET IDENTITY_INSERT [dbo].[CompanyMst] OFF
SET IDENTITY_INSERT [dbo].[CutMst] ON 

INSERT [dbo].[CutMst] ([CutCode], [CutName], [CutAliasName], [SortID], [Logid], [Pcid], [Sdate], [CompanyCode], [Active]) VALUES (1, N'EX', N'EXCELLENT', 1, 1, N'192.168.0.1', CAST(0x0000AB6000000000 AS DateTime), 1, 1)
INSERT [dbo].[CutMst] ([CutCode], [CutName], [CutAliasName], [SortID], [Logid], [Pcid], [Sdate], [CompanyCode], [Active]) VALUES (2, N'VG', N'VERY GOOD', 1, 1, N'192.168.0.1', CAST(0x0000AB6000000000 AS DateTime), 1, 1)
INSERT [dbo].[CutMst] ([CutCode], [CutName], [CutAliasName], [SortID], [Logid], [Pcid], [Sdate], [CompanyCode], [Active]) VALUES (3, N'GD', N'GOOD', 1, 1, N'192.168.0.1', CAST(0x0000AB6000000000 AS DateTime), 1, 1)
INSERT [dbo].[CutMst] ([CutCode], [CutName], [CutAliasName], [SortID], [Logid], [Pcid], [Sdate], [CompanyCode], [Active]) VALUES (4, N'NONE', N'NONE', 1, 1, N'192.168.0.1', CAST(0x0000AB6000000000 AS DateTime), 1, 1)
SET IDENTITY_INSERT [dbo].[CutMst] OFF
SET IDENTITY_INSERT [dbo].[FancyColorMst] ON 

INSERT [dbo].[FancyColorMst] ([FancyColorCode], [FancyColorName], [SortID], [Logid], [Pcid], [Sdate], [CompanyCode], [Active]) VALUES (1, N'YELLOW', 1, 1, N'192.168.0.1', CAST(0x0000AB6000000000 AS DateTime), 1, 1)
INSERT [dbo].[FancyColorMst] ([FancyColorCode], [FancyColorName], [SortID], [Logid], [Pcid], [Sdate], [CompanyCode], [Active]) VALUES (2, N'PINK', 1, 1, N'192.168.0.1', CAST(0x0000AB6000000000 AS DateTime), 1, 1)
INSERT [dbo].[FancyColorMst] ([FancyColorCode], [FancyColorName], [SortID], [Logid], [Pcid], [Sdate], [CompanyCode], [Active]) VALUES (3, N'BLUE', 1, 1, N'192.168.0.1', CAST(0x0000AB6000000000 AS DateTime), 1, 1)
INSERT [dbo].[FancyColorMst] ([FancyColorCode], [FancyColorName], [SortID], [Logid], [Pcid], [Sdate], [CompanyCode], [Active]) VALUES (4, N'ORANGE', 1, 1, N'192.168.0.1', CAST(0x0000AB6000000000 AS DateTime), 1, 1)
INSERT [dbo].[FancyColorMst] ([FancyColorCode], [FancyColorName], [SortID], [Logid], [Pcid], [Sdate], [CompanyCode], [Active]) VALUES (5, N'GREEN', 1, 1, N'192.168.0.1', CAST(0x0000AB6000000000 AS DateTime), 1, 1)
SET IDENTITY_INSERT [dbo].[FancyColorMst] OFF
SET IDENTITY_INSERT [dbo].[FancyOTMst] ON 

INSERT [dbo].[FancyOTMst] ([FancyOTCode], [FancyOTName], [SortID], [Logid], [Pcid], [Sdate], [CompanyCode], [Active]) VALUES (1, N'BROWNISH', 1, 1, N'192.168.0.1', CAST(0x0000AB6000000000 AS DateTime), 1, 1)
INSERT [dbo].[FancyOTMst] ([FancyOTCode], [FancyOTName], [SortID], [Logid], [Pcid], [Sdate], [CompanyCode], [Active]) VALUES (2, N'GREENISH', 1, 1, N'192.168.0.1', CAST(0x0000AB6000000000 AS DateTime), 1, 1)
INSERT [dbo].[FancyOTMst] ([FancyOTCode], [FancyOTName], [SortID], [Logid], [Pcid], [Sdate], [CompanyCode], [Active]) VALUES (3, N'YELLOWISH', 1, 1, N'192.168.0.1', CAST(0x0000AB6000000000 AS DateTime), 1, 1)
INSERT [dbo].[FancyOTMst] ([FancyOTCode], [FancyOTName], [SortID], [Logid], [Pcid], [Sdate], [CompanyCode], [Active]) VALUES (4, N'PURPLISH', 1, 1, N'192.168.0.1', CAST(0x0000AB6000000000 AS DateTime), 1, 1)
INSERT [dbo].[FancyOTMst] ([FancyOTCode], [FancyOTName], [SortID], [Logid], [Pcid], [Sdate], [CompanyCode], [Active]) VALUES (5, N'BLUISH', 1, 1, N'192.168.0.1', CAST(0x0000AB6000000000 AS DateTime), 1, 1)
SET IDENTITY_INSERT [dbo].[FancyOTMst] OFF
SET IDENTITY_INSERT [dbo].[FlouMst] ON 

INSERT [dbo].[FlouMst] ([FlouCode], [FlouName], [FlouAliasName], [SortID], [Logid], [Pcid], [Sdate], [CompanyCode], [Active]) VALUES (1, N'STG', N'STRONG', 1, 1, N'192.168.0.1', CAST(0x0000AB6000000000 AS DateTime), 1, 1)
INSERT [dbo].[FlouMst] ([FlouCode], [FlouName], [FlouAliasName], [SortID], [Logid], [Pcid], [Sdate], [CompanyCode], [Active]) VALUES (2, N'MED', N'MEDIUM', 1, 1, N'192.168.0.1', CAST(0x0000AB6000000000 AS DateTime), 1, 1)
INSERT [dbo].[FlouMst] ([FlouCode], [FlouName], [FlouAliasName], [SortID], [Logid], [Pcid], [Sdate], [CompanyCode], [Active]) VALUES (3, N'FNT', N'FAINT', 1, 1, N'192.168.0.1', CAST(0x0000AB6000000000 AS DateTime), 1, 1)
INSERT [dbo].[FlouMst] ([FlouCode], [FlouName], [FlouAliasName], [SortID], [Logid], [Pcid], [Sdate], [CompanyCode], [Active]) VALUES (4, N'NONE', N'NONE', 1, 1, N'192.168.0.1', CAST(0x0000AB6000000000 AS DateTime), 1, 1)
SET IDENTITY_INSERT [dbo].[FlouMst] OFF
SET IDENTITY_INSERT [dbo].[HAMst] ON 

INSERT [dbo].[HAMst] ([HACode], [HAName], [HAAliasName], [SortID], [Logid], [Pcid], [Sdate], [CompanyCode], [Active]) VALUES (1, N'EX', N'EXCELLENT', 1, 1, N'192.168.0.1', CAST(0x0000AB6000000000 AS DateTime), 1, 1)
INSERT [dbo].[HAMst] ([HACode], [HAName], [HAAliasName], [SortID], [Logid], [Pcid], [Sdate], [CompanyCode], [Active]) VALUES (2, N'VG', N'VERY GOOD', 1, 1, N'192.168.0.1', CAST(0x0000AB6000000000 AS DateTime), 1, 1)
INSERT [dbo].[HAMst] ([HACode], [HAName], [HAAliasName], [SortID], [Logid], [Pcid], [Sdate], [CompanyCode], [Active]) VALUES (3, N'GD', N'GOOD', 1, 1, N'192.168.0.1', CAST(0x0000AB6000000000 AS DateTime), 1, 1)
INSERT [dbo].[HAMst] ([HACode], [HAName], [HAAliasName], [SortID], [Logid], [Pcid], [Sdate], [CompanyCode], [Active]) VALUES (4, N'NONE', N'NONE', 1, 1, N'192.168.0.1', CAST(0x0000AB6000000000 AS DateTime), 1, 1)
SET IDENTITY_INSERT [dbo].[HAMst] OFF
SET IDENTITY_INSERT [dbo].[PartyMst] ON 

INSERT [dbo].[PartyMst] ([PartyCode], [PartyName], [Add1], [Add2], [Add3], [City], [PhNo1], [PhNo2], [MobNo1], [MobNo2], [FaxNo], [Email], [PanNo], [SortID], [Active], [Logid], [Pcid], [Sdate], [CompanyCode], [TypeCode]) VALUES (1, N'ASHISH', N'SURAT', NULL, NULL, N'SURAT', N'9876543210', N'7698669934', NULL, NULL, NULL, NULL, NULL, 1, N'1', 1, N'192.168.0.1', CAST(0x0000AB6000000000 AS DateTime), 1, 1)
INSERT [dbo].[PartyMst] ([PartyCode], [PartyName], [Add1], [Add2], [Add3], [City], [PhNo1], [PhNo2], [MobNo1], [MobNo2], [FaxNo], [Email], [PanNo], [SortID], [Active], [Logid], [Pcid], [Sdate], [CompanyCode], [TypeCode]) VALUES (2, N'RAJU', N'SURAT', NULL, NULL, N'SURAT', N'9976543210', N'7698669933', NULL, NULL, NULL, NULL, NULL, 1, N'1', 1, N'192.168.0.1', CAST(0x0000AB6000000000 AS DateTime), 1, 2)
INSERT [dbo].[PartyMst] ([PartyCode], [PartyName], [Add1], [Add2], [Add3], [City], [PhNo1], [PhNo2], [MobNo1], [MobNo2], [FaxNo], [Email], [PanNo], [SortID], [Active], [Logid], [Pcid], [Sdate], [CompanyCode], [TypeCode]) VALUES (3, N'HIREN', N'SURAT', NULL, NULL, N'SURAT', N'9776543210', N'9979999799', NULL, NULL, NULL, NULL, NULL, 1, N'1', 1, N'192.168.0.1', CAST(0x0000AB6000000000 AS DateTime), 1, 3)
SET IDENTITY_INSERT [dbo].[PartyMst] OFF
SET IDENTITY_INSERT [dbo].[PurityMst] ON 

INSERT [dbo].[PurityMst] ([PurityCode], [PurityName], [PurityAliasName], [SortID], [Logid], [Pcid], [Sdate], [CompanyCode], [Active]) VALUES (1, N'FL', N'FL', 1, 1, N'192.168.0.1', CAST(0x0000AB6000000000 AS DateTime), 1, 1)
INSERT [dbo].[PurityMst] ([PurityCode], [PurityName], [PurityAliasName], [SortID], [Logid], [Pcid], [Sdate], [CompanyCode], [Active]) VALUES (2, N'IF', N'IF', 1, 1, N'192.168.0.1', CAST(0x0000AB6000000000 AS DateTime), 1, 1)
INSERT [dbo].[PurityMst] ([PurityCode], [PurityName], [PurityAliasName], [SortID], [Logid], [Pcid], [Sdate], [CompanyCode], [Active]) VALUES (3, N'VVS1', N'VVS1', 1, 1, N'192.168.0.1', CAST(0x0000AB6000000000 AS DateTime), 1, 1)
INSERT [dbo].[PurityMst] ([PurityCode], [PurityName], [PurityAliasName], [SortID], [Logid], [Pcid], [Sdate], [CompanyCode], [Active]) VALUES (4, N'VVS2', N'VVS2', 1, 1, N'192.168.0.1', CAST(0x0000AB6000000000 AS DateTime), 1, 1)
INSERT [dbo].[PurityMst] ([PurityCode], [PurityName], [PurityAliasName], [SortID], [Logid], [Pcid], [Sdate], [CompanyCode], [Active]) VALUES (5, N'VS1', N'VS1', 1, 1, N'192.168.0.1', CAST(0x0000AB6000000000 AS DateTime), 1, 1)
INSERT [dbo].[PurityMst] ([PurityCode], [PurityName], [PurityAliasName], [SortID], [Logid], [Pcid], [Sdate], [CompanyCode], [Active]) VALUES (6, N'VS2', N'VS2', 1, 1, N'192.168.0.1', CAST(0x0000AB6000000000 AS DateTime), 1, 1)
INSERT [dbo].[PurityMst] ([PurityCode], [PurityName], [PurityAliasName], [SortID], [Logid], [Pcid], [Sdate], [CompanyCode], [Active]) VALUES (7, N'SI1', N'SI1', 1, 1, N'192.168.0.1', CAST(0x0000AB6000000000 AS DateTime), 1, 1)
INSERT [dbo].[PurityMst] ([PurityCode], [PurityName], [PurityAliasName], [SortID], [Logid], [Pcid], [Sdate], [CompanyCode], [Active]) VALUES (8, N'SI2', N'SI2', 1, 1, N'192.168.0.1', CAST(0x0000AB6000000000 AS DateTime), 1, 1)
INSERT [dbo].[PurityMst] ([PurityCode], [PurityName], [PurityAliasName], [SortID], [Logid], [Pcid], [Sdate], [CompanyCode], [Active]) VALUES (9, N'I1', N'I1', 1, 1, N'192.168.0.1', CAST(0x0000AB6000000000 AS DateTime), 1, 1)
INSERT [dbo].[PurityMst] ([PurityCode], [PurityName], [PurityAliasName], [SortID], [Logid], [Pcid], [Sdate], [CompanyCode], [Active]) VALUES (10, N'I2', N'I2', 1, 1, N'192.168.0.1', CAST(0x0000AB6000000000 AS DateTime), 1, 1)
INSERT [dbo].[PurityMst] ([PurityCode], [PurityName], [PurityAliasName], [SortID], [Logid], [Pcid], [Sdate], [CompanyCode], [Active]) VALUES (11, N'I3', N'I3', 1, 1, N'192.168.0.1', CAST(0x0000AB6000000000 AS DateTime), 1, 1)
SET IDENTITY_INSERT [dbo].[PurityMst] OFF
SET IDENTITY_INSERT [dbo].[ShapeMst] ON 

INSERT [dbo].[ShapeMst] ([ShapeCode], [ShapeName], [ShapeAliasName], [SortID], [Logid], [Pcid], [Sdate], [CompanyCode], [Active]) VALUES (1, N'RD', N'ROUND', 1, 1, N'192.168.0.1', CAST(0x0000AB6000000000 AS DateTime), 1, 1)
INSERT [dbo].[ShapeMst] ([ShapeCode], [ShapeName], [ShapeAliasName], [SortID], [Logid], [Pcid], [Sdate], [CompanyCode], [Active]) VALUES (2, N'EM', N'EMERALD', 1, 1, N'192.168.0.1', CAST(0x0000AB6000000000 AS DateTime), 1, 1)
INSERT [dbo].[ShapeMst] ([ShapeCode], [ShapeName], [ShapeAliasName], [SortID], [Logid], [Pcid], [Sdate], [CompanyCode], [Active]) VALUES (3, N'PR', N'PRINCESS', 1, 1, N'192.168.0.1', CAST(0x0000AB6000000000 AS DateTime), 1, 1)
INSERT [dbo].[ShapeMst] ([ShapeCode], [ShapeName], [ShapeAliasName], [SortID], [Logid], [Pcid], [Sdate], [CompanyCode], [Active]) VALUES (4, N'MQ', N'MARQUISH', 1, 1, N'192.168.0.1', CAST(0x0000AB6000000000 AS DateTime), 1, 1)
INSERT [dbo].[ShapeMst] ([ShapeCode], [ShapeName], [ShapeAliasName], [SortID], [Logid], [Pcid], [Sdate], [CompanyCode], [Active]) VALUES (5, N'CUSH', N'CUSHION', 1, 1, N'192.168.0.1', CAST(0x0000AB6000000000 AS DateTime), 1, 1)
INSERT [dbo].[ShapeMst] ([ShapeCode], [ShapeName], [ShapeAliasName], [SortID], [Logid], [Pcid], [Sdate], [CompanyCode], [Active]) VALUES (6, N'ASH', N'ASSCHER', 1, 1, N'192.168.0.1', CAST(0x0000AB6000000000 AS DateTime), 1, 1)
SET IDENTITY_INSERT [dbo].[ShapeMst] OFF
SET IDENTITY_INSERT [dbo].[SizeMst] ON 

INSERT [dbo].[SizeMst] ([SizeMstID], [FromSize], [ToSize], [SizeAlias], [SortID], [Logid], [Pcid], [Sdate], [CompanyCode], [Active]) VALUES (1, CAST(0.001 AS Numeric(18, 3)), CAST(0.499 AS Numeric(18, 3)), N'0.001-0.499', 1, 1, N'192.168.0.1', CAST(0x0000AB6000000000 AS DateTime), 1, 1)
INSERT [dbo].[SizeMst] ([SizeMstID], [FromSize], [ToSize], [SizeAlias], [SortID], [Logid], [Pcid], [Sdate], [CompanyCode], [Active]) VALUES (2, CAST(0.500 AS Numeric(18, 3)), CAST(0.999 AS Numeric(18, 3)), N'0.500-0.999', 1, 1, N'192.168.0.1', CAST(0x0000AB6000000000 AS DateTime), 1, 1)
INSERT [dbo].[SizeMst] ([SizeMstID], [FromSize], [ToSize], [SizeAlias], [SortID], [Logid], [Pcid], [Sdate], [CompanyCode], [Active]) VALUES (3, CAST(1.000 AS Numeric(18, 3)), CAST(1.499 AS Numeric(18, 3)), N'1.000-1.499', 1, 1, N'192.168.0.1', CAST(0x0000AB6000000000 AS DateTime), 1, 1)
INSERT [dbo].[SizeMst] ([SizeMstID], [FromSize], [ToSize], [SizeAlias], [SortID], [Logid], [Pcid], [Sdate], [CompanyCode], [Active]) VALUES (4, CAST(1.500 AS Numeric(18, 3)), CAST(1.999 AS Numeric(18, 3)), N'1.500-1.999', 1, 1, N'192.168.0.1', CAST(0x0000AB6000000000 AS DateTime), 1, 1)
SET IDENTITY_INSERT [dbo].[SizeMst] OFF
INSERT [dbo].[TypeMst] ([TypeCode], [Type], [Active]) VALUES (1, N'BROKER', 1)
INSERT [dbo].[TypeMst] ([TypeCode], [Type], [Active]) VALUES (2, N'SALES PERSON', 1)
INSERT [dbo].[TypeMst] ([TypeCode], [Type], [Active]) VALUES (3, N'PARTY', 1)
ALTER TABLE [dbo].[AspNetUserClaims]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserClaims_dbo.AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserClaims] CHECK CONSTRAINT [FK_dbo.AspNetUserClaims_dbo.AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserLogins]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserLogins_dbo.AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserLogins] CHECK CONSTRAINT [FK_dbo.AspNetUserLogins_dbo.AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetRoles_RoleId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetUsers_UserId]
GO
