using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DoorManager : MonoBehaviour
{
    public GameObject canvas;
    public GameObject yesButton;

    void Start()
    {
        
    }

    void Update()
    {
        if(GameManager.gameManager.time < 360)
        {
            transform.GetChild(0).GetComponent<Text>().text = "남은 시간이 6시간 미만이므로 밖으로 나갈 수 없습니다.";
            yesButton.GetComponent<Button>().interactable = false;
        }
        else
        {
            transform.GetChild(0).GetComponent<Text>().text = "밖으로 나가시겠습니까?";
            yesButton.GetComponent<Button>().interactable = true;
        }
        
    }

    public void OnYesCilcked()
    {
        OnNoClicked();
        SceneManager.LoadScene("Outside");
    }

    public void OnNoClicked()
    {
        canvas.SetActive(false);
    }
}
