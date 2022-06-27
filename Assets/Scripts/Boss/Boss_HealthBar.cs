using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Boss_HealthBar : MonoBehaviour
{
    public float maxHealth = 200;
    private Slider slider;
    private float currHealth;
    private GameObject floatingTextPrefab;
    private Animator anim;
    private string healbarPrefabLocation = "Prefabs/Healthbar_Boss";
    private string floatingTextPrefabLocation = "Prefabs/FloatingText";
    public bool isVulnerable = false;

    void Awake()
    {
        anim = GameObject.FindGameObjectWithTag("Boss").GetComponent<Animator>();
        GameObject healthBarCanvas = Instantiate((GameObject)Resources.Load(healbarPrefabLocation, typeof(GameObject)));
        floatingTextPrefab = (GameObject)Resources.Load(floatingTextPrefabLocation, typeof(GameObject));
        healthBarCanvas.transform.parent = transform;
        slider = healthBarCanvas.GetComponentInChildren<Slider>();
        currHealth = maxHealth;
        slider.maxValue = maxHealth;
        slider.value = maxHealth;
    }

    public void TakeDamage(float damage, bool isCrit)
    {
        if (isVulnerable)
            return;
        
        currHealth -= damage;
        ShowDamage(damage, isCrit);
        SetHealth(currHealth);

        if (currHealth <= 100)
        {
            anim.SetTrigger("isEnrange");
        }
        if (currHealth <= 0)
        {
            // dead
            anim.SetTrigger("Death");
            //Destroy(gameObject);

        }
    }

    public void ShowDamage(float damage, bool isCrit)
    {
        Vector3 offset = new Vector3(Random.Range(-0.5f, 0.5f), Random.Range(-0.5f, 0.5f), 0f);

        GameObject floatDamage = Instantiate(floatingTextPrefab, transform.position + offset, Quaternion.identity);

        floatDamage.GetComponentInChildren<TextMesh>().text = damage.ToString();
        if (isCrit)
        {
            floatDamage.GetComponentInChildren<TextMesh>().color = Color.red;
        }
        Destroy(floatDamage, 1f);
    }


    public void SetHealth(float HP)
    {
        slider.value = HP;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void LateUpdate()
    {
        slider.transform.position = Camera.main.WorldToScreenPoint(transform.position + new Vector3(0f, 0.5f, 0f));
    }
}