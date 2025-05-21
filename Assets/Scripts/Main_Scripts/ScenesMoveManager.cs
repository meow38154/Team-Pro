using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class ScenesMoveManager : MonoBehaviour
{
    [SerializeField] private int sceneNum;
    string target = "ngc";
    private int currentIndex = 0;


    void Update()
    {
        if (Input.anyKeyDown)
        {
            foreach (char c in Input.inputString)
            {
                if (char.ToLower(c) == target[currentIndex])
                {
                    currentIndex++;
                    if (currentIndex >= target.Length)
                    {
                        SceneManager.LoadScene(sceneNum);
                        currentIndex = 0;
                    }
                }
                else
                {
                    currentIndex = 0;
                }
            }
        }
    }
}
