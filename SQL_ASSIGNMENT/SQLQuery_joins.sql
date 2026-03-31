CREATE DATABASE BikeStores;

USE BikeStores;

CREATE TABLE customers (
    customer_id INT PRIMARY KEY,
    first_name VARCHAR(50),
    last_name VARCHAR(50),
    phone VARCHAR(20),
    email VARCHAR(100),
    street VARCHAR(100),
    city VARCHAR(50),
    state VARCHAR(50),
    zip_code VARCHAR(10)
);

INSERT INTO customers 
VALUES
(1,'John','Smith','9876543210','john@gmail.com','Street 1','New York','NY','10001'),
(2,'Emma','Johnson','9876543211','emma@gmail.com','Street 2','Chicago','IL','60007'),
(3,'Michael','Brown','9876543212','michael@gmail.com','Street 3','Dallas','TX','75001'),
(4,'Olivia','Davis','9876543213','olivia@gmail.com','Street 4','Seattle','WA','98001');

CREATE TABLE stores (
    store_id INT PRIMARY KEY,
    store_name VARCHAR(100),
    phone VARCHAR(20),
    email VARCHAR(100),
    street VARCHAR(100),
    city VARCHAR(50),
    state VARCHAR(50),
    zip_code VARCHAR(10)
);

INSERT INTO stores VALUES
(1,'Downtown Bikes','1112223333','downtown@bikes.com','Street A','New York','NY','10001'),
(2,'City Cycle Store','2223334444','citycycle@bikes.com','Street B','Chicago','IL','60007');

CREATE TABLE orders (
    order_id INT PRIMARY KEY,
    customer_id INT,
    order_status INT,
    order_date DATE,
    required_date DATE,
    shipped_date DATE,
    store_id INT,

    FOREIGN KEY (customer_id) REFERENCES customers(customer_id),
    FOREIGN KEY (store_id) REFERENCES stores(store_id)
);

INSERT INTO orders VALUES
(101,1,1,'2026-03-01','2026-03-05',NULL,1),
(102,2,4,'2026-02-25','2026-03-01','2026-02-27',1),
(103,3,4,'2026-02-20','2026-02-25','2026-02-22',2),
(104,4,2,'2026-03-02','2026-03-07',NULL,2);

CREATE TABLE brands (
    brand_id INT PRIMARY KEY,
    brand_name VARCHAR(100)
);

INSERT INTO brands VALUES
(1,'Trek'),
(2,'Giant'),
(3,'Specialized');

CREATE TABLE categories (
    category_id INT PRIMARY KEY,
    category_name VARCHAR(100)
);

INSERT INTO categories VALUES
(1,'Mountain Bikes'),
(2,'Road Bikes'),
(3,'Electric Bikes');

CREATE TABLE products (
    product_id INT PRIMARY KEY,
    product_name VARCHAR(100),
    brand_id INT,
    category_id INT,
    model_year INT,
    list_price DECIMAL(10,2),

    FOREIGN KEY (brand_id) REFERENCES brands(brand_id),
    FOREIGN KEY (category_id) REFERENCES categories(category_id)
);

INSERT INTO products VALUES
(1,'Trek Marlin 7',1,1,2023,800),
(2,'Giant ATX',2,1,2022,650),
(3,'Specialized Turbo',3,3,2024,1200),
(4,'Trek Domane',1,2,2023,950);

CREATE TABLE order_items (
    order_id INT,
    item_id INT,
    product_id INT,
    quantity INT,
    list_price DECIMAL(10,2),
    discount DECIMAL(4,2),

    PRIMARY KEY(order_id, item_id),

    FOREIGN KEY (order_id) REFERENCES orders(order_id),
    FOREIGN KEY (product_id) REFERENCES products(product_id)
);

INSERT INTO order_items VALUES
(102,1,1,2,800,0.10),
(102,2,2,1,650,0.05),
(103,1,3,1,1200,0.15),
(103,2,4,1,950,0.10);


CREATE TABLE stocks (
    store_id INT,
    product_id INT,
    quantity INT,

    PRIMARY KEY(store_id, product_id),

    FOREIGN KEY (store_id) REFERENCES stores(store_id),
    FOREIGN KEY (product_id) REFERENCES products(product_id)
);

INSERT INTO stocks VALUES
(1,1,15),
(1,2,20),
(1,3,10),
(2,1,12),
(2,3,8),
(2,4,5);

SELECT * FROM customers;
SELECT * FROM orders;
SELECT * FROM products;
SELECT * FROM brands;
SELECT * FROM categories;
SELECT * FROM stores;
SELECT * FROM stocks;
SELECT * FROM order_items;

--Level-1 : Problem 1 – Basic Customer Order Report
SELECT 
    c.first_name,
    c.last_name,
    o.order_id,
    o.order_date,
    o.order_status
FROM customers c
INNER JOIN orders o
ON c.customer_id = o.customer_id
WHERE o.order_status = 1 
   OR o.order_status = 4
ORDER BY o.order_date DESC;

--Level-1 : Problem 2 – Product Price Listing by Category
SELECT 
    p.product_name,
    b.brand_name,
    c.category_name,
    p.model_year,
    p.list_price
FROM products p
INNER JOIN brands b
ON p.brand_id = b.brand_id
INNER JOIN categories c
ON p.category_id = c.category_id
WHERE p.list_price > 500
ORDER BY p.list_price ASC;

--Level-2: Problem 1 - Store Wise Sales Summary
SELECT 
    s.store_name,
    SUM(oi.quantity * oi.list_price * (1 - oi.discount)) AS total_sales
FROM stores s
INNER JOIN orders o
ON s.store_id = o.store_id
INNER JOIN order_items oi
ON o.order_id = oi.order_id
WHERE o.order_status = 4
GROUP BY s.store_name
ORDER BY total_sales DESC;

--Level-2: Problem 2 - Product Stock and Sales Analysis
SELECT 
    p.product_name,
    s.store_name,
    st.quantity AS stock_quantity,
    SUM(oi.quantity) AS total_quantity_sold
FROM stocks st
INNER JOIN products p
ON st.product_id = p.product_id
INNER JOIN stores s
ON st.store_id = s.store_id
LEFT JOIN order_items oi
ON st.product_id = oi.product_id
GROUP BY p.product_name, s.store_name, st.quantity
ORDER BY p.product_name;