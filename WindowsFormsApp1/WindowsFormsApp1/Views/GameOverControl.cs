using System.Windows.Forms;
using WindowsFormsApp1.Domain;

namespace WindowsFormsApp1.Views
{
    public partial class GameOverControl : UserControl,IControl
    {
        public GameOverControl()
        {
            InitializeComponent();
        }

        public void Configure(Game game)
        {
        }


    }
}