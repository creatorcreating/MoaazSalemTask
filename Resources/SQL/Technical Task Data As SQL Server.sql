

CREATE TABLE Person_Details (
    [id] int IDENTITY(101, 1) PRIMARY KEY,
    [name] varchar(50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
    [telephone Number] varchar(50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
    [address] varchar(200) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
    [country] varchar(50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL
);

INSERT INTO Person_Details
(
    [name],
    [telephone Number],
    [address],
    [country]
)
VALUES
(
    'Ahmed Mohammed',
    '20-010334445',
    '10 Road Street',
    'Egypt'
),
(
    'Mona Mahmoud',
    '20-010334445',
    '11 Road Street',
    'Egypt'   
),
(
    'Mohammed Rabie',
    '970-111111111',
    '15 Road Street',
    'Palestine'
),
(
    'Ana yousif',
    '961-111111111',
    '20 Road Street',
    'Lebanon'
);

