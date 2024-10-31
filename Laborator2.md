Dica Ionela-Valentina, grupa 3133b, laborator 2

 La modificarea constantei MatrixMode.Projection forma nu mai era vizibila.

1. Un viewport reprezintă o regiune rectangulară din fereastra de afişare în care se va
desena o scenă.Definirea viewport-ului este esențială pentru a controla dimensiunea și proporțiile
imaginii renderizate.

2.Frames per second (FPS) se referă la numărul de cadre (frames) renderizate pe secundă. În OpenGL,
un FPS mai mare indică o experiență de utilizare mai fluidă, iar un FPS scăzut poate duce la mișcări
sacadate.

3.Metoda OnUpdateFrame() este rulată în fiecare cadru (frame) de actualizare. Acest lucru se întâmplă
între actualizările logice ale aplicației, cum ar fi gestionarea intrării utilizatorului, actualizarea
poziției obiectelor și alte calcule necesare.

4.Modul imediat de randare (immediate mode) este o metodă de a trimite vertecși către OpenGL în timp
real, folosind apeluri de funcții pentru a defini fiecare vertex și atribut.

5.Ultima versiune de OpenGL care acceptă modul imediat de randare este OpenGL 3.3.

6.Metoda OnRenderFrame() este rulată de fiecare dată când este necesar să se actualizeze imaginea pe
ecran, de obicei în fiecare cadru de randare. Aceasta se ocupă cu desenarea efectivă a scenei, inclusiv
aplicarea transformărilor și renderizarea obiectelor.

7.Metoda OnResize() este esențială pentru a adapta viewport-ul și proiecția grafică atunci când fereastra
este redimensionată. Aceasta trebuie să fie executată cel puțin o dată pentru a configura corect dimensiunea
viewport-ului și pentru a asigura că aspectul scenei rămâne corect pe ecran.

8. Parametrii metodei CreatePerspectiveFieldOfView():
~FOV(Field of View)-utilizeaza valori intre MathHelper.PiOver4 (45 de grade) și MathHelper.PiOver2 (90 de
grade)
~Aspect Ratio: Raportul de aspect al viewport-ului (lățime/înălțime), care determină cum este distorsionată
imaginea. Acesta ar trebui să fie un număr pozitiv.
~Near Plane: Distanța minimă la care obiectele sunt vizibile, un număr pozitiv.
~Far Plane: Distanța maximă la care obiectele sunt vizibile, de asemenea un număr pozitiv și mai mare decât
near plane.
