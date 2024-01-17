GO
create database QLSV

GO
use QLSV

---================TẠO ROLE=====================================---
-----Tạo role để nhóm các tài khoản dành cho giảng viên vào role GiangVien, dành cho sinh viên vào role SinhVien
GO
CREATE ROLE GiangVien
CREATE ROLE SinhVien

---================TẠO PROCEDURE=====================================---
GO
CREATE FUNCTION dbo.charR(@str nvarchar(50))
RETURNS VARCHAR(50)
AS
BEGIN
	SET @str = REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE
	(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE
	(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE
	(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE
	(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE
	(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE
	(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE
	(REPLACE(@str,'é','e'),'ê','e'),'h','h'),'è','e'),'É','E'),'È','E'),
	'Ê','E'),'Ẹ','E'),'ọ','o'),'Ð','D'),'â','a'),'à','a'),'á','a'),'ã','a'),
	'æ','a'),'à','a'),'å','a'),'Å','A'),'À','A'),'Á','A'),'Â','A'),'Ã','A'),
	'Æ','A'),'ä','a'),'Ä','A'),'ị','i'),'î','i'),'ì','i'),'í','i'),'Ì','I'),
	'Í','I'),'Î','I'),'Ï','I'),'ô','o'),'ò','o'),'ó','o'),'õ','o'),'ø','o'),
	'Ò','O'),'Ó','O'),'Ô','O'),'Õ','O'),'Ø','O'),'ö','o'),'Ö','O'),'û','u'),
	'ù','u'),'ú','u'),'Ù','U'),'Ú','U'),'Û','U'),'Ü','U'),'ü','u'),'ñ','n'),
	'Ñ','N'),'Ç','C'),'ç','c'),'ý','y'),'ÿ','y'),'Ý','Y'),'þ','T'),'Þ','t')
	RETURN @str
END

GO
CREATE PROCEDURE [dbo].[ProcINSERTGiangVien] @CMTND varchar(15), @ho nvarchar(15), @dem nvarchar(50),  @ten nvarchar(15), @mavien char(15), @ngaybdgd char(15)
AS
BEGIN
	DECLARE @mgv varchar(6)
	if (select count(MaGV) from tblGiangVien) = 0 
		set @mgv = '0'
	else select @mgv = max(right(MaGV, 4)) from tblGiangVien
		SELECT @mgv = CASE
			WHEN @mgv >= 0 and @mgv < 9 THEN 'GV000' + CONVERT(VARCHAR, CONVERT(INT, @mgv) + 1)
			WHEN @mgv >= 9 THEN  'GV00' + CONVERT(VARCHAR, CONVERT(INT, @mgv) + 1)
			WHEN @mgv >= 99 THEN 'GV0' + CONVERT(VARCHAR, CONVERT(INT, @mgv) + 1)
			WHEN @mgv >= 999 THEN 'GV' + CONVERT(VARCHAR, CONVERT(INT, @mgv) + 1)
		END

----------------------------------------Tạo email
	DECLARE @email varchar(50)
	DECLARE @tendem2 nvarchar(50)
	SELECT @tendem2 = LTRIM(dbo.charR(@dem))
	set @email = LEFT(@tendem2,1)
	WHILE(CHARINDEX(' ', @tendem2)) <> 0 
	BEGIN
	SET @email = @email + SUBSTRING(@tendem2, CHARINDEX(' ', @tendem2)+1, 1) 
	SET @tendem2 = SUBSTRING(@tendem2, CHARINDEX(' ', @tendem2) + 1, LEN(@tendem2) - CHARINDEX(' ', @tendem2))
	END
	----------------
	SELECT @email = dbo.charR(@ten) + '.' + SUBSTRING(LTRIM(dbo.charR(@ho)), 1, 1) + @email + RIGHT(@mgv,6) +'@sis.huil.edu.vn'
	----------------

	INSERT INTO tblGiangVien(CMTND, Ho, Dem, Ten, MaVien, MaGV, Email, NgayBDGD)
	VALUES
	(@CMTND, @ho, @dem, @ten, @mavien, @mgv, @email, @ngaybdgd)
	
---------------------Tạo tài khoản cho giáo viên và add vào ROLE GiangVien
	DECLARE @check char(10)
	set @check = dbo.FuncCheckUser(@mgv, 'GiangVien') 
	IF(@check <> '1' )  ---------Check login vào user đã tồn tại chưa, 1 nghĩa là đã tồn tại
	BEGIN
		---Tạo login
		IF(@check = 'nologin')
		BEGIN
			Declare @LoginCreationScript as varchar(max);
			set @LoginCreationScript ='EXEC sp_addlogin [{mgv}], [{CMTND}], QLSV'
			set @LoginCreationScript=Replace(@LoginCreationScript, '{mgv}', @mgv)
			set @LoginCreationScript=Replace(@LoginCreationScript, '{CMTND}', @CMTND)
			Execute(@LoginCreationScript)
		END
		---Tạo user
		set @check = dbo.FuncCheckUser(@mgv, 'GiangVien')
		IF (@check = 'nouser')
		BEGIN
			Declare @UserCreationScript as varchar(max);
			set @UserCreationScript ='USE QLSV CREATE User [{mgv}] for LOGIN [{mgv}]'
			set @UserCreationScript =Replace(@UserCreationScript, '{mgv}', @mgv)		
			Execute(@UserCreationScript)
		END
		set @check = dbo.FuncCheckUser(@mgv, 'GiangVien')
		IF (@check = 'noaddrole')
		BEGIN
			Declare @AddMemberScript as varchar(max);
			set @AddMemberScript = 'ALTER ROLE GiangVien ADD MEMBER [{mgv}]'		
			set @AddMemberScript=Replace(@AddMemberScript, '{mgv}', @mgv)		
			Execute(@AddMemberScript)	
		END		
	END
END

GO
CREATE PROCEDURE [dbo].[ProcINSERTSinhVien]  @CMTND varchar(15), @ho nvarchar(15), @dem nvarchar(50),  @ten nvarchar(15), @manganh nvarchar(50), @MaLopSV char(15)
AS
BEGIN
	DECLARE @mssv varchar(8)
	if (select count(MSSV) from tblSinhVien) = 0 
		set @mssv = '0'
	else select @mssv = max(right(MSSV, 4)) from tblSinhVien
		SELECT @mssv = CASE
			WHEN @mssv >= 0 and @mssv < 9 THEN CONVERT(VARCHAR,year(GETDATE())) + '000' + CONVERT(VARCHAR, CONVERT(INT, @mssv) + 1)
			WHEN @mssv >= 9 THEN CONVERT(VARCHAR,year(GETDATE())) + '00' + CONVERT(VARCHAR, CONVERT(INT, @mssv) + 1)
			WHEN @mssv >= 99 THEN CONVERT(VARCHAR,year(GETDATE())) + '0' + CONVERT(VARCHAR, CONVERT(INT, @mssv) + 1)
			WHEN @mssv >= 999 THEN CONVERT(VARCHAR,year(GETDATE())) + CONVERT(VARCHAR, CONVERT(INT, @mssv) + 1)
	END
----------------------------------------Tạo email
	DECLARE @email varchar(50)
	DECLARE @tendem2 nvarchar(50)
	SELECT @tendem2 = LTRIM(dbo.charR(@dem))
	set @email = LEFT(@tendem2,1)
	WHILE(CHARINDEX(' ', @tendem2)) <> 0 
	BEGIN
	SET @email = @email + SUBSTRING(@tendem2, CHARINDEX(' ', @tendem2)+1, 1) 
	SET @tendem2 = SUBSTRING(@tendem2, CHARINDEX(' ', @tendem2) + 1, LEN(@tendem2) - CHARINDEX(' ', @tendem2))
	END
	----------------
	SELECT @email = dbo.charR(@ten) + '.' + SUBSTRING(LTRIM(dbo.charR(@ho)), 1, 1) + @email + RIGHT(@mssv,6) +'@sis.huil.edu.vn'
	----------------
	INSERT INTO tblSinhVien(CMTND, Ho, Dem, Ten, MaNganh, MaLopSV, MSSV, Email)
	VALUES
	(@CMTND, @ho, @dem, @ten, @manganh, @MaLopSV, @mssv, @email)

