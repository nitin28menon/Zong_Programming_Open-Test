using UnityEngine;
using ZPOT.Constant;

namespace ZPOT.GamePlay
{
    /// <summary>
    /// class for player camera movement
    /// </summary>
    public class PlayerCamera : MonoBehaviour
    {
        #region SerializeFields

        [SerializeField] private Transform orientaion;

        #endregion

        #region Private variables

        private float xSensitivity, ySensitivity;
        private float xRotation, yRotation;
        private float xInputValue, yInputValue;
        private float xRotationMinClampValue, xRotationMaxClampValue;
        private float yRotationMinClampValue, yRotationMaxClampValue;

        private bool canRotateCamera;

        #endregion

        #region Internal variables

        internal bool CanRotateCamera { get => canRotateCamera; set => canRotateCamera = value; }

        #endregion

        #region Mono methods

        private void Update()
        {
            if(!canRotateCamera)
                return;
            GetMouseInput();
            SetCameraRotation();
            RotateCamera();
        }

        #endregion

        /// <summary>
        /// initialises the script
        /// </summary>
        internal void Init()
        {
            LockMouse();
            canRotateCamera = true;
            xSensitivity = Constants.XSensitivity;
            ySensitivity = Constants.YSensitivity;
            xRotationMinClampValue = Constants.XRotationMinClampValue;
            xRotationMaxClampValue = Constants.XRotationMaxClampValue;
            yRotationMinClampValue = Constants.YRotationMinClampValue;
            yRotationMaxClampValue = Constants.YRotationMaxClampValue;
        }

        /// <summary>
        /// locks the mouse and makes it invisible
        /// </summary>
        private void LockMouse()
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }

        /// <summary>
        /// gets the mouse input
        /// </summary>
        private void GetMouseInput()
        {
            xInputValue = Input.GetAxisRaw("Mouse X") * Time.deltaTime * xSensitivity;
            yInputValue = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * ySensitivity;
        }

        /// <summary>
        /// sets the camera rotation
        /// </summary>
        private void SetCameraRotation()
        {
            yRotation += xInputValue;
            yRotation = Mathf.Clamp(yRotation, yRotationMinClampValue, yRotationMaxClampValue);
            xRotation -= yInputValue;
            xRotation = Mathf.Clamp(xRotation, xRotationMinClampValue, xRotationMaxClampValue);
        }

        /// <summary>
        /// Rotates the camera
        /// </summary>
        private void RotateCamera()
        {
            transform.rotation = Quaternion.Euler(xRotation, yRotation, 0);
            orientaion.rotation = Quaternion.Euler(0, yRotation, 0);
        }
    }
}
