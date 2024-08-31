-- MySQL dump 10.13  Distrib 8.0.12, for Win64 (x86_64)
--
-- Host: 127.0.0.1    Database: performencedb
-- ------------------------------------------------------
-- Server version	8.1.0

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
 SET NAMES utf8 ;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `admins`
--

DROP TABLE IF EXISTS `admins`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `admins` (
  `id` int NOT NULL AUTO_INCREMENT,
  `emp.name` varchar(45) DEFAULT NULL,
  `email` text,
  `username` text NOT NULL,
  `password` text NOT NULL,
  `contact1` int NOT NULL,
  `desig_id` int DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `designation_idx` (`desig_id`),
  CONSTRAINT `designation` FOREIGN KEY (`desig_id`) REFERENCES `designation` (`desig_id`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `admins`
--

LOCK TABLES `admins` WRITE;
/*!40000 ALTER TABLE `admins` DISABLE KEYS */;
INSERT INTO `admins` VALUES (2,'admin','test@gmail.com','admin','admin',1234567890,8),(3,'K.N.Frenando','test@gmail.com','sup01','sup01',1234567890,33),(4,'T.Silva','test@gmail.com','sup02','sup02',1234567890,33);
/*!40000 ALTER TABLE `admins` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `department`
--

DROP TABLE IF EXISTS `department`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `department` (
  `department_id` int NOT NULL,
  `department` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL,
  PRIMARY KEY (`department_id`) USING BTREE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci ROW_FORMAT=DYNAMIC;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `department`
--

LOCK TABLES `department` WRITE;
/*!40000 ALTER TABLE `department` DISABLE KEYS */;
INSERT INTO `department` VALUES (23,'HR Department'),(24,'Production Department ');
/*!40000 ALTER TABLE `department` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `designation`
--

DROP TABLE IF EXISTS `designation`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `designation` (
  `desig_id` int NOT NULL AUTO_INCREMENT,
  `designation` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci DEFAULT NULL,
  `department_id` int DEFAULT NULL,
  PRIMARY KEY (`desig_id`) USING BTREE,
  KEY `department_id_idx` (`department_id`),
  CONSTRAINT `department_id` FOREIGN KEY (`department_id`) REFERENCES `department` (`department_id`)
) ENGINE=InnoDB AUTO_INCREMENT=37 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci ROW_FORMAT=DYNAMIC;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `designation`
--

LOCK TABLES `designation` WRITE;
/*!40000 ALTER TABLE `designation` DISABLE KEYS */;
INSERT INTO `designation` VALUES (8,'Data Operator',23),(33,'supervisor ',24),(34,'Machine Operator',24);
/*!40000 ALTER TABLE `designation` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `efficiency`
--

DROP TABLE IF EXISTS `efficiency`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `efficiency` (
  `efficiency_id` int NOT NULL AUTO_INCREMENT,
  `emp_no` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci DEFAULT NULL,
  `no_target` varchar(45) DEFAULT NULL,
  `no_taget_achieve` varchar(45) DEFAULT NULL,
  `efficiency` varchar(45) DEFAULT NULL,
  `month` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci DEFAULT NULL,
  `mark` int DEFAULT NULL,
  `year` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`efficiency_id`)
) ENGINE=InnoDB AUTO_INCREMENT=22 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `efficiency`
--

LOCK TABLES `efficiency` WRITE;
/*!40000 ALTER TABLE `efficiency` DISABLE KEYS */;
INSERT INTO `efficiency` VALUES (1,'0120','500','455','98.52%','October',NULL,'2023'),(2,'0121','500','460','92.52%','October',NULL,'2023'),(3,'0122','400','355','68.52%','October',NULL,'2023'),(4,'0123','300','250','54.52%','October',NULL,'2023'),(5,'0124','500','460','68.52%','October',NULL,'2023'),(10,'103','203','200','88.52%','January',NULL,'2023'),(11,'1030','40','36','40.00%','January',NULL,'2023'),(12,'103','200','160','80.00%','March',5,'2023'),(13,'100','200','170','35.00%','October',2,'2023'),(14,'103','100','176','176.00%','March',5,'2023'),(15,'201','300','176','49.67%','March',3,'2023'),(16,'12','200','178','79.00%','February',4,'2023'),(17,'222','222','222','50.00%','April',2,'2023'),(18,'222','222','222','30.00%','December',2,'2023'),(19,'111','100','100','10.00%','October',1,'2023'),(20,'0189','500','400','80.00%','November',5,'2023'),(21,'0125','100','45','45.00%','November',3,'2023');
/*!40000 ALTER TABLE `efficiency` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `emp_per_evaluation`
--

DROP TABLE IF EXISTS `emp_per_evaluation`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `emp_per_evaluation` (
  `id` int NOT NULL AUTO_INCREMENT,
  `emp_no` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci DEFAULT NULL,
  `communication` varchar(45) DEFAULT NULL,
  `written_communication` varchar(45) DEFAULT NULL,
  `listening` varchar(45) DEFAULT NULL,
  `ethical_conduct` varchar(45) DEFAULT NULL,
  `comfort_reporting` varchar(45) DEFAULT NULL,
  `alignment_ethical_values` varchar(45) DEFAULT NULL,
  `work_motivation` varchar(45) DEFAULT NULL,
  `growth_opportunities` varchar(45) DEFAULT NULL,
  `daily_enthusiasm` varchar(45) DEFAULT NULL,
  `month` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=14 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `emp_per_evaluation`
--

LOCK TABLES `emp_per_evaluation` WRITE;
/*!40000 ALTER TABLE `emp_per_evaluation` DISABLE KEYS */;
INSERT INTO `emp_per_evaluation` VALUES (10,'0189','5','5','5','5','3','3','2','4','6','November'),(13,'0125','1','2','3','4','4','5','1','3','5','November');
/*!40000 ALTER TABLE `emp_per_evaluation` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `emp_recode`
--

DROP TABLE IF EXISTS `emp_recode`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `emp_recode` (
  `id` int NOT NULL AUTO_INCREMENT,
  `emp_no` varchar(45) DEFAULT NULL,
  `month` varchar(45) DEFAULT NULL,
  `no_target` varchar(45) DEFAULT NULL,
  `no_tagrget_achive` varchar(45) DEFAULT NULL,
  `defects` varchar(45) DEFAULT NULL,
  `quality` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=11 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `emp_recode`
--

LOCK TABLES `emp_recode` WRITE;
/*!40000 ALTER TABLE `emp_recode` DISABLE KEYS */;
INSERT INTO `emp_recode` VALUES (1,'0120',NULL,'500','455','450','5'),(2,'0121',NULL,'500','460','450','10'),(3,'0122',NULL,'400','355','350','5'),(4,'0123',NULL,'300','250','245','5'),(5,'0124',NULL,'500','460','450','10'),(6,'0125',NULL,'550','500','455','45');
/*!40000 ALTER TABLE `emp_recode` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `employee`
--

DROP TABLE IF EXISTS `employee`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `employee` (
  `employee_id` int NOT NULL AUTO_INCREMENT,
  `emp_no` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci DEFAULT NULL,
  `full_name` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci DEFAULT NULL,
  `dob` date NOT NULL,
  `gender` varchar(10) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL,
  `address` text CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL,
  `contact_1` varchar(15) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci DEFAULT NULL,
  `status` varchar(15) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
  `designation_id` int DEFAULT NULL,
  `enrollment_date` date DEFAULT NULL,
  `education_qualification` varchar(450) COLLATE utf8mb4_general_ci DEFAULT NULL,
  `other_qualification` varchar(450) COLLATE utf8mb4_general_ci DEFAULT NULL,
  `supervisor` int DEFAULT NULL,
  `department_name` varchar(45) COLLATE utf8mb4_general_ci DEFAULT NULL,
  `add_sup_date` varchar(45) COLLATE utf8mb4_general_ci DEFAULT NULL,
  PRIMARY KEY (`employee_id`) USING BTREE
) ENGINE=InnoDB AUTO_INCREMENT=119 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci ROW_FORMAT=DYNAMIC;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `employee`
--

LOCK TABLES `employee` WRITE;
/*!40000 ALTER TABLE `employee` DISABLE KEYS */;
INSERT INTO `employee` VALUES (31,'0000','P.Silva','1990-09-16','Male','No.6,Minuwangoda','0711234567','permanant',8,'2010-09-01',NULL,NULL,NULL,'Cutting Section',NULL),(33,'0189','T.Silva','1985-09-06','Female','No.12,Veyangoda','0711234567','permanant',34,'2005-05-01',NULL,NULL,206,'Cutting Section',NULL),(34,'0129','J.Perea','1983-07-09','Female','No.4,Katunayaka','0711234567','permanant',33,'2003-02-20',NULL,NULL,206,'Cutting Section',NULL),(35,'0206','K.N.Frenando','1980-07-11','male','No.5,Katunayaka','0711234567','permanant',33,'2003-09-24',NULL,NULL,NULL,'Cutting Section',NULL),(36,'0213','H.Perera','1984-04-08','Female','No.1,Veyangoda','0711234567','permanant',33,'2008-03-01',NULL,NULL,206,'Cutting Section',NULL),(37,'0214','L.Silva','1983-04-28','Female','No.3,Minuwangoda','0711234567','permanant',33,'2007-04-16',NULL,NULL,NULL,'Cutting Section',NULL),(38,'0120','U.Perera','1995-07-02','Female','No.5,Minuwangaoda','0711234567','Permanant',34,'2015-05-02','A/L','test',206,'Cutting Section',NULL),(40,'0121','R.Silva','1995-07-02','Female','No.6,Veyangoda','0786991796','Permanant',8,'2015-10-05','A/L','test',NULL,'Cutting Section',NULL),(41,'0122','K.O.Perera','2003-01-25','Female','No.19,Minuwangoda','0711234567','Tranner',34,'2023-08-26',NULL,NULL,189,'Cutting Section',NULL),(47,'0123','L.T.Frenando','1995-02-13','Female','No.20,Veyangoda','0711234567','Permanant',34,'2016-03-01','A/L','test',189,'Finishing Section',NULL),(48,'0124','E.P.Perera','1994-07-08','Female','No.21,Katunayaka','0711234567','permanant',34,'2016-03-10',NULL,NULL,129,'Sewing Section',NULL),(49,'0125','G.Frenando','1994-11-18','Female','No.30,Veyangoda','0711234567','permanant',34,'2016-05-02',NULL,NULL,129,'Sewing Section','26-Nov-23 12:00:00 AM'),(110,'0135','name','2022-01-01','Female','test','1234567890','Permanant',34,'2022-01-01','A/L','no',NULL,'Sewing Section',NULL),(111,'0100','test','2022-01-01','Male','test','1456789','permanant',34,'2022-01-01','test','test',NULL,'Sewing Section',NULL),(112,'2345','esham','2022-01-01','Male','test','07856656565','permanant',34,'2023-03-01','test','test',189,'Sewing Section',NULL),(113,'8765','eshan','2022-01-01','Male','terst','1234511111','Permanant',34,'2023-09-01','terst','test',189,'Finishing Section',NULL),(114,'9847','testnew','2022-01-01','Male','ttttt','2333333333','Permanant',34,'2022-01-01','ttttt','tttttt',NULL,'Cutting Section',NULL),(115,'3214','dilmi','2022-01-01','Male','ff','44444','permanant',33,'2022-01-01','ffff','ot',NULL,'Cutting Section',NULL),(116,'116','test','2022-01-01','Male','test2','1234567898','Permanant',34,'2022-01-26','O/L','eeeeee',NULL,'Finishing Section',NULL),(117,'117','test','1999-01-01','Male','test tes1 System.Windows.Forms.TextBox, Text: test2  System.Windows.Forms.TextBox, Text:   System.Windows.Forms.TextBox, Text: ','1234567891','Permanant',34,'2022-01-01','O/L','test',NULL,'Finishing Section',NULL),(118,'118','ttttttt','1999-01-06','Male','test  System.Windows.Forms.TextBox, Text: ','1111111111','Permanant',34,'2022-01-01','O/L','test',NULL,'Cutting Section',NULL);
/*!40000 ALTER TABLE `employee` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `evaluvator_recode`
--

DROP TABLE IF EXISTS `evaluvator_recode`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `evaluvator_recode` (
  `id` int NOT NULL AUTO_INCREMENT,
  `emp_no` varchar(45) DEFAULT NULL,
  `communication` varchar(45) DEFAULT NULL,
  `ethics` varchar(45) DEFAULT NULL,
  `operation_efficiency` varchar(45) DEFAULT NULL,
  `leadrship` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `evaluvator_recode`
--

LOCK TABLES `evaluvator_recode` WRITE;
/*!40000 ALTER TABLE `evaluvator_recode` DISABLE KEYS */;
INSERT INTO `evaluvator_recode` VALUES (1,'0120','2','3','4','4'),(2,'0121','3','3','3','3'),(3,'0122','4','4','5','5'),(4,'0123','5','5','5','5'),(5,'0124','2','2','2','2'),(6,'0125','4','3','4','3');
/*!40000 ALTER TABLE `evaluvator_recode` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `output_quality`
--

DROP TABLE IF EXISTS `output_quality`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `output_quality` (
  `output_quality_id` int NOT NULL AUTO_INCREMENT,
  `Emp_no` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci DEFAULT NULL,
  `no_target` varchar(45) DEFAULT NULL,
  `no_target_achieve` varchar(45) DEFAULT NULL,
  `defect_products` varchar(45) DEFAULT NULL,
  `quality` varchar(45) DEFAULT NULL,
  `productivity` varchar(45) DEFAULT NULL,
  `month` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci DEFAULT NULL,
  `mark` int DEFAULT NULL,
  `year` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`output_quality_id`)
) ENGINE=InnoDB AUTO_INCREMENT=15 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `output_quality`
--

LOCK TABLES `output_quality` WRITE;
/*!40000 ALTER TABLE `output_quality` DISABLE KEYS */;
INSERT INTO `output_quality` VALUES (1,'0120','500','455','29','450','50','October',3,'2023'),(2,'0121','500','460','30','450','50','October',3,'2023'),(3,'0122','400','355','20','350','50','October',3,'2023'),(4,'0123','300','250','29','245','50','October',3,'2023'),(5,'0124','500','460','40','450','50','October',3,'2023'),(6,'0125','550','500','40','455','50','October',3,'2023'),(7,'100','100','100','30','100.00%','50','September',3,'2023'),(8,'1256','1000','900','20','880','50','October',3,'2023'),(10,'0189','100','80','20','60','50','November',3,'2023'),(13,'0125','100','54','4','60','50','November',3,'2023'),(14,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,'');
/*!40000 ALTER TABLE `output_quality` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `productivity`
--

DROP TABLE IF EXISTS `productivity`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `productivity` (
  `emp_no` int NOT NULL AUTO_INCREMENT,
  `working_days` varchar(45) DEFAULT NULL,
  `absentisnt` varchar(45) DEFAULT NULL,
  `attendance` varchar(45) DEFAULT NULL,
  `productivity` varchar(45) DEFAULT NULL,
  `month` varchar(45) DEFAULT NULL,
  `mark` int DEFAULT NULL,
  `year` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`emp_no`)
) ENGINE=InnoDB AUTO_INCREMENT=126 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `productivity`
--

LOCK TABLES `productivity` WRITE;
/*!40000 ALTER TABLE `productivity` DISABLE KEYS */;
INSERT INTO `productivity` VALUES (120,'25','2','23',NULL,'October',NULL,NULL),(121,'25','1','24',NULL,'October',NULL,NULL),(122,'25','3','22',NULL,'October',NULL,NULL),(123,'25','0','25',NULL,'October',NULL,NULL),(124,'25','5','20',NULL,'October',NULL,NULL),(125,'25','1','24',NULL,'October',NULL,NULL);
/*!40000 ALTER TABLE `productivity` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2023-11-28 12:10:31
