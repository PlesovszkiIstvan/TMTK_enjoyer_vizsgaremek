drop database if exists isabike;
CREATE DATABASE isabike;
USE isabike;

create TABLE Felhasznalok (
	felhasznalo_id mediumint primary key auto_increment,
    felhasznalo_nev varchar(20) not null,
    vezetek_nev varchar(30) not null,
    kereszt_nev varchar(30) not null,
    vasarlo_telefonszama varchar(20),
	email varchar(40) not null,
	jelszo varchar(200) not null,
    szalitasi_cime varchar(40),
    jogosultsag tinyint default 0,
    regisztracio_ideje DATETIME default NOW(),
    viszaigazolas_statusz boolean default false,
    aktiv boolean default false,
    constraint email_check check (email LIKE '%@%')
    -- constraint vasarlo_telefonszama_check check (vasarlo_telefonszama like '123456789')
);

create table Viszaigazolo_kod(
	viszaigazolo_kod_id mediumint primary key auto_increment,
    felhasznalo_id mediumint,
    viszaigazolo_kod varchar(5),
    constraint fk_in_viszaigazolo_kod_felhasznalo_id foreign key(felhasznalo_id) REFERENCES Felhasznalok(felhasznalo_id) ON delete restrict
);

create table Tokenek(
	token_id mediumint primary key auto_increment,
    felhasznalo_id mediumint,
    token varchar(120),
	generalas_ideje DATETIME default NOW(),
    constraint fk_in_token_felhasznalo_id foreign key(felhasznalo_id) REFERENCES Felhasznalok(felhasznalo_id) ON delete restrict
);

create table Ertekelesek(
	ertekeles_id tinyint primary key auto_increment, 
    ertekeles varchar(20) not null
);

create table velemenyek(
	velemeny_id smallint primary key auto_increment,
    felhasznalo_id mediumint not null,
    ertekeles_id tinyint default 1,
    velemeny varchar(500) default 'Ez egy jó bolt!',
    lathato boolean default true,
    constraint fk_in_velemenyek_felhasznalo_id foreign key(felhasznalo_id) REFERENCES Felhasznalok(felhasznalo_id) ON delete restrict,
    constraint fk_in_Ertekelesek_ertekeles_id foreign key(ertekeles_id) REFERENCES Ertekelesek(ertekeles_id) ON delete restrict
);

create table Kedvezmenyek(
	kedvezmeny_id tinyint primary key auto_increment,
    kedvezmeny_neve varchar(50) not null,
    kedvezmeny_leiras varchar(500) not null,
    kedvezmeny_összege smallint default 0,
    aktiv boolean default 1
);

create table Szalitok(
	szalito_id tinyint primary key auto_increment,
    szalito_nev varchar(50) not null,
    telefonszama varchar(25) not null,
    webhely varchar(50) not null 
);

create table Fizetes_opciok(
	fizetes_opcio_id tinyint primary key auto_increment,
    fizetes_modja varchar(50)
);

create table Rendelesek(
	rendeles_id mediumint primary key auto_increment,
    felhasznalo_id mediumint,
    rendeles_ideje DATETIME default NOW(),
    megjegyzes varchar(200),
    szalito_id tinyint,
    fizetes_opcio_id TINYINT,
    kedvezmeny_id tinyint,
	constraint fk_in_felhasznalok_felhasznalo_id foreign key(felhasznalo_id) REFERENCES Felhasznalok(felhasznalo_id) ON delete restrict,
    constraint fk_in_rendelesek_kedvezmeny_id foreign key(kedvezmeny_id) REFERENCES Kedvezmenyek(kedvezmeny_id) ON delete restrict,
    constraint fk_in_rendelesek_szalito_id foreign key(szalito_id) REFERENCES Szalitok(szalito_id) ON delete restrict,
    constraint fk_in_rendelesek_fizetes_opcio_id foreign key(fizetes_opcio_id) REFERENCES Fizetes_opciok(fizetes_opcio_id) ON delete restrict
    
);

create table Gyartok(
	gyarto_id tinyint primary key auto_increment,
    gyarto_neve varchar(20) not null unique,
	telefonszama varchar(25) not null,
    webhely varchar(50) not null 
);

create table Kategoriak(
	kategoria_id mediumint primary key auto_increment,
	kategoria_neve varchar(50) not null
);

create table Tomeg_tulajdonsagai(
	tomeg_tulajdonsaga_id tinyint primary key auto_increment,
    mertek_egysege varchar(20)
);

create table Termekek(
	termek_id mediumint primary key auto_increment,
    kategoria_id mediumint not null,
    termek_nev varchar(50) not null,
    gyarto_id tinyint not null,
    raktarondb bigint default 0,
    tomeg_tulajdonsaga_id tinyint not null,
    tomeg_erteke double,
    szine varchar(50) default 'valoszinü',
    leiras varchar(500) not null,
    egyseg_ar mediumint unsigned,
    elerheto boolean default 1,
    constraint ar_check check (egyseg_ar >= 1),
    constraint suly_check check(tomeg_erteke > 0),
    constraint fk_in_Termekek_gyarto_id foreign key(gyarto_id) references Gyartok(gyarto_id),
	constraint fk_in_Termekek_kategoria_id foreign key(kategoria_id) references Kategoriak(kategoria_id),
    constraint fk_in_Termekek_tomeg_tulajdonsaga_id foreign key(tomeg_tulajdonsaga_id) references Tomeg_tulajdonsagai(tomeg_tulajdonsaga_id)
);

create table termek_kepek(
	termek_kep_id mediumint primary key auto_increment,
    termek_id mediumint not null,
    kep_helye MEDIUMTEXT ,
    constraint fk_in_termekek_kep_id foreign key(termek_id) references Termekek(termek_id)
);

