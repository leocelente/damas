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
    public partial class Pre : Form
    {
        public Pre()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Jogador jog1 = new Jogador(textBox1.Text, comboBox1.Text);
            Jogador jog2 = new Jogador(textBox2.Text, label1.Text);
            Jogo j = new Jogo(jog1, jog2);
            j.MdiParent = this.ParentForm;
            j.Show();

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 1)
                label1.Text = "Preto";
            else if (comboBox1.SelectedIndex == 2)
                label1.Text = "Branca";
            else if (comboBox1.SelectedIndex == 3)
                label1.Text = "______";
            

        }

        
    }
}
