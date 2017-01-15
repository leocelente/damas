using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace damas
{
    class Jogador
    {
        public string _name;
        public string _color;
        
        public int _ref;
        public int points { get; set;}


        public Jogador()
        {
            _name = "";
            _color = "";
        }
        public Jogador(string name, string color)
        {
            _name = name;
            _color = color;
            if (color == "Branca") { 
                _ref = 1; 
               
            }
            else if (color == "Preto") {
                _ref = 2;
               
            }
        }

        

        
    }
}
