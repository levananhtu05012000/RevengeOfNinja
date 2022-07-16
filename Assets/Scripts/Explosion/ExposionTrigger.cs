using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Common;
using UnityEngine;

public class ExposionTrigger : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals(Constants.TagPlayer))
        {
            GameObject.FindGameObjectWithTag(Constants.TagPlayer).GetComponent<HealthBarBehaviour>().TakeDamage(Constants.MushroomDmg, false);
        }
    }
}
