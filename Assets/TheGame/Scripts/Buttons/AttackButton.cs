using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class AttackButton : MonoBehaviour
{
    [SerializeField] private PlayerController playerController;
    
    private void OnMouseDown()
    {
        playerController.AttackButton = true;
    }

    private void OnMouseUp()
    {
        playerController.AttackButton = false;
    }
}
