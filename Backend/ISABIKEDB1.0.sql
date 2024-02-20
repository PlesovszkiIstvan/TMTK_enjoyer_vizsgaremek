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

create table Tomeg_tulajdonsagai(
	tomeg_tulajdonsaga_id tinyint primary key auto_increment,
    mertek_egysege varchar(20)
);

create table Termekek(
	termek_id mediumint primary key auto_increment,
    termek_kateg varchar(8) default '00000000',
    termek_nev varchar(20) not null,
    gyarto_id tinyint not null,
    raktarondb smallint default 0,
    tomeg_tulajdonsaga_id tinyint not null,
    tomeg_erteke double,
    szine varchar(50) default 'valoszinü',
    leiras varchar(500) not null,
    egyseg_ar mediumint unsigned,
    elerheto boolean default 1,
    constraint ar_check check (egyseg_ar >= 1),
    constraint suly_check check(tomeg_erteke > 0),
    constraint fk_in_Termekek_gyarto_id foreign key(gyarto_id) references Gyartok(gyarto_id),
    constraint fk_in_Termekek_tomeg_tulajdonsaga_id foreign key(tomeg_tulajdonsaga_id) references Tomeg_tulajdonsagai(tomeg_tulajdonsaga_id)
);

create table termek_kepek(
	termek_kep_id mediumint primary key auto_increment,
    termek_id mediumint not null,
    kep_helye varchar(100) unique default '/termek_kepek/noimage.jpg',
    constraint kep_vizsgalat check (kep_helye LIKE '%.jpg'),
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
VALUES ('nagyJ69','Nagy','János','nagyj69@gmail.com','Almafa12;','1',true,true);


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

INSERT INTO Termekek (termek_kateg, termek_nev, gyarto_id, raktarondb, tomeg_tulajdonsaga_id, tomeg_erteke, szine, leiras, egyseg_ar )
VALUES ('01', 'PirosBicigli0', 1, 1, 1, 20, 'piros', 'lopott', 1500);

INSERT INTO Termekek (termek_kateg, termek_nev, gyarto_id, raktarondb, tomeg_tulajdonsaga_id, tomeg_erteke, szine, leiras, egyseg_ar )
VALUES ('01', 'PirosBicigli1', 2, 1, 1, 20, 'piros', 'lopott', 1500);

INSERT INTO Termekek (termek_kateg, termek_nev, gyarto_id, raktarondb, tomeg_tulajdonsaga_id, tomeg_erteke, szine, leiras, egyseg_ar )
VALUES ('01', 'PirosBicigli2', 3, 1, 1, 20, 'piros', 'lopott', 1500);

INSERT INTO Termekek (termek_kateg, termek_nev, gyarto_id, raktarondb, tomeg_tulajdonsaga_id, tomeg_erteke, szine, leiras, egyseg_ar )
VALUES ('01', 'PirosBicigli3', 4, 1, 1, 20, 'piros', 'lopott', 1500);

INSERT INTO Termekek (termek_kateg, termek_nev, gyarto_id, raktarondb, tomeg_tulajdonsaga_id, tomeg_erteke, szine, leiras, egyseg_ar )
VALUES ('01', 'PirosBicigli4', 5, 1, 1, 20, 'piros', 'lopott', 1500);   

DELIMITER $$
CREATE PROCEDURE add_termek_procedure(
    IN termek_kateg_p varchar(8),
    IN termek_nev_p varchar(20),
    IN gyarto_id_p tinyint,
    IN raktarondb_p smallint,
    IN tomeg_tulajdonsaga_id_p tinyint,
    IN tomeg_erteke_p double,
    IN szine_p varchar(50),
    IN leiras_p varchar(500),
    IN egyseg_ar_p mediumint
)
BEGIN
	INSERT INTO Termekek (termek_kateg, termek_nev, gyarto_id, raktarondb, tomeg_tulajdonsaga_id, tomeg_erteke, szine, leiras, egyseg_ar)
	VALUES (termek_kateg_p, termek_nev_p, gyarto_id_p, raktarondb_p, tomeg_tulajdonsaga_id_p, tomeg_erteke_p, szine_p, leiras_p, egyseg_ar_p);
END$$
DELIMITER ;

DELIMITER $$
CREATE PROCEDURE update_termek_procedure(
    IN termek_id_p mediumint,
    IN termek_kateg_p varchar(8),
    IN termek_nev_p varchar(20),
    IN gyarto_id_p tinyint,
    IN raktarondb_p smallint,
    IN tomeg_tulajdonsaga_id_p tinyint,
    IN tomeg_erteke_p double,
    IN szine_p varchar(50),
    IN leiras_p varchar(500),
    IN egyseg_ar_p mediumint
)
BEGIN
    UPDATE Termekek
	SET	termek_kateg = termek_kateg_p,
    termek_nev = termek_nev_p,
    gyarto_id = gyarto_id_p,
    raktarondb = raktarondb_p,
    tomeg_tulajdonsaga_id = tomeg_tulajdonsaga_id_p,
    tomeg_erteke = tomeg_erteke_p,
    szine = szine_p,
    leiras = leiras_p,
    egyseg_ar = egyseg_ar_p
	WHERE termek_id = termek_id_p;
END$$
DELIMITER ;

DELIMITER $$
CREATE PROCEDURE update_termekek_elerheto_procedure(IN termek_id_p MEDIUMINT)
BEGIN
	DECLARE elerheto_var boolean;
    
    SELECT Termekek.elerheto
    INTO elerheto_var
    FROM Termekek
    WHERE Termekek.termek_id = termek_id_p;
    
    if elerheto_var = true
    then
		UPDATE Termekek
        SET Termekek.elerheto = FALSE
        WHERE Termekek.termek_id = termek_id_p;
	else
		UPDATE Termekek
        SET Termekek.elerheto = TRUE
        WHERE Termekek.termek_id = termek_id_p;
    end if;
END$$
DELIMITER ;

DELIMITER $$
CREATE PROCEDURE get_termekek_procedure()
BEGIN
      select 
        termekek.termek_id,
        termek_kateg,
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
        kep_helye
        from termekek
        left join gyartok
        on termekek.gyarto_id = gyartok.gyarto_id
        left join tomeg_tulajdonsagai
        on termekek.tomeg_tulajdonsaga_id = tomeg_tulajdonsagai.tomeg_tulajdonsaga_id
        left join termek_kepek
        on termekek.termek_id = termek_kepek.termek_id;
   END$$
DELIMITER ;

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
        select * from felhasznalok
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























