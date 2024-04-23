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
    }
}