---------------------Tạo tài khoản cho sinh viên và add vào ROLE SinhVien
	DECLARE @check char(10)
	set @check = dbo.FuncCheckUser(@mssv, 'SinhVien') 
	IF(@check <> '1' )  ---------Check login vào user đã tồn tại chưa, 1 nghĩa là đã tồn tại
	BEGIN
		---Tạo login
		IF(@check = 'nologin')
		BEGIN
			Declare @LoginCreationScript as varchar(max);
			set @LoginCreationScript ='EXEC sp_addlogin [{mssv}], [{CMTND}], QLSV'
			set @LoginCreationScript=Replace(@LoginCreationScript, '{mssv}', @mssv)
			set @LoginCreationScript=Replace(@LoginCreationScript, '{CMTND}', @CMTND)
			Execute(@LoginCreationScript)
		END
		---Tạo user
		set @check = dbo.FuncCheckUser(@mssv, 'SinhVien')
		IF (@check = 'nouser')
		BEGIN
			Declare @UserCreationScript as varchar(max);
			set @UserCreationScript ='USE QLSV CREATE User [{mssv}] for LOGIN [{mssv}]'
			set @UserCreationScript =Replace(@UserCreationScript, '{mssv}', @mssv)		
			Execute(@UserCreationScript)
		END
		set @check = dbo.FuncCheckUser(@mssv, 'SinhVien')
		IF (@check = 'noaddrole')
		BEGIN
			Declare @AddMemberScript as varchar(max);
			set @AddMemberScript = 'ALTER ROLE SinhVien ADD MEMBER [{mssv}]'		
			set @AddMemberScript=Replace(@AddMemberScript, '{mssv}', @mssv)		
			Execute(@AddMemberScript)	
		END		
	END
END

---================TẠO BẢNG DỮ LIỆU=====================================---
-----Tạo bảng để lưu thông tin về các khoa/viện của trường-------tblKhoaVien--------
go
CREATE TABLE tblKhoaVien(
	MaVien char(15), 
	TenVien nvarchar(50),
	CONSTRAINT PK_KhoaVien PRIMARY KEY(MaVien)
)

-----Tạo bảng để lưu thông tin về các ngành trong khoa/viện-------tblNganh--------
go
CREATE TABLE tblNganh(
	MaNganh char(15), 
	TenNganh nvarchar(50),
	MaVien char(15),
	CONSTRAINT PK_Nganh PRIMARY KEY(MaNganh),
	CONSTRAINT FK_NganhMaVien FOREIGN KEY(MaVien) REFERENCES tblKhoaVien(MaVien)
)

------Tạo bảng để lưu thông tin về giảng viên-------tblGiangVien--------
go
CREATE TABLE tblGiangVien(
	MaGV char(7),
	Ho nvarchar(15),
	Dem nvarchar(50),
	Ten nvarchar(15),
	MaVien char(15),
	Email char(100),
	CMTND char(15),
	NgayBDGD date,
	NgaySinh date,	
	NoiSinh nvarchar(50),
	QuocTich nchar(100),
	DanToc nchar(100),
	GioiTinh nchar(4),
	SoTheBH char(15),
	DiaChi nvarchar(300),
	Email_thuongdung char(30),
	Sdt char(13),
	Ques nchar(300),
	Ans nchar(51),
	CONSTRAINT PK_GV PRIMARY KEY(MaGV),
	CONSTRAINT FK_GVVien FOREIGN KEY(MaVien) REFERENCES tblKhoaVien(MaVien)
)

------Tạo bảng để lưu thông tin về lớp của sinh viên-------tblLopSV--------
go
CREATE TABLE tblLopSV(
	MaLopSV char(15),
	TenLopSV nvarchar(100),
	GVPT char(7),
	CONSTRAINT PK_LopSV PRIMARY KEY(MaLopSV),
	CONSTRAINT FK_LopSVGVPT FOREIGN KEY(GVPT) REFERENCES tblGiangVien(MaGV)
)

-------Tạo bảng lưu thông tin Sinh viên---------tblSinhVien---------
go
CREATE TABLE tblSinhVien(
	MSSV char(9),
	Ho nvarchar(15),
	Dem nvarchar(50),
	Ten nvarchar(15),
	CMTND char(16),	
	Email char(100),
	MaNganh char(15),
	MaLopSV char(15),
	TrangThai nchar(20) constraint Trang_ThaiSV default N'Học',
	NgayNhapHoc date,
	NoiSinh nchar(100),
	QuocTich nchar(100),
	DanToc nchar(100),
	GioiTinh nchar(10),
	SoTheBH char(20),
	DiaChi nvarchar(300),
	Email_thuongdung char(30),
	NgaySinh date,
	Sdt char(12),
	SoThich nchar(50),
	NoiODK nchar(100),
	Ques nchar(300),
	Ans nchar(51),
	CONSTRAINT PK_SV PRIMARY KEY(MSSV),
	CONSTRAINT FK_SVMaLopSV FOREIGN KEY(MaLopSV) REFERENCES tblLopSV(MaLopSV),
	CONSTRAINT FK_SVMaNganh FOREIGN KEY(MaNganh) REFERENCES tblNganh(MaNganh)
)

------Tạo bảng để lưu thông tin về kỳ học-------tblKyHoc--------
go
CREATE TABLE tblKyHoc(
	KyHoc char(6),
	MSSV char(9),
	TCDK  smallint,		
	GPA	float,			
	DuNo char(15) default '0',
	DaTT char(15),
	NgayCapNhat date,
	CONSTRAINT PK_KH PRIMARY KEY(KyHoc, MSSV),
	CONSTRAINT PK_KHMSSV FOREIGN KEY(MSSV) REFERENCES tblSinhVien(MSSV)
)

------Tạo bảng để lưu thông tin về học phần-------tblHocPhan--------
go
CREATE TABLE tblHocPhan(
	MaHP char(15), 
	TenHP nvarchar(100),
	SoTC smallint,
	TCHP smallint,
	TrongSo char(4),
	Tien_1TCHP char(15),
	CONSTRAINT PK_HP PRIMARY KEY(MaHP),
)

------Tạo bảng để lưu thông tin về chương trình đào tạo của các ngành-------tblCTDT------
go
CREATE TABLE tblCTDT(
	MaNganh char(15), 
	MaHP char(15),
	CONSTRAINT PK_CTDT PRIMARY KEY(MaNganh, MaHP),
	CONSTRAINT FK_CTDTMaNganh FOREIGN KEY(MaNganh) REFERENCES tblNganh(MaNganh),
	CONSTRAINT FK_CTDTMAHP FOREIGN KEY(MaHP) REFERENCES tblHocPhan(MaHP)
)

-----Tạo bảng để lưu thông tin về các học phần được mở trong các kỳ học-------tblLopMo---
go
CREATE TABLE tblLopMo(
	KyHoc char(6),
	MaHP char(15),
	MaLop char(6), 
	MaLopBT char(6),
	Thu smallint,
	TGBD char(6),
	TGKT char(6),
	Kip nchar(6),
	Tuan char(30),
	Phong char(10),
	SLDK smallint default 0,
	SLMAX smallint,
	TrangThai nchar(30),
	CONSTRAINT PK_LopMo PRIMARY KEY(KyHoc, MaLopBT),
	CONSTRAINT PK_LopMoMaHP FOREIGN KEY(MaHP) REFERENCES tblHocPhan(MaHP)
)

------Tạo bảng để lưu thông tin về việc học tập của sinh viên-------tblHocTap--------
go
CREATE TABLE tblHocTap(
	KyHoc char(6),
	MSSV char(9), 
	MaLopBT char(6),
	DiemQT char(10),
	DiemThi char(10),
	TrangThaiDK nchar(30) default N'Đăng ký thất bại',
	CONSTRAINT PK_HT PRIMARY KEY(KyHoc, MSSV, MaLopBT),
	CONSTRAINT FK_HTMSSV FOREIGN KEY(MSSV) REFERENCES tblSinhVien(MSSV),
	CONSTRAINT FK_HTKHMaLopBT FOREIGN KEY(KyHoc, MaLopBT) REFERENCES tblLopMo(KyHoc, MaLopBT)
)

