using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_Weapon : MonoBehaviour
{
    // Start is called before the first frame update
    private float bossDamageNormal;
    private float BossDamageEnrage;
    private float BossJumpAttack;
    private float BossFireBlastingAttack;

    public Vector3 attackOffset;
    public float attackRange = 1f;
    public LayerMask attackMask;

    public void Attack()
    {
        Vector3 pos = transform.position;
        pos += transform.right * attackOffset.x;
        pos += transform.up * attackOffset.y;

        Collider2D colInfo = Physics2D.OverlapCircle(pos, attackRange, attackMask);
        AudioManager.Play(AudioClipName.Boss_Heavy_sword);
        if (colInfo != null)
        {
            bossDamageNormal = DataManager.Instance.gameData.bossDamageNormal;
            colInfo.GetComponent<HealthBarBehaviour>().TakeDamage(bossDamageNormal, false);
        }
    }

    public void EnragedAttack()
    {
        Vector3 pos = transform.position;
        pos += transform.right * attackOffset.x;
        pos += transform.up * attackOffset.y;
        AudioManager.Play(AudioClipName.Boss_Heavy_sword);
        Collider2D colInfo = Physics2D.OverlapCircle(pos, attackRange, attackMask);
        if (colInfo != null)
        {
            BossDamageEnrage = DataManager.Instance.gameData.BossDamageEnrage;
            colInfo.GetComponent<HealthBarBehaviour>().TakeDamage(BossDamageEnrage, false);
        }
    }

    public void JumpAttack()
    {
        Vector3 pos = transform.position;
        pos += transform.right * attackOffset.x;
        pos += transform.up * attackOffset.y;
        AudioManager.Play(AudioClipName.Boss_jump);

        Collider2D colInfo = Physics2D.OverlapCircle(pos, attackRange, attackMask);
        if (colInfo != null)
        {
            BossJumpAttack = DataManager.Instance.gameData.BossJumpAttack;
            colInfo.GetComponent<HealthBarBehaviour>().TakeDamage(BossJumpAttack, false);
        }
    }

    public void Skill1()
    {
        Vector3 pos = transform.position;
        pos += transform.right * attackOffset.x;
        pos += transform.up * attackOffset.y;
        AudioManager.Play(AudioClipName.Boss_Fire_blasting_Boss_skill1);

        Collider2D colInfo = Physics2D.OverlapCircle(pos, attackRange, attackMask);
        if (colInfo != null)
        {
            BossFireBlastingAttack = DataManager.Instance.gameData.BossFireBlastingAttack;
            colInfo.GetComponent<HealthBarBehaviour>().TakeDamage(BossFireBlastingAttack, false);

        }
    }


    void OnDrawGizmosSelected()
    {
        Vector3 pos = transform.position;
        pos += transform.right * attackOffset.x;
        pos += transform.up * attackOffset.y;

        Gizmos.DrawWireSphere(pos, attackRange);
    }
}
