-- Active: 1666715470903@@SG-brawny-mantis-3541-6847-mysql-master.servers.mongodirector.com@3306@gregslist

CREATE TABLE
    IF NOT EXISTS houses(
        id int NOT NULL AUTO_INCREMENT PRIMARY KEY,
        bedrooms int NOT NULL CHECK (bedrooms >= 1),
        bathrooms int NOT NULL CHECK (bathrooms >= 1),
        levels int NOT NULL CHECK (levels >= 1),
        year int NOT NULL CHECK (year >= 1),
        price DECIMAL(10, 2) NOT NULL CHECK (price >= 0),
        description VARCHAR(255),
        imgUrl MEDIUMTEXT,
        classifiedId int NOT NULL UNIQUE
    );


INSERT INTO houses(bedrooms, bathrooms, levels, year, price, description, imgUrl, classifiedId)
VALUES (1996, 3, 2, 6666, 12312312, "Only accessible via helicopter .", "http://vignette1.wikia.nocookie.net/metalgear/images/8/8e/LD2gtmQ.jpg/revision/latest?cb=20141217041819", 3);

SELECT * FROM houses;