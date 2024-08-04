--Admin user
insert into Human_user values ('Ahmed', 'Ali', 'Giza', 'A', 1);
insert into Human_user values ('Emad', 'Mohamed', 'Giza', 'A', 2);
insert into admin values (1);
insert into admin values (2);
insert into Human_user_Phone values('01121458754',1);
insert into Human_user_Phone values('01128548845',2);

--Customer user
insert into Human_user values ('Ahmed','Hassan','Cairo', 'C', 3);
insert into Human_user values ('Ali','Ahmed','Cairo', 'C', 4);
insert into Human_user values ('Ziad','Mohamed','Cairo', 'C', 5);
insert into Human_user values ('Mariem','Hossam','Cairo','C', 6);
insert into Human_user values ('Mona','Yasser','Cairo', 'C', 7);
insert into customer values(3);
insert into customer values(4);
insert into customer values(5);
insert into customer values(6);
insert into customer values(7);
insert into Human_user_Phone values('01544851254',3);
insert into Human_user_Phone values('01025487555',4);
insert into Human_user_Phone values('01545684523',5);
insert into Human_user_Phone values('01154584651',6);
insert into Human_user_Phone values('01021565444',7);

--login information
insert into website_login values('Admin1','123123123',1);
insert into website_login values('Admin2','456456456',2);

insert into website_login values('Customer1','123123456',3);
insert into website_login values('Customer2','987654321',4);
insert into website_login values('Customer3','456456456',5);
insert into website_login values('Customer4','123456789',6);
insert into website_login values('Customer5','456789123',7);

--Category
insert into category values('Electric Appliances Category',1,'Electric Appliances');
insert into category values('Food Products Category',2,'Food Products');

--Product
insert into product values(1, 'keyboard', 30, 60, 1);
insert into product values(2, 'Laptop', 2000, 30, 1);
insert into product values(3, 'Mobile', 950, 50, 1);
insert into product values(4, 'TV', 1200, 20, 1);

insert into product values(5, 'Tomato', 12, 250, 2);
insert into product values(6, 'Banana', 8, 200, 2);
insert into product values(7, 'Mango', 20, 100, 2);

--orders
-- customer with id 3 orders
insert into take_orders(order_id, amount_sales, date, User_id, p_id) values(1, 2,'2020-12-15', 3, 1);
insert into take_orders(order_id, amount_sales, date, User_id, p_id) values(2, 50, '2020-12-16', 3, 5);
insert into take_orders(order_id, amount_sales, date, User_id, p_id) values(3, 10, '2020-12-17', 3, 6);

-- customer with id 4 orders
insert into take_orders(order_id, amount_sales, date, User_id, p_id) values(4, 4,'2020-12-15', 4, 4);
insert into take_orders(order_id, amount_sales, date, User_id, p_id) values(5, 10, '2020-2-16', 4, 5);
insert into take_orders(order_id, amount_sales, date, User_id, p_id) values(6, 10, '2022-6-16', 4, 7);

-- customer with id 6 orders
insert into take_orders(order_id, amount_sales, date, User_id, p_id) values(7, 1,'2020-3-15', 6, 2);
insert into take_orders(order_id, amount_sales, date, User_id, p_id) values(8, 5, '2020-11-16', 6, 5);
insert into take_orders(order_id, amount_sales, date, User_id, p_id) values(9, 10, '2021-7-12', 6, 6);
insert into take_orders(order_id, amount_sales, date, User_id, p_id) values(10, 5, '2021-7-12', 6, 7);

--customer with id 5 orders
insert into take_orders(order_id, amount_sales, date, User_id, p_id) values(11, 4,'2022-3-15', 5, 5);
insert into take_orders(order_id, amount_sales, date, User_id, p_id) values(12, 1, '2022-11-16', 5, 1);
insert into take_orders(order_id, amount_sales, date, User_id, p_id) values(13, 10, '2022-7-12', 5, 6);
insert into take_orders(order_id, amount_sales, date, User_id, p_id) values(14, 2, '2022-5-12', 5, 7);
insert into take_orders(order_id, amount_sales, date, User_id, p_id) values(15, 5, '2022-6-10', 5, 7);