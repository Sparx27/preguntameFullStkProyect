ALTER DATABASE askmedb SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
drop database askmedb

create database askmedb

use askmedb

/* PAISES */
CREATE TABLE Paises(
	paisId nvarchar(2) not null,
	nombre nvarchar(50) not null,
	CONSTRAINT PK_Paises PRIMARY KEY(paisId)
)
--ALTER TABLE Paises
--ADD CONSTRAINT PK_Paises PRIMARY KEY(paisId)


/* USUARIOS */
CREATE TABLE Usuarios(
	username nvarchar(20) not null,
	nombre nvarchar(30) not null,
	apellido nvarchar(30),
	correo nvarchar(255) not null,
	usuario_password nvarchar(20) not null,
	paisId nvarchar(2) not null,
	foto_path nvarchar(255),
	background numeric(5),
	CONSTRAINT PK_Usuario PRIMARY KEY(username),
	CONSTRAINT CK_username CHECK(LEN(username) BETWEEN 4 AND 20),
	CONSTRAINT FK_UsuPais FOREIGN KEY(paisId) REFERENCES Paises(paisId),
	CONSTRAINT AK_correo UNIQUE(correo),
	CONSTRAINT CK_usuario_password CHECK(
		LEN(usuario_password) BETWEEN 6 AND 30 AND
		usuario_password like '%[a-z]%' AND
		usuario_password like '%[A-Z]%' AND
		usuario_password like '%[0-9]%'
	)
)
ALTER TABLE Usuarios
ALTER COLUMN paisId nvarchar(2)
--ALTER TABLE Usuarios
--ADD foto_path nvarchar(255)
--ALTER TABLE Usuarios
--ADD background numeric(5)
--ALTER TABLE Usuarios
--ADD CONSTRAINT AK_correo UNIQUE(correo)
--ALTER TABLE Usuarios
--ADD usuario_password nvarchar(20) not null
--ALTER TABLE Usuarios
--ADD CONSTRAINT CK_usuario_password CHECK(
--	LEN(usuario_password) BETWEEN 6 AND 30 AND
--	usuario_password like '%[a-z]%' AND
--	usuario_password like '%[A-Z]%' AND
--	usuario_password like '%[0-9]%'
--)

/* PREGUNTAS */
CREATE TABLE Preguntas(
	preguntaId int IDENTITY(1,1) not null,
	dsc nvarchar(1000) not null,
	fecha datetime not null,
	CONSTRAINT PK_Preguntas PRIMARY KEY(preguntaId),
	CONSTRAINT CK_dsc CHECK(LEN(dsc) BETWEEN 2 AND 1000)
)

/* PREGUNTAS A USUARIOS - RESPUESTAS */
CREATE TABLE UsuarioPreguntas(
	preguntaId int not null,
	usernameConsultado nvarchar(20) not null,
	usernameConsultante nvarchar(20),
	estado bit not null default 0, 
	dscRespuesta nvarchar(1000),
	fechaRespuesta datetime,
	CONSTRAINT FK_usuarioPreguntas PRIMARY KEY(preguntaId, usernameConsultado),
	CONSTRAINT FK_preguntaId FOREIGN KEY(preguntaId) REFERENCES Preguntas(preguntaId),
	CONSTRAINT FK_usernameConsultado FOREIGN KEY(usernameConsultado) REFERENCES Usuarios(username),
	CONSTRAINT FK_usernameConsultante FOREIGN KEY(usernameConsultante) REFERENCES Usuarios(username)
)

CREATE TABLE Likes(
	likeId int IDENTITY(1,1) not null,
	usuarioPreguntas_preguntaId int not null,
	usuarioPreguntas_usernameConsultado nvarchar(20) not null,
	usuario_like nvarchar(20) not null,
	CONSTRAINT PK_Likes PRIMARY KEY(likeId, usuarioPreguntas_preguntaId, usuarioPreguntas_usernameConsultado),
	CONSTRAINT FK_preguntaUsuarioLike FOREIGN KEY(usuarioPreguntas_preguntaId, usuarioPreguntas_usernameConsultado) 
		REFERENCES UsuarioPreguntas(preguntaId, usernameConsultado),
	CONSTRAINT FK_usuLike FOREIGN KEY(usuario_like)
		REFERENCES Usuarios(username)
)


/* RESPUESTAS */
--CREATE TABLE Respuestas(
--	respuestaId int IDENTITY(1,1) not null,
--	dsc nvarchar(1000) not null,
--	fecha datetime not null,
--	username nvarchar(20) not null,
--	consultante nvarchar(20),
--	preguntaId int not null,
--	CONSTRAINT PK_Respuestas PRIMARY KEY(respuestaId, username, preguntaId),
--	CONSTRAINT FK_UsuRespuesta FOREIGN KEY(username) REFERENCES Usuarios(username),
--	CONSTRAINT FK_consultanteRespuesta FOREIGN KEY(consultante) REFERENCES Usuarios(username),
--	CONSTRAINT FK_pregRespuesta FOREIGN KEY(preguntaId) REFERENCES Preguntas(preguntaId),
--	CONSTRAINT CK_dscRespuesta CHECK(LEN(dsc) BETWEEN 2 AND 1000)
--)
