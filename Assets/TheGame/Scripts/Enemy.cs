using System;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    private int HP = 500;
    [SerializeField] private GameObject HPBar;
    [SerializeField] private Image HPBarUI;
    [SerializeField] private GameObject HPBarGO;
    [SerializeField] private GameObject BloodFX;
    

    public void Hit(int damage)
    {
        HP -= damage;
        Instantiate(BloodFX, transform);

        if (HP <= 0)
        {
            //Finish Game;
            Destroy(this);
            return;
        }

        HPBarUI.fillAmount = HP / (float)500;
        HPBar.transform.localScale = new Vector3(HP / 500f, 1f, 1f);
    }

    private void OnBecameVisible()
    {
        HPBarGO.SetActive(true);
    }
}
