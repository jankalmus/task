using Application.DataAccess.Context;
using Application.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace Application.DataAccess.Seeding;

public static class Seeder
{
    public static void SeedDatabase(this WebApplication app)
    {
        using var serviceScope = app.Services.CreateScope();

        var context = serviceScope.ServiceProvider.GetService<ApplicationDbContext>();
        
        if (context is null) throw new ArgumentNullException(nameof(context));
        
        try
        {
            Console.WriteLine("INFO: Attempting to migrate database.");
                
            context.Database.Migrate();
                
            Console.WriteLine("INFO: Database migration completed.");
        }
        catch (Exception e)
        {
            Console.WriteLine($"ERROR: Database migration failed. Details: {e.Message}");
            throw;
        }
        
        SeedData(context);
    }
    
    /*
     *
     *
     * 	<option value="1">Manufacturing</option>
	<option value="19">&nbsp;&nbsp;&nbsp;&nbsp;Construction materials</option>
	<option value="18">&nbsp;&nbsp;&nbsp;&nbsp;Electronics and Optics</option>
	<option value="6">&nbsp;&nbsp;&nbsp;&nbsp;Food and Beverage</option>
	<option value="342">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Bakery &amp; confectionery products</option>
	<option value="43">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Beverages</option>
	<option value="42">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Fish &amp; fish products </option>
	<option value="40">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Meat &amp; meat products</option>
	<option value="39">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Milk &amp; dairy products </option>
	<option value="437">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Other</option>
	<option value="378">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Sweets &amp; snack food</option>
	
     */

