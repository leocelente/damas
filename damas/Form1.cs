using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace damas
{
    public partial class Container : Form
    {
        public Container()
        {
            InitializeComponent();
        }

        private void Container_Load(object sender, EventArgs e)
        {
            Pre p = new Pre();
            p.MdiParent = this;
            p.WindowState = FormWindowState.Maximized;
            p.Show();
        }
        public void show_game(){
            Jogo j = new Jogo();
            j.MdiParent = this;
            j.Show();
        }

        

          

        private void windowToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
