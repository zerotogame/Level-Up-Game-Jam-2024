using FMOD.Studio;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;
using System;

public class VolumeController : MonoBehaviour
{
    private static VolumeController _instance;
    public static VolumeController Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<VolumeController>();
                if (_instance == null)
                {
                    GameObject obj = new GameObject("VolumeController");
                    _instance = obj.AddComponent<VolumeController>();
                }
            }
            return _instance;
        }
    }

    VCA masterVCA;
    VCA musicVCA;
    VCA sfxVCA;
    VCA ambientVCA;


    [Range(0f, 1f)] public float masterVolume = 0.75f;
    [Range(0f, 1f)] public float musicVolume = 0.75f;
    [Range(0f, 1f)] public float sfxVolume = 0.75f;
    [Range(0f, 1f)] public float ambientVolume = 0.75f;

    public static object instance { get; internal set; }

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        masterVCA = FMODUnity.RuntimeManager.GetVCA("vca:/Master");
        musicVCA = FMODUnity.RuntimeManager.GetVCA("vca:/Music");
        sfxVCA = FMODUnity.RuntimeManager.GetVCA("vca:/Sfx");
        ambientVCA = FMODUnity.RuntimeManager.GetVCA("vca:/AmbientSounds");

        DontDestroyOnLoad(gameObject);
    }
    private void Update()
    {
        masterVCA.setVolume(masterVolume);
        musicVCA.setVolume(musicVolume);
        sfxVCA.setVolume(sfxVolume);
        ambientVCA.setVolume(ambientVolume);
    }
}
