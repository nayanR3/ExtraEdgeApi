CREATE DATABASE ExtraEdge

use ExtraEdge

-- Insert data into Brand table
INSERT INTO Brands
    (Name, Description)
VALUES
    ('Samsung', 'Electronics company based in South Korea'),
    ('Apple', 'Technology company based in Cupertino, California'),
    ('Xiaomi', 'Electronics company based in Beijing, China'),
    ('OnePlus', 'Smartphone manufacturer based in China'),
    ('Google', 'American multinational technology company');


-- Insert data into Customer table
INSERT INTO customers
    (Name, Address, Phone)
VALUES
    ('John Doe', '123 Main St, Anytown USA', 5551),
    ('Jane Smith', '456 Maple Ave, Anytown USA', 5559),
    ('Bob Johnson', '789 Oak St, Anytown USA', 5555),
    ('Sara Lee', '321 Elm St, Anytown USA', 5522),
    ('Tom Williams', '555 Pine St, Anytown USA', 5333);

-- Insert data into Mobile table
INSERT INTO Mobiles
    (Model, Description, Price, BrandId)
VALUES
    ('Galaxy S21', 'Flagship smartphone from Samsung', 999, 1),
    ('iPhone 13', 'Latest iPhone model from Apple', 1099, 2),
    ('Mi 11', 'Flagship smartphone from Xiaomi', 799, 3),
    ('OnePlus 9', 'Flagship smartphone from OnePlus', 869, 4),
    ('Pixel 6', 'Latest smartphone from Google', 699, 5);


INSERT INTO Sells
    (CustomerId, MobileId, SellDate, SellPrice, Discount, FinalPrice)
VALUES
    (1, 1, '2020-04-26', 1000, 10, 900),
    (2, 3, '2021-05-25', 1500, 20, 1200),
    (3, 2, '2022-06-24', 1200, 15, 1020),
    (4, 4, '2023-01-23', 2000, 25, 1500),
    (5, 5, '2023-02-22', 1800, 15, 1530);



SELECT * FROM Mobiles
SELECT * FROM Brands
SELECT * FROM sells
SELECT * FROM Customers




