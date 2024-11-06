1.În mod implicit, OpenGL interpretează vertexurile desenate în sens anti-orar ca fața frontală a unui poligon.

2.Anti-aliasing este o tehnică de îmbunătățire a calității imaginii prin netezirea marginilor obiectelor grafice
pentru a elimina aliasing-ul (efectul de „jagged edges” sau „scăriță” vizibil la margini). Aceasta face tranzițiile
între margini și fundal mai graduale, oferind o grafică mai fină. OpenGL folosește tehnici de anti-aliasing, cum ar
fi multisampling.

3.
GL.LineWidth(float): Schimbă grosimea liniilor.
GL.PointSize(float): Setează dimensiunea punctelor.
Funcționează în exteriorul zonei GL.Begin().

4.
GL.LineLoop: Conectează o serie de puncte prin linii, iar la final, conectează ultimul punct cu primul, formând un
poligon închis.
GL.LineStrip: Desenează o linie continuă între puncte, însă nu conectează ultimul punct la primul, formând o linie 
„deschisă”.
GL.TriangleFan: Generează un set de triunghiuri, toate având un vârf comun (primul vertex specificat). Fiecare 
triunghi este definit de vârful comun și de o pereche de puncte succesive.
GL.TriangleStrip: Creează o serie de triunghiuri conectate, folosind fiecare trei puncte adiacente pentru a crea un
triunghi. După primul triunghi, fiecare vertex nou formează un triunghi împreună cu ultimele două puncte din secvența
precedentă.

6. Utilizarea de culori diferite (în gradient sau culori selectate per suprafață) în desenarea obiectelor 3D  este 
importantă pentru a „induce ochiului” forma respectivă. Astfel, o piramida se poate destinge de un triunghi in același 
cadru.

7.Un gradient de culoare este o trecere graduală de la o culoare la alta. În OpenGL, un gradient de culoare se obține
prin setarea culorilor fiecărui vertex. OpenGL va interpola culorile între vertexuri, rezultând un efect de trecere a
culorii pe întreaga suprafață a obiectului.

10.Atunci când aplici culori diferite fiecărui vertex pentru primitive ca linii sau triunghiuri, OpenGL va interpola 
culorile de la un vertex la altul. Astfel, în cazul unei linii, vei obține un gradient de-a lungul liniei, iar pentru 
un triunghi strip, vei obține o trecere continuă a culorilor între vertexuri, oferind un efect de tranziție naturală a 
culorilor.
