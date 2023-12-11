DElIMITER $$
create procedure add_fizetes_opcio_procedure(IN fizetes_modja_p varchar(50))
BEGIN
	INSERT INTO Fizetes_opciok (fizetes_modja)
	VALUES (fizetes_modja_p);
END $$
DELIMITER ;

DElIMITER $$
create procedure get_fizetes_opciok_procedure()
BEGIN
	SELECT * FROM Fizetes_opciok;
END $$
DELIMITER ;

DElIMITER $$
create procedure update_fizetesi_opciok_procedure(IN fizetes_opcio_id_p tinyint, IN fizetes_modja_p varchar(50))
BEGIN
	UPDATE Fizetes_opciok
	SET fizetes_modja = fizetes_modja_p
	WHERE fizetes_opcio_id = fizetes_opcio_id_p;
END $$
DELIMITER ;









