using UnityEngine;

public class ProjectileMoveMage : MonoBehaviour
{
   private Transform baculeMage;
   private float topBoundX;
   private float lowerBoundX;
   private float topBoundZ;
   private float lowerBoundZ;
   public float speed = 30.0f;
   void Start()
    {
        baculeMage = GameObject.FindGameObjectWithTag("BaculeMage").GetComponent<Transform>();
    }

   void Update()
   {
      transform.Translate(Vector3.forward * Time.deltaTime * speed);

      topBoundX = baculeMage.transform.position.x + 10.0f;
      lowerBoundX = baculeMage.transform.position.x + -10.0f;
      topBoundZ = baculeMage.transform.position.z + 10.0f;
      lowerBoundZ = baculeMage.transform.position.z + -10.0f;

      if (transform.position.x > topBoundX)
      {
         Destroy(gameObject);
      }
      else if (transform.position.x < lowerBoundX)
      {
         Destroy(gameObject);
      }
      else if (transform.position.z > topBoundZ)
      {
         Destroy(gameObject);
      }
      else if (transform.position.z < lowerBoundZ)
      {
         Destroy(gameObject);
      }
    
   }
    
}