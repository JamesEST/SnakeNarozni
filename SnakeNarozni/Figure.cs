﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeNarozni
{
    class Figure
    {
        protected List<point> pList;

        public void Drow()
        {
            foreach (point p in pList)
            {
                p.draw();
            }
        }
    }
}