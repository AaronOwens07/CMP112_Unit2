using UnityEngine;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenuUI;
    public GameObject controllsMenu;
    public bool isPaused = false;
    public PlayerLightController playerLightController;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseMenuLogic();
        }
    }

    void PauseMenuLogic()
    {
        if (isPaused)
        {
            pauseMenuUI.SetActive(false);
            isPaused = false;
            playerLightController.enabled = true;
        }
        else
        {
            pauseMenuUI.SetActive(true);
            isPaused = true;
            playerLightController.enabled = false;
        }
    }

    public void ResumeGame()
    {
        pauseMenuUI.SetActive(false);
        isPaused = false;
    }

    public void QuitGame()
    {
        Debug.Log("Quitting Game...");
        Application.Quit();
    }

    public void Controlls()
    {
        controllsMenu.SetActive(true);
    }
}
