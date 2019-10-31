using System;
using System.Collections.Generic;
using System.Text;

namespace Repository
{
    //T é um objeto genérico
    interface IRepository<T>
    {
        bool Cadastrar(T objeto);
        List<T> ListarTodos();
        T BuscarPorId(int? id);
    }
}
