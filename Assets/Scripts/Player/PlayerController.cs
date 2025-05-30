using UnityEngine;

namespace Player
{
    [RequireComponent(typeof(CharacterController))]
    public class PlayerController : MonoBehaviour
    {
        public float moveSpeed = 5f;
        private CharacterController controller;

        private Vector3 moveInput;
        private bool canMove = true;

        void Awake()
        {
            controller = GetComponent<CharacterController>();
        }

        void Update()
        {
            if (!canMove) return;

            float h = Input.GetAxis("Horizontal");
            float v = Input.GetAxis("Vertical");
            moveInput = new Vector3(h, 0f, v).normalized;

            controller.Move(moveInput * moveSpeed * Time.deltaTime);
        }

        public void EnableControl(bool enable)
        {
            canMove = enable;
        }
    }
}