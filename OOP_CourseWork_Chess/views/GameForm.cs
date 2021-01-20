using OOP_CourseWork_Chess.Properties;
using OOP_CourseWork_Chess.units;
using OOP_CourseWork_Chess.units.black;
using OOP_CourseWork_Chess.units.white;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OOP_CourseWork_Chess.views
{
    public partial class GameForm : Form
    {
        public GameForm()
        {
            InitializeComponent();
            CreateUnits();
            Draw();
        }

        //Drawing Part
        Bitmap bitmap;
        Graphics graph;

        BoardLibrary.Board board = new BoardLibrary.Board();
        private List<Unit> units;

        public void CreateUnits()
        {
            units = new List<Unit> { };

            units.Add(new RookBlack("rook", "Black", board.cells[0,0], new Bitmap(Resources.rookB, BoardLibrary.Cell.size)));
            units.Add(new KnightBlack("knight", "Black", board.cells[1, 0], new Bitmap(Resources.knightB, BoardLibrary.Cell.size)));
            units.Add(new BishopBlack("bishop", "Black", board.cells[2, 0], new Bitmap(Resources.bishopB, BoardLibrary.Cell.size)));
            units.Add(new QueenBlack("queen", "Black", board.cells[3, 0], new Bitmap(Resources.queenB, BoardLibrary.Cell.size)));
            units.Add(new KingBlack("king", "Black", board.cells[4, 0], new Bitmap(Resources.kingB, BoardLibrary.Cell.size)));
            units.Add(new BishopBlack("bishop", "Black", board.cells[5, 0], new Bitmap(Resources.bishopB, BoardLibrary.Cell.size)));
            units.Add(new KnightBlack("knight", "Black", board.cells[6, 0], new Bitmap(Resources.knightB, BoardLibrary.Cell.size)));
            units.Add(new RookBlack("rook", "Black", board.cells[7, 0], new Bitmap(Resources.rookB, BoardLibrary.Cell.size)));

            units.Add(new PawnBlack("pawn", "Black", board.cells[0, 1], new Bitmap(Resources.pawnB, BoardLibrary.Cell.size)));
            units.Add(new PawnBlack("pawn", "Black", board.cells[1, 1], new Bitmap(Resources.pawnB, BoardLibrary.Cell.size)));
            units.Add(new PawnBlack("pawn", "Black", board.cells[2, 1], new Bitmap(Resources.pawnB, BoardLibrary.Cell.size)));
            units.Add(new PawnBlack("pawn", "Black", board.cells[3, 1], new Bitmap(Resources.pawnB, BoardLibrary.Cell.size)));
            units.Add(new PawnBlack("pawn", "Black", board.cells[4, 1], new Bitmap(Resources.pawnB, BoardLibrary.Cell.size)));
            units.Add(new PawnBlack("pawn", "Black", board.cells[5, 1], new Bitmap(Resources.pawnB, BoardLibrary.Cell.size)));
            units.Add(new PawnBlack("pawn", "Black", board.cells[6, 1], new Bitmap(Resources.pawnB, BoardLibrary.Cell.size)));
            units.Add(new PawnBlack("pawn", "Black", board.cells[7, 1], new Bitmap(Resources.pawnB, BoardLibrary.Cell.size)));

            units.Add(new RookWhite("rook", "White", board.cells[0, 7], new Bitmap(Resources.rookW, BoardLibrary.Cell.size)));
            units.Add(new KnightWhite("knight", "White", board.cells[1, 7], new Bitmap(Resources.knightW, BoardLibrary.Cell.size)));
            units.Add(new BishopWhite("bishop", "White", board.cells[2, 7], new Bitmap(Resources.bishopW, BoardLibrary.Cell.size)));
            units.Add(new QueenWhite("queen", "White", board.cells[3, 7], new Bitmap(Resources.queenW, BoardLibrary.Cell.size)));
            units.Add(new KingWhite("king", "White", board.cells[4, 7], new Bitmap(Resources.kingW, BoardLibrary.Cell.size)));
            units.Add(new BishopWhite("bishop", "White", board.cells[5, 7], new Bitmap(Resources.bishopW, BoardLibrary.Cell.size)));
            units.Add(new KnightWhite("knight", "White", board.cells[6, 7], new Bitmap(Resources.knightW, BoardLibrary.Cell.size)));
            units.Add(new RookWhite("rook", "White", board.cells[7, 7], new Bitmap(Resources.rookW, BoardLibrary.Cell.size)));

            units.Add(new PawnWhite("pawn", "White", board.cells[0, 6], new Bitmap(Resources.pawnW, BoardLibrary.Cell.size)));
            units.Add(new PawnWhite("pawn", "White", board.cells[1, 6], new Bitmap(Resources.pawnW, BoardLibrary.Cell.size)));
            units.Add(new PawnWhite("pawn", "White", board.cells[2, 6], new Bitmap(Resources.pawnW, BoardLibrary.Cell.size)));
            units.Add(new PawnWhite("pawn", "White", board.cells[3, 6], new Bitmap(Resources.pawnW, BoardLibrary.Cell.size)));
            units.Add(new PawnWhite("pawn", "White", board.cells[4, 6], new Bitmap(Resources.pawnW, BoardLibrary.Cell.size)));
            units.Add(new PawnWhite("pawn", "White", board.cells[5, 6], new Bitmap(Resources.pawnW, BoardLibrary.Cell.size)));
            units.Add(new PawnWhite("pawn", "White", board.cells[6, 6], new Bitmap(Resources.pawnW, BoardLibrary.Cell.size)));
            units.Add(new PawnWhite("pawn", "White", board.cells[7, 6], new Bitmap(Resources.pawnW, BoardLibrary.Cell.size)));
        }

        public void Draw()
        {
            bitmap = new Bitmap(pictureBox.Width, pictureBox.Height);
            graph = Graphics.FromImage(bitmap);


            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (board.cells[j, i].Color == "white")
                    {
                        graph.FillRectangle(Brushes.LightGray, board.cells[j, i].Rect);
                    }
                    else if (board.cells[j, i].Color == "black")
                    {
                        graph.FillRectangle(Brushes.DarkGray, board.cells[j, i].Rect);
                    }
                }
            }

            foreach (Unit unit in units)
            {
                graph.DrawImage(unit.Image, unit.Cell.X, unit.Cell.Y);
            }

            pictureBox.Image = bitmap;
        }

        //Logic Part
        private bool isMoving = false;
        private Unit currentUnit = null;
        private bool whiteTurn = true;
        Pen pen = new Pen(Color.Green, 2);

        internal List<Unit> Units { get => units; set => units = value; }

        Unit GetUnitByCell(BoardLibrary.Cell cell)
        {
            Unit result = null;
            foreach (Unit unit in units)
            {
                if (cell.Equals(unit.Cell))
                {
                    result = unit;
                }
            }
            return result;
        }

        private void pictureBox_MouseClick(object sender, MouseEventArgs e)
        {
            if (isMoving)
            {
                if (GetUnitByCell(board.GetCell(e.Location)) != null)
                {
                    units.Remove(GetUnitByCell(board.GetCell(e.Location)));
                }
                currentUnit.Move(board.GetCell(e.Location));
                isMoving = false;
                Draw();

            }
            else
            {
                foreach (Unit unit in units)
                {
                    if ((whiteTurn && unit.Color == "White") || (!whiteTurn && unit.Color == "Black"))
                    {
                        if (unit.Cell.Rect.Contains(new Point(e.X, e.Y)))
                        {
                            isMoving = true;
                            currentUnit = unit;
                            List<BoardLibrary.Cell> steps = currentUnit.CheckMoves();
                            foreach (BoardLibrary.Cell cell in steps)
                            {
                                graph.DrawEllipse(pen, cell.Rect);
                            }
                            whiteTurn = !whiteTurn;
                            pictureBox.Image = bitmap;
                        }
                    }
                }
            }
        }
    }
}
