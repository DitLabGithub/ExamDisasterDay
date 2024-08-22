using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory_Nav : MonoBehaviour
{
    public GameObject InventoryPanel;
    public GameObject PhoneInventory;
    public GameObject SSIPanel;
    public GameObject Particle;
    public void InventoryOpen()
    {
    InventoryPanel.SetActive(!InventoryPanel.activeSelf);
    }
    public void PhoneOpen()
    {
    PhoneInventory.SetActive(!PhoneInventory.activeSelf);
    }
    public void SSIOpen()
    {
        SSIPanel.SetActive(!SSIPanel.activeSelf);
    }
    public void ParticleSpawn()
    {
        Instantiate(Particle, transform);
    }
}
