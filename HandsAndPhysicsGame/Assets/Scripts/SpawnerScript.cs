using UnityEditor.AnimatedValues;
using UnityEngine;
using UnityEngine.InputSystem;

public class SpawnerScript : MonoBehaviour
{
    public InputActionReference action;
    public GameObject ball;

    private void Start()
    {
        action.action.Enable();
        action.action.performed += (ctx) =>
        {
            Instantiate(ball, transform.position, Quaternion.identity);
        };
    }
}
