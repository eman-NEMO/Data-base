/*create database SuperMarket;*/

CREATE TABLE Human_user
(
  First_Name VARCHAR(255) NOT NULL,
  Last_Name VARCHAR(255) NOT NULL,
  Adress VARCHAR(255) NOT NULL,
  type VARCHAR(10) NOT NULL,
  User_id INT NOT NULL,
  PRIMARY KEY (User_id)
);

CREATE TABLE website_login
(
  user_name VARCHAR(255) NOT NULL,
  password VARCHAR(255) NOT NULL,
  User_id INT NOT NULL,
  PRIMARY KEY (user_name),
  FOREIGN KEY (User_id) REFERENCES Human_user(User_id)
);

CREATE TABLE customer
(
  Customer_id INT NOT NULL,
  PRIMARY KEY (Customer_id),
  FOREIGN KEY (Customer_id) REFERENCES Human_user(User_id)
);

CREATE TABLE admin
(
  Admin_id INT NOT NULL,
  PRIMARY KEY (Admin_id),
  FOREIGN KEY (Admin_id) REFERENCES Human_user(User_id)
);

CREATE TABLE Discount
(
  discount_id VARCHAR(255) NOT NULL,
  discount_quantity FLOAT NOT NULL,
  start_date DATE NOT NULL,
  end_date DATE NOT NULL,
  PRIMARY KEY (discount_id)
);

CREATE TABLE category
(
  descrption VARCHAR(255) NOT NULL,
  category_id VARCHAR(255) NOT NULL,
  name VARCHAR(255) NOT NULL,
  PRIMARY KEY (category_id)
);

CREATE TABLE handle
(
  Customer_id INT NOT NULL,
  Admin_id INT NOT NULL,
  PRIMARY KEY (Customer_id, Admin_id),
  FOREIGN KEY (Customer_id) REFERENCES customer(Customer_id),
  FOREIGN KEY (Admin_id) REFERENCES admin(Admin_id)
);

CREATE TABLE Human_user_Phone
(
  Phone VARCHAR(255) NOT NULL,
  User_id INT NOT NULL,
  PRIMARY KEY (Phone, User_id),
  FOREIGN KEY (User_id) REFERENCES Human_user(User_id)
);

CREATE TABLE product
(
  p_id VARCHAR(255) NOT NULL,
  name VARCHAR(255) NOT NULL,
  price FLOAT NOT NULL,
  quantity INT NOT NULL,
  category_id VARCHAR(255) NOT NULL,
  PRIMARY KEY (p_id),
  FOREIGN KEY (category_id) REFERENCES category(category_id)
);

CREATE TABLE take_orders
(
  amount_sales FLOAT NOT NULL,
  date DATE NOT NULL,
  order_id INT NOT NULL,
  User_id INT NOT NULL,
  p_id VARCHAR(255) NOT NULL,
  PRIMARY KEY (order_id),
  FOREIGN KEY (User_id) REFERENCES customer(Customer_id),
  FOREIGN KEY (p_id) REFERENCES product(p_id),
);

CREATE TABLE product_discount
(
  p_id VARCHAR(255) NOT NULL,
  discount_id VARCHAR(255) NOT NULL,
  PRIMARY KEY (p_id, discount_id),
  FOREIGN KEY (p_id) REFERENCES product(p_id),
  FOREIGN KEY (discount_id) REFERENCES Discount(discount_id)
);

CREATE TABLE browsing
(
  p_id VARCHAR(255) NOT NULL,
  User_id INT NOT NULL,
  PRIMARY KEY (p_id, User_id),
  FOREIGN KEY (p_id) REFERENCES product(p_id),
  FOREIGN KEY (User_id) REFERENCES Human_user(User_id)
);

CREATE TABLE manage
(
  User_id INT NOT NULL,
  p_id VARCHAR(255) NOT NULL,
  PRIMARY KEY (User_id, p_id),
  FOREIGN KEY (User_id) REFERENCES admin(Admin_id),
  FOREIGN KEY (p_id) REFERENCES product(p_id)
);

ALTER TABLE product
ADD CONSTRAINT CheckPrice check(price >= 0);
ALTER TABLE product
ADD CONSTRAINT CheckQ check(quantity >= 0);
ALTER TABLE take_orders
ADD CONSTRAINT CheckA check(amount_sales > 0);

