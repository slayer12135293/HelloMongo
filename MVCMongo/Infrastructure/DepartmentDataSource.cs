using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Builders;
using MVCMongo.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MVCMongo.Infrastructure
{
    public class DepartmentDataSource : DbContext, IMongoDepartmentDataSource
    {
        private MongoDatabase database;
        List<Department> Departments;


        public DepartmentDataSource()
        {
            SetDatabase();
            SetDepartments();
        }

        private void SetDepartments()
        {
            var collection = database.GetCollection<Department>("Department");
            Departments = collection.FindAllAs<Department>().ToList(); 
        }

        private void SetDatabase()
        {
            var connectionString = ConfigurationManager.ConnectionStrings["MongoConnection"].ConnectionString;
            var client = new MongoClient(connectionString.ToString());
            var server = client.GetServer();
            database = server.GetDatabase("MVCMongo");
        }


        List<Department> IMongoDepartmentDataSource.Departments
        {
            get
            {
               return Departments;
            }
        }


        void IMongoDepartmentDataSource.CreateDepartment(Models.Department colleciton)
        {
            if (colleciton != null)
            {
                int Id = 0;
                if (Departments.Count() > 0)
                    Id = Departments.Max(x => x.DepartmentId);
                Id += 1;
                MongoCollection<Department> MCollection = database.GetCollection<Department>("Department");
                BsonDocument doc = new BsonDocument { 
                    {"DepartmentId",Id},
                    {"DepartmentName",colleciton.DepartmentName},
                    {"CreatedDate", colleciton.CreatedDate}
                };

                IMongoQuery query = Query.EQ("DepartmentName", colleciton.DepartmentName);
                var exists = MCollection.Find(query);
                if (exists.ToList().Count == 0)
                    MCollection.Insert(doc);
            }
        }

        void IMongoDepartmentDataSource.EditDepartment(Models.Department collection)
        {
            MongoCollection<Department> MCollection = database.GetCollection<Department>("Department");
            IMongoQuery query = Query.EQ("DepartmentId", collection.DepartmentId);
            IMongoUpdate update = MongoDB.Driver.Builders.Update.Set("DepartmentName", collection.DepartmentName).Set("CreatedDate", collection.CreatedDate);

            MCollection.Update(query, update);
        }

        void IMongoDepartmentDataSource.DeleteDepartment(Models.Department collection)
        {
            MongoCollection<Department> MCollection = database.GetCollection<Department>("Department");
            IMongoQuery query = Query.EQ("_id", collection._id);
            MCollection.Remove(query);
        }

    }
}