------Tạo bảng để lưu thông tin về việc giảng dạy của giảng viên-------tblGiangDay-------
go
CREATE TABLE tblGiangDay(
	KyHoc char(6),
	MaGV char(7), 
	MaLopBT char(6),
	CONSTRAINT PK_GD PRIMARY KEY(KyHoc, MaGV, MaLopBT),
	CONSTRAINT FK_GDMGV FOREIGN KEY(MaGV) REFERENCES tblGiangVien(MaGV),
	CONSTRAINT FK_GDKH_MaLopBT FOREIGN KEY(KyHoc, MaLopBT) REFERENCES tblLopMo(KyHoc, MaLopBT)
)

---================================FUNCTION==========================================---
---Function kiểm tra xem input có là chuỗi chứa toàn số hay k?----Để check sđt, CMTND----
GO
CREATE FUNCTION dbo.FuncCheckNumber(@str char(15))
RETURNS BIT
AS
BEGIN 
	DECLARE @i int, @char char(2), @check bit
	SET @str = RTRIM(LTRIM(@str))
	SET @i = 1
	SET @check = 1
	WHILE(@i <= LEN(@str))
		BEGIN
		SET @char = SUBSTRING(@str,@i,1)
		IF(ASCII(@char)<48 OR ASCII(@char)>57) 
		BEGIN
			SET @check = 0 
			BREAK
		END
		ELSE SET @i = @i + 1
		END
	RETURN @check
END

---=====================================VIEW======================================---
GO
CREATE VIEW ViewTTSV AS SELECT * FROM dbo.tblSinhVien
WHERE dbo.FuncCheckNumber(CMTND) <> 0 
AND dbo.FuncCheckNumber(Sdt) <> 0
WITH CHECK OPTION

GO
CREATE VIEW ViewTTHP AS SELECT * FROM dbo.tblHocPhan

--------Tính điểm học phần cho sinh viên--------
GO
CREATE FUNCTION [dbo].[FuncTinhDiemSo](@mssv char(9))
RETURNS FLOAT
AS
BEGIN
	DECLARE @DiemHP FLOAT
	IF(@mssv IS NULL) SET @DiemHP = 0
	ELSE
	SELECT @DiemHP = CONVERT(float, tblHocTap.DiemThi)* CONVERT(float, ViewTTHP.TrongSo) + CONVERT(float, tblHocTap.DiemQT)*(1-CONVERT(float,ViewTTHP.TrongSo))
	FROM tblHocTap inner join ViewTTLM ON tblHocTap.MaLopBT = ViewTTLM.MaLopBT
		 inner join ViewTTHP ON ViewTTHP.MaHP = ViewTTLM.MaHP
		 WHERE tblHocTap.MSSV = @mssv
	RETURN @DiemHP
END

GO
CREATE VIEW ViewTTHT AS 
SELECT * FROM dbo.tblHocTap

GO
CREATE VIEW ViewTTGV AS SELECT * FROM dbo.tblGiangVien

GO
CREATE VIEW ViewTTGD AS SELECT * FROM dbo.tblGiangDay

GO
CREATE VIEW ViewTTN AS SELECT * FROM dbo.tblNganh

GO
CREATE VIEW ViewTTKV AS SELECT * FROM dbo.tblKhoaVien

GO
CREATE VIEW ViewTTLSV AS SELECT * FROM dbo.tblLopSV

GO
CREATE VIEW ViewTTLM AS SELECT * FROM dbo.tblLopMo
WHERE SLDK < SLMAX + 1 WITH CHECK OPTION

GO 
CREATE VIEW ViewTTCTDT AS SELECT * FROM dbo.tblCTDT

GO 
CREATE VIEW ViewKyHoc AS SELECT * FROM dbo.tblKyHoc

GO
CREATE FUNCTION [dbo].[FuncCheckUser](@mssv char(8), @role varchar(20))
RETURNS VARCHAR(10)
AS
BEGIN
	DECLARE @kq varchar(10)
	IF(NOT EXISTS (SELECT * FROM sys.server_principals	WHERE name = @mssv)) 
		SET @kq = 'nologin' 
	ELSE 
	BEGIN
		IF(NOT EXISTS (SELECT * FROM sys.database_principals WHERE name = @mssv)) 
		SET @kq = 'nouser' 
		ELSE 
		BEGIN
		IF(NOT EXISTS (SELECT dp.name, us.name FROM sys.sysusers us right 
							JOIN  sys.database_role_members rm ON us.uid = rm.member_principal_id
							JOIN sys.database_principals dp ON rm.role_principal_id =  dp.principal_id
							WHERE us.name = @mssv AND dp.name = @role))
			SET @kq = 'noaddrole'
			ELSE SET @kq = '1'
		END
	END
RETURN @kq
END

---================================TRIGGER==========================================---
--Khi sinh viên đăng ký lớp học tập thì sẽ cập nhật SLDK, TrangThaiDK trong bảng tblLopMo--
GO
CREATE TRIGGER InsertSLDK
ON tblHocTap AFTER INSERT 
AS
BEGIN
	UPDATE ViewTTLM SET SLDK = SLDK + 1 WHERE ViewTTLM.MaLopBT = (SELECT MaLopBT FROM inserted)
	UPDATE ViewTTHT SET TrangThaiDK = N'Đăng ký thành công' WHERE ViewTTHT.MaLopBT = (SELECT MaLopBT FROM inserted)
END

--Khi sinh viên xóa lớp đăng ký thì sẽ cập nhật số lượng đăng ký trong bảng tblLopMo-
GO
CREATE TRIGGER DELETESLDK
ON tblHocTap AFTER DELETE
AS
BEGIN
	UPDATE ViewTTLM SET SLDK = SLDK - 1 WHERE ViewTTLM.MaLopBT = (SELECT MaLopBT FROM deleted)
END

-----------=============================INSERT DATA====================================-------------
GO
INSERT INTO tblKhoaVien (MaVien, TenVien)
VALUES
    ('MIL', N'Khoa Giáo dục Quốc phòng & An ninh'),
    ('PE', N'Khoa Giáo dục Thể chất'),
    ('SSH', N'Khoa Lý luận Chính trị'),
    ('BF', N'Viện Công nghệ Sinh học và Công nghệ Thực phẩm'),
    ('NE', N'Viện Vật lý Kỹ thuật'),
    ('ED', N'Viện Sư phạm Kỹ thuật'),
    ('FL', N'Viện Ngoại ngữ'),
    ('HH', N'Viện Kỹ thuật Hóa học'),
    ('EM', N'Viện Kinh tế và Quản lý'),
    ('VL', N'Viện Khoa học và Kỹ thuật Vật liệu'),
    ('MT', N'Viện Khoa học và Công nghệ Môi trường'),
    ('DM', N'Viện Dệt may - Da giầy và Thời trang'),
    ('MI', N'Viện Toán Ứng Dụng và Tin Học'),
    ('CK', N'Trường Cơ Khí'),
    ('DT', N'Trường Điện - Điện Tử'),
    ('IT', N'Trường Công Nghệ Thông Tin & Truyền Thông');

GO
INSERT INTO tblNganh (MaNganh, TenNganh, MaVien)
VALUES
    ('NE1', N'Vật lý kĩ thuật', 'NE'),
    ('FL2', N'Song bằng ĐH Plymouth Marjon', 'FL'),
    ('MS1', N'Kỹ Thuật Vật Liệu', 'VL'),
    ('MI1', N'Toán Tin', 'MI'),
    ('ED1', N'Sư phạm kỹ thuật công nghiệp', 'ED'),
    ('FL1', N'Tiếng Anh cho KHKT', 'FL'),
    ('HH1', N'Kỹ Thuật Hóa Học', 'HH'),
    ('DT03', N'Cơ Điện Tử', 'DT'),
    ('DT02', N'Điều Khiển và Tự Động Hóa', 'DT'),
    ('DT01', N'Điện Tử Viễn Thông', 'DT'),
    ('IT2', N'Kỹ Thuật Máy Tính', 'IT'),
    ('IT1', N'Khoa Học Máy Tính', 'IT'),
    ('ITE6', N'Công Nghệ Thông Tin Việt Nhật', 'IT');

