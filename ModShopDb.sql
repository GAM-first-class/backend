-- ایجاد و انتخاب دیتابیس
CREATE DATABASE ModShopDb;
GO

USE ModShopDb;
GO

---------------------------------------------------------------------
-- ۱) کاربران
---------------------------------------------------------------------

CREATE TABLE Roles (
    RoleId INT IDENTITY(1,1) PRIMARY KEY,
    RoleName NVARCHAR(50) NOT NULL
);

CREATE TABLE Users (
    UserId INT IDENTITY(1,1) PRIMARY KEY,
    RoleId INT NOT NULL,
    FirstName NVARCHAR(50) NOT NULL,
    LastName NVARCHAR(50) NOT NULL,
    Email NVARCHAR(100) NOT NULL UNIQUE,
    Mobile NVARCHAR(20) NOT NULL,
    PasswordHash NVARCHAR(255) NOT NULL,
    IsActive BIT NOT NULL DEFAULT 1,
    CreatedAt DATETIME2 NOT NULL DEFAULT GETDATE(),
    CONSTRAINT FK_Users_Roles FOREIGN KEY (RoleId) REFERENCES Roles(RoleId)
);

CREATE TABLE Addresses (
    AddressId INT IDENTITY(1,1) PRIMARY KEY,
    UserId INT NOT NULL,
    ReceiverName NVARCHAR(100) NOT NULL,
    ReceiverMobile NVARCHAR(20) NOT NULL,
    Province NVARCHAR(50) NOT NULL,
    City NVARCHAR(50) NOT NULL,
    FullAddress NVARCHAR(500) NOT NULL,
    PostalCode NVARCHAR(20) NOT NULL,
    IsDefault BIT NOT NULL DEFAULT 0,
    CONSTRAINT FK_Addresses_Users FOREIGN KEY (UserId) REFERENCES Users(UserId) ON DELETE CASCADE
);

---------------------------------------------------------------------
-- ۲) محصولات
---------------------------------------------------------------------

CREATE TABLE Categories (
    CategoryId INT IDENTITY(1,1) PRIMARY KEY,
    ParentCategoryId INT NULL,
    Name NVARCHAR(100) NOT NULL,
    ImageUrl NVARCHAR(500) NULL,
    SortOrder INT NOT NULL DEFAULT 0,
    IsActive BIT NOT NULL DEFAULT 1,
    CONSTRAINT FK_Categories_Parent FOREIGN KEY (ParentCategoryId) REFERENCES Categories(CategoryId)
);

CREATE TABLE Products (
    ProductId INT IDENTITY(1,1) PRIMARY KEY,
    CategoryId INT NOT NULL,
    Name NVARCHAR(200) NOT NULL,
    Description NVARCHAR(MAX) NULL,
    Price DECIMAL(18,2) NOT NULL,
    OldPrice DECIMAL(18,2) NULL,
    OfferEndDate DATETIME2 NULL,
    IsNew BIT NOT NULL DEFAULT 0,
    IsActive BIT NOT NULL DEFAULT 1,
    CreatedAt DATETIME2 NOT NULL DEFAULT GETDATE(),
    CONSTRAINT FK_Products_Categories FOREIGN KEY (CategoryId) REFERENCES Categories(CategoryId)
);

CREATE TABLE ProductImages (
    ImageId INT IDENTITY(1,1) PRIMARY KEY,
    ProductId INT NOT NULL,
    ImageUrl NVARCHAR(500) NOT NULL,
    IsMain BIT NOT NULL DEFAULT 0,
    SortOrder INT NOT NULL DEFAULT 0,
    CONSTRAINT FK_ProductImages_Products FOREIGN KEY (ProductId) REFERENCES Products(ProductId) ON DELETE CASCADE
);

CREATE TABLE Sizes (
    SizeId INT IDENTITY(1,1) PRIMARY KEY,
    SizeName NVARCHAR(50) NOT NULL
);

CREATE TABLE Colors (
    ColorId INT IDENTITY(1,1) PRIMARY KEY,
    ColorName NVARCHAR(50) NOT NULL,
    HexCode NVARCHAR(10) NULL
);

