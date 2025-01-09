using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{
    public void LoadScane(string ScaneName)
    {
        SceneManager.LoadScene(ScaneName);
    }
}
