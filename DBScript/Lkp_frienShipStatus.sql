USE [proworldzdbNEW]
GO
SET IDENTITY_INSERT [dbo].[Lkp_FriendShipStatus] ON 

INSERT [dbo].[Lkp_FriendShipStatus] ([Id], [Status]) VALUES (1, N'New')
INSERT [dbo].[Lkp_FriendShipStatus] ([Id], [Status]) VALUES (2, N'Accepted')
INSERT [dbo].[Lkp_FriendShipStatus] ([Id], [Status]) VALUES (3, N'Pending')
SET IDENTITY_INSERT [dbo].[Lkp_FriendShipStatus] OFF
