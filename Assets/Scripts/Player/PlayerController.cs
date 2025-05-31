using UnityEngine;

namespace Player
{
    [RequireComponent(typeof(CharacterController))]
    public class PlayerController : MonoBehaviour
    {
        public static PlayerController Instance { get; private set; }
        
        public float moveSpeed = 5f;
        private CharacterController controller;

        private Vector3 moveInput;
        private bool canMove = true;

        void Awake()
        {
            controller = GetComponent<CharacterController>();
            if (Instance == null) Instance = this;
            else Destroy(gameObject);
        }

        void Update()
        {
            if (!canMove) return;

            float h = Input.GetAxis("Horizontal");
            float v = Input.GetAxis("Vertical");
            moveInput = new Vector3(h, 0f, v).normalized;

            controller.Move(moveInput * moveSpeed * Time.deltaTime);
        }

        public void EnableControls()
        {
            canMove = true;
            Debug.Log("Enable Controls");
        }
        
        public void DisableControls()
        {
            canMove = false;
            Debug.Log("Disable Controls");
        }
    }
}