GO
EXEC [dbo].[ProcINSERTGiangVien] '643392398717', N'Nguyễn', N'Ngọc', N'Bobby', 'FL', '2021-01-26'
EXEC [dbo].[ProcINSERTGiangVien] '554892597736', N'Đặng', N'Trang', N'Dương', 'DT', '2022-06-17'
EXEC [dbo].[ProcINSERTGiangVien] '927665294838', N'Trần', N'Phương', N'Hoàng', 'VL', '2022-06-18'
EXEC [dbo].[ProcINSERTGiangVien] '946296270453', N'Trương', N'Tùng', N'Anh', 'IT', '2022-06-19'
EXEC [dbo].[ProcINSERTGiangVien] '729817103630', N'Lê', N'Minh', N'Quang', 'FL', '2022-06-22'
EXEC [dbo].[ProcINSERTGiangVien] '116616043187', N'Võ', N'Đức', N'Thu', 'DT', '2022-06-23'
EXEC [dbo].[ProcINSERTGiangVien] '217870018983', N'Huỳnh', N'Ngọc', N'Thu', 'IT', '2022-06-25'
EXEC [dbo].[ProcINSERTGiangVien] '621280325993', N'Phạm', N'Tú', N'Đức', 'NE', '2022-06-26'
EXEC [dbo].[ProcINSERTGiangVien] '850812367459', N'Dương', N'Bình', N'Tiến', 'FL', '2022-06-27'
EXEC [dbo].[ProcINSERTGiangVien] '495134699043', N'Nguyễn', N'Vân', N'Ánh', 'HH', '2022-06-28'
EXEC [dbo].[ProcINSERTGiangVien] '580622557949', N'Đỗ', N'Quỳnh', N'Minh', 'ED', '2022-06-29'
EXEC [dbo].[ProcINSERTGiangVien] '148847093455', N'Hoàng', N'Hiền', N'Thịnh', 'IT', '2022-06-30'
EXEC [dbo].[ProcINSERTGiangVien] '565501452009', N'Lê', N'Hạnh', N'Thu', 'FL', '2022-07-01'
EXEC [dbo].[ProcINSERTGiangVien] '619796822565', N'Đỗ', N'Thanh', N'Lan', 'NE', '2022-07-02'
EXEC [dbo].[ProcINSERTGiangVien] '909232727607', N'Nguyễn', N'Hương', N'Tuấn', 'FL', '2022-07-03'
EXEC [dbo].[ProcINSERTGiangVien] '100617540743', N'Phan', N'Lan', N'Hà', 'DT', '2022-07-04'
EXEC [dbo].[ProcINSERTGiangVien] '583796051842', N'Hồ', N'Dũng', N'Thanh', 'MI', '2022-07-05'
EXEC [dbo].[ProcINSERTGiangVien] '346076304097', N'Bùi', N'Hoàng', N'Thị', 'HH', '2022-06-21'
EXEC [dbo].[ProcINSERTGiangVien] '503458087599', N'Trương', N'Anh', N'Phương', 'VL', '2022-06-20'
EXEC [dbo].[ProcINSERTGiangVien] '262029921720', N'Nguyễn', N'Nga', N'Ngọc', 'ED', '2022-06-24'
EXEC [dbo].[ProcINSERTGiangVien] '318600299698', N'Nguyễn', N'Sơn', N'Khánh','MI', '2022-07-05'

GO
INSERT INTO tblLopSV(MaLopSV, TenLopSV, GVPT)
VALUES 
('ED1-01', N'Sư phạm kỹ thuật công nghiệp 02', 'GV0003'),
('FL1-01', N'Tiếng Anh cho KHKT 04', 'GV0010'),
('FL1-02', N'Tiếng Anh cho KHKT 04', 'GV0009'),
('FL2-01', N'ĐH Plymouth Marjon 03', 'GV0001'),
('HH1-01', N'Kỹ Thuật Hóa Học 02', 'GV0004'),
('HH1-02', N'Kỹ Thuật Hóa Học 02', 'GV0015'),
('IT1-01', N'Khoa Học Máy Tính 01', 'GV0008'),
('IT1-02', N'Khoa Học Máy Tính 01', 'GV0001'),
('IT1-03', N'Khoa Học Máy Tính 01', 'GV0020'),
('MI1-01', N'Toán Tin 1', 'GV0016'),
('MI1-02', N'Toán Tin 1', 'GV0017'),
('MI1-03', N'Toán Tin 1', 'GV0018'),
('MS1-01', N'Kỹ Thuật Vật Liệu 04', 'GV0002'),
('MS1-02', N'Kỹ Thuật Vật Liệu 04', 'GV0006'),
('MS1-03', N'Kỹ Thuật Vật Liệu 04', 'GV0006'),
('NE1-01', N'Vật lý kĩ thuật 02', 'GV0004'),
('NE1-02', N'Vật lý kĩ thuật 02', 'GV0005'),
('VN-01', N'Việt Nhật 01', 'GV0011'),
('VN-02', N'Việt Nhật 01', 'GV0001'),
('VN-03', N'Việt Nhật 01', 'GV0003')

GO
EXEC [dbo].[ProcINSERTSinhVien] 890123456712, N'Nguyễn', N'Anh', N'Vinh', 'ITE6', 'VN-01'
EXEC [dbo].[ProcINSERTSinhVien] 761239845601, N'Trương', N'Anh', N'Ngọc', 'MI1', 'MI1-01'
EXEC [dbo].[ProcINSERTSinhVien] 981276543210, N'Đặng', N'Dương', N'Hải', 'MI1', 'MI1-01'
EXEC [dbo].[ProcINSERTSinhVien] 498756102934, N'Dương', N'TIến', N'Đạt', 'MI1', 'MI1-01'
EXEC [dbo].[ProcINSERTSinhVien] 309857612394, N'Đỗ', N'Minh', N'Quang', 'MI1', 'MI1-01'
EXEC [dbo].[ProcINSERTSinhVien] 890543218765, N'Trương', N'Phương', N'Diệu', 'IT1', 'IT1-01'
EXEC [dbo].[ProcINSERTSinhVien] 674210983512, N'Bùi', N'Thị', N'Tâm', 'IT1', 'IT1-01'
EXEC [dbo].[ProcINSERTSinhVien] 789654312310, N'Đỗ', N'Lan', N'Dung', 'IT1', 'IT1-01'
EXEC [dbo].[ProcINSERTSinhVien] 432190786543, N'Nguyễn', N'Tuấn', N'Quân', 'IT1', 'IT1-01'
EXEC [dbo].[ProcINSERTSinhVien] 123890765412, N'Phan', N'Hà', N'Thương', 'IT1', 'IT1-01'
EXEC [dbo].[ProcINSERTSinhVien] 572019836421, N'Nguyễn', N'Ngọc', N'Thảo', 'IT1', 'IT1-01'
EXEC [dbo].[ProcINSERTSinhVien] 102938475610, N'Hồ', N'Thanh', N'Nhi', 'IT1', 'IT1-01'
EXEC [dbo].[ProcINSERTSinhVien] 123456789012, N'Nguyễn', N'Khánh', N'Linh', 'ITE6', 'VN-01'
EXEC [dbo].[ProcINSERTSinhVien] 457609831278, N'Huỳnh', N'Thu', N'Trang','MI1', 'MI1-01'
EXEC [dbo].[ProcINSERTSinhVien] 908712345678, N'Trần', N'Hoàng', N'Đức', 'ITE6', 'VN-01'
EXEC [dbo].[ProcINSERTSinhVien] 506123789142, N'Lê', N'Quang', N'Chiến', 'ITE6', 'VN-01'
EXEC [dbo].[ProcINSERTSinhVien] 654312789021, N'Võ', N'Thu', N'Hà', 'ITE6', 'VN-01'
EXEC [dbo].[ProcINSERTSinhVien] 890123456712, N'Phạm', N'Đức', N'Mạnh', 'ITE6', 'VN-01'
EXEC [dbo].[ProcINSERTSinhVien] 231089765432, N'Hoàng', N'Thịnh', N'Thắng', 'ITE6', 'VN-01'
EXEC [dbo].[ProcINSERTSinhVien] 675431298765, N'Lê', N'Thu', N'Hương', 'ITE6', 'VN-01'

