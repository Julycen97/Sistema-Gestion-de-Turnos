USE GESTOR_DE_TURNOS
GO

-- INSERT CATEGORIAS
INSERT INTO CATEGORIAS (NOMBRE, DESCRIPCION) VALUES
('Urgente', 'Para casos que requieren atención inmediata'),
('Consulta', 'Para consultas médicas generales'),
('Revisión de estudios', 'Para revisión de resultados de estudios médicos'),
('Seguimiento', 'Para seguimiento de tratamientos médicos');

--INSERT ESPECIALIDADES
INSERT INTO ESPECIALIDADES (NOMBRE, RAMA) VALUES
('Traumatologia', 'Ortopedia'), ('Odontologia', 'Estomatologia'), ('Cardiologia', 'Medicina interna'), ('Dermatologia', 'Medicina especializada'),
('Neurologia', 'Medicina de sistema nervioso'), ('Ginecologia', 'Obstetricia'), ('Pediatria', 'Medicina infantil'), ('Oftalmologia', 'Medicina ocular'),
('Psiquiatria', 'Medicina mental'), ('Oncologia', 'Medicina de cancer'), ('Radiologia', 'Medico radiologo'), ('Urologia', 'Medicina del tracto urinario'),
('Nutriologia', 'Estudio de la nutricion'), ('Endocrinologia', 'Estudio de las glandulas endocrinas'), ('Reumatologia', 'Estudio de las enfermedades reumaticas'), ('Infectologia', 'Medicina de enfermedades infecciosas'),
('Fisioterapia', 'Rehabilitacion fisica'), ('Otorrinolaringologia', 'Medicina otorrinolaringologica'), ('Anestesiologia', 'Medicina anestesica'), ('Rehabilitacion', 'Medicina de rehabilitacion');

--INSERT PROVINCIAS
INSERT INTO PROVINCIAS (NOMBRE) VALUES
('Buenos Aires'), ('Catamarca'), ('Chaco'), ('Chubut'), ('Ciudad Autonoma de Buenos Aires'), ('Cordoba'),
('Corrientes'), ('Entre Rios'), ('Formosa'), ('Jujuy'), ('La Pampa'), ('La Rioja'),
('Mendoza'), ('Misiones'), ('Neuquen'), ('Rio Negro'), ('Salta'), ('San Juan'),
('San Luis'), ('Santa Cruz'), ('Santa Fe'), ('Santiago del Estero'), ('Tierra del Fuego'), ('Tucuman');

