
using UnityEngine;
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SetSense : MonoBehaviour
{
    // Start is called before the first frame update

    public Slider xSlider;
    public Slider ySlider;

    void Start()
    {
        xSlider.onValueChanged.AddListener(delegate { ValueChangeCheck(); });
        ySlider.onValueChanged.AddListener(delegate { ValueChangeCheck(); });
    }

    void ValueChangeCheck() 
    {
        PlayerPrefs.SetFloat("XSensitivity", xSlider.value);
        PlayerPrefs.SetFloat("YSensitivity", ySlider.value);
        //SettingControll.Instance.xsense = xSlider.value;
        //SettingControll.Instance.ysense = ySlider.value;

        Debug.Log(PlayerPrefs.GetFloat("YSensitivity"));

        Debug.Log(PlayerPrefs.GetFloat("XSensitivity"));
    }
}
