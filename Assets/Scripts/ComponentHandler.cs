using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComponentHandler : MonoBehaviour
{
    [SerializeField]
    List<GameObject> listComponent = new List<GameObject>();
    [SerializeField]
    GameObject UnlocokableObject;
    public static ComponentHandler componentHandler;

    private void Awake()
    {
        componentHandler = this;
    }

    public bool CheckAllComponentDisable()
    {
        bool flag = true;
        foreach(GameObject component in listComponent)
        {
            if (component.activeInHierarchy)
            {
                flag = false;
            }
        }
        return flag;
    }

    public void Unlock()
    {
        UnlocokableObject.SetActive(CheckAllComponentDisable());
    }
}
