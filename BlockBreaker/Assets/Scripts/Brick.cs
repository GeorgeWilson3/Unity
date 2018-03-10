
using UnityEngine;

public class Brick : MonoBehaviour
{
    public static int breakableCount = 0;
    public AudioClip crackSound;
    public AudioClip breakSound;
    public AudioClip unbreakableSound;


    private int timesHit;
    public Sprite[] hitSprites;
    private bool isBreakable;

    private LevelManager levelManager;
    

    // Use this for initialization
    void Start()
    {
        isBreakable = this.tag == "Breakable";
        if (isBreakable)
        {
            breakableCount++;
        }

        timesHit = 0;
        levelManager = GameObject.FindObjectOfType<LevelManager>();
       
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (isBreakable)
        {
            HandleHits();
        }
        else
        {
            AudioSource.PlayClipAtPoint(unbreakableSound, transform.position, 0.8f);
        }

    }

    void HandleHits()
    {
        timesHit++;
        print("Times hit:" + timesHit);

        if (timesHit >= hitSprites.Length)
        {
            AudioSource.PlayClipAtPoint(breakSound, transform.position, 0.8f);
            breakableCount--;
            Debug.Log("Current brick count: " + breakableCount);
            levelManager.BricksDetroyed();
            
            DestroyObject(gameObject);

        }
        else
        {
            AudioSource.PlayClipAtPoint(crackSound, transform.position, 0.8f);
            LoadSprites();
        }
    }

    private void LoadSprites()
    {
        int spriteIndex = timesHit;
        if (hitSprites[spriteIndex])
        {
            Color color = new Color();
            
            if (hitSprites.Length - timesHit == 1)
            {
                color.r = 0;
                color.g = 255;
                color.b = 0;
                color.a = 255;
            }
            else if (hitSprites.Length - timesHit == 2)
            {
                color.r = 255;
                color.g = 255;
                color.b = 0;
                color.a = 255;
            }
            this.GetComponent<SpriteRenderer>().color = color;
            // this.GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];

        }
        
    }

    // TODO: Remove this methois once we can actually win
    void SimulateWin()
    {
        levelManager.LoadNextLevel();
    }

}
