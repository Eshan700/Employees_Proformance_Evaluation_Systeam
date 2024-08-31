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
  `first_name` varchar(45) DEFAULT NULL,
  `last_name` varchar(45) DEFAULT NULL,
  `email` text,
  `username` text NOT NULL,
  `password` text NOT NULL,
  `contact1` int NOT NULL,
  `address` text,
  `gender` varchar(45) DEFAULT NULL,
  `dob` date DEFAULT NULL,
  `nic` varchar(45) DEFAULT NULL,
  `desig_id` int DEFAULT NULL,
  `test_attendance` int DEFAULT NULL,
  `test_leave` int DEFAULT NULL,
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
INSERT INTO `admins` VALUES (1,'line',' Leder','test@gmail.com','line1','line1',1234567890,'test','mail','1996-11-02','1234567890',36,NULL,NULL),(2,'admin','admin','test@gmail.com','admin','admin',1234567890,'test','mail','1996-11-02','1234567890',8,NULL,NULL),(3,'supervisor','sup01','test@gmail.com','sup01','sup01',1234567890,'test','mail','1996-11-02','1234567890',33,NULL,NULL),(4,'desition','maker','test@gmail.com','test1','test1',1234567890,'test','mail','1996-11-02','1234567890',4,NULL,NULL);
/*!40000 ALTER TABLE `admins` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `attendance`
--

DROP TABLE IF EXISTS `attendance`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `attendance` (
  `attendance_id` int NOT NULL AUTO_INCREMENT,
  `emp_no` varchar(10) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
  `in_time` varchar(30) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci DEFAULT NULL,
  `out_time` varchar(30) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci DEFAULT NULL,
  `date` varchar(30) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci DEFAULT NULL,
  PRIMARY KEY (`attendance_id`) USING BTREE
) ENGINE=InnoDB AUTO_INCREMENT=6732 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci ROW_FORMAT=DYNAMIC;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `attendance`
--

LOCK TABLES `attendance` WRITE;
/*!40000 ALTER TABLE `attendance` DISABLE KEYS */;
INSERT INTO `attendance` VALUES (1,'0120','04:42:35','18:04:45','2023-01-01'),(2,'0120','04:42:35','18:04:45','2023-01-02'),(3,'0120','04:42:35','18:04:45','2023-01-03'),(4,'0120','04:42:35','18:04:45','2023-01-04'),(5,'0120','04:42:35','18:04:45','2023-01-05'),(6,'0120','04:42:35','18:04:45','2023-01-06'),(7,'0120','04:42:35','18:04:45','2023-01-07'),(8,'0120','04:42:35','18:04:45','2023-01-08'),(9,'0120','04:42:35','18:04:45','2023-01-09'),(10,'0120','04:42:35','18:04:45','2023-01-10'),(11,'0120','04:42:35','18:04:45','2023-06-01'),(12,'0120','04:42:35','18:04:45','2023-06-02'),(13,'0120','04:42:35','18:04:45','2023-06-03'),(14,'0120','04:42:35','18:04:45','2023-06-04'),(15,'0120','04:42:35','18:04:45','2023-06-05'),(16,'0120','04:42:35','18:04:45','2023-06-06'),(17,'0120','04:42:35','18:04:45','2023-06-07'),(18,'0120','04:42:35','18:04:45','2023-06-08'),(19,'0120','04:42:35','18:04:45','2023-06-09');
/*!40000 ALTER TABLE `attendance` ENABLE KEYS */;
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
  `description` text CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci,
  PRIMARY KEY (`department_id`) USING BTREE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci ROW_FORMAT=DYNAMIC;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `department`
--

