using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cau1
{
    class DoVat
    {
        public string tenDV { get; set; }
        public int giaTri { get; set;}
        public int soLuong { get; set; }
        public int trongLuong1 { get; set; }
        public int trongLuong2 { get; set; }
    }

    class Class1
    {
        class Item
    {
        public string Name { get; set; }
        public int Value { get; set; }
        public int Weight1 { get; set; }
        public int Weight2 { get; set; }
        public int Quantity { get; set; }
    }

        class Class1
        {
            static void Main(string[] args)
            {
                Item[] items = {
            new Item { Name = "Sách", Value = 60, Weight1 = 10, Weight2 = 20, Quantity = 3 },
            new Item { Name = "Máy tính", Value = 100, Weight1 = 20, Weight2 = 10, Quantity = 2 },
            new Item { Name = "Đèn pin", Value = 120, Weight1 = 30, Weight2 = 15, Quantity = 1 }
        };

                int capacity1 = 50;
                int capacity2 = 40;

                int totalValue = SolveKnapsackProblem(items, capacity1, capacity2);

                Console.WriteLine("Tổng giá trị các mặt hàng trong balo: {totalValue}");
                Console.WriteLine("Các mặt hàng trong balo:");
                foreach (var item in items)
                {
                    if (item.Weight1 <= capacity1 && item.Weight2 <= capacity2 && item.Quantity > 0)
                    {
                        Console.WriteLine("- {item.Name} (Số lượng: {item.Quantity})");
                        item.Quantity--;
                    }
                }
            }

            static int SolveKnapsackProblem(Item[] items, int capacity1, int capacity2)
            {
                Array.Sort(items, (a, b) => (b.Value * Math.Max(a.Weight1, a.Weight2)).CompareTo(a.Value * Math.Max(b.Weight1, b.Weight2)));

                int totalValue = 0;
                int currentWeight1 = 0;
                int currentWeight2 = 0;

                foreach (var item in items)
                {
                    if (currentWeight1 + item.Weight1 <= capacity1 && currentWeight2 + item.Weight2 <= capacity2 && item.Quantity > 0)
                    {
                        totalValue += item.Value;
                        currentWeight1 += item.Weight1;
                        currentWeight2 += item.Weight2;
                        item.Quantity--;
                    }
                    else
                    {
                        break;
                    }
                }

                return totalValue;
            }
        }
    }
}
