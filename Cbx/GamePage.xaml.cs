using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using MonoGame.Framework;
using Windows.ApplicationModel.Activation;


namespace Cbx
{
    /// <summary>
    /// The root page used to display the game.
    /// </summary>
    public sealed partial class GamePage : SwapChainBackgroundPanel
    {
        readonly Cubix _game;

        public GamePage(LaunchActivatedEventArgs args)
        {
            this.InitializeComponent();

            // Create the game.
            _game = XamlGame<Cubix>.Create(args, Window.Current.CoreWindow, this);
        }
        // Launch a demo
        public void LaunchDemo(string stateName)
        {
            _game.RunState(stateName);
        }

        // Return to menu
        private void Image_Tapped(object sender, Windows.UI.Xaml.Input.TappedRoutedEventArgs e)
        {
            _game.Pause();
            var mainPage = App.MenuPage;
            Window.Current.Content = mainPage;
            Window.Current.Activate();
        }
    }
}
