USE [KnockoutDemo]
GO
/***** Object: Table [dbo].[User] Script Date: 14/04/2021 9:10:50 am *****/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
[UserId] [int] NOT NULL,
[FirstName] [nvarchar](50) NOT NULL,
[LastName] [nvarchar](50) NOT NULL,
[Age] [int] NOT NULL,
CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED
(
[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
USE [master]
GO
ALTER DATABASE [KnockoutDemo] SET READ_WRITE
GO