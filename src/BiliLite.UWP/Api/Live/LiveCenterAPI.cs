using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiliLite.Api.Live
{
    public class LiveCenterAPI
    {
        public ApiModel FollowLive()
        {
            //ApiHelper.MustParameter(ApiHelper.AndroidKey, true) + "&qn=0&sortRule=0&filterRule=0",
            ApiModel api = new ApiModel()
            {
                method = RestSharp.Method.Get,
                baseUrl = "https://api.live.bilibili.com/xlive/app-interface/v1/relation/liveAnchor",
                parameter = new ApiParameter
                {
                    { "qn", "0" },
                    { "sortRule", "0" },
                    { "filterRule", "0" }
                } + ApiHelper.MustParameter(ApiHelper.AndroidKey, true)
            };
            api.parameter += ApiHelper.GetSign(api.parameter, ApiHelper.AndroidKey);
            return api;
        }
        public ApiModel FollowUnLive(int page)
        {
            //ApiHelper.MustParameter(ApiHelper.AndroidKey, true) + $"&page={page}&pagesize=30",
            ApiModel api = new ApiModel()
            {
                method = RestSharp.Method.Get,
                baseUrl = "https://api.live.bilibili.com/xlive/app-interface/v1/relation/unliveAnchor",
                parameter = new ApiParameter
                {
                    { "page", page.ToString() },
                    { "pagesize", "30" }
                } + ApiHelper.MustParameter(ApiHelper.AndroidKey, true)
            };
            api.parameter += ApiHelper.GetSign(api.parameter, ApiHelper.AndroidKey);
            return api;
        }
        public ApiModel History(int page)
        {
            //ApiHelper.MustParameter(ApiHelper.AndroidKey, true) + $"&pn={page}&ps=20",
            ApiModel api = new ApiModel()
            {
                method = RestSharp.Method.Get,
                baseUrl = "https://app.bilibili.com/x/v2/history/liveList",
                parameter = new ApiParameter
                {
                    { "pn", page.ToString() },
                    { "ps", "20" }
                } + ApiHelper.MustParameter(ApiHelper.AndroidKey, true)
            };
            api.parameter += ApiHelper.GetSign(api.parameter, ApiHelper.AndroidKey);
            return api;
        }
        public ApiModel SignInfo()
        {
            //ApiHelper.MustParameter(ApiHelper.AndroidKey, true) + "&actionKey=appkey",
            ApiModel api = new ApiModel()
            {
                method = RestSharp.Method.Get,
                baseUrl = "https://api.live.bilibili.com/rc/v2/Sign/getSignInfo",
                parameter = new ApiParameter
                {
                    { "actionKey", "appkey" }
                } + ApiHelper.MustParameter(ApiHelper.AndroidKey, true)
            };
            api.parameter += ApiHelper.GetSign(api.parameter, ApiHelper.AndroidKey);
            return api;
        }
        public ApiModel DoSign()
        {
            //ApiHelper.MustParameter(ApiHelper.AndroidKey, true) + "&actionKey=appkey"
            ApiModel api = new ApiModel()
            {
                method = RestSharp.Method.Get,
                baseUrl = $"https://api.live.bilibili.com/rc/v1/Sign/doSign",
                parameter = new ApiParameter
                {
                    { "actionKey", "appkey" }
                } + ApiHelper.MustParameter(ApiHelper.AndroidKey, true)
            };
            api.parameter += ApiHelper.GetSign(api.parameter, ApiHelper.AndroidKey);
            return api;
        }

    }

}
