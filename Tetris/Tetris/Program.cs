using System;

namespace Tetris
{

    public class Siatka
    {
        public bool[,] array = new bool[10, 16];
        public int x;
        public int y;

         
        public bool GetValueForPoint(int X, int Y)
        {
            return array[X, Y];
        }


        public Siatka()
        {
            for (int i = 0; i < array.GetLength(0); i++)
                for (int j = 0; j < array.GetLength(1); j++)
                    array[i, j] = false;
        }
        

        public void test (ref int i)
        {
            for (int idx = 0; idx < 10; idx++)
                i++;
        }
    }                                    
                                         
    class Program
    {
        static void Main(string[] args)
        {
             int i = 20;
             Block K = new TBlock();
             while (i>0)
             {
                 Console.Clear();                
                 K.Show();
                 //K.Right();
                 K.Down();
                 System.Threading.Thread.Sleep(500);
                 i--;
             }

            /*
            int i = 10;
            Console.WriteLine(i);
            new Siatka().test(ref i);
            Console.WriteLine(i);
            */

            //Console.WriteLine();
            //K = new LBlock();
            //K.Show();
            //K = new OBlock();
            //K.Show();
            //K = new TBlock();
            //K.Show();
            //K = new ZBlock();
            //K.Show();
            //K = new SBlock();
            //K.Show();
            //K = new IBlock();
            //K.Show();

        }
    }
}
