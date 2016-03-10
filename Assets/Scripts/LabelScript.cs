using UnityEngine;
using System.Collections;

public class LabelScript : MonoBehaviour
{

    public int order = 3;
	public string layer = "main";
    public string VocabuloryTextKey = "";

    void Start()
    {
        if (GetComponent<MeshRenderer>() != null)
        {
            GetComponent<MeshRenderer>().sortingOrder = order;
			GetComponent<MeshRenderer>().sortingLayerName = layer;
        }
        else
        {
            Debug.Log("Missing MeshRenderer for text");
        }

        if (VocabuloryTextKey != "") gameObject.GetComponent<TextMesh>().text = Localization.getText(VocabuloryTextKey);
    }

	/**
	*  Текст надписи
	 **/
	public string text
	{
		get
		{
            TextMesh tm = GetComponent<TextMesh>();
			return tm.text;
		}
		set
		{
			TextMesh tm = GetComponent<TextMesh>();
			tm.text = value;
		}
	}
	/**
	*  Размер текста
	 **/ 
	public float textSize
	{
		get
		{
            TextMesh tm = GetComponent<TextMesh>();
			return tm.characterSize;
		}
		set
		{
            TextMesh tm = GetComponent<TextMesh>();
			tm.characterSize = value;
		}
	}
	/**
	*  Цвет текста
	 **/ 
	public Color textColor
	{
		get
		{
            TextMesh tm = GetComponent<TextMesh>();
			return tm.color;
		}
		set
		{
            TextMesh tm = GetComponent<TextMesh>();
			tm.color = value;
		}
	}
}
