using KeenVPN.Presentation.ViewModels;
using KeenVPN.Infrastructure;
using System.Windows;

namespace KeenVPN.Presentation.Views
{
    public partial class NodeListWindow : Window
    {
        public NodeListWindow()
        {
            InitializeComponent();
            DataContext = new NodeListViewModel(new MockVpnService());
        }
    }
}
