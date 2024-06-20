using PedraPapelTesoura.ViewModel;

namespace PedraPapelTesoura.View;

public partial class PedraPapelTesoura : ContentPage
{
    public PedraPapelTesoura()
    {
        InitializeComponent();
        BindingContext = new PedraPapelTesouraViewModel();
    }
}