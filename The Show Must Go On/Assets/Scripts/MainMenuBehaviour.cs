using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuBehaviour : MonoBehaviour
{
    [SerializeField]
    private GameObject title;

    [SerializeField]
    private GameObject prompt;

    [SerializeField]
    private string nextScene;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
            GoToNextScene();
    }

    public void GoToNextScene()
    {
        SceneManager.LoadScene(nextScene);
    }
}