CREATE TABLE ProductVariants (
    VariantId INT IDENTITY(1,1) PRIMARY KEY,
    ProductId INT NOT NULL,
    SizeId INT NOT NULL,
    ColorId INT NOT NULL,
    SKU NVARCHAR(100) NOT NULL UNIQUE,
    Stock INT NOT NULL DEFAULT 0,
    CONSTRAINT FK_ProductVariants_Products FOREIGN KEY (ProductId) REFERENCES Products(ProductId) ON DELETE CASCADE,
    CONSTRAINT FK_ProductVariants_Sizes FOREIGN KEY (SizeId) REFERENCES Sizes(SizeId),
    CONSTRAINT FK_ProductVariants_Colors FOREIGN KEY (ColorId) REFERENCES Colors(ColorId),
    CONSTRAINT UQ_ProductVariants_Combination UNIQUE (ProductId, SizeId, ColorId)
);

CREATE TABLE Reviews (
    ReviewId INT IDENTITY(1,1) PRIMARY KEY,
    ProductId INT NOT NULL,
    UserId INT NOT NULL,
    Rating INT NOT NULL CHECK (Rating BETWEEN 1 AND 5),
    Comment NVARCHAR(1000) NULL,
    CreatedAt DATETIME2 NOT NULL DEFAULT GETDATE(),
    IsApproved BIT NOT NULL DEFAULT 0,
    CONSTRAINT FK_Reviews_Products FOREIGN KEY (ProductId) REFERENCES Products(ProductId) ON DELETE CASCADE,
    CONSTRAINT FK_Reviews_Users FOREIGN KEY (UserId) REFERENCES Users(UserId)
);
CREATE TABLE WishlistItems (
    UserId INT NOT NULL,
    ProductId INT NOT NULL,
    AddedAt DATETIME2 NOT NULL DEFAULT GETDATE(),
    PRIMARY KEY (UserId, ProductId),
    CONSTRAINT FK_Wishlist_Users FOREIGN KEY (UserId) REFERENCES Users(UserId) ON DELETE CASCADE,
    CONSTRAINT FK_Wishlist_Products FOREIGN KEY (ProductId) REFERENCES Products(ProductId) ON DELETE CASCADE
);

---------------------------------------------------------------------
-- ۳) سبد خرید و سفارش
---------------------------------------------------------------------

CREATE TABLE Carts (
    CartId INT IDENTITY(1,1) PRIMARY KEY,
    UserId INT NOT NULL,
    CreatedAt DATETIME2 NOT NULL DEFAULT GETDATE(),
    CONSTRAINT FK_Carts_Users FOREIGN KEY (UserId) REFERENCES Users(UserId) ON DELETE CASCADE
);

CREATE TABLE CartItems (
    CartItemId INT IDENTITY(1,1) PRIMARY KEY,
    CartId INT NOT NULL,
    VariantId INT NOT NULL,
    Quantity INT NOT NULL DEFAULT 1,
    CONSTRAINT FK_CartItems_Carts FOREIGN KEY (CartId) REFERENCES Carts(CartId) ON DELETE CASCADE,
    CONSTRAINT FK_CartItems_Variants FOREIGN KEY (VariantId) REFERENCES ProductVariants(VariantId)
);

CREATE TABLE OrderStatuses (
    StatusId INT IDENTITY(1,1) PRIMARY KEY,
    StatusName NVARCHAR(50) NOT NULL
);

CREATE TABLE ShippingMethods (
    ShippingMethodId INT IDENTITY(1,1) PRIMARY KEY,
    Name NVARCHAR(100) NOT NULL,
    Cost DECIMAL(18,2) NOT NULL,
    EstimatedDays INT NOT NULL,
    IsActive BIT NOT NULL DEFAULT 1
);

