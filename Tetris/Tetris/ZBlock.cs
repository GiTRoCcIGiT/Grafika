using System;
using System.Collections.Generic;
using System.Text;

namespace Tetris
{
    class ZBlock:Block
    {
        //ZBlock
        //(1,1), (2,1), (2,2), (3,2)
        //(3,1), (3,2), (2,2), (2,3)
        //(1,2), (2,2), (2,3), (3,3)
        //(2,1), (2,2), (1,2), (1,3)
        public ZBlock()
        {
            klocek = new bool[4, 4]
            {
                {false, false, false, false},
                {false, true, true, false},
                {false, false, true, true},
                {false, false, false, false},
            };

            AddColisionPoint(CreateColisionPoint(0, 1, 2));
            AddColisionPoint(CreateColisionPoint(0, 2, 3));
            AddColisionPoint(CreateColisionPoint(0, 3, 3));

            AddColisionPoint(CreateColisionPoint(1, 1, 3));
            AddColisionPoint(CreateColisionPoint(1, 2, 2));

            AddColisionPoint(CreateColisionPoint(2, 0, 2));
            AddColisionPoint(CreateColisionPoint(2, 1, 3));
            AddColisionPoint(CreateColisionPoint(2, 2, 3));

            AddColisionPoint(CreateColisionPoint(3, 1, 4));
            AddColisionPoint(CreateColisionPoint(3, 2, 3));

        }
    }
}
