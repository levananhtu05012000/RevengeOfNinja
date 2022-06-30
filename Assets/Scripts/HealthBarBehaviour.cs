using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HealthBarBehaviour : MonoBehaviour
{
    public float maxHealth = 50;
    private Slider slider;
    private float currHealth;
    private GameObject floatingTextPrefab;
    private string healbarPrefabLocation = "Prefabs/Healthbar";
    private string floatingTextPrefabLocation = "Prefabs/FloatingText";
    private string playerHealbarPrefabLocation = "Prefabs/PlayerHealthBarCanvas";

    void Awake()
    {
        GameObject healthBarCanvas;
        if (gameObject.CompareTag("Player"))
        {
            healthBarCanvas = Instantiate((GameObject)Resources.Load(playerHealbarPrefabLocation, typeof(GameObject)));
            maxHealth = DataManager.Instance.gameData.playerMaxHealth;

        }
        else
        {
            healthBarCanvas = Instantiate((GameObject)Resources.Load(healbarPrefabLocation, typeof(GameObject)));
        }


        floatingTextPrefab = (GameObject)Resources.Load(floatingTextPrefabLocation, typeof(GameObject));
        healthBarCanvas.transform.parent = transform;
        slider = healthBarCanvas.GetComponentInChildren<Slider>();
        currHealth = maxHealth;
        slider.maxValue = maxHealth;
        slider.value = maxHealth;
    }

    public void TakeDamage(float damage, bool isCrit)
    {
        if (isCrit)
        {
            damage = Mathf.Ceil(damage * DataManager.Instance.gameData.playerCritDamage);
        }

        currHealth -= damage;
        ShowDamage(damage, isCrit);
        SetHealth(currHealth);
        if (currHealth <= 0)
        {
            if (gameObject.CompareTag("Player"))
            {
                GetComponent<BuffController>().Respawn();
            }
            else
            {
                Destroy(gameObject);
            }

        }
    }

    public void ShowDamage(float damage, bool isCrit)
    {
        Vector3 offset = new Vector3(Random.Range(-0.5f, 0.5f), Random.Range(-0.5f, 0.5f), 0f);

        GameObject floatDamage = Instantiate(floatingTextPrefab, transform.position + offset, Quaternion.identity);

        floatDamage.GetComponentInChildren<TextMeshPro>().text = damage.ToString();
        if (isCrit)
        {
            floatDamage.GetComponentInChildren<TextMeshPro>().color = Color.red;
        }
        Destroy(floatDamage, 1f);
    }

    public bool BuffHP(float buffHP)
    {
        if (currHealth >= maxHealth) return false;
        currHealth += buffHP;
        if (currHealth >= maxHealth) currHealth = maxHealth;
        SetHealth(currHealth);
        return true;
    }


    public void SetHealth(float HP)
    {
        slider.value = HP;
    }

    public void ResetMaxHealth()
    {
        SetHealth(maxHealth);
        currHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void LateUpdate()
    {
        if (!gameObject.CompareTag("Player"))
        {
            slider.transform.position = Camera.main.WorldToScreenPoint(transform.position + new Vector3(0f, 0.5f, 0f));
        }
    }
}
