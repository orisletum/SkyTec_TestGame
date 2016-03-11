using UnityEngine;
using System.Collections;

public class ButtonScript : SpriteScript
{
	public delegate void Func(ButtonScript target);

    public Func onClick;
    public Func onDown;

    public Vector2 baseScale;



    float downscaleFactor = 0.8f;



    void Start()
    {
        //
        gameObject.layer = LayerMask.NameToLayer("Button") < 0?0:LayerMask.NameToLayer("Button");

        if (GetComponent<Collider2D>() != null)
            GetComponent<Collider2D>().isTrigger = true;
       
    }

    void OnMouseDown()
    {
        MouseDown();
        if (onDown != null) onDown(this);
    }

	virtual public void MouseDown()
    {

    }

    void OnMouseUp()
    {
        MouseUp();
		if (onClick != null) onClick(this);
    }

	virtual public void MouseUp()
    {


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