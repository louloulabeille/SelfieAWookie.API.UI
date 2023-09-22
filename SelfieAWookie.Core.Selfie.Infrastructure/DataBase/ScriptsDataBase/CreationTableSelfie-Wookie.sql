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

create index idx_FK_SelfieWookie on Selfie(WookieId);

commit 