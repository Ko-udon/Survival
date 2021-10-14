using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemInfo : MonoBehaviour
{
    public GameObject info_window;
    public string item_name;

    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClicked()
    {
        info_window.SetActive(true);
        info_window.transform.position = this.transform.position;
        info_window.transform.GetChild(0).GetComponent<Image>().sprite = this.GetComponent<Image>().sprite;
        info_window.transform.GetChild(1).GetComponent<Text>().text = this.item_name;
    }
}
