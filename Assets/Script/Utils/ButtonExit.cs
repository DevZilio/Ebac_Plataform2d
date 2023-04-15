using System.Net.Mime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonExit : MonoBehaviour
{
  public void Quit()
  {
      Application.Quit();
      Debug.Log("Quit");
  }
}
