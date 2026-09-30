using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary1.Repositories
{
    public interface IGenericRepository<T> where T : class
    {
        void Agregar(T entidad);
        List<T> ObtenerTodos();
        T ObtenerPorId(int id);
        void Eliminar(object id);
        void Modificar(T entidad);
    }
}
