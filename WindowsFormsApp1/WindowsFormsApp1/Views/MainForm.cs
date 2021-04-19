using System;
using System.Windows.Forms;
using WindowsFormsApp1.Domain;

namespace WindowsFormsApp1.Views
{
    public partial class MainForm : Form
    {
        private Game game;
        //private MenuControl menuControl;
        //private OptionsControl optionsControl;
        public MainForm()
        {
            InitializeComponent();
            game = new Game();
            game.StageChanged += Game_OnStageChanged;
            game.ChangeStage(default);
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
                default:
                    ShowStartScreen();
                    break;
            }
        }
        
        private void ShowStartScreen()
        {
           HideScreens();
           menuControl1.Configure(game);
           menuControl1.Show();
        }
        
        public void ShowOptionsScreen()
        {
            HideScreens();
            optionsControl1.Configure(game);
            optionsControl1.Show();
        }

        private void  HideScreens()
        {
            menuControl1.Hide();
            optionsControl1.Hide();
        }


        private void menuControl1_Load(object sender, EventArgs e)
        {
        }


    }
}