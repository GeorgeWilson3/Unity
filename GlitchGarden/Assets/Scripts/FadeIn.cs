
using UnityEngine;
using UnityEngine.UI;

public class FadeIn : MonoBehaviour
{

    public float fadeInTime;
    private Image fadePanel;
    private Color currentColor = Color.black ;

	// Use this for initialization
	void Start ()
    {
        fadePanel = GetComponent<Image>();
        currentColor.b = 0.1294118f;
        currentColor.r = 0.1607843f;
        currentColor.g = 0.4019608f;
        currentColor.a = 1f;
        fadePanel.color = currentColor;
    }
	
	// Update is called once per frame
	void Update ()
    {
		if(Time.timeSinceLevelLoad < fadeInTime)
        {
            //fadePanel.color.a = fadePanel.color.a - 0.1);\
            float alphaChange = Time.deltaTime / fadeInTime;
            currentColor.a -= alphaChange;
            fadePanel.color = currentColor;
        }
        else
        {
            gameObject.SetActive(false);            
        }

	}
}
