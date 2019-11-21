using RMS.Data.Common;
using RMS.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace RMS.Data
{
    public static class MenuDal
    {
       

        public static List<MenuEntity> GetMenu(MenuEntity menuEntity)
        {
            List<MenuEntity> menues = new List<MenuEntity>();
            try
            {
                using (SqlCommand command=new SqlCommand())
                {
                    command.CommandText = "dbo.MenuMasterSel";
                    command.CommandType = CommandType.StoredProcedure;
                    SqlParameter param1 = new SqlParameter("@MenuId", menuEntity.Id);
                    command.Parameters.Add(param1);
                    SqlParameter param2 = new SqlParameter("@MenuName", menuEntity.Name );
                    command.Parameters.Add(param2);
                    SqlParameter param3 = new SqlParameter("@CourseId", menuEntity.Course.Id);
                    command.Parameters.Add(param3);
                    SqlParameter param4 = new SqlParameter("@CuisineId", menuEntity.Cuisine.Id);
                    command.Parameters.Add(param4);
                    using (DataTable dt = Common.DataAccess.GetData(command))
                    {
                        foreach (DataRow dr in dt.Rows)
                        {
                            menues.Add(GetRow(dr));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return menues;
        }

        //public static List<MenuEntity> GetMenuByName(MenuEntity menuEntity)
        //{
        //    List<MenuEntity> menu = new List<MenuEntity>();
        //       try
        //       {
        //          using (SqlCommand command = new SqlCommand())
        //          {
        //              command.CommandText = "dbo.MenuMasterSel";
        //              command.CommandType = CommandType.StoredProcedure;
        //               SqlParameter param1 = new SqlParameter("@MenuName", menuEntity.name);
        //               command.Parameters.Add(param1);
        //               using (DataTable dt = DataAccess.GetData(command))
        //              {
        //                  foreach (DataRow dr in dt.Rows)
        //                  {
        //                       menu.Add(GetRow(dr));
        //                   }
        //               }
        //           }
        //       }
        //        catch (Exception ex)
        //       {
        //            throw ex;
        //        }
        //        return menu;
        //}

        //public static MenuEntity GetMenuByName(MenuEntity menuEntity)
        //{
        //    throw new NotImplementedException();
        //}

        public static MenuEntity CreateMenu(MenuEntity menuEntity)
        {
            return InsertUpdate(menuEntity, DatabaseAccessKey.Insert);
        }

        public static MenuEntity UpdateMenu(MenuEntity menuEntity)
        {
            return InsertUpdate(menuEntity, DatabaseAccessKey.Update);
        }

        private static MenuEntity InsertUpdate(MenuEntity menuEntity, DatabaseAccessKey databaseAccessKey)
        {
            try
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.CommandText = "MenuMasterAction";
                    command.CommandType = CommandType.StoredProcedure;
                    SqlParameter MenuId = new SqlParameter("@MenuId", menuEntity.Id);
                    command.Parameters.Add(MenuId);
                    SqlParameter CuisineId = new SqlParameter("@CuisineId", menuEntity.Cuisine.Id);
                    command.Parameters.Add(CuisineId);
                    SqlParameter CourseId = new SqlParameter("@CourseId", menuEntity.Course.Id);
                    command.Parameters.Add(CourseId);
                    SqlParameter MenuName = new SqlParameter("@MenuName", menuEntity.Name);
                    command.Parameters.Add(MenuName);
                    SqlParameter ShortContent = new SqlParameter("@ShortContent", menuEntity.Description.LongContent);
                    command.Parameters.Add(ShortContent);
                    SqlParameter Title = new SqlParameter("@Title", menuEntity.Description.Title);
                    command.Parameters.Add(Title);
                    SqlParameter LongContent = new SqlParameter("@LongContent", menuEntity.Description.LongContent);
                    command.Parameters.Add(LongContent);
                    SqlParameter User = new SqlParameter("@User", menuEntity.CreatedByUserName);
                    command.Parameters.Add(User);
                    SqlParameter DescriptionId = new SqlParameter("@DescriptionId", menuEntity.Description.Id);
                    command.Parameters.Add(DescriptionId);
                    SqlParameter IsActive = new SqlParameter("@IsActive", menuEntity.IsActive);
                    command.Parameters.Add(IsActive);
                    SqlParameter ActionMode = new SqlParameter("@ActionMode", databaseAccessKey);
                    command.Parameters.Add(ActionMode);
                    using (DataTable dt = DataAccess.GetData(command))
                    {
                        foreach (DataRow dr in dt.Rows)
                        {
                            menuEntity.Id = DataConvert.ToInt(dr["MenuId"]);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return menuEntity;
        }

        private static MenuEntity GetRow(DataRow dr)
        {
            MenuEntity menuEntity = new MenuEntity
            {
                Id = DataConvert.ToInt(dr["Id"]),
                Name = DataConvert.ToString(dr["Name"]),
                CreatedAt = DataConvert.ToDateTime(dr["CreatedAt"]),
                CreatedByUserId = DataConvert.ToString(dr["Createdby"]),
                UpdatedAt = DataConvert.ToDateTime(dr["UpdateAt"]),
                UpdatedByUserId = DataConvert.ToString(dr["Updateby"]),
                Description = new DescriptionEntity
                {
                    Id = DataConvert.ToInt(dr["DescriptionId"]),
                    CreatedAt = DataConvert.ToDateTime(dr["DescCreatedAt"]),
                    CreatedByUserId = DataConvert.ToString(dr["DescCreatedBy"]),
                    UpdatedAt = DataConvert.ToDateTime(dr["DescUpdateAt"]),
                    IsActive = DataConvert.ToBoolean(dr["DescIsActive"]),
                    UpdatedByUserId = DataConvert.ToString(dr["DescUpdateBy"]),
                    Title = DataConvert.ToString(dr["Title"]),
                    LongContent = DataConvert.ToString(dr["LongContent"]),
                    ShortContent = DataConvert.ToString(dr["ShortContent"])
                },
                Cuisine = new CuisineEntity
                {
                    Id = DataConvert.ToInt(dr["CuisineId"]),
                    Name = DataConvert.ToString(dr["CuisineName"])
                },
                Course = new CourseEntity
                {
                    Id = DataConvert.ToInt(dr["CourseId"]),
                    Name = DataConvert.ToString(dr["CourseName"])
                },
                IsActive = DataConvert.ToBoolean(dr["IsActive"])
            };
            return menuEntity;
        }

        public static MenuEntity GetMenuById(MenuEntity menuEntity)
        {
            MenuEntity menu = new MenuEntity();
            try
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.CommandText = "dbo.MenuMasterSel";
                    command.CommandType = CommandType.StoredProcedure;
                    SqlParameter param1 = new SqlParameter("@MenuId", menuEntity.Id);
                    command.Parameters.Add(param1);
                    using (DataTable dt = DataAccess.GetData(command))
                    {
                        foreach (DataRow dr in dt.Rows)
                        {
                            menu = GetRow(dr);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return menu;
        }
        //public static MenuEntity GetMenuByName(MenuEntity menuEntity)
        //{
        //    MenuEntity menu = new MenuEntity();
        //    try
        //    {
        //        using (SqlCommand command = new SqlCommand())
        //        {
        //            command.CommandText = "dbo.MenuMasterSel";
        //            command.CommandType = CommandType.StoredProcedure;
        //            SqlParameter param1 = new SqlParameter("@MenuName", menuEntity.name);
        //            command.Parameters.Add(param1);
        //            using (DataTable dt = DataAccess.GetData(command))
        //            {
        //                foreach (DataRow dr in dt.Rows)
        //                {
        //                    menu = GetRow(dr);
        //                }
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    return menu;
        //}



    }
}
