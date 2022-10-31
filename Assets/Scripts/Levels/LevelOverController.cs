using Assets.Scripts.Levels;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;



public class LevelOverController : MonoBehaviour
{

    public ParticleSystem dust;
    public int nextScenLoad;
    private void Start()
    {
        nextScenLoad = SceneManager.GetActiveScene().buildIndex + 1;
    }
    public void CreateDust()
    {
        dust.Play();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.GetComponent<Player_Controller>() != null)
        {
            LevelManager.Instance.SetCurrentLevelComplete();
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);   
        }
    }
}
