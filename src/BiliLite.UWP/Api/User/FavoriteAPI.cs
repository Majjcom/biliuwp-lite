﻿using BiliLite.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiliLite.Api.User
{
    /// <summary>
    /// 收藏夹相关API
    /// </summary>
    public class FavoriteApi
    {
        /// <summary>
        /// 我的收藏夹/收藏的收藏夹
        /// </summary>
        /// <returns></returns>
        public ApiModel MyFavorite()
        {
            //ApiHelper.MustParameter(ApiHelper.AndroidKey, true) + $"&up_mid={SettingHelper.Account.UserID}"
            ApiModel api = new ApiModel()
            {
                method = RestSharp.Method.Get,
                baseUrl = $"{ApiHelper.API_BASE_URL}/x/v3/fav/folder/created/list-all",
                parameter = new ApiParameter
                {
                    { "up_mid", SettingHelper.Account.UserID.ToString() }
                } + ApiHelper.MustParameter(ApiHelper.AndroidKey, true)
            };
            api.parameter += ApiHelper.GetSign(api.parameter, ApiHelper.AndroidKey);
            return api;
        }
        public ApiModel MyCreatedFavoriteList(int page)
        {
            //ApiHelper.MustParameter(ApiHelper.AndroidKey, true) + $"&up_mid={SettingHelper.Account.UserID}&pn={page}&ps=20"
            ApiModel api = new ApiModel()
            {
                method = RestSharp.Method.Get,
                baseUrl = $"{ApiHelper.API_BASE_URL}/x/v3/fav/folder/collected/list",
                parameter = new ApiParameter
                {
                    { "up_mid", SettingHelper.Account.UserID.ToString() },
                    { "pn", page.ToString() },
                    { "ps", "20" }
                } + ApiHelper.MustParameter(ApiHelper.AndroidKey, true)
            };
            api.parameter += ApiHelper.GetSign(api.parameter, ApiHelper.AndroidKey);
            return api;
        }
        /// <summary>
        /// 我创建的收藏夹
        /// </summary>
        /// <returns></returns>
        public ApiModel MyCreatedFavorite(string aid)
        {
            //ApiHelper.MustParameter(ApiHelper.AndroidKey, true) + $"&rid={aid}&up_mid={SettingHelper.Account.UserID}&type=2&pn=1&ps=100"
            ApiModel api = new ApiModel()
            {
                method = RestSharp.Method.Get,
                //baseUrl = $"{ApiHelper.API_BASE_URL}/medialist/gateway/base/created",
                baseUrl = $"{ApiHelper.API_BASE_URL}/x/v3/fav/folder/collected/list",
                parameter = new ApiParameter
                {
                    { "rid", aid },
                    { "up_mid", SettingHelper.Account.UserID.ToString() },
                    { "type", "2" },
                    { "pn", "1" },
                    { "ps", "100" }
                } + ApiHelper.MustParameter(ApiHelper.AndroidTVKey, true)
            };
            api.parameter += ApiHelper.GetSign(api.parameter, ApiHelper.AndroidTVKey);
            return api;
        }

        /// <summary>
        /// 添加到收藏夹
        /// </summary>
        /// <returns></returns>
        public ApiModel AddFavorite(List<string> fav_ids, string avid)
        {
            var ids = "";
            foreach (var item in fav_ids)
            {
                ids += item + ",";
            }
            ids = Uri.EscapeDataString(ids.TrimEnd(','));
            //ApiHelper.MustParameter(ApiHelper.AndroidKey, true) + $"&add_media_ids={ids}&rid={avid}&type=2"
            ApiParameter body = new ApiParameter
            {
                { "add_media_ids", ids },
                { "rid", avid },
                { "type", "2" }
            } + ApiHelper.MustParameter(ApiHelper.AndroidKey, true);

            ApiModel api = new ApiModel()
            {
                method = RestSharp.Method.Post,
                baseUrl = $"{ApiHelper.API_BASE_URL}/medialist/gateway/coll/resource/deal",
                body = body.ToString()
            };
            api.body += '&' + ApiHelper.GetSign(api.body, ApiHelper.AndroidKey).ToString();
            return api;
        }

        /// <summary>
        /// 收藏收藏夹
        /// </summary>
        /// <returns></returns>
        public ApiModel CollectFavorite(string media_id)
        {
            //ApiHelper.MustParameter(ApiHelper.AndroidKey, true) + $"&media_id={media_id}"
            ApiParameter body = new ApiParameter
            {
                { "media_id", media_id }
            } + ApiHelper.MustParameter(ApiHelper.AndroidKey, true);

            ApiModel api = new ApiModel()
            {
                method = RestSharp.Method.Post,
                baseUrl = $"{ApiHelper.API_BASE_URL}/x/v3/fav/folder/fav",
                body = body.ToString()
            };
            api.body += '&' + ApiHelper.GetSign(api.body, ApiHelper.AndroidKey).ToString();
            return api;
        }

        /// <summary>
        /// 取消收藏收藏夹
        /// </summary>
        /// <returns></returns>
        public ApiModel CacnelCollectFavorite(string media_id)
        {
            //ApiHelper.MustParameter(ApiHelper.AndroidKey, true) + $"&media_id={media_id}"
            ApiParameter body = new ApiParameter
            {
                { "media_id", media_id }
            } + ApiHelper.MustParameter(ApiHelper.AndroidKey, true);

            ApiModel api = new ApiModel()
            {
                method = RestSharp.Method.Post,
                baseUrl = $"{ApiHelper.API_BASE_URL}/x/v3/fav/folder/unfav",
                body = body.ToString()
            };
            api.body += '&' + ApiHelper.GetSign(api.body, ApiHelper.AndroidKey).ToString();
            return api;
        }

        /// <summary>
        /// 创建收藏夹
        /// </summary>
        /// <param name="title">标题</param>
        /// <param name="intro">介绍</param>
        /// <param name="isOpen">是否私密</param>
        /// <returns></returns>
        public ApiModel CreateFavorite(string title,string intro, bool isOpen)
        {
            //ApiHelper.MustParameter(ApiHelper.AndroidKey, true) + $"privacy={(isOpen ? 0 : 1)}&title={Uri.EscapeDataString(title)}&intro={Uri.EscapeDataString(intro)}"
            ApiParameter body = new ApiParameter
            {
                { "privacy", (isOpen ? 0 : 1).ToString() },
                { "title", Uri.EscapeDataString(title) },
                { "intro", Uri.EscapeDataString(intro) }
            } + ApiHelper.MustParameter(ApiHelper.AndroidKey, true);

            ApiModel api = new ApiModel()
            {
                method = RestSharp.Method.Post,
                baseUrl = $"{ApiHelper.API_BASE_URL}/x/v3/fav/folder/add",
                body = body.ToString()
            };
            api.body += '&' + ApiHelper.GetSign(api.body, ApiHelper.AndroidKey).ToString();
            return api;
        }
        /// <summary>
        /// 编辑收藏夹
        /// </summary>
        /// <param name="title">标题</param>
        /// <param name="intro">介绍</param>
        /// <param name="isOpen">是否私密</param>
        /// <param name="media_id">收藏夹ID</param>
        /// <returns></returns>
        public ApiModel EditFavorite(string title, string intro, bool isOpen, string media_id)
        {
            //ApiHelper.MustParameter(ApiHelper.AndroidKey, true) + $"privacy={(isOpen ? 0 : 1)}&title={Uri.EscapeDataString(title)}&intro={Uri.EscapeDataString(intro)}&media_id={media_id}"
            ApiParameter body = new ApiParameter
            {
                { "privacy", (isOpen ? 0 : 1).ToString() },
                { "title", Uri.EscapeDataString(title) },
                { "intro", Uri.EscapeDataString(intro) },
                { "media_id", media_id }
            } + ApiHelper.MustParameter(ApiHelper.AndroidKey, true);

            ApiModel api = new ApiModel()
            {
                method = RestSharp.Method.Post,
                baseUrl = $"{ApiHelper.API_BASE_URL}/x/v3/fav/folder/edit",
                body = body.ToString()
            };
            api.body += '&' + ApiHelper.GetSign(api.body, ApiHelper.AndroidKey).ToString();
            return api;
        }

        /// <summary>
        /// 删除收藏夹
        /// </summary>
        /// <param name="media_id">收藏夹ID</param>
        /// <returns></returns>
        public ApiModel DelFavorite(string media_id)
        {
            //ApiHelper.MustParameter(ApiHelper.AndroidKey, true) + $"&media_ids={media_id}"
            ApiParameter body = new ApiParameter
            {
                { "media_ids", media_id }
            } + ApiHelper.MustParameter(ApiHelper.AndroidKey, true);

            ApiModel api = new ApiModel()
            {
                method = RestSharp.Method.Post,
                baseUrl = $"{ApiHelper.API_BASE_URL}/x/v3/fav/folder/del",
                body = body.ToString()
            };
            api.body += '&' + ApiHelper.GetSign(api.body, ApiHelper.AndroidKey).ToString();
            return api;
        }

        /// <summary>
        /// 收藏夹信息
        /// </summary>
        /// <returns></returns>
        public ApiModel FavoriteInfo(string fid, string keyword, int page = 1)
        {
            //ApiHelper.MustParameter(ApiHelper.AndroidKey, true) + $"&media_id={fid}&mid={SettingHelper.Account.UserID}&keyword={Uri.EscapeDataString(keyword)}&pn={page}&ps=20"
            ApiModel api = new ApiModel()
            {
                method = RestSharp.Method.Get,
                baseUrl = $"{ApiHelper.API_BASE_URL}/x/v3/fav/resource/list",
                parameter = new ApiParameter
                {
                    { "media_id" ,fid },
                    { "mid", SettingHelper.Account.UserID.ToString() },
                    { "keyword", Uri.EscapeDataString(keyword) },
                    { "pn", page.ToString() },
                    { "ps", "20" }
                } + ApiHelper.MustParameter(ApiHelper.AndroidTVKey, true)
            };
            api.parameter += ApiHelper.GetSign(api.parameter, ApiHelper.AndroidTVKey);
            return api;
        }
        public ApiModel FavoriteSeasonInfo(string season_id, string keyword, int page = 1)
        {
            //ApiHelper.MustParameter(ApiHelper.AndroidKey, true) + $"&season_id={season_id}&mid={SettingHelper.Account.UserID}&keyword={Uri.EscapeDataString(keyword)}&pn={page}&ps=20"
            ApiModel api = new ApiModel()
            {
                method = RestSharp.Method.Get,
                baseUrl = $"{ApiHelper.API_BASE_URL}/x/space/fav/season/list",
                parameter = new ApiParameter
                {
                    { "season_id", season_id },
                    { "mid", SettingHelper.Account.UserID.ToString() },
                    { "keyword", Uri.EscapeDataString(keyword) },
                    { "pn", page.ToString() },
                    { "ps", "20" }
                } + ApiHelper.MustParameter(ApiHelper.AndroidKey, true)
            };
            api.parameter += ApiHelper.GetSign(api.parameter, ApiHelper.AndroidKey);
            return api;
        }

        /// <summary>
        /// 取消收藏
        /// </summary>
        /// <returns></returns>
        public ApiModel Delete(string media_id,List<string> video_ids)
        {
            var ids = "";
            foreach (var item in video_ids)
            {
                ids += $"{item}:2,";
            }
            ids = Uri.EscapeDataString(ids.TrimEnd(','));
            //ApiHelper.MustParameter(ApiHelper.AndroidKey, true) + $"&media_id={media_id}&resources={ids}"
            ApiParameter body = new ApiParameter
            {
                { "media_id", media_id },
                { "resources", ids }
            } + ApiHelper.MustParameter(ApiHelper.AndroidKey, true);

            ApiModel api = new ApiModel()
            {
                method = RestSharp.Method.Post,
                baseUrl = $"{ApiHelper.API_BASE_URL}/x/v3/fav/resource/batch-del",
                body = body.ToString()
            };
            api.body += '&' + ApiHelper.GetSign(api.body, ApiHelper.AndroidKey).ToString();
            return api;
        }
        /// <summary>
        /// 复制到自己的收藏夹
        /// </summary>
        /// <returns></returns>
        public ApiModel Copy(string src_media_id, string tar_media_id, List<string> video_ids,string mid)
        {
            var ids = "";
            foreach (var item in video_ids)
            {
                ids += $"{item}:2,";
            }
            ids = Uri.EscapeDataString(ids.TrimEnd(','));
            //ApiHelper.MustParameter(ApiHelper.AndroidKey, true) + $"&src_media_id={src_media_id}&tar_media_id={tar_media_id}&resources={ids}&mid={mid}"
            ApiParameter body = new ApiParameter
            {
                { "src_media_id", src_media_id },
                { "tar_media_id", tar_media_id },
                { "resources", ids },
                { "mid", mid }
            } + ApiHelper.MustParameter(ApiHelper.AndroidKey, true);

            ApiModel api = new ApiModel()
            {
                method = RestSharp.Method.Post,
                baseUrl = $"{ApiHelper.API_BASE_URL}/x/v3/fav/resource/copy",
                body = body.ToString()
            };
            api.body += '&' + ApiHelper.GetSign(api.body, ApiHelper.AndroidKey).ToString();
            return api;
        }
        /// <summary>
        /// 移动到收藏夹
        /// </summary>
        /// <returns></returns>
        public ApiModel Move(string src_media_id, string tar_media_id, List<string> video_ids)
        {
            var ids = "";
            foreach (var item in video_ids)
            {
                ids += $"{item}:2,";
            }
            ids = Uri.EscapeDataString(ids.TrimEnd(','));
            //ApiHelper.MustParameter(ApiHelper.AndroidKey, true) + $"&src_media_id={src_media_id}&tar_media_id={tar_media_id}&resources={ids}"
            ApiParameter body = new ApiParameter
            {
                { "src_media_id", src_media_id },
                { "tar_media_id", tar_media_id },
                { "resources", ids },
            } + ApiHelper.MustParameter(ApiHelper.AndroidKey, true);

            ApiModel api = new ApiModel()
            {
                method = RestSharp.Method.Post,
                baseUrl = $"{ApiHelper.API_BASE_URL}/x/v3/fav/resource/move",
                body = body.ToString()
            };
            api.body += '&' + ApiHelper.GetSign(api.body, ApiHelper.AndroidKey).ToString();
            return api;
        }
        /// <summary>
        /// 清除失效
        /// </summary>
        /// <returns></returns>
        public ApiModel Clean(string media_id)
        {
            //ApiHelper.MustParameter(ApiHelper.AndroidKey, true) + $"&media_id={media_id}"
            ApiParameter body = new ApiParameter
            {
                { "media_id", media_id }
            } + ApiHelper.MustParameter(ApiHelper.AndroidKey, true);

            ApiModel api = new ApiModel()
            {
                method = RestSharp.Method.Post,
                baseUrl = $"{ApiHelper.API_BASE_URL}/x/v3/fav/resource/clean",
                body = body.ToString()
            };
            api.body += '&' + ApiHelper.GetSign(api.body, ApiHelper.AndroidKey).ToString();
            return api;
        }
    }
}
