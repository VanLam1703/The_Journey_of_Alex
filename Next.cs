using UnityEngine;
using UnityEngine.SceneManagement;

public class Next : MonoBehaviour
{
    public void loadMap()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Map");
    }
}
