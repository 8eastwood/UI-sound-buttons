using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SoundPlayer : MonoBehaviour
{
    [SerializeField] private AudioMixerGroup _mixer;
    [SerializeField] private AudioSource _backgroundMusic;
    [SerializeField] private AudioSource _elephantSound;
    [SerializeField] private AudioSource _engineSound;
    [SerializeField] private AudioSource _rainSound;
    [SerializeField] private Button _elephantButton;
    [SerializeField] private Button _engineButton;
    [SerializeField] private Button _rainButton;

    private string _engineVolumeParameter = "EngineVolume";
    private string _elephantVolumeParameter = "ElephantVolume";
    private string _rainVolumeParameter = "RainVolume";
    private string _musicVolumeParameter = "MusicVolume";
    private string _masterVolumeParameter = "MasterVolume";
    private bool _isSoundsPlaying = false;
    private int _lowestValue = -80;
    private int _defaultValue = 0;
    private int _coefficient = 20;

    private void Awake()
    {
        _backgroundMusic.Play();
    }

    private void Update()
    {
        if (_isSoundsPlaying)
        {
            _backgroundMusic.Stop();
        }
    }

    public void OnEnable()
    {
        _engineButton.onClick.AddListener(OnEngineButtonClick);
        _elephantButton.onClick.AddListener(OnElephantButtonClick);
        _rainButton.onClick.AddListener(OnRainButtonClick);
    }

    public void OnDisable()
    {
        _engineButton.onClick.RemoveListener(OnEngineButtonClick);
        _elephantButton.onClick.RemoveListener(OnElephantButtonClick);
        _rainButton.onClick.RemoveListener(OnRainButtonClick);
    }

    public void ToggleMusic(bool enabled)
    {
        if (enabled)
        {
            _mixer.audioMixer.SetFloat(_musicVolumeParameter, _defaultValue);
        }
        else
        {
            _mixer.audioMixer.SetFloat(_musicVolumeParameter, _lowestValue);
        }
    }

    public void ChangeEngineVolume(float soundLevel)
    {
        _mixer.audioMixer.SetFloat(_engineVolumeParameter, Mathf.Log10(soundLevel) * _coefficient);
    }

    public void ChangeElephantVolume(float soundLevel)
    {
        _mixer.audioMixer.SetFloat(_elephantVolumeParameter, Mathf.Log10(soundLevel) * _coefficient);
    }

    public void ChangeRainVolume(float soundLevel)
    {
        _mixer.audioMixer.SetFloat(_rainVolumeParameter, Mathf.Log10(soundLevel) * _coefficient);
    }

    public void ChangeMasterVolume(float soundLevel)
    {
        _mixer.audioMixer.SetFloat(_masterVolumeParameter, Mathf.Log10(soundLevel) * _coefficient);
    }

    private void OnElephantButtonClick()
    {
        _isSoundsPlaying = true;
        _elephantSound.Play();
    }

    private void OnRainButtonClick()
    {
        _isSoundsPlaying = true;
        _rainSound.Play();
    }

    private void OnEngineButtonClick()
    {
        _isSoundsPlaying = true;
        _engineSound.Play();
    }
}
