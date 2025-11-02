using System.Windows;
using AnimalApp.Models;
using AnimalApp.ViewModels;
using AnimalApp.Views;

namespace AnimalApp
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private MainViewModel VM => (MainViewModel)DataContext;

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            var dlg = new AddEditDialog { Owner = this };
            if (dlg.ShowDialog() == true && dlg.Result != null)
                VM.Items.Add(dlg.Result);
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            if (Grid.SelectedItem is not Animal selected)
            {
                MessageBox.Show("Vali rida, mida muuta.", "Info");
                return;
            }
            var copy = new Animal { Name = selected.Name, Species = selected.Species, Age = selected.Age, Notes = selected.Notes };
            var dlg = new AddEditDialog(copy) { Owner = this };
            if (dlg.ShowDialog() == true && dlg.Result != null)
            {
                var idx = VM.Items.IndexOf(selected);
                if (idx >= 0) VM.Items[idx] = dlg.Result;
            }
        }

        private void Remove_Click(object sender, RoutedEventArgs e)
        {
            if (Grid.SelectedItem is not Animal selected)
            {
                MessageBox.Show("Vali rida, mida kustutada.", "Info");
                return;
            }
            if (MessageBox.Show("Kas oled kindel?", "Kinnitus", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                VM.Items.Remove(selected);
        }
    }
}
