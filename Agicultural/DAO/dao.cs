using Agicultural.Context;
using Agicultural.Models;

namespace Agicultural.DAO
{
    public class dao
    {
        private readonly Cont cont;
        public dao(Cont con) { cont = con; }

        public string login(LoginModel login) {
            return "";
        }
    }
}
