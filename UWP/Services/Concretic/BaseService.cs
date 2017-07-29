using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Web.Http;

namespace UWP.Services.Concretic
{
    public abstract class BaseService
    {
        protected HttpClient _httpClient = new HttpClient();
        protected const string _APIURL = "http://localhost:53090/api/";
        protected const string _APPID = "D22392E9-EAEB-47A4-A1A5-7A149E373C09";


    }
}
