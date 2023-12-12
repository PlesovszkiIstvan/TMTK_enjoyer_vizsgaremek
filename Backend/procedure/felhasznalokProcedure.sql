DElIMITER $$
create procedure check_if_felhasznalo_exist_procedure(IN felhasznalo_nev_p varchar(20), IN email_p varchar(40))
BEGIN
	  DECLARE count_value int;
      
      SELECT COUNT(felhasznalo_id)
      INTO felhasznalo_id_var
      FROM Felhasznalok
      WHERE felhasznalo_nev = felhasznalo_nev_p or email =  email_p;
      
	  if count_value > 0
	  then
		select "true";
	  else
		SELECT "FALSE";
      end if; 
END $$
DELIMITER ;



DElIMITER $$
create procedure add_felhasznalok_procedure(
IN felhasznalo_nev_p varchar(20),
IN vezetek_nev_p varchar(30),
IN kereszt_nev_p varchar(30),
IN email_p varchar(40),
IN jelszo_p tinytext
)
BEGIN
	INSERT INTO Felhasznalok (felhasznalo_nev, vezetek_nev, kereszt_nev, email, jelszo)
	VALUES (felhasznalo_nev_p, vezetek_nev_p, kereszt_nev_p, email_p, jelszo_p);
END $$
DELIMITER ;
