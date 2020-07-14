using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeMenu_Class
{
    public class CafeMenuRepository
    {
        // Globally define _allMenuItems for all Methods
        // _allMenuItems is a list of type MenuItem. It contains the entire list of menu items
        List<MenuItem> _allMenuItems = new List<MenuItem>();

        public bool AddItemToMenu(MenuItem newMenuItem)
        {
            int menuListSizeBeforeCreate = _allMenuItems.Count;

            // add the new menu item to the menu list
            _allMenuItems.Add(newMenuItem);

            // sort the list of menu items
            _allMenuItems.Sort(delegate (MenuItem x, MenuItem y)
            {
                return x.MealNumber.CompareTo(y.MealNumber);
            });

            bool menuItemWasAdded = (_allMenuItems.Count > menuListSizeBeforeCreate) ? true : false;
            return menuItemWasAdded;
        }

        public bool DeleteMenuItem(MenuItem menuItemToRemove)
        {

            bool menuItemWasDeleted = _allMenuItems.Remove(menuItemToRemove);

            //bool menuItemWasDeleted = (_allMenuItems.Count < menuListSizeBeforeDelete) ? true : false;
            return menuItemWasDeleted;

        }

        public List<MenuItem> GetAllMenuItems()
        {
            return _allMenuItems;
        }

        public MenuItem GetMenuItemByMealNumber(int requestedMealNumber)
        {
            foreach(MenuItem thisMenuItem in _allMenuItems)
            {
                if(thisMenuItem.MealNumber == requestedMealNumber)
                {
                    return thisMenuItem;
                }
            }
            return null;
        }

        public List<MenuItem> DeleteAllMenuItems()
        {
            _allMenuItems.Clear();
            return _allMenuItems;
        }
    }
}
