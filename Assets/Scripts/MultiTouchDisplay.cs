using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MultiTouchDisplay : MonoBehaviour
{
    public TextMeshProUGUI multiTouchInfoDisplay;
    private int _maxTapCount = 0;
    private string _multiTouchInfo;
    private Touch _theTouch;
    
    void Update()
    {
        _multiTouchInfo = string.Format("Max tap count: {0}\n", _maxTapCount);

        if (Input.touchCount > 0)
        {
            for (int i = 0; i < Input.touchCount; i++)
            {
                _theTouch = Input.GetTouch(i);

                _multiTouchInfo +=
                    string.Format("Touch{0} - Position {1} - Tap Count: {2} - Finger ID: {3}\nRadius: {4} ({5})\n", 
                        i, _theTouch.position, _theTouch.tapCount, _theTouch.fingerId, _theTouch.radius,
                        ((_theTouch.radius/(_theTouch.radius + _theTouch.radiusVariance)) * 100f).ToString("F1"));

                if (_theTouch.tapCount > _maxTapCount)
                {
                    _maxTapCount = _theTouch.tapCount;
                }
            }
        }

        multiTouchInfoDisplay.text = _multiTouchInfo;
    }
}
