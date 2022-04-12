using N1B2_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace N1B2_API.Controllers
{
    [Route("api/arte")]
    public class ArteController : Controller
    {
        [AcceptVerbs("POST")]
        [Route("CadastrarArte")]
        public string CadastrarArte(ArteModel arte)
        {
             
        }

        private string ValidaDado(ArteModel arte)
        {

        }

        private bool ValidaLink(string link)
        {
            if (string.IsNullOrEmpty(link))
                return false;
            return true;
        }


    }
}