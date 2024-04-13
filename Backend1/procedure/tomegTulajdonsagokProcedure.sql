DElIMITER $$
create procedure add_tomeg_tulajdonsagai_procedure(IN mertek_egysege_p varchar(20))
BEGIN
	INSERT INTO Tomeg_tulajdonsagai (mertek_egysege)
	VALUES (mertek_egysege_p);
END $$
DELIMITER ;

DElIMITER $$
create procedure get_tomeg_tulajdonsagai_procedure()
BEGIN
	SELECT * FROM Tomeg_tulajdonsagai;
END $$
DELIMITER ;

DElIMITER $$
create procedure update_tomeg_tulajdonsagai_procedure(IN tomeg_tulajdonsaga_id_p tinyint, IN mertek_egysege_p varchar(20))
BEGIN
	UPDATE Tomeg_tulajdonsagai
	SET mertek_egysege = mertek_egysege_p
	WHERE tomeg_tulajdonsaga_id = tomeg_tulajdonsaga_id_p;
END $$
DELIMITER ;