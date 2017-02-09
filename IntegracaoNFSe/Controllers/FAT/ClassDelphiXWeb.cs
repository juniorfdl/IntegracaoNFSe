using Models.FAT;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Web;

namespace Controllers.FAT
{
    public class ClassDelphiXWeb
    {

        [DllImport(@"Fat_Nfs_Eletronica.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        //[return: MarshalAs(UnmanagedType.LPStr)]
        private static extern int emitirWeb(int id,
            [MarshalAs(UnmanagedType.LPStr)] string CEMP,
            [MarshalAs(UnmanagedType.LPStr)] string Usuario,
            [MarshalAs(UnmanagedType.LPStr)] string CodigoUsuario,
            [MarshalAs(UnmanagedType.LPStr)] string Operacao);

        public FAT_NF_SERVICO EmitirNFSe(int id, string CEMP, string Usuario, string CodigoUsuario, string Operacao)
        {
            FAT_NF_SERVICO item = new FAT_NF_SERVICO();

            var ret = emitirWeb(id, CEMP, Usuario, CodigoUsuario, Operacao);

            item.Retorno = ret.ToString();

            if (ret > 0)
            {
                string arquivoerro = "erronfse" + id.ToString() + ".txt";
                if (File.Exists(arquivoerro))
                {
                    item.Retorno = File.ReadAllText(arquivoerro);
                    return item;
                }
            }
            else
            {
                string arquivolog = "nfseok" + id.ToString() + ".txt";
                if (File.Exists(arquivolog))
                {
                    int cont = 1;
                    string[] lines = System.IO.File.ReadAllLines(arquivolog);
                    foreach (string line in lines)
                    {
                        switch (cont)
                        {
                            case 1:
                                item.Tipo = line;
                                break;
                            case 2:
                                item.Protocolo = line;
                                break;
                            case 3:
                                item.CODIGOVERIFICACAO = line;
                                break;
                            case 4:
                                item.NFSE_NUMERO = line;
                                break;
                        }

                        cont++;
                    }

                    return item;
                }

            }


            return item;
        }

    }
}