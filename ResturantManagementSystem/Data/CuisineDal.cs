using RMS.Data.Common;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System;
using RMS.Entity;

namespace RMS.Data
{
    public static class CuisineDal
    {
        public static List<CuisineEntity> GetCuisine(CuisineEntity cuisine)
        {
            List<CuisineEntity> cuisines = new List<CuisineEntity>();
            try
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.CommandText = "dbo.CuisineMasterSel";
                    command.CommandType = CommandType.StoredProcedure;
                    SqlParameter param1 = new SqlParameter("@CuisineName", cuisine.Name);
                    command.Parameters.Add(param1);
                    using (DataTable dt = DataAccess.GetData(command))
                    {
                        foreach (DataRow dr in dt.Rows)
                        {
                            cuisines.Add(GetRow(dr));
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
                return cuisines;
        }
        public static CuisineEntity GetCuisineById(CuisineEntity cuisine)
        {
            CuisineEntity cuisines = new CuisineEntity();
            try
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.CommandText = "CuisineMasterSel";
                    command.CommandType = CommandType.StoredProcedure;
                    SqlParameter param1 = new SqlParameter("@CuisineId", cuisine.Id);
                    command.Parameters.Add(param1);
                    using (DataTable dt = DataAccess.GetData(command))
                    {
                        foreach (DataRow dr in dt.Rows)
                        {
                            cuisines = GetRow(dr);
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
            return cuisines;
        }

        
        private static CuisineEntity GetRow(DataRow dr)
        {
            CuisineEntity cuisine = new CuisineEntity
            {
                CreatedAt = DataConvert.ToDateTime(dr["CuisineCreatedAt"]),
                CreatedByUserId = DataConvert.ToString(dr["CuisineCreatedby"]),
                Id = DataConvert.ToInt(dr["Id"]),
                UpdatedAt = DataConvert.ToDateTime(dr["CuisineUpdateAt"]),
                UpdatedByUserId = DataConvert.ToString(dr["CuisineUpdateby"]),
                Name = DataConvert.ToString(dr["Name"]),
                IsActive = DataConvert.ToBoolean(dr["CuisineIsActive"]),
                Description = new DescriptionEntity
                {
                    Id = DataConvert.ToInt(dr["DescriptionId"]),
                    CreatedAt = DataConvert.ToDateTime(dr["DescriptionCreatedAt"]),
                    CreatedByUserId = DataConvert.ToString(dr["DescriptionCreatedBy"]),
                    UpdatedAt = DataConvert.ToDateTime(dr["DescriptionUpdateAt"]),
                    IsActive = DataConvert.ToBoolean(dr["DescriptionIsActive"]),
                    UpdatedByUserId = DataConvert.ToString(dr["DescriptionUpdateBy"]),
                    Title = DataConvert.ToString(dr["Title"]),
                    LongContent = DataConvert.ToString(dr["LongContent"]),
                    ShortContent = DataConvert.ToString(dr["ShortContent"]),
                }
            };
            return cuisine;
        }

        public static CuisineEntity CreateCuisine(CuisineEntity cuisineEntity)
        {
            return InsertUpdate(cuisineEntity, DatabaseAccessKey.Insert);
        }

        public static CuisineEntity UpdateCuisine(CuisineEntity cuisineEntity)
        {
            return InsertUpdate(cuisineEntity, DatabaseAccessKey.Update);
        }

        private static CuisineEntity InsertUpdate(CuisineEntity cuisineEntity, DatabaseAccessKey databaseAccessKey)
        {
            try
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.CommandText = "CuisineMasterAction";
                    command.CommandType = CommandType.StoredProcedure;
                    SqlParameter CuisineId = new SqlParameter("@CuisineId", cuisineEntity.Id);
                    command.Parameters.Add(CuisineId);
                    SqlParameter CuisineName = new SqlParameter("@CuisineName", cuisineEntity.Name);
                    command.Parameters.Add(CuisineName);
                    SqlParameter ShortContent = new SqlParameter("@ShortContent", cuisineEntity.Description.ShortContent);
                    command.Parameters.Add(ShortContent);
                    SqlParameter Title = new SqlParameter("@Title", cuisineEntity.Description.Title);
                    command.Parameters.Add(Title);
                    SqlParameter LongContent = new SqlParameter("@LongContent", cuisineEntity.Description.LongContent);
                    command.Parameters.Add(LongContent);
                    SqlParameter User = new SqlParameter("@User", cuisineEntity.CreatedByUserName);
                    command.Parameters.Add(User);
                    SqlParameter DescriptionId = new SqlParameter("@DescriptionId", cuisineEntity.Description.Id);
                    command.Parameters.Add(DescriptionId);
                    SqlParameter IsActive = new SqlParameter("@IsActive", cuisineEntity.IsActive);
                    command.Parameters.Add(IsActive);
                    SqlParameter ActionMode = new SqlParameter("@ActionMode", databaseAccessKey);
                    command.Parameters.Add(ActionMode);
                    using (DataTable dt = DataAccess.GetData(command))
                    {
                        foreach (DataRow dr in dt.Rows)
                        {
                            cuisineEntity.Id = DataConvert.ToInt(dr["CuisineId"]);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return cuisineEntity;
        }

    }
}
