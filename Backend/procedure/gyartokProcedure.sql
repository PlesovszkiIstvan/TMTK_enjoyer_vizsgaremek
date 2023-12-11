DElIMITER $$
create procedure add_gyartok_procedure(IN gyarto_neve_p varchar(20), IN telefonszama_p varchar(25), IN webhely_p varchar(50))
BEGIN
	INSERT INTO Gyartok (gyarto_neve, telefonszama, webhely)
	VALUES (gyarto_neve_p, telefonszama_p, webhely_p);
END $$
DELIMITER ;

DElIMITER $$
create procedure get_gyartok_procedure()
BEGIN
	SELECT * FROM Gyartok;
END $$
DELIMITER ;

DElIMITER $$
create procedure update_gyartok_procedure(IN gyarto_id_p tinyint, IN gyarto_neve_p varchar(20), IN telefonszama_p varchar(25), IN webhely_p varchar(50))
BEGIN
	UPDATE Gyartok
	SET gyarto_neve = gyarto_neve_p,
		telefonszama = telefonszama_p,
        webhely = webhely_p
	WHERE gyarto_id = gyarto_id_p;
END $$
DELIMITER ;