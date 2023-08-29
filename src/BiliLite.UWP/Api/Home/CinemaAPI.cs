using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiliLite.Api.Home
{
   public class CinemaAPI
    {
        public ApiModel CinemaHome()
        {
            ApiModel api = new ApiModel()
            {
                method = RestSharp.Method.Get,
                baseUrl = $"{ApiHelper.IL_BASE_URL}/api/cinema/home"
            };
            return api;
        }
        public ApiModel CinemaFallMore(int wid, long cursor = 0)
        {
            //$"wid={wid}&cursor={cursor}"
            ApiModel api = new ApiModel()
            {
                method = RestSharp.Method.Get,
                baseUrl = $"{ApiHelper.IL_BASE_URL}/api/cinema/falls",
                parameter = new ApiParameter
                {
                    { "wid", wid.ToString() },
                    { "cursor", cursor.ToString() }
                }
            };
            return api;
        }
     
    }
}
