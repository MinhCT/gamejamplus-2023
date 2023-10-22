using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    #region Variables

    // Option
    [Header("Debug")]
    public bool isDebug = false;

    [Header("Dynamic value")]
    public bool isLookController = false;
    public bool isDisableMouse = true;

    // Setup
    [Header("Object")]
    public HumanController humanController;
    public WeaponController weaponController;
    #endregion

    #region Local Variables
    public static PlayerController instance { get; private set; }
    #endregion

    void Awake() {
        if (instance == null) {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else {
            Destroy(gameObject);
        }
    }
    // Start is called before the first frame update
    void Start() {
        humanController.ResetStatus();
    }

    #region Input system
    public void OnFire(InputAction.CallbackContext context) {
        weaponController.OnFire(context);
    }
    public void OnLook(InputAction.CallbackContext context) {
        if (context.performed) {
            isDisableMouse = false;
        }
        humanController.OnLook(context);
        weaponController.OnLook(context);
    }
    public void OnRotate(InputAction.CallbackContext context) {
        if (context.performed) {
            ResetMouse();
        }
        humanController.OnRotate(context);
        weaponController.OnRotate(context);
    }
    #endregion

    #region Function
    void ResetMouse() {
        if (!isDisableMouse) {
            Mouse.current.WarpCursorPosition(new Vector2(Screen.width / 2, Screen.height / 2));
            isDisableMouse = true;
        }
    }
    #endregion
}
