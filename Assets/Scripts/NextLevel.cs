using UnityEngine;
using UnityEngine.Rendering;
using UnityEditor.SceneManagement;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        Debug.Log("Next Level Triggered");
    }
}
