﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiliLite.Api.Home
{
    public class RecommendAPI
    {
        public ApiModel Recommend(string idx = "0")
        {
            //ApiHelper.MustParameter(ApiHelper.AndroidKey, true) + $"&flush=0&idx={idx}&login_event=2&network=wifi&open_event=&pull={(idx == "0").ToString().ToLower()}&qn=32&style=2"

            ApiModel api = new ApiModel()
            {
                method = RestSharp.Method.Get,
                baseUrl = $"https://app.bilibili.com/x/v2/feed/index",
                parameter = new ApiParameter
                {
                    { "flush", "0" },
                    { "idx", idx },
                    { "login_event", "2" },
                    { "network", "wifi" },
                    { "open_event", "" },
                    { "pull", (idx == "0").ToString().ToLower() },
                    { "qn", "32" },
                    { "style", "2" }
                } + ApiHelper.MustParameter(ApiHelper.AndroidKey, true)
            };
            api.parameter += ApiHelper.GetSign(api.parameter, ApiHelper.AndroidKey);
            return api;
        }

        public ApiModel Dislike(string _goto, string id, string mid, int reason_id, int rid, int tag_id)
        {
            //ApiHelper.MustParameter(ApiHelper.AndroidKey, true) + $"&goto={_goto}&id={id}&mid={mid}&reason_id={reason_id}&rid={rid}&tag_id={tag_id}"
            ApiModel api = new ApiModel()
            {
                method = RestSharp.Method.Get,
                baseUrl = $"https://app.biliapi.net/x/feed/dislike",
                parameter = new ApiParameter
                {
                    { "goto", _goto },
                    { "id", id },
                    { "mid", mid },
                    { "reason_id", reason_id.ToString() },
                    { "rid", rid.ToString() },
                    { "tag_id", tag_id.ToString() }
                } + ApiHelper.MustParameter(ApiHelper.AndroidKey, true)
            };
            api.parameter += ApiHelper.GetSign(api.parameter, ApiHelper.AndroidKey);
            return api;
        }
        public ApiModel Feedback(string _goto, string id, string mid, int feedback_id, int rid, int tag_id)
        {
            //ApiHelper.MustParameter(ApiHelper.AndroidKey, true) + $"&goto={_goto}&id={id}&mid={mid}&feedback_id={feedback_id}&rid={rid}&tag_id={tag_id}"
            ApiModel api = new ApiModel()
            {
                method = RestSharp.Method.Get,
                baseUrl = $"https://app.biliapi.net/x/feed/dislike",
                parameter = new ApiParameter
                {
                    { "goto", _goto },
                    { "id", id },
                    { "mid", mid },
                    { "feedback_id", feedback_id.ToString() },
                    { "rid", rid.ToString() },
                    { "tag_id", tag_id.ToString() }
                } + ApiHelper.MustParameter(ApiHelper.AndroidKey, true)
            };
            api.parameter += ApiHelper.GetSign(api.parameter, ApiHelper.AndroidKey);
            return api;
        }

    }
}
