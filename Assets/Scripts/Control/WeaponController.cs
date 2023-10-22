using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

    public class WeaponController : MonoBehaviour
    {
        #region Variables
        // Option
        [Header("Debug")]
        public bool isDebug = false;

        // Setup
        [Header("Object")]
        public Transform root;
        public Transform tail;
        public Transform head;

        [Header("Distance value")]
        public float disStopRotate = 0.5f;

        [Header("Force value")]
        public float vWaitFire = 0.5f;

        [Header("Dynamic value")]
        public Vector2 directVector;
        public bool isDisableMouse = false;
        public bool isFire = false;
        public bool isWaitFire = false;

        // Local Variables
        Vector2 targetDirection;
        Vector2 weaponDirection;
        Vector2 vecPointer;
        float disPlayerWeapon;
        #endregion

        // Start is called before the first frame update
        void Awake() {
            directVector = Vector2.zero;
            vecPointer = Camera.main.WorldToScreenPoint(head.transform.position);
            disPlayerWeapon = Vector2.Distance(root.position, tail.position);
        }

        // FixedUpdate is called once per physics update
        void FixedUpdate() {
            Vector2 targetPoint = Vector2.zero;
            if (!isDisableMouse) {
                //targetPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                targetPoint = Camera.main.ScreenToWorldPoint(vecPointer);
            }
            else {
                targetPoint = (Vector2)root.position + directVector;
            }

            targetDirection = (targetPoint - (Vector2)root.position).normalized;
            weaponDirection = ((Vector2)head.position - (Vector2)tail.position).normalized;

            float distance = Vector2.Distance(targetPoint, root.position);

            // Rotate weapon
            if (distance >= disStopRotate) {
                float angle = Vector2.SignedAngle(weaponDirection, targetDirection);
                transform.eulerAngles += Vector3.forward * angle;
            }

            // Move weapon
            Vector2 targetPos = root.position + (Vector3)targetDirection * disPlayerWeapon;
            Vector2 vecMoveGo = targetPos - (Vector2)tail.position;
            transform.position += (Vector3)vecMoveGo;

            // Push back
            if (isFire) {
                if (!isWaitFire) {
                    StartCoroutine(WaitFire());
                }
                isFire = false;
            }

            Flip();
        }
        public void ResetStatus() {
            isDisableMouse = true;
            directVector = Vector2.zero;
        }

        void Flip() {
            Vector3 scale = transform.localScale;
            scale.x = Mathf.Abs(scale.x) * Mathf.Sign(targetDirection.x);
            transform.localScale = scale;
        }

        #region Input meathods
        // Only for mouse
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
                directVector = direction.normalized * disStopRotate;
            }
        }
        public void OnFire(InputAction.CallbackContext context) {
            if (context.performed) {
                isFire = true;
            }
        }
        IEnumerator WaitFire() {
            isWaitFire = true;
            yield return new WaitForSeconds(vWaitFire);
            isWaitFire = false;
        }

    #endregion
        #region Gizmos
        // OnDrawGizmos is called when the scene view is drawn
        void OnDrawGizmos() {
            if (!isDebug) return;

            Gizmos.color = Color.yellow;
            Gizmos.DrawWireSphere(root.position, disStopRotate);
        }
        #endregion
    }