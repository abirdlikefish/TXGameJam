//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.7.0
//     from Assets/Scripts/InputManager/InputControls.inputactions
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public partial class @InputControls: IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @InputControls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""InputControls"",
    ""maps"": [
        {
            ""name"": ""Play"",
            ""id"": ""f665a30e-b744-467f-9827-86f8206983cf"",
            ""actions"": [
                {
                    ""name"": ""Move_0"",
                    ""type"": ""Value"",
                    ""id"": ""8f7c86e5-f6db-4729-88b8-8cff9d607e2b"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Move_1"",
                    ""type"": ""Value"",
                    ""id"": ""d0df32eb-1b42-4bde-b835-876f76d3dd3b"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Use_0"",
                    ""type"": ""Button"",
                    ""id"": ""ab77b0f7-f1de-40dc-b562-7db89b8f4160"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Use_1"",
                    ""type"": ""Button"",
                    ""id"": ""d851631d-4b2a-4248-9f22-ced8f728a95d"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""4576ae11-cbe6-4b24-8265-972cdd0fd2b9"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move_0"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""68a2a6c0-d6a6-44d6-846d-9168a6be4381"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move_0"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""45e6f30f-d71a-4428-a515-843022d2a4e9"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move_0"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""9e2e017c-4d03-4f93-939c-1b0d9ee1960d"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move_0"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""1c142b70-fea4-407e-9749-5901940f3cf0"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move_0"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""bbf81203-21a9-4841-b02b-f2dc86633aa4"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move_1"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""21fbf1cf-7f07-4b50-9270-3384e6928cb4"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move_1"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""06cd9469-3a95-462e-a3f1-fa4038e2a8fd"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move_1"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""47975c75-c111-433d-a86b-17d3a9dcdcd5"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move_1"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""81025e06-0a9d-4496-a89c-797a33c9fbbe"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move_1"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""00146abe-89fe-43a3-993a-a74da1fef71f"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Use_0"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""000690bf-7876-4a81-8b22-3e516ba06e1c"",
                    ""path"": ""<Keyboard>/enter"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Use_1"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Select"",
            ""id"": ""d0a78330-2917-497a-8f98-03930b5434b0"",
            ""actions"": [
                {
                    ""name"": ""Move_0"",
                    ""type"": ""Value"",
                    ""id"": ""bbe7b8d7-b184-4fbc-ac63-943a130761f2"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Move_1"",
                    ""type"": ""Value"",
                    ""id"": ""17f14eb6-71d0-42f1-a0f3-a209906b83b5"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Use_0"",
                    ""type"": ""Button"",
                    ""id"": ""761bad6b-0bc8-40c8-a5f8-f4053070441a"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Use_1"",
                    ""type"": ""Button"",
                    ""id"": ""6c949e1b-e718-45c8-b573-e5a2fa118893"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""82e826ac-c3e0-4be3-8ad1-be925544cd6b"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move_0"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""Up"",
                    ""id"": ""d115400e-e014-4dd4-b97e-6e287c2ace10"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move_0"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Down"",
                    ""id"": ""92e586f0-e8a0-4697-988b-735ef0192002"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move_0"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Left"",
                    ""id"": ""a4c2e7e0-9995-478a-8924-1ee708f0573b"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move_0"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Right"",
                    ""id"": ""3b609da1-c396-4052-9c3a-a1a4ff5472da"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move_0"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""933d848d-63eb-4876-9fb3-f4082862ce37"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move_1"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""f028a4b8-a64c-40cb-b8d4-5cd4075361d7"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move_1"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""edb0dad7-b5f1-49d7-ad05-800eda5f65f0"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move_1"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""b8d4df9a-b9f7-4fe8-8d3b-b9ff3151fb6b"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move_1"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""49d7311d-45bd-4f11-806a-8e513b1dd6bf"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move_1"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""f5697a92-9f81-4735-b65e-306057f4af06"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Use_0"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""93fd1237-0dc4-41b5-87d0-490391c92883"",
                    ""path"": ""<Keyboard>/enter"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Use_1"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""UI"",
            ""id"": ""a48374b2-4d13-42b5-8264-e6cfec776217"",
            ""actions"": [],
            ""bindings"": []
        }
    ],
    ""controlSchemes"": []
}");
        // Play
        m_Play = asset.FindActionMap("Play", throwIfNotFound: true);
        m_Play_Move_0 = m_Play.FindAction("Move_0", throwIfNotFound: true);
        m_Play_Move_1 = m_Play.FindAction("Move_1", throwIfNotFound: true);
        m_Play_Use_0 = m_Play.FindAction("Use_0", throwIfNotFound: true);
        m_Play_Use_1 = m_Play.FindAction("Use_1", throwIfNotFound: true);
        // Select
        m_Select = asset.FindActionMap("Select", throwIfNotFound: true);
        m_Select_Move_0 = m_Select.FindAction("Move_0", throwIfNotFound: true);
        m_Select_Move_1 = m_Select.FindAction("Move_1", throwIfNotFound: true);
        m_Select_Use_0 = m_Select.FindAction("Use_0", throwIfNotFound: true);
        m_Select_Use_1 = m_Select.FindAction("Use_1", throwIfNotFound: true);
        // UI
        m_UI = asset.FindActionMap("UI", throwIfNotFound: true);
    }

    public void Dispose()
    {
        UnityEngine.Object.Destroy(asset);
    }

    public InputBinding? bindingMask
    {
        get => asset.bindingMask;
        set => asset.bindingMask = value;
    }

    public ReadOnlyArray<InputDevice>? devices
    {
        get => asset.devices;
        set => asset.devices = value;
    }

    public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

    public bool Contains(InputAction action)
    {
        return asset.Contains(action);
    }

    public IEnumerator<InputAction> GetEnumerator()
    {
        return asset.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Enable()
    {
        asset.Enable();
    }

    public void Disable()
    {
        asset.Disable();
    }

    public IEnumerable<InputBinding> bindings => asset.bindings;

    public InputAction FindAction(string actionNameOrId, bool throwIfNotFound = false)
    {
        return asset.FindAction(actionNameOrId, throwIfNotFound);
    }

    public int FindBinding(InputBinding bindingMask, out InputAction action)
    {
        return asset.FindBinding(bindingMask, out action);
    }

    // Play
    private readonly InputActionMap m_Play;
    private List<IPlayActions> m_PlayActionsCallbackInterfaces = new List<IPlayActions>();
    private readonly InputAction m_Play_Move_0;
    private readonly InputAction m_Play_Move_1;
    private readonly InputAction m_Play_Use_0;
    private readonly InputAction m_Play_Use_1;
    public struct PlayActions
    {
        private @InputControls m_Wrapper;
        public PlayActions(@InputControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move_0 => m_Wrapper.m_Play_Move_0;
        public InputAction @Move_1 => m_Wrapper.m_Play_Move_1;
        public InputAction @Use_0 => m_Wrapper.m_Play_Use_0;
        public InputAction @Use_1 => m_Wrapper.m_Play_Use_1;
        public InputActionMap Get() { return m_Wrapper.m_Play; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayActions set) { return set.Get(); }
        public void AddCallbacks(IPlayActions instance)
        {
            if (instance == null || m_Wrapper.m_PlayActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_PlayActionsCallbackInterfaces.Add(instance);
            @Move_0.started += instance.OnMove_0;
            @Move_0.performed += instance.OnMove_0;
            @Move_0.canceled += instance.OnMove_0;
            @Move_1.started += instance.OnMove_1;
            @Move_1.performed += instance.OnMove_1;
            @Move_1.canceled += instance.OnMove_1;
            @Use_0.started += instance.OnUse_0;
            @Use_0.performed += instance.OnUse_0;
            @Use_0.canceled += instance.OnUse_0;
            @Use_1.started += instance.OnUse_1;
            @Use_1.performed += instance.OnUse_1;
            @Use_1.canceled += instance.OnUse_1;
        }

        private void UnregisterCallbacks(IPlayActions instance)
        {
            @Move_0.started -= instance.OnMove_0;
            @Move_0.performed -= instance.OnMove_0;
            @Move_0.canceled -= instance.OnMove_0;
            @Move_1.started -= instance.OnMove_1;
            @Move_1.performed -= instance.OnMove_1;
            @Move_1.canceled -= instance.OnMove_1;
            @Use_0.started -= instance.OnUse_0;
            @Use_0.performed -= instance.OnUse_0;
            @Use_0.canceled -= instance.OnUse_0;
            @Use_1.started -= instance.OnUse_1;
            @Use_1.performed -= instance.OnUse_1;
            @Use_1.canceled -= instance.OnUse_1;
        }

        public void RemoveCallbacks(IPlayActions instance)
        {
            if (m_Wrapper.m_PlayActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IPlayActions instance)
        {
            foreach (var item in m_Wrapper.m_PlayActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_PlayActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public PlayActions @Play => new PlayActions(this);

    // Select
    private readonly InputActionMap m_Select;
    private List<ISelectActions> m_SelectActionsCallbackInterfaces = new List<ISelectActions>();
    private readonly InputAction m_Select_Move_0;
    private readonly InputAction m_Select_Move_1;
    private readonly InputAction m_Select_Use_0;
    private readonly InputAction m_Select_Use_1;
    public struct SelectActions
    {
        private @InputControls m_Wrapper;
        public SelectActions(@InputControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move_0 => m_Wrapper.m_Select_Move_0;
        public InputAction @Move_1 => m_Wrapper.m_Select_Move_1;
        public InputAction @Use_0 => m_Wrapper.m_Select_Use_0;
        public InputAction @Use_1 => m_Wrapper.m_Select_Use_1;
        public InputActionMap Get() { return m_Wrapper.m_Select; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(SelectActions set) { return set.Get(); }
        public void AddCallbacks(ISelectActions instance)
        {
            if (instance == null || m_Wrapper.m_SelectActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_SelectActionsCallbackInterfaces.Add(instance);
            @Move_0.started += instance.OnMove_0;
            @Move_0.performed += instance.OnMove_0;
            @Move_0.canceled += instance.OnMove_0;
            @Move_1.started += instance.OnMove_1;
            @Move_1.performed += instance.OnMove_1;
            @Move_1.canceled += instance.OnMove_1;
            @Use_0.started += instance.OnUse_0;
            @Use_0.performed += instance.OnUse_0;
            @Use_0.canceled += instance.OnUse_0;
            @Use_1.started += instance.OnUse_1;
            @Use_1.performed += instance.OnUse_1;
            @Use_1.canceled += instance.OnUse_1;
        }

        private void UnregisterCallbacks(ISelectActions instance)
        {
            @Move_0.started -= instance.OnMove_0;
            @Move_0.performed -= instance.OnMove_0;
            @Move_0.canceled -= instance.OnMove_0;
            @Move_1.started -= instance.OnMove_1;
            @Move_1.performed -= instance.OnMove_1;
            @Move_1.canceled -= instance.OnMove_1;
            @Use_0.started -= instance.OnUse_0;
            @Use_0.performed -= instance.OnUse_0;
            @Use_0.canceled -= instance.OnUse_0;
            @Use_1.started -= instance.OnUse_1;
            @Use_1.performed -= instance.OnUse_1;
            @Use_1.canceled -= instance.OnUse_1;
        }

        public void RemoveCallbacks(ISelectActions instance)
        {
            if (m_Wrapper.m_SelectActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(ISelectActions instance)
        {
            foreach (var item in m_Wrapper.m_SelectActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_SelectActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public SelectActions @Select => new SelectActions(this);

    // UI
    private readonly InputActionMap m_UI;
    private List<IUIActions> m_UIActionsCallbackInterfaces = new List<IUIActions>();
    public struct UIActions
    {
        private @InputControls m_Wrapper;
        public UIActions(@InputControls wrapper) { m_Wrapper = wrapper; }
        public InputActionMap Get() { return m_Wrapper.m_UI; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(UIActions set) { return set.Get(); }
        public void AddCallbacks(IUIActions instance)
        {
            if (instance == null || m_Wrapper.m_UIActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_UIActionsCallbackInterfaces.Add(instance);
        }

        private void UnregisterCallbacks(IUIActions instance)
        {
        }

        public void RemoveCallbacks(IUIActions instance)
        {
            if (m_Wrapper.m_UIActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IUIActions instance)
        {
            foreach (var item in m_Wrapper.m_UIActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_UIActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public UIActions @UI => new UIActions(this);
    public interface IPlayActions
    {
        void OnMove_0(InputAction.CallbackContext context);
        void OnMove_1(InputAction.CallbackContext context);
        void OnUse_0(InputAction.CallbackContext context);
        void OnUse_1(InputAction.CallbackContext context);
    }
    public interface ISelectActions
    {
        void OnMove_0(InputAction.CallbackContext context);
        void OnMove_1(InputAction.CallbackContext context);
        void OnUse_0(InputAction.CallbackContext context);
        void OnUse_1(InputAction.CallbackContext context);
    }
    public interface IUIActions
    {
    }
}
