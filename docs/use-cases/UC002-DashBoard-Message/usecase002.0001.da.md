## Metadata
| Key               | Value                             |
|-------------------|-----------------------------------|
| Id                | UC-002                            |
| crossReference    | BC                                  |

## Version Log
| Version | Date       | Description              | Author     |
|---------|------------|--------------------------|------------|
| 0001    | 2026-03-06 | Initial                  | Team 6 |

## Use Case Description

## User story
Som medarbejder vil jeg kunne se aktuelle beskeder om beboerne på tavlen/skærmen, tilføje en besked på en beboer, rette/redigere en eksisterende besked på en beboer, og slette en nuværende besked på en beboer, så beskederne altid er opdaterede og relevante.

### Brief Use Case
**Use Case Number**: UC-002
**Title**: Håndtering af beskeder på beboer
**Success Flow**:
Medarbejder vælger en beboer. Systemet viser aktuelle beskeder. Medarbejder tilføjer, retter eller sletter en besked på en beboer efter behov.

### Casual Use Case
**Use Case Number**: UC-002
**Title**: Håndtering af beskeder på beboer
**Actors**:
- Medarbejder
- System
**Summary**: Medarbejder håndterer beskeder om beboere på tavlen/skærmen.
**Preconditions**:
- Medarbejder er logget ind
- Beboer eksisterer i systemet
**Main Flow**:
1. Medarbejder vælger en beboer 
2. Systemet viser aktuelle beskeder for beboeren
3. Medarbejder tilføjer besked
4. Medarbejder retter besked  
5. Medarbejder sletter besked 
**Main Exceptions**:
3.a Besked kan ikke gemmes – Medarbejder får fejlmeddelelse
4.a Besked kan ikke gemmes – Medarbejder får fejlmeddelelse
**Postconditions**:
- Beskeder er opdateret og synlige
- Slettede beskeder eksisterer ikke længere

### Fully Dressed Use Case
**Use Case Number**: UC-002
**Title**: Beskeder på beboer-dashboard
**Actors**:
- Medarbejder
- System
**Related Requirements**:
- Beskeder skal kunne oprettes, redigeres og slettes
- Beskeder skal vises på tavlen/skærmen
**Preconditions**:
- Medarbejder er logget ind
- Beboer eksisterer i systemet
**Main Flow**:
1. Medarbejder vælger beboer
2. System viser aktuelle beskeder
3. Medarbejder tilføjer en besked
4. Medarbejder redigerer en besked
5. Medarbejder sletter en besked
**Alternate Flows**:
2.1 Ingen beskeder – system viser tom liste
2.2 Flere beskeder – system viser alle beskeder
**Exceptions**:
1.a Beboer findes ikke – system viser fejl
2.2.a Besked kan ikke vises – system viser fejl
3.a Besked kan ikke gemmes – system viser fejl
**Postconditions**:
- Beskeder er opdateret og synlige
- Slettede beskeder eksisterer ikke længere
