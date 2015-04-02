using System.Collections.Generic;
using System.Windows.Input;
using Cirrious.MvvmCross.ViewModels;

namespace WTM.Mobile.Core.ViewModels
{
    public class TestViewModel : ViewModelBase
    {
        public TestViewModel(IContext context)
            : base(context)
        { }

        public void Init()
        {
            Items = new List<Item>
            {
                new Item{Name = "Duck", Price = 21.00, Quantity = 1},
                new Item{Name = "Brush", Price = 7.50, Quantity = 4},
                new Item{Name = "Stuff", Price = 6.20, Quantity = 5},
            };
        }

        public List<Item> Items
        {
            get { return items; }
            set
            {
                items = value; 
                RaisePropertyChanged(() => Items);
            }
        }
        private List<Item> items;

        public ICommand ItemClickCommand
        {
            get
            {
                if (itemClickCommand == null)
                {
                    itemClickCommand = new MvxCommand<Item>(item =>
                    {
                        // Tada
                    });
                }
                return itemClickCommand;
            }
        }
        private MvxCommand<Item> itemClickCommand;
    }

    public class Item
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
    }
}