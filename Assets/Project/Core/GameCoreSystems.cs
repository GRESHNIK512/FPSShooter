using Entitas;

namespace Core
{ 
    internal class GameCoreSystems : Systems
    {  
        internal GameCoreSystems(Contexts contexts)
        {
            Add(new AppStartGroupSystems(contexts));

            Add(new SaveData.SaveDataSystems(contexts)); 
            
            Add(new InputSys.InputSystems(contexts));
           
            Add(new Button.ButtonControlSystems(contexts));
           
            Add(new WindowControlSystems(contexts));
            
            Add(new TimerControlSystems(contexts));
            
            Add(new Game.GameControlSystems(contexts));  

            //AutoGenerate
            Add(new DataEventSystems(contexts));
            Add(new DataCleanupSystems(contexts));

            Add(new UiEventSystems(contexts));
            Add(new UiCleanupSystems(contexts));

            Add(new GameEventSystems(contexts));
            Add(new GameCleanupSystems(contexts));

            Add(new InputEventSystems(contexts));
            //Add(new InputCleanupSystems(contexts));
        }
    }
}   