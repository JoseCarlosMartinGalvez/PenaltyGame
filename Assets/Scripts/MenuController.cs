using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    public Button PlayBtn;

    // Start is called before the first frame update
    void Start()
    {
        PlayBtn.onClick.AddListener(Play);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    void Play()
    {

        SceneManager.LoadScene(1);
    }
}
