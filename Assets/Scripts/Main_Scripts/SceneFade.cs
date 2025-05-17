using UnityEngine;
using UnityEngine.InputSystem;

public class SceneFade : MonoBehaviour
{
    [SerializeField] int sceneNum;
    SceneManagerReal _scene;
    FadeOut _fade;

    private bool isWaiting = false;
    private float waitTimer = 0f;
    private float waitDuration = 1f;

    private void Awake()
    {
        _scene = GameObject.Find("SceneManager").GetComponent<SceneManagerReal>();
        _fade = GameObject.Find("BlackScreen").GetComponent<FadeOut>();
    }

    private void Update()
    {
        if (isWaiting)
        {
            waitTimer += Time.unscaledDeltaTime;
            if (waitTimer >= waitDuration)
            {
                isWaiting = false;
                Time.timeScale = 1f;
                _scene.ChangeScene(sceneNum);
            }
        }
    }

    public void SceneChangeFadeout()
    {
        _fade.StartFadeIn();
        Time.timeScale = 0f;
        isWaiting = true;
        waitTimer = 0f;
    }
}
