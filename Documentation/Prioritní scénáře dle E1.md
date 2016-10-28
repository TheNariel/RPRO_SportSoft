<h3>UC1 - Ověření uživatele: Přihlášení uživatele</h3>
<b>Actor</b>: Majitel, zákazník

<b>Preconditions</b>
Uživatel je má zobrazenu úvodní webovou stránku.

<b>Basic Flow</b>
- 1. Uživatel zadá jméno a heslo.
- 2. Uživatel potvrdí možnost přihlášení.
- 3. Aplikace ověří uživatelské údaje.
- 4. Aplikace uživatele přihlásí.
- 5. Aplikace zobrazí stránku dle přihlášeného uživatele.

<h3>UC4 – Správa sportovišť: Vytvoření nového sportoviště </h3>
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

<h3>UC4 - Správa sportovišť: Vytvoření nového kurtu</h3>
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
- 7. Apikace zobrazí seznam kurtů.

<h3>UC3 - Rezervace: Rezervace kurtu uživatelem</h3>
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
