using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    private bool canDrag = true;
    private int startIndex = 0;

    private int currentIndex;
    public List<GameObject> particleVFXs;
    [SerializeField] private List<GameLevel> levels;
    
    private TouchPoint head;
    private int id1 = 0;
    private int id2 = 0;
    private int id3 = 0;
    private int id4 = 0;
    private int id5 = 0;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        currentIndex = startIndex;
        levels[currentIndex].gameObject.SetActive(true);
    }

    public void CheckLevelUp()
    {
        canDrag = false;
        GameObject explosion = Instantiate(particleVFXs[Random.Range(0,particleVFXs.Count)], transform.position, transform.rotation);
        Destroy(explosion, .75f);
        Invoke(nameof(NextLevel),1.0f);
    }

    void NextLevel()
    {
        levels[currentIndex].gameObject.SetActive(false);
        currentIndex++;
        if (currentIndex >= 3)
        {
            currentIndex = startIndex;
            canDrag = true;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        else
        {
            levels[currentIndex].gameObject.SetActive(true);
            canDrag = true;
        }
        
    }
    
    Vector3 offset;

    void Update()
    {
        if(!canDrag) return;
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (Input.GetMouseButtonDown(0))
        {
            Collider2D targetObject = Physics2D.OverlapPoint(mousePosition);
            if (targetObject)
            {
                var tp = targetObject.GetComponent<Bar>();
                if (tp != null)
                {
                    tp.RoTate();
                    canDrag = false;
                    Invoke(nameof(EnableDrag),0.25f);
                }
            }
        }
    }

    public void EnableDrag()
    {
        canDrag = true;
    }
    public GameLevel GetCurLevel()
    {
        return levels[currentIndex];
    }
}