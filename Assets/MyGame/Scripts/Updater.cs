using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Updater : MonoBehaviour {

    [SerializeField] Text text; //doesn't have to be accessed outside function so changed to private
    [SerializeField] string inputtext; // see  above
    public GameObject circleColor;
    public Color color;
    public GameObject[] shuffleCircles;

    [SerializeField] GameObject circlePosition;

    private List<Color> colorList;
    private System.Random rnd = new System.Random();
    
    private void Start()
    {
        //deleted bc unnecessary 

        colorList = new List<Color> {
            Color.red,
            Color.blue,
            Color.green, //missed a comma
            Color.magenta
        };
    }

    public void UpdateTextWithInspectorInput()
    {
        text.text = inputtext; //changed first text to lowercase so it matches w/ variable
    }

    public void UpdateCircleColor()
    {
        SpriteRenderer circRenderer = circleColor.GetComponent<SpriteRenderer>();
        byte r = (byte)rnd.Next(0, 255);
        byte g = (byte)rnd.Next(0, 255);
        byte b = (byte)rnd.Next(0, 255);
        byte a = 255; //only colours are cycled, not alpha channel

        circRenderer.color = new Color32(r, g, b, a);
    }
	
    public void UpdateObjectPosition()
    {
        Transform circleTransform = circlePosition.GetComponent<Transform>(); //changed fro circ to circle for better orientation
        
        float randomPosX = UnityEngine.Random.Range(5, 433);
        circleTransform.localPosition = new Vector3(randomPosX, circleTransform.localPosition.y, circleTransform.localPosition.z);
    }

    public void ShuffleColorsInCircles()
    {
        List<SpriteRenderer> objectList = new List<SpriteRenderer>();
        
        foreach(GameObject item in shuffleCircles)
        {
            objectList.Add(item.GetComponent<SpriteRenderer>());
        }

        colorList.Shuffle();

        for(int i = 0; i < objectList.Count; i++)
        {
            objectList[i].color = colorList[i];
        }
    }
}
