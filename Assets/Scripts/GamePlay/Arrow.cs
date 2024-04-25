using UnityEngine;
using ZPOT.Constant;

namespace ZPOT.GamePlay
{
    /// <summary>
    /// class responsible for controlling movement and rotation of arrow
    /// </summary>
    public class Arrow : MonoBehaviour
    {
        #region Private variables

        private bool canAnimate;
        private float movementDistance;
        private float movementSpeed;
        private float direction;
        private float rotationValue;
        private Vector3 initialPosition;

        #endregion

        #region Internal Properties

        internal bool CanAnimate { get => canAnimate; set => canAnimate = value; }

        #endregion

        #region Mono methods

        private void Update()
        {
            if (canAnimate)
            {
                RotateArrow();
                MoveArrow();
            }
        }

        #endregion

        /// <summary>
        /// Initalises the script
        /// </summary>
        internal void Init() => InitaliseVariables();

        /// <summary>
        /// Initialises all variables
        /// </summary>
        private void InitaliseVariables()
        {
            initialPosition = transform.position;
            movementDistance = Constants.ArrowMovementDistance;
            movementSpeed = Constants.ArrowMovementSpeed;
            rotationValue = Constants.ArrowRotationValue;
            direction = Constants.ArrowMovementDirection;
            canAnimate = true;
        }

        /// <summary>
        /// rotates the arrow
        /// </summary>
        private void RotateArrow() => transform.Rotate(rotationValue, 0, 0);

        /// <summary>
        /// moves the arrow up and down
        /// </summary>
        private void MoveArrow()
        {
            // Calculate the new position based on the direction and speed
            Vector3 newPosition = transform.position + Vector3.up * direction * movementSpeed * Time.deltaTime;

            // If the distance from the initial position is greater than movementDistance, change direction
            if (Vector3.Distance(newPosition, initialPosition) > movementDistance)
                direction *= -1f;

            // Set the arrow's position to the new position
            transform.position = newPosition;
        }
    }
}
