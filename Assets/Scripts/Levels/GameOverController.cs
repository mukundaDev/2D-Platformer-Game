using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverController : MonoBehaviour
{
    public Button buttonRestart;
    public Button buttonMainmenu;
 

    private void Awake()
    {
        buttonRestart.onClick.AddListener(RestartButton);
        buttonMainmenu.onClick.AddListener(MainMenuButton);
    }
    public void PlayerDied()
    {
        gameObject.SetActive(true);
    }
    public void RestartButton()
    {
      Scene scene = SceneManager.GetActiveScene();
      SceneManager.LoadScene(scene.buildIndex);
    }
    public void MainMenuButton()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
