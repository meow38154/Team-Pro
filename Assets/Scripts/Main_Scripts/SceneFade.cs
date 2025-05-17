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
        GameObject sceneManagerObj = GameObject.Find("SceneManager");
        GameObject blackScreenObj = GameObject.Find("BlackScreen");

        if (sceneManagerObj == null)
            Debug.LogError("SceneManager ������Ʈ�� ã�� �� �����ϴ�.");

        if (blackScreenObj == null)
            Debug.LogError("BlackScreen ������Ʈ�� ã�� �� �����ϴ�.");

        _scene = sceneManagerObj?.GetComponent<SceneManagerReal>();
        _fade = blackScreenObj?.GetComponent<FadeOut>();

        if (_fade == null)
            Debug.LogError("BlackScreen�� FadeOut ������Ʈ�� �����ϴ�.");
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
