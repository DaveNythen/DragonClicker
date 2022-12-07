using UnityEngine;

public class AudioHandler : Singleton<AudioHandler>
{
    [Header("Sound Fx")]
    public ClipSound[] clipSoundsArray;

    [System.Serializable]
    public class ClipSound
    {
        public SoundManager.soundList sound;
        public AudioClip audioClip;
    }   
}


