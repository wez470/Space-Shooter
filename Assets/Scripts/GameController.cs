using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameController : MonoBehaviour {
    public static GameController Instance;
    public GameObject GameOverMenu;

    void Awake() {
        Instance = this;
        setupBulletCollisions();
    }

    private void setupBulletCollisions() {
        int bulletLayer = LayerMask.NameToLayer("Bullet");
        int playerLayer = LayerMask.NameToLayer("Player");
        Physics2D.IgnoreLayerCollision(bulletLayer, bulletLayer, true);
        Physics2D.IgnoreLayerCollision(bulletLayer, playerLayer, true);
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
