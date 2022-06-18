using UnityEngine;

[RequireComponent(typeof(AudioSource))]
[RequireComponent(typeof(TerritoryCheck))]
public class Alarm : MonoBehaviour
{
    private AudioSource _audioSource;
    private TerritoryCheck _territoryCheck;

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
        if (somebodyEnteredOnTerritory)
        {
            while (_audioSource.volume != 1)
            {
                _audioSource.volume += Time.deltaTime;
            }
        }
        else
        {
            while (_audioSource.volume != 0)
            {
                _audioSource.volume -= Time.deltaTime;
            }
        }
    }
}
