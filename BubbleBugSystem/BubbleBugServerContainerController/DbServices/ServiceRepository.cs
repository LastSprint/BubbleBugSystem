using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using BubbleBugServiceController.Configuration;
using BubbleBugSharedModels;
using Newtonsoft.Json;

namespace BubbleBugServiceController.DbServices
{
    public interface IRepository<T> {
        IList<T> ReadAll();
        void Add(T obj);
        void Remove(T obj);
    }

    public class ServiceRepository: IRepository<ServiceModel> {

        private readonly IList<ServiceModel> _models;

        public ServiceRepository() {
            var dbFileContent = File.ReadAllText(Config.Instance.DbFilePath);
            this._models = JsonConvert.DeserializeObject<List<ServiceModel>>(dbFileContent);
        }

        public IList<ServiceModel> ReadAll() {
            return this._models;
        }

        public void Add(ServiceModel obj) {
            if (this._models.First(x => x.Name == obj.Name) != null) {
                throw new ArgumentException("Проект с таким именем уже существует");
            }
            JsonConvert.SerializeObject(this._models);
        }

        public void Remove(ServiceModel obj) {
            throw new NotImplementedException();
        }
    }
}
