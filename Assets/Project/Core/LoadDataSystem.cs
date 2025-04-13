using Entitas;
using Newtonsoft.Json;
using System.Collections.Generic;
using UnityEngine;

namespace SaveData
{
    internal class LoadDataSystem : ReactiveSystem<DataEntity>
    {
        private Contexts _context;

        public LoadDataSystem(Contexts contexts) : base(contexts.data)
        {
            _context = contexts;
        }

        protected override ICollector<DataEntity> GetTrigger(IContext<DataEntity> context)
        {
            return context.CreateCollector(DataMatcher.LoadData);
        }

        protected override bool Filter(DataEntity entity)
        {
            return entity.hasKeyData;
        }

        protected override void Execute(List<DataEntity> entities)
        {
            foreach (var dateEnt in entities)
            {
                var jsData = PlayerPrefs.GetString(dateEnt.keyData.Value, string.Empty);

                if (string.IsNullOrEmpty(jsData))
                {
                    dateEnt.isDataLoadFail = true;
                    continue;
                }

                var dictionary = JsonConvert.DeserializeObject<Dictionary<string, object>>(jsData);

                foreach (var item in dictionary)
                {
                    for (int i = 0; i < DataComponentsLookup.componentNames.Length; i++)
                    {
                        if (item.Key == DataComponentsLookup.componentTypes[i].ToString())
                        {
                            var saveDataComponent = System.Activator.CreateInstance(
                                DataComponentsLookup.componentTypes[i]);
                            var component = saveDataComponent as IComponent;
                            var saveData = saveDataComponent as ISaveData;

                            dateEnt.ReplaceComponent(i, component);

                            saveData?.SetValue(item.Value);
                        }
                    }
                } 
                dateEnt.isDataLoadComplete = true;
            }
        }
    }
}