create table Ar_valtozasok(
	ar_valtozas_id mediumint primary key auto_increment,
    termek_id mediumint not null,
    regi_egyseg_ar mediumint not null,
    valtozas_ideje datetime,
    constraint fk_in_Ar_valtozasok_ar_valtozas_id foreign key(ar_valtozas_id) references Termekek(termek_id)
);

create table Kosarazot_termekek(
	felhasznalo_id mediumint not null,
    termekek_id mediumint not null,
    darabszam tinyint not null,
    kosarazas_ideje DATETIME default NOW(),
    constraint darabszam_check_in_kosarazot_termekek check(darabszam > 0),
	constraint fk_in_Kosarazot_termekek_felhasznalo_id_id foreign key(felhasznalo_id) references Felhasznalok(felhasznalo_id),
	constraint fk_in_Kosarazot_termekek_termek_id foreign key(termekek_id) references Termekek(termek_id)
);

create table Rendelt_termekek(
	rendelt_termek_id mediumint primary key auto_increment,
	rendeles_id mediumint not null,
    termek_id mediumint not null,
    darabszam tinyint not null,
    kezbesitve boolean default false,
    kezbesites_ideje DATETIME,
    constraint darabszam_check_in_rendelt_termekek check(darabszam > 0),
    constraint fk_in_Rendelt_termekek_rendeles_id foreign key(rendeles_id) references Rendelesek(rendeles_id),
    constraint fk_in_Rendelt_termekek_termekek_id foreign key(termek_id) references Termekek(termek_id)
);

Drop user if exists 'browserUser'@'%';
Drop user if exists 'desktopUser'@'%';

CREATE USER 'browserUser'@'%' IDENTIFIED BY 'browseradmin';
create USER 'desktopUser'@'%' IDENTIFIED BY 'desktopadmin';
GRANT EXECUTE ON isabike.* TO desktopUser@'%';
GRANT EXECUTE ON isabike.* TO browserUser@'%';
 FLUSH PRIVILEGES;

USE isabike;

INSERT INTO Felhasznalok (felhasznalo_nev, vezetek_nev, kereszt_nev, email, jelszo, jogosultsag, viszaigazolas_statusz, aktiv)
VALUES ('admin','admin','admin','admin@super.lan','admin','3',true,true);

INSERT INTO Tokenek(felhasznalo_id, token)
VALUES (1, 'admin');

INSERT INTO ertekelesek (ertekeles_id,ertekeles)
VALUES ('1','Szuper volt');

INSERT INTO ertekelesek (ertekeles_id,ertekeles)
VALUES ('2','Ajánlom');

INSERT INTO ertekelesek (ertekeles_id,ertekeles)
VALUES ('3','Kevésbé ajánlom');

INSERT INTO ertekelesek (ertekeles_id,ertekeles)
VALUES ('4','Nem ajánlom');


INSERT INTO Fizetes_opciok(fizetes_modja)
VALUES ('Kártyás Online');

INSERT INTO Fizetes_opciok(fizetes_modja)
VALUES ('Utánvétel kezpenzel');

INSERT INTO Fizetes_opciok(fizetes_modja)
VALUES ('Utánvetel Kártyával');

INSERT INTO Szalitok(szalito_nev,telefonszama,webhely)
VALUES ('GLS','06-23-400-4001','GLSexample.com');

INSERT INTO Szalitok(szalito_nev,telefonszama,webhely)
VALUES ('FOXPOST','06-23-400-4002','FOXPOSTexample.com');

INSERT INTO Szalitok(szalito_nev,telefonszama,webhely)
VALUES ('MagyarPosta','06-23-400-4003','MagyarPostaexample.com');

INSERT INTO Szalitok(szalito_nev,telefonszama,webhely)
VALUES ('DPD','06-23-400-4004','DPDexample.com');

INSERT INTO Tomeg_tulajdonsagai(mertek_egysege)
VALUES('g');

INSERT INTO Tomeg_tulajdonsagai(mertek_egysege)
VALUES('dkg');

INSERT INTO Tomeg_tulajdonsagai(mertek_egysege)
VALUES('kg');

INSERT INTO Tomeg_tulajdonsagai(mertek_egysege)
VALUES('t');

INSERT INTO Gyartok(gyarto_neve, telefonszama, webhely)
VALUES('KTM','06-23-400-5001','KTMexample.com');

INSERT INTO Gyartok(gyarto_neve, telefonszama, webhely)
VALUES('GEPIDA','06-23-400-5002','GEPIDAexample.com');

INSERT INTO Gyartok(gyarto_neve, telefonszama, webhely)
VALUES('Mongoose','06-23-400-5003','Mongooseexample.com');

INSERT INTO Gyartok(gyarto_neve, telefonszama, webhely)
VALUES('Csepel','06-23-400-5004','example.com');

INSERT INTO Gyartok(gyarto_neve, telefonszama, webhely)
VALUES('Merida','06-23-400-5005','Meridaexample.com');

INSERT INTO Gyartok(gyarto_neve, telefonszama, webhely)
VALUES('Kellys','06-23-400-5006','Kellysexample.com');

insert into Kategoriak(kategoria_neve)
VALUES
("komplet biciklik"),
("alkatrészek"),
("kiegészitök"),
("felnöt bicikli"),
("gyerek bicikli"),
("kormányok és reszei"),
("ülések"),
("fék rendszerk és részei"),
("kerekek és részei"),
("hajtás és részei");

