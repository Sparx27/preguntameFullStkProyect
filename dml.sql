use askmedb

INSERT INTO Paises
VALUES ('UY', 'Uruguay')
INSERT INTO Paises
VALUES ('ES', 'España'),
	('AR', 'Argentina'),
	('BR', 'Brasil')

INSERT INTO Usuarios(username, nombre, apellido, correo, usuario_password, paisId)
VALUES ('fran', 'fran', 'algo', 'correo@correo.com', '123Aaa', 'UY'),
	('maria', 'maria', 'otra', 'correoo@correo.com', '123Aaa', 'AR'),
	('jhon', 'Jhon', 'Doe', 'correooo@correo.com', '123Aaa', 'BR')

INSERT INTO Preguntas(dsc, fecha)
VALUES ('Hola fran', '2024/08/06'),
	('Como estas fran', '2024/06/06'),
	('Hola maría', '2024/07/12'),
	('Holaaaa maría', '2024/08/11'),
	('Hola maríaaaaa', '2024/05/26'),
	('Hola jhon', '2024/01/16'),
	('Hola Jhooon', '2023/02/20'),
	('Hola Jhooooon', '2024/11/23')
	--preguntaId int IDENTITY(1,1) not null,
	--dsc nvarchar(1000) not null,
	--fecha datetime not null,

INSERT INTO Preguntas(dsc, fecha)
VALUES ('Hola fran con respuesta', '2024/02/26')
INSERT INTO Preguntas(dsc, fecha)
VALUES ('Hola desde otro usuario, fran, esta también tiene respuesta', '2024/08/26')

INSERT INTO UsuarioPreguntas(preguntaId, usernameConsultado, usernameConsultante)
VALUES (1, 'fran', 'maria'),
	(2, 'fran', 'jhon'),
	(4, 'maria', 'fran'),
	(5, 'maria', 'jhon'),
	(7, 'jhon', 'fran')
INSERT INTO UsuarioPreguntas(preguntaId, usernameConsultado)
VALUES (3, 'fran'),
	(6, 'maria'),
	(8, 'jhon'),
	(9, 'jhon')

/*Ya respondidas*/
INSERT INTO UsuarioPreguntas(preguntaId, usernameConsultado, estado, dscRespuesta, fechaRespuesta)
VALUES(10, 'fran', 1, 'Esta pregunta ya tiene una respuesta. Hola!!', GETDATE())

INSERT INTO UsuarioPreguntas(preguntaId, usernameConsultado, usernameConsultante, estado, dscRespuesta, fechaRespuesta)
VALUES(11, 'fran', 'jhon', 1, 'Esta pregunta ya tiene una respuesta Jhon. Hola amigo!!', GETDATE())

	--preguntaId int not null,
	--usernameConsultado nvarchar(20) not null,
	--usernameConsultante nvarchar(20),
	--estado bit not null default 0, 
	--dscRespuesta nvarchar(1000),
	--fechaRespuesta datetime,

INSERT INTO Likes(usuarioPreguntas_preguntaId, usuarioPreguntas_usernameConsultado, usuario_like)
VALUES(10, 'fran', 'maria'),
	(10, 'fran', 'jhon'),
	(11, 'fran', 'jhon'),
	(11, 'fran', 'maria')

	--likeId int IDENTITY(1,1) not null,
	--usuarioPreguntas_preguntaId int not null,
	--usuarioPreguntas_usernameConsultado nvarchar(20) not null,
	--usuario_like nvarchar(20) not null,
