using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class Brick : MonoBehaviour
{
    public int currentLife = 1;

    public List<Material> materials;
    public List<Mesh> meshes;

    public VisualEffect vfx;
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
            GameObject vfxClone = Instantiate(vfx.gameObject, new Vector3(transform.position.x, transform.position.y, vfx.transform.position.z), Quaternion.identity, null);
            vfxClone.SetActive(true);
            Destroy(gameObject);
            return;
        }

        GetComponent<Renderer>().material = materials[currentLife - 1];
        GetComponent<MeshFilter>().mesh = meshes[currentLife - 1];
    }
}
