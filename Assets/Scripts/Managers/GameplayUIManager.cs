using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameplayUIManager : MonoBehaviour
{
    public static GameplayUIManager instance;
    public Text _scoreText;
    public Text _damageText;

    public GameObject pauseMenu;
    public Toggle pauseMenutoggle;

    private bool isToggleOn;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this);
        }
        else
        {
            instance = this;
        }
    }

    private void Start()
    {
        _scoreText.text = "Score : " + 0;
        isToggleOn = pauseMenutoggle.GetComponent<Toggle>().isOn;

    }

    public void OnClick_PauseButton()
    {
        if (isToggleOn) pauseMenu.SetActive(true);
        else pauseMenu.SetActive(false);
    }
}
