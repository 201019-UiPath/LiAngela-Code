--SQL functions demo

--setup

-- drop table if exists products;

-- create table products
-- (
-- 	id serial primary key,
-- 	productName varchar,
-- 	productPrice decimal
-- );

-- insert into products (productName, productPrice) values
-- ('Apple', 1.99),
-- ('Orange', 2.30),
-- ('Banana', 0.99),
-- ('Grapes', 2.50),
-- ('Apple', 3.50);

-- select * from products;

DROP FUNCTION IF EXISTS discount_products;
DROP FUNCTION IF EXISTS steeply_discount_products;
DROP FUNCTION IF EXISTS discount_products_return_one;

CREATE FUNCTION discount_products (x int, OUT productName varchar, OUT normalPrice decimal, OUT discountedPrice decimal)
RETURNS SETOF record
AS $$
    SELECT productName, productPrice, round((100 - $1) * 0.01 * productPrice, 2) FROM products;
$$ LANGUAGE SQL;

CREATE FUNCTION steeply_discount_products (x int)
RETURNS TABLE(productName varchar, normalPrice decimal, steeplyDiscountedPrice decimal) AS $$
    SELECT productName, productPrice, round((100 - $1) * 0.01 * 0.5 * productPrice, 2) FROM products;
$$ LANGUAGE SQL;

CREATE FUNCTION discount_products_return_one (x int, OUT productName varchar, OUT normalPrice decimal, OUT discountedPrice decimal)
RETURNS record
AS $$
    SELECT productName, productPrice, round((100 - $1) * 0.01 * productPrice, 2) FROM products;
$$ LANGUAGE SQL;

SELECT * FROM discount_products(20);
SELECT * FROM steeply_discount_products(20);
SELECT * FROM discount_products_return_one(20);
