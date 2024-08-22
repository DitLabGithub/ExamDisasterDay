using UnityEngine;
using UnityEngine.SceneManagement;

public class ResetButton : MonoBehaviour
{
    // This function should be linked to the button's OnClick event
    public void ResetGame()
    {
        // Load the first scene (usually indexed as 0)
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
