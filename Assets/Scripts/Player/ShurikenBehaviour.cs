using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Common;
using UnityEngine;

public class ShurikenBehaviour : MonoBehaviour
{
    private bool isCrit = false;
    private SpriteRenderer sr;

    // Start is called before the first frame update
    void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
        CheckCrit();
    }

    public void CheckCrit()
    {
        float critRate = DataManager.Instance.gameData.playerCritRate;
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
            collision.gameObject.GetComponent<HealthBarBehaviour>().TakeDamage(DataManager.Instance.gameData.playerDamage, isCrit);
        }
        if (collision.gameObject.CompareTag("Boss"))
        {
            collision.gameObject.GetComponent<Boss_HealthBar>().TakeDamage(20, isCrit);
            Animator anim = GameObject.FindGameObjectWithTag("Boss").GetComponent<Animator>();
            anim.SetTrigger("Takehit");
        }
    }
}