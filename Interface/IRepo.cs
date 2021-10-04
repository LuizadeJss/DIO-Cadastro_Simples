using System.Collections.Generic;

namespace Cadastro.Interface
{
    public interface IRepo<T>
    {
         List<T> Lista();
         T ReId(int id);
         void Insere(T entidade);
         void Exclui(int id);
         void Atualiza(int id, T entidade);
         int ProId();

    }
}