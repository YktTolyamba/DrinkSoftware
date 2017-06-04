using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Npgsql;
using NpgsqlTypes;

namespace DrinkSoftware
{
    public class MainForm
    {
        private static string connStr;

        static MainForm()
        {
            connStr = "Server=127.0.0.1;Port=5432;User Id=postgres;Password=1;Database=DrinkSoftware;encoding=unicode;";
        }

        public static DataSet GetDataSet()
        {
            DataSet ds = new DataSet();
            NpgsqlConnection conn = new NpgsqlConnection(connStr);
            NpgsqlDataAdapter da = new NpgsqlDataAdapter("SELECT * FROM \"Order\" ORDER BY ID", conn);
            da.Fill(ds, "order");
            return ds;
        }

        public static void UpdateDataSet(DataSet ds)
        {
            NpgsqlConnection conn = new NpgsqlConnection(connStr);

            string sqlInsert, sqlUpdate, sqlDelete;
            sqlInsert = "insert into \"Order\" (id,per_id,cas_id,disc_id,discinfo,orderdate,closedate,payment,collateral,ordestate) values(@p1, @p2, @p3, @p4, @p5, @p6, @p7, @p8, @p9, @p10)";
            sqlUpdate = "update \"Order\" set per_id=@p2,cas_id=@p3,disc_id=@p4,discinfo = @p5, orderdate = @p6, closedate = @p7, payment = @p8, collateral = @p9, orderstate = @p10 where id = @p1";
            sqlDelete = "delete from \"Order\" where id=@p1";

            NpgsqlParameter[] pInsert = new NpgsqlParameter[10];
            NpgsqlParameter[] pUpdate = new NpgsqlParameter[10];
            NpgsqlParameter[] pDelete = new NpgsqlParameter[1];

            pInsert[0] = new NpgsqlParameter("@p1", NpgsqlDbType.Varchar, 5,"id");
            pInsert[1] = new NpgsqlParameter("@p2", NpgsqlDbType.Varchar, 40,"per_id");
            pInsert[2] = new NpgsqlParameter("@p3", NpgsqlDbType.Varchar, 40,"cas_id");
            pInsert[3] = new NpgsqlParameter("@p4", NpgsqlDbType.Varchar, 40,"disc_id");
            pInsert[4] = new NpgsqlParameter("@p5", NpgsqlDbType.Varchar, 400, "discinfo");
            pInsert[5] = new NpgsqlParameter("@p6", NpgsqlDbType.Varchar, 40, "orderdate");
            pInsert[6] = new NpgsqlParameter("@p7", NpgsqlDbType.Varchar, 40, "closedate");
            pInsert[7] = new NpgsqlParameter("@p8", NpgsqlDbType.Varchar, 40, "payment");
            pInsert[8] = new NpgsqlParameter("@p9", NpgsqlDbType.Varchar, 40, "collateral");
            pInsert[9] = new NpgsqlParameter("@p10", NpgsqlDbType.Varchar, 40, "orderstate");


            pUpdate[1] = new NpgsqlParameter("@p2", NpgsqlDbType.Varchar, 40, "per_id");
            pUpdate[2] = new NpgsqlParameter("@p3", NpgsqlDbType.Varchar, 40, "cas_id");
            pUpdate[3] = new NpgsqlParameter("@p4", NpgsqlDbType.Varchar, 40, "disc_id");
            pUpdate[4] = new NpgsqlParameter("@p5", NpgsqlDbType.Varchar, 400, "discinfo");
            pUpdate[5] = new NpgsqlParameter("@p6", NpgsqlDbType.Varchar, 40, "orderdate");
            pUpdate[6] = new NpgsqlParameter("@p7", NpgsqlDbType.Varchar, 40, "closedate");
            pUpdate[7] = new NpgsqlParameter("@p8", NpgsqlDbType.Varchar, 40, "payment");
            pUpdate[8] = new NpgsqlParameter("@p9", NpgsqlDbType.Varchar, 40, "collateral");
            pUpdate[9] = new NpgsqlParameter("@p10", NpgsqlDbType.Varchar, 40, "orderstate");
            pUpdate[0] = new NpgsqlParameter("@p1", NpgsqlDbType.Varchar, 5,"id");

            pDelete[0] = new NpgsqlParameter("@p1", NpgsqlDbType.Varchar, 5,"id");

            NpgsqlCommand cmdInsert = new NpgsqlCommand(sqlInsert, conn);
            NpgsqlCommand cmdUpdate = new NpgsqlCommand(sqlUpdate, conn);
            NpgsqlCommand cmdDelete = new NpgsqlCommand(sqlDelete, conn);

            cmdInsert.Parameters.AddRange(pInsert);
            cmdUpdate.Parameters.AddRange(pUpdate);
            cmdDelete.Parameters.AddRange(pDelete);

            NpgsqlDataAdapter da = new NpgsqlDataAdapter();
            da.InsertCommand = cmdInsert;
            da.UpdateCommand = cmdUpdate;
            da.DeleteCommand = cmdDelete;
            da.Update(ds, "order");
            ds.AcceptChanges();
        }

        /*public static DataSet GetCountries()
        {
            DataSet ds = new DataSet();
            NpgsqlDataAdapter da = new NpgsqlDataAdapter("select distinct country from customers", connStr);
      
            da.Fill(ds, "countries");
            return ds;
        }*/
    }
}