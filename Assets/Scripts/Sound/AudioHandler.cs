using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioHandler : MonoBehaviour
{
    public static AudioHandler instance;

    [Header("Sound Fx")]
    public ClipSound[] clipSoundsArray;


    private void Awake()
    {
        if (instance == null)
            instance = this;
    }

    [System.Serializable]
    public class ClipSound
    {
        public SoundManager.soundList sound;
        public AudioClip audioClip;
    }   
}


