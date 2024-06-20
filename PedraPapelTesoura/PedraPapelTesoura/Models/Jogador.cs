using CommunityToolkit.Mvvm.ComponentModel;
using PedraPapelTesoura.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PedraPapelTesoura.Models
{
    public class Jogador
    {
        public int Pontuacao { get; set; }
        public string Sorteio { get; set; }
        private int temp { get; set; }

        public Jogador()
        {
            Pontuacao = 0;
        }

        public void Escolhrer(String escolha)
        {
            Sorteio = escolha;
        }

        public void Jogar()
        {
            Random rnd = new Random();
            temp = rnd.Next(3);
            if (temp == 1)
            {
                Sorteio = "Pedra";
            }
            else if (temp == 2)
            {
                Sorteio = "Papel";
            }
            else
            {
                Sorteio = "Tesoura";
            }
            this.Escolhrer(Sorteio);
        }
    }
}