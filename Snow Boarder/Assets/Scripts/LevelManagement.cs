using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManagement : MonoBehaviour
{
    public IEnumerator ResetLevel()
    {
        Time.timeScale = 0;
        yield return new WaitForSecondsRealtime(1);
        SceneManager.LoadScene(0);
    }
}