GO
INSERT INTO tblKyHoc([KyHoc], [MSSV], [DuNo], [DaTT])
VALUES('20221', '20230001', 0, 24000000),
('20221', '20230002', 6000000, 13000000),
('20221', '20230003', 2000000, 17000000),
('20221', '20230004', 0, 24000000),
('20222', '20230005', 1000000, 21000000),
('20222', '20230006', 2000000, 20000000),
('20222', '20230007', 0, 22000000),
('20222', '20230008', 1000000, 21500000),
('20222', '20230009', 0, 10000000),
('20221', '20230010', 5000000, 14000000),
('20221', '20230011', 1500000, 23500000),
('20222', '20230012', 8000000, 12000000),
('20221', '20230013', 7000000, 14000000),
('20221', '20230014', 7000000, 15000000),
('20221', '20230015', 3000000, 17000000),
('20222', '20230016', 6000000, 13500000),
('20221', '20230017', 1000000, 23000000),
('20221', '20230018', 6000000, 16000000),
('20221', '20230019', 0, 25000000),
('20221', '20230020', 0, 26000000);

GO
INSERT INTO tblHocPhan(MaHP, TenHP, SoTC, TCHP, TrongSo, Tien_1TCHP)
VALUES 
('BF2701','Nhập môn kỹ thuật sinh học',3,2,0.6,450000),
('BF2703','Thí nghiệm hóa sinh',2,2,0.7,450000),
('BF2901','Nhập môn công nghệ thực phẩm',3,2,0.7,450000),
('BF3011','Hóa sinh đại cương',3,3,0.6,1000000),
('BF3015','Quá trình và thiết bị chuyển khối',2,3,0.5,6500000),
('BF3040','Vi sinh thực phẩm',3,2,0.5,450000),
('ED2000','Nhập môn ngành Công nghệ Giáo dục',3,2,0.5,450000),
('ED3040','Tâm lý học chuyên ngành',3,4,0.6,450000),
('ED3220','Kỹ năng mềm',2,2,0.6,450000),
('ED3220Q','Kỹ năng mềm',3,2,0.5,450000),
('ED3280','Tâm lý học ứng dụng',2,4,0.7,450000),
('ED3390', 'Hệ thống quản lý học tập thế hệ tương lai', 2, 2,  0.7, 650000),
('ED3410', 'Lãnh đạo tổ chức đào tạo', 3, 2,  0.7, 450000),
('ED4054', 'Lý luận dạy học chuyên ngành CNTT', 3, 2,  0.6, 650000),
('EM1010', 'Quản trị học đại cương', 3, 4, 0.6, 450000),
('EM1100', 'Kinh tế vi mô đại cương', 2, 2, 0.5, 1000000),
('EM1180', 'Văn hóa kinh doanh và tinh thần khởi nghiệp', 2, 2, 0.5, 6500000)

GO
INSERT INTO tblCTDT(MaNganh, MaHP)
VALUES 
('MI1', 'ED3220'),
('MI1', 'ED3280'),
('MI1', 'EM1010'),
('ED1', 'EM1010'),
('ED1', 'EM1100'),
('ED1', 'EM1180'),
('ED1', 'ED3390'),
('ED1', 'ED3410'),
('ED1', 'ED4054'),
('ED1', 'ED3220Q'),
('ED1', 'ED2000'),
('ED1', 'ED3040'),
('NE1', 'BF2701'),
('NE1', 'BF2703'),
('NE1', 'BF2901'),
('NE1', 'BF3011'),
('NE1', 'BF3015'),
('NE1', 'BF3040');

GO
INSERT INTO tblLopMo([KyHoc],[MaHP],[MaLop],[MaLopBT],[Thu],[TGBD],[TGKT],[Kip],[Tuan],[Phong],[SLMAX])
VALUES ('20222', 'ED3220', '674209', '674210', 2, '09:20', '10:05', 'Sáng', '26,28,30,32,34,36,38,40,42', 'D9-404', 75),
       (20221, 'BF3040', '981276', '981276', 6, '12:30', '14:00', 'Chiều', '2-10,12-15,18-21', 'C2-303', 80),
       (20222, 'BF3015', '123890', '123892', 5, '09:20', '11:45', 'Sáng', '2-10,12-15,18-21', 'TC-502', 65),
       (20221, 'ED3040', '654312', '654312', 4, '14:10', '14:55', 'Chiều', '2-10,12-15,18-21', 'D9-401', 90),
       (20221, 'ED3410', '908721', '908721', 5, '09:20', '11:45', 'Sáng', '2-10,12-15,18-21', 'D9-403', 30),
       (20221, 'ED3390', '231089', '231089', 2, '14:10', '14:55', 'Chiều', '3-10,12-15,18-21', 'D9-405', 95),
	   (20221, 'BF3011', '457609', '457609', 4, '12:30', '14:00', 'Chiều', '2-10,12-15,18-21', 'TC-506', 80),
       (20222, 'ED2000', '231089', '231089', 2, '14:10', '14:55', 'Chiều', '3-10,12-15,18-21', 'D9-405', 95),
       (20222, 'EM1180', '674209', '674209', 2, '08:20', '09:05', 'Sáng', '26,28,30,32,34,36,38,40,42', 'D9-403', 75),
       (20221, 'EM1100', '457609', '457610', 3, '08:25', '10:05', 'Sáng', '2-10,12-15,18-21', 'C2-304', 55),
       (20221, 'ED3390', '123890', '123891', 5, '06:45', '08:15', 'Sáng', '25-32,34-42', 'B1-302', 60),
       (20222, 'ED3410', '309856', '309856', 2, '14:10', '17:30', 'Chiều', '25-32,34-42', 'D9-401', 70),
	   (20222,'ED4054','123566','123567',4,'12:30','14:00','Chiều','25-32,34-42','D9-401',85),
		(20222,'BF2901','654312','654312',5,'09:20','11:45','Sáng','25,27,29,31,35,37,39,41','C2-306',55),
		(20221,'BF2901','329845','329845',6,'14:10','17:30','Chiều','2-10,12-15,18-21','C2-306',50),
		(20221,'ED2000','329855','329855',6,'14:10','17:30','Chiều','2-10,12-15,18-21','C2-306',50),
		(20221,'ED3220Q','572902','572903',2,'09:20','11:45','Sáng','3-10,12-15,18-21','D9-401',30);

GO
INSERT INTO tblGiangDay(KyHoc, MaGV, MaLopBT) VALUES 
(20221, 'GV0001', 123891),
(20221, 'GV0003', 231089),
(20221, 'GV0004', 329845),
(20221, 'GV0005', 329855),
(20221, 'GV0006', 457609),
(20221, 'GV0017', 457610),
(20221, 'GV0008', 572903),
(20221, 'GV0010', 654312),
(20221, 'GV0010', 908721),
(20221, 'GV0011', 981276),
(20222, 'GV0013', 123892),
(20222, 'GV0001', 231089),
(20222, 'GV0008', 309856),
(20222, 'GV0016', 654312),
(20222, 'GV0017', 674209),
(20222, 'GV0018', 674210);

------O/ Đăng nhập------
---------0.1. Nhập email---------
-------Tạo Procedure lấy MSSV từ email nhập từ WinForm------
GO
CREATE PROCEDURE [dbo].[ProcLayMSSV] @email varchar(50)
AS
BEGIN
	DECLARE @mssv char(8)
	SELECT @mssv = LEFT(RIGHT(RTRIM(@email),22),6)
	SELECT @mssv
END