--INSERT CIUDADES (SOLO BUENOS AIRES)
INSERT INTO CIUDADES (IDPROVINCIA, NOMBRE) VALUES
(1, 'Adolfo Gonzales Chaves'), (1, 'Adrogué	'), (1, 'Alberti	'), (1, 'Alejandro Korn'), (1, 'América	'), (1, 'Arrecifes'),
(1, 'Avellaneda'), (1, 'Ayacucho'), (1, 'Azul'), (1, 'Bahía Blanca'), (1, 'Balcarce'), (1, 'Banfield'),
(1, 'Baradero'), (1, 'Batán'), (1, 'Béccar'), (1, 'Bella Vista'), (1, 'Benavídez'), (1, 'Benito Juárez'), (1, 'Berazategui'),
(1, 'Bernal'), (1, 'Bolívar'), (1, 'Bosques'), (1, 'Boulogne Sur Mer'), (1, 'Bragado'), (1, 'Brandsen'), (1, 'Burzaco'),
(1, 'Campana'), (1, 'Cañuelas'), (1, 'Capilla del Señor'), (1, 'Capitán Sarmiento'), (1, 'Carhué'), (1, 'Carlos Casares'), (1, 'Carlos Spegazzini'),
(1, 'Carlos Tejedor'), (1, 'Carmen de Areco'), (1, 'Carmen de Patagones'), (1, 'Casbas'), (1, 'Caseros'), (1, 'Castelar'),
(1, 'Castelli'), (1, 'Chacabuco'), (1, 'Chivilcoy'), (1, 'Claypole'), (1, 'Colón'), (1, 'Comandante Nicanor Otamendi'),
(1, 'Coronel Dorrego'), (1, 'Coronel Pringles'), (1, 'Coronel Suárez'), (1, 'Coronel Vidal'), (1, 'Daireaux'), (1, 'Dock Sud'),
(1, 'Dolores'), (1, 'Don Torcuato'), (1, 'Eduardo o Brien'), (1, 'El Jagüel'), (1, 'El Palomar'), (1, 'Tres de Febrero'),
(1, 'El Talar'), (1, 'Ezeiza'), (1, 'Ezpeleta'), (1, 'Francisco Álvarez'), (1, 'Florencio Varela'),
(1, 'Florentino Ameghino'), (1, 'Garín'), (1, 'General Alvear'), (1, 'General Arenales'), (1, 'General Belgrano'),
(1, 'General Conesa'), (1, 'General Daniel Cerri'), (1, 'General Guido'), (1, 'General Juan Madariaga'), (1, 'General Las Heras'), (1, 'General Lavalle'), (1, 'General Pacheco'),
(1, 'General Pinto'), (1, 'General Rodríguez'), (1, 'General Villegas'), (1, 'Gerli'), (1, 'Glew'), (1, 'González Catán'), (1, 'Gregorio de Laferrere'),
(1, 'Guaminí'), (1, 'Guernica'), (1, 'Haedo'), (1, 'Henderson'), (1, 'Hudson'), (1, 'Hurlingham'), (1, 'Ingeniero Budge'),
(1, 'Ingeniero Maschwitz'), (1, 'Isidro Casanova'), (1, 'Ituzaingó'), (1, 'José C. Paz'), (1, 'Junín'), (1, 'La Emilia'), (1, 'La Plata'),
(1, 'La Tablada'), (1, 'La Unión'), (1, 'Lanús'), (1, 'Laprida'), (1, 'Las Flores'), (1, 'Lezama'), (1, 'Llavallol'),
(1, 'Libertad'), (1, 'Lima'), (1, 'Lincoln'), (1, 'Lobería'), (1, 'Lobos'), (1, 'Lomas de Zamora'), (1, 'Lomas del Mirador'),
(1, 'Longchamps'), (1, 'Los Polvorines'), (1, 'Los Toldos'), (1, 'Luján'), (1, 'Luis Guillón'), (1, 'Magdalena'), (1, 'Maipú'), (1, 'Mar de Ajó'), (1, 'Mar del Plata'),
(1, 'Mar del Tuyú'), (1, 'Marcos Paz'), (1, 'Mariano Acosta'), (1, 'Martínez'), (1, 'Médanos'), (1, 'Mercedes'), (1, 'Merlo'),
(1, 'Miramar'), (1, 'Monte'), (1, 'Monte Chingolo'), (1, 'Monte Grande'), (1, 'Monte Hermoso'), (1, 'Navarro'), (1, 'Necochea'), (1, 'Nueve de Julio'), (1, 'Olavarría'), (1, 'Paso del Rey'),
(1, 'Pehuajó'), (1, 'Pellegrini'), (1, 'Pergamino'), (1, 'Pila'), (1, 'Pilar'), (1, 'Pinamar'), (1, 'Pontevedra'),
(1, 'Presidente Derqui'), (1, 'Puan'), (1, 'Punta Alta'), (1, 'Quilmes'), (1, 'Rafael Calzada'), (1, 'Rafael Castillo'), (1, 'Ramallo'),
(1, 'Ramos Mejía'), (1, 'Ranchos'), (1, 'Rauch'), (1, 'Rawson'), (1, 'Remedios de Escalada'), (1, 'Rojas'), (1, 'Roque Pérez'), (1, 'Saavedra'),
(1, 'Saladillo'), (1, 'Salto'), (1, 'San Andrés de Giles'), (1, 'San Antonio de Areco'), (1, 'San Antonio de Padua'), (1, 'San Cayetano'),
(1, 'San Fernando'), (1, 'San Francisco Solano'), (1, 'Almirante Brown'), (1, 'San Isidro'), (1, 'San Justo'), (1, 'San Martín'),
(1, 'San Pedro'), (1, 'San Nicolás de los Arroyos'), (1, 'San Vicente'), (1, 'Santa María'), (1, 'Sarandí'), (1, 'Suipacha'),
(1, 'Tandil'), (1, 'Tapalqué'), (1, 'Temperley'), (1, 'Tigre'), (1, 'Tornquist'), (1, 'Treinta de Agosto'), (1, 'Trenque Lauquen'),
(1, 'Tres Arroyos'), (1, 'Tres Lomas'), (1, 'Tristán Suárez'), (1, 'Turdera'), (1, 'Valentín Alsina'), (1, 'Vedia'),
(1, 'Veinticinco de Mayo'), (1, 'Vicente López'), (1, 'Villa Ballester'), (1, 'Villa Elisa'), (1, 'Villa Fiorito'),
(1, 'Villa Luzuriaga'), (1, 'Villa Madero'), (1, 'Villa Ramallo'), (1, 'Villa Tesei'), (1, 'Wilde'), (1, 'Zárate');

