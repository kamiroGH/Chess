using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_CourseWork_Chess.units
{
    class Unit
    {
        public Unit(string type, string color, BoardLibrary.Cell cell, Image image)
        {
            Type = type;
            Color = color;
            Cell = cell;
            Image = image;
            possibleSteps = new List<BoardLibrary.Cell> { };
        }

        private string type;
        private string color;
        private BoardLibrary.Cell cell;
        private Image image;
        private List<BoardLibrary.Cell> possibleSteps;

        public string Type { get => type; set => type = value; }
        public string Color { get => color; set => color = value; }
        public BoardLibrary.Cell Cell { get => cell; set => cell = value; }
        public Image Image { get => image; set => image = value; }

        public virtual List<BoardLibrary.Cell> CheckMoves() { return new List<BoardLibrary.Cell> { }; }
        public virtual void Move(BoardLibrary.Cell cell) { }
    }
}