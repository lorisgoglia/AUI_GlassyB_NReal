/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class CustomDebug
{
    
    public void DrawRectangle(Vector2 top_right_corner, Vector2 bottom_left_corner)
    {
        Vector2 displacement_vector = top_right_corner - bottom_left_corner;
        float x_projection = Vector2.Dot(displacement_vector, Vector2.right);
        float y_projection = Vector2.Dot(displacement_vector , Vector2.up);

        Vector2 top_left_corner = new Vector2(-x_projection * 0.5f, y_projection * 0.5f);
        Vector2 bottom_right_corner = new Vector2(x_projection * 0.5f, -y_projection * 0.5f);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}*/
