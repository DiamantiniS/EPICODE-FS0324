SELECT * FROM IMPIEGATO
WHERE Eta > 29;

SELECT * FROM IMPIEGATO
WHERE [Reddito Mensile] >=1200;

SELECT * FROM IMPIEGATO
WHERE [Detrazione fiscale] = 1;

SELECT * FROM IMPIEGATO
WHERE [Detrazione fiscale] = 0;

SELECT * FROM IMPIEGATO
WHERE Cognome LIKE 'G%'
ORDER BY Cognome;

SELECT COUNT(*) AS NumeroTotaleImpiegati FROM IMPIEGATO;

SELECT SUM([Reddito Mensile]) AS TotaleRedditiMensili FROM IMPIEGATO;

SELECT AVG([Reddito Mensile]) AS MediaRedditiMensili FROM IMPIEGATO;

SELECT MAX([Reddito Mensile]) AS RedditoMensileMassimo FROM IMPIEGATO;

SELECT MIN([Reddito Mensile]) AS RedditoMensileMinimo FROM IMPIEGATO;

SELECT I.* 
FROM IMPIEGATO I
JOIN IMPIEGO P ON I.IdImpiegato = P.IDImpiegato
WHERE P.Assunzione BETWEEN '2007-01-01' AND '2008-01-01';