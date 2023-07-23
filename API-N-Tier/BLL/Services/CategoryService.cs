using AutoMapper;
using BLL.DTOs;
using DAL.EF.Model;
using DAL.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class CategoryService
    {
        // create one service
        public static bool CreateCategory(Category category)
        {
            return CategoryRepo.Create(category);
        }

        // Get all service
        public static List<CategoryDTO> GetAllCategories()
        {
            var data = CategoryRepo.GetAll();
            var config = new MapperConfiguration(cfg =>{
                cfg.CreateMap<CategoryRepo, CategoryDTO>();
                });

            var mapper = new Mapper(config);
            var converted = mapper.Map<List<CategoryDTO>>(data);
            return converted;
        }

        // get one service
        public static CategoryDTO GetCategory(int id)
        {
            var data = CategoryRepo.Get(id);
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<CategoryRepo, CategoryDTO>();
            });
            var mapper = new Mapper(config);
            var converted = mapper.Map<CategoryDTO>(data);
            return converted;
        }

        public static bool EditCategory(Category C)
        {
            return CategoryRepo.Edit(C);
        }
        public static bool DeleteCategory(int id)
        {
            return CategoryRepo.Delete(id);
        }
    }
}
