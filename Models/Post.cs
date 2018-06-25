using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspnetCore_EFCoreInMemory.Models
{
    public class Post
    {
        public string Id { get; set; }
        public string UsuarioId { get; set; }
        public string Conteudo { get; set; }
        public Usuario Usuario { get; set; }
    }
}
