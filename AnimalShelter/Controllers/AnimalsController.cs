using Microsoft.AspNetCore.Mvc;
using AnimalShelter.Models;
using System.Collections.Generic;

namespace AnimalShelter.Controllers
{
  public class AnimalsController : Controller
  {

    [HttpGet("/types/{typeId}/animals/new")]
    public ActionResult New(int typeId)
    {
       Type type = Type.Find(typeId);
       return View(type);
    }

    [HttpGet("/types/{typeId}/animals/{animalId}")]
    public ActionResult Show(int typeId, int animalId)
    {
      Animal animal = Animal.Find(animalId);
      Dictionary<string, object> model = new Dictionary<string, object>();
      Type type = Type.Find(typeId);
      model.Add("animal", animal);
      model.Add("type", type);
      return View(model);
    }
  }
}
