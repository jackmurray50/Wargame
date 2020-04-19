// GENERATED AUTOMATICALLY FROM 'Assets/Scripts/inputHandlers/InputMaster.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @InputMaster : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @InputMaster()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""InputMaster"",
    ""maps"": [
        {
            ""name"": ""battleInputs"",
            ""id"": ""f53ef063-473a-4c8f-9311-491882f9c61c"",
            ""actions"": [
                {
                    ""name"": ""CameraMovement"",
                    ""type"": ""Button"",
                    ""id"": ""279b1520-1a48-4dca-a8e6-5f474ffa191d"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""CameraRotation"",
                    ""type"": ""Button"",
                    ""id"": ""d6028ba5-a6e5-4e2e-86ce-8ad30c5ee038"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""CameraZoom"",
                    ""type"": ""Value"",
                    ""id"": ""a283be37-6e79-4de7-9622-90b3b082644d"",
                    ""expectedControlType"": ""Analog"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""MousePosition"",
                    ""type"": ""Value"",
                    ""id"": ""88dee345-7ea6-419b-9823-91eb592b28f8"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""wasd"",
                    ""id"": ""76e28a23-cb35-4dcb-b90e-2f6b6a4e5a57"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""CameraMovement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""cb5a6f9d-02fc-4713-9649-c8828d1fd865"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and Mouse"",
                    ""action"": ""CameraMovement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""0ce3f4ce-e3ef-49ee-bbb5-60c01bc03809"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and Mouse"",
                    ""action"": ""CameraMovement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""6c295336-1e0e-458d-bade-c3210f2e0f71"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and Mouse"",
                    ""action"": ""CameraMovement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""912cbbfa-7a5b-4787-a25e-d9acf31b5854"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and Mouse"",
                    ""action"": ""CameraMovement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Rotation"",
                    ""id"": ""4f9bcd72-89a5-4bf0-89b6-ebf07e368b4c"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""CameraRotation"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""956466e8-d1a1-420e-bffe-7acbd4a9a89c"",
                    ""path"": ""<Keyboard>/q"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and Mouse"",
                    ""action"": ""CameraRotation"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""0c6846a6-ef19-4835-b660-eee222883044"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and Mouse"",
                    ""action"": ""CameraRotation"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""30c4c303-9cec-47b6-8816-89b2f42377dc"",
                    ""path"": ""<Mouse>/scroll/y"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and Mouse"",
                    ""action"": ""CameraZoom"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""5302ca67-e197-4267-a8af-0f77c138f8a4"",
                    ""path"": ""<Mouse>/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and Mouse"",
                    ""action"": ""MousePosition"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""Keyboard and Mouse"",
            ""bindingGroup"": ""Keyboard and Mouse"",
            ""devices"": [
                {
                    ""devicePath"": ""<Keyboard>"",
                    ""isOptional"": false,
                    ""isOR"": false
                },
                {
                    ""devicePath"": ""<Mouse>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
        // battleInputs
        m_battleInputs = asset.FindActionMap("battleInputs", throwIfNotFound: true);
        m_battleInputs_CameraMovement = m_battleInputs.FindAction("CameraMovement", throwIfNotFound: true);
        m_battleInputs_CameraRotation = m_battleInputs.FindAction("CameraRotation", throwIfNotFound: true);
        m_battleInputs_CameraZoom = m_battleInputs.FindAction("CameraZoom", throwIfNotFound: true);
        m_battleInputs_MousePosition = m_battleInputs.FindAction("MousePosition", throwIfNotFound: true);
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

    // battleInputs
    private readonly InputActionMap m_battleInputs;
    private IBattleInputsActions m_BattleInputsActionsCallbackInterface;
    private readonly InputAction m_battleInputs_CameraMovement;
    private readonly InputAction m_battleInputs_CameraRotation;
    private readonly InputAction m_battleInputs_CameraZoom;
    private readonly InputAction m_battleInputs_MousePosition;
    public struct BattleInputsActions
    {
        private @InputMaster m_Wrapper;
        public BattleInputsActions(@InputMaster wrapper) { m_Wrapper = wrapper; }
        public InputAction @CameraMovement => m_Wrapper.m_battleInputs_CameraMovement;
        public InputAction @CameraRotation => m_Wrapper.m_battleInputs_CameraRotation;
        public InputAction @CameraZoom => m_Wrapper.m_battleInputs_CameraZoom;
        public InputAction @MousePosition => m_Wrapper.m_battleInputs_MousePosition;
        public InputActionMap Get() { return m_Wrapper.m_battleInputs; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(BattleInputsActions set) { return set.Get(); }
        public void SetCallbacks(IBattleInputsActions instance)
        {
            if (m_Wrapper.m_BattleInputsActionsCallbackInterface != null)
            {
                @CameraMovement.started -= m_Wrapper.m_BattleInputsActionsCallbackInterface.OnCameraMovement;
                @CameraMovement.performed -= m_Wrapper.m_BattleInputsActionsCallbackInterface.OnCameraMovement;
                @CameraMovement.canceled -= m_Wrapper.m_BattleInputsActionsCallbackInterface.OnCameraMovement;
                @CameraRotation.started -= m_Wrapper.m_BattleInputsActionsCallbackInterface.OnCameraRotation;
                @CameraRotation.performed -= m_Wrapper.m_BattleInputsActionsCallbackInterface.OnCameraRotation;
                @CameraRotation.canceled -= m_Wrapper.m_BattleInputsActionsCallbackInterface.OnCameraRotation;
                @CameraZoom.started -= m_Wrapper.m_BattleInputsActionsCallbackInterface.OnCameraZoom;
                @CameraZoom.performed -= m_Wrapper.m_BattleInputsActionsCallbackInterface.OnCameraZoom;
                @CameraZoom.canceled -= m_Wrapper.m_BattleInputsActionsCallbackInterface.OnCameraZoom;
                @MousePosition.started -= m_Wrapper.m_BattleInputsActionsCallbackInterface.OnMousePosition;
                @MousePosition.performed -= m_Wrapper.m_BattleInputsActionsCallbackInterface.OnMousePosition;
                @MousePosition.canceled -= m_Wrapper.m_BattleInputsActionsCallbackInterface.OnMousePosition;
            }
            m_Wrapper.m_BattleInputsActionsCallbackInterface = instance;
            if (instance != null)
            {
                @CameraMovement.started += instance.OnCameraMovement;
                @CameraMovement.performed += instance.OnCameraMovement;
                @CameraMovement.canceled += instance.OnCameraMovement;
                @CameraRotation.started += instance.OnCameraRotation;
                @CameraRotation.performed += instance.OnCameraRotation;
                @CameraRotation.canceled += instance.OnCameraRotation;
                @CameraZoom.started += instance.OnCameraZoom;
                @CameraZoom.performed += instance.OnCameraZoom;
                @CameraZoom.canceled += instance.OnCameraZoom;
                @MousePosition.started += instance.OnMousePosition;
                @MousePosition.performed += instance.OnMousePosition;
                @MousePosition.canceled += instance.OnMousePosition;
            }
        }
    }
    public BattleInputsActions @battleInputs => new BattleInputsActions(this);
    private int m_KeyboardandMouseSchemeIndex = -1;
    public InputControlScheme KeyboardandMouseScheme
    {
        get
        {
            if (m_KeyboardandMouseSchemeIndex == -1) m_KeyboardandMouseSchemeIndex = asset.FindControlSchemeIndex("Keyboard and Mouse");
            return asset.controlSchemes[m_KeyboardandMouseSchemeIndex];
        }
    }
    public interface IBattleInputsActions
    {
        void OnCameraMovement(InputAction.CallbackContext context);
        void OnCameraRotation(InputAction.CallbackContext context);
        void OnCameraZoom(InputAction.CallbackContext context);
        void OnMousePosition(InputAction.CallbackContext context);
    }
}
