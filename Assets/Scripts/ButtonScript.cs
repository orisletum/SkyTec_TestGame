using UnityEngine;
using System.Collections;

public class ButtonScript : SpriteScript
{
	public delegate void Func(ButtonScript target);

    public Func onClick;
    public Func onDown;

    public Vector2 baseScale;

    BoxCollider2D bc = null;
    CircleCollider2D cc = null;

    float downscaleFactor = 0.8f;

//    Vector2 lossyScale;

    void Start()
    {
        //
        gameObject.layer = LayerMask.NameToLayer("Button") < 0?0:LayerMask.NameToLayer("Button");

        if (GetComponent<Collider2D>() != null)
            GetComponent<Collider2D>().isTrigger = true;
        //

//        lossyScale = transform.lossyScale;
//        baseScale = new Vector2(scaleX, scaleY);
//        bc = GetComponent<BoxCollider2D>();
//        if (bc != null)
//        {
//            bc.size = new Vector2(width / lossyScale.x, height / lossyScale.y);
//        }
//        else
//        {
//            cc = GetComponent<CircleCollider2D>();
//            if (cc != null)
//            {
//                cc.radius = width / lossyScale.x * 0.5f;
//            }
//        }
//        base.Start();
    }

    void OnMouseDown()
    {
        MouseDown();
        if (onDown != null) onDown(this);
    }

	virtual public void MouseDown()
    {
//        scaleX = baseScale.x * downscaleFactor;
//        scaleY = baseScale.y * downscaleFactor;
//        if (bc != null)
//        {
//            bc.size = new Vector2(bc.size.x * (1f / downscaleFactor), bc.size.y * (1f / downscaleFactor));
//        }
//        else if (cc != null)
//        {
//            cc.radius = cc.radius * (1f / downscaleFactor);
//        }
    }

    void OnMouseUp()
    {
        MouseUp();
		if (onClick != null) onClick(this);
    }

	virtual public void MouseUp()
    {
//        scaleX = baseScale.x * 1.0f;
//        scaleY = baseScale.y * 1.0f;

//        if (bc != null)
//        {
//            bc.size = new Vector2(width / lossyScale.x, height / lossyScale.y);
//        }
//        else if (cc != null)
//        {
//            cc.radius = width / lossyScale.x * 0.5f;
//        }

    }

    void OnMouseUpAsButton()
    {
        MouseUp();
        if (onClick != null) onClick(this);
    }

    public bool enable
    {
        get
        {
            return GetComponent<Collider2D>().enabled;
        }
        set
        {
            alpha = value ? 1 : .5f;
            GetComponent<Collider2D>().enabled = value;
        }
    }

    bool _visible;
    public bool visible
    {
        get
        {
            return _visible;
        }
        set
        {
            _visible = value;
            alpha = value ? 1 : 0;
            GetComponent<Collider2D>().enabled = value;
        }
    }
}