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
            // TODO: Player Take Damage
            Debug.Log($"{collision.tag} Take Damge by {transform.tag}");
        }
    }
}
