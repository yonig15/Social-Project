----Creating a user message table
create table Contact_Us(Code int primary key identity, 
FirstName nvarchar(max),LastName nvarchar(max),Email nvarchar(max), Message nvarchar(max), JoinedNewsletter bit, date datetime)

----Creating a registration request table
create table Register_Applications(Code int primary key identity, 
Name nvarchar(max), Email nvarchar(max), Role_Request nvarchar(max),Is_Aproved bit)


----Creating a table of non-profit organizations
create table Non_Profit_Organizations(Code int primary key identity, 
Name nvarchar(max), Email nvarchar(max), Website_URL nvarchar(max),Image nvarchar(MAX))

----Creating a table of social activists
create table Social_Activist(Code int primary key identity, 
FirstName nvarchar(max),LastName nvarchar(max), Email nvarchar(max), Address nvarchar(max), Phone_Number nvarchar(max), Money_Status money, Image nvarchar(MAX))

----Creating a table of campaigns
create table Campaigns(Code int primary key identity, 
Name nvarchar(max), Email nvarchar(max), Landing_Page_URL nvarchar(max), HashTag nvarchar(max), 
NPO_code int foreign key references Non_Profit_Organizations (code), Image nvarchar(MAX), Is_Active bit)

----Creating a table of business companies
create table Buisness_Companies(Code int primary key identity, 
Name nvarchar(max), Email nvarchar(max), Image nvarchar(MAX))

 ----Creating a product table
create table Products(Code int primary key identity, 
Name nvarchar(max), Price money, Units_In_Stock int,BC_code int foreign key references Buisness_Companies (code),
Campaign_code int foreign key references Campaigns (code), Image nvarchar(MAX))

 ----Creating an order table
create table Orders(Code int primary key identity, 
SA_code int foreign key references Social_Activist (code),BC_code int foreign key references Buisness_Companies (code),
Campaign_code int foreign key references Campaigns (code),Product_code int foreign key references Products (code),
Order_Time datetime, is_Sent bit)

 ----Creating a table of tweets
create table Tweets(Code int primary key identity, 
SA_code int foreign key references Social_Activist (code), Campaign_code int foreign key references Campaigns (code),
HashTag nvarchar(max), Landing_Page_URL nvarchar(max),Tweet_Content nvarchar(max), Tweet_Time datetime)

