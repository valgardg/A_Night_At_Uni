using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingControll : MonoBehaviour
{
    public static SettingControll Instance;
    private float _xsense = 100;
    private float _ysense = 100;
    private bool _easy = false;
    private float _volume = 100;
    private bool _tooltips = true;
    private bool _mouseinverted = false;

    private void Awake()
    {
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }



    public float xsense
    {
        get { return _xsense; }
        set { _xsense = value; }
    }

    public float ysense
    {
        get { return _ysense; }
        set { _ysense = value; }
    }

    public bool easy
    {
        get { return _easy; }
        set { _easy = value; }
    }

    public float volume
    {
        get { return _volume; }
        set { _volume = value; }
    }
    
    public bool tooltips 
    {
        get { return _tooltips; }
        set { _tooltips = value; }
    }

    public bool mouseinverted
    {
        get { return _mouseinverted; }
        set { _mouseinverted = value; }
    }

    
}
