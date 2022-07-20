using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "PlayerSkill", menuName = "PlayerSkill/ThrowShuriken", order = 3)]
public class ThrowShuriken : Skill
{
    public float shurikenSpeed;
    public GameObject shurikenPrefab;


    public override void Activate(GameObject parent)
    {
        PlayerMovement movement = parent.GetComponent<PlayerMovement>();
        Rigidbody2D rigidbody = parent.GetComponent<Rigidbody2D>();

        if (parent.GetComponent<BuffController>().UseShuriken())
        {
            AudioManager.Play(AudioClipName.PlayerShuriken);
            GameObject newShuriken = Instantiate(shurikenPrefab, parent.transform.position, Quaternion.identity);
            newShuriken.GetComponent<Rigidbody2D>().velocity = new Vector2(parent.transform.localScale.x * shurikenSpeed, 0f);
        }


    }
    public override void BeginCooldown(GameObject parent)
    {

    }
}
