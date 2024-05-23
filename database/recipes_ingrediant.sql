CREATE DATABASE  IF NOT EXISTS `recipes` /*!40100 DEFAULT CHARACTER SET utf8mb3 */ /*!80016 DEFAULT ENCRYPTION='N' */;
USE `recipes`;
-- MySQL dump 10.13  Distrib 8.0.34, for Win64 (x86_64)
--
-- Host: localhost    Database: recipes
-- ------------------------------------------------------
-- Server version	8.0.35

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!50503 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `ingrediant`
--

DROP TABLE IF EXISTS `ingrediant`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `ingrediant` (
  `ingrediant_id` int NOT NULL AUTO_INCREMENT,
  `ingrediant_name` varchar(45) NOT NULL,
  `ingrediant_amount` double NOT NULL,
  `ingrediant_unit` varchar(45) NOT NULL,
  `ingrediant_cost` double DEFAULT NULL,
  `recipe_id` int NOT NULL,
  PRIMARY KEY (`ingrediant_id`),
  KEY `fk_ingrediant_recipe1_idx` (`recipe_id`),
  CONSTRAINT `fk_ingrediant_recipe1` FOREIGN KEY (`recipe_id`) REFERENCES `recipe` (`recipe_id`)
) ENGINE=InnoDB AUTO_INCREMENT=54 DEFAULT CHARSET=utf8mb3;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `ingrediant`
--

LOCK TABLES `ingrediant` WRITE;
/*!40000 ALTER TABLE `ingrediant` DISABLE KEYS */;
INSERT INTO `ingrediant` VALUES (1,'Blueberries',6,'Cups',10,1),(2,'Pie Crust',1,'',2,1),(3,'Lemon Zest',1,'Lemon',1,1),(4,'Lemon Juice',2,'Tbsp',0,1),(5,'Flour',4.5,'Tbsp',0,1),(6,'Ground Cinnamon',1,'Teaspoon',0,1),(7,'Egg',1,'',0.1,1),(8,'Salted Butter',1,'Cup',2,3),(9,'Granulated Sugar',1,'Cup',0.25,3),(10,'Light Brown Sugar',1,'Cup',0.25,3),(11,'Vanilla Extract',2,'Tsp',0.25,3),(12,'Eggs',2,'',0.66,3),(13,'Flour',3,'Cups',0.25,3),(14,'Baking Soda',1,'Tsp',0.1,3),(15,'Baking Powder',0.5,'Tsp',0.05,3),(16,'Sea Salt',1,'Tsp',0.03,3),(17,'Chocolate Chips',2,'Cups',3,3),(18,'Flour',2,'Cups',0.25,4),(19,'Baking Powder',2.5,'Tsp',0.01,4),(20,'Cooking Salt',0.25,'Tsp',0,4),(21,'Eggs',4,'',1.25,4),(22,'Superfine Sugar',1.5,'Cups',0.4,4),(23,'Unsalted Butter',0.5,'Cups',1,4),(24,'Milk',1,'Cup',0.5,4),(25,'Vanilla Extract',3,'Tsp',2.4,4),(26,'Vegetable Oil',3,'Tsp',0.1,4),(27,'Unsalted Butter',2,'Sticks',2,4),(28,'Powdered Sugar',1,'lb',2,4),(29,'Vanilla Extract',3,'Tsp',2.4,4),(30,'Milk',3,'Tbsp',0.2,4),(31,'Uncooked Elbow Noodles',16,'Ounces',3,5),(32,'Chicken Broth',4,'Cups',2,5),(33,'Butter',2,'Tbsp',0.15,5),(34,'Hot Pepper Sauce',1,'Tsp',0,5),(35,'Garlic Powder',1,'Tsp',0,5),(36,'Black Pepper',0.5,'Tsp',0,5),(37,'Salt',0.5,'Tsp',0,5),(38,'Cheddar Cheese',2,'Cups',1.5,5),(39,'Mozzarella Cheese',1,'Cup',2,5),(40,'Parmesan Cheese',0.5,'Cups',1.5,5),(41,'Milk',0.75,'Cups',0.5,5),(44,'Flour',2,'Cups',0.6,15),(45,'Instant Yeast',1,'Packet',0.32,15),(46,'Sugar',1.5,'Tsp',0,15),(47,'Salt',0.75,'Tsp',0,15),(48,'Garlic Power',0.25,'Tsp',0,15),(49,'Dried Basil Leaves',0.25,'Tsp',0,15),(50,'Olive Oil',2,'Tbsp',0.2,15),(51,'Warm Water',0.75,'Cups',0,15),(53,'pickels',4,'',0.2,17);
/*!40000 ALTER TABLE `ingrediant` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2024-05-23 12:09:50
