using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.FAT
{
    public class FAT_NF_SERVICO
    {
        public int id { get; set; }
        public string nome { get; set; }
        public string CEMP { get; set; }
        public string Usuario { get; set; }
        public string CodigoUsuario { get; set; }
        public string Operacao { get; set; }
        public string Retorno { get; set; }
        public string Tipo { get; set; }
        public string Protocolo { get; set; }
        public string CODIGOVERIFICACAO { get; set; }
        public string NFSE_NUMERO { get; set; }        
    }
}
