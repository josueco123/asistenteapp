using AsistenteJudicialApp.Managers;
using AsistenteJudicialApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AsistenteJudicialApp.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ProcesoPage : ContentPage
	{
        ProcesoManager manager;
        Proceso proceso;
		public ProcesoPage (int id)
		{
			InitializeComponent ();
            manager = new ProcesoManager();
            obtenerProceso(id);           
            //obtenerEstados();

        }

        public async void obtenerProceso(int id)
        {
            try
            {
                proceso = await manager.getProceso(id);
                radicacion.Text = proceso.radicacion;
                juzgado.Text = proceso.juzgado;
                demandado.Text = proceso.demandado;
                demandante.Text = proceso.demandante;

                var response = await manager.getEstados(proceso.id.ToString());

                if (response != null)
                {
                    lstEstado.ItemsSource = response;
                }
            }
            catch(Exception ex) { }
        }              
        
	}
}