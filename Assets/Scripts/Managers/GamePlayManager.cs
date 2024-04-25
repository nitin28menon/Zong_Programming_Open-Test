using UnityEngine;
using ZPOT.GamePlay;

namespace ZPOT.Manager
{
    /// <summary>
    /// main class that manages the gameflow
    /// </summary>
    public class GamePlayManager : MonoBehaviour
    {
        #region Serialize Fields

        [SerializeField] private PlayerCamera playerCamera;
        [SerializeField] private PlayerMovement playerMovement;
        [SerializeField] private Arrow arrow;

        #endregion

        private void Start()
        {
            Init();
        }
        
        /// <summary>
        /// Initialises the script
        /// </summary>
        internal void Init()
        {
            playerCamera.Init();
            playerMovement.Init();
            arrow.Init();
        }
    }
}
