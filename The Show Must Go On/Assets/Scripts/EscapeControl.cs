using UnityEngine;
using UnityEngine.SceneManagement;

public class EscapeControl : MonoBehaviour
{
    [SerializeField]
    private string mainMenuScene;

    [SerializeField]
    private KeyCode quitKey = KeyCode.Escape;
    private void Update()
    {
        if (Input.GetKeyDown(quitKey))
        {
            if (CurrentSceneIsMainMenu())
            {
                // process quit
#if UNITY_EDITOR
                UnityEditor.EditorApplication.ExitPlaymode();
#else
            Application.Quit();
#endif    
            }
        
            else
                SceneManager.LoadScene(mainMenuScene);
        }
    }

    private bool CurrentSceneIsMainMenu() => SceneManager.GetActiveScene().path == mainMenuScene;
}