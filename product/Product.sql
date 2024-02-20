CREATE DATABASE Product

USE Product

CREATE TABLE Products(
	ID int NOT NULL identity(1,1) Primary Key,
	name nvarchar(max) NOT NULL,
	type nvarchar(max) NOT NULL,
	color nvarchar(20) NOT NULL,
	calories int NOT NULL
)

INSERT INTO Products (name, type, color, calories)
VALUES ('Яблоко', 'Фрукт', 'Красный', 52),
       ('Банан', 'Фрукт', 'Желтый', 89),
       ('Морковь', 'Овощ', 'Оранжевый', 41),
       ('Брокколи', 'Овощ', 'Зеленый', 55),
       ('Клубника', 'Фрукт', 'Красный', 32);