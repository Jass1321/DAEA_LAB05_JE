using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Entity;
using Data;

namespace Business
{
    public class BCategoria
    {
        private DCategoria dCategoria = null;

        public List<Categoria> Listar(int IdCategoria)
        {
            List<Categoria> categorias = null;
            try
            {
                dCategoria = new DCategoria();
                //PROBLEMA
                categorias = dCategoria.Listar(new Categoria { IdCategoria = IdCategoria });
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return categorias;
        }

        public bool Insertar(Categoria categoria)
        {
            bool result = true;

            try
            {
                dCategoria = new DCategoria();
                dCategoria.Insertar(categoria);
            }
            catch (Exception ex)
            {
                result = false;
            }

            return result;
        }

        public bool Actualizar(Categoria categoria)
        {
            bool result = true;

            try
            {
                dCategoria = new DCategoria();
                dCategoria.Actualizar(categoria);
            }
            catch (Exception)
            {
                result = false;
            }

            return result;
        }

        public bool Eliminar(int IdCategoria)
        {
            bool result = true;

            try
            {
                dCategoria = new DCategoria();
                dCategoria.Eliminar(IdCategoria);
            }
            catch (Exception)
            {
                result = false;
            }

            return result;
        }
    }
}
