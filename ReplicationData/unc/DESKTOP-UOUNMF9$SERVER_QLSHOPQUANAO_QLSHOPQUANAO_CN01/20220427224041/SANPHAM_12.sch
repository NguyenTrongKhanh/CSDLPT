drop Table [dbo].[SANPHAM]
go
SET ANSI_PADDING OFF
go

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SANPHAM](
	[MaSP] [int] IDENTITY(1,1) NOT FOR REPLICATION NOT NULL,
	[TenSP] [nvarchar](max) NULL,
	[HinhAnh] [nvarchar](max) NULL,
	[TrangThai] [nvarchar](max) NULL,
	[DonGia] [int] NULL,
	[SoLuongTon] [int] NULL,
	[MaChatLieu] [int] NULL,
	[MaLoai] [int] NULL,
	[MaNSX] [int] NULL,
	[MaCN] [nvarchar](10) NULL,
	[rowguid] [uniqueidentifier] ROWGUIDCOL  NOT NULL
)

GO
ALTER TABLE [dbo].[SANPHAM] ADD  CONSTRAINT [MSmerge_df_rowguid_84BC04CDB9E1484EBD879258280CC10B]  DEFAULT (newsequentialid()) FOR [rowguid]
GO
SET ANSI_NULLS ON

go

SET QUOTED_IDENTIFIER ON

go

ALTER TABLE [dbo].[SANPHAM] ADD  CONSTRAINT [PK_SANPHAM] PRIMARY KEY CLUSTERED 
(
	[MaSP] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
