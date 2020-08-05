
create table dept(
id int primary key,
dname varchar(10),
);
insert into dept(id,dname) values (001,'Consult');
select * from dept;
create table employee(
id int primary key,
ename varchar(20),
deptid int
);
drop table employee;
select * from employee;
Create Procedure Insert_Dept 
(@id int, @name varchar(10))
as 
    begin
        insert into dept(id,dname) values (@id, @name);
    end
go
Create Procedure Delete_Emp 
(@eid int)
as 
    begin
        delete from employee where id=@eid;
    end
go

Create Procedure Emp_Dept
as 
    begin 
        select e.id,e.ename,d.dname from employee as e
        join dept as d
        on e.deptid=d.id;
    end
go
select * from employee;
insert into employee(id, ename, deptid) values (2,'Priyank Ahuja',2);
insert into employee(id, ename, deptid) values (1,'Arhan Relan',1);
select * from dept;
delete from dept where id>=5;

