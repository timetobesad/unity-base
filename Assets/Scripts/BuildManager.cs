using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public string buildAvilTag;

    public Camera mainCam;

    private GameObject prevObj;
    private GameObject currObj;

    public Material[] colors;

    [SerializeField]
    public BuildObj obj;

    private GameObject prevObjBuild;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Debug.Log("click");

            if (obj.texture == null) return;

            Instantiate(obj.objBuild, prevObjBuild.transform.position, prevObjBuild.transform.rotation);

            Destroy(prevObjBuild);
            obj = null;
        }

        if (obj != null && obj.objPreview != null)
        {

            Vector3 pos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0);
            Ray ray = mainCam.ScreenPointToRay(pos);

            RaycastHit hit;

            Debug.DrawRay(ray.origin, ray.direction * 10, Color.yellow);

            if (Physics.Raycast(mainCam.ScreenPointToRay(pos), out hit, 144))
            {
                if (hit.transform.gameObject.tag != buildAvilTag)
                    return;

                prevObjBuild.transform.position = new Vector3(hit.transform.position.x, hit.transform.position.y + 1, hit.transform.position.z);
            }

        }
    }

    public void setBuildObj(BuildObj obj)
    {
        this.obj = obj;

        prevObjBuild = Instantiate(obj.objPreview, new Vector3(0, 0, -144), Quaternion.identity);
    }
}
