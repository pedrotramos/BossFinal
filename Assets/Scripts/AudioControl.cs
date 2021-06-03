using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioControl : MonoBehaviour
{
    // Referência aos Sliders e AudioMixer para conseguir definir pelo Inspector.
    public Slider masterSlider;
    public Slider sfxSlider;
    public Slider musicSlider;

    public AudioMixer master;

    float outMaster;
    float outSFX;
    float outAudio;

    // Inicializo os sliders nos limites dem db do mixer e já com os valores que estão salvos no mixer
    void Start()
    {
        master.GetFloat("MasterParam", out outMaster);
        masterSlider.minValue = -80.0f;
        masterSlider.maxValue = 20.0f;
        masterSlider.value = outMaster;
        //Registro o evento de mudança de slider.
        masterSlider.onValueChanged.AddListener(delegate { SliderChanged(masterSlider); });

        master.GetFloat("SFXParam", out outSFX);
        sfxSlider.minValue = -80.0f;
        sfxSlider.maxValue = 20.0f;
        sfxSlider.value = outSFX;
        //Registro o evento de mudança de slider.
        sfxSlider.onValueChanged.AddListener(delegate { SliderChanged(sfxSlider); });


        master.GetFloat("MusicParam", out outAudio);
        musicSlider.minValue = -80.0f;
        musicSlider.maxValue = 20.0f;
        musicSlider.value = outAudio;
        //Registro o evento de mudança de slider.
        musicSlider.onValueChanged.AddListener(delegate { SliderChanged(musicSlider); });
    }

    // Método responsável por alterar os volumes no AudioMixer de acordo com slider que foi modificado.
    public void SliderChanged(Slider slider)
    {
        if (slider == masterSlider)
        {
            master.SetFloat("MasterParam", slider.value);
        }
        else if (slider == sfxSlider)
        {
            master.SetFloat("SFXParam", slider.value);
        }
        else if (slider == musicSlider)
        {
            master.SetFloat("MusicParam", slider.value);
        }
    }
}