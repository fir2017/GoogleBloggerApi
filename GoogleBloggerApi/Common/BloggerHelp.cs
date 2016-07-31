using Google.Apis.Auth.OAuth2;
using Google.Apis.Util.Store;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GoogleBloggerApi.Common
{
    public class BloggerHelp
    {
        /// <summary>
        /// 憑證檔案路徑
        /// </summary>
        private string KeyFilePath = "C:\\auth2.json";

        /// <summary>
        /// 取得使用者資訊
        /// </summary>
        /// <returns></returns>
        public UserCredential GetCredential()
        {
            UserCredential credential;

            using (var stream = new FileStream(KeyFilePath, FileMode.Open, FileAccess.Read))
            {
                credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
                    GoogleClientSecrets.Load(stream).Secrets,
                    new[] { "https://www.googleapis.com/auth/blogger" },
                    "Kentilink",
                    CancellationToken.None,
                    new FileDataStore("Auth.Blogger")).Result;
            }

            return credential;
        }
    }
}
