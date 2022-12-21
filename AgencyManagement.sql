create database AgencyManagemnt
go

use AgencyManagemnt
go

set dateformat DMY
go

create table Units
(
	Id varchar(10) primary key not null,
	Value NVarchar(20) 
)
go

create table TypeOfAgency
(
	Id varchar(10) primary key not null,
	Type int,
	MaxDebt money,
)
go

create table Agency
(
	AgencyId varchar(10) not null primary key,
	AgencyName NVarchar(100),
	TypeId	varchar(10),
	PhoneNumber	Varchar(15),
	Address	NVarchar(100),
	District	NVarchar(20),
	DayReception	SmallDateTime,
	foreign key (TypeId) references TypeOfAgency(Id),
)

create table AgencyDebt
(
	AgencyId varchar(10) not null,
	Month int,
	Year int,
	FirsDebt money,
	Incurred money,
	foreign key (AgencyId) references Agency(AgencyId),
)
go

create table Items
(
	ItemsId varchar(10) not null primary key,
	ItemsName NVarchar(100),
	UnitId varchar(10),
	Price money,
	foreign key (UnitId) references Units(Id),
)
go

create table ExportSlip
(
	ExportSlipId varchar(10) not null primary key,
	AgencyId	Varchar(10) not null,
	Date	SmallDateTime,
	AmountPaid	Money,
	foreign key (AgencyId) references Agency(AgencyId),
)
go

create table ExportSlipDetail
(
	ExportSlipId varchar(10) not null,
	ItemsId	Varchar(10) not null,
	Amount	Int,
	foreign key (ItemsId) references Items(ItemsId),
	foreign key (ExportSlipId) references ExportSlip(ExportSlipId)
)
go

create table Receipts
(
	ReceiptId varchar(10) not null primary key,
	AgencyId	Varchar(10) not null,
	Date	SmallDateTime,
	Proceeds	Money
	foreign key (AgencyId) references Agency(AgencyId),
)
go

create table TurnoverReport
(
	TurnoverId varchar(10) not null primary key,
	Month	Int,
	Year	Int,
)
go

create table DebtsReport
(
	DebtsId varchar(10) not null primary key,
	Month	Int,
	Year	Int
)
go

create table Reference
(
	Id varchar(10) primary key,
	Name NVarchar(100),
	Value int,
)
go