--INSERT DOMICLIOS
INSERT INTO DOMICILIOS (CALLE, ALTURA, IDCIUDAD, CODPOSTAL)
VALUES
('Calle JMVDZ', 234, 1, 12345), ('Calle 9 de Julio', 456, 2, 54321), ('Avenida Belgrano', 321, 3, 67890), ('Calle San Martin', 567, 4, NULL),
('Camino Centenario', 890, 5, 45678), ('Avenida Roca', 789, 6, 40300), ('Camino Cordoba', 678, 7, 27600), ('Calle La Rioja', 567, 8, 14000), ('Barrio 17 de Agosto', 987, 9, 16400),
('Calle Independencia', 345, 10, NULL), ('Calle Paraguay', 234, 1, 17000), ('Calle Uruguay', 456, 1, 19000), ('Calle Chile', 321, 3, 20000), ('Calle Bolivia', 567, 4, 21000),
('Calle Peru', 890, 5, 22000), ('Calle Ecuador', 789, 6, 23000), ('Calle Colombia', 678, 7, 24000), ('Calle Venezuela', 567, 8, 25000), ('Calle Brasil', 987, 9, 26000),
('Calle Guyana', 345, 10, 27000), ('Calle Surinam', 234, 2, 28000), ('Calle Guyana Francesa', 456, 2, 29000), ('Calle Trinidad y Tobago', 321, 3, 30000), ('Calle Barbados', 567, 4, 31000),
('Calle Antigua y Barbuda', 890, 25, 32000), ('Calle Santa Lucia', 789, 26, 33000), ('Calle San Vicente y las Granadinas', 678, 27, 34000), ('Calle Granada', 567, 28, 35000),
('Calle Dominica', 987, 29, 36000), ('Calle San Kitts y Nevis', 345, 30, 37000), ('Calle Antigua y Barbuda', 234, 31, 38000), ('Calle Bahamas', 456, 32, 39000),
('Calle Turcas y Caicos', 321, 33, 40000), ('Calle Islas Vírgenes Británicas', 567, 34, 41000), ('Calle Anguila', 890, 35, 42000);

--INSERT PERSONAS
INSERT INTO PERSONAS (DNI, NOMBRE, APELLIDO, SEXO, FECHANACIMIENTO, IDDOMICILIO)
VALUES (12345678, 'USUARIO_1', 'APELLIDO_1', 'M', '1980-01-01', 10);

