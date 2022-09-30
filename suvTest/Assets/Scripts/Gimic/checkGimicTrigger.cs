using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkGimicTrigger : MonoBehaviour
{
    GimicManager gimicManager;
    public string type;
    // Start is called before the first frame update
    void Start()
    {
        gimicManager = GameObject.FindGameObjectWithTag("Gimic1").GetComponent<GimicManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            gimicManager.addType(type);
            this.gameObject.SetActive(false);
        }


    }
}
