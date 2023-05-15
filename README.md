# Projektdokumentation
*Dokumentation zur Projektarbeit im Fach "Software-Qualitätssicherung" an der TH Rosenheim (SoSe23) von Karl Herzog*
Der Aufbau dieser Dokumentation orientiert sich am offiziellen [Arc42-Template](https://docs.arc42.org/home/)

## Kapitel 1: Einleitung
### Fachliche Anforderungen
Die *PokemonApp* soll es dem Nutzer ermöglichen, Basisinformationen zu allen derzeit bekannten Pokemon zu erhalten. Nach Eingabe der individuellen Nummer eines Pokemon werden sein Name, sein Bild in Form eines Sprite sowie sein Typ bzw. Typen (sofern das Pokemon zwei Typen besitzt) angezeigt. Sind die entsprechenden Daten in der angebundenen SQL-Datenbank bereits vorhanden, werden sie direkt über eine Datenbankabfrage gewonnen. Ansonsten erfolgt eine HTTP-ReST Anfrage über die öffentlich verfügbare [PokeAPI](https://pokeapi.co/) und die erhaltenen Daten in der Datenbank abgespeichert. Dadurch soll sichergestellt werden, dass im Falle des Nichtvorhandenseins der API dennoch ein Mindestmaß an positiver User Experience gegeben ist und bereits vorhandene Daten weiterhin abgerufen werden können.
### Qualitätsziele
Die relevanten Qulaitätsziele werden in Kapitel 10 im Details erläutert.
### Stakeholder
Stakeholder des Projekts sind die Studenten sowie der Dozent im Fach "Software-Qualitätssicherung" an der TH Rosenheim.

## Kapitel 2: Beschränkungen
Bekannte, nicht veränderbare Beschränkungen sind die Vorgaben des Dozenten zur Grundstruktur des Projekts. Dieses soll aus folgenden Elementen bestehen:
- Frontend
- Backend
- Datenbank
- Externe REST-API

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
- Lasttest:
    - K6
    - (Apache JMeter)
- Security:
    - OWAP ZAP
    - Dependency Check
    - (Dependa-bot)

## Geplanter Aufbau: (Orientieren am Arc42 - Framework: docs.arc42.org)
- Prerequisites:
    - Node
    - .Net 7
    - PostgreSQL
- Fachlicher Kontext
- Third Party Libraries, Schnittstellen (API-Dokumentation)
- Architekturentscheidungen (evtl. mit Bild)
- Tests
    - Unit Test: JUnit, Mockito
    - Architektur Test: Arch Unit
    - Integration Test: RestAssured, Test Containers, WireMock/Hoverfly
    - E2E + UI Tests: Cypress (+Mocha), Selenium (+Junit), Cucumber(BDD), Geb
    - Last Performance Test: 
        - Test Setup Architecture
            - CI-based    
            - In-Cluster
            - Dedicated
        - Frameworks: K6(!), Gatling, JMeter, Locust
    - Security Tests
        - Statische Analyse 
            - Sonar / Sonarcloud
            - Test Coverage
            - Zero-Violation-Policy
        - DependaBot (Github Action verfügbar)
        - OWASP Dependency Check
        - IaC Security (Terraform, Dockerfile, k8s): Snyk, Aqua
        - ZED Attack Proxy
         



Aufgaben: 
- Recherche zu Testframeworks
- ~~Rudimentäre Github Actions erstellen~~
    - ~~Kompiliert der Code?~~
    - ~~laufen Unittest?~~
- ~~Erste Tests bereits schreiben~~
- Lasttest für die API schreiben
- Security-Test schreiben
    - Dependency Check (per GitHub Action)
    - (evtl. Versionen autmoatisch aktualisieren lassen per Github Action)
    - Mit OWASP ZAP testen
