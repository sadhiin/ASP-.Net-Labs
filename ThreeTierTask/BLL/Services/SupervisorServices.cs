using AutoMapper;
using BLL.DTOs;
using DLL;
using DLL.EF.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class SupervisorServices
    {

        public static bool CreateProject(int super_id, ProjectDTO obj)
        {
            var pjt = new Project();

            pjt.Title = obj.Title;
            pjt.Supervisor_ID = super_id;
            pjt.Status = 0;

            var rtn = DataAccessFactory.SupervisorDataAccess().CreateProject(pjt);
            return rtn;
        }

        public static bool ConfirmAproject( int pid)
        {
            var members = DataAccessFactory.SupervisorDataAccess().GetMembersInProject(pid);
            if (members == null || members.Count < 3)
            {
                return false;
            }

            var rtn = DataAccessFactory.SupervisorDataAccess().ConfirmProject(pid);

            return rtn;
        }

        public static List<ProjectDTO> GetAllProject()
        {
            var data = DataAccessFactory.SupervisorDataAccess().Projects();
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Project, ProjectDTO>();
            });
            var mapper = new Mapper(config);

            var rtn = mapper.Map<List<ProjectDTO>>(data);
            return rtn;
        }

        public static List<ProjectDTO> AllOnGoingProjects()
        {
            var data = DataAccessFactory.SupervisorDataAccess().OnGoingProjects();
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Project, ProjectDTO>();
            });
            var mapper = new Mapper(config);

            var rtn = mapper.Map<List<ProjectDTO>>(data);
            return rtn;
        }

        public static List<ProjectDTO> AllTheCompletedProjects()
        {
            var data = DataAccessFactory.SupervisorDataAccess().AllCompletedProjects();
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Project, ProjectDTO>();
            });
            var mapper = new Mapper(config);

            var rtn = mapper.Map<List<ProjectDTO>>(data);
            return rtn;
        }

        public static ProjectDTO ProjectById(int id)
        {
            var data = DataAccessFactory.SupervisorDataAccess().ProjectById(id);
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Project, ProjectDTO>();
            });
            var mapper = new Mapper(config);

            var rtn = mapper.Map<ProjectDTO>(data);
            return rtn;
        }
    }
}
