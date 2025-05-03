using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneManagerTest : MonoBehaviour
{
    [Header("Carga de Escena")]
    [SerializeField] private Image loadingBarFill;

    public void LoadSceneWithScreenLoad(string nameScene)
    {
        StartCoroutine(LoadWithLoadingScreen(nameScene));
    }
    private IEnumerator LoadWithLoadingScreen(string targetScene)
    {

        AsyncOperation loadLoading = SceneManager.LoadSceneAsync("LoadScene", LoadSceneMode.Additive);
        yield return loadLoading;

        yield return null;


        AsyncOperation loadTarget = SceneManager.LoadSceneAsync(targetScene, LoadSceneMode.Single);
        loadTarget.allowSceneActivation = false;

        float progress = 0f;
        while (progress < 0.9f)
        {
            progress = Mathf.Clamp01(loadTarget.progress / 0.9f);

            yield return null;
        }

        yield return new WaitForSeconds(0.5f);


        loadTarget.allowSceneActivation = true;


        yield return new WaitForSeconds(1f);
        SceneManager.UnloadSceneAsync("LoadScene");
    }
}
