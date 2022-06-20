using System.Collections;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
[RequireComponent(typeof(TerritoryCheck))]
public class Alarm : MonoBehaviour
{
    private AudioSource _audioSource;
    private TerritoryCheck _territoryCheck;
    private Coroutine _processChangeVolume;   

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        _territoryCheck = GetComponent<TerritoryCheck>();
        _territoryCheck.SomebodyWentHouse += AlarmActivation;
        _audioSource.Play();
    }

    private void OnDisable()
    {
        _territoryCheck.SomebodyWentHouse -= AlarmActivation;
    }

    private void AlarmActivation(bool somebodyEnteredOnTerritory)
    {
        if (_processChangeVolume != null)
        {
            StopCoroutine(_processChangeVolume);
        }

        _processChangeVolume = StartCoroutine(AlarmActivationCoroutine(somebodyEnteredOnTerritory));
    }

    private IEnumerator AlarmActivationCoroutine(bool somebodyEnteredOnTerritory)
    {
        float durationTranstion = 2f;
        float runningTime = 0f;

        if (somebodyEnteredOnTerritory)
        {
            while (_audioSource.volume != 1)
            {
                runningTime += Time.deltaTime;
                _audioSource.volume = runningTime / durationTranstion;
                yield return null;
            }
        }
        else
        {
            runningTime = 2f;

            while(_audioSource.volume != 0)
            {
                runningTime -= Time.deltaTime;
                _audioSource.volume = runningTime / durationTranstion;
                yield return null;
            }
        }
    }
}
