﻿using EEGGaming.Core.Data;
using EEGGaming.Core.Tools;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EEGGaming.Core.Managers
{
    public  class BaseManager
    {
        public EEGGamingDbContext DbContext { get; set; }
        public BaseManager() {
            if (Directory.Exists(CommonTools.GetAppRootDataFolderAbsolutePath()) == false)
            {
                Directory.CreateDirectory(CommonTools.GetAppRootDataFolderAbsolutePath());
            }
            DbContext = new EEGGamingDbContext();
            DbContext.Database.EnsureCreated();
            DbContext.Database.MigrateAsync();
             

        
        }
        public void CreateDatabase()
        {
            DbContext.Database.EnsureCreated();
            DbContext.Database.MigrateAsync();
            
        }
        public int PredictLastId(string tablename)
        {
            try
            {

                int ap = -1;
                string sql;// String.Format(@"USE {0} Go SELECT IDENT_CURRENT ('{1}') AS Current_Identity;", db.Database.GetDbConnection().Database, tablename);
                if (CommonTools.isEmpty(tablename) == false)
                {
                    sql = String.Format(@"USE [{0}] SELECT IDENT_CURRENT ('{1}') AS Current_Identity;", DbContext.Database.GetDbConnection().Database, tablename);
                    //sql = String.Format(@"SELECT IDENT_CURRENT ('{0}') AS Current_Identity;", tablename);



                    //  db.Database.BeginTransaction();

                    int res = -1;//;= await db.Database.ExecuteSqlRawAsync(sql);
                    var con = DbContext.Database.GetDbConnection();
                    if (con != null)
                    {
                        con.Open();
                        var comm = con.CreateCommand();
                        if (comm != null)
                        {
                            comm.CommandText = sql;
                            comm.CommandType = System.Data.CommandType.Text;
                            var reader = comm.ExecuteReader();
                            if (reader != null)
                            {
                                while (reader.Read())
                                {
                                    res = Convert.ToInt32(reader["Current_Identity"]);
                                }

                                reader.Close();
                            }
                        }
                        con.Close();
                    }

                    //  db.Database.CommitTransaction();

                    if (res > 0)
                    {
                        ap = Convert.ToInt32(res);
                    }
                    //await  db.Database.ExecuteSqlRawAsync(sql));
                }





                return ap;



            }
            catch (Exception ex)
            {

                CommonTools.ErrorReporting(ex);
                return -1;
            }
        }

        

    }
}
