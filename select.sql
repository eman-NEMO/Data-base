-- a
select p_id as ProductID, name as ProductName
from product
where p_id in (
	select p_id
	from take_orders
	group by p_id
	having COUNT(*) = (
		select MAX(o.cnt)
		from (select COUNT(*) as cnt 
			  from take_orders
			  group by p_id
			 ) as o
		)
	)

-- b
select p_id as ProductID, name as ProductName
from product 
where p_id NOT IN ( select p_id from take_orders 
					where MONTH(date) = 12 and YEAR(date) = 2020)

-- c
select Customer_id as CustomerID, First_Name , Last_Name 
from customer join Human_user on Customer_id = User_id 
where Customer_id not in( select distinct User_id from take_orders where YEAR(date) = 2021 )

-- d
-- if he mean by highest purchase the highest number of orders
select Customer_id as CustomerID, First_Name , Last_Name
from customer join Human_user on Customer_id = User_id
where Customer_id in (
	select User_id
	from take_orders
	where MONTH(date) = MONTH(GETDATE()) and YEAR(date) = YEAR(GETDATE())
	group by User_id
	having COUNT(*) = (
		select MAX(o.cnt)
		from (select COUNT(*) as cnt 
			  from take_orders
			  where MONTH(date) = MONTH(GETDATE()) and YEAR(date) = YEAR(GETDATE())
			  group by User_id
			 ) as o
		)
	)

-- if he mean by highest purchase the highest amount 
select Customer_id as CustomerID, First_Name , Last_Name
from customer join Human_user on Customer_id = User_id
where Customer_id in (
	select User_id
	from take_orders
	where MONTH(date) = MONTH(GETDATE()) and YEAR(date) = YEAR(GETDATE())
	group by User_id
	having SUM(amount_sales) = (
		select MAX(o.cnt)
		from (select SUM(amount_sales) as cnt 
			  from take_orders
			  where MONTH(date) = MONTH(GETDATE()) and YEAR(date) = YEAR(GETDATE())
			  group by User_id
			 ) as o
		)
	)

-- e
-- if he want number of orders
select category_id as 'Category ID', name as 'Category Name'
from category
where category_id in (
	select category_id
	from product join take_orders on product.p_id = take_orders.p_id
	group by category_id
	having count(*) = (
		select MAX(o.cnt)
		from (select COUNT(*) as cnt 
			  from product join take_orders on product.p_id = take_orders.p_id
			  group by category_id
			 ) as o
		) 
	)
-- if he want quantity
select category_id as 'Category ID', name as 'Category Name'
from category
where category_id in (
	select category_id
	from product join take_orders on product.p_id = take_orders.p_id
	group by category_id
	having SUM(take_orders.amount_sales) = (
		select MAX(o.cnt)
		from (select SUM(take_orders.amount_sales) as cnt 
			  from product join take_orders on product.p_id = take_orders.p_id
			  group by category_id
			 ) as o
		) 
	)


-- f
SELECT product.p_id AS ID, product.name, product.price, product.quantity, category.name as 'Category Name', count(orders.p_id) AS 'Number of Customers'
FROM (select distinct p_id, User_id from take_orders) as orders
		RIGHT JOIN product ON product.p_id = orders.p_id JOIN category ON category.category_id = product.category_id 
GROUP BY product.p_id, product.name, product.price, product.quantity, category.name