using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoade : MonoBehaviour
{
    public void LoadNextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1) ;
    }
}
