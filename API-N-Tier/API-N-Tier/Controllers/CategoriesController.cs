using BLL.Services;
using DAL.EF.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace API_N_Tier.Controllers
{
    public class CategoriesController : ApiController
    {

        [HttpPost]
        [Route("api/category/")]
        public HttpResponseMessage CreateNewCategory(Category category)
        {
            if (ModelState.IsValid)
            {
                var responseFromBLL = CategoryService.CreateCategory(category);
                if (responseFromBLL == true)
                {
                    return Request.CreateResponse(HttpStatusCode.Created, new { Msg = "New Category Added!" });
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Msg = "Something went wrong!" });
                }
            }
            return Request.CreateResponse(HttpStatusCode.BadRequest, ModelState.ToString());
        }
        [HttpGet]
        [Route("api/category/all")]
        public HttpResponseMessage AllCategory()
        {
            var response = CategoryService.GetAllCategories();
            if (response.Count == 0)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, new { Msg = "No Category present at this moment" });
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.OK, response);
            }
        }

        [HttpGet]
        [Route("api/category/{id}")]
        public HttpResponseMessage GetCategory(int id)
        {
            var response = CategoryService.GetCategory(id);
            if (response != null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, response);
            }
            return Request.CreateResponse(HttpStatusCode.NotFound, new { Msg = "Category not found with this id" });
        }

        [HttpPost]
        [Route("api/category/edit/")]
        public HttpResponseMessage Edit(Category category)
        {
            var response = CategoryService.EditCategory(category);
            if (response)
                return Request.CreateResponse(HttpStatusCode.OK, new { Msg = "Category Updated" });
            return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Msg = "Category Not Updated!" });
        }

        [HttpPost]
        [Route("api/category/delete/{id}")]
        public HttpResponseMessage DeleteCategory(int id)
        {
            var response = CategoryService.DeleteCategory(id);
            if (response)
                return Request.CreateResponse(HttpStatusCode.OK, new { Msg = "Category Deleted" });
            return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Msg = "Category Not Deleted!" });
        }
    }
}
