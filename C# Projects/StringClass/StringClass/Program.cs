using System;//libraria principala care contine toate metodele,variabilele functionarii unui program in C#

namespace StringClass 
		/*
		 *  namespace-ul este defap numele unei librarii pe care o putem folosi ulterior in alt program exemplu de namespace este chiar System ,
		 *  in alt program putem folosi astfel namespace-ul : 
		 *  using StringClass;
		 *  si putem apela astfel orice metoda si variabila din programul StringClass
		   NOTA : Poate fi apelata orice variabila care are proprietatea de a fi publica si statica, in programul de acum toate variabilele sunt de tip private si nu pot fi apelate 
		   NOTA 2 : Daca o variabila nu are declarat tipul de securitate(nu stiu cum sa ii spun altfel) va fi pus cel default ( private ) si variabilele pot fi folosite doar in programul curent.

		   Ex de variabila publica :
			   public static string MyString ;
			   // putem apela in alt program folosind numele classei de care apartine -> 
			   
				Program.MyString = "Am apelat string-ul din alt program";
			  
		   Astfel se pot face legaturi intre 2 sau mai multe scripturi.
		 */
{
    class Program
    {
        //declaram string-ul nostru global, fiind declarata global , string-ul trebuie sa fie static 
        static string MyString = String.Empty; //initializam string-ul folosindu-te de String.Empty care il initializeaza cu nimic same cu null fi
        static void Main(string[] args)
        {
            Console.Write("Scrie o propozitie : "); //afisam ceva pe ecran sa stim ca incepe programul
            MyString = Console.ReadLine(); //fiind deja un string nu mai trebuie sa convertim cum se intampla la int,float,etc.

            //Operatiile pe care le putem face cu string sunt urmatoarele 
            //1) Length -> returneaza lungimea string-ului nostru in int .Sirul incepe de la 0 (este precum un array primul index e 0)
            int length = MyString.Length;
            Console.WriteLine("Lungimea string-ului '{0}' este {1} .", MyString,length);
            //{0} reprezinta primul element dupa virgula adica MyString ,{1} reprezinta al 2-lea element fiind mai usor de citit asa codul
            /*INPUT:
                 Imi place informatica.

             OUTPUT:
                 Lungimea string-ului 'Imi place informatica.' este 22
            
            NOTA: Returneaza inclusiv spatiile libere iar in total ar fi 23 de elemente insa indexul incepand de la 0 vor ramane 22.
            */
            //2) ToUpper() -> creeaza un nou string cu litere mari(nu imi vine alta exprimare) 
            string MyUpperString = MyString.ToUpper();
            Console.WriteLine("String-ul meu este acum cu litere mari : " + MyUpperString);
            /*
            INPUT: 
                   Imi place informatica.

            OUTPUT:
                    String-ul meu este acum cu litere mari : IMI PLACE INFORMATICA.

            Nota: Daca litera e deja majuscula nu o mai modifica.
            */
            //3) To.Lower() -> creeaza un nou string cu litere mici 
            string MyLowerString = MyString.ToLower();
            Console.WriteLine("String-ul meu este acum cu litere mici : " + MyLowerString);
            /*
             INPUT : 
                    Imi place informatica.

             OUTPUT:
                    String-ul meu este acum litere mici : imi place informatica.

             Nota: Daca litera e deja minuscula nu o mai modifica.
             */
            //3) Trim() -> sterge un anumit caracter de la inceputul si sfarsitul string-ului.
            string MyTrimmedString = MyString.Trim('.',' '); //caracterele folosite pentru trim sunt 'punctul' si 'spatiul'
            Console.WriteLine("String-ul meu dupa trim este acum : " + MyTrimmedString);
            /*
             INPUT :
                               Imi place informatica           .....

             OUTPUT :
                     String-ul meu dupa trim este acum : Imi place informatica

             Nota : Sterge numai characterele de la inceputul si sfarsitul string-ului , cand acesta gaseste un caracter care nu e cel pe care trebuie sa il stearga se opreste.
             EX:
             
             INPUT:      
                          ../,./..  Imi place informatica ... //, ..|.. 

             OUTPUT:
                    String-ul meu dupa trim este acum : /,./.. Imi place informatica ... //, ..|
                      
             S-a oprit dupa ce a gasit un alt caracter decat cel pe care il cauta (aici fiind '.' si ' ' caracterele cautate)
             La inceput s-a oprit dupa primul / si la sfarsit dupa | .

             Nota : Daca functia este folosita fara nici un caracter va sterge toate spatiile de la final si inceputul si sfarsitul string-ului.
             EX: 
                   string MyTrimmedString = MyString.Trim();

                   INPUT:        
                                Imi place informatica.       

                   OUTPUT:      
                          String-ul meu dupa trim este acum : Imi place informatica. //Nota spatiul dupa : este de la Console.WriteLine ,nu este spatiu lasat dupa trim.
            */
            //4) Trim.Start() -> sterge anumite caractere din string NUMAI de la inceputul acestuia si returneaza un string nou.
            string MyStartTrimmedString = MyString.TrimStart(',', ' '); //caracterele folosite pentru trim sunt 'virgula' si 'spatiul'
            Console.WriteLine("String-ul meu trimmed la inceput este : "+MyStartTrimmedString);
            /*
              INPUT :
                               ,, ,..., Imi place informatica ..  ., 

              OUTPUT :
                      String-ul meu trimmed la inceput este : ..., Imi place informatica .. .,

              NOTA : Dupa cum se vede in exemplu doar caracterele de la inceput au fost sterse pana cand a gasit un caracter nou unde s-a oprit.
            */
            //5) Trim.End() -> sterge anumite caractere din string NUMAI de la sfarsitul acestuia si returneaza un string nou.
            string MyEndTrimmedString = MyString.TrimEnd(',', ' ', '.'); //caracterele folosite pentru trim sunt 'virgula' , 'spatiul' si 'punctul'
            Console.WriteLine("String-ul meu trimmed la sfarsit este : " + MyEndTrimmedString);
            /*
              INPUT :
                               ,, ,..., Imi place informatica ..  ., ,, 

              OUTPUT :
                      String-ul meu trimmed la sfarsit este :           ,, ,..., Imi place informatica

              NOTA : Dupa cum se vede in exemplu doar caracterele de la sfarsit au fost sterse pana cand a gasit un caracter nou unde s-a oprit.

              NOTA PENTRU TOATE FUNCTIILE TRIM : Se poate forma un array care trebuie sa fie de tip char in care se pot pune toate caracterele ce trebuie sterse insa toate trebuie sa fie de tip char
                    altfel va aparea o eroare.

            EX :
                char[] TrimmCharacters =  new char[3] { ' ' , ',' , ':' };
            */
            //6) PadLeft() & PadRight() [ Le voi explica impreuna deoarece fac acelasi lucru doar ca in directii opuse .] -> adauga un caracter intr-o anumita directie ( stanga/drepta ) pana cand se obtine marimea specificata in methoda.
            string MyLeftPadString = MyString.PadLeft(MyString.Length + 3, '*'); // o sa adauge 3 stelute in stanga string-ului deoarece am pus sa umple dimensiunea string-ului + 3
            string MyRightPadString = MyString.PadRight(MyString.Length + 4, '@');
            Console.WriteLine("PadLeft cu caracterul '*' pentru 3 pozitii : " + MyLeftPadString + "\n" + "PadRight cu caracterul '@' pentru 4 poziti in plus : " + MyRightPadString);
            /*
              INPUT :
                      Imi place informatica.
                      
              OUTPUT : 
                     Padleft cu caracterul '*' pentru 3 pozitii : ***Imi place informatica.
                     PadRight cu caracterul '@' pentru 4 pozitii : Imi place informatica.@@@@
                     
              Nota : Se pot folosi si fara cel de-al 2-lea parametru precum trim se foloseste ca Trim() si va adauga spatii libere in stanga/dreapta.
                     Al 2-lea parametru trebuie sa fie de tip char.
                     
              Explicatie mai explicita(cred) :
                     primul parametru reprezinta lungimea la care trebuie sa ajunga string-ul nostru , cel de-al 2lea reprezinta caracterul pe care il adauga pana cand ajunge la lungimea data de primul parametru
              
              Alt exemplu :
                   string MyLeftPadString = "Hi".PadLeft(7,'%');
                   Console.WriteLine(MyLeftPadString);

             OUTPUT :
                   %%%%%Hi

                   Avem deja 2 pozitii ocupate in string pana la 7 => 7-2 = 5 , raman inca 5 pozitii in stanga de umplut iar aceste sunt umplute cu %.
                   
             Ex. cu PadLeft() // se vad mai bine spatiile lasate la inceput decat la sfarsit.
                  string MyLeftPadString = "Hi".PadLeft(6);
                  Console.WriteLine(MyLeftPadString);

             OUTPUT :          
                       Hi

              O sa ramana 4 spatii libere in fata string-ului (avand deja 2 pozitii ocupate pana la 6 mai avem nevoie de 4).
            */
            //7) Insert() -> adauga un string in alt string incepand de la o anumita pozitie.
            string MyInsertString = MyString.Insert(0, "Mie ");//si da e si spatiu dupa Mie deci sunt 4 caractere in total de adaugat.
            Console.WriteLine("String-ul meu cu insert este : " + MyInsertString +" Iar noua lui dimensiune este " + MyInsertString.Length);
            /*
             INPUT :
                     imi place informatica.
                         
             OUTPUT : 
                     String-ul meu cu insert este : Mie imi place informatica. Iar noua lui dimensiune este 26.

             Nota : Pe pozitia 0 aveam initial i si am adaugat pe aceasi pozitie 0 "Mie " impingand astfel string-ul (care poate fi privit si ca un sir de caractere) astfel crescand si marimea string-ului
            */
            //8) Remove() -> sterge un anumit numar de caractere de la o anumita pozitie.
            string MyRemoveString = MyString.Remove(0, 3);
            Console.WriteLine("String-ul meu cu remove este acum : " + MyRemoveString + " Iar dimensiunea lui este " + MyRemoveString.Length);
            /*
             INPUT :
                    Nu Imi place informatica.

             OUTPUT : 
                    String-ul meu cu remove este : Imi place informatica. Iar dimensiunea lui este 22. (25-3)

             Nota : Am sters primele 3 caractere(asta a inclus si spatiul) incepand de la pozitia 0. [ anume : 'n','u' si ' ' ]
            */
            //9) Replace() -> inlocuieste un caracter (acela fiind primul parametru) cu un altul .
            // NOTA : poate inlocui atat un string cu un alt string cat si un char cu un alt char . INSA nu poate inlocui un string cu un char sau viceversa.
            string MyReplaceString = MyString.Replace('i','p'); //aici inlocuiesc un char cu un alt char anume a i cu p
            Console.WriteLine("String-ul meu replaced este : " + MyReplaceString);
            /*
                INPUT:
                        Imi place informatica.
             
                OUTPUT:
                        String-ul meu replaced este : Imp place pnformatpca.

                NOTA: Aceasta metoda este case sensitive mai exact distinge majusculele de literele mari iar , in cazul de fata a modificat doar i-ul nu si I .
            */
            //10) Substring() -> extrage o anumita portiune din string formand altul nou.
            string MySubstringString = MyString.Substring(0,9); //incepe de la pozitia 0 pana la 9 si pastreaza toate caracterele stocandu-le int-un nou string.
            Console.WriteLine("Substring-ul meu este : " + MySubstringString);
            /*
             INPUT : 
                    Imi place informatica.

             OUTPUT :
                    Substring-ul meu este : Imi place

             NOTA : Primul parametru reprezinta pozitia de inceput in cazul nostru 0 iar cel de-al doilea reprezinta cate va salva in nou string. 
                    Se poate incepe si de la alta pozitie.
             
             EX:
                 string MySubstringString = MyString.Substring(10,11);
                 Console.WriteLine("Substring-ul meu este : " + MySubstringString);

                 INPUT: 
                       Imi place informatica.

                 OUTPUT:
                        Substring-ul meu este : informatica

                 NOTA: Caracterul de la care a inceput a fost i , dupa care a mers inca 11 caractere pe care le-a salvat oprindu-se la al 11-lea ('punctul' nu a fost salvat)
            */
            //11) StartWith() & EndsWith() -> verifica daca un string incepe/se termina cu un anumit substring(sir de caractere) si returneaza true sau false.
            bool MyStartWithString = MyString.StartsWith("Imi");
            bool MyEndWithString = MyString.EndsWith("place");
            Console.WriteLine("String-ul meu incepe cu substring-ul curent "+MyStartWithString+ "\nString-ul meu se termina cu substring-ul curent "+MyEndWithString);
            /*
             INPUT :
                   Imi place informatica.
                    
             OUTPUT :
                     String-ul meu incepe cu substring-ul curent true 
                     String-ul meu se termina cu substring-ul curent false  
                     
            Nota : Substring-ul Imi exista la inceput insa place nu exista la sfarsit-ul string-ului.
            */
            //12) Split() -> creaza un array in care stocheaza toate elementele care apar inaintea delimitatorului 
            string[] MySplittedString = MyString.Split();//folosim spatiul ca separator daca nici un caracter nu este definit | alt exemplu poate fi string[] MySplittedString = MyString.Split(','); unde folosim virgula ca separator
            Console.WriteLine("String-ul meu split-uit este : ");
            int i = 0;
            foreach (string s in MySplittedString)
            {
                Console.WriteLine(s+" -> elementul numarul "+i++);
            }
            /*
               Pentru o intelegere mai usoara folosesc in exemplul asta virgula.
               string[] MySplittedString = MyString.Split(',');
                           Console.WriteLine("String-ul meu split-uit este : ");
               int i = 0;
               foreach (string s in MySplittedString)
               {
                   Console.WriteLine(s+" -> elementul numarul "+i);
                   i++;
               }
               INPUT :
                      Imi place,, , informatica , .Foarte mult,dar da,.

               OUTPUT :
                      String-ul meu split-uit este : 
                      Imi place-> elementul numarul 0
                       ->elementul numarul 1 // ce se intampla mai exact aici avem Imi place,, => inainte de a 2-a virgula nu este nimic astfel se ajunge la blank space.
                        ->elementul numarul 2 //aici avem spatiul de la , + spatiu ca ,caracter
                        informatica -> elementul numarul 3
                        .Foarte mult -> elementul numarul 4
                      dar da ->elementul numarul 5
                      . ->elementul numarul 6
              
              Nota : Se folosesc numai caractere in functia split ca delimitatori.
            */
            //13) string.Join() -> alipeste elementele unui array de tip string cu un separator.
            string MyJoinString = string.Join(" ",MySplittedString); //vom folosi string-ul splituit si il vom alipi folosind ca delimitator spatiul
            Console.WriteLine("String-ul meu alipit / concatenat este acum : " + MyJoinString);
            /*
              INPUT :
                    //Aici folosim input-ul de la string-ul split-uit , cel cu spatiu folosint propozitia : Imi place informatica.
                    V[0] : Imi
                    v[1] : place
                    v[2] : informatica.

              OUTPUT : 
                    String-ul meu alipit / concatenat este acum : Imi place informatica.

              Nota : Putem numi acest proces ,procesul invers split-ului.
              Nota : Foloseste ca separator un string nu un char(caracter). 
            */
            /*14) string.Equals(string stringul1,string stringul2) -> compara 2 string-uri si returneaza true daca sunt egale.
                  string.IsNullOrEmpty(string StringDeVerificat) -> verifica daca un string e null sau e empty si returneaza true sau false.
                  string.IsNullOrWhiteSpace(string StringDeVerificat) -> verifica daca un string e null sau e format doar din spatii si returneaza true sau false.      
                  
                  //exemple
                  1) if(string.Equals("PLACE","place")) //returneaza false pentru ca C# e case sensitive si verifica si diferenta dintre literele mari si mici
                  2) if(string.IsNullOrEmpty("Plaace")) // returneaza false pentru ca string-ul nu e null sau empty 
                  3) if(string.IsNullorWhiteSpace("   ")) // returneaza true pentru ca string-ul are spatii goale
            */
            if (string.IsNullOrEmpty(" ") || string.IsNullOrWhiteSpace(MyString))
                Console.WriteLine("E null sau gol.");
            else
                Console.WriteLine("Nu e null sau gol.");
            //15) string.Format -> formateaza un string , putem modifica valoarea din el.
            string MyFormattedString = string.Empty;
            double formatat = 100.0 - 75.3;
            MyFormattedString = string.Format("{0} formatat {1:0.0} ",MyString,formatat);
            Console.WriteLine(MyFormattedString);
            /*
               INPUT :
                      Imi place informatica.

               OUTPUT :
                      Imi place informatica. formatat 25,7

              Nota : Aici am aratat si cum se afiseaza o constanta de tip double .
            */
            /*16) 
              string.Compare(string S1,string S2) -> returneaza 0 daca caracterele lor sunt egale , -1 daca primul string este mai mic(marimea)(sau daca cele 2 string-uri au aceasi marime dar caractere diferite)
                                                     decat cel de-al 2-lea si 1 daca e mai mare decat cel de-al 2-lea
              Insa putem compara 2 stringuri si folosind "==" sau "!=".
              string MyCopyString = string.Copy(string MyString); -> copiem in MyCopyString pe MyString.
              Putem atribui o valoare dintr-un string in altul folosind "=".
            */
            string MyComparedString1 = "abcde";
            string MyComparedString2 = "abcdj";
            if (string.Compare(MyComparedString1, MyComparedString2) == 0)
                Console.WriteLine("Cele 2 stringuri sunt egale cu compare.");
            else
                Console.WriteLine("Cele 2 string-uri nu sunt egale si am returnat {0}", string.Compare(MyComparedString1, MyComparedString2));
            /*
                INPUT :  
                         abcde
                         abcdj
                         
                OUTPUT :
                         Cele 2 string-uri nu sunt egale si am returnat -1.
                        
                NOTA: In acest caz cele 2 string-uri au fost egale ca marime insa au avut caractere diferite , astfel in acest caz s-a returnat -1;
            */
            //17) IndexOf -> returneaza indexul la care apare un anumit caracter , poate fi folosit pentru a verifica daca exista un anumit caracter intr-un string
            string SearchCharacter = "informatica";
            if (MyString.IndexOf(SearchCharacter) != -1)//daca exista caracterul -1 adica daca nu exista nici un caracter 
            {
                Console.WriteLine("Exista {0} in '{1}'.", SearchCharacter, MyString);
            }
            else
            {
                Console.WriteLine("Nu exista {0} in '{1}'.", SearchCharacter, MyString);
            }
            /*
             INPUT : 
                    Imi place informatica.
                    
             OUTPUT :
                    Exista informatica in Nu imi place informatica. 
            */
            Console.ReadKey();
        }
    }
}