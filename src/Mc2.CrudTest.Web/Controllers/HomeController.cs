using Mc2.CrudTest.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Mc2.CrudTest.Web.Services;

namespace Mc2.CrudTest.Web.Controllers;

public class HomeController : Controller
{
    private readonly ICustomerWebServices _customerWebServices;

    public HomeController(ICustomerWebServices customerWebServices)
    {
        _customerWebServices = customerWebServices;
    }

    public async Task<IActionResult> Index(CancellationToken cancellationToken)
    {
        var customers = await _customerWebServices.GetCustomerListAsync(cancellationToken);

        return View(customers);
    }


    [HttpGet("Add")]
    public IActionResult AddCustomer() => View(new CreateCustomerViewModel());


    [HttpPost("Add")]
    public async Task<IActionResult> AddCustomer(CreateCustomerViewModel model, CancellationToken cancellationToken)
    {
        if (ModelState.IsValid == false) return View(model);

        var result = await _customerWebServices.AddCustomerAsync(model.Customer, cancellationToken);

        if (result.Errors != null && result.Errors.Any())
            return View(result);

        return RedirectToAction("Index");
    }

    [HttpGet("Edit/{id}")]
    public async Task<IActionResult> EditCustomer(Guid id, CancellationToken cancellationToken)
    {
        var customer = await _customerWebServices.GetCustomerAsync(id, cancellationToken);

        return View(new UpdateCustomerViewModel
        {
            Customer = customer
        });
    }


    [HttpPost("Edit")]
    public async Task<IActionResult> EditCustomer(UpdateCustomerViewModel updateCustomerViewModel,
        CancellationToken cancellationToken)
    {
        if (ModelState.IsValid == false) return View(updateCustomerViewModel);

        await _customerWebServices.UpdateCustomerAsync(updateCustomerViewModel.UpdateCustomer, cancellationToken);

        return RedirectToAction("Index");
    }

    [HttpGet("Delete/{id}")]
    public async Task<IActionResult> DeleteCustomer(Guid id, CancellationToken cancellationToken)
    {
        await _customerWebServices.DeleteCustomerAsync(id, cancellationToken);

        return RedirectToAction("Index");
    }
}