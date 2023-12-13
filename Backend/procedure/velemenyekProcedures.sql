USE isabike;

DELIMITER $$
CREATE PROCEDURE Velemenyek_add_procedure(IN Token_p varchar(100), IN ertekeles_id_p tinyint, IN velemeny_p varchar(500))
   BEGIN
      DECLARE felhasznalo_id_var mediumint;
      
      SELECT Tokenek.felhasznalo_id
      INTO felhasznalo_id_var
      FROM Tokenek
      WHERE Tokenek.token = Token_p;
      
      INSERT INTO velemenyek (felhasznalo_id, ertekeles_id, velemeny, lathato)
      VALUES (felhasznalo_id_var, ertekeles_id_p, velemeny_p, true);
      
   END $$
DELIMITER ;

DElIMITER $$
create procedure get_velemenyek_procedure()
BEGIN
	SELECT * FROM velemenyek;
END $$
DELIMITER ;

DElIMITER $$
create procedure change_velemenyek_lathato_procedure(IN velemeny_id_p smallint)
BEGIN
	DECLARE lathato_var boolean;
    
    SELECT velemenyek.lathato
    INTO lathato_var
    FROM velemenyek
    WHERE velemenyek.velemeny_id = velemeny_id_p;
    
    if lathato_var = true
    then
		UPDATE velemenyek
        SET velemenyek.lathato = FALSE
        WHERE velemenyek.velemeny_id = velemeny_id_p;
	else
		UPDATE velemenyek
        SET velemenyek.lathato = TRUE
        WHERE velemenyek.velemeny_id = velemeny_id_p;
    end if;
END $$
DELIMITER ;