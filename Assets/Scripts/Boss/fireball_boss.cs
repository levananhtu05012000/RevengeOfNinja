using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fireball_boss : MonoBehaviour
{
    public GameObject fireBall;
    public Transform[] firePoints = new Transform[3];
    public float fireForce;
    private Animator anim;
    private int count = 0;
    private float sec = 0.01f;
    // Start is called before the first frame 


    private void Awake()
    {
        anim = GameObject.FindGameObjectWithTag("Boss").GetComponent<Animator>();
    }
    
    public void fire()
    {
        foreach (Transform firePoint in firePoints)
        {
            GameObject projectile = Instantiate(fireBall, firePoint.position, firePoint.rotation);
            projectile.GetComponent<Rigidbody2D>().AddForce(firePoint.up * fireForce, ForceMode2D.Impulse);
        }
    }

    IEnumerator fire1() {

        foreach (Transform firePoint in firePoints)
        {
            if(count == 2)
            {
                sec = 0.1f;
            }
            if (count == 3)
            {
                sec = 0.01f;
            }
            GameObject projectile = Instantiate(fireBall, firePoint.position, firePoint.rotation);
            projectile.GetComponent<Rigidbody2D>().AddForce(firePoint.up * fireForce, ForceMode2D.Impulse);
            yield return new WaitForSeconds(sec);
            count += 1;
        }
        count = 0;
        sec = 0.01f;
    }

}
