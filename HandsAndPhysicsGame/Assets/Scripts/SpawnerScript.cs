using UnityEngine;

public class SpawnerScript : MonoBehaviour
{
    public GameObject ball;

    public void SpawnBall()
    {
        Instantiate(ball, transform.position, Quaternion.identity);
    }
}
