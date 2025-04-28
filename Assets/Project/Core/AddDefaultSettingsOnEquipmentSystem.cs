using Entitas;
using System.Collections.Generic;

namespace Game
{
    internal class AddDefaultSettingsOnEquipmentSystem : ReactiveSystem<GameEntity>
    {
        private Contexts _context;

        public AddDefaultSettingsOnEquipmentSystem(Contexts contexts) : base (contexts.game)
        {
            _context = contexts;
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(GameMatcher.AllOf(GameMatcher.EquipmentType, GameMatcher.Count));
        }

        protected override bool Filter(GameEntity entity)
        {
            return entity.count.Value > 0 &&
                  !entity.hasMassByOneItem;
        }  

        protected override void Execute(List<GameEntity> entities)
        {
            foreach (var equipmentEnt in entities) 
            {
                foreach (var equipmentSetting in ConfigsManager.EquipmentConfig.EquipmentSettings)
                {
                    if (equipmentEnt.equipmentType.Value == equipmentSetting.Type)
                    {
                        equipmentEnt.AddMassByOneItem(equipmentSetting.Mass);
                        equipmentEnt.AddMaxCountInStack(equipmentSetting.MaxCountInStack);
                        equipmentEnt.AddEquipmentKey(equipmentEnt.equipmentType.Value.ToString());

                        if (equipmentSetting.Material != null)
                            equipmentEnt.ReplaceModelMaterial(equipmentSetting.Material);
                        
                        break;
                    }
                }
            }
        } 
    }
}