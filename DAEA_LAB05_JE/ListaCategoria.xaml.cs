using System;
using System.Windows;
using System.Windows.Controls;
using System.Collections.Generic;
using Business;
using Entity;

namespace S5_WPF
{
    /// <summary>
    /// Lógica de interacción para ListaCategoria.xaml
    /// </summary>
    public partial class ListaCategoria : Window
    {
        public ListaCategoria()
        {
            InitializeComponent();
        }

        private void btnConsultar_Click(object sender, RoutedEventArgs e)
        {
            Cargar();
        }

        private void Cargar()
        {
            BCategoria bCategoria = null;
            try
            {
                //0:Listar todas las categorias
                bCategoria = new BCategoria();
                dgvCategoria.ItemsSource = bCategoria.Listar(0);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Comunicarse con el admin -> {ex}");
            }
            finally
            {
                bCategoria = null;
            }
        }

        private void btnNuevo_Click(object sender, RoutedEventArgs e)
        {
            //se coloca 0 pq es nuevo
            ManCategoria manCategoria = new ManCategoria(0);
            manCategoria.ShowDialog();
            Cargar();
        }

        private void btnEliminar_Click(object sender, RoutedEventArgs e)
        {
            
        }
      
        private void dgvCategoria_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int idCategoria = 0;
            var item = (Categoria)dgvCategoria.SelectedItem;
            if (null == item) return;
            idCategoria = Convert.ToInt32(item.IdCategoria);

            ManCategoria manCategoria = new ManCategoria(idCategoria);
            manCategoria.ShowDialog();
            Cargar();

        }

    }
}
