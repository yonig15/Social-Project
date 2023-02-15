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

----Creating a table of Configuration
create table Configuration(Code int primary key identity, 
Name nvarchar(max), value nvarchar(max))


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

select * from Orders where BC_Code =1


select * from Campaigns where NPO_code =2

select * from Non_Profit_Organizations where Email='be.happy.015@gmail.com' 

select * from Products where Campaign_code = 1002


insert into Orders values (SA_code, BC_code, Campaign_code, Product_code, getdate(), 0)  update Products set Units_In_Stock = Units_In_Stock - 1 where Code = Product_code

Campaign_code
select * from Social_Activist

update Social_Activist set Money_Status= 200 where Code=1

select [Quantity] from Orders
select * from Orders

SELECT Products.Name as 'Product_Name', Products.Price as 'Price', COUNT(Orders.Code) as 'Total_Donations',
sum(Orders.Quantity) as 'Quantity',Products.Price*sum(Orders.Quantity) as 'Total_Price', Campaigns.Name as 'Campaign_Name'
FROM Orders
JOIN Products ON Products.Code = Orders.Product_code
JOIN Campaigns ON Orders.Campaign_code = Campaigns.Code
WHERE Orders.SA_code = 1
GROUP BY Products.Name, Products.Price, Campaigns.Name;

select Orders.*, SA.FirstName+' '+ SA.LastName as SA_Name, BC.Name as BC_Name, Campaigns.Name as Campaign_Name, Products.Name as Product_Name, 
SA.Address as Activist_Address, SA.Phone_Number as Activist_Phone,
SA.Email as Activist_Email, Campaigns.Email as Campaign_Email 
from Orders
inner join Social_Activist as SA on Orders.SA_code = SA.Code
inner join Buisness_Companies as BC on Orders.BC_code = BC.Code
inner join Campaigns on Orders.Campaign_code = Campaigns.Code
inner join Products on Orders.Product_code = Products.Code where Orders.BC_code= 1



update Social_Activist set Money_Status = Money_Status+5 where code = 1

select * from Tweets


select * from Social_Activist

insert into Tweets values(1,1,'#hastag','www.google.com','you are ok', getdate())

insert into Tweets values(sa_code,campain_code,hashtag,landing_url,tweet_content, getdate())

insert into Tweets values('1','1','#ShoshaSaveTheWorld','http://127.0.0.1:5173','Help the baby Shosha save the world and donate things for babies together with her', getdate()) where Code = 1


ALTER TABLE Social_Activist
ADD Twitter_Name NVARCHAR(MAX) NULL;

ALTER TABLE Tweets
ADD Tweet_id NVARCHAR(MAX) NULL;


if not exists(select Code from Tweets where Tweet_id like '" + newTweet.Tweet_id + "')\r\n\tbegin\r\n\t\t insert into Tweets values (" + newTweet.SA_code + ", " + newTweet.Campaign_code + ", '" + newTweet.HashTag + "', '" + newTweet.Landing_Page_URL + "', '" + newTweet.Tweet_Content + "', getdate(), '" + newTweet.Tweet_id + "')\r\n\t\t update Social_Activist set Money_Status = Money_Status + 10 where Code = " + newTweet.SA_code + "\r\n\tend



