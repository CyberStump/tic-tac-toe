using System;

namespace tic_tac_toe
{
    class Program : API
    {
        readonly static string Title = "Tic-Tac-Toe 1.0(beta)";
        public static Grid GameGrid;
        public static ConsoleColor DefaultBackColor { get; private set; } = ConsoleColor.Gray;
        public static ConsoleColor DefaultTextColor { get; private set; } = ConsoleColor.Black;

        // The move of a cross(X) or a zero(O).
        private static char MoveSign; 


        static void Main(string[] args)
        {
            SetTitle(Title);
            CursorVisible(false);
            BackColor(DefaultBackColor);
            TextColor(DefaultTextColor);            
            ClearScreen(true);
            GameGrid = new Grid(4, 9);

            while (true) {
                Game();
            }
        }

        public static void Game()
        {
            int moves = 0;      // Number of moves taken.
            char winner = 'N';
            int textStartPosX = 5,
                textSrartPosY = 2;
                      
            MoveSign = RandomGen.Next(0, 2) == 0 ? 'X' : 'O';
            GameGrid.DrawGrid();
            do
            {
                MoveSign = MoveSign == 'X' ? 'O' : 'X';                

                WriteAt("Ход: " + MoveSign.ToString(), textStartPosX, textSrartPosY);
                WriteAt("Количество ходов: " + moves.ToString(), textStartPosX, textSrartPosY+2);
                GameGrid.Move(MoveSign);

                moves++;
                winner = moves > 4 ? GameGrid.CheckWin() : winner;
            }
            while (winner == 'N');

            BackColor(ConsoleColor.DarkRed);
            TextColor(ConsoleColor.White);

            WriteAt(" Победитель: " + winner.ToString() + "    Для продолжения 2 раза нажмите Enter", textStartPosX, textSrartPosY);
            Console.ReadLine();
            WriteAt(" Победитель: " + winner.ToString() + "    Для продолжения 1 раз нажмите Enter ", textStartPosX, textSrartPosY);
            Console.ReadLine();


            BackColor(DefaultBackColor);
            TextColor(DefaultTextColor);

            GameGrid.ResetGrid();
            ClearScreen(true);
        }
        //
        //
        //
    }
}
