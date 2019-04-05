using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelsMenu : MonoBehaviour
{
    public void PlayLevel1()
    {
        SceneManager.LoadScene("level1");
    }

    public void PlayLevel2()
    {
        SceneManager.LoadScene("level2");
    }

    public void PlayLevel3()
    {
        SceneManager.LoadScene("level3");
    }

    public void PlayLevel4()
    {
        SceneManager.LoadScene("level4");
    }

}
