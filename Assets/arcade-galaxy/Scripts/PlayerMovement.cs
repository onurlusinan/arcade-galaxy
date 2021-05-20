using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Player player;

    private void Awake()
    {
        player = this.GetComponent<Player>();
    }

    private void Update()
    {
        if (Input.GetKeyDown("W"))
        { 
            
        }
    }
}
