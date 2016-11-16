<h3>UC1 - Ověření uživatele: Registrace zákazníka</h3>
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
- 5a. Pokud uživatel nevyplnil všechna pole formuláře, aplikace zahlásí chybu.
- 5b. Pokud uživatel s uvedeným e-mailem již existuje, aplikace zahlásí chybu.

<h3>UC1 - Ověření uživatele: Přihlášení uživatele</h3>
<b>Actor</b>: Majitel, zákazník

<b>Preconditions</b>
Uživatel má zobrazenu úvodní webovou stránku.

<b>Basic Flow</b>
- 1. Uživatel zadá jméno a heslo.
- 2. Uživatel potvrdí možnost přihlášení.
- 3. Aplikace ověří uživatelské údaje.
- 4. Aplikace uživatele přihlásí.
- 5. Aplikace zobrazí stránku dle přihlášeného uživatele.

<h3>UC1 - Ověření uživatele: Odhlášení uživatele</h3>
<b>Actor</b>: Majitel, zákazník

<b>Preconditions</b>
Uživatel je přihlášen a má zobrazenu jakoukoli stránku aplikace.

<b>Basic Flow</b>
- 1. Uživatel vybere možnost odhlásit se.
- 2. Aplikace uživatele odhlásí.
- 3. Aplikace zobrazí úvodní stránku.

<hr />

<h3>UC2 - Správa uživatelů: Změna hesla uživatele</h3>
<b>Actor</b>: Majitel, zákazník

<b>Preconditions</b>
Uživatel je přihlášen a je na úvodní stránce.

<b>Basic Flow</b>
- 1. Uživatel vybere možnost správy účtu.
- 2. Aplikace zobrazí stránku pro správu účtu.
- 3. Uživatele vybere možnost změny hesla.
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

<h3>UC2 - Správa uživatelů: Změna údajů uživatele</h3>
<b>Actor</b>: Majitel, zákazník

<b>Preconditions</b>
Uživatel je přihlášen a je na úvodní stránce.

<b>Basic Flow</b>
- 1. Uživatel vybere možnost správy účtu.
- 2. Aplikace zobrazí stránku pro správu účtu.
- 3. Uživatele vybere možnost změny údajů.
- 4. Aplikace zobrazí formulář pro změnu údajů s předvyplněnými údaji o uživateli.
- 5. Uživatel upraví údaje.
- 6. Uživatel potvrdí formulář pro změnu údajů.
- 7. Aplikace ověří zadané údaje. 
- 8. Aplikace uloží zadaná data do databáze.
- 9. Aplikace zobrazí stránku pro správu účtu.

<b>Alternative Flow</b>
- 7a. Uživatel nevyplnil některé z polí formuláře a aplikace zahlásí chybu.

<hr />

<h3>UC3 - Přehled kurtů: Zobrazení kurtu uživateli</h3>
<b>Actor</b>: Majitel, zákazník

<b>Preconditions</b>
Uživatel je přihlášen a je na úvodní stránce.

<b>Basic Flow</b>
- 1. Uživatel vybere dané sportoviště.
- 2. Aplikace zobrazí kurty pro dané sportoviště.

<h3>UC3 - Přehled kurtů: Zobrazení statistik majiteli</h3>
<b>Actor</b>: Majitel

<b>Preconditions</b>
Majitel je přihlášen a je na úvodní stránce.

<b>Basic Flow</b>
- 1. Majitel zvolí možnost zobrazení statistik.
- 2. Aplikace zobrazí statistiku pro všechny kurty.

<hr />

<h3>UC4 - Správa sportovišť: Přidání kurtu majitelem</h3>
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

<h3>UC4 – Správa sportovišť: Přidání sportoviště majitelem </h3>
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

<hr />

<h3>UC5 - Správa ceníku: Vytvoření ceníku majitelem</h3>
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

<h3>UC5 - Správa ceníku: Smazání ceníku majitelem</h3>
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

<h3>UC5 - Správa ceníku: Změna ceníku</h3>
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

<h3>UC6 - Rezervace: Rezervace kurtu uživatelem</h3>
<b>Actor</b>: Majitel, zákazník

<b>Preconditions</b>
Uživatel je přihlášen a má zobrazenou úvodní stránku.

<b>Basic Flow</b>
- 1. Uživatel vybere dané sportoviště.
- 2. Aplikace zobrazí kurty pro dané sportoviště.
- 3. Uživatel zvolí čas, který chce rezervovat.
- 4. Uživatel vybere kurt.
- 5. Uživatel potvrdí rezervaci.
- 6. Aplikace uloží rezervaci.
- 7. Aplikace odešle potvrzení rezervace na e-mail uživatele.
- 8. Aplikace zobrazí přehled rezervací uživatele.