INSERT INTO Termekek (kategoria_id, termek_nev, gyarto_id, raktarondb, tomeg_tulajdonsaga_id, tomeg_erteke, szine, leiras, egyseg_ar)
VALUES
('4', 'Trek Procaliber 9.8 Mountain Bike', 1, 12, 3, 13.2, 'Zöld/fekete', 'Könnyű, versenyzésre tervezett mountain bike profi kerékpárosoknak.', 600000),
('4', 'Specialized Epic EVO Comp Mountain Bike', 2, 8, 4, 27.5, 'Szürke/narancs', 'Sokoldalú mountain bike terepre és túrázáshoz.', 750000),
('4', 'Csepel BMX Freestyle 20" Kerékpár', 4, 15, 1, 9, 'Fekete/zöld', 'Könnyű BMX kerékpár profi BMX-eseknek.', 120000),
('7', 'KLS TREKKINGLINE NYEREG TÖBB SZÍNBEN', 6, 20, 3, 1, 'Fekete/zöld/piros/kék', 'Maximális komfortra tervezve Zone cut', 8000),
('3', 'GEPIDA KULACS SZÜRKE/PIROS 800ML', 6, 40, 2, 500, 'Szürke/piros', 'Két állású gumi szívó rész Praktikus mm széles betöltő nyílás', 1200),
('9', 'KTM Fűzött Kerék Első Deore CL 28', 1, 4, 3, 4, 'Fekete', 'Front 28" Deore CL', 35000);

insert into termek_kepek (termek_id, kep_helye)
values 
(1, "https://www.wheelbase.co.uk/wp-content/uploads/2021/12/Procaliber-9.8-x15.jpg"),
(2, "https://downhillendurokerekpar.hu/uploads/shop/downhillendurokerekpar.hu/termek/3761688_big.jpg"),
(3, "https://static.testbike.hu/images/prpic/Schwinn-Csepel-Rebel-2013-NO.jpg"),
(4, "https://ebike.hu/kepek/1BtU/kls-trekkingline-nyereg.jpg"),
(5, "https://speedbike2.cdn.shoprenter.hu/custom/speedbike2/image/cache/w191h191q100/1/4.jpg?lastmod=1702121164.1667481212"),
(6, "https://bringaboard2.cdn.shoprenter.hu/custom/bringaboard2/image/cache/w1350h750wt1/Termékek/KTM/Alkatrészek/Fűzött%20Kerék/Deore%20CL%2028%20első.jpg?lastmod=1695382539.1701073421");


INSERT INTO Kedvezmenyek (kedvezmeny_neve, kedvezmeny_leiras, kedvezmeny_összege)
values('Nincs kedvezmény', '', 0);

DElIMITER $$
create procedure check_if_felhasznalo_exist_procedure(IN felhasznalo_nev_p varchar(20), IN email_p varchar(40))
BEGIN
      
      SELECT COUNT(felhasznalo_id) as result
      FROM Felhasznalok
      WHERE felhasznalo_nev = felhasznalo_nev_p or email =  email_p;
END $$
DELIMITER ;

DElIMITER $$
create procedure add_felhasznalo_procedure(
IN felhasznalo_nev_p varchar(20),
IN vezetek_nev_p varchar(30),
IN kereszt_nev_p varchar(30),
IN email_p varchar(40),
IN jelszo_p varchar(200),
in viszaigazolo_kod_p varchar(5)
)
BEGIN
      declare felhasznalo_id int;

			INSERT INTO Felhasznalok (felhasznalo_nev, vezetek_nev, kereszt_nev, email, jelszo)
			VALUES (felhasznalo_nev_p, vezetek_nev_p, kereszt_nev_p, email_p, jelszo_p);
	
			select felhasznalok.felhasznalo_id
			into felhasznalo_id
			from felhasznalok
			where felhasznalok.email = email_p;
    
			insert into Viszaigazolo_kod(felhasznalo_id, viszaigazolo_kod)
			values(felhasznalo_id, viszaigazolo_kod_p);
            
            select * from felhasznalok
            right join viszaigazolo_kod
            on felhasznalok.felhasznalo_id = viszaigazolo_kod.felhasznalo_id
            where felhasznalok.felhasznalo_id = felhasznalo_id;
END $$
DELIMITER ;

DElIMITER $$
create procedure verify_felhasznalo_procedure(in viszaigazolo_kod_p varchar(5))
BEGIN
	declare felhasznalo_id_p int;
    select viszaigazolo_kod.felhasznalo_id 
    into felhasznalo_id_p from viszaigazolo_kod
    where viszaigazolo_kod.viszaigazolo_kod = viszaigazolo_kod_p;
	UPDATE felhasznalok
	SET felhasznalok.jogosultsag = 1, felhasznalok.viszaigazolas_statusz = 1
	WHERE felhasznalok.felhasznalo_id = felhasznalo_id_p;
    select * from felhasznalok where felhasznalok.felhasznalo_id = felhasznalo_id_p;
END $$
DELIMITER ;

DELIMITER $$
CREATE PROCEDURE logIn_felhasznalo_procedure(IN felhasznalo_jelszo_p varchar(200), IN email_p varchar(40), IN token_p varchar(120))
BEGIN
		declare felhasznalo_id_var int;

		SELECT felhasznalok.felhasznalo_id
      INTO felhasznalo_id_var
      FROM Felhasznalok
      WHERE felhasznalok.jelszo like binary felhasznalo_jelszo_p and email like  email_p and felhasznalok.viszaigazolas_statusz = 1 and felhasznalok.aktiv = 0;
      
      	  
		  if felhasznalo_id_var is null
	  then
		select FALSE as result;
	  else
		INSERT INTO tokenek(tokenek.felhasznalo_id, tokenek.token)
        values(felhasznalo_id_var, token_p);

        UPDATE felhasznalok
        SET felhasznalok.aktiv = 1
        WHERE felhasznalok.felhasznalo_id = felhasznalo_id_var;
        select *, true as result from felhasznalok
        left join tokenek
        on Felhasznalok.felhasznalo_id = tokenek.felhasznalo_id
        where felhasznalok.felhasznalo_id = felhasznalo_id_var;
      end if; 
	
