using Entitas;

namespace Button
{
    internal class ButtonControlSystems : Systems
    {
        internal ButtonControlSystems(Contexts contexts)
        {
            //UI
            Add(new GameStartPressButtonSystem(contexts));
            //Add(new GameClosePressButtonSystem(contexts));
            Add(new SitDownPressButtonSystem(contexts));

            Add(new ShootPressButtonSystem(contexts));

            Add(new NextLevelPressButtonSystem(contexts));
            Add(new MainMenuPressButtonSystem(contexts));
        }
    }
}