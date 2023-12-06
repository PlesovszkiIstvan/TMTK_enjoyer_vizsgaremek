CREATE DATABASE isabike;
USE isabike;

create TABLE Felhasznalok (
	felhasznalo_id mediumint primary key auto_increment,
    felhasznalo_nev varchar(20) not null unique,
    vezetek_nev varchar(30) not null,
    kereszt_nev varchar(30) not null,
    vasarlo_telefonszama varchar(20),
	email varchar(40) not null unique,
	jelszo tinytext not null,
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
    token TINYTEXT,
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
    termek_nev varchar(20) not null unique,
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



























