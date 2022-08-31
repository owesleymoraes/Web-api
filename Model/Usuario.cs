using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace webapi.Model
{
    public class Usuario
    {
        public int Id { get; set; }

        public string? Nome { get; set; }

        public DateTime DataDeNascimento { get; set; }

    }
}