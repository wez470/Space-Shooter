using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameController : MonoBehaviour {
    public static GameController Instance;
    public GameObject GameOverMenu;

    void Awake() {
        Instance = this;
    }

    public void GameOver() {
        GameOverMenu.SetActive(true);
    }

    public void Restart() {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Quit() {
        Application.Quit();
    }
}
