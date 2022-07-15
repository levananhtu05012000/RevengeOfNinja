using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BuffController : MonoBehaviour
{
    [Header("UI Count")]
    [SerializeField]
    private TextMeshProUGUI countShuriken;
    [SerializeField]
    private TextMeshProUGUI countLife;
    [SerializeField]
    private TextMeshProUGUI countExp;

    private int currShuriken = 0;
    private int currLife = 0;
    private int currExp = 0;

    private GameObject currentCheckpoint;

    private GameObject endGameUI;

    private void Awake()
    {
        currShuriken = DataManager.Instance.gameData.numberShuriken;
        currLife = DataManager.Instance.gameData.numberLife;
        UpdateUICount();
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void UpdateUICount()
    {
        countShuriken.text = currShuriken.ToString();
        countLife.text = currLife.ToString();
        countExp.text = currExp.ToString();
    }

    public bool CollectBuffHP()
    {
        return GetComponent<HealthBarBehaviour>().BuffHP(DataManager.Instance.gameData.buffHP);
    }

    public void CollectShuriken()
    {
        currShuriken += 1;
        UpdateUICount();
    }
    public void CollectEXP()
    {
        currExp += 1;
        UpdateUICount();
    }

    public void ChangeCheckpoint(GameObject newCheckPoint)
    {
        if (currentCheckpoint != null)
        {
            currentCheckpoint.transform.Find("InactiveCheckpoint").gameObject.SetActive(true);
            currentCheckpoint.transform.Find("ActiveCheckpoint").gameObject.SetActive(false);
        }
        currentCheckpoint = newCheckPoint;
        currentCheckpoint.transform.Find("InactiveCheckpoint").gameObject.SetActive(false);
        currentCheckpoint.transform.Find("ActiveCheckpoint").gameObject.SetActive(true);
    }

    public void Respawn()
    {
        if (currLife > 0)
        {
            GetComponent<HealthBarBehaviour>().ResetMaxHealth();
            transform.position = currentCheckpoint.transform.position;
            currLife--;
            UpdateUICount();
        }
        else
        {
            // END GAME
            Debug.Log("End Game");
            DisplayEndGameUI("Game Over", 0);
        }
    }

    public bool UseShuriken()
    {
        if (currShuriken > 0)
        {
            currShuriken--;
            UpdateUICount();
            return true;
        }
        else return false;
    }

    public void FinishGame()
    {
        PlayerPrefs.SetInt("expValue", PlayerPrefs.GetInt("expValue") + currExp);
        DisplayEndGameUI("Complete Level", currExp);
    }

    public void DisplayEndGameUI(string message, int expCount)
    {
        GameObject endGameUICanvas = Instantiate((GameObject)Resources.Load("Prefabs/EndGameUI", typeof(GameObject)));
        endGameUICanvas.transform.Find("Background").Find("Message").GetComponent<TextMeshProUGUI>().text = message;
        endGameUICanvas.transform.Find("Background").Find("CountEXP").GetComponent<TextMeshProUGUI>().text = expCount.ToString();
        endGameUICanvas.transform.Find("Background").Find("ButtonReplay").GetComponent<Button>()
            .onClick.AddListener(() =>
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            });
        endGameUICanvas.transform.Find("Background").Find("ButtonSelectLevel").GetComponent<Button>()
             .onClick.AddListener(() =>
             {
                 SceneManager.LoadScene("ChooseLevel");
             });
    }
}
