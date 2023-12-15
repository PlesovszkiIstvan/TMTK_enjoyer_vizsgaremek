DElIMITER $$
create procedure add_kosarazot_termek_procedure(IN Token_p varchar(100), IN termekek_id_p mediumint, IN darabszam tinyint)
BEGIN
	  DECLARE felhasznalo_id_var mediumint;
      
      SELECT Tokenek.felhasznalo_id
      INTO felhasznalo_id_var
      FROM Tokenek
      WHERE Tokenek.token = Token_p;
      
      INSERT INTO Kosarazot_termekek (felhasznalo_id, termekek_id, darabszam)
      VALUES(felhasznalo_id_var, termekek_id_p, darabszam_p);
END $$
DELIMITER ;

DElIMITER $$
create procedure update_kosarazot_termeke_darabszam_procedure(IN Token_p mediumint, IN termekek_id_p mediumint, IN darabszam_p tinyint)
BEGIN
	DECLARE felhasznalo_id_var mediumint;
    
	SELECT Tokenek.felhasznalo_id
	INTO felhasznalo_id_var
	FROM Tokenek
	WHERE Tokenek.token = Token_p;
    
    UPDATE Kosarazot_termekek
	SET darabszam  = darabszam_p
	WHERE felhasznalo_id  = felhasznalo_id_var and termekek_id = termekek_id_p;
    
END $$
DELIMITER ;

DElIMITER $$
create procedure get_all_kosarazot_termekek_procedure()
BEGIN
		SELECT * FROM Kosarazot_termekek;
END $$
DELIMITER ;

DElIMITER $$
create procedure get_one_user_kosarazot_termekek_procedure(IN Token_p mediumint)
BEGIN
	DECLARE felhasznalo_id_var mediumint;
    
	SELECT Tokenek.felhasznalo_id
	INTO felhasznalo_id_var
	FROM Tokenek
	WHERE Tokenek.token = Token_p;
    
    SELECT termekek_id, darabszam, kosarazas_ideje FROM Kosarazot_termekek WHERE felhasznalo_id = felhasznalo_id_var;
END $$
DELIMITER ;




