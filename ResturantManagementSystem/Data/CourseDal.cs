using System;
using System.Collections.Generic;
using RMS.Entity;
using System.Data.SqlClient;
using System.Data;
using RMS.Data.Common;

namespace RMS.Data
{
    public static class CourseDal
    {
        public static List<CourseEntity> GetCourse(CourseEntity courseEntity)
        {
            List<CourseEntity> courses = new List<CourseEntity>();
            try
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.CommandText = "dbo.CourseMasterSel";
                    command.CommandType = CommandType.StoredProcedure;
                    SqlParameter param1 = new SqlParameter("@CuisineId", courseEntity.Cuisine.Id);
                    command.Parameters.Add(param1);
                    SqlParameter param2 = new SqlParameter("@CourseName", courseEntity.Name);
                    command.Parameters.Add(param2);
                    using (DataTable dt = DataAccess.GetData(command))
                    {
                        foreach (DataRow dr in dt.Rows)
                        {
                            courses.Add(GetRow(dr));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return courses;
        }

        private static CourseEntity GetRow(DataRow dr)
        {
            CourseEntity courseEntity = new CourseEntity
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
                IsActive= DataConvert.ToBoolean(dr["IsActive"])
            };
            return courseEntity;
        }

        public static CourseEntity GetCourseById(CourseEntity courseEntity)
        {
            CourseEntity course = new CourseEntity();
            try
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.CommandText = "dbo.CourseMasterSel";
                    command.CommandType = CommandType.StoredProcedure;
                    SqlParameter param1 = new SqlParameter("@CourseId", courseEntity.Id);
                    command.Parameters.Add(param1);
                    using (DataTable dt = DataAccess.GetData(command))
                    {
                        foreach (DataRow dr in dt.Rows)
                        {
                            course=GetRow(dr);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return course;
        }

       

        public static CourseEntity CreateCourse(CourseEntity courseEntity)
        {
            return InsertUpdate(courseEntity, DatabaseAccessKey.Insert);
        }

        public static CourseEntity UpdateCourse(CourseEntity courseEntity)
        {
            return InsertUpdate(courseEntity, DatabaseAccessKey.Update);
        }

        private static CourseEntity InsertUpdate(CourseEntity courseEntity, DatabaseAccessKey databaseAccessKey)
        {
            try
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.CommandText = "CourseMasterAction";
                    command.CommandType = CommandType.StoredProcedure;
                    SqlParameter CourseId = new SqlParameter("@CourseId", courseEntity.Id);
                    command.Parameters.Add(CourseId);
                    SqlParameter CourseName = new SqlParameter("@CourseName", courseEntity.Name);
                    command.Parameters.Add(CourseName);
                    SqlParameter ShortContent = new SqlParameter("@ShortContent", courseEntity.Description.LongContent);
                    command.Parameters.Add(ShortContent);
                    SqlParameter Title = new SqlParameter("@Title", courseEntity.Description.Title);
                    command.Parameters.Add(Title);
                    SqlParameter LongContent = new SqlParameter("@LongContent", courseEntity.Description.LongContent);
                    command.Parameters.Add(LongContent);
                    SqlParameter User = new SqlParameter("@User", courseEntity.CreatedByUserName);
                    command.Parameters.Add(User);
                    SqlParameter DescriptionId = new SqlParameter("@DescriptionId", courseEntity.Description.Id);
                    command.Parameters.Add(DescriptionId);
                    SqlParameter CuisineId = new SqlParameter("@CuisineId", courseEntity.Cuisine.Id);
                    command.Parameters.Add(CuisineId);
                    SqlParameter IsActive = new SqlParameter("@IsActive", courseEntity.IsActive);
                    command.Parameters.Add(IsActive);
                    SqlParameter ActionMode = new SqlParameter("@ActionMode", databaseAccessKey);
                    command.Parameters.Add(ActionMode);
                    using (DataTable dt = DataAccess.GetData(command))
                    {
                        foreach (DataRow dr in dt.Rows)
                        {
                            courseEntity.Id = DataConvert.ToInt(dr["CourseId"]);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return courseEntity;
        }




    }
}
