using Entitas;

namespace Button
{
    internal class ButtonControlSystems : Systems
    {
        internal ButtonControlSystems(Contexts contexts)
        {
            //UI
            Add(new GameStartPressButtonSystem(contexts));
            
            Add(new SitDownPressButtonSystem(contexts));

            Add(new ShootPressButtonSystem(contexts));
            Add(new ShootPressUpButtonSystem(contexts));  
           
            Add(new WeaponSlotPressButtonSystem(contexts));
            Add(new ReloadPressButtonSystem(contexts)); 

            Add(new CloseGameLevelPressButtonSystem(contexts));
            Add(new MainMenuPressButtonSystem(contexts));
            Add(new NextLevelPressButtonSystem(contexts)); 

            Add(new ClearButtonClickSystem(contexts));
        }
    }
}