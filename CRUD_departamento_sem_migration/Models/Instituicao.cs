using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRUD_departamento_sem_migration.Models
{
    public class Instituicao
    {
        public long? Id { get; set; }
        public string Nome { get; set; }
        public string Endereco { get; set; } 
    }
}