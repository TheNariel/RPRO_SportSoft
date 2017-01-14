<h3>UC1.1 - Ověření uživatele: Registrace zákazníka</h3>
<b>Actor</b>: Zákazník

<b>Preconditions</b>
Zákazník má zobrazenu úvodní webovou stránku.

<b>Basic Flow</b>
- 1. Zákazník vybere možnost registrovat se.
- 2. Aplikace zobrazí registrační formulář.
- 3. Zákazník vyplní registrační formulář.
- 4. Zákazník odešle formulář.
- 5. Aplikace ověří data ve formuláři.
- 6. Aplikace uloží zákazníka do databáze.
- 7. Aplikace odešle informace o registraci na e-mail zákazníka.

<b>Alternative Flow</b>
- 5a. Pokud zákazník nevyplnil všechna pole formuláře, aplikace zahlásí chybu.
- 5b. Pokud zákazník s uvedeným e-mailem již existuje, aplikace zahlásí chybu.

<h3>UC1.2 - Ověření uživatele: Přihlášení uživatele</h3>
<b>Actor</b>: Uživatel

<b>Preconditions</b>
Uživatel má zobrazenu úvodní webovou stránku.

<b>Basic Flow</b>
- 1. Uživatel zadá jméno a heslo.
- 2. Uživatel potvrdí možnost přihlášení.
- 3. Aplikace ověří uživatelské údaje.
- 4. Aplikace uživatele přihlásí.
- 5. Aplikace zobrazí stránku dle přihlášeného uživatele.

<b>Alternative Flow</b>
- 1a. Pokud uživatel zapoměl heslo, klikne na "Zapomenuté heslo", zadá svůj email a zvolí "Odeslat". Nové heslo mu bude odesláno na email.

<h3>UC1.3 - Ověření uživatele: Odhlášení uživatele</h3>
<b>Actor</b>: Uživatel

<b>Preconditions</b>
Uživatel je přihlášen a má zobrazenu jakoukoli stránku aplikace.

<b>Basic Flow</b>
- 1. Uživatel vybere možnost odhlásit se.
- 2. Aplikace uživatele odhlásí.
- 3. Aplikace zobrazí úvodní stránku.

<hr />
<h3>UC2.1 - Správa uživatelů: Reaktivace zákazníka</h3>
<b>Actor</b>: Majitel

<b>Preconditions</b>
Majitel je přihlášen a má zobrazenu úvodní webovou stránku. 

<b>Basic Flow</b>
- 1. Majitel vybere možnost správy zákazníků.
- 2. Aplikace zobrazí seznam zákazníků.
- 3. Majitel zvolí zákazníka, kterého chce reaktivovat.
- 4. Majitel potvrdí reaktivaci.
- 5. Aplikace zákazníka reaktivuje.
- 6. Aplikace zobrazí seznam zákazníků.

<b>Alternative Flow</b>
- 4a. Zvolený zákazník je aktivní, aplikace zahlásí chybu.

<h3>UC2.2 - Správa uživatelů: Deaktivace zákazníka</h3>
<b>Actor</b>: Majitel

<b>Preconditions</b>
Majitel je přihlášen a má zobrazenu úvodní webovou stránku. 

<b>Basic Flow</b>
- 1. Majitel vybere možnost správy zákazníků.
- 2. Aplikace zobrazí seznam zákazníků.
- 3. Majitel zvolí zákazníka, kterého chce deaktivovat.
- 4. Majitel potvrdí deaktivaci.
- 5. Aplikace zákazníka deaktivuje.
- 6. Aplikace zobrazí seznam zákazníků.

<b>Alternative Flow</b>
- 4a. Zvolený zákazník není aktivní, aplikace zahlásí chybu.

<h3>UC2.3 - Správa uživatelů: Změna hesla uživatele</h3>
<b>Actor</b>: Uživatel

<b>Preconditions</b>
Uživatel je přihlášen a je na úvodní stránce.

<b>Basic Flow</b>
- 1. Uživatel vybere možnost správy účtu.
- 2. Aplikace zobrazí stránku pro správu účtu.
- 3. Uživatel vybere možnost změny hesla.
- 4. Aplikace zobrazí formulář pro změnu hesla.
- 5. Uživatel vyplní staré heslo, nové heslo a potvrzení nového hesla.
- 6. Uživatel potvrdí formulář pro změnu hesla.
- 7. Aplikace ověří zadané údaje. 
- 8. Aplikace uloží zadaná data do databáze.
- 9. Aplikace zobrazí stránku pro správu účtu.

<b>Alternative Flow</b>
- 7a. Uživatel nevyplnil správně staré heslo a aplikace zahlásí chybu.
- 7b. Uživatel nevyplnil stejně obě pole pro nové heslo a aplikace zobrazí chybu.
- 7c. Uživatel nevyplnil některé z polí formuláře a aplikace zahlásí chybu.

<h3>UC2.4 - Správa uživatelů: Změna údajů uživatele</h3>
<b>Actor</b>: Uživatel

<b>Preconditions</b>
Uživatel je přihlášen a je na úvodní stránce.

