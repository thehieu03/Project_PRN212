USE [ProjectPrn211]
GO
/****** Object:  Table [dbo].[Author]    Script Date: 20/10/2024 3:52:04 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Author](
	[author_id] [int] IDENTITY(1,1) NOT NULL,
	[author_name] [nvarchar](50) NULL,
 CONSTRAINT [PK_Author] PRIMARY KEY CLUSTERED 
(
	[author_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Book]    Script Date: 20/10/2024 3:52:04 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Book](
	[book_id] [int] IDENTITY(1,1) NOT NULL,
	[book_name] [nvarchar](50) NULL,
	[book_img] [nvarchar](max) NULL,
	[book_description] [nvarchar](500) NULL,
	[author_id] [int] NULL,
	[quantity] [int] NULL,
	[category_id] [int] NULL,
 CONSTRAINT [PK_Book] PRIMARY KEY CLUSTERED 
(
	[book_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[BookBorrowingRegistrationForm]    Script Date: 20/10/2024 3:52:04 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BookBorrowingRegistrationForm](
	[book_registration_form] [int] IDENTITY(1,1) NOT NULL,
	[id] [int] NULL,
	[book_id] [int] NULL,
	[loan_borowing] [date] NULL,
	[payment_date] [date] NULL,
 CONSTRAINT [PK_BookBorrowingRegistrationForm] PRIMARY KEY CLUSTERED 
(
	[book_registration_form] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CategoryBook]    Script Date: 20/10/2024 3:52:04 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CategoryBook](
	[category_id] [int] NOT NULL,
	[category_name] [nvarchar](255) NULL,
 CONSTRAINT [PK_CategoryBook] PRIMARY KEY CLUSTERED 
(
	[category_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LateFee]    Script Date: 20/10/2024 3:52:04 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LateFee](
	[lateFree_id] [int] IDENTITY(1,1) NOT NULL,
	[id] [int] NULL,
	[book_registration_form] [int] NULL,
	[fine_amount] [float] NULL,
	[due_date] [date] NULL,
 CONSTRAINT [PK_LateFee] PRIMARY KEY CLUSTERED 
(
	[lateFree_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 20/10/2024 3:52:04 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[user_name] [nvarchar](50) NULL,
	[pass_word] [nvarchar](max) NULL,
	[email] [nvarchar](50) NULL,
	[role_id] [int] NULL,
	[user_address] [nvarchar](100) NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE [dbo].[Book]  WITH CHECK ADD  CONSTRAINT [FK_Book_Author] FOREIGN KEY([author_id])
REFERENCES [dbo].[Author] ([author_id])
GO
ALTER TABLE [dbo].[Book] CHECK CONSTRAINT [FK_Book_Author]
GO
ALTER TABLE [dbo].[Book]  WITH CHECK ADD  CONSTRAINT [FK_Book_CategoryBook] FOREIGN KEY([category_id])
REFERENCES [dbo].[CategoryBook] ([category_id])
GO
ALTER TABLE [dbo].[Book] CHECK CONSTRAINT [FK_Book_CategoryBook]
GO
ALTER TABLE [dbo].[BookBorrowingRegistrationForm]  WITH CHECK ADD  CONSTRAINT [FK_BookBorrowingRegistrationForm_Book] FOREIGN KEY([book_id])
REFERENCES [dbo].[Book] ([book_id])
GO
ALTER TABLE [dbo].[BookBorrowingRegistrationForm] CHECK CONSTRAINT [FK_BookBorrowingRegistrationForm_Book]
GO
ALTER TABLE [dbo].[BookBorrowingRegistrationForm]  WITH CHECK ADD  CONSTRAINT [FK_BookBorrowingRegistrationForm_User] FOREIGN KEY([id])
REFERENCES [dbo].[User] ([id])
GO
ALTER TABLE [dbo].[BookBorrowingRegistrationForm] CHECK CONSTRAINT [FK_BookBorrowingRegistrationForm_User]
GO
ALTER TABLE [dbo].[LateFee]  WITH CHECK ADD  CONSTRAINT [FK_LateFee_BookBorrowingRegistrationForm] FOREIGN KEY([book_registration_form])
REFERENCES [dbo].[BookBorrowingRegistrationForm] ([book_registration_form])
GO
ALTER TABLE [dbo].[LateFee] CHECK CONSTRAINT [FK_LateFee_BookBorrowingRegistrationForm]
GO
ALTER TABLE [dbo].[LateFee]  WITH CHECK ADD  CONSTRAINT [FK_LateFee_User] FOREIGN KEY([id])
REFERENCES [dbo].[User] ([id])
GO
ALTER TABLE [dbo].[LateFee] CHECK CONSTRAINT [FK_LateFee_User]
GO
