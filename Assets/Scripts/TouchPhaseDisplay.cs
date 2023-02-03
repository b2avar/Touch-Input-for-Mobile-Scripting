using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TouchPhaseDisplay : MonoBehaviour
{
    public TextMeshProUGUI phaseDisplayText;
    private Touch _theTouch;
    private float _timeTouchEnded;
    private float _displayTime = 0.5f;
    
    
    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {
            _theTouch = Input.GetTouch(0);
            if (_theTouch.phase == TouchPhase.Ended)
            {
                phaseDisplayText.text = _theTouch.phase.ToString();
                _timeTouchEnded = Time.time;
            }
            else if (Time.time - _timeTouchEnded > _displayTime)
            {
                phaseDisplayText.text = "";
            }
        }
    }
}
