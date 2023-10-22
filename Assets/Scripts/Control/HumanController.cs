using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class HumanController : MonoBehaviour
{
    #region Variables
    // Option
    [Header("Debug")]
    public bool isDebug = false;

    [Header("Value")]
    public float fAccelerationStop = 0.2f;

    [Header("Dynamic value")]
    public bool isDisableMouse = false;
    #endregion

    #region Local Variables
    Vector2 vecMove;
    #endregion

    // Start is called before the first frame update
    void Awake() {
        vecMove = Vector2.right;
    }

    // FixedUpdate is called once per physics update
    private void FixedUpdate() {
        Flip();
    }

    public void ResetStatus() {
        vecMove = Vector2.right;
    }

    #region Input System
    public void OnLook(InputAction.CallbackContext context) {
        if (context.performed) {
            isDisableMouse = false;
            vecMove = context.ReadValue<Vector2>() - (Vector2)transform.position;
            vecMove.Normalize();
        }
    }
    public void OnRotate(InputAction.CallbackContext context) {
        if (context.performed) {
            isDisableMouse = true;
            vecMove = new Vector2(context.ReadValue<Vector2>().x, 0);
            vecMove.Normalize();
        }
    }
    void Flip() {
        Vector3 scale = transform.localScale;
        if (vecMove.x > 0) {
            scale.x = 1;
        }
        else if (vecMove.x < 0) {
            scale.x = -1;
        }
        transform.localScale = scale;
    }
    #endregion
}