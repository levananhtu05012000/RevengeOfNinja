using Assets.Scripts.Common;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fb : MonoBehaviour
{
    [SerializeField]
    GameObject prefapExposionBoss;
    public float BossFireBallsAttack;



    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(Constants.TagPlayer))
        {
            BossFireBallsAttack = DataManager.Instance.gameData.BossFireBallsAttack;
            collision.GetComponent<HealthBarBehaviour>().TakeDamage(BossFireBallsAttack, false);
            Destroy(gameObject);
            Instantiate<GameObject>(prefapExposionBoss, transform.position, Quaternion.identity);
        }
        else if (collision.CompareTag(Constants.TagFireball))
        {
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
