using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiliLite.Api.User
{
    public class UserDetailAPI
    {
        /// <summary>
        /// 用户信息
        /// </summary>
        /// <param name="mid"></param>
        /// <returns></returns>
        public ApiModel UserInfo(string mid)
        {
            //ApiHelper.MustParameter(ApiHelper.AndroidKey,needAccesskey:true) + $"&mid={mid}",
            ApiModel api = new ApiModel()
            {
                method = RestSharp.Method.Get,
                baseUrl = $"{ApiHelper.API_BASE_URL}/x/space/myinfo",
                parameter = new ApiParameter
                {
                    { "mid", mid }
                } + ApiHelper.MustParameter(ApiHelper.AndroidKey, true)
            };

            return api;
        }

        /// <summary>
        /// 个人空间
        /// </summary>
        /// <param name="mid"></param>
        /// <returns></returns>
        public ApiModel Space(string mid)
        {
            //ApiHelper.MustParameter(ApiHelper.AndroidKey,needAccesskey:true) + $"&vmid={mid}",
            ApiModel api = new ApiModel()
            {
                method = RestSharp.Method.Get,
                baseUrl = "https://app.bilibili.com/x/v2/space",
                parameter = new ApiParameter
                {
                    { "vmid", mid }
                } + ApiHelper.MustParameter(ApiHelper.AndroidKey, true)
            };
            api.parameter += ApiHelper.GetSign(api.parameter, ApiHelper.AndroidKey);
            return api;
        }

        /// <summary>
        /// 数据
        /// </summary>
        /// <param name="mid"></param>
        /// <returns></returns>
        public ApiModel UserStat(string mid)
        {
            //$"vmid={mid}",
            ApiModel api = new ApiModel()
            {
                method = RestSharp.Method.Get,
                baseUrl = $"{ApiHelper.API_BASE_URL}/x/relation/stat",
                parameter = new ApiParameter
                {
                    { "vmid", mid }
                }
            };
         
            return api;
        }

        /// <summary>
        /// 用户视频投稿
        /// </summary>
        /// <param name="mid">用户ID</param>
        /// <param name="page">页数</param>
        /// <param name="pagesize">每页数量</param>
        /// <returns></returns>
        public ApiModel SubmitVideos(string mid, int page = 1, int pagesize = 30, string keyword = "", int tid=0, SubmitVideoOrder order = SubmitVideoOrder.pubdate)
        {
            //$"mid={mid}&ps={pagesize}&tid={tid}&pn={page}&keyword={keyword}&order={order.ToString()}",
            ApiModel api = new ApiModel()
            {
                method = RestSharp.Method.Get,
                baseUrl = $"{ApiHelper.API_BASE_URL}/x/space/arc/search",
                parameter = new ApiParameter
                {
                    { "mid", mid },
                    { "ps", pagesize.ToString() },
                    { "tid", tid.ToString() },
                    { "pn", page.ToString() },
                    { "keyword", keyword },
                    { "order", order.ToString() }
                }
            };
            return api;
        }

        /// <summary>
        /// 用户专栏投稿
        /// </summary>
        /// <param name="mid">用户ID</param>
        /// <param name="page">页数</param>
        /// <param name="pagesize">每页数量</param>
        /// <returns></returns>
        public ApiModel SubmitArticles(string mid, int page = 1, int pagesize = 30, SubmitArticleOrder order = SubmitArticleOrder.publish_time)
        {
            //$"mid={mid}&ps={pagesize}&pn={page}&sort={order.ToString()}",
            ApiModel api = new ApiModel()
            {
                method = RestSharp.Method.Get,
                baseUrl = $"{ApiHelper.API_BASE_URL}/x/space/article",
                parameter = new ApiParameter
                {
                    { "mid", mid },
                    { "ps", pagesize.ToString() },
                    { "pn", page.ToString() },
                    { "sort", order.ToString() }
                }
            };
            return api;
        }

        /// <summary>
        /// 关注的分组
        /// </summary>
        /// <returns></returns>
        public ApiModel FollowingsTag()
        {
            ApiModel api = new ApiModel()
            {
                method = RestSharp.Method.Get,
                baseUrl = $"{ApiHelper.API_BASE_URL}/x/relation/tags",
                parameter = ApiHelper.MustParameter(ApiHelper.AndroidKey, true)
            };
            api.parameter += ApiHelper.GetSign(api.parameter, ApiHelper.AndroidKey);
            return api;
        }

        /// <summary>
        /// 关注的人
        /// </summary>
        /// <param name="mid">用户ID</param>
        /// <param name="page">页数</param>
        /// <param name="pagesize">每页数量</param>
        /// <returns></returns>
        public ApiModel Followings(string mid, int page = 1, int pagesize = 30, int tid = 0, string keyword="", FollowingsOrder order = FollowingsOrder.attention)
        {
            //ApiHelper.MustParameter(ApiHelper.AndroidKey,true) + $"&vmid={mid}&ps={pagesize}&pn={page}&order=desc&order_type={(order== FollowingsOrder.attention? "attention":"")}",
            ApiModel api = new ApiModel()
            {
                method = RestSharp.Method.Get,
                baseUrl = $"{ApiHelper.API_BASE_URL}/x/relation/followings",
                parameter = new ApiParameter
                {
                    { "vmid", mid },
                    { "ps", pagesize.ToString() },
                    { "pn", page.ToString() },
                    { "order", "desc" },
                    { "order_type", order == FollowingsOrder.attention ? "attention" : "" }
                }
            };
            if (tid==-1&& keyword != "")
            {
                api.baseUrl = $"{ApiHelper.API_BASE_URL}/x/relation/followings/search";
                //$"&name={keyword}";
                api.parameter += new ApiParameter
                {
                    { "name", keyword }
                };
            }
            if (tid != -1)
            {
                api.baseUrl = $"{ApiHelper.API_BASE_URL}/x/relation/tag";
                //$"&tagid={tid}&mid={mid}";
                api.parameter += new ApiParameter
                {
                    { "tagid", tid.ToString() },
                    { "mid", mid }
                };
            }
            api.parameter += ApiHelper.GetSign(api.parameter, ApiHelper.AndroidKey);
            return api;
        }

        /// <summary>
        /// 粉丝
        /// </summary>
        /// <param name="mid">用户ID</param>
        /// <param name="page">页数</param>
        /// <param name="pagesize">每页数量</param>
        /// <returns></returns>
        public ApiModel Followers(string mid, int page = 1, int pagesize = 30)
        {
            //$"vmid={mid}&ps={pagesize}&pn={page}&order=desc",
            ApiModel api = new ApiModel()
            {
                method = RestSharp.Method.Get,
                baseUrl = $"{ApiHelper.API_BASE_URL}/x/relation/followers",
                parameter = new ApiParameter
                {
                    { "vmid", mid },
                    { "ps", pagesize.ToString() },
                    { "pn", page.ToString() }
                }
            };
            return api;
        }

        /// <summary>
        /// 用户收藏夹
        /// </summary>
        /// <param name="mid">用户ID</param>
        /// <returns></returns>
        public ApiModel Favlist(string mid)
        {
            //$"up_mid={mid}",
            ApiModel api = new ApiModel()
            {
                method = RestSharp.Method.Get,
                baseUrl = $"{ApiHelper.API_BASE_URL}/x/v3/fav/folder/created/list-all",
                parameter = new ApiParameter
                {
                    { "up_mid", mid }
                }
            };
            return api;
        }
    }

    public enum SubmitVideoOrder
    {
        pubdate,
        click,
        stow
    }
    public enum SubmitArticleOrder
    {
        publish_time,
        view,
        fav
    }
    public enum FollowingsOrder
    {
        /// <summary>
        /// 关注时间
        /// </summary>
        addtime,
        /// <summary>
        /// 最常访问
        /// </summary>
        attention,
    }
}
