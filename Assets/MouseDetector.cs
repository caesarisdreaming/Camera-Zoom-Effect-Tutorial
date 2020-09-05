using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MouseDetector : MonoBehaviour
{
    [SerializeField] CameraAnimation CamAnim;
    [SerializeField] SpriteRenderer background;
    [SerializeField] Text text;

    //Detects when the mouse if over the squares
    private void OnMouseOver()
    {
        if (background.color != this.GetComponent<SpriteRenderer>().color)//if the color is different from the background it will proceed to the change
        {
            CameraAnimation.IsZoomedOut = false;
            StartCoroutine(ZoomInAndOut());
            text.text = this.name + "?";
        }
    }
    //Zoom In and Out Coroutine
    IEnumerator ZoomInAndOut()
    {
        while (!CameraAnimation.IsZoomedOut)
        {
            CamAnim.ZoomInCamera(this.transform);
            yield return CameraAnimation.IsZoomedIn;
            CamAnim.ZoomOutCamera();
            yield return !CameraAnimation.IsZoomedIn;
            if (CameraAnimation.IsZoomedIn)
            {
                background.color = this.GetComponent<SpriteRenderer>().color;
            }
        }
    }
}
