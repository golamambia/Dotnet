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
    public static class CourseProcess
    {
        public static List<CourseModel> GetAllCourse()
        {
            List<CourseModel> model = new List<CourseModel>();
            try
            {
                List<CourseEntity> response = CourseDal.GetCourse(new CourseEntity());
                foreach (CourseEntity node in response)
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

        public static CourseModel GetCourseById()
        {
            throw new NotImplementedException();
        }

        public static List<CourseModel> GetCuisineId(int cuisineId)
        {
            List<CourseModel> model = new List<CourseModel>();
            try
            {
                List<CourseEntity> response = CourseDal.GetCourse(new CourseEntity
                {
                    Cuisine = new CuisineEntity
                    {
                        Id = cuisineId
                    }
                });
                foreach (CourseEntity node in response)
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
        public static List<CourseModel> GetByName(string courseName)
        {
            List<CourseModel> model = new List<CourseModel>();
            try
            {
                List<CourseEntity> response = CourseDal.GetCourse(new CourseEntity
                {
                    Name = courseName
                });
                foreach (CourseEntity node in response)
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
        public static CourseModel GetCourseById(int courseId)
        {
            CourseModel model = new CourseModel();
            try
            {
                CourseEntity response = CourseDal.GetCourseById(new CourseEntity
                {
                    Id = courseId
                });
                    model=BindEntityToModel(response);
                
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return model;
        }

        public static CourseModel AddCourse(string courseName, string title, string longContent, string shortContent, string createdByUserName, string createdByUserId,int cuisineId)
        {
            CourseModel courseModel = new CourseModel();
            try
            {
                List<CourseEntity> response = CourseDal.GetCourse(new CourseEntity { Name = courseName });

                if (response.Count == 0)
                {
                    CourseEntity courseEntity = new CourseEntity
                    {
                        Name = courseName,
                        Description = new DescriptionEntity
                        {
                            Title = title,
                            LongContent = longContent,
                            ShortContent = shortContent,
                            CreatedByUserId = createdByUserId,
                            CreatedByUserName = createdByUserName
                        },
                        Cuisine=new CuisineEntity
                        {
                            Id=cuisineId
                        },
                        CreatedByUserName = createdByUserName,
                        CreatedByUserId = createdByUserId
                    };
                    courseEntity = CourseDal.CreateCourse(courseEntity);
                    if (courseEntity.Id > 0)
                    {
                        courseModel = BindEntityToModel(courseEntity);
                    }
                    else
                    {
                        courseModel.ExceptionKey = ExceptionKey.CourseNotCreatedExcepton;
                    }
                }
                else
                {
                    courseModel.ExceptionKey = ExceptionKey.CourseAlreadyExist;
                }
            }
            catch (Exception ex)
            {
                courseModel.ExceptionKey = ExceptionKey.CriticalCodeException;
                courseModel.DetailResponseMessage = CommonProcess.GetDetailException(ex);
            }
            return courseModel;
        }

        public static CourseModel UpdateCourse(int id, string courseName, string title, string longContent, string shortContent, string createdByUserName, string createdByUserId, bool courseIsActive, bool descriptionIsActive, int cuisineId)
        {
            CourseModel courseModel = new CourseModel();
            try
            {
                //List<CuisineEntity> response = CuisineDal.GetCuisine(new CuisineEntity { Name = cuisineName });
                CourseEntity response = CourseDal.GetCourseById(new CourseEntity { Id = id });
                if (response != null && response.Id > 0)
                {
                    CourseEntity courseEntity = new CourseEntity
                    {
                        Id = id,
                        Name = courseName,
                        IsActive = courseIsActive,
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
                        CreatedByUserId = createdByUserId,
                        Cuisine=new CuisineEntity
                        {
                            Id=cuisineId
                        }
                    };
                    courseEntity = CourseDal.UpdateCourse(courseEntity);
                    if (courseEntity.Id > 0)
                    {
                        courseModel = BindEntityToModel(courseEntity);
                    }
                    else
                    {
                        courseModel.ExceptionKey = ExceptionKey.CuisineNotCreatedExcepton;
                    }
                }
                else
                {
                    courseModel.ExceptionKey = ExceptionKey.CuisineDoesNotExist;
                }
            }
            catch (Exception ex)
            {
                courseModel.ExceptionKey = ExceptionKey.CriticalCodeException;
                courseModel.DetailResponseMessage = CommonProcess.GetDetailException(ex);
            }
            return courseModel;
        }
        private static CourseModel BindEntityToModel(CourseEntity node)
        {
            CourseModel courseModel = new CourseModel
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
                IsActive = node.IsActive
            };
            return courseModel;
        }
    }
}
