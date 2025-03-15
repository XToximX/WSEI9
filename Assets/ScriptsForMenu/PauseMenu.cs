using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenu;
    private bool isPaused = false;

    public void Pause()
    {
        pauseMenu.SetActive(true);
    }
    public void Home()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void Resume()
    {
        isPaused = !isPaused;
        pauseMenu.SetActive(false);
        Time.timeScale = isPaused ? 0f : 1f;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            isPaused = !isPaused;
            pauseMenu.SetActive(!pauseMenu.activeSelf);
            Time.timeScale = isPaused ? 0f : 1f;
        }
    }
}
