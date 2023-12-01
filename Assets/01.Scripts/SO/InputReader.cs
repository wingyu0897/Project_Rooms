using System;
using UnityEngine;
using UnityEngine.InputSystem;
using static PlayerInput;

[CreateAssetMenu(menuName = "SO/InputReader")]
public class InputReader : ScriptableObject, IPlayerActions
{
    public Vector2 MousePosition { get; private set; }
    public event Action<Vector2> OnMovementEvent;

    private PlayerInput controlAction;

    private void OnEnable()
    {
        if (controlAction == null)
        {
            controlAction = new PlayerInput();
            controlAction.Player.SetCallbacks(this);
        }
        controlAction.Player.Enable();
    }

    public void OnAim(InputAction.CallbackContext context)
	{
        MousePosition = context.ReadValue<Vector2>();
	}

	public void OnMovement(InputAction.CallbackContext context)
	{
        Vector2 value = context.ReadValue<Vector2>();
        OnMovementEvent?.Invoke(value);
	}
}
