using UnityEngine;
using ZPOT.Constant;

namespace ZPOT.GamePlay
{
    /// <summary>
    /// class for player movement
    /// </summary>
    [RequireComponent(typeof(Rigidbody))]
    public class PlayerMovement : MonoBehaviour
    {
        #region Serialize fields

        [SerializeField] private Transform orientation;
        [SerializeField] private LayerMask groundLayer;
        [SerializeField] private Animator animationController;
        [SerializeField] private float groundForce = 10f;
        [SerializeField] private float playerMoveSpeed = 7f;
        [SerializeField] private Transform characterModel;

        #endregion

        #region Private variables

        //movement variables
        private float groundDrag;
        private float playerHeight;
        // private float playerMoveSpeed;
        private bool isGrounded;
        private bool playerCanMove;
        private Vector3 moveDirection;
        private Rigidbody playerRB;

        //jump variables
        private float playerJumpForce;
        private float playerJumpCoolddown;
        private float airMultiplier;
        private bool readyToJump;
        private KeyCode jumpKey;

        //player input variables
        private float verticalInput;
        private float horizontalInput;

        #endregion

        #region Internal Variables

        internal bool PlayerCanMove { get => playerCanMove; set => playerCanMove = value; }

        #endregion

        #region Mono methods

        private void Update()
        {
            if (!playerCanMove)
                return;
            CheckForPlayerInput();
            SpeedControl();
            HandleDrag();
        }

        private void FixedUpdate()
        {
            if (!playerCanMove)
                return;
            MovePlayer();
        }

        #endregion    

        #region Initialising functions

        /// <summary>
        /// Initialises script
        /// </summary>
        internal void Init()
        {
            InitialiseComponents();
            InitialiseVariables();
        }

        /// <summary>
        /// Initialises components
        /// </summary>
        private void InitialiseComponents()
        {
            playerRB = GetComponent<Rigidbody>();
            playerRB.freezeRotation = true;
        }

        /// <summary>
        /// Initialises variables
        /// </summary>
        private void InitialiseVariables()
        {
            // playerMoveSpeed = Constants.PlayerMoveSpeed;
            jumpKey = Constants.PlayerJumpKey;
            playerHeight = Constants.PlayerHeight;
            groundDrag = Constants.GroundDrag;
            playerJumpForce = Constants.PlayerJumpForce;
            playerJumpCoolddown = Constants.PlayerJumpCoolddown;
            airMultiplier = Constants.AirMultiplier;
            isGrounded = true;
            readyToJump = true;
            playerCanMove = true;
        }

        #endregion

        #region Player input functions

        /// <summary>
        /// gets the user's input
        /// </summary>
        private void CheckForPlayerInput()
        {
            CheckForPlayerMovement();
            CheckForPlayerJump();
        }

        /// <summary>
        /// checks for input regarding player movement
        /// </summary>
        private void CheckForPlayerMovement()
        {
            horizontalInput = Input.GetAxisRaw("Horizontal");
            verticalInput = Input.GetAxisRaw("Vertical");
        }

        /// <summary>
        /// checks for input regarding player jump
        /// </summary>
        private void CheckForPlayerJump()
        {
            if (Input.GetKey(jumpKey) && readyToJump && CheckForIsGrounded())
            {
                animationController.SetTrigger("JumpTrigger");
                readyToJump = false;
                Jump();
                Invoke(nameof(ResetJump), playerJumpCoolddown);
            }
        }

        #endregion

        /// <summary>
        /// checks if the player is grounded or not
        /// </summary>
        private bool CheckForIsGrounded()
        {
            return isGrounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.2f, groundLayer);
        }

        #region Player movement functions

        /// <summary>
        /// moves the player
        /// </summary>
        private void MovePlayer()
        {
            animationController.SetBool("IsWalking", horizontalInput != 0 || verticalInput != 0);
            //calculate movement direction
            moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;
            characterModel.LookAt(moveDirection);
            //add force based on wether the player is on ground or in air
            playerRB.AddForce((CheckForIsGrounded() ? groundForce : groundForce * airMultiplier) * playerMoveSpeed * moveDirection.normalized, ForceMode.Force);
        }

        /// <summary>
        /// controls speed of player
        /// </summary>
        private void SpeedControl()
        {
            Vector3 currentVelocity = new Vector3(playerRB.velocity.x, 0f, playerRB.velocity.z);

            //limit velocity
            if (currentVelocity.magnitude > playerMoveSpeed)
            {
                Vector3 limitedVelocity = currentVelocity.normalized * playerMoveSpeed;
                playerRB.velocity = new Vector3(limitedVelocity.x, playerRB.velocity.y, limitedVelocity.z);
            }
        }

        /// <summary>
        /// handles drag for player movement
        /// </summary>
        private void HandleDrag() => playerRB.drag = CheckForIsGrounded() ? groundDrag : 0;

        #endregion

        #region Player jump related functions

        /// <summary>
        /// makes the player jump
        /// </summary>
        private void Jump()
        {
            // reset y velocity before jumping
            playerRB.velocity = new Vector3(playerRB.velocity.x, 0, playerRB.velocity.z);
            playerRB.AddForce(transform.up * playerJumpForce, ForceMode.Impulse);
        }

        /// <summary>
        /// resets jump
        /// </summary>
        private void ResetJump() => readyToJump = true;

        #endregion
    }
}
