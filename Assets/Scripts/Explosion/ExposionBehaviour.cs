using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExposionBehaviour : MonoBehaviour
{
    private float delay = 0f;

    private void Start()
    {
        AudioManager.Play(AudioClipName.Explosion);
        Destroy(gameObject,this.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length + delay);
    }

}
