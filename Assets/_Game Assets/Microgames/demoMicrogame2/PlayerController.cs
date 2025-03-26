using UnityEngine;
using UnityEngine.Events;

namespace _Game_Assets.Microgames.demoMicrogame2
{
    public class PlayerController : MonoBehaviour
    {
        [Header("Components")]
        [SerializeField] private Rigidbody2D rb;
        [SerializeField] private Transform crown;
        
        [Header("Settings")]
        [SerializeField] private float speed;
        [SerializeField] private float movingRotationAmount;
        private Vector2 movement;
        
        [Header("Events")]
        [SerializeField] private UnityEvent<bool> playerFinishedMazeUnityEvent;

        private void Start()
        {
            if (rb == null) rb = GetComponent<Rigidbody2D>();
        }

        void Update()
        {
            movement = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        }

        private void FixedUpdate()
        {
            rb.position += movement.normalized * speed * Time.fixedDeltaTime;
            rb.MoveRotation(movement.x * movingRotationAmount);
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.transform == crown)
            {
                playerFinishedMazeUnityEvent?.Invoke(true);
                Destroy(other.gameObject);
            }
        }
    }
}
