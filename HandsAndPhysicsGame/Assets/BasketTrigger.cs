using UnityEngine;

public class BasketTrigger : MonoBehaviour
{
    public int points = 1;
    public ScoreManager scoreManager;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball")) 
        {
            scoreManager.AddScore(points);
        }
    }
}
