using System.Collections;
using UnityEngine;

namespace CYS_Scripts
{
    public class Starting : MonoBehaviour
    {
    
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
}
