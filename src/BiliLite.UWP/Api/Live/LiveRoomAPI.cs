using BiliLite.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiliLite.Api.Live
{
    public class LiveRoomAPI
    {
        /// <summary>
        /// 直播间信息
        /// </summary>
        /// <param name="roomid"></param>
        /// <returns></returns>
        public ApiModel LiveRoomInfo(string roomid)
        {
            //ApiHelper.MustParameter(ApiHelper.AndroidKey, true) + $"&actionKey=appkey&room_id={roomid}&device=android"
            ApiModel api = new ApiModel()
            {
                method = RestSharp.Method.Get,
                baseUrl = $"https://api.live.bilibili.com/xlive/app-room/v1/index/getInfoByRoom",
                parameter = new ApiParameter
                {
                    { "actionKey", "appkey" },
                    { "room_id", roomid },
                } + ApiHelper.MustParameter(ApiHelper.AndroidKey, true)
            };
            api.parameter += ApiHelper.GetSign(api.parameter, ApiHelper.AndroidKey);
            return api;
        }
        /// <summary>
        /// 钱包
        /// </summary>
        /// <returns></returns>
        public ApiModel MyWallet()
        {
            //ApiHelper.MustParameter(ApiHelper.AndroidKey, true) + $"&actionKey=appkey"
            ApiModel api = new ApiModel()
            {
                method = RestSharp.Method.Get,
                baseUrl = $"https://api.live.bilibili.com/pay/v2/Pay/myWallet",
                parameter = new ApiParameter
                {
                    { "actionKey", "appkey" }
                } + ApiHelper.MustParameter(ApiHelper.AndroidKey, true)
            };
            api.parameter += ApiHelper.GetSign(api.parameter, ApiHelper.AndroidKey);
            return api;
        }

        /// <summary>
        /// 直播头衔列表
        /// </summary>
        /// <returns></returns>
        public ApiModel LiveTitles()
        {
            //ApiHelper.MustParameter(ApiHelper.AndroidKey, true) + $"&actionKey=appkey"
            ApiModel api = new ApiModel()
            {
                method = RestSharp.Method.Get,
                baseUrl = $"https://api.live.bilibili.com/rc/v1/Title/getTitle",
                parameter = new ApiParameter
                {
                    { "actionKey", "appkey" }
                } + ApiHelper.MustParameter(ApiHelper.AndroidKey, true)
            };
            api.parameter += ApiHelper.GetSign(api.parameter, ApiHelper.AndroidKey);
            return api;
        }

        /// <summary>
        /// 直播礼物列表
        /// </summary>
        /// <returns></returns>
        public ApiModel GiftList(int area_v2_id,int area_v2_parent_id,int roomId)
        {
            //ApiHelper.MustParameter(ApiHelper.AndroidKey, true) + $"&actionKey=appkey&area_v2_id={area_v2_id}&area_v2_parent_id={area_v2_parent_id}&roomid={roomId}"
            ApiModel api = new ApiModel()
            {
                method = RestSharp.Method.Get,
                baseUrl = $"https://api.live.bilibili.com/gift/v4/Live/giftConfig",
                parameter = new ApiParameter
                {
                    { "actionKey", "appkey" },
                    { "area_v2_id", area_v2_id.ToString() },
                    { "area_v2_parent_id", area_v2_parent_id.ToString() },
                    { "roomid", roomId.ToString() }
                } + ApiHelper.MustParameter(ApiHelper.AndroidKey, true)
            };
            api.parameter += ApiHelper.GetSign(api.parameter, ApiHelper.AndroidKey);
            return api;
        }

        /// <summary>
        /// 直播背包
        /// </summary>
        /// <returns></returns>
        public ApiModel BagList(int roomId)
        {
            //ApiHelper.MustParameter(ApiHelper.AndroidKey, true) + $"&actionKey=appkey&roomid={roomId}"
            ApiModel api = new ApiModel()
            {
                method = RestSharp.Method.Get,
                baseUrl = $"https://api.live.bilibili.com/xlive/app-room/v1/gift/bag_list",
                parameter = new ApiParameter
                {
                    { "actionKey", "appkey" },
                    { "roomid", roomId.ToString() }
                } + ApiHelper.MustParameter(ApiHelper.AndroidKey, true)
            };
            api.parameter += ApiHelper.GetSign(api.parameter, ApiHelper.AndroidKey);
            return api;
        }

        /// <summary>
        /// 直播房间可用礼物列表
        /// </summary>
        /// <returns></returns>
        public ApiModel RoomGifts(int area_v2_id, int area_v2_parent_id, int roomId)
        {
            //ApiHelper.MustParameter(ApiHelper.AndroidKey, true) + $"&actionKey=appkey&area_v2_id={area_v2_id}&area_v2_parent_id={area_v2_parent_id}&roomid={roomId}"
            ApiModel api = new ApiModel()
            {
                method = RestSharp.Method.Get,
                baseUrl = $"https://api.live.bilibili.com/gift/v3/live/room_gift_list",
                parameter = new ApiParameter
                {
                    { "actionKey", "appkey" },
                    { "area_v2_id", area_v2_id.ToString() },
                    { "area_v2_parent_id", area_v2_parent_id.ToString() },
                    { "roomid", roomId.ToString() }
                } + ApiHelper.MustParameter(ApiHelper.AndroidKey, true)
            };
            api.parameter += ApiHelper.GetSign(api.parameter, ApiHelper.AndroidKey);
            return api;
        }

        /// <summary>
        /// 免费瓜子（宝箱）
        /// </summary>
        /// <returns></returns>
        public ApiModel FreeSilverTime()
        {
            //ApiHelper.MustParameter(ApiHelper.AndroidKey, true) + $"&actionKey=appkey"
            ApiModel api = new ApiModel()
            {
                method = RestSharp.Method.Get,
                baseUrl = $"https://api.live.bilibili.com/mobile/freeSilverCurrentTask",
                parameter = new ApiParameter
                {
                    { "actionKey", "appkey" }
                } + ApiHelper.MustParameter(ApiHelper.AndroidKey, true)
            };
            api.parameter += ApiHelper.GetSign(api.parameter, ApiHelper.AndroidKey);
            return api;
        }
        /// <summary>
        /// 领取免费瓜子（宝箱）
        /// </summary>
        /// <returns></returns>
        public ApiModel GetFreeSilver()
        {
            //ApiHelper.MustParameter(ApiHelper.AndroidKey, true) + $"&actionKey=appkey"
            ApiModel api = new ApiModel()
            {
                method = RestSharp.Method.Get,
                baseUrl = $"https://api.live.bilibili.com/mobile/freeSilverAward",
                parameter = new ApiParameter
                {
                    { "actionKey", "appkey" }
                } + ApiHelper.MustParameter(ApiHelper.AndroidKey, true)
            };
            api.parameter += ApiHelper.GetSign(api.parameter, ApiHelper.AndroidKey);
            return api;
        }

        /// <summary>
        /// 赠送背包礼物
        /// </summary>
        /// <returns></returns>
        public ApiModel SendBagGift(long ruid, int gift_id, int num, int bag_id, int roomId)
        {
            //$"uid={SettingHelper.Account.UserID}&ruid={ruid}&send_ruid=0&gift_id={gift_id}&gift_num={num}&bag_id={bag_id}&biz_id={roomId}&rnd={new Random().Next(1000,999999).ToString("000000")}&biz_code=live&data_behavior_id=&data_source_id="
            ApiParameter body = new ApiParameter
            {
                { "uid", SettingHelper.Account.UserID.ToString() },
                { "ruid", ruid.ToString() },
                { "send_ruid", "0" },
                { "gift_id", gift_id.ToString() },
                { "gift_num", num.ToString() },
                { "bag_id", bag_id.ToString() },
                { "biz_id", roomId.ToString() },
                { "rnd", new Random().Next(1000,999999).ToString("000000") },
                { "biz_code", "live" },
                { "data_behavior_id", "" },
                { "data_source_id", "" }
            };

            //ApiHelper.MustParameter(ApiHelper.AndroidKey, true) + $"&actionKey=appkey",
            ApiModel api = new ApiModel()
            {
                method = RestSharp.Method.Post,
                baseUrl = $"https://api.live.bilibili.com/gift/v2/live/bag_send",
                parameter = new ApiParameter
                {
                    { "actionKey", "appkey" }
                } + ApiHelper.MustParameter(ApiHelper.AndroidKey, true),
                body = body.ToString()
            };
            api.parameter += ApiHelper.GetSign(api.parameter, ApiHelper.AndroidKey);
            return api;
        }

        /// <summary>
        /// 赠送礼物
        /// </summary>
        /// <returns></returns>
        public ApiModel SendGift(long ruid, int gift_id, int num, int roomId, string coin_type, int price)
        {
            //ApiHelper.MustParameter(ApiHelper.AndroidKey, true) + $"&actionKey=appkey&biz_code=live&biz_id={roomId}&coin_type={coin_type}&gift_id={gift_id}&gift_num={num}&mobi_app=android&platform=android&price={price}&rnd={Utils.GetTimestampMS()}&ruid={ruid}&uid={SettingHelper.Account.UserID}",
            ApiParameter body = new ApiParameter
            {
                { "actionKey", "appkey" },
                { "biz_code", "live" },
                { "biz_id", roomId.ToString() },
                { "coin_type", coin_type },
                { "gift_id", gift_id.ToString() },
                { "gift_num", num.ToString() },
                { "mobi_app", "android" },
                { "price", price.ToString() },
                { "rnd", Utils.GetTimestampMS().ToString() },
                { "ruid", ruid.ToString() },
                { "uid", SettingHelper.Account.UserID.ToString() }
            } + ApiHelper.MustParameter(ApiHelper.AndroidKey, true);

            ApiModel api = new ApiModel()
            {
                method = RestSharp.Method.Post,
                baseUrl = $"https://api.live.bilibili.com/gift/v2/live/send",
                body = body.ToString()
            };
            api.body += '&' + ApiHelper.GetSign(api.body, ApiHelper.AndroidKey).ToString();
            return api;
        }

        /// <summary>
        /// 发送弹幕
        /// </summary>
        /// <returns></returns>
        public ApiModel SendDanmu(string text, int roomId)
        {
            //$"cid={roomId}&mid={SettingHelper.Account.UserID}&msg={Uri.EscapeDataString(text)}&rnd={Utils.GetTimestampMS()}&mode=1&pool=0&type=json&color=16777215&fontsize=25&playTime=0.0"
            ApiParameter body = new ApiParameter
            {
                { "cid", roomId.ToString() },
                { "mid", SettingHelper.Account.UserID.ToString() },
                { "msg", Uri.EscapeDataString(text) },
                { "rnd", Utils.GetTimestampMS().ToString() },
                { "mode", "1" },
                { "pool", "0" },
                { "type", "json" },
                { "color", "16777215" },
                { "fontsize", "25" },
                { "playTime", "0.0" }
            };

            //ApiHelper.MustParameter(ApiHelper.AndroidKey, true) + $"&actionKey=appkey",
            ApiModel api = new ApiModel()
            {
                method = RestSharp.Method.Post,
                baseUrl = $"https://api.live.bilibili.com/api/sendmsg",
                parameter = new ApiParameter
                {
                    { "actionKey", "appkey" }
                } + ApiHelper.MustParameter(ApiHelper.AndroidKey, true),
                body = body.ToString()
            };
            api.parameter += ApiHelper.GetSign(api.body, ApiHelper.AndroidKey);
            return api;
        }

        /// <summary>
        /// 主播详细信息
        /// </summary>
        /// <returns></returns>
        public ApiModel AnchorProfile(long uid)
        {
            //ApiHelper.MustParameter(ApiHelper.AndroidKey, true) + $"&actionKey=appkey&uid={uid}",
            ApiModel api = new ApiModel()
            {
                method = RestSharp.Method.Get,
                baseUrl = $"https://api.live.bilibili.com/live_user/v1/card/card_up",
                parameter = new ApiParameter
                {
                    { "actionKey", "appkey" },
                    { "uid", uid.ToString() }
                } + ApiHelper.MustParameter(ApiHelper.AndroidKey, true)
            };
            api.parameter += ApiHelper.GetSign(api.parameter, ApiHelper.AndroidKey);
            return api;
        }


        /// <summary>
        /// 舰队列表
        /// </summary>
        /// <param name="ruid">主播ID</param>
        /// <param name="roomId">房间号</param>
        /// <param name="page">页码</param>
        /// <returns></returns>
        public ApiModel GuardList(long ruid, int roomId, int page)
        {
            //ApiHelper.MustParameter(ApiHelper.AndroidKey, true) + $"&actionKey=appkey&page={page}&page_size=20&roomid={roomId}&ruid={ruid}",
            ApiModel api = new ApiModel()
            {
                method = RestSharp.Method.Get,
                baseUrl = $"https://api.live.bilibili.com/xlive/app-room/v1/guardTab/topList",
                parameter = new ApiParameter
                {
                    { "actionKey", "appkey" },
                    { "page", page.ToString() },
                    { "page_size", "20" },
                    { "roomid", roomId.ToString() },
                    { "ruid", ruid.ToString() }
                } + ApiHelper.MustParameter(ApiHelper.AndroidKey, true)
            };
            api.parameter += ApiHelper.GetSign(api.parameter, ApiHelper.AndroidKey);
            return api;
        }

        /// <summary>
        /// 粉丝榜
        /// </summary>
        /// <param name="ruid">主播ID</param>
        /// <param name="roomId">房间号</param>
        /// <param name="page">页码</param>
        /// <returns></returns>
        public ApiModel FansList(long ruid, int roomId, int page)
        {
            //ApiHelper.MustParameter(ApiHelper.AndroidKey, true) + $"&actionKey=appkey&page={page}&roomid={roomId}&ruid={ruid}",
            ApiModel api = new ApiModel()
            {
                method = RestSharp.Method.Get,
                baseUrl = $"https://api.live.bilibili.com/rankdb/v2/RoomRank/mobileMedalRank",
                parameter = new ApiParameter
                {
                    { "actionKey", "appkey" },
                    { "page", page.ToString() },
                    { "roomid", roomId.ToString() },
                    { "ruid", ruid.ToString() }
                } + ApiHelper.MustParameter(ApiHelper.AndroidKey, true)
            };
            api.parameter += ApiHelper.GetSign(api.parameter, ApiHelper.AndroidKey);
            return api;
        }


        /// <summary>
        /// 房间榜单
        /// </summary>
        /// <param name="ruid">主播ID</param>
        /// <param name="roomId">房间号</param>
        /// <param name="rank_type"></param>
        /// <param name="next_offset">gold-rank=金瓜子排行，today-rank=今日礼物排行，seven-rank=7日礼物排行</param>
        /// <returns></returns>
        public ApiModel RoomRankList(long ruid, int roomId, string rank_type, int next_offset = 0)
        {
            //ApiHelper.MustParameter(ApiHelper.AndroidKey, true) + $"&actionKey=appkey&next_offset={next_offset}&room_id={roomId}&ruid={ruid}&rank_type={rank_type}",
            ApiModel api = new ApiModel()
            {
                method = RestSharp.Method.Get,
                baseUrl = $"https://api.live.bilibili.com/rankdb/v1/RoomRank/tabRanks",
                parameter = new ApiParameter
                {
                    { "actionKey", "appkey" },
                    { "next_offset", next_offset.ToString() },
                    { "room_id", roomId.ToString() },
                    { "ruid", ruid.ToString() },
                    { "rank_type", rank_type }
                } + ApiHelper.MustParameter(ApiHelper.AndroidKey, true)
            };
            api.parameter += ApiHelper.GetSign(api.parameter, ApiHelper.AndroidKey);
            return api;
        }

        /// <summary>
        /// 直播间抽奖信息
        /// </summary>
        /// <param name="roomId"></param>
        /// <returns></returns>
        public ApiModel RoomLotteryInfo(int roomId)
        {
            //ApiHelper.MustParameter(ApiHelper.AndroidKey, true) + $"&actionKey=appkey&roomid={roomId}",
            ApiModel api = new ApiModel()
            {
                method = RestSharp.Method.Get,
                baseUrl = $"https://api.live.bilibili.com/xlive/lottery-interface/v1/lottery/getLotteryInfo",
                parameter = new ApiParameter
                {
                    { "actionKey", "appkey" },
                    { "roomid", roomId.ToString() }
                } + ApiHelper.MustParameter(ApiHelper.AndroidKey, true)
            };
            api.parameter += ApiHelper.GetSign(api.parameter, ApiHelper.AndroidKey);
            return api;
        }

        /// <summary>
        /// 直播间抽奖信息
        /// </summary>
        /// <param name="roomId"></param>
        /// <returns></returns>
        public ApiModel RoomSuperChat(int roomId)
        {
            //ApiHelper.MustParameter(ApiHelper.AndroidKey, true) + $"&actionKey=appkey&room_id={roomId}",
            ApiModel api = new ApiModel()
            {
                method = RestSharp.Method.Get,
                baseUrl = $"https://api.live.bilibili.com/av/v1/SuperChat/getMessageList",
                parameter = new ApiParameter
                {
                    { "actionKey", "appkey" },
                    { "room_id", roomId.ToString() }
                } + ApiHelper.MustParameter(ApiHelper.AndroidKey, true)
            };
            api.parameter += ApiHelper.GetSign(api.parameter, ApiHelper.AndroidKey);
            return api;
        }
        /// <summary>
        /// 进入房间
        /// </summary>
        /// <param name="roomId"></param>
        /// <returns></returns>
        public ApiModel RoomEntryAction(int roomId)
        {
            //ApiHelper.MustParameter(ApiHelper.AndroidKey, true) + $"&actionKey=appkey&room_id={roomId}",
            ApiParameter body = new ApiParameter
            {
                { "actionKey", "appkey" },
                { "room_id", roomId.ToString() }
            } + ApiHelper.MustParameter(ApiHelper.AndroidKey, true);

            ApiModel api = new ApiModel()
            {
                method = RestSharp.Method.Post,
                baseUrl = $"https://api.live.bilibili.com/room/v1/Room/room_entry_action",
                body = body.ToString()
            };
            api.body += '&' + ApiHelper.GetSign(api.body, ApiHelper.AndroidKey).ToString();
            return api;
        }
    }
}
