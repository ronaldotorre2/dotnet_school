/****************************************************************
 * Projeto:.....: Projeto School                              	*
 * Titulo:......: Script Criar esquema School                 	*
 * Autor........: Ronaldo Torre                                 *
 * Referencia...: Release 1.0.0                                 *
 *--------------------------------------------------------------*
  ***************************************************************/


-- Banco de dados
-- ---------------------------------------------------------------
Drop database if exists Schooldb;

-- Criar banco de dados
Create database if not exists Schooldb DEFAULT CHARACTER SET utf8;

Use Schooldb;


-- Módulo Pessoa
-- ----------------------------------------------------------------

-- Pessoa

Create table Person 
(
	IdPerson				 	integer      	not null auto_increment,
	TypeId			     		integer      	not null,
	Name					 	varchar(100)  	not null,
	SocialName		     		varchar(150) 	null,
	Gender					 	integer      	null,
	BirthDate 				 	date         	null,
	Document1				 	varchar(25)  	not null,
	Document2				 	varchar(25)  	null,
	Document3				 	varchar(25)  	null,
    AddressId 					integer 		not null,
	MotherName               	varchar(50)  	null,
	FatherName               	varchar(50)  	null,
	AddDate                  	datetime     	not null,
	AddUser					 	varchar(25)  	not null,
	UpdateDate				 	datetime     	null,
	UpdateUser				 	varchar(25)  	null,
	Constraint Pk_Person primary key(IdPerson)
)ENGINE=InnoDB DEFAULT CHARSET=utf8;


-- Endereço

Create table Address
(
	IdAddress		 			integer      	not null auto_increment,
	TypeId 					 	integer      	not null,
	Name						varchar(100) 	not null,
    Number 						varchar(10)  	not null,
    Complement 				 	varchar(100) 	null,
    ZipCode					 	varchar(10)  	not null,
    District 					varchar(100)    not null,
    City 						varchar(50)		not null,
    State 						varchar(5)		not null,
	AddDate 					datetime     	not null,
	AddUser					 	varchar(25)  	not null,
	UpdateDate				 	datetime     	null,
	UpdateUser				 	varchar(25)  	null,
	Constraint Pk_Address primary key(IdAddress)
)ENGINE=InnoDB DEFAULT CHARSET=utf8;

Alter table Person add Constraint Fk_Address_Person foreign key(AddressId) references address(IdAddress);


-- Contato

Create table Contact
(
	IdContact		 			integer	  	 	not null auto_increment,
    PersonId 					integer 		null,
    TypeId				 		integer      	not null,
	Description				 	varchar(100) 	not null,
	AddDate 					datetime     	not null,
	AddUser					 	varchar(25)  	not null,
	UpdateDate				 	datetime     	null,
	UpdateUser				 	varchar(25)  	null,
	Constraint Pk_Contact primary key(IdContact),
	Constraint Fk_Person_Contact foreign key(PersonId) references Person(IdPerson)
)ENGINE=InnoDB DEFAULT CHARSET=utf8;




-- Módulo Usuário
-- ---------------------------------------------------------------

Create table User_Profile 
(
	IdProfile				 	integer      	not null auto_increment,
	Name 					 	varchar(50) 	not null,
	Initials                  	varchar(5)   	not null,
    IsActive				 	bit          	not null,
	AddDate 			     	datetime     	not null,
    AddUser					 	varchar(25)  	not null,
	UpdateDate 			     	datetime     	null,
    UpdateUser				 	varchar(25)  	null,
	Constraint Pk_UserProfile primary key(IdProfile)
);



-- Usuário

Create table User_Sys
(
	IdUser 					 	integer 	 	not null auto_increment,
    PersonId 					integer 		null,
	Name 					 	varchar(50)  	not null,
	Login 					 	varchar(25)  	not null,
	Password 			     	varchar(100) 	not null,
	Remember				 	varchar(100) 	null,
	Mail					 	varchar(100) 	null,
	ProfileId                	integer      	not null,
	IsActive				 	bit          	not null,
	AddDate 			     	datetime     	not null,
    AddUser					 	varchar(25)  	not null,
	UpdateDate 			     	datetime     	null,
    UpdateUser				 	varchar(25)  	null,
	Constraint Pk_UserSys primary key(IdUser),
	Constraint Fk_UserProfile_UserSys foreign key(ProfileId) references User_Profile(IdProfile),
    Constraint Fk_Person_UserSys foreign key(PersonId) references Person(IdPerson)
);


-- Importar dados
-- ----------------------------------------------------------------
Insert into User_Profile(Name,Initials,IsActive,AddDate,AddUser)values('Sistema','SIS',1,STR_TO_DATE('29/05/2018 09:05','%d/%m/%Y %H:%i'),'@System');
Insert into User_Sys(Name,Login,Password,Remember,Mail,ProfileId,IsActive,AddDate,AddUser)values('Administrador','Uadmin','adm123@',null,null,1,1,STR_TO_DATE('29/05/2018 09:05','%d/%m/%Y %H:%i'),'@System');

