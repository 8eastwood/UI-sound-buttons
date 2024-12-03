using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SoundPlayer : MonoBehaviour
{
    [SerializeField] private Button _elephantButton;
    [SerializeField] private Button _engineButton;
    [SerializeField] private Button _rainButton;
    [SerializeField] private AudioSource _backgroundMusic;
    [SerializeField] private AudioSource _elephantSound;
    [SerializeField] private AudioSource _engineSound;
    [SerializeField] private AudioSource _rainSound;
    [SerializeField] private AudioMixerGroup _mixer;

    private bool _isSoundsPlaying = false;

    private void Awake()
    {
        _backgroundMusic.Play();
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

    }

    public void ChangeVolume(float volume)
    {

    }

    private void OnElephantButtonClick()
    {
        _elephantSound.Play();
    }

    private void OnRainButtonClick()
    {
        _rainSound.Play();
    }

    private void OnEngineButtonClick()
    {
        _engineSound.Play();
    }
}
