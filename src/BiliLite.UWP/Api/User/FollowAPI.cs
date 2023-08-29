using BiliLite.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiliLite.Api.User
{
    public class FollowAPI
    {
        /// <summary>
        /// 我的追番
        /// </summary>
        /// <param name="page">页数</param>
        /// <param name="status">0=全部，1=想看，2=在看，3=看过</param>
        /// <param name="pagesize">每页数量</param>
        /// <returns></returns>
        public ApiModel MyFollowBangumi(int page = 1, int status = 0, int pagesize = 20)
        {
            //ApiHelper.MustParameter(ApiHelper.AndroidKey, true) + $"&pn={page}&ps={pagesize}&status={status}",
            ApiModel api = new ApiModel()
            {
                method = RestSharp.Method.Get,
                baseUrl = $"{ApiHelper.API_BASE_URL}/pgc/app/follow/v2/bangumi",
                parameter = new ApiParameter
                {
                    { "pn", page.ToString() },
                    { "ps", pagesize.ToString() },
                    { "status", status.ToString() }
                } + ApiHelper.MustParameter(ApiHelper.AndroidKey, true)
            };
            api.parameter += ApiHelper.GetSign(api.parameter, ApiHelper.AndroidKey);
            return api;
        }

        /// <summary>
        /// 我的追剧
        /// </summary>
        /// <param name="page">页数</param>
        /// <param name="status">0=全部，1=想看，2=在看，3=看过</param>
        /// <param name="pagesize">每页数量</param>
        /// <returns></returns>
        public ApiModel MyFollowCinema(int page = 1, int status = 0, int pagesize = 20)
        {
            //ApiHelper.MustParameter(ApiHelper.AndroidKey, true) + $"&pn={page}&ps={pagesize}&status={status}",
            ApiModel api = new ApiModel()
            {
                method = RestSharp.Method.Get,
                baseUrl = $"{ApiHelper.API_BASE_URL}/pgc/app/follow/v2/cinema",
                parameter = new ApiParameter
                {
                    { "pn", page.ToString() },
                    { "ps", pagesize.ToString() },
                    { "status", status.ToString() }
                } + ApiHelper.MustParameter(ApiHelper.AndroidKey, true)
            };
            api.parameter += ApiHelper.GetSign(api.parameter, ApiHelper.AndroidKey);
            return api;
        }

        /// <summary>
        /// 收藏番剧
        /// </summary>
        /// <returns></returns>
        public ApiModel FollowSeason(string season_id)
        {
            //ApiHelper.MustParameter(ApiHelper.AndroidKey, true) + $"&season_id={season_id}"
            ApiParameter body = new ApiParameter
            {
                { "season_id", season_id }
            } + ApiHelper.MustParameter(ApiHelper.AndroidKey, true);

            ApiModel api = new ApiModel()
            {
                method = RestSharp.Method.Post,
                baseUrl = $"{ApiHelper.API_BASE_URL}/pgc/app/follow/add",
                body = body.ToString()
            };
            api.body += '&' + ApiHelper.GetSign(api.body, ApiHelper.AndroidKey).ToString();
            return api;
        }

        /// <summary>
        /// 取消收藏番剧
        /// </summary>
        /// <returns></returns>
        public ApiModel CancelFollowSeason(string season_id)
        {
            //ApiHelper.MustParameter(ApiHelper.AndroidKey, true) + $"&season_id={season_id}"
            ApiParameter body = new ApiParameter
            {
                { "season_id", season_id }
            } + ApiHelper.MustParameter(ApiHelper.AndroidKey, true);

            ApiModel api = new ApiModel()
            {
                method = RestSharp.Method.Post,
                baseUrl = $"{ApiHelper.API_BASE_URL}/pgc/app/follow/del",
                body = body.ToString()
            };
            api.body += '&' + ApiHelper.GetSign(api.body, ApiHelper.AndroidKey).ToString();
            return api;
        }

        /// <summary>
        /// 设置状态
        /// </summary>
        /// <returns></returns>
        public ApiModel SetSeasonStatus(string season_id,int status)
        {
            //ApiHelper.MustParameter(ApiHelper.AndroidKey, true) + $"&season_id={season_id}&status={status}"
            ApiParameter body = new ApiParameter
            {
                { "season_id", season_id },
                { "status", status.ToString() }
            } + ApiHelper.MustParameter(ApiHelper.AndroidKey, true);

            ApiModel api = new ApiModel()
            {
                method = RestSharp.Method.Post,
                baseUrl = $"{ApiHelper.API_BASE_URL}/pgc/app/follow/status/update",
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
    }
}
