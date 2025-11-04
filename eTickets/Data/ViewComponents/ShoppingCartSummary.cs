using eTickets.Data.Cart;
using Microsoft.AspNetCore.Mvc;

namespace eTickets.Data.ViewComponents;

public class ShoppingCartSummary: ViewComponent
{
    private readonly ShoppingCart _shoppingCart;
    public ShoppingCartSummary(ShoppingCart shoppingCart)
    {
        _shoppingCart = shoppingCart;
    }

    public IViewComponentResult Invoke()
    {
        var items = _shoppingCart.GetShoppingCartItems();
        _shoppingCart.ShoppingCartItems = items;
        var total = _shoppingCart.GetShoppingCartTotal();
        ViewBag.ShoppingCartTotal = total;
        return View(_shoppingCart);
    }
}
