using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomStageManager : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void OnInventoryClicked(GameObject window)
    {
        window.SetActive(true);
    }

    public void OnCraftClicked(GameObject window)
    {
        window.SetActive(true);
    }

    public void OnClosetClicked(GameObject window)
    {
        window.SetActive(true);
    }
}
