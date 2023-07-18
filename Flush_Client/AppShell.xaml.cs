using Flush_Client.Pages;

namespace Flush_Client
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute(nameof(ManageIbsPage), typeof(ManageIbsPage));

        }
    }
}