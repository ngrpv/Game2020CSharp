using System.Windows.Forms;
using WindowsFormsApp1.Domain;

namespace WindowsFormsApp1.Views
{
    public  partial class MainForm : Form
    {
        private readonly Game game;

        public MainForm()
        {
            DoubleBuffered = true;
            InitializeComponent();
            game = new Game();
            game.StageChanged += Game_OnStageChanged;
            game.ChangeStage(GameStage.NotStarted);
        }


        private void Game_OnStageChanged(GameStage stage)
        {
            switch (stage)
            {
                case GameStage.Options:
                    ShowScreen(optionsControl);
                    break;
                case GameStage.NotStarted:
                    ShowScreen(menuControl);
                    break;
                case GameStage.Selection:
                    break;
                case GameStage.Playing:
                    ShowScreen(playingControl);
                    break;
                case GameStage.Updated:
                    break;
                case GameStage.Stopped:
                    playingControl.Stop();
                    ShowScreen(menuControl);
                    break;
                case GameStage.Freezed:
                    ShowScreen(_gameOverControl);
                    break;
                default:
                    ShowScreen(menuControl);
                    break;
            }
        }
        
        private void ShowScreen(IControl control)
        {
            HideScreens();
            control.Configure(game);
            control.Show();
            ActiveControl = control as UserControl;
        }

        private void HideScreens()
        {
            menuControl.Hide();
            optionsControl.Hide();
            playingControl.Hide();
        }
        
    }
}