-- Endereço
Insert into Address(TypeId,Name,Number,Complement,ZipCode,District,City,State,AddDate,AddUser)values(2,'Rua Azaléia','953',null,'12906-090','Parque Brasil','Bragança Paulista','SP',STR_TO_DATE('29/05/2018 09:05','%d/%m/%Y %H:%i'),'@System');
Insert into Address(TypeId,Name,Number,Complement,ZipCode,District,City,State,AddDate,AddUser)values(2,'Rua Jandaia','820',null,'13061-306','Vila Padre Manoel de Nóbrega','Campinas','SP',STR_TO_DATE('29/05/2018 09:15','%d/%m/%Y %H:%i'),'@System');
Insert into Address(TypeId,Name,Number,Complement,ZipCode,District,City,State,AddDate,AddUser)values(2,'Rua Ana Adelaide Camargo','353',null,'13088-641','Jardim Santana','Campinas','SP',STR_TO_DATE('29/05/2018 09:15','%d/%m/%Y %H:%i'),'@System');
Insert into Address(TypeId,Name,Number,Complement,ZipCode,District,City,State,AddDate,AddUser)values(2,'Travessa Jací','957',null,'15813-002','Jardim Imperial','Catanduva','SP',STR_TO_DATE('29/05/2018 09:15','%d/%m/%Y %H:%i'),'@System');

-- Pessoas
Insert into Person(TypeId,Name,Gender,BirthDate,Document1,Document2,AddressId,MotherName,FatherName,AddDate,AddUser)values(0,'Benedito Henrique Gonçalves',1,STR_TO_DATE('04/05/1988','%d/%m/%Y'),'379.838.238-78','37.566.309-5',1,'Malu Bárbara','Hugo Luiz Cláudio Gonçalves',STR_TO_DATE('29/05/2018 09:05','%d/%m/%Y %H:%i'),'@System');
Insert into Person(TypeId,Name,Gender,BirthDate,Document1,Document2,AddressId,MotherName,FatherName,AddDate,AddUser)values(0,'Eliane Eloá Helena Pereira',0,STR_TO_DATE('19/01/1993','%d/%m/%Y'),'643.000.488-00','40.109.774-2',2,'Fernanda Marli Larissa','Iago Ricardo Pereira',STR_TO_DATE('29/05/2018 09:15','%d/%m/%Y %H:%i'),'@System');
Insert into Person(TypeId,Name,Gender,BirthDate,Document1,Document2,AddressId,MotherName,FatherName,AddDate,AddUser)values(0,'Antonio Severino Isaac Fogaça',1,STR_TO_DATE('01/10/1996','%d/%m/%Y'),'990.637.188-96','40.451.947-7',3,'Aparecida Lavínia','Severino Augusto Fogaça',STR_TO_DATE('29/05/2018 09:15','%d/%m/%Y %H:%i'),'@System');
Insert into Person(TypeId,Name,Gender,BirthDate,Document1,Document2,AddressId,MotherName,FatherName,AddDate,AddUser)values(0,'Antonella Ester Rosa Carvalho',0,STR_TO_DATE('27/03/1996','%d/%m/%Y'),'402.778.858-33','42.331.223-6',4,'Eliane Olivia','Danilo Benício Carvalho',STR_TO_DATE('29/05/2018 09:15','%d/%m/%Y %H:%i'),'@System');

-- Contato
Insert into Contact(PersonId,TypeId,Description,AddDate,AddUser)values(1,0,'(11)99767-2794',STR_TO_DATE('29/05/2018 09:05','%d/%m/%Y %H:%i'),'@System');
Insert into Contact(PersonId,TypeId,Description,AddDate,AddUser)values(1,2,'beneditohenriquegoncalves@pozzer.net',STR_TO_DATE('29/05/2018 09:05','%d/%m/%Y %H:%i'),'@System');
Insert into Contact(PersonId,TypeId,Description,AddDate,AddUser)values(2,0,'(19)99235-6076',STR_TO_DATE('29/05/2018 09:15','%d/%m/%Y %H:%i'),'@System');
Insert into Contact(PersonId,TypeId,Description,AddDate,AddUser)values(2,2,'elianeeloahelenapereira@zipmail.com.br',STR_TO_DATE('29/05/2018 09:15','%d/%m/%Y %H:%i'),'@System');
Insert into Contact(PersonId,TypeId,Description,AddDate,AddUser)values(3,0,'(19)98148-6413',STR_TO_DATE('29/05/2018 09:15','%d/%m/%Y %H:%i'),'@System');
Insert into Contact(PersonId,TypeId,Description,AddDate,AddUser)values(3,1,'(19)2771-5969',STR_TO_DATE('29/05/2018 09:15','%d/%m/%Y %H:%i'),'@System');
Insert into Contact(PersonId,TypeId,Description,AddDate,AddUser)values(3,2,'antoniosfogaca@engeco.com.br',STR_TO_DATE('29/05/2018 09:15','%d/%m/%Y %H:%i'),'@System');
Insert into Contact(PersonId,TypeId,Description,AddDate,AddUser)values(4,0,'(17)98392-9090',STR_TO_DATE('29/05/2018 09:15','%d/%m/%Y %H:%i'),'@System');
Insert into Contact(PersonId,TypeId,Description,AddDate,AddUser)values(4,1,'(17)3996-2890',STR_TO_DATE('29/05/2018 09:15','%d/%m/%Y %H:%i'),'@System');
Insert into Contact(PersonId,TypeId,Description,AddDate,AddUser)values(4,2,'antonellaecarvalho@tursi.com.br',STR_TO_DATE('29/05/2018 09:15','%d/%m/%Y %H:%i'),'@System');

