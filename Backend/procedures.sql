USE isabike;

DELIMITER $$
CREATE PROCEDURE Velemenyek_add_procedure(IN Token_p mediumint, IN ertekeles_id_p tinyint, IN velemeny varchar(500))
   BEGIN
      DECLARE felhasznalo_id_var mediumint;
      SELECT felhasznalo_id_var = felhasznalo_id FROM Tokenek WHERE Tokenek.token = Token_p;
      
      INSERT INTO velemenyek (felhasznalo_id, ertekeles_id, velemeny, lathato)
      VALUES (felhasznalo_id_var, ertekeles_id_p, velemeny, true);
      
   END $$
DELIMITER ;


CALL Velemenyek_add_procedure('EZEGYTOKEN123',1,'Jó volt ez a bolt');

































