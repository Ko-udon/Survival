using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class showGimicTrigger : MonoBehaviour
{
    public GameObject showGimic;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            showGimic.SetActive(true);
        }
        
        
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            showGimic.SetActive(false);
        }
    }


}
