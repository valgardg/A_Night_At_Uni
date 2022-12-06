
using UnityEngine;
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SetSense : MonoBehaviour
{
    // Start is called before the first frame update

    public Slider xSlider;
    public Slider ySlider;

    public float xval;
    public float yval;
    public static SetSense Instance;

    private void Awake()
    {
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        xSlider.onValueChanged.AddListener(delegate { ValueChangeCheck(); });
        ySlider.onValueChanged.AddListener(delegate { ValueChangeCheck(); });
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    void ValueChangeCheck() 
    {
        
        xval = xSlider.value;
        Debug.Log(xSlider.value);

        yval = ySlider.value;
        Debug.Log(ySlider.value);
        //yval = xSlider.value;

    }
}
