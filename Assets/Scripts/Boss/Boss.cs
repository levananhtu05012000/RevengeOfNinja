using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    public Transform player;
    public bool isFlipped = false;
    private Animator anim;
    private string checkpointEndGameLocation = "Prefabs/CheckpointEndGame";

    private void Start()
    {
        anim = GetComponent<Animator>();
    }


    public void LookAtPlayer()
    {

        Vector3 flipped = transform.localScale;
        flipped.z *= -1f;

        if (transform.position.x > player.position.x && isFlipped)
        {
            transform.localScale = flipped;
            transform.Rotate(0f, 180f, 0f);
            isFlipped = false;
        }
        else if (transform.position.x < player.position.x && !isFlipped)
        {
            transform.localScale = flipped;
            transform.Rotate(0f, 180f, 0f);
            isFlipped = true;
        }
    }

    private void Update()
    {
        float currentHealth = gameObject.GetComponent<HealthBarBehaviour>().CurrHealth;
        if (currentHealth <= DataManager.Instance.gameData.bossEnrangeHealth)
        {
            anim.SetTrigger("isEnrange");
        }
        if (currentHealth <= 0)
        {
            anim.SetTrigger("Death");
        }

    }

    public void OnDeathAnimationFinished()
    {
        Destroy(gameObject);
        Instantiate((GameObject)Resources.Load(checkpointEndGameLocation, typeof(GameObject)), transform.position, Quaternion.identity);
    }
}
