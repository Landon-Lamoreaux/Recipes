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
-- Table structure for table `recipe_steps`
--

DROP TABLE IF EXISTS `recipe_steps`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `recipe_steps` (
  `recipe_steps_id` int NOT NULL AUTO_INCREMENT,
  `recipe_step_num` int NOT NULL,
  `recipe_steps` varchar(2048) NOT NULL,
  `recipe_id` int NOT NULL,
  `recipe_step_name` varchar(100) NOT NULL,
  PRIMARY KEY (`recipe_steps_id`),
  KEY `fk_recipe_steps_recipe1_idx` (`recipe_id`),
  CONSTRAINT `fk_recipe_steps_recipe1` FOREIGN KEY (`recipe_id`) REFERENCES `recipe` (`recipe_id`)
) ENGINE=InnoDB AUTO_INCREMENT=54 DEFAULT CHARSET=utf8mb3;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `recipe_steps`
--

LOCK TABLES `recipe_steps` WRITE;
/*!40000 ALTER TABLE `recipe_steps` DISABLE KEYS */;
INSERT INTO `recipe_steps` VALUES (1,1,'Pre-make your pie crust and let it refrigerate for 1 hour in the refrigerator before using. Roll the first disk into a 13 inch circle and transfer it to a 9 inch wide, deep pie pan',1,'Step 1'),(2,2,'Roll the second crust into a 12 inch circle and use a pizza cutter to slice into ten 1-inch strips.',1,'Step 2'),(3,3,'In a large mixing bowl, combine 6 cups blueberries, 1 tsp lemon zest, 2 Tbsp lemon juice, 1/2 cup granulated sugar, 4 1/2 Tbsp flour, 1 tsp cinnamon and toss to combine. Transfer blueberries into the dough-lined pie pan, mounding it just slightly in the center and keeping the edges clean of blueberry juice.',1,'Step 3'),(4,4,'Using the 10 strips of dough, create a lattice crust over the top: Place 5 strips of dough evenly over the pie, with the longer strips in the center. Fold back every other strip halfway and place a long strip in the center perpendicular to the first 5 strips. Fold the strips back over the new line and fold back the alternate strips. Continue adding and alternating strips, then switch to the other side of the pie and continue until the woven lattice is finished. Pinch the edges to seal then crimp for a fluted pattern.',1,'Step 4'),(5,5,'Beat together 1 egg and 1 Tbsp water and brush the egg wash over the lattice crust and edges. Bake in the center of the oven at 375˚F for 50-60 minutes, or until the crust is golden and blueberry juice is bubbling at the edges.',1,'Step 5'),(6,1,'Preheat oven to 375 degrees F. Line three baking sheets with parchment paper and set aside.',3,'Step 1'),(7,2,'In a medium bowl mix flour, baking soda, baking powder and salt. Set aside.',3,'Step 2'),(8,3,'Cream together butter and sugars until combined.',3,'Step 3'),(9,4,'Beat in eggs and vanilla until light (about 1 minute).',3,'Step 4'),(10,5,'Mix in the dry ingredients until combined.',3,'Step 5'),(11,6,'Add chocolate chips and mix well.',3,'Step 6'),(12,7,'Roll 2-3 Tablespoons (depending on how large you like your cookies) of dough at a time into balls and place them evenly spaced on your prepared cookie sheets.',3,'Step 7'),(13,8,'Bake in preheated oven for approximately 8-10 minutes. Take them out when they are just barely starting to turn brown.',3,'Step 8'),(14,9,'Let them sit on the baking pan for 2 minutes before removing to cooling rack.',3,'Step 9'),(15,1,'Preheat oven to 180°C/350°F (160°C fan) for 20 minutes before starting the batter (Note 8). Place shelf in the middle of the oven.',4,'Step 1'),(16,2,'Grease 2 x 20cm / 8” cake pans with butter, then line with parchment / baking paper. (Note 9 more pan sizes) Best to use cake pan without loose base, if you can.',4,'Step 2'),(17,3,'Whisk flour, baking powder and salt in a large bowl. Set aside.',4,'Step 3'),(18,4,'30 sec beat: Beat eggs for 30 seconds on speed 6 of a Stand Mixer fitted with a whisk attachment, or hand beater.',4,'Step 4'),(19,5,'Slowly add sugar: With the beater still going, pour the sugar in over 45 seconds.',4,'Step 5'),(20,6,'Triple volume: Then beat for 7 minutes on speed 8, or until tripled in volume and white.',4,'Step 6'),(21,7,'Heat Milk-Butter (Note 5): While egg is beating, place butter and milk in a heatproof jug and microwave 2 minutes on high to melt butter (or use stove).',4,'Step 7'),(22,8,'Gently add flour: When the egg is whipped, scatter 1/3 flour across surface, then beat on Speed 1 for 5 seconds. Add half remaining flour, then mix on Speed 1 for 5 sec. Add remaining flour, then mix on Speed 1 for 5 – 10 sec until the flour is just mixed in. Once you can’t see flour, stop straight away.',4,'Step 8'),(23,9,'Combine milk, vanilla & oil – Pour hot milk, vanilla and oil into the now empty flour bowl.',4,'Step 9'),(24,10,'Lighten with some Egg Batter: Add about 1 1/2 cups (2 ladles or so) of the Egg Batter into the Milk-Butter (don\'t need to be 100% accurate with amount). Use a whisk to mix until smooth – you can be vigorous here. Will look foamy.',4,'Step 10'),(25,11,'Slowly add milk: Turn beater back on Speed 1 then pour the Milk mixture into the Egg Batter over 15 seconds, then turn beater off.',4,'Step 11'),(26,12,'Scrape and final mix: Scrape down sides and base of bowl. Beat on Speed 1 for 10 seconds – batter should now be smooth and pourable.',4,'Step 12'),(27,13,'Pour batter into pans.',4,'Step 13'),(28,14,'Knock out bubbles: Bang each cake pan on the counter 3 times to knock out big bubbles (Note 10 for why)',4,'Step 14'),(29,15,'Bake 30 minutes or until golden and toothpick inserted into centre comes out clean.',4,'Step 15'),(30,16,'Turn out & cool: Remove from oven. Cool in cake pans for 15 minutes, then gently turn out onto cooling racks. If using as layer cakes, cool upside down – slight dome will flatten perfectly. Level cake = neat layers.',4,'Step 16'),(31,17,'Frost: Once cake layers are fully cool, top with frosting of choice, or cream and fresh berries or jam. See list of ideas in post!',4,'Step 17'),(32,18,'Beat butter with paddle attachment in stand mixer for 3 minutes on high until it changes from yellow to almost white, and it becomes fluffy and creamy.',4,'Step 18'),(33,19,'Add icing sugar / powdered sugar gradually in 3 lots, beating slowly (to avoid a powder storm) then once mostly incorporated, beat on high for a full 3 minutes until fluffy.',4,'Step 19'),(34,20,'Add vanilla and milk, then beat for a further 30 seconds. Use milk only if needed to make it lovely and soft but still holds it\'s form (eg for piping). Use immediately. (If you make ahead, refrigerate then beat to re-fluff).',4,'Step 20'),(35,1,'Add the uncooked macaroni, chicken broth, butter, hot sauce, garlic powder, pepper, and salt to the Instant Pot. ',5,'Step 1'),(36,1,'Add the uncooked macaroni, chicken broth, butter, hot sauce, garlic powder, pepper, and salt to the Instant Pot. ',5,'Step 1'),(37,2,'Place the lid on the pot and set to sealing.  Cook on manual function, high pressure for 5 minutes. Then, do a quick release.',5,'Step 2'),(38,3,'Add the milk, then the cheese to the pot in 3-4 handfuls, stirring in between each addition until smooth and creamy. Season as necessary to taste.',5,'Step 3'),(41,1,'Combine 1 cup (125g) of flour, instant yeast, sugar, and salt in a large bowl. If desired, add garlic powder and dried basil at this point as well.',15,'Step 1'),(42,2,'Add olive oil and warm water and use a wooden spoon to stir well very well.',15,'Step 2'),(43,3,'Gradually add another 1 cup (125g) of flour. Add any additional flour as needed (I\'ve found that sometimes I need as much as an additional ⅓ cup), stirring until the dough is forming into a cohesive, elastic ball and is beginning to pull away from the sides of the bowl (see video above recipe for visual cue). The dough will still be slightly sticky but still should be manageable with your hands.',15,'Step 3'),(44,4,'Drizzle a separate, large, clean bowl generously with olive oil and use a pastry brush to brush up the sides of the bowl.',15,'Step 4'),(45,5,'Lightly dust your hands with flour and form your pizza dough into a round ball and transfer to your olive oil-brushed bowl. Use your hands to roll the pizza dough along the inside of the bowl until it is coated in olive oil, then cover the bowl tightly with plastic wrap and place it in a warm place.',15,'Step 5'),(46,6,'Allow dough to rise for 30 minutes or until doubled in size. If you intend to bake this dough into a pizza, I also recommend preheating your oven to 425F (215C) at this point so that it will have reached temperature once your pizza is ready to bake.',15,'Step 6'),(47,7,'Once the dough has risen, use your hands to gently deflate it and transfer to a lightly floured surface and knead briefly until smooth (about 3-5 times). ',15,'Step 7'),(48,8,'Use either your hands or a rolling pin to work the dough into 12\" circle.',15,'Step 8'),(49,9,'Transfer dough to a parchment paper lined pizza pan and either pinch the edges or fold them over to form a crust.',15,'Step 9'),(50,10,'Drizzle additional olive oil (about a Tablespoon) over the top of the pizza and use your pastry brush to brush the entire surface of the pizza (including the crust) with olive oil. ',15,'Step 10'),(51,11,'Use a fork to poke holes all over the center of the pizza to keep the dough from bubbling up in the oven.',15,'Step 11'),(52,12,'Add desired toppings (see the notes for a link to my favorite, 5-minute pizza sauce recipe!) and bake in a 425F (215C) preheated oven for 13-15 minutes or until toppings are golden brown. Slice and serve.',15,'Step 12');
/*!40000 ALTER TABLE `recipe_steps` ENABLE KEYS */;
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
