use Alternative_Library2

INSERT INTO Accounts (UserId, UserName, Password, Role, DateCreated) VALUES
(1, 'Reader', 'pass123', 'user', '2024-01-01'),
(2, 'user2', 'pass234', 'user', '2024-02-01'),
(3, 'user3', 'pass345', 'user', '2024-03-01'),
(4, 'Librarian', 'pass456', 'librarian', '2024-04-01'),
(5, 'user5', 'pass567', 'user', '2024-05-01'),
(6, 'user6', 'pass678', 'librarian', '2024-06-01'),
(7, 'user7', 'pass789', 'user', '2024-07-01'),
(8, 'user8', 'pass890', 'librarian', '2024-08-01'),
(9, 'user9', 'pass901', 'user', '2024-09-01'),
(10, 'user10', 'pass012', 'user', '2024-10-01'),
(11, 'user11', 'pass012', 'librarian', '2024-10-01'),
(12, 'user12', 'pass012', 'librarian', '2024-10-01'),
(13, 'user13', 'pass012', 'librarian', '2024-10-01');

delete from Accounts
INSERT INTO Readers(readerId, readerName, address, gender, UserId1) VALUES
(1, 'Nguyễn Thị Lan', '123 Đường Láng', 'Female', 2),
(2, 'Trần Văn Minh', '456 Đường Kim Mã', 'Male', 3),
(3, 'Lê Thị Hoa', '789 Đường Hoàng Quốc Việt', 'Female', 5),
(4, 'Phạm Văn Long', '321 Đường Lê Duẩn', 'Male', 7),
(5, 'Hoàng Thị Mai', '654 Đường Cầu Giấy', 'Female', 9),
(6, 'Vũ Văn Hùng', '987 Đường Trần Duy Hưng', 'Male', 10),
(7, 'Đặng Thị Thu', '246 Đường Lạc Long Quân', 'Female', 2),
(8, 'Bùi Văn Kiên', '135 Đường Thái Hà', 'Male', 3),
(9, 'Ngô Thị Hương', '579 Đường Đê La Thành', 'Female', 5),
(10, 'Đỗ Văn Tuấn', '864 Đường Nguyễn Chí Thanh', 'Male', 7);

INSERT INTO ReaderCarts (cardId, readerId, dateCreated, ExpDate) VALUES
(1, 1, '2024-01-01', '2025-01-01'),
(2, 2, '2024-02-01', '2025-02-01'),
(3, 3, '2024-03-01', '2025-03-01'),
(4, 4, '2024-04-01', '2025-04-01'),
(5, 5, '2024-05-01', '2025-05-01'),
(6, 6, '2024-06-01', '2025-06-01'),
(7, 7, '2024-07-01', '2025-07-01'),
(8, 8, '2024-08-01', '2025-08-01'),
(9, 9, '2024-09-01', '2025-09-01'),
(10, 10, '2024-10-01', '2025-10-01');

INSERT INTO Librarians (libId, libName, birthday, address, UserId) VALUES
(1, 'Nguyễn Văn An', '1980-01-15', '123 Đường Láng', 4),
(2, 'Trần Thị Bích', '1985-02-20', '456 Đường Kim Mã', 8),
(3, 'Lê Văn Hùng', '1990-03-25', '789 Đường Hoàng Quốc Việt', 11),
(4, 'Phạm Thị Hà', '1975-04-30', '321 Đường Lê Duẩn', 12),
(5, 'Hoàng Văn Tùng', '1988-05-05', '654 Đường Cầu Giấy', 13),
(6, 'Vũ Thị Lan', '1982-06-10', '987 Đường Trần Duy Hưng', 8),
(7, 'Đặng Văn Sơn', '1977-07-15', '246 Đường Lạc Long Quân', 4),
(8, 'Bùi Thị Hằng', '1993-08-20', '135 Đường Thái Hà', 8),
(9, 'Ngô Văn Khoa', '1983-09-25', '579 Đường Đê La Thành', 4),
(10, 'Đỗ Thị Thu', '1992-10-30', '864 Đường Nguyễn Chí Thanh', 8);

INSERT INTO ReportCards (ReportCardId, libId, time, moneyIn, moneyOut, moneyInSource, moneyOutSource, Total) VALUES
(1, 1, '2024-01-01', 1000.0, 500.0, 700.0, 300.0, 1200.0),
(2, 2, '2024-02-01', 1500.0, 600.0, 800.0, 400.0, 1300.0),
(3, 3, '2024-03-01', 2000.0, 700.0, 900.0, 500.0, 1700.0),
(4, 4, '2024-04-01', 2500.0, 800.0, 1000.0, 600.0, 2100.0),
(5, 5, '2024-05-01', 3000.0, 900.0, 1100.0, 700.0, 2500.0),
(6, 1, '2024-06-01', 3500.0, 1000.0, 1200.0, 800.0, 2900.0),
(7, 2, '2024-07-01', 4000.0, 1100.0, 1300.0, 900.0, 3300.0),
(8, 3, '2024-08-01', 4500.0, 1200.0, 1400.0, 1000.0, 3700.0),
(9, 4, '2024-09-01', 5000.0, 1300.0, 1500.0, 1100.0, 4100.0),
(10,5, '2024-10-01', 5500.0, 1400.0, 1600.0, 1200.0, 4500.0);

