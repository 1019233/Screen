using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class WindowController : MonoBehaviour, IDragHandler
{
    private bool isMinimized = false;
    private bool isMaximized = false;

    private Vector2 originalPosition;
    private Vector2 originalSize;
    public GameObject targetObject;

    private void Start()
    {
        // ウィンドウの初期スケールを保管
        RectTransform rectTransform = GetComponent<RectTransform>();
        originalPosition = rectTransform.position;
        originalSize = rectTransform.sizeDelta;
        Debug.Log("originalPosition: "+originalPosition+", originalSize: "+originalSize);
    }

    public void MinimizeWindow()
    {
        // 最小化の処理を実装
        isMinimized = true;
        isMaximized = false;
        // ここでウィンドウを非表示にするか、最小化する処理を追加
        if (targetObject != null)
        {
            targetObject.SetActive(false);
        }
    }

    public void MaximizeWindow()
    {
        RectTransform rectTransform = GetComponent<RectTransform>();

        if(!isMaximized)
        {
        // 最大化の処理を実装
        isMinimized = false;
        isMaximized = true;

        // 画面全体に広げる処理
        rectTransform.position = new Vector3(Screen.width / 2, (Screen.height / 2)+15, 0);
        // rectTransform.position = new Vector2(365, -45);
        rectTransform.sizeDelta = new Vector2(800, 420);
        }
        else if(isMaximized)
        {
        // ウィンドウを通常状態に戻す処理を実装
        isMinimized = false;
        isMaximized = false;

        // 通常状態に戻す処理
        rectTransform.position = originalPosition;
        rectTransform.sizeDelta = originalSize;
        }else
        {
        }
    }

    public void RestoreWindow()
    {
        if(isMinimized)
        {
        // ウィンドウを通常状態に戻す処理を実装
        isMinimized = false;
        isMaximized = false;

        // 通常状態に戻す処理
        targetObject.SetActive(true);
        //Debug.Log("DefScale: " + originalScale);
        //RectTransform rectTransform = GetComponent<RectTransform>();
        //rectTransform.position = originalPosition;
        // Debug.Log("Size:" + originalSize);

        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        if(!isMaximized)
        {
        transform.position += (Vector3)eventData.delta;
        originalPosition = transform.position;
        }
    }
}
