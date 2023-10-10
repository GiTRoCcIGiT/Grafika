using System;
using System.Collections.Generic;
using System.Text;

namespace Tetris
{
    class OBlock:Block
    {
        //OBlock
        //(1,1), (1,2), (2,1), (2,2)
        //(1,1), (1,2), (2,1), (2,2)
        //(1,1), (1,2), (2,1), (2,2)
        //(1,1), (1,2), (2,1), (2,2)
        public OBlock()
        {
            klocek = new bool[4, 4]
            {
                {false, false, false, false},
                {false, true, true, false},
                {false, true, true, false},
                {false, false, false, false},
            };

            AddColisionPoint(CreateColisionPoint(0, 1, 3));
            AddColisionPoint(CreateColisionPoint(0, 2, 3));

            AddColisionPoint(CreateColisionPoint(1, 1, 3));
            AddColisionPoint(CreateColisionPoint(1, 2, 3));

            AddColisionPoint(CreateColisionPoint(2, 1, 3));
            AddColisionPoint(CreateColisionPoint(2, 2, 3));

            AddColisionPoint(CreateColisionPoint(3, 1, 3));
            AddColisionPoint(CreateColisionPoint(3, 2, 3));

        }
    }
}
