using RMS.Data;
using RMS.Model;
using System.Collections.Generic;
using System;
using RMS.Entity;

namespace RMS.Process
{
    public class CuisineProcess
    {
        public static List<CuisineModel> GetAllCuisine()
        {
            List<CuisineModel> model = new List<CuisineModel>();
            try
            {
                List<CuisineEntity> response = CuisineDal.GetCuisine(new CuisineEntity());
                foreach(CuisineEntity node in response)
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
        public static CuisineModel GetCuisineById(int id)
        {
            CuisineModel model = new CuisineModel();
            try
            {
                CuisineEntity response = CuisineDal.GetCuisineById(new CuisineEntity { Id = id });
                if(response!=null)
                {
                    model = BindEntityToModel(response);
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
            return model;
        }

        

        public static List<CuisineModel> GetCuisineByName(string name)
        {
            List<CuisineModel> model = new List<CuisineModel>();
            try
            {
                
                List<CuisineEntity> response = CuisineDal.GetCuisine(new CuisineEntity {Name=name });
                foreach (CuisineEntity node in response)
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
        public static CuisineModel AddCuisine(string cuisineName,string title, string longContent,string shortContent,string createdByUserName,string createdByUserId)
        {
            CuisineModel cuisineModel = new CuisineModel();
            try
            {
                List<CuisineEntity> response = CuisineDal.GetCuisine(new CuisineEntity { Name = cuisineName });

                if(response.Count==0)
                {
                    CuisineEntity cuisineEntity = new CuisineEntity
                    {
                        Name = cuisineName,
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
                    cuisineEntity = CuisineDal.CreateCuisine(cuisineEntity);
                    if(cuisineEntity.Id>0)
                    {
                        cuisineModel = BindEntityToModel(cuisineEntity);
                    }
                    else
                    {
                        cuisineModel.ExceptionKey = ExceptionKey.CuisineNotCreatedExcepton;
                    }
                }
                else
                {
                    cuisineModel.ExceptionKey = ExceptionKey.CuisineAlreadyExist;
                }                
            }
            catch(Exception ex)
            {
                cuisineModel.ExceptionKey = ExceptionKey.CriticalCodeException;
                cuisineModel.DetailResponseMessage = CommonProcess.GetDetailException(ex);
            }
            return cuisineModel;
        }


        public static CuisineModel UpdateCuisine(int id,string cuisineName, string title, string longContent, string shortContent, string createdByUserName, string createdByUserId,bool cuisineIsActive,bool descriptionIsActive)
        {
            CuisineModel cuisineModel = new CuisineModel();
            try
            {
                //List<CuisineEntity> response = CuisineDal.GetCuisine(new CuisineEntity { Name = cuisineName });
                CuisineEntity response = CuisineDal.GetCuisineById(new CuisineEntity { Id = id });
                if (response!=null&&response.Id>0 )
                {
                    CuisineEntity cuisineEntity = new CuisineEntity
                    {
                        Id = id,
                        Name = cuisineName,
                        IsActive=cuisineIsActive,
                        Description = new DescriptionEntity
                        {
                            Id=response.Description.Id,
                            Title = title,
                            LongContent = longContent,
                            ShortContent = shortContent,
                            CreatedByUserId = createdByUserId,
                            CreatedByUserName = createdByUserName,
                            IsActive=descriptionIsActive
                        },
                        CreatedByUserName = createdByUserName,
                        CreatedByUserId = createdByUserId
                    };
                    cuisineEntity = CuisineDal.UpdateCuisine(cuisineEntity);
                    if (cuisineEntity.Id > 0)
                    {
                        cuisineModel = BindEntityToModel(cuisineEntity);
                    }
                    else
                    {
                        cuisineModel.ExceptionKey = ExceptionKey.CuisineNotCreatedExcepton;
                    }
                }
                else
                {
                    cuisineModel.ExceptionKey = ExceptionKey.CuisineDoesNotExist;
                }
            }
            catch (Exception ex)
            {
                cuisineModel.ExceptionKey = ExceptionKey.CriticalCodeException;
                cuisineModel.DetailResponseMessage = CommonProcess.GetDetailException(ex);
            }
            return cuisineModel;
        }
        private static CuisineModel BindEntityToModel(CuisineEntity response)
        {
            CuisineModel cuisine = new CuisineModel
            {
                CreatedAt = response.CreatedAt,
                CreatedByUserId = response.CreatedByUserId,
                Id = response.Id,
                UpdatedAt = response.UpdatedAt,
                UpdatedByUserId = response.UpdatedByUserId,
                Name = response.Name,
                IsActive = response.IsActive,
                Description = new DescriptionModel
                {
                    Id = response.Description.Id,
                    CreatedAt = response.Description.CreatedAt,
                    CreatedByUserId = response.Description.CreatedByUserId,
                    UpdatedAt = response.Description.UpdatedAt,
                    IsActive = response.Description.IsActive,
                    UpdatedByUserId = response.Description.UpdatedByUserId,
                    Title = response.Description.Title,
                    LongContent = response.Description.LongContent,
                    ShortContent = response.Description.ShortContent,
                }
            };
            return cuisine;
        }

    }
}
