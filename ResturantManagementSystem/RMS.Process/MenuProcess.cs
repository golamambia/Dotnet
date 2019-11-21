using RMS.Data;
using RMS.Entity;
using RMS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMS.Process
{
    public static class MenuProcess
    {
        public static List<MenuModel> GetAllMenu()
        {
            List<MenuModel> model = new List<MenuModel>();
            try
            {
                List<MenuEntity> response = MenuDal.GetMenu(new MenuEntity());
                foreach (MenuEntity node in response)
                {
                    model.Add(BindEntityToModel(node));
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return model;
        }
        public static MenuModel GetMenuById(int menuId)
        {
            MenuModel model = new MenuModel();
            try
            {
                MenuEntity response = MenuDal.GetMenu(new MenuEntity
                {
                    Id = menuId
                }).FirstOrDefault();
                model = BindEntityToModel(response);

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return model;
        }
        public static List<MenuModel> GetMenuByName(string menuName)
        {
            List<MenuModel> model = new List<MenuModel>();
            try
            {
                List<MenuEntity> response = MenuDal.GetMenu(new MenuEntity
                {
                    Name = menuName
                });
                foreach (MenuEntity node in response)
                {
                    model.Add(BindEntityToModel(node));
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return model;
        }
        public static List<MenuModel> GetMenuByCourseId(int courseId)
        {
            List<MenuModel> model = new List<MenuModel>();
            try
            {
                List<MenuEntity> response = MenuDal.GetMenu(new MenuEntity
                {
                    Course = new CourseEntity
                    {
                        Id = courseId
                    }
                });
                foreach (MenuEntity node in response)
                {
                    model.Add(BindEntityToModel(node));
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return model;
        }
        public static List<MenuModel> GetMenuByCuisineId(int cuisineId)
        {
            List<MenuModel> model = new List<MenuModel>();
            try
            {
                List<MenuEntity> responce = MenuDal.GetMenu(new MenuEntity
                {

                    Cuisine = new CuisineEntity
                    {
                        Id = cuisineId
                        }

                    });
                foreach (MenuEntity node in responce)
                {
                    model.Add(BindEntityToModel(node));
                }

            }
            catch(Exception ex)
            {
                throw ex;
            }
            return model;
        }

        public static MenuModel AddMenu(string menuName, string title, string longContent, string shortContent, string createdByUserName, string createdByUserId, int cuisineId, int courseId)
        {
            MenuModel menuModel = new MenuModel();
            try
            {
                List<MenuEntity> response = MenuDal.GetMenu(new MenuEntity { Name = menuName });

                if (response.Count == 0)
                {
                    MenuEntity menuEntity = new MenuEntity
                    {
                        Name = menuName,
                        
                        Course =new CourseEntity
                        {
                            Id=courseId,
                        },
                        Cuisine =new CuisineEntity
                        {
                            Id=cuisineId,
                        },
                        Description = new DescriptionEntity
                        {
                            Title = title,
                            LongContent = longContent,
                            ShortContent = shortContent,
                            CreatedByUserId = createdByUserId,
                            CreatedByUserName = createdByUserName
                        },
                        CreatedByUserName = createdByUserName,
                        CreatedByUserId = createdByUserId
                    };
                    menuEntity = MenuDal.CreateMenu(menuEntity);
                    if (menuEntity.Id > 0)
                    {
                        menuModel = BindEntityToModel(menuEntity);
                    }
                    else
                    {
                        menuModel.ExceptionKey = ExceptionKey.MenuNotCreatedExcepton;
                    }
                }
                else
                {
                    menuModel.ExceptionKey = ExceptionKey.MenuAlreadyExist;
                }
            }
            catch (Exception ex)
            {
                menuModel.ExceptionKey = ExceptionKey.CriticalCodeException;
                menuModel.DetailResponseMessage = CommonProcess.GetDetailException(ex);
            }
            return menuModel;
        }

        public static MenuModel UpdateMenu(int id, string menuName, string title, string longContent, string shortContent, string createdByUserName, string createdByUserId, bool courseIsActive, bool descriptionIsActive, int cuisineId, int courseId)
        {
            MenuModel menuModel = new MenuModel();
            try
            {
                //List<CuisineEntity> response = CuisineDal.GetCuisine(new CuisineEntity { Name = cuisineName });
                MenuEntity response = MenuDal.GetMenuById(new MenuEntity { Id = id });
                if (response != null && response.Id > 0)
                {
                    MenuEntity menuEntity = new MenuEntity
                    {
                        Id = id,
                        Name = menuName,
                        IsActive = courseIsActive,
                        Course = new CourseEntity
                        {
                            Id = courseId,
                        },
                        Cuisine = new CuisineEntity
                        {
                            Id = cuisineId,
                        },
                        Description = new DescriptionEntity
                        {
                            Id = response.Description.Id,
                            Title = title,
                            LongContent = longContent,
                            ShortContent = shortContent,
                            CreatedByUserId = createdByUserId,
                            CreatedByUserName = createdByUserName,
                            IsActive = descriptionIsActive
                        },
                        CreatedByUserName = createdByUserName,
                        CreatedByUserId = createdByUserId
                    };
                    menuEntity = MenuDal.UpdateMenu(menuEntity);
                    if (menuEntity.Id > 0)
                    {
                        menuModel = BindEntityToModel(menuEntity);
                    }
                    else
                    {
                        menuModel.ExceptionKey = ExceptionKey.CourseNotCreatedExcepton;
                    }
                }
                else
                {
                    menuModel.ExceptionKey = ExceptionKey.CourseDoesNotExist;
                }
            }
            catch (Exception ex)
            {
                menuModel.ExceptionKey = ExceptionKey.CriticalCodeException;
                menuModel.DetailResponseMessage = CommonProcess.GetDetailException(ex);
            }
            return menuModel;
        }

        private static MenuModel BindEntityToModel(MenuEntity node)
        {
            MenuModel menuModel = new MenuModel
            {
                Id = node.Id,
                Name = node.Name,
                CreatedAt = node.CreatedAt,
                CreatedByUserId = node.CreatedByUserId,
                UpdatedAt = node.UpdatedAt,
                UpdatedByUserId = node.UpdatedByUserId,
                Description = new DescriptionModel
                {
                    Id = node.Description.Id,
                    CreatedAt = node.Description.CreatedAt,
                    CreatedByUserId = node.Description.CreatedByUserId,
                    UpdatedAt = node.Description.UpdatedAt,
                    IsActive = node.Description.IsActive,
                    UpdatedByUserId = node.Description.UpdatedByUserId,
                    Title = node.Description.Title,
                    LongContent = node.Description.LongContent,
                    ShortContent = node.Description.ShortContent
                },
                Cuisine = new CuisineModel
                {
                    Id = node.Cuisine.Id,
                    Name = node.Cuisine.Name
                },
                Course = new CourseModel
                {
                    Id = node.Course.Id,
                    Name = node.Course.Name
                },
                IsActive = node.IsActive
            };
            return menuModel;
        }
    }
}
