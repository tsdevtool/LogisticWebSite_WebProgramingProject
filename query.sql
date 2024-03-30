CREATE DATABASE [Logistics]
GO
USE [Logistics]
GO
/****** Object:  Table [dbo].[BillOfLading]    Script Date: 3/25/2024 7:53:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BillOfLading](
	[BillID] [int] IDENTITY(1,1) NOT NULL,
	[BookingNo] [int] NOT NULL,
	[ShipID] [int] NULL,
	[ContainerID] [int] NOT NULL,
 CONSTRAINT [PK_Booking] PRIMARY KEY CLUSTERED 
(
	[BillID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[BookingInfomation]    Script Date: 3/25/2024 7:53:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BookingInfomation](
	[BookingNo] [int] IDENTITY(1,1) NOT NULL,
	[From] [nvarchar](200) NOT NULL,
	[To] [nvarchar](200) NOT NULL,
	[Commodity] [nvarchar](100) NOT NULL,
	[PriceOwner] [bit] NOT NULL,
	[ShippingDay] [date] NOT NULL,
	[CutOffSI] [date] NOT NULL,
	[CutOffVGM] [date] NOT NULL,
	[CutOffCY] [date] NOT NULL,
	[UserID] [int] NOT NULL,
 CONSTRAINT [PK_PackageInfomation] PRIMARY KEY CLUSTERED 
(
	[BookingNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Booking-WareHouse]    Script Date: 3/25/2024 7:53:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Booking-WareHouse](
	[No] [int] IDENTITY(1,1) NOT NULL,
	[BillID] [int] NOT NULL,
	[WhareHouseID] [int] NOT NULL,
	[Dayin] [date] NOT NULL,
 CONSTRAINT [PK_Booking-WhareHouse] PRIMARY KEY CLUSTERED 
(
	[No] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Container]    Script Date: 3/25/2024 7:53:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Container](
	[ContainerID] [int] NOT NULL,
	[CargoWeight] [float] NOT NULL,
	[ContainerSize] [nchar](10) NOT NULL,
	[NumberOfContainer] [tinyint] NOT NULL,
	[Type] [bit] NOT NULL,
	[PlaceToPickUp] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_Container] PRIMARY KEY CLUSTERED 
(
	[ContainerID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ContainerBillOfLading]    Script Date: 3/25/2024 7:53:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ContainerBillOfLading](
	[Container] [nchar](10) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CostsIncurred]    Script Date: 3/25/2024 7:53:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CostsIncurred](
	[CostsIncurredID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[DateCreate] [datetime] NOT NULL,
	[Price] [money] NOT NULL,
	[BillID] [int] NOT NULL,
 CONSTRAINT [PK_CostsIncurred] PRIMARY KEY CLUSTERED 
(
	[CostsIncurredID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Invoice]    Script Date: 3/25/2024 7:53:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Invoice](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[BillID] [int] NOT NULL,
	[CostsIncurredID] [int] NULL,
	[Surcharge] [money] NULL,
	[Total] [money] NOT NULL,
	[Status] [bit] NOT NULL,
 CONSTRAINT [PK_Bill] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Schedule]    Script Date: 3/25/2024 7:53:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Schedule](
	[ScheduleId] [int] IDENTITY(1,1) NOT NULL,
	[POL] [nvarchar](80) NOT NULL,
	[POD] [nvarchar](80) NOT NULL,
	[DayGo] [date] NOT NULL,
	[DayCome] [date] NOT NULL,
	[TransitTime] [tinyint] NOT NULL,
 CONSTRAINT [PK_Schedule] PRIMARY KEY CLUSTERED 
(
	[ScheduleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Ship]    Script Date: 3/25/2024 7:53:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Ship](
	[ShipID] [int] IDENTITY(1,1) NOT NULL,
	[ScheduleId] [int] NOT NULL,
	[ShipCode] [nchar](6) NOT NULL,
	[ShipName] [nvarchar](50) NOT NULL,
	[Status] [bit] NOT NULL,
 CONSTRAINT [PK_Ship] PRIMARY KEY CLUSTERED 
(
	[ShipID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tracking]    Script Date: 3/25/2024 7:53:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tracking](
	[TrackingID] [int] IDENTITY(1,1) NOT NULL,
	[BillID] [int] NOT NULL,
 CONSTRAINT [PK_Tracking] PRIMARY KEY CLUSTERED 
(
	[TrackingID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 3/25/2024 7:53:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[UserID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[EmailAddress] [varchar](100) NOT NULL,
	[Country/Region] [nvarchar](30) NOT NULL,
	[PhoneNumber] [nchar](10) NOT NULL,
	[Password] [varchar](20) NOT NULL,
	[TypeOfAccount] [bit] NOT NULL,
 CONSTRAINT [PK_UserSignUp] PRIMARY KEY CLUSTERED 
(
	[UserID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[WareHouse]    Script Date: 3/25/2024 7:53:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[WareHouse](
	[WhareHouseID] [int] IDENTITY(1,1) NOT NULL,
	[Price] [money] NULL,
	[Type] [bit] NOT NULL,
 CONSTRAINT [PK_WhareHouse] PRIMARY KEY CLUSTERED 
(
	[WhareHouseID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[BillOfLading]  WITH CHECK ADD  CONSTRAINT [FK_BillOfLading_BookingInfomation] FOREIGN KEY([BookingNo])
REFERENCES [dbo].[BookingInfomation] ([BookingNo])
GO
ALTER TABLE [dbo].[BillOfLading] CHECK CONSTRAINT [FK_BillOfLading_BookingInfomation]
GO
ALTER TABLE [dbo].[BillOfLading]  WITH CHECK ADD  CONSTRAINT [FK_BillOfLading_Container1] FOREIGN KEY([ContainerID])
REFERENCES [dbo].[Container] ([ContainerID])
GO
ALTER TABLE [dbo].[BillOfLading] CHECK CONSTRAINT [FK_BillOfLading_Container1]
GO
ALTER TABLE [dbo].[BillOfLading]  WITH CHECK ADD  CONSTRAINT [FK_BillOfLading_Ship] FOREIGN KEY([ShipID])
REFERENCES [dbo].[Ship] ([ShipID])
GO
ALTER TABLE [dbo].[BillOfLading] CHECK CONSTRAINT [FK_BillOfLading_Ship]
GO
ALTER TABLE [dbo].[BookingInfomation]  WITH CHECK ADD  CONSTRAINT [FK_BookingInfomation_User] FOREIGN KEY([UserID])
REFERENCES [dbo].[User] ([UserID])
GO
ALTER TABLE [dbo].[BookingInfomation] CHECK CONSTRAINT [FK_BookingInfomation_User]
GO
ALTER TABLE [dbo].[Booking-WareHouse]  WITH CHECK ADD  CONSTRAINT [FK_Booking-WhareHouse_Booking] FOREIGN KEY([BillID])
REFERENCES [dbo].[BillOfLading] ([BillID])
GO
ALTER TABLE [dbo].[Booking-WareHouse] CHECK CONSTRAINT [FK_Booking-WhareHouse_Booking]
GO
ALTER TABLE [dbo].[Booking-WareHouse]  WITH CHECK ADD  CONSTRAINT [FK_Booking-WhareHouse_WhareHouse] FOREIGN KEY([WhareHouseID])
REFERENCES [dbo].[WareHouse] ([WhareHouseID])
GO
ALTER TABLE [dbo].[Booking-WareHouse] CHECK CONSTRAINT [FK_Booking-WhareHouse_WhareHouse]
GO
ALTER TABLE [dbo].[CostsIncurred]  WITH CHECK ADD  CONSTRAINT [FK_CostsIncurred_BillOfLading] FOREIGN KEY([BillID])
REFERENCES [dbo].[BillOfLading] ([BillID])
GO
ALTER TABLE [dbo].[CostsIncurred] CHECK CONSTRAINT [FK_CostsIncurred_BillOfLading]
GO
ALTER TABLE [dbo].[Invoice]  WITH CHECK ADD  CONSTRAINT [FK_Invoice_BillOfLading] FOREIGN KEY([BillID])
REFERENCES [dbo].[BillOfLading] ([BillID])
GO
ALTER TABLE [dbo].[Invoice] CHECK CONSTRAINT [FK_Invoice_BillOfLading]
GO
ALTER TABLE [dbo].[Invoice]  WITH CHECK ADD  CONSTRAINT [FK_Invoice_CostsIncurred] FOREIGN KEY([CostsIncurredID])
REFERENCES [dbo].[CostsIncurred] ([CostsIncurredID])
GO
ALTER TABLE [dbo].[Invoice] CHECK CONSTRAINT [FK_Invoice_CostsIncurred]
GO
ALTER TABLE [dbo].[Ship]  WITH CHECK ADD  CONSTRAINT [FK_Ship_Schedule] FOREIGN KEY([ScheduleId])
REFERENCES [dbo].[Schedule] ([ScheduleId])
GO
ALTER TABLE [dbo].[Ship] CHECK CONSTRAINT [FK_Ship_Schedule]
GO
ALTER TABLE [dbo].[Tracking]  WITH CHECK ADD  CONSTRAINT [FK_Tracking_BillOfLading] FOREIGN KEY([BillID])
REFERENCES [dbo].[BillOfLading] ([BillID])
GO
ALTER TABLE [dbo].[Tracking] CHECK CONSTRAINT [FK_Tracking_BillOfLading]
GO