END$$
DELIMITER ;

DELIMITER $$
CREATE PROCEDURE set_token_procedure(IN felhasznalo_id_p mediumint, IN token_p varchar(120))
BEGIN
		INSERT INTO tokenek(tokenek.felhasznalo_id, tokenek.token)
        values(felhasznalo_id_p, token_p);

        UPDATE felhasznalok
        SET felhasznalok.aktiv = 1
        WHERE felhasznalok.felhasznalo_id = felhasznalo_id_p;
END$$
DELIMITER ;

DELIMITER $$
CREATE PROCEDURE logout_procedure(IN token_p varchar(120))
BEGIN
		declare felhasznalo_id_var int;
        
        SELECT tokenek.felhasznalo_id
        INTO felhasznalo_id_var
        FROM tokenek
        where tokenek.token = token_p;
        
        UPDATE felhasznalok
        SET felhasznalok.aktiv = 0
        WHERE felhasznalok.felhasznalo_id = felhasznalo_id_var;
        
        DELETE FROM tokenek WHERE tokenek.felhasznalo_id = felhasznalo_id_var;
END$$
DELIMITER ;

DELIMITER $$
CREATE PROCEDURE get_felhasznalok_procedure(IN token_p varchar(120))
BEGIN
		declare felhasznalo_id_var int;
        
        SELECT tokenek.felhasznalo_id
        INTO felhasznalo_id_var
        FROM tokenek
        inner join felhasznalok on tokenek.felhasznalo_id = felhasznalok.felhasznalo_id
        where tokenek.token = token_p and felhasznalok.jogosultsag = 3;
        
        if felhasznalo_id_var is null
        then
			select false as result;
		else
			select * , true as result from felhasznalok;
		end if;
        
END$$
DELIMITER ;

DELIMITER $$
CREATE PROCEDURE get_one_felhasznalo_procedure(IN token_p varchar(120))
BEGIN
		declare felhasznalo_id_var int;
        
        SELECT tokenek.felhasznalo_id
        INTO felhasznalo_id_var
        FROM tokenek
        inner join felhasznalok on tokenek.felhasznalo_id = felhasznalok.felhasznalo_id
        where tokenek.token = token_p;
        
        if felhasznalo_id_var is null
        then
			select false as result;
		else
			select * , true as result from felhasznalok
            where felhasznalok.felhasznalo_id = felhasznalo_id_var;
		end if;
        
END$$
DELIMITER ;

DELIMITER $$
CREATE PROCEDURE update_felhasznalok_procedure(IN token_p varchar(120),
IN felhasznalo_id_p mediumint,
IN felhasznalo_nev_p varchar(20),
IN vezetek_nev_p varchar(30),
IN kereszt_nev_p varchar(30),
IN vasarlo_telefonszama_p varchar(20),
IN email_p varchar(40),
IN szalitasi_cime_p varchar(40),
IN jogosultsag_p tinyint
)
BEGIN
		declare felhasznalo_id_var int;
        
        SELECT tokenek.felhasznalo_id
        INTO felhasznalo_id_var
        FROM tokenek
        inner join felhasznalok on tokenek.felhasznalo_id = felhasznalok.felhasznalo_id
        where tokenek.token = token_p and felhasznalok.jogosultsag = 3;
        
        if felhasznalo_id_var is null
        then
			select false as result;
		else
			update felhasznalok
            set felhasznalo_nev = felhasznalo_nev_p,
				vezetek_nev = vezetek_nev_p,
                kereszt_nev = kereszt_nev_p,
                vasarlo_telefonszama = vasarlo_telefonszama_p,
                email = email_p,
                szalitasi_cime = szalitasi_cime_p,
                jogosultsag = jogosultsag_p
            where felhasznalok.felhasznalo_id = felhasznalo_id_P;
            select * , TRUE AS result from felhasznalok
            where felhasznalok.felhasznalo_id = felhasznalo_id_p;
		end if;
        
END$$
DELIMITER ;

DELIMITER $$
CREATE PROCEDURE update_one_felhasznalo_procedure(IN token_p varchar(120),
IN felhasznalo_nev_p varchar(20),
IN vezetek_nev_p varchar(30),
IN kereszt_nev_p varchar(30),
IN vasarlo_telefonszama_p varchar(20),
IN email_p varchar(40),
IN szalitasi_cime_p varchar(40)
)
BEGIN
		declare felhasznalo_id_var int;
        
        SELECT tokenek.felhasznalo_id
        INTO felhasznalo_id_var
        FROM tokenek
        inner join felhasznalok on tokenek.felhasznalo_id = felhasznalok.felhasznalo_id
        where tokenek.token = token_p;
        
        if felhasznalo_id_var is null
        then
			select false as result;
		else
			update felhasznalok
            set felhasznalo_nev = felhasznalo_nev_p,
				vezetek_nev = vezetek_nev_p,
                kereszt_nev = kereszt_nev_p,
                vasarlo_telefonszama = vasarlo_telefonszama_p,
                email = email_p,
                szalitasi_cime = szalitasi_cime_p
            where felhasznalok.felhasznalo_id = felhasznalo_id_var;
            select felhasznalo_nev, vezetek_nev, kereszt_nev, vasarlo_telefonszama, email, szalitasi_cime , TRUE AS result from felhasznalok
            where felhasznalok.felhasznalo_id = felhasznalo_id_var;
		end if;
END$$
DELIMITER ;

