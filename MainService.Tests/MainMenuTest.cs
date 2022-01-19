using System.ComponentModel.Design;
using System.Linq;
using System.Reflection;
using MainService;
using Xunit;

namespace MyCli.Tests;

public class MainMenuTest {
    [Fact]
    public void TestGetMenuItems() {
        var service = new MenuService();
        var menuItems = service.getMenuItems();

        Assert.Equal(2, menuItems.Count());
    }
}
