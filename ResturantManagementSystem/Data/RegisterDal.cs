using RMS.Data.Common;
using RMS.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMS.Data
{
    public class RegisterDal
    {
        public static SqlDbType databaseAccessKey { get; private set; }

        public static List<RegisterEntity> GetRegister(RegisterEntity registerEntity)
        {
            List<RegisterEntity> registersEntity = new List<RegisterEntity>();
            try
            {
                using (SqlCommand command=new SqlCommand())
                {
                    command.CommandText = "RegisterMasterSel";
                    command.CommandType = CommandType.StoredProcedure;
                    SqlParameter param1 = new SqlParameter("@RegisterName",registerEntity.Name);
                    command.Parameters.Add(param1);

                    using (DataTable dt =DataAccess.GetData(command))
                    {
                        foreach(DataRow dr in dt.Rows)
                        {
                            registersEntity.Add(GetRow(dr));
                        }

                    }


                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return registersEntity;
        }


        public static RegisterEntity GetRegById(RegisterEntity entity) 
        {
            RegisterEntity registerEntity = new RegisterEntity();
            try
            {
                using (SqlCommand command=new SqlCommand())
                {
                    command.CommandText = "RegisterMaterSel";
                    command.CommandType = CommandType.StoredProcedure;
                    SqlParameter param1 = new SqlParameter("@RegisterId", entity.Id);
                    command.Parameters.Add(param1);
                    using (DataTable dt=DataAccess.GetData(command))
                    {
                        foreach (DataRow dr in dt.Rows)
                        {
                            registerEntity = GetRow(dr);
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }

            return registerEntity;

        }

        public static RegisterEntity GetRegByEmail(RegisterEntity entity)
        {
            RegisterEntity registerEntity = new RegisterEntity();
            try
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.CommandText = "RegisterMasterSel";
                    command.CommandType = CommandType.StoredProcedure;
                    SqlParameter param1 = new SqlParameter("@RegisterEmail", entity.Email);
                    command.Parameters.Add(param1);
                    using (DataTable dt = DataAccess.GetData(command))
                    {
                        foreach (DataRow dr in dt.Rows)
                        {
                            registerEntity = GetRow(dr);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return registerEntity;

        }

        private static RegisterEntity GetRow(DataRow dr)
        {
            RegisterEntity registerEntity = new RegisterEntity {

                Id = DataConvert.ToInt(dr["Id"]),
                Name = DataConvert.ToString(dr["Name"]),
                Email = DataConvert.ToString(dr["Email"]),
                CreatedAt = DataConvert.ToDateTime(dr["CreatedAt"]),
                CreatedByUserId = DataConvert.ToString(dr["CreatedBy"]),
                UpdatedAt= DataConvert.ToDateTime(dr["UpdatedAt"]),
                UpdatedByUserId= DataConvert.ToString(dr["UpdatedBy"]),
                IsActive=DataConvert.ToBoolean(dr["IsActive"])

            };

            return registerEntity;
        }
        public static RegisterEntity CreateRegiter(RegisterEntity registerEntity)
        {
            return InsertUpdate(registerEntity, DatabaseAccessKey.Insert);
        }
        public static RegisterEntity UpdateRegister(RegisterEntity registerEntity)
        {
            return InsertUpdate(registerEntity, DatabaseAccessKey.Update);
        }


        private static RegisterEntity InsertUpdate(RegisterEntity registerEntity, DatabaseAccessKey databaseAccessKey)
        {
            try
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.CommandText = "RegisterMasterAction";
                    command.CommandType = CommandType.StoredProcedure;
                   
                    SqlParameter RegisterName = new SqlParameter("@RegisterName", registerEntity.Name);
                    command.Parameters.Add(RegisterName);

                    SqlParameter RegisterEmail = new SqlParameter("@RegisterEmail", registerEntity.Email);
                    command.Parameters.Add(RegisterEmail);
                    SqlParameter User = new SqlParameter("@User", registerEntity.CreatedByUserId);
                    command.Parameters.Add(User);
                   
                    SqlParameter IsActive = new SqlParameter("@IsActive", registerEntity.IsActive);
                    command.Parameters.Add(IsActive);
                    SqlParameter RegisterId = new SqlParameter("@RegisterId",registerEntity.Id);
                    command.Parameters.Add(RegisterId);
                    SqlParameter ActionMode = new SqlParameter("@ActionMode", databaseAccessKey);
                    command.Parameters.Add(ActionMode);
                    using (DataTable dt = DataAccess.GetData(command))
                    {
                        foreach (DataRow dr in dt.Rows)
                        {
                            registerEntity.Id = DataConvert.ToInt(dr["Id"]);
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
            return registerEntity;
        }
    }
}
