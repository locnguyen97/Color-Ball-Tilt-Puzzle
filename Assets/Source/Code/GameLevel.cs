using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLevel : MonoBehaviour
{
    public List<GameObject> gameObjectsTarget;
    [SerializeField] private Transform parentListObj;
    private bool canCheck = true;
    public void Start()
    {
        canCheck = true;
        foreach (Transform tr in parentListObj)
        {
            gameObjectsTarget.Add(tr.gameObject);
            //tr.gameObject.SetActive(false);
        }
        
    }

    public void RemoveObject(GameObject obj)
    {
        gameObjectsTarget.Remove(obj);
        if (canCheck)
        {
            if (gameObjectsTarget.Count == 0)
            {
                GameManager.Instance.CheckLevelUp();
                canCheck = false;
            }
        }
    }
}
