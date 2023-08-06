using BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ThreeTierTask.Controllers
{
    public class SupervisorController : ApiController
    {
        [HttpGet]
        [Route("api/projects")]
        public HttpResponseMessage Projects()
        {
            try
            {
            var data = SupervisorServices.GetAllProject();
            return Request.CreateResponse(HttpStatusCode.OK, data);

            }catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message.ToString());
            }
        }

        [HttpGet]
        [Route("api/project/{id}")]
        public HttpResponseMessage Project(int id)
        {
            if (id > 0)
            {
                try
                {
                    var data = SupervisorServices.ProjectById(id);
                    if( data != null)
                    {
                        return Request.CreateResponse(HttpStatusCode.OK, data);
                    }
                    else
                    {
                        return Request.CreateResponse(HttpStatusCode.InternalServerError, new {Msg="Not getting the data!"});
                    }
                }
                catch (Exception ex)
                {
                    return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message.ToString());
                }
            }
            return Request.CreateResponse(HttpStatusCode.BadRequest);
        }


        [HttpGet]
        [Route("api/ongoing")]
        public HttpResponseMessage OnGoingProjects()
        {
            try
            {
                var data = SupervisorServices.AllOnGoingProjects();
                return Request.CreateResponse(HttpStatusCode.OK, data);

            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message.ToString());
            }
        }

        [HttpGet]
        [Route("api/completed")]
        public HttpResponseMessage CompletedProjects()
        {
            try
            {
                var data = SupervisorServices.AllTheCompletedProjects();
                return Request.CreateResponse(HttpStatusCode.OK, data);

            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message.ToString());
            }
        }

        [HttpPost]
        [Route("api/confirm/{id}")]
        public HttpResponseMessage ProjectConfirm(int id)
        {
            if (id > 0)
            {
                try
                {
                    var data = SupervisorServices.ConfirmAproject(id);
                    if(data == true)
                    {
                        return Request.CreateResponse(HttpStatusCode.OK, new {Msg="Project confirmed"});
                    }
                    else
                    {
                        return Request.CreateResponse(HttpStatusCode.InternalServerError, new {Msg= "Project not confirmed. Somthing went wrong!"});
                    }
                }
                catch (Exception ex)
                {
                    return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message.ToString());
                }
            }
            return Request.CreateResponse(HttpStatusCode.BadRequest);
        }
    }
}
