-- MySQL dump 10.13  Distrib 8.0.34, for Win64 (x86_64)
--
-- Host: localhost    Database: performencedb
-- ------------------------------------------------------
-- Server version	8.0.34

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
-- Table structure for table `admins`
--

DROP TABLE IF EXISTS `admins`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
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
INSERT INTO `admins` VALUES (2,'admin','test@gmail.com','admin','admin',1234567890,8),(3,'sup01','test@gmail.com','sup01','sup01',1234567890,33);
/*!40000 ALTER TABLE `admins` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `attendance`
--

DROP TABLE IF EXISTS `attendance`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
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
INSERT INTO `attendance` VALUES (1,'0120','08:25:35','16:30:45','2023-01-01'),(2,'0121','08:26:35','16:25:45','2023-01-01'),(3,'0122','ab','ab','2023-01-01'),(4,'0123','08:40:35','16:26:45','2023-01-01'),(5,'0124','08:42:35','16:28:45','2023-01-01'),(6,'0125','ab','ab','2023-01-01');
/*!40000 ALTER TABLE `attendance` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `department`
--

DROP TABLE IF EXISTS `department`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
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
/*!50503 SET character_set_client = utf8mb4 */;
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
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `efficiency` (
  `efficiency_id` int NOT NULL AUTO_INCREMENT,
  `emp_no` varchar(45) DEFAULT NULL,
  `no_target` varchar(45) DEFAULT NULL,
  `no_taget_achieve` varchar(45) DEFAULT NULL,
  `efficiency` varchar(45) DEFAULT NULL,
  `month` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`efficiency_id`)
) ENGINE=InnoDB AUTO_INCREMENT=9 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `efficiency`
--

LOCK TABLES `efficiency` WRITE;
/*!40000 ALTER TABLE `efficiency` DISABLE KEYS */;
INSERT INTO `efficiency` VALUES (1,'0120','500','455',NULL,'October'),(2,'0121','500','460',NULL,'October'),(3,'0122','400','355',NULL,'October'),(4,'0123','300','250',NULL,'October'),(5,'0124','500','460',NULL,'October'),(6,'0125','550','500',NULL,'October'),(7,'',NULL,NULL,NULL,'October'),(8,NULL,NULL,NULL,NULL,'October');
/*!40000 ALTER TABLE `efficiency` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `emp_recode`
--

DROP TABLE IF EXISTS `emp_recode`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
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
/*!50503 SET character_set_client = utf8mb4 */;
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
  `enrollment_date` date DEFAULT NULL,
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
INSERT INTO `employee` VALUES (31,'0000','P.Silva','1990-09-16','Male','123456789v','No.6,Minuwangoda','0711234567','permanant',8,'2010-09-01',NULL,260),(33,'0189','T.Silva','1985-09-06','Female','123456789v','No.12,Veyangoda','0711234567','permanant',33,'2005-05-01',NULL,NULL),(34,'0120','J.Perea','1983-07-09','Female','123456789v','No.4,Katunayaka','0711234567','permanant',33,'2003-02-20',NULL,NULL),(35,'0206','K.N.Frenando','1980-07-11','male','123456789v','No.5,Katunayaka','0711234567','permanant',33,'2003-09-24',NULL,NULL),(36,'0213','H.Perera','1984-04-08','Female','123456789v','No.1,Veyangoda','0711234567','permanant',33,'2008-03-01',NULL,NULL),(37,'0214','L.Silva','1983-04-28','Female','123456789v','No.3,Minuwangoda','0711234567','permanant',33,'2007-04-16',NULL,NULL),(38,'0120','U.Perera','1995-07-02','Female','123456789v','No.5,Minuwangaoda','0711234567','permanant',34,'2015-05-02',189,260),(40,'0121','R.Silva','1995-07-02','Female','123456789v','No.6,Veyangoda','0711234567','permanant',34,'2015-10-05',189,260),(41,'0122','K.O.Perera','2003-01-25','Female','123456789v','No.19,Minuwangoda','0711234567','Tranner',34,'2023-08-26',213,260),(47,'0123','L.T.Frenando','1995-02-13','Female','123456789v','No.20,Veyangoda','0711234567','permanant',34,'2016-03-01',213,260),(48,'0124','E.P.Perera','1994-07-08','Female','123456789v','No.21,Katunayaka','0711234567','permanant',34,'2016-03-10',213,261),(49,'0125','G.Frenando','1994-11-18','Female','123456789v','No.30,Veyangoda','0711234567','permanant',34,'2016-05-02',NULL,261);
/*!40000 ALTER TABLE `employee` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `evaluvator_recode`
--

DROP TABLE IF EXISTS `evaluvator_recode`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
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
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `output_quality` (
  `output_quality_id` int NOT NULL AUTO_INCREMENT,
  `Emp_no` varchar(45) DEFAULT NULL,
  `no_target` varchar(45) DEFAULT NULL,
  `no_achieve` varchar(45) DEFAULT NULL,
  `quality` varchar(45) DEFAULT NULL,
  `month` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`output_quality_id`)
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `output_quality`
--

LOCK TABLES `output_quality` WRITE;
/*!40000 ALTER TABLE `output_quality` DISABLE KEYS */;
INSERT INTO `output_quality` VALUES (1,'0120','500','455','450','October'),(2,'0121','500','460','450','October'),(3,'0122','400','355','350','October'),(4,'0123','300','250','245','October'),(5,'0124','500','460','450','October'),(6,'0125','550','500','455','October');
/*!40000 ALTER TABLE `output_quality` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `productivity`
--

DROP TABLE IF EXISTS `productivity`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `productivity` (
  `emp_no` int NOT NULL AUTO_INCREMENT,
  `working_days` varchar(45) DEFAULT NULL,
  `absentisnt` varchar(45) DEFAULT NULL,
  `attendance` varchar(45) DEFAULT NULL,
  `productivity` varchar(45) DEFAULT NULL,
  `month` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`emp_no`)
) ENGINE=InnoDB AUTO_INCREMENT=126 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `productivity`
--

LOCK TABLES `productivity` WRITE;
/*!40000 ALTER TABLE `productivity` DISABLE KEYS */;
INSERT INTO `productivity` VALUES (120,'25','2','23',NULL,'October'),(121,'25','1','24',NULL,'October'),(122,'25','3','22',NULL,'October'),(123,'25','0','25',NULL,'October'),(124,'25','5','20',NULL,'October'),(125,'25','1','24',NULL,'October');
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

-- Dump completed on 2023-10-18 13:20:22
