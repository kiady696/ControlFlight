INSERT INTO [dbo].[Aeroport] ([Id_Aeroport],[Code_Aeroport],[Ville]) VALUES ('AE1' , 'TNR' , 'Antananarivo');
INSERT INTO [dbo].[Aeroport] ([Id_Aeroport],[Code_Aeroport],[Ville]) VALUES ('AE2' , 'MRU' , 'Maurice');
INSERT INTO [dbo].[Aeroport] ([Id_Aeroport],[Code_Aeroport],[Ville]) VALUES ('AE3' , 'CDG' , 'Paris');
INSERT INTO [dbo].[Aeroport] ([Id_Aeroport],[Code_Aeroport],[Ville]) VALUES ('AE4' , 'SYD' , 'Sydney');

-- Raha te hi convertir string ho datetime / datetime ho string CONVERT(datetime, '02/09/2020 08:32:19', 103) 

-- Raha efa samy DateTime ilay type fa ny format-any no ovaina : FORMAT(GETDATE(), 'dd/mm/yyyy hh:mm:ss')

CONVERT(datetime2,'02/09/2020 08:32:19',103) --string ho datetime
FORMAT(CONVERT(datetime2,'02/09/2020 08:32:19',103), 'dd/mm/yyyy hh:mm:ss')  -- Format-any ho dd/mm/yyy hh:mm:ss

INSERT INTO [dbo].[Vol] ([Id_Vol], [Id_Aeroport_Depart], [Id_Aeroport_Arrivee], [Id_Avion], [Date_Depart], [Duree]) VALUES ('V1', 'AE1', 'AE3', 'A1', CONVERT(datetime, '02/09/2020 08:32:19', 103) , 1.5)																
INSERT INTO [dbo].[Vol] ([Id_Vol], [Id_Aeroport_Depart], [Id_Aeroport_Arrivee], [Id_Avion], [Date_Depart], [Duree]) VALUES ('V2', 'AE2', 'AE3', 'A2', CONVERT(datetime,'05/09/2020 08:32:00',103) , 3.5)

INSERT INTO [dbo].[Vol] ([Id_Vol], [Id_Aeroport_Depart], [Id_Aeroport_Arrivee], [Id_Avion], [Date_Depart], [Duree]) VALUES ('V3', 'AE2', 'AE1', 'A3', CONVERT(datetime,'09/09/2020 11:00:00',103) , 1)
INSERT INTO [dbo].[Vol] ([Id_Vol], [Id_Aeroport_Depart], [Id_Aeroport_Arrivee], [Id_Avion], [Date_Depart], [Duree]) VALUES ('V4', 'AE3', 'AE1', 'A3', CONVERT(datetime,'09/09/2020 11:05:00',103) , 1)
INSERT INTO [dbo].[Vol] ([Id_Vol], [Id_Aeroport_Depart], [Id_Aeroport_Arrivee], [Id_Avion], [Date_Depart], [Duree]) VALUES ('V5', 'AE2', 'AE1', 'A5', CONVERT(datetime,'09/09/2020 11:10:00',103) , 1)
INSERT INTO [dbo].[Vol] ([Id_Vol], [Id_Aeroport_Depart], [Id_Aeroport_Arrivee], [Id_Avion], [Date_Depart], [Duree]) VALUES ('V6', 'AE3', 'AE1', 'A4', CONVERT(datetime,'09/09/2020 11:15:00',103) , 1)
INSERT INTO [dbo].[Vol] ([Id_Vol], [Id_Aeroport_Depart], [Id_Aeroport_Arrivee], [Id_Avion], [Date_Depart], [Duree]) VALUES ('V7', 'AE2', 'AE1', 'A5', CONVERT(datetime,'09/09/2020 11:20:00',103) , 1)
INSERT INTO [dbo].[Vol] ([Id_Vol], [Id_Aeroport_Depart], [Id_Aeroport_Arrivee], [Id_Avion], [Date_Depart], [Duree]) VALUES ('V8', 'AE3', 'AE1', 'A5', CONVERT(datetime,'09/09/2020 11:25:00',103) , 1)
INSERT INTO [dbo].[Vol] ([Id_Vol], [Id_Aeroport_Depart], [Id_Aeroport_Arrivee], [Id_Avion], [Date_Depart], [Duree]) VALUES ('V9', 'AE2', 'AE1', 'A3', CONVERT(datetime,'09/09/2020 11:30:00',103) , 1)
INSERT INTO [dbo].[Vol] ([Id_Vol], [Id_Aeroport_Depart], [Id_Aeroport_Arrivee], [Id_Avion], [Date_Depart], [Duree]) VALUES ('V10', 'AE3', 'AE1', 'A5', CONVERT(datetime,'09/09/2020 11:35:00',103) , 1)
INSERT INTO [dbo].[Vol] ([Id_Vol], [Id_Aeroport_Depart], [Id_Aeroport_Arrivee], [Id_Avion], [Date_Depart], [Duree]) VALUES ('V11', 'AE2', 'AE1', 'A4', CONVERT(datetime,'09/09/2020 11:40:00',103) , 1)
INSERT INTO [dbo].[Vol] ([Id_Vol], [Id_Aeroport_Depart], [Id_Aeroport_Arrivee], [Id_Avion], [Date_Depart], [Duree]) VALUES ('V12', 'AE3', 'AE1', 'A4', CONVERT(datetime,'09/09/2020 11:45:00',103) , 1)

