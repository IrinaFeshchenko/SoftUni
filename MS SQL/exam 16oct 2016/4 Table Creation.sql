create table CustomerReviews(
ReviewID int primary key,
ReviewContent varchar(255) not null,
ReviewGrade int check(ReviewGrade between 0 and 10),
AirlineID int foreign key references Airlines(AirlineID),
CustomerID  int foreign key references Customers(CustomerID)
)

create table CustomerBankAccounts(
AccountID int primary key,
AccountNumber varchar(10) not null,
Balance decimal(10,2) not null,
CustomerID int foreign key references Customers(CustomerID)
)
