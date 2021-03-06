using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    public bool isDead = false;
    public bool isEnrage = false;
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
            if(isEnrage == false)
            {
                AudioManager.Play(AudioClipName.Boss_enrage_1);
                isEnrage = true;
            } 
            anim.SetTrigger("isEnrange");

        }
        if (currentHealth <= 0)
        {
            if (isDead == false)
            {
                AudioManager.Play(AudioClipName.Boss_death_1);
                isDead = true;
            }
            anim.SetTrigger("Death");
        }

    }

    public void CastSkill(int rand)
    {
        StartCoroutine(BossDelay(rand));
    }

    IEnumerator BossDelay(int rand)
    {
        yield return new WaitForSeconds(Random.Range(1.5f, 2f));
        if (rand == 0)
        {
            anim.SetTrigger("Jump");
        }
        else if (rand == 1)
        {
            anim.SetTrigger("Skill 1");
        }
        else if (rand == 2)
        {
            anim.SetTrigger("Approach");
        }
        else
        {
            anim.SetTrigger("Skill 2");
        }
    }


    public void OnDeathAnimationFinished()
    {
        Destroy(gameObject);
        Instantiate((GameObject)Resources.Load(checkpointEndGameLocation, typeof(GameObject)), transform.position, Quaternion.identity);
    }
}
