using OOP_CourseWork_Chess.views;
using System;
using System.Windows.Forms;

namespace OOP_CourseWork_Chess
{
    public partial class Form : System.Windows.Forms.Form
    {
        public Form()
        {
            InitializeComponent();
        }

        private void новаяИграToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            GameForm gameForm = new GameForm();
            gameForm.Show();
        }

        private void главнаяToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form form = new Form();
            form.Show();
        }

        private void справкаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            AboutForm aboutForm = new AboutForm();
            aboutForm.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            GameForm gameForm = new GameForm();
            gameForm.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            RulesForm rulesForm = new RulesForm();
            rulesForm.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            AuthorForm authorForm = new AuthorForm();
            authorForm.Show();
        }

        private void правилаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            RulesForm rulesForm = new RulesForm();
            rulesForm.Show();
        }

        private void проАвтораToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            AuthorForm authorForm = new AuthorForm();
            authorForm.Show();
        }

        private void закончитьИгруToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}