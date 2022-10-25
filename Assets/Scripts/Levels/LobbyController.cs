using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LobbyController : MonoBehaviour
{

    public Button buttonStart;
    public Button buttonQuit;
    public GameObject levelSelection;
    public void ButtonStart()
    {
        SoundManager.Instance.Play(Sounds.buttonClick);
        levelSelection.SetActive(true);
     
    }

    public void ButtonQuit()
    {
        SoundManager.Instance.Play(Sounds.buttonClick);
        SceneManager.LoadScene(0);
    }
}
