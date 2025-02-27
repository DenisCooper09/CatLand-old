//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.4.4
//     from Assets/Input Actions/CatInputActions.inputactions
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

public partial class @CatInputActions : IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @CatInputActions()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""CatInputActions"",
    ""maps"": [
        {
            ""name"": ""Cat"",
            ""id"": ""c87aa898-4407-416c-a364-e17d7ef2d5ce"",
            ""actions"": [
                {
                    ""name"": ""Movement"",
                    ""type"": ""Value"",
                    ""id"": ""a12669ab-af3a-4d57-a33e-76d638f29c22"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""PointerPosition"",
                    ""type"": ""Value"",
                    ""id"": ""010e36b5-1e78-4f04-9e25-d424ad979e19"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Drop"",
                    ""type"": ""Button"",
                    ""id"": ""618c837a-509c-4d4d-8356-8539cf6a51e0"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""WASD"",
                    ""id"": ""178d158e-c066-421d-a2b7-9943d8eec035"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""63078045-a32f-4735-bea4-d7728f0d4ee9"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""4d7b7119-03e4-4432-8205-8a8f8af5f38d"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""86ac1f44-4027-474d-af50-250e0e7517e6"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""7d32d8e6-e26d-4d6f-bd2f-1281aea88f6c"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Arrows"",
                    ""id"": ""63936a13-f13c-4cf3-89e2-87d71a4240a9"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""1a9004e1-aeea-4cfe-8e50-d8c8d2b09446"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""0416d369-654d-48ba-8ccf-db0686a0f807"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""b91a1725-de08-43d3-bd3f-cae1e360d1e4"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""8a7ee89a-7cda-45df-a371-3b84f21d9722"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""18cde893-9734-4c3b-9307-e46b439fbd3d"",
                    ""path"": ""<Mouse>/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""PointerPosition"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""1dc5f4c2-ae33-4edd-8734-3170486b71d2"",
                    ""path"": ""<Keyboard>/q"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Drop"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Cat
        m_Cat = asset.FindActionMap("Cat", throwIfNotFound: true);
        m_Cat_Movement = m_Cat.FindAction("Movement", throwIfNotFound: true);
        m_Cat_PointerPosition = m_Cat.FindAction("PointerPosition", throwIfNotFound: true);
        m_Cat_Drop = m_Cat.FindAction("Drop", throwIfNotFound: true);
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

    // Cat
    private readonly InputActionMap m_Cat;
    private ICatActions m_CatActionsCallbackInterface;
    private readonly InputAction m_Cat_Movement;
    private readonly InputAction m_Cat_PointerPosition;
    private readonly InputAction m_Cat_Drop;
    public struct CatActions
    {
        private @CatInputActions m_Wrapper;
        public CatActions(@CatInputActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @Movement => m_Wrapper.m_Cat_Movement;
        public InputAction @PointerPosition => m_Wrapper.m_Cat_PointerPosition;
        public InputAction @Drop => m_Wrapper.m_Cat_Drop;
        public InputActionMap Get() { return m_Wrapper.m_Cat; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(CatActions set) { return set.Get(); }
        public void SetCallbacks(ICatActions instance)
        {
            if (m_Wrapper.m_CatActionsCallbackInterface != null)
            {
                @Movement.started -= m_Wrapper.m_CatActionsCallbackInterface.OnMovement;
                @Movement.performed -= m_Wrapper.m_CatActionsCallbackInterface.OnMovement;
                @Movement.canceled -= m_Wrapper.m_CatActionsCallbackInterface.OnMovement;
                @PointerPosition.started -= m_Wrapper.m_CatActionsCallbackInterface.OnPointerPosition;
                @PointerPosition.performed -= m_Wrapper.m_CatActionsCallbackInterface.OnPointerPosition;
                @PointerPosition.canceled -= m_Wrapper.m_CatActionsCallbackInterface.OnPointerPosition;
                @Drop.started -= m_Wrapper.m_CatActionsCallbackInterface.OnDrop;
                @Drop.performed -= m_Wrapper.m_CatActionsCallbackInterface.OnDrop;
                @Drop.canceled -= m_Wrapper.m_CatActionsCallbackInterface.OnDrop;
            }
            m_Wrapper.m_CatActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Movement.started += instance.OnMovement;
                @Movement.performed += instance.OnMovement;
                @Movement.canceled += instance.OnMovement;
                @PointerPosition.started += instance.OnPointerPosition;
                @PointerPosition.performed += instance.OnPointerPosition;
                @PointerPosition.canceled += instance.OnPointerPosition;
                @Drop.started += instance.OnDrop;
                @Drop.performed += instance.OnDrop;
                @Drop.canceled += instance.OnDrop;
            }
        }
    }
    public CatActions @Cat => new CatActions(this);
    public interface ICatActions
    {
        void OnMovement(InputAction.CallbackContext context);
        void OnPointerPosition(InputAction.CallbackContext context);
        void OnDrop(InputAction.CallbackContext context);
    }
}
