DROP USER IF EXISTS 'Cliente'@'%';
CREATE USER 'Cliente'@'%' IDENTIFIED BY 'passCliente';

GRANT SELECT ON Gastronomia.Cliente TO 'Cliente'@'%';
GRANT SELECT ON Gastronomia.Menuplato TO 'Cliente'@'%';
GRANT SELECT ON Gastronomia.Plato TO 'Cliente'@'%';
GRANT SELECT (idRestaurant, Email, Domicilio, Nombrer) ON Gastronomia.Restaurant TO 'Cliente'@'%';
GRANT SELECT, UPDATE ON Gastronomia.Pedido TO 'Cliente'@'%';

-- 2)

DROP USER IF EXISTS 'Admin'@'localhost';
CREATE USER 'Admin'@'localhost' IDENTIFIED BY 'passAdmin';

GRANT SELECT ON Gastronomia.* TO 'Admin'@'localhost';
GRANT SELECT, DELETE ON Gastronomia.Plato TO 'Admin'@'localhost';
GRANT SELECT, DELETE ON Gastronomia.Restaurant TO 'Admin'@'localhost';

-- 3)

DROP USER IF EXISTS 'AdminResto'@'localhost';
CREATE USER 'AdminResto'@'localhost' IDENTIFIED BY 'passAdminResto';

GRANT SELECT ON Gastronomia.* TO  'AdminResto'@'localhost';
GRANT SELECT, INSERT ON Gastronomia.Restaurant TO 'AdminResto'@'localhost';
GRANT SELECT, INSERT ON Gastronomia.Plato TO 'AdminResto'@'localhost';
GRANT SELECT, UPDATE (idPlato, Disponible, PrecioUnitario) ON Gastronomia.Plato TO 'AdminResto'@'localhost';