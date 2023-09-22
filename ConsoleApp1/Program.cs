// See https://aka.ms/new-console-template for more information
using SelfieAWookie.Core.Selfies.Infrastructure.DataBase;
using SelfieAWookie.Core.Selfies.Infrastructure.DataLayers;
using SelfieAWookie.Core.Selfies.Interface.Infrastructure;

Console.WriteLine("Hello, World!");

var context = new SelfieDbContext();
var dataLayer = new SqlServerSelfieDataLayer(context);

/*foreach(var item in context.Selfies )
{
    Console.WriteLine(item.Title);
    //Console.WriteLine(item.Wookie.Surname);
}*/
var result = dataLayer.GetAll();
foreach(var layer in result)
{
    Console.WriteLine(layer.Title);
    //Console.WriteLine(layer.Wookie.Surname);
}


Console.ReadLine();