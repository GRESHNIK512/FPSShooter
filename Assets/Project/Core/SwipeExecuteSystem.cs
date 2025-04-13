using Entitas;
using UnityEngine;

namespace InputSys
{
    internal class SwipeExecuteSystem : IExecuteSystem
    {
        private Contexts _context;
        private IGroup<InputEntity> _inputGroup;
        private Vector2 _lastMousePosition; 

        public SwipeExecuteSystem(Contexts contexts)
        {
            _context = contexts;
            _inputGroup = _context.input.GetGroup(InputMatcher.Input); 
        }

        public void Execute()
        {
            HandleTouchInput();
#if UNITY_EDITOR
            HandleMouseInput();
#endif
        }

        private void HandleTouchInput()
        {
            if (Input.touchCount > 0)
            {
                foreach (Touch touch in Input.touches)
                {
                    // Проверяем, что касание в правой части экрана
                    if (touch.position.x > Screen.width * (1 - ConfigsManager.PlayerConfig.RightPersentScreenArea))
                    {
                        foreach (var inputEnt in _inputGroup.GetEntities())
                        {
                            switch (touch.phase)
                            {
                                case TouchPhase.Began:
                                //    touchStartPosition = touch.position;
                                //    isRotating = true;
                                      break;

                                case TouchPhase.Moved:
                                    //_context.ui.inputEntity.ReplaceTouc
                                    //currentTouchDelta = touch.deltaPosition; 
                                    inputEnt.ReplaceTouchDeltaPosition(touch.deltaPosition);
                                    //RotateCamera(currentTouchDelta);
                                    break;

                                case TouchPhase.Ended:
                                case TouchPhase.Canceled:
                                    //isRotating = false;
                                    if (inputEnt.hasTouchDeltaPosition) inputEnt.touchDeltaPosition.Value = Vector2.zero;
                                    //currentTouchDelta = Vector2.zero;
                                    break;
                            }
                        }
                    }
                }
            }
        }

        private void HandleMouseInput() 
        {
            if (Input.GetMouseButton(0)) // Левая кнопка мыши
            {
                Vector2 mousePosition = Input.mousePosition;

                if (mousePosition.x > Screen.width * (1 - ConfigsManager.PlayerConfig.RightPersentScreenArea))
                {
                    foreach (var inputEnt in _inputGroup.GetEntities())
                    {
                        if (Input.GetMouseButtonDown(0)) // Аналог TouchPhase.Began
                        {
                            // Обработка начала касания
                            _lastMousePosition = Input.mousePosition;
                        }
                        else if (Input.GetMouseButton(0)) // Аналог TouchPhase.Moved
                        { 
                            // Для deltaPosition можно использовать разницу между кадрами
                            Vector2 currentPos = Input.mousePosition; 
                            Vector2 delta = currentPos - _lastMousePosition;
                            _lastMousePosition = currentPos;

                            inputEnt.ReplaceTouchDeltaPosition(delta);
                        }
                        else if (Input.GetMouseButtonUp(0)) // Аналог TouchPhase.Ended
                        {
                            if (inputEnt.hasTouchDeltaPosition)
                                inputEnt.touchDeltaPosition.Value = Vector2.zero;
                        }
                    }
                }
            }
        }
    }
}