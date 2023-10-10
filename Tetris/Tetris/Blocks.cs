using System;
using System.Collections.Generic;
using System.Text;

namespace Tetris
{
   

    public class Block
    {

        //int Row, Column;
        public bool[,] klocek = new bool[4, 4];
        public int Y;
        public int X;
        //public int offset;
        public int orientation;
        public ColisionPoint[] ColisionArray;
        public Block()
        {
            Y = 0;
            X = 3;
            orientation = 0;
            //offset = new Position(StartOffset.Column, StartOffset.Row);

        }

        public void AddColisionPoint (ColisionPoint P)
        {
            if (ColisionArray == null)
            {
                ColisionArray = new ColisionPoint[1];
                ColisionArray[0] = P;
            }
            else
            {
                ColisionPoint[] TEMP = new ColisionPoint[ColisionArray.Length + 1];
                int idx = 0;
                foreach (ColisionPoint C in ColisionArray)
                {
                    TEMP[idx] = C;
                    idx++;
                }
                TEMP[idx] = P;
                ColisionArray = TEMP;
            }
        }
        public struct ColisionPoint
        {
            public int orientation;
            public int offset_X;
            public int offset_Y;           
        }

        public ColisionPoint CreateColisionPoint(int O, int OX, int OY)
        {
            ColisionPoint C = new ColisionPoint();
            C.orientation = O;
            C.offset_X = OX;
            C.offset_Y = OY;
            return C;
        }

        public void Show()
        {
            int Temp_Y = Y;
            
            while (Temp_Y > 0)
            {
                Console.WriteLine("");
                Temp_Y--;
            }
            for (int i = 0; i < 4; i++)
            {
                int Temp_X = X;
                for (int j = 0; j < 4; j++)
                {
                    if (j == 0)
                    {
                        while (Temp_X > 0)
                        {
                            Console.Write(" ");
                            Temp_X--;
                        }
                    }
                    if (klocek[i, j])
                        Console.Write("■");
                    else
                        Console.Write(" ");
                }
                Console.WriteLine("");
            }
        }
        
        public bool Collision(ref Siatka S)
        {
            bool IsColision = false;
            foreach (ColisionPoint C in ColisionArray)
            {
                if (C.orientation == orientation)
                {
                    if (S.GetValueForPoint(C.offset_X + X, C.offset_Y + Y))
                        IsColision = true;
                }
            }

            if (IsColision)
            {
                for (S.x = 3; S.x < 0 - 4; S.x++)
                {
                    for (S.y = 5; S.y < 0 - 4; S.y++)
                    {
                        if (klocek[S.x + X, S.y + Y])
                        {
                            S.array[S.x, S.y] = true;
                        }
                    }
                }
            }
            return IsColision;
        }

        public void Rotate()
        {
            bool[,] temp = new bool[4, 4];
            for (int i = 0; i < 4; i++)
            {
                for (int j = 3; j >=0; j--)
                {
                    if (klocek[i, 3-j])
                        temp[j, i] = true;
                    else
                        temp[j, i] = false;
                }
            }
            klocek = temp;
            orientation++;
            if (orientation == 4)
                orientation = 0;

        }


        public void Down()
        {
            Y++;
        }

        public void Right()
        {
            X++;
        }

        public void Left()
        {
            X--; 
        }

    }
    class Blocks
    {
        
    }
}
