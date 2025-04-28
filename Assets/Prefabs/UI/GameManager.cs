using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Photon.Pun;
using Unity.VisualScripting;


public class GameManager : MonoBehaviourPunCallbacks
{
       public static GameManager Instance;
       
      private void Awake()
      {
            if (Instance != null && Instance != this)
            {
                Destroy(this.gameObject);
                return;
            }
     
          Instance = this;
          DontDestroyOnLoad(this.gameObject);
      }
         
     
       
    public void LoadScene(string sceneName)
    {
        if (PhotonNetwork.IsMasterClient)

            PhotonNetwork.LoadLevel(sceneName);
    }
       
      
       
    public override void OnEnable()
    {
        base.OnEnable();
       // SceneManager.sceneLoaded += OnSceneLoaded;
    }
 
       
    public override void OnDisable()
    {
        base.OnDisable();
       // SceneManager.sceneLoaded -= OnSceneLoaded;
    }
       
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "YourSceneName") ;
    }
       
       
     
}
