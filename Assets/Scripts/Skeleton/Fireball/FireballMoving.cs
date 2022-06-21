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
        Vector2 direction = new(player.transform.position.x - transform.position.x, player.transform.position.y - transform.position.y);
        float magnitude = 1.2f;
        Rigidbody2D rb2d = GetComponent<Rigidbody2D>();
        rb2d.AddForce(direction * magnitude, ForceMode2D.Impulse);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(Constants.TagPlayer))
        {
            Destroy(gameObject);
            Instantiate<GameObject>(prefapExposion, transform.position, Quaternion.identity);
            
            // TODO: Player Take Damage
            Debug.Log($"{collision.tag} Take Damge by {transform.tag}");
        }
    }
}
