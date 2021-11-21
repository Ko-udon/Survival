using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DoorManager : MonoBehaviour
{
    public GameObject canvas;
    public GameObject yesButton;

    //public PlayerCharacter player;

    void Start()
    {
        //player=GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerCharacter>();
    }

    void Update()
    {
        if(GameManager.gameManager.time < 360)
        {
            transform.GetChild(0).GetComponent<Text>().text = "남은 시간이 6시간 미만이므로 나갈 수 없습니다.";
        }
        else
        {
            transform.GetChild(0).GetComponent<Text>().text = "밖으로 나가시겠습니까?";
        }
        
    }

    public void OnYesCilcked()
    {
        OnNoClicked();
        if(GameManager.gameManager.time >= 360)
        {
            //player.transform.position= new Vector2(-8,-2);
            SceneManager.LoadScene("Outside");
        }
    }

    public void OnNoClicked()
    {
        canvas.SetActive(false);
    }
}
