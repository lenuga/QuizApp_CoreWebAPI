create table UserInfo(
userId int identity(1,1) NOT NULL primary Key,
username nvarchar(255),
password nvarchar(255),
emailId nvarchar(255),
address nvarchar(255),
phoneNo nvarchar(50),
userType nvarchar(50)
);
select * from dbo.userInfo;
insert into [dbo].[UserInfo](username,password,emailId,address,phoneNo,userType) Values ('admin', 'qwert', 'admin123@gmail.com', 'jaffna', '0778989880', 'admin');

create table LoginInfo(
Id int identity(1,1) NOT NULL primary Key,
username nvarchar(255),
password nvarchar(255),
userType nvarchar(50)
);

select * from dbo.LoginInfo;
ALTER TABLE UserInfo
DROP COLUMN username;

ALTER TABLE LoginInfo
ADD role nvarchar(50);

ALTER TABLE UserInfo
ADD lastName nvarchar(255);

insert into [dbo].[LoginInfo](username,password,role) Values ('admin', 'admin', 'admin');
DELETE FROM UserInfo
WHERE userId = 2;

select * from dbo.userInfo;
insert into [dbo].[UserInfo](emailId,address,phoneNo,userType,firstName,lastName) Values ('user123@gmail.com', 'jaffna', '0778989982', '','Akshana','Roshan');
