create database if not exists final character set utf8;
use final;

create table stock
	( 	number int primary key,
		max double not null,
        min double not null,
        storage int not null,
        profit double not null
    ) engine = InnoDB;

create table stock_company
	( 	number int,
		name varchar(16) not null,
        type varchar(12) not null,
		foreign key (number) references stock(number) on delete cascade on update cascade
	);
    
create table stock_purchase_time
	( 	number int,
		name varchar(16) not null,
        purchase_date date not null,
		foreign key (number) references stock(number) on delete cascade on update cascade
	);
    
create table company_analysis
	( 	number int,
		name varchar(16) not null ,
        analysis varchar(16) not null,
		foreign key (number) references stock(number) on delete cascade on update cascade
	);
    
create table company_build
	( 	name varchar(16) not null primary key,
        build_time varchar(16) not null,
		build_place varchar(17) not null
	) engine = InnoDB;
    
create table company_leader
	(	name varchar(16) not null,
		leader varchar(16) not null,
		foreign key (name) references company_build(name) on delete cascade on update cascade
	);
    
insert into stock values
	('000001',34.28,32.66,2000,128907.2);
    
insert into stock values
	('000002',66.76,63.27,3000,289271.2);
    
insert into stock values
	('000003',75.28,72.25,2000,100281.2);
    
insert into stock values
	('000004',23.12,20.98,1000,80081.3);   
    
 insert into stock values
	('000005',13.88,13.44,1500,110287.7);   
    
insert into  stock_company values
	('000001','apple','technology');

insert into  stock_company values
	('000002','facebook','technology');

insert into  stock_company values
	('000003','bmw','car');
    
insert into  stock_company values
	('000004','msci','finance');  
    
insert into  stock_company values
	('000005','peach','grocery');  
    
insert into stock_purchase_time values
	('000001','apple','2012-1-12');
    
insert into stock_purchase_time values
	('000002','facebook','2012-2-18');  
    
insert into stock_purchase_time values
	('000003','bmw','2013-8-28');
    
insert into stock_purchase_time values
	('000004','msci','2014-9-30');

insert into stock_purchase_time values
	('000001','peach','2016-10-11');
    
insert into company_analysis values
	('000001','apple','good');
    
insert into company_analysis values
	('000002','facebook','good');

insert into company_analysis values
	('000003','bmw','medium');
    
insert into company_analysis values
	('000004','msci','medium');
    
insert into company_analysis values
	('000005','peach','bad');
    
insert into company_build values
	('apple','1893-3-2','us');
    
insert into company_build values
	('facebook','1991-4-2','us');
    
insert into company_build values
	('bmw','1880-10-7','german');

insert into company_build values
	('msci','1879-2-8','us');
    
insert into company_build values
	('peach','2013-11-12','uk');
    
insert into company_leader values
	('apple','cook');
    
insert into company_leader values
	('facebook','mark');
    
insert into company_leader values
	('bmw','anna');

insert into company_leader values
	('msci','mogen');
    
insert into company_leader values
	('peach','jack');