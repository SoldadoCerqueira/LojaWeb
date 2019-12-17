using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Loja2019.Models
{
    public class Confeccao
    {
        public Confeccao()
        {

        }
        public Confeccao(Roupa roupa)
        {
            this.Roupa = roupa;
            this.Data = DateTime.Now;
        }
        public int ConfeccaoId { get; set; }

        public Roupa Roupa { get; set; }

        public int RoupaId { get; set; }

        public DateTime Data { get; set; }
    }
}
