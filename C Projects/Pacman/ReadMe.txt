Descriere :
Un program care citește de la tastatură un număr ce reprezintă dimensiunea triunghiului și un caracter, și afișează un triunghi făcut din 
caracterul respectiv și cu dimensiunea respectivă. Triunghiul trebuie să aibă aceeași formă cu cel de mai sus (trebuie să reprezinte jumătatea 
din dreapta sus a unui pătrat tăiat pe diagonală). Caracterele de pe aceeași linie trebuie separate cu un spațiu. Spațiile libere 
(jumatatea din stanga jos simetrica triunghiului) trebuie făcută tot din caracterul spațiu.

Jocul este turn-based, iar o tură funcționeaza în felul urmator:

  - se afișează tabla de joc curentă
  - se citește de la tastatură un singur caracter de mișcare (w, a, s sau d) urmat de caracterul newline (\n)
  - personajul se mută pe tablă corespunzător (w = sus, a = stânga, s = jos, d = dreapta) 
  - se trece la tura următoare
  - jocul se consideră încheiat când personajul ajunge în colțul din dreapta jos al tablei, caz în care se
afișează tabla corespunzătoare (după aplicarea mutării ce trimite personajul în colțul din dreapta jos), urmată de mesajul “GAME COMPLETED” pe linia următoare
  - Un obstacol va fi reprezentat pe tabla de joc folosind caracterul ‘x’. Un obstacol fix va rămâne mereu acolo unde a fost poziționat, 
  la coordonatele (l, c). Un obstacol mobil se va deplasa înspre personaj, pe una din cele 8 direcții, cu 1 poziție la fiecare 2 ture. 
  Când utilizatorul execută o mutare care trimite personajul intr-o poziție ocupată de un obstacol (sau când un obstacol mobil vine peste 
  personaj), jocul se termină (nu se mai afișează tabla de joc încă o dată, în schimb se afișează mesajul “GAME OVER” și execuția se 
  încheie).
  
EXEMPLU DE INPUT : 
  3 4 2 1 3 
  2 1 f
  1 4 m
  3 4 m
  
EXPLICATII : 

  3 si 4 reprezinta nr de linii si coloane al tablei
  2 si 1 reprezinta coordonatele la care va aparea playerul cand incepe jocul
  3 reprezinta numarul de obstacole
  2 si 1 reprezinta coordonatele primului obstacol si f reprezinta tipul acestuia adica fix
  1 si 4 reprezinta coordonatele celui de-al 2-lea obstacol si f reprezinta tipul acestuia adica fix
  3 si 4 reprezinta coordonatele celui de-al 3-lea obstacol si m reprezinta tipul acestuia adica mobil
  
