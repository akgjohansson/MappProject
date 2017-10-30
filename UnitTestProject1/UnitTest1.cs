using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Data.SqlClient;
using NHibernate.Cfg;
using NHibernate.Dialect;
using NHibernate.Mapping.ByCode;
using System.Reflection;
using Hogia.SkeletonWeb.Web.App.src.services.homes;
using NHibernate.Cfg.MappingSchema;
using NHibernate.Tool.hbm2ddl;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        public static string ConnectionString { get; set; }
        public UnitTest1()
        {
            ConnectionString = @"Server = (localdb)\mssqllocaldb; Database = Bostadskollen;";//
        }
        [TestMethod]
        public void BuildDataBase()
        {

            using (SqlConnection con = new SqlConnection(@"Server = (localdb)\mssqllocaldb;"))
            {
                con.Open();

                using (SqlCommand command = new SqlCommand("if db_id('Bostadskollen') is null create database Bostadskollen", con))
                {
                    command.ExecuteNonQuery();
                }
            }

            Configuration config = new Configuration();
            var schema = new SchemaExport(Configure());
            schema.SetOutputFile("outputFile.sql");
            schema.Create(true, false);
            //schema.Drop(true, true);
            schema.Create(true, true);
        }

        private static Configuration Configure()
        {
            Configuration cfg = new Configuration()
                           .DataBaseIntegration(db =>
                           {
                               db.ConnectionString = ConnectionString + " Trusted_Connection = True;";
                               db.Dialect<MsSql2008Dialect>();
                           });

            var mapper = new ModelMapper();
            Type[] myTypes = Assembly.GetExecutingAssembly().GetExportedTypes();
            mapper.AddMappings(myTypes);

            HbmMapping mapping = new Hogia.SkeletonWeb.Web.App.src.services.homes.Mapper().Map();
            cfg.AddMapping(mapping);

            return cfg;
        }
    }
}
