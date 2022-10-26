-- Active: 1666715470903@@SG-brawny-mantis-3541-6847-mysql-master.servers.mongodirector.com@3306@gregslist

CREATE TABLE
    IF NOT EXISTS cars(
        id int NOT NULL AUTO_INCREMENT PRIMARY KEY,
        make VARCHAR(255) NOT NULL,
        model VARCHAR(255) NOT NULL,
        year int NOT NULL CHECK (year >= 1886),
        price DECIMAL(10, 2) NOT NULL CHECK (price >= 0),
        description VARCHAR(255),
        imgUrl MEDIUMTEXT,
        classifiedId int NOT NULL UNIQUE
    );


INSERT INTO cars(make, model, year, price, description, imgUrl, classifiedId)
VALUES ("KFC", "Bucket Tré", 1985, 999, "Yum Yum!!", "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRJcEQw9jHNAmFu-VTA7bhvZhMugoz0q_r0oeTUswAO&s", 1);

SELECT * FROM cars;