using UnityEngine;

public class Clicker : MonoBehaviour
{

    public void Click(GameObject Subject)
    {
        Subject.GetComponent<Subject>().Click();
    }
}
