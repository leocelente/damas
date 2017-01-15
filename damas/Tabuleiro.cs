using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace damas
{
    class Tabuleiro
    {
        public static int[,] tab = new int[6, 6];
         
        private void encher() 
        {
            for (int l = 0; l < tab.GetLength(0); l++)
            {
                int s = 0;
                int k = 0;
                if (l < 2) k = 1;
                else if (l > 3) k = 2;
                if (l % 2 == 0) s = 0;
                else s = 1;
                for (int i = s; i < tab.GetLength(0); i += 2) tab[l, i] = k;
            }
         }

        public Tabuleiro()
        {
            encher();
        }

    }
}
