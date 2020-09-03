using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    private int damage;

    public void SetDamage(int damage)
    {
        this.damage = damage;
        Invoke("DestroyThis",2f);
    }

    void DestroyThis()
    {
        Destroy(gameObject);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position += Vector3.right * Time.deltaTime * 10;

    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.tag == "Enemy")
        {
            other.gameObject.GetComponent<Enemy>().Hit(damage);
            Destroy(gameObject);
        }
    }
}
