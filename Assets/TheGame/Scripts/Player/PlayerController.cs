using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Weapon weapon;
    private bool isAttacking;
    
    [SerializeField]private Animator charAnim;
    [SerializeField]private Transform barrel;
    [SerializeField]private GameObject bullet;
    public bool AttackButton;


    private void Update()
    {
        if (AttackButton)
        {
            Attack();
        }
        else
        {
            StopAttack();
        }
    }

    void Attack()
    {
        if (isAttacking) return;
        isAttacking = true;
        charAnim.Play($"Attack{weapon.weaponType}");
    }
    
    void StopAttack()
    {
        if (!isAttacking) return;
        isAttacking = false;
        charAnim.Play("Idle");
    }

    public void PistolShoot()
    {
        var go = Instantiate(bullet, barrel);
        go.transform.SetParent(null);
        go.GetComponent<Bullet>().SetDamage(weapon.damage);
    }
    
    private Enemy enemy;
    private void HitEnemy()
    {
        enemy.Hit(weapon.damage);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemy" && isAttacking)
        {
            enemy = other.GetComponent<Enemy>();
            InvokeRepeating("HitEnemy",0.33f,0.33f);
        }

        if (other.tag == "Respawn")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Enemy")
        {
            CancelInvoke("HitEnemy");
        }
    }
    
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.tag == "LootBox")
        {
            LootBoxManager lootBox;
            lootBox = other.gameObject.GetComponent<LootBoxManager>();
            weapon.SetWeapon(lootBox.GetRandomItem());
            lootBox.DestroyLootBox();
        }
    }
}
