using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    private string state;

    public GameObject settingMenu;
    public GameObject skillMenu;

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
        switch(state)
        {
            case "Settings":
                settingMenu.SetActive(true);
                skillMenu.SetActive(false);
                break;

            case "Skills":
                skillMenu.SetActive(true);
                settingMenu.SetActive(false);
                break;
        }
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
