using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Starting : MonoBehaviour
{

    //private void OnEnable()
    //{
    //    StartCoroutine(Sleeping());
    //    //Debug.Log("����");
    //    SceneManager.LoadScene(0);
    //}

    
    private void Update()
    {
       
    
    }

    private void OnEnable()
    {
        StartCoroutine(Sleeping());
    }




    private IEnumerator Sleeping()
    {
        
        yield return new WaitForSeconds(Random.Range(1, 3)); //<---30��????
        Debug.Log("����");
    
    }
}
