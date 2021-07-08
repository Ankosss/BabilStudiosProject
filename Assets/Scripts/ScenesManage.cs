using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenesManage : MonoBehaviour
{
    #region Singleton
    /// <summary>
    /// ScenesManage Scriptini static olarak diðer scriptlerimde kullanabilmeme yaran bir kod parçasý
    /// </summary>

    private static ScenesManage _sManage;
    public static ScenesManage sManage
    {
        get
        {
            if (_sManage == null)
                _sManage = FindObjectOfType<ScenesManage>();
            return _sManage;
        }
    }
    #endregion

    public void TekrarOyna()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
