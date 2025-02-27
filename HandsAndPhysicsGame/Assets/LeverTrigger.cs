using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class LeverTrigger : MonoBehaviour
{
    // Start is called before the first frame update
    public float gameTime = 60.0f;

    private bool _gameTimeActive = false;

    public UnityEvent onActivated, onDeactivated;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Shaft") && !_gameTimeActive)
        {
            onActivated?.Invoke();
            Debug.Log("Activated");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Shaft") && !_gameTimeActive)
        {
            onDeactivated?.Invoke();
            Debug.Log("deActivated");
            StartCoroutine(WaitForGameTime());
        }
    }

    IEnumerator WaitForGameTime()
    {
        _gameTimeActive = true;
        yield return new WaitForSeconds(gameTime);
        _gameTimeActive = false;
    }
}
