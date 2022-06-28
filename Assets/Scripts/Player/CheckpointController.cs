using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointController : MonoBehaviour
{
    private GameObject currentCheckpoint;
    private int lifeCount = 3;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

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
        if (lifeCount > 0)
        {
            transform.position = currentCheckpoint.transform.position;
            lifeCount--;
        }
        else
        {
            // END GAME
            Debug.Log("End Game");
        }
    }
}
