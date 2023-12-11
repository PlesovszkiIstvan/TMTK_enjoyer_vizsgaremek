DElIMITER $$
create procedure add_termek_kep_procedure(IN termek_id_p mediumint, IN kep_helye_p varchar(100))
BEGIN
	INSERT INTO termek_kepek (termek_id , kep_helye )
	VALUES (termek_id_p, kep_helye_p);
END $$
DELIMITER ;

DElIMITER $$
create procedure get_termek_kepek_procedure()
BEGIN
	SELECT * FROM termek_kepek;
END $$
DELIMITER ;

DElIMITER $$
create procedure delete_termek_kepek_procedure(IN termek_id_p mediumint)
BEGIN
	DELETE FROM termek_kepek WHERE termek_kep_id = termek_id_p;
END $$
DELIMITER ;