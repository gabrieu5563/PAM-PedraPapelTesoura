using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Windows.Input;
using PedraPapelTesoura.Models;
using CommunityToolkit.Mvvm.Input;

namespace PedraPapelTesoura.ViewModel
{
    public partial class PedraPapelTesouraViewModel : ObservableObject
    {
        private Jogador player;
        private Jogador oponente;

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
            player = new Jogador();
            oponente = new Jogador();
            JogarCommand = new RelayCommand(Jogar);
        }

        public ICommand JogarCommand { get; }

        public void Jogar()
        {
            player.Jogar();

            if (String.IsNullOrEmpty(Escolha))
            {
                App.Current.MainPage.DisplayAlert("Pedra papel tesoura", "Selecione pedra, papel ou tesoura para prosseguir", "ok");
            }
            else
            {
                if (Escolha == "pedra" && player.Sorteio == "tesoura"
                || Escolha == "papel" && player.Sorteio == "pedra"
                || Escolha == "tesoura" && player.Sorteio == "papel")
                {
                    Resultado = "Você ganhou";
                    PontuacaoJogador = player.Pontuar();
                }
                else if (Escolha == player.Sorteio)
                {
                    Resultado = "Empate!";
                }
                else
                {
                    Resultado = "Você perdeu";
                    PontuacaoOponente = oponente.Pontuar();
                }

                ImagemJogador = Escolha + ".png";
                ImagemOponente = player.Sorteio + ".png";

                if (PontuacaoJogador >= 10 || PontuacaoOponente >= 10)
                {
                    String vencedor = PontuacaoJogador >= 10 ? "você" : "o oponente";
                    App.Current.MainPage.DisplayAlert("Pedra papel tesoura", "Fim de jogo, " + vencedor + " ganhou", "ok");
                    PontuacaoJogador = 0;
                    PontuacaoOponente = 0;
                    player.ResetarPontuacao();
                    oponente.ResetarPontuacao();
                }
            }
        }
    }
}
