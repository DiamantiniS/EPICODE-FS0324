-- 1. Conteggio dei verbali trascritti
SELECT COUNT(*) AS TotaleVerbali FROM VERBALE;

-- 2. Conteggio dei verbali trascritti raggruppati per anagrafe
SELECT idanagrafica, COUNT(*) AS ConteggioVerbali
FROM VERBALE
GROUP BY idanagrafica;

-- 3. Conteggio dei verbali trascritti raggruppati per tipo di violazione
SELECT vv.idviolazione, COUNT(*) AS ConteggioVerbali
FROM VERBALE_VIOLAZIONE vv
JOIN TIPO_VIOLAZIONE tv ON vv.idviolazione = tv.idviolazione
GROUP BY vv.idviolazione;

-- 4. Totale dei punti decurtati per ogni anagrafe
SELECT idanagrafica, SUM(DecurtamentoPunti) AS TotalePunti
FROM VERBALE
GROUP BY idanagrafica;

-- 5. Cognome, Nome, Data violazione, Indirizzo violazione, importo e punti decurtati per tutti gli anagrafici residenti a Palermo
SELECT a.Cognome, a.Nome, v.DataViolazione, v.IndirizzoViolazione, v.Importo, v.DecurtamentoPunti
FROM VERBALE v
JOIN ANAGRAFICA a ON v.idanagrafica = a.idanagrafica
WHERE a.Città = 'Palermo';

-- 6. Cognome, Nome, Indirizzo, Data violazione, importo e punti decurtati per le violazioni fatte tra il febbraio 2009 e luglio 2009
SELECT a.Cognome, a.Nome, a.Indirizzo, v.DataViolazione, v.Importo, v.DecurtamentoPunti
FROM VERBALE v
JOIN ANAGRAFICA a ON v.idanagrafica = a.idanagrafica
WHERE v.DataViolazione BETWEEN '2009-02-01' AND '2009-07-31';

-- 7. Totale degli importi per ogni anagrafico
SELECT idanagrafica, SUM(Importo) AS TotaleImporti
FROM VERBALE
GROUP BY idanagrafica;

-- 8. Visualizzazione di tutti gli anagrafici residenti a Palermo
SELECT * FROM ANAGRAFICA
WHERE Città = 'Palermo';

-- 9. Query che visualizzi Data violazione, Importo e decurtamento punti relativi ad una certa data
SELECT DataViolazione, Importo, DecurtamentoPunti
FROM VERBALE
WHERE DataViolazione = '2023-01-01';

-- 10. Conteggio delle violazioni contestate raggruppate per Nominativo dell’agente di Polizia
SELECT Nominativo_Agente, COUNT(*) AS ConteggioViolazioni
FROM VERBALE
GROUP BY Nominativo_Agente;

-- 11. Cognome, Nome, Indirizzo, Data violazione, Importo e punti decurtati per tutte le violazioni che superino il decurtamento di 5 punti
SELECT a.Cognome, a.Nome, a.Indirizzo, v.DataViolazione, v.Importo, v.DecurtamentoPunti
FROM VERBALE v
JOIN ANAGRAFICA a ON v.idanagrafica = a.idanagrafica
WHERE v.DecurtamentoPunti > 5;

-- 12. Cognome, Nome, Indirizzo, Data violazione, Importo e punti decurtati per tutte le violazioni che superino l’importo di 400 euro
SELECT a.Cognome, a.Nome, a.Indirizzo, v.DataViolazione, v.Importo, v.DecurtamentoPunti
FROM VERBALE v
JOIN ANAGRAFICA a ON v.idanagrafica = a.idanagrafica
WHERE v.Importo > 400;