insert into Configuration values ('Auth0BearerCode', 'eyJhbGciOiJSUzI1NiIsInR5cCI6IkpXVCIsImtpZCI6IjdBR3I4SFdQdmx6MmFIQnVEZ3RkTyJ9.eyJpc3MiOiJodHRwczovL2Rldi15dmZrdnQ3Z3VoNGt2bXV0LnVzLmF1dGgwLmNvbS8iLCJzdWIiOiJXNk41UEFHNk01QUxhMFlpMTFuNGd0emhETks2dWFlOEBjbGllbnRzIiwiYXVkIjoiaHR0cHM6Ly9kZXYteXZma3Z0N2d1aDRrdm11dC51cy5hdXRoMC5jb20vYXBpL3YyLyIsImlhdCI6MTY3NjE2MjMwOSwiZXhwIjoxNjc4NzU0MzA5LCJhenAiOiJXNk41UEFHNk01QUxhMFlpMTFuNGd0emhETks2dWFlOCIsInNjb3BlIjoicmVhZDpjbGllbnRfZ3JhbnRzIGNyZWF0ZTpjbGllbnRfZ3JhbnRzIGRlbGV0ZTpjbGllbnRfZ3JhbnRzIHVwZGF0ZTpjbGllbnRfZ3JhbnRzIHJlYWQ6dXNlcnMgdXBkYXRlOnVzZXJzIGRlbGV0ZTp1c2VycyBjcmVhdGU6dXNlcnMgcmVhZDp1c2Vyc19hcHBfbWV0YWRhdGEgdXBkYXRlOnVzZXJzX2FwcF9tZXRhZGF0YSBkZWxldGU6dXNlcnNfYXBwX21ldGFkYXRhIGNyZWF0ZTp1c2Vyc19hcHBfbWV0YWRhdGEgcmVhZDp1c2VyX2N1c3RvbV9ibG9ja3MgY3JlYXRlOnVzZXJfY3VzdG9tX2Jsb2NrcyBkZWxldGU6dXNlcl9jdXN0b21fYmxvY2tzIGNyZWF0ZTp1c2VyX3RpY2tldHMgcmVhZDpjbGllbnRzIHVwZGF0ZTpjbGllbnRzIGRlbGV0ZTpjbGllbnRzIGNyZWF0ZTpjbGllbnRzIHJlYWQ6Y2xpZW50X2tleXMgdXBkYXRlOmNsaWVudF9rZXlzIGRlbGV0ZTpjbGllbnRfa2V5cyBjcmVhdGU6Y2xpZW50X2tleXMgcmVhZDpjb25uZWN0aW9ucyB1cGRhdGU6Y29ubmVjdGlvbnMgZGVsZXRlOmNvbm5lY3Rpb25zIGNyZWF0ZTpjb25uZWN0aW9ucyByZWFkOnJlc291cmNlX3NlcnZlcnMgdXBkYXRlOnJlc291cmNlX3NlcnZlcnMgZGVsZXRlOnJlc291cmNlX3NlcnZlcnMgY3JlYXRlOnJlc291cmNlX3NlcnZlcnMgcmVhZDpkZXZpY2VfY3JlZGVudGlhbHMgdXBkYXRlOmRldmljZV9jcmVkZW50aWFscyBkZWxldGU6ZGV2aWNlX2NyZWRlbnRpYWxzIGNyZWF0ZTpkZXZpY2VfY3JlZGVudGlhbHMgcmVhZDpydWxlcyB1cGRhdGU6cnVsZXMgZGVsZXRlOnJ1bGVzIGNyZWF0ZTpydWxlcyByZWFkOnJ1bGVzX2NvbmZpZ3MgdXBkYXRlOnJ1bGVzX2NvbmZpZ3MgZGVsZXRlOnJ1bGVzX2NvbmZpZ3MgcmVhZDpob29rcyB1cGRhdGU6aG9va3MgZGVsZXRlOmhvb2tzIGNyZWF0ZTpob29rcyByZWFkOmFjdGlvbnMgdXBkYXRlOmFjdGlvbnMgZGVsZXRlOmFjdGlvbnMgY3JlYXRlOmFjdGlvbnMgcmVhZDplbWFpbF9wcm92aWRlciB1cGRhdGU6ZW1haWxfcHJvdmlkZXIgZGVsZXRlOmVtYWlsX3Byb3ZpZGVyIGNyZWF0ZTplbWFpbF9wcm92aWRlciBibGFja2xpc3Q6dG9rZW5zIHJlYWQ6c3RhdHMgcmVhZDppbnNpZ2h0cyByZWFkOnRlbmFudF9zZXR0aW5ncyB1cGRhdGU6dGVuYW50X3NldHRpbmdzIHJlYWQ6bG9ncyByZWFkOmxvZ3NfdXNlcnMgcmVhZDpzaGllbGRzIGNyZWF0ZTpzaGllbGRzIHVwZGF0ZTpzaGllbGRzIGRlbGV0ZTpzaGllbGRzIHJlYWQ6YW5vbWFseV9ibG9ja3MgZGVsZXRlOmFub21hbHlfYmxvY2tzIHVwZGF0ZTp0cmlnZ2VycyByZWFkOnRyaWdnZXJzIHJlYWQ6Z3JhbnRzIGRlbGV0ZTpncmFudHMgcmVhZDpndWFyZGlhbl9mYWN0b3JzIHVwZGF0ZTpndWFyZGlhbl9mYWN0b3JzIHJlYWQ6Z3VhcmRpYW5fZW5yb2xsbWVudHMgZGVsZXRlOmd1YXJkaWFuX2Vucm9sbG1lbnRzIGNyZWF0ZTpndWFyZGlhbl9lbnJvbGxtZW50X3RpY2tldHMgcmVhZDp1c2VyX2lkcF90b2tlbnMgY3JlYXRlOnBhc3N3b3Jkc19jaGVja2luZ19qb2IgZGVsZXRlOnBhc3N3b3Jkc19jaGVja2luZ19qb2IgcmVhZDpjdXN0b21fZG9tYWlucyBkZWxldGU6Y3VzdG9tX2RvbWFpbnMgY3JlYXRlOmN1c3RvbV9kb21haW5zIHVwZGF0ZTpjdXN0b21fZG9tYWlucyByZWFkOmVtYWlsX3RlbXBsYXRlcyBjcmVhdGU6ZW1haWxfdGVtcGxhdGVzIHVwZGF0ZTplbWFpbF90ZW1wbGF0ZXMgcmVhZDptZmFfcG9saWNpZXMgdXBkYXRlOm1mYV9wb2xpY2llcyByZWFkOnJvbGVzIGNyZWF0ZTpyb2xlcyBkZWxldGU6cm9sZXMgdXBkYXRlOnJvbGVzIHJlYWQ6cHJvbXB0cyB1cGRhdGU6cHJvbXB0cyByZWFkOmJyYW5kaW5nIHVwZGF0ZTpicmFuZGluZyBkZWxldGU6YnJhbmRpbmcgcmVhZDpsb2dfc3RyZWFtcyBjcmVhdGU6bG9nX3N0cmVhbXMgZGVsZXRlOmxvZ19zdHJlYW1zIHVwZGF0ZTpsb2dfc3RyZWFtcyBjcmVhdGU6c2lnbmluZ19rZXlzIHJlYWQ6c2lnbmluZ19rZXlzIHVwZGF0ZTpzaWduaW5nX2tleXMgcmVhZDpsaW1pdHMgdXBkYXRlOmxpbWl0cyBjcmVhdGU6cm9sZV9tZW1iZXJzIHJlYWQ6cm9sZV9tZW1iZXJzIGRlbGV0ZTpyb2xlX21lbWJlcnMgcmVhZDplbnRpdGxlbWVudHMgcmVhZDphdHRhY2tfcHJvdGVjdGlvbiB1cGRhdGU6YXR0YWNrX3Byb3RlY3Rpb24gcmVhZDpvcmdhbml6YXRpb25zIHVwZGF0ZTpvcmdhbml6YXRpb25zIGNyZWF0ZTpvcmdhbml6YXRpb25zIGRlbGV0ZTpvcmdhbml6YXRpb25zIGNyZWF0ZTpvcmdhbml6YXRpb25fbWVtYmVycyByZWFkOm9yZ2FuaXphdGlvbl9tZW1iZXJzIGRlbGV0ZTpvcmdhbml6YXRpb25fbWVtYmVycyBjcmVhdGU6b3JnYW5pemF0aW9uX2Nvbm5lY3Rpb25zIHJlYWQ6b3JnYW5pemF0aW9uX2Nvbm5lY3Rpb25zIHVwZGF0ZTpvcmdhbml6YXRpb25fY29ubmVjdGlvbnMgZGVsZXRlOm9yZ2FuaXphdGlvbl9jb25uZWN0aW9ucyBjcmVhdGU6b3JnYW5pemF0aW9uX21lbWJlcl9yb2xlcyByZWFkOm9yZ2FuaXphdGlvbl9tZW1iZXJfcm9sZXMgZGVsZXRlOm9yZ2FuaXphdGlvbl9tZW1iZXJfcm9sZXMgY3JlYXRlOm9yZ2FuaXphdGlvbl9pbnZpdGF0aW9ucyByZWFkOm9yZ2FuaXphdGlvbl9pbnZpdGF0aW9ucyBkZWxldGU6b3JnYW5pemF0aW9uX2ludml0YXRpb25zIHJlYWQ6b3JnYW5pemF0aW9uc19zdW1tYXJ5IGNyZWF0ZTphY3Rpb25zX2xvZ19zZXNzaW9ucyBjcmVhdGU6YXV0aGVudGljYXRpb25fbWV0aG9kcyByZWFkOmF1dGhlbnRpY2F0aW9uX21ldGhvZHMgdXBkYXRlOmF1dGhlbnRpY2F0aW9uX21ldGhvZHMgZGVsZXRlOmF1dGhlbnRpY2F0aW9uX21ldGhvZHMiLCJndHkiOiJjbGllbnQtY3JlZGVudGlhbHMifQ.d6RYxn-qL6dYqb_fsxP_a-MM2eWiOsX4CGbGwLJ19N_bGJDqIm4EVuBdYLSktwySLQpgUz94X8hUNAOaK8HbIaj_lwAgvPyUvze9AiB3VpyV4OAL2ehRbmiAKN4jZ-8EJa3IyW5e2TiIhm91dd-J3ZwxATa5cVi2GVFine8daYyNDBYvlvEp7S_60_l8BqffG7TqEPq_bV9Fx6rRFJBtsht-IDrBX2qDsjmPfOUniRa4Nd5LAMEYCKhtiPQuxAqDhwDkyt-_r5buVIUQ6oB_c11XfeNx_OUdUCzQQxVwXQegUvnV8Az_VW1N-ua9cK3gzfAIgJK6j54lYOAv9xs8Aw')
insert into Configuration values ('TwitterBearerCode', 'AAAAAAAAAAAAAAAAAAAAAAbxlAEAAAAAYfWfIWGOCYsxgb8QWKbVHIILg3g%3DmaB2S5kHwMjRBIuBSdpItgeOylqB5lkYxV5mltg8FPXLNKX0Ht')
insert into Configuration values ('TwitterConsumerKey', 'VZ5VkgFepx1My7TxmoWaXjCr6')
insert into Configuration values ('TwitterConsumerKeySecret', 'q8ufmEXGaow8YJq6cGXynFrDG4ilcvV1ee89PByGUEqLNoFPmy')
insert into Configuration values ('TwitterAccessKey', '1614610924983259146-weskDlwL3A8IjV03n1Q902PLDhuMtA')
insert into Configuration values ('TwitterAccessKeySecret', 'ZRwxVUQARSWcTpXhi9BGIimWrJV40Dmul9NPLdHMR1gXJ')

select * from Configuration