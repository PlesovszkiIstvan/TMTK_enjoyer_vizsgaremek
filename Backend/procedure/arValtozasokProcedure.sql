DElIMITER $$
create procedure add_ar_valtozasok_procedure(IN termek_id_p mediumint, IN regi_egyseg_ar_p mediumint, IN valtozas_ideje_p datetime)
BEGIN
	INSERT INTO Ar_valtozasok (termek_id, regi_egyseg_ar, valtozas_ideje)
	VALUES (termek_id_p, regi_egyseg_ar_p, valtozas_ideje_p);
END $$
DELIMITER ;

DElIMITER $$
create procedure get_ar_valtozasok_procedure()
BEGIN
	SELECT * FROM Ar_valtozasok;
END $$
DELIMITER ;

DElIMITER $$
create procedure update_ar_valtozasok_procedure(IN ar_valtozas_id_p mediumint, IN termek_id_p mediumint, IN regi_egyseg_ar_p mediumint)
BEGIN
	UPDATE Ar_valtozasok
	SET termek_id = termek_id_p,
		regi_egyseg_ar = regi_egyseg_ar_p
	WHERE ar_valtozas_id = ar_valtozas_id_p;
END $$
DELIMITER ;

DElIMITER $$
create procedure delete_ar_valtozasok_procedure(IN ar_valtozas_id_p mediumint)
BEGIN
	DELETE FROM Ar_valtozasok WHERE ar_valtozas_id = ar_valtozas_id_p;
END $$
DELIMITER ;