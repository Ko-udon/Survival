using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    private string state;

    public GameObject settingMenu;
    public GameObject skillMenu;

    public GameObject settingButton;
    public GameObject skillButton;
    private void OnEnable()
    {
        Time.timeScale = 0;
        state = "Settings";
        ChangeMenu();
    }

    void Start()
    {
        
    }

    
    void Update()
    {
        
    }

    void ChangeMenu()
    {
        switch (state)
        {
            case "Settings":
                settingMenu.SetActive(true);
                skillMenu.SetActive(false);
                ButtonAble(settingButton);
                ButtonDisable(skillButton);
                break;

            case "Skills":
                skillMenu.SetActive(true);
                settingMenu.SetActive(false);
                ButtonAble(skillButton);
                ButtonDisable(settingButton);
                break;
        }
    }

    void ButtonAble(GameObject button)
    {
        Image image = button.GetComponent<Image>();
        Text text = button.transform.GetChild(0).GetComponent<Text>();

        image.color = new Color(image.color.r, image.color.g, image.color.b, 1.0f);
        text.color = new Color(text.color.r, text.color.g, text.color.b, 1.0f);
    }

    void ButtonDisable(GameObject button)
    {
        Image image = button.GetComponent<Image>();
        Text text = button.transform.GetChild(0).GetComponent<Text>();

        image.color = new Color(image.color.r, image.color.g, image.color.b, 0.6f);
        text.color = new Color(text.color.r, text.color.g, text.color.b, 0.6f);
    }

    public void OnSettingsClicked()
    {
        state = "Settings";
        ChangeMenu();
    }

    public void OnSkillsClicked()
    {
        state = "Skills";
        ChangeMenu();
    }

    public void OnCloseClicked()
    {
        Time.timeScale = 1;
        this.gameObject.SetActive(false);
    }

    public void OnExitClicked()
    {
        Application.Quit();
    }

    public void OnMainClicked()
    {
        SceneManager.LoadScene("StartScene");
    }
}
