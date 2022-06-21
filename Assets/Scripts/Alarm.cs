using System.Collections;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
[RequireComponent(typeof(Detector))]
public class Alarm : MonoBehaviour
{
    private AudioSource _audioSource;
    private Detector _territoryCheck;
    private Coroutine _processChangeVolume;
    private readonly float _maxValue = 1;
    private readonly float _minValue = 0;

    private void OnEnable()
    {
        _territoryCheck = GetComponent<Detector>();
        _territoryCheck.ChangeValue += OnChangeValue;
    }

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();        
        _audioSource.Play();
    }

    private void OnDisable()
    {
        _territoryCheck.ChangeValue -= OnChangeValue;
    }

    private void OnChangeValue(bool somebodyEnteredOnTerritory)
    {
        if (_processChangeVolume != null)
        {
            StopCoroutine(_processChangeVolume);
        }
        _processChangeVolume = StartCoroutine(ActivateAlarm(somebodyEnteredOnTerritory));
    }

    private IEnumerator ActivateAlarm(bool somebodyEnteredOnTerritory)
    {     
        float targetVolume = somebodyEnteredOnTerritory ? _maxValue : _minValue;
        while (_audioSource.volume != targetVolume)
        {
           _audioSource.volume = Mathf.MoveTowards(_audioSource.volume, targetVolume, Time.deltaTime);
            yield return null;
        }
    }
}
