
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Runtime.CompilerServices;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using static UnityEngine.Windows.WebCam.VideoCapture;


public class AudioManager : SingleMonManger<AudioManager>
{

    public MusicData musicData = new MusicData();

    private AudioSource _musicSources = null;
    private AudioSource _effectSources = null;
    private List<AudioSource> _efftSourcesList = new List<AudioSource>();



    private void Update()
    {
        for (int i = _efftSourcesList.Count - 1; i >= 0; --i)
        {
            if (!_efftSourcesList[i].isPlaying)
            {
                GameObject.Destroy(_efftSourcesList[i]);
                _efftSourcesList.RemoveAt(i);
            }
        }
    }

    
    public void Save()
    {
        JsonMgr.Instance.SaveData(musicData, "musicData");
    }

    public MusicData Load()
    {
        return JsonMgr.Instance.LoadData<MusicData>("musicData");
    }

    //���ű�������
    public void PlayMusic(string name)
    {
        if (!Load().isBKMusic)
            return;
        if (_musicSources == null )
        {
            GameObject objMusic = new GameObject("objMusic");
            _musicSources = objMusic.AddComponent<AudioSource>();
        }
        ResourcesManger.GetInstanceMon().LoadAsync<AudioClip>("Audio/Music/" + name, (clip) =>
        {
            _musicSources.clip = clip;
            _musicSources.loop = true;
            _musicSources.volume = Load().MusicValue;
            _musicSources.Play();

        });
        
    }
    public void MuteMusic(bool isMusic)
    {
        if (_musicSources == null)
        {
            GameObject objMusic = new GameObject("objMusic");
            _musicSources = objMusic.AddComponent<AudioSource>();
            ResourcesManger.GetInstanceMon().LoadAsync<AudioClip>("Audio/Music/BGM", (clip) =>
            {
                _musicSources.clip = clip;
                _musicSources.loop = true;
                _musicSources.volume = Load().MusicValue;
                _musicSources.Play();

            });
        }
        _musicSources.mute = !isMusic;
    }


    //��ͣ��������
    public void PauseMusic()
    {
        if (_musicSources == null)
            return;
        _musicSources.Pause();
    }
    //ѭ����������
    public void LoopMusic(bool isLoop)
    {
        if (_musicSources == null)
            return;
        _musicSources.loop = isLoop;
    }
    //ֹͣ��������
    public void StopMusic()
    {
        if (_musicSources == null)
            return;
        _musicSources.Stop();
    }
    //�ı䱳�����ִ�С
    public void ChangeMusicValue(float value)
    {
        if (_musicSources == null)
            return;
        _musicSources.volume = value;
    }


    //������Ч
    public void PlayEfftSources(string name, bool isLoop, UnityAction<AudioSource> callBack = null)
    {
        if (!Load().isSoundEffect)
            return;
        if(_effectSources == null)
        {
            GameObject objEfft = new GameObject("objEfft");
            _effectSources = objEfft.AddComponent<AudioSource>();
        }
        ResourcesManger.GetInstanceMon().LoadAsync<AudioClip>("Audio/Effect/" + name, (clip) =>
        {
            _effectSources.clip = clip;
            _effectSources.loop = isLoop;
            _effectSources.volume = Load().SoundValue;
            _effectSources.Play();
        });

    }

    //��ͣ��Ч
    public void StopSound(AudioSource source)
    {
        if (_efftSourcesList.Contains(source))
        {
            _efftSourcesList.Remove(source);
            source.Stop();
            GameObject.Destroy(source);
        }
    }

    //�ı���Ч������С
    public void ChangeEffectValue(float value)
    {
        for (int i = 0; i < _efftSourcesList.Count; ++i)
            _efftSourcesList[i].volume = value;
    }
    //�Ƿ���
    public void MuteEffect(bool isEffect)
    {
        if(_effectSources == null)
        {
            GameObject objEfft = new GameObject("objEfft");
            _effectSources = objEfft.AddComponent<AudioSource>();
            ResourcesManger.GetInstanceMon().LoadAsync<AudioClip>("Audio/Effect/Monster", (clip) =>
            {
                _effectSources.clip = clip;
                _effectSources.loop = false;
                _effectSources.volume = Load().SoundValue;
                _effectSources.Play();
            });
        }
        for (int i = 0; i < _efftSourcesList.Count; ++i)
            _efftSourcesList[i].mute = !isEffect;
    }
}


