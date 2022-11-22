using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{

    public AudioSource musicSource;
    [SerializeField] float musicVolume;

    public AudioClip musicIntro;
    public AudioClip musicLoop;

    private void Start()
    {
        PlayMusicWithLoop();
    }

    public void PlayMusicWithLoop()
    {
        musicSource.clip = musicIntro;
        musicSource.volume = musicVolume;
        musicSource.Play();
        StartCoroutine(FadeMusic(true));

        StartCoroutine(ContinueMusicWithLoop());
    }

    IEnumerator ContinueMusicWithLoop()
    {
        float introTime = musicIntro.length;

        yield return new WaitForSeconds(introTime);

        musicSource.clip = musicLoop;
        musicSource.loop = true;
        musicSource.Play();
    }

    public void StopMusic()
    {
        StartCoroutine(FadeMusic(false));
    }

    IEnumerator FadeMusic(bool isFadeIn)
    {
        float timeToFade = 2f;
        float timeElapsed = 0f;

        if (isFadeIn)
        {
            while (timeElapsed < timeToFade)
            {
                musicSource.volume = Mathf.Lerp(0, musicVolume, timeElapsed / timeToFade);
                timeElapsed += Time.deltaTime;
                yield return null;
            }
        }
        else
        {
            while (timeElapsed < timeToFade)
            {
                musicSource.volume = Mathf.Lerp(musicVolume, 0, timeElapsed / timeToFade);
                timeElapsed += Time.deltaTime;
                yield return null;
            }

            musicSource.Stop();
        }
    }

}
