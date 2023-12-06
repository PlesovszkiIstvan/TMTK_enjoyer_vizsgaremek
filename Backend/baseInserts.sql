USE isabike;

INSERT INTO Felhasznalok (felhasznalo_nev, vezetek_nev, kereszt_nev, email, jelszo, jogosultsag, viszaigazolas_statusz, aktiv)
VALUES ('nagyJ69','Nagy','János','nagyj69@gmail.com','Almafa12;','1',true,true);

INSERT INTO Tokenek (felhasznalo_id,token)
VALUES ('4','EZEGYTOKEN123');

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