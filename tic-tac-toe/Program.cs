using System;

namespace tic_tac_toe
{
    class Program : API
    {
        readonly static string Title = "Tic-Tac-Toe";
        public static ConsoleColor DefaultBackColor { get; private set; } = ConsoleColor.Gray;
        public static ConsoleColor DefaultTextColor { get; private set; } = ConsoleColor.Black;
        public static Grid GameGrid;

        // The move of a cross or a zero.
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
            int moves    = 0;      // Number of moves till win.
            int textPosX = 5,
                textPosY = 1;
            char winner = 'N';
                      
            MoveSign = RandomGen.Next(0, 2) == 0 ? 'X' : 'O';
            GameGrid.DrawGrid();
            do
            {
                MoveSign = MoveSign == 'X' ? 'O' : 'X';                

                WriteAt("Ход: " + MoveSign.ToString(), textPosX, textPosY);
                WriteAt("Количество ходов: " + moves.ToString(), textPosX, textPosY+2);
                GameGrid.Move(MoveSign);

                moves++;
                winner = moves > 4 ? GameGrid.CheckWin() : winner;
            }
            while (winner == 'N');

            BackColor(ConsoleColor.DarkRed);
            TextColor(ConsoleColor.White);
            WriteAt(" Победитель: " + winner.ToString() + " ", textPosX, textPosY);
            BackColor(DefaultBackColor);
            TextColor(DefaultTextColor);

            Console.ReadLine();
            GameGrid.ResetGrid();
            ClearScreen(true);
        }
        //
        //
        //
    }
}