<b>Basic Flow</b>
- 1. Uživatel vybere možnost správy účtu.
- 2. Aplikace zobrazí stránku pro správu účtu.
- 3. Uživatel vybere možnost změny údajů.
- 4. Aplikace zobrazí formulář pro změnu údajů s předvyplněnými údaji o uživateli.
- 5. Uživatel upraví údaje.
- 6. Uživatel potvrdí formulář pro změnu údajů.
- 7. Aplikace ověří zadané údaje. 
- 8. Aplikace uloží zadaná data do databáze.
- 9. Aplikace zobrazí stránku pro správu účtu.

<b>Alternative Flow</b>
- 7a. Uživatel nevyplnil některé z polí formuláře a aplikace zahlásí chybu.

<hr />

<h3>UC3.1 - Přehled kurtů: Zobrazení kurtu uživateli</h3>
<b>Actor</b>: Uživatel

<b>Preconditions</b>
Uživatel je přihlášen a je na úvodní stránce.

<b>Basic Flow</b>
- 1. Uživatel vybere dané sportoviště.
- 2. Aplikace zobrazí kurty pro dané sportoviště.

<h3>UC3.2 - Přehled kurtů: Zobrazení statistik majiteli</h3>
<b>Actor</b>: Majitel

<b>Preconditions</b>
Majitel je přihlášen a je na úvodní stránce.

<b>Basic Flow</b>
- 1. Majitel zvolí možnost zobrazení statistik (souhrnné - všechny kurty a jejich výdělky za určité období, nebo jednotlivé - jednotlivé kurty, přehled jejich rezervací).
- 2. Aplikace zobrazí statistiku pro všechny kurty.
- 3. Majitel může statistiky filtrovat (dle data, ceny, apod.).

<hr />

<h3>UC4.1 - Správa sportovišť: Přidání kurtu majitelem</h3>
<b>Actor</b>: Majitel

<b>Preconditions</b>
Majitel je přihlášen. Aplikace zobrazí již existující kurty dle zvoleného sportoviště.

<b>Basic Flow</b>
- 1. Majitel zvolí možnost vytvoření nového kurtu.
- 2. Aplikace zobrazí formulář pro vytvoření nového kurtu.
- 3. Majitel vyplní informace o kurtu do formuláře.
- 4. Majitel přiřadí kurtu ceník nebo vytvoří nový ceník.
- 5. Majitel potvrdí údaje.
- 6. Aplikace informace uloží.
- 7. Aplikace zobrazí seznam kurtů.

<b>Alternative FLow</b>
- 6a. Kurt se zvoleným názvem již existuje, aplikace zobrazí chybovou hlášku.

<h3>UC4.2 – Správa sportovišť: Přidání sportoviště majitelem </h3>
<b>Actor</b>: Majitel  

<b>Preconditions:</b>
Majitel je přihlášen. Aplikace zobrazí již existující sportoviště.

<b>Basic Flow:</b>
- 1. Majitel zvolí možnost vytvoření nového sportoviště.
- 2. Aplikace zobrazí formulář pro vytvoření nového sportoviště.
- 3. Majitel vyplní informace o sportovišti do formuláře.
- 4. Majitel potvrdí údaje.
- 5. Aplikace informace uloží.
- 6. Aplikace zobrazí seznam sportovišť.

<b>Alternative FLow</b>
- 5a. Sportoviště se zvoleným názvem již existuje, aplikace zobrazí chybovou hlášku.

<hr />

<h3>UC5.1 - Správa ceníků: Zobrazení ceníku majiteli</h3>
<b>Actor</b>: Majitel

<b>Preconditions</b>
Majitel je přihlášen a má zobrazenu úvodní webovou stránku. 

<b>Basic Flow</b>
- 1. Majitel vybere možnost správy ceníků.
- 2. Aplikace zobrazí seznam ceníků.

<h3>UC5.2 - Správa ceníku: Vytvoření ceníku majitelem</h3>
<b>Actor</b>: Majitel

<b>Preconditions</b>
Majitel je přihlášen a má zobrazenu úvodní stránku.

<b>Basic Flow</b>
- 1. Majitel vybere možnost správy ceníků.
- 2. Aplikace zobrazí všechny ceníky.
- 3. Majitel zvolí možnost přidání nového ceníku.
- 4. Aplikace zobrazí formulář pro vytvoření nového ceníku.
- 5. Majitel vyplní informace do formuláře.
- 6. Majitel potvrdí možnost vytvoření nového ceníku.
- 7. Aplikace informace uloží.
- 8. Aplikace zobrazí přehled ceníků.

<h3>UC5.3 - Správa ceníku: Smazání ceníku majitelem</h3>
<b>Actor</b>: Majitel

<b>Preconditions</b>
Majitel je přihlášen a má zobrazenu úvodní stránku.

<b>Basic Flow</b>
- 1. Majitel vybere možnost správy ceníků.
- 2. Aplikace zobrazí všechny ceníky.
- 3. Majitel vybere možnost smazat ceník u konkrétního ceníku.
- 4. Aplikace ověří, zda lze ceník smazat.
- 5. Aplikace smaže ceník.
- 6. Aplikace zobrazí hlášku o úspěšném smazání ceníku.
- 7. Aplikace zobrazí všechny ceníky.

