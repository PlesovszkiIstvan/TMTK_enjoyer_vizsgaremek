DElIMITER $$
create procedure add_kedvezmenyek_procedure(in kedvezmeny_neve_p varchar(50), IN kedvezmeny_leiras_p VARCHAR(500), IN kedvezmeny_összege_p smallint)
BEGIN
	INSERT INTO Kedvezmenyek(kedvezmeny_neve, kedvezmeny_leiras, kedvezmeny_összege)
    VALUES(kedvezmeny_neve_p, kedvezmeny_leiras_p, kedvezmeny_összege_p);
END $$
DELIMITER ;

DElIMITER $$
create procedure get_kedvezmenyek_procedure()
BEGIN
	SELECT * FROM Kedvezmenyek;
END $$
DELIMITER ;

DElIMITER $$
create procedure update_kedvezmenyek_procedure(IN kedvezmeny_id_p tinyint, IN kedvezmeny_neve_p varchar(50), IN kedvezmeny_leiras_p VARCHAR(500), IN kedvezmeny_összege_p smallint)
BEGIN
	UPDATE Kedvezmenyek
	SET kedvezmeny_neve = kedvezmeny_neve_p, kedvezmeny_leiras = kedvezmeny_leiras_p, kedvezmeny_összege = kedvezmeny_összege_p
	WHERE Kedvezmenyek.kedvezmeny_id = kedvezmeny_id_p;
END $$
DELIMITER ;

DElIMITER $$
create procedure change_kedvezmenyek_aktiv_procedure(IN kedvezmeny_id_p tinyint)
BEGIN
	DECLARE kedvezmeny_aktiv_var boolean;
    
    SELECT Kedvezmenyek.aktiv
    INTO kedvezmeny_aktiv_var
    FROM Kedvezmenyek
    WHERE Kedvezmenyek.kedvezmeny_id = kedvezmeny_id_p;
    
    if kedvezmeny_aktiv_var = TRUE
    THEN
		UPDATE Kedvezmenyek
        SET Kedvezmenyek.aktiv = FALSE
        WHERE Kedvezmenyek.kedvezmeny_id = kedvezmeny_id_p;
	else
		UPDATE Kedvezmenyek
        SET Kedvezmenyek.aktiv = true
        WHERE Kedvezmenyek.kedvezmeny_id = kedvezmeny_id_p;
    end if;
	
END $$
DELIMITER ;