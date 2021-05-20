using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using DG.Tweening;

public class PlayerMovement : MonoBehaviour
{
    [Header("Attributes")]
    public float verticalMovementSpeed = 1f;
    public float horizontalMovementSpeed = 1f;

    private void Update()
    {
        if (Input.GetKey(KeyCode.A))
            transform.Translate(Vector3.left * horizontalMovementSpeed, Space.World);
        if (Input.GetKey(KeyCode.D))
            transform.Translate(Vector3.right * horizontalMovementSpeed, Space.World);
        if (Input.GetKey(KeyCode.W))
            transform.Translate(Vector3.up * verticalMovementSpeed, Space.World);
        if (Input.GetKey(KeyCode.S))
            transform.Translate(Vector3.down * verticalMovementSpeed, Space.World);
    }
}
