using cakes.Entyties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cakes.Modules
{
    public class MainCommand
    {
        private string padding = "   ";
        private List<string> legendList = new();
        private int cursorPosition = 0;
        private int startIndex = 0;
        private CakeOrder order = new() { cakeOrderItems = new() };
        private Cake cake = new();
        private CakeAttr? attr = null;
        private int menuCount = 0;
        ConsoleKey key = new();
        private bool endOrder = false;
        
        public void Main()
        {
            cake = new Helper().FillNewCake();
            legendList = new Helper().FirstInfo();
            cursorPosition = legendList.Count;
            menuCount = cake.Cake_Attrs.Count;
            ShowCakeMenu();
           

            key = Console.ReadKey().Key;
            Console.CursorVisible = false;

            while (!endOrder)
            {
                if(attr == null)
                {
                    MoveMainMenu();
                }
                else
                {
                    MoveSubMainMenu();
                }
                
                if(!endOrder)
                    key = Console.ReadKey().Key;

            }
            
        }

        private void ShowLegend()
        {
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            foreach (var item in legendList)
            {
                Console.WriteLine(padding + item);
            }
            Console.ForegroundColor = ConsoleColor.White;
        }

        private void MoveMainMenu()
        {
            switch (key)
            {
                case ConsoleKey.Escape:
                    {
                        attr = null;
                        ShowCakeMenu();
                        break;
                    }
                case ConsoleKey.UpArrow:
                    {
                        //перемещение по меню

                        if (startIndex > 0)
                        {
                            startIndex--;
                            NavigateMenu(+1);
                        }

                        break;
                    }
                case ConsoleKey.DownArrow:
                    {
                        //перемещение по меню
                        if (startIndex < (menuCount-1))
                        {
                            startIndex++;
                            NavigateMenu(-1);
                        }

                        break;
                    }
                case ConsoleKey.Enter:
                    {
                        var menuItem = cake.Cake_Attrs.Find(x => x.Id == startIndex + 1);

                        if (menuItem != null)
                        {
                            if (menuItem.Id == 8)
                            {
                                Console.Clear();
                                endOrder = true;
                                break;
                            }
                            else if (menuItem.Id == 7)
                            {
                                //сформировать заказ
                                CreateOrder();
                            }
                            else
                            {
                                attr = menuItem;
                                ShowCakeSubMenu();
                            }
                        }

                        break;
                    }
                default:
                    {
                        startIndex = 0;
                        break;
                    }
            }
        }


        

        private void MoveSubMainMenu()
        {
            switch (key)
            {
                case ConsoleKey.Escape:
                    {
                        attr = null;
                        ShowCakeMenu();
                        break;
                    }
                case ConsoleKey.UpArrow:
                    {
                        //перемещение по меню

                        if (startIndex > 0)
                        {
                            startIndex--;
                            NavigateMenu(+1);
                        }

                        break;
                    }
                case ConsoleKey.DownArrow:
                    {
                        //перемещение по меню
                        if (startIndex < attr.ListProp.Count-1)
                        {
                            startIndex++;
                            NavigateMenu(-1);
                        }

                        break;
                    }
                case ConsoleKey.Enter:
                    {
                        var menuItem = attr.ListProp.Find(x => x.Id == startIndex + 1);

                        if (menuItem != null)
                        {

                            var ordrItem = order.cakeOrderItems.Where(x => x.attrName.Id == attr.Id).FirstOrDefault();

                            if(ordrItem != null)
                            {
                                ordrItem.CakeProp = menuItem;
                            }
                            else
                            {
                                ordrItem = new CakeOrderItem();
                                ordrItem.CakeProp = menuItem;
                                ordrItem.attrName = attr;
                                order.cakeOrderItems.Add(ordrItem);
                            }

                            attr = null;
                            startIndex = 0;
                            ShowCakeMenu();

                        }

                        break;
                    }
                default:
                    {
                        startIndex = 0;
                        break;
                    }
            }
        }


        private void ShowCakeMenu()
        {
            Console.Clear();
            ShowLegend();
            foreach (var cake in cake.Cake_Attrs)
            {
                Console.WriteLine(padding + cake.Id + " " + cake.AttrName);
            }
            PrintOrder();
            Console.SetCursorPosition(0, cursorPosition + startIndex);
            Console.Write("=>");

            
        }

        private void ShowCakeSubMenu()
        {
            Console.Clear();
            startIndex = 0;
            ShowLegend();
            cursorPosition = legendList.Count;

            foreach (var item in attr.ListProp)
            {
                Console.WriteLine(padding + item.Id + " " + item.Name + ", цена = " + item.Price);
            }
            PrintOrder();
            Console.SetCursorPosition(0, cursorPosition + startIndex);
            Console.Write("=>");
        }

        private void NavigateMenu(int navIndex)
        {
            Console.SetCursorPosition(0, cursorPosition + startIndex);
            Console.Write("=>");
            Console.SetCursorPosition(0, cursorPosition + startIndex + navIndex);
            Console.Write("  ");
        }

        private void PrintOrder()
        {
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("Детали заказа:");

            if (order.cakeOrderItems.Count == 0)
            {
                Console.WriteLine("Общая цена = 0");
                return;
            }
                

            var resOrder = "";
            double totalSum = 0;

            foreach(var item in order.cakeOrderItems)
            {
                resOrder += item.attrName.AttrName + "-" + item.CakeProp.Name + ", ";
                totalSum += item.CakeProp.Price;
            }


            Console.WriteLine("Общая цена = " + totalSum);
            Console.WriteLine("Состав торта = " + resOrder);
        }

        private void CreateOrder()
        {
            string ordersPath = Directory.GetCurrentDirectory() + @"\orders\";

            if (!Directory.Exists(ordersPath))
                Directory.CreateDirectory(ordersPath);

            string fileNamePath = ordersPath + DateTime.Now.ToString("dd_MM_yyyy") + "_order.txt";

            if (!File.Exists(fileNamePath))
            {
                var file = File.Create(fileNamePath);
                file.Dispose();
            }

            using (StreamWriter sw = new StreamWriter(File.Open(fileNamePath, FileMode.Append), Encoding.Unicode))
            {
                var resOrder = "";
                double totalSum = 0;

                foreach (var item in order.cakeOrderItems)
                {
                    resOrder += item.attrName.AttrName + "-" + item.CakeProp.Name + ", ";
                    totalSum += item.CakeProp.Price;
                }

                sw.WriteLine("Заказ от " + DateTime.Now.ToString("dd.MM.yyyy HH:mm"));
                sw.WriteLine("Общая цена = " + totalSum);
                sw.WriteLine("Состав торта = " + resOrder);
                sw.WriteLine();
            }

            attr = null;
            order = new CakeOrder() { cakeOrderItems = new List<CakeOrderItem>() };
            startIndex = 0;

            Console.Clear();
            ShowLegend();
            Console.WriteLine("Ура! заказ сформирован.");
            Console.WriteLine("Файл заказа находится по пути: " + fileNamePath);
            Console.WriteLine("Нажмите любую клавишу для возврата в меню.");
            key = Console.ReadKey().Key;
            ShowCakeMenu();

        }
    }
}
