using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MouseDetector : MonoBehaviour
{
    [SerializeField] CameraAnimation CamAnim;
    [SerializeField] SpriteRenderer background;
    [SerializeField] Text text;

    private void OnMouseOver()
    {
        if (background.color != this.GetComponent<SpriteRenderer>().color)
        {
            CameraAnimation.IsZoomedOut = false;
            StartCoroutine(ZoomInAndOut());
            text.text = this.name + "?";
        }
    }

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
