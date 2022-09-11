CREATE database projcole
drop database projcole
CREATE TABLE Niveau (codeNiveau VARCHAR(50) PRIMARY KEY, nomNiveau VARCHAR(50), Frais_Inscription VARCHAR(50))-- ; Technicien , Technicien Sp�cialis�, Sp�cialisation, Qualification 
CREATE TABLE Secteur (CodeSecteur VARCHAR(50) PRIMARY KEY, nomSecteur VARCHAR(50)) --; Tertiaire, NTIC, Industriel,�
CREATE TABLE Fili�re (codeF VARCHAR(50) PRIMARY KEY, nomFiliere VARCHAR(50), codeNiveau VARCHAR(50) FOREIGN KEY  REFERENCES Niveau(codeNiveau) , CodeSecteur VARCHAR(50) FOREIGN KEY  REFERENCES Secteur(CodeSecteur)) 
CREATE TABLE Classe (codeC VARCHAR(50) PRIMARY KEY, nom_classe VARCHAR(50), codefili�re VARCHAR(50) FOREIGN KEY  REFERENCES Fili�re(codeF)) 
CREATE TABLE Mati�re (codeM VARCHAR(50) PRIMARY KEY, nom_Mat VARCHAR(50), Nombreheure  int, codeFili VARCHAR(50) FOREIGN KEY  REFERENCES Fili�re(codeF))
CREATE TABLE Enseignant (codeEns VARCHAR(50) PRIMARY KEY, nom VARCHAR(50), pr�nom VARCHAR(50), adresse VARCHAR(50), date_de_naissance date, dipl�me VARCHAR(50), grade VARCHAR(50), date_embauche date,CNE VARCHAR(50), sp�cialit� VARCHAR(50), tel VARCHAR(50), email VARCHAR(50), Login VARCHAR(50) foreign key references Comptes(Login), Mot_de_passe VARCHAR(50))
CREATE TABLE Etudiant (NumInscription int PRIMARY KEY, nom VARCHAR(50), pr�nom VARCHAR(50), adresse VARCHAR(50),CNI VARCHAR(50),CNE VARCHAR(50),date_de_naissance date, dipl�me VARCHAR(50), tel VARCHAR(50), email VARCHAR(50), Login VARCHAR(50) foreign key references Comptes(Login),Mot_de_passe VARCHAR(50))
CREATE TABLE Inscription (NumInscription INT foreign key references Etudiant(NumInscription) ,codeClasse VARCHAR(50) foreign key references Classe(codec),DateInscription date,primary key (NumInscription,codeClasse))
CREATE TABLE Affectation (codeEns  VARCHAR(50) foreign key references Enseignant(codeEns), codeM  VARCHAR(50)foreign key references Mati�re(codeM),codeC VARCHAR(50) foreign key references Classe(codec), dateAffactation date,primary key (codeEns,codeM,codeC))
CREATE TABLE Absence (NumInscription int foreign key references Etudiant(NumInscription),codeM VARCHAR(50)foreign key references Mati�re(codeM), dateAbsence date, Nombreheure int,primary key (NumInscription,codeM))
CREATE TABLE Comptes(Login VARCHAR(50) PRIMARY KEY, Mot_de_passe VARCHAR(50))




CREATE TABLE Cr�er une table compte( code_User, Login, mot_de_passe , Type_User)

alter table Niveau add constraint nomNiveau ('Technicien ', 'Technicien Sp�cialis�', 'Sp�cialisation', 'Qualification') check ()
select * from Niveau

SELECT Mati�re.* FROM Mati�re INNER JOIN Fili�re ON Mati�re.codeFili = Fili�re.codeF WHERE (Fili�re.codeF = 'g')
select * from Absence where Absence.NumInscription=

select Mati�re.codeM,Mati�re.nom_Mat,Mati�re.Nombreheure,Fili�re.nomFiliere from Mati�re,Fili�re where Fili�re.codeF=Mati�re.codeFili

select count(CodeSecteur) from Secteur where CodeSecteur='d'

select distinct  Etudiant.NumInscription, Etudiant.nom, Etudiant.pr�nom, Etudiant.adresse, Etudiant.date_de_naissance, Etudiant.dipl�me, Etudiant.email, Etudiant.tel from Notes,Secteur,Fili�re,Classe,Etudiant,Inscription where Notes.CodeSecteur=Secteur.CodeSecteur and Notes.codeF=Fili�re.codeF and Notes.code_Classe=Classe.codec and Notes.NumInscription=Etudiant.NumInscription and Classe.nom_classe=


select distinct Notes.CodeNote as [Code],secteur.nomSecteur as [Secteur],Fili�re.nomFiliere as [Filiere],Classe.nom_classe as [Classe],Etudiant.nom+' '+Etudiant.pr�nom as [Nom Complete],Notes.NoteAnnee as [La Note Annuelle],Notes.NotePassage as [La Note de Passage],Notes.NoteEpreuve as [Note du Fin Formation],Notes.Notegeneral as [Moyenne g�n�rale] from Notes,Secteur,Fili�re,Classe,Etudiant,Inscription where Notes.CodeSecteur=Secteur.CodeSecteur and Notes.codeF=Fili�re.codeF and Notes.code_Classe=Classe.codec and Notes.NumInscription=Etudiant.NumInscription AND Etudiant.Login="Session("username")"

ALTER PROCEDURE P2 @CodeC INT
AS
begin

select distinct  Etudiant.NumInscription, Etudiant.nom, Etudiant.pr�nom, Etudiant.adresse, Etudiant.date_de_naissance, Etudiant.dipl�me, Etudiant.email, Etudiant.tel from Notes,Secteur,Fili�re,Classe,Etudiant,Inscription where Notes.CodeSecteur=Secteur.CodeSecteur and Notes.codeF=Fili�re.codeF and Notes.code_Classe=Classe.codec and Notes.NumInscription=Etudiant.NumInscription and Classe.codeC=@CodeC
end

CREATE PROCEDURE P3 
AS
begin
select distinct  Enseignant.codeEns, Enseignant.nom, Enseignant.pr�nom, Enseignant.adresse, Enseignant.date_de_naissance, Enseignant.dipl�me, Enseignant.email,Enseignant.date_embauche, Enseignant.tel from Enseignant 
END

CREATE PROCEDURE P4
AS
begin
select * FROM Fili�re
END
