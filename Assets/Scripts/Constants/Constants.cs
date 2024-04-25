using UnityEngine;

namespace ZPOT.Constant
{
    /// <summary>
    /// class containing all constant values
    /// </summary>
    public class Constants
    {
        #region Camera

        internal const float XSensitivity = 400f;
        internal const float YSensitivity = 400f;
        internal const float XRotationMinClampValue = -45f;
        internal const float XRotationMaxClampValue = 45f;

        #endregion

        #region Player

        internal const float PlayerMoveSpeed = 7f;
        internal const float PlayerHeight = 2f;
        internal const float GroundDrag = 5f;
        internal const float PlayerJumpForce = 6f;
        internal const float PlayerJumpCoolddown = .25f;
        internal const float AirMultiplier = .4f;
        internal const KeyCode PlayerJumpKey = KeyCode.Space;

        #endregion
        
        #region Arrow

        internal const float ArrowMovementDistance = .5f;
        internal const float ArrowMovementSpeed = .8f;
        internal const float ArrowRotationValue = .8f;
        internal const float ArrowMovementDirection = 1f;

        #endregion
    }
}
