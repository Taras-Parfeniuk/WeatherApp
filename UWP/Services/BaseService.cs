using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Web.Http;

namespace Uwp.Services
{
    public abstract class BaseService
    {
        protected HttpClient _httpClient = new HttpClient();
        protected const string _APIURL = "http://localhost:53090/api/";
    }
}
