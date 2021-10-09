using System;

namespace tic_tac_toe
{
    class API
    {
        public static Random RandomGen = new Random();
        public const string Pixel = "██";

        // Full-size string of length = 120px
        public const string Line  = "                                                                                                                        ";

                      
        public static void ClearScreen(bool fill) {
            if (fill)
            {
                for (int i = 0; i < 30; i++)
                {
                    Write(Line);
                }
                Console.Clear();
                SetCursor();
            } 
            else Console.Clear();
        }

        public static void SetTitle(string t)
        {
            Console.Title = t;
        }

        public static ConsoleKey ReadButton() {
            return Console.ReadKey().Key;
        }
               
        public static void Write(string t) {
            Console.Write(t);
        }

        public static void WriteAt(string t, int x, int y)
        {
            SetCursor(x, y);
            Console.Write(t);
        }

        public static void TextColor(ConsoleColor c) {
            Console.ForegroundColor = c;
        }

        public static void BackColor(ConsoleColor c) {
            Console.BackgroundColor = c;
        }

        public static void CursorVisible(bool visible)
        {
            Console.CursorVisible = visible;
        }

        public static void SetCursor(int x, int y) {
            Console.SetCursorPosition(x, y);
        }

        public static void SetCursor()
        {
            Console.SetCursorPosition(0, 0);
        }

        public static int GetCursorX()
        {
            return Console.CursorLeft;
        }

        public static int GetCursorY() {
            return Console.CursorTop;
        }

    }
}
