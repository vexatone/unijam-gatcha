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

        EffectSoundDictionary.Add("Coin1", Resources.Load<AudioClip>("Audio/SE/DM-CGS-45"));
        EffectSoundDictionary.Add("NextScene", Resources.Load<AudioClip>("Audio/SE/DM-CGS-26"));
        EffectSoundDictionary.Add("Jump", Resources.Load<AudioClip>("Audio/SE/Jump19"));
        EffectSoundDictionary.Add("DoubleJump", Resources.Load<AudioClip>("Audio/SE/Jump16"));
        EffectSoundDictionary.Add("Landing", Resources.Load<AudioClip>("Audio/SE/PUNCH_CLEAN_HEAVY_10"));  // 현재 안 씀
        EffectSoundDictionary.Add("Water", Resources.Load<AudioClip>("Audio/SE/Splash"));  // TODO
        EffectSoundDictionary.Add("Mouse", Resources.Load<AudioClip>("Audio/SE/Squeak"));  // TODO
        EffectSoundDictionary.Add("Stomp", Resources.Load<AudioClip>("Audio/SE/Stomp"));

        EffectSoundDictionary.Add("MainMenu", Resources.Load<AudioClip>("Audio/BGM/Palm Trees (w Joey Edwin) - Joakim Karud"));
        EffectSoundDictionary.Add("Intro", Resources.Load<AudioClip>("Audio/BGM/Road Trip - Joakim Karud"));
        EffectSoundDictionary.Add("Stage1", Resources.Load<AudioClip>("Audio/BGM/Fun Kid - Quincas Moreira"));
        EffectSoundDictionary.Add("Stage2", Resources.Load<AudioClip>("Audio/BGM/Nu Island - DayFox"));
        EffectSoundDictionary.Add("Stage3", Resources.Load<AudioClip>("Audio/BGM/Back To Summer - Nekzlo"));
        EffectSoundDictionary.Add("BadEnding", Resources.Load<AudioClip>("Audio/BGM/Bangla sad music 2023"));
        EffectSoundDictionary.Add("HappyEnding", Resources.Load<AudioClip>("Audio/BGM/Relax - Peyruis"));
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