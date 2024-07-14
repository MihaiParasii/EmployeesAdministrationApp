CREATE TABLE IF NOT EXISTS `__EFMigrationsHistory` (
    `MigrationId` varchar(150) CHARACTER SET utf8mb4 NOT NULL,
    `ProductVersion` varchar(32) CHARACTER SET utf8mb4 NOT NULL,
    CONSTRAINT `PK___EFMigrationsHistory` PRIMARY KEY (`MigrationId`)
) CHARACTER SET=utf8mb4;

START TRANSACTION;

ALTER DATABASE CHARACTER SET utf8mb4;

CREATE TABLE `Employees` (
    `Id` int NOT NULL AUTO_INCREMENT,
    `Name` varchar(15) CHARACTER SET utf8mb4 NOT NULL,
    `SurName` varchar(30) CHARACTER SET utf8mb4 NOT NULL,
    `Email` longtext CHARACTER SET utf8mb4 NOT NULL,
    `BirthDate` date NOT NULL,
    `PhotoPath` longtext CHARACTER SET utf8mb4 NULL,
    `Department` int NOT NULL,
    CONSTRAINT `PK_Employees` PRIMARY KEY (`Id`)
) CHARACTER SET=utf8mb4;

INSERT INTO `__EFMigrationsHistory` (`MigrationId`, `ProductVersion`)
VALUES ('20240711222557_InitialMigration', '8.0.7');

COMMIT;

START TRANSACTION;

ALTER TABLE `Employees` RENAME COLUMN `Department` TO `DepartmentId`;

CREATE TABLE `Departments` (
    `Id` int NOT NULL AUTO_INCREMENT,
    `Name` varchar(20) CHARACTER SET utf8mb4 NOT NULL,
    CONSTRAINT `PK_Departments` PRIMARY KEY (`Id`)
) CHARACTER SET=utf8mb4;

CREATE INDEX `IX_Employees_DepartmentId` ON `Employees` (`DepartmentId`);

ALTER TABLE `Employees` ADD CONSTRAINT `FK_Employees_Departments_DepartmentId` FOREIGN KEY (`DepartmentId`) REFERENCES `Departments` (`Id`) ON DELETE CASCADE;

INSERT INTO `__EFMigrationsHistory` (`MigrationId`, `ProductVersion`)
VALUES ('20240711233542_AddDepartmentsModel', '8.0.7');

COMMIT;

