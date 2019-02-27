using System.Collections.Generic;
using System;
using Microsoft.AspNetCore.Mvc;
using AnimalShelter.Models;

namespace AnimalShelter.Controllers
{
  public class TypesController : Controller
  {

    [HttpGet("/types")]
    public ActionResult Index()
    {
      List<Type> allTypes = Type.GetAll();
      return View(allTypes);
    }

    [HttpGet("/types/new")]
    public ActionResult New()
    {
      return View();
    }

    [HttpPost("/types")]
    public ActionResult Create(string typeName)
    {
      Type newType = new Type(typeName);
      List<Type> allTypes = Type.GetAll();
      return View("Index", allTypes);
    }

    [HttpGet("/types/{id}")]
    public ActionResult Show(int id)
    {
      Dictionary<string, object> model = new Dictionary<string, object>();
      Type selectedType = Type.Find(id);
      List<Animal> typeAnimals = selectedType.GetItems();
      model.Add("type", selectedType);
      model.Add("animals", typeAnimals);
      return View(model);
    }

    // This one creates new Items within a given Category, not new Categories:
    [HttpPost("/types/{typeId}/animals")]
    public ActionResult Create(int typeId, string animalName)
    {
      Dictionary<string, object> model = new Dictionary<string, object>();
      Type foundType = Type.Find(typeId);
      Animal newAnimal = new Animal(animalName);
      newAnimal.Save();
      foundType.AddItem(newAnimal);
      List<Animal> typeAnimals = foundType.GetAnimals();
      model.Add("animals", typeAnimals);
      model.Add("type", foundType);
      return View("Show", model);
    }

  }
}
