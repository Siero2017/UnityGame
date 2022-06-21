using System.Collections;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
[RequireComponent(typeof(Detector))]
public class Alarm : MonoBehaviour
{
    private AudioSource _audioSource;
    private Detector _territoryCheck;
    private Coroutine _processChangeVolume;   

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        _territoryCheck = GetComponent<Detector>();
        _territoryCheck.SomebodyWentHouse += ActivateAlarm;
        _audioSource.Play();
    }

    private void OnDisable()
    {
        _territoryCheck.SomebodyWentHouse -= ActivateAlarm;
    }

    private void ActivateAlarm(bool somebodyEnteredOnTerritory)
    {
        if (_processChangeVolume != null)
        {
            StopCoroutine(_processChangeVolume);
        }

        _processChangeVolume = StartCoroutine(AlarmActivationCoroutine(somebodyEnteredOnTerritory));
    }

    private IEnumerator AlarmActivationCoroutine(bool somebodyEnteredOnTerritory)
    {
        float targetVolume = somebodyEnteredOnTerritory ? 1: 0;
        
        while (_audioSource.volume != targetVolume)
        {               
            Mathf.MoveTowards(_audioSource.volume, targetVolume, Time.deltaTime);
            yield return null;
        }
    }
}
