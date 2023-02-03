using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class VirtualDPad : MonoBehaviour
{
    public TextMeshProUGUI directionText;
    private Touch _theTouch;
    private Vector2 _touchStartPosition, _touchEndPosition;
    private string _direction;
    
    void Update()
    {
        if (Input.touchCount > 0)
        {
            _theTouch = Input.GetTouch(0);

            if (_theTouch.phase == TouchPhase.Began)
            {
                _touchStartPosition = _theTouch.position;
            }
            
            else if (_theTouch.phase == TouchPhase.Moved || _theTouch.phase == TouchPhase.Ended)
            {
                _touchEndPosition = _theTouch.position;

                float x = _touchEndPosition.x - _touchStartPosition.x;
                float y = _touchEndPosition.y - _touchStartPosition.y;

                if (Mathf.Abs(x) == 0 && Mathf.Abs(y) == 0)
                {
                    _direction = "Tapped";
                }
                
                else if (Mathf.Abs(x) > Mathf.Abs(y))
                {
                    _direction = x > 0 ? "Right" : "Left";
                }

                else
                {
                    _direction = y > 0 ? "Up" : "Down";
                }
            }
        }

        directionText.text = _direction;
    }
}
