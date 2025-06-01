using UnityEngine;

public class ProjectileMoveRogue : MonoBehaviour
{
   private Transform ArmRogue;
   private float topBoundX;
   private float lowerBoundX;
   private float topBoundZ;
   private float lowerBoundZ;
   public float speed = 30.0f;
   void Start()
    {
        ArmRogue = GameObject.FindGameObjectWithTag("ArmRogue").GetComponent<Transform>();
    }

   void Update()
   {
      transform.Translate(Vector3.down * Time.deltaTime * speed);

      topBoundX = ArmRogue.transform.position.x + 10.0f;
      lowerBoundX = ArmRogue.transform.position.x + -10.0f;
      topBoundZ = ArmRogue.transform.position.z + 10.0f;
      lowerBoundZ = ArmRogue.transform.position.z + -10.0f;

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