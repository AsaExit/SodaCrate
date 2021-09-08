using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LäskBacken1
{
    class Program
    {
        class Sodacrate
        {
            // Spara våra valda flaskor
            public string[] flaskor = new string[25];

            // Antalet flaskor
            public int antal_flaskor = 0;

            // Summa av kostand för alla flaskor, räknas ut med calc_total funktionen
            public int sum = 0;

            public void Run()
            {
                Console.WriteLine("Välkommen till Awesome Socker Chock AB Simulator");
                // Vårt första meny val
                int meny = 0;

                // Köra meny tills val 4 = avsluta väljs
                do
                {

                    Console.WriteLine("");
                    Console.WriteLine("Välj ett alternativ");
                    Console.WriteLine("1. Lägg till en dryck");
                    Console.WriteLine("2. Visa innehåll");
                    Console.WriteLine("3. Beräkna värde");
                    Console.WriteLine("4. Avsluta program");

                    // Läs vår sträng till en integer
                    meny = int.Parse(Console.ReadLine());

                    switch (meny)
                    {
                        // Om vi ska lägga till en dryck
                        case 1:
                            Add_soda();
                            break;

                        // Om vi ska skriva ut innehåll
                        case 2:
                            Print_crate();
                            break;

                        // Om vi ska räkna ut värdet
                        case 3:
                            sum = Calc_total();
                            Console.WriteLine("Totalt värde: {0} kr", sum);
                            break;

                        // Om avsluta program väljs
                        case 4:
                            Console.WriteLine("Programmet avslutas!");
                            break;

                        // Om inget av valen matchar
                        default:
                            Console.WriteLine("Felaktig inmatning");
                            break;
                    }
                } while (meny != 4); // Börja om menyn om valet inte är 4
            }

            // För att lägga till en dryck
            public void Add_soda()
            {
                // Vi kan inte lägga till om den är full
                if (antal_flaskor == 25)
                {
                    Console.WriteLine("Backen är full, du kan inte lägga till flera flaskor!");
                    return;
                }

                Console.WriteLine("Vilken dryck vill du lägga till i backen?: ");
                Console.WriteLine("1. Cola 15 kr");
                Console.WriteLine("2. Sunkist 15 kr");
                Console.WriteLine("3. Solo 15 kr");
                Console.WriteLine("4. Kalle Sprätt 15 kr");
                Console.WriteLine("5. Bullet 15 kr");

                // Läs in val av dryck och gör strängen till en integer
                int val = int.Parse(Console.ReadLine());

                // Namnet på den flaska som väljs
                string flaska = "";

                // Om menyn ska visas eller inte
                bool visa_meny = true;

                do
                {
                    switch (val)
                    {
                        // Om vi ska lägga till en Cola
                        case 1:
                            flaska = "Cola";
                            Console.WriteLine("Du valde att lägga till Cola");
                            visa_meny = false;
                            break;

                        // Om vi ska lägga till en Sunkist
                        case 2:
                            flaska = "Sunkist";
                            Console.WriteLine("Du valde att lägga till Sunkist");
                            visa_meny = false;
                            break;

                        // Om vi ska lägga till en Solo
                        case 3:
                            flaska = "Solo";
                            Console.WriteLine("Du valde att lägga till Solo");
                            visa_meny = false;
                            break;

                        // Om vi ska lägga till en Kalle Sprätt
                        case 4:
                            flaska = "Kalle Sprätt";
                            Console.WriteLine("Du valde att lägga till Kalle Sprätt");
                            visa_meny = false;
                            break;

                        // Om vi ska lägga till en Bullet
                        case 5:
                            flaska = "Bullet";
                            Console.WriteLine("Du valde att lägga till Bullet");
                            visa_meny = false;
                            break;

                        // Om en ogiltig dryck väljs så vill vi visa menyn igen
                        default:
                            flaska = "";
                            Console.WriteLine("Felaktig inmatning, mata in ett tal mellan 1-5");
                            visa_meny = true;
                            break;
                    }
                } while (visa_meny); // Visa menyn sålänge visa_meny är sant

                Console.Write("Hur många {0} vill du lägga till: ", flaska);

                // Läs in hur många av drycken som ska läggas till, gör om sträng till integer.
                int antal = int.Parse(Console.ReadLine());

                // Ser om det finns plats för drycken i backen
                if (antal_flaskor + antal < 26)
                {
                    for (int i = 0; i < antal; i++)
                    {
                        flaskor[antal_flaskor] = flaska;
                        antal_flaskor++;
                    }

                    // Räkna ut antalet platser kvar ocv visar det
                    int kvar = flaskor.Length - antal_flaskor;

                    Console.WriteLine("Du valde att lägga till {0} styck {1}", antal, flaska);
                    Console.WriteLine("{0} platser kvar i läskbacken", kvar);
                }
                else
                {
                    Console.WriteLine("Det finns inte plats för att lägga till {0} styck {1}, det finns bara {2} platser kvar. Försök igen ", antal, flaska, flaskor.Length - antal_flaskor);
                }
            }

            public void Print_crate()
            {
                // Gå igenom alla flaskor, om platsen är fylld skriv ut drycken
                // annars skriv bara ut tom plats.
                foreach (var dryck in flaskor)
                {
                    if (dryck != null)
                        Console.WriteLine(dryck);
                    else
                        Console.WriteLine("Tom plats");
                }
            }

            // Räkna ut totala värdet på backen
            private int Calc_total()
            {
                int total = 0;

                foreach (var dryck in flaskor)
                {
                    // Kolla så att platsen inte är tom
                    if (dryck != null)
                        total += 15; // Varje dryck kostar 15 kr så vi behöver inte kolla vad det är för dryck
                }
                return total; // Returnera totalen
            }
        }
        public static void Main(string[] args)
        {

            Console.BackgroundColor = ConsoleColor.White;   // Gör programmet lite mer trevligt att titta på
            Console.ForegroundColor = ConsoleColor.Black;
            Console.SetWindowSize(55, 40);

            // Skapa ett Sodacrate objekt
            var sodacrate = new Sodacrate();
            sodacrate.Run(); // Kör vår run funktion för att börja


            Console.Write("Press any key to continue . . . ");
            Console.ReadKey(true);
        }
    }
}
