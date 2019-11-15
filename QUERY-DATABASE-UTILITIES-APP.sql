/*Creacion base de datos*/
create database UTILITIES_APP

/*Utilizacion*/
use UTILITIES_APP
go

/*Creacion de Tablas */
/*Creacion Tabla Estudiante*/
Create table ESTUDIANTES
(
ID_estudiante int Identity(1,1) primary Key,
nombre varchar(25) not null,
apellido varchar(25) not null,
edad int,
sexo varchar(10),
carrera varchar(30),
)
/*---------------Insertar Datos de Prueba en tabla ESTUDIANTES------------------------*/
insert into ESTUDIANTES values('Ewin','Mendez',20,'Masculino','Desarrollo de Software')
insert into ESTUDIANTES values('Joel','Baez',20,'Masculino','Desarrollo de Software')

select * from ESTUDIANTES
/*----------------------------------------------------------------------------------*/

Create table MATERIAS
(
	ID_materia int Identity(1,1) not null primary key,
	nombre varchar(25),
	descripcion varchar (200),
	horario varchar(30),
	creditos int,
	profesor varchar(25)
)
/*---------------Insertar Datos de Prueba en tabla MATERIAS------------------------*/
insert into MATERIAS values('Programacion III','Ultima Materia de Progrmacion del Pensum','Miercoles-6:00pm-8:00pm',5,'Juan Rosario')
insert into MATERIAS values('Calculo Integral','Apredender sobre el caculo integral','Lunes-5:00pm-10:00pm',5,'Samuel Angomas')
insert into MATERIAS values('Etica 4',': Valores, Tecnologia y Ejercicio Profesional','Viernes-7:00pm-10:00pm',5,'Freddy García')

select * from MATERIAS
/*----------------------------------------------------------------------------------*/

Create table ESTUDIANTES_MATERIAS
(
	ID_estudiante_materia int identity(1,1) primary key,
	ID_estudiante int foreign key references ESTUDIANTES(ID_estudiante),
	ID_materia int 
)
/*Agregamos llave Foranea*/
alter table ESTUDIANTES_MATERIAS add constraint FK_MATERIA_ESTUDAINTE foreign key (ID_materia) references MATERIAS(ID_materia)
/*-----------------------*/
/*---------------Insertar Datos de Prueba en tabla ESTUDAINTES_MATERIAS------------------------*/
/*Estudiante 1*/
insert into ESTUDIANTES_MATERIAS values(1,1)
insert into ESTUDIANTES_MATERIAS values(1,2)
/*Estudiante 2*/
insert into ESTUDIANTES_MATERIAS values(2,3)
insert into ESTUDIANTES_MATERIAS values(2,1)


select * from ESTUDIANTES_MATERIAS
/*----------------------------------------------------------------------------------*/

Create table CONTACTO
(
	ID_contacto int identity(1,1) primary key,
	nombre varchar(25),
	celular varchar(12),
	email varchar(50),
	direccion varchar(200)
)
/*---------------Insertar Datos de Prueba en tabla CONTACTO------------------------*/
insert into CONTACTO values('Ezequiel Mendez','849-276-5378','Ezequielmendez@gmail.com','Santo Domingo Norte, Av.Jacobo Majluta Residencial Colinas del Arroyo 2')

select * from CONTACTO
/*----------------------------------------------------------------------------------*/
create table EVENTOS
(
	ID_evento int identity(1,1) primary key,
	fecha date,
	hora varchar(10),
	descripcion varchar(200)
)
/*---------------Insertar Datos de Prueba en tabla EVENTOS------------------------*/
insert into EVENTOS values('2019-11-16','5:00pm','Conferencia de Software de Manejo de Versiones')

select * from EVENTOS

/*----------------------------------------------------------------------------------*/