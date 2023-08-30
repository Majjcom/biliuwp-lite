using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiliLite.Api
{
    public class VideoAPI
    {
        public ApiModel Detail(string id,bool isbvid)
        {
            //ApiHelper.MustParameter(ApiHelper.AndroidKey, true) + $"&{(isbvid?"bvid=":"aid=")}{id}&plat=0"
            ApiModel api = new ApiModel()
            {
                method = RestSharp.Method.Get,
                //baseUrl = $"https://app.bilibili.com/x/v2/view",
                baseUrl = $"https://api.bilibili.com/x/web-interface/view",
                parameter = new ApiParameter
                {
                    { isbvid ? "bvid" : "aid", id },
                    { "plat", "0" }
                },// + ApiHelper.MustParameter(ApiHelper.AndroidKey, true),
                need_cookie = true
            };
            //api.parameter += ApiHelper.GetSign(api.parameter, ApiHelper.AndroidKey);
            return api;
        }

        public ApiModel DetailProxy(string id, bool isbvid)
        {
            //ApiHelper.MustParameter(ApiHelper.AndroidKey, true) + $"&{(isbvid ? "bvid=" : "aid=")}{id}&plat=0"
            ApiModel api = new ApiModel()
            {
                method = RestSharp.Method.Get,
                baseUrl = $"https://app.bilibili.com/x/v2/view",
                parameter = new ApiParameter
                {
                    { isbvid ? "bvid" : "aid", id },
                    { "plat", "0" }
                } + ApiHelper.MustParameter(ApiHelper.AndroidKey, true)
            };
            api.parameter += ApiHelper.GetSign(api.parameter, ApiHelper.AndroidKey);
            var apiUrl = Uri.EscapeDataString(api.url);
            api.baseUrl = "https://biliproxy.iill.moe/app.php";
            //"url=" + apiUrl;
            api.parameter = new ApiParameter
            {
                { "url", apiUrl }
            };
            return api;
        }
        /// <summary>
        ///点赞
        /// </summary>
        /// <param name="dislike"> 当前dislike状态</param>
        /// <param name="like">当前like状态</param>
        /// <returns></returns>
        public ApiModel Like(string aid, int dislike,int like)
        {
            //ApiHelper.MustParameter(ApiHelper.AndroidKey, true) + $"&aid={aid}&dislike={dislike}&from=7&like={like}"
            ApiParameter body = new ApiParameter
            {
                { "aid", aid },
                { "dislike", dislike.ToString() },
                { "from", "7" },
                { "like", like.ToString() }
            } + ApiHelper.MustParameter(ApiHelper.AndroidKey, true);

            ApiModel api = new ApiModel()
            {
                method = RestSharp.Method.Post,
                baseUrl = $"https://app.bilibili.com/x/v2/view/like",
                body = body.ToString()
            };
            api.body += '&' + ApiHelper.GetSign(api.body, ApiHelper.AndroidKey).ToString();
            return api;
        }
        /// <summary>
        ///点赞
        /// </summary>
        /// <param name="dislike"> 当前dislike状态</param>
        /// <param name="like">当前like状态</param>
        /// <returns></returns>
        public ApiModel Dislike(string aid, int dislike, int like)
        {
            //ApiHelper.MustParameter(ApiHelper.AndroidKey, true) + $"&aid={aid}&dislike={dislike}&from=7&like={like}"
            ApiParameter body = new ApiParameter
            {
                { "aid", aid },
                { "dislike", dislike.ToString() },
                { "from", "7" },
                { "like", like.ToString() }
            } + ApiHelper.MustParameter(ApiHelper.AndroidKey, true);

            ApiModel api = new ApiModel()
            {
                method = RestSharp.Method.Post,
                baseUrl = $"https://app.biliapi.net/x/v2/view/dislike",
                body = body.ToString()
            };
            api.body += '&' + ApiHelper.GetSign(api.body, ApiHelper.AndroidKey).ToString();
            return api;
        }

        /// <summary>
        /// 一键三连
        /// </summary>
        /// <returns></returns>
        public ApiModel Triple(string aid)
        {
            //ApiHelper.MustParameter(ApiHelper.AndroidKey, true) + $"&aid={aid}"
            ApiParameter body = new ApiParameter
            {
                { "aid", aid }
            } + ApiHelper.MustParameter(ApiHelper.AndroidKey, true);

            ApiModel api = new ApiModel()
            {
                method = RestSharp.Method.Post,
                baseUrl = $"https://app.bilibili.com/x/v2/view/like/triple",
                body = body.ToString()
            };
            api.body += '&' + ApiHelper.GetSign(api.body, ApiHelper.AndroidKey).ToString();
            return api;
        }

        public ApiModel Coin(string aid, int num)
        {
            //ApiHelper.MustParameter(ApiHelper.AndroidKey, true) + $"&aid={aid}&multiply={num}&platform=android&select_like=0"
            ApiParameter body = new ApiParameter
            {
                { "aid", aid },
                { "multiply", num.ToString() },
                { "select_like", "0" }
            } + ApiHelper.MustParameter(ApiHelper.AndroidKey, true);

            ApiModel api = new ApiModel()
            {
                method = RestSharp.Method.Post,
                baseUrl = $"https://app.biliapi.net/x/v2/view/coin/add",
                body = body.ToString()
            };
            api.body += '&' + ApiHelper.GetSign(api.body, ApiHelper.AndroidKey).ToString();
            return api;
        }
        /// <summary>
        /// 关注
        /// </summary>
        /// <param name="mid">用户ID</param>
        /// <param name="mode">1为关注，2为取消关注</param>
        /// <returns></returns>
        public ApiModel Attention(string mid, string mode)
        {
            //ApiHelper.MustParameter(ApiHelper.AndroidKey, true) + $"&act={mode}&fid={mid}&re_src=32"
            ApiParameter body = new ApiParameter
            {
                { "act", mode },
                { "fid", mid },
                { "re_src", "32" }
            } + ApiHelper.MustParameter(ApiHelper.AndroidKey, true);

            ApiModel api = new ApiModel()
            {
                method = RestSharp.Method.Post,
                baseUrl = $"{ApiHelper.API_BASE_URL}/x/relation/modify",
                body = body.ToString()
            };
            api.body += '&' + ApiHelper.GetSign(api.body, ApiHelper.AndroidKey).ToString();
            return api;
        }

        public ApiModel Recommend(string id, bool isbvid)
        {
            ApiModel api = new ApiModel
            {
                method = RestSharp.Method.Get,
                baseUrl = $"{ApiHelper.API_BASE_URL}/x/web-interface/archive/related",
                parameter = new ApiParameter
                {
                    { isbvid ? "bvid" : "aid", id },
                }
            };

            return api;
        }
    }
}
