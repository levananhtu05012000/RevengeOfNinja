using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Common;
using UnityEngine;

public class ShurikenBehaviour : MonoBehaviour
{
    private bool isCrit = false;
    private SpriteRenderer sr;
    private Animator anim;

    // Start is called before the first frame update
    void Awake()
    {
        anim = GameObject.FindGameObjectWithTag("Boss").GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
    }

    public void CheckCrit(float critRate)
    {
        if (Random.Range(0, 100) <= critRate)
        {
            isCrit = true;
            sr.color = Color.red;
        }
        else
        {
            isCrit = false;
            sr.color = Color.white;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    Destroy(gameObject);
    //    if (collision.gameObject.CompareTag(Constants.TagCreep))
    //    {
    //        collision.gameObject.GetComponent<HealthBarBehaviour>().TakeDamage(20, isCrit);
    //    }
    //    if (collision.gameObject.CompareTag("Boss"))
    //    {
    //        collision.gameObject.GetComponent<Boss_HealthBar>().TakeDamage(20, isCrit);
    //        anim.SetTrigger("Takehit");
    //    }
    //}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
        if (collision.gameObject.CompareTag(Constants.TagCreep))
        {
            collision.gameObject.GetComponent<HealthBarBehaviour>().TakeDamage(20, isCrit);
        }
        if (collision.gameObject.CompareTag("Boss"))
        {
            collision.gameObject.GetComponent<Boss_HealthBar>().TakeDamage(20, isCrit);
            anim.SetTrigger("Takehit");
        }
    }
}
