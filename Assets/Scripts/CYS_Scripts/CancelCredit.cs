using UnityEngine;
using UnityEngine.Serialization;

public class CancelCredit : MonoBehaviour
{
    [FormerlySerializedAs("_credit")][SerializeField] private GameObject creditForm;


    public void Cancel()
    {
        creditForm.SetActive(false);
    }
}
