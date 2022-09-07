use banco
go


create table CLIENTES(
id_cliente int IDENTITY (1,1) not null,
nombre varchar (20) not null,
apellido varchar (30) not null,
dni int not null,
constraint pk_id_cliente PRIMARY KEY (id_cliente))


create table Tipos_Cuenta(
id_tipos int  not null,
nombre varchar (20) not null,
constraint pk_id_tipos PRIMARY KEY (id_tipos))

create table Cuentas(
id_cuenta int not null,
cbu int not null,
id_tipos INT not null,
ultimo_movimiento int not null,
Saldos decimal(30,2),
id_cliente int not null,
constraint pk_id_cuenta PRIMARY KEY (id_cuenta),
constraint fk_tipo_cuenta FOREIGN KEY (id_tipos) REFERENCES Tipos_Cuenta(id_tipos),
constraint fk_id_cliente FOREIGN KEY (id_cliente) REFERENCES Clientes(id_cliente))

INSERT INTO Tipos_Cuenta (id_tipos, nombre) VALUES (1, 'C.A. en pesos')
INSERT INTO Tipos_Cuenta (id_tipos, nombre) VALUES (2, 'C.A. en dolares')
INSERT INTO Tipos_Cuenta (id_tipos, nombre) VALUES (3, 'C.C. en pesos')
INSERT INTO Tipos_Cuenta (id_tipos, nombre) VALUES (4, 'C.C. en dolares')
INSERT INTO Tipos_Cuenta (id_tipos, nombre) VALUES (5, 'cuenta sueldo')
INSERT INTO Tipos_Cuenta (id_tipos, nombre) VALUES (6, 'C.A. recaudadora')


insert into cuentas (id_cuenta, cbu, id_tipos, ultimo_movimiento, Saldos, id_cliente) values (1, 111111111, 2, 232, 34232323, 1)
insert into cuentas (id_cuenta, cbu, id_tipos, ultimo_movimiento, Saldos, id_cliente) values (2, 22222222, 1, 2132, 7778990, 2)
insert into cuentas (id_cuenta, cbu, id_tipos, ultimo_movimiento, Saldos, id_cliente) values (3, 33333333,3, 56232, 0.56, 3)
insert into cuentas (id_cuenta, cbu, id_tipos, ultimo_movimiento, Saldos, id_cliente) values (4,4444441,4, 71232, 27277262.90,4)
insert into cuentas (id_cuenta, cbu, id_tipos, ultimo_movimiento, Saldos, id_cliente) values (5,555555555,5, 23244, 123767.44, 5)
insert into cuentas (id_cuenta, cbu, id_tipos, ultimo_movimiento, Saldos, id_cliente) values (6, 666666666,6, 90876, 2354667.8, 6)
insert into cuentas (id_cuenta, cbu, id_tipos, ultimo_movimiento, Saldos, id_cliente) values (7,77777777,4, 66232, 27277262.90,7)
insert into cuentas (id_cuenta, cbu, id_tipos, ultimo_movimiento, Saldos, id_cliente) values (8,588888855,5, 55244, 123767.44, 8)
insert into cuentas (id_cuenta, cbu, id_tipos, ultimo_movimiento, Saldos, id_cliente) values (9, 99999999,6, 1190876, 203054667.8,9)

insert into clientes ( nombre, apellido, dni) values ( 'marcos', 'flores', 23232323)


insert into clientes ( nombre, apellido, dni) values ( 'victoria', 'bruno', 326779922)
insert into clientes ( nombre, apellido, dni) values ( 'yael', 'salinas', 32567890)
insert into clientes ( nombre, apellido, dni) values ( 'carolina', 'romero', 32120878)
insert into clientes ( nombre, apellido, dni) values ( 'yesi', 'perez', 232444323)
insert into clientes ( nombre, apellido, dni) values ( 'laura', 'sanchez', 32675907)
insert into clientes ( nombre, apellido, dni) values ( 'camila', 'posadas', 333992323)
insert into clientes ( nombre, apellido, dni) values ( 'liliana', 'lutre', 17387053)
insert into clientes ( nombre, apellido, dni) values ( 'ignacio', 'fernandez', 34232323)


select * from Tipos_Cuenta
select * from CLIENTES
select * from Cuentas



CREATE PROCEDURE SP_CARGA_COMB
as
select * from Tipos_Cuenta

--CREATE PROC SP_CARGA_COMBO
@cuentas varchar(50) output
as
select * from Tipos_Cuenta

declare @tiposcuentas varchar(50)
exec SP_CARGA_COMBO @tiposcuentas
print @tiposcuentas


CREATE PROCEDURE SP_INSERT_BCO

@nombre varchar (20) null,
@apellido varchar (30) null,
@dni int null
as 
begin
 insert into CLIENTES values( @nombre, @apellido, @dni)
end;

--CREATE PROC SP_insert
@nombre varchar(50) output,
@apellido varchar(50) output,
@dni int output
as
begin
 insert into CLIENTES values(@nombre, @apellido, @dni)
end;


create proc SP_cargar_dgv
as
select c.cbu,cl.id_cliente,tc.nombre,cl.apellido,cl.nombre,cl.dni,c.Saldos,c.ultimo_movimiento,tc.id_tipos
from cuentas c
join clientes cl on c.id_cliente=cl.id_cliente
join tipos_cuenta tc on c.id_tipos=tc.id_tipos