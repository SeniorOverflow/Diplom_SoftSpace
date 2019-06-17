
CREATE EXTENSION pgcrypto;
--1
CREATE TABLE users (
	id serial,
	first_name 		varchar(50) 	default 'Не указанно' 	not null,
	second_name		varchar(50) 	default 'Не указанно'	not null,
	login			varchar(50) 	UNIQUE 					not null,
	password 		text 									not null,
	mail 			text 			UNIQUE					not null,
	lvl             int             default '1'				not null,
	score			decimal(10,2) 	default '0.00' 			not null,
	bonus_score 	decimal(10,2) 	default '0.00'			not null,
	picture_profile varchar(100) 	default 'NaPicture.png' not null,
	primary key(id)
);



--2
CREATE TABLE developers (
	id serial,
	name_of_company 	varchar(50)		 UNIQUE  		 	 not null,
	url_on_logo         varchar(100)	 default'NaL'        not null,
	description 		text 			 default'NaD'		 not null,
	address 			varchar(100)	 default'NaA'		 not null,
	mail 				text 			 default'NaM'		 not null,
	phone 				varchar(80) 	 default'NaP'		 not null,
	score 				decimal(10,2) 	 default '0.00' 	 not null,
	primary key(id)
);

--3
CREATE TABLE user_dev(
	id serial,
	id_user				int		 REFERENCES users(id)
		ON DELETE CASCADE ON UPDATE CASCADE 					not null,
	id_dev 				int 	 REFERENCES developers(id)
		ON DELETE CASCADE ON UPDATE CASCADE						not null,
	primary key(id)	
);
--4
CREATE TABLE type_of_subscription(
	id serial,
	name				varchar(50) 							not null,
	count_days   		int 				default '0' 		not null,
	price 				decimal(10,2) 		default '0.00'		not null,
	primary key(id)	
);
--5
CREATE TABLE subscription_on_dev(
	id serial,
	id_type 			int 				REFERENCES type_of_subscription(id)
		ON DELETE CASCADE ON UPDATE CASCADE										 	not null,
	id_dev 				int 				REFERENCES developers(id)
		ON DELETE CASCADE ON UPDATE CASCADE											not null,
	id_user 			int 				REFERENCES users(id)
		ON DELETE CASCADE ON UPDATE CASCADE											not null,
	date_begin 			TIMESTAMP 													not null,
	date_end 			TIMESTAMP 													not null,
	primary key(id)	
);

--6
CREATE TABLE user_sub_on_dev(
	id serial,
	id_user 			int 		REFERENCES users(id)
		ON DELETE CASCADE ON UPDATE CASCADE					 					not null,
	id_subscription		int			REFERENCES subscription_on_dev(id)
		ON DELETE CASCADE ON UPDATE CASCADE										not null,
	primary key(id)	
);

--7
CREATE TABLE category (
	id serial,
	name 				varchar(50) 								not null,
	description 		text 			default 'NaD' 				not null,
	def_picture			varchar(100) 	default 'NaPicture' 		not null, 
	primary key(id)
);

--8
CREATE TABLE picture_category(
	id serial,
	id_category 		int 			REFERENCES category(id)
		ON DELETE CASCADE ON UPDATE CASCADE							not null,
	url_picture 		varchar(100) 	default 'NaPicture' 		not null,
	primary key(id)	
);

--9
CREATE TABLE product(
	id serial,
	name 				varchar(100)	UNIQUE						 not null,
	description 		text 			default 'NaDescription' 	 not null,
	id_dev 				int 			REFERENCES developers(id) 	
		ON DELETE CASCADE ON UPDATE CASCADE	 						 not null,
	id_category 		int 			REFERENCES category(id) 
		ON DELETE CASCADE ON UPDATE CASCADE							 not null,
	price				decimal(10,2)	default '0.00' 				 not null,
	url_on_product 		varchar(100) 	default 'NaUrlOnProduct'	 not null,
	def_picture			varchar(100) 	default 'NaPicture.png' 	 not null,
	is_dlc				boolean			default false 				 not null,
	is_invisuble		boolean			default false 				 not null,
	primary key(id)
);

--10
CREATE TABLE picture_product (
	id serial,
	id_product 			int 			REFERENCES product(id)
		ON DELETE CASCADE ON UPDATE CASCADE					 		 not null,
	url_picture 		varchar(100) 	default 'NaU' 				 not null,
	primary key(id)
);

--11
CREATE TABLE label_product (
	id serial,
	id_product 			int 			REFERENCES product(id)
		ON DELETE CASCADE ON UPDATE CASCADE					 		 not null,
	label_name 		    varchar(20) 	default 'NaL' 				 not null,
	primary key(id)
);

--12
CREATE TABLE event_product (
	id serial,
	id_product 			int 			REFERENCES product(id)
		ON DELETE CASCADE ON UPDATE CASCADE					 		 not null,
	event_name 		    varchar(100) 	default 'NaP' 				 not null,
	date_event 			TIMESTAMP 									 not null,
	description 		text 			default'NaD' 				 not null,
	def_picture			varchar(100) 	default 'NaPicture' 		 not null, 
	primary key(id)
);

--13
CREATE TABLE picture_event (
	id serial,
	id_envent 			int 			REFERENCES event_product(id)
			ON DELETE CASCADE ON UPDATE CASCADE						 		 not null,
	url_picture 		varchar(100) 	default 'NaU' 						 not null,
	primary key(id)
);

--14
CREATE TABLE dlc_for_product(
	id serial,
	id_product 		    int  			REFERENCES product(id)
		ON DELETE CASCADE ON UPDATE CASCADE				 		not null,
	id_sub_product 		int 			REFERENCES product(id) 
		ON DELETE CASCADE ON UPDATE CASCADE						not null,
	primary key(id)	
);

