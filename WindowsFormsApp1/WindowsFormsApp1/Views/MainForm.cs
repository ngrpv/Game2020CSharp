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
            var start = new MenuControl();
            start.Configure(game);
            start.Show();
        }
    }
}