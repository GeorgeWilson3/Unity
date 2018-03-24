
using UnityEngine;

public class Brick : MonoBehaviour
{
    [SerializeField]
    private static int breakableCount;

    [SerializeField]
    private AudioClip crackSound;
    [SerializeField]
    private AudioClip breakSound;
    [SerializeField]
    private AudioClip unbreakableSound;


    private int timesHit;
    [SerializeField]
    private Sprite[] hitSprites;
    private bool isBreakable;

    private LevelManager levelManager;

    public static int BreakableCount
    {
        get
        {
            return breakableCount;
        }

        set
        {
            breakableCount = value;
        }
    }

    public AudioClip CrackSound
    {
        get
        {
            return crackSound;
        }

        set
        {
            crackSound = value;
        }
    }

    public AudioClip BreakSound
    {
        get
        {
            return breakSound;
        }

        set
        {
            breakSound = value;
        }
    }

    public AudioClip UnbreakableSound
    {
        get
        {
            return unbreakableSound;
        }

        set
        {
            unbreakableSound = value;
        }
    }

    public Sprite[] HitSprites
    {
        get
        {
            return hitSprites;
        }

        set
        {
            hitSprites = value;
        }
    }


    // Use this for initialization
    void Start()
    {
        isBreakable = this.tag == "Breakable";
        if (isBreakable)
        {
            BreakableCount++;
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
            AudioSource.PlayClipAtPoint(UnbreakableSound, transform.position, 0.8f);
        }

    }

    void HandleHits()
    {
        timesHit++;
        print("Times hit:" + timesHit);

        if (timesHit >= HitSprites.Length)
        {
            AudioSource.PlayClipAtPoint(BreakSound, transform.position, 0.8f);
            BreakableCount--;
            Debug.Log("Current brick count: " + BreakableCount);
            levelManager.BricksDetroyed();
            
            DestroyObject(gameObject);

        }
        else
        {
            AudioSource.PlayClipAtPoint(CrackSound, transform.position, 0.8f);
            LoadSprites();
        }
    }

    private void LoadSprites()
    {
        int spriteIndex = timesHit;
        if (HitSprites[spriteIndex])
        {
            Color color = new Color();
            
            if (HitSprites.Length - timesHit == 1)
            {
                color.r = 0;
                color.g = 255;
                color.b = 0;
                color.a = 255;
            }
            else if (HitSprites.Length - timesHit == 2)
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
