using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace CYS_Scripts
{
    public class Starting : MonoBehaviour
    {
        SceneManagerReal _scene;
        GameObject fade;
        GameObject _text;

        private void Awake()
        {
            fade = GameObject.Find("Black");
            _text = GameObject.Find("StartingTMP");
            _scene = GameObject.Find("SceneManager").GetComponent<SceneManagerReal>();        
        }

        private void OnEnable()
        {
            StartCoroutine(Sleeping());
        }
        private IEnumerator Sleeping()
        {
            yield return new WaitForSeconds(Random.Range(1, 3));
            fade.GetComponent<Fade>().DarkPlay();
            _text.SetActive(false);
            yield return new WaitForSeconds(1);
            _scene.ChangeScene(3);
        }
    }
}