DELIMITER $$
CREATE PROCEDURE add_termek_procedure(IN token_p varchar(120),
    IN kategoria_id_p mediumint,
    IN termek_nev_p varchar(50),
    IN gyarto_id_p tinyint,
    IN raktarondb_p bigint,
    IN tomeg_tulajdonsaga_id_p tinyint,
    IN tomeg_erteke_p double,
    IN szine_p varchar(50),
    IN leiras_p varchar(500),
    IN egyseg_ar_p mediumint
)
BEGIN
	declare felhasznalo_id_var int;
	
	SELECT tokenek.felhasznalo_id
	INTO felhasznalo_id_var
	FROM tokenek
	inner join felhasznalok on tokenek.felhasznalo_id = felhasznalok.felhasznalo_id
	where tokenek.token = token_p and felhasznalok.jogosultsag = 3;
	
	if felhasznalo_id_var is null
	then
		select false as result;
	else
		INSERT INTO Termekek (kategoria_id, termek_nev, gyarto_id, raktarondb, tomeg_tulajdonsaga_id, tomeg_erteke, szine, leiras, egyseg_ar)
		VALUES (kategoria_id_p, termek_nev_p, gyarto_id_p, raktarondb_p, tomeg_tulajdonsaga_id_p, tomeg_erteke_p, szine_p, leiras_p, egyseg_ar_p);
        select *, true as result from Termekek ORDER BY termek_id DESC LIMIT 1;
    
    end if;
END$$
DELIMITER ;

DELIMITER $$
CREATE PROCEDURE update_termek_procedure(IN token_p varchar(120),
    IN termek_id_p mediumint,
    IN kategoria_id_p mediumint,
    IN termek_nev_p varchar(50),
    IN gyarto_id_p tinyint,
    IN raktarondb_p bigint,
    IN tomeg_tulajdonsaga_id_p tinyint,
    IN tomeg_erteke_p double,
    IN szine_p varchar(50),
    IN leiras_p varchar(500),
    IN egyseg_ar_p mediumint
)
BEGIN
	declare felhasznalo_id_var int;
	
	SELECT tokenek.felhasznalo_id
	INTO felhasznalo_id_var
	FROM tokenek
	inner join felhasznalok on tokenek.felhasznalo_id = felhasznalok.felhasznalo_id
	where tokenek.token = token_p and felhasznalok.jogosultsag = 3;
	
	if felhasznalo_id_var is null
	then
		select false as result;
	else
		UPDATE Termekek
		SET	kategoria_id = kategoria_id_p,
		termek_nev = termek_nev_p,
		gyarto_id = gyarto_id_p,
		raktarondb = raktarondb_p,
		tomeg_tulajdonsaga_id = tomeg_tulajdonsaga_id_p,
		tomeg_erteke = tomeg_erteke_p,
		szine = szine_p,
		leiras = leiras_p,
		egyseg_ar = egyseg_ar_p
		WHERE termek_id = termek_id_p;
        select *, true as result from termekek
        where termekek.termek_id = termek_id_p;
	end if;
END$$
DELIMITER ;

DELIMITER $$
CREATE PROCEDURE update_termekek_elerheto_procedure(IN token_p varchar(120), IN termek_id_p MEDIUMINT)
BEGIN
	DECLARE elerheto_var boolean;
	declare felhasznalo_id_var int;
	
	SELECT tokenek.felhasznalo_id
	INTO felhasznalo_id_var
	FROM tokenek
	inner join felhasznalok on tokenek.felhasznalo_id = felhasznalok.felhasznalo_id
	where tokenek.token = token_p and felhasznalok.jogosultsag = 3;
	
	if felhasznalo_id_var is null
	then
		select false as result;
	else
		SELECT Termekek.elerheto
		INTO elerheto_var
		FROM Termekek
		WHERE Termekek.termek_id = termek_id_p;
		if elerheto_var = true
		then
			UPDATE Termekek
			SET Termekek.elerheto = FALSE
			WHERE Termekek.termek_id = termek_id_p;
            select true as result;
		else
			UPDATE Termekek
			SET Termekek.elerheto = TRUE
			WHERE Termekek.termek_id = termek_id_p;
            select true as result;
		end if;
	end if;
END$$
DELIMITER ;

DELIMITER $$
CREATE PROCEDURE get_termekek_procedure(IN limit_p integer)
BEGIN
      select
		termekek.termek_id,
        termekek.kategoria_id,
        kategoria_neve,
        termek_nev,
        termekek.gyarto_id,
        gyarto_neve,
        telefonszama,
        webhely,
        raktarondb,
        termekek.tomeg_tulajdonsaga_id,
        mertek_egysege, 
        tomeg_erteke, 
        szine, 
        leiras, 
        egyseg_ar, 
        elerheto, 
        MIN(kep_helye) as kep_helye
        from termekek
        left join kategoriak
        on termekek.kategoria_id = kategoriak.kategoria_id
        left join gyartok
        on termekek.gyarto_id = gyartok.gyarto_id
        left join tomeg_tulajdonsagai
        on termekek.tomeg_tulajdonsaga_id = tomeg_tulajdonsagai.tomeg_tulajdonsaga_id
        left join termek_kepek
        on termekek.termek_id = termek_kepek.termek_id
        group by
        termekek.termek_id,
        termekek.kategoria_id,
        kategoria_neve,
        termek_nev,
        termekek.gyarto_id,
        gyarto_neve,
        telefonszama,
        webhely,
        raktarondb,
        termekek.tomeg_tulajdonsaga_id,
        mertek_egysege, 
        tomeg_erteke, 
        szine, 
        leiras, 
        egyseg_ar, 
        elerheto
        limit limit_p;
   END$$
DELIMITER ;

