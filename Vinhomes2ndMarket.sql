use master
go

DROP DATABASE Vinhomes2ndMarket;

go
CREATE DATABASE Vinhomes2ndMarket;
go
use Vinhomes2ndMarket
go

-- Tạo bảng Role
CREATE TABLE [Role] (
    RoleId INT PRIMARY KEY,
    Name VARCHAR(255)
);

-- Tạo bảng Building
CREATE TABLE Building (
    BuildingId INT PRIMARY KEY,
    Name VARCHAR(255),
    Address VARCHAR(255)
);

-- Tạo bảng Account
CREATE TABLE Account (
    AccountId uniqueidentifier PRIMARY KEY,
    Username NVARCHAR(255),
    Password VARCHAR(255),
    Fullname NVARCHAR(255),
    Description TEXT,
    Phone VARCHAR(15),
    Gender bit,
    RoleId INT,
    BuildingId INT,
    FOREIGN KEY (RoleId) REFERENCES Role(RoleId),
    FOREIGN KEY (BuildingId) REFERENCES Building(BuildingId)
);

-- Tạo bảng Wallet
CREATE TABLE Wallet (
    WalletId INT PRIMARY KEY,
    AccountId uniqueidentifier,
    Balance DECIMAL(10, 2),
    FOREIGN KEY (AccountId) REFERENCES Account(AccountId)
);

-- Tạo bảng Category
CREATE TABLE Category (
    CategoryId INT PRIMARY KEY,
    Name NVARCHAR(255)
);

-- Tạo bảng ProductPost
CREATE TABLE ProductPost (
    ProductPostId uniqueidentifier PRIMARY KEY,
    AccountId uniqueidentifier,
    Title VARCHAR(255),
    Description TEXT,
    ImageUrl VARCHAR(255),
    Status VARCHAR(255),
    CreateAt DATETIME,
    LastUpdateAt DATETIME,
    Price DECIMAL(10, 2),
    BuildingId INT,
    CategoryId INT,
    FOREIGN KEY (AccountId) REFERENCES Account(AccountId),
    FOREIGN KEY (BuildingId) REFERENCES Building(BuildingId),
    FOREIGN KEY (CategoryId) REFERENCES Category(CategoryId)
);

-- Tạo bảng Order
CREATE TABLE [Order] (
    OrderId uniqueidentifier PRIMARY KEY,
    ProductPostId uniqueidentifier,
    AccountId uniqueidentifier,
    Price DECIMAL(10, 2),
    Quantity INT,
    Total DECIMAL(10, 2),
    FOREIGN KEY (ProductPostId) REFERENCES ProductPost(ProductPostId),
    FOREIGN KEY (AccountId) REFERENCES Account(AccountId)
);

-- Tạo bảng PostStatus
CREATE TABLE PostStatus (
    PostStatusId uniqueidentifier PRIMARY KEY,
    Status NCHAR(255),
    Payment VARCHAR(255),
    ProductPostId uniqueidentifier,
    FOREIGN KEY (ProductPostId) REFERENCES ProductPost(ProductPostId)
);


-- Tạo dữ liệu giả cho bảng Role
INSERT INTO [Role] (RoleId, Name)
VALUES (1, 'Admin'),
       (2, 'User');

-- Tạo dữ liệu giả cho bảng Building
INSERT INTO Building (BuildingId, Name, Address)
VALUES (1, 'Building A', '123 Main St'),
       (2, 'Building B', '456 Elm St');

-- Tạo dữ liệu giả cho bảng Category
INSERT INTO Category (CategoryId, Name)
VALUES (1, N'Electronics'),
       (2, N'Clothing');

-- Tạo dữ liệu giả cho bảng Account
INSERT INTO Account (AccountId, Username, Password, Fullname, Description, Phone, Gender, RoleId, BuildingId)
VALUES (NEWID(), 'user1', 'password1', N'User One', 'Description for User One', '123-456-7890', 1, 2, 1),
       (NEWID(), 'admin', 'adminpass', N'Admin User', 'Description for Admin User', '987-654-3210', 0, 1, 2);

-- Tạo dữ liệu giả cho bảng Wallet
INSERT INTO Wallet (WalletId, AccountId, Balance)
VALUES (1, (SELECT AccountId FROM Account WHERE Username = 'user1'), 500.00),
       (2, (SELECT AccountId FROM Account WHERE Username = 'admin'), 1000.00);

-- Tạo dữ liệu giả cho bảng ProductPost
INSERT INTO ProductPost (ProductPostId, AccountId, Title, Description, ImageUrl, Status, CreateAt, LastUpdateAt, Price, BuildingId, CategoryId)
VALUES (NEWID(), (SELECT AccountId FROM Account WHERE Username = 'user1'), 'Product 1', 'Description for Product 1', 'image1.jpg', 'Active', GETDATE(), GETDATE(), 99.99, 1, 1),
       (NEWID(), (SELECT AccountId FROM Account WHERE Username = 'admin'), 'Product 2', 'Description for Product 2', 'image2.jpg', 'Inactive', GETDATE(), GETDATE(), 49.99, 2, 2);

-- Tạo dữ liệu giả cho bảng Order
INSERT INTO [Order] (OrderId, ProductPostId, AccountId, Price, Quantity, Total)
VALUES (NEWID(), (SELECT ProductPostId FROM ProductPost WHERE Title = 'Product 1'), (SELECT AccountId FROM Account WHERE Username = 'user1'), 99.99, 2, 199.98),
       (NEWID(), (SELECT ProductPostId FROM ProductPost WHERE Title = 'Product 2'), (SELECT AccountId FROM Account WHERE Username = 'admin'), 49.99, 3, 149.97);

-- Tạo dữ liệu giả cho bảng PostStatus
INSERT INTO PostStatus (PostStatusId, Status, Payment, ProductPostId)
VALUES (NEWID(), N'New', 'Pending', (SELECT ProductPostId FROM ProductPost WHERE Title = 'Product 1')),
       (NEWID(), N'Approved', 'Paid', (SELECT ProductPostId FROM ProductPost WHERE Title = 'Product 2'));
