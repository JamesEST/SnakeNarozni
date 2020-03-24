using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeNarozni
{
    class Snake : Figure
    {

        public Snake(point tail, int lenght, Direction direction)
        {
            pList = new List<point>();
            for(int i = 0; i < lenght; i++)
            {
                point p = new point(tail);
                p.Move(i, direction);
                pList.Add(p);
            }
        }
    }
}