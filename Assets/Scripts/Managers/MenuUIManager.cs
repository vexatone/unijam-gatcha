using UnityEngine;
using UnityEngine.UI;

class MenuUIManager : MonoBehaviour
{
    [SerializeField] private GameObject panel;
    [SerializeField] private Slider bgmSlider;
    [SerializeField] private Slider sfxSlider;

    private void Start()
    {
        bgmSlider.value = SoundManager.Instance.BGMVolume;
        sfxSlider.value = SoundManager.Instance.EffectVolume;
        panel.SetActive(false);
    }

    public void SFXTest()
    {
        SoundManager.Instance.PlayEffect("Coin1");
        // 이름은 알아서
    }

    public void Activate()
    {
        panel.SetActive(true);
    }

    public void Deactivate()
    {
        panel.SetActive(false);
    }

    public void UpdateBGMVolume()
    {
        SoundManager.Instance.BGMVolume = bgmSlider.value;
    }

    public void UpdateSFXVolume()
    {
        SoundManager.Instance.EffectVolume = sfxSlider.value;
    }
}