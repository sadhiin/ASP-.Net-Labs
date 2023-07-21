using System;
using System.Collections.Generic;
using System.Linq;
using API_Assignemnt.Models;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.Entity;
using System.Runtime.Remoting.Messaging;

namespace API_Assignemnt.Controllers
{
    public class NewsController : ApiController
    {
        private AssignmentContext _context;
        public NewsController()
        {
            _context = new AssignmentContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // Create a news
        [HttpPost]
        [Route("api/news/create")]
        public HttpResponseMessage Create(News news)
        {
            if (news.Title != null && news.Content != null && news.CategoryId != 0)
            {
                String Msg = "";
                try
                {
                    news.Date = DateTime.Today;
                    _context.Newses.Add(news);
                    int check = _context.SaveChanges();
                    if (check == 0)
                    {
                        Msg = "Something Went Wrong! New not created";
                        return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, Msg);
                    }
                    else
                    {
                        Msg = "News created!";
                        return Request.CreateResponse(HttpStatusCode.OK, Msg);
                    }
                }
                catch (Exception ex)
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message.ToString());
                }
            }
            return Request.CreateResponse(HttpStatusCode.BadRequest, ModelState.ToString());
        }

        // Get all news
        [HttpGet]
        [Route("api/news/all")]
        public HttpResponseMessage GetAllNews()
        {
            var newses = _context.Newses.Select(n => new { n.Id, n.Title, n.Content, n.Date, n.Category.Name }).ToList();
            //var newses = _context.Newses.Select(n => new { n.Id, n.Title, n.Content, Category = n.Category.Name })
            //.ToList();

            if (newses.Count == 0)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, new { Msg = "No news present at this moment" });
            }
            return Request.CreateResponse(HttpStatusCode.OK, newses);
        }

        // Get news by id
        [HttpGet]
        [Route("api/news/{id}")]
        public HttpResponseMessage GetNewsById(int id)
        {
            if (id == 0)
            {
                return Request.CreateResponse(HttpStatusCode.BadGateway, new { Msg = "Null id value not acceptable" });
            }

            var news = _context.Newses.Select(n => new { n.Id, n.Title, n.Content, n.Date, n.Category.Name }).SingleOrDefault(n => n.Id == id);
            if (news == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, new { Msg = "Invalid id" });
            }
            return Request.CreateResponse(HttpStatusCode.OK, news);
        }

        //Edit message
        [HttpPost]
        [Route("api/news/edit")]
        public HttpResponseMessage Edit(News news)
        {
            if (news.Id > 0 && news.Title != null && news.Content != null)
            {
                var newsInDb = _context.Newses.Find(news.Id);
                if (newsInDb == null)
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, new { Msg = "No news found" });
                }
                newsInDb.Title = news.Title;
                newsInDb.Content = news.Content;
                //newsInDb.Date = news.Date;
                newsInDb.CategoryId = news.CategoryId;
                int check = _context.SaveChanges();
                if (check == 0)
                {
                    return Request.CreateResponse(HttpStatusCode.InternalServerError,
                        new { Msg = "News not updated due to internal server error!" });
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.OK,
                        new { Msg = "News updated!" });
                }
            }
            return Request.CreateErrorResponse(HttpStatusCode.BadGateway, ModelState.ToString());
        }

        // Delete news
        [HttpPost]
        [Route("api/news/delete/{id}")]
        public HttpResponseMessage Delete(int id)
        {
            if (id > 0)
            {
                try
                {
                    var newInDb = _context.Newses.Find(id);
                    if (newInDb == null)
                    {
                        return Request.CreateResponse(HttpStatusCode.NotFound,
                            new { Msg = "Now news present with this ID value!" });
                    }
                    _context.Entry(newInDb).State = EntityState.Deleted;
                    int check = _context.SaveChanges();

                    if (check == 0)
                    {
                        return Request.CreateResponse(HttpStatusCode.InternalServerError,
                        new { Msg = "Something Went Wrong!" });
                    }
                    else
                    {
                        return Request.CreateResponse(HttpStatusCode.OK,
                            new { Msg = "News deleted!" });
                    }
                }
                catch (Exception ex)
                {
                    return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message.ToString());
                }
            }

            return Request.CreateResponse(HttpStatusCode.BadRequest,
                        new { Msg = "Invalid id value is not acceptable!" });
        }

        // Get news by date
        [HttpGet]
        [Route("api/news/by/date/{date}")]
        public HttpResponseMessage GetNewsByDate(DateTime date)
        {
            var newsByDate = _context.Newses.Select(n => new { n.Id, n.Title, n.Content, n.Date, n.Category.Name })
                                .Where(n => n.Date.Year == date.Year && 
                                n.Date.Month == date.Month && n.Date.Day == date.Day)
                                .ToList();
            if (newsByDate.Count == 0 || newsByDate == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, new { Msg = "Now news found with this date!" });
            }
            return Request.CreateResponse(HttpStatusCode.OK, newsByDate);
        }


        [HttpGet]
        [Route("api/news/by/category/{categoryName}")]
        public HttpResponseMessage GetNesByCategory(string categoryName)
        {
            var news = _context.Newses
                .Where(n => n.Category.Name.Contains(categoryName))
                .Select(n => new { n.Id, n.Title, n.Content, n.Date, n.Category.Name }).ToList();
            if (news.Count == 0 || news == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, new { Msg = "No news present with this category!" });
            }
            return Request.CreateResponse(HttpStatusCode.OK, news);
        }

        [HttpGet]
        [Route("api/news/by/{date}/{categoryName}")]
        public HttpResponseMessage GetNewsByDateAndCategory(DateTime date, string categoryName)
        {
            var news = _context.Newses
                            .Where(n => n.Date.Year == date.Year && n.Date.Month == date.Month && n.Date.Day == date.Day && n.Category.Name.Contains(categoryName))
                            .Select(n => new { n.Id, n.Title, n.Content, n.Date, CategoryName = n.Category.Name })
                            .ToList();

            if (news.Count == 0 || news == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, new { Msg = "No news present with this date or category!" });
            }
            return Request.CreateResponse(HttpStatusCode.OK, news);
        }
    }
}