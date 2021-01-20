﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_CourseWork_Chess.units.white
{
    class KingWhite : Unit, IFirstMoveUnit
    {
        public KingWhite(string type, string color, BoardLibrary.Cell cell, Image image) : base(type, color, cell, image) { }

        public bool CheckFirstMove()
        {
            throw new NotImplementedException();
        }
    }
}
