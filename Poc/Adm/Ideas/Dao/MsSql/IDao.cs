using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ideas.Dao.MsSql
{
    public interface IDao<T>
    {
        int Id { get; set; }
        int Incluir();
        int Alterar();
        int Excluir();
        T Obter(int id);
    }
}