---------0.2. Cấp lại mật khẩu---------
------Tạo PROCEDURE kiểm tra thông tin để cấp lại mật khẩu-
CREATE PROCEDURE [dbo].[ProcCheckQuenMK] @mssv char(8), @input1 nvarchar(300), @input2 nvarchar(50)
AS
BEGIN
		IF(@input1 = (SELECT Ques FROM ViewTTSV WHERE MSSV = @mssv) 
			AND @input2 = (SELECT Ans FROM ViewTTSV WHERE MSSV = @mssv))
		BEGIN
			SELECT @input2 = CONVERT(VARCHAR(20), CRYPT_GEN_RANDOM(5), 2)
			SELECT @input2
			DECLARE @check char(10)
			set @check = dbo.FuncCheckUser(@mssv, 'SinhVien')
			IF(@check = '1')
			BEGIN
				Declare @LoginCreationScript as varchar(max);
				set @LoginCreationScript ='DROP LOGIN [{mssv}]'
				set @LoginCreationScript=Replace(@LoginCreationScript, '{mssv}', @mssv)
				Execute(@LoginCreationScript)

				set @LoginCreationScript ='EXEC sp_addlogin [{mssv}], [{input2}], QLSV'
				Set @LoginCreationScript=Replace(@LoginCreationScript, '{mssv}', @mssv)
				set @LoginCreationScript=Replace(@LoginCreationScript, '{input2}', @input2)
				Execute(@LoginCreationScript)

				set @LoginCreationScript ='DROP USER [{mssv}]'
				set @LoginCreationScript=Replace(@LoginCreationScript, '{mssv}', @mssv)
				Execute(@LoginCreationScript)

				Declare @UserCreationScript as varchar(max);
				set @UserCreationScript ='USE QLSV CREATE User [{mssv}] for LOGIN [{mssv}]'
				set @UserCreationScript =Replace(@UserCreationScript, '{mssv}', @mssv)		
				Execute(@UserCreationScript)

				Declare @AddMemberScript as varchar(max);
				set @AddMemberScript = 'ALTER ROLE SinhVien ADD MEMBER [{mssv}]'		
				set @AddMemberScript=Replace(@AddMemberScript, '{mssv}', @mssv)		
				Execute(@AddMemberScript)
			END
		END
		ELSE SELECT 0
END

---------0.3. Đổi mật khẩu---------
-------Tạo Procedure đổi mật khẩu------
GO
CREATE PROCEDURE [dbo].[ProcDoiMK] @login char(8), @matkhaucu varchar(30), @matkhaumoi varchar(30)
AS
BEGIN
	DECLARE @sql char(100) 
	SET @sql = 'ALTER LOGIN [{@login}]
	WITH PASSWORD = '''+ @matkhaumoi + '''
	OLD_PASSWORD = ''' + @matkhaucu + ''''+ 'SELECT 1'
	SET @sql = REPLACE(@sql, '{@login}', @login)
	EXEC(@sql)
END

---I/ SINH VIÊN---
------1. Hồ sơ sinh viên------
---------1.1. Hồ sơ sinh viên---------
--Tạo PROCEDURE để sinh viên update thông tin cá nhân vào ViewTTSV --
GO
CREATE PROCEDURE [dbo].[ProcSinhVienUpdate] 
	@ngaysinh char(20), @gioitinh nchar(10), @quoctich nchar(100), 
	@dantoc nchar(100), @noisinh nchar(100), @sdt char(15), @stbh char(20), 
	@emailtd char(30), @diachi nvarchar(300), @noiodk nchar(100), @sothich nchar(50)
AS
	BEGIN
	UPDATE ViewTTSV
	SET
		NgaySinh = @ngaysinh, GioiTinh = @gioitinh, QuocTich = @quoctich,
		DanToc = @dantoc, NoiSinh = @noisinh, Sdt = @sdt, SoTheBH = @stbh,
		Email_thuongdung = @emailtd, DiaChi = @diachi, NoiODK = @noiodk, SoThich = @sothich 
	WHERE MSSV = USER_NAME()
END

--Tạo PROCEDURE để hiển thị thông tin từ bảng view ViewTTSV--
GO
CREATE PROCEDURE [dbo].[ProCSinhVienSelect]
AS
BEGIN
	SELECT NgaySinh, GioiTinh, QuocTich, DanToc, NoiSinh, Sdt, SoTheBH, Email_thuongdung, DiaChi, Ho, Dem, Ten FROM ViewTTSV
	WHERE MSSV = USER_NAME()
	
END

---------1.2. Thông tin lớp sinh viên---------
GO
CREATE PROCEDURE ProcTTLopSV
AS
BEGIN
	SELECT MSSV AS N'Mã số sinh viên', Ho AS N'Họ', Dem N'Tên đệm', Ten AS N'Tên', CONVERT(VARCHAR(10),NgaySinh,103) AS N'Ngày sinh', 
	MaLopSV AS 'Lớp', TenNganh AS 'Tên Ngành', TrangThai AS 'Trạng thái học tập' 
	FROM ViewTTSV INNER JOIN ViewTTN ON  ViewTTSV.MaNganh = ViewTTN.MaNganh
	WHERE MaLopSV = (SELECT MaLopSV FROM ViewTTSV WHERE MSSV = USER_NAME() )
END 

------2. Thời khóa biểu------
go
CREATE PROCEDURE [dbo].[ProcTKB] 
AS
BEGIN
	SELECT ViewTTLM.MaHP AS 'Mã học phần', ViewTTHP.TenHP AS 'Tên học phần', ViewTTLM.MaLop AS 'Mã lớp',
			 ViewTTLM.Tuan AS 'Tuần', ViewTTLM.Thu AS 'Thứ', ViewTTLM.Kip AS 'Kíp', ViewTTLM.TGBD AS 'Thời gian bắt đầu', 
			ViewTTLM.TGKT AS 'Thời gian kết thúc', ViewTTLM.Phong AS 'Phòng', Ho +' '+ Dem +' '+ Ten AS 'Tên giảng viên'
	FROM ViewTTLM inner join ViewTTGD on ViewTTLM.MaLopBT = ViewTTGD.MaLopBT 
				inner join ViewTTHT on  ViewTTLM.MaLopBT = ViewTTHT.MaLopBT 
				inner join ViewTTHP on ViewTTLM.MaHP = ViewTTHP.MaHP
				inner join ViewTTGV on ViewTTGD.MaGV = ViewTTGV.MaGV
	WHERE MSSV = USER_NAME()
END 

------3. Kết quả học tập------
---------3.1. Bảng điểm cá nhân---------
go
CREATE PROCEDURE [dbo].[BangDiemCN] 
AS
BEGIN
	SELECT ViewTTLM.KyHoc AS 'Kỳ Học', ViewTTLM.MaHP AS 'Mã học phần', ViewTTHP.TenHP AS 'Tên học phần', ViewTTHP.SoTC AS 'Số tín chỉ', dbo.FuncTinhDiemChu(ViewTTHT.DiemSo) AS 'Điểm chữ'
	FROM ViewTTLM inner join ViewTTHT on ViewTTLM.MaLopBT = ViewTTHT.MaLopBT 
	inner join ViewTTHP on ViewTTLM.MaHP = ViewTTHP.MaHP
WHERE ViewTTHT.MSSV = USER_NAME()
END 

---------3.2. Kiểm tra điểm mới nhập kỳ mới nhất---------
go
CREATE PROCEDURE [dbo].[BdKyMoiNhat] 
AS
BEGIN
	DECLARE @kyhoc char(5)
	SELECT @kyhoc = MAX(ViewTTLM.KyHoc) from ViewTTLM inner join ViewTTHT on ViewTTLM.MaLopBT = ViewTTHT.MaLopBT
	where ViewTTHT.MSSV = USER_NAME() and TrangThai = N'Đã xếp TKB'

	SELECT ViewTTLM.MaLop, ViewTTHP.TenHP, ViewTTHP.TrongSo, ViewTTHT.DiemQT, ViewTTHT.DiemThi
	FROM ViewTTLM inner join ViewTTHT on ViewTTLM.MaLopBT = ViewTTHT.MaLopBT 
	inner join ViewTTHP on ViewTTLM.MaHP = ViewTTHP.MaHP
	WHERE ViewTTHT.MSSV = USER_NAME() AND ViewTTLM.KyHoc = @kyhoc
