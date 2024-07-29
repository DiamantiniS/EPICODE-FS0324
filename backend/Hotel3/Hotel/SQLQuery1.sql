
CREATE TABLE [dbo].[Camere] (
    [Id]          INT             IDENTITY (1, 1) NOT NULL,
    [Descrizione] NVARCHAR (255)  NOT NULL,
    [Tipologia]   NVARCHAR (255)  NOT NULL,
    [Prezzo]      DECIMAL (10, 2) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

CREATE TABLE [dbo].[Clienti] (
    [id]             INT           IDENTITY (1, 1) NOT NULL,
    [codice_fiscale] VARCHAR (16)  NOT NULL,
    [cognome]        VARCHAR (50)  NOT NULL,
    [nome]           VARCHAR (50)  NOT NULL,
    [città]          VARCHAR (50)  NOT NULL,
    [provincia]      VARCHAR (50)  NOT NULL,
    [email]          VARCHAR (100) NOT NULL,
    [cellulare]      VARCHAR (15)  NOT NULL,
    PRIMARY KEY CLUSTERED ([id] ASC),
    UNIQUE NONCLUSTERED ([codice_fiscale] ASC),
    CONSTRAINT [chk_codice_fiscale_length] CHECK (len([codice_fiscale])=(16))
);

CREATE TABLE [dbo].[Prenotazioni_Servizi] (
    [id]              INT IDENTITY (1, 1) NOT NULL,
    [prenotazione_id] INT NOT NULL,
    [servizio_id]     INT NOT NULL,
    PRIMARY KEY CLUSTERED ([id] ASC),
    FOREIGN KEY ([prenotazione_id]) REFERENCES [dbo].[Prenotazioni] ([id]),
    FOREIGN KEY ([servizio_id]) REFERENCES [dbo].[Servizi] ([id])
);

CREATE TABLE [dbo].[Servizi] (
    [id]          INT             IDENTITY (1, 1) NOT NULL,
    [descrizione] VARCHAR (100)   NOT NULL,
    [prezzo]      DECIMAL (10, 2) NOT NULL,
    PRIMARY KEY CLUSTERED ([id] ASC)
);

CREATE TABLE [dbo].[Users] (
    [id]       INT          IDENTITY (1, 1) NOT NULL,
    [username] VARCHAR (50) NOT NULL,
    [password] VARCHAR (50) NOT NULL,
    [role]     VARCHAR (50) NOT NULL,
    PRIMARY KEY CLUSTERED ([id] ASC),
    UNIQUE NONCLUSTERED ([username] ASC)
);
CREATE TABLE [dbo].[Prenotazioni] (
    [id]                  INT             IDENTITY (1, 1) NOT NULL,
    [cliente_id]          INT             NOT NULL,
    [camera_id]           INT             NOT NULL,
    [data_prenotazione]   DATE            NOT NULL,
    [numero_progressivo]  INT             NOT NULL,
    [anno]                INT             NOT NULL,
    [dal]                 DATE            NOT NULL,
    [al]                  DATE            NOT NULL,
    [caparra]             DECIMAL (10, 2) NOT NULL,
    [tariffa]             DECIMAL (10, 2) NOT NULL,
    [tipologia_soggiorno] VARCHAR (255)   NOT NULL,
    PRIMARY KEY CLUSTERED ([id] ASC),
    FOREIGN KEY ([cliente_id]) REFERENCES [dbo].[Clienti] ([id]),
    FOREIGN KEY ([camera_id]) REFERENCES [dbo].[Camere] ([Id]),
    CONSTRAINT [chk_tipologia_soggiorno] CHECK ([tipologia_soggiorno]='pernottamento con prima colazione' OR [tipologia_soggiorno]='pensione completa' OR [tipologia_soggiorno]='mezza pensione')
);


INSERT INTO Users (username, password, role) VALUES 
('admin', 'admin', 'admin'),
('receptionist', 'reception', 'receptionist');