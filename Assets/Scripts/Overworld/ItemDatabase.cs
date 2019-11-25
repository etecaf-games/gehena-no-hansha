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
            new Item(0, "Canivete", "Uma lâmina pequena, mas afiada! Cuidado! Pode acabar furando um olho!",new Dictionary<string, int> {{ "Ataque", 1 }},true),
            new Item(1, "Doce", "Para te manter animado com o combate! Mas não exagera! Sua mãe disse para pegar só um!  .",
            new Dictionary<string, int> {
                { "Cura Hp", 5 }
            },false),
            new Item(2, "Bebida", "Revigora corpo e espírito! Sério, essa coisa revigora sua alma por algum motivo! Mas não faz bem pros ossos",
            new Dictionary<string, int> {
                { "Cura Sp", 5 },
            },false),
            new Item(3,"Capacete", "Proteção fácil! Evite andar de moto ou praticar esportes sem um desses, segurança em primeiro lugar!",
                new Dictionary<string, int>{
                    {"Acerto bônus de Defesa", 1},
                },true),
            new Item(4,"Taco", "As pessoas dizem que baseball não é um esporte violente. Mas você com um taco de baseball? Ai é outra história.",
                new Dictionary<string, int>{
                    {"Acerto bônus de Ataque", 1},
                },false),
                 new Item(5,"Spray de Pimenta", "Sempre vale a pena andar com um desses na bolsa, mesmo que você esteja enfrentando monstros terríveis!",
                new Dictionary<string, int>{
                    {"Dano de toxina", 7},
                    {"Chance de cegueria", 75},
                },false),
                new Item(6,"Carta para Ária", "Uma carta de amor adolescente! Aparentemente, alguém se apaixonou por Ária em uma apresentação dela. Quem escreveu compara a voz dela a um anjo! Uma pena que nem todos viam desse jeito...",
                    new Dictionary<string, int>{
                        {"Memento Ária", 1},
                    },false),
               new Item(7,"Microfone de Ária", "Todo rosa, até meio infantil. Aparentemente, Ária usava apenas este microfone, um presente de sua avó. Ela dizia que a ajudava a superar a timidez. O fato dele estar num armário que não o dela já mostra como pegavam pesado com ela...",
                   new Dictionary<string, int>{
                       {"Memento Ária", 1},
                   },false),
                new Item(8,"Grampo", "Apenas um grampo de cabelo para alguns, mas uma forma de abrir caminhos para outros!",
                    new Dictionary<string, int>{
                      
                    },false),

                new Item(9,"O último Bilhete", "Um bilhete de despedida escrito com ódio e tristeza. Quando Ária o fez, ela achou que nunca mais teria que encarar seus problemas, mas agora ela é uma só com eles...",
                    new Dictionary<string, int>{
                        {"Memento Ária", 1},
                    },false),
        
        };
    }
}
