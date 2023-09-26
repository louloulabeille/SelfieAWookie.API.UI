Begin transaction

create table Wookie(
	Id int not null identity(1,1),
	Surname nvarchar(155) not null,
	Primary key(Id)
);

create table Selfie( 
	Id int not null identity(1,1),
	Title nvarchar(100) not null,
	ImagePath nvarchar(150),
	WookieId int not null
	Primary key(Id),
	Constraint FK_SelfieWookie Foreign key (WookieId) References Wookie(Id)
);

alter table Selfie drop ImagePath;

alter table Selfie
 add ImageId int;

alter  table Selfie add Constraint FK_SelfieImage Foreign key (ImageId) references Images(Id);

 create table Images(
 Id int primary key not null identity(1,1),
 Url nvarchar(255))

create index idx_FK_SelfieImages on Selfie(ImageId);
create index idx_FK_SelfieWookie on Selfie(WookieId);

commit 