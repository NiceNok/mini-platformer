using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveButton : MonoBehaviour
{

    [SerializeField] private MoveDirection direction;
    [SerializeField] private Transform player;
    private bool pressed;

    private void OnMouseDown()
    {
        pressed = true;
    }

    private void OnMouseUp()
    {
        pressed = false;
    }

    void FixedUpdate()
    {
        if (!pressed)
        {
            return;
        }
        
        var direction = this.direction == MoveDirection.LEFT ? -1 : 1; 
        player.position = new Vector2(player.position.x + (direction / 10f),
            player.position.y);
    }
    
    
}

public enum MoveDirection
{
    LEFT,
    RIGHT
}
