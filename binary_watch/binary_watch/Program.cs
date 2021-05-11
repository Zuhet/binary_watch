using System;
using System.Media;

namespace binary_watch
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] xPos = { 5, 10, 15, 20, 25, 30 };
            Console.CursorVisible = false;
            string oldTime = Convert.ToString(DateTime.Now.Second);


            Udsmykning();
            SekPrinter(xPos);
            MinutPrinter(xPos);
            TimePrinter(xPos);

            do
            {
                while (!Console.KeyAvailable)
                {
                    if (oldTime != Convert.ToString(DateTime.Now.Second)) {
                        oldTime = Convert.ToString(DateTime.Now.Second);
                        SekPrinter(xPos);
                    }
                }
            } while (Console.ReadKey(true).Key != ConsoleKey.Escape);


        }


        private static void Udsmykning()
        {
            //boks værdien vises 
            Console.SetCursorPosition(5, 2);
            Console.Write("32");
            Console.SetCursorPosition(10, 2);
            Console.Write("16");
            Console.SetCursorPosition(15, 2);
            Console.Write("8");
            Console.SetCursorPosition(20, 2);
            Console.Write("4");
            Console.SetCursorPosition(25, 2);
            Console.Write("2");
            Console.SetCursorPosition(30, 2);
            Console.Write("1");

            //rækkernes mening
            Console.SetCursorPosition(1, 3);
            Console.Write("S");
            Console.SetCursorPosition(1, 6);
            Console.Write("M");
            Console.SetCursorPosition(1, 9);
            Console.Write("T");

        }



        //int ySekPos = 3, yMinPos = 6, yTimPos = 9;


        private static int SekPrinter(int[] xPos)
        {
            string[] sekAray = SixBites(Convert.ToString(DateTime.Now.Second, 2));
            int counter = 0;
            int ySekPos = 3;
            for (int i = 0; i < 6; i++)
            {
                Console.SetCursorPosition(xPos[i], ySekPos);
                if (sekAray[i] == "1")
                {
                    Console.BackgroundColor = ConsoleColor.Red;
                }
                else
                {
                    Console.BackgroundColor = ConsoleColor.Yellow;
                    counter++;
                }
                Console.WriteLine(" ");
            }
            //anonymed instanssering
            new SoundPlayer("tiktok.wav").Play();
            if (counter == 6)
            {
                MinutPrinter(xPos);
            }
            return counter;
        }



        public static void MinutPrinter(int[] xPos) {
            int yMinPos = 6;
            int counter = 0;
			string[] minAray = SixBites(Convert.ToString(DateTime.Now.Minute, 2));
			for (int i = 0; i < 6; i++) {
				Console.SetCursorPosition(xPos[i], yMinPos);
				if (minAray[i] == "1") {
					Console.BackgroundColor = ConsoleColor.Red;
				}
				else {
					Console.BackgroundColor = ConsoleColor.Yellow;
                    counter++;
				}
				Console.WriteLine(" ");
			}
            if (counter == 6)
            {
                TimePrinter(xPos);
            }
		}
        


        public static void TimePrinter(int[] xPos) {
            int yTimPos = 9;
			string[] minAray = SixBites(Convert.ToString(DateTime.Now.Hour, 2));
			for (int i = 0; i < 6; i++) {
				Console.SetCursorPosition(xPos[i], yTimPos);
				if (minAray[i] == "1") {
					Console.BackgroundColor = ConsoleColor.Red;
				}
				else {
					Console.BackgroundColor = ConsoleColor.Yellow;
				}
				Console.WriteLine(" ");
			}
		}



        // 1 2 4 8 16 32 == 6
        static public string[] SixBites(string tidsmaoler)
        {
            string[] binaryArray = new string[6];
            if (tidsmaoler.Length != 6)
            {
                for (int i = tidsmaoler.Length; i < 6; i++)
                {
                    tidsmaoler = "0" + tidsmaoler;
                }
            }
            // Nu er tidsmaoler 6 karaktere lang, altså "000000"
            for (int i = 0; i < 6; i++)
            {
                binaryArray[i] = tidsmaoler.Substring(i, 1);
            }
            return binaryArray;
        }
    }
}