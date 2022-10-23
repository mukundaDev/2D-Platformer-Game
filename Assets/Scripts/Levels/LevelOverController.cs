using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelOverController : MonoBehaviour
{
    public int nextScenLoad;
    private void Start()
    {
        nextScenLoad = SceneManager.GetActiveScene().buildIndex + 1;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.GetComponent<Player_Controller>() != null)
        {
            Debug.Log("YUP");
            SceneManager.LoadScene(nextScenLoad);

            if (nextScenLoad > PlayerPrefs.GetInt("levelAt"))
            {
                PlayerPrefs.SetInt("levelAt", nextScenLoad);
            }
        }
    }
}
