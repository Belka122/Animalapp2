using System;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;
using AnimalApp.Models;

namespace AnimalApp.Views
{
    public partial class AddEditDialog : Window
    {
        public Animal? Result { get; private set; }

        public AddEditDialog(Animal? existing = null)
        {
            InitializeComponent();
            if (existing != null)
            {
                Title = "Edit Animal";
                NameBox.Text = existing.Name;
                SpeciesBox.SelectedIndex = (int)existing.Species;
                AgeBox.Text = existing.Age.ToString(CultureInfo.InvariantCulture);
                NotesBox.Text = existing.Notes;
                Result = existing;
            }
            else
            {
                Title = "Add Animal";
                SpeciesBox.SelectedIndex = 0;
            }
        }

        private void Ok_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(NameBox.Text))
            {
                MessageBox.Show("Name is required", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                NameBox.Focus();
                return;
            }
            if (!int.TryParse(AgeBox.Text, NumberStyles.Integer, CultureInfo.InvariantCulture, out var age) || age < 0 || age > 50)
            {
                MessageBox.Show("Age must be 0..50", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                AgeBox.Focus();
                return;
            }

            var speciesText = ((ComboBoxItem)SpeciesBox.SelectedItem!).Content!.ToString()!;
            var species = Enum.Parse<Species>(speciesText);

            Result ??= new Animal();
            Result.Name = NameBox.Text.Trim();
            Result.Species = species;
            Result.Age = age;
            Result.Notes = string.IsNullOrWhiteSpace(NotesBox.Text) ? null : NotesBox.Text.Trim();

            DialogResult = true;
            Close();
        }
    }
}
