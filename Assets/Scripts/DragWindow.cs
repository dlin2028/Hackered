using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class DragWindow : MonoBehaviour, IDragHandler, IPointerDownHandler
{

    [SerializeField] private RectTransform titlebar;
    [SerializeField] private RectTransform background;

    private Canvas canvas;
    private RectTransform rectTrans;

    private void Awake()
    {
        rectTrans = GetComponent<RectTransform>();

        Transform testCanvasTransform = transform.parent;
        while (testCanvasTransform != null)
        {
            canvas = testCanvasTransform.GetComponent<Canvas>();
            if (canvas != null)
            {
                break;
            }
            testCanvasTransform = testCanvasTransform.parent;
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (eventData.rawPointerPress == titlebar.gameObject)
        {
            rectTrans.anchoredPosition += eventData.delta / canvas.scaleFactor;
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        titlebar.SetAsLastSibling();

        Vector2 pos = transform.InverseTransformPoint(eventData.position);
        if (pos.x < -(rectTrans.sizeDelta.x / 2) + canvas.scaleFactor * 10)
        {
            StartCoroutine(ResizeLeft());
        }
    }

    IEnumerator ResizeLeft()
    {
        while (Input.GetMouseButton(0))
        {
            Vector2 pos = transform.InverseTransformPoint(Input.mousePosition);
            rectTrans.sizeDelta = new Vector2(rectTrans.sizeDelta.x - (pos.x + (rectTrans.sizeDelta.x / 2)), rectTrans.sizeDelta.y);
            rectTrans.anchoredPosition += new Vector2(pos.x + (rectTrans.sizeDelta.x / 2), 0);
            yield return null;
        }
    }
}
