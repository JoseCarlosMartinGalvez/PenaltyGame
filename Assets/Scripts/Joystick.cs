using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Joystick : MonoBehaviour
{
    public float maxDistance = 50f;
    private RectTransform handleRectTransform;
    private Vector2 startPosition;
    private Vector2 inputVector;


    // Start is called before the first frame update
    void Start()
    {
        handleRectTransform = GetComponent<RectTransform>();
        startPosition = handleRectTransform.anchoredPosition;
    }

    public void OnMouseDrag(PointerEventData eventData)
    {
        Vector2 position = Vector2.zero;

        if (RectTransformUtility.ScreenPointToLocalPointInRectangle(
            handleRectTransform.parent.GetComponent<RectTransform>(),
            eventData.position,
            eventData.pressEventCamera, 
            out position)) 
        {
            float distance = Vector2.Distance(startPosition, position);

            if (distance > maxDistance)
            {
                position = startPosition + (position - startPosition).normalized * maxDistance;
            }

            handleRectTransform.anchoredPosition = position;
            inputVector = (position - startPosition) / maxDistance;
        }
    }

    public void OnEndMouseDrag ()
    {
        handleRectTransform.anchoredPosition = startPosition;
        inputVector = Vector2.zero;
    }

    public Vector2 GetInputVector()
    {
        return inputVector;
    }
}