END

------4. Học phí - Công nợ------
----------- Đưa ra thông tin học phí----------
-------Tạo Function tính tổng học phí------
go
CREATE FUNCTION [dbo].[FuncTinhTongHP](@kyhoc char(5))
RETURNS CHAR(15)
AS
BEGIN
	DECLARE @sum char(15)
	SELECT @sum = SUM(RTRIM(CONVERT(bigint,Tien_1TCHP))*CONVERT(int,TCHP)) FROM ViewTTHP
		INNER JOIN ViewTTLM ON ViewTTHP.MaHP = ViewTTLM.MaHP
		INNER JOIN ViewTTHT ON ViewTTHT.MaLopBT = ViewTTLM.MaLopBT
	WHERE ViewTTHT.KyHoc = @kyhoc AND MSSV = USER_NAME()
	RETURN @sum
END

go
CREATE PROCEDURE [dbo].[ProcHPCN] @kyhoc char(5)
AS
BEGIN
	SELECT MaHP, TenHP, Tien_1TCHP, TCHP, Tien_1TCHP*TCHP AS 'Tổng tiền học phần' FROM ViewTTHP
	WHERE MaHP = (
					SELECT MaHP FROM ViewTTHT
					WHERE MaLopBT = (
									SELECT MaLopBT FROM ViewTTLM
									WHERE KyHoc = @kyhoc AND MSSV = USER_NAME()
									)
					)
END

----------- Đưa ra thông tin tổng học phí, dư nợ, học phí cần thanh toán----------
go
CREATE PROCEDURE [dbo].[ProcTTHP] @kyhoc char(5)
AS
BEGIN
	DECLARE @sum char(15)
	SET @sum = dbo.FuncTinhTongHP(@kyhoc)
	DECLARE @phaidong char(15)
	SET @phaidong = CONVERT(int, @sum)
	SELECT @phaidong = @phaidong + CONVERT(int, DuNo) - CONVERT(int, DaTT) FROM ViewKyHoc WHERE MSSV = USER_NAME() AND KyHoc = @kyhoc
	SELECT @sum, @phaidong, DuNo, NgayCapNhat FROM ViewKyHoc
	WHERE MSSV = USER_NAME() AND KyHoc = @kyhoc
END

go
CREATE PROCEDURE [dbo].[ProcCTDT] 
AS
BEGIN
	SELECT ViewTTCTDT.MaHP,  ViewTTHP.TenHP,  ViewTTHP.SoTC,  ViewTTHP.TrongSo, ViewTTN.MaVien
	FROM ViewTTCTDT INNER JOIN ViewTTHP ON ViewTTCTDT.MaHP = ViewTTHP.MaHP
		INNER JOIN ViewTTN ON ViewTTN.MaNganh = ViewTTCTDT.MaNganh
	WHERE ViewTTCTDT.MaNganh = (SELECT MaNganh FROM ViewTTSV WHERE MSSV = USER_NAME())
END

---------5.2. Danh mục học phần toàn trường---------
go
CREATE PROCEDURE [dbo].[ProcDMHP] 
AS
BEGIN
	SELECT * FROM ViewTTHP 
END

------6. Đăng ký lớp học------
------6.1. Danh sách lớp mở------
go
CREATE PROCEDURE [dbo].[ProcTTLM] @kyhoc char(5)
AS
BEGIN
	IF(@kyhoc IS NOT NULL)
		SELECT * FROM ViewTTLM WHERE KyHoc = @kyhoc 
	ELSE 
		SELECT * FROM ViewTTLM
END

------6.2. Đăng ký học tập------
-----Tạo Procedure để Insert hoặc Delete ViewTTHT----------
go
CREATE PROCEDURE [dbo].[ProcDKHT_InDe] @sql varchar(20), @kyhoc char(5), @malopbt char(10)
AS
BEGIN
	IF(@sql = 'insert')
		BEGIN
		INSERT INTO ViewTTHT(KyHoc, MaLopBT, MSSV) VALUES (@kyhoc, @malopbt, USER_NAME()) 
		END
	ELSE IF(@sql = 'delete')
		BEGIN
		DELETE ViewTTHT WHERE MaLopBT = @malopbt AND MSSV = USER_NAME() AND KyHoc = @kyhoc
		END
END

-----Tạo Procedure để hiện thị danh sách lớp đã đăng ký----------
go
CREATE PROCEDURE [dbo].[ProcDKHT_Se] @kyhoc char(5)
AS
BEGIN
	SELECT DISTINCT MaLop, ViewTTLM.MaLopBT, ViewTTLM.MaHP, ViewTTHT.TrangThaiDK, ViewTTHP.TenHP, ViewTTHP.SoTC  
	FROM ViewTTLM INNER JOIN ViewTTHT ON ViewTTLM.MaLopBT = ViewTTHT.MaLopBT 
		INNER JOIN ViewTTHP ON ViewTTHP.MaHP = ViewTTLM.MaHP
	WHERE MSSV = USER_NAME() AND VIEWTTHT.KyHoc = @kyhoc 
END

-----Tạo Procedure để hiện thị thời khóa biểu lớp đã đăng ký----------
CREATE PROCEDURE [dbo].[ProcDKHT_SeTKB] @kyhoc char(5)
AS
BEGIN
	SELECT DISTINCT ViewTTHT.MaLopBT, Tuan, Thu, Kip, TGBD, TGKT, Phong   
	FROM ViewTTLM INNER JOIN ViewTTHT ON ViewTTLM.KyHoc = ViewTTHT.KyHoc AND ViewTTLM.MaLopBT = ViewTTHT.MaLopBT
	WHERE MSSV = USER_NAME() AND ViewTTHT.KyHoc = @kyhoc
END

---II/ GIẢNG VIÊN---
------1. Hồ sơ giảng viên------
---------1.1. Hồ sơ giảng viên---------
--Tạo PROCEDURE để sinh viên update thông tin cá nhân vào ViewTTSV --
CREATE PROCEDURE [dbo].[ProcGiangVienUpdate] 
	@ngaysinh char(20), @gioitinh nvarchar(10), @quoctich nvarchar(100), 
	@dantoc nvarchar(100), @noisinh nvarchar(100), @sdt varchar(15), @stbh varchar(20), 
	@emailtd varchar(30), @diachi nvarchar(300), @ques nvarchar(300), @ans nvarchar(50)
AS
	BEGIN
	UPDATE ViewTTGV
	SET
		NgaySinh = @ngaysinh, GioiTinh = @gioitinh, QuocTich = @quoctich,
		DanToc = @dantoc, NoiSinh = @noisinh, Sdt = @sdt, SoTheBH = @stbh,
		Email_thuongdung = @emailtd, DiaChi = @diachi, Ques = @ques, Ans = @ans 
	WHERE MaGV = USER_NAME()
END

--Tạo PROCEDURE để hiển thị thông tin từ bảng view ViewTTGV--
GO
CREATE PROCEDURE [dbo].[ProCGiangVienSelect]
AS
BEGIN
	SELECT NgaySinh, GioiTinh, QuocTich, DanToc, NoiSinh, Sdt, SoTheBH, Email_thuongdung, DiaChi, Ho, Dem, Ten FROM ViewTTGV
	WHERE MaGV = USER_NAME()
	
END
---------1.2. Thông tin lớp phụ trách quản lí---------
--Tạo PROCEDURE để lấy ra danh sách các lớp giảng viên quản lý--
GO
CREATE PROCEDURE [dbo].[ProCDSMaLopQL]
AS
BEGIN
	SELECT MaLopSV FROM ViewTTLSV WHERE GVPT = USER_NAME()
END	

