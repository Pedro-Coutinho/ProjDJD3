// GENERATED AUTOMATICALLY FROM 'Assets/Scripts/Player/PlayerControls.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @PlayerControls : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerControls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerControls"",
    ""maps"": [
        {
            ""name"": ""Gameplay"",
            ""id"": ""f559a1a8-b89e-4b1a-a309-c70a030232e2"",
            ""actions"": [
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""e13b026a-c742-44bc-9070-61de590bfc94"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Move"",
                    ""type"": ""Value"",
                    ""id"": ""25638983-99a9-4376-8a10-0fddd98fc2ed"",
                    ""expectedControlType"": ""Stick"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""CameraMove"",
                    ""type"": ""Value"",
                    ""id"": ""bd5fee13-657d-4d57-b4d1-4996c000317a"",
                    ""expectedControlType"": ""Stick"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Roll"",
                    ""type"": ""Button"",
                    ""id"": ""4d1d6863-640d-47b3-b76f-fb0b4f49f157"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Shoot"",
                    ""type"": ""Button"",
                    ""id"": ""4e2cd505-20c2-4130-8459-f72a525de602"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Aim"",
                    ""type"": ""Button"",
                    ""id"": ""5d173ba5-af0d-4aa1-accc-711e728e0173"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""SwitchEnemy"",
                    ""type"": ""Button"",
                    ""id"": ""5eced0ce-a969-4d4f-8171-bf94a0d69cd4"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Interact"",
                    ""type"": ""Button"",
                    ""id"": ""c8f2866d-fb2f-492f-bb16-1ef892efbd87"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Abilitiy1"",
                    ""type"": ""Button"",
                    ""id"": ""db7d4e96-eb83-43df-8c4b-5a4c46d86f86"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""SlowTime"",
                    ""type"": ""Button"",
                    ""id"": ""c552861e-8b19-445f-a3a0-b07f51c18d5a"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Menu"",
                    ""type"": ""Button"",
                    ""id"": ""abce9b56-12ad-420d-a723-ffcda53bd99e"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Ability2"",
                    ""type"": ""Button"",
                    ""id"": ""fd262773-96c0-48af-8250-87ee30eced65"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""69c876d7-d9e8-4ae9-af45-50815fdd354b"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""befac1f7-64f1-46fc-8573-1a3d43f6bdf1"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""1f615756-23ee-4838-9c5e-663327da5d22"",
                    ""path"": ""<Gamepad>/rightStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""CameraMove"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ac80f55d-2f5b-493e-a651-e34b09dd391c"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Roll"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""0966d1ae-08fb-4739-812d-08a7f0872278"",
                    ""path"": ""<Gamepad>/rightTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Shoot"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""9767d7a3-3ee8-48b0-af53-e9bc5af72b10"",
                    ""path"": ""<Gamepad>/leftTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Aim"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""fb749ac1-f96e-4ebe-8cf5-16bb3568961b"",
                    ""path"": ""<Gamepad>/rightShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SwitchEnemy"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""55c56445-2282-4432-a424-20d996e9e249"",
                    ""path"": ""<Gamepad>/leftShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Interact"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""618eeae3-75a0-4e83-92c2-a3f969c94e40"",
                    ""path"": ""<Gamepad>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Abilitiy1"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""8efee540-9e17-4b1e-a104-f9e1e4c7a4d2"",
                    ""path"": ""<Gamepad>/rightStickPress"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SlowTime"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""bd12b731-45b9-4982-82dc-43499b890cab"",
                    ""path"": ""<Gamepad>/start"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Menu"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""81b3df00-b4f2-4ad3-b28c-0b7f96054133"",
                    ""path"": ""<Gamepad>/buttonNorth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Ability2"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Menu"",
            ""id"": ""9457bf7b-3be9-4691-9c03-29158ffa4621"",
            ""actions"": [
                {
                    ""name"": ""NavigationUp"",
                    ""type"": ""Button"",
                    ""id"": ""0e3c6f79-c8dc-4307-8127-26c55e5be407"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Exit"",
                    ""type"": ""Button"",
                    ""id"": ""86b67415-6608-4f24-a455-fa2fe0933237"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Enter"",
                    ""type"": ""Button"",
                    ""id"": ""3fca48c6-782a-471d-af74-1fc00e2a73d9"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""NavigationDown"",
                    ""type"": ""Button"",
                    ""id"": ""7de05681-9688-4528-9e53-c83c2a1034c0"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""NavigationLeft"",
                    ""type"": ""Button"",
                    ""id"": ""6d72a243-022b-4126-82f1-1fb03dc37959"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""NavigationRight"",
                    ""type"": ""Button"",
                    ""id"": ""a56c2dfd-dc18-4e83-8850-d8bac23406a6"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Navigate"",
                    ""type"": ""PassThrough"",
                    ""id"": ""bb276113-50ca-4bbb-b3bd-2fd2eaa1022c"",
                    ""expectedControlType"": ""Stick"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""1b84aed8-8989-45f3-a884-b35b0db0d9ed"",
                    ""path"": ""<Gamepad>/leftStick/up"",
                    ""interactions"": """",
                    ""processors"": ""AxisDeadzone"",
                    ""groups"": """",
                    ""action"": ""NavigationUp"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""08ac4381-4b70-4b4d-9d77-6ab903e336b8"",
                    ""path"": ""<Gamepad>/start"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Exit"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ecf95a91-0b3f-4868-b1df-454ba607d266"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Enter"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""5729af99-9eac-4af1-ad25-73e6f0ad6c6c"",
                    ""path"": ""<Gamepad>/leftStick/down"",
                    ""interactions"": """",
                    ""processors"": ""AxisDeadzone"",
                    ""groups"": """",
                    ""action"": ""NavigationDown"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f7c51ec2-feb3-4630-a300-4fe91e35239d"",
                    ""path"": ""<Gamepad>/leftStick/left"",
                    ""interactions"": """",
                    ""processors"": ""AxisDeadzone"",
                    ""groups"": """",
                    ""action"": ""NavigationLeft"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""99fe5e8d-1cf2-4be9-9acc-86496b345813"",
                    ""path"": ""<Gamepad>/leftStick/right"",
                    ""interactions"": """",
                    ""processors"": ""AxisDeadzone"",
                    ""groups"": """",
                    ""action"": ""NavigationRight"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b4756525-6aa9-4809-b276-3fcf97688e0c"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Gameplay
        m_Gameplay = asset.FindActionMap("Gameplay", throwIfNotFound: true);
        m_Gameplay_Jump = m_Gameplay.FindAction("Jump", throwIfNotFound: true);
        m_Gameplay_Move = m_Gameplay.FindAction("Move", throwIfNotFound: true);
        m_Gameplay_CameraMove = m_Gameplay.FindAction("CameraMove", throwIfNotFound: true);
        m_Gameplay_Roll = m_Gameplay.FindAction("Roll", throwIfNotFound: true);
        m_Gameplay_Shoot = m_Gameplay.FindAction("Shoot", throwIfNotFound: true);
        m_Gameplay_Aim = m_Gameplay.FindAction("Aim", throwIfNotFound: true);
        m_Gameplay_SwitchEnemy = m_Gameplay.FindAction("SwitchEnemy", throwIfNotFound: true);
        m_Gameplay_Interact = m_Gameplay.FindAction("Interact", throwIfNotFound: true);
        m_Gameplay_Abilitiy1 = m_Gameplay.FindAction("Abilitiy1", throwIfNotFound: true);
        m_Gameplay_SlowTime = m_Gameplay.FindAction("SlowTime", throwIfNotFound: true);
        m_Gameplay_Menu = m_Gameplay.FindAction("Menu", throwIfNotFound: true);
        m_Gameplay_Ability2 = m_Gameplay.FindAction("Ability2", throwIfNotFound: true);
        // Menu
        m_Menu = asset.FindActionMap("Menu", throwIfNotFound: true);
        m_Menu_NavigationUp = m_Menu.FindAction("NavigationUp", throwIfNotFound: true);
        m_Menu_Exit = m_Menu.FindAction("Exit", throwIfNotFound: true);
        m_Menu_Enter = m_Menu.FindAction("Enter", throwIfNotFound: true);
        m_Menu_NavigationDown = m_Menu.FindAction("NavigationDown", throwIfNotFound: true);
        m_Menu_NavigationLeft = m_Menu.FindAction("NavigationLeft", throwIfNotFound: true);
        m_Menu_NavigationRight = m_Menu.FindAction("NavigationRight", throwIfNotFound: true);
        m_Menu_Navigate = m_Menu.FindAction("Navigate", throwIfNotFound: true);
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

    // Gameplay
    private readonly InputActionMap m_Gameplay;
    private IGameplayActions m_GameplayActionsCallbackInterface;
    private readonly InputAction m_Gameplay_Jump;
    private readonly InputAction m_Gameplay_Move;
    private readonly InputAction m_Gameplay_CameraMove;
    private readonly InputAction m_Gameplay_Roll;
    private readonly InputAction m_Gameplay_Shoot;
    private readonly InputAction m_Gameplay_Aim;
    private readonly InputAction m_Gameplay_SwitchEnemy;
    private readonly InputAction m_Gameplay_Interact;
    private readonly InputAction m_Gameplay_Abilitiy1;
    private readonly InputAction m_Gameplay_SlowTime;
    private readonly InputAction m_Gameplay_Menu;
    private readonly InputAction m_Gameplay_Ability2;
    public struct GameplayActions
    {
        private @PlayerControls m_Wrapper;
        public GameplayActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Jump => m_Wrapper.m_Gameplay_Jump;
        public InputAction @Move => m_Wrapper.m_Gameplay_Move;
        public InputAction @CameraMove => m_Wrapper.m_Gameplay_CameraMove;
        public InputAction @Roll => m_Wrapper.m_Gameplay_Roll;
        public InputAction @Shoot => m_Wrapper.m_Gameplay_Shoot;
        public InputAction @Aim => m_Wrapper.m_Gameplay_Aim;
        public InputAction @SwitchEnemy => m_Wrapper.m_Gameplay_SwitchEnemy;
        public InputAction @Interact => m_Wrapper.m_Gameplay_Interact;
        public InputAction @Abilitiy1 => m_Wrapper.m_Gameplay_Abilitiy1;
        public InputAction @SlowTime => m_Wrapper.m_Gameplay_SlowTime;
        public InputAction @Menu => m_Wrapper.m_Gameplay_Menu;
        public InputAction @Ability2 => m_Wrapper.m_Gameplay_Ability2;
        public InputActionMap Get() { return m_Wrapper.m_Gameplay; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(GameplayActions set) { return set.Get(); }
        public void SetCallbacks(IGameplayActions instance)
        {
            if (m_Wrapper.m_GameplayActionsCallbackInterface != null)
            {
                @Jump.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnJump;
                @Jump.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnJump;
                @Jump.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnJump;
                @Move.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMove;
                @Move.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMove;
                @Move.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMove;
                @CameraMove.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnCameraMove;
                @CameraMove.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnCameraMove;
                @CameraMove.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnCameraMove;
                @Roll.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnRoll;
                @Roll.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnRoll;
                @Roll.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnRoll;
                @Shoot.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnShoot;
                @Shoot.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnShoot;
                @Shoot.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnShoot;
                @Aim.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnAim;
                @Aim.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnAim;
                @Aim.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnAim;
                @SwitchEnemy.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnSwitchEnemy;
                @SwitchEnemy.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnSwitchEnemy;
                @SwitchEnemy.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnSwitchEnemy;
                @Interact.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnInteract;
                @Interact.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnInteract;
                @Interact.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnInteract;
                @Abilitiy1.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnAbilitiy1;
                @Abilitiy1.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnAbilitiy1;
                @Abilitiy1.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnAbilitiy1;
                @SlowTime.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnSlowTime;
                @SlowTime.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnSlowTime;
                @SlowTime.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnSlowTime;
                @Menu.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMenu;
                @Menu.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMenu;
                @Menu.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMenu;
                @Ability2.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnAbility2;
                @Ability2.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnAbility2;
                @Ability2.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnAbility2;
            }
            m_Wrapper.m_GameplayActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Jump.started += instance.OnJump;
                @Jump.performed += instance.OnJump;
                @Jump.canceled += instance.OnJump;
                @Move.started += instance.OnMove;
                @Move.performed += instance.OnMove;
                @Move.canceled += instance.OnMove;
                @CameraMove.started += instance.OnCameraMove;
                @CameraMove.performed += instance.OnCameraMove;
                @CameraMove.canceled += instance.OnCameraMove;
                @Roll.started += instance.OnRoll;
                @Roll.performed += instance.OnRoll;
                @Roll.canceled += instance.OnRoll;
                @Shoot.started += instance.OnShoot;
                @Shoot.performed += instance.OnShoot;
                @Shoot.canceled += instance.OnShoot;
                @Aim.started += instance.OnAim;
                @Aim.performed += instance.OnAim;
                @Aim.canceled += instance.OnAim;
                @SwitchEnemy.started += instance.OnSwitchEnemy;
                @SwitchEnemy.performed += instance.OnSwitchEnemy;
                @SwitchEnemy.canceled += instance.OnSwitchEnemy;
                @Interact.started += instance.OnInteract;
                @Interact.performed += instance.OnInteract;
                @Interact.canceled += instance.OnInteract;
                @Abilitiy1.started += instance.OnAbilitiy1;
                @Abilitiy1.performed += instance.OnAbilitiy1;
                @Abilitiy1.canceled += instance.OnAbilitiy1;
                @SlowTime.started += instance.OnSlowTime;
                @SlowTime.performed += instance.OnSlowTime;
                @SlowTime.canceled += instance.OnSlowTime;
                @Menu.started += instance.OnMenu;
                @Menu.performed += instance.OnMenu;
                @Menu.canceled += instance.OnMenu;
                @Ability2.started += instance.OnAbility2;
                @Ability2.performed += instance.OnAbility2;
                @Ability2.canceled += instance.OnAbility2;
            }
        }
    }
    public GameplayActions @Gameplay => new GameplayActions(this);

    // Menu
    private readonly InputActionMap m_Menu;
    private IMenuActions m_MenuActionsCallbackInterface;
    private readonly InputAction m_Menu_NavigationUp;
    private readonly InputAction m_Menu_Exit;
    private readonly InputAction m_Menu_Enter;
    private readonly InputAction m_Menu_NavigationDown;
    private readonly InputAction m_Menu_NavigationLeft;
    private readonly InputAction m_Menu_NavigationRight;
    private readonly InputAction m_Menu_Navigate;
    public struct MenuActions
    {
        private @PlayerControls m_Wrapper;
        public MenuActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @NavigationUp => m_Wrapper.m_Menu_NavigationUp;
        public InputAction @Exit => m_Wrapper.m_Menu_Exit;
        public InputAction @Enter => m_Wrapper.m_Menu_Enter;
        public InputAction @NavigationDown => m_Wrapper.m_Menu_NavigationDown;
        public InputAction @NavigationLeft => m_Wrapper.m_Menu_NavigationLeft;
        public InputAction @NavigationRight => m_Wrapper.m_Menu_NavigationRight;
        public InputAction @Navigate => m_Wrapper.m_Menu_Navigate;
        public InputActionMap Get() { return m_Wrapper.m_Menu; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(MenuActions set) { return set.Get(); }
        public void SetCallbacks(IMenuActions instance)
        {
            if (m_Wrapper.m_MenuActionsCallbackInterface != null)
            {
                @NavigationUp.started -= m_Wrapper.m_MenuActionsCallbackInterface.OnNavigationUp;
                @NavigationUp.performed -= m_Wrapper.m_MenuActionsCallbackInterface.OnNavigationUp;
                @NavigationUp.canceled -= m_Wrapper.m_MenuActionsCallbackInterface.OnNavigationUp;
                @Exit.started -= m_Wrapper.m_MenuActionsCallbackInterface.OnExit;
                @Exit.performed -= m_Wrapper.m_MenuActionsCallbackInterface.OnExit;
                @Exit.canceled -= m_Wrapper.m_MenuActionsCallbackInterface.OnExit;
                @Enter.started -= m_Wrapper.m_MenuActionsCallbackInterface.OnEnter;
                @Enter.performed -= m_Wrapper.m_MenuActionsCallbackInterface.OnEnter;
                @Enter.canceled -= m_Wrapper.m_MenuActionsCallbackInterface.OnEnter;
                @NavigationDown.started -= m_Wrapper.m_MenuActionsCallbackInterface.OnNavigationDown;
                @NavigationDown.performed -= m_Wrapper.m_MenuActionsCallbackInterface.OnNavigationDown;
                @NavigationDown.canceled -= m_Wrapper.m_MenuActionsCallbackInterface.OnNavigationDown;
                @NavigationLeft.started -= m_Wrapper.m_MenuActionsCallbackInterface.OnNavigationLeft;
                @NavigationLeft.performed -= m_Wrapper.m_MenuActionsCallbackInterface.OnNavigationLeft;
                @NavigationLeft.canceled -= m_Wrapper.m_MenuActionsCallbackInterface.OnNavigationLeft;
                @NavigationRight.started -= m_Wrapper.m_MenuActionsCallbackInterface.OnNavigationRight;
                @NavigationRight.performed -= m_Wrapper.m_MenuActionsCallbackInterface.OnNavigationRight;
                @NavigationRight.canceled -= m_Wrapper.m_MenuActionsCallbackInterface.OnNavigationRight;
                @Navigate.started -= m_Wrapper.m_MenuActionsCallbackInterface.OnNavigate;
                @Navigate.performed -= m_Wrapper.m_MenuActionsCallbackInterface.OnNavigate;
                @Navigate.canceled -= m_Wrapper.m_MenuActionsCallbackInterface.OnNavigate;
            }
            m_Wrapper.m_MenuActionsCallbackInterface = instance;
            if (instance != null)
            {
                @NavigationUp.started += instance.OnNavigationUp;
                @NavigationUp.performed += instance.OnNavigationUp;
                @NavigationUp.canceled += instance.OnNavigationUp;
                @Exit.started += instance.OnExit;
                @Exit.performed += instance.OnExit;
                @Exit.canceled += instance.OnExit;
                @Enter.started += instance.OnEnter;
                @Enter.performed += instance.OnEnter;
                @Enter.canceled += instance.OnEnter;
                @NavigationDown.started += instance.OnNavigationDown;
                @NavigationDown.performed += instance.OnNavigationDown;
                @NavigationDown.canceled += instance.OnNavigationDown;
                @NavigationLeft.started += instance.OnNavigationLeft;
                @NavigationLeft.performed += instance.OnNavigationLeft;
                @NavigationLeft.canceled += instance.OnNavigationLeft;
                @NavigationRight.started += instance.OnNavigationRight;
                @NavigationRight.performed += instance.OnNavigationRight;
                @NavigationRight.canceled += instance.OnNavigationRight;
                @Navigate.started += instance.OnNavigate;
                @Navigate.performed += instance.OnNavigate;
                @Navigate.canceled += instance.OnNavigate;
            }
        }
    }
    public MenuActions @Menu => new MenuActions(this);
    public interface IGameplayActions
    {
        void OnJump(InputAction.CallbackContext context);
        void OnMove(InputAction.CallbackContext context);
        void OnCameraMove(InputAction.CallbackContext context);
        void OnRoll(InputAction.CallbackContext context);
        void OnShoot(InputAction.CallbackContext context);
        void OnAim(InputAction.CallbackContext context);
        void OnSwitchEnemy(InputAction.CallbackContext context);
        void OnInteract(InputAction.CallbackContext context);
        void OnAbilitiy1(InputAction.CallbackContext context);
        void OnSlowTime(InputAction.CallbackContext context);
        void OnMenu(InputAction.CallbackContext context);
        void OnAbility2(InputAction.CallbackContext context);
    }
    public interface IMenuActions
    {
        void OnNavigationUp(InputAction.CallbackContext context);
        void OnExit(InputAction.CallbackContext context);
        void OnEnter(InputAction.CallbackContext context);
        void OnNavigationDown(InputAction.CallbackContext context);
        void OnNavigationLeft(InputAction.CallbackContext context);
        void OnNavigationRight(InputAction.CallbackContext context);
        void OnNavigate(InputAction.CallbackContext context);
    }
}
