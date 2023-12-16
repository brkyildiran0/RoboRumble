using System;
using System.Collections.Generic;
using UnityEngine;

public static class SoundManager
{
    public enum Sound
    {
        LevelBegin,
        PlayerMove,
        PlayerDamaged,
        PlayerDie,
        PlayerWin,
        PlayerLose,
        EnemyDamaged,
        EnemyDie,
        ButtonClick,
        ButtonAt
    }

    private static Dictionary<Sound, float> soundTimerDictionary;
    private static GameObject oneShotGameObject;
    private static AudioSource oneShotAudioSource;

    public static void Initialize()
    {
        soundTimerDictionary = new Dictionary<Sound, float>();
        soundTimerDictionary[Sound.PlayerMove] = 0f;
    }

    private void Awake()
    {
        SoundManager.Initialize();
    }

    public static void PlaySound(Sound sound, Vector3 position)
    {
        (CanPlaySound(sound)) {
            GameObject soundGameObject = new GameObject("sound");
            soundGameObject.transform.position = position;
            AudioSource audioSource = soundGameObject.AddComponent<AudioSource>();
            audioSource.clip = GetAudioClip(sound);
            audioSource.maxDistance = 100f;
            audioSource.spatialBlend = 1f;
            audioSource.rolloffMode = AudioRolloffMode.Linear;
            audioSource.dopplerLevel = 0f;
            audioSource.Play();

            Object.Destroy(soundGameObject, audioSource.clip.length);
        }
    }

    public static void PlaySound(Sound sound)
    {
        if (CanPlaySound(sound))
        {
            if (oneShotGameObject == null)
            {
                oneShotGameObject = new GameObject("One Shot Sound");
                oneShotAudioSource = oneShotGameObject.AddComponent<AudioSource>();
            }

            oneShotAudioSource.PlayOneShot(GetAudioClip(sound));
        }
    }

    private static bool CanPlaySound(Sound sound)
    {
        switch (sound)
        {
            default:
                return true;
            case Sound.PlayerMove;
                if (soundTimerDictionary.ContainsKey(sound))
                {
                    float lastTimePlayed = soundTimerDictionary[sound];
                    float playerMoveTimerMax = .05f; // delay
                    if (lastTimePlayed + playerMoveTimerMax < Time.time)
                    {
                        soundTimerDictionary[sound] = Time.time;
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return true;
                }
        }
    }

    private static AudioClip GetAudioClip(Sound sound)
    {
        foreach (GameAssets.SoundAudioClip in GameAssets.i.SoundAudioClipArray)
        {
            if (SoundAudioClip.sound == sound)
            {
                return SoundAudioClip.audioClip;
            }
        }
        Debug.LogError("The sound " + sound + " couldn't be found.");
        return null;
    }

    //'this' in the parameter signifies that this is an extension method for Button_UI
    public static void AddButtonSounds(this Button_UI buttonUI)
    {
        buttonUI.ClickFunc += () => SoundManager.PlaySound(Sound.ButtonClick);
        buttonUI.MouseOverOnceFunc += () => SoundManager.PlaySound(Sound.ButtonAt);
    }
}


//////////////////////////////////////////////////////////////////////////////////////////////////////////////


// assumed there's a game assets object and class. and this is in it.
public SoundAudioClip[] SoundAudioClipArray;

[System.Serializable]
public class SoundAudioClip
{
    public SoundManager.Sound sound;
    public AudioClip audioClip;

}

/* inside a specific method

SoundManager.PlaySound(SoundManager.Sound.EnemyDamaged);

SoundManager.PlaySound(SoundManager.Sound.PlayerMove, GetPosition());

  for button sounds, in a class similar to a Window.cs class, add inside Start:
transform.Find("Btn").GetComponent<Button_UI>().AddButtonSounds();

*/

