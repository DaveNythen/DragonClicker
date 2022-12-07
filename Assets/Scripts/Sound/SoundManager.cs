using UnityEngine;

public static class SoundManager
{
    public enum soundList { smash, smashFail};

    private static GameObject soundOneShot;
    private static AudioSource oneShotAudioSource;

    public static void PlaySound(soundList _soundToPlay)
    {
        if (soundOneShot == null)
        {
            soundOneShot = new GameObject("Sound One Shot");
            soundOneShot.transform.parent = GameObject.Find("AudioManager").transform;
            oneShotAudioSource = soundOneShot.AddComponent<AudioSource>();
            oneShotAudioSource.volume = 0.5f;
        }

        oneShotAudioSource.PlayOneShot(GetClip(_soundToPlay));
    }

    public static void PlaySound3D(soundList _soundToPlay, Vector3 position)
    {
        GameObject soundGO = new GameObject("Sound 3D");
        soundGO.transform.parent = GameObject.Find("AudioManager").transform;
        soundGO.transform.position = position;

        AudioSource audioSource = soundGO.AddComponent<AudioSource>();
        audioSource.clip = GetClip(_soundToPlay);
        audioSource.maxDistance = 25f; //Maybe need to adjust
        audioSource.spatialBlend = 1f;
        audioSource.rolloffMode = AudioRolloffMode.Linear;
        audioSource.dopplerLevel = 0f;
        audioSource.Play();

        Object.Destroy(soundGO, audioSource.clip.length); //Destroy when the clip is finished
    }

    private static AudioClip GetClip(soundList _soundToPlay)
    {
        foreach (AudioHandler.ClipSound clipSound in AudioHandler.Instance.clipSoundsArray)
        {
            if(clipSound.sound == _soundToPlay)
            {
                return clipSound.audioClip;
            }
        }
        Debug.LogError("Sound " + _soundToPlay + " does not exist!");
        return null;
    }

    //Not used
    public static void MuteSounds()
    {
        oneShotAudioSource.mute = !oneShotAudioSource.mute;
    }
}
