using Entitas;
using Entitas.CodeGeneration.Attributes;

namespace Ui
{
    [Ui]
    public class ButtonComponent : IComponent { }  

    [Game, Ui, Cleanup(CleanupMode.RemoveComponent)]
    public class TrigTryPlayerClickComponent : IComponent { }

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
}