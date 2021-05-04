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
                    ShowScreen(optionsControl1);
                    break;
                case GameStage.Finished:
                    //ShowFinishedScreen();
                    break;
                case GameStage.NotStarted:
                    ShowScreen(menuControl);
                    break;
                case GameStage.Selection:
                    break;
                case GameStage.Playing:
                    ShowScreen(playingControl);
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
        }

        private void HideScreens()
        {
            menuControl.Hide();
            optionsControl1.Hide();
            playingControl.Hide();
        }


        private void menuControl1_Load(object sender, EventArgs e)
        {
        }
    }
}