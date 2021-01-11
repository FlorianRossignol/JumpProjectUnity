using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundVolume : MonoBehaviour
{
    [SerializeField] Slider slider_;
    [SerializeField] AudioSource soundvolume_;


    public void VolumeSound()
    {
        soundvolume_.volume = slider_.value;
    }
}
