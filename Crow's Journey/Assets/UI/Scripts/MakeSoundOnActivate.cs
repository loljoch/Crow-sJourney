using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ChrisTutorials.Persistent;

public class MakeSoundOnActivate : MonoBehaviour
{
    [SerializeField] AudioClip soundToMakeOnEnable;
    [SerializeField] float volume;

    private void OnEnable()
    {
        AudioManager.Instance.Play(soundToMakeOnEnable, transform, volume);
    }
}
