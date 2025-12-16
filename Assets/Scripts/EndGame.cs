using UnityEngine;

public class EndGame : MonoBehaviour
{
    public void ExitGame()
    {
        Debug.Log("Game Over");
        Application.Quit();
    }
}
