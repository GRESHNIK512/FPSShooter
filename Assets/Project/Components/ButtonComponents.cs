using Entitas;
using Entitas.CodeGeneration.Attributes;

namespace Ui
{
    [Ui]
    public class ButtonComponent : IComponent { } 

    [Ui]
    public class IndexComponent : IComponent 
    {
        public int Value;
    }

    [Game, Ui, Cleanup(CleanupMode.RemoveComponent)]
    public class TrigTryPlayerClickComponent : IComponent { }

    [Ui, Cleanup(CleanupMode.RemoveComponent)]
    public class TrigButtonUpComponent : IComponent { }

    //buttons
    [Ui]
    public class StartGameButtonComponent : IComponent { }

    [Ui]
    public class JumpPlayerButtonComponent : IComponent { }

    [Ui]
    public class SitDownButtonComponent : IComponent { }

    [Ui]
    public class ShootButtonComponent : IComponent { }

    [Ui]
    public class NextLevelButtonComponent : IComponent { }

    [Ui]
    public class MainMenuButtonComponent : IComponent { }

    [Ui]
    public class CloseGameLevelButtonComponent : IComponent { }

    [Ui]
    public class WeaponSlotButtonComponent : IComponent { }

    [Ui]
    public class ReloadButtonComponent : IComponent { }
}