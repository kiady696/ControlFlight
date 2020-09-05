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

--

INSERT INTO [dbo].[Avion] ([Id_Avion], [Id_Modele], [Nom_Avion]) VALUES ('A1', 'M1' , 'A380')

INSERT INTO [dbo].[Avion] ([Id_Avion], [Id_Modele], [Nom_Avion]) VALUES ('A2', 'M2' , 'B747')

--

INSERT INTO [dbo].[Modele] ([Id_Model], [Designation_Modele], [Besoin_Decollage] ,[Besoin_Atterrissage] , [Longueur_Modele]) VALUES ('M1', 'A300' , 300 , 400 , 25)

INSERT INTO [dbo].[Modele] ([Id_Model], [Designation_Modele], [Besoin_Decollage] ,[Besoin_Atterrissage] , [Longueur_Modele]) VALUES ('M2', 'B700' , 500 , 600 , 30)

--

INSERT INTO [dbo].[Piste] ([Id_Piste], [Id_Aeroport], [Num_Piste] , [Longueur] , [Temps_Degagement]) VALUES ('P1', 'AE3' , '1' , '1000' , 0.5)
INSERT INTO [dbo].[Piste] ([Id_Piste], [Id_Aeroport], [Num_Piste] , [Longueur] , [Temps_Degagement]) VALUES ('P2', 'AE3' , '2' , '500' , 1)
INSERT INTO [dbo].[Piste] ([Id_Piste], [Id_Aeroport], [Num_Piste] , [Longueur] , [Temps_Degagement]) VALUES ('P3', 'AE3' , '3' , '350' , 0.5)
INSERT INTO [dbo].[Piste] ([Id_Piste], [Id_Aeroport], [Num_Piste] , [Longueur] , [Temps_Degagement]) VALUES ('P4', 'AE3' , '4' , '800' , 0.25)

















