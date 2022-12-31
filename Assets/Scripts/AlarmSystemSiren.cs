using System.Collections;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]

public class AlarmSystemSiren : MonoBehaviour
{
    private float _targetVolume;
    private float _deltaVolume = 0.5f;
    private AudioSource _audioSource;
    private Coroutine _activeCorotine;

    public void Activate()
    {
        _targetVolume = 1f;

        UseCorotine();
    }

    public void TurnOff()
    {
        _targetVolume = 0f;

        UseCorotine();
    }

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();

        _audioSource.volume = 0;
    }

    private void UseCorotine()
    {
        if (_activeCorotine != null)
        { 
            StopCoroutine(_activeCorotine);
        }

        _activeCorotine = StartCoroutine(FadeVolume());
    }

    private IEnumerator FadeVolume()
    {
        while (_audioSource.volume != _targetVolume)
        {
            _audioSource.volume = Mathf.MoveTowards(_audioSource.volume, _targetVolume, _deltaVolume * Time.deltaTime);

            yield return null;
        }

        yield break;
    }
}
