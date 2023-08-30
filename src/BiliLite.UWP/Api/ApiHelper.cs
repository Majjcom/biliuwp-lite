using BiliLite.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ApiParameterPri = System.Collections.Generic.Dictionary<string, string>;

namespace BiliLite.Api
{
    public class ApiParameter : System.Collections.Generic.Dictionary<string, string>
    {
        public ApiParameter(): base()
        {
        }

        public ApiParameter(IDictionary<string, string> dic): base(dic)
        {
        }

        override public string ToString()
        {
            string ret = "";
            foreach (var item in this)
            {
                if (ret.Length != 0)
                {
                    ret += '&';
                }
                ret += item.Key;
                ret += '=';
                ret += item.Value;
            }
            return ret;
        }

        //public ApiParameter Concat(ApiParameter other)
        //{
        //    return this.Concat(other);
        //}

        public static ApiParameter operator +(ApiParameter first ,ApiParameter second)
        {
            return new ApiParameter(first.Concat(second).ToDictionary(pair => pair.Key, pair => pair.Value));
        }
    }

    public static class ApiHelper
    { 
        // BiliLite.WebApi 项目部署的服务器
        //public static string baseUrl = "http://localhost:5000";
        public const string IL_BASE_URL = "https://biliapi.iliili.cn";

        // GIT RAW路径
        public const string GIT_RAW_URL = "https://git.nsapps.cn/xiaoyaocz/BiliLite/raw/master/";

        // 哔哩哔哩API
        public const string API_BASE_URL = "https://api.bilibili.com";

        //漫游默认的服务器
        public const string ROMAING_PROXY_URL = "https://b.chuchai.vip";

        public static ApiKeyInfo AndroidKey = new ApiKeyInfo("1d8b6e7d45233436", "560c52ccd288fed045859ed18bffd973");
        public static ApiKeyInfo AndroidVideoKey = new ApiKeyInfo("iVGUTjsxvpLeuDCf", "aHRmhWMLkdeMuILqORnYZocwMBpMEOdt");
        public static ApiKeyInfo WebVideoKey = new ApiKeyInfo("84956560bc028eb7", "94aba54af9065f71de72f5508f1cd42e");
        public static ApiKeyInfo AndroidTVKey = new ApiKeyInfo("4409e2ce8ffd12b8", "59b43e04ad6965f34319062b478f83dd");
        public static ApiKeyInfo LoginKey = new ApiKeyInfo("783bbb7264451d82", "2653583c8873dea268ab9386918b1d65");
        private const string build = "6235200";
        private const string _mobi_app = "android";
        private const string _platform = "android";
        public static string deviceId = "";
        
        public static ApiParameter GetSign(string url, ApiKeyInfo apiKeyInfo)
        {
            string result;
            string str = url.Substring(url.IndexOf("?", 4) + 1);
            List<string> list = str.Split('&').ToList();
            list.Sort();
            StringBuilder stringBuilder = new StringBuilder();
            foreach (string str1 in list)
            {
                stringBuilder.Append((stringBuilder.Length > 0 ? "&" : string.Empty));
                stringBuilder.Append(str1);
            }
            stringBuilder.Append(apiKeyInfo.Secret);
            result = Utils.ToMD5(stringBuilder.ToString()).ToLower();
            return new ApiParameter
            {
                { "sign", result }
            };
        }

        public static ApiParameter GetSign(ApiParameter pars, ApiKeyInfo apiKeyInfo)
        {
            StringBuilder sb = new StringBuilder();
            foreach (var item in pars.OrderBy(x => x.Key))
            {
                sb.Append(item.Key);
                sb.Append("=");
                sb.Append(item.Value);
                sb.Append("&");
            }
            var results = sb.ToString().TrimEnd('&');
            results = results + apiKeyInfo.Secret;
            
            return new ApiParameter
            {
                { "sign", Utils.ToMD5(results).ToLower() }
            };
        }

        /// <summary>
        /// 一些必要的参数
        /// </summary>
        /// <param name="needAccesskey">是否需要accesskey</param>
        /// <returns></returns>
        public static ApiParameter MustParameter(ApiKeyInfo apikey, bool needAccesskey = false)
        {
            ApiParameter ret = new ApiParameter
            {
                { "appkey", apikey.Appkey },
                //{ "build", build },
                { "mobi_app", _mobi_app },
                { "platform", _platform },
                { "ts", Utils.GetTimestampS().ToString() },
            };
            
            if (needAccesskey && SettingHelper.Account.Logined)
            {
                ret.Add("access_key", SettingHelper.Account.AccessKey);
            }

            return ret;
        }
        /// <summary>
        /// 默认一些请求头
        /// </summary>
        /// <returns></returns>
        public static IDictionary<string, string> GetDefaultHeaders()
        {
            Dictionary<string, string> headers = new Dictionary<string, string>();
            headers.Add("user-agent", "Mozilla/5.0 BiliDroid/5.44.2 (bbcallen@gmail.com)");
            headers.Add("Referer", "https://www.bilibili.com/");
            return headers;
        }

    }
    
    

    public class ApiKeyInfo
    {
        public ApiKeyInfo(string key, string secret)
        {
            Appkey = key;
            Secret = secret;
        }
        public string Appkey { get; set; }
        public string Secret { get; set; }
    }
    
    public class ApiModel
    {
        /// <summary>
        /// 请求方法
        /// </summary>
        public RestSharp.Method method { get; set; }
        
        /// <summary>
        /// API地址
        /// </summary>
        public string baseUrl { get; set; }
        
        /// <summary>
        /// Url参数
        /// </summary>
        public ApiParameter parameter { get; set; } = new ApiParameter();
        
        /// <summary>
        /// 发送内容体，用于POST方法
        /// </summary>
        public string body { get; set; }
        
        /// <summary>
        /// 请求头
        /// </summary>
        public IDictionary<string, string> headers { get; set; }
        
        /// <summary>
        /// 需要Cookie
        /// </summary>
        public bool need_cookie { get; set; } = false;

        /// <summary>
        /// 需要Wbi签名
        /// </summary>
        public bool need_wbi { get; set; } = false;

        /// <summary>
        /// 请求地址
        /// </summary>
        public string url
        {
            get
            {
                return baseUrl + '?' + parameter.ToString();
            }
        }

        public async Task<string> Get_url()
        {
            
            return baseUrl + "?" + await caculate_parameter();
            
        }

        private async Task<string> caculate_parameter()
        {
            ApiParameter p = need_wbi ? await WbiHelper.EncodeWbi(parameter) : parameter;
            return p.ToString();
        }
    }
}
