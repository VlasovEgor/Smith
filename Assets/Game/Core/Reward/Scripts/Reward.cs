using UnityEngine;

public class Reward : MonoBehaviour
{
    [SerializeField] private TypeReward _type;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
      var storage = other.GetComponent<Entity>().GetComponentImplementing<Bag>();
      storage.AddReward(_type);
      Destroy(gameObject);
    }
}
