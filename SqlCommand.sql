----Creating a user message table
create table Contact_Us(Code int primary key identity, 
FirstName nvarchar(max),LastName nvarchar(max),Email nvarchar(max), Message nvarchar(max), JoinedNewsletter bit, Date datetime)

----Creating a registration request table
create table Register_Applications(Code int primary key identity, 
Name nvarchar(max), Email nvarchar(max), Role_Request nvarchar(max),Is_Approved bit)

----Creating a table of non-profit organizations
create table Non_Profit_Organizations(Code int primary key identity, 
Name nvarchar(max), Email nvarchar(max), Website_URL nvarchar(max),Image nvarchar(MAX),Register_Time datetime)

----Creating a table of social activists
create table Social_Activist(Code int primary key identity, 
FirstName nvarchar(max),LastName nvarchar(max), Email nvarchar(max), Address nvarchar(max), Phone_Number nvarchar(max), Money_Status money, Image nvarchar(MAX),Register_Time datetime)

----Creating a table of campaigns
create table Campaigns(Code int primary key identity, 
Name nvarchar(max), Email nvarchar(max),Description nvarchar(max), Landing_Page_URL nvarchar(max), HashTag nvarchar(max), 
NPO_code int foreign key references Non_Profit_Organizations (code), Image nvarchar(MAX), Is_Active bit)

----Creating a table of business companies
create table Buisness_Companies(Code int primary key identity, 
Name nvarchar(max), Email nvarchar(max), Image nvarchar(MAX),Register_Time datetime)

 ----Creating a product table
create table Products(Code int primary key identity, 
Name nvarchar(max), Price money,Description nvarchar(max), Units_In_Stock int,BC_code int foreign key references Buisness_Companies (code),
Campaign_code int foreign key references Campaigns (code), Image nvarchar(MAX))

 ----Creating an order table
create table Orders(Code int primary key identity, 
SA_code int foreign key references Social_Activist (code),BC_code int foreign key references Buisness_Companies (code),
Campaign_code int foreign key references Campaigns (code),Product_code int foreign key references Products (code),Quantity int,
Order_Time datetime, Is_Sent bit)

 ----Creating a table of tweets
create table Tweets(Code int primary key identity, 
SA_code int foreign key references Social_Activist (code), Campaign_code int foreign key references Campaigns (code),
HashTag nvarchar(max), Landing_Page_URL nvarchar(max),Tweet_Content nvarchar(max), Tweet_Time datetime)


select * from Contact_Us

select * from Non_Profit_Organizations

select * from Buisness_Companies

select * from Register_Applications

select * from Tweets

select * from Campaigns

select * from Social_Activist

select * from Products

select * from Orders





update Register_Applications set Is_Approved = 0 where code = '3'

select * from Register_Applications where Is_Approved =0


select Is_Aproved from Register_Applications where Email like 'email@gmail.com'

insert into Social_Activist values ('yoni','golan','yo@gmail.com','herzelia','0503661994',0,'Image' ,getdate())

insert into Non_Profit_Organizations values ('yoni','yonig15@gmail.com','url','url_image',getdate())

insert into Campaigns values ('cats','catdo@gmail.com','chidi is very good','Landing_url','#dogs for you',1,'url_image',0)

insert into Tweets values (1,1,'#dogs','Landing_url','isreal',getdate())

update Campaigns set Name = '" + m_Campaign.Name + "', Email = '" + m_Campaign.Email + "', Description = '" + m_Campaign.Description + "', Landing_Page_URL = '" + m_Campaign.Landing_Page_URL + "',HashTag = '" + m_Campaign.HashTag + "',NPO_code=2, Image = '" + m_Campaign.Image + "' where Code = 2

select * from Products where BC_Code = 1

select * from Campaigns where NPO_code =2

select * from Non_Profit_Organizations where Email='be.happy.015@gmail.com' 

select * from Products where Campaign_code = 1002


insert into Orders values (SA_code, BC_code, Campaign_code, Product_code, getdate(), 0)  update Products set Units_In_Stock = Units_In_Stock - 1 where Code = Product_code


select * from Social_Activist

update Social_Activist set Money_Status= 200 where Code=1

select [Quantity] from Orders
select * from Orders

SELECT Products.Name as 'Product_Name', Products.Price as 'Price', COUNT(Orders.Code) as 'Donation_Count',
sum(Orders.Quantity) as 'Quantity',Products.Price*sum(Orders.Quantity) as 'Total_Price', Campaigns.Name as 'Campaign_Name'
FROM Orders
JOIN Products ON Products.Code = Orders.Product_code
JOIN Campaigns ON Orders.Campaign_code = Campaigns.Code
WHERE Orders.SA_code = 1
GROUP BY Products.Name, Products.Price, Campaigns.Name;