using System;
using System.Windows.Forms;
using WindowsFormsApp1.Domain;

namespace WindowsFormsApp1.Views
{
    public partial class MainForm : Form
    {
        
        private Game game;

        public MainForm()
        {
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
                    ShowOptionsScreen();
                    break;
                case GameStage.Finished:
                    //ShowFinishedScreen();
                    break;
                case GameStage.NotStarted:
                    ShowStartScreen();
                    break;
                case GameStage.Selection:
                    break;
                case GameStage.Playing:
                    ShowPlayingScreen();
                    break;
                default:
                    ShowStartScreen();
                    break;
            }
        }

        private void ShowStartScreen()
        {
            HideScreens();
            menuControl.Configure(game);
            menuControl.Show();
        }

        private void ShowOptionsScreen()
        {
            HideScreens();
            optionsControl1.Configure(game);
            optionsControl1.Show();
        }
        
        private void ShowPlayingScreen()
        {
            HideScreens();
            playingControl.Configure(game);
            playingControl.Show();
        }

        private void HideScreens()
        {
            menuControl.Hide();
            optionsControl1.Hide();
        }


        private void menuControl1_Load(object sender, EventArgs e)
        {
        }
    }
}