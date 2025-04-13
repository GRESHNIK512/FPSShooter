using Entitas;
using Newtonsoft.Json;
using System.Collections.Generic;
using UnityEngine;

namespace SaveData
{
    internal class SaveDataSystem : ReactiveSystem<DataEntity>
    {
        private Contexts _context;

        public SaveDataSystem(Contexts contexts) : base(contexts.data)
        {
            _context = contexts;
        }

        protected override ICollector<DataEntity> GetTrigger(IContext<DataEntity> context)
        {
            return context.CreateCollector(DataMatcher.SaveData);
        }

        protected override bool Filter(DataEntity entity)
        {
            return entity.hasKeyData;
        }

        protected override void Execute(List<DataEntity> entities)
        {
            foreach (var dataEnt in entities)
            {
                var dictionary = new Dictionary<string, object>();

                foreach (var component in dataEnt.GetComponents())
                {
                    if (component is ISaveData saveData)
                    {
                        dictionary.Add(saveData.ToString(), saveData.GetValue);
                    }
                }

                PlayerPrefs.SetString(
                    dataEnt.keyData.Value,
                    JsonConvert.SerializeObject(dictionary, Formatting.Indented));
            }
        }
    }
}