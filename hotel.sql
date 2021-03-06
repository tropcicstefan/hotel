

SELECT * FROM dbo.Hotel

SELECT * FROM dbo.Gost

SELECT * FROM dbo.Soba

SELECT * FROM dbo.SobaTip

SELECT * FROM dbo.ElementPonude

SELECT * FROM dbo.Rezervacija






DELETE FROM dbo.PrivremeniRacun

DELETE FROM dbo.Gost WHERE ID = 0

DELETE FROM dbo.Rezervacija WHERE SobaID = 4

INSERT INTO dbo.Rezervacija(
	GostID,
	SobaID,
	DatumOd,
	DatumDo,
	DatumOdDolaska,
	DatumDoDolaska,
	Popust)	
VALUES
	(987654321, 5, '2018/09/19', '2018/09/22', '', '', 10)
----
DELETE FROM dbo.Rezervacija WHERE ID = 9
-----
INSERT INTO dbo.Soba(
	SobaTipID,
	HotelID)
VALUES
	(1, 1),
	(1, 2),
	(2, 2)

SELECT s.ID FROM Rezervacija as r right join Soba as s on r.SobaID = s.ID where  (GETDATE() between r.DatumOd and r.DatumDo) or (getdate() between r.DatumOdDolaska and r.DatumDoDolaska)

SELECT s.ID FROM Rezervacija as r right join Soba as s on r.SobaID = s.ID where  (GETDATE() between r.DatumOd and r.DatumDo)
UNION all
SELECT s.ID FROM Rezervacija as r right join Soba as s on r.SobaID = s.ID where  (getdate() between r.DatumOdDolaska and r.DatumDoDolaska)

select GETDATE();

SELECT ID From Soba
where ID not IN(SELECT s.ID FROM Rezervacija as r right join Soba as s on r.SobaID = s.ID where  (GETDATE() between r.DatumOd and r.DatumDo) or (getdate() between r.DatumOdDolaska and r.DatumDoDolaska));


SELECT ID From Soba
where ID not IN(SELECT s.ID FROM Rezervacija as r right join Soba as s on r.SobaID = s.ID where  (GETDATE() >= r.DatumOd and GETDATE() <= r.DatumDo) or (getdate() >= r.DatumOdDolaska and getdate() <= r.DatumDoDolaska));


INSERT INTO dbo.Rezervacija(
	GostID,
	SobaID,
	DatumOd,
	DatumDo,
	DatumOdDolaska,
	DatumDoDolaska,
	Popust)	
VALUES
	(5, 3, '2017/09/19', '2017/10/10', '', '', 10)

SELECT * FROM dbo.Stavke
INSERT INTO dbo.Stavke(
	PrivremeniRacunID,
	ElementPonudeID,
	Kolicina
)
VALUES
	(71,1,2)

SELECT * FROM dbo.PrivremeniRacun
INSERT INTO dbo.PrivremeniRacun(
	RezervacijaID,
	Placeno
)
VALUES
	(3, 1),
	(4, 0),
	(5, 0)