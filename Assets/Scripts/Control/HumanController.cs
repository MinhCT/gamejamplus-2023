using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEditor.Recorder.OutputPath;

public class HumanController : MonoBehaviour
{
    #region Variables
    // Option
    [Header("Debug")]
    public bool isDebug = false;

    [Header("Setup")]
    public Transform head;

    [Header("Dynamic value")]
    public Vector2 directVector;
    public bool isDisableMouse = false;
    #endregion

    #region Local Variables
    // Local Variables
    Vector2 targetDirection, weaponDirection;
    Vector2 vecPointer;
    #endregion

    // Start is called before the first frame update
    void Awake() {
        directVector = Vector2.zero;
    }

    // FixedUpdate is called once per physics update
    private void FixedUpdate() {
        Vector2 targetPoint = Vector2.zero;
        if (!isDisableMouse) {
            //targetPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            targetPoint = Camera.main.ScreenToWorldPoint(vecPointer);
        }
        else {
            targetPoint = (Vector2)transform.position + directVector;
        }

        targetDirection = (targetPoint - (Vector2)transform.position).normalized;
        weaponDirection = ((Vector2)head.position - (Vector2)transform.position).normalized;

        // Rotate weapon
        float angle = Vector2.SignedAngle(weaponDirection, targetDirection);
        transform.eulerAngles += Vector3.forward * angle;
    }

    public void ResetStatus() {
        isDisableMouse = true;
        directVector = Vector2.zero;
    }

    #region Input System
    public void OnLook(InputAction.CallbackContext context) {
        if (context.performed) {
            vecPointer = context.ReadValue<Vector2>();
            isDisableMouse = false;
        }
    }
    public void OnRotate(InputAction.CallbackContext context) {
        if (context.performed) {
            isDisableMouse = true;
            Vector2 direction = context.ReadValue<Vector2>();
            directVector = direction.normalized;
        }
    }
    #endregion
}