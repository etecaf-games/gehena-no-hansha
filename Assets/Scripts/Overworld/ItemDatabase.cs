using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDatabase : MonoBehaviour
{
    public List<Item> items = new List<Item>();

    void Awake()
    {
        BuildDatabase();
    }
    public Item GetItem(int id)
    {
        return items.Find(item => item.id == id);
    }

    public Item GetItem(string itemName)
    {
        return items.Find(item => item.title == itemName);
    }

    void BuildDatabase()
    {
        items = new List<Item>() {
            new Item(0, "Canivete", "Uma lâmina pequena, mas afiada! Cuidado! Pode acabar furando um olho!",
            new Dictionary<string, int> {
                { "Ataque", 1 },

            }),
            new Item(1, "Doce", "Para te manter animado com o combate! Mas não exagera! Sua mãe disse para pegar só um!  .",
            new Dictionary<string, int> {
                { "Cura Hp", 5 }
            }),
            new Item(2, "Bebida", "Revigora corpo e espírito! Sério, essa coisa revigora sua alma por algum motivo! Mas não faz bem pros ossos",
            new Dictionary<string, int> {
                { "Cura Sp", 5 },
            })
        };
    }
}
