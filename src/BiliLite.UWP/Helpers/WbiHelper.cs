using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using System.Net.Http;
using System.Security.Cryptography;
using BiliLite.Api;


namespace BiliLite.Helpers
{

    public class WbiHelper
    {
        private static HttpClient _httpClient = new HttpClient();

        private static string imgUrl = "";

        private static string subUrl = "";

        private static readonly int[] MixinKeyEncTab =
        {
            46, 47, 18, 2, 53, 8, 23, 32, 15, 50, 10, 31, 58, 3, 45, 35, 27, 43, 5, 49, 33, 9, 42, 19, 29, 28, 14, 39,
            12, 38, 41, 13, 37, 48, 7, 16, 24, 55, 40, 61, 26, 17, 0, 1, 60, 51, 30, 4, 22, 25, 54, 21, 56, 59, 6, 63,
            57, 62, 11, 36, 20, 34, 44, 52
        };

        //对 imgKey 和 subKey 进行字符顺序打乱编码
        private static string GetMixinKey(string orig)
        {
            return MixinKeyEncTab.Aggregate("", (s, i) => s + orig[i]).Substring(0, 32);
        }

        public static async Task<(string, string)> LoadWbi()
        {
            //HttpResponseMessage responseMessage = await _httpClient.SendAsync(new HttpRequestMessage
            //{
            //    Method = HttpMethod.Get,
            //    RequestUri = new Uri("https://api.bilibili.com/x/web-interface/nav"),
            //});

            //responseMessage.Content.ReadAsStringAsync();

            var responseMessage = await HttpHelper.Get("https://api.bilibili.com/x/web-interface/nav");

            JObject response = JObject.Parse(responseMessage.results);

            imgUrl = response["data"]["wbi_img"]["img_url"].ToString();
            imgUrl = imgUrl.Split("/").Last().Split(".")[0];

            subUrl = response["data"]["wbi_img"]["sub_url"].ToString();
            subUrl = subUrl.Split("/").Last().Split(".")[0];

            return (imgUrl, subUrl);
        }

        private async static Task<(string, string)> GetWbiKeys()
        {
            if (imgUrl.Length == 0)
            {
                await LoadWbi();
            }
            return (imgUrl, subUrl);
        }

        public async static Task<ApiParameter> EncodeWbi(ApiParameter parameters)
        {
            var (imgKey, subKey) = await GetWbiKeys();

            string mixinKey = GetMixinKey(imgKey + subKey);
            string currTime = DateTimeOffset.Now.ToUnixTimeSeconds().ToString();
            //添加 wts 字段
            parameters["wts"] = currTime;
            // 按照 key 重排参数
            var parameters_d = parameters.OrderBy(p => p.Key).ToDictionary(p => p.Key, p => p.Value);
            //过滤 value 中的 "!'()*" 字符
            parameters_d = parameters.ToDictionary(
                kvp => kvp.Key,
                kvp => new string(kvp.Value.Where(chr => !"!'()*".Contains(chr)).ToArray())
            );
            // 序列化参数
            string query = new FormUrlEncodedContent(parameters).ReadAsStringAsync().Result;
            //计算 w_rid
            MD5 md5 = MD5.Create();
            byte[] hashBytes = md5.ComputeHash(Encoding.UTF8.GetBytes(query + mixinKey));
            string wbiSign = BitConverter.ToString(hashBytes).Replace("-", "").ToLower();
            parameters["w_rid"] = wbiSign;

            return new ApiParameter(parameters);
        }
    }
}
