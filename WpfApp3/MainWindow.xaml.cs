using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfApp3.Annotations;
using WPFLocalizeExtension.Engine;

namespace WpfApp3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        private ObservableCollection<string> _list = new ObservableCollection<string>()
        {
            "test"
        };

        public MainWindow()
        {
            InitializeComponent();

            LocalizeDictionary.Instance.SetCurrentThreadCulture = true;
            
        }

        public ObservableCollection<string> List
        {
            get => _list;
            set
            {
                if (Equals(value, _list)) return;
                _list = value;
                OnPropertyChanged();
            }
        }

        private void Add_OnClick(object sender, RoutedEventArgs e)
        {
             List.Add("test");
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void Remove_OnClick(object sender, RoutedEventArgs e)
        {
            if (List.Any())
                List.Remove(List.Last());
        }

        private void Chance_OnClick(object sender, RoutedEventArgs e)
        {
            if (LocalizeDictionary.Instance.Culture.TwoLetterISOLanguageName == "en")
                LocalizeDictionary.Instance.Culture = new CultureInfo("fr-FR");
            else
            {
                LocalizeDictionary.Instance.Culture = new CultureInfo("en-US");
            }
        }
    }
}
