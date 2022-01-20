-- phpMyAdmin SQL Dump
-- version 3.4.5
-- http://www.phpmyadmin.net
--
-- Host: localhost
-- Generation Time: Jun 26, 2014 at 08:49 AM
-- Server version: 5.5.16
-- PHP Version: 5.3.8

SET SQL_MODE="NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;

--
-- Database: `tmp`
--
CREATE DATABASE `tmp` DEFAULT CHARACTER SET utf8 COLLATE utf8_general_ci;
USE `tmp`;

-- --------------------------------------------------------

--
-- Table structure for table `magacin`
--

CREATE TABLE IF NOT EXISTS `magacin` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `LadicaBroj` int(11) NOT NULL,
  `Sadrzaj` text NOT NULL,
  `Kolicina` int(11) NOT NULL,
  `Slika` varchar(16) NOT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB  DEFAULT CHARSET=utf8 AUTO_INCREMENT=25 ;

--
-- Dumping data for table `magacin`
--

INSERT INTO `magacin` (`ID`, `LadicaBroj`, `Sadrzaj`, `Kolicina`, `Slika`) VALUES
(1, 1, 'Otpornici 1k', 10, 'otpornici.jpg'),
(2, 2, 'Otpornici 1k1', 20, 'otpornici.jpg'),
(3, 3, 'Otpornici 1k2', 30, 'otpornici.jpg'),
(4, 4, 'Otpornici 1k3', 45, 'otpornici.jpg'),
(5, 5, 'Otpornici 1k6', 17, 'otpornici.jpg'),
(6, 6, 'Otpornici 1k8', 21, 'otpornici.jpg'),
(7, 7, 'Otpornici 2k', 30, 'otpornici.jpg'),
(8, 8, 'Otpornici 2k2', 0, 'otpornici.jpg'),
(9, 9, 'Otpornici 2k4', 14, 'otpornici.jpg'),
(10, 10, 'Otpornici 2k7', 3, 'otpornici.jpg'),
(11, 11, 'Otpornici 3k', 7, 'otpornici.jpg'),
(12, 12, 'Otpornici 3k3', 9, 'otpornici.jpg'),
(13, 13, 'Otpornici 3k6', 18, 'otpornici.jpg'),
(14, 14, 'Otpornici 3k9', 50, 'otpornici.jpg'),
(15, 15, 'Otpornici 4k3', 24, 'otpornici.jpg'),
(16, 16, 'Otpornici 4k7', 9, 'otpornici.jpg'),
(17, 17, 'Kondezatori 10pF', 30, 'kondezatori.jpg'),
(18, 18, 'Kondezatori 12pF', 0, 'kondezatori.jpg'),
(19, 19, 'Kondezatori 15pF', 14, 'kondezatori.jpg'),
(20, 20, 'Kondezatori 18pF', 3, 'kondezatori.jpg'),
(21, 21, 'Kondezatori 22pF', 9, 'kondezatori.jpg'),
(22, 22, 'Kondezatori 27pF', 18, 'kondezatori.jpg'),
(23, 23, 'Kondezatori 33pF', 50, 'kondezatori.jpg'),
(24, 24, 'Kondezatori 39pF', 24, 'kondezatori.jpg');

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
