USE ISABIKE;   

CREATE USER 'browserUser'@'%' IDENTIFIED BY 'browseradmin';
create USER 'desktopUser'@'%' IDENTIFIED BY 'desktopadmin';
GRANT EXECUTE ON isabike.* TO desktopUser@'%';
GRANT EXECUTE ON isabike.* TO browserUser@'%';
 FLUSH PRIVILEGES; 