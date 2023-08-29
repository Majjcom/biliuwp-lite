using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiliLite.Api
{
    public class RegionAPI
    {
        public ApiModel Regions()
        {
            ApiModel api = new ApiModel()
            {
                method = RestSharp.Method.Get,
                baseUrl = $"https://app.bilibili.com/x/v2/region/index",
                parameter = ApiHelper.MustParameter(ApiHelper.AndroidKey, true)
            };
            api.parameter += ApiHelper.GetSign(api.parameter, ApiHelper.AndroidKey);
            return api;
        }

        public ApiModel RegionDynamic(int rid)
        {
            ApiModel api = new ApiModel()
            {
                method = RestSharp.Method.Get,
                baseUrl = $"https://app.bilibili.com/x/v2/region/dynamic",
                parameter = new ApiParameter
                {
                    { "rid", rid.ToString() }
                } + ApiHelper.MustParameter(ApiHelper.AndroidKey, false)
            };
            //ApiHelper.MustParameter(ApiHelper.AndroidKey, false) + $"&rid={rid}"
            api.parameter += ApiHelper.GetSign(api.parameter, ApiHelper.AndroidKey);
            return api;
        }
        public ApiModel RegionDynamic(int rid, string next_aid)
        {
            ApiModel api = new ApiModel()
            {
                method = RestSharp.Method.Get,
                baseUrl = $"https://app.biliapi.net/x/v2/region/dynamic/list",
                parameter = new ApiParameter
                {
                    { "rid", rid.ToString() },
                    { "ctime", next_aid },
                    { "pull", "false" }
                } + ApiHelper.MustParameter(ApiHelper.AndroidKey, false)
            };
            //ApiHelper.MustParameter(ApiHelper.AndroidKey, false) + $"&rid={rid}&ctime={next_aid}&pull=false"
            api.parameter += ApiHelper.GetSign(api.parameter, ApiHelper.AndroidKey);
            return api;
        }


        public ApiModel RegionChildDynamic(int rid, int tag_id = 0)
        {
            ApiModel api = new ApiModel()
            {
                method = RestSharp.Method.Get,
                baseUrl = $"https://app.biliapi.net/x/v2/region/dynamic/child",
                parameter = new ApiParameter
                {
                    { "rid", rid.ToString() },
                    { "tag_id", tag_id.ToString() },
                    { "pull", "true" }
                } + ApiHelper.MustParameter(ApiHelper.AndroidKey, false)
            };
            //ApiHelper.MustParameter(ApiHelper.AndroidKey, false) + $"&rid={rid}&tag_id={tag_id}&pull=true"
            api.parameter += ApiHelper.GetSign(api.parameter, ApiHelper.AndroidKey);
            return api;
        }

        public ApiModel RegionChildDynamic(int rid, string next, int tag_id = 0)
        {
            ApiModel api = new ApiModel()
            {
                method = RestSharp.Method.Get,
                baseUrl = $"https://app.bilibili.com/x/v2/region/dynamic/child/list",
                parameter = new ApiParameter
                {
                    { "rid", rid.ToString() },
                    { "tag_id", tag_id.ToString() },
                    { "pull", "false" },
                    { "ctime", next }
                } + ApiHelper.MustParameter(ApiHelper.AndroidKey, false)
            };
            //ApiHelper.MustParameter(ApiHelper.AndroidKey, false) + $"&rid={rid}&tag_id={tag_id}&pull=false&ctime={next}"
            api.parameter += ApiHelper.GetSign(api.parameter, ApiHelper.AndroidKey);
            return api;
        }
        public ApiModel RegionChildList(int rid, string order, int page, int tag_id = 0)
        {
            ApiModel api = new ApiModel()
            {
                method = RestSharp.Method.Get,
                baseUrl = $"https://app.biliapi.net/x/v2/region/show/child/list",
                parameter = new ApiParameter
                {
                    { "order", order },
                    { "pn", page.ToString() },
                    { "ps", "2" },
                    { "rid", rid.ToString() },
                    { "tag_id", tag_id.ToString() }
                } + ApiHelper.MustParameter(ApiHelper.AndroidKey, false)
            };
            //ApiHelper.MustParameter(ApiHelper.AndroidKey, false) + $"&order={order}&pn={page}&ps=20&rid={rid}&tag_id={tag_id}"
            api.parameter += ApiHelper.GetSign(api.parameter, ApiHelper.AndroidKey);
            return api;
        }

    }
}
