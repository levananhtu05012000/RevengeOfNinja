using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Common;
using UnityEngine;

public class FireballMoving : MonoBehaviour
{ 
    [SerializeField]
    GameObject prefapExposion;

    // Start is called before the first frame update
    void Start()
    {
        GameObject player = GameObject.FindGameObjectWithTag(Constants.TagPlayer);
        Vector3 direction = player.transform.position - transform.position;
        direction.z = 0;
        float magnitude = 2f;
        Rigidbody2D rb2d = GetComponent<Rigidbody2D>();
        //rb2d.AddForce(direction * magnitude, ForceMode2D.Impulse);
        rb2d.velocity = direction.normalized * magnitude;
    }
    private void Update()
    {
        if (!GetComponent<Renderer>().isVisible)
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.layer == 7)
        {
            Destroy(gameObject);
            Instantiate<GameObject>(prefapExposion, transform.position, Quaternion.identity);
        }
        if (collision.CompareTag(Constants.TagPlayer))
        {
            Destroy(gameObject);
            Instantiate<GameObject>(prefapExposion, transform.position, Quaternion.identity);
            collision.gameObject.GetComponent<HealthBarBehaviour>().TakeDamage(15, false);
        }
    }



}
