DElIMITER $$
create procedure add_szalitok_procedure(IN szalito_nev_p varchar(50), IN telefonszama_p varchar(25), webhely_p varchar(50))
BEGIN
	INSERT INTO Szalitok (szalito_nev, telefonszama, webhely)
	VALUES (szalito_nev_p, telefonszama_p, webhely_p);
END $$
DELIMITER ;

DElIMITER $$
create procedure get_szalitok_procedure()
BEGIN
	SELECT * FROM Szalitok;
END $$
DELIMITER ;

DElIMITER $$
create procedure update_szalitok_procedure(IN szalito_id_p tinyint, IN szalito_nev_p varchar(50), IN telefonszama_p varchar(25), IN webhely_p varchar(50))
BEGIN
	UPDATE Szalitok
	SET szalito_nev = szalito_nev_p,
		telefonszama = telefonszama_p,
        webhely = webhely_p
	WHERE szalito_id = szalito_id_p;
END $$
DELIMITER ;