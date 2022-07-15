using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class StatsController : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private TextMeshProUGUI countExpText;
    [SerializeField]
    private TextMeshProUGUI attackDamageText;
    [SerializeField]
    private TextMeshProUGUI maxHealthText;
    [SerializeField]
    private TextMeshProUGUI critRateText;
    [SerializeField]
    private TextMeshProUGUI critDamageText;

    [SerializeField]
    private Button btnPlusAttackDamage, btnPlusMaxHealth, btnPlusCritRate, btnPlusCritDamage;

    [SerializeField]
    private Button btnSubtractAttackDamage, btnSubtractMaxHealth, btnSubtractCritRate, btnSubtractCritDamage;

    private float attackDamageValue = 0;
    private float maxHealthValue = 0;
    private float critRateValue = 0;
    private float critDamageValue = 0;
    private int countExpValue = 0;

    void Start()
    {
        LoadInitData();
        UpdateUIData();
        LoadListener();

        if (PlayerPrefs.HasKey("attackDamage")) SaveStats();
    }

    void LoadInitData()
    {
        if (PlayerPrefs.HasKey("attackDamageValue"))
            attackDamageValue = PlayerPrefs.GetFloat("attackDamageValue");
        else
            attackDamageValue = DataManager.Instance.gameData.playerDamage;

        if (PlayerPrefs.HasKey("maxHealthValue"))
            maxHealthValue = PlayerPrefs.GetFloat("maxHealthValue");
        else
            maxHealthValue = DataManager.Instance.gameData.playerMaxHealth;

        if (PlayerPrefs.HasKey("critRateValue"))
            critRateValue = PlayerPrefs.GetFloat("critRateValue");
        else
            critRateValue = DataManager.Instance.gameData.playerCritRate;

        if (PlayerPrefs.HasKey("critDamageValue"))
            critDamageValue = PlayerPrefs.GetFloat("critDamageValue");
        else
            critDamageValue = DataManager.Instance.gameData.playerCritDamage;

        if (PlayerPrefs.HasKey("expValue"))
            countExpValue = PlayerPrefs.GetInt("expValue");
        else
            countExpValue = 10;
    }

    void UpdateUIData()
    {
        attackDamageText.text = attackDamageValue.ToString();
        maxHealthText.text = maxHealthValue.ToString();
        critRateText.text = critRateValue.ToString() + "%";
        critDamageText.text = critDamageValue.ToString();
        countExpText.text = countExpValue.ToString();
    }

    void LoadListener()
    {
        btnPlusAttackDamage.onClick.AddListener(delegate { UpgradeStats(1, true); });
        btnSubtractAttackDamage.onClick.AddListener(delegate { UpgradeStats(1, false); });
        btnPlusMaxHealth.onClick.AddListener(delegate { UpgradeStats(2, true); });
        btnSubtractMaxHealth.onClick.AddListener(delegate { UpgradeStats(2, false); });
        btnPlusCritRate.onClick.AddListener(delegate { UpgradeStats(3, true); });
        btnSubtractCritRate.onClick.AddListener(delegate { UpgradeStats(3, false); });
        btnPlusCritDamage.onClick.AddListener(delegate { UpgradeStats(4, true); });
        btnSubtractCritDamage.onClick.AddListener(delegate { UpgradeStats(4, false); });
    }

    private void UpgradeStats(int statIndex, bool isPlus)
    {
        if (isPlus && countExpValue < DataManager.Instance.gameData.expToUpLevel) return;

        int coefficient = 1;
        if (!isPlus) coefficient = -1;

        bool isValidUpgrade = true;
        switch (statIndex)
        {
            case 1: // attackDamage
                float plusPlayerAttackDamage = DataManager.Instance.gameData.plusPlayerDamage;
                if (attackDamageValue + coefficient * plusPlayerAttackDamage < DataManager.Instance.gameData.playerDamage)
                {
                    isValidUpgrade = false;
                }
                else
                {
                    attackDamageValue += coefficient * plusPlayerAttackDamage;
                }
                break;

            case 2: // maxHealth
                float plusPlayerMaxHealth = DataManager.Instance.gameData.plusPlayerMaxHealth;
                if (maxHealthValue + coefficient * plusPlayerMaxHealth < DataManager.Instance.gameData.playerMaxHealth)
                {
                    isValidUpgrade = false;
                }
                else
                {
                    maxHealthValue += coefficient * plusPlayerMaxHealth;
                }
                break;

            case 3: // critRate
                float plusPlayerCritRate = DataManager.Instance.gameData.plusPlayerCritRate;
                if (critRateValue + coefficient * plusPlayerCritRate < DataManager.Instance.gameData.playerCritRate)
                {
                    isValidUpgrade = false;
                }
                else
                {
                    critRateValue += coefficient * plusPlayerCritRate;
                }
                break;

            case 4: // critDamage
                float plusPlayerCritDamage = DataManager.Instance.gameData.plusPlayerCritDamage;
                if (critDamageValue + coefficient * plusPlayerCritDamage < DataManager.Instance.gameData.playerCritDamage)
                {
                    isValidUpgrade = false;
                }
                else
                {
                    critDamageValue += coefficient * plusPlayerCritDamage;
                }
                break;

            default:
                break;
        }

        if (isValidUpgrade)
        {
            if (isPlus)
            {
                countExpValue -= DataManager.Instance.gameData.expToUpLevel;
            }
            else
            {
                countExpValue += DataManager.Instance.gameData.expToUpLevel;
            }
            UpdateUIData();
            SaveStats();
        }

    }



    public void SaveStats()
    {
        PlayerPrefs.SetFloat("attackDamageValue", attackDamageValue);
        PlayerPrefs.SetFloat("maxHealthValue", maxHealthValue);
        PlayerPrefs.SetFloat("critRateValue", critRateValue);
        PlayerPrefs.SetFloat("critDamageValue", critDamageValue);
        PlayerPrefs.SetInt("expValue", countExpValue);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
