-- Active: 1666715470903@@SG-brawny-mantis-3541-6847-mysql-master.servers.mongodirector.com@3306@gregslist

CREATE TABLE IF NOT EXISTS classifieds (
  id int NOT NULL AUTO_INCREMENT PRIMARY KEY,
  listingType VARCHAR(255) NOT NULL,
  _sellerId VARCHAR(255) NOT NULL,

  FOREIGN KEY (_sellerId) REFERENCES accounts(id) ON DELETE CASCADE
) default charset utf8 COMMENT '';


INSERT INTO classifieds (listingType, _sellerId)
VALUES ("Car", "633f47dbeb516186a541c5e7");

INSERT INTO classifieds (listingType, _sellerId)
VALUES ("Job", "633f47dbeb516186a541c5e7");

INSERT INTO classifieds (listingType, _sellerId)
VALUES ("House", "633f47dbeb516186a541c5e7");

SELECT * FROM classifieds;


 public int Id { get; set; }
  public ListingType type { get; set; }
  public string _sellerId { get; set; }
  public Car car { get; set; }
  public House house { get; set; }
  public Job job { get; set; }