using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShurikenBehaviour : MonoBehaviour
{
    private bool isCrit = false;
    private SpriteRenderer sr;

    // Start is called before the first frame update
    void Awake()
    {
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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
        if (collision.gameObject.CompareTag("Creep"))
        {
            collision.gameObject.GetComponent<HealthBarBehaviour>().TakeDamage(20, isCrit);
        }
    }
}
