create database Storage;
use Storage;

create table Good (              /*�����*/
	id int primary key identity(1, 1) not null,
	name varchar(50) not null,
	Good_type varchar(50) not null
);

create table Good_Provider (             /*���������*/
	id int primary key identity(1, 1) not null,
	name varchar(50) not null,
);

create table Price (                     /*����*/
	id int primary key identity(1, 1) not null,
	price money not null
);

create table storage (                 /*�����*/
	id int primary key identity(1, 1) not null,
	Good_id int foreign key references Good(id),
	Price_id int foreign key references Price(id),
	Provider_id int foreign key references Good_Provider(id),
	Good_count int not null,
	Delivery_date date not null
);


INSERT INTO Good (name, Good_type) VALUES
('�����', '����������'),
('�������', '�����������'),
('��������', '������'),
('����', '������'),
('���', '�����������');


INSERT INTO Good_Provider (name) VALUES
('��������� ��������'),
('��������� ��������'),
('��������� �������');


INSERT INTO Price (price) VALUES
(100),
(800),
(20),
(500),
(50);


INSERT INTO storage (Good_id, Price_id, Provider_id, Good_count, Delivery_date) VALUES
(1, 1, 1, 50, '2023-05-01'),
(2, 2, 2, 20, '2023-08-23'),
(3, 3, 3, 100, '2023-10-05'),
(4, 4, 1, 10, '2024-01-01'),
(5, 5, 2, 30, '2024-02-04');