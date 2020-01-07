using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonTest : MonoBehaviour
{
    public Button but;
    public void freeze()
    {
        but.interactable = false;
    }
}