    private static void SeedData(ApplicationDbContext? context)
    {
        if (context is null) throw new ArgumentNullException(nameof(context));

        if (context.Sectors.Any()) return;

        var sectors = new List<Sector>();

        var manufacturing = new Sector("Manufacturing", 1);
        
        sectors.Add(manufacturing);
        
        sectors.Add(new Sector("Construction Materials", 19, manufacturing));
        sectors.Add(new Sector("Electronics and Optics", 18, manufacturing));

        var foodAndBeverage = new Sector("Food and Beverage", 6, manufacturing);
        
        sectors.Add(foodAndBeverage);
        
	    sectors.Add(new Sector("Bakery & confectionery products", 342, foodAndBeverage));
	    sectors.Add(new Sector("Beverages", 43, foodAndBeverage));
	    sectors.Add(new Sector("Fish & fish products", 42, foodAndBeverage));
	    sectors.Add(new Sector("Meat & meat products", 40, foodAndBeverage));
	    sectors.Add(new Sector("Milk & dairy products", 39, foodAndBeverage));
	    sectors.Add(new Sector("Other", 437, foodAndBeverage));
	    sectors.Add(new Sector("Sweets & snack food", 378, foodAndBeverage));

	    var furniture = new Sector("Furniture", 13, manufacturing);

	    sectors.Add(furniture);
	    
	    sectors.Add(new Sector("Bathroom/sauna", 389, furniture));
	    sectors.Add(new Sector("Bedroom", 385, furniture));
	    sectors.Add(new Sector("Children's room", 390, furniture));
	    sectors.Add(new Sector("Kitchen", 98, furniture));
	    sectors.Add(new Sector("Living room", 101, furniture));
	    sectors.Add(new Sector("Office", 392, furniture));
	    sectors.Add(new Sector("Other (Furniture)", 394, furniture));
	    sectors.Add(new Sector("Outdoor", 341, furniture));
	    sectors.Add(new Sector("Project furniture", 99, furniture));

	    var machinery = new Sector("Machinery", 12, manufacturing);
	    
	    sectors.Add(machinery);
	    
	    sectors.Add(new Sector("Machinery components", 94, machinery));
	    sectors.Add(new Sector("Machinery equipment/tools", 14, machinery));
	    sectors.Add(new Sector("Manufacture of machinery", 224, machinery));

	    var maritime = new Sector("Maritime", 97, machinery);
	    
	    sectors.Add(maritime);
	    
	    sectors.Add(new Sector("Aluminum and steel workboats", 271, maritime));
	    sectors.Add(new Sector("Boat/Yacht building", 269, maritime));
	    sectors.Add(new Sector("Ship repair and conversion", 230, maritime));
	    
	    sectors.Add(new Sector("Metal structures", 93, machinery));
	    sectors.Add(new Sector("Other", 508, machinery));
	    sectors.Add(new Sector("Repair and maintenance service", 227, machinery));

	    var metalworking = new Sector("Metalworking", 11, manufacturing);
	    
	    sectors.Add(metalworking);
	    
	    sectors.Add(new Sector("Construction of metal structures", 67, metalworking));
	    sectors.Add(new Sector("Houses and buildings", 263, metalworking));
	    sectors.Add(new Sector("Metal products", 267, metalworking));

	    var works = new Sector("Metal works", 542, metalworking);
	    
	    sectors.Add(works);
	    
	    sectors.Add(new Sector("CNC-machining", 75, works));
	    sectors.Add(new Sector("Forgings, fasteners", 62, works));
	    sectors.Add(new Sector("Gas, Plasma, Laser cutting", 69, works));
	    sectors.Add(new Sector("MIG, TIG, Aluminum welding", 66, works));
	    
	    var plastic = new Sector("Plastic and Rubber", 9, manufacturing); 
	    
	    sectors.Add(plastic);
	    
	    sectors.Add(new Sector("Packaging", 54, plastic));
	    sectors.Add(new Sector("Plastic goods", 556, plastic));

	    var plasticTech = new Sector("Plastic processing technology", 559, plastic);
	    
	    sectors.Add(plasticTech);
	    
	    sectors.Add(new Sector("Blowing", 55, plasticTech));
	    sectors.Add(new Sector("Moulding", 57, plasticTech));
	    sectors.Add(new Sector("Plastics welding and processing", 53, plasticTech));
	    
	    sectors.Add(new Sector("Plastic profiles", 560, plastic));

	    var printing = new Sector("Printing", 5, manufacturing);
	    
	    sectors.Add(printing);
	    
	    sectors.Add(new Sector("Advertising", 148, printing));
	    sectors.Add(new Sector("Book/Periodicals printing", 150, printing));
	    sectors.Add(new Sector("Labelling and packaging printing", 145, printing));

	    var textile = new Sector("Textile and clothing", 7, manufacturing);
	    
	    sectors.Add(textile);
	    
	    sectors.Add(new Sector("Clothing", 44, textile));
	    sectors.Add(new Sector("Textile", 45, textile));

	    var wood = new Sector("Wood", 8, manufacturing);
	    
	    sectors.Add(wood);
	    
	    sectors.Add(new Sector("Other (Wood)", 337, wood));
	    sectors.Add(new Sector("Wooden building materials", 51, wood));
	    sectors.Add(new Sector("Wooden houses", 47, wood));

	    var other = new Sector("Other", 3);
        
        sectors.Add(other);
        
        sectors.Add(new Sector("Creative industries", 37, other));
        sectors.Add(new Sector("Energy technology", 29, other));
        sectors.Add(new Sector("Environment", 33, other));

        var service = new Sector("Service", 2);
        
        sectors.Add(service);
        
        sectors.Add(new Sector("Business services", 25, service));
        sectors.Add(new Sector("Engineering", 35, service));
        
        var itc = new Sector("Information Technology and Telecommunications", 28, service);
        
        sectors.Add(itc);
	        
	    sectors.Add(new Sector("Data processing, Web portals, E-marketing", 581, itc));
	    sectors.Add(new Sector("Programming, Consultancy", 576, itc));
	    sectors.Add(new Sector("Software, Hardware", 121, itc));
	    sectors.Add(new Sector("Telecommunications", 122, itc));

	    sectors.Add(new Sector("Tourism", 22, service));
	    sectors.Add(new Sector("Translation services", 141, service));

	    var logistics = new Sector("Transport and Logistics", 21, service);
		    
	    sectors.Add(logistics);
		    
	    sectors.Add(new Sector("Air", 111, logistics));
	    sectors.Add(new Sector("Rail", 114, logistics));
	    sectors.Add(new Sector("Road", 112, logistics));
	    sectors.Add(new Sector("Water", 113, logistics));

	    context.Sectors.AddRange(sectors);
        
        context.SaveChanges(); 
    }
}



