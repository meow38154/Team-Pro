using UnityEngine;
using TMPro;
using System.Collections;
using UnityEngine.SceneManagement;
public class Buttons : MonoBehaviour
{
    [SerializeField] GameObject _startingForm;
    //[SerializeField] GameObject _settingForm;
    [SerializeField] private TextMeshProUGUI _starting;
    [SerializeField] private GameObject _turnOffTheLight;
    [SerializeField] private GameObject _dontDisturb;
    [SerializeField] private GameObject _3dCubeR;
    [SerializeField] private GameObject _3dCuben;

    bool _isTimeOver;
    
    private void Start()
    {
      //_settingForm.SetActive(false);
        _startingForm.SetActive(false);
      _3dCubeR.SetActive(false);
    }

    public void StartingButton()
    {
        _3dCuben.SetActive(false);
        _dontDisturb.SetActive(false);
        _turnOffTheLight.SetActive(false);
        _startingForm.SetActive(true);
     _3dCubeR.SetActive(true);
        //StartCoroutine(Sleeping());
        //Debug.Log("Ω√¿€");
        //SceneManager.LoadScene(0);

    }

   public void Quitting()
    {
        Application.Quit();
    }




    //private IEnumerator Starting()
    //{
    //    _isTimeOver = false;
    //    yield return new WaitForSeconds(0.3f);
    //    _isTimeOver = true;
    //}
    private IEnumerator Sleeping()
    {

        yield return new WaitForSecondsRealtime(2);

    }







}
