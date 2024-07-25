using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeSliders : MonoBehaviour
{
    private enum VolumeType
    {
        MASTER,
        MUSIC,
        SFX,
        AMBIENCE,
    }

    [Header("Type")]
    [SerializeField] private VolumeType volumeType;

    private Slider volumeSlider;

    void Awake()
    {
        volumeSlider = GetComponent<Slider>();
        VolumeController.Instance.GetComponent<VolumeController>();
    }
    void Update()
    {
        if (volumeSlider != null)
        {
            if (VolumeController.Instance != null)
            {
                switch (volumeType)
                {
                    case VolumeType.MASTER:
                        volumeSlider.value = VolumeController.Instance.masterVolume;
                        break;
                    case VolumeType.MUSIC:
                        volumeSlider.value = VolumeController.Instance.musicVolume;
                        break;
                    case VolumeType.SFX:
                        volumeSlider.value = VolumeController.Instance.sfxVolume;
                        break;
                    case VolumeType.AMBIENCE:
                        volumeSlider.value = VolumeController.Instance.ambientVolume;
                        break;
                    default:
                        throw new ArgumentException("Tipo de volumen no soportado." + volumeType);
                }
            }
        }

    }
    public void OnSliderValueCahnge()
    {
        switch (volumeType)
        {
            case VolumeType.MASTER:
                VolumeController.Instance.masterVolume = volumeSlider.value;
                break;
            case VolumeType.MUSIC:
                VolumeController.Instance.musicVolume = volumeSlider.value;
                break;
            case VolumeType.SFX:
                VolumeController.Instance.sfxVolume = volumeSlider.value;
                break;
            case VolumeType.AMBIENCE:
                VolumeController.Instance.ambientVolume = volumeSlider.value;
                break;
            default:
                throw new ArgumentException("Tipo de volumen no soportado." + volumeType);
        }
    }
}
