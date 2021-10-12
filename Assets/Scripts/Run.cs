using UnityEngine;

namespace WormTomb
{
    public class Run : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D rb;
        [SerializeField] private float runSpeed;
        [SerializeField] private float runSensitivity;

        private void OnEnable()
        {
            PlayerInput.Instance.onHorizontalInput.AddListener(SetRunVelocity);
        }

        private void SetRunVelocity(float xVelocity)
        {
            if (Mathf.Abs(xVelocity) < runSensitivity)
                xVelocity = 0;
        
            rb.velocity = new Vector2(xVelocity * runSpeed, rb.velocity.y);
        }
    }
}
