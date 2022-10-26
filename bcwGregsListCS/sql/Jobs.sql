-- Active: 1666715470903@@SG-brawny-mantis-3541-6847-mysql-master.servers.mongodirector.com@3306@gregslist

CREATE TABLE
    IF NOT EXISTS jobs(
        id int NOT NULL AUTO_INCREMENT PRIMARY KEY,
        jobTitle VARCHAR(255) NOT NULL,
        company VARCHAR(255) NOT NULL,
        hours int NOT NULL CHECK (hours >= 1),
        rate DECIMAL(10, 2) NOT NULL CHECK (rate >= 0),
        description VARCHAR(255),
        classifiedId int NOT NULL UNIQUE
    );


INSERT INTO jobs(jobTitle, company, hours, rate, description, classifiedId)
VALUES ("Wine Taster", "St Chappelle", 42, 100, "Drink wine and get paid $$ please neeeeeee", 2);

SELECT * FROM jobs;