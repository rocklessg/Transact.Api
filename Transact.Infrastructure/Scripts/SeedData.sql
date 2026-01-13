USE [DotnetPracticalInterviewAssessment]
GO
INSERT [dbo].[CustomerData] ([CustomerId], [CustomerName], [CustomerType], [DateCreated]) VALUES (1344459, N'James Babalola', N'BUSINESS', CAST(N'1993-01-01T00:00:00.000' AS DateTime))
GO
INSERT [dbo].[CustomerData] ([CustomerId], [CustomerName], [CustomerType], [DateCreated]) VALUES (2311159, N'Alfred Wisdom', N'BUSINESS', CAST(N'1995-01-01T00:00:00.000' AS DateTime))
GO
INSERT [dbo].[CustomerData] ([CustomerId], [CustomerName], [CustomerType], [DateCreated]) VALUES (2344559, N'John Ole', N'RETAIL', CAST(N'1992-01-01T00:00:00.000' AS DateTime))
GO
INSERT [dbo].[CustomerData] ([CustomerId], [CustomerName], [CustomerType], [DateCreated]) VALUES (3344659, N'Peter Mod', N'RETAIL', CAST(N'1994-01-01T00:00:00.000' AS DateTime))
GO
INSERT [dbo].[AccountData] ([AccountId], [AccountNumber], [CustomerId], [AccountBalance], [AccountOpenDate]) VALUES (1, N'2344559772', 2344559, CAST(9000000.00 AS Decimal(18, 2)), CAST(N'2013-01-01T00:00:00.000' AS DateTime))
GO
INSERT [dbo].[AccountData] ([AccountId], [AccountNumber], [CustomerId], [AccountBalance], [AccountOpenDate]) VALUES (2, N'1344459859', 1344459, CAST(1400000.00 AS Decimal(18, 2)), CAST(N'2021-12-28T00:00:00.000' AS DateTime))
GO
INSERT [dbo].[AccountData] ([AccountId], [AccountNumber], [CustomerId], [AccountBalance], [AccountOpenDate]) VALUES (3, N'3344659440', 3344659, CAST(2000.00 AS Decimal(18, 2)), CAST(N'2019-06-21T00:00:00.000' AS DateTime))
GO
INSERT [dbo].[AccountData] ([AccountId], [AccountNumber], [CustomerId], [AccountBalance], [AccountOpenDate]) VALUES (4, N'2311159447', 2311159, CAST(30000.00 AS Decimal(18, 2)), CAST(N'2020-03-29T00:00:00.000' AS DateTime))
GO
INSERT [dbo].[AccountData] ([AccountId], [AccountNumber], [CustomerId], [AccountBalance], [AccountOpenDate]) VALUES (5, N'2344559713', 2344559, CAST(40.00 AS Decimal(18, 2)), CAST(N'2019-06-22T00:00:00.000' AS DateTime))
GO
INSERT [dbo].[AccountData] ([AccountId], [AccountNumber], [CustomerId], [AccountBalance], [AccountOpenDate]) VALUES (6, N'1344459312', 1344459, CAST(401000.09 AS Decimal(18, 2)), CAST(N'2022-01-21T00:00:00.000' AS DateTime))
GO
INSERT [dbo].[AccountData] ([AccountId], [AccountNumber], [CustomerId], [AccountBalance], [AccountOpenDate]) VALUES (7, N'3344659380', 3344659, CAST(4000.09 AS Decimal(18, 2)), CAST(N'2022-01-21T00:00:00.000' AS DateTime))
GO
INSERT [dbo].[AccountData] ([AccountId], [AccountNumber], [CustomerId], [AccountBalance], [AccountOpenDate]) VALUES (8, N'2311159609', 2311159, CAST(1000.00 AS Decimal(18, 2)), CAST(N'2022-02-21T00:00:00.000' AS DateTime))
GO
INSERT [dbo].[AccountData] ([AccountId], [AccountNumber], [CustomerId], [AccountBalance], [AccountOpenDate]) VALUES (9, N'2344559774', 2344559, CAST(2000000.00 AS Decimal(18, 2)), CAST(N'2022-03-30T00:00:00.000' AS DateTime))
GO
INSERT [dbo].[AccountData] ([AccountId], [AccountNumber], [CustomerId], [AccountBalance], [AccountOpenDate]) VALUES (10, N'1344459578', 1344459, CAST(4000.09 AS Decimal(18, 2)), CAST(N'2022-06-30T00:00:00.000' AS DateTime))
GO
INSERT [dbo].[AccountData] ([AccountId], [AccountNumber], [CustomerId], [AccountBalance], [AccountOpenDate]) VALUES (11, N'3344659907', 3344659, CAST(4000.09 AS Decimal(18, 2)), CAST(N'2022-07-20T00:00:00.000' AS DateTime))
GO
INSERT [dbo].[AccountData] ([AccountId], [AccountNumber], [CustomerId], [AccountBalance], [AccountOpenDate]) VALUES (12, N'2311159242', 2311159, CAST(15000.79 AS Decimal(18, 2)), CAST(N'2021-08-31T00:00:00.000' AS DateTime))
GO
INSERT [dbo].[AccountData] ([AccountId], [AccountNumber], [CustomerId], [AccountBalance], [AccountOpenDate]) VALUES (13, N'2344559209', 2344559, CAST(150000.11 AS Decimal(18, 2)), CAST(N'2021-09-30T00:00:00.000' AS DateTime))
GO
INSERT [dbo].[AccountData] ([AccountId], [AccountNumber], [CustomerId], [AccountBalance], [AccountOpenDate]) VALUES (14, N'1344459411', 1344459, CAST(12345.00 AS Decimal(18, 2)), CAST(N'2020-10-31T00:00:00.000' AS DateTime))
GO
INSERT [dbo].[AccountData] ([AccountId], [AccountNumber], [CustomerId], [AccountBalance], [AccountOpenDate]) VALUES (15, N'3344659556', 3344659, CAST(1500000.00 AS Decimal(18, 2)), CAST(N'2021-11-30T00:00:00.000' AS DateTime))
GO
INSERT [dbo].[AccountData] ([AccountId], [AccountNumber], [CustomerId], [AccountBalance], [AccountOpenDate]) VALUES (16, N'2311159703', 2311159, CAST(1500000.00 AS Decimal(18, 2)), CAST(N'2019-12-31T00:00:00.000' AS DateTime))
GO
INSERT [dbo].[TransactionData] ([TransactionId], [AccountNumber], [Amount], [DiscountedAmount], [Rate], [TransactionDate]) VALUES (1, N'1344459312', CAST(192560.00 AS Decimal(18, 2)), CAST(173304.00 AS Decimal(18, 2)), CAST(10.00 AS Decimal(18, 2)), CAST(N'2022-01-05T00:00:00.000' AS DateTime))
GO
INSERT [dbo].[TransactionData] ([TransactionId], [AccountNumber], [Amount], [DiscountedAmount], [Rate], [TransactionDate]) VALUES (2, N'2344559713', CAST(337374.00 AS Decimal(18, 2)), CAST(303636.60 AS Decimal(18, 2)), CAST(10.00 AS Decimal(18, 2)), CAST(N'2022-01-21T00:00:00.000' AS DateTime))
GO
INSERT [dbo].[TransactionData] ([TransactionId], [AccountNumber], [Amount], [DiscountedAmount], [Rate], [TransactionDate]) VALUES (3, N'1344459411', CAST(211715.00 AS Decimal(18, 2)), CAST(190543.50 AS Decimal(18, 2)), CAST(10.00 AS Decimal(18, 2)), CAST(N'2022-01-24T00:00:00.000' AS DateTime))
GO
INSERT [dbo].[TransactionData] ([TransactionId], [AccountNumber], [Amount], [DiscountedAmount], [Rate], [TransactionDate]) VALUES (4, N'3344659907', CAST(258123.00 AS Decimal(18, 2)), CAST(232310.70 AS Decimal(18, 2)), CAST(10.00 AS Decimal(18, 2)), CAST(N'2022-01-28T00:00:00.000' AS DateTime))
GO
INSERT [dbo].[TransactionData] ([TransactionId], [AccountNumber], [Amount], [DiscountedAmount], [Rate], [TransactionDate]) VALUES (5, N'2311159703', CAST(489473.00 AS Decimal(18, 2)), CAST(440525.70 AS Decimal(18, 2)), CAST(10.00 AS Decimal(18, 2)), CAST(N'2022-01-31T00:00:00.000' AS DateTime))
GO
INSERT [dbo].[TransactionData] ([TransactionId], [AccountNumber], [Amount], [DiscountedAmount], [Rate], [TransactionDate]) VALUES (6, N'2344559774', CAST(104954.00 AS Decimal(18, 2)), CAST(94458.60 AS Decimal(18, 2)), CAST(10.00 AS Decimal(18, 2)), CAST(N'2022-02-01T00:00:00.000' AS DateTime))
GO
INSERT [dbo].[TransactionData] ([TransactionId], [AccountNumber], [Amount], [DiscountedAmount], [Rate], [TransactionDate]) VALUES (7, N'1344459859', CAST(198972.00 AS Decimal(18, 2)), CAST(179074.80 AS Decimal(18, 2)), CAST(10.00 AS Decimal(18, 2)), CAST(N'2022-02-03T00:00:00.000' AS DateTime))
GO
INSERT [dbo].[TransactionData] ([TransactionId], [AccountNumber], [Amount], [DiscountedAmount], [Rate], [TransactionDate]) VALUES (8, N'2311159242', CAST(277494.00 AS Decimal(18, 2)), CAST(249744.60 AS Decimal(18, 2)), CAST(10.00 AS Decimal(18, 2)), CAST(N'2022-02-05T00:00:00.000' AS DateTime))
GO
INSERT [dbo].[TransactionData] ([TransactionId], [AccountNumber], [Amount], [DiscountedAmount], [Rate], [TransactionDate]) VALUES (9, N'3344659907', CAST(432555.00 AS Decimal(18, 2)), CAST(389299.50 AS Decimal(18, 2)), CAST(10.00 AS Decimal(18, 2)), CAST(N'2022-02-10T00:00:00.000' AS DateTime))
GO
INSERT [dbo].[TransactionData] ([TransactionId], [AccountNumber], [Amount], [DiscountedAmount], [Rate], [TransactionDate]) VALUES (10, N'2344559713', CAST(165376.00 AS Decimal(18, 2)), CAST(148838.40 AS Decimal(18, 2)), CAST(10.00 AS Decimal(18, 2)), CAST(N'2022-02-20T00:00:00.000' AS DateTime))
GO
INSERT [dbo].[TransactionData] ([TransactionId], [AccountNumber], [Amount], [DiscountedAmount], [Rate], [TransactionDate]) VALUES (11, N'3344659380', CAST(401855.00 AS Decimal(18, 2)), CAST(361669.50 AS Decimal(18, 2)), CAST(10.00 AS Decimal(18, 2)), CAST(N'2022-02-21T00:00:00.000' AS DateTime))
GO
INSERT [dbo].[TransactionData] ([TransactionId], [AccountNumber], [Amount], [DiscountedAmount], [Rate], [TransactionDate]) VALUES (12, N'3344659440', CAST(41400.00 AS Decimal(18, 2)), CAST(37260.00 AS Decimal(18, 2)), CAST(10.00 AS Decimal(18, 2)), CAST(N'2022-02-21T00:00:00.000' AS DateTime))
GO
INSERT [dbo].[TransactionData] ([TransactionId], [AccountNumber], [Amount], [DiscountedAmount], [Rate], [TransactionDate]) VALUES (13, N'2311159447', CAST(369185.00 AS Decimal(18, 2)), CAST(332266.50 AS Decimal(18, 2)), CAST(10.00 AS Decimal(18, 2)), CAST(N'2022-02-27T00:00:00.000' AS DateTime))
GO
INSERT [dbo].[TransactionData] ([TransactionId], [AccountNumber], [Amount], [DiscountedAmount], [Rate], [TransactionDate]) VALUES (14, N'3344659380', CAST(208404.00 AS Decimal(18, 2)), CAST(187563.60 AS Decimal(18, 2)), CAST(10.00 AS Decimal(18, 2)), CAST(N'2022-03-06T00:00:00.000' AS DateTime))
GO
INSERT [dbo].[TransactionData] ([TransactionId], [AccountNumber], [Amount], [DiscountedAmount], [Rate], [TransactionDate]) VALUES (15, N'2311159609', CAST(389846.00 AS Decimal(18, 2)), CAST(350861.40 AS Decimal(18, 2)), CAST(10.00 AS Decimal(18, 2)), CAST(N'2022-03-07T00:00:00.000' AS DateTime))
GO
INSERT [dbo].[TransactionData] ([TransactionId], [AccountNumber], [Amount], [DiscountedAmount], [Rate], [TransactionDate]) VALUES (16, N'1344459411', CAST(430892.00 AS Decimal(18, 2)), CAST(387802.80 AS Decimal(18, 2)), CAST(10.00 AS Decimal(18, 2)), CAST(N'2022-03-12T00:00:00.000' AS DateTime))
GO
INSERT [dbo].[TransactionData] ([TransactionId], [AccountNumber], [Amount], [DiscountedAmount], [Rate], [TransactionDate]) VALUES (17, N'1344459859', CAST(443412.00 AS Decimal(18, 2)), CAST(399070.80 AS Decimal(18, 2)), CAST(10.00 AS Decimal(18, 2)), CAST(N'2022-03-13T00:00:00.000' AS DateTime))
GO
INSERT [dbo].[TransactionData] ([TransactionId], [AccountNumber], [Amount], [DiscountedAmount], [Rate], [TransactionDate]) VALUES (18, N'1344459312', CAST(193482.00 AS Decimal(18, 2)), CAST(174133.80 AS Decimal(18, 2)), CAST(10.00 AS Decimal(18, 2)), CAST(N'2022-03-14T00:00:00.000' AS DateTime))
GO
INSERT [dbo].[TransactionData] ([TransactionId], [AccountNumber], [Amount], [DiscountedAmount], [Rate], [TransactionDate]) VALUES (19, N'2344559713', CAST(129521.00 AS Decimal(18, 2)), CAST(116568.90 AS Decimal(18, 2)), CAST(10.00 AS Decimal(18, 2)), CAST(N'2022-03-18T00:00:00.000' AS DateTime))
GO
INSERT [dbo].[TransactionData] ([TransactionId], [AccountNumber], [Amount], [DiscountedAmount], [Rate], [TransactionDate]) VALUES (20, N'3344659556', CAST(456461.00 AS Decimal(18, 2)), CAST(410814.90 AS Decimal(18, 2)), CAST(10.00 AS Decimal(18, 2)), CAST(N'2022-03-31T00:00:00.000' AS DateTime))
GO
INSERT [dbo].[TransactionData] ([TransactionId], [AccountNumber], [Amount], [DiscountedAmount], [Rate], [TransactionDate]) VALUES (21, N'1344459859', CAST(498308.00 AS Decimal(18, 2)), CAST(448477.20 AS Decimal(18, 2)), CAST(10.00 AS Decimal(18, 2)), CAST(N'2022-04-01T00:00:00.000' AS DateTime))
GO
INSERT [dbo].[TransactionData] ([TransactionId], [AccountNumber], [Amount], [DiscountedAmount], [Rate], [TransactionDate]) VALUES (22, N'2311159447', CAST(171916.00 AS Decimal(18, 2)), CAST(154724.40 AS Decimal(18, 2)), CAST(10.00 AS Decimal(18, 2)), CAST(N'2022-04-10T00:00:00.000' AS DateTime))
GO
INSERT [dbo].[TransactionData] ([TransactionId], [AccountNumber], [Amount], [DiscountedAmount], [Rate], [TransactionDate]) VALUES (23, N'2344559209', CAST(479889.00 AS Decimal(18, 2)), CAST(431900.10 AS Decimal(18, 2)), CAST(10.00 AS Decimal(18, 2)), CAST(N'2022-04-14T00:00:00.000' AS DateTime))
GO
INSERT [dbo].[TransactionData] ([TransactionId], [AccountNumber], [Amount], [DiscountedAmount], [Rate], [TransactionDate]) VALUES (24, N'2344559772', CAST(195904.00 AS Decimal(18, 2)), CAST(176313.60 AS Decimal(18, 2)), CAST(10.00 AS Decimal(18, 2)), CAST(N'2022-04-16T00:00:00.000' AS DateTime))
GO
INSERT [dbo].[TransactionData] ([TransactionId], [AccountNumber], [Amount], [DiscountedAmount], [Rate], [TransactionDate]) VALUES (25, N'1344459312', CAST(23570.00 AS Decimal(18, 2)), CAST(21213.00 AS Decimal(18, 2)), CAST(10.00 AS Decimal(18, 2)), CAST(N'2022-04-22T00:00:00.000' AS DateTime))
GO
INSERT [dbo].[TransactionData] ([TransactionId], [AccountNumber], [Amount], [DiscountedAmount], [Rate], [TransactionDate]) VALUES (26, N'2311159447', CAST(68497.00 AS Decimal(18, 2)), CAST(61647.30 AS Decimal(18, 2)), CAST(10.00 AS Decimal(18, 2)), CAST(N'2022-04-22T00:00:00.000' AS DateTime))
GO
INSERT [dbo].[TransactionData] ([TransactionId], [AccountNumber], [Amount], [DiscountedAmount], [Rate], [TransactionDate]) VALUES (27, N'2311159703', CAST(391091.00 AS Decimal(18, 2)), CAST(351981.90 AS Decimal(18, 2)), CAST(10.00 AS Decimal(18, 2)), CAST(N'2022-04-23T00:00:00.000' AS DateTime))
GO
INSERT [dbo].[TransactionData] ([TransactionId], [AccountNumber], [Amount], [DiscountedAmount], [Rate], [TransactionDate]) VALUES (28, N'2311159703', CAST(205833.00 AS Decimal(18, 2)), CAST(185249.70 AS Decimal(18, 2)), CAST(10.00 AS Decimal(18, 2)), CAST(N'2022-05-01T00:00:00.000' AS DateTime))
GO
INSERT [dbo].[TransactionData] ([TransactionId], [AccountNumber], [Amount], [DiscountedAmount], [Rate], [TransactionDate]) VALUES (29, N'3344659440', CAST(146636.00 AS Decimal(18, 2)), CAST(131972.40 AS Decimal(18, 2)), CAST(10.00 AS Decimal(18, 2)), CAST(N'2022-05-08T00:00:00.000' AS DateTime))
GO
INSERT [dbo].[TransactionData] ([TransactionId], [AccountNumber], [Amount], [DiscountedAmount], [Rate], [TransactionDate]) VALUES (30, N'1344459578', CAST(306730.00 AS Decimal(18, 2)), CAST(276057.00 AS Decimal(18, 2)), CAST(10.00 AS Decimal(18, 2)), CAST(N'2022-05-11T00:00:00.000' AS DateTime))
GO
INSERT [dbo].[TransactionData] ([TransactionId], [AccountNumber], [Amount], [DiscountedAmount], [Rate], [TransactionDate]) VALUES (31, N'2311159609', CAST(126727.00 AS Decimal(18, 2)), CAST(114054.30 AS Decimal(18, 2)), CAST(10.00 AS Decimal(18, 2)), CAST(N'2022-05-14T00:00:00.000' AS DateTime))
GO
INSERT [dbo].[TransactionData] ([TransactionId], [AccountNumber], [Amount], [DiscountedAmount], [Rate], [TransactionDate]) VALUES (32, N'2344559774', CAST(190538.00 AS Decimal(18, 2)), CAST(171484.20 AS Decimal(18, 2)), CAST(10.00 AS Decimal(18, 2)), CAST(N'2022-05-25T00:00:00.000' AS DateTime))
GO
INSERT [dbo].[TransactionData] ([TransactionId], [AccountNumber], [Amount], [DiscountedAmount], [Rate], [TransactionDate]) VALUES (33, N'2344559209', CAST(82695.00 AS Decimal(18, 2)), CAST(74425.50 AS Decimal(18, 2)), CAST(10.00 AS Decimal(18, 2)), CAST(N'2022-05-29T00:00:00.000' AS DateTime))
GO
INSERT [dbo].[TransactionData] ([TransactionId], [AccountNumber], [Amount], [DiscountedAmount], [Rate], [TransactionDate]) VALUES (34, N'1344459578', CAST(26317.00 AS Decimal(18, 2)), CAST(23685.30 AS Decimal(18, 2)), CAST(10.00 AS Decimal(18, 2)), CAST(N'2022-06-04T00:00:00.000' AS DateTime))
GO
INSERT [dbo].[TransactionData] ([TransactionId], [AccountNumber], [Amount], [DiscountedAmount], [Rate], [TransactionDate]) VALUES (35, N'2344559772', CAST(269853.00 AS Decimal(18, 2)), CAST(242867.70 AS Decimal(18, 2)), CAST(10.00 AS Decimal(18, 2)), CAST(N'2022-06-07T00:00:00.000' AS DateTime))
GO
INSERT [dbo].[TransactionData] ([TransactionId], [AccountNumber], [Amount], [DiscountedAmount], [Rate], [TransactionDate]) VALUES (36, N'2344559774', CAST(277054.00 AS Decimal(18, 2)), CAST(249348.60 AS Decimal(18, 2)), CAST(10.00 AS Decimal(18, 2)), CAST(N'2022-06-17T00:00:00.000' AS DateTime))
GO
INSERT [dbo].[TransactionData] ([TransactionId], [AccountNumber], [Amount], [DiscountedAmount], [Rate], [TransactionDate]) VALUES (37, N'2311159609', CAST(495589.00 AS Decimal(18, 2)), CAST(446030.10 AS Decimal(18, 2)), CAST(10.00 AS Decimal(18, 2)), CAST(N'2022-06-19T00:00:00.000' AS DateTime))
GO
INSERT [dbo].[TransactionData] ([TransactionId], [AccountNumber], [Amount], [DiscountedAmount], [Rate], [TransactionDate]) VALUES (38, N'2311159242', CAST(321260.00 AS Decimal(18, 2)), CAST(289134.00 AS Decimal(18, 2)), CAST(10.00 AS Decimal(18, 2)), CAST(N'2022-06-23T00:00:00.000' AS DateTime))
GO
INSERT [dbo].[TransactionData] ([TransactionId], [AccountNumber], [Amount], [DiscountedAmount], [Rate], [TransactionDate]) VALUES (39, N'3344659556', CAST(499908.00 AS Decimal(18, 2)), CAST(449917.20 AS Decimal(18, 2)), CAST(10.00 AS Decimal(18, 2)), CAST(N'2022-06-30T00:00:00.000' AS DateTime))
GO
INSERT [dbo].[TransactionData] ([TransactionId], [AccountNumber], [Amount], [DiscountedAmount], [Rate], [TransactionDate]) VALUES (40, N'2344559772', CAST(386089.00 AS Decimal(18, 2)), CAST(347480.10 AS Decimal(18, 2)), CAST(10.00 AS Decimal(18, 2)), CAST(N'2022-07-06T00:00:00.000' AS DateTime))
GO
INSERT [dbo].[TransactionData] ([TransactionId], [AccountNumber], [Amount], [DiscountedAmount], [Rate], [TransactionDate]) VALUES (41, N'1344459859', CAST(295635.00 AS Decimal(18, 2)), CAST(266071.50 AS Decimal(18, 2)), CAST(10.00 AS Decimal(18, 2)), CAST(N'2022-07-06T00:00:00.000' AS DateTime))
GO
INSERT [dbo].[TransactionData] ([TransactionId], [AccountNumber], [Amount], [DiscountedAmount], [Rate], [TransactionDate]) VALUES (42, N'3344659440', CAST(108404.00 AS Decimal(18, 2)), CAST(97563.60 AS Decimal(18, 2)), CAST(10.00 AS Decimal(18, 2)), CAST(N'2022-07-15T00:00:00.000' AS DateTime))
GO
INSERT [dbo].[TransactionData] ([TransactionId], [AccountNumber], [Amount], [DiscountedAmount], [Rate], [TransactionDate]) VALUES (43, N'2311159447', CAST(445913.00 AS Decimal(18, 2)), CAST(401321.70 AS Decimal(18, 2)), CAST(10.00 AS Decimal(18, 2)), CAST(N'2022-07-16T00:00:00.000' AS DateTime))
GO
INSERT [dbo].[TransactionData] ([TransactionId], [AccountNumber], [Amount], [DiscountedAmount], [Rate], [TransactionDate]) VALUES (44, N'3344659440', CAST(103910.00 AS Decimal(18, 2)), CAST(93519.00 AS Decimal(18, 2)), CAST(10.00 AS Decimal(18, 2)), CAST(N'2022-07-20T00:00:00.000' AS DateTime))
GO
INSERT [dbo].[TransactionData] ([TransactionId], [AccountNumber], [Amount], [DiscountedAmount], [Rate], [TransactionDate]) VALUES (45, N'3344659380', CAST(255057.00 AS Decimal(18, 2)), CAST(229551.30 AS Decimal(18, 2)), CAST(10.00 AS Decimal(18, 2)), CAST(N'2022-07-22T00:00:00.000' AS DateTime))
GO
