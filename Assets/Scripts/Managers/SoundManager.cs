using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance { get; private set; }

    public AudioSource BgmPlayer;
    public AudioSource EffectPlayer;

    public float BGMVolume { get; set; }
    public float EffectVolume { get; set; }
    
    [SerializeField] private AudioClip[] EffectAudioClips;

    private Dictionary<string, AudioClip> EffectSoundDictionary = new Dictionary<string, AudioClip>();

    void Awake()
    {
        if (Instance != null && Instance != this) Destroy(this);
        Instance = this;
        DontDestroyOnLoad(this.gameObject);

        GameObject EffectTempObject = new GameObject("Effect");
        EffectTempObject.transform.SetParent(gameObject.transform);
        EffectPlayer = EffectTempObject.AddComponent<AudioSource>();

        GameObject BgmTempObject = new GameObject("Bgm");
        BgmTempObject.transform.SetParent(gameObject.transform);
        BgmPlayer = BgmTempObject.AddComponent<AudioSource>();

        foreach (AudioClip audioclip in EffectAudioClips)
        {
            EffectSoundDictionary.Add(audioclip.name, audioclip);
        }

        BGMVolume = 1f;
        EffectVolume = 0.3f;

        EffectSoundDictionary.Add("GetCoin", Resources.Load<AudioClip>("Audio/DM-CGS-45"));
        EffectSoundDictionary.Add("NextScene", Resources.Load<AudioClip>("Audio/DM-CGS-26"));
        EffectSoundDictionary.Add("Jump", Resources.Load<AudioClip>("Audio/PUNCH_CLEAN_HEAVY_10"));

    }

    void Start()
    {
        
    }

    public void PlayEffect(string name)
    {
        EffectPlayer.PlayOneShot(EffectSoundDictionary[name], EffectVolume);
    }

    public void PlayBgm(string name)
    {
        BgmPlayer.loop = true;
        BgmPlayer.volume = BGMVolume;

        BgmPlayer.clip = EffectSoundDictionary[name];
        BgmPlayer.Play();
    }

    public void StopBgm()
    {
        BgmPlayer.clip = null;
        BgmPlayer.Stop();
    }

}