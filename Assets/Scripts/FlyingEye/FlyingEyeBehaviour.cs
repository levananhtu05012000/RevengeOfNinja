using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingEyeBehaviour : MonoBehaviour
{
    private Rigidbody2D rb2d;
    private Animator animationController;

    private float moveSpeed = 1f;
    private bool isFlyUp = true;
    private bool facingRight = true;
    private Vector2 originalPosition;
    [SerializeField]
    private float movingDistance;
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        animationController = GetComponent<Animator>();
        originalPosition = new Vector2(transform.position.x, transform.position.y);

        // first move of goblin
        Vector2 direction = new Vector2(0, 1);
        rb2d.AddForce(direction * moveSpeed, ForceMode2D.Impulse);
        StartCoroutine(Moving());
    }

    IEnumerator Moving()
    {
        while (true)
        {
            yield return new WaitUntil(HasEndRoutin);
            rb2d.velocity = Vector2.zero;
            isFlyUp = !isFlyUp;
            yield return new WaitForSeconds(2);
            Vector2 direction = new Vector2(0, isFlyUp ? 1 : -1);
            rb2d.AddForce(direction * moveSpeed, ForceMode2D.Impulse);
            yield return new WaitForSeconds(1);
        }
    }

    private bool HasEndRoutin()
    {
        float maxDistanceAround = Mathf.Abs(transform.position.y - originalPosition.y);
        return (movingDistance / 2 - maxDistanceAround < 0);
        // add new velocity
    }

    // Update is called once per frame
    void Update()
    {
    }

    void Flip()
    {
        // Switch the way the player is labelled as facing
        facingRight = !facingRight;
        // Multiply the player's x local scale by -1
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}