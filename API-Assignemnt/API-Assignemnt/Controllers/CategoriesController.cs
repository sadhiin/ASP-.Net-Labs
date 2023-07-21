using System;
using System.Collections.Generic;
using System.Linq;
using API_Assignemnt.Models;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace API_Assignemnt.Controllers
{
    public class CategoriesController : ApiController
    {
        private AssignmentContext _context;
        // GET: Categories

        public CategoriesController()
        {
            _context = new AssignmentContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // Get all categories
        [HttpGet]
        [Route("api/category/all")]
        public HttpResponseMessage GetAllCategories()
        {
            var categories = _context.Categories.Select(c => new { c.Id, c.Name }).ToList();
            if (categories.Count == 0)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, new { Msg = "No Category Present at this moment"});
            }
            return Request.CreateResponse(HttpStatusCode.OK, categories);
        }

        // Get category by id
        [HttpGet]
        [Route("api/category/{id}")]
        public HttpResponseMessage GetCategoryById(int id)
        {
            var category = _context.Categories.Find(id);
            if (category == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
            return Request.CreateResponse(HttpStatusCode.OK, category);
        }

        // Create a new category
        [HttpPost]
        [Route("api/category/create")]
        public HttpResponseMessage CreateCategory(Category category)
        {
            if (ModelState.IsValid)
            {
                string Msg = "";
                try
                {
                    _context.Categories.Add(category);
                    int check = _context.SaveChanges();
                    if (check == 0)
                    {
                        Msg = "Not Created";
                        return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, Msg);
                    }
                    else
                    {
                        Msg = "New Category Created";
                        return Request.CreateResponse(HttpStatusCode.OK, Msg);
                    }
                }
                catch (Exception ex)
                {
                    return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
                }
            }
            return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
        }

        // Edit a category

        [HttpPost]
        [Route("api/category/edit")]
        public HttpResponseMessage Edit(Category cat)
        {
            if (ModelState.IsValid)
            {
                string Msg = "";
                try
                {
                    var categoryIdDb = _context.Categories.Find(cat.Id);

                    if (categoryIdDb == null) { return Request.CreateResponse(HttpStatusCode.NotFound); }
                    else
                    {
                        categoryIdDb.Name = cat.Name;
                        _context.Entry(categoryIdDb);
                        int check = _context.SaveChanges();
                        if(check == 0) {
                            Msg = "Something Went Wrong";
                            return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, Msg); }
                        else
                        {
                            Msg = "Category Updated";
                            return Request.CreateErrorResponse(HttpStatusCode.OK, Msg);
                        }
                    }
                }
                catch (Exception ex)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
                }
            }
            return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
        }

        // Delete a category

        [HttpPost]
        [Route("api/category/delete/{id}")]
        public HttpResponseMessage Delete(int id)
        {
            string Msg = "";
            try
            {
                var categoryInDb = _context.Categories.Find(id);
                if (categoryInDb == null) {
                    Msg = "Category not found. Invalid category Id.";
                    return Request.CreateResponse(HttpStatusCode.NotFound, Msg);
                }
                else
                {
                    _context.Categories.Remove(categoryInDb);
                    int check = _context.SaveChanges();
                    if(check== 0)
                    {
                        Msg = "Something went wrong";
                        return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, Msg);
                    }
                    else
                    {
                        Msg = "Category Deleted";
                        return Request.CreateResponse(HttpStatusCode.OK, Msg);
                    }
                }
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}
