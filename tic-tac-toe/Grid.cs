using System;

namespace tic_tac_toe
{
    class Grid : API
    {
        private static Cell[,] Cells = new Cell[3, 3];

        private int _PosX,
                    _PosY;
        private int _IndexX,
                    _IndexY;

        public Grid(int x, int y)
        {
            _PosX = x;
            _PosY = y;
            for (int i = 0; i < 3; i++) {
                for (int j = 0; j < 3; j++) {
                    Cells[i, j] = new Cell('N');
                }
            }
            DrawGrid();
        }

        public void Move(char MoveSign)
        {            
            ConsoleKey pressedKey;
            do
            {
                do
                {
                    pressedKey = ReadButton();
                    if (pressedKey != ConsoleKey.Enter) { 
                        SelectCell(pressedKey); 
                    }
                    DrawGrid();
                }
                while (pressedKey != ConsoleKey.Enter);
            }
            while (!AddCell(MoveSign));
            
            DrawCursor(Pixel);
        }

        public void DrawGrid()
        {
            for (int i = 0; i < 18; i++) {
                for(int j = 0; j < 37; j += 12)
                    WriteAt(Pixel, _PosX + j, i + _PosY);
            }
            for (int i = 0; i < 38; i += 2) {
                for (int j = 0; j < 19; j += 6)
                    WriteAt(Pixel, i + _PosX, _PosY + j);
            }

            for (int i = 0; i < 3; i++) {
                for (int j = 0; j < 3; j++) 
                {
                    try {
                        Cells[i, j].Draw();
                    }
                    catch { }
                    //Cells[i, j].Draw();
                    //if(Cells[i, j] != null) Cells[i, j].Draw();
                }
            }
            DrawCursor(Pixel);
        }
                
        public void SelectCell(ConsoleKey pressedKey)
        {            
            DrawCursor("  ");
            switch (pressedKey)
            {
                case ConsoleKey.UpArrow:
                case ConsoleKey.W:
                    if (_IndexY > 0) _IndexY--;
                    break;
                case ConsoleKey.DownArrow:
                case ConsoleKey.S:                    
                    if (_IndexY < 2) _IndexY++;
                    break;
                case ConsoleKey.LeftArrow:
                case ConsoleKey.A:                    
                    if (_IndexX > 0) _IndexX--;
                    break;
                case ConsoleKey.RightArrow:
                case ConsoleKey.D:                    
                    if (_IndexX < 2) _IndexX++;
                    break;
            }
            DrawCursor(Pixel);
        }

        private bool AddCell(char moveSign) 
        {
            if (Cells[_IndexX, _IndexY].Type == 'N')
            { 
                Cells[_IndexX, _IndexY] = new Cell(moveSign, _PosX + 4 + 12 * _IndexX, _PosY + 2 + 6 * _IndexY);
                return true;
            }
            else return false;
        }

        public void ResetGrid()
        {
            for (int i = 0; i < 3; i++) {
                for (int j = 0; j < 3; j++) {
                    Cells[i, j] = new Cell('N');
                }
            }
            _IndexX = 0;
            _IndexY = 0;
        }

        public char CheckWin()
        {
            char index = 'N';
            for (int i = 0; i < 3; i++) {

                // Check lines.
                if ((Cells[i, 0].Type == Cells[i, 1].Type) && (Cells[i, 0].Type == Cells[i, 2].Type))
                {
                    index = Cells[i, 0].Type;
                    break;
                }

                // Check columns.
                if ((Cells[0, i].Type == Cells[1, i].Type) && (Cells[0, i].Type == Cells[2, i].Type))
                { 
                    index = Cells[0, i].Type;    
                    break;
                }                
            }

            // Check diagonals.
            if ( ((Cells[1, 1].Type == Cells[0, 0].Type) && (Cells[1, 1].Type == Cells[2, 2].Type)) 
            ||  ( (Cells[1, 1].Type == Cells[0, 2].Type) && (Cells[1, 1].Type == Cells[2, 0].Type)) )
            { 
                index = Cells[1, 1].Type;
            }
            return index;
        }        

        public void DrawCursor(string symbol)
        {
            // If symbol == "  " we just erase unused cursor.
            if (symbol == "██") 
            {
                TextColor(ConsoleColor.DarkGray);
                BackColor(ConsoleColor.DarkGray);
            }

            // Cursor at top.
            WriteAt(symbol, _PosX + 4 + _IndexX * 12, _PosY - 3);
            WriteAt(symbol, _PosX + 8 + _IndexX * 12, _PosY - 3);
            WriteAt(symbol, _PosX + 6 + _IndexX * 12, _PosY - 2);

            // Cursor at right side.
            WriteAt(symbol, _PosX + 42, _PosY + 2 + _IndexY * 6);
            WriteAt(symbol, _PosX + 40, _PosY + 3 + _IndexY * 6);
            WriteAt(symbol, _PosX + 42, _PosY + 4 + _IndexY * 6);

            for (int i = 1; i < 6; i++) {
                WriteAt("          ", _PosX + 2 + 12 * _IndexX, _PosY + i + 6 * _IndexY);
            }

            BackColor(Program.DefaultBackColor);
            TextColor(Program.DefaultTextColor);

            Cells[_IndexX, _IndexY].Draw();
        }
        // 
        // 
        // 
    }
}
