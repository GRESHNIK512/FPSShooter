using Entitas;
using System.Collections.Generic;

namespace SaveData
{
    internal class LoadDataSuccessfulLevelManagerSystem : ReactiveSystem<DataEntity>
    {
        private Contexts _context;

        public LoadDataSuccessfulLevelManagerSystem(Contexts contexts) : base (contexts.data)
        {
            _context = contexts;
        }

        protected override ICollector<DataEntity> GetTrigger(IContext<DataEntity> context)
        {
            return context.CreateCollector(DataMatcher.DataLoadComplete);
        }

        protected override bool Filter(DataEntity entity)
        {
            return entity.isClientData;
        } 
       
        protected override void Execute(List<DataEntity> entities)
        {
            //foreach (var entity in entities) 
            //{
            
            //}
        } 
    }
}