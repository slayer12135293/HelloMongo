using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Builders;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MVCMongo.Models
{
    public class Department
    {
        public ObjectId _id { get; set; }
        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; }
        public DateTime CreatedDate { get; set; }
    }


    #region mongo

    //public class MongoDBEntities : DbContext
    //{
    //    public MongoDBEntities() : base("name=MongoConnection") { }
    //    static MongoServer server = MongoServer.Create(ConfigurationManager.ConnectionStrings["MongoConnection"].ConnectionString.ToString());
    //    MongoDatabase database = server.GetDatabase("MVCMongo");

    //    List<Department> department;
    //    public List<Department> Departments
    //    {
    //        get
    //        {
    //            var collection = database.GetCollection<Department>("Department");
    //            return collection.FindAllAs<Department>().ToList();
    //        }
    //        set { department = value; }
    //    }
    //    public void CreateDepartment(Department colleciton)
    //    {
    //        try
    //        {
    //            int Id = 0;
    //            if (Departments.Count() > 0)
    //                Id = Departments.Max(x => x.DepartmentId);
    //            Id += 1;
    //            MongoCollection<Department> MCollection = database.GetCollection<Department>("Department");
    //            BsonDocument doc = new BsonDocument { 
    //                {"DepartmentId",Id},
    //                {"DepartmentName",colleciton.DepartmentName}
    //            };

    //            IMongoQuery query = Query.EQ("DepartmentName", colleciton.DepartmentName);
    //            var exists = MCollection.Find(query);
    //            if (exists.ToList().Count == 0)
    //                MCollection.Insert(doc);

    //        }
    //        catch { }
    //    }
    //    public void EditDepartment(Department collection)
    //    {
    //        try
    //        {
    //            MongoCollection<Department> MCollection = database.GetCollection<Department>("Department");
    //            IMongoQuery query = Query.EQ("DepartmentId", collection.DepartmentId);
    //            IMongoUpdate update = MongoDB.Driver.Builders.Update.Set("DepartmentName", collection.DepartmentName);
    //            MCollection.Update(query, update);
    //        }
    //        catch { }
    //    }
    //    public void DeleteDepartment( Department collection)
    //    {
    //        try
    //        { 
    //            MongoCollection<Department> MCollection = database.GetCollection<Department>("Department");
    //            IMongoQuery query = Query.EQ("_id", collection._id);
    //            MCollection.Remove(query);
    //        }
    //        catch { }
    //    }

    //}
    #endregion
}