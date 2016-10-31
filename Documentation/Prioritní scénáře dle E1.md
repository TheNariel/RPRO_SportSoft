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

<h3>UC3 - Přehled kurtů: Zobrazení kurtu uživateli</h3>
<b>Actor</b>: Majitel, zákazník

<b>Preconditions</b>
Uživatel je přihlášen a je na úvodní stránce.

<b>Basic Flow</b>
- 1. Uživatel vybere dané sportoviště.
- 2. Aplikace zobrazí kurty pro dané sportoviště.

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

<h3>UC5 - Správa ceníku: Změna majitelem</h3>
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
- 8. Majitel potvrdí možnost uložení upraveného ceníku.
- 9. Aplikace informace uloží.
- 10. Aplikace zobrazí přehled ceníků.

<h3>UC6 - Rezervace: Rezervace kurtu uživatelem</h3>
<b>Actor</b>: Majitel, zákazník

<b>Preconditions</b>
Uživatel je přihlášen a má zobrazeny kurty dle zvoleného sportoviště.

<b>Basic Flow</b>
- 1. Uživatel zvolí čas, který chce rezervovat.
- 2. Uživatel vybere kurt.
- 3. Uživatel potvrdí rezervaci.
- 4. Aplikace uloží rezervaci.
- 5. Aplikace odešle potvrzení rezervace na e-mail uživatele.
- 6. Aplikace zobrazí přehled rezervací uživatele.
