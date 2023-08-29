using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BiliLite.Api;

namespace BiliLite.Api.Home
{
   
    public class AnimeAPI
    {

        public ApiModel BangumiHome()
        {
            ApiModel api = new ApiModel()
            {
                method = RestSharp.Method.Get,
                baseUrl = $"{ApiHelper.IL_BASE_URL}/api/anime/bangumi"
            };
            return api;
        }
        public ApiModel GuochuangHome()
        {
            ApiModel api = new ApiModel()
            {
                method = RestSharp.Method.Get,
                baseUrl = $"{ApiHelper.IL_BASE_URL}/api/anime/guochuang"
            };
            return api;
        }
        public ApiModel Timeline(int type)
        {
            //"type="+ type
            ApiModel api = new ApiModel()
            {
                method = RestSharp.Method.Get,
                baseUrl = $"{ApiHelper.IL_BASE_URL}/api/anime/timeline",
                parameter = new ApiParameter
                {
                    { "type", type.ToString() }
                }
            };
            return api;
        }
        public ApiModel AnimeFallMore(int wid, long cursor = 0)
        {
            //$"wid={wid}&cursor={cursor}"
            ApiModel api = new ApiModel()
            {
                method = RestSharp.Method.Get,
                baseUrl = $"{ApiHelper.IL_BASE_URL}/api/anime/bangumiFalls",
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
