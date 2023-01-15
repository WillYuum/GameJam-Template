using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using DG.Tweening;

public class CheckControllerInput : MonoBehaviour
{
    private bool _isControllerConnected = false;

    private MainControls _controls;

    [SerializeField] private GameObject _pressToContinueText;
    [SerializeField] private Image _controllerImage;

    private void Awake()
    {
        _pressToContinueText.SetActive(false);
        _controls = new MainControls();
    }


    void Update()
    {
        if (Gamepad.current != null)
        {
            if (!_isControllerConnected)
            {
                RenderConnectedController(Gamepad.current, InputDeviceChange.Added);
            }

            _isControllerConnected = true;
        }
        else
        {
            if (_isControllerConnected)
            {
                RenderConnectedController(Gamepad.current, InputDeviceChange.Removed);
            }

            _isControllerConnected = false;
        }
    }


    private void RenderConnectedController(InputDevice device, InputDeviceChange change)
    {
#if UNITY_EDITOR
        Debug.Log("change: " + change);
        if (device != null)
        {
            Debug.Log("Device connected to: " + device.name);
        }
#endif

        switch (change)
        {
            case InputDeviceChange.Added:
                _isControllerConnected = true;

                _controls.TestControls.PressStart.Enable();
                _controls.TestControls.PressStart.performed += OnPressStart;

                _pressToContinueText.SetActive(true);
                _controllerImage.DOColor(Color.green, 0.75f).SetEase(Ease.InQuart);

                break;
            case InputDeviceChange.Removed:
                _isControllerConnected = false;

                _controls.TestControls.PressStart.Disable();
                _controls.TestControls.PressStart.performed -= OnPressStart;

                _pressToContinueText.SetActive(false);
                _controllerImage.DOColor(Color.white, 0.75f).SetEase(Ease.InQuart);
                break;
        }
    }


    private void OnPressStart(InputAction.CallbackContext cb)
    {
#if UNITY_EDITOR
        Debug.Log("Press Start");
#endif
    }

}
