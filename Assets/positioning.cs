using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class positioning : MonoBehaviour
{
  
        // Start is called before the first frame update
        public GameObject goal;

        // Update is called once per frame
        void Update()
        {

            Quaternion goalv = new Quaternion(0, goal.transform.rotation.y, 0, goal.transform.rotation.w);
            Vector3 goalp = new Vector3(goal.transform.position.x, goal.transform.position.y - 1.3f, goal.transform.position.z-0.1f);
            transform.rotation = goalv;
            transform.position = goalp;

        }
    
}
