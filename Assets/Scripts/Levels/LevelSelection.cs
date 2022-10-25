using Assets.Scripts.Levels;
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
        LevelStatus levelStatus = LevelManager.Instance.GetLevelStatus(LevelName);
        switch (levelStatus)
        {
            case LevelStatus.Locked:
                break;
            case LevelStatus.UnLocked:
                SoundManager.Instance.Play(Sounds.buttonClick);
                SceneManager.LoadScene(LevelName);
                break;
            case LevelStatus.Completed:
                SoundManager.Instance.Play(Sounds.buttonClick);
                SceneManager.LoadScene(LevelName);
                break;
        }
    }
}
