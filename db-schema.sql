/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `competition` (
  `GUID` varbinary(16) NOT NULL,
  `title` text,
  `creator_user_guid` varbinary(16) NOT NULL,
  `start_date` datetime NOT NULL,
  `end_date` datetime NOT NULL,
  `description` text,
  `short_description` text,
  `extra` text,
  PRIMARY KEY (`GUID`),
  KEY `FK_competition_user_creator_user_guid` (`creator_user_guid`),
  CONSTRAINT `FK_competition_user_creator_user_guid` FOREIGN KEY (`creator_user_guid`) REFERENCES `user` (`GUID`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `competition_categories` (
  `GUID` varbinary(16) NOT NULL,
  `name` text,
  PRIMARY KEY (`GUID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `competition_constraints` (
  `GUID` varbinary(16) NOT NULL,
  `competition_guid` varbinary(16) NOT NULL,
  `checked_value` text,
  `min` int(11) NOT NULL,
  `max` int(11) NOT NULL,
  PRIMARY KEY (`GUID`),
  KEY `FK_competition_constraints_competition_competition_guid` (`competition_guid`),
  CONSTRAINT `FK_competition_constraints_competition_competition_guid` FOREIGN KEY (`competition_guid`) REFERENCES `competition` (`GUID`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `profiles` (
  `user_role_guid` varbinary(16) NOT NULL,
  `data` text,
  `short_link` text,
  PRIMARY KEY (`user_role_guid`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `roles` (
  `GUID` varbinary(16) NOT NULL,
  `role` enum('moderator','jury','user','manager','admin') NOT NULL,
  `user_guid` varbinary(16) NOT NULL,
  PRIMARY KEY (`GUID`),
  KEY `FK_roles_user_user_guid` (`user_guid`),
  CONSTRAINT `FK_roles_user_user_guid` FOREIGN KEY (`user_guid`) REFERENCES `user` (`GUID`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `user` (
  `GUID` varbinary(16) NOT NULL,
  `login` text,
  `password_hash` binary(24) DEFAULT NULL,
  PRIMARY KEY (`GUID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;
