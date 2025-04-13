using Entitas;
using FixedGame;

namespace FixedButton
{
    internal class FixedButtonReactionSystem : Systems
    {
        internal FixedButtonReactionSystem(Contexts contexts)
        {
            Add(new PlayerGroundCollisionSystem(contexts));
            Add(new JumpPlayerPressButtonSystem(contexts));
        }
    }
}
