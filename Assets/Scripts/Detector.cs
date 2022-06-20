using UnityEngine;

public class Detector : MonoBehaviour
{
    public delegate void AlarmSystem(bool isActive);
    public event AlarmSystem SomebodyWentHouse;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent<Player>(out Player player))
        {            
            SomebodyWentHouse?.Invoke(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.TryGetComponent<Player>(out Player player))
        {
            SomebodyWentHouse?.Invoke(false);
        }
    }
}
