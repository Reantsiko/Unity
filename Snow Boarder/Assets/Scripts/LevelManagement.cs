using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManagement : MonoBehaviour
{
    public SoundEffectsPlayer sfxPlayer;
    void Start()
    {
        sfxPlayer = FindObjectOfType<SoundEffectsPlayer>();
        if (sfxPlayer == null)
            Debug.LogError($"{gameObject.name} stxPlayer is null");
    }

    public IEnumerator ResetLevel()
    {
        // Time.timeScale = 0;
        yield return new WaitForSecondsRealtime(2);
        SceneManager.LoadScene(0);
    }
}
