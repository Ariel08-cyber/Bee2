using BeeDone.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeeDone.ViewModel
{
    public class MainViewModel
    {
        private readonly ITacheDataProvider _tacheDataProvider;

        public MainViewModel(ITacheDataProvider tacheDataProvider)
        {

        }

        public bool AjouterTache()
        {
            string titreTache = NouvelleTache.Trim();

            if (string.IsNullOrEmpty(titreTache)) {
                return false;

            Tache nouvelleTache = new Tache(titreTache);
            Taches.Add(nouvelleTache);
            nouvelleTache = string.Empty;
            return true;
        }

        public void ChargerTaches() { 
        }
    }
}
