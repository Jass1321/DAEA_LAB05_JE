using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Business;
using DAEA_LAB05_JE.LAB07.Model;

namespace DAEA_LAB05_JE.LAB07.ViewModel
{
    public class ManCategoriaViewModel : ViewModelBase
    {
        #region Properties
        int _ID;

        public int ID
        {
            get { return _ID; }
            set
            {
                if (_ID != value)
                {
                    _ID = value;
                    OnPropertyChanged();
                }
            }
        }

        string _Nombre;
        public string Nombre
        {
            get { return _Nombre; }
            set
            {
                if (_Nombre != value)
                {
                    _Nombre = value;
                    OnPropertyChanged();
                }
            }
        }

        string _Descripcion;
        public string Descripcion
        {
            get { return _Descripcion; }
            set
            {
                if (_Descripcion != value)
                {
                    _Descripcion = value;
                    OnPropertyChanged();
                }
            }
        }
        #endregion Properties

        public ICommand GrabarCommand { set; get; }
        public ICommand CerrarCommand { set; get; }

        public ICommand EliminarCommand { set; get; }

        public ManCategoriaViewModel()
        {
            EliminarCommand = new RelayCommand<object>(
                o =>
                {
                    BCategoria bCategoria = null;
                    bool result = true;
                        //1° se lista todas las categorias
                        bCategoria = new BCategoria();

                        //2° eliminar el registro
                        result = new CategoriaModel().Eliminar(ID);
                        MessageBox.Show("Eliminado correctamente");
                        if (!result)
                        {
                            MessageBox.Show("Comunicarse con el Administrador");
                        }
                   
                });

            GrabarCommand = new RelayCommand<object>(
                o =>
                {
                    BCategoria bCategoria = null;
                    bool result = true;

                    if (ID > 0)
                    {
                        result = new CategoriaModel().Actualizar(new Entity.Categoria
                        {
                            IdCategoria = ID,
                            NombreCategoria = Nombre,
                            Descripcion = Descripcion
                        });
                        MessageBox.Show("Actualizado correctamente");
                    }
                    else
                    {
                        result= new CategoriaModel().Insertar(new Entity.Categoria
                        {
                            NombreCategoria = Nombre,
                            Descripcion = Descripcion
                        });
                        MessageBox.Show("Insertado correctamente");
                    }
                    if (!result)
                    {
                        MessageBox.Show("Comunicarse con el Administrador");
                    }
                });

            CerrarCommand = new RelayCommand<Window>(
                param => Cerrar(param)
                );
           
        }

            void Cerrar(Window window)
        {
            window.Close();
        }
    }
}
