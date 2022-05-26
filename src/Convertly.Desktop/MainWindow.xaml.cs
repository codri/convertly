using Convertly.Desktop.ViewModels;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Convertly.Desktop
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private static Regex ValidNumber = new Regex("[^0-9\\.]+");

        public MainWindow()
        {
            this.InitializeComponent();
            this.DataContext = new MainWindowViewModel();

            this.SourceType.SelectionChanged += ComboboxSelectionChanged;
            this.TargetType.SelectionChanged += ComboboxSelectionChanged;
        }

        // Reset the selected index when the underlying data changes
        private void ComboboxSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (this.SourceType.SelectedIndex == -1)
            {
                this.SourceType.SelectedIndex = 0;
            }

            if (this.TargetType.SelectedIndex == -1)
            {
                this.TargetType.SelectedIndex = 0;
            }
        }

        // only allow digits and dots in the TextBoxes
        public void ValidNumberPreview(object sender, TextCompositionEventArgs e)
        {
            e.Handled = ValidNumber.IsMatch(e.Text);
        }
    }
}
