using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Controller component that handles the slider class provided by Unity.<br/>
/// <strong>Note:</strong> Make sure not to use this component methods in Awake method since the slider component is not initialized yet.
/// </summary>
public class SliderController : MonoBehaviour
{
    private Slider _slider;

    private void Awake()
    {
        _slider = gameObject.GetComponent<Slider>();
    }


    /// <param name="value">Value that should be between 0 and 1</param>
    public void SetSliderValue(float value)
    {
        _slider.value = value;
    }
}
