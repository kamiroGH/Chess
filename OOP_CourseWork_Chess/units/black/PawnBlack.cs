using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_CourseWork_Chess.units.black
{
    class PawnBlack : Unit, IFirstMoveUnit
    {
        public PawnBlack(string type, string color, BoardLibrary.Cell cell, Image image) : base(type, color, cell, image) { }
        public bool CheckFirstMove()
        {
            if (Cell.Y/50 == 1)
                return true;
            else
            {
                return false;
            }
        }
        public override List<BoardLibrary.Cell> CheckMoves()
        {
            List<BoardLibrary.Cell> result = new List<BoardLibrary.Cell> { };
            if(Cell.Color == "white")
            {
                result.Add(new BoardLibrary.Cell(Cell.X / 50, Cell.Y / 50 + 1, "black"));
            } 
            else
            {
                result.Add(new BoardLibrary.Cell(Cell.X / 50, Cell.Y / 50 + 1, "white"));
            }
            if (CheckFirstMove())
            {
                result.Add(new BoardLibrary.Cell(Cell.X / 50, Cell.Y / 50 + 2, Cell.Color));
            }


            return result;
        }
        public override void Move(BoardLibrary.Cell cell)
        {
            Cell = cell;
        }
    }
}
