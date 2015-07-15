using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniRitter.UniRitter2015.Models;

namespace UniRitter.UniRitter2015.Services.Implementation
{
    public class MongoPersonRepository : IRepository<PersonModel>
    {
        private IMongoDatabase database;
        private IMongoCollection<PersonModel> collection;

        public MongoPersonRepository()
        {
            var client = new MongoClient("mongodb://localhost");
            database = client.GetDatabase("uniritter");
            collection = database.GetCollection<PersonModel>("people");
        }

        public PersonModel Add(PersonModel model)
        {
            model.id = Guid.NewGuid();
            collection.InsertOneAsync(model).Wait();
            return model;
        }

        public bool Delete(Guid id)
        {
            var result = collection.DeleteOneAsync(
                p => p.id == id).Result;

            return result.DeletedCount > 0;
        }

        public PersonModel Update(Guid id, PersonModel model)
        {
            collection.ReplaceOneAsync(p => p.id == id, model).Wait();
            return model;
        }

        public IEnumerable<PersonModel> GetAll()
        {
            var data = collection.Find(p => true).ToListAsync<PersonModel>();
            return data.Result;
        }

        public PersonModel GetById(Guid id)
        {
            var data = collection.Find(p => p.id == id).FirstOrDefaultAsync();
            return data.Result;
        }
    }

    public class MongoPostRepository : IRepository<PostModel>
    {
        private IMongoDatabase database;
        private IMongoCollection<PostModel> collection;

        public MongoPostRepository()
        {
            var client = new MongoClient("mongodb://localhost");
            database = client.GetDatabase("uniritter");
            collection = database.GetCollection<PostModel>("post");
        }

        public PostModel Add(PostModel model)
        {
            model.id = Guid.NewGuid();
            collection.InsertOneAsync(model).Wait();
            return model;
        }

        public bool Delete(Guid id)
        {
            var result = collection.DeleteOneAsync(
                p => p.id == id).Result;

            return result.DeletedCount > 0;
        }

        public PostModel Update(Guid id, PostModel model)
        {
            collection.ReplaceOneAsync(p => p.id == id, model).Wait();
            return model;
        }

        public IEnumerable<PostModel> GetAll()
        {
            var data = collection.Find(p => true).ToListAsync<PostModel>();
            return data.Result;
        }

        public PostModel GetById(Guid id)
        {
            var data = collection.Find(p => p.id == id).FirstOrDefaultAsync();
            return data.Result;
        }
    }

    public class MongoCommentRepository : IRepository<CommentModel>
    {
        private IMongoDatabase database;
        private IMongoCollection<CommentModel> collection;

        public MongoCommentRepository()
        {
            var client = new MongoClient("mongodb://localhost");
            database = client.GetDatabase("uniritter");
            collection = database.GetCollection<CommentModel>("comment");
        }

        public CommentModel Add(CommentModel model)
        {
            model.id = Guid.NewGuid();
            collection.InsertOneAsync(model).Wait();
            return model;
        }

        public bool Delete(Guid id)
        {
            var result = collection.DeleteOneAsync(p => p.id == id).Result;
            return result.DeletedCount > 0;
        }

        public CommentModel Update(Guid id, CommentModel model)
        {
            collection.ReplaceOneAsync(p => p.id == id, model).Wait();
            return model;
        }

        public IEnumerable<CommentModel> GetAll()
        {
            var data = collection.Find(p => true).ToListAsync<CommentModel>();
            return data.Result;
        }

        public CommentModel GetById(Guid id)
        {
            var data = collection.Find(p => p.id == id).FirstOrDefaultAsync();
            return data.Result;
        }
    }
}