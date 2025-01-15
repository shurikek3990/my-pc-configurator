USE [ConfiguratorDb]
GO
SET IDENTITY_INSERT [dbo].[Vendors] ON 
GO
INSERT [dbo].[Vendors] ([Id], [Name], [LegalName], [CountryCode]) VALUES (1, N'AMD', N'Advanced Micro Devices, Inc.', N'US')
GO
INSERT [dbo].[Vendors] ([Id], [Name], [LegalName], [CountryCode]) VALUES (2, N'MSI', N'Micro-Star International Co. Ltd', N'US')
GO
INSERT [dbo].[Vendors] ([Id], [Name], [LegalName], [CountryCode]) VALUES (3, N'Crucial', N'Micron Technology, Inc.', N'US')
GO
INSERT [dbo].[Vendors] ([Id], [Name], [LegalName], [CountryCode]) VALUES (4, N'NVidia', N'Nvidia Corporation', N'US')
GO
INSERT [dbo].[Vendors] ([Id], [Name], [LegalName], [CountryCode]) VALUES (5, N'Be Quiet!', N'Listan GmbH', N'DE')
GO
SET IDENTITY_INSERT [dbo].[Vendors] OFF
GO
SET IDENTITY_INSERT [dbo].[Disks] ON 
GO
INSERT [dbo].[Disks] ([Id], [Capacity], [ModelName], [PowerConsumption], [Price], [VendorId]) VALUES (1, 1000, N'MX500 1TB', 15, CAST(278.00 AS Decimal(5, 2)), 3)
GO
INSERT [dbo].[Disks] ([Id], [Capacity], [ModelName], [PowerConsumption], [Price], [VendorId]) VALUES (2, 2000, N'MX500 2TB', 15, CAST(379.00 AS Decimal(5, 2)), 3)
GO
SET IDENTITY_INSERT [dbo].[Disks] OFF
GO
SET IDENTITY_INSERT [dbo].[GraphicsCards] ON 
GO
INSERT [dbo].[GraphicsCards] ([Id], [Memory], [ModelName], [PowerConsumption], [Price], [VendorId]) VALUES (1, 12000, N'RTX 3060 12GB', 250, CAST(999.00 AS Decimal(5, 2)), 4)
GO
INSERT [dbo].[GraphicsCards] ([Id], [Memory], [ModelName], [PowerConsumption], [Price], [VendorId]) VALUES (2, 16000, N'RX 7600 XT 16GB', 300, CAST(899.00 AS Decimal(5, 2)), 1)
GO
SET IDENTITY_INSERT [dbo].[GraphicsCards] OFF
GO
SET IDENTITY_INSERT [dbo].[Memories] ON 
GO
INSERT [dbo].[Memories] ([Id], [Capacity], [RamType], [ModelName], [PowerConsumption], [Price], [VendorId]) VALUES (1, 8000, N'DDR4', N'Ballistix DDR4 - 1', 10, CAST(198.00 AS Decimal(5, 2)), 3)
GO
INSERT [dbo].[Memories] ([Id], [Capacity], [RamType], [ModelName], [PowerConsumption], [Price], [VendorId]) VALUES (2, 8000, N'DDR5', N'Ballistix DDR5 - 1', 12, CAST(299.00 AS Decimal(5, 2)), 3)
GO
INSERT [dbo].[Memories] ([Id], [Capacity], [RamType], [ModelName], [PowerConsumption], [Price], [VendorId]) VALUES (3, 8000, N'DDR4', N'Ballistix DDR4 - 2', 10, CAST(198.00 AS Decimal(5, 2)), 3)
GO
INSERT [dbo].[Memories] ([Id], [Capacity], [RamType], [ModelName], [PowerConsumption], [Price], [VendorId]) VALUES (4, 8000, N'DDR5', N'Ballistix DDR5 - 2', 12, CAST(299.00 AS Decimal(5, 2)), 3)
GO
SET IDENTITY_INSERT [dbo].[Memories] OFF
GO
SET IDENTITY_INSERT [dbo].[Motherboards] ON 
GO
INSERT [dbo].[Motherboards] ([Id], [Format], [Socket], [RamType], [RamSlots], [ModelName], [PowerConsumption], [Price], [VendorId]) VALUES (1, N'ATX', N'AM4', N'DDR4', 4, N'B550 Tomahawk', 10, CAST(398.00 AS Decimal(5, 2)), 2)
GO
INSERT [dbo].[Motherboards] ([Id], [Format], [Socket], [RamType], [RamSlots], [ModelName], [PowerConsumption], [Price], [VendorId]) VALUES (3, N'ATX', N'AM5', N'DDR5', 4, N'B650 Tomahavk Wi-Fi', 10, CAST(549.00 AS Decimal(5, 2)), 2)
GO
SET IDENTITY_INSERT [dbo].[Motherboards] OFF
GO
SET IDENTITY_INSERT [dbo].[PowerSupplys] ON 
GO
INSERT [dbo].[PowerSupplys] ([Id], [OutputPower], [ModelName], [PowerConsumption], [Price], [VendorId]) VALUES (1, 600, N'System Power 12 600W', 0, CAST(418.00 AS Decimal(5, 2)), 5)
GO
INSERT [dbo].[PowerSupplys] ([Id], [OutputPower], [ModelName], [PowerConsumption], [Price], [VendorId]) VALUES (2, 850, N'Pure Power 13M 850W', 0, CAST(669.00 AS Decimal(5, 2)), 5)
GO
INSERT [dbo].[PowerSupplys] ([Id], [OutputPower], [ModelName], [PowerConsumption], [Price], [VendorId]) VALUES (5, 550, N'System Power 12 550W', 0, CAST(279.00 AS Decimal(5, 2)), 5)
GO
SET IDENTITY_INSERT [dbo].[PowerSupplys] OFF
GO
SET IDENTITY_INSERT [dbo].[Processors] ON 
GO
INSERT [dbo].[Processors] ([Id], [Socket], [Cores], [IntegratedGraphics], [ModelName], [PowerConsumption], [Price], [VendorId]) VALUES (1, N'AM4', 8, 0, N'Ryzen 7 5800X3D', 105, CAST(900.00 AS Decimal(5, 2)), 1)
GO
INSERT [dbo].[Processors] ([Id], [Socket], [Cores], [IntegratedGraphics], [ModelName], [PowerConsumption], [Price], [VendorId]) VALUES (2, N'AM5', 8, 0, N'Ryzen 7 7800X3D', 125, CAST(999.00 AS Decimal(5, 2)), 1)
GO
SET IDENTITY_INSERT [dbo].[Processors] OFF
GO
