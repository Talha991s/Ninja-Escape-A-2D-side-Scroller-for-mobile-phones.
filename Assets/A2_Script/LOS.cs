using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class LOS : MonoBehaviour
{
    public Collider2D Collidewithp;
    public ContactFilter2D Contactfilterp;
    public List<Collider2D> collidep;

    private BoxCollider2D LosColliderp;


    // Start is called before the first frame update
    void Start()
    {
        LosColliderp = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Physics2D.GetContacts(LosColliderp, Contactfilterp, collidep);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Collidewithp = other;
    }
}
