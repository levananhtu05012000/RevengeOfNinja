using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuffController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public bool CollectBuffHP()
    {
        return GetComponent<HealthBarBehaviour>().BuffHP(12);
    }
}
