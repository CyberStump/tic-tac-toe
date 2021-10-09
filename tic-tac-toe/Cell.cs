
namespace tic_tac_toe
{
    class Cell : API
    {
        public char Type { private set; get; } = 'N';
        private int PosX, PosY;

        public Cell(char type, int posX, int posY) 
        {
            Type = type;
            PosX = posX;
            PosY = posY;
        }

        public Cell(char type)
        {
            Type = type;
        }

        public void Draw()
        {
            if(Type == 'O')
            {
                WriteAt("██████", PosX, PosY);
                WriteAt("██", PosX, PosY + 1);
                WriteAt(    "██", PosX + 4, PosY + 1);
                WriteAt("██████", PosX, PosY + 2);
            }
            else if(Type == 'X')
            {
                WriteAt("██", PosX, PosY);
                WriteAt(    "██", PosX + 4, PosY);
                WriteAt(  "██", PosX + 2, PosY + 1);
                WriteAt("██", PosX, PosY + 2);
                WriteAt("██", PosX + 4, PosY + 2);
            }
        }
        //
        //
        //
    }
}
