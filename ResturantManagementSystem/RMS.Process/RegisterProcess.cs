using RMS.Data;
using RMS.Model;
using System.Collections.Generic;
using System;
using RMS.Entity;


namespace RMS.Process
{


    
    public class RegisterProcess
    {
        public static List<RegistrationModel> GetAll()
        {
            List<RegistrationModel> registerModel = new List<RegistrationModel>();
            try
            {
                List<RegisterEntity> responce = RegisterDal.GetRegister(new RegisterEntity());
                foreach (RegisterEntity node in responce)
                {
                    registerModel.Add(BindEntityToModel(node));

                }

            }
            catch(Exception ex)
            {
                throw ex;
            }
            return registerModel;
        } 
        public static RegistrationModel GetRegById(int id)
        {
            RegistrationModel registerModel = new RegistrationModel();
            try
            {
                RegisterEntity registerEntity = RegisterDal.GetRegById(new RegisterEntity {Id=id });
                if (registerEntity!=null)
                {
                    registerModel = BindEntityToModel(registerEntity);
                }

            }
            catch(Exception ex)
            {
                throw ex;
            }
            return registerModel;
        }

        public static RegistrationModel GetRegByEmail(string email)
        {
            RegistrationModel registerModel = new RegistrationModel();
            try
            {
                RegisterEntity registerEntity = RegisterDal.GetRegByEmail(new RegisterEntity { Email = email });
                if (registerEntity != null)
                {
                    registerModel = BindEntityToModel(registerEntity);
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return registerModel;
        }

        public static RegistrationModel AddRegistration(string name, string email, string createdByUserName, string createdByUserId, bool registerIsActive)
        {
            RegistrationModel registerModel = new RegistrationModel();
            try
            {
                
                    RegisterEntity registerEntity = new RegisterEntity
                    {
                        Name = name,
                        Email= email,
                        IsActive=registerIsActive,
                        CreatedByUserName = createdByUserName,
                        CreatedByUserId = createdByUserId
                    };
                    registerEntity = RegisterDal.CreateRegiter(registerEntity);
                    if (registerEntity.Id > 0)
                    {
                        registerModel = BindEntityToModel(registerEntity);
                    registerModel.ExceptionKey = ExceptionKey.Success;
                    }
                    else
                    {
                        registerModel.ExceptionKey = ExceptionKey.CuisineNotCreatedExcepton;
                    }

                
            }
            catch (Exception ex)
            {
                registerModel.ExceptionKey = ExceptionKey.CriticalCodeException;
                registerModel.DetailResponseMessage = CommonProcess.GetDetailException(ex);
            }
            return registerModel;
        }


        public static RegistrationModel UpdateRegistration(int Id,string name, string email, string createdByUserName, string createdByUserId, bool registerIsActive)
        {
            RegistrationModel registrationModel = new RegistrationModel();
            try
            {
                RegisterEntity registerEntity = new RegisterEntity{
                    Id=Id,
                    Name=name,
                    Email=email,
                    IsActive=registerIsActive,
                    CreatedByUserName = createdByUserName,
                    CreatedByUserId = createdByUserId

                };
                registerEntity = RegisterDal.UpdateRegister(registerEntity);
                
                if (registerEntity.Id > 0)
                {
                    registrationModel = BindEntityToModel(registerEntity);
                    registrationModel.ExceptionKey = ExceptionKey.Success;
                }
                else
                {
                    registrationModel.ExceptionKey = ExceptionKey.Failure;
                }

            }
            catch(Exception ex)
            {
                registrationModel.ExceptionKey = ExceptionKey.Failure;
                registrationModel.DetailResponseMessage = CommonProcess.GetDetailException(ex);
            }
            return registrationModel;
        }




        private static RegistrationModel BindEntityToModel(RegisterEntity response)
        {
            RegistrationModel register = new RegistrationModel
            {
                CreatedAt = response.CreatedAt,
                CreatedByUserId = response.CreatedByUserId,
                Id = response.Id,
                UpdatedAt = response.UpdatedAt,
                UpdatedByUserId = response.UpdatedByUserId,
                Name = response.Name,
                Email=response.Email,
                IsActive = response.IsActive,
                
            };
            return register;
        }


    }
}
