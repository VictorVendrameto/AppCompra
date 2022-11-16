using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using SQLite; 

namespace AppCompras.Model
{
    public class Produto
    {
        [PrimaryKey, AutoIncrement]
        public int id { get; set; }

        public string desc { get; set; }
        public double preco { get; set; }
        public double quant { get; set; }
    }
}
