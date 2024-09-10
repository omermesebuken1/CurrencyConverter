using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[ExecuteInEditMode]
public class blurred : MonoBehaviour
{
    
    [SerializeField] GameObject bg;
    Image image;
    float width;
    float height;
    Rect rect;
    
    
    
    void Update()
    {
        if(bg != null)
        {

        
        image = bg.GetComponent<Image>();
        rect = image.rectTransform.rect;
        width = rect.width;
        height = rect.height;
        this.GetComponent<Image>().rectTransform.sizeDelta = new Vector2(width,height);

        this.gameObject.transform.position = bg.transform.position;
        this.gameObject.transform.localScale = bg.transform.localScale;
        }
    }
}
