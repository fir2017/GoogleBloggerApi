using System;
using Google.Apis.Blogger.v3.Data;
using Google.Apis.Blogger.v3;
using Google.Apis.Services;
using Google.Apis.Auth.OAuth2;
using System.IO;
using System.Threading;
using Google.Apis.Util.Store;
using System.Collections.Generic;
using GoogleBloggerApi.Common;


namespace GoogleBloggerApi
{
    class Program
    {
        static void Main(string[] args)
        {
            BloggerHelp BloggerHelp = new BloggerHelp();

            string blogUrl = "blogUrl.com";

            BloggerService BloggerService = new BloggerService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = BloggerHelp.GetCredential(),
                ApplicationName = "Test",
            });

            //取得Blogger資料
            var BlogResource = BloggerService.Blogs.GetByUrl(blogUrl);

            //第一次會請求允許
            Blog blog = BlogResource.Execute();
            
            Console.WriteLine("Blog ID: " + blog.Id);
            Console.WriteLine("Insert");

            //新增資料
            Post PostData = new Post();
            PostData.Content = "<h1>Content</h1>";
            PostData.Labels = new List<string>() { "TestTag" };
            PostData.Title = DateTime.Now.ToString() + "Title";

            //執行新增
            PostsResource PostsResource = new PostsResource(BloggerService);
            PostsResource.Insert(PostData, blog.Id).Execute();

            Console.WriteLine("Done...");


        }
    }
}
