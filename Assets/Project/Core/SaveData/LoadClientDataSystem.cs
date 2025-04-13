using Entitas;
using System.Collections.Generic;

namespace SaveData
{
    internal class LoadClientDataSystem : ReactiveSystem<DataEntity>
    {
        private Contexts _context;

        public LoadClientDataSystem(Contexts contexts) : base (contexts.data)
        {
            _context = contexts;
        }

        protected override ICollector<DataEntity> GetTrigger(IContext<DataEntity> context)
        {
            return context.CreateCollector(DataMatcher.DataLoadFail);
        }

        protected override bool Filter(DataEntity entity)
        {
            return entity.isClientData;
        } 

        protected override void Execute(List<DataEntity> entities)
        {
            foreach (var clientData in entities) 
            {
                clientData.AddCurrentSceneIndex(0);
                clientData.AddLevelCompleteCount(0);
                clientData.isSaveData = true;
                clientData.isDataLoadComplete = true;
            }
        } 
    }
}