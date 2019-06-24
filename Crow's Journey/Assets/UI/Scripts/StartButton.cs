using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using ChrisTutorials.Persistent;

public class StartButton : MonoBehaviour
{
    [SerializeField] AudioClip buttonnClick;

    public void StartGame()
    {
        AudioManager.Instance.Play(buttonnClick, transform, 0.4f);
        BgSound.Instance.SwitchBgMusic();
        SceneManager.LoadScene(1);
    }
}
