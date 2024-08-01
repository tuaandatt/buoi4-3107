using System;
using System.Collections.Generic;
//lamtuandat
//2033212004
class Item
{
    public int Value { get; set; }
    public int Weight { get; set; }

    public Item(int value, int weight)
    {
        Value = value;
        Weight = weight;
    }

    public double Ratio()
    {
        return (double)Value / Weight;
    }
}

class SelectedItem
{
    public Item Item { get; set; }
    public int Quantity { get; set; }

    public SelectedItem(Item item, int quantity)
    {
        Item = item;
        Quantity = quantity;
    }
}

class Program
{
    static Tuple<int, List<SelectedItem>, List<Item>> GreedyKnapsack(int capacity, List<Item> items)
    {
        // Sắp xếp các vật phẩm theo tỷ lệ giá trị trên trọng lượng giảm dần
        items.Sort((a, b) => b.Ratio().CompareTo(a.Ratio()));

        int totalValue = 0;
        int currentWeight = 0;
        List<SelectedItem> selectedItems = new List<SelectedItem>();
        List<Item> notSelectedItems = new List<Item>();

        foreach (var item in items)
        {
            if (currentWeight + item.Weight <= capacity)
            {
                currentWeight += item.Weight;
                totalValue += item.Value;
                selectedItems.Add(new SelectedItem(item, 1));
            }
            else
            {
                notSelectedItems.Add(item);
            }
        }

        return Tuple.Create(totalValue, selectedItems, notSelectedItems);
    }

    static void Main()
    {
        // Tự cho mảng các đồ vật
        List<Item> items = new List<Item>
        {
            new Item(100, 10),
            new Item(200, 20),
            new Item(150, 15),
            new Item(80, 5),
            new Item(120, 10),
            new Item(50, 5)
        };

        Console.Write("Nhập dung lượng của Ba lô: ");
        int capacity = int.Parse(Console.ReadLine());

        var result = GreedyKnapsack(capacity, items);
        int maxValue = result.Item1;
        List<SelectedItem> selectedItems = result.Item2;
        List<Item> notSelectedItems = result.Item3;

        Console.WriteLine("Giá trị lớn nhất trong Ba lô = " + maxValue);
        Console.WriteLine("Các vật phẩm được chọn:");
        foreach (var selectedItem in selectedItems)
        {
            Console.WriteLine(" Giá trị: " + selectedItem.Item.Value + " Trọng lượng: " + selectedItem.Item.Weight + " Số lượng: " + selectedItem.Quantity);
        }

        Console.WriteLine("Các vật phẩm không được chọn:");
        foreach (var item in notSelectedItems)
        {
            Console.WriteLine(" Giá trị: " + item.Value + " Trọng lượng: " + item.Weight);
        }
    }
}
