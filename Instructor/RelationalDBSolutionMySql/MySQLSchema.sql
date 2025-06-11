CREATE DATABASE  IF NOT EXISTS `MySqlContactsDB` /*!40100 DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci */ /*!80016 DEFAULT ENCRYPTION='N' */;
USE `MySqlContactsDB`;
-- MySQL dump 10.13  Distrib 8.0.13, for Win64 (x86_64)
--
-- Host: localhost    Database: MySqlContactsDB
-- ------------------------------------------------------
-- Server version	8.0.18

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
-- Table structure for table `ContactEmail`
--

DROP TABLE IF EXISTS `ContactEmail`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `ContactEmail` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `ContactId` int(11) NOT NULL,
  `EmailAddressId` int(11) NOT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `ContactEmail`
--

LOCK TABLES `ContactEmail` WRITE;
/*!40000 ALTER TABLE `ContactEmail` DISABLE KEYS */;
INSERT INTO `ContactEmail` VALUES (1,1,1),(2,1,2),(3,2,3),(4,2,2);
/*!40000 ALTER TABLE `ContactEmail` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `ContactPhoneNumbers`
--

DROP TABLE IF EXISTS `ContactPhoneNumbers`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `ContactPhoneNumbers` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `ContactId` int(11) NOT NULL,
  `PhoneNumberId` int(11) NOT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `ContactPhoneNumbers`
--

LOCK TABLES `ContactPhoneNumbers` WRITE;
/*!40000 ALTER TABLE `ContactPhoneNumbers` DISABLE KEYS */;
INSERT INTO `ContactPhoneNumbers` VALUES (2,1,2),(3,2,1),(4,2,3);
/*!40000 ALTER TABLE `ContactPhoneNumbers` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `Contacts`
--

DROP TABLE IF EXISTS `Contacts`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `Contacts` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `FirstName` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `LastName` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Contacts`
--

LOCK TABLES `Contacts` WRITE;
/*!40000 ALTER TABLE `Contacts` DISABLE KEYS */;
INSERT INTO `Contacts` VALUES (1,'Timothy','Corey'),(2,'Charity','Corey');
/*!40000 ALTER TABLE `Contacts` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `EmailAddresses`
--

DROP TABLE IF EXISTS `EmailAddresses`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `EmailAddresses` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `EmailAddress` varchar(100) NOT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `EmailAddresses`
--

LOCK TABLES `EmailAddresses` WRITE;
/*!40000 ALTER TABLE `EmailAddresses` DISABLE KEYS */;
INSERT INTO `EmailAddresses` VALUES (1,'tim@iamtimcorey.com'),(2,'me@timothycorey.com'),(3,'nope@aol.com');
/*!40000 ALTER TABLE `EmailAddresses` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `PhoneNumbers`
--

DROP TABLE IF EXISTS `PhoneNumbers`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `PhoneNumbers` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `PhoneNumber` varchar(20) NOT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `PhoneNumbers`
--

LOCK TABLES `PhoneNumbers` WRITE;
/*!40000 ALTER TABLE `PhoneNumbers` DISABLE KEYS */;
INSERT INTO `PhoneNumbers` VALUES (1,'555-1212'),(2,'555-1234'),(3,'555-9876');
/*!40000 ALTER TABLE `PhoneNumbers` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2019-11-20 12:37:17
