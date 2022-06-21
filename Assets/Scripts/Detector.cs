using UnityEngine;
using UnityEngine.Events;

public class Detector : MonoBehaviour
{
    public UnityAction<bool> ChangeValue;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out Player player))
        {            
            ChangeValue?.Invoke(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.TryGetComponent(out Player player))
        {
            ChangeValue?.Invoke(false);
        }
    }
}