LOCK TABLES `department` WRITE;
/*!40000 ALTER TABLE `department` DISABLE KEYS */;
INSERT INTO `department` VALUES (23,'HR Department','Department Of Human Resource  asasaa'),(24,'Production Department ','Department Of Production');
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
INSERT INTO `designation` VALUES (4,'Decision Maker',24),(8,'Data Operator',23),(33,'supervisor ',24),(34,'Machine Operator',24),(36,'Line Leader',24);
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
  `emp_no` varchar(45) DEFAULT NULL,
  `no_target` varchar(45) DEFAULT NULL,
  `no_taget_achieve` varchar(45) DEFAULT NULL,
  `efficiency` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`efficiency_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `efficiency`
--

LOCK TABLES `efficiency` WRITE;
/*!40000 ALTER TABLE `efficiency` DISABLE KEYS */;
/*!40000 ALTER TABLE `efficiency` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `emp_daily_recode`
--

DROP TABLE IF EXISTS `emp_daily_recode`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `emp_daily_recode` (
  `id` int NOT NULL AUTO_INCREMENT,
  `emp_reg_no` varchar(45) DEFAULT NULL,
  `date` varchar(45) DEFAULT NULL,
  `total_production` varchar(45) DEFAULT NULL,
  `quality` varchar(45) DEFAULT NULL,
  `defects` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=11 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `emp_daily_recode`
--

LOCK TABLES `emp_daily_recode` WRITE;
/*!40000 ALTER TABLE `emp_daily_recode` DISABLE KEYS */;
INSERT INTO `emp_daily_recode` VALUES (1,'0120','2023-01-02','10','8','2'),(2,'0120','2023-01-02','10','8','2'),(3,'0120','2023-01-03','10','8','2'),(4,'0120','2023-01-04','10','8','2'),(5,'0120','2023-01-05','10','8','2'),(6,'0120','2023-01-06','10','8','2'),(7,'0120','2023-01-07','10','8','2'),(8,'0120','2023-01-08','10','8','2'),(9,'0120','2023-01-09','10','8','2'),(10,'0120','2023-01-10','10','8','2');
/*!40000 ALTER TABLE `emp_daily_recode` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `emp_per_evaluation`
--

DROP TABLE IF EXISTS `emp_per_evaluation`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `emp_per_evaluation` (
  `id` int NOT NULL AUTO_INCREMENT,
  `emp_no` varchar(45) DEFAULT NULL,
  `total_production` varchar(45) DEFAULT NULL,
  `number_of_quality` varchar(45) DEFAULT NULL,
  `number_of_defects` varchar(45) DEFAULT NULL,
  `complete_production` varchar(45) DEFAULT NULL,
  `incomplete_production` varchar(45) DEFAULT NULL,
  `date` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=10 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `emp_per_evaluation`
--

LOCK TABLES `emp_per_evaluation` WRITE;
/*!40000 ALTER TABLE `emp_per_evaluation` DISABLE KEYS */;
INSERT INTO `emp_per_evaluation` VALUES (1,'0132','10','8','2','10','0','2023-08-15'),(2,'0132','20','18','2','20','0','2023-08-16'),(3,'0132','10','8','2','10','0','2023-08-17'),(4,'0132','20','18','2','20','0','2023-08-18'),(5,'0132','10','8','2','10','0','2023-08-19'),(6,'0132','20','18','2','20','0','2023-08-20'),(7,'0132','10','8','2','10','0','2023-08-21'),(8,'0132','20','18','2','20','0','2023-08-22'),(9,'0132','200','140','50','190','10','2023-08-15');
/*!40000 ALTER TABLE `emp_per_evaluation` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `employee`
--

DROP TABLE IF EXISTS `employee`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `employee` (
  `employee_id` int NOT NULL AUTO_INCREMENT,
  `emp_no` varchar(128) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `full_name` varchar(355) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL,
  `dob` date NOT NULL,
  `gender` varchar(10) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL,
  `nic` varchar(15) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL,
  `address` text CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL,
  `contact_1` varchar(15) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci DEFAULT NULL,
  `status` varchar(15) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
  `designation_id` int DEFAULT NULL,
  `registerd_date` date DEFAULT NULL,
  `supervisor` int DEFAULT NULL,
  `line_leader` int DEFAULT NULL,
  PRIMARY KEY (`employee_id`) USING BTREE
) ENGINE=InnoDB AUTO_INCREMENT=110 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci ROW_FORMAT=DYNAMIC;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `employee`
--

LOCK TABLES `employee` WRITE;
/*!40000 ALTER TABLE `employee` DISABLE KEYS */;
INSERT INTO `employee` VALUES (30,'0132','test','1967-03-29','Male','123456789v','test addrese','0711234567','Married',4,'1988-08-01',NULL,189),(31,'0000','test2','1951-09-16','Male','123456789v','test addrese','0711234567','Married',8,'1988-09-01',NULL,189),(33,'0189','test3','1994-09-06','Female','123456789v','test addrese','0711234567','Single',33,'2011-05-01',NULL,NULL),(34,'0120','test4','1982-07-09','Female','123456789v','test addrese','0711234567','Single',33,'2003-02-20',NULL,NULL),(35,'0206','test78','1973-07-11','Female','123456789v','test addrese','0711234567','Married',33,'2013-09-24',NULL,NULL),(36,'0213','test6','1973-04-08','Female','123456789v','test addrese','0711234567','Married',33,'2013-03-01',NULL,NULL),(37,'0214','test7','1983-04-28','Female','123456789v','test addrese','0711234567','Married',33,'2014-04-16',NULL,NULL),(38,'0224','test8','1987-07-02','Female','123456789v','test addrese','0711234567','Married',34,'2015-05-02',NULL,189),(40,'0228','test9','1998-07-02','Female','123456789v','test addrese','0711234567','Single',34,'2015-10-05',206,NULL),(41,'0232','test10','1974-01-25','Female','123456789v','test addrese','0711234567','Married',34,'2016-02-26',206,NULL),(47,'0233','test12','1982-02-13','Female','123456789v','test addrese','0711234567','Married',34,'2016-03-01',NULL,NULL),(48,'0234','test13','1976-07-08','Female','123456789v','test addrese','0711234567','Married',34,'2016-03-10',NULL,NULL),(49,'0242','test14','1999-11-18','Female','123456789v','test addrese','0711234567','Single',34,'2016-05-02',NULL,NULL),(50,'0244','test15','1987-02-04','Female','123456789v','test addrese','0711234567','Single',34,'2018-03-01',NULL,NULL),(51,'0255','test16','2002-01-03','Female','123456789v','test addrese','0711234567','Single',34,'2018-01-05',NULL,189),(52,'0259','test17','2001-11-18','Female','123456789v','test addrese','0711234567','Single',34,'2018-10-15',NULL,120),(53,'0260','test18','2002-05-13','Female','123456789v','test addrese','0711234567','Single',36,'2019-07-09',NULL,120),(54,'0261','test19','1983-07-01','Female','123456789v','test addrese','0711234567','Married',36,'2019-08-05',NULL,120);
/*!40000 ALTER TABLE `employee` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `employee_leave`
--

DROP TABLE IF EXISTS `employee_leave`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `employee_leave` (
  `leave_id` int NOT NULL AUTO_INCREMENT,
  `emp_no` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
  `date` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci DEFAULT NULL,
  `reason` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
  `day_type` varchar(45) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci DEFAULT NULL,
  `leave_type` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
  `approvel` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci DEFAULT NULL,
  PRIMARY KEY (`leave_id`) USING BTREE
) ENGINE=InnoDB AUTO_INCREMENT=201 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci ROW_FORMAT=DYNAMIC;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `employee_leave`
--

LOCK TABLES `employee_leave` WRITE;
/*!40000 ALTER TABLE `employee_leave` DISABLE KEYS */;
INSERT INTO `employee_leave` VALUES (197,'0120','2023-01-20','PERSONAL','Full Day','Anual leave','Approved'),(198,'0120','2023-01-21','PERSONAL','Full Day','Anual leave','Approved'),(199,'0120','2023-01-22','PERSONAL','Full Day','Anual leave','Approved'),(200,'0120','2023-01-23','PERSONAL','Full Day','Anual leave','Approved');
/*!40000 ALTER TABLE `employee_leave` ENABLE KEYS */;
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
  `output_qty` varchar(45) DEFAULT NULL,
  `time_management` varchar(45) DEFAULT NULL,
  `operation_efficiency` varchar(45) DEFAULT NULL,
  `adaptability` varchar(45) DEFAULT NULL,
  `fromDate` varchar(45) DEFAULT NULL,
  `toDate` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `evaluvator_recode`
--

LOCK TABLES `evaluvator_recode` WRITE;
/*!40000 ALTER TABLE `evaluvator_recode` DISABLE KEYS */;
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
  `Emp_no` varchar(45) DEFAULT NULL,
  `no_target` varchar(45) DEFAULT NULL,
  `no_achieve` varchar(45) DEFAULT NULL,
  `quality` varchar(45) DEFAULT NULL,
  `month` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`output_quality_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `output_quality`
--

LOCK TABLES `output_quality` WRITE;
/*!40000 ALTER TABLE `output_quality` DISABLE KEYS */;
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
  PRIMARY KEY (`emp_no`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `productivity`
--

LOCK TABLES `productivity` WRITE;
/*!40000 ALTER TABLE `productivity` DISABLE KEYS */;
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

-- Dump completed on 2023-10-18 13:33:46
