using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneManagerReal : MonoBehaviour
{
   

    public void ChangeScene(int sceneNum)
    {
        SceneManager.LoadScene(sceneNum);
    }
}
