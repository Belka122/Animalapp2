using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Data;
using AnimalApp.Models;

namespace AnimalApp.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<Animal> Items { get; } = new();
        public ICollectionView View { get; }
        private string _filter = string.Empty;
        public string Filter { get => _filter; set { _filter = value; View.Refresh(); OnPropertyChanged(nameof(Filter)); } }

        public MainViewModel()
        {
            Items.Add(new Animal { Name = "Rex", Species = Species.Dog, Age = 4, Notes = "Sõbralik" });
            Items.Add(new Animal { Name = "Mimi", Species = Species.Cat, Age = 2, Notes = "Väike" });
            View = CollectionViewSource.GetDefaultView(Items);
            View.Filter = o =>
            {
                if (string.IsNullOrWhiteSpace(Filter)) return true;
                var a = (Animal)o;
                return a.Name.Contains(Filter, StringComparison.InvariantCultureIgnoreCase) ||
                       a.Species.ToString().Contains(Filter, StringComparison.InvariantCultureIgnoreCase) ||
                       a.Age.ToString().Contains(Filter);
            };
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        private void OnPropertyChanged(string name) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
