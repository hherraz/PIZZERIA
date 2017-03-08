CREATE DEFINER=`pizzeria`@`%` PROCEDURE `LogUsuario`()
BEGIN
	DECLARE V_user varchar(30);
    SET V_user=user;

	INSERT INTO logUsuario (user) VALUES (V_user);

END