using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class WindowController : MonoBehaviour, IDragHandler
{
    private bool isMinimized = false;
    private bool isMaximized = false;

    private Vector3 originalScale;

    private Vector2 originalPosition;
    private Vector2 originalSize;

    public GameObject targetObject;

    private void Start()
    {
        // ウィンドウの初期スケールを保管
        originalScale = GetComponent<RectTransform>().localScale;
        originalPosition = transform.position;
        Debug.Log("Scale: " + originalScale);
    }

    public void MinimizeWindow()
    {
        if(!isMinimized)
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
        rectTransform.localScale = new Vector3(1, 1, 1f);
        rectTransform.position = new Vector3(Screen.width / 2, Screen.height / 2, 0);
        }
        else if(isMaximized)
        {
        // ウィンドウを通常状態に戻す処理を実装
        isMinimized = false;
        isMaximized = false;

        // 通常状態に戻す処理
        rectTransform.localScale = originalScale;
        rectTransform.position = originalPosition;

        }else
        {
        }
    }

    public void RestoreWindow()
    {
        if(isMinimized || isMaximized)
        {
        // ウィンドウを通常状態に戻す処理を実装
        isMinimized = false;
        isMaximized = false;

        // 通常状態に戻す処理
        targetObject.SetActive(true);
        Debug.Log("DefScale: " + originalScale);
        RectTransform rectTransform = GetComponent<RectTransform>();
        rectTransform.localScale = originalScale;
        rectTransform.position = originalPosition;
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
