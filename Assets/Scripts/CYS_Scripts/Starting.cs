using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace CYS_Scripts
{
    public class Starting : MonoBehaviour
    {
        SceneManagerReal _scene;

        private void Awake()
        {
            _scene = GameObject.Find("SceneManager").GetComponent<SceneManagerReal>();        }

        private void OnEnable()
        {
            StartCoroutine(Sleeping());
        }
        private IEnumerator Sleeping()
        {
            yield return new WaitForSeconds(Random.Range(1, 3));
            _scene.ChangeScene(1);
        }
    }
}