DElIMITER $$
create procedure add_gyartok_procedure(IN token_p varchar(120), IN gyarto_neve_p varchar(20), IN telefonszama_p varchar(25), IN webhely_p varchar(50))
BEGIN
	declare felhasznalo_id_var int;
	
	SELECT tokenek.felhasznalo_id
	INTO felhasznalo_id_var
	FROM tokenek
	inner join felhasznalok on tokenek.felhasznalo_id = felhasznalok.felhasznalo_id
	where tokenek.token = token_p and felhasznalok.jogosultsag = 3;
	
	if felhasznalo_id_var is null
	then
		select false as result;
	else
		INSERT INTO Gyartok (gyarto_neve, telefonszama, webhely)
		VALUES (gyarto_neve_p, telefonszama_p, webhely_p);
        select true as result;
	end if;
END $$
DELIMITER ;

DElIMITER $$
create procedure get_gyartok_procedure()
BEGIN
	SELECT * FROM Gyartok;
END $$
DELIMITER ;

DElIMITER $$
create procedure update_gyartok_procedure(IN token_p varchar(120), IN gyarto_id_p tinyint, IN gyarto_neve_p varchar(20), IN telefonszama_p varchar(25), IN webhely_p varchar(50))
BEGIN
	declare felhasznalo_id_var int;
	
	SELECT tokenek.felhasznalo_id
	INTO felhasznalo_id_var
	FROM tokenek
	inner join felhasznalok on tokenek.felhasznalo_id = felhasznalok.felhasznalo_id
	where tokenek.token = token_p and felhasznalok.jogosultsag = 3;
	
	if felhasznalo_id_var is null
	then
		select false as result;
	else
		UPDATE Gyartok
		SET gyarto_neve = gyarto_neve_p,
			telefonszama = telefonszama_p,
			webhely = webhely_p
		WHERE gyarto_id = gyarto_id_p;
        select true as result;
    end if;
END $$
DELIMITER ;

DElIMITER $$
create procedure get_ertekelesek_procedure()
BEGIN
	SELECT * FROM ertekelesek;
END $$
DELIMITER ;

DElIMITER $$
create procedure get_tomeg_tulajdonsagok_procedure()
BEGIN
	SELECT * FROM tomeg_tulajdonsagai;
END $$
DELIMITER ;

DElIMITER $$
create procedure add_tomeg_tulajdonsagok_procedure(IN Token_p varchar(100), in mertek_egysege varchar(20))
BEGIN
		declare felhasznalo_id_var int;
		
		SELECT tokenek.felhasznalo_id
		INTO felhasznalo_id_var
		FROM tokenek
		inner join felhasznalok on tokenek.felhasznalo_id = felhasznalok.felhasznalo_id
		where tokenek.token = token_p and felhasznalok.jogosultsag = 3;
		
		if felhasznalo_id_var is null
		then
			select false as result;
		else
			insert into tomeg_tulajdonsagai(mertek_egysege)
            values (mertek_egysege);
            select *, true as result from tomeg_tulajdonsagai order by tomeg_tulajdonsagai.tomeg_tulajdonsaga_id desc limit 1;
		end if;
END $$
DELIMITER ;

DELIMITER $$
CREATE PROCEDURE add_velemenyek_procedure(IN Token_p varchar(100), IN ertekeles_id_p tinyint, IN velemeny_p varchar(500))
   BEGIN
      DECLARE felhasznalo_id_var mediumint;
      
      SELECT Tokenek.felhasznalo_id
      INTO felhasznalo_id_var
      FROM Tokenek
      WHERE Tokenek.token = Token_p;
      if felhasznalo_id_var is null
      then 
			select false as result;
		else
		  INSERT INTO velemenyek (felhasznalo_id, ertekeles_id, velemeny)
		  VALUES (felhasznalo_id_var, ertekeles_id_p, velemeny_p);
		select true as result;
        end if;
   END $$
DELIMITER ;

DElIMITER $$
create procedure get_velemenyek_procedure()
BEGIN
	SELECT * FROM velemenyek;
END $$
DELIMITER ;

DElIMITER $$
create procedure change_velemenyek_lathato_procedure(IN Token_p varchar(100), IN velemeny_id_p smallint)
BEGIN
	DECLARE lathato_var boolean;
	declare felhasznalo_id_var int;
	
	SELECT tokenek.felhasznalo_id
	INTO felhasznalo_id_var
	FROM tokenek
	inner join felhasznalok on tokenek.felhasznalo_id = felhasznalok.felhasznalo_id
	where tokenek.token = token_p and felhasznalok.jogosultsag = 3;
	
	if felhasznalo_id_var is null
	then
		select false as result;
	else
		SELECT velemenyek.lathato
		INTO lathato_var
		FROM velemenyek
		WHERE velemenyek.velemeny_id = velemeny_id_p;
		
		if lathato_var = true
		then
			UPDATE velemenyek
			SET velemenyek.lathato = FALSE
			WHERE velemenyek.velemeny_id = velemeny_id_p;
            select true as result;
		else
			UPDATE velemenyek
			SET velemenyek.lathato = TRUE
			WHERE velemenyek.velemeny_id = velemeny_id_p;
            select true as result;
		end if;
	end if;
END $$
DELIMITER ;

DElIMITER $$
create procedure add_termek_kep_procedure(IN Token_p varchar(100), IN termek_id_p mediumint, IN kep_helye_p MEDIUMTEXT)
BEGIN
	declare felhasznalo_id_var int;
	
	SELECT tokenek.felhasznalo_id
	INTO felhasznalo_id_var
	FROM tokenek
	inner join felhasznalok on tokenek.felhasznalo_id = felhasznalok.felhasznalo_id
	where tokenek.token = token_p and felhasznalok.jogosultsag = 3;
	
	if felhasznalo_id_var is null
	then
		select false as result;
	else
		INSERT INTO termek_kepek(termek_id, kep_helye)
		VALUES (termek_id_p, kep_helye_p);
		select true as result;
    end if;
END $$
DELIMITER ;

