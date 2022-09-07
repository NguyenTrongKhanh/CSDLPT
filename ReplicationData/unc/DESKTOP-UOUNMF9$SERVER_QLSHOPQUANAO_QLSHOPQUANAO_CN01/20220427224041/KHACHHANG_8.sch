drop Table [dbo].[KHACHHANG]
go
SET ANSI_PADDING OFF
go

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[KHACHHANG](
	[MaKH] [int] IDENTITY(1,1) NOT FOR REPLICATION NOT NULL,
	[TenKH] [nvarchar](max) NULL,
	[SDT] [nvarchar](10) NULL,
	[DiaChi] [nvarchar](max) NULL,
	[MaLoaiKH] [int] NULL,
	[MaCN] [nvarchar](10) NULL,
	[rowguid] [uniqueidentifier] ROWGUIDCOL  NOT NULL
)

GO
ALTER TABLE [dbo].[KHACHHANG] ADD  CONSTRAINT [MSmerge_df_rowguid_73FB837D882D4C5384A45CAC72E2EF24]  DEFAULT (newsequentialid()) FOR [rowguid]
GO
SET ANSI_NULLS ON

go

SET QUOTED_IDENTIFIER ON

go

ALTER TABLE [dbo].[KHACHHANG] ADD  CONSTRAINT [PK_KhachHang] PRIMARY KEY CLUSTERED 
(
	[MaKH] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
