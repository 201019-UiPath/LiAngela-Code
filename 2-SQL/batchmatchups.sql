CREATE TABLE public."teams"
(
	id serial primary key,
    teamName varchar(50) not null,
	coach varchar(50) not null
);

INSERT INTO public."teams" (teamName, coach) VALUES
('UiPath Hockey', 'Pushpinder K');

CREATE TABLE public."players"
(
	id serial primary key,
	teamId serial references teams(id),
    playerName varchar(50) not null,
	position varchar(50) not null
);

INSERT INTO public."players" (teamId, playerName, position) VALUES
(1, 'Lindsey W', 'Goaltender'),
(1, 'Shalei K', 'Forward'),
(1, 'Julie G', 'Forward'),
(1, 'Brian P', 'Forward'),
(1, 'James M', 'Defense'),
(1, 'James P', 'Defense'),
(1, 'Michael B', 'Defense'),
(1, 'Nicole H', 'Defense'),
(1, 'Shantel C', 'Defense'),
(1, 'Angela L', 'Defense');

CREATE TABLE public."matchups"
(
	id serial primary key,
    teamId serial references teams(id),
	gameTime time not null
);
