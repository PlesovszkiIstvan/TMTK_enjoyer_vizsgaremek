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
      SELECT * FROM Termekek;
   END$$
DELIMITER ;