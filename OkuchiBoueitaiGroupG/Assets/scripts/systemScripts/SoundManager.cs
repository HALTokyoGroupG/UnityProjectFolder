using UnityEngine;
using System.Collections;

public class SoundManager : MonoBehaviour {


    public AudioSource[] effectSource;
    public AudioSource LoopingeffectSource;
    public AudioSource musicSource;
    public static SoundManager instance = null;

    public float lowPitchRange = .95f;
    public float highPitchRange = 1.05f;

    private int RotateSource = 0;

    //==============================
    // 初期化処理
    //==============================
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }

    //==============================
    // 曲を流す処理
    //==============================
    public void PlayTrack(AudioClip clip)
    {
        if( musicSource.isPlaying )
        {
            musicSource.Stop();
        }
        musicSource.clip = clip;
        musicSource.Play();
    }

    //==============================
    // 曲を流す処理
    //==============================
    public void PlayLoop(AudioClip clip)
    {
        if (LoopingeffectSource.isPlaying)
        {
            LoopingeffectSource.Stop();
        }
        LoopingeffectSource.clip = clip;
        LoopingeffectSource.Play();
    }
    //==============================
    // 曲を流す処理
    //==============================
    public void StopLoop()
    {
        if (LoopingeffectSource.isPlaying)
        {
            LoopingeffectSource.Stop();
        }
    }

    //==============================
    // 曲を止める処理
    //==============================
    public void StopTrack()
    {
        if (musicSource.isPlaying)
        {
            musicSource.Stop();
        }
    }

    //==============================
    // 音を流す処理
    //==============================
    public void PlaySingle(AudioClip clip)
    {
        effectSource[RotateSource].clip = clip;
        effectSource[RotateSource].Play();
        RotateCount();
    }

    //==============================
    // ランダムな効果音を出す
    //==============================
    public void RandomiseSfx(params AudioClip[] clips)
    {
        int randomIndex = Random.Range(0, clips.Length);
        float randomPitch = Random.Range(lowPitchRange, highPitchRange);

        effectSource[RotateSource].pitch = randomPitch;
        effectSource[RotateSource].clip = clips[randomIndex];
        effectSource[RotateSource].Play();
        RotateCount();
    }

    //==============================
    // ランダムな効果音を出す
    //==============================
    public void RisingSfx(AudioClip clip, int count)
    {
        float Pitch = lowPitchRange + count / 100;

        effectSource[RotateSource].pitch = Pitch;
        effectSource[RotateSource].clip = clip;
        effectSource[RotateSource].Play();
        RotateCount();
    }

    void RotateCount()
    {
        RotateSource ++;
        if( RotateSource >= effectSource.Length )
        {
            RotateSource = 0;
        }
    }
}