--15
CREATE TABLE roles  (
	id serial,
	name 				varchar(50) 	UNIQUE						not null,
	description 		text 			default'NaD'				not null,
	primary key(id)
);

--16
CREATE TABLE user_role(
	id serial,
	id_user			 	int 	REFERENCES users(id)
		ON DELETE CASCADE ON UPDATE CASCADE			 			 		not null,
	id_role 			int 	REFERENCES roles(id)
		ON DELETE CASCADE ON UPDATE CASCADE			 	default '1' 	not null,
	primary key(id)	
);

--17 
CREATE TABLE abilities(
	id serial,
	name 				varchar(50) 	UNIQUE						not null,
	description 		text 			default'NaD'				not null,
	primary key(id)
);

--18 
CREATE TABLE role_abilities(
	id serial,
	id_abilities		int 	REFERENCES abilities(id)
		ON DELETE CASCADE ON UPDATE CASCADE			 			 		not null,
	id_role 			int 	REFERENCES roles(id)
		ON DELETE CASCADE ON UPDATE CASCADE			 	 				not null,
	primary key(id)	
);

--19
CREATE TABLE review  (
	id serial,
	id_product 			int			REFERENCES product(id)
		ON DELETE CASCADE ON UPDATE CASCADE				 		not null,
	id_user 			int		 	REFERENCES users(id)
		ON DELETE CASCADE ON UPDATE CASCADE				 		not null,
	assessment 			smallint 	default'5',
	comment_to_product 	text 	 	default'NaC' 				not null,
	primary key(id)
);

--20
CREATE TABLE deal (
	id serial,
	id_user 			int 			REFERENCES users(id)
		ON DELETE CASCADE ON UPDATE CASCADE					 		not null,
	date_deal 			TIMESTAMP 									not null,
	total_price 		decimal(10,2)	default'0.00' 				not null,
	primary key(id)
);

--21
CREATE TABLE deal_product (
	id serial,
	id_deal				int 			REFERENCES deal(id) 
		ON DELETE CASCADE ON UPDATE CASCADE							not null,
	id_product 			int				REFERENCES product(id)
		ON DELETE CASCADE ON UPDATE CASCADE					 		not null,
	count 				int 			default'0' 					not null,
	price 				decimal(10,2) 	default'0.00' 				not null,
	primary key(id)
);

--22
CREATE TABLE library (
	id serial,
	id_user 		  			int 			REFERENCES users(id)
		ON DELETE CASCADE ON UPDATE CASCADE					 		not null,
	id_deal_product 			int				REFERENCES deal_product(id)        
		ON DELETE CASCADE ON UPDATE CASCADE			UNIQUE	 		not null,
	count_hours 		int 			default'0' 					not null,
	primary key(id)
);

--23
CREATE TABLE baggage (
	id serial,
	id_user 			int 			REFERENCES users(id)
		ON DELETE CASCADE ON UPDATE CASCADE					 		not null,
	id_deal_product 	int				REFERENCES deal_product(id)        
		ON DELETE CASCADE ON UPDATE CASCADE			    	 		not null,
	primary key(id)
);

--24
CREATE TABLE block_user (
	id serial,
	id_user 			int 			REFERENCES users(id)
		ON DELETE CASCADE ON UPDATE CASCADE					 		not null,
	date_begin 			TIMESTAMP 									not null,
	date_end 			TIMESTAMP 									not null,
	cause 				text 			default'NaC' 				not null,
	primary key(id)
);

--25
CREATE TABLE shopping_cart(
	id serial,
	id_product 			int 			REFERENCES product(id)
		ON DELETE CASCADE ON UPDATE CASCADE				 			not null,
	id_user 			int 			REFERENCES users(id) 		
		ON DELETE CASCADE ON UPDATE CASCADE							not null,
	count 				int 			default'0' 					not null,
	primary key(id)
);

--26
CREATE TABLE liked_product(
	id serial,
	id_product 			int 			REFERENCES product(id)
			ON DELETE CASCADE ON UPDATE CASCADE 					not null,
	id_user 			int 			REFERENCES users(id)
			ON DELETE CASCADE ON UPDATE CASCADE				 		not null,
	primary key(id)
);

--27
CREATE TABLE recommended_product(
	id serial,
	id_product 			int				REFERENCES product(id)
		ON DELETE CASCADE ON UPDATE CASCADE					 		not null,
	id_user 			int 			REFERENCES users(id)
		ON DELETE CASCADE ON UPDATE CASCADE 						not null,
	primary key(id)
);

--28
CREATE TABLE liked_category(
	id serial,
	id_category 		int 			REFERENCES category(id)
		ON DELETE CASCADE ON UPDATE CASCADE						 	not null,
	id_user 			int 			REFERENCES users(id)
		ON DELETE CASCADE ON UPDATE CASCADE					 		not null,
	primary key(id)
);

--29
CREATE TABLE confirmation_email(
	id serial,
	id_user 			int  			REFERENCES users(id)
		ON DELETE CASCADE ON UPDATE CASCADE							 not null,
	date_begin 			TIMESTAMP 									 not null,
	date_end 			TIMESTAMP 									 not null,
	code 				varchar(20) 								 not null,
	primary key(id)
);

--30

CREATE TABLE discount(
	id serial,
	id_product 			int  			REFERENCES product(id)
		ON DELETE CASCADE ON UPDATE CASCADE							 not null,
	discount_price 		decimal(10,2)  	default'0.00' 			  	 not null,

	date_begin 			TIMESTAMP 									 not null,
	date_end 			TIMESTAMP 									 not null,
	primary key(id)
);

