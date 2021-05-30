using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ArcadeGalaxy.Characters
{
    public class PlayerMovement : MonoBehaviour
    {
        [Header("Attributes")]
        public float verticalMovementSpeed = 1f;
        public float horizontalMovementSpeed = 1f;

        [Header("Rockets")]
        public ParticleSystem rocketLeft;
        public ParticleSystem rocketRight;

        /// <summary>
        /// Play the rocket particle effects
        /// </summary>
        private void PlayRockets()
        {
            rocketLeft.Play();
            rocketRight.Play();
        }

        /// <summary>
        /// Stop the rocket particle effects
        /// </summary>
        private void StopRockets()
        {
            rocketRight.Stop();
            rocketLeft.Stop();
        }

        private void FaceMouse()
        {
            Vector3 mousePosition = Input.mousePosition;
            mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);

            Vector2 direction = new Vector2(
                mousePosition.x - transform.position.x,
                mousePosition.y - transform.position.y
            );

            transform.up = direction;
        }

        private void Update()
        {
            // Follow the mouse
            FaceMouse();

            // Basic Movement
            if (Input.GetKey(KeyCode.A))
                transform.Translate(Vector3.left * horizontalMovementSpeed, Space.World);
            if (Input.GetKey(KeyCode.D))
                transform.Translate(Vector3.right * horizontalMovementSpeed, Space.World);
            if (Input.GetKey(KeyCode.W))
                transform.Translate(Vector3.up * verticalMovementSpeed, Space.World);
            if (Input.GetKey(KeyCode.S))
                transform.Translate(Vector3.down * verticalMovementSpeed, Space.World);

            // Rockets Particles
            if (Input.GetKeyDown(KeyCode.W))
                PlayRockets();
            if (Input.GetKeyUp(KeyCode.W))
                StopRockets();
        }
    }
}
