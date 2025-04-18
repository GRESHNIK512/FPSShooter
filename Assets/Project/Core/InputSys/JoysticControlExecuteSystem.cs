using Entitas;
using UnityEngine;

namespace InputSys
{
    internal class JoysticControlExecuteSystem : IExecuteSystem
    {
        private Contexts _context;
        private IGroup<UiEntity> _joysticGroup;

        public JoysticControlExecuteSystem(Contexts contexts)
        {
            _context = contexts;
            _joysticGroup = _context.ui.GetGroup(UiMatcher.Joystick);
        }

        public void Execute()
        {
            foreach (var joysticEnt in _joysticGroup.GetEntities())
            {
                if (joysticEnt.joystick.Value.Direction.magnitude > 0.01f)
                {
                    joysticEnt.ReplaceJoystickDirection(joysticEnt.joystick.Value.Direction);
                }
                else if (joysticEnt.hasJoystickDirection)
                {
                    var joystickDir = joysticEnt.joystickDirection.Value;
                    if (joystickDir.magnitude > 0.001f)
                    { 
                        joysticEnt.ReplaceJoystickDirection(joystickDir - joystickDir * Time.deltaTime * 8);
                    }
                }
            }
        }
    }
}