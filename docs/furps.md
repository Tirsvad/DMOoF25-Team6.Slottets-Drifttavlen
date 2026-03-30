# FURPS+ 
FURPS+ is a model for classifying software quality attributes.
The acronym stands for Functionality, Usability, Reliability, Performance, and Supportability, with the "+" indicating additional considerations such as design constraints, implementation requirements, interface requirements, and physical requirements.

## Metadata
| Key               | Value                             |
|-------------------|-----------------------------------|
| Id                | FURPS	                            |
| crossReference    |                                   |

## Version
- **Version**: 0001
- **Date**: 2026-02-07

### Change Log
| Date       | Version | Description                     | Author        |
|------------|---------|---------------------------------|---------------|
| 2026-02-07 | 0001    | Initial creation of the document |               |

---

## FURPS+ for Slottet – Digital Overlap System

### Functionality
- Digitalt overlapsskema med borgerfelter, trafiklysmodel, medicinstatus, opgaver og beskeder.
- Understøttelse af både Skoven og Slottet afdelinger med mulighed for separat og samlet visning.
- Brugerroller: plejepersonale, vagtansvarlige, ledere/koordinatorer, admin.
- Differentierede brugerrettigheder (almindelige medarbejdere vs. ledere/koordinatorer).
- Adgangskontrol og login (hurtigt login, minimumskrav til kodeord, initialer/e-mail som brugernavn).
- Historik og sporbarhed for alle overlaps og ændringer (audit trail: hvem har skrevet/redigeret hvad og hvornår).
- Markering af sene/tilbagevirkende indtastninger med korrekt tidsstempel.
- Hurtig og nem markering af medicin og risikovurdering (trafiklys-system).
- Integration med FMK og notifikationssystem (udvidelse).

### Usability
- Intuitiv brugergrænseflade tilpasset travle vagtskifter og alle medarbejdertyper (inkl. vikarer og nyansatte).
- Klart visuelt overblik over borgerstatus og opgaver.
- Responsivt design til tablets, PC og arbejdstelefoner (mobile enheder).
- Hurtig navigation og let aflæsning af kritisk information.
- Hurtig og nem login-proces.
- Mulighed for løbende og efterfølgende dokumentation, med tydelig markering af sene indtastninger.

### Reliability
- Høj tilgængelighed og failover (cloud-ready, lokal og netværksdrift).
- Automatisk backup og versionering af data.
- Audit-log for alle ændringer og brugerhandlinger.
- Robust håndtering af netværks- og strømudfald.

### Performance
- Hurtig indlæsning og opdatering af borgerdata.
- Skalerbar løsning (horisontal skalering, flere instanser).
- Effektiv håndtering af samtidige brugere ved vagtskifte.

### Supportability
- Omfattende brugerdokumentation og træning.
- Ticketing-system og supportfunktion.
- Let opdatering og vedligeholdelse af systemet.

### + (Design Constraints, Implementation, Interface, Physical)
- GDPR-compliance og sikker behandling af persondata.
- Containerisering via Docker, cloud-ready arkitektur.
- API til integration med eksterne systemer.
- Central konfiguration via miljøvariabler og secrets.
- Ingen bindinger til lokalt filsystem, fast server eller IP.
