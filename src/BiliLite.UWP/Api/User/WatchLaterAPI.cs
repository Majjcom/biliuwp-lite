using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiliLite.Api.User
{
    public class WatchLaterAPI
    {
        public ApiModel Add(string aid)
        {
            //ApiHelper.MustParameter(ApiHelper.AndroidKey, true) + $"&aid={aid}"
            ApiParameter body = new ApiParameter
            {
                { "aid", aid }
            } + ApiHelper.MustParameter(ApiHelper.AndroidKey, true);

            ApiModel api = new ApiModel()
            {
                method = RestSharp.Method.Post,
                baseUrl = $"{ApiHelper.API_BASE_URL}/x/v2/history/toview/add",
                body = body.ToString()
            };
            api.body += '&' + ApiHelper.GetSign(api.body, ApiHelper.AndroidKey).ToString();
            return api;
        }
        public ApiModel Watchlater()
        {
            //ApiHelper.MustParameter(ApiHelper.AndroidKey, true) + $"&ps=100"
            ApiModel api = new ApiModel()
            {
                method = RestSharp.Method.Get,
                baseUrl = $"{ApiHelper.API_BASE_URL}/x/v2/history/toview",
                parameter = new ApiParameter
                {
                    { "ps", "100" }
                } + ApiHelper.MustParameter(ApiHelper.AndroidKey, true)
            };
            api.parameter += ApiHelper.GetSign(api.parameter, ApiHelper.AndroidKey);
            return api;
        }
        public ApiModel Clear()
        {
            ApiModel api = new ApiModel()
            {
                method = RestSharp.Method.Post,
                baseUrl = $"{ApiHelper.API_BASE_URL}/x/v2/history/toview/clear",
                body = ApiHelper.MustParameter(ApiHelper.AndroidKey, true).ToString()
            };
            api.parameter += ApiHelper.GetSign(api.body, ApiHelper.AndroidKey);
            return api;
        }
        public ApiModel Del()
        {
            //ApiHelper.MustParameter(ApiHelper.AndroidKey, true) + "&viewed=true"
            ApiParameter body = new ApiParameter
            {
                { "viewed", "true" }
            } + ApiHelper.MustParameter(ApiHelper.AndroidKey, true);

            ApiModel api = new ApiModel()
            {
                method = RestSharp.Method.Post,
                baseUrl = $"{ApiHelper.API_BASE_URL}/x/v2/history/toview/del",
                body = body.ToString()
            };
            api.parameter += ApiHelper.GetSign(api.body, ApiHelper.AndroidKey);
            return api;
        }
        public ApiModel Del(string id)
        {
            //ApiHelper.MustParameter(ApiHelper.AndroidKey, true) + "&aid="+id
            ApiParameter body = new ApiParameter
            {
                { "aid", id }
            } + ApiHelper.MustParameter(ApiHelper.AndroidKey, true);

            ApiModel api = new ApiModel()
            {
                method = RestSharp.Method.Post,
                baseUrl = $"{ApiHelper.API_BASE_URL}/x/v2/history/toview/del",
                body = body.ToString()
            };
            api.parameter += ApiHelper.GetSign(api.body, ApiHelper.AndroidKey);
            return api;
        }
    }
}