CREATE TABLE Orders (
    OrderId INT IDENTITY(1,1) PRIMARY KEY,
    UserId INT NOT NULL,
    AddressId INT NOT NULL,
    StatusId INT NOT NULL,
    ShippingMethodId INT NOT NULL,
    OrderDate DATETIME2 NOT NULL DEFAULT GETDATE(),
    ItemsTotal DECIMAL(18,2) NOT NULL,
    ShippingCost DECIMAL(18,2) NOT NULL,
    TotalAmount DECIMAL(18,2) NOT NULL,
    CONSTRAINT FK_Orders_Users FOREIGN KEY (UserId) REFERENCES Users(UserId),
    CONSTRAINT FK_Orders_Addresses FOREIGN KEY (AddressId) REFERENCES Addresses(AddressId),
    CONSTRAINT FK_Orders_Statuses FOREIGN KEY (StatusId) REFERENCES OrderStatuses(StatusId),
    CONSTRAINT FK_Orders_Shipping FOREIGN KEY (ShippingMethodId) REFERENCES ShippingMethods(ShippingMethodId)
);

CREATE TABLE OrderItems (
    OrderItemId INT IDENTITY(1,1) PRIMARY KEY,
    OrderId INT NOT NULL,
    VariantId INT NOT NULL,
    Quantity INT NOT NULL,
    UnitPrice DECIMAL(18,2) NOT NULL,
    CONSTRAINT FK_OrderItems_Orders FOREIGN KEY (OrderId) REFERENCES Orders(OrderId) ON DELETE CASCADE,
    CONSTRAINT FK_OrderItems_Variants FOREIGN KEY (VariantId) REFERENCES ProductVariants(VariantId)
);

CREATE TABLE Payments (
    PaymentId INT IDENTITY(1,1) PRIMARY KEY,
    OrderId INT NOT NULL,
    Amount DECIMAL(18,2) NOT NULL,
    Method NVARCHAR(50) NOT NULL,
    TransactionRef NVARCHAR(100) NULL,
    Status NVARCHAR(50) NOT NULL,
    PaidAt DATETIME2 NULL,
    CONSTRAINT FK_Payments_Orders FOREIGN KEY (OrderId) REFERENCES Orders(OrderId) ON DELETE CASCADE
);

---------------------------------------------------------------------
-- ۴) محتوای سایت
---------------------------------------------------------------------

CREATE TABLE Banners (
    BannerId INT IDENTITY(1,1) PRIMARY KEY,
    Title NVARCHAR(150) NULL,
    Subtitle NVARCHAR(250) NULL,
    ButtonText NVARCHAR(50) NULL,
    LinkUrl NVARCHAR(500) NULL,
    ImageUrl NVARCHAR(500) NOT NULL,
    Position NVARCHAR(50) NOT NULL,
    SortOrder INT NOT NULL DEFAULT 0,
    IsActive BIT NOT NULL DEFAULT 1
);

CREATE TABLE NewsletterSubscribers (
    SubscriberId INT IDENTITY(1,1) PRIMARY KEY,
    Email NVARCHAR(100) NOT NULL UNIQUE,
    SubscribedAt DATETIME2 NOT NULL DEFAULT GETDATE(),
    IsActive BIT NOT NULL DEFAULT 1
);

CREATE TABLE ContactMessages (
    MessageId INT IDENTITY(1,1) PRIMARY KEY,
    UserId INT NULL,
    FullName NVARCHAR(100) NOT NULL,
    Email NVARCHAR(100) NOT NULL,
    Subject NVARCHAR(200) NOT NULL,
    MessageText NVARCHAR(2000) NOT NULL,
    SentAt DATETIME2 NOT NULL DEFAULT GETDATE(),
    IsRead BIT NOT NULL DEFAULT 0,
    CONSTRAINT FK_ContactMessages_Users FOREIGN KEY (UserId) REFERENCES Users(UserId) ON DELETE SET NULL
);

CREATE TABLE Faqs (
    FaqId INT IDENTITY(1,1) PRIMARY KEY,
    Question NVARCHAR(500) NOT NULL,
    Answer NVARCHAR(MAX) NOT NULL,
    SortOrder INT NOT NULL DEFAULT 0,
    IsActive BIT NOT NULL DEFAULT 1
);

CREATE TABLE SiteSettings (
    SettingId INT IDENTITY(1,1) PRIMARY KEY,
    SettingKey NVARCHAR(100) NOT NULL UNIQUE,
    SettingValue NVARCHAR(MAX) NULL
);