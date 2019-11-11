using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu_Script : MonoBehaviour
{
    public GameObject Credits_panel;

    // Update is called once per frame
    void Update()
    {

    }

    public void Credits()
    {
        Credits_panel.gameObject.SetActive(true);
    }

    public void Back()
    {
        Credits_panel.gameObject.SetActive(false);
    }

    public void PlayGame()
    {
        SceneManager.LoadScene(1);
    }

    public void QuitGame()
    {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = (false);
#else
        Application.Quit();
#endif

    }
}
