
--26
CREATE TABLE social_status (
	id serial,
	name 				varchar(50)									not null,
	description 		text 			default'NaD' 				not null,
	primary key(id)
);

--27
CREATE TABLE social_interconnection(
	id serial,
	id_user_first 		int 			REFERENCES users(id)
		ON DELETE CASCADE ON UPDATE CASCADE					 		not null,
	id_user_second 		int 			REFERENCES users(id) 
		ON DELETE CASCADE ON UPDATE CASCADE							not null,
	id_social_status  			smallint 		REFERENCES social_status(id)
		ON DELETE CASCADE ON UPDATE CASCADE					 		not null,
	primary key(id)	
);

--32
CREATE TABLE similar_views(
	id serial,
	id_user_first  		int 			 REFERENCES users(id)
		ON DELETE CASCADE ON UPDATE CASCADE					 		not null,
	id_user_second 		int 			 REFERENCES users(id)
		ON DELETE CASCADE ON UPDATE CASCADE					 		not null,
	primary key(id)
);


--24
CREATE TABLE message(                 
	id serial,
	departure_date 		TIMESTAMP 									not null,
	msg 				text 										not null, 
	primary key(id)	
);

--25
CREATE TABLE user_message(             
	id serial,
	id_user_first 		int			 	REFERENCES users(id)
		ON DELETE CASCADE ON UPDATE CASCADE 						not null,
	id_user_second 		int 			REFERENCES users(id)
		ON DELETE CASCADE ON UPDATE CASCADE 						not null,
	id_message 			int				REFERENCES message(id)
		ON DELETE CASCADE ON UPDATE CASCADE					 		not null,
	primary key(id)	
);


CREATE TABLE activity_status (
	id serial,
	name 				varchar(50)									not null,
	description 		text 			default'NaD' 				not null,
	primary key(id)
);

--3
CREATE TABLE activity_status_user(

	id serial,
	id_user						int		 REFERENCES users(id)
		ON DELETE CASCADE ON UPDATE CASCADE 					not null,
	id_activity_status			int		 REFERENCES activity_status(id)
		ON DELETE CASCADE ON UPDATE CASCADE 					not null,
	primary key(id)
);