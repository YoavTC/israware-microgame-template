using System;
using UnityEngine;
using UnityEngine.Events;

namespace _Game_Assets.Microgames.demoMicrogame
{
    public class PlayerController : MonoBehaviour
    {
        [Header("Components")]
        [SerializeField] private Rigidbody2D rb;
        [SerializeField] private Transform badTransform, goodTransform;
        
        [Header("Settings")]
        [SerializeField] private float speed;
        [SerializeField] private float movingRotationAmount;
        private Vector2 movement;
        
        [Header("Events")]
        [SerializeField] private UnityEvent<bool> playerTouchedPlatformUnityEvent;

        private void Start()
        {
            if (rb == null) rb = GetComponent<Rigidbody2D>();
        }

        void Update()
        {
            movement.x = Input.GetAxisRaw("Horizontal");
        }

        private void FixedUpdate()
        {
            rb.position += movement * speed * Time.fixedDeltaTime;
            rb.MoveRotation(movement.x * movingRotationAmount);
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            playerTouchedPlatformUnityEvent?.Invoke(other.transform == goodTransform);
        }
    }
}
