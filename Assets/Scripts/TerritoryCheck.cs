using UnityEngine;
using UnityEngine.Events;

public class TerritoryCheck : MonoBehaviour
{
    [SerializeField] private UnityEvent _playerInside;
    [SerializeField] private UnityEvent _playerOutside;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent<Player>(out Player player))
        {
            _playerInside.Invoke();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.TryGetComponent<Player>(out Player player))
        {
            _playerOutside.Invoke();
        }
    }
}
