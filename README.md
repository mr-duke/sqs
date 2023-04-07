# Projektdokumentation
*Dokumentation zur Projektarbeit im Fach "Software-Qualitätssicherung" an der TH Rosenheim (SoSe23) von Karl Herzog*

## Fachlicher Kontext:
Die *PokemonAPP* soll es dem Nutzer ermöglichen, Basisinformationen zu allen derzeit bekannten Pokemon zu erhalten. Nach Eingabe der individuellen Nummer eines Pokemon werden sein Name, sein Bild in Form eines Sprite sowie sein Typ bzw. Typen (sofern das Pokemon zwei Typen besitzt) angezeigt. Sind die entsprechenden Daten in der angebundenen SQL-Datenbank bereits vorhanden, werden sie direkt über eine Datenbankabfrage gewonnen. Ansonsten erfolgt eine HTTP-ReST Anfrage über die öffentlich verfügbare [PokeAPI](https://pokeapi.co/) und die erhaltenen Daten in der Datenbank abgespeichert. Dadurch soll sichergestellt werden, dass im Falle des Nichtvorhandenseins der API dennoch ein Mindestmaß an positiver User Experience gegeben ist und bereits vorhandene Daten weiterhin abgerufen werden können.

Arc42, nonfunctional requirements, Qualitätseigenschaften ("-ilities"):

## Gewählter Technikstack:
- Frontend: Vue 3 mit Vite-Buildserver
- Backend: .NET 7.0
- Datenbank: PostgreSQL
- OR-Mapper: Entity Framework

Toolauswahl für Unit-, Integrations-, Akzeptanz- (SpecFlow), und UI- (CodedUI, Selenium for .Net) Tests:


Aufgaben: 
- Recherche zu Testframeworks
- Rudimentäre Github Actions erstellen
    - Kompiliert der Code?
    - laufen Unittest?
- Erste Tests bereits schreiben
