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
        _territoryCheck.SomebodyWentHouse += OnSomebodyWentHouse;
        _audioSource.Play();
    }

    private void OnDisable()
    {
        _territoryCheck.SomebodyWentHouse -= OnSomebodyWentHouse;
    }

    private void OnSomebodyWentHouse(bool somebodyEnteredOnTerritory)
    {
        if (_processChangeVolume != null)
        {
            StopCoroutine(_processChangeVolume);
        }

        _processChangeVolume = StartCoroutine(ActivateAlarm(somebodyEnteredOnTerritory));
    }

    private IEnumerator ActivateAlarm(bool somebodyEnteredOnTerritory)
    {
        float targetVolume = somebodyEnteredOnTerritory ? 1: 0;
        
        while (_audioSource.volume != targetVolume)
        {               
            Mathf.MoveTowards(_audioSource.volume, targetVolume, Time.deltaTime);
            yield return null;
        }
    }
}