--

INSERT INTO [dbo].[Avion] ([Id_Avion], [Id_Modele], [Nom_Avion]) VALUES ('A1', 'M1' , 'A380')
INSERT INTO [dbo].[Avion] ([Id_Avion], [Id_Modele], [Nom_Avion]) VALUES ('A2', 'M2' , 'B747')

INSERT INTO [dbo].[Avion] ([Id_Avion], [Id_Modele], [Nom_Avion]) VALUES ('A3', 'M3' , 'B777')
INSERT INTO [dbo].[Avion] ([Id_Avion], [Id_Modele], [Nom_Avion]) VALUES ('A4', 'M4' , 'A440')
INSERT INTO [dbo].[Avion] ([Id_Avion], [Id_Modele], [Nom_Avion]) VALUES ('A5', 'M5' , 'B647')


--

INSERT INTO [dbo].[Modele] ([Id_Modele], [Designation_Modele], [Besoin_Decollage] ,[Besoin_Atterrissage] , [Longueur_Modele]) VALUES ('M1', 'A300' , 300 , 400 , 25)
INSERT INTO [dbo].[Modele] ([Id_Modele], [Designation_Modele], [Besoin_Decollage] ,[Besoin_Atterrissage] , [Longueur_Modele]) VALUES ('M2', 'B700' , 500 , 600 , 30)

INSERT INTO [dbo].[Modele] ([Id_Modele], [Designation_Modele], [Besoin_Decollage] ,[Besoin_Atterrissage] , [Longueur_Modele]) VALUES ('M3', 'B770' , 1500 , 1500 , 35)
INSERT INTO [dbo].[Modele] ([Id_Modele], [Designation_Modele], [Besoin_Decollage] ,[Besoin_Atterrissage] , [Longueur_Modele]) VALUES ('M4', 'A400' , 1500.00 , 1500.00 , 26.00)
INSERT INTO [dbo].[Modele] ([Id_Modele], [Designation_Modele], [Besoin_Decollage] ,[Besoin_Atterrissage] , [Longueur_Modele]) VALUES ('M5', 'B600' , 800.00 , 800.00 , 19.00)

--

INSERT INTO [dbo].[Piste] ([Id_Piste], [Id_Aeroport], [Num_Piste] , [Longueur] , [Degagement]) VALUES ('P1', 'AE3' , '1' , '1000' , 0.5)
INSERT INTO [dbo].[Piste] ([Id_Piste], [Id_Aeroport], [Num_Piste] , [Longueur] , [Degagement]) VALUES ('P2', 'AE3' , '2' , '500' , 1)
INSERT INTO [dbo].[Piste] ([Id_Piste], [Id_Aeroport], [Num_Piste] , [Longueur] , [Degagement]) VALUES ('P3', 'AE3' , '3' , '350' , 0.5)
INSERT INTO [dbo].[Piste] ([Id_Piste], [Id_Aeroport], [Num_Piste] , [Longueur] , [Degagement]) VALUES ('P4', 'AE3' , '4' , '800' , 0.25)

INSERT INTO [dbo].[Piste] ([Id_Piste], [Id_Aeroport], [Num_Piste] , [Longueur] , [Degagement]) VALUES ('P5', 'AE1' , '1' , '2000' , 0.25)
INSERT INTO [dbo].[Piste] ([Id_Piste], [Id_Aeroport], [Num_Piste] , [Longueur] , [Degagement]) VALUES ('P6', 'AE1' , '2' , '1000' , 0.5)
INSERT INTO [dbo].[Piste] ([Id_Piste], [Id_Aeroport], [Num_Piste] , [Longueur] , [Degagement]) VALUES ('P7', 'AE1' , '3' , '500' , 0.45)

--

INSERT INTO [dbo].[Occupation] ([Id_Occupation], [Id_Piste], [Id_Vol] , [Debut_Occupation] , [Fin_Occupation]) VALUES ('O5', 'P1' , 'V1' , CONVERT(datetime, '05/09/2020 12:03:00', 103) , CONVERT(datetime, '05/09/2020 12:20:00', 103))

INSERT INTO [dbo].[Occupation] ([Id_Occupation], [Id_Piste], [Id_Vol] , [Debut_Occupation] , [Fin_Occupation]) VALUES ('O6', 'P5' , 'V3' , CONVERT(datetime, '09/09/2020 12:00:00', 103) , CONVERT(datetime, '09/09/2020 12:30:00', 103))














