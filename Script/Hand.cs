using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hand : MonoBehaviour
{
    public Player player;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "O1")
        {
            player.stage1_1 = true;
        }
        if (other.tag == "O2")
        {
            player.stage1_2 = true;
        }
        if (other.tag == "O3")
        {
            player.stage1_3 = true;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("O1"))
        {
            player.stage1_1 = true;
        }
        if (collision.collider.CompareTag("O2"))
        {
            player.stage1_2 = true;
        }
        if (collision.collider.CompareTag("O3"))
        {
            player.stage1_3 = true;
        }
    }
}
