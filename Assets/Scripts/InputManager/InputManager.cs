using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : IInputManager 
{
    private static InputManager instance;
    public static IInputManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new InputManager();
                instance.Init();
            }
            return instance;
        }
    }

    private InputControls inputControls;
    
    private void Init()
    {
        inputControls = new InputControls();
        playActionsReader = new PlayActionsReader();
        uiActionsReader = new UIActionsReader();
        selectActionsReader = new SelectActionsReader();
        inputControls.Play.SetCallbacks(playActionsReader);
        inputControls.UI.SetCallbacks(uiActionsReader);
        inputControls.Select.SetCallbacks(selectActionsReader);
        moveInput = new List<Vector2>();
        useInput = new List<float>();
    }

    public Vector2Int GetInput_move(int playerIndex)
    {
        if(-1 < moveInput[playerIndex].x && moveInput[playerIndex].x <= 0 && 0 < moveInput[playerIndex].y && moveInput[playerIndex].y <= 1)
        {
            return CameraManager.Instance.GetOffsetY() * -1;
        }
        else if(0 < moveInput[playerIndex].x && moveInput[playerIndex].x <= 1 && 0 <= moveInput[playerIndex].y && moveInput[playerIndex].y < 1)
        {
            return CameraManager.Instance.GetOffsetX() * -1;
        }
        else if(-1 <= moveInput[playerIndex].x && moveInput[playerIndex].x < 0 && -1 < moveInput[playerIndex].y && moveInput[playerIndex].y <= 0)
        {
            return CameraManager.Instance.GetOffsetX();
        }
        else if(0 <= moveInput[playerIndex].x && moveInput[playerIndex].x < 1 && -1 <= moveInput[playerIndex].y && moveInput[playerIndex].y < 0)
        {
            return CameraManager.Instance.GetOffsetY();
        }
        else
        {
            return Vector2Int.zero;
        }
    }

    public bool GetInput_use(int playerIndex)
    {
        float cacheTime = 0.1f;
        if(Time.time - useInput[playerIndex] < cacheTime)
        {
            useInput[playerIndex] = 0;
            return true;
        }
        else
        {
            return false;
        }
    }

    List<Vector2> moveInput ;
    List<float> useInput ;
    PlayActionsReader playActionsReader ;
    UIActionsReader uiActionsReader ;
    SelectActionsReader selectActionsReader ;

    private class PlayActionsReader : InputControls.IPlayActions
    {
        void InputControls.IPlayActions.OnMove_0(UnityEngine.InputSystem.InputAction.CallbackContext context)
        {
            if(context.started)
            {
                instance.moveInput[0] = context.ReadValue<Vector2>();
            }
            else if(context.canceled)
            {
                instance.moveInput[0] = Vector2.zero;
            }
        }

        void InputControls.IPlayActions.OnMove_1(UnityEngine.InputSystem.InputAction.CallbackContext context)
        {
            if(context.started)
            {
                instance.moveInput[1] = context.ReadValue<Vector2>();
            }
            else if(context.canceled)
            {
                instance.moveInput[1] = Vector2.zero;
            }
        }

        void InputControls.IPlayActions.OnUse_0(UnityEngine.InputSystem.InputAction.CallbackContext context)
        {
            if(context.started)
            {
                instance.useInput[0] = Time.time;
            }
            else if(context.canceled)
            {
                instance.useInput[0] = 0;
            }
        }

        void InputControls.IPlayActions.OnUse_1(UnityEngine.InputSystem.InputAction.CallbackContext context)
        {
            if(context.started)
            {
                instance.useInput[1] = Time.time;
            }
            else if(context.canceled)
            {
                instance.useInput[1] = 0;
            }
        }
    }
    private class UIActionsReader : InputControls.IUIActions
    {

    }
    private class SelectActionsReader : InputControls.ISelectActions
    {
        void InputControls.ISelectActions.OnMove_0(UnityEngine.InputSystem.InputAction.CallbackContext context)
        {
            throw new System.NotImplementedException();
        }

        void InputControls.ISelectActions.OnMove_1(UnityEngine.InputSystem.InputAction.CallbackContext context)
        {
            throw new System.NotImplementedException();
        }

        void InputControls.ISelectActions.OnUse_0(UnityEngine.InputSystem.InputAction.CallbackContext context)
        {
            throw new System.NotImplementedException();
        }

        void InputControls.ISelectActions.OnUse_1(UnityEngine.InputSystem.InputAction.CallbackContext context)
        {
            throw new System.NotImplementedException();
        }
    }

}
