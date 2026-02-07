# Risikoanalyse
Denne risikoanalyse opsummerer hovedrisici for projektet opdelt efter kategori. Hver risiko har et entydigt ID, en vurdering af sandsynlighed (1-5), alvorlighed (1-5), en beregnet risikoscore (Likelihood × Severity) og anbefalede afhjælpende tiltag.

## Risikoniveau (legend)
| Score | Niveau |
|---:|---|
|15–25 | Kritisk |
|10–14 | Høj |
|5–9 | Moderat |
|1–4 | Lav |

---

## 1) Tekniske risici
Tekniske risici omfatter problemer i systemets arkitektur, kode eller infrastruktur (fx sikkerhedssårbarheder, afhængigheder og databaseforbindelser), som kan føre til datatab, nedetid eller kompromitteret integritet.
### Risiko
| ID | Risiko | Beskrivelse |
|---|---|---|
| R-RT-001 | Sikkerhedssårbarheder | Potentiel risiko for SQL-injektion, XSS m.fl. |
| R-RT-002 | Databrud | Uautoriseret adgang pga. svag autentifikation eller sessionsstyring |
| R-RT-003 | Afhængighed | Sårbarheder i tredjepartsbiblioteker eller frameworks |
| R-RT-004 | Databaseforbindelsesproblemer | Potentiale for nedetid eller ydeevneproblemer, især ved tunneling |

### Risikoniveau
| ID | Likelihood (1-5) | Severity (1-5) | Score | Risiko-niveau |
|---|:---:|:---:|:---:|---|
| R-RT-001 |4 |5 |20 | Kritisk |
| R-RT-002 |4 |4 |16 | Høj |
| R-RT-003 |3 |3 |9 | Moderat |
| R-RT-004 |2 |2 |4 | Lav |

### Mitigation
<table border="1" width="100%" style="border-collapse: collapse;">
  <tr><th>ID</th><th>Mitigation</th></tr>
  <tr><td>R-RT-001</td><td><ul>
    <li>Brug parameteriserede forespørgsler/ORM</li>
    <li>Inputvalidering</li>
    <li>Content Security Policy</li>
    <li>Sikkerhedstest (SAST/DAST)</li>
  </ul></td></tr>
  <tr><td>R-RT-002</td><td><ul>
    <li>Implementer stærkere autentifikation</li>
    <li>Overvågning af adgangslogfiler</li>
    <li>Regelmæssige sikkerhedsrevisioner</li>
  </ul></td></tr>
  <tr><td>R-RT-003</td><td><ul>
    <li>Hold afhængigheder opdaterede</li>
    <li>Brug værktøjer til at scanne for sårbarheder</li>
    <li>Anvend sikkerhedsforanstaltninger i kode</li>
  </ul></td></tr>
  <tr><td>R-RT-004</td><td><ul>
    <li>Overvåg databaseforbindelser</li>
    <li>Implementer timeout og genopret mekanismer</li>
    <li>Brug connection pooling</li>
  </ul></td></tr>
</table>

---

## 2) Operationelle risici
Operationelle risici vedrører interne processer, personale og driftsprocedurer (fx dårlig UI/UX, mangelfuld dokumentation eller utilstrækkelig support), som kan påvirke adoption, kvalitet og leverancer.

### Risiko
| ID | Risiko | Beskrivelse |
|---|---|---|
| R-RO-001 | Brugeroplevelse | Dårligt UI/UX kan føre til lav adoption |
| R-RO-002 | Dokumentation | Mangelfuld dokumentation kan skabe forvirring og fejl |
| R-RO-003 | Support | Utilstrækkelig support kan føre til utilfredse brugere |

### Risikoniveau
| ID | Likelihood (1-5) | Severity (1-5) | Score | Risiko-niveau |
|---|:---:|:---:|:---:|---|
| R-RO-001 |3 |3 |9 | Moderat |
| R-RO-002 |2 |4 |8 | Moderat |
| R-RO-003 |2 |3 |6 | Moderat |