DElIMITER $$
create procedure get_termek_kepek_procedure(IN termek_id_p mediumint)
BEGIN
	SELECT * FROM termek_kepek where termek_kepek.termek_id = termek_id_p;
END $$
DELIMITER ;

DElIMITER $$
create procedure delete_termek_kep_procedure(IN Token_p varchar(100), IN termek_id_p mediumint)
BEGIN
	declare felhasznalo_id_var int;
	
	SELECT tokenek.felhasznalo_id
	INTO felhasznalo_id_var
	FROM tokenek
	inner join felhasznalok on tokenek.felhasznalo_id = felhasznalok.felhasznalo_id
	where tokenek.token = token_p and felhasznalok.jogosultsag = 3;
	
	if felhasznalo_id_var is null
	then
		select false as result;
	else
		DELETE FROM termek_kepek WHERE termek_kepek.termek_id = termek_id_p;
		select true as result;
    end if;
END $$
DELIMITER ;

DElIMITER $$
create procedure add_kosarazot_termek_procedure(IN Token_p varchar(100), IN termekek_id_p mediumint, IN darabszam_p tinyint)
BEGIN
	  DECLARE felhasznalo_id_var mediumint;
      DECLARE termek_darabszam_var tinyint;
      
      SELECT termekek.raktarondb
      into termek_darabszam_var
      from termekek
      where termekek.termek_id = termekek_id_p;
      SELECT Tokenek.felhasznalo_id
      INTO felhasznalo_id_var
      FROM Tokenek
      WHERE Tokenek.token = Token_p;
      
	  if felhasznalo_id_var is null
		then
			select 0 as result;
	  elseif termek_darabszam_var < darabszam_p
		then
			select 2 as result;
		else
		  INSERT INTO Kosarazot_termekek (felhasznalo_id, termekek_id, darabszam)
		  VALUES(felhasznalo_id_var, termekek_id_p, darabszam_p);
			select 3 as result;
		end if;
END $$
DELIMITER ;

DElIMITER $$
create procedure get_one_kosarazot_termek_procedure(IN Token_p varchar(100))
BEGIN
		DECLARE felhasznalo_id_var mediumint;
      
      SELECT Tokenek.felhasznalo_id
      INTO felhasznalo_id_var
      FROM Tokenek
      WHERE Tokenek.token = Token_p;
      
	  if felhasznalo_id_var is null
		then
			select false as result;
		else
			SELECT *, true as result FROM Kosarazot_termekek 
            left join termekek
			on termekek.termek_id = Kosarazot_termekek.termekek_id
            where kosarazot_termekek.felhasznalo_id = felhasznalo_id_var;
		end if;
END $$
DELIMITER ;

DElIMITER $$
create procedure update_kosarazot_termeke_darabszam_procedure(IN Token_p varchar(100), IN termekek_id_p mediumint, IN darabszam_p tinyint)
BEGIN
	DECLARE felhasznalo_id_var mediumint;
	DECLARE termek_darabszam_var tinyint;
      
	SELECT termekek.raktarondb
	into termek_darabszam_var
	from termekek
	where termekek.termek_id = termekek_id_p;
	SELECT Tokenek.felhasznalo_id
	INTO felhasznalo_id_var
	FROM Tokenek
	WHERE Tokenek.token = Token_p;
    
    if felhasznalo_id_var is null
		then
			select 0 as result;
	elseif termek_darabszam_var < darabszam_p
		then
			select 1 as result;
	else
			UPDATE Kosarazot_termekek
			SET darabszam  = darabszam_p
			WHERE felhasznalo_id  = felhasznalo_id_var and termekek_id = termekek_id_p;
            select 2 as result;
	end if;
END $$
DELIMITER ;

DElIMITER $$
create procedure delete_kosarazot_termekek_procedure(IN Token_p varchar(100), IN termekek_id_p mediumint)
BEGIN
		DECLARE felhasznalo_id_var mediumint;
    
		SELECT Tokenek.felhasznalo_id
		INTO felhasznalo_id_var
		FROM Tokenek
		WHERE Tokenek.token = Token_p;
		
		if felhasznalo_id_var is null
			then
				select false as result;
			else
				DELETE FROM kosarazot_termekek WHERE felhasznalo_id  = felhasznalo_id_var and termekek_id = termekek_id_p;
                SELECT true as result;
		end if;
				
END $$
DELIMITER ;

DElIMITER $$
create procedure add_rendeles_procedure(IN Token_p varchar(100), IN vasarlo_telefonszama_p varchar(20), IN szalitasi_cime_p varchar(40), IN megjegyzes_p varchar(200), IN szalito_id_p tinyint, IN fizetes_opcio_id_p tinyint, IN kedvezmeny_id_p tinyint)
BEGIN
		DECLARE felhasznalo_id_var mediumint;
        declare rendeles_id_var mediumint;
    
		SELECT Tokenek.felhasznalo_id
		INTO felhasznalo_id_var
		FROM Tokenek
		WHERE Tokenek.token = Token_p;
		
		if felhasznalo_id_var is null
			then
				select false as result;
		else
			INSERT INTO rendelesek (felhasznalo_id, megjegyzes, szalito_id, fizetes_opcio_id, kedvezmeny_id)
			VALUES (felhasznalo_id_var, megjegyzes_p, szalito_id_p, fizetes_opcio_id_p, kedvezmeny_id_p);
            
            select rendelesek.rendeles_id
            into rendeles_id_var
            from rendelesek order by rendeles_id desc limit 1;
            
            INSERT INTO rendelt_termekek (rendeles_id, termek_id, darabszam)
			SELECT rendeles_id_var, termekek_id, darabszam
			FROM kosarazot_termekek
			WHERE felhasznalo_id = felhasznalo_id_var;
			
            update termekek, rendelt_termekek
			set termekek.raktarondb = raktarondb - rendelt_termekek.darabszam
			where termekek.termek_id = rendelt_termekek.termek_id and rendelt_termekek.rendeles_id = rendeles_id_var;
            
            UPDATE felhasznalok
			SET felhasznalok.vasarlo_telefonszama = vasarlo_telefonszama_p, felhasznalok.szalitasi_cime = szalitasi_cime_p
			WHERE felhasznalok.felhasznalo_id = felhasznalo_id_var;
            
            delete from kosarazot_termekek where kosarazot_termekek.felhasznalo_id = felhasznalo_id_var;
        end if;
        select *, felhasznalok.email, true as result from rendelesek inner join felhasznalok on rendelesek.felhasznalo_id = felhasznalok.felhasznalo_id  where rendelesek.felhasznalo_id = felhasznalo_id_var order by rendeles_id desc limit 1;
