using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MonProjet.Models;



public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly AppDbContext _context;

    
    public HomeController(ILogger<HomeController> logger, AppDbContext context)
    {
        _logger = logger;
        _context = context;
    }

    
    public IActionResult Create()
    {
        return View();
    }

    
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(Personne personne)
    {
        if (ModelState.IsValid)
        {
            _context.Add(personne);  
            await _context.SaveChangesAsync();  
            return RedirectToAction(nameof(Index));  
        }
        return View(personne);  
    }

    
    public async Task<IActionResult> Index()
    {
        var personnes = await _context.Personnes.ToListAsync(); 
        return View(personnes); 
    }

    
    public IActionResult Privacy()
    {
        return View();
    }


public async Task<IActionResult> Edit(int id)
    {
        var personne = await _context.Personnes.FindAsync(id);
        
        if (personne == null)
        {
            return NotFound();
        }

        return View(personne);
    }


    
[HttpPost]
[ValidateAntiForgeryToken]
public async Task<IActionResult> Edit(int id, Personne personne)
{
    if (id != personne.Id)
    {
        return NotFound();  
    }

    if (ModelState.IsValid)
    {
        try
        {
            
            _context.Update(personne);
            await _context.SaveChangesAsync();  
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!PersonneExists(personne.Id))
            {
                return NotFound();  
            }
            else
            {
                throw;  
            }
        }

        return RedirectToAction(nameof(Index));  
    }
    return View(personne);  
}


private bool PersonneExists(int id)
{
    return _context.Personnes.Any(e => e.Id == id);
}









    public async Task<IActionResult> Details(int id)
    {
        var personne = await _context.Personnes.FindAsync(id);
        
        if (personne == null)
        {
            return NotFound();
        }

        return View(personne);
    }



    public async Task<IActionResult> Delete(int id)
    {
        var personne = await _context.Personnes.FindAsync(id);

        if (personne != null)
        {
            _context.Personnes.Remove(personne);  
            await _context.SaveChangesAsync();    
        }

        return RedirectToAction(nameof(Index));  
    }





    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }







}