### Mitigation
<table border="1" width="100%" style="border-collapse: collapse;">
  <tr><th>ID</th><th>Mitigation</th></tr>
  <tr><td>R-RO-001</td><td><ul>
    <li>Involver brugere i designprocessen</li>
    <li>Udfør brugertests</li>
    <li>Iterer på UI/UX baseret på feedback</li>
  </ul></td></tr>
  <tr><td>R-RO-002</td><td><ul>
    <li>Udarbejd omfattende dokumentation</li>
    <li>Opdater løbende</li>
    <li>Gør dokumentationen let tilgængelig for brugere og udviklere</li>
  </ul></td></tr>
  <tr><td>R-RO-003</td><td><ul>
    <li>Tilbyd et dedikeret supportteam</li>
    <li>Implementer en ticketing-system</li>
    <li>Tilbyd træning og ressourcer til brugere</li>
  </ul></td></tr>
</table>

---

## 3) Projektledelsesrisici
Projektledelsesrisici omfatter faktorer som tidsplanoverskridelser, budgetoverskridelser og ressourceallokering, som kan påvirke projektets succes.
### Risiko
| ID | Risiko | Beskrivelse |
|---|---|---|
| R-PM-001 | Tidsplanoverskridelser | Forsinkelser i projektleverancer |
| R-PM-002 | Budgetoverskridelser | Uventede omkostninger, der overskrider budgettet |
| R-PM-003 | Ressourceallokering | Utilstrækkelige ressourcer til at fuldføre opgaver |
| R-PM-004 | Sygdom/manglende kompetence | Nøglepersoner bliver syge eller mangler nødvendige kompetencer, hvilket kan forsinke projektet eller påvirke kvaliteten |

### Risikoniveau
| ID | Likelihood (1-5) | Severity (1-5) | Score | Risiko-niveau |
|---|:---:|:---:|:---:|---|
| R-PM-001 |3 |4 |12 | Høj |
| R-PM-002 |2 |5 |10 | Høj |
| R-PM-003 |3 |3 |9 | Moderat |
| R-PM-004 |2 |4 |8 | Moderat |

### Mitigation
| ID | Mitigation |
|---|---|
| R-PM-001 | Opret realistiske tidsplaner, overvåg fremskridt regelmæssigt, juster planer efter behov. |
| R-PM-002 | Opret et detaljeret budget, overvåg omkostninger løbende, identificer potentielle besparelser. |
| R-PM-003 | Sørg for tilstrækkelige ressourcer, omfordel efter behov, ansæt midlertidigt personale ved spidsbelastninger. |
| R-PM-004 | Sørg for backup-ressourcer, kompetenceudvikling, vidensdeling til kollegaer, god kode og dokumentation, fleksibel ressourceallokering. |

---

## 4) Eksterne risici
Eksterne risici inkluderer faktorer uden for projektets kontrol, såsom ændringer i lovgivning, markedsforhold eller leverandørproblemer.

### Risiko
| ID | Risiko | Beskrivelse |
|---|---|---|
| R-EX-001 | Lovgivningsændringer | Nye regler, der påvirker projektets gennemførelse |
| R-EX-002 | Markedsforhold | Ændringer i markedet, der påvirker projektets relevans |
| R-EX-003 | Leverandørproblemer | Forsinkelser eller problemer med tredjepartsleverandører |

### Risikoniveau
| ID | Likelihood (1-5) | Severity (1-5) | Score | Risiko-niveau |
|---|:---:|:---:|:---:|---|
| R-EX-001 |2 |4 |8 | Moderat |
| R-EX-002 |3 |3 |9 | Moderat |
| R-EX-003 |2 |3 |6 | Moderat |

### Mitigation
<table border="1" width="100%" style="border-collapse: collapse;">
  <tr><th>ID</th><th>Mitigation</th></tr>
  <tr><td>R-EX-001</td><td><ul>
    <li>Hold dig opdateret om lovgivningsændringer</li>
    <li>Konsulter juridiske eksperter</li>
    <li>Tilpas projektplaner efter behov</li>
  </ul></td></tr>
  <tr><td>R-EX-002</td><td><ul>
    <li>Overvåg markedstendenser</li>
    <li>Juster projektets fokus for at forblive relevant</li>
    <li>Involver interessenter</li>
  </ul></td></tr>
  <tr><td>R-EX-003</td><td><ul>
    <li>Vælg pålidelige leverandører</li>
    <li>Opret backup-planer</li>
    <li>Overvåg leverandørpræstationer løbende</li>
  </ul></td></tr>
</table>
