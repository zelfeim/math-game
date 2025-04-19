using UnityEngine;
using UnityEngine.UI;

public class Scroller : MonoBehaviour
{

    [SerializeField] private RawImage _img;
    [SerializeField] private float _x, y;



    void Update()
    {
        _img.uvRect = new Rect(_img.uvRect.position + new Vector2(_x, y) * Time.deltaTime, _img.uvRect.size);
    }
}
