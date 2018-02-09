using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using BubbleBugServerContainerController.Configuration;
using BubbleBugServerContainerController.Models;
using Newtonsoft.Json;

namespace BubbleBugServerContainerController.DbServices
{
    public interface IRepository<T> {
        IList<T> ReadAll();
        void Add(T obj);
        void Remove(T obj);
    }

    public class ServiceRepository: IRepository<ApiServiceModel> {

        private readonly IList<ApiServiceModel> _models;

        public ServiceRepository() {
            var dbFileContent = File.ReadAllText(Config.Instance.DbFilePath);
            this._models = JsonConvert.DeserializeObject<List<ApiServiceModel>>(dbFileContent);
        }

        public IList<ApiServiceModel> ReadAll() {
            return this._models;
        }

        public void Add(ApiServiceModel obj) {
            if (this._models.First(x => x.ProjectName == obj.ProjectName) != null) {
                throw new ArgumentException("Проект с таким именем уже существует");
            }

            var port = this._models.Count == 0 ? this._models.Max(x => x.Port) : Config.Instance.StartPort;

            if (port++ > Config.Instance.EndPort) {
                throw new SystemException("Закончились свободные порты");
            }

            obj.Port = port + 1;

            this._models.Add(obj);

            JsonConvert.SerializeObject(this._models);
        }

        public void Remove(ApiServiceModel obj) {
            throw new NotImplementedException();
        }
    }
}
