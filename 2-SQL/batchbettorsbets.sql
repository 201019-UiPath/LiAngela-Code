DROP TABLE IF EXISTS public."bettors";
DROP TABLE IF EXISTS public."bets";
DROP TABLE IF EXISTS public."racetrackManagers";

CREATE TABLE public."bettors"
(
	id serial primary key,
	bettorName varchar(100) not null
);

INSERT INTO public."bettors" (bettorName) VALUES
('Anthony Tejada'),
('Andrea Siles-Loayza'),
('Jacob Jinnings'),
('Rachel Hufnagel'),
('Vincent Wise');

CREATE TABLE public."bets"
(
	id serial primary key,
	bettorId serial references public."bettors"(id),
	managerId serial references public."racetrackManagers"(id),
	wager decimal not null,
	racehorse varchar(50) not null,
	betTime time not null
);

INSERT INTO public."bets" (bettorId, managerId, wager, racehorse, betTime) VALUES
(1, 2, 17, 'Harry', now()),
(2, 2, 98, 'Authentic', now()),
(3, 2, 99, 'Harry', now()),
(4, 2, 5, 'Harry', now()),
(5, 2, 90, 'Harry', now());

CREATE TABLE public."racetrackManagers"
(
	id serial primary key,
	managerName varchar(50) not null,
	racetrack varchar(50) not null
);

INSERT INTO public."racetrackManagers" (id, managerName, racetrack) VALUES
(2, 'Mariele Nolasco', 'Revature Racetrack');

SELECT * FROM public."bettors";
SELECT * FROM public."bets";
SELECT * FROM public."racetrackManagers";
