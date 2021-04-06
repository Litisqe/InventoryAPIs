using Inventory.BAL.Models;
using Inventory.DAL.DBManager;
using System;
using System.Data;
using System.Data.SqlClient;

namespace Inventory.BAL.Utilities
{
    public sealed class InventoryUtility
    {
        private static InventoryUtility instance;
        public static InventoryUtility Instance
        {
            get
            {
                if (instance == null)
                    instance = new InventoryUtility();
                return instance;
            }
        }

        public DataTable ListInventory(InventoryVM inventory, string ConnectionString)
        {
            try
            {
                SqlParameter[] MyParam = new SqlParameter[7];
                MyParam[0] = new SqlParameter("@Id", SqlDbType.Int);
                if (inventory == null)
                    MyParam[0].Value = DBNull.Value;
                else
                    MyParam[0].Value = inventory.Id;

                MyParam[1] = new SqlParameter("@InvId", SqlDbType.VarChar);
                if (inventory == null)
                    MyParam[1].Value = DBNull.Value;
                else
                    MyParam[1].Value = inventory.InvId;

                MyParam[2] = new SqlParameter("@BrandId", SqlDbType.VarChar);
                if (inventory == null)
                    MyParam[2].Value = DBNull.Value;
                else
                    MyParam[2].Value = inventory.BrandId;

                MyParam[3] = new SqlParameter("@InvName", SqlDbType.VarChar);
                if (inventory == null)
                    MyParam[3].Value = DBNull.Value;
                else
                    MyParam[3].Value = inventory.InvName;

                MyParam[4] = new SqlParameter("@InvDescription", SqlDbType.VarChar);
                if (inventory == null)
                    MyParam[4].Value = DBNull.Value;
                else
                    MyParam[4].Value = inventory.InvDescription;

                MyParam[5] = new SqlParameter("@Price", SqlDbType.Decimal);
                if (inventory == null)
                    MyParam[5].Value = DBNull.Value;
                else
                    MyParam[5].Value = inventory.Price;

                MyParam[6] = new SqlParameter("@Quantity", SqlDbType.Int);
                if (inventory == null)
                    MyParam[6].Value = DBNull.Value;
                else
                    MyParam[6].Value = inventory.Quantity;
                return SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "ListInventory", MyParam).Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int AddInventory(InventoryVM inventory, string ConnectionString)
        {
            try
            {
                SqlParameter[] MyParam = new SqlParameter[6];
                MyParam[0] = new SqlParameter("@InvId", inventory.InvId);
                MyParam[1] = new SqlParameter("@BrandId", inventory.BrandId);
                MyParam[2] = new SqlParameter("@InvName", inventory.InvName);
                MyParam[3] = new SqlParameter("@InvDescription", inventory.InvDescription);
                MyParam[4] = new SqlParameter("@Price", inventory.Price);
                MyParam[5] = new SqlParameter("@Quantity", inventory.Quantity);
                return SqlHelper.ExecuteNonQuery(ConnectionString, CommandType.StoredProcedure, "AddInventory", MyParam);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int ModifyInventory(InventoryVM inventory, string ConnectionString)
        {
            try
            {
                SqlParameter[] MyParam = new SqlParameter[7];
                MyParam[0] = new SqlParameter("@Id", inventory.Id);
                MyParam[1] = new SqlParameter("@InvId", inventory.InvId);
                MyParam[2] = new SqlParameter("@BrandId", inventory.BrandId);
                MyParam[3] = new SqlParameter("@InvName", inventory.InvName);
                MyParam[4] = new SqlParameter("@InvDescription", inventory.InvDescription);
                MyParam[5] = new SqlParameter("@Price", inventory.Price);
                MyParam[6] = new SqlParameter("@Quantity", inventory.Quantity);
                return SqlHelper.ExecuteNonQuery(ConnectionString, CommandType.StoredProcedure, "ModifyInventory", MyParam);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int DeleteInventory(InventoryVM inventory, string ConnectionString)
        {
            try
            {
                SqlParameter[] MyParam = new SqlParameter[2];
                MyParam[0] = new SqlParameter("@InvId", inventory.InvId);
                MyParam[1] = new SqlParameter("@BrandId", inventory.BrandId);
                return SqlHelper.ExecuteNonQuery(ConnectionString, CommandType.StoredProcedure, "DeleteInventory", MyParam);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
