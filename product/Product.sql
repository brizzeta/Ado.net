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
VALUES ('������', '�����', '�������', 52),
       ('�����', '�����', '������', 89),
       ('�������', '����', '���������', 41),
       ('��������', '����', '�������', 55),
       ('��������', '�����', '�������', 32);