INSERT INTO PERSONAS (DNI, NOMBRE, APELLIDO, SEXO, FECHANACIMIENTO, IDDOMICILIO)
VALUES (87654321, 'USUARIO_2', 'APELLIDO_2', 'F', '1990-02-02', 25);

INSERT INTO PERSONAS (DNI, NOMBRE, APELLIDO, SEXO, FECHANACIMIENTO, IDDOMICILIO)
VALUES (98765432, 'USUARIO_3', 'APELLIDO_3', 'M', '2000-03-03', 15);

INSERT INTO PERSONAS (DNI, NOMBRE, APELLIDO, SEXO, FECHANACIMIENTO, IDDOMICILIO)
VALUES (43215678, 'USUARIO_4', 'APELLIDO_4', 'F', '2010-04-04', 30);

INSERT INTO PERSONAS (DNI, NOMBRE, APELLIDO, SEXO, FECHANACIMIENTO, IDDOMICILIO)
VALUES (56789876, 'USUARIO_5', 'APELLIDO_5', 'M', '2020-05-05', 20);

INSERT INTO PERSONAS (DNI, NOMBRE, APELLIDO, SEXO, FECHANACIMIENTO, IDDOMICILIO)
VALUES (12345679, 'USUARIO_6', 'APELLIDO_6', 'M', '1980-06-06', 12);

INSERT INTO PERSONAS (DNI, NOMBRE, APELLIDO, SEXO, FECHANACIMIENTO, IDDOMICILIO)
VALUES (98765433, 'USUARIO_7', 'APELLIDO_7', 'F', '1990-07-07', 27);

INSERT INTO PERSONAS (DNI, NOMBRE, APELLIDO, SEXO, FECHANACIMIENTO, IDDOMICILIO)
VALUES (76543210, 'USUARIO_8', 'APELLIDO_8', 'M', '2000-08-08', 18);

INSERT INTO PERSONAS (DNI, NOMBRE, APELLIDO, SEXO, FECHANACIMIENTO, IDDOMICilio)
VALUES (54321098, 'USUARIO_9', 'APELLIDO_9', 'F', '2010-09-09', 32);

INSERT INTO PERSONAS (DNI, NOMBRE, APELLIDO, SEXO, FECHANACIMIENTO, IDDOMICilio)
VALUES (32109876, 'USUARIO_10', 'APELLIDO_10', 'M', '2020-10-10', 23);

INSERT INTO PERSONAS (DNI, NOMBRE, APELLIDO, SEXO, FECHANACIMIENTO, IDDOMICilio)
VALUES (10987654, 'USUARIO_11', 'APELLIDO_11', 'F', '1981-11-11', 14);

INSERT INTO PERSONAS (DNI, NOMBRE, APELLIDO, SEXO, FECHANACIMIENTO, IDDOMICilio)
VALUES (98765434, 'USUARIO_12', 'APELLIDO_12', 'M', '1991-12-12', 29);

INSERT INTO PERSONAS (DNI, NOMBRE, APELLIDO, SEXO, FECHANACIMIENTO, IDDOMICilio)
VALUES (76543211, 'USUARIO_13', 'APELLIDO_13', 'F', '2001-01-13', 19);

INSERT INTO PERSONAS (DNI, NOMBRE, APELLIDO, SEXO, FECHANACIMIENTO, IDDOMICilio)
VALUES (54321099, 'USUARIO_14', 'APELLIDO_14', 'M', '2011-02-14', 33);

INSERT INTO PERSONAS (DNI, NOMBRE, APELLIDO, SEXO, FECHANACIMIENTO, IDDOMICilio)
VALUES (32109877, 'USUARIO_15', 'APELLIDO_15', 'F', '2021-03-15', 24);

--INSERT COBERTURAS
INSERT INTO COBERTURAS (NOMBRE) VALUES
('OSPE'), ('OSDE'), ('OSMATA'), ('OSECAC'), ('OSPIP'), ('OSCHOCA'), ('PAMI');