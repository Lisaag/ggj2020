using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour
{
    public int currentLife = 1;

    public List<Material> materials;
    // Start is called before the first frame update
    void Start()
    {
        BrickManager.instance.Bricks.Add(this.gameObject);
        GetComponent<Renderer>().material = materials[currentLife - 1];
    }

    public void RemoveLife()
    {
        currentLife--;

        if (currentLife <= 0)
        {
            Destroy(gameObject);
            return;
        }

        GetComponent<Renderer>().material = materials[currentLife - 1];
    }
}
