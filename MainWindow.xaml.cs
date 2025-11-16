using System.Collections.ObjectModel;
using System.Windows;
using AnimalApp.Models;
using AnimalApp.Services;

namespace AnimalApp
{
    public partial class MainWindow : Window
    {
        private readonly ObservableCollection<Animal> _animals = new ObservableCollection<Animal>();
        private readonly LogService _logService = new LogService();

        private Animal _selectedAnimal;

        public MainWindow()
        {
            InitializeComponent();

            // Привязываем список животных к ListBox
            AnimalsListBox.ItemsSource = _animals;

            // Привязываем лог к ListBox
            LogListBox.ItemsSource = _logService.Entries;

            SeedAnimals();
        }

        private void SeedAnimals()
        {
            _animals.Add(new Dog("Rex", 3));
            _animals.Add(new Cat("Muri", 2));
        }

        private void AnimalsListBox_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            _selectedAnimal = AnimalsListBox.SelectedItem as Animal;
            UpdateDetails();
        }

        private void UpdateDetails()
        {
            if (_selectedAnimal == null)
            {
                NameTextBlock.Text = string.Empty;
                AgeTextBlock.Text = string.Empty;
                SpeciesTextBlock.Text = string.Empty;
                return;
            }

            NameTextBlock.Text = _selectedAnimal.Name;
            AgeTextBlock.Text = _selectedAnimal.Age.ToString();
            SpeciesTextBlock.Text = _selectedAnimal.Species;
        }

        private void FeedButton_Click(object sender, RoutedEventArgs e)
        {
            if (_selectedAnimal == null) return;

            var message = _selectedAnimal.Feed();
            _logService.Log(message);
        }

        private void SoundButton_Click(object sender, RoutedEventArgs e)
        {
            if (_selectedAnimal == null) return;

            var sound = _selectedAnimal.MakeSound();
            _logService.Log($"{_selectedAnimal.Species} {_selectedAnimal.Name} teeb häält: {sound}");
        }
    }
}