INSERT INTO Publishers (publisherName, address) VALUES
(N'Nhà Xuất Bản Kim Đồng', N'38 Xuân Diệu, Tây Hồ, Hà Nội'),
(N'Nhà Xuất Bản Trẻ', N'61/10 Nguyễn Thị Minh Khai, Quận 1, TP.HCM'),
(N'Nhà Xuất Bản Văn Học', N'47 Quang Trung, Hoàn Kiếm, Hà Nội'),
(N'Nhà Xuất Bản Giáo Dục', N'23 Nguyễn Văn Bảo, Gò Vấp, TP.HCM'),
(N'Nhà Xuất Bản Hội Nhà Văn', N'87 Trần Hưng Đạo, Hoàn Kiếm, Hà Nội'),
(N'Nhà Xuất Bản Thanh Niên', N'14 Nguyễn Văn Tráng, Đống Đa, Hà Nội'),
(N'Nhà Xuất Bản Kim Điền', N'72 Đặng Văn Ngữ, Phường 10, Quận Phú Nhuận, TP.HCM'),
(N'Nhà Xuất Bản Nông Nghiệp', N'45 Nguyễn Thái Học, Ba Đình, Hà Nội'),
(N'Nhà Xuất Bản Phụ Nữ', N'122 Lê Thanh Nghị, Hai Bà Trưng, Hà Nội');

INSERT INTO Authors (authorName, Gender, Age )VALUES
(N'Nguyễn Nhật Ánh', 'Male', '53'),
(N'Trương Đình Kiên', 'Male', '44'),
(N'Lê Văn Vĩnh', 'Male', '49'),
(N'Hồ Anh Thái', 'Male', '47'),
(N'Nguyễn Hồng', 'Male', '42'),
(N'Phạm Ngọc Như Quỳnh', 'Female', '34'),
(N'Nguyễn Thành Long', 'Male', '41'),
(N'Trần Nhật Phong', 'Male', '41'),
(N'Nguyễn Phong Việt', 'Male', '49'),
(N'Lê Minh Khuê', 'Female', '35');

INSERT INTO Books (bookId, bookname, Category, Description, Amount, Status, Price, publisherName, authorName, ImagePath) VALUES
(1,N'Kí ức đêm mưa', N'Tiểu thuyết', N'Sài Gòn 1977', 15, 'Considered', 39.99,  N'Nhà xuất bản Kim Đồng' ,N'Nguyễn Thành Long',null),
(2,N'Ngày xưa thân ái', N'Tiểu thuyết', N'Hồi kí Miền Nam', 20, 'Approved', 29.99, N'Nhà xuất bản Trẻ', N'Trần Nhật Phong',null),
(3,N'Cậu bé đọc sách', N'Tiểu thuyết', N'Vùng quê nghèo khó', 12, 'Available', 29.99, N'Nhà xuất bản Văn Học', N'Nguyễn Phong Việt',null),
(4,N'Chiếc lược ngà', N'Tiểu thuyết', N'bé Thu', 12, 'Approved', 29.99, N'Nhà xuất bản Giáo Dục', N'Phạm Ngọc Quỳnh Như',null),
(5,N'Tấm Cám', N'Truyện cổ tích', N'Hư cấu', 25, 'Approved', 29.99, N'Nhà xuất bản Kim Đồng', N'Lê Văn Vĩnh',null),
(6,N'Những đoạn đường sống', N'Tiểu thuyết', N'Kí sự', 10, 'Available', 29.99, N'Nhà xuất bản Hội Nhà Văn', N'Nguyễn Hồng',null),
(7,N'Những con đường xưa', N'Tiểu thuyết', N'Kí sự Miền Nam', 20, 'Available', 29.99, N'Nhà xuất bản Thanh Niên', N'Lê Minh Khuê',null),
(8,N'Những mùa lúa chín', N'Tiểu thuyết', N'Hồi kí Miền Nam', 20, 'Available', 29.99, N'Nhà xuất bản Kim Điền', N'Hồ Anh Thái',null),
(9,N'Rừng Na Uy', N'Tiểu thuyết', N'Dịch thuật', 20, 'Available', 29.99, N'Nhà xuất bản Nông Nghiệp', N'Lê Văn Vĩnh',null),
(10,N'Tiếng dương cầm', N'Tiểu thuyết', N'Sài Gòn đêm khuya', 15, 'Available', 29.99, N'Nhà xuất bản Phụ Nữ', N'Nguyễn Hồng',null);
 delete from books 
 select * from books

INSERT INTO BorrowCards (brcardId, userId, bookId, dateCreated, Expidate) VALUES

(1, 2, 1, '2024-07-06', '2024-07-20'),
(2, 3, 2, '2024-07-06', '2024-07-21'),
(3, 5, 3, '2024-07-07', '2024-07-22'),
(4, 7, 4, '2024-07-08', '2024-07-23'),
(5, 9, 5, '2024-07-09', '2024-07-24'),
(6, 10, 6, '2024-07-10', '2024-07-25'),
(7, 2, 7, '2024-07-11', '2024-07-26'),
(8, 3, 8, '2024-07-12', '2024-07-27'),
(9, 5, 9, '2024-07-13', '2024-07-28'),
(10, 7, 10, '2024-07-14', '2024-07-29');


INSERT INTO ReturnCards (recardId, returnDate,PhieuMuonSach) VALUES
(1,  '2024-07-20'),
(2,  '2024-07-21'),
(3,  '2024-07-22'),
(4,  '2024-07-23'),
(5,  '2024-07-24'),
(6,  '2024-07-25'),
(7,  '2024-07-26'),
(8,  '2024-07-27'),
(9,  '2024-07-28'),
(10, '2024-07-29');

SET IDENTITY_INSERT Accounts on
go 

SET IDENTITY_INSERT books OFF 
go