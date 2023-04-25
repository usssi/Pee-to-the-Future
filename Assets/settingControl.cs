using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class settingControl : MonoBehaviour
{
    public GameObject postprocess;
    public bool processOnOff;
    public Toggle settingsToggle;
    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.GetInt("process01") == 0)
        {
            postprocess.GetComponent<Volume>().enabled = false;
            processOnOff = false;
        }
        else if(PlayerPrefs.GetInt("process01") == 1)
        {
            postprocess.GetComponent<Volume>().enabled = true;
            processOnOff = true;
        }

        if (settingsToggle != null)
        {
            settingsToggle.isOn = !processOnOff;
        }
    }


    public void PostProcessSettings()
    {
        if (processOnOff == true)
        {
            processOnOff = false;
            postprocess.GetComponent<Volume>().enabled = false;
            PlayerPrefs.SetInt("process01", 0);
        }
        else if (processOnOff == false)
        {
            processOnOff = true;
            postprocess.GetComponent<Volume>().enabled = true;
            PlayerPrefs.SetInt("process01", 1);
        }
    }
}
