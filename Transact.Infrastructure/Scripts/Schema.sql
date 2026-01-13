USE [DotnetPracticalInterviewAssessment]
GO
/****** Object:  Table [dbo].[AccountData]    Script Date: 2/3/2025 10:19:08 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AccountData](
	[AccountId] [int] NOT NULL,
	[AccountNumber] [varchar](10) NOT NULL,
	[CustomerId] [bigint] NOT NULL,
	[AccountBalance] [decimal](18, 2) NOT NULL,
	[AccountOpenDate] [datetime] NOT NULL,
 CONSTRAINT [PK_AccountData] PRIMARY KEY CLUSTERED 
(
	[AccountId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CustomerData]    Script Date: 2/3/2025 10:19:08 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CustomerData](
	[CustomerId] [bigint] NOT NULL,
	[CustomerName] [varchar](100) NOT NULL,
	[CustomerType] [varchar](50) NOT NULL,
	[DateCreated] [datetime] NOT NULL,
 CONSTRAINT [PK_CustomerData] PRIMARY KEY CLUSTERED 
(
	[CustomerId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TransactionData]    Script Date: 2/3/2025 10:19:08 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TransactionData](
	[TransactionId] [int] NOT NULL,
	[AccountNumber] [varchar](10) NOT NULL,
	[Amount] [decimal](18, 2) NOT NULL,
	[DiscountedAmount] [decimal](18, 2) NOT NULL,
	[Rate] [decimal](18, 2) NOT NULL,
	[TransactionDate] [datetime] NOT NULL,
 CONSTRAINT [PK_TransactionData] PRIMARY KEY CLUSTERED 
(
	[TransactionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[AccountData]  WITH CHECK ADD  CONSTRAINT [FK_AccountData_CustomerData] FOREIGN KEY([CustomerId])
REFERENCES [dbo].[CustomerData] ([CustomerId])
GO
ALTER TABLE [dbo].[AccountData] CHECK CONSTRAINT [FK_AccountData_CustomerData]
GO
USE [master]
GO
ALTER DATABASE [DotnetPracticalInterviewAssessment] SET  READ_WRITE 
GO
