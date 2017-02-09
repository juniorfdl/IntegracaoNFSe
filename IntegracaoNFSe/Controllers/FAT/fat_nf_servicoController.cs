namespace Controllers.FAT
{
    using System;
    //using System.Collections.Generic;
   // using System.Data;
    //using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Web.Http;
    //using Newtonsoft.Json;
    using Models.FAT;

    public class fat_nf_servicoController : ApiController
    {
        [Route("api/fat_nf_servico/EmitirNFSe")]
        [HttpGet]
        public dynamic EmitirNFSe([FromUri]FAT_NF_SERVICO filtros)
        {            
            ClassDelphiXWeb d = new ClassDelphiXWeb();            
            return Ok(d.EmitirNFSe(filtros.id, filtros.CEMP, filtros.Usuario, filtros.CodigoUsuario, filtros.Operacao));
        }

    }
}
