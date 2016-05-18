using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class MoveLScript : MonoBehaviour, IPointerUpHandler, IPointerDownHandler
{

    //==============================
    // 移動ボタン押す処理
    //==============================
    public void OnPointerDown(PointerEventData eventData)
    {
        GameManager.instance.GetComponent<LocalMove>().MoveLeft();
    }

    //==============================
    // 移動ボタン放す処理
    //==============================
    public void OnPointerUp(PointerEventData eventData)
    {
        GameManager.instance.GetComponent<LocalMove>().CancelMove();
    }
}
