# AnimalApp — WPF (täielik projekt)

**Parandab vead, mille eest said märkuse:**
- `.sln` ja `.csproj` kaasas → saab avada ja **käivitada** Visual Studios.
- Klassid **eraldi** failides ja kaustades.
- Puhas struktuur + README.

## Käivitamine
1. Ava `AnimalApp.sln` Visual Studios (2022+), .NET 6 SDK.
2. Build → Start (F5).

## Funktsionaalsus
- Kollektsioon `Animal` (Name, Species, Age, Notes).
- Lisa / Muuda / Kustuta dialoogidega.
- Sorteerimine DataGridi päisest, Otsing.

## Struktuur
- `Models/Animal.cs`
- `ViewModels/MainViewModel.cs`
- `Views/AddEditDialog.xaml` (+ .cs)
- `MainWindow.xaml` (+ .cs)
- `Resources/Strings.xaml`
- `.gitignore`

