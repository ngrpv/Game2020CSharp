using WindowsFormsApp1.Domain;

namespace WindowsFormsApp1.Views
{
    public interface IControl
    {
        void Configure(Game game);
        void Show();
    }
}