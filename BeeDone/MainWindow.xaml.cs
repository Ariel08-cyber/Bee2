using BeeDone.Models;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace BeeDone
{
    /// <summary>
    /// An empty window that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainWindow : Window
    {
        ObservableCollection<Tache> Taches  = new ObservableCollection<Tache>();

        public MainWindow()
        {
            InitializeComponent();

            Taches.Add(new Tache("Faire l'épicerie"));
            Taches.Add(new Tache("Réviser WinUI"));

            lvTaches.ItemsSource = Taches;
        }


        private async void btnAjouterTache_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(txtNouvelleTache.Text))
            {
                // Créer un objet Tâche à partir du nom de la tâche s'il n'est pas vide
                Tache nouvelleTache = new Tache(txtNouvelleTache.Text);

                // Ajouter à la liste des tâches
                Taches.Add(nouvelleTache);
                txtNouvelleTache.Text = string.Empty;

            } 
            else
            {
                // Afficher un message d'erreur dans dialogue
                ContentDialog dialogue = new ContentDialog()
                {
                    Title = "Erreur",
                    Content = "Veuillez entrer une tâche avant d'ajouter.",
                    CloseButtonText = "OK",
                    XamlRoot = this.Content.XamlRoot
                };

                await dialogue.ShowAsync();

            }

        }

        private async void btnSupprimerTache_Click(object sender, RoutedEventArgs e)
        {
            
            if (lvTaches.SelectedItem != null)
            {
                Tache tache = (Tache)lvTaches.SelectedItem ;
                Taches.Remove(tache);
            }
        }

        private void btnFermerDetails_Click(object sender, RoutedEventArgs e)
        {
            brdDetailsTache.Visibility = Visibility.Collapsed;

            // Optionnel : Si on veut redimentionner 
            Grid.SetColumnSpan(grdZoneAjout, 2);
            Grid.SetColumnSpan(brdListeTaches, 2);
        }
    }
}
