using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ArcadeGalaxy.Utils
{
    public class Boundaries : MonoBehaviour
    {
        private Camera MainCamera;
        private Vector2 screenBounds;
        private float objectWidth;
        private float objectHeight;

        void Start()
        {
            MainCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
            screenBounds = MainCamera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, MainCamera.transform.position.z));

            objectWidth = transform.GetComponent<SpriteRenderer>().bounds.extents.x; //extents = size of width / 2
            objectHeight = transform.GetComponent<SpriteRenderer>().bounds.extents.y; //extents = size of height / 2
        }

        void LateUpdate()
        {
            Vector3 viewPos = transform.position;
            viewPos.x = Mathf.Clamp(viewPos.x, screenBounds.x * -1 + objectWidth, screenBounds.x - objectWidth);
            viewPos.y = Mathf.Clamp(viewPos.y, screenBounds.y * -1 + objectHeight, screenBounds.y - objectHeight);
            transform.position = viewPos;
        }
    }
}