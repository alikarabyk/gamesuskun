using UnityEngine;
using UnityEngine.SceneManagement;



public class UIManager : MonoBehaviour
{
        
    public void Restart()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.name);

    }

}
