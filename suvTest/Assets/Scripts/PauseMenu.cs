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

    public GameObject scroll;

    private Scrollbar scrollBar;

    private List<GameObject> ableUI;
    private void OnEnable()
    {
        Time.timeScale = 0;
        state = "Settings";
        ChangeMenu();
        DisableOther();
    }

    private void OnDisable()
    {
        EnableOther();
    }

    void Start()
    {
        scrollBar = scroll.GetComponent<Scrollbar>();
    }

    
    void Update()
    {
        scrollBar.size = 0.1f;
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
                scrollBar.value = 1;
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
        if(state != "Settings")
        {
            state = "Settings";
            ChangeMenu();
        }
    }

    public void OnSkillsClicked()
    {
        if(state != "Skills")
        {
            state = "Skills";
            ChangeMenu();
        }
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

    public void DisableOther()
    {
        ableUI = new List<GameObject>();
        for (int i = 0; i < transform.parent.transform.childCount; i++)
        {
            GameObject ui = transform.parent.transform.GetChild(i).gameObject;
            if (ui != this.gameObject && ui.activeSelf)
            {
                ableUI.Add(ui);
                ui.SetActive(false);
            }
        }
    }

    public void EnableOther()
    {
        foreach(GameObject ui in ableUI)
        {
            ui.SetActive(true);
        }
        ableUI.Clear();
    }
}
