using UnityEngine;
using System.Collections;

public class SpriteScript : MonoBehaviour
{
	/**
	*  Координата Х в юнитах
	 **/
	public virtual float x
	{
		get
		{
			return transform.position.x;
		}
		set
		{
			Vector3 p = transform.position;
			p.Set(value, p.y, p.z);
			transform.position = p;
		}
	}

	/**
	*  Координата Y в юнитах
	 **/
	public virtual float y
	{
		get
		{
			return transform.position.y;
		}
		set
		{
			Vector3 p = transform.position;
			p.Set(p.x, value, p.z);
			transform.position = p;
		}
	}

	/**
	*  Поворот спрайта в градусах
	 **/
	public virtual float rotation
	{
		get
		{
			return transform.rotation.eulerAngles.z;
		}
		set
		{
			transform.rotation = Quaternion.Euler(0,0,value);
		}
	}

	/**
	*  Изменение размера спрайта по Х
	 **/
	public virtual float scaleX
	{
		get
		{
			return transform.localScale.x;
		}
		set
		{
			Vector3 s = transform.localScale;
			s.Set(value, s.y, s.z);
			transform.localScale = s;
		}
	}

	/**
	*  Изменение размера спрайта по Y
	 **/
	public virtual float scaleY
	{
		get
		{
			return transform.localScale.y;
		}
		set
		{
			Vector3 s = transform.localScale;
			s.Set(s.x, value, s.z);
			transform.localScale = s;
		}
	}

	/**
	*  Изменение прозрачности спрайта
	 **/
	public virtual float alpha
	{
		get
		{
            return GetComponent<Renderer>().material.color.a;
		}
		set
		{
			Color32 c = GetComponent<Renderer>().material.color;
            GetComponent<Renderer>().material.color = new Color32(c.r, c.g, c.b, (byte)Mathf.Lerp(0, 255, value));
		}
	}

    /**
    *  Color32 R-component (0-255)
    **/
    public virtual byte r
    {
        get
        {
            Color32 rColor = GetComponent<Renderer>().material.color;
            return rColor.r;
        }
        set
        {
            Color32 c = GetComponent<Renderer>().material.color;
            GetComponent<Renderer>().material.color = new Color32(value, c.g, c.b, c.a);
        }
    }
    /**
    *  Color32 G-component (0-255)
    **/
    public virtual byte g
    {
        get
        {
            Color32 rColor = GetComponent<Renderer>().material.color;
            return rColor.g;
        }
        set
        {
            Color32 c = GetComponent<Renderer>().material.color;
            GetComponent<Renderer>().material.color = new Color32(c.r, value, c.b, c.a);
        }
    }
    /**
    *  Color32 B-component (0-255)
    **/
    public virtual byte b
    {
        get
        {
            Color32 rColor = GetComponent<Renderer>().material.color;
            return rColor.b;
        }
        set
        {
            Color32 c = GetComponent<Renderer>().material.color;
            GetComponent<Renderer>().material.color = new Color32(c.r, c.g, value, c.a);
        }
    }


	/**
	*  Ширина спрайта вместе с детьми
	 **/
	public virtual float width
	{
		get
		{
            float min = Mathf.Infinity;
            float max = -Mathf.Infinity;

            if (GetComponent<Renderer>() != null)
            {
                max = GetComponent<Renderer>().bounds.max.x;
                min = GetComponent<Renderer>().bounds.min.x;
            }
            
			SpriteScript[] children = GetComponentsInChildren<SpriteScript>();
            if (children.Length == 0) return 0;
			foreach (SpriteScript child in GetComponentsInChildren<SpriteScript>())
            {
                if (child.GetComponent<Renderer>() != null)
                {
                    if (child.GetComponent<Renderer>().bounds.max.x > max) max = child.GetComponent<Renderer>().bounds.max.x;
                    if (child.GetComponent<Renderer>().bounds.min.x < min) min = child.GetComponent<Renderer>().bounds.min.x;
                }
            }
            return max - min;
		}
	}

	/**
	*  Ширина спрайта без детей
	 **/
    public virtual float width_clear
    {
        get
        {
            if (GetComponent<Renderer>() != null)
            {
                return GetComponent<Renderer>().bounds.size.x;
            }
            
            return 0;
        }
    }

	/**
	*  Высота спрайта вместе с детьми
	 **/
	public virtual float height
	{
		get
		{
            float min = Mathf.Infinity;
            float max = -Mathf.Infinity;

            if (GetComponent<Renderer>() != null)
            {
                min = GetComponent<Renderer>().bounds.min.y;
                max = GetComponent<Renderer>().bounds.max.y;
            }

			SpriteScript[] children = GetComponentsInChildren<SpriteScript>();
            if (children.Length == 0) return 0;
			foreach (SpriteScript child in GetComponentsInChildren<SpriteScript>())
            {
                if (child.GetComponent<Renderer>() != null)
                {
                    if (child.GetComponent<Renderer>().bounds.max.y > max) max = child.GetComponent<Renderer>().bounds.max.y;
                    if (child.GetComponent<Renderer>().bounds.min.y < min) min = child.GetComponent<Renderer>().bounds.min.y;
                }
            }
            return max - min;
		}
	}



	/**
	*  Высота спрайта без детей
	 **/
    public virtual float height_clear
    {
        get
        {

            if (GetComponent<Renderer>() != null)
            {
                return GetComponent<Renderer>().bounds.size.y;
            }

            return 0;
        }
    }

	/**
	*  Получение пути к картинке спрайта или передача картинки в спрайт
	 **/
    string _src;
    public string src
    {
        get
        {
            return _src;
        }
        set
        {
            _src = value;
            (GetComponent<Renderer>() as SpriteRenderer).sprite = Resources.Load<Sprite>(src);
        }
    }

	/**
	*  Изменение цвета спрайта
	 **/
    Color _color;
    public Color color
    {
        get
        {
            return _color;
        }
        set
        {
            (GetComponent<Renderer>() as SpriteRenderer).color = _color = value;
        }
    }
    /**
    *  Изменение цвета спрайта
    *  Color32 для нормального взаимодействия с Tween-скриптами
     **/
    Color32 _color32;
    public Color32 color32
    {
        get
        {
            return _color32;
        }
        set
        {
            (GetComponent<Renderer>() as SpriteRenderer).color = _color32 = value;
        }
    }
}
