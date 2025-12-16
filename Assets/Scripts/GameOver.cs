using UnityEngine;

public class GameOver : MonoBehaviour
{
    public GameObject gameOverUI;
    public GameObject player;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        gameOverUI.SetActive(true);
        player.SetActive(false);
    }
}
