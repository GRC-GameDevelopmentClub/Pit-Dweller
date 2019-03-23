using UnityEngine.SceneManagement;
using UnityEngine;

public class sceneChanger : MonoBehaviour {

    public void PlayAgain(string scene)
    {
        SceneManager.LoadScene(scene);
    }
}
