using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;

namespace RPM1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            TextChangedUpdate();
            TextBox1.TextChanged += (s, e) => TextChangedUpdate();
            TextBox2.TextChanged += (s, e) => TextChangedUpdate();
        }

        private void TextChangedUpdate()
        {
            CloseButton.IsEnabled = string.IsNullOrWhiteSpace(TextBox1.Text) && string.IsNullOrWhiteSpace(TextBox2.Text);
        }

        private void FontStyleCombo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (FontStyleCombo.SelectedItem is ComboBoxItem selectedItem)
            {
                string font = selectedItem.Content.ToString();
                TextBox1.FontFamily = new System.Windows.Media.FontFamily(font);
                TextBox2.FontFamily = new System.Windows.Media.FontFamily(font);
            }
        }

        private void OpenButton_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog openFileDialog = new Microsoft.Win32.OpenFileDialog();
            openFileDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";

            if (openFileDialog.ShowDialog() == true)
            {
                string filePath = openFileDialog.FileName;
                TextBox1.Text = File.ReadAllText(filePath); // Загружает текст в первое текстовое поле
            }
        }

        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            TextBox1.Clear();
            TextBox2.Clear();
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}