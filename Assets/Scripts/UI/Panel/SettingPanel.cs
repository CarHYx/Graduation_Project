using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingPanel : BasePanel
{
    public Transform transformFather;

    private Button btnColse;

    private Toggle togMusic;
    private Toggle togSound;

    private Slider sliderMusic;
    private Slider sliderSound;

    protected override void Init()
    {
        btnColse = this.transform.Find("btnColse").GetComponent<Button>();

        togMusic = transformFather.Find("togMusic").GetComponent<Toggle>();
        togSound = transformFather.Find("togSound").GetComponent<Toggle>();

        sliderMusic = transformFather.Find("slideMusic").GetComponent<Slider>();
        sliderSound = transformFather.Find("sliderSound").GetComponent<Slider>();
        Debug.Log(Application.persistentDataPath);
        togMusic.isOn = AudioManager.GetInstanceMon().Load().isBKMusic;
        togSound.isOn = AudioManager.GetInstanceMon().Load().isSoundEffect;
        sliderMusic.value = AudioManager.GetInstanceMon().Load().MusicValue;
        sliderSound.value = AudioManager.GetInstanceMon().Load().SoundValue;

        Registration();
    }
    private void OnDestroy()
    {
        AudioManager.GetInstanceMon().Save();
    }

    private void Registration()
    {
        btnColse.onClick.AddListener(() => { UIManager.GetInstance().HidePanel("SettingPanel"); });

        togMusic.onValueChanged.AddListener((isMusic) =>
        {
            AudioManager.GetInstanceMon().musicData.isBKMusic = isMusic;
            AudioManager.GetInstanceMon().MuteMusic(isMusic);
        });

        togSound.onValueChanged.AddListener((isSound) =>
        {
            AudioManager.GetInstanceMon().musicData.isSoundEffect = isSound;
            AudioManager.GetInstanceMon().MuteEffect(isSound);
        });

        sliderMusic.onValueChanged.AddListener((musicValue) =>
        {
            AudioManager.GetInstanceMon().ChangeMusicValue(musicValue);
            AudioManager.GetInstanceMon().musicData.MusicValue = musicValue;

        });
        sliderSound.onValueChanged.AddListener((soundValue) =>
        {

            AudioManager.GetInstanceMon().ChangeEffectValue(soundValue);
            AudioManager.GetInstanceMon().musicData.SoundValue = soundValue;
        });

    }
}