<b>Alternative Flow</b>
- 4a. Ceník nelze smazat, protože je přiřazen kurtu, a aplikace zahlásí chybu.

<h3>UC5.4 - Správa ceníku: Změna ceníku</h3>
<b>Actor</b>: Majitel

<b>Preconditions</b>
Majitel je přihlášen a má zobrazenu úvodní stránku.

<b>Basic Flow</b>
- 1. Majitel vybere možnost správy ceníků.
- 2. Aplikace zobrazí všechny ceníky.
- 3. Majitel zvolí zobrazení konkrétnho ceníku.
- 4. Aplikace zobrazí informace o konkrétním ceníku.
- 5. Majitel zvolí možnost správy ceníku.
- 6. Aplikace zobrazí formulář pro správu.
- 7. Majitel upraví informace.
- 8. Majitel potvrdí uložení upraveného ceníku.
- 9. Aplikace informace uloží.
- 10. Aplikace zobrazí přehled ceníků.


<hr />

<h3>UC6.1 - Rezervace: Rezervace kurtu uživatelem</h3>
<b>Actor</b>: Uživatel

<b>Preconditions</b>
Uživatel je přihlášen a má zobrazenou úvodní stránku.

<b>Basic Flow</b>
- 1. Uživatel vybere dané sportoviště.
- 2. Aplikace zobrazí kurty pro dané sportoviště.
- 3. Uživatel zvolí datum, kdy chce kurt rezervovat.
- 4. Aplikace zobrazí obsazenost všech kurtů sportoviště pro zvolený den.
- 5. Uživatel vybere konkrétní čas pro rezervaci kurtu.
- 6. Aplikace zobrazí souhrn rezervace.
- 7. Uživatel potvrdí rezervaci.
- 8. Aplikace uloží rezervaci.
- 9. Aplikace odešle potvrzení rezervace na e-mail uživatele.
- 10. Aplikace zobrazí přehled rezervací uživatele.

<h3>UC6.2 - Rezervace: Zobrazení historie rezervací zákazníkem</h3>
<b>Actor</b>: Zákazník

<b>Preconditions</b>
Zákazník je přihlášen a má zobrazenu úvodní webovou stránku. 

<b>Basic Flow</b>
- 1. Zákazník vybere možnost zobrazení historie svých rezervací.
- 2. Aplikace zobrazí seznam zákaznikova rezervací.

<h3>UC6.3 - Rezervace: Opakovaná rezervace uživatelem</h3>
<b>Actor</b>: Uživatel

<b>Preconditions</b>
Uživatel je přihlášen a má zobrazenu úvodní webovou stránku. 

<b>Basic Flow</b>
- 1. Uživatel vybere dané sportoviště.
- 2. Aplikace zobrazí kurty pro dané sportoviště.
- 3. Uživatel zvolí den, kdy chce kurt rezervovat.
- 4. Uživatel zvolí počet týdnů opakované rezervace.
- 5. Aplikace zobrazí časy, kdy jsou kurty volné a kdy ne(s odůvodněním, proč jsou obsazené).
- 5. Uživatel vybere kurt.
- 6. Uživatel potvrdí rezervaci.
- 7. Aplikace uloží rezervaci.
- 8. Aplikace odešle potvrzení rezevací na e-mail uživatele.
- 9. Aplikace zobrazí přehled rezervací uživatele.

<h3>UC6.4 - Rezervace: Zrušení rezervace zákazníkem</h3>
<b>Actor</b>: Zákazník

<b>Preconditions</b>
Zákazník je přihlášen a má zobrazenu úvodní webovou stránku. 

<b>Basic Flow</b>
- 1. Zákazník zvolí možnost zobrazení historie rezervací.
- 2. Aplikace zobrazí zákazníkovy rezervace.
- 3. Zákazník zvolí rezervaci, kterou chce zrušit.
- 4. Zákazník potvrdí zrušení rezervace.
- 5. Aplikace zruší rezervaci.
- 6. Aplikace odešle potvrzení o zrušení rezevace na e-mail zákazníka.
- 7. Aplikace zobrazí přehled rezervací zákazníka.

<b>Alternative Flow</b>
- 4a. Zvolená rezervace již nejde zrušit, aplikace zobrazí chybovou hlášku.

<h3>UC6.5 - Rezervace: Zrušení rezervace majtelem</h3>
<b>Actor</b>: Majitel

<b>Preconditions</b>
Majitel je přihlášen a má zobrazenu úvodní webovou stránku. 

<b>Basic Flow</b>
- 1. Majitel zvolí možnost zobrazení historie rezervací.
- 2. Aplikace zobrazí uživatelové rezervace.
- 3. Majitel zvolí rezervaci, kterou chce zrušit.
- 4. Majitel potvrdí zrušení rezervace.
- 5. Aplikace zruší rezervaci.
- 6. Aplikace odešle potvrzení o zrušení rezevace na e-mail zákazníka.
- 7. Aplikace zobrazí přehled rezervací.

