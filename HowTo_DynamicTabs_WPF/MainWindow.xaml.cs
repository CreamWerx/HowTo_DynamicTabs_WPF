using System.Windows;
using System.Windows.Controls;

namespace HowTo_DynamicTabs_WPF;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }
    public void AddNewTabItem(string headerName)
    {
        TabItem newTabItem = CreateNewTabItem(headerName);
        tabControl.Items.Add(newTabItem);
    }

    private TabItem CreateNewTabItem(string headerName)
    {
        var newTabHeader = new TabHeader(headerName);

        // Subscription to necessary event is needed
        newTabHeader.TabCloseClicked += TabHeader_TabCloseClicked;
        return new TabItem { Header = newTabHeader };
    }

    private void TabHeader_TabCloseClicked(object? sender, TabItem e)
    {
        CloseTab(e);
    }

    private void CloseTab(TabItem e)
    {
        tabControl.Items.Remove(e);
    }

    private void Button_Click(object sender, RoutedEventArgs e)
    {
        AddNewTabItem(tbInput.Text);
    }
}