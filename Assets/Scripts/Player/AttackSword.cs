using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerSkill", menuName = "PlayerSkill/AttackSword", order = 1)]
public class AttackSword : Skill
{
    private Transform swordPoint;
    public float attackRange = 0.33f;
    public LayerMask enemyLayers;

    public override void Activate(GameObject parent)
    {
        PlayerMovement movement = parent.GetComponent<PlayerMovement>();
        Rigidbody2D rigidbody = parent.GetComponent<Rigidbody2D>();
        Animator anim = parent.GetComponent<Animator>();

        swordPoint = parent.transform.Find("SwordPoint").transform;

        anim.SetTrigger("attack");

        float critRate = DataManager.Instance.gameData.playerCritRate;
        bool isCrit = Random.Range(0, 100) <= critRate;
        if (isCrit)
            anim.SetFloat("attackState", 2);
        else
            anim.SetFloat("attackState", 1);

        // Xác định địch dính chiêu
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(swordPoint.position, attackRange, enemyLayers);

        // Gây dame
        foreach (Collider2D enemy in hitEnemies)
        {
            Debug.Log(enemy.name);

            float swordDamage = DataManager.Instance.gameData.playerDamage;

            enemy.GetComponent<HealthBarBehaviour>().TakeDamage(swordDamage, isCrit);
        }

    }
    public override void BeginCooldown(GameObject parent)
    {

    }
}
