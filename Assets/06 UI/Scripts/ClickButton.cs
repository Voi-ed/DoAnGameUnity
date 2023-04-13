using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ClickButton : MonoBehaviour,IPointerDownHandler,IPointerUpHandler
{
    [SerializeField] private Image _image;
    [SerializeField] private Sprite _default,_pressed;



    public void OnPointerDown(PointerEventData eventData)
    {
        _image.sprite = _pressed;
        AudioController.Instant.playSound("Compressed");
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        _image.sprite = _default;
        AudioController.Instant.playSound("Uncompressed");
    }

}
