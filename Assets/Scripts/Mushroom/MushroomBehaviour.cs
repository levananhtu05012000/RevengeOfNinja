using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Common;
using UnityEngine;

public class MushroomBehaviour : MonoBehaviour
{
    private Rigidbody2D rb2d;
    private Animator animationController;

    private float moveSpeed = 2f;
    private Vector2 originalPosition;
    private bool hasRun = false;
    [SerializeField]
    private float detectDistance;
    [SerializeField]
    private GameObject prefabExplosion;
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        animationController = GetComponent<Animator>();
        originalPosition = new Vector2(transform.position.x, transform.position.y);

        StartCoroutine(Moving());
    }
    IEnumerator Moving()
    {
        yield return new WaitUntil(HasDetectPlayer);
        hasRun = true;
        AudioManager.Play(AudioClipName.MushroomDetection);
        yield return new WaitForSeconds(2);
        Destroy(gameObject);
        Vector3 location = new Vector3(originalPosition.x, originalPosition.y, Camera.main.transform.position.z);
        Instantiate<GameObject>(prefabExplosion, location, Quaternion.identity);

    }

    private bool HasDetectPlayer()
    {
        GameObject player = GameObject.FindGameObjectWithTag(Constants.TagPlayer);
        return Mathf.Abs(player.transform.position.x - originalPosition.x) <= detectDistance;
    }

    // Update is called once per frame
    void Update()
    {
        animationController.SetBool("running", rb2d.velocity.sqrMagnitude >= 0.9);
        if (hasRun)
        {
            GameObject player = GameObject.FindGameObjectWithTag(Constants.TagPlayer);
            originalPosition = new Vector2(transform.position.x, transform.position.y);
            bool isRight = transform.position.x - player.transform.position.x >= 0;
            Flip(isRight);
            rb2d.velocity = Vector2.zero;
            Vector2 direction = new Vector2(isRight ? -1 : 1, 0);
            rb2d.AddForce(direction * moveSpeed, ForceMode2D.Impulse);
            if (Mathf.Abs(player.transform.position.x - originalPosition.x) < 0.1)
                rb2d.velocity = Vector2.zero;

        }
    }

    void Flip(bool isRight)
    {
        // Multiply the player's x local scale by -1
        Vector3 theScale = transform.localScale;
        theScale.x = isRight ? -1 : 1;
        transform.localScale = theScale;
    }
}
