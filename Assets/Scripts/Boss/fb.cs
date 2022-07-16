using Assets.Scripts.Common;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fb : MonoBehaviour
{
    [SerializeField]
    GameObject prefapExposionBoss;

    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(Constants.TagPlayer))
        {
            Destroy(gameObject);
            Debug.Log("Hit player with fireball");
            Instantiate<GameObject>(prefapExposionBoss, transform.position, Quaternion.identity);
        }
        else if (collision.CompareTag(Constants.TagFireball))
        {
            Debug.Log("Fireball Collision");
        }
        else
        {
            Destroy(gameObject);
            Instantiate<GameObject>(prefapExposionBoss, transform.position, Quaternion.identity);
        }
        
    }
    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