END $$
DELIMITER ;

DElIMITER $$
create procedure get_one_rendeles_procedure(IN Token_p varchar(100))
BEGIN
		DECLARE felhasznalo_id_var mediumint;
      
      SELECT Tokenek.felhasznalo_id
      INTO felhasznalo_id_var
      FROM Tokenek
      WHERE Tokenek.token = Token_p;
      
	  if felhasznalo_id_var is null
		then
			select false as result;
		else
			SELECT *, true as result FROM rendelesek
            where rendelesek.felhasznalo_id = felhasznalo_id_var;
		end if;
END $$
DELIMITER ;

DElIMITER $$
create procedure get_all_rendeles_procedure(IN Token_p varchar(100))
BEGIN
		declare felhasznalo_id_var int;
		
		SELECT tokenek.felhasznalo_id
		INTO felhasznalo_id_var
		FROM tokenek
		inner join felhasznalok on tokenek.felhasznalo_id = felhasznalok.felhasznalo_id
		where tokenek.token = token_p and felhasznalok.jogosultsag = 3;
		
		if felhasznalo_id_var is null
		then
			select false as result;
		else
			SELECT rendeles_id, rendeles_ideje, megjegyzes, szalito_nev, fizetes_modja, kedvezmeny_id, felhasznalo_nev, vasarlo_telefonszama, email, szalitasi_cime, true as result FROM rendelesek 
		left join felhasznalok
        on rendelesek.felhasznalo_id = felhasznalok.felhasznalo_id
		left join Szalitok
        on rendelesek.szalito_id = Szalitok.szalito_id
		left join Fizetes_opciok
        on rendelesek.fizetes_opcio_id = Fizetes_opciok.fizetes_opcio_id;
		end if;
END $$
DELIMITER ;

DElIMITER $$
create procedure get_rendelt_termekek_procedure(IN Token_p varchar(100))
BEGIN
	declare felhasznalo_id_var int;
		
		SELECT tokenek.felhasznalo_id
		INTO felhasznalo_id_var
		FROM tokenek
		inner join felhasznalok on tokenek.felhasznalo_id = felhasznalok.felhasznalo_id
		where tokenek.token = token_p and felhasznalok.jogosultsag = 3;
		
		if felhasznalo_id_var is null
		then
			select false as result;
		else
			SELECT *, true as result FROM rendelt_termekek;
		end if;
END $$
DELIMITER ;

DElIMITER $$
create procedure get_one_rendeles_termekek_procedure(IN rendeles_id mediumint)
BEGIN
	select rendelt_termek_id, rendeles_id, termek_nev, darabszam, egyseg_ar, kezbesitve from rendelt_termekek left join termekek
        on rendelt_termekek.termek_id = termekek.termek_id where rendelt_termekek.rendeles_id = rendeles_id;
END $$
DELIMITER ;

DElIMITER $$
create procedure update_rendelt_termek(IN Token_p varchar(100), IN rendelt_termek_id_p mediumint)
BEGIN
	declare felhasznalo_id_var int;
		
		SELECT tokenek.felhasznalo_id
		INTO felhasznalo_id_var
		FROM tokenek
		inner join felhasznalok on tokenek.felhasznalo_id = felhasznalok.felhasznalo_id
		where tokenek.token = token_p and felhasznalok.jogosultsag = 3;
		
		if felhasznalo_id_var is null
		then
			select false as result;
		else
			UPDATE rendelt_termekek
			SET rendelt_termekek.kezbesitve = true
			WHERE rendelt_termekek.rendelt_termek_id = rendelt_termek_id_p;
			select true as result;
		end if;
END $$
DELIMITER ;


DElIMITER $$
create procedure get_kategoriak_procedure()
BEGIN
	select * from kategoriak;
END $$
DELIMITER ;


DElIMITER $$
create procedure get_one_termek_procedure(IN termek_id_p mediumint)
BEGIN
	select 
		termekek.termek_id,
        termekek.kategoria_id,
        kategoria_neve,
        termek_nev,
        termekek.gyarto_id,
        gyarto_neve,
        telefonszama,
        webhely,
        raktarondb,
        termekek.tomeg_tulajdonsaga_id,
        mertek_egysege, 
        tomeg_erteke, 
        szine, 
        leiras, 
        egyseg_ar, 
        elerheto,
        kep_helye as kep_helye
    from termekek 
		left join kategoriak
        on termekek.kategoria_id = kategoriak.kategoria_id
        left join gyartok
        on termekek.gyarto_id = gyartok.gyarto_id
        left join tomeg_tulajdonsagai
        on termekek.tomeg_tulajdonsaga_id = tomeg_tulajdonsagai.tomeg_tulajdonsaga_id
		left join termek_kepek
        on termekek.termek_id = termek_kepek.termek_id
	where termekek.termek_id = termek_id_p;
END $$
DELIMITER ;

