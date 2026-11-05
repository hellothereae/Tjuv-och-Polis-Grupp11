# Police & Thief

## Projektbeskrivning

Police & Thief är en konsolapplikation som simulerar en stad där medborgare, tjuvar och poliser rör sig och interagerar med varandra.

## Funktioner

- **Stad:** Medborgare, tjuvar och poliser rör sig automatiskt i olika riktningar.
- **Rån:** Tjuvar kan råna medborgare och ta deras pengar.
- **Gripanden:** Poliser kan gripa tjuvar som har stulna pengar.
- **Fängelse:** Gripna tjuvar placeras i fängelse och släpps efter en viss tid.
- **Fattighus:** Medborgare som förlorar alla sina pengar hamnar i fattighuset och kan få ekonomisk hjälp.
- **Statistik:** Visar information om rån, gripanden och ekonomin i staden.
- **Händelselogg:** Visar viktiga händelser i staden.

## Projektstruktur

| Klass | Ansvar |
|---|---|
| **Program** | Startar och styr simuleringen |
| **Person** | Basklass för personerna |
| **Citizen** | Representerar en medborgare |
| **Thief** | Representerar en tjuv |
| **Police** | Representerar en polis |
| **City** | Hanterar stadens utseende |
| **Movement** | Hanterar personernas rörelser |
| **Meetings** | Hanterar möten mellan personer |
| **Prison** | Hanterar fängelset |
| **PoorHouse** | Hanterar fattighuset |
| **Inventory** | Visar statistik och ekonomisk information |
| **EventLog** | Visar händelser i realtid |
| **AddPersons** | Lägger till nya personer |
| **Keys** | Styr programmets funktioner via tangentbordet. |
| **،ثغس** | Basklass för olika platser |
