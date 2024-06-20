using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PedraPapelTesoura.Models;
using CommunityToolkit.Mvvm.Input;
using System.Windows.Input;

namespace PedraPapelTesoura.ViewModel
{
    public partial class PedraPapelTesouraViewModel : ObservableObject
    {
        [ObservableProperty]
        private string imagemJogador;

        [ObservableProperty]
        private string imagemOponente;

        [ObservableProperty]
        private string resultado;

        [ObservableProperty]
        private string escolha;

        [ObservableProperty]
        private int pontuacaoJogador;

        [ObservableProperty]
        private int pontuacaoOponente;

        public PedraPapelTesouraViewModel()
        {
            JogarCommand = new
            RelayCommand(Jogar);
        }

        public ICommand JogarCommand { get;}

        public void Jogar()
        {
            Jogador player = new Jogador();
            Jogador oponente = new Jogador();
            player.Jogar();

            if (Escolha == "pedra" && player.Sorteio == "tesoura"
                || Escolha == "papel" && player.Sorteio == "pedra"
                || Escolha == "tesoura" && player.Sorteio == "papel")
            {
                Resultado = "Você ganhou";
                player.Pontuacao++;
            } else if (Escolha == player.Sorteio) {
                Resultado = "Empate!";
            }
            else
            {
                Resultado = "Você perdeu";
                oponente.Pontuacao++;
            }

            ImagemJogador = Escolha + ".png";
            ImagemOponente = player.Sorteio + ".png";
        }
    }
}