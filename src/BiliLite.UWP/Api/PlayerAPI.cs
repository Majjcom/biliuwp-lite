﻿using BiliLite.Helpers;
using BiliLite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiliLite.Api
{
    public class PlayerAPI
    {
        public ApiModel VideoPlayUrl(string aid, string cid, int qn,bool dash,bool proxy=false,string area="")
        {
            var baseUrl = ApiHelper.API_BASE_URL;

            if (proxy)
            {
                baseUrl = Utils.ChooseProxyServer(area);
            }
            ApiModel api = new ApiModel()
            {
                method = RestSharp.Method.Get,
                baseUrl = $"{baseUrl}/x/player/playurl",
                parameter = new ApiParameter
                {
                    { "avid", aid },
                    { "cid", cid },
                    { "qn", qn.ToString() },
                    { "type", "" },
                    { "otype", "json" },
                    { "mid", SettingHelper.Account.Logined ? SettingHelper.Account.Profile.mid.ToString() : "" }
                } + ApiHelper.MustParameter(ApiHelper.WebVideoKey, true)
            };
            //ApiHelper.MustParameter(ApiHelper.WebVideoKey, true) + $"&avid={aid}&cid={cid}&qn={qn}&type=&otype=json&mid={(SettingHelper.Account.Logined? SettingHelper.Account.Profile.mid.ToString():"")}"
            if (dash)
            {
                api.parameter += new ApiParameter
                {
                    { "fourk", "1" },
                    { "fnver", "0" },
                    { "fnval", "4048" }
                };
                //"&fourk=1&fnver=0&fnval=4048"
            }

            api.parameter += ApiHelper.GetSign(api.parameter, ApiHelper.WebVideoKey);
            if (proxy)
            {
                api.parameter += new ApiParameter
                {
                    { "area", area }
                };
                //$"&area={area}"
            }
            return api;
        }

       

        public ApiModel SeasonPlayUrl(string aid, string cid, string ep_id, int qn,int season_type, bool dash, bool proxy = false, string area = "")
        {
            var baseUrl = ApiHelper.API_BASE_URL;
            if (proxy)
            {
                baseUrl = Utils.ChooseProxyServer(area);
            }
            ApiModel api = new ApiModel()
            {
                method = RestSharp.Method.Get,
                baseUrl = $"{baseUrl}/pgc/player/web/playurl",
                parameter = new ApiParameter
                {
                    { "appkey", ApiHelper.WebVideoKey.Appkey },
                    { "cid", cid },
                    { "ep_id", ep_id },
                    { "qn", qn.ToString() },
                    { "type", "" },
                    { "otype", "json" },
                    { "module", "bangumi" },
                    { "season_type", season_type.ToString() }
                }
            };
            //$"appkey={ApiHelper.WebVideoKey.Appkey}&cid={cid}&ep_id={ep_id}&qn={qn}&type=&otype=json&module=bangumi&season_type={season_type}"
            if (SettingHelper.Account.Logined)
            {
                api.parameter += new ApiParameter
                {
                    { "access_key", SettingHelper.Account.AccessKey },
                    { "mid", SettingHelper.Account.Profile.mid.ToString() }
                };
                //$"&access_key={SettingHelper.Account.AccessKey}&mid={SettingHelper.Account.Profile.mid}"
            }
            if (dash)
            {
                api.parameter += new ApiParameter
                {
                    { "fourk", "1" },
                    { "fnver", "0" },
                    { "fnval", "4048" }
                };
                //"&fourk=1&fnver=0&fnval=4048"
            }

            api.parameter += ApiHelper.GetSign(api.parameter, ApiHelper.WebVideoKey);
            if (proxy)
            {
                api.parameter += new ApiParameter
                {
                    { "area", area }
                };
                //$"&area={area}"
            }
            return api;
        }
        public ApiModel SeasonAndroidPlayUrl(string aid, string cid, int qn, int season_type, bool dash)
        {
            ApiModel api = new ApiModel()
            {
                method = RestSharp.Method.Get,
                baseUrl = $"{ApiHelper.API_BASE_URL}/pgc/player/web/playurl",
                parameter = new ApiParameter
                {
                    { "appkey", ApiHelper.AndroidKey.Appkey },
                    { "cid", cid },
                    { "qn", qn.ToString() },
                    { "type", "" },
                    { "otype", "json" },
                    { "module", "bangumi" },
                    { "season_type", season_type.ToString() }
                }
            };
            //$"appkey={ApiHelper.AndroidKey.Appkey}&cid={cid}&qn={qn}&type=&otype=json&module=bangumi&season_type={season_type}"
            if (SettingHelper.Account.Logined)
            {
                api.parameter += new ApiParameter
                {
                    { "access_key", SettingHelper.Account.AccessKey },
                    { "mid", SettingHelper.Account.Profile.mid.ToString() }
                };
                //$"&access_key={SettingHelper.Account.AccessKey}&mid={SettingHelper.Account.Profile.mid}"
            }
            if (dash)
            {
                api.parameter += new ApiParameter
                {
                    { "fourk", "1" },
                    { "fnver", "0" },
                    { "fnval", "4048" }
                };
                //"&fourk=1&fnver=0&fnval=4048"
            }
            api.parameter += ApiHelper.GetSign(api.parameter, ApiHelper.WebVideoKey);
            return api;
        }

        public ApiModel LivePlayUrl(string cid, int qn=0)
        {
            ApiModel api = new ApiModel()
            {
                method = RestSharp.Method.Get,
                baseUrl = $"https://api.live.bilibili.com/room/v1/Room/playUrl",
                parameter = new ApiParameter
                {
                    { "cid", cid },
                    { "qn", qn.ToString() },
                    { "platform", "web" }
                }
            };
            //$"cid={cid}&qn={qn}&platform=web"
            //api.parameter += ApiHelper.GetSign(api.parameter, ApiHelper.AndroidVideoKey);
            return api;
        }

        /// <summary>
        /// 互动视频信息
        /// </summary>
        /// <param name="aid"></param>
        /// <param name="graph_version"></param>
        /// <param name="edge_id"></param>
        /// <returns></returns>
        public ApiModel InteractionEdgeInfo(string aid,int graph_version,int edge_id=0)
        {
            ApiModel api = new ApiModel()
            {
                method = RestSharp.Method.Get,
                baseUrl = $"{ApiHelper.API_BASE_URL}/x/stein/edgeinfo_v2",
                parameter = new ApiParameter
                {
                    { "aid", aid },
                    { "graph_version", graph_version.ToString() },
                    { "edge_id", edge_id.ToString() }
                } + ApiHelper.MustParameter(ApiHelper.AndroidKey, true)
            };
            //ApiHelper.MustParameter(ApiHelper.AndroidKey, true) + $"&aid={aid}&graph_version={graph_version}&edge_id={edge_id}"
            api.parameter += ApiHelper.GetSign(api.parameter, ApiHelper.AndroidKey);
            return api;
        }

        /// <summary>
        /// 番剧播放记录上传
        /// </summary>
        /// <param name="aid">AVID</param>
        /// <param name="cid">CID</param>
        /// <param name="sid">SID</param>
        /// <param name="epid">EPID</param>
        /// <param name="type">类型 3=视频，4=番剧</param>
        /// <param name="progress">进度/秒</param>
        /// <returns></returns>
        public ApiModel SeasonHistoryReport(string aid,string cid, int progress, int sid=0,string epid="0",int type=3)
        {
            ApiParameter body = new ApiParameter
            {
                { "aid", aid },
                { "cid", cid },
                { "epid", epid },
                { "sid", sid.ToString() },
                { "progress", progress.ToString() },
                { "realtime", progress.ToString() },
                { "sub_type", "1" },
                { "type", type.ToString() }
            } + ApiHelper.MustParameter(ApiHelper.AndroidVideoKey, true);

            ApiModel api = new ApiModel()
            {
                method = RestSharp.Method.Post,
                baseUrl = $"{ApiHelper.API_BASE_URL}/x/v2/history/report",
                body = body.ToString()
            };
            //$"&aid={aid}&cid={cid}&epid={epid}&sid={sid}&progress={progress}&realtime={progress}&sub_type=1&type={type}" + ApiHelper.MustParameter(ApiHelper.AndroidVideoKey, true)
            api.body += '&' + ApiHelper.GetSign(api.body, ApiHelper.AndroidVideoKey).ToString();
            return api;
        }
       /// <summary>
       /// 发送弹幕
       /// </summary>
       /// <param name="aid">AV</param>
       /// <param name="cid">CID</param>
       /// <param name="color">颜色(10进制)</param>
       /// <param name="msg">内容</param>
       /// <param name="position">位置</param>
       /// <param name="mode">类型</param>
       /// <param name="plat">平台</param>
       /// <returns></returns>
        public ApiModel SendDanmu(string aid,string cid,string color,string msg,int position,int mode=1,int plat=2)
        {
            ApiModel api = new ApiModel()
            {
                method = RestSharp.Method.Post,
                baseUrl = $"{ApiHelper.API_BASE_URL}/x/v2/dm/post",
                parameter = new ApiParameter
                {
                    { "aid", aid }
                } + ApiHelper.MustParameter(ApiHelper.AndroidVideoKey, true),
                body = new ApiParameter
                {
                    { "msg", Uri.EscapeDataString(msg) },
                    { "mode", mode.ToString() },
                    { "screen_state", "1" },
                    { "color", color },
                    { "pool", "0" },
                    { "progress", Convert.ToInt32(position * 1000).ToString() },
                    { "fontsize", "25" },
                    { "rnd", Utils.GetTimestampS().ToString() },
                    { "from", "7" },
                    { "cid", cid },         // oid ??
                    { "plat", plat.ToString() },
                    { "type", "1" }
                }.ToString()
            };
            //ApiHelper.MustParameter(ApiHelper.AndroidVideoKey, true) + $"&aid={aid}"
            //$"msg={Uri.EscapeDataString(msg)}&mode={mode}&screen_state=1&color={color}&pool=0&progress={Convert.ToInt32(position * 1000)}&fontsize=25&rnd={Utils.GetTimestampS()}&from=7&oid={cid}&plat={plat}&type=1"
            api.parameter += ApiHelper.GetSign(api.parameter, ApiHelper.AndroidVideoKey);
            return api;
        }
        /// <summary>
        /// 读取播放信息
        /// </summary>
        /// <param name="aid">AV</param>
        /// <param name="cid">CID</param>
        /// <returns></returns>
        public ApiModel GetPlayerInfo(string aid, string cid,string bvid)
        {
            ApiModel api = new ApiModel()
            {
                method = RestSharp.Method.Get,
                baseUrl = $"{ApiHelper.API_BASE_URL}/x/player/v2",
                parameter = new ApiParameter
                {
                    { "cid", cid },
                    { "aid", aid },
                    { "bvid", bvid }
                }
            };
            //$"cid={cid}&aid={aid}&bvid={bvid}",
            return api;
        }
        /// <summary>
        /// 读取视频在线人数
        /// </summary>
        /// <param name="aid">AV</param>
        /// <param name="cid">CID</param>
        /// <returns></returns>
        public ApiModel GetPlayerOnline(string aid, string cid, string bvid)
        {
            ApiModel api = new ApiModel()
            {
                method = RestSharp.Method.Get,
                baseUrl = $"{ApiHelper.API_BASE_URL}/x/player/online/total",
                parameter = new ApiParameter
                {
                    { "cid", cid },
                    { "aid", aid },
                    { "bvid", bvid }
                }
            };
            //$"cid={cid}&aid={aid}&bvid={bvid}",
            return api;
        }

        /// <summary>
        /// 弹幕关键词
        /// </summary>
        /// <returns></returns>
        public ApiModel GetDanmuFilterWords()
        {
            ApiModel api = new ApiModel()
            {
                method = RestSharp.Method.Get,
                baseUrl = $"{ApiHelper.API_BASE_URL}/x/dm/filter/user",
                parameter = ApiHelper.MustParameter(ApiHelper.AndroidVideoKey, true) 
            };
            api.parameter += ApiHelper.GetSign(api.parameter, ApiHelper.AndroidVideoKey);
            return api;
        }
        /// <summary>
        /// 添加弹幕屏蔽关键词
        /// </summary>
        /// <param name="word">关键词</param>
        /// <param name="type">类型，0=关键字，1=正则，2=用户</param>
        /// <returns></returns>
        public ApiModel AddDanmuFilterWord(string word,int type)
        {
            ApiModel api = new ApiModel()
            {
                method = RestSharp.Method.Post,
                baseUrl = $"{ApiHelper.API_BASE_URL}/x/dm/filter/user/add",
                body = new ApiParameter
                {
                    { "filter", Uri.EscapeDataString(word) },
                    { "type", type.ToString() }
                }.ToString()
            };
            //ApiHelper.MustParameter(ApiHelper.AndroidVideoKey, true) + $"&filter={Uri.EscapeDataString(word)}&type={type}"
            api.body += '&' + ApiHelper.GetSign(api.parameter, ApiHelper.AndroidVideoKey).ToString();
            return api;
        }
        /// <summary>
        /// 分段弹幕
        /// </summary>
        /// <param name="oid"></param>
        /// <param name="segment_index"></param>
        /// <returns></returns>
        public ApiModel SegDanmaku(string oid, int segment_index)
        {
            ApiModel api = new ApiModel()
            {
                method = RestSharp.Method.Get,
                baseUrl = $"http://api.bilibili.com/x/v2/dm/list/seg.so",
                parameter = new ApiParameter
                {
                    { "type", "1" },
                    { "oid", oid },
                    { "segment_index", segment_index.ToString() }
                }
            };
            //$"type=1&oid={oid}&segment_index={segment_index}"
            return api;
        }

        /// <summary>
        /// 生成一个MPD文件链接
        /// </summary>
        /// <param name="generate"></param>
        /// <returns></returns>
        public string GenerateMPD(GenerateMPDModel generate)
        {
            var par=Newtonsoft.Json.JsonConvert.SerializeObject(generate);
            return $"{ApiHelper.IL_BASE_URL}/api/player/generatempd?par={Uri.EscapeDataString(par)}";
        }


    }
}
