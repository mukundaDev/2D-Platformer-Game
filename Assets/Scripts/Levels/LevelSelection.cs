using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class LevelSelection : MonoBehaviour
{
    private Button lvlButton;
    public string LevelName;

    private void Start()
    {
        lvlButton = GetComponent<Button>();
        lvlButton.onClick.AddListener(onClick);
    }

    public void onClick()
    {
        SceneManager.LoadScene(LevelName);
    }
}
