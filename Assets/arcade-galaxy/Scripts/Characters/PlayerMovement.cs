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
        public float turnRotation;

        [Header("Rockets")]
        public ParticleSystem rocketLeft;
        public ParticleSystem rocketRight;

        private void Awake()
        {
            turnRotation = Mathf.Clamp(turnRotation, 0, turnRotation);
        }

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

        private void Update()
        {
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

            // Turn Rotations
            if (Input.GetKeyDown(KeyCode.A))
                transform.rotation = Quaternion.Euler(0, turnRotation, 0);
            if (Input.GetKeyUp(KeyCode.A))
                transform.rotation = Quaternion.identity;
            if (Input.GetKeyDown(KeyCode.D))
                transform.rotation = Quaternion.Euler(0, -turnRotation, 0);
            if (Input.GetKeyUp(KeyCode.D))
                transform.rotation = Quaternion.identity;
        }
    }
}
