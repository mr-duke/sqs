# Projektdokumentation
*Dokumentation zur Projektarbeit im Fach "Software-Qualitätssicherung" an der TH Rosenheim (SoSe23) von Karl Herzog*

## Fachlicher Kontext:
Die *PokemonApp* soll es dem Nutzer ermöglichen, Basisinformationen zu allen derzeit bekannten Pokemon zu erhalten. Nach Eingabe der individuellen Nummer eines Pokemon werden sein Name, sein Bild in Form eines Sprite sowie sein Typ bzw. Typen (sofern das Pokemon zwei Typen besitzt) angezeigt. Sind die entsprechenden Daten in der angebundenen SQL-Datenbank bereits vorhanden, werden sie direkt über eine Datenbankabfrage gewonnen. Ansonsten erfolgt eine HTTP-ReST Anfrage über die öffentlich verfügbare [PokeAPI](https://pokeapi.co/) und die erhaltenen Daten in der Datenbank abgespeichert. Dadurch soll sichergestellt werden, dass im Falle des Nichtvorhandenseins der API dennoch ein Mindestmaß an positiver User Experience gegeben ist und bereits vorhandene Daten weiterhin abgerufen werden können.

## Nicht-funktionale Qualitätsanforderungen:
(Arc42, nonfunctional requirements, Qualitätseigenschaften ("-ilities"))

- **Leistung und Skalierbarkeit**: Die Anwendung soll nach Benutzereingaben eine Antwortzeit von durchschnittlich maximal 1 Sekunde einhalten, um eine angemessene Benutzererfahrung zu gewährleisten und Frustration auf Seiten der Nutzer zu verhindern.

- **Sicherheit**: Das System soll durch Prüfung der Nutzereingaben auf korrekte Datentypen oder ungültige Pokemon-NummernSicherheitsrisiken wie SQL-Injection so gut wie möglich verhindern

- **Verfügbarkeit**: Die Anwendung soll eine zuverlässige und hohe Verfügbarkeit von 99% aufweisen, um sicherzustellen, dass sie für Benutzer beinahe jederzeit verfügbar ist.

- **Wartbarkeit und Erweiterbarkeit**: Durch Schnittstellen und modularen Aufbau soll die Wartbarkeit der Anwendung gefördert werden, um diese bestmöglich aktualisieren und erweitern zu können, beispielsweise bei einer Änderung der PokeAPI, der JSON-Struktur der HTTP-Response oder dem Hinzukommen neuer Pokemon beim Erscheinen neuer Spiele. 

- **Testbarkeit**: Die Anwendung soll durch modularen Aufbau zuverlässig testbar sein und eine Testabdeckung von mind. 80% aufweisen.

- **Benutzerfreundlichkeit**: Das Nutzer-Interface soll ergonomisch gestaltet und selbsterklärend bedienbar sein. Sämliche Funktionen sollen innerhalb von maximal 2 Klicks erreichbar sein, um eine positive Benutzererfahrung zu bieten.

- **Interoperabilität und Integration**: Die Anwendung soll in der Lage sein, mit anderen Systemen und Komponenten durch APIs und Schnittstellen zu kommunizieren

- **Wirtschaftlichkeit**: Die Kosten für Entwicklung und Betrieb der Anwendung sollen durch ausschließlichen Einsatz von Open-Source-Tools minimiert werden.

- **Konformität**: Die Anwendung muss konform mit den relevanten Datenschutzgesetzen und -vorschriften sein und keinerlei persönliche Daten verarbeiten.

## Gewählter Technikstack:
- Frontend: Vue 3 mit Vite-Buildserver
- Backend: .NET 7.0
- Datenbank: PostgreSQL
- OR-Mapper: Entity Framework

## Gewählte Test-Tools
- Unit-Tests: xUnit
- Integrationstests: xUnit oder NUnit
- Akzeptanztests: SpecFlow
- UI-Tests: 
    - Selenium / Selenium WebDriver API / Kombination mit xUnit oder SpecFLow
    - CodedUI


Aufgaben: 
- Recherche zu Testframeworks
- ~~Rudimentäre Github Actions erstellen~~
    - ~~Kompiliert der Code?~~
    - ~~laufen Unittest?~~
- ~~Erste Tests bereits schreiben~~
