using System;
using System.Windows.Forms;
using WindowsFormsApp1.Domain;

namespace WindowsFormsApp1.Views
{
    public  partial class MainForm : Form
    {
        // Баг с color.Transparent
        // Не плавное обновление дорог
        // Фриз машины после некоторого времени
        // Не добавляются машины в другом потоке
        public Game game;

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
                    ShowScreen(optionsControl1);
                    game.Options.Volume /= 10;
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
                case GameStage.Updated:
                    break;
                case GameStage.Stopped:
                    /*playingControl.InitializeGameObjects();*/
                    playingControl.Stop();
                    ShowScreen(menuControl);
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
            optionsControl1.Hide();
            playingControl.Hide();
        }
        
    }
}