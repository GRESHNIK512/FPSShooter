using Entitas;

namespace SaveData
{
    internal class SaveDataSystems : Systems
    {
        internal SaveDataSystems(Contexts contexts)
        {  
            Add(new SaveDataSystem(contexts));
            Add(new LoadDataSystem(contexts));

            Add(new LoadClientDataSystem(contexts));  
            //Add(new LoadDataSuccessfulLevelManagerSystem(contexts));
        }
    }
}