--Tạo PROCEDURE để lấy thông tin cụ thể của từng lớp--
GO
CREATE PROCEDURE [dbo].[ProCSelectTTLopQL] @malopsv char(15)
AS
BEGIN
	SELECT MSSV, Ho, Dem, Ten, NgaySinh, TenLopSV, TenNganh, TrangThai 
	FROM ViewTTSV INNER JOIN ViewTTLSV ON ViewTTSV.MaLopSV = ViewTTLSV.MaLopSV
		INNER JOIN ViewTTN ON ViewTTN.MaNganh = ViewTTSV.MaNganh
	WHERE ViewTTSV.MaLopSV = @malopsv
END	

------2. Thời khóa biểu giảng dạy------
--------2.1. Thời khóa biểu giảng dạy--------
--Tạo PROCEDURE để lấy ra danh sách các kỳ giảng viên tham gia giảng dạy--
GO
CREATE PROCEDURE [dbo].[ProCKyGD]
AS
BEGIN
	SELECT DISTINCT KyHoc FROM ViewTTGD WHERE MaGV = USER_NAME()
END	

--Tạo PROCEDURE để đưa ra thời khóa biểu--
go
CREATE PROCEDURE [dbo].[ProcGVTKB] @kyhoc char(5)
AS
BEGIN
	SELECT ViewTTLM.MaHP AS 'Mã học phần', TenHP AS 'Tên học phần', MaLop AS 'Mã lớp', Tuan AS 'Tuần', 
			Thu AS 'Thứ', Kip AS 'Kíp', TGBD AS 'Thời gian bắt đầu', TGKT AS 'Thời gian kết thúc', Phong AS 'Phòng'
	FROM ViewTTLM inner join ViewTTHP on ViewTTLM.MaHP = ViewTTHP.MaHP
	WHERE MaLopBT IN ( SELECT MaLopBT FROM ViewTTGD WHERE MaGV = USER_NAME() AND KyHoc = @kyhoc )
END 

---------2.2. Tra cứu danh sách lớp học---------
--Tạo PROCEDURE để lấy ra danh sách các mã lớp giảng viên tham gia giảng dạy--
GO
CREATE PROCEDURE [dbo].[ProCDSMaLopGD]
AS
BEGIN
	SELECT MaLopBT FROM ViewTTGD WHERE MaGV = USER_NAME()
END	

--Tạo PROCEDURE để đưa ra danh sách lớp--
GO
CREATE PROCEDURE [dbo].[ProCSelectTTLopGD] @malopbt char(15), @kyhoc char(5)
AS
BEGIN
	SELECT ViewTTHT.MSSV, Ho +' '+ Dem +' '+ Ten AS 'Họ Tên', MaLopSV, TenNganh, SLDK, ViewTTLM.TrangThai 
	FROM ViewTTSV INNER JOIN ViewTTHT ON ViewTTSV.MSSV = ViewTTHT.MSSV
		INNER JOIN ViewTTN ON ViewTTN.MaNganh = ViewTTSV.MaNganh
		INNER JOIN ViewTTLM ON ViewTTLM.MaLopBT = ViewTTHT.MaLopBT AND ViewTTLM.KyHoc = ViewTTHT.KyHoc
	WHERE ViewTTHT.MaLopBT = @malopbt AND ViewTTHT.KyHoc = @kyhoc
END	

------3. Nhập điểm------
--Tạo PROCEDURE để nhập điểm--
GO
CREATE PROCEDURE [dbo].[ProcNhapDiem] @malopbt varchar(15), @kyhoc char(5), @mssv char(8) = NULL, @diemqt varchar(10) = NULL, @diemthi varchar(10) = NULL
AS
BEGIN
	IF(@mssv IS NULL)
	BEGIN
		SELECT ViewTTHT.MSSV, Ho +' '+ Dem +' '+ Ten AS 'Họ Tên', ViewTTLM.MaHP, TenHP, TrongSo, DiemQT, DiemThi
		FROM ViewTTSV INNER JOIN ViewTTHT ON ViewTTSV.MSSV = ViewTTHT.MSSV
					INNER JOIN ViewTTLM ON ViewTTLM.MaLopBT = ViewTTHT.MaLopBT AND ViewTTLM.KyHoc = ViewTTHT.KyHoc
					INNER JOIN ViewTTHP ON ViewTTHP.MaHP = ViewTTLM.MaHP
		WHERE ViewTTHT.MaLopBT = @malopbt AND ViewTTHT.KyHoc = @kyhoc
	END
	ELSE
		IF(@diemqt IS NOT NULL)
		BEGIN
			UPDATE ViewTTHT SET DiemQT = @diemqt
			WHERE MaLopBT = @malopbt AND KyHoc = @kyhoc AND MSSV = @mssv
			SELECT 1
		END
		IF(@diemthi IS NOT NULL)
		BEGIN
			UPDATE ViewTTHT SET DiemThi = @diemthi
			WHERE MaLopBT = @malopbt AND KyHoc = @kyhoc AND MSSV = @mssv
			SELECT 1
		END
END	

---======================GRANT========================================---
GRANT CREATE VIEW TO SinhVien
GRANT SELECT ON [dbo].[ViewTTSV] TO SinhVien
GRANT SELECT ON [dbo].[ViewTTHP] TO SinhVien
GRANT SELECT ON [dbo].[ViewTTHT] TO SinhVien
GRANT SELECT ON [dbo].[ViewTTLM] TO SinhVien
GRANT SELECT ON [dbo].[ViewTTLSV] TO SinhVien
GRANT SELECT ON [dbo].[ViewTTCTDT] TO SinhVien
GRANT SELECT ON [dbo].[ViewTTN] TO SinhVien
GRANT SELECT ON [dbo].[ViewTTKV] TO SinhVien
GRANT SELECT ON [dbo].[ViewKyHoc] TO SinhVien

grant execute on [dbo].[ProcTTLopSV]  to SinhVien
grant execute on [dbo].[ProCSinhVienSelect] to SinhVien
grant execute on [dbo].[ProCSinhVienUpdate] to SinhVien
grant execute on [dbo].[ProcTKB] to SinhVien
grant execute on [dbo].[BangDiemCN] to SinhVien
grant execute on [dbo].[BdKyMoiNhat] to SinhVien
grant execute on [dbo].[ProcHPCN] to SinhVien
grant execute on [dbo].[ProcCTDT] to SinhVien
grant execute on [dbo].[ProcDMHP] to SinhVien
grant execute on [dbo].[ProcTTLM] to SinhVien
grant execute on [dbo].[ProcTTHP] to SinhVien
grant execute on [dbo].[ProcDKHT_InDe] to SinhVien
grant execute on [dbo].[ProcDKHT_Se] to SinhVien
grant execute on [dbo].[ProcDKHT_SeTKB] to SinhVien


GRANT CREATE VIEW TO GiangVien
GRANT SELECT ON [dbo].[ViewTTSV] TO GiangVien
GRANT SELECT ON [dbo].[ViewTTHP] TO GiangVien
GRANT SELECT ON [dbo].[ViewTTHT] TO GiangVien
GRANT SELECT ON [dbo].[ViewTTGV] TO GiangVien
GRANT SELECT ON [dbo].[ViewTTGD] TO GiangVien
GRANT SELECT ON [dbo].[ViewTTLM] TO GiangVien
GRANT SELECT ON [dbo].[ViewTTLSV] TO GiangVien
GRANT SELECT ON [dbo].[ViewTTCTDT] TO GiangVien
GRANT SELECT ON [dbo].[ViewTTN] TO GiangVien
GRANT SELECT ON [dbo].[ViewTTKV] TO GiangVien
GRANT SELECT ON [dbo].[ViewKyHoc] TO GiangVien

grant execute on [dbo].[ProCGiangVienSelect] to GiangVien
grant execute on [dbo].[ProcGiangVienUpdate]  to GiangVien
grant execute on [dbo].[ProCDSMaLopQL] to GiangVien
grant execute on [dbo].[ProCSelectTTLopQL]  to GiangVien
grant execute on [dbo].[ProCKyGD] to GiangVien
grant execute on [dbo].[ProcGVTKB] to GiangVien
grant execute on [dbo].[ProCDSMaLopGD] to GiangVien
grant execute on [dbo].[ProCSelectTTLopGD] to GiangVien