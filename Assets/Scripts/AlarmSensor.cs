using UnityEngine;
using UnityEngine.Events;

public class AlarmSensor : MonoBehaviour
{
    [SerializeField] private UnityEvent _playerFounded;
    [SerializeField] private UnityEvent _playerLost;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Player>(out Player player))
        {
            _playerFounded?.Invoke();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Player>(out Player player))
        {
            _playerLost?.Invoke();
        }
    }
}
