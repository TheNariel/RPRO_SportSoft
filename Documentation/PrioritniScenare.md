<h3>UC – Přehled sportovišť:  Zobrazení sportovišť </h3>
<b>Actor:</b> Zákazník

<b>Preconditions:</b>
Zákazník má vytvořený účet a spuštěnou aplikaci.

<b>Basic Flow:</b>
- 1. Zákazník se přihlásí.
- 2. Aplikace zobrazí hlavní stránku.
- 3. Zákazník zvolí zobrazení sportoviště.
- 4. Aplikace zobrazí sportoviště.

<h3>UC – Rezervace:  Rezervace kurtu </h3>
<b>Actor</b>: Zákazník

<b>Preconditions:</b>
Zákazník má vytvořený účet, spuštěnou aplikaci a je přihlášen. Zákazník je na hlavní stránce.

<b>Basic Flow:</b>
- 1. Uživatel zvolí zobrazení sportoviště.
- 2. Aplikace zobrazí sportoviště.
- 3. Uživatel vybere časový rozsah.
- 4. Uživatel potvrdí volbu.
- 5. Aplikace zobrazí kurty, které jsou volné.
- 6. Uživatel zvolí, který chce rezervovat.
- 7. Uživatel potvrdí rezervaci.
- 8. Aplikace zobrazí přehled rezervací uživatele.


<h3>UC – Ověření uživatele: Přihlášení </h3>
<b>Actor</b>: Majitel 

<b>Preconditions:</b>
Aplikace je spuštěná a zobrazuje přihlašovací stránku.

<b>Basic Flow:</b>
- 1. Majitel zadá přihlašovací email a heslo.
- 2. Majitel potvrdí přihlašovací údaje.
- 3. Aplikace ověří přihlašovací údaje.
- 4. Aplikace majitele přihlásí.
- 5. Aplikace zobrazí přehled sportovišť.


<h3>UC – Přehled sportovišť: Zobrazení sportovišť</h3>
<b>Actor</b>: Majitel  

<b>Preconditions:</b>
Majitel má spuštěnou aplikaci, je přihlášen a aplikace zobrazí hlavní stránku.

<b>Basic Flow:</b>
- 1. Majitel zvolí zobrazení sportoviště.
- 2. Aplikace zobrazí sportoviště.


<h3>UC – Správa sportovišť: Vytvoření nového kurtu </h3>
<b>Actor</b>: Majitel  

<b>Preconditions:</b>
Majitel je přihlášen. Aplikace zobrazí přehled sportovišť.

<b>Basic Flow:</b>
- 1. Majitel zvolí možnost vytvoření novéhu kurtu.
- 2. Aplikace zobrazí formulář.
- 3. Majitel napíše informace o kurtu.
- 4. Majitel určí od kdy bude kurt k dispozici.
- 5. Majitel zadá ceník pro daný kurt.
- 6. Majitel potvrdí vytvoření nového kurtu.
- 7. Aplikace zviditelní daný kurt pro zákazníky od daného data.


<h3>UC – Správa sportovišť: Smazání kurtu </h3>
<b>Actor</b>: Majitel  

<b>Preconditions:</b>
Majitel je přihlášen. Aplikace zobrazí přehled sportovišť.

<b>Basic Flow:</b>
- 1.	Majitel zvolí odebrání vybraného sportoviště
- 2.	Potvrdí uložení změn
- 3.  Sportoviště se odstrání
- 4.	Zobrazí se mu stránka s výběrem sportovišť


<h3>UC – Rezervace: Rezervace kurtu  </h3>
<b>Actor</b>: Majitel 

<b>Preconditions:</b>
Majitel je přihlášen a je na hlavní stránce.

<b>Basic Flow:</b>
- 1. Majitel zvolí zobrazení sportoviště.
- 2. Aplikace zobrazí sportoviště.
- 3. Majitel vybere časový rozsah.
- 4. Majitel potvrdí volbu.
- 5. Aplikace vyznačí kurty, které jsou volné.
- 6. Majitel zvolí, který kurt chce rezervovat.
- 7. Majitel potvrdí rezervaci.
- 8. Aplikace zobrazí přehled všech rezervací.

