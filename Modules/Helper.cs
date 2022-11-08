using cakes.Entyties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cakes.Modules
{
    public class Helper
    {
        public List<string> FirstInfo()
        {
            var list = new List<string>();
            list.Add("Заказ тортов в Интернет-магазине Сластёна");
            list.Add("Выберите все параметры торта и оформите заказ.");
            list.Add("_________________________________________________");

            return list;
        }

        public Cake FillNewCake()
        {
            Cake cake = new() { Cake_Attrs = new List<CakeAttr>() };
            cake.Cake_Attrs.Add(GetNewAttrForm());
            cake.Cake_Attrs.Add(GetNewAttrSize());
            cake.Cake_Attrs.Add(GetNewAttrTaste());
            cake.Cake_Attrs.Add(GetNewAttrCountLayers());
            cake.Cake_Attrs.Add(GetNewAttrGlaze());
            cake.Cake_Attrs.Add(GetNewAttrDecor());
            cake.Cake_Attrs.Add(new CakeAttr() { Id = 7, AttrName = "Сформировать заказ", ListProp = new List<CakeProp>() });
            cake.Cake_Attrs.Add(new CakeAttr() { Id = 8, AttrName = "Завершить работу", ListProp = new List<CakeProp>() });
            return cake;
        } 

        private CakeAttr GetNewAttrForm()
        {
            CakeAttr attr = new() { Id=1, AttrName= "форма", ListProp = new List<CakeProp>() };
            attr.ListProp.Add(new CakeProp() { Id = 1, Name = "Круг", Price = 100 });
            attr.ListProp.Add(new CakeProp() { Id = 2, Name = "Квадрат", Price = 200 });
            attr.ListProp.Add(new CakeProp() { Id = 3, Name = "Овал", Price = 300 });
            attr.ListProp.Add(new CakeProp() { Id = 4, Name = "Ромб", Price = 400 });
            attr.ListProp.Add(new CakeProp() { Id = 5, Name = "Звезда", Price = 500 });


            return attr;
        }

        private CakeAttr GetNewAttrSize()
        {
            CakeAttr attr = new() { Id = 2, AttrName = "размер", ListProp = new List<CakeProp>() };
            attr.ListProp.Add(new CakeProp() { Id = 1, Name = "20", Price = 100 });
            attr.ListProp.Add(new CakeProp() { Id = 2, Name = "25", Price = 200 });
            attr.ListProp.Add(new CakeProp() { Id = 3, Name = "30", Price = 300 });
            attr.ListProp.Add(new CakeProp() { Id = 4, Name = "35", Price = 400 });
            attr.ListProp.Add(new CakeProp() { Id = 5, Name = "40", Price = 500 });

            return attr;
        }

        private CakeAttr GetNewAttrTaste()
        {
            CakeAttr attr = new() { Id = 3, AttrName = "вкус", ListProp = new List<CakeProp>() };
            attr.ListProp.Add(new CakeProp() { Id = 1, Name = "Шоколад", Price = 100 });
            attr.ListProp.Add(new CakeProp() { Id = 2, Name = "Клубника", Price = 200 });
            attr.ListProp.Add(new CakeProp() { Id = 3, Name = "Карамель", Price = 300 });
            attr.ListProp.Add(new CakeProp() { Id = 4, Name = "Сливки", Price = 400 });
            attr.ListProp.Add(new CakeProp() { Id = 5, Name = "Сырный", Price = 500 });

            return attr;
        }

        private CakeAttr GetNewAttrCountLayers()
        {
            CakeAttr attr = new() { Id = 4, AttrName = "количество слоёв", ListProp = new List<CakeProp>() };
            attr.ListProp.Add(new CakeProp() { Id = 1, Name = "1", Price = 100 });
            attr.ListProp.Add(new CakeProp() { Id = 2, Name = "2", Price = 200 });
            attr.ListProp.Add(new CakeProp() { Id = 3, Name = "3", Price = 300 });
            attr.ListProp.Add(new CakeProp() { Id = 4, Name = "4", Price = 400 });
            attr.ListProp.Add(new CakeProp() { Id = 5, Name = "5", Price = 500 });

            return attr;
        }

        private CakeAttr GetNewAttrGlaze()
        {
            CakeAttr attr = new() { Id = 5, AttrName = "глазурь ", ListProp = new List<CakeProp>() };
            attr.ListProp.Add(new CakeProp() { Id = 1, Name = "Крем", Price = 100 });
            attr.ListProp.Add(new CakeProp() { Id = 2, Name = "Безе", Price = 200 });
            attr.ListProp.Add(new CakeProp() { Id = 3, Name = "Ягоды", Price = 300 });
            attr.ListProp.Add(new CakeProp() { Id = 4, Name = "Сливки", Price = 400 });
            attr.ListProp.Add(new CakeProp() { Id = 5, Name = "Фрукты", Price = 500 });

            return attr;
        }

        private CakeAttr GetNewAttrDecor()
        {
            CakeAttr attr = new() { Id = 6, AttrName = "декор", ListProp = new List<CakeProp>() };
            attr.ListProp.Add(new CakeProp() { Id = 1, Name = "Сердечки", Price = 100 });
            attr.ListProp.Add(new CakeProp() { Id = 2, Name = "Птички", Price = 200 });
            attr.ListProp.Add(new CakeProp() { Id = 3, Name = "Животные", Price = 300 });
            attr.ListProp.Add(new CakeProp() { Id = 4, Name = "Шарики", Price = 400 });
            attr.ListProp.Add(new CakeProp() { Id = 5, Name = "Ленточки", Price = 500 });

            return attr;
        }

    }
}
