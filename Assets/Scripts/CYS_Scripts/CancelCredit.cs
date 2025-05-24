using UnityEngine;
using UnityEngine.Serialization;

public class CancelCredit : MonoBehaviour
{
    [FormerlySerializedAs("_credit")][SerializeField] private GameObject creditForm;
    [SerializeField] GameObject _s;


    public void Cancel()
    {
        creditForm.SetActive(false);
        _s.SetActive(true);
        AudioManager.Instance.PlayUICilck();
    }
}
