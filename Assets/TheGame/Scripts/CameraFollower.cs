using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollower : MonoBehaviour
{

    [SerializeField] private Transform player;

    public float minX, maxX;

    // Update is called once per frame
    void Update()
    {
        if (player)
        {
            Vector3 temp = transform.position;
            temp.x = player.position.x;

            if (temp.x < minX)
            {
                temp.x = minX;
            }

            if (temp.x > maxX)
            {
                temp.x = maxX;
            }

            temp.y = player.position.y;

            transform.position = temp;
        }        
    }
}
