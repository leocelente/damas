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
    public partial class Jogo : Form
    {
        public static int n_jogada = 0;
        int index = 37;
        int x, y, value;
        Jogador _j1, _j2;
        bool is_j1 = true;
        int x_ant, y_ant = 7;

        public static int points = 0;


        public static Button[] btns = new Button[36];
        public Jogo()
        {
            InitializeComponent();
        }

        public Jogo(object j1_, object j2_)
        {
            Jogador j1 = (Jogador)j1_;
            Jogador j2 = (Jogador)j2_;

            InitializeComponent();
            btns = this.Controls.OfType<Button>().ToArray();
            Array.Reverse(btns);
            _j1 = j1;
            _j2 = j2;
            
        }

        #region nada
        private void Jogo_Click(object sender, EventArgs e)
        {
           
        }

        private void Jogo_MouseCaptureChanged(object sender, EventArgs e)
        {

        }

        private void Jogo_MouseClick(object sender, MouseEventArgs e)
        {
          
        }

        #endregion

        private void newPlay(object sender, EventArgs e) //CLICK EM ALGUM BOTAO
        {
            if (n_jogada > 1)// NAO É O PRIMEIRO (0) OU SEGUNDO (1) CLICK
            {
                is_j1 = !is_j1;//MUDA O JOGADOR
                n_jogada = 0;
            }
            #region pega index do botao
            Button b = (Button)sender;
            foreach (Button btn in btns)
                if (b.Name.ToString() == btn.Name.ToString()) 
                { 
                    index = Array.IndexOf(btns, btn);
                    break;
                }
            #endregion

            if (n_jogada == 0) btns[index].ForeColor = Color.Red;
                else if (n_jogada == 1) btns[index].ForeColor = Color.Blue;

                x = (index / 6);
                y = (index % 6);

                move(n_jogada, x, y);

                n_jogada++;
                btns[index].ForeColor = SystemColors.ControlText;
        }

        public void move(int parte_j, int x, int y)
        {
            if (parte_j == 0)//PRIMEIRA PARTE DA JOGADA (GUARDA P1)
            {
                if (Tabuleiro.tab[x, y]  == 1 && is_j1)//É JOGADOR 1 MOVENDO PECA DE 1
                {
                    x_ant = x;
                    y_ant = y;
                }
                else if (Tabuleiro.tab[x, y] == 2 && !is_j1)//É JOGADOR 2 MOVENDO PECA DE 2
                {
                    x_ant = x;
                    y_ant = y;
                }
                else //JOGADOR MOVENDO PECA DO OUTRO
                {
                    label3.Text = ("NAO!");
                    parte_j = 0;
                    n_jogada = -1;
                }
                
            }
            else//SEGUNDA PARTE DA JOGADA (MUDA COR E VALOR E DA O PONTO)
            {
                if (Tabuleiro.tab[x, y]  == 0 && (  (x == x_ant + 1 || x == x_ant - 1)
                                                    &&
                                                    (y == y_ant + 1 || y == y_ant - 1 )))
                {
                    Tabuleiro.tab[x, y] = Tabuleiro.tab[x_ant, y_ant];
                    Tabuleiro.tab[x_ant, y_ant] = 0;

                }else if (Tabuleiro.tab[x, y]  == 0 && (  (x == x_ant + 2 || x == x_ant - 2)
                                                    &&
                                                    (y == y_ant + 2 || y == y_ant - 2 )))
                {
                    if ((x == x_ant + 2) && (y == y_ant + 2))
                    {
                        if (is_j1 && Tabuleiro.tab[x - 1, y - 1] == 2) { _j1.points++; Tabuleiro.tab[x - 1, y - 1] = 0; }
                        else if (!is_j1 && Tabuleiro.tab[x - 1, y - 1] == 1) { _j2.points++; Tabuleiro.tab[x - 1, y - 1] = 0; }
                        Tabuleiro.tab[x, y] = Tabuleiro.tab[x_ant, y_ant];
                        Tabuleiro.tab[x_ant, y_ant] = 0;
                    }
                    else if ((x == x_ant - 2) && (y == y_ant - 2))
                    {
                        if (is_j1 && Tabuleiro.tab[x + 1, y + 1] == 2) { _j1.points++; Tabuleiro.tab[x + 1, y + 1] = 0; }
                        else if (!is_j1 && Tabuleiro.tab[x + 1, y + 1] == 1) { _j2.points++; Tabuleiro.tab[x + 1, y + 1] = 0; }
                        Tabuleiro.tab[x, y] = Tabuleiro.tab[x_ant, y_ant];
                        Tabuleiro.tab[x_ant, y_ant] = 0;
                    }
                    else if ((x == x_ant - 2) && (y == y_ant + 2))
                    {
                        if (is_j1 && Tabuleiro.tab[x + 1, y - 1] == 2) { _j1.points++; Tabuleiro.tab[x + 1, y - 1] = 0; }
                        else if (!is_j1 && Tabuleiro.tab[x + 1, y - 1] == 1) { _j2.points++; Tabuleiro.tab[x + 1, y - 1] = 0; }
                        Tabuleiro.tab[x, y] = Tabuleiro.tab[x_ant, y_ant];
                        Tabuleiro.tab[x_ant, y_ant] = 0;
                    }
                    else if ((x == x_ant + 2) && (y == y_ant - 2))
                    {
                        if (is_j1 && Tabuleiro.tab[x - 1, y + 1] == 2) { _j1.points++; Tabuleiro.tab[x - 1, y + 1] = 0; }
                        else if (!is_j1 && Tabuleiro.tab[x - 1, y + 1] == 1) { _j2.points++; Tabuleiro.tab[x - 1, y + 1] = 0; }
                        Tabuleiro.tab[x, y] = Tabuleiro.tab[x_ant, y_ant];
                        Tabuleiro.tab[x_ant, y_ant] = 0;
                    }
                    
                }
                
                check();
            }
            
            label1.Text = "Jogador 1: " + _j1._name + " | Cor: " + _j1._color + " | Points: " + _j1.points.ToString();
            label2.Text = "Jogador 2: " + _j2._name + " | Cor: " + _j2._color + " | Points: " + _j2.points.ToString();
        }
        private void Jogo_Load(object sender, EventArgs e) //MOSTRA INFO DO JOGADOR
        {
            Tabuleiro t = new Tabuleiro();
            label1.Text = "Jogador 1: " + _j1._name + " | Cor: " + _j1._color + " | Points: " + _j1.points.ToString();
            label2.Text = "Jogador 2: " + _j2._name + " | Cor: " + _j2._color + " | Points: " + _j2.points.ToString();
            check();
        }

        public void check()
        {
            foreach (Button btn in btns)
            {
                index = Array.IndexOf(btns, btn);
                x = (index / 6);
                y = (index % 6);
                value = Tabuleiro.tab[x, y];
                //btns[index].Text = index.ToString() + "(" + x.ToString() + ", " + y.ToString() + ", " + value.ToString() + ")";
                if (value == 1) btn.BackColor = Color.White;
                else if (value == 2) btn.BackColor = Color.Red;
                else { btn.BackColor = Color.Black; btn.ForeColor = Color.Black; }

            }
        }
    }
}
