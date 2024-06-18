using System.Windows;
using System.Windows.Controls;

namespace HowTo_DynamicTabs_WPF;
/// <summary>
/// Interaction logic for TabHeader.xaml
/// </summary>
public partial class TabHeader : UserControl
{
    public event EventHandler<int> TabCloseClicked;
    int _index;

    public TabHeader()
    {
        InitializeComponent();
    }
    public TabHeader(int index, string headerName)
    {
        InitializeComponent();
        _index = index;
        NameLabel.Content = headerName;
    }

    private void button_close_Click(object sender, RoutedEventArgs e)
    {
        TabCloseClicked?.Invoke(this, _index);
    }
}
