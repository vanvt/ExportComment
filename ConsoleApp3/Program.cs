using ConsoleApp3.Model;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    class Program
    {
        static readonly HttpClient client = new HttpClient();
        static void Main(string[] args)
        {
           var xx =  GetComments(1, 2).Where(e=>e.Comment.Id!=null);
        }
        private static List<Bug> GetComments(int startPr,int endPr)
        {
            List<Bug> bugs = new List<Bug>();
            List<Comment> childbug = new List<Comment>();
            //loop pr
            for (int i = startPr; i <= endPr; i++)
            {
                //loop comments
                for (int y = 1; y < 100; y++)
                {
                    try
					
					111
                    {
                        var client = new RestClient($"http://127.0.0.1:7990/rest/api/1.0/projects/STUD/repos/master/pull-requests/{i}/comments/{y}");
                        var request = new RestRequest(Method.GET);
                        request.AddHeader("authorization", "Basic dmFudnRzZTpBYmMxMjM0NTY=");
                        IRestResponse response = client.Execute(request);
                        var xxx = response.Content;
                        var result = JsonConvert.DeserializeObject<Comment>(xxx);
                        bugs.Add(new Bug {Assigineer = GetAuthor(i),Reporter = result.Author,Comment = result});


                        foreach (var item in result.comments)
                        {
                            childbug.Add(item);
                        }
                       
                        if (childbug.Select(e => e.Id).Contains(result.Id))
                        {
                            bugs.Remove(bugs.Find(r => r.Comment.Id == result.Id));
                        }
                    }
                    catch (Exception)
                    {
                        break;
                    }
                }
            }
            return bugs;

        }
        private static Author GetAuthor(int idPr)
        {
            var client = new RestClient($"http://127.0.0.1:7990/rest/api/1.0/projects/STUD/repos/master/pull-requests/{idPr}");
            var request = new RestRequest(Method.GET);
            request.AddHeader("authorization", "Basic dmFudnRzZTpBYmMxMjM0NTY=");
            IRestResponse response = client.Execute(request);
            var xxx = response.Content;
            var result = JsonConvert.DeserializeObject<PullRequest>(xxx);
            return result.Author.User;
        }
    }
}
