using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using DAEA_LAB05_JE.LAB07.ViewModel;
using Business;
using Entity;

namespace DAEA_LAB05_JE.LAB07.View
{
    /// <summary>
    /// Lógica de interacción para ListaCategoria.xaml
    /// </summary>
    public partial class ListaCategoria : Window
    {
        ListaCategoriaViewModel viewModel;
        public ListaCategoria()
        {
            InitializeComponent();
            viewModel = new ListaCategoriaViewModel();
            this.DataContext = viewModel;
        }


        private void BtnConsultar_Click(object sender, RoutedEventArgs e)
        {
            Cargar();
        }

        private void BtnNuevo_Click(object sender, RoutedEventArgs e)
        {
            ManCategoria nuevaCategoria = new ManCategoria(0);
            _ = nuevaCategoria.ShowDialog();
            Cargar();
        }

        private void DgvCategoria_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int idCategoria;
            var item = (Categoria)dgvCategoria.SelectedItem;
            if (null == item)
            {
                return;
            }

            idCategoria = Convert.ToInt32(item.IdCategoria);
            ManCategoria nuevaCategoria = new ManCategoria(idCategoria);
            _ = nuevaCategoria.ShowDialog();
            Cargar();
        }

        private void Cargar()
        {
            BCategoria bCategoria;
            try
            {
                bCategoria = new BCategoria();
                dgvCategoria.ItemsSource = bCategoria.Listar(0);
            }
            catch (Exception ex)
            {
                _ = MessageBox.Show("Comunicarse con el admin");
                throw ex;
            }
        }
    }
}
