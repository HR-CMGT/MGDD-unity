using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    // verander private naar public om in de editor te kunnen tweaken met de waarden
    private Vector2 Speed = new Vector2(-1f, 0);

    void Update()
    {
        // movement voor non-physics objects
        transform.Translate(Speed * Time.deltaTime);
    }
}
