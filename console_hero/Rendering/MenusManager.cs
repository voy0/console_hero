namespace console_hero;

public class MenusManager{
    private List<IMenu> _menus = new List<IMenu>();

    public void RegisterMenu(IMenu menu)
    {
        _menus.Add(menu);
        
        if (_menus.Count == 1) 
        {
            menu.InFocus = true;
        }
    }

    public IMenu? GetFocusedMenu()
    {
        return _menus.FirstOrDefault(m => m.InFocus && m.IsEnabled);
        
    }
    public void ForceFocus(IMenu targetMenu)
    {
        foreach (var menu in _menus)
        {
            menu.InFocus = false;
        }
        targetMenu.InFocus = true;
    }

    public void FocusNext()
    {
        var activeMenus = _menus.Where(m => m.IsEnabled).ToList();

        if (activeMenus.Count == 0) return;

        if (activeMenus.Count == 1)
        {
            activeMenus[0].InFocus = true;
            return;
        }

        int currentIndex = activeMenus.FindIndex(m => m.InFocus);
        if (currentIndex != -1)
        {
            activeMenus[currentIndex].InFocus = false;
            int nextIndex = (currentIndex + 1) % activeMenus.Count;
            activeMenus[nextIndex].InFocus = true;   
        }
        else
        {
            activeMenus[0].InFocus = true;
        }
    }
}