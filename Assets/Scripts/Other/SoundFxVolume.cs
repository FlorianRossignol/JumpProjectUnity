using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundFxVolume : MonoBehaviour
{
    [SerializeField] Slider slider_;
    [SerializeField] Slider sliderfx_;
    [SerializeField] AudioSource soundvolume_;
    [SerializeField] AudioClip walksound_;
    [SerializeField] AudioClip jumpsound_;


    public void VolumeSound()
    {
        soundvolume_.volume = slider_.value;
    }

    public void FxVolume()
    {
        soundvolume_.PlayOneShot(walksound_, soundvolume_.volume